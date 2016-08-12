
#Region "Imports"

Imports System.Text
Imports System.IO.Ports

#End Region

Module Module_Functions

#Region "Statements"

    Public WithEvents _SerialPort As New System.IO.Ports.SerialPort
    Public WithEvents _Seriallist As New System.Windows.Forms.ListBox
    Public WithEvents _ToolTip As New System.Windows.Forms.ToolTip

    Public WithEvents _TimerNow As New System.Windows.Forms.Timer
    Public WithEvents _TimerConnected As New System.Windows.Forms.Timer
    Public WithEvents _TimerDisconnected As New System.Windows.Forms.Timer
    Public WithEvents _TimerUsartTx As New System.Windows.Forms.Timer
    Public WithEvents _TimerUsartRx As New System.Windows.Forms.Timer

    Public WithEvents _TimerPanelTx As New System.Windows.Forms.Timer
    Public WithEvents _TimerPanelRx As New System.Windows.Forms.Timer

#End Region

#Region "Declarations"

    'file *.ini
    Private Declare Auto Function GetPrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpDefault As String, ByVal lpReturnedString As StringBuilder, ByVal nSize As Integer, ByVal lpFileName As String) As Integer
    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

    'Process
    Public Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long

#End Region

#Region "File *.ini"

    'file read *.ini
    Public Function LeArquivoINI(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String

        Const MAX_LENGTH As Integer = 500
        Dim string_builder As New StringBuilder(MAX_LENGTH)

        Try
            GetPrivateProfileString(section_name, key_name, default_value, string_builder, MAX_LENGTH, file_name)
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH: mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

        Return string_builder.ToString()

    End Function

    'File name *.ini
    Public Function NomeArquivoINI(ByVal Diretorio As String) As String


        Dim nome_arquivo_ini As String = AppDomain.CurrentDomain.BaseDirectory().Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 3, 3)

        Try
            nome_arquivo_ini = nome_arquivo_ini.Substring(0, nome_arquivo_ini.LastIndexOf("\"))
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH: mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

        Return nome_arquivo_ini & Diretorio

    End Function

    Public Sub CreatFileConfig()

        Try
            Dim nome_arquivo_ini As String = SGS_Library.NomeArquivoINI(DirConfig)

            WriteFileChecksum("Parameters", "Parameter0010", FormTop, nome_arquivo_ini)
            WriteFileChecksum("Parameters", "Parameter0011", FormLeft, nome_arquivo_ini)

            WriteFileChecksum("Parameters", "Parameter0020", TimerNowInterval, nome_arquivo_ini)
            WriteFileChecksum("Parameters", "Parameter0021", TimerConnectedInterval, nome_arquivo_ini)
            WriteFileChecksum("Parameters", "Parameter0022", TimerDisconnectedInterval, nome_arquivo_ini)
            WriteFileChecksum("Parameters", "Parameter0023", TimerUsartTxInterval, nome_arquivo_ini)
            WriteFileChecksum("Parameters", "Parameter0024", TimerUsartRxInterval, nome_arquivo_ini)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Function ReadFileChecksum(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String

        Try
            Dim ValName As String
            Dim ValChecksum As Integer

            Dim read_data As String = LeArquivoINI(file_name, section_name, key_name, default_value)

            If Strings.Left(read_data, 1) = "@" And Strings.Right(read_data, 1) = "#" Then

                read_data = read_data.Substring(1, read_data.Length - 2)

                ValName = read_data.Substring(0, read_data.IndexOf("%"))
                ValChecksum = Strings.Right(read_data, 3)

                Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(ValName)

                Dim checksum As Long
                Dim datacalculations As Long

                For i As Byte = 0 To ValName.Length - 1
                    datacalculations = array(i) * (i + 1)
                    checksum += datacalculations
                Next

                checksum = checksum Mod 99

                If checksum = Convert.ToInt16(ValChecksum) Then

                    Return ValName
                    Exit Function

                Else

                    default_value = default_value.Substring(1, default_value.Length - 2)
                    default_value = default_value.Substring(0, default_value.IndexOf("%"))

                    WriteFileChecksum(section_name, key_name, default_value.Substring(0, default_value.IndexOf(" ")), file_name)

                    Return default_value
                    Exit Function

                End If

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Function

    Public Sub WriteFileChecksum(ByVal section_name As String, ByVal key_name As String, ByVal val_name As String, ByVal file_name As String)

        Try

            For i As Byte = 0 To 69 - val_name.Length - 1
                val_name += " "
            Next

            Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(val_name)

            Dim checksum As Long
            Dim datacalculations As Long
            Dim checksumstring As String = ""

            For i As Byte = 0 To val_name.Length - 1
                datacalculations = array(i) * (i + 1)
                checksum += datacalculations
            Next

            checksum = checksum Mod 99

            For i As Byte = 0 To 3 - checksum.ToString.Length - 1
                checksumstring += "0"
            Next

            checksumstring += checksum.ToString

            WritePrivateProfileString(section_name, key_name, "@" + val_name + "%" + checksumstring + "#", file_name)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try
    End Sub

#End Region

#Region "Controls"

    Public Sub BootSettings()

        Try

            Dim nome_arquivo_ini As String = SGS_Library.NomeArquivoINI(DirConfig)

            SGS_Library.Language = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0000", "@English                                                              %058#")
            SGS_Library.Language = SGS_Library.Language.Substring(0, SGS_Library.Language.IndexOf(" "))
            SGS_Library.ReadLanguageLibrary()

            FormTop = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0010", "@100                                                                  %058#")
            FormLeft = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0011", "@250                                                                  %069#")

            TimerNowInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0020", "@100                                                                  %058#")
            TimerConnectedInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0021", "@1500                                                                 %033#")
            TimerDisconnectedInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0022", "@1500                                                                 %033#")
            TimerUsartTxInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0023", "@100                                                                  %058#")
            TimerUsartRxInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "Parameter0024", "@100                                                                  %058#")

            If Not System.IO.File.Exists(nome_arquivo_ini) Then

                CreatFileConfig()
                FormMessageBox(5)

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH: mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub BootControls()

        Try
            UsartConnected = False
            FileSystem = 0

            If FormLeft < 0 Or FormLeft > My.Computer.Screen.Bounds.Width - 328 Then FormLeft = 250
            If FormTop < 0 Or FormTop > My.Computer.Screen.Bounds.Height - 689 Then FormTop = 100

            With Form_Controller
                .Location = New Point(FormLeft, FormTop)
                .ButtonSize.Text = "-"
                .Size = New Size(328, 689)
            End With

            With _TimerNow
                .Enabled = True
                .Interval = TimerNowInterval
            End With

            With _TimerConnected
                .Enabled = True
                .Interval = TimerConnectedInterval
                .Stop()
            End With

            With _TimerDisconnected
                .Enabled = True
                .Interval = TimerDisconnectedInterval
                .Stop()
            End With

            With _TimerUsartTx
                .Enabled = True
                .Interval = TimerUsartTxInterval
                .Stop()
            End With

            With _TimerUsartRx
                .Enabled = True
                .Interval = TimerUsartRxInterval
                .Stop()
            End With

            With _TimerPanelTx
                .Enabled = True
                .Interval = 50
                .Stop()
            End With

            With _TimerPanelRx
                .Enabled = True
                .Interval = 50
                .Stop()
            End With

            RecipeControl = False

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub WriteLocation(_form As System.Windows.Forms.Form)

        Try
            Dim nome_arquivo_ini As String = SGS_Library.NomeArquivoINI(DirConfig)

            WriteFileChecksum("Parameters", "Parameter0010", _form.Top, nome_arquivo_ini)
            WriteFileChecksum("Parameters", "Parameter0011", _form.Left, nome_arquivo_ini)
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub
#End Region

#Region "Forms"

    Public Sub LanguageForm(_form As System.Windows.Forms.Form)

        Try
            Select Case _form.Name

                Case Is = "Form_Controller"

                    With Form_Controller
                        .ButtonClose.Text = SGS_Library.Label0000
                        .ButtonConnect.Text = SGS_Library.Label0002
                        .ButtonCreateRecipes.Text = SGS_Library.label0022

                        .Label0002.Text = SGS_Library.Label0006
                        .Label0003.Text = SGS_Library.Label0007
                        .Label0004.Text = SGS_Library.Label0008
                        .Label0005.Text = SGS_Library.Label0013
                        .Label0006.Text = SGS_Library.Label0014
                        .Label0007.Text = SGS_Library.Label0015
                        .Label0008.Text = SGS_Library.Label0016
                        .Label0009.Text = SGS_Library.Label0017
                        .Label0010.Text = SGS_Library.Label0018
                        .Label0011.Text = SGS_Library.Label0018
                        .Label0012.Text = SGS_Library.Label0018
                        .Label0013.Text = SGS_Library.Label0018
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_Controller.ButtonClose, SGS_Library.Label0001)
                            .SetToolTip(Form_Controller.ButtonConnect, SGS_Library.Label0003)
                            .SetToolTip(Form_Controller.ButtonCreateRecipes, SGS_Library.Label0023)
                        End With
                    End With

            End Select

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub FormMouseDown(_form As System.Windows.Forms.Form)

        Try
            drag = True
            mousex = System.Windows.Forms.Cursor.Position.X - _form.Left
            mousey = System.Windows.Forms.Cursor.Position.Y - _form.Top
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub FormMouseMove(_form As System.Windows.Forms.Form)

        Try
            If drag Then
                _form.Top = System.Windows.Forms.Cursor.Position.Y - mousey
                _form.Left = System.Windows.Forms.Cursor.Position.X - mousex
            End If
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub FormMouseUp()

        Try
            drag = False
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

#Region "Threading"

    Public Sub _TimerNow_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerNow.Tick

        Try
            Form_Controller.LabelHour.Text = Format(Now, "HH:mm:ss")
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub _TimerConnected_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerConnected.Tick

        Try
            _TimerConnected.Stop()

            If UsartConnected = False Then

                If UsartRxControl < 3 Then
                    UsartRxControl += 1
                Else
                    UsartRxControl = 0
                    UsartPorts += 1
                End If

                If _Seriallist.Items.Count > 0 And UsartPorts <= _Seriallist.Items.Count - 1 Then

                    Try

                        _Seriallist.SelectedIndex = UsartPorts
                        SerialPortSetup()

                        With _SerialPort
                            .Open()
                            .Write(vbLf)
                        End With

                        UsartTx = "WC00001"
                        _TimerUsartTx.Start()

                    Catch ex As Exception

                        MessageBox.Show(ex.Message)

                    End Try

                Else

                    FormMessageBox(3)

                    With Form_Controller
                        .ButtonConnect.Enabled = True
                        .ButtonClose.Enabled = True
                    End With

                End If

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub _TimerDisconnected_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerDisconnected.Tick

        Try
            _TimerDisconnected.Stop()
            SerialPortForceDisconnected()

            FormMessageBox(2)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub _TimerUsartTx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerUsartTx.Tick

        Try
            _TimerUsartTx.Stop()

            If UsartConnected = False Then
                SerialPortConnect(UsartTx)
                _TimerConnected.Start()
            Else
                SerialPortDataSend(UsartTx)
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub _TimerUsartRx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerUsartRx.Tick

        Try
            _TimerUsartRx.Stop()

            If UsartConnected = True Then

                If UsartRxTimeout < 3 Then
                    _TimerUsartTx.Start()
                    UsartRxTimeout += 1
                Else
                    _TimerDisconnected.Start()
                    ConnectDevice()
                End If

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub _TimerPanelTx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerPanelTx.Tick

        Try
            _TimerPanelTx.Stop()
            Form_Controller.PanelTx.BackColor = System.Drawing.Color.Transparent
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub _TimerPanelRx_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _TimerPanelRx.Tick

        Try
            _TimerPanelRx.Stop()
            Form_Controller.PanelRx.BackColor = System.Drawing.Color.Transparent
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub
#End Region

#Region "SerialPort controller"

    Public Sub ConnectDevice()

        Try
            UsartRxControl = 0
            UsartRxTimeout = 0

            If UsartConnected = False Then

                UsartPorts = 0
                SerialPortGetNames()
                _TimerConnected.Start()

                With Form_Controller
                    .ButtonConnect.Enabled = False
                    .ButtonClose.Enabled = False
                End With

            Else

                UsartTx = "WC00000"
                _TimerUsartTx.Start()

                Form_Controller.ButtonConnect.Enabled = False
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialPortForceDisconnected()

        Try
            _TimerConnected.Stop()
            _TimerUsartTx.Stop()
            _TimerUsartRx.Stop()

            UsartConnected = False
            RecipeControl = False

            UsartRx = ""

            With Form_Controller.ButtonConnect
                .Text = "Connect"
                .Enabled = True
            End With

            RemoveHandler _SerialPort.DataReceived, AddressOf Form_Controller.DataReceivedHandler
            Application.DoEvents()

            If _SerialPort.IsOpen Then
                With _SerialPort
                    .DiscardInBuffer()
                    .DiscardOutBuffer()
                    .Close()
                    .Dispose()
                End With
            End If

            _ToolTip.SetToolTip(Form_Controller.ButtonConnect, SGS_Library.Label0003)
            Form_Controller.ButtonClose.Enabled = True

            _Seriallist.Items.Clear()

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialPortGetNames()

        Try
            _Seriallist.Items.Clear()

            For Each portname As String In My.Computer.Ports.SerialPortNames
                _Seriallist.Items.Add(portname)
            Next

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialPortSetup()

        Try
            RemoveHandler _SerialPort.DataReceived, AddressOf Form_Controller.DataReceivedHandler
            Application.DoEvents()

            If _SerialPort.IsOpen Then
                With _SerialPort
                    .DiscardInBuffer()
                    .DiscardOutBuffer()
                    .Close()
                    .Dispose()
                End With
            End If

            With _SerialPort
                .PortName = _Seriallist.SelectedItem
                .BaudRate = 115200
                .DataBits = 8
                .Parity = Parity.None
                .StopBits = StopBits.One
                .Handshake = Handshake.None
                .Encoding = System.Text.Encoding.Default
                .RtsEnable = False
                AddHandler _SerialPort.DataReceived, AddressOf Form_Controller.DataReceivedHandler

            End With

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialPortConnect(SerialData As String)

        Try
            Form_Controller.PanelTx.BackColor = System.Drawing.Color.DeepSkyBlue
            _SerialPort.Write(SerialData + vbLf)
            _TimerPanelTx.Start()
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialPortDataSend(SerialData As String)

        Try
            For i As Byte = 0 To 69 - SerialData.Length - 1
                SerialData += " "
            Next

            Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(SerialData)

            Dim checksum As Long
            Dim datacalculations As Long
            Dim checksumstring As String = ""

            For i As Byte = 0 To SerialData.Length - 1
                datacalculations = array(i) * (i + 1)
                checksum += datacalculations
            Next

            checksum = checksum Mod 99

            For i As Byte = 0 To 3 - checksum.ToString.Length - 1
                checksumstring += "0"
            Next

            checksumstring += checksum.ToString

            Form_Controller.PanelTx.BackColor = System.Drawing.Color.DeepSkyBlue
            _SerialPort.Write("@" + SerialData + "%" + checksumstring + "#" + vbLf)
            _TimerPanelTx.Start()
            _TimerUsartRx.Start()

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialRead()

        Try
            Dim SerialData As String
            Dim SerialChecksum As Integer

            _TimerUsartRx.Stop()
            _TimerPanelRx.Start()

            With Form_Controller
                .TextBoxReceiver.Text = UsartRx
                .PanelRx.BackColor = System.Drawing.Color.DeepSkyBlue
            End With

            UsartRxTimeout = 0

            If Strings.Left(UsartRx, 1) = "@" And Strings.Right(UsartRx, 1) = "#" Then

                UsartRx = UsartRx.Substring(1, UsartRx.Length - 2)

                SerialData = UsartRx.Substring(0, UsartRx.IndexOf("%"))
                SerialChecksum = Strings.Right(UsartRx, 3)

                Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(SerialData)

                Dim checksum As Long
                Dim datacalculations As Long

                For i As Byte = 0 To SerialData.Length - 1
                    datacalculations = array(i) * (i + 1)
                    checksum += datacalculations
                Next

                checksum = checksum Mod 99

                If checksum = Convert.ToInt16(SerialChecksum) Then
                    UsartRxControl = 0
                    SerialDecoder(SerialData)
                Else
                    If UsartRxControl < 3 Then
                        _TimerUsartTx.Start()
                        UsartRxControl = UsartRxControl + 1
                    Else
                        _TimerDisconnected.Start()
                        ConnectDevice()
                    End If

                End If

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialDecoder(Decoder As String)

        Try

            Dim Header As String = Decoder.Substring(0, 2)
            Dim Control As String = Decoder.Substring(2, 3)
            Dim Data As String = Decoder.Substring(5, 64)

            If Header.Equals("RC") Then

                If Control.Equals("000") Then
                    If Data.Substring(0, 2) = "01" Then
                        UsartConnected = True
                        UsartRx = ""
                        With Form_Controller.ButtonConnect
                            .Text = SGS_Library.Label0004
                            .Enabled = True
                        End With

                        _TimerConnected.Stop()

                        _ToolTip.SetToolTip(Form_Controller.ButtonConnect, SGS_Library.Label0005)

                        FormMessageBox(0)

                        DeviceVersion()
                        Exit Sub
                    End If

                    If Data.Substring(0, 2) = "00" Then
                        UsartConnected = False
                        RecipeControl = False

                        UsartRx = ""

                        RemoveHandler _SerialPort.DataReceived, AddressOf Form_Controller.DataReceivedHandler
                        Application.DoEvents()

                        If _SerialPort.IsOpen Then
                            With _SerialPort
                                .DiscardInBuffer()
                                .DiscardOutBuffer()
                                .Close()
                                .Dispose()
                            End With
                        End If

                        With Form_Controller
                            .Label0010.Text = SGS_Library.Label0018
                            .Label0011.Text = SGS_Library.Label0018
                            .Label0012.Text = SGS_Library.Label0018
                            .Label0013.Text = SGS_Library.Label0018
                            With .ButtonConnect
                                .Text = SGS_Library.Label0002
                                .Enabled = True
                            End With
                        End With

                        _ToolTip.SetToolTip(Form_Controller.ButtonConnect, SGS_Library.Label0003)
                        Form_Controller.ButtonClose.Enabled = True

                        _TimerDisconnected.Stop()
                        _TimerConnected.Stop()
                        _TimerUsartTx.Stop()
                        _TimerUsartRx.Stop()

                        FormMessageBox(1)

                        Exit Sub
                    End If
                End If

            End If

            If Header.Equals("RV") Then
                If Control.Equals("000") Then

                    UsartRx = ""
                    With Form_Controller
                        .Label0010.Text = "SGS-" & Data.Substring(Data.IndexOf("P") + 2, 3)
                        .Label0011.Text = Data.Substring(Data.IndexOf("S") + 2, 4)
                        .Label0012.Text = Data.Substring(Data.IndexOf("H") + 2, 4)
                        .Label0013.Text = Data.Substring(Data.IndexOf("F") + 2, 4)
                    End With
                End If

                Exit Sub
            End If

            If Header.Equals("RR") Then

                'RecordRecipe() 'Arrumar

                If RecipeControl = True And RecipeIndex < 500 Then
                    RecipeIndex = RecipeIndex + 1
                    'ReadAllRecipes() 'Arrumar
                Else
                    RecipeControl = False
                End If

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub DeviceVersion()

        Try

            UsartTx = "RV000"

            SerialPortDataSend(UsartTx)

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

#Region "Messages"

    Public Sub FormMessageBox(_message As Integer)

        LoadMessage = _message
        If Form_MessageBox.IsHandleCreated = True Then
            MessageLoad()
        Else
            Form_MessageBox.ShowDialog()
        End If

    End Sub

    Public Sub MessageLoad()

        Try

            With Form_MessageBox
                .Activate()
                .Visible = True
                .Size = New Size(534, 248)
                .ButtonSize.Text = "-"
                .Label0001.Text = SGS_Library.Label0009
                .Button01.Visible = False
                .Button02.Visible = False
                .Button03.Visible = False
            End With

            Select Case LoadMessage

                Case Is = 0
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0000
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 1
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0001
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 2
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0002
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 3
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0003
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 4
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0004
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0011
                        End With
                        With .Button02
                            .Visible = True
                            .Text = SGS_Library.Label0012
                            With _ToolTip
                                .IsBalloon = True
                                .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0021)
                                .SetToolTip(Form_MessageBox.Button02, SGS_Library.Label0020)
                            End With
                        End With
                    End With

                Case Is = 5
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0005
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

            End Select

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub FormMessageBoxButton(_button As Integer)

        Try

            Select Case _button

                Case Is = 1
                    Select Case LoadMessage

                        Case Is = 0
                            Form_MessageBox.Dispose()

                        Case Is = 1
                            Form_MessageBox.Dispose()

                        Case Is = 2
                            Form_MessageBox.Dispose()

                        Case Is = 3
                            Form_MessageBox.Dispose()

                        Case Is = 4
                            Form_MessageBox.Dispose()

                        Case Is = 5
                            Form_MessageBox.Dispose()

                    End Select

                Case Is = 2
                    Select Case LoadMessage

                        Case Is = 4
                            Form_MessageBox.Dispose()
                            ConnectDevice()

                    End Select

                Case Is = 3
                    Select Case LoadMessage

                    End Select

            End Select

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region



    Public Sub FileProperties()

        Try

            With Form_CreateFile
                .Activate()
                .Visible = True
                .Size = New Size(534, 248)
                .ButtonSize.Text = "-"
                .Label0001.Text = SGS_Library.Label0024
                .Label0002.Text = SGS_Library.Label0017
                .Label0003.Text = SGS_Library.Label0030

                .ButtonBrowse.Text = SGS_Library.Label0027
                .ButtonConfirm.Text = SGS_Library.Label0028
                .ButtonCancel.Text = SGS_Library.Label0029

                .ButtonConfirm.Enabled = False

                .LabelDirectory.Text = ""
                .ComboBoxFirmware.Items.Clear()
                .ComboBoxFirmware.Items.AddRange(SGS_Firmware.FirmwareSelect)
                .ComboBoxFirmware.SelectedIndex = 0
            End With




        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SaveFileDirectory()

        Try

            Dim _saveFileDialog As New SaveFileDialog()

            _saveFileDialog.Filter = SGS_Library.Label0025
            _saveFileDialog.Title = SGS_Library.Label0026
            _saveFileDialog.FilterIndex = 1
            _saveFileDialog.ShowDialog()

            If _saveFileDialog.FileName <> "" Then

                FileDirectory = System.IO.Path.GetDirectoryName(_saveFileDialog.FileName)
                FileName = System.IO.Path.GetFileName(_saveFileDialog.FileName)
                FileSystem = _saveFileDialog.FilterIndex

                If Strings.Right(FileDirectory, 1) = "\" Then
                    FileDirectory = FileDirectory.Substring(0, FileDirectory.Length - 1)
                End If

                With Form_CreateFile
                    .LabelDirectory.Text = FileDirectory & "\" & FileName
                    .ButtonConfirm.Enabled = True
                End With
            End If


        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

End Module

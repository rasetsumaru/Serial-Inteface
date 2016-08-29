
#Region "Imports"

Imports System.Text
Imports System.IO.Ports

#End Region

Module Module_Functions

#Region "Statements"

    Public WithEvents _SerialPort As New System.IO.Ports.SerialPort
    Public WithEvents _Seriallist As New System.Windows.Forms.ListBox

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

    Public Function ReadFileChecksum(ByVal file_name As String, ByVal section_name As String, ByVal key_name As String, ByVal default_value As String) As String

        Try
            Dim ValName As String
            Dim ValChecksum As Integer

            Dim read_data As String = LeArquivoINI(file_name, section_name, key_name, default_value)

            If Strings.Left(read_data, 1) = "@" And Strings.Right(read_data, 1) = "#" Then

                read_data = read_data.Substring(1, read_data.Length - 2)

                ValName = key_name & read_data.Substring(0, read_data.IndexOf("%"))
                ValChecksum = Strings.Right(read_data, 3)

                Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(ValName)

                Dim checksum As Long
                Dim datacalculations As Long

                For i As Byte = 0 To ValName.Length - 1
                    datacalculations = array(i) * (i + 1)
                    checksum += datacalculations
                Next

                checksum = checksum Mod 99

                If checksum = Convert.toint32(ValChecksum) Then

                    Return Strings.Right(ValName, 64)
                    Exit Function

                Else

                    WriteFileChecksum(section_name, key_name, default_value, file_name)

                    Return default_value
                    Exit Function

                End If

            Else

                WriteFileChecksum(section_name, key_name, default_value, file_name)

                Return default_value
                Exit Function

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Function

    Public Sub WriteFileChecksum(ByVal section_name As String, ByVal key_name As String, ByVal val_name As String, ByVal file_name As String)

        Try

            For i As Byte = 1 To 64 - val_name.Length
                val_name += " "
            Next

            Dim val_checksum As String = key_name & val_name

            Dim array() As Byte = System.Text.Encoding.ASCII.GetBytes(val_checksum)

            Dim checksum As Long
            Dim datacalculations As Long
            Dim checksumstring As String = ""

            For i As Byte = 0 To val_checksum.Length - 1
                datacalculations = array(i) * (i + 1)
                checksum += datacalculations
            Next

            checksum = checksum Mod 99

            For i As Byte = 0 To 3 - checksum.ToString.Length - 1
                checksumstring += "0"
            Next

            checksumstring += checksum.ToString

            WritePrivateProfileString(section_name, key_name, "@" & val_name & "%" & checksumstring & "#", file_name)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

#Region "Controls"

    Public Sub BootSettings()

        Try

            Dim nome_arquivo_ini As String = SGS_Library.NomeArquivoINI(DirConfig)

            If Not System.IO.File.Exists(nome_arquivo_ini) Then
                FormMessageBox(5)
            End If

            SGS_Library.Language = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP000", "English")
            SGS_Library.Language = SGS_Library.Language.Substring(0, SGS_Library.Language.IndexOf(" "))
            SGS_Library.ReadLanguageLibrary()

            FormTop = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP010", "100")
            FormLeft = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP011", "250")

            TimerNowInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP020", "100")
            TimerConnectedInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP021", "1500")
            TimerDisconnectedInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP022", "1500")
            TimerUsartTxInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP023", "100")
            TimerUsartRxInterval = ReadFileChecksum(nome_arquivo_ini, "Parameters", "PP024", "100")

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

                .ButtonDisconnect.Visible = False
                .ButtonDownload.Enabled = False
                .ButtonUpload.Enabled = False
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

            RecipeControl = 0

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub WriteLocation(_form As System.Windows.Forms.Form)

        Try
            Dim nome_arquivo_ini As String = SGS_Library.NomeArquivoINI(DirConfig)

            WriteFileChecksum("Parameters", "PP010", _form.Top, nome_arquivo_ini)
            WriteFileChecksum("Parameters", "PP011", _form.Left, nome_arquivo_ini)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub
#End Region

#Region "Forms"

    Public Sub LanguageForm(_form As System.Windows.Forms.Form)

        Try

            Dim _ToolTip As New System.Windows.Forms.ToolTip

            Select Case _form.Name

                Case Is = "Form_Controller"

                    With Form_Controller
                        .ButtonClose.Text = SGS_Library.Label0000
                        .ButtonConnect.Text = SGS_Library.Label0002
                        .ButtonDisconnect.Text = SGS_Library.Label0004
                        .ButtonCreateFile.Text = SGS_Library.Label0022
                        .ButtonOpenFile.Text = SGS_Library.label0054
                        .ButtonUpload.Text = SGS_Library.Label0056
                        .ButtonDownload.Text = SGS_Library.Label0058

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
                            .SetToolTip(Form_Controller.ButtonDisconnect, SGS_Library.Label0005)
                            .SetToolTip(Form_Controller.ButtonCreateFile, SGS_Library.Label0023)
                            .SetToolTip(Form_Controller.ButtonOpenFile, SGS_Library.Label0055)
                            .SetToolTip(Form_Controller.ButtonUpload, SGS_Library.Label0057)
                            .SetToolTip(Form_Controller.ButtonDownload, SGS_Library.Label0059)
                        End With

                    End With

                Case Is = "Form_Recipes"

                    With Form_Recipes
                        .ButtonClose.Text = SGS_Library.Label0000
                        .ButtonSaveFile.Text = SGS_Library.Label0066
                        .ButtonPrevious.Text = SGS_Library.Label0041
                        .ButtonNext.Text = SGS_Library.Label0042

                        .Label0001.Text = SGS_Library.Label0027
                        .Label0002.Text = SGS_Library.Label0028
                        .Label0003.Text = SGS_Library.Label0029
                        .Label0004.Text = SGS_Library.Label0030
                        .Label0005.Text = SGS_Library.Label0031
                        .Label0006.Text = SGS_Library.Label0032
                        .Label0007.Text = SGS_Library.Label0033
                        .Label0008.Text = SGS_Library.Label0034
                        .Label0009.Text = SGS_Library.Label0035
                        .Label0010.Text = SGS_Library.Label0036
                        .Label0011.Text = SGS_Library.Label0037
                        .Label0012.Text = SGS_Library.Label0038
                        .Label0013.Text = SGS_Library.Label0039
                        .Label0014.Text = SGS_Library.Label0040

                        .CheckBoxEnableTips.Text = SGS_Library.Label0053

                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_Recipes.ButtonPrevious, SGS_Library.Label0043)
                            .SetToolTip(Form_Recipes.ButtonNext, SGS_Library.Label0044)
                            .SetToolTip(Form_Recipes.ButtonSaveFile, SGS_Library.Label0045)
                            .SetToolTip(Form_Recipes.ButtonClose, SGS_Library.Label0046)
                        End With

                    End With

                Case Is = "Form_Settings"

                    With Form_Settings
                        .ButtonClose.Text = SGS_Library.Label0000
                        .ButtonSaveFile.Text = SGS_Library.Label0066

                        .Label0001.Text = SGS_Library.Label0060
                        .Label0002.Text = SGS_Library.Label0028
                        .Label0003.Text = SGS_Library.Label0061
                        .Label0004.Text = SGS_Library.Label0062
                        .Label0005.Text = SGS_Library.Label0063
                        .Label0006.Text = SGS_Library.Label0064
                        .Label0007.Text = SGS_Library.Label0065

                        .CheckBoxEnableTips.Text = SGS_Library.Label0053

                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_Settings.ButtonSaveFile, SGS_Library.Label0045)
                            .SetToolTip(Form_Settings.ButtonClose, SGS_Library.Label0046)
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

#Region "Form Recipe tooltip"

    Public Sub ComboBoxRecipeToolTip(_ComboBox As System.Windows.Forms.ComboBox)

        Try

            Dim i As Integer = Int(Strings.Right(_ComboBox.Name, 4))
            Dim _ToolTip As New System.Windows.Forms.ToolTip

            _ToolTip.IsBalloon = True

            If Form_Recipes.CheckBoxEnableTips.Checked = True Then

                If i = 0 Then

                    _ToolTip.Show(SGS_Library.Label0052, _ComboBox, 40, -32, 2000)

                Else

                    _ToolTip.Show(SGS_Library.Label0051, _ComboBox, 65, -32, 2000)

                End If
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub TextBoxRecipeToolTip(_TextBox As System.Windows.Forms.TextBox)

        Try

            Dim i As Integer = Int(Strings.Right(_TextBox.Name, 4)) - 1
            Dim _ToolTip As New System.Windows.Forms.ToolTip

            _ToolTip.IsBalloon = True

            If Form_Recipes.CheckBoxEnableTips.Checked = True Then

                If i = 1 Or i = 4 Or i = 5 Then

                    _ToolTip.Show(SGS_Library.Label0047 & Format(Convert.ToDecimal(SGS_Firmware.ValidationRecipeMinimum(i)), SGS_Firmware.ParametersFormat(i)) & vbCrLf & SGS_Library.Label0048 & Format(Convert.ToDecimal(SGS_Firmware.ValidationRecipeMaximum(i)), SGS_Firmware.ParametersFormat(i)), _TextBox, 65, -55, 2000)

                ElseIf i = 0 Then

                    _ToolTip.Show(SGS_Library.Label0049 & SGS_Firmware.ValidationRecipeMinimum(i) & vbCrLf & SGS_Library.Label0050 & Strings.Mid(SGS_Firmware.ValidationRecipeMaximum(i), 3, SGS_Firmware.ValidationRecipeMaximum(i).Length - 4), _TextBox, 65, -55, 2000)

                Else
                    _ToolTip.Show(SGS_Library.Label0047 & Format(Convert.ToInt32(SGS_Firmware.ValidationRecipeMinimum(i)), SGS_Firmware.ParametersFormat(i)) & vbCrLf & SGS_Library.Label0048 & Format(Convert.ToInt32(SGS_Firmware.ValidationRecipeMaximum(i)), SGS_Firmware.ParametersFormat(i)), _TextBox, 65, -55, 2000)

                End If
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

#Region "Form Settings tooltip"

    Public Sub ComboBoxSettingToolTip(_ComboBox As System.Windows.Forms.ComboBox)

        Try

            Dim i As Integer = Int(Strings.Right(_ComboBox.Name, 4))
            Dim _ToolTip As New System.Windows.Forms.ToolTip

            _ToolTip.IsBalloon = True

            If Form_Settings.CheckBoxEnableTips.Checked = True Then

                Select Case i

                    Case Is = 0

                        _ToolTip.Show(SGS_Library.Label0067, _ComboBox, 65, -32, 2000)

                    Case Is = 1

                        _ToolTip.Show(SGS_Library.Label0068, _ComboBox, 65, -32, 2000)

                    Case Is = 2

                        _ToolTip.Show(SGS_Library.Label0069, _ComboBox, 65, -32, 2000)

                End Select

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub TextBoxSettingToolTip(_TextBox As System.Windows.Forms.TextBox)

        Try

            Dim i As Integer = Int(Strings.Right(_TextBox.Name, 4)) - 1
            Dim _ToolTip As New System.Windows.Forms.ToolTip

            _ToolTip.IsBalloon = True

            If Form_Settings.CheckBoxEnableTips.Checked = True Then

                _ToolTip.Show(SGS_Library.Label0047 & Format(Convert.ToInt32(SGS_Firmware.ValidationSettingMinimum(i)), SGS_Firmware.SettingsFormat(i)) & vbCrLf & SGS_Library.Label0048 & Format(Convert.ToInt32(SGS_Firmware.ValidationSettingMaximum(i)), SGS_Firmware.SettingsFormat(i)), _TextBox, 65, -55, 2000)


            End If

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
            RecipeControl = 0

            UsartRx = ""

            With Form_Controller

                .ButtonConnect.Visible = True
                .ButtonConnect.Enabled = True
                .ButtonDisconnect.Visible = False

                .ButtonOpenFile.Enabled = True
                .ButtonCreateFile.Enabled = True
                .ButtonUpload.Enabled = False
                .ButtonDownload.Enabled = False
                .ButtonClose.Enabled = True

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
            Form_Controller.PanelTx.BackColor = System.Drawing.SystemColors.ControlDark
            _SerialPort.Write(SerialData + vbLf)
            _TimerPanelTx.Start()
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SerialPortDataSend(SerialData As String)

        Try
            If SerialData.Length < 69 Then
                For i As Byte = 0 To 69 - SerialData.Length - 1
                    SerialData += " "
                Next
            End If

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

            Form_Controller.PanelTx.BackColor = System.Drawing.SystemColors.ControlDark
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
                .PanelRx.BackColor = System.Drawing.SystemColors.ControlDark
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

                If checksum = Convert.toint32(SerialChecksum) Then
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
                        With Form_Controller
                            .ButtonConnect.Visible = False
                            .ButtonDisconnect.Visible = True
                        End With

                        _TimerConnected.Stop()

                        FormMessageBox(0)

                        DeviceVersion()

                        With Form_Controller
                            .ButtonOpenFile.Enabled = False
                            .ButtonCreateFile.Enabled = False
                            .ButtonUpload.Enabled = True
                            .ButtonDownload.Enabled = True
                        End With

                        Exit Sub
                    End If

                    If Data.Substring(0, 2) = "00" Then
                        UsartConnected = False
                        RecipeControl = 0

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

                            .ButtonConnect.Visible = True
                            .ButtonConnect.Enabled = True
                            .ButtonDisconnect.Visible = False

                            .ButtonOpenFile.Enabled = True
                            .ButtonCreateFile.Enabled = True
                            .ButtonUpload.Enabled = False
                            .ButtonDownload.Enabled = False
                            .ButtonClose.Enabled = True
                        End With

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

                Select Case RecipeControl

                    Case Is = 1

                        If RecipeIndex < 500 Then
                            RecipeIndex = RecipeIndex + 1
                            DownloadFileControl()
                        Else
                            RecipeControl = 0
                        End If

                    Case Is = 2

                        Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

                        WriteFileChecksum("Recipes", Strings.Left(Decoder, 5), Strings.Right(Decoder, 64), nome_arquivo_ini)

                        If RecipeIndex < 500 Then
                            RecipeIndex = RecipeIndex + 1
                            UploadFileControl()
                        Else
                            RecipeControl = 0

                            OpenFormRecipe()

                        End If

                End Select

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

    Public Sub DownloadFileControl()

        Try

            Dim pointer As String

            pointer = RecipeIndex.ToString

            For i As Integer = 0 To 2 - pointer.Length
                pointer = "0" + pointer
            Next

            UsartTx = "WR" & pointer & RecipeList(RecipeIndex)
            Console.WriteLine(UsartTx)
            SerialPortDataSend(UsartTx)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub UploadFileControl()

        Try

            Dim pointer As String

            pointer = RecipeIndex.ToString

            For i As Integer = 0 To 2 - pointer.Length
                pointer = "0" + pointer
            Next

            UsartTx = "RR" & pointer

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

            Dim _ToolTip As New System.Windows.Forms.ToolTip

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

                Case Is = 6
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0006
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 7
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0007
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 8
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0008
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 9
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0009
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 10
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0010
                        With .Button01
                            .Visible = True
                            .Text = SGS_Library.Label0010
                        End With
                        With _ToolTip
                            .IsBalloon = True
                            .SetToolTip(Form_MessageBox.Button01, SGS_Library.Label0019)
                        End With
                    End With

                Case Is = 11
                    With Form_MessageBox
                        .LabelMessage.Text = SGS_Library.Message0011
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

                        Case Is = 6
                            Form_MessageBox.Dispose()

                        Case Is = 7
                            Form_MessageBox.Dispose()

                        Case Is = 8
                            Form_MessageBox.Dispose()

                        Case Is = 9
                            Form_MessageBox.Dispose()

                        Case Is = 10
                            Form_MessageBox.Dispose()

                        Case Is = 11
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

#Region "Files SGS"

    Public Sub SaveFileDirectory()

        Try

            Dim _saveFileDialog As New SaveFileDialog()

            _saveFileDialog.Filter = SGS_Library.Label0024
            _saveFileDialog.Title = SGS_Library.Label0025
            _saveFileDialog.FilterIndex = 1
            _saveFileDialog.ShowDialog()

            If _saveFileDialog.FileName <> "" Then

                FileDirectory = System.IO.Path.GetDirectoryName(_saveFileDialog.FileName)
                FileName = System.IO.Path.GetFileName(_saveFileDialog.FileName)
                FileSystem = _saveFileDialog.FilterIndex

                If Strings.Right(FileDirectory, 1) = "\" Then
                    FileDirectory = FileDirectory.Substring(0, FileDirectory.Length - 1)
                End If

                Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

                SGS_Firmware.Firmware = SGS_Firmware.FirmwareSelect(0)
                SGS_Firmware.ReadFirmwareLibrary()

                WriteFileChecksum("Firmware", "FR000", SGS_Firmware.Firmware, nome_arquivo_ini)

                Select Case FileSystem

                    Case 1

                        Dim RecipeData As String

                        For i As Integer = 1 To 500

                            RecipeData = "RR"

                            For j As Integer = 1 To 3 - i.ToString.Length()
                                RecipeData += "0"
                            Next

                            RecipeData = RecipeData & i.ToString() & SGS_Firmware.FirmwareString
                            WriteFileChecksum("Recipes", Strings.Left(RecipeData, 5), Strings.Right(RecipeData, 64), nome_arquivo_ini)

                            RecipeList(i) = RecipeData
                        Next

                        If Form_Recipes.IsHandleCreated = True Then
                            RecipeLoad()
                        Else
                            Form_Recipes.ShowDialog()
                        End If

                    Case 2

                        WriteFileChecksum("Settings", "RS000", SGS_Firmware.SettingsString, nome_arquivo_ini)

                        CurrentSettings = "RS000" & SGS_Firmware.SettingsString

                        If Form_Settings.IsHandleCreated = True Then
                            SettingsLoad()
                        Else
                            Form_Settings.ShowDialog()
                        End If

                End Select

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub OpenFileDirectory()

        Try

            Dim myStream As System.IO.Stream = Nothing
            Dim _openFileDialog As New OpenFileDialog()

            _openFileDialog.Filter = SGS_Library.Label0024
            _openFileDialog.Title = SGS_Library.Label0026
            _openFileDialog.FilterIndex = 1
            _openFileDialog.RestoreDirectory = True

            If _openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Try

                    myStream = _openFileDialog.OpenFile()

                    If (myStream IsNot Nothing) Then

                        FileDirectory = System.IO.Path.GetDirectoryName(_openFileDialog.FileName)
                        FileName = System.IO.Path.GetFileName(_openFileDialog.FileName)
                        FileSystem = _openFileDialog.FilterIndex

                        If Strings.Right(FileDirectory, 1) = "\" Then
                            FileDirectory = FileDirectory.Substring(0, FileDirectory.Length - 1)
                        End If

                        Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

                        Dim FirmwareData As String = ReadFileChecksum(nome_arquivo_ini, "Firmware", "FR000", SGS_Firmware.Firmware)

                        SGS_Firmware.Firmware = FirmwareData.Substring(0, FirmwareData.IndexOf(" "))
                        SGS_Firmware.ReadFirmwareLibrary()

                        Select Case FileSystem

                            Case 1

                                OpenFormRecipe()

                            Case 2

                                OpenFormSettings()

                        End Select

                    End If
                Catch Ex As Exception
                    MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message) 'msgbox
                Finally
                    If (myStream IsNot Nothing) Then
                        myStream.Close()
                    End If
                End Try
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub DownloadFileDirectory()

        Try

            Dim myStream As System.IO.Stream = Nothing
            Dim _openFileDialog As New OpenFileDialog()

            _openFileDialog.Filter = SGS_Library.Label0024
            _openFileDialog.Title = SGS_Library.Label0026
            _openFileDialog.FilterIndex = 1
            _openFileDialog.RestoreDirectory = True

            If _openFileDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                Try

                    myStream = _openFileDialog.OpenFile()

                    If (myStream IsNot Nothing) Then

                        FileDirectory = System.IO.Path.GetDirectoryName(_openFileDialog.FileName)
                        FileName = System.IO.Path.GetFileName(_openFileDialog.FileName)
                        FileSystem = _openFileDialog.FilterIndex

                        If Strings.Right(FileDirectory, 1) = "\" Then
                            FileDirectory = FileDirectory.Substring(0, FileDirectory.Length - 1)
                        End If

                        Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

                        Dim FirmwareData As String = ReadFileChecksum(nome_arquivo_ini, "Firmware", "FR000", SGS_Firmware.Firmware)

                        If Form_Controller.Label0013.Text = FirmwareData.Substring(0, FirmwareData.IndexOf(" ")) = True Then

                            Select Case FileSystem

                                Case 1

                                    Dim RecipeData As String

                                    For i As Integer = 1 To 500

                                        RecipeData = "RR"

                                        For j As Integer = 1 To 3 - i.ToString.Length()
                                            RecipeData += "0"
                                        Next

                                        RecipeData = RecipeData & i.ToString()
                                        RecipeList(i) = ReadFileChecksum(nome_arquivo_ini, "Recipes", RecipeData, SGS_Firmware.FirmwareString)

                                    Next

                                    RecipeControl = 1
                                    RecipeIndex = 1
                                    DownloadFileControl()

                            End Select

                        Else

                            FormMessageBox(9)

                        End If

                    End If
                Catch Ex As Exception
                    MessageBox.Show("Cannot read file from disk. Original error: " & Ex.Message)
                Finally
                    If (myStream IsNot Nothing) Then
                        myStream.Close()
                    End If
                End Try
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub UploadFileDirectory()

        Try

            Dim _saveFileDialog As New SaveFileDialog()

            _saveFileDialog.Filter = SGS_Library.Label0024
            _saveFileDialog.Title = SGS_Library.Label0025
            _saveFileDialog.FilterIndex = 1
            _saveFileDialog.ShowDialog()

            If _saveFileDialog.FileName <> "" Then

                FileDirectory = System.IO.Path.GetDirectoryName(_saveFileDialog.FileName)
                FileName = System.IO.Path.GetFileName(_saveFileDialog.FileName)
                FileSystem = _saveFileDialog.FilterIndex

                If Strings.Right(FileDirectory, 1) = "\" Then
                    FileDirectory = FileDirectory.Substring(0, FileDirectory.Length - 1)
                End If

                Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

                WriteFileChecksum("Firmware", "FR000", Form_Controller.Label0013.Text, nome_arquivo_ini)

                Select Case FileSystem

                    Case 1

                        RecipeControl = 2
                        RecipeIndex = 1
                        UploadFileControl()

                    Case 2

                        'WriteFileChecksum("Settings", "SR000", SGS_Firmware.SettingsString, nome_arquivo_ini)

                End Select

            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

#Region "Form Recipe"

    Public Sub RecipeLoad()

        Try

            With Form_Recipes
                .Activate()
                .ButtonSize.Text = "-"
                .Size = New Size(328, 689)

            End With

            Form_Recipes.ComboBox0000.Items.Clear()
            For i As Integer = 1 To 500
                Form_Recipes.ComboBox0000.Items.Add(i)
            Next

            Form_Recipes.ComboBox0000.SelectedIndex = 0
            RecipeIndex = 1
            RecipeEdit()

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub OpenFormRecipe()

        Try

            Dim RecipeData As String
            Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

            For i As Integer = 1 To 500

                RecipeData = "RR"

                For j As Integer = 1 To 3 - i.ToString.Length()
                    RecipeData += "0"
                Next

                RecipeData = RecipeData & i.ToString()
                RecipeList(i) = RecipeData & ReadFileChecksum(nome_arquivo_ini, "Recipes", RecipeData, SGS_Firmware.FirmwareString)

            Next

            If Form_Recipes.IsHandleCreated = True Then
                RecipeLoad()
            Else
                Form_Recipes.ShowDialog()
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub RecipeEdit()

        Try

            Form_Recipes.TextBox0000.Text = RecipeList(RecipeIndex)
            Form_Recipes.TextBox0000.SelectionStart = 0

            Dim ListTextBoxes() As TextBox = {Form_Recipes.TextBox0001, Form_Recipes.TextBox0002, Form_Recipes.TextBox0003, Form_Recipes.TextBox0004, Form_Recipes.TextBox0005, Form_Recipes.TextBox0006, Form_Recipes.TextBox0007, Form_Recipes.TextBox0008, Form_Recipes.TextBox0009, Form_Recipes.TextBox0010, Form_Recipes.TextBox0011}

            Dim ListSubstrings() As Integer = {5, 16, 21, 5, 26, 5, 31, 6, 37, 6, 43, 4, 47, 5, 52, 2, 54, 4, 58, 6, 64, 3}

            Dim ListEdit() As Integer = {0, 6, 9, 7, 1, 2, 3, 4, 5, 8, 10}

            Dim Parameters As String = RecipeList(RecipeIndex)

            For i As Integer = 0 To 10
                ListCurrentParameters(i) = Parameters.Substring(ListSubstrings(2 * ListEdit(i)), ListSubstrings(2 * ListEdit(i) + 1))
                ListTextBoxes(i).Text = ListCurrentParameters(i)

                If Not i = 0 Then
                    If i = 1 Or i = 4 Or i = 5 Then
                        ListTextBoxes(i).Text = Format(Convert.ToDecimal(ListTextBoxes(i).Text) / 100, SGS_Firmware.ParametersFormat(i))
                    Else
                        ListTextBoxes(i).Text = Format(Convert.ToInt32(ListTextBoxes(i).Text), SGS_Firmware.ParametersFormat(i))
                    End If
                End If
            Next

            With Form_Recipes.ComboBox0001
                .Items.Clear()
                .Items.AddRange(SGS_Library.List0000)
                .SelectedIndex = Form_Recipes.TextBox0004.Text
            End With

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub ValidateEdition()

        Try

            Dim ListTextBoxes() As TextBox = {Form_Recipes.TextBox0001, Form_Recipes.TextBox0002, Form_Recipes.TextBox0003, Form_Recipes.TextBox0004, Form_Recipes.TextBox0005, Form_Recipes.TextBox0006, Form_Recipes.TextBox0007, Form_Recipes.TextBox0008, Form_Recipes.TextBox0009, Form_Recipes.TextBox0010, Form_Recipes.TextBox0011}

            SGS_Firmware.ValidationRecipeMinimum(7) = ListCurrentParameters(6)
            SGS_Firmware.ValidationRecipeMaximum(6) = ListCurrentParameters(7)
            SGS_Firmware.ValidationRecipeMinimum(5) = Convert.ToDecimal(ListCurrentParameters(4)) / 100
            SGS_Firmware.ValidationRecipeMaximum(4) = Convert.ToDecimal(ListCurrentParameters(5)) / 100


            If Convert.ToDecimal(ListCurrentParameters(1)) / 100 < 10 Then
                SGS_Firmware.ValidationRecipeMinimum(4) = "1,30"
                SGS_Firmware.ValidationRecipeMaximum(5) = "18,00"
            Else
                SGS_Firmware.ValidationRecipeMinimum(4) = "7,00"
                SGS_Firmware.ValidationRecipeMaximum(5) = "30,00"
            End If

            Dim Parameter As String

            For i As Integer = 0 To 10

                Parameter = ListTextBoxes(i).Text

                If i = 0 Then

                    If Parameter.Length() > Convert.ToInt32(SGS_Firmware.ValidationRecipeMinimum(i)) Or System.Text.RegularExpressions.Regex.IsMatch(Parameter, SGS_Firmware.ValidationRecipeMaximum(i)) = True Then
                        FormMessageBox(6)
                        ListTextBoxes(i).Text = ListCurrentParameters(i)
                        ListTextBoxes(i).Focus()
                    Else
                        ListCurrentParameters(i) = Parameter
                    End If

                Else

                    If i = 1 Or i = 4 Or i = 5 Then

                        If Not System.Text.RegularExpressions.Regex.IsMatch(Parameter, "[^0-9]+") Then

                            If Convert.ToDecimal(Parameter) / 100 < Convert.ToDecimal(SGS_Firmware.ValidationRecipeMinimum(i)) Or Convert.ToDecimal(Parameter) / 100 > Convert.ToDecimal(SGS_Firmware.ValidationRecipeMaximum(i)) Then
                                FormMessageBox(8)
                                ListTextBoxes(i).Text = Format(ListCurrentParameters(i) / 100, SGS_Firmware.ParametersFormat(i))
                                ListTextBoxes(i).Focus()
                            Else

                                If i = 1 And Not Parameter = ListCurrentParameters(i) Then
                                    If Convert.ToDecimal(Parameter) / 100 < 10 Then
                                        SGS_Firmware.ValidationRecipeMinimum(4) = "1,30"
                                        SGS_Firmware.ValidationRecipeMinimum(5) = "1,30"
                                        SGS_Firmware.ValidationRecipeMaximum(4) = "18,00"
                                        SGS_Firmware.ValidationRecipeMaximum(5) = "18,00"
                                        If Convert.ToDecimal(ListCurrentParameters(5)) / 100 > Convert.ToDecimal("18,00") Then
                                            FormMessageBox(7)
                                            ListTextBoxes(4).Text = "130"
                                            ListTextBoxes(5).Text = "130"
                                        End If
                                    Else
                                        SGS_Firmware.ValidationRecipeMinimum(4) = "7,00"
                                        SGS_Firmware.ValidationRecipeMinimum(5) = "7,00"
                                        SGS_Firmware.ValidationRecipeMaximum(4) = "30,00"
                                        SGS_Firmware.ValidationRecipeMaximum(5) = "30,00"
                                        If Convert.ToDecimal(ListCurrentParameters(4)) / 100 < Convert.ToDecimal("7,00") Then
                                            FormMessageBox(7)
                                            ListTextBoxes(4).Text = "700"
                                            ListTextBoxes(5).Text = "700"
                                        End If
                                    End If

                                End If

                                ListCurrentParameters(i) = Parameter
                                ListTextBoxes(i).Text = Format(Convert.ToDecimal(Parameter) / 100, SGS_Firmware.ParametersFormat(i))

                            End If

                        Else

                            If Not Format(ListCurrentParameters(i) / 100, SGS_Firmware.ParametersFormat(i)) = Parameter Then
                                ListTextBoxes(i).Text = Format(ListCurrentParameters(i) / 100, SGS_Firmware.ParametersFormat(i))
                            End If

                        End If

                    Else

                        If Not System.Text.RegularExpressions.Regex.IsMatch(Parameter, "[^0-9]+") Then

                            If Convert.ToInt32(Parameter) < Convert.ToInt32(SGS_Firmware.ValidationRecipeMinimum(i)) Or Convert.ToInt32(Parameter) > Convert.ToInt32(SGS_Firmware.ValidationRecipeMaximum(i)) Then
                                FormMessageBox(8)
                                ListTextBoxes(i).Focus()
                                ListTextBoxes(i).Text = Format(Convert.ToInt32(ListCurrentParameters(i)), SGS_Firmware.ParametersFormat(i))
                            Else
                                ListCurrentParameters(i) = Parameter
                                ListTextBoxes(i).Text = Format(Convert.ToInt32(Parameter), SGS_Firmware.ParametersFormat(i))
                            End If

                        Else

                            If Not Format(Convert.ToInt32(ListCurrentParameters(i)), SGS_Firmware.ParametersFormat(i)) = Parameter Then
                                ListTextBoxes(i).Text = Format(Convert.ToInt32(ListCurrentParameters(i)), SGS_Firmware.ParametersFormat(i))
                            End If

                        End If

                    End If

                End If

            Next

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SaveEditRam()

        Try

            Dim Newrecipe As String = "RR"

            For i As Integer = 0 To 3 - RecipeIndex.ToString.Length - 1

                Newrecipe += "0"

            Next

            Newrecipe = Newrecipe & RecipeIndex


            Dim RecipeEqualizer() As Integer = {16, 5, 5, 6, 6, 4, 5, 2, 4, 6, 3}
            Dim ListEdit() As Integer = {0, 4, 5, 6, 7, 8, 1, 3, 9, 2, 10}

            For i As Integer = 0 To 10

                If i = 0 Then

                    Newrecipe += ListCurrentParameters(ListEdit(i))
                    For j As Integer = 0 To RecipeEqualizer(i) - ListCurrentParameters(ListEdit(i)).Length - 1
                        Newrecipe += " "
                    Next

                Else
                    Dim equalizer As String = Convert.ToInt32(ListCurrentParameters(ListEdit(i)))
                    For j As Integer = 0 To RecipeEqualizer(i) - equalizer.Length - 1
                        Newrecipe += " "
                    Next
                    Newrecipe += equalizer

                End If

            Next

            RecipeList(RecipeIndex) = Newrecipe

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SaveAll()

        Try

            SaveEditRam()

            Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

            WriteFileChecksum("Firmware", "FR000", SGS_Firmware.Firmware, nome_arquivo_ini)

            For i As Integer = 1 To 500
                WriteFileChecksum("Recipes", Strings.Left(RecipeList(i), 5), Strings.Mid(RecipeList(i), 6), nome_arquivo_ini)
            Next

            FormMessageBox(10)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

#Region "Form Settings"

    Public Sub SettingsLoad()

        Try

            Dim Settingsstring As String = CurrentSettings

            Form_Settings.TextBox0000.Text = Settingsstring

            Dim ListTextBoxes() As TextBox = {Form_Settings.TextBox0001, Form_Settings.TextBox0002, Form_Settings.TextBox0003, Form_Settings.TextBox0004, Form_Settings.TextBox0005}

            Dim ListSubstrings() As Integer = {12, 2, 26, 6, 32, 3, 35, 2, 37, 2}

            Dim ListEdit() As Integer = {4, 0, 1, 2, 3}

            Dim Parameters As String = Settingsstring

            For i As Integer = 0 To 4

                ListCurrentSettings(i) = Parameters.Substring(ListSubstrings(2 * ListEdit(i)), ListSubstrings(2 * ListEdit(i) + 1))
                ListTextBoxes(i).Text = Convert.ToInt32(ListCurrentSettings(i))

                If i = 2 Or i = 3 Then
                    ListTextBoxes(i).Text = Format(Convert.ToInt32(ListTextBoxes(i).Text), SGS_Firmware.SettingsFormat(i))
                End If

            Next

            With Form_Settings
                .Activate()
                .ButtonSize.Text = "-"
                .Size = New Size(328, 689)

                With .ComboBox0000
                    .Items.Clear()
                    .Items.AddRange(SGS_Library.List0001)
                    .SelectedIndex = Form_Settings.TextBox0001.Text
                End With

                With .ComboBox0001
                    .Items.Clear()
                    .Items.AddRange(SGS_Library.List0001)
                    .SelectedIndex = Form_Settings.TextBox0002.Text
                End With

                With .ComboBox0002
                    .Items.Clear()
                    .Items.AddRange(SGS_Library.List0002)
                    .SelectedIndex = Form_Settings.TextBox0005.Text
                End With

            End With

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub ValidateEditionSettings()

        Try

            Dim ListTextBoxes() As TextBox = {Form_Settings.TextBox0001, Form_Settings.TextBox0002, Form_Settings.TextBox0003, Form_Settings.TextBox0004, Form_Settings.TextBox0005}

            Dim Parameter As String

            For i As Integer = 0 To 4

                Parameter = ListTextBoxes(i).Text


                If Not System.Text.RegularExpressions.Regex.IsMatch(Parameter, "[^0-9]+") Then

                    If Convert.ToInt32(Parameter) < Convert.ToInt32(SGS_Firmware.ValidationSettingMinimum(i)) Or Convert.ToInt32(Parameter) > Convert.ToInt32(SGS_Firmware.ValidationSettingMaximum(i)) Then
                        FormMessageBox(8)
                        ListTextBoxes(i).Text = Format(Convert.ToInt32(ListCurrentSettings(i)), SGS_Firmware.SettingsFormat(i))
                        ListTextBoxes(i).Focus()
                    Else
                        ListCurrentSettings(i) = Parameter
                        ListTextBoxes(i).Text = Format(Convert.ToInt32(Parameter), SGS_Firmware.SettingsFormat(i))
                    End If

                Else

                    If Not Format(Convert.ToInt32(ListCurrentSettings(i)), SGS_Firmware.ParametersFormat(i)) = Parameter Then
                        ListTextBoxes(i).Text = Format(Convert.ToInt32(ListCurrentSettings(i)), SGS_Firmware.SettingsFormat(i))
                    End If

                End If

            Next

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub SaveSettings()

        Try

            Dim NewSetting As String = CurrentSettings

            Dim ListSubstrings() As Integer = {12, 2, 26, 6, 32, 3, 35, 2, 37, 2}

            Dim ListEdit() As Integer = {4, 0, 1, 2, 3}

            Dim SettingEqualizer() As Integer = {2, 6, 3, 2, 2}

            For i As Integer = 0 To 4

                Dim Parameter As String = ""

                For j As Integer = 0 To SettingEqualizer(ListEdit(i)) - Convert.ToInt32(ListCurrentSettings(i)).ToString.Length() - 1
                    Parameter += " "
                Next

                Parameter += Convert.ToInt32(ListCurrentSettings(i)).ToString

                NewSetting = Strings.Left(CurrentSettings, ListSubstrings(ListEdit(i) * 2)) & Parameter & Strings.Right(CurrentSettings, 69 - ListSubstrings((ListEdit(i) * 2)) - ListSubstrings(ListEdit(i) * 2 + 1))

                CurrentSettings = NewSetting
                Form_Settings.TextBox0000.Text = CurrentSettings

            Next


            Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName
            MsgBox(CurrentSettings)
            WriteFileChecksum("Firmware", "FR000", SGS_Firmware.Firmware, nome_arquivo_ini)

            WriteFileChecksum("Settings", Strings.Left(CurrentSettings, 5), Strings.Mid(CurrentSettings, 6), nome_arquivo_ini)

            FormMessageBox(10)

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Public Sub OpenFormSettings()

        Try

            Dim SettingData As String
            Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

            SettingData = "RS000"

            CurrentSettings = SettingData & ReadFileChecksum(nome_arquivo_ini, "Settings", SettingData, SGS_Firmware.SettingsString)

            If Form_Settings.IsHandleCreated = True Then
                SettingsLoad()
            Else
                Form_Settings.ShowDialog()
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

End Module

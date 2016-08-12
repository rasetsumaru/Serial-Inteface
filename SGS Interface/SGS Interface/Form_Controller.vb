
Public Class Form_Controller

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Form event"

    Public Sub Form_Controller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        BootSettings()
        BootControls()

        LanguageForm(Me)

    End Sub

    Private Sub Form_Controller_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try

            If UsartConnected = True Then
                e.Cancel = True
                FormMessageBox(4)
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Private Sub Form_Controller_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        FormMouseDown(Me)

    End Sub

    Private Sub Form_Controller_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        FormMouseMove(Me)

    End Sub

    Private Sub Form_Controller_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

        FormMouseUp()

    End Sub

#End Region

#Region "Usart DataReceived"

    Public Sub DataReceivedHandler(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs)

        Try
            If _SerialPort.IsOpen Then
                UsartRx = _SerialPort.ReadTo(vbLf)
                If UsartRx.Length > 0 Then
                    UsartRx = UsartRx.Replace(vbLf, "")
                    BeginInvoke(New Threading.ThreadStart(AddressOf SerialRead))
                End If
            End If
        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

#Region "Buttons"

    Private Sub ButtonSize_Click(sender As Object, e As EventArgs) Handles ButtonSize.Click

        Try

            Select Case ButtonSize.Text
                Case Is = "-"
                    ButtonSize.Text = "+"
                    Size = New Size(328, 607)
                Case Is = "+"
                    ButtonSize.Text = "-"
                    Size = New Size(328, 689)
            End Select

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Private Sub ButtonConnect_Click_(sender As Object, e As EventArgs) Handles ButtonConnect.Click

        ConnectDevice()

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click

        WriteLocation(Me)
        Close()

    End Sub

#End Region



    Private Sub ButtonCreateRecipes_Click(sender As Object, e As EventArgs) Handles ButtonCreateRecipes.Click

        Try

            If Form_CreateFile.IsHandleCreated = True Then
                FileProperties()
            Else
                Form_CreateFile.ShowDialog()
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

End Class

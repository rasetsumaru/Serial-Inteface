
Public Class Form_CreateFile

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Form event"

    Public Sub Form_MessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        FileProperties()

    End Sub

    Private Sub Form_MessageBox_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        FormMouseDown(Me)

    End Sub

    Private Sub Form_MessageBox_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        FormMouseMove(Me)

    End Sub

    Private Sub Form_MessageBox_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

        FormMouseUp()

    End Sub

#End Region

#Region "Controls"

    Private Sub ButtonBrowse_Click(sender As Object, e As EventArgs) Handles ButtonBrowse.Click

        SaveFileDirectory()

    End Sub

    Private Sub ButtonConfirm_Click(sender As Object, e As EventArgs) Handles ButtonConfirm.Click


    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Try
            Close()

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Private Sub ButtonSize_Click(sender As Object, e As EventArgs) Handles ButtonSize.Click

        Try

            Select Case ButtonSize.Text
                Case Is = "-"
                    ButtonSize.Text = "+"
                    Size = New Size(534, 169)
                Case Is = "+"
                    ButtonSize.Text = "-"
                    Size = New Size(534, 248)
            End Select

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

#End Region

End Class
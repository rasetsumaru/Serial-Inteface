Public Class Form_MessageBox

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Form event"

    Public Sub Form_MessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        MessageLoad()

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

    Private Sub Button01_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button01.Click

        FormMessageBoxButton(1)

    End Sub

    Private Sub Button02_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button02.Click

        FormMessageBoxButton(2)

    End Sub

    Private Sub Button03_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button03.Click

        FormMessageBoxButton(3)

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
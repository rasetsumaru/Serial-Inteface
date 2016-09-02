
Public Class Form_Settings

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Forms events"

    Private Sub Form_Settings_Load(sender As Object, e As EventArgs) Handles Me.Load

        SettingsLoad()
        LanguageForm(Me)

    End Sub

    Private Sub Form_Settings_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        FormMouseDown(Me)

    End Sub

    Private Sub Form_Settings_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        FormMouseMove(Me)

    End Sub

    Private Sub Form_Settings_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

        FormMouseUp()

    End Sub

#End Region

#Region "Buttons"

    Private Sub ButtonSize_Click(sender As Object, e As EventArgs) Handles ButtonSize.Click

        Try

            Select Case ButtonSize.Text
                Case Is = "-"
                    ButtonSize.Text = "+"
                    Size = New Size(328, 361)
                Case Is = "+"
                    ButtonSize.Text = "-"
                    Size = New Size(328, 443)
            End Select

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click

        WriteFormEnableTips(Me.CheckBoxEnableTips.Checked)
        WriteLocation(Me)
        Close()

    End Sub

    Private Sub ButtonSaveFile_Click(sender As Object, e As EventArgs) Handles ButtonSaveFile.Click

        SaveSettings()

    End Sub

#End Region

#Region "Validating Settings"

    Private Sub TextBox0001_Validating(sender As Object, e As EventArgs) Handles TextBox0001.Validating

        ValidateEditionSettings()

    End Sub

    Private Sub TextBox0002_Validating(sender As Object, e As EventArgs) Handles TextBox0002.Validating

        ValidateEditionSettings()

    End Sub

    Private Sub TextBox0003_Validating(sender As Object, e As EventArgs) Handles TextBox0003.Validating

        ValidateEditionSettings()

    End Sub

    Private Sub TextBox0004_Validating(sender As Object, e As EventArgs) Handles TextBox0004.Validating

        ValidateEditionSettings()

    End Sub

    Private Sub TextBox0005_Validating(sender As Object, e As EventArgs) Handles TextBox0005.Validating

        ValidateEditionSettings()

    End Sub

    Private Sub TextBox0006_Validating(sender As Object, e As EventArgs) Handles TextBox0006.Validating

        ValidateEditionSettings()

    End Sub

#End Region

#Region "TextBoxToolTip"

    Private Sub TextBox0001_Enter(sender As Object, e As EventArgs) Handles TextBox0001.Enter

        TextBoxSettingToolTip(sender)

    End Sub

    Private Sub TextBox0002_Enter(sender As Object, e As EventArgs) Handles TextBox0002.Enter

        TextBoxSettingToolTip(sender)

    End Sub

    Private Sub TextBox0003_Enter(sender As Object, e As EventArgs) Handles TextBox0003.Enter

        TextBoxSettingToolTip(sender)

    End Sub

    Private Sub TextBox0004_Enter(sender As Object, e As EventArgs) Handles TextBox0004.Enter

        TextBoxSettingToolTip(sender)

    End Sub

    Private Sub TextBox0005_Enter(sender As Object, e As EventArgs) Handles TextBox0005.Enter

        TextBoxSettingToolTip(sender)

    End Sub

    Private Sub TextBox0006_Enter(sender As Object, e As EventArgs) Handles TextBox0006.Enter

        TextBoxSettingToolTip(sender)

    End Sub

#End Region

#Region "ComboBoxToolTip"

    Private Sub ComboBox0000_Enter(sender As Object, e As EventArgs) Handles ComboBox0000.Enter

        ComboBoxSettingToolTip(sender)

    End Sub

    Private Sub ComboBox0001_Enter(sender As Object, e As EventArgs) Handles ComboBox0001.Enter

        ComboBoxSettingToolTip(sender)

    End Sub

    Private Sub ComboBox0002_Enter(sender As Object, e As EventArgs) Handles ComboBox0002.Enter

        ComboBoxSettingToolTip(sender)

    End Sub

    Private Sub ComboBox0003_Enter(sender As Object, e As EventArgs) Handles ComboBox0003.Enter

        ComboBoxSettingToolTip(sender)


    End Sub
#End Region

#Region "Combobox"
    Private Sub ComboBox0000_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0000.SelectedIndexChanged

        Me.TextBox0001.Text = ComboBox0000.SelectedIndex
        ValidateEditionSettings()

    End Sub

    Private Sub ComboBox0001_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0002.SelectedIndexChanged

        Me.TextBox0003.Text = ComboBox0002.SelectedIndex
        ValidateEditionSettings()

    End Sub

    Private Sub ComboBox0002_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0003.SelectedIndexChanged

        Me.TextBox0006.Text = ComboBox0003.SelectedIndex
        ValidateEditionSettings()

    End Sub

#End Region

End Class
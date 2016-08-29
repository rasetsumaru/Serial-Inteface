
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

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click

        Close()

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

#End Region

    Private Sub ComboBox0000_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0000.SelectedIndexChanged

        Me.TextBox0001.Text = ComboBox0000.SelectedIndex
        ValidateEditionSettings()

    End Sub

    Private Sub ComboBox0001_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0001.SelectedIndexChanged

        Me.TextBox0002.Text = ComboBox0001.SelectedIndex
        ValidateEditionSettings()

    End Sub

    Private Sub ComboBox0002_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0002.SelectedIndexChanged

        Me.TextBox0005.Text = ComboBox0002.SelectedIndex
        ValidateEditionSettings()

    End Sub

    Private Sub ButtonSaveFile_Click(sender As Object, e As EventArgs) Handles ButtonSaveFile.Click

        SaveSettings()

    End Sub
End Class
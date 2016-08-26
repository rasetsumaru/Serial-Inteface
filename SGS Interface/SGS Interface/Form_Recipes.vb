
Public Class Form_Recipes

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Forms events"

    Private Sub Form_Recipes_Load(sender As Object, e As EventArgs) Handles Me.Load

        RecipeLoad()
        LanguageForm(Me)

    End Sub

    Private Sub Form_Recipes_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

        Try

            If UsartConnected = True Then
                e.Cancel = True
                FormMessageBox(4)
            End If

        Catch ex As Exception
            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))
        End Try

    End Sub

    Private Sub Form_Recipes_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown

        FormMouseDown(Me)

    End Sub

    Private Sub Form_Recipes_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove

        FormMouseMove(Me)

    End Sub

    Private Sub Form_Recipes_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp

        FormMouseUp()

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

#End Region


    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click

        SaveEditRam()

        If RecipeIndex > 1 Then
            RecipeIndex -= 1
            Me.ComboBox0000.SelectedIndex -= 1
            RecipeEdit()

        End If

    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click

        SaveEditRam()

        If RecipeIndex < 500 Then
            RecipeIndex += 1
            Me.ComboBox0000.SelectedIndex += 1
            RecipeEdit()

        End If

    End Sub

    Private Sub ComboBox0000_LostFocus(sender As Object, e As EventArgs) Handles ComboBox0000.LostFocus

        If ComboBox0000.FindStringExact(ComboBox0000.Text) < 0 Then

            MsgBox("Item não encontrado")
            Me.ComboBox0000.SelectedIndex = RecipeIndex - 1

        Else


            ComboBox0000.SelectedIndex = ComboBox0000.FindStringExact(ComboBox0000.Text) + 0

            If Not RecipeIndex = Me.ComboBox0000.SelectedItem Then
                SaveEditRam()
                RecipeIndex = Me.ComboBox0000.SelectedItem
                RecipeEdit()
            End If

        End If

    End Sub

    Public Sub ComboBox0000_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0000.SelectedIndexChanged

        Me.TextBox0000.Focus()

    End Sub

    Private Sub ComboBox0000_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBox0000.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If

    End Sub

    Private Sub ComboBox0001_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox0001.SelectedIndexChanged

        TextBox0004.Text = ComboBox0001.SelectedIndex
        ValidateEdition()

    End Sub

#Region "Validating Parameters"

    Private Sub TextBoxParameters0000_Validating(sender As Object, e As EventArgs) Handles TextBox0001.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0001_Validating(sender As Object, e As EventArgs) Handles TextBox0002.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0002_Validating(sender As Object, e As EventArgs) Handles TextBox0003.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0003_Validating(sender As Object, e As EventArgs) Handles TextBox0004.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0004_Validating(sender As Object, e As EventArgs) Handles TextBox0005.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0005_Validating(sender As Object, e As EventArgs) Handles TextBox0006.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0006_Validating(sender As Object, e As EventArgs) Handles TextBox0007.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0007_Validating(sender As Object, e As EventArgs) Handles TextBox0008.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0008_Validating(sender As Object, e As EventArgs) Handles TextBox0009.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0009_Validating(sender As Object, e As EventArgs) Handles TextBox0010.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0010_Validating(sender As Object, e As EventArgs) Handles TextBox0011.Validating

        ValidateEdition()

    End Sub

#End Region

    Private Sub ButtonSaveFile_Click(sender As Object, e As EventArgs) Handles ButtonSaveFile.Click

        SaveAll()

    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As EventArgs) Handles ButtonClose.Click

        Close()

    End Sub


#Region "TextBoxToolTip"

    Private Sub TextBox0001_Enter(sender As Object, e As EventArgs) Handles TextBox0001.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0002_Enter(sender As Object, e As EventArgs) Handles TextBox0002.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0003_Enter(sender As Object, e As EventArgs) Handles TextBox0003.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0004_Enter(sender As Object, e As EventArgs) Handles TextBox0004.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0005_Enter(sender As Object, e As EventArgs) Handles TextBox0005.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0006_Enter(sender As Object, e As EventArgs) Handles TextBox0006.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0007_Enter(sender As Object, e As EventArgs) Handles TextBox0007.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0008_Enter(sender As Object, e As EventArgs) Handles TextBox0008.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0009_Enter(sender As Object, e As EventArgs) Handles TextBox0009.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0010_Enter(sender As Object, e As EventArgs) Handles TextBox0010.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

    Private Sub TextBox0011_Enter(sender As Object, e As EventArgs) Handles TextBox0011.Enter

        TextBoxRecipeToolTip(sender)

    End Sub

#End Region

#Region "ComboBoxToolTip"

    Private Sub ComboBox0000_Enter(sender As Object, e As EventArgs) Handles ComboBox0000.Enter

        ComboBoxRecipeToolTip(sender)
    End Sub

    Private Sub ComboBox0001_Enter(sender As Object, e As EventArgs) Handles ComboBox0001.Enter

        ComboBoxRecipeToolTip(sender)

    End Sub

#End Region

End Class
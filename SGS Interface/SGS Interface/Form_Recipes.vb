Public Class Form_Recipes

    Private Sub Form_Recipes_Load(sender As Object, e As EventArgs) Handles Me.Load

        RecipeLoad()

    End Sub

    Private Sub ButtonPrevious_Click(sender As Object, e As EventArgs) Handles ButtonPrevious.Click

        SaveEditRam()

        If RecipeIndex > 1 Then
            RecipeIndex -= 1
            Me.ComboBoxRecipeIndex.SelectedIndex -= 1
            RecipeEdit()

        End If

    End Sub

    Private Sub ButtonNext_Click(sender As Object, e As EventArgs) Handles ButtonNext.Click

        SaveEditRam()

        If RecipeIndex < 500 Then
            RecipeIndex += 1
            Me.ComboBoxRecipeIndex.SelectedIndex += 1
            RecipeEdit()

        End If

    End Sub

    Private Sub ComboBoxRecipeIndex_LostFocus(sender As Object, e As EventArgs) Handles ComboBoxRecipeIndex.LostFocus

        If ComboBoxRecipeIndex.FindStringExact(ComboBoxRecipeIndex.Text) < 0 Then

            MsgBox("Item não encontrado")
            Me.ComboBoxRecipeIndex.SelectedIndex = RecipeIndex - 1

        Else


            ComboBoxRecipeIndex.SelectedIndex = ComboBoxRecipeIndex.FindStringExact(ComboBoxRecipeIndex.Text) + 0

            If Not RecipeIndex = Me.ComboBoxRecipeIndex.SelectedItem Then
                SaveEditRam()
                RecipeIndex = Me.ComboBoxRecipeIndex.SelectedItem
                RecipeEdit()
            End If

        End If

    End Sub

    Public Sub ComboBoxRecipeIndex_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxRecipeIndex.SelectedIndexChanged

        Me.TextBoxRecipe.Focus()

    End Sub

    Private Sub ComboBoxRecipeIndex_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBoxRecipeIndex.KeyPress

        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If

    End Sub



#Region "Validating Parameters"

    Private Sub TextBoxParameters0000_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0000.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0001_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0001.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0002_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0002.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0003_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0003.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0004_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0004.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0005_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0005.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0006_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0006.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0007_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0007.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0008_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0008.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0009_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0009.Validating

        ValidateEdition()

    End Sub

    Private Sub TextBoxParameters0010_Validating(sender As Object, e As EventArgs) Handles TextBoxParameters0010.Validating

        ValidateEdition()

    End Sub

#End Region

    Private Sub ComboBoxParameters0000_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxParameters0000.SelectedIndexChanged

        TextBoxParameters0003.Text = ComboBoxParameters0000.SelectedIndex
        ValidateEdition()

    End Sub

    Private Sub ButtonCreateFile_Click(sender As Object, e As EventArgs) Handles ButtonCreateFile.Click

        SaveAll()

    End Sub

End Class
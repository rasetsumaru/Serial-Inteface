<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Recipes
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonPrevious = New System.Windows.Forms.Button()
        Me.ButtonNext = New System.Windows.Forms.Button()
        Me.TextBoxRecipe = New System.Windows.Forms.TextBox()
        Me.ComboBoxRecipeIndex = New System.Windows.Forms.ComboBox()
        Me.ButtonCreateFile = New System.Windows.Forms.Button()
        Me.ButtonSize = New System.Windows.Forms.Button()
        Me.Label0001 = New System.Windows.Forms.Label()
        Me.Label0000 = New System.Windows.Forms.Label()
        Me.Lbl5004 = New System.Windows.Forms.Label()
        Me.ComboBoxParameters0000 = New System.Windows.Forms.ComboBox()
        Me.Lbl5012 = New System.Windows.Forms.Label()
        Me.Lbl5011 = New System.Windows.Forms.Label()
        Me.Lbl5008 = New System.Windows.Forms.Label()
        Me.Lbl5010 = New System.Windows.Forms.Label()
        Me.Lbl5009 = New System.Windows.Forms.Label()
        Me.Lbl5007 = New System.Windows.Forms.Label()
        Me.Lbl5006 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxParameters0000 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0002 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0003 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0004 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0005 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0006 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0007 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0008 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0009 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0010 = New System.Windows.Forms.TextBox()
        Me.TextBoxParameters0001 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'ButtonPrevious
        '
        Me.ButtonPrevious.Location = New System.Drawing.Point(340, 429)
        Me.ButtonPrevious.Name = "ButtonPrevious"
        Me.ButtonPrevious.Size = New System.Drawing.Size(75, 23)
        Me.ButtonPrevious.TabIndex = 0
        Me.ButtonPrevious.Text = "Previous"
        Me.ButtonPrevious.UseVisualStyleBackColor = True
        '
        'ButtonNext
        '
        Me.ButtonNext.Location = New System.Drawing.Point(421, 429)
        Me.ButtonNext.Name = "ButtonNext"
        Me.ButtonNext.Size = New System.Drawing.Size(75, 23)
        Me.ButtonNext.TabIndex = 1
        Me.ButtonNext.Text = "Next"
        Me.ButtonNext.UseVisualStyleBackColor = True
        '
        'TextBoxRecipe
        '
        Me.TextBoxRecipe.Location = New System.Drawing.Point(291, 403)
        Me.TextBoxRecipe.Name = "TextBoxRecipe"
        Me.TextBoxRecipe.Size = New System.Drawing.Size(205, 20)
        Me.TextBoxRecipe.TabIndex = 2
        '
        'ComboBoxRecipeIndex
        '
        Me.ComboBoxRecipeIndex.FormattingEnabled = True
        Me.ComboBoxRecipeIndex.Location = New System.Drawing.Point(259, 431)
        Me.ComboBoxRecipeIndex.Name = "ComboBoxRecipeIndex"
        Me.ComboBoxRecipeIndex.Size = New System.Drawing.Size(75, 21)
        Me.ComboBoxRecipeIndex.TabIndex = 3
        '
        'ButtonCreateFile
        '
        Me.ButtonCreateFile.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCreateFile.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCreateFile.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCreateFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCreateFile.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonCreateFile.Location = New System.Drawing.Point(392, 79)
        Me.ButtonCreateFile.Name = "ButtonCreateFile"
        Me.ButtonCreateFile.Size = New System.Drawing.Size(90, 26)
        Me.ButtonCreateFile.TabIndex = 66
        Me.ButtonCreateFile.TabStop = False
        Me.ButtonCreateFile.Text = "Create file"
        Me.ButtonCreateFile.UseVisualStyleBackColor = True
        '
        'ButtonSize
        '
        Me.ButtonSize.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSize.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSize.ForeColor = System.Drawing.Color.White
        Me.ButtonSize.Location = New System.Drawing.Point(291, 12)
        Me.ButtonSize.Name = "ButtonSize"
        Me.ButtonSize.Size = New System.Drawing.Size(25, 25)
        Me.ButtonSize.TabIndex = 68
        Me.ButtonSize.TabStop = False
        Me.ButtonSize.Text = "+"
        Me.ButtonSize.UseVisualStyleBackColor = True
        '
        'Label0001
        '
        Me.Label0001.AutoSize = True
        Me.Label0001.Font = New System.Drawing.Font("Arial Unicode MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0001.ForeColor = System.Drawing.Color.White
        Me.Label0001.Location = New System.Drawing.Point(14, 48)
        Me.Label0001.Name = "Label0001"
        Me.Label0001.Size = New System.Drawing.Size(86, 21)
        Me.Label0001.TabIndex = 67
        Me.Label0001.Text = "USB Usart"
        '
        'Label0000
        '
        Me.Label0000.AutoSize = True
        Me.Label0000.Font = New System.Drawing.Font("Arial Unicode MS", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0000.ForeColor = System.Drawing.Color.White
        Me.Label0000.Location = New System.Drawing.Point(9, 9)
        Me.Label0000.Name = "Label0000"
        Me.Label0000.Size = New System.Drawing.Size(199, 39)
        Me.Label0000.TabIndex = 65
        Me.Label0000.Text = "SGS Interface"
        '
        'Lbl5004
        '
        Me.Lbl5004.AutoSize = True
        Me.Lbl5004.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Lbl5004.ForeColor = System.Drawing.Color.White
        Me.Lbl5004.Location = New System.Drawing.Point(14, 119)
        Me.Lbl5004.Name = "Lbl5004"
        Me.Lbl5004.Size = New System.Drawing.Size(78, 16)
        Me.Lbl5004.TabIndex = 132
        Me.Lbl5004.Text = "Parameters"
        '
        'ComboBoxParameters0000
        '
        Me.ComboBoxParameters0000.FormattingEnabled = True
        Me.ComboBoxParameters0000.Location = New System.Drawing.Point(108, 223)
        Me.ComboBoxParameters0000.Name = "ComboBoxParameters0000"
        Me.ComboBoxParameters0000.Size = New System.Drawing.Size(121, 21)
        Me.ComboBoxParameters0000.TabIndex = 145
        '
        'Lbl5012
        '
        Me.Lbl5012.AutoSize = True
        Me.Lbl5012.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl5012.Location = New System.Drawing.Point(26, 304)
        Me.Lbl5012.Name = "Lbl5012"
        Me.Lbl5012.Size = New System.Drawing.Size(41, 13)
        Me.Lbl5012.TabIndex = 141
        Me.Lbl5012.Text = "Recipe"
        '
        'Lbl5011
        '
        Me.Lbl5011.AutoSize = True
        Me.Lbl5011.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl5011.Location = New System.Drawing.Point(26, 278)
        Me.Lbl5011.Name = "Lbl5011"
        Me.Lbl5011.Size = New System.Drawing.Size(41, 13)
        Me.Lbl5011.TabIndex = 139
        Me.Lbl5011.Text = "Recipe"
        '
        'Lbl5008
        '
        Me.Lbl5008.AutoSize = True
        Me.Lbl5008.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl5008.Location = New System.Drawing.Point(26, 200)
        Me.Lbl5008.Name = "Lbl5008"
        Me.Lbl5008.Size = New System.Drawing.Size(41, 13)
        Me.Lbl5008.TabIndex = 140
        Me.Lbl5008.Text = "Recipe"
        '
        'Lbl5010
        '
        Me.Lbl5010.AutoSize = True
        Me.Lbl5010.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl5010.Location = New System.Drawing.Point(26, 252)
        Me.Lbl5010.Name = "Lbl5010"
        Me.Lbl5010.Size = New System.Drawing.Size(41, 13)
        Me.Lbl5010.TabIndex = 138
        Me.Lbl5010.Text = "Recipe"
        '
        'Lbl5009
        '
        Me.Lbl5009.AutoSize = True
        Me.Lbl5009.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl5009.Location = New System.Drawing.Point(26, 226)
        Me.Lbl5009.Name = "Lbl5009"
        Me.Lbl5009.Size = New System.Drawing.Size(41, 13)
        Me.Lbl5009.TabIndex = 137
        Me.Lbl5009.Text = "Recipe"
        '
        'Lbl5007
        '
        Me.Lbl5007.AutoSize = True
        Me.Lbl5007.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl5007.Location = New System.Drawing.Point(26, 174)
        Me.Lbl5007.Name = "Lbl5007"
        Me.Lbl5007.Size = New System.Drawing.Size(41, 13)
        Me.Lbl5007.TabIndex = 136
        Me.Lbl5007.Text = "Recipe"
        '
        'Lbl5006
        '
        Me.Lbl5006.AutoSize = True
        Me.Lbl5006.ForeColor = System.Drawing.SystemColors.Control
        Me.Lbl5006.Location = New System.Drawing.Point(26, 148)
        Me.Lbl5006.Name = "Lbl5006"
        Me.Lbl5006.Size = New System.Drawing.Size(41, 13)
        Me.Lbl5006.TabIndex = 135
        Me.Lbl5006.Text = "Recipe"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.SystemColors.Control
        Me.Label1.Location = New System.Drawing.Point(26, 330)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "Recipe"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.SystemColors.Control
        Me.Label2.Location = New System.Drawing.Point(26, 356)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 138
        Me.Label2.Text = "Recipe"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.SystemColors.Control
        Me.Label3.Location = New System.Drawing.Point(26, 382)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 139
        Me.Label3.Text = "Recipe"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.SystemColors.Control
        Me.Label4.Location = New System.Drawing.Point(26, 408)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 141
        Me.Label4.Text = "Recipe"
        '
        'TextBoxParameters0000
        '
        Me.TextBoxParameters0000.Location = New System.Drawing.Point(108, 145)
        Me.TextBoxParameters0000.Name = "TextBoxParameters0000"
        Me.TextBoxParameters0000.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0000.TabIndex = 142
        '
        'TextBoxParameters0002
        '
        Me.TextBoxParameters0002.Location = New System.Drawing.Point(108, 197)
        Me.TextBoxParameters0002.Name = "TextBoxParameters0002"
        Me.TextBoxParameters0002.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0002.TabIndex = 144
        '
        'TextBoxParameters0003
        '
        Me.TextBoxParameters0003.Location = New System.Drawing.Point(235, 223)
        Me.TextBoxParameters0003.Name = "TextBoxParameters0003"
        Me.TextBoxParameters0003.Size = New System.Drawing.Size(15, 20)
        Me.TextBoxParameters0003.TabIndex = 142
        '
        'TextBoxParameters0004
        '
        Me.TextBoxParameters0004.Location = New System.Drawing.Point(108, 249)
        Me.TextBoxParameters0004.Name = "TextBoxParameters0004"
        Me.TextBoxParameters0004.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0004.TabIndex = 146
        '
        'TextBoxParameters0005
        '
        Me.TextBoxParameters0005.Location = New System.Drawing.Point(108, 275)
        Me.TextBoxParameters0005.Name = "TextBoxParameters0005"
        Me.TextBoxParameters0005.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0005.TabIndex = 147
        '
        'TextBoxParameters0006
        '
        Me.TextBoxParameters0006.Location = New System.Drawing.Point(108, 301)
        Me.TextBoxParameters0006.Name = "TextBoxParameters0006"
        Me.TextBoxParameters0006.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0006.TabIndex = 148
        '
        'TextBoxParameters0007
        '
        Me.TextBoxParameters0007.Location = New System.Drawing.Point(108, 327)
        Me.TextBoxParameters0007.Name = "TextBoxParameters0007"
        Me.TextBoxParameters0007.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0007.TabIndex = 149
        '
        'TextBoxParameters0008
        '
        Me.TextBoxParameters0008.Location = New System.Drawing.Point(108, 353)
        Me.TextBoxParameters0008.Name = "TextBoxParameters0008"
        Me.TextBoxParameters0008.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0008.TabIndex = 150
        '
        'TextBoxParameters0009
        '
        Me.TextBoxParameters0009.Location = New System.Drawing.Point(108, 379)
        Me.TextBoxParameters0009.Name = "TextBoxParameters0009"
        Me.TextBoxParameters0009.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0009.TabIndex = 151
        '
        'TextBoxParameters0010
        '
        Me.TextBoxParameters0010.Location = New System.Drawing.Point(108, 405)
        Me.TextBoxParameters0010.Name = "TextBoxParameters0010"
        Me.TextBoxParameters0010.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0010.TabIndex = 152
        '
        'TextBoxParameters0001
        '
        Me.TextBoxParameters0001.Location = New System.Drawing.Point(108, 171)
        Me.TextBoxParameters0001.Name = "TextBoxParameters0001"
        Me.TextBoxParameters0001.Size = New System.Drawing.Size(100, 20)
        Me.TextBoxParameters0001.TabIndex = 143
        '
        'Form_Recipes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(508, 473)
        Me.Controls.Add(Me.TextBoxParameters0001)
        Me.Controls.Add(Me.TextBoxParameters0010)
        Me.Controls.Add(Me.TextBoxParameters0009)
        Me.Controls.Add(Me.TextBoxParameters0008)
        Me.Controls.Add(Me.TextBoxParameters0007)
        Me.Controls.Add(Me.TextBoxParameters0006)
        Me.Controls.Add(Me.TextBoxParameters0005)
        Me.Controls.Add(Me.TextBoxParameters0004)
        Me.Controls.Add(Me.TextBoxParameters0003)
        Me.Controls.Add(Me.TextBoxParameters0002)
        Me.Controls.Add(Me.TextBoxParameters0000)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Lbl5012)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Lbl5011)
        Me.Controls.Add(Me.Lbl5008)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Lbl5010)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Lbl5009)
        Me.Controls.Add(Me.Lbl5007)
        Me.Controls.Add(Me.Lbl5006)
        Me.Controls.Add(Me.ComboBoxParameters0000)
        Me.Controls.Add(Me.Lbl5004)
        Me.Controls.Add(Me.ButtonCreateFile)
        Me.Controls.Add(Me.ButtonSize)
        Me.Controls.Add(Me.Label0001)
        Me.Controls.Add(Me.Label0000)
        Me.Controls.Add(Me.ComboBoxRecipeIndex)
        Me.Controls.Add(Me.TextBoxRecipe)
        Me.Controls.Add(Me.ButtonNext)
        Me.Controls.Add(Me.ButtonPrevious)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form_Recipes"
        Me.Opacity = 0.90000000000000002R
        Me.Text = "Form_Recipes"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ButtonPrevious As System.Windows.Forms.Button
    Friend WithEvents ButtonNext As System.Windows.Forms.Button
    Friend WithEvents TextBoxRecipe As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxRecipeIndex As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonCreateFile As System.Windows.Forms.Button
    Friend WithEvents ButtonSize As System.Windows.Forms.Button
    Friend WithEvents Label0001 As System.Windows.Forms.Label
    Friend WithEvents Label0000 As System.Windows.Forms.Label
    Friend WithEvents Lbl5004 As System.Windows.Forms.Label
    Friend WithEvents ComboBoxParameters0000 As System.Windows.Forms.ComboBox
    Friend WithEvents Lbl5012 As System.Windows.Forms.Label
    Friend WithEvents Lbl5011 As System.Windows.Forms.Label
    Friend WithEvents Lbl5008 As System.Windows.Forms.Label
    Friend WithEvents Lbl5010 As System.Windows.Forms.Label
    Friend WithEvents Lbl5009 As System.Windows.Forms.Label
    Friend WithEvents Lbl5007 As System.Windows.Forms.Label
    Friend WithEvents Lbl5006 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBoxParameters0000 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0002 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0003 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0004 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0005 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0006 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0007 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0008 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0009 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0010 As System.Windows.Forms.TextBox
    Friend WithEvents TextBoxParameters0001 As System.Windows.Forms.TextBox
End Class

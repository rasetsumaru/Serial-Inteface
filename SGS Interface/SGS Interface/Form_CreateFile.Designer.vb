<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_CreateFile
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
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

    'Exigido pelo Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'OBSERVAÇÃO: o procedimento a seguir é exigido pelo Windows Form Designer
    'Pode ser modificado usando o Windows Form Designer.  
    'Não o modifique usando o editor de códigos.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonConfirm = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonSize = New System.Windows.Forms.Button()
        Me.Label0001 = New System.Windows.Forms.Label()
        Me.Label0000 = New System.Windows.Forms.Label()
        Me.ComboBoxFirmware = New System.Windows.Forms.ComboBox()
        Me.ButtonBrowse = New System.Windows.Forms.Button()
        Me.Label0003 = New System.Windows.Forms.Label()
        Me.Label0002 = New System.Windows.Forms.Label()
        Me.LabelDirectory = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ButtonCancel
        '
        Me.ButtonCancel.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCancel.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancel.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonCancel.Location = New System.Drawing.Point(413, 26)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(90, 26)
        Me.ButtonCancel.TabIndex = 2
        Me.ButtonCancel.TabStop = False
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonConfirm
        '
        Me.ButtonConfirm.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonConfirm.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonConfirm.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonConfirm.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConfirm.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonConfirm.Location = New System.Drawing.Point(317, 26)
        Me.ButtonConfirm.Name = "ButtonConfirm"
        Me.ButtonConfirm.Size = New System.Drawing.Size(90, 26)
        Me.ButtonConfirm.TabIndex = 1
        Me.ButtonConfirm.TabStop = False
        Me.ButtonConfirm.Text = "Confirm"
        Me.ButtonConfirm.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ButtonCancel)
        Me.Panel1.Controls.Add(Me.ButtonConfirm)
        Me.Panel1.Location = New System.Drawing.Point(-2, 169)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(540, 83)
        Me.Panel1.TabIndex = 8
        '
        'ButtonSize
        '
        Me.ButtonSize.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSize.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSize.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ButtonSize.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonSize.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButtonSize.ForeColor = System.Drawing.Color.White
        Me.ButtonSize.Location = New System.Drawing.Point(498, 12)
        Me.ButtonSize.Name = "ButtonSize"
        Me.ButtonSize.Size = New System.Drawing.Size(25, 25)
        Me.ButtonSize.TabIndex = 12
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
        Me.Label0001.Size = New System.Drawing.Size(109, 21)
        Me.Label0001.TabIndex = 11
        Me.Label0001.Text = "File properties"
        '
        'Label0000
        '
        Me.Label0000.AutoSize = True
        Me.Label0000.Font = New System.Drawing.Font("Arial Unicode MS", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0000.ForeColor = System.Drawing.Color.White
        Me.Label0000.Location = New System.Drawing.Point(9, 9)
        Me.Label0000.Name = "Label0000"
        Me.Label0000.Size = New System.Drawing.Size(199, 39)
        Me.Label0000.TabIndex = 10
        Me.Label0000.Text = "SGS Interface"
        '
        'ComboBoxFirmware
        '
        Me.ComboBoxFirmware.BackColor = System.Drawing.SystemColors.Window
        Me.ComboBoxFirmware.FormattingEnabled = True
        Me.ComboBoxFirmware.Location = New System.Drawing.Point(95, 93)
        Me.ComboBoxFirmware.Name = "ComboBoxFirmware"
        Me.ComboBoxFirmware.Size = New System.Drawing.Size(72, 21)
        Me.ComboBoxFirmware.TabIndex = 13
        '
        'ButtonBrowse
        '
        Me.ButtonBrowse.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonBrowse.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonBrowse.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonBrowse.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonBrowse.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonBrowse.Location = New System.Drawing.Point(411, 115)
        Me.ButtonBrowse.Name = "ButtonBrowse"
        Me.ButtonBrowse.Size = New System.Drawing.Size(90, 26)
        Me.ButtonBrowse.TabIndex = 3
        Me.ButtonBrowse.TabStop = False
        Me.ButtonBrowse.Text = "Browse"
        Me.ButtonBrowse.UseVisualStyleBackColor = True
        '
        'Label0003
        '
        Me.Label0003.AutoSize = True
        Me.Label0003.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0003.Location = New System.Drawing.Point(26, 122)
        Me.Label0003.Name = "Label0003"
        Me.Label0003.Size = New System.Drawing.Size(52, 13)
        Me.Label0003.TabIndex = 47
        Me.Label0003.Text = "Directory:"
        '
        'Label0002
        '
        Me.Label0002.AutoSize = True
        Me.Label0002.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0002.Location = New System.Drawing.Point(26, 96)
        Me.Label0002.Name = "Label0002"
        Me.Label0002.Size = New System.Drawing.Size(52, 13)
        Me.Label0002.TabIndex = 46
        Me.Label0002.Text = "Firmware:"
        '
        'LabelDirectory
        '
        Me.LabelDirectory.AutoSize = True
        Me.LabelDirectory.ForeColor = System.Drawing.SystemColors.Control
        Me.LabelDirectory.Location = New System.Drawing.Point(92, 122)
        Me.LabelDirectory.Name = "LabelDirectory"
        Me.LabelDirectory.Size = New System.Drawing.Size(0, 13)
        Me.LabelDirectory.TabIndex = 48
        '
        'Form_CreateFile
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(534, 248)
        Me.Controls.Add(Me.LabelDirectory)
        Me.Controls.Add(Me.Label0003)
        Me.Controls.Add(Me.Label0002)
        Me.Controls.Add(Me.ButtonBrowse)
        Me.Controls.Add(Me.ComboBoxFirmware)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonSize)
        Me.Controls.Add(Me.Label0001)
        Me.Controls.Add(Me.Label0000)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_CreateFile"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form_MessageBox"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ButtonCancel As Button
    Friend WithEvents ButtonConfirm As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TimerRearm As Timer
    Friend WithEvents ButtonSize As Button
    Friend WithEvents Label0001 As Label
    Friend WithEvents Label0000 As Label
    Friend WithEvents TimerResult As Timer
    Friend WithEvents TimerResultTest As Timer
    Friend WithEvents ComboBoxFirmware As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonBrowse As System.Windows.Forms.Button
    Friend WithEvents Label0003 As System.Windows.Forms.Label
    Friend WithEvents Label0002 As System.Windows.Forms.Label
    Friend WithEvents LabelDirectory As System.Windows.Forms.Label
End Class

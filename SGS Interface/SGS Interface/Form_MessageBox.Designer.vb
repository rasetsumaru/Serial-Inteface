<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_MessageBox
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
        Me.components = New System.ComponentModel.Container()
        Me.Button01 = New System.Windows.Forms.Button()
        Me.Button02 = New System.Windows.Forms.Button()
        Me.Button03 = New System.Windows.Forms.Button()
        Me.LabelMessage = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TimerRearm = New System.Windows.Forms.Timer(Me.components)
        Me.ButtonSize = New System.Windows.Forms.Button()
        Me.Label0001 = New System.Windows.Forms.Label()
        Me.Label0000 = New System.Windows.Forms.Label()
        Me.TimerResult = New System.Windows.Forms.Timer(Me.components)
        Me.TimerResultTest = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button01
        '
        Me.Button01.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Button01.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button01.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button01.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button01.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button01.ForeColor = System.Drawing.SystemColors.Control
        Me.Button01.Location = New System.Drawing.Point(413, 26)
        Me.Button01.Name = "Button01"
        Me.Button01.Size = New System.Drawing.Size(90, 26)
        Me.Button01.TabIndex = 2
        Me.Button01.TabStop = False
        Me.Button01.Text = "Button01"
        Me.Button01.UseVisualStyleBackColor = True
        Me.Button01.Visible = False
        '
        'Button02
        '
        Me.Button02.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Button02.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button02.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button02.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button02.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button02.ForeColor = System.Drawing.SystemColors.Control
        Me.Button02.Location = New System.Drawing.Point(317, 26)
        Me.Button02.Name = "Button02"
        Me.Button02.Size = New System.Drawing.Size(90, 26)
        Me.Button02.TabIndex = 1
        Me.Button02.TabStop = False
        Me.Button02.Text = "Button02"
        Me.Button02.UseVisualStyleBackColor = True
        Me.Button02.Visible = False
        '
        'Button03
        '
        Me.Button03.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.Button03.FlatAppearance.CheckedBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button03.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button03.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.Button03.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button03.ForeColor = System.Drawing.SystemColors.Control
        Me.Button03.Location = New System.Drawing.Point(221, 26)
        Me.Button03.Name = "Button03"
        Me.Button03.Size = New System.Drawing.Size(90, 26)
        Me.Button03.TabIndex = 0
        Me.Button03.TabStop = False
        Me.Button03.Text = "Button03"
        Me.Button03.UseVisualStyleBackColor = True
        Me.Button03.Visible = False
        '
        'LabelMessage
        '
        Me.LabelMessage.ForeColor = System.Drawing.SystemColors.Control
        Me.LabelMessage.Location = New System.Drawing.Point(13, 119)
        Me.LabelMessage.Name = "LabelMessage"
        Me.LabelMessage.Size = New System.Drawing.Size(414, 43)
        Me.LabelMessage.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Button01)
        Me.Panel1.Controls.Add(Me.Button02)
        Me.Panel1.Controls.Add(Me.Button03)
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
        Me.Label0001.Size = New System.Drawing.Size(105, 21)
        Me.Label0001.TabIndex = 11
        Me.Label0001.Text = "Message box"
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
        'TimerResult
        '
        Me.TimerResult.Interval = 1500
        '
        'TimerResultTest
        '
        Me.TimerResultTest.Interval = 200
        '
        'Form_MessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DimGray
        Me.ClientSize = New System.Drawing.Size(534, 248)
        Me.Controls.Add(Me.LabelMessage)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonSize)
        Me.Controls.Add(Me.Label0001)
        Me.Controls.Add(Me.Label0000)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form_MessageBox"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form_MessageBox"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button01 As Button
    Friend WithEvents Button02 As Button
    Friend WithEvents Button03 As Button
    Friend WithEvents LabelMessage As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TimerRearm As Timer
    Friend WithEvents ButtonSize As Button
    Friend WithEvents Label0001 As Label
    Friend WithEvents Label0000 As Label
    Friend WithEvents TimerResult As Timer
    Friend WithEvents TimerResultTest As Timer
End Class

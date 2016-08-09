<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_SplashScreen
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ApplicationTitle = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Version = New System.Windows.Forms.Label()
        Me.Copyright = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ApplicationTitle
        '
        Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
        Me.ApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplicationTitle.ForeColor = System.Drawing.Color.White
        Me.ApplicationTitle.Location = New System.Drawing.Point(34, 134)
        Me.ApplicationTitle.Name = "ApplicationTitle"
        Me.ApplicationTitle.Size = New System.Drawing.Size(388, 32)
        Me.ApplicationTitle.TabIndex = 7
        Me.ApplicationTitle.Text = "Application Title"
        Me.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.ApplicationTitle.UseWaitCursor = True
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(-4, -6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(408, 29)
        Me.Panel2.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(-19, 169)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(408, 10)
        Me.Panel1.TabIndex = 11
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Image = Global.SGS_interface.My.Resources.Resources.LogoSolitec
        Me.PictureBox1.Location = New System.Drawing.Point(-4, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(375, 160)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 10
        Me.PictureBox1.TabStop = False
        '
        'Version
        '
        Me.Version.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Version.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.SystemColors.Control
        Me.Version.Location = New System.Drawing.Point(201, 360)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(154, 20)
        Me.Version.TabIndex = 8
        Me.Version.Text = "Version {0}.{1:00}"
        Me.Version.UseWaitCursor = True
        '
        'Copyright
        '
        Me.Copyright.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Copyright.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Copyright.ForeColor = System.Drawing.SystemColors.Control
        Me.Copyright.Location = New System.Drawing.Point(201, 380)
        Me.Copyright.Name = "Copyright"
        Me.Copyright.Size = New System.Drawing.Size(154, 29)
        Me.Copyright.TabIndex = 9
        Me.Copyright.Text = "Copyright"
        Me.Copyright.UseWaitCursor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(-2, 336)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(371, 86)
        Me.Panel3.TabIndex = 13
        '
        'Form_SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(367, 420)
        Me.ControlBox = False
        Me.Controls.Add(Me.ApplicationTitle)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.Copyright)
        Me.Controls.Add(Me.Panel3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_SplashScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ApplicationTitle As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Version As Label
    Friend WithEvents Copyright As Label
    Friend WithEvents Panel3 As Panel
End Class

﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Controller
    Inherits System.Windows.Forms.Form

    'Descartar substituições de formulário para limpar a lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Controller))
        Me.TextBoxReceiver = New System.Windows.Forms.TextBox()
        Me.Panel0000 = New System.Windows.Forms.Panel()
        Me.ButtonConnect = New System.Windows.Forms.Button()
        Me.LabelHour = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.Label0001 = New System.Windows.Forms.Label()
        Me.Label0000 = New System.Windows.Forms.Label()
        Me.ButtonSize = New System.Windows.Forms.Button()
        Me.PanelRx = New System.Windows.Forms.Panel()
        Me.PanelTx = New System.Windows.Forms.Panel()
        Me.Label0002 = New System.Windows.Forms.Label()
        Me.Label0003 = New System.Windows.Forms.Label()
        Me.Label0004 = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.Label0005 = New System.Windows.Forms.Label()
        Me.Label0008 = New System.Windows.Forms.Label()
        Me.Label0007 = New System.Windows.Forms.Label()
        Me.Label0006 = New System.Windows.Forms.Label()
        Me.Label0011 = New System.Windows.Forms.Label()
        Me.Label0009 = New System.Windows.Forms.Label()
        Me.Label0010 = New System.Windows.Forms.Label()
        Me.Panel0000.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextBoxReceiver
        '
        Me.TextBoxReceiver.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.TextBoxReceiver.Location = New System.Drawing.Point(196, 552)
        Me.TextBoxReceiver.Name = "TextBoxReceiver"
        Me.TextBoxReceiver.Size = New System.Drawing.Size(119, 20)
        Me.TextBoxReceiver.TabIndex = 8
        Me.TextBoxReceiver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextBoxReceiver.Visible = False
        '
        'Panel0000
        '
        Me.Panel0000.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel0000.Controls.Add(Me.ButtonConnect)
        Me.Panel0000.Controls.Add(Me.LabelHour)
        Me.Panel0000.Controls.Add(Me.ButtonClose)
        Me.Panel0000.Location = New System.Drawing.Point(-2, 607)
        Me.Panel0000.Name = "Panel0000"
        Me.Panel0000.Size = New System.Drawing.Size(337, 83)
        Me.Panel0000.TabIndex = 34
        '
        'ButtonConnect
        '
        Me.ButtonConnect.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonConnect.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonConnect.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonConnect.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonConnect.Location = New System.Drawing.Point(132, 45)
        Me.ButtonConnect.Name = "ButtonConnect"
        Me.ButtonConnect.Size = New System.Drawing.Size(90, 26)
        Me.ButtonConnect.TabIndex = 35
        Me.ButtonConnect.TabStop = False
        Me.ButtonConnect.Text = "Connect"
        Me.ButtonConnect.UseVisualStyleBackColor = True
        '
        'LabelHour
        '
        Me.LabelHour.AutoSize = True
        Me.LabelHour.ForeColor = System.Drawing.SystemColors.Control
        Me.LabelHour.Location = New System.Drawing.Point(14, 59)
        Me.LabelHour.Name = "LabelHour"
        Me.LabelHour.Size = New System.Drawing.Size(49, 13)
        Me.LabelHour.TabIndex = 34
        Me.LabelHour.Text = "00:00:00"
        '
        'ButtonClose
        '
        Me.ButtonClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonClose.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ControlDark
        Me.ButtonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonClose.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonClose.Location = New System.Drawing.Point(228, 45)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(90, 26)
        Me.ButtonClose.TabIndex = 4
        Me.ButtonClose.TabStop = False
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'Label0001
        '
        Me.Label0001.AutoSize = True
        Me.Label0001.Font = New System.Drawing.Font("Arial Unicode MS", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0001.ForeColor = System.Drawing.Color.White
        Me.Label0001.Location = New System.Drawing.Point(14, 48)
        Me.Label0001.Name = "Label0001"
        Me.Label0001.Size = New System.Drawing.Size(86, 21)
        Me.Label0001.TabIndex = 36
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
        Me.Label0000.TabIndex = 35
        Me.Label0000.Text = "SGS Interface"
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
        Me.ButtonSize.TabIndex = 37
        Me.ButtonSize.TabStop = False
        Me.ButtonSize.Text = "+"
        Me.ButtonSize.UseVisualStyleBackColor = True
        '
        'PanelRx
        '
        Me.PanelRx.BackColor = System.Drawing.Color.Transparent
        Me.PanelRx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelRx.Location = New System.Drawing.Point(26, 524)
        Me.PanelRx.Name = "PanelRx"
        Me.PanelRx.Size = New System.Drawing.Size(15, 15)
        Me.PanelRx.TabIndex = 42
        '
        'PanelTx
        '
        Me.PanelTx.BackColor = System.Drawing.Color.Transparent
        Me.PanelTx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PanelTx.Location = New System.Drawing.Point(26, 498)
        Me.PanelTx.Name = "PanelTx"
        Me.PanelTx.Size = New System.Drawing.Size(15, 15)
        Me.PanelTx.TabIndex = 41
        '
        'Label0002
        '
        Me.Label0002.AutoSize = True
        Me.Label0002.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0002.ForeColor = System.Drawing.Color.White
        Me.Label0002.Location = New System.Drawing.Point(14, 469)
        Me.Label0002.Name = "Label0002"
        Me.Label0002.Size = New System.Drawing.Size(89, 16)
        Me.Label0002.TabIndex = 40
        Me.Label0002.Text = "PCB Interface"
        '
        'Label0003
        '
        Me.Label0003.AutoSize = True
        Me.Label0003.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0003.Location = New System.Drawing.Point(52, 498)
        Me.Label0003.Name = "Label0003"
        Me.Label0003.Size = New System.Drawing.Size(83, 13)
        Me.Label0003.TabIndex = 38
        Me.Label0003.Text = "USB Usart send"
        '
        'Label0004
        '
        Me.Label0004.AutoSize = True
        Me.Label0004.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0004.Location = New System.Drawing.Point(52, 524)
        Me.Label0004.Name = "Label0004"
        Me.Label0004.Size = New System.Drawing.Size(95, 13)
        Me.Label0004.TabIndex = 39
        Me.Label0004.Text = "USB Usart receive"
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(13, 578)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(302, 10)
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar.TabIndex = 43
        '
        'Label0005
        '
        Me.Label0005.AutoSize = True
        Me.Label0005.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label0005.ForeColor = System.Drawing.Color.White
        Me.Label0005.Location = New System.Drawing.Point(14, 119)
        Me.Label0005.Name = "Label0005"
        Me.Label0005.Size = New System.Drawing.Size(115, 16)
        Me.Label0005.TabIndex = 50
        Me.Label0005.Text = "Connection Status"
        '
        'Label0008
        '
        Me.Label0008.AutoSize = True
        Me.Label0008.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0008.Location = New System.Drawing.Point(26, 200)
        Me.Label0008.Name = "Label0008"
        Me.Label0008.Size = New System.Drawing.Size(52, 13)
        Me.Label0008.TabIndex = 49
        Me.Label0008.Text = "Firmware:"
        '
        'Label0007
        '
        Me.Label0007.AutoSize = True
        Me.Label0007.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0007.Location = New System.Drawing.Point(26, 174)
        Me.Label0007.Name = "Label0007"
        Me.Label0007.Size = New System.Drawing.Size(56, 13)
        Me.Label0007.TabIndex = 45
        Me.Label0007.Text = "Hardware:"
        '
        'Label0006
        '
        Me.Label0006.AutoSize = True
        Me.Label0006.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0006.Location = New System.Drawing.Point(26, 148)
        Me.Label0006.Name = "Label0006"
        Me.Label0006.Size = New System.Drawing.Size(47, 13)
        Me.Label0006.TabIndex = 44
        Me.Label0006.Text = "Product:"
        '
        'Label0011
        '
        Me.Label0011.AutoSize = True
        Me.Label0011.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0011.Location = New System.Drawing.Point(91, 200)
        Me.Label0011.Name = "Label0011"
        Me.Label0011.Size = New System.Drawing.Size(59, 13)
        Me.Label0011.TabIndex = 51
        Me.Label0011.Text = "Desconect"
        '
        'Label0009
        '
        Me.Label0009.AutoSize = True
        Me.Label0009.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0009.Location = New System.Drawing.Point(91, 148)
        Me.Label0009.Name = "Label0009"
        Me.Label0009.Size = New System.Drawing.Size(59, 13)
        Me.Label0009.TabIndex = 52
        Me.Label0009.Text = "Desconect"
        '
        'Label0010
        '
        Me.Label0010.AutoSize = True
        Me.Label0010.ForeColor = System.Drawing.SystemColors.Control
        Me.Label0010.Location = New System.Drawing.Point(91, 174)
        Me.Label0010.Name = "Label0010"
        Me.Label0010.Size = New System.Drawing.Size(59, 13)
        Me.Label0010.TabIndex = 53
        Me.Label0010.Text = "Desconect"
        '
        'Form_Controller
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlDarkDark
        Me.ClientSize = New System.Drawing.Size(328, 689)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label0010)
        Me.Controls.Add(Me.Label0009)
        Me.Controls.Add(Me.Label0011)
        Me.Controls.Add(Me.Label0005)
        Me.Controls.Add(Me.Label0008)
        Me.Controls.Add(Me.Label0007)
        Me.Controls.Add(Me.Label0006)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.PanelRx)
        Me.Controls.Add(Me.PanelTx)
        Me.Controls.Add(Me.Label0002)
        Me.Controls.Add(Me.Label0003)
        Me.Controls.Add(Me.Label0004)
        Me.Controls.Add(Me.ButtonSize)
        Me.Controls.Add(Me.Label0001)
        Me.Controls.Add(Me.Label0000)
        Me.Controls.Add(Me.Panel0000)
        Me.Controls.Add(Me.TextBoxReceiver)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(10, 25)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Controller"
        Me.Opacity = 0.9R
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "SGS Interface"
        Me.Panel0000.ResumeLayout(False)
        Me.Panel0000.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextBoxReceiver As TextBox
    Friend WithEvents Panel0000 As Panel
    Friend WithEvents Button03 As Button
    Friend WithEvents LabelHour As Label
    Friend WithEvents ButtonClose As Button
    Friend WithEvents Label0001 As Label
    Friend WithEvents Label0000 As Label
    Friend WithEvents ButtonSize As Button
    Friend WithEvents ButtonConnect As Button
    Friend WithEvents PanelRx As Panel
    Friend WithEvents PanelTx As Panel
    Friend WithEvents Label0002 As Label
    Friend WithEvents Label0003 As Label
    Friend WithEvents Label0004 As Label
    Friend WithEvents ProgressBar As ProgressBar
    Friend WithEvents Label0005 As Label
    Friend WithEvents Label0008 As Label
    Friend WithEvents Label0007 As Label
    Friend WithEvents Label0006 As Label
    Friend WithEvents Label0011 As Label
    Friend WithEvents Label0009 As Label
    Friend WithEvents Label0010 As Label
End Class
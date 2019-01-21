<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container
        Me.timer_missile_move = New System.Windows.Forms.Timer(Me.components)
        Me.speed_slider = New System.Windows.Forms.TrackBar
        Me.timer_create_ship = New System.Windows.Forms.Timer(Me.components)
        Me.timer_ship_move = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.launcher_silo = New System.Windows.Forms.Button
        Me.launcher_crosshairs = New System.Windows.Forms.RadioButton
        Me.launcher_trackbar = New System.Windows.Forms.TrackBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        CType(Me.speed_slider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.launcher_trackbar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timer_missile_move
        '
        Me.timer_missile_move.Enabled = True
        Me.timer_missile_move.Interval = 50
        '
        'speed_slider
        '
        Me.speed_slider.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.speed_slider.Location = New System.Drawing.Point(12, 426)
        Me.speed_slider.Maximum = 30
        Me.speed_slider.Minimum = 10
        Me.speed_slider.Name = "speed_slider"
        Me.speed_slider.Size = New System.Drawing.Size(106, 45)
        Me.speed_slider.TabIndex = 3
        Me.speed_slider.TickFrequency = 5
        Me.speed_slider.Value = 20
        '
        'timer_create_ship
        '
        Me.timer_create_ship.Enabled = True
        '
        'timer_ship_move
        '
        Me.timer_ship_move.Enabled = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(113, 433)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "FireSpeed"
        '
        'launcher_silo
        '
        Me.launcher_silo.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.launcher_silo.BackColor = System.Drawing.SystemColors.ControlText
        Me.launcher_silo.Location = New System.Drawing.Point(432, 396)
        Me.launcher_silo.Name = "launcher_silo"
        Me.launcher_silo.Size = New System.Drawing.Size(16, 24)
        Me.launcher_silo.TabIndex = 6
        Me.launcher_silo.UseVisualStyleBackColor = False
        '
        'launcher_crosshairs
        '
        Me.launcher_crosshairs.AutoSize = True
        Me.launcher_crosshairs.BackColor = System.Drawing.Color.Yellow
        Me.launcher_crosshairs.Location = New System.Drawing.Point(434, 307)
        Me.launcher_crosshairs.Name = "launcher_crosshairs"
        Me.launcher_crosshairs.Size = New System.Drawing.Size(14, 13)
        Me.launcher_crosshairs.TabIndex = 7
        Me.launcher_crosshairs.TabStop = True
        Me.launcher_crosshairs.UseVisualStyleBackColor = False
        '
        'launcher_trackbar
        '
        Me.launcher_trackbar.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.launcher_trackbar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.launcher_trackbar.Location = New System.Drawing.Point(197, 426)
        Me.launcher_trackbar.Maximum = 160
        Me.launcher_trackbar.Minimum = 20
        Me.launcher_trackbar.Name = "launcher_trackbar"
        Me.launcher_trackbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.launcher_trackbar.RightToLeftLayout = True
        Me.launcher_trackbar.Size = New System.Drawing.Size(488, 45)
        Me.launcher_trackbar.TabIndex = 8
        Me.launcher_trackbar.TickFrequency = 10
        Me.launcher_trackbar.Value = 90
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(706, 427)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 9
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New System.Drawing.Point(691, 407)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(197, 64)
        Me.TextBox1.TabIndex = 10
        Me.TextBox1.Text = "Hold down launch slider and move left or right to aim." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Press space to fire. Chan" & _
            "ge fire speed as required"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.LightGray
        Me.PictureBox1.BackgroundImage = Global.shooter1.My.Resources.Resources.ocean_for_d_day
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(-3, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(891, 420)
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(888, 465)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.launcher_trackbar)
        Me.Controls.Add(Me.launcher_crosshairs)
        Me.Controls.Add(Me.launcher_silo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.speed_slider)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.speed_slider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.launcher_trackbar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timer_missile_move As System.Windows.Forms.Timer
    Friend WithEvents speed_slider As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents timer_create_ship As System.Windows.Forms.Timer
    Friend WithEvents timer_ship_move As System.Windows.Forms.Timer
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents launcher_silo As System.Windows.Forms.Button
    Friend WithEvents launcher_crosshairs As System.Windows.Forms.RadioButton
    Friend WithEvents launcher_trackbar As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox

End Class

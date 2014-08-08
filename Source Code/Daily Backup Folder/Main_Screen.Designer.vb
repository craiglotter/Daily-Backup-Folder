<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Screen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main_Screen))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.HelpToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.AutoUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Button1 = New System.Windows.Forms.Button
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker
        Me.StatusLabel = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Setting_SourceFolder = New System.Windows.Forms.Label
        Me.Setting_BackupFolder = New System.Windows.Forms.Label
        Me.Setting_ScheduledTime = New System.Windows.Forms.Label
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.Button2 = New System.Windows.Forms.Button
        Me.ScheduledTime = New System.Windows.Forms.Label
        Me.CurrentTime = New System.Windows.Forms.Label
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.spacer_label = New System.Windows.Forms.Label
        Me.backup_label = New System.Windows.Forms.Label
        Me.source_label = New System.Windows.Forms.Label
        Me.Button4 = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem1, Me.AboutToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(449, 24)
        Me.MenuStrip1.TabIndex = 4
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'HelpToolStripMenuItem1
        '
        Me.HelpToolStripMenuItem1.Name = "HelpToolStripMenuItem1"
        Me.HelpToolStripMenuItem1.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem1.Text = "Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem1, Me.AutoUpdateToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'AboutToolStripMenuItem1
        '
        Me.AboutToolStripMenuItem1.Name = "AboutToolStripMenuItem1"
        Me.AboutToolStripMenuItem1.Size = New System.Drawing.Size(143, 22)
        Me.AboutToolStripMenuItem1.Text = "About"
        '
        'AutoUpdateToolStripMenuItem
        '
        Me.AutoUpdateToolStripMenuItem.Name = "AutoUpdateToolStripMenuItem"
        Me.AutoUpdateToolStripMenuItem.Size = New System.Drawing.Size(143, 22)
        Me.AutoUpdateToolStripMenuItem.Text = "AutoUpdate"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(129, 183)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(102, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Force Backup"
        Me.ToolTip1.SetToolTip(Me.Button1, "Force Backup Operation")
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BackgroundWorker1
        '
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        '
        'StatusLabel
        '
        Me.StatusLabel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.StatusLabel.ForeColor = System.Drawing.SystemColors.ControlDark
        Me.StatusLabel.Location = New System.Drawing.Point(0, 296)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Padding = New System.Windows.Forms.Padding(21, 0, 21, 0)
        Me.StatusLabel.Size = New System.Drawing.Size(449, 18)
        Me.StatusLabel.TabIndex = 21
        Me.StatusLabel.Text = "Application Loaded"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 109)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Folder to Backup:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Backup Location:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(18, 156)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(87, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Scheduled Time:"
        '
        'Setting_SourceFolder
        '
        Me.Setting_SourceFolder.AutoEllipsis = True
        Me.Setting_SourceFolder.ForeColor = System.Drawing.Color.Olive
        Me.Setting_SourceFolder.Location = New System.Drawing.Point(115, 109)
        Me.Setting_SourceFolder.Name = "Setting_SourceFolder"
        Me.Setting_SourceFolder.Size = New System.Drawing.Size(313, 13)
        Me.Setting_SourceFolder.TabIndex = 27
        '
        'Setting_BackupFolder
        '
        Me.Setting_BackupFolder.AutoEllipsis = True
        Me.Setting_BackupFolder.ForeColor = System.Drawing.Color.Olive
        Me.Setting_BackupFolder.Location = New System.Drawing.Point(115, 132)
        Me.Setting_BackupFolder.Name = "Setting_BackupFolder"
        Me.Setting_BackupFolder.Size = New System.Drawing.Size(313, 13)
        Me.Setting_BackupFolder.TabIndex = 29
        '
        'Setting_ScheduledTime
        '
        Me.Setting_ScheduledTime.AutoEllipsis = True
        Me.Setting_ScheduledTime.ForeColor = System.Drawing.Color.Olive
        Me.Setting_ScheduledTime.Location = New System.Drawing.Point(115, 156)
        Me.Setting_ScheduledTime.Name = "Setting_ScheduledTime"
        Me.Setting_ScheduledTime.Size = New System.Drawing.Size(248, 13)
        Me.Setting_ScheduledTime.TabIndex = 30
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Enabled = False
        Me.ProgressBar1.Location = New System.Drawing.Point(21, 212)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(407, 23)
        Me.ProgressBar1.TabIndex = 35
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(21, 183)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(102, 23)
        Me.Button2.TabIndex = 36
        Me.Button2.Text = "Settings"
        Me.ToolTip1.SetToolTip(Me.Button2, "Change the Operation Settings")
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ScheduledTime
        '
        Me.ScheduledTime.AutoSize = True
        Me.ScheduledTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ScheduledTime.ForeColor = System.Drawing.Color.Olive
        Me.ScheduledTime.Location = New System.Drawing.Point(272, 183)
        Me.ScheduledTime.Name = "ScheduledTime"
        Me.ScheduledTime.Size = New System.Drawing.Size(80, 24)
        Me.ScheduledTime.TabIndex = 37
        Me.ScheduledTime.Text = "00:00:00"
        Me.ToolTip1.SetToolTip(Me.ScheduledTime, "Time at which the Backup Operation will be carried out")
        '
        'CurrentTime
        '
        Me.CurrentTime.AutoSize = True
        Me.CurrentTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentTime.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CurrentTime.Location = New System.Drawing.Point(348, 183)
        Me.CurrentTime.Name = "CurrentTime"
        Me.CurrentTime.Size = New System.Drawing.Size(80, 24)
        Me.CurrentTime.TabIndex = 38
        Me.CurrentTime.Text = "00:00:00"
        Me.ToolTip1.SetToolTip(Me.CurrentTime, "Current System Time")
        '
        'Button3
        '
        Me.Button3.Enabled = False
        Me.Button3.Location = New System.Drawing.Point(352, 148)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(76, 31)
        Me.Button3.TabIndex = 39
        Me.Button3.Text = "Cancel"
        Me.ToolTip1.SetToolTip(Me.Button3, "Cancel Operation")
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'Panel1
        '
        Me.Panel1.BackgroundImage = Global.Daily_Backup_Folder.My.Resources.Resources.Form_Banner
        Me.Panel1.Location = New System.Drawing.Point(0, 24)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(449, 69)
        Me.Panel1.TabIndex = 11
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        '
        'spacer_label
        '
        Me.spacer_label.AutoEllipsis = True
        Me.spacer_label.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.spacer_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.spacer_label.Location = New System.Drawing.Point(0, 283)
        Me.spacer_label.Name = "spacer_label"
        Me.spacer_label.Size = New System.Drawing.Size(449, 13)
        Me.spacer_label.TabIndex = 40
        '
        'backup_label
        '
        Me.backup_label.AutoEllipsis = True
        Me.backup_label.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.backup_label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.backup_label.Location = New System.Drawing.Point(0, 270)
        Me.backup_label.Name = "backup_label"
        Me.backup_label.Padding = New System.Windows.Forms.Padding(21, 0, 21, 0)
        Me.backup_label.Size = New System.Drawing.Size(449, 13)
        Me.backup_label.TabIndex = 41
        Me.ToolTip1.SetToolTip(Me.backup_label, "Last Processed Backup Folder")
        '
        'source_label
        '
        Me.source_label.AutoEllipsis = True
        Me.source_label.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.source_label.ForeColor = System.Drawing.Color.Olive
        Me.source_label.Location = New System.Drawing.Point(0, 257)
        Me.source_label.Name = "source_label"
        Me.source_label.Padding = New System.Windows.Forms.Padding(21, 0, 21, 0)
        Me.source_label.Size = New System.Drawing.Size(449, 13)
        Me.source_label.TabIndex = 42
        Me.ToolTip1.SetToolTip(Me.source_label, "Last Processed Source Folder")
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(352, 122)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(76, 23)
        Me.Button4.TabIndex = 43
        Me.Button4.Text = "Minimise"
        Me.ToolTip1.SetToolTip(Me.Button4, "Minimise Application Window")
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(378, 238)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(50, 13)
        Me.LinkLabel1.TabIndex = 44
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Error Log"
        '
        'Main_Screen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 314)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.source_label)
        Me.Controls.Add(Me.backup_label)
        Me.Controls.Add(Me.spacer_label)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.CurrentTime)
        Me.Controls.Add(Me.ScheduledTime)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Setting_ScheduledTime)
        Me.Controls.Add(Me.Setting_BackupFolder)
        Me.Controls.Add(Me.Setting_SourceFolder)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main_Screen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents HelpToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AutoUpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents StatusLabel As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Setting_SourceFolder As System.Windows.Forms.Label
    Friend WithEvents Setting_BackupFolder As System.Windows.Forms.Label
    Friend WithEvents Setting_ScheduledTime As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ScheduledTime As System.Windows.Forms.Label
    Friend WithEvents CurrentTime As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents spacer_label As System.Windows.Forms.Label
    Friend WithEvents backup_label As System.Windows.Forms.Label
    Friend WithEvents source_label As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel

End Class

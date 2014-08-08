Imports System.IO
Imports System.Web.Mail


Public Class Main_Screen

    Private busyworking As Boolean = False
    Private AutoUpdate As Boolean = False

    Private Setting_SendMail As String = ""
    Private Setting_MailServer As String = ""
    Private Setting_FromAddress As String = ""
    Private Setting_ToAddress As String = ""
    Private Setting_LastBackupFolder As String = ""

    Private SetScheduledTime As Set_Scheduled_Time
    Private SetMailSettings As Set_Mail_Settings

    Private precountFiles As Long = 0
    Private precountFolders As Long = 0
    Private precountObjects As Long = 0

    Private countFiles As Long = 0
    Private countFolders As Long = 0
    Private countObjects As Long = 0

    Private creationfolder As String = ""
    Private source_label_text As String = ""
    Private backup_label_text As String = ""

    Dim shownminimizetip As Boolean = False

    Private Sub Error_Handler(ByVal ex As Exception, Optional ByVal identifier_msg As String = "")
        Try
            If ex.Message.IndexOf("Thread was being aborted") < 0 Then
                Dim Display_Message1 As New Display_Message()
                Display_Message1.Message_Textbox.Text = "The Application encountered the following problem: " & vbCrLf & identifier_msg & ": " & ex.ToString
                Display_Message1.Timer1.Interval = 1000
                Display_Message1.ShowDialog()
                Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs")
                If dir.Exists = False Then
                    dir.Create()
                End If
                dir = Nothing
                Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt", True)
                filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & identifier_msg & ": " & ex.ToString)
                filewriter.WriteLine("")
                filewriter.Flush()
                filewriter.Close()
                filewriter = Nothing
            End If
            StatusLabel.Text = "Error Reported"
        Catch exc As Exception
            MsgBox("An error occurred in the application's error handling routine. The application will try to recover from this serious error." & vbCrLf & vbCrLf & exc.ToString, MsgBoxStyle.Critical, "Critical Error Encountered")
        End Try
    End Sub

    Private Sub Activity_Handler(ByVal message As String)
        Try
            Dim dir As System.IO.DirectoryInfo = New System.IO.DirectoryInfo((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs")
            If dir.Exists = False Then
                dir.Create()
            End If
            dir = Nothing
            Dim filewriter As System.IO.StreamWriter = New System.IO.StreamWriter((Application.StartupPath & "\").Replace("\\", "\") & "Activity Logs\" & Format(Now(), "yyyyMMdd") & "_Activity_Log.txt", True)
            filewriter.WriteLine("#" & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & " - " & message)
            filewriter.WriteLine("")
            filewriter.Flush()
            filewriter.Close()
            filewriter = Nothing
            StatusLabel.Text = "Activity Logged"
        Catch ex As Exception
            Error_Handler(ex, "Activity Handler")
        End Try
    End Sub

    Private Sub SendNotificationEmail(ByVal StartOrClose As String)
        Try
            Dim body As String
            If StartOrClose = "Startup" Then
                body = "This is just a notification message to inform you that " & My.Application.Info.ProductName & " has been successfully started up."
            Else
                body = "This is just a notification message to inform you that " & My.Application.Info.ProductName & " has been shutdown."
            End If

            body = body & vbCrLf & vbCrLf & "******************************" & vbCrLf & vbCrLf & "This is an auto-generated email submitted from " & My.Application.Info.ProductName & " at " & Format(Now(), "dd/MM/yyyy hh:mm:ss tt") & ", running on:"
            body = body & vbCrLf & vbCrLf & "Machine Name: " + Environment.MachineName
            body = body & vbCrLf & "OS Version: " & Environment.OSVersion.ToString()
            body = body & vbCrLf & "User Name: " + Environment.UserName

            If StartOrClose = "Startup" Then
                TextMail(Setting_MailServer, Setting_FromAddress, Setting_ToAddress, My.Application.Info.ProductName & ": Application Startup", body)
            Else
                TextMail(Setting_MailServer, Setting_FromAddress, Setting_ToAddress, My.Application.Info.ProductName & ": Application Shutdown", body)
            End If

        Catch ex As Exception
            Error_Handler(ex, "Send Notification Email")
        End Try
    End Sub

    Public Function TextMail(ByVal SmtpServer As String, ByVal strFrom As String, ByVal strTo As String, ByVal strSubj As String, ByVal strBody As String, Optional ByRef strErrMsg As String = "") As Boolean
        Dim objMail As MailMessage
        Try
            Dim emailaddys As String()
            emailaddys = strTo.Split(";")

            Dim counter As Integer = 0
            For counter = 0 To emailaddys.Length - 1


                objMail = New MailMessage
                objMail.BodyFormat = MailFormat.Text
                objMail.From = strFrom
                objMail.To = emailaddys(counter).Trim
                objMail.Subject = strSubj
                objMail.Body = strBody

                SmtpMail.SmtpServer = SmtpServer
                SmtpMail.Send(objMail)
            Next
            TextMail = True
        Catch ex As Exception
            TextMail = False
            MsgBox("It appears as if the Mail Send function has failed. This notification service as as a result been turned off. You can re-enable the service using the Settings button", MsgBoxStyle.Information, "Mail Send Failed")
            Setting_SendMail = False
            Error_Handler(ex, "Send Mail")
        End Try
    End Function

    Private Sub Main_Screen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            NotifyIcon1.BalloonTipText = "You have chosen to hide " & My.Application.Info.ProductName & ". To bring it back up, simply click here."
            NotifyIcon1.BalloonTipTitle = "" & My.Application.Info.ProductName & ""
            NotifyIcon1.Text = "Click to bring up " & My.Application.Info.ProductName & ""
            shownminimizetip = False
            Control.CheckForIllegalCrossThreadCalls = False
            Me.Text = My.Application.Info.ProductName & " (" & Format(My.Application.Info.Version.Major, "0000") & Format(My.Application.Info.Version.Minor, "00") & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00") & ")"
            loadSettings()
            If Setting_SendMail = "True" Then
                StatusLabel.Text = "Sending Startup Notification Email"
                SendNotificationEmail("Startup")
            End If
            If My.Computer.FileSystem.DirectoryExists(Setting_LastBackupFolder) = False Then
                StatusLabel.Text = "Application Loaded"
            Else
                StatusLabel.Text = "Application Loaded (Last Backup: " & Setting_LastBackupFolder & ")"
            End If

        Catch ex As Exception
            Error_Handler(ex, "Application Loading")
        End Try
    End Sub

    Private Sub loadSettings()
        Try

            Dim configfile As String = (Application.StartupPath & "\config.sav").Replace("\\", "\")
            If My.Computer.FileSystem.FileExists(configfile) Then
                Dim reader As StreamReader = New StreamReader(configfile)
                Dim lineread As String
                Dim variablevalue As String
                While reader.Peek <> -1
                    lineread = reader.ReadLine
                    If lineread.IndexOf("=") <> -1 Then
                        variablevalue = lineread.Remove(0, lineread.IndexOf("=") + 1)
                        If lineread.StartsWith("Setting_SourceFolder=") Then
                            'If My.Computer.FileSystem.DirectoryExists(variablevalue) = True Then
                            Setting_SourceFolder.Text = variablevalue
                            'End If
                        End If
                        If lineread.StartsWith("Setting_BackupFolder=") Then
                            'If My.Computer.FileSystem.DirectoryExists(variablevalue) = True Then
                            Setting_BackupFolder.Text = variablevalue
                            'End If
                        End If
                        If lineread.StartsWith("Setting_ScheduledTime=") Then
                            Setting_ScheduledTime.Text = variablevalue
                        End If
                        If lineread.StartsWith("Setting_SendMail=") Then
                            Setting_SendMail = variablevalue
                        End If
                        If lineread.StartsWith("Setting_MailServer=") Then
                            Setting_MailServer = variablevalue
                        End If
                        If lineread.StartsWith("Setting_ToAddress=") Then
                            Setting_ToAddress = variablevalue
                        End If
                        If lineread.StartsWith("Setting_FromAddress=") Then
                            Setting_FromAddress = variablevalue
                        End If
                        If lineread.StartsWith("Setting_LastBackupFolder=") Then
                            Setting_LastBackupFolder = variablevalue
                        End If
                    End If
                End While
                reader.Close()
                reader = Nothing

                Dim keepscheduledtime As Boolean = False
                If Setting_ScheduledTime.Text.Length = 8 Then
                    If Setting_ScheduledTime.Text.IndexOf(":") = 2 Then
                        If Setting_ScheduledTime.Text.LastIndexOf(":") = 5 Then
                            keepscheduledtime = True
                        End If
                    End If
                End If
                If keepscheduledtime = False Then
                    Setting_ScheduledTime.Text = "00:00:00"
                End If

                If Setting_SourceFolder.Text.Length = 0 Then
                    Setting_SourceFolder.Text = My.Computer.FileSystem.SpecialDirectories.MyDocuments
                End If
                If Setting_BackupFolder.Text.Length = 0 Then
                    Setting_BackupFolder.Text = My.Computer.FileSystem.SpecialDirectories.Desktop
                End If
                If Setting_SendMail.Length = 0 Then
                    Setting_SendMail = "False"
                End If
                If Setting_MailServer.Length = 0 Then
                    Setting_MailServer = "mail.uct.ac.za"
                End If
                If Setting_ToAddress.Length = 0 Then
                    Setting_ToAddress = "com-webmaster@uct.ac.za"
                End If
                If Setting_FromAddress.Length = 0 Then
                    Setting_FromAddress = "SAN.FMS.2@uct.ac.za"
                End If
                If Setting_LastBackupFolder.Length = 0 Then
                    Setting_LastBackupFolder = Setting_BackupFolder.Text & " (Backup 00000000)"
                End If

            End If
            StatusLabel.Text = "Application Settings Loaded"
        Catch ex As Exception
            Error_Handler(ex, "Load Settings")
        End Try
    End Sub

    Private Sub SaveSettings()
        Try
            Dim configfile As String = (Application.StartupPath & "\config.sav").Replace("\\", "\")
            Dim writer As StreamWriter = New StreamWriter(configfile, False)
            writer.WriteLine("Setting_SourceFolder=" & Setting_SourceFolder.Text)
            writer.WriteLine("Setting_BackupFolder=" & Setting_BackupFolder.Text)
            writer.WriteLine("Setting_ScheduledTime=" & Setting_ScheduledTime.Text)
            writer.WriteLine("Setting_SendMail=" & Setting_SendMail)
            writer.WriteLine("Setting_MailServer=" & Setting_MailServer)
            writer.WriteLine("Setting_ToAddress=" & Setting_ToAddress)
            writer.WriteLine("Setting_FromAddress=" & Setting_FromAddress)
            writer.WriteLine("Setting_LastBackupFolder=" & Setting_LastBackupFolder)
            writer.Flush()
            writer.Close()
            writer = Nothing
            StatusLabel.Text = "Application Settings Saved"
        Catch ex As Exception
            Error_Handler(ex, "Save Settings")
        End Try
    End Sub

    Private Sub Main_Screen_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            SaveSettings()
            If Setting_SendMail = "True" Then
                StatusLabel.Text = "Sending Shutdown Notification Email"
                SendNotificationEmail("Shutdown")
            End If
            If AutoUpdate = True Then
                If My.Computer.FileSystem.FileExists((Application.StartupPath & "\AutoUpdate.exe").Replace("\\", "\")) = True Then
                    Dim startinfo As ProcessStartInfo = New ProcessStartInfo
                    startinfo.FileName = (Application.StartupPath & "\AutoUpdate.exe").Replace("\\", "\")
                    startinfo.Arguments = "force"
                    startinfo.CreateNoWindow = False
                    Process.Start(startinfo)
                End If
            End If
            StatusLabel.Text = "Application Shutting Down"
        Catch ex As Exception
            Error_Handler(ex, "Closing Application")
        End Try
    End Sub


    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem1.Click
        Try
            HelpBox1.ShowDialog()
            StatusLabel.Text = "Help Dialog Viewed"
        Catch ex As Exception
            Error_Handler(ex, "Display Help Screen")
        End Try
    End Sub

    Private Sub AutoUpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AutoUpdateToolStripMenuItem.Click
        Try
            StatusLabel.Text = "AutoUpdate Requested"
            AutoUpdate = True
            Me.Close()
        Catch ex As Exception
            Error_Handler(ex, "AutoUpdate")
        End Try
    End Sub

    Private Sub AboutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem1.Click
        Try
            AboutBox1.ShowDialog()
            StatusLabel.Text = "About Dialog Viewed"
        Catch ex As Exception
            Error_Handler(ex, "Display About Screen")
        End Try
    End Sub

    Private Sub Control_Enabler(ByVal IsEnabled As Boolean)
        Try
            Select Case IsEnabled
                Case True
                    Button1.Enabled = True
                    Button2.Enabled = True
                    MenuStrip1.Enabled = True
                    Me.ControlBox = True
                    ProgressBar1.Enabled = False
                    Button3.Enabled = False
                    Button3.Visible = False
                    Button4.Enabled = False
                    Button4.Visible = False
                Case False
                    Button1.Enabled = False
                    Button2.Enabled = False
                    MenuStrip1.Enabled = False
                    Me.ControlBox = False
                    ProgressBar1.Enabled = True
                    Button3.Enabled = True
                    Button3.Visible = True
                    Button4.Enabled = True
                    Button4.Visible = True
            End Select
            StatusLabel.Text = "Control Enabler Run"
        Catch ex As Exception
            Error_Handler(ex, "Control Enabler")
        End Try
    End Sub


    Private Sub RunPrecount(ByVal targetfolder As String)
        Try
            If BackgroundWorker1.CancellationPending = False Then
                'source_label_text = "Source: " & targetfolder
                source_label_text = "" & targetfolder
                BackgroundWorker1.ReportProgress(50)
                If My.Computer.FileSystem.DirectoryExists(targetfolder) = True Then
                    Dim dinfo As DirectoryInfo = New DirectoryInfo(targetfolder)
                    Try
                        precountObjects = precountObjects + 1
                        precountFolders = precountFolders + 1

                        For Each finfo As FileInfo In dinfo.GetFiles
                            Try
                                precountObjects = precountObjects + 1
                                precountFiles = precountFiles + 1
                                'source_label_text = "Source: " & finfo.FullName
                                BackgroundWorker1.ReportProgress(50)
                            Catch ex As Exception
                                Error_Handler(ex, "Precount Function: " & finfo.FullName)
                            End Try
                            finfo = Nothing
                        Next

                        For Each dinfo2 As DirectoryInfo In dinfo.GetDirectories
                            Try
                                RunPrecount(dinfo2.FullName)
                                dinfo2 = Nothing
                            Catch ex As Exception
                                Error_Handler(ex, "Precount Function: " & dinfo2.FullName)
                            End Try
                        Next
                    Catch ex As Exception
                        Error_Handler(ex, "Precount Function: " & dinfo.FullName)
                    End Try
                    dinfo = Nothing
                End If
            End If
            BackgroundWorker1.ReportProgress(50)
        Catch ex As Exception
            Error_Handler(ex, "Precount Function")
        End Try
    End Sub


    Private Sub RunCleanUp(ByVal targetfolder As String)
        Try
            If BackgroundWorker1.CancellationPending = False Then
                'backup_label_text = "Backup: " & targetfolder
                backup_label_text = "" & targetfolder
                BackgroundWorker1.ReportProgress(30)
                If My.Computer.FileSystem.DirectoryExists(targetfolder) = True Then
                    Dim dinfo As DirectoryInfo = New DirectoryInfo(targetfolder)
                    Try

                        If My.Computer.FileSystem.DirectoryExists(dinfo.FullName.Replace(creationfolder, Setting_SourceFolder.Text)) = False Then
                            'MsgBox(dinfo.FullName & " -- " & dinfo.FullName.Replace(creationfolder, Setting_SourceFolder.Text))
                            My.Computer.FileSystem.DeleteDirectory(dinfo.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin, FileIO.UICancelOption.DoNothing)
                        End If
                        countFolders = countFolders + 1

                        For Each dinfo2 As DirectoryInfo In dinfo.GetDirectories
                            Try
                                RunCleanUp(dinfo2.FullName)
                            Catch ex As Exception
                                Error_Handler(ex, "CleanUp Function: " & dinfo2.FullName)
                            End Try
                            dinfo2 = Nothing
                        Next

                        For Each finfo As FileInfo In dinfo.GetFiles
                            Try
                                If My.Computer.FileSystem.FileExists(finfo.FullName.Replace(creationfolder, Setting_SourceFolder.Text)) = False Then
                                    'MsgBox(finfo.FullName & " -- " & finfo.FullName.Replace(creationfolder, Setting_SourceFolder.Text))
                                    My.Computer.FileSystem.DeleteFile(finfo.FullName, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
                                End If
                                'backup_label_text = "Backup: " & finfo.FullName
                                countFiles = countFiles + 1
                                BackgroundWorker1.ReportProgress(30)
                            Catch ex As Exception
                                Error_Handler(ex, "CleanUp Function: " & finfo.FullName)
                            End Try
                            finfo = Nothing
                        Next

                    Catch ex As Exception
                        Error_Handler(ex, "CleanUp Function: " & dinfo.FullName)
                    End Try


                    dinfo = Nothing
                End If
            End If
            BackgroundWorker1.ReportProgress(30)
        Catch ex As Exception
            Error_Handler(ex, "Precount Function")
        End Try
    End Sub


    Private Sub RunBackup(ByVal targetfolder As String)
        Try
            If BackgroundWorker1.CancellationPending = False Then
                'ProgressBar1.Value = Math.Round(((countObjects / precountObjects) * 100), 0)
                'StatusLabel.Text = "Backing Content Up: " & countFolders & " folders | " & countFiles & " files"
                BackgroundWorker1.ReportProgress(100)
                If My.Computer.FileSystem.DirectoryExists(targetfolder) = True Then

                    Dim dinfo As DirectoryInfo = New DirectoryInfo(targetfolder)
                    If My.Computer.FileSystem.DirectoryExists((creationfolder & "\" & targetfolder.Replace(Setting_SourceFolder.Text, "")).Replace("\\", "\")) = False Then
                        My.Computer.FileSystem.CreateDirectory((creationfolder & "\" & targetfolder.Replace(Setting_SourceFolder.Text, "")).Replace("\\", "\"))
                    End If
                    'source_label_text = "Source: " & targetfolder
                    source_label_text = "" & targetfolder
                    'backup_label_text = "Backup: " & (creationfolder & "\" & targetfolder.Replace(Setting_SourceFolder.Text, "")).Replace("\\", "\")
                    backup_label_text = "" & (creationfolder & "\" & targetfolder.Replace(Setting_SourceFolder.Text, "")).Replace("\\", "\")

                    Try
                        countObjects = countObjects + 1
                        countFolders = countFolders + 1

                        For Each finfo As FileInfo In dinfo.GetFiles
                            Try
                                countObjects = countObjects + 1
                                countFiles = countFiles + 1
                                Dim overwrite As Boolean = False
                                Dim einfo As FileInfo = New FileInfo((creationfolder & "\" & targetfolder.Replace(Setting_SourceFolder.Text, "") & "\" & finfo.Name).Replace("\\", "\"))
                                If einfo.Exists = False Then
                                    overwrite = True
                                Else
                                    If finfo.LastWriteTime <> einfo.LastWriteTime Then
                                        overwrite = True
                                    Else
                                        overwrite = False
                                    End If
                                End If
                                If overwrite = True Then
                                    My.Computer.FileSystem.CopyFile(finfo.FullName, (creationfolder & "\" & targetfolder.Replace(Setting_SourceFolder.Text, "") & "\" & finfo.Name).Replace("\\", "\"), overwrite)
                                End If
                                'source_label_text = "Source: " & finfo.FullName
                                'backup_label_text = "Backup: " & (creationfolder & "\" & targetfolder.Replace(Setting_SourceFolder.Text, "") & "\" & finfo.Name).Replace("\\", "\")

                                BackgroundWorker1.ReportProgress(100)
                            Catch ex As Exception
                                Error_Handler(ex, "Backup Function: " & finfo.FullName)
                            End Try
                            finfo = Nothing
                        Next

                        For Each dinfo2 As DirectoryInfo In dinfo.GetDirectories
                            Try
                                RunBackup(dinfo2.FullName)
                                dinfo2 = Nothing
                            Catch ex As Exception
                                Error_Handler(ex, "Backup Function: " & dinfo2.FullName)
                            End Try
                        Next
                    Catch ex As Exception
                        Error_Handler(ex, "Backup Function: " & dinfo.FullName)
                    End Try
                    dinfo = Nothing
                End If
                'ProgressBar1.Value = Math.Round(((countObjects / precountObjects) * 100), 0)
                'StatusLabel.Text = "Backing Content Up: " & countFolders & " folders | " & countFiles & " files"
            End If
            BackgroundWorker1.ReportProgress(100)
        Catch ex As Exception
            Error_Handler(ex, "Precount Function")
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        Try
            source_label.Text = source_label_text
            backup_label.Text = backup_label_text
            If e.ProgressPercentage = 100 Then
                ProgressBar1.Value = Math.Round(((countObjects / precountObjects) * 100), 0)
                StatusLabel.Text = "Backing Content Up: " & countFolders & " folders | " & countFiles & " files"
            ElseIf e.ProgressPercentage = 30 Then
                StatusLabel.Text = "Cleaning Existing Backup Up: " & countFolders & " folders | " & countFiles & " files"
            Else
                StatusLabel.Text = "Running Precount: " & precountFolders & " folders | " & precountFiles & " files"
            End If
            'source_label.Refresh()
            'backup_label.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Report Progress")
        End Try
    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            StatusLabel.Refresh()
            source_label.Refresh()
            backup_label.Refresh()
            If BackgroundWorker1.CancellationPending = False Then
                StatusLabel.Text = "Backup Operation in Progress"
                StatusLabel.Text = "Starting up Precount Operation"
                RunPrecount(Setting_SourceFolder.Text)
            Else
                e.Cancel = True
            End If
            StatusLabel.Refresh()
            source_label.Refresh()
            backup_label.Refresh()
            If BackgroundWorker1.CancellationPending = False Then
                countFolders = 0
                countFiles = 0
                StatusLabel.Text = "Precount Operation Complete"
                StatusLabel.Text = "Cleaning Existing Backup Up"
                RunCleanUp(creationfolder)
            Else
                e.Cancel = True
            End If
            StatusLabel.Refresh()
            source_label.Refresh()
            backup_label.Refresh()
            If BackgroundWorker1.CancellationPending = False Then
                countFolders = 0
                countFiles = 0
                StatusLabel.Text = "CleanUp Operation Complete"
                StatusLabel.Text = "Backing Content Up"
                RunBackup(Setting_SourceFolder.Text)
            Else
                e.Cancel = True
            End If
            StatusLabel.Refresh()
            source_label.Refresh()
            backup_label.Refresh()
            If BackgroundWorker1.CancellationPending = False Then
                StatusLabel.Text = "Content Backup Complete"
                e.Result = "Success"
            Else
                e.Cancel = True
            End If
            StatusLabel.Refresh()
            source_label.Refresh()
            backup_label.Refresh()
        Catch ex As Exception
            e.Cancel = True
            Error_Handler(ex, "Backup Operation")
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Control_Enabler(True)
            If e.Cancelled = False And e.Error Is Nothing Then
                If e.Result = "Success" Then
                    StatusLabel.Text = "Backup Operation Completed Successfully (" & countFolders & " folders | " & countFiles & " files)"
                End If
            Else
                StatusLabel.Text = "Backup Operation Did Not Complete Successfully (" & countFolders & " folders | " & countFiles & " files)"
            End If
            busyworking = False
            BackgroundWorker1.Dispose()
            BackgroundWorker1 = Nothing
        Catch ex As Exception
            Error_Handler(ex, "Backup Operation Complete")
        End Try
    End Sub

    Private Sub runworker()
        Try
            If busyworking = False Then
                If My.Computer.FileSystem.DirectoryExists(Setting_BackupFolder.Text) = True Then
                    If My.Computer.FileSystem.DirectoryExists(Setting_SourceFolder.Text) = True Then
                        StatusLabel.Text = "Backup Operation Initiated"
                        source_label.Text = "Source: "
                        backup_label.Text = "Backup: "
                        precountFiles = 0
                        precountFolders = 0
                        precountObjects = 0
                        countFiles = 0
                        countFolders = 0
                        countObjects = 0
                        ProgressBar1.Value = 0
                        ProgressBar1.Refresh()
                        StatusLabel.Refresh()

                        If BackgroundWorker1 Is Nothing Then
                            BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
                            BackgroundWorker1.WorkerReportsProgress = True
                            BackgroundWorker1.WorkerSupportsCancellation = True
                        End If
                        creationfolder = Setting_BackupFolder.Text
                        Dim setupinfo As DirectoryInfo = New DirectoryInfo(Setting_SourceFolder.Text)
                        creationfolder = (creationfolder + "\" & setupinfo.Name & " (Backup " & Format(Now, "yyyyMMdd") & ")").Replace("\\", "\")
                        setupinfo = Nothing
                        If My.Computer.FileSystem.DirectoryExists(Setting_LastBackupFolder) = True Then
                            If creationfolder <> Setting_LastBackupFolder Then
                                My.Computer.FileSystem.MoveDirectory(Setting_LastBackupFolder, creationfolder)
                            End If
                        End If
                        If My.Computer.FileSystem.DirectoryExists(creationfolder) = False Then
                            My.Computer.FileSystem.CreateDirectory(creationfolder)
                        End If
                        Setting_LastBackupFolder = creationfolder
                        busyworking = True
                        Control_Enabler(False)
                        BackgroundWorker1.RunWorkerAsync()
                    Else
                        MsgBox("Sorry, but it appears as if your selected Source Folder no longer exists on the system.", MsgBoxStyle.Exclamation, "Folder Does Not Exist")
                    End If
                Else
                    MsgBox("Sorry, but it appears as if your selected Backup Folder no longer exists on the system.", MsgBoxStyle.Exclamation, "Folder Does Not Exist")
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex, "Run Worker")
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            runworker()
        Catch ex As Exception
            Error_Handler(ex, "Force Operation")
        End Try
    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            CurrentTime.Text = Format(Now, "HH:mm:ss")
            If CurrentTime.Text = ScheduledTime.Text Then
                If busyworking = False Then
                    runworker()
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex, "Timer Tick")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            Dim exitfunction As Boolean = False

            If exitfunction = False Then
                FolderBrowserDialog1 = New FolderBrowserDialog
                If My.Computer.FileSystem.DirectoryExists(Setting_SourceFolder.Text) = True Then
                    FolderBrowserDialog1.SelectedPath = Setting_SourceFolder.Text
                End If
                FolderBrowserDialog1.Description = "Select the folder that you wish to backup:"
                If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Setting_SourceFolder.Text = FolderBrowserDialog1.SelectedPath
                Else
                    exitfunction = True
                End If
            End If

            If exitfunction = False Then
                If My.Computer.FileSystem.DirectoryExists(Setting_BackupFolder.Text) = True Then
                    FolderBrowserDialog1.SelectedPath = Setting_BackupFolder.Text
                End If
                FolderBrowserDialog1.Description = "Select the folder that you wish to create the backup in:"
                If FolderBrowserDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Setting_BackupFolder.Text = FolderBrowserDialog1.SelectedPath
                Else
                    exitfunction = True
                End If
                FolderBrowserDialog1 = Nothing
            End If

            If exitfunction = False Then
                SetScheduledTime = New Set_Scheduled_Time
                SetScheduledTime.Set_ScheduledTime(Setting_ScheduledTime.Text)
                If SetScheduledTime.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Setting_ScheduledTime.Text = SetScheduledTime.settime
                Else
                    exitfunction = True
                End If
                SetScheduledTime = Nothing
            End If

            If exitfunction = False Then
                SetMailSettings = New Set_Mail_Settings
                SetMailSettings.SetSettings(Setting_MailServer, Setting_SendMail, Setting_ToAddress, Setting_FromAddress)
                If SetMailSettings.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Setting_SendMail = SetMailSettings.SendMail
                    Setting_MailServer = SetMailSettings.MailServer
                    Setting_ToAddress = SetMailSettings.ToAddress
                    Setting_FromAddress = SetMailSettings.FromAddress
                Else
                    exitfunction = True
                End If
                SetMailSettings = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Change Settings")
        End Try
    End Sub

    Private Sub Setting_ScheduledTime_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Setting_ScheduledTime.TextChanged
        Try
            ScheduledTime.Text = Setting_ScheduledTime.Text
        Catch ex As Exception
            Error_Handler(ex, "Scheduled Time Setting Changed")
        End Try
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            BackgroundWorker1.CancelAsync()
        Catch ex As Exception
            Error_Handler(ex, "Cancel Backup Operation")
        End Try
    End Sub

    Private Sub NotifyIcon1_BalloonTipClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.BalloonTipClicked
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            NotifyIcon1.Visible = False
            Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Click on NotifyIcon")
        End Try
    End Sub


    Private Sub NotifyIcon1_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseClick
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            NotifyIcon1.Visible = False
            Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Click on NotifyIcon")
        End Try
    End Sub


    Private Sub NotifyIcon1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NotifyIcon1.Click
        Try
            Me.WindowState = FormWindowState.Normal
            Me.ShowInTaskbar = True
            NotifyIcon1.Visible = False
            Me.Refresh()
        Catch ex As Exception
            Error_Handler(ex, "Click on NotifyIcon")
        End Try
    End Sub

    Private Sub Main_Screen_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.ShowInTaskbar = False
                NotifyIcon1.Visible = True
                If shownminimizetip = False Then
                    NotifyIcon1.ShowBalloonTip(1)
                    shownminimizetip = True
                End If
            End If
        Catch ex As Exception
            Error_Handler(ex, "Change Window State")
        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            Me.WindowState = FormWindowState.Minimized
        Catch ex As Exception
            Error_Handler(ex, "Minimise Window Clicked")
        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Try
            If My.Computer.FileSystem.FileExists((Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt") = True Then
                Dim systemDirectory As String
                systemDirectory = System.Environment.SystemDirectory
                Dim finfo As FileInfo = New FileInfo((systemDirectory & "\notepad.exe").Replace("\\", "\"))
                If finfo.Exists = True Then
                    Dim apptorun As String
                    apptorun = """" & (systemDirectory & "\notepad.exe").Replace("\\", "\") & """ """ & (Application.StartupPath & "\").Replace("\\", "\") & "Error Logs\" & Format(Now(), "yyyyMMdd") & "_Error_Log.txt" & """"
                    Dim procID As Integer = Shell(apptorun, AppWinStyle.NormalFocus, False)
                End If
                finfo = Nothing
            End If
        Catch ex As Exception
            Error_Handler(ex, "Open Error Log")
        End Try
    End Sub
End Class

Imports System.Windows.Forms

Public Class Set_Mail_Settings
    Public MailServer As String = ""
    Public SendMail As String = ""
    Public ToAddress As String = ""
    Public FromAddress As String = ""

    Public Sub SetSettings(ByVal Setting_MailServer As String, ByVal Setting_SendMail As String, ByVal Setting_ToAddress As String, ByVal Setting_FromAddress As String)
        MailServer = Setting_MailServer
        SendMail = Setting_SendMail
        ToAddress = Setting_ToAddress
        FromAddress = Setting_FromAddress

        If SendMail = "True" Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
        TextBox1.Text = MailServer
        TextBox2.Text = ToAddress
        TextBox3.Text = FromAddress
    End Sub

    Private Sub SaveSettings()
        If CheckBox1.Checked = True Then
            SendMail = "True"
        Else
            SendMail = "False"
        End If
        MailServer = TextBox1.Text
        ToAddress = TextBox2.Text
        FromAddress = TextBox3.Text
    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        SaveSettings()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Enabled = True
            TextBox2.Enabled = True
            TextBox3.Enabled = True
        Else
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
        End If
    End Sub
End Class

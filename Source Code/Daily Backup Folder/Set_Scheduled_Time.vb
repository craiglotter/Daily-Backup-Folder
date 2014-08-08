Imports System.Windows.Forms

Public Class Set_Scheduled_Time

    Public initialtime As String
    Public settime As String


    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Dim part1, part2, part3 As String
        part1 = NumericUpDown1.Value
        part2 = NumericUpDown2.Value
        part3 = NumericUpDown3.Value
        While part1.Length < 2
            part1 = "0" & part1
        End While
        While part2.Length < 2
            part2 = "0" & part2
        End While
        While part3.Length < 2
            part3 = "0" & part3
        End While
        settime = part1 & ":" & part2 & ":" & part3
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public Sub Set_ScheduledTime(ByVal scheduledtime As String)
        If scheduledtime.Length = 8 Then
            If scheduledtime.IndexOf(":") = 2 Then
                If scheduledtime.LastIndexOf(":") = 5 Then
                    NumericUpDown1.Value = Integer.Parse(scheduledtime.Substring(0, 2))
                    NumericUpDown2.Value = Integer.Parse(scheduledtime.Substring(3, 2))
                    NumericUpDown3.Value = Integer.Parse(scheduledtime.Substring(6, 2))
                End If
            End If
        End If
    End Sub
End Class

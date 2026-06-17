Public Partial Class CanteenReportMain
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CmbDepartment.Items.Insert(0, New ListItem("-Select-", ""))
            CmbCanteenName.Items.Insert(0, New ListItem("-Select-", ""))
        End If
 
    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        From1.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        To1.Visible = True
    End Sub

    Protected Sub To1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles To1.SelectionChanged
        TxtTo.Text = ""
        TxtTo.Text = To1.SelectedDate.ToString("dd-MMM-yyyy")
        To1.Visible = False
    End Sub

    Protected Sub From1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles From1.SelectionChanged
        TxtFrom.Text = ""
        TxtFrom.Text = From1.SelectedDate.ToString("dd-MMM-yyyy")
        From1.Visible = False
        TxtTo.Text = ""
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TxtFrom.Text.Equals("") Then
            Lblmsg.Text = "Please Select FROM Date!"
            Exit Sub
        End If

        If TxtTo.Text.Equals("") Then
            Lblmsg.Text = "Please Select TO Date!"
            Exit Sub
        End If

        Lblmsg.Text = ""

        Session("cn_from1") = TxtFrom.Text
        Session("cn_to1") = Convert.ToDateTime(TxtTo.Text).AddDays(1).ToString("dd-MMM-yyyy")
        Session("cn_department") = CmbDepartment.Text
        If ChkCanteen.Checked = True Then
            Session("cn_canteenname") = CmbCanteenName.Text
            Session("msg") = "Report for " & Session("cn_canteenname")
        Else
            Session("cn_canteenname") = "both"
            Session("msg") = "Report for Plant1 and Plant7 Canteen"
        End If


       If RBtn1.Checked And ChkCanteen.Checked = True Then
            Session("cn_option") = "nothing"
        ElseIf RBtn1.Checked = True Then
            Session("cn_option") = "nothing"
        ElseIf RBtn2.Checked = True Then
            Session("cn_option") = "DepartmentSummary"
        ElseIf RBtn3.Checked = True Then
            Session("cn_option") = "SectionSummary"
        ElseIf Rbtn4.Checked = True And ChkCanteen.Checked = True Then
            Session("cn_option") = "DateSummary"
        ElseIf Rbtn4.Checked = True Then
            Session("cn_option") = "DateSummary"
        ElseIf RBtn5.Checked And ChkCanteen.Checked = True Then
            Session("cn_option") = "ByCanteenSummary"
        End If

        Response.Redirect("CanteenDetailedReport.aspx")

    End Sub

  
    
    
    Protected Sub RBtn5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBtn5.CheckedChanged

    End Sub
End Class
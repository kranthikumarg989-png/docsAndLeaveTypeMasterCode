Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Partial Public Class ReportCV
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (61)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged
        If rdoptions.SelectedValue = "Cust" Then
            ddlcust.Enabled = True
            txtempidr.Enabled = False
            txtbt.Enabled = False
        ElseIf rdoptions.SelectedValue = "BT" Then
            ddlcust.Enabled = False
            txtempidr.Enabled = False
            txtbt.Enabled = True
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddlcust.Enabled = False
            txtempidr.Enabled = True
            txtbt.Enabled = False
        Else
            ddlcust.Enabled = False
            txtempidr.Enabled = False
            txtbt.Enabled = False
        End If
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim rdvalue As String
        rdvalue = rdoptions.SelectedValue

        Session("cvcust") = Trim(ddlcust.SelectedValue)
        Session("cvemp") = Trim(txtempidr.Text)
        Session("cvbt") = Trim(txtbt.Text.Trim)


        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)
        Session("cvfromd") = fd

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        Session("cvtod") = td


        If rdvalue = "Cust" And ddlcust.SelectedValue <> "" Then
            Session("cvstat") = "C"
        ElseIf rdvalue = "BT" And txtbt.Text <> "" Then
            Session("cvstat") = "B"
        ElseIf rdvalue = "Emp" And txtempidr.Text <> "" Then
            Session("cvstat") = "E"
        Else
            Session("cvstat") = "O"
        End If

        Response.Redirect("cvreportsbyselection.aspx")
    End Sub
End Class
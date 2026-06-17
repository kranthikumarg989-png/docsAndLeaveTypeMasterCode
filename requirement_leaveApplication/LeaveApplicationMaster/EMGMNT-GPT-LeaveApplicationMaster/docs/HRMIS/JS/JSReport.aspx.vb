Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class JSReport
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim emp As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (135)
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
        MyApp.GetfiscalYear()

        If txtempidr.Text = "" Then
            txtempidr.Text = "0"
        End If

    End Sub
    Protected Sub rdoptions_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoptions.SelectedIndexChanged

        If rdoptions.SelectedValue = "Dept" Then
            ddldeptr.Enabled = True
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
            GridView2.Visible = False

            ddlsectrpt.SelectedValue = "-1"
            ddldesigr.SelectedValue = "-1"
            txtempidr.Text = "0"
        ElseIf rdoptions.SelectedValue = "Sect" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = True
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
            GridView2.Visible = False

            ddldeptr.SelectedValue = "-1"
            ddldesigr.SelectedValue = "-1"
            txtempidr.Text = "0"
        ElseIf rdoptions.SelectedValue = "Desig" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = True
            txtempidr.Enabled = False
            GridView2.Visible = False

            ddldeptr.SelectedValue = "-1"
            ddlsectrpt.SelectedValue = "-1"
            txtempidr.Text = "0"
        ElseIf rdoptions.SelectedValue = "Emp" Then
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = True
            GridView2.Visible = False

            ddldeptr.SelectedValue = "-1"
            ddldesigr.SelectedValue = "-1"
            ddlsectrpt.SelectedValue = "-1"
        Else
            ddldeptr.Enabled = False
            ddlsectrpt.Enabled = False
            ddldesigr.Enabled = False
            txtempidr.Enabled = False
            GridView2.DataBind()
            GridView2.Visible = True

            ddldeptr.SelectedValue = "-1"
            ddldesigr.SelectedValue = "-1"
            ddlsectrpt.SelectedValue = "-1"
            txtempidr.Text = "0"
        End If

    End Sub
    Public Sub PrintJS(ByVal sender As Object, ByVal e As CommandEventArgs)

        emp = e.CommandArgument
        Session("jsemp") = emp
        Session("jsowner") = "1"
        Response.Redirect("printJS.aspx")

    End Sub
End Class
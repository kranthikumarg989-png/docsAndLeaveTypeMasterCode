Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class frmUsageSummary
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        If IsPostBack = False Then
            GetDepartment()
        End If
    End Sub
    Protected Sub GetDepartment()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        con.Open()
        cmd = New SqlCommand("SP_PPE_Department", con)
        cmd.CommandType = CommandType.StoredProcedure
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        con.Close()
        ddlDept.DataSource = dt
        ddlDept.DataTextField = "DeptCodeName"
        ddlDept.DataValueField = "departmentcode"
        ddlDept.DataBind()
        ddlDept.Items.Insert(0, "All")
        ddlDept.Items(0).Value = "All"
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        ClientScript.RegisterStartupScript(GetType(String), "IssueUsagePrint", "UsageRpt('" + rbtnType.SelectedValue + "','" + ddlDept.SelectedValue + "','" + txtFromDt.Text.Trim() + "','" + txtToDt.Text.Trim() + "')", True)

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session("ppefromDt") = txtFromDt.Text.Trim
        Session("ppeToDt") = txtToDt.Text.Trim
        Session("ppedept") = ddlDept.SelectedValue
        Session("ppetype") = rbtnType.SelectedValue
        Response.Redirect("frmusagebydept.aspx")
    End Sub
End Class
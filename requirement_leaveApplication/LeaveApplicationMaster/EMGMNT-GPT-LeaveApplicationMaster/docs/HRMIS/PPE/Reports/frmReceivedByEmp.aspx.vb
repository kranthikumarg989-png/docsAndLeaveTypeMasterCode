Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class frmReceivedByEmp
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        If IsPostBack = False Then

        End If
    End Sub
    Protected Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim stremp As String = "All"
        If txtEmpCode.Text.Trim() <> "" Then
            stremp = txtEmpCode.Text.Trim()
        End If
        ClientScript.RegisterStartupScript(GetType(String), "IssueEmpPrint", "IssueEmpRpt('" + rbtnType.SelectedValue + "','" + stremp + "','" + txtFromDt.Text.Trim() + "','" + txtToDt.Text.Trim() + "','" + rbtnreport.SelectedValue + "')", True)
    End Sub
End Class
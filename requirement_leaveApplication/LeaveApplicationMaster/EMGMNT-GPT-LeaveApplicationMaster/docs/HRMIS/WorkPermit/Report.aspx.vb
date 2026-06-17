Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class Report
    Inherits System.Web.UI.Page
    Public strCon As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
    Dim sqlCon As SqlConnection()
    Dim sqlCmd As SqlCommand()
    Dim sqladapter As New SqlDataAdapter()
    Dim ds As New DataSet()
    Dim ds2 As New DataSet()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If (Session("EmpCode") = Nothing) Then
            Response.Redirect("Login.aspx")
        End If
        If (Not Page.IsPostBack()) Then
            BindDepartment()
            BindGrid()
        End If
    End Sub

    Sub BindGrid()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "Report")
                If (ddlDepartment.SelectedIndex > 0) Then
                    sqlCmd.Parameters.AddWithValue("@Department", ddlDepartment.SelectedValue)
                End If
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using

        If (ds.Tables(0).Rows.Count > 0) Then
            gv.DataSource = ds
            gv.Visible = True
            gv.DataBind()
        Else
            gv.Visible = False
        End If
    End Sub

    Sub BindDepartment()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_Department", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "getall")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        ddlDepartment.DataTextField = "DepartmentName"
        ddlDepartment.DataValueField = "DepartmentCode"
        ddlDepartment.DataSource = ds
        ddlDepartment.DataBind()
        ddlDepartment.Items.Insert(0, "All")
    End Sub

    Protected Sub ddlDepartment_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlDepartment.SelectedIndexChanged
        BindGrid()
    End Sub

    Public Overrides Sub VerifyRenderingInServerForm(ByVal control As Control)
    End Sub

    Protected Sub btnExcel_Click1(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcel.Click
        Dim attachment As String = "attachment; filename=Report.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        gv.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub
End Class

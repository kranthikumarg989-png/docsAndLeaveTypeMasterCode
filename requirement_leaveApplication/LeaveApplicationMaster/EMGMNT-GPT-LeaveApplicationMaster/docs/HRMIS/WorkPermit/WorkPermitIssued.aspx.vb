Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Partial Class WorkPermitIssued
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
            BindStatus()
            BindGrid()
        End If
    End Sub

    Sub BindGrid()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "WPIssuedList")
                sqlCmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue)
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

    Sub BindStatus()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "getWPStatus")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        ddlStatus.DataTextField = "Status"
        ddlStatus.DataValueField = "Code"
        ddlStatus.DataSource = ds
        ddlStatus.DataBind()
        ddlStatus.SelectedValue = "RP"
    End Sub

    Protected Sub ddlStatus_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlStatus.SelectedIndexChanged
        BindGrid()
    End Sub
End Class

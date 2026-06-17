Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient

Public Class PassportHistory
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
        lblMsg.Text = ""
        If (Not Page.IsPostBack()) Then
            'txtFromdate.Text = System.DateTime.Now.ToString("dd/MM/yyyy")
            'txtTodate.Text = System.DateTime.Now.ToString("dd/MM/yyyy")
            BindEmpCode()
            BindGrid()
        End If
    End Sub

    Sub BindEmpCode()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_EmpMaster_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "GetAll")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        ddlEmpCode.DataTextField = "empcode"
        ddlEmpCode.DataValueField = "empcode"
        ddlEmpCode.DataSource = ds
        ddlEmpCode.DataBind()
        ddlEmpCode.Items.Insert(0, "Select")
    End Sub

    Sub BindGrid()
        gv.Visible = True
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "History")
                If (txtFromdate.Text <> "" AndAlso txtTodate.Text <> "") Then
                    sqlCmd.Parameters.AddWithValue("@frmDate", txtFromdate.Text)
                    sqlCmd.Parameters.AddWithValue("@toDate", txtTodate.Text)
                End If
                If (ddlEmpCode.SelectedIndex > 0) Then
                    sqlCmd.Parameters.AddWithValue("@EmpCode", ddlEmpCode.SelectedValue)
                End If
                If (txtPassportNo.Text <> "") Then
                    sqlCmd.Parameters.AddWithValue("@passportNo", txtPassportNo.Text)
                End If
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using
        gv.DataSource = ds
        gv.DataBind()
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click
        BindGrid()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtFromdate.Text = ""
        txtTodate.Text = ""
        ddlEmpCode.SelectedIndex = -1
        txtPassportNo.Text = ""
        BindGrid()
    End Sub

    Private Sub gv_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gv.PageIndexChanging
        gv.PageIndex = e.NewPageIndex
        BindGrid()
    End Sub
End Class
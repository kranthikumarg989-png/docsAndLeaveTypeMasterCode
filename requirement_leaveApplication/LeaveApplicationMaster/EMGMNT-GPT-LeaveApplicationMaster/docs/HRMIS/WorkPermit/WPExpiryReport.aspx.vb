Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Partial Class WPExpiryReport
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
            BindYear()
            BindGrid()
        End If
    End Sub

    Sub BindGrid()
        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "WPExpiry")
                sqlCmd.Parameters.AddWithValue("@Month", ddlMonth.SelectedValue + " - " + ddlYear.SelectedValue)
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using

        If (ds.Tables(0).Rows.Count > 0) Then
            gv.DataSource = ds
            btnExcel.Visible = True
            gv.Visible = True
            gv.DataBind()
        Else
            btnExcel.Visible = False
            gv.Visible = False
        End If


        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "WPExpiry")
                sqlCmd.Parameters.AddWithValue("@Month", ddlMonth.SelectedValue + " - " + ddlYear.SelectedValue)
                sqlCmd.Parameters.AddWithValue("@Gender", "Male")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using

        If (ds.Tables(0).Rows.Count > 0) Then
            gvMale.DataSource = ds
            gvMale.Visible = True
            gvMale.DataBind()
        Else
            gvMale.Visible = False
        End If

        ds = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "WPExpiry")
                sqlCmd.Parameters.AddWithValue("@Month", ddlMonth.SelectedValue + " - " + ddlYear.SelectedValue)
                sqlCmd.Parameters.AddWithValue("@Gender", "Female")
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds)
            End Using
        End Using

        If (ds.Tables(0).Rows.Count > 0) Then
            gvFemale.DataSource = ds
            gvFemale.Visible = True
            gvFemale.DataBind()
        Else
            gvFemale.Visible = False
        End If

        If (gvFemale.Rows.Count <= 0 And gvMale.Rows.Count <= 0) Then
            btnExcel2.Visible = False
        Else
            btnExcel2.Visible = True
        End If
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

    Protected Sub ddlMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlMonth.SelectedIndexChanged
        BindGrid()
    End Sub

    Function getDetails(ByVal month As Object) As DataSet
        ds2 = New DataSet()
        Using sqlCon As New SqlConnection(strCon)
            sqlCon.Open()
            Using sqlCmd As New SqlCommand("sp_WorkPermit_in", sqlCon)
                sqlCmd.CommandType = CommandType.StoredProcedure
                sqlCmd.Parameters.AddWithValue("@Type", "Report")
                sqlCmd.Parameters.AddWithValue("@Month", month.ToString())
                sqladapter = New SqlDataAdapter(sqlCmd)
                sqladapter.Fill(ds2)
            End Using
        End Using
        Return ds2
    End Function
    Sub BindYear()
        For i As Integer = DateTime.Now.Year - 2 To DateTime.Now.Year + 1
            ddlYear.Items.Add(i.ToString())
        Next
        If (DateTime.Now.Month.ToString() = "11") Then
            ddlMonth.SelectedValue = "January"
            ddlYear.SelectedValue = DateTime.Now.Year + 1
        Else
            ddlMonth.SelectedValue = MonthName(DateTime.Now.Month + 1, False)
            ddlYear.SelectedValue = DateTime.Now.Year
        End If
    End Sub

    Protected Sub btnExcel2_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles btnExcel2.Click
        Dim attachment As String = "attachment; filename=Report.xls"
        Response.ClearContent()
        Response.AddHeader("content-disposition", attachment)
        Response.ContentType = "application/ms-excel"
        Dim sw As New StringWriter()
        Dim htw As New HtmlTextWriter(sw)
        tblDetails.RenderControl(htw)
        Response.Write(sw.ToString())
        Response.[End]()
    End Sub

    Protected Sub ddlYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlYear.SelectedIndexChanged
        BindGrid()
    End Sub
End Class

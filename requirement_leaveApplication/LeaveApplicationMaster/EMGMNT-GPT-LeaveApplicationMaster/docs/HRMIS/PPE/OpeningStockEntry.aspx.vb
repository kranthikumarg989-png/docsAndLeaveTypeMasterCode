Imports System.Data.SqlClient
Partial Public Class OpeningStockEntry
    Inherits System.Web.UI.Page
    Dim dtCommon As DataTable = New DataTable()
    Dim drCommon As SqlDataReader
    Dim connection As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection = ConfigurationManager.ConnectionStrings("Sqlcon1").ConnectionString
        If IsPostBack = False Then
            Session("empcode") = "014543"
            LoadDepartment()
            dgvOpeningStock.Visible = False
            btnSave.Visible = False
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub LoadDepartment()
        Dim dtDept As DataTable = New DataTable()
        Dim strSpName As String = "SP_PPE_Department"
        CommonDrDt(strSpName)
        dtDept = dtCommon
        ddlDepartment.DataSource = dtDept
        ddlDepartment.DataTextField = "DeptCodeName"
        ddlDepartment.DataValueField = "departmentcode"
        ddlDepartment.DataBind()
        ddlDepartment.Items.Insert(0, "--Select--")
        ddlDepartment.Items(0).Value = "-1"
    End Sub

    Protected Sub LoadGrid()
        Dim con As New SqlConnection(connection)
        Dim dr As SqlDataReader
        Dim dtGrid As DataTable = New DataTable()
        con.Open()
        Dim cmd As SqlCommand = New SqlCommand("SP_PPE_LoadItem", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = ddlDepartment.SelectedValue
        dr = cmd.ExecuteReader()
        dtGrid.Load(dr)
        con.Close()
        dgvOpeningStock.DataSource = dtGrid
        dgvOpeningStock.DataBind()

        If dtGrid.Rows.Count > 0 Then
            dgvOpeningStock.Visible = True
            btnSave.Visible = True
        Else
            dgvOpeningStock.Visible = False
            btnSave.Visible = False
        End If
    End Sub

    Protected Sub CommonDrDt(ByVal strQuery As String)
        Dim con As SqlConnection = New SqlConnection(connection)
        dtCommon = New DataTable()
        '******* 
        Dim cmdMailId As SqlCommand = New SqlCommand(strQuery, con)
        con.Open()
        drCommon = cmdMailId.ExecuteReader()
        dtCommon.Load(drCommon)
        con.Close()
    End Sub


    Protected Sub ddlDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDepartment.SelectedIndexChanged
        LoadGrid()
    End Sub

    Protected Sub txtOpeningStock_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim indexValue As Int32 = TryCast(TryCast(sender, TextBox).NamingContainer, GridViewRow).RowIndex
        Dim strRate As String = dgvOpeningStock.Rows(indexValue).Cells(3).Text
        Dim txtOpeningStock As TextBox = DirectCast(dgvOpeningStock.Rows(indexValue).FindControl("txtOpeningStock"), TextBox)
        'Dim intval As Integer = Convert.ToInt32(strRate) * Convert.ToInt32(txtOpeningStock.Text)
        Dim intval As Double = Convert.ToDouble(strRate) * Convert.ToDouble(txtOpeningStock.Text)
        dgvOpeningStock.Rows(indexValue).Cells(5).Text = intval.ToString()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Count As Integer = 0
        Dim IncomQty As Integer = 0
        For i As Integer = 0 To dgvOpeningStock.Rows.Count - 1
            Dim txtOpeningStock As TextBox = DirectCast(dgvOpeningStock.Rows(i).FindControl("txtOpeningStock"), TextBox)
            If txtOpeningStock.Text <> "" Then
                IncomQty = IncomQty + 1
            End If
        Next
        If IncomQty = 0 Then
            MessageBox("Atleast Enter One Opening Qty")
            Exit Sub
        End If
        For i As Integer = 0 To dgvOpeningStock.Rows.Count - 1
            Dim strCatName As String = dgvOpeningStock.Rows(i).Cells(0).Text
            Dim strGroup As String = dgvOpeningStock.Rows(i).Cells(1).Text
            Dim strItem As String = dgvOpeningStock.Rows(i).Cells(2).Text
            Dim strRate As String = dgvOpeningStock.Rows(i).Cells(3).Text
            Dim txtOpeningStock As TextBox = DirectCast(dgvOpeningStock.Rows(i).FindControl("txtOpeningStock"), TextBox)
            Dim strAmount As String = dgvOpeningStock.Rows(i).Cells(5).Text
            Dim strDept As String = dgvOpeningStock.Rows(i).Cells(6).Text

            If strAmount <> "" And txtOpeningStock.Text <> "" Then
                Dim con As New SqlConnection(connection)
                Dim dr As SqlDataReader
                Dim dtGrid As DataTable = New DataTable()
                con.Open()
                Dim cmd As SqlCommand = New SqlCommand("SP_PPE_openingStockInsert", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@CatName", SqlDbType.VarChar).Value = strCatName
                cmd.Parameters.Add("@ItemGroup", SqlDbType.VarChar).Value = strGroup
                cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = strItem
                cmd.Parameters.Add("@Rate", SqlDbType.VarChar).Value = strRate
                cmd.Parameters.Add("@openingStock", SqlDbType.VarChar).Value = txtOpeningStock.Text
                cmd.Parameters.Add("@OpenAmount", SqlDbType.VarChar).Value = strAmount
                cmd.Parameters.Add("@Dept", SqlDbType.VarChar).Value = strDept
                cmd.Parameters.Add("@CreatedBy", SqlDbType.VarChar).Value = Session("empcode").ToString()
                cmd.ExecuteNonQuery()
                con.Close()
                Count = Count + 1
            End If
        Next
        dgvOpeningStock.Visible = False
        btnSave.Visible = False
        LoadDepartment()
        If Count > 0 Then
            MessageBox("Record Saved Successfully")
        End If
    End Sub
End Class
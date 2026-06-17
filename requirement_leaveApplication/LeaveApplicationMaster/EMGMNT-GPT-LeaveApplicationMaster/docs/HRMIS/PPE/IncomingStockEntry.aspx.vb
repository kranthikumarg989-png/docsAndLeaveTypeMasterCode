Imports System.Data.SqlClient
Partial Public Class IncomingStockEntry
    Inherits System.Web.UI.Page
    Dim dtCommon As DataTable = New DataTable()
    Dim drCommon As SqlDataReader
    Dim connection As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        connection = ConfigurationManager.ConnectionStrings("Sqlcon1").ConnectionString
        If IsPostBack = False Then
            LoadDepartment()
            Session("empcode") = "014543"
            dgvIncomingStock.Visible = False
            btnSave.Visible = False
            txtDate.Text = ""
        End If
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
        Dim cmd As SqlCommand = New SqlCommand("SP_PPE_LoadItemClosingStock", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Department", SqlDbType.VarChar).Value = ddlDepartment.SelectedValue
        cmd.Parameters.Add("@ClosingDate", SqlDbType.VarChar).Value = txtDate.Text.Trim()
        dr = cmd.ExecuteReader()
        dtGrid.Load(dr)
        con.Close()
        dgvIncomingStock.DataSource = dtGrid
        dgvIncomingStock.DataBind()

        If dtGrid.Rows.Count > 0 Then
            dgvIncomingStock.Visible = True
            btnSave.Visible = True
        Else
            dgvIncomingStock.Visible = False
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

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub ddlDepartment_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDepartment.SelectedIndexChanged
        If txtDate.Text.Trim() <> "" Then
            LoadGrid()
        Else
            MessageBox("Please Select Date")
            Exit Sub
        End If

    End Sub

    Protected Sub txtIncomingQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim indexValue As Int32 = TryCast(TryCast(sender, TextBox).NamingContainer, GridViewRow).RowIndex
        Dim strRate As String = dgvIncomingStock.Rows(indexValue).Cells(3).Text
        Dim txtIncomingQty As TextBox = DirectCast(dgvIncomingStock.Rows(indexValue).FindControl("txtIncomingQty"), TextBox)
        Dim intval As Double = Convert.ToDouble(strRate) * Convert.ToDouble(txtIncomingQty.Text)
        dgvIncomingStock.Rows(indexValue).Cells(5).Text = intval.ToString()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim Count As Integer = 0
        Dim IncomQty As Integer = 0
        For i As Integer = 0 To dgvIncomingStock.Rows.Count - 1
            Dim txtIncomingQty As TextBox = DirectCast(dgvIncomingStock.Rows(i).FindControl("txtIncomingQty"), TextBox)
            If txtIncomingQty.Text <> "" Then
                IncomQty = IncomQty + 1
            End If
        Next
        If IncomQty = 0 Then
            MessageBox("Atleast Enter One Incoming Qty")
            Exit Sub
        End If
        For i As Integer = 0 To dgvIncomingStock.Rows.Count - 1
            Dim strCatName As String = dgvIncomingStock.Rows(i).Cells(0).Text
            Dim strGroup As String = dgvIncomingStock.Rows(i).Cells(1).Text
            Dim strItem As String = dgvIncomingStock.Rows(i).Cells(2).Text
            Dim strRate As String = dgvIncomingStock.Rows(i).Cells(3).Text
            Dim txtIncomingQty As TextBox = DirectCast(dgvIncomingStock.Rows(i).FindControl("txtIncomingQty"), TextBox)
            Dim strAmount As String = dgvIncomingStock.Rows(i).Cells(5).Text

            If strAmount <> "" And txtIncomingQty.Text <> "" Then
                Dim con As New SqlConnection(connection)
                Dim dr As SqlDataReader
                Dim dtGrid As DataTable = New DataTable()
                con.Open()
                Dim cmd As SqlCommand = New SqlCommand("SP_PPE_ClosingStockInsert", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@CatName", SqlDbType.VarChar).Value = strCatName
                cmd.Parameters.Add("@ItemGroup", SqlDbType.VarChar).Value = strGroup
                cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = strItem
                cmd.Parameters.Add("@Rate", SqlDbType.VarChar).Value = strRate
                cmd.Parameters.Add("@IncomingStock", SqlDbType.VarChar).Value = txtIncomingQty.Text
                cmd.Parameters.Add("@IncomeAmount", SqlDbType.VarChar).Value = strAmount
                cmd.Parameters.Add("@Dept", SqlDbType.VarChar).Value = ddlDepartment.SelectedValue
                cmd.Parameters.Add("@InComeDate", SqlDbType.VarChar).Value = txtDate.Text.Trim()
                cmd.Parameters.Add("@Createdby", SqlDbType.VarChar).Value = Session("empcode").ToString()
                cmd.ExecuteNonQuery()
                con.Close()
                Count = Count + 1
            End If
        Next
        dgvIncomingStock.Visible = False
        btnSave.Visible = False
        LoadDepartment()
        txtDate.Text = ""
        If Count > 0 Then
            MessageBox("Record Saved Successfully")
        End If
    End Sub
End Class
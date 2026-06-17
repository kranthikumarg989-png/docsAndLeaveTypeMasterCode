Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications

Partial Public Class frmIssueForm
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Private Shared dtItem As DataTable = New DataTable()
    Shared dctot As Double

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (355)
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


        dctot = 0
        lblmsg.Text = ""
        If IsPostBack = False Then
            GetIssueDept()
            ' lblDept.Text = "9000" ' Session("_edept")
            'txtAstock.Text = "50"
            GetCategory()
            GetIssueForm()
            ddlGroup.Items.Insert(0, "**Select**")
            ddlGroup.Items(0).Value = 0
            ddlItem.Items.Insert(0, "**Select**")
            ddlItem.Items(0).Value = 0
        End If
    End Sub
    Protected Sub GetIssueDept()
        Try
            Dim con As SqlConnection = New SqlConnection(constr)
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim dt As DataTable = New DataTable()
            con.Open()
            cmd = New SqlCommand("SP_PPE_IssueDept_Rights", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = Session("empcode")
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            con.Close()
            ddlDept.DataSource = dt
            ddlDept.DataTextField = "dept"
            ddlDept.DataValueField = "dept"
            ddlDept.DataBind()
            ddlDept.SelectedValue = Session("_edept")
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub GetCategory()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        con.Open()
        cmd = New SqlCommand("select * from Tb_PPE_CategoryType", con)
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        con.Close()
        ddlCategory.DataSource = dt
        ddlCategory.DataTextField = "Description"
        ddlCategory.DataValueField = "CatCode"
        ddlCategory.DataBind()
        ddlCategory.Items.Insert(0, "**Select**")
        ddlCategory.Items(0).Value = 0
    End Sub

    Protected Sub ddlCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCategory.SelectedIndexChanged
        txtAstock.Text = ""
        txtRate.Text = ""
        ddlGroup.Items.Clear()
        ddlItem.Items.Clear()
        ddlItem.Items.Insert(0, "**Select**")
        ddlItem.Items(0).Value = 0
        If ddlCategory.SelectedValue <> "0" Then
            Dim con As SqlConnection = New SqlConnection(constr)
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim dt As DataTable = New DataTable()
            con.Open()
            cmd = New SqlCommand("select * from Tb_PPE_ItemGroup where Category='" + ddlCategory.SelectedItem.Text + "'", con)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            con.Close()

            ddlGroup.DataSource = dt
            ddlGroup.DataTextField = "ItemGroup"
            ddlGroup.DataValueField = "RowId"
            ddlGroup.DataBind()
            ddlGroup.Items.Insert(0, "**Select**")
            ddlGroup.Items(0).Value = 0
        Else
            ddlGroup.DataSource = Nothing
            ddlGroup.DataBind()
            ddlGroup.Items.Insert(0, "**Select**")
            ddlGroup.Items(0).Value = 0
        End If
        ddlCategory.Focus()
    End Sub

    Protected Sub ddlGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged
        txtRate.Text = ""
        txtAstock.Text = ""
        ddlItem.Items.Clear()
        If ddlGroup.SelectedValue <> "0" Then
            Dim con As SqlConnection = New SqlConnection(constr)
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim dt As DataTable = New DataTable()
            con.Open()
            cmd = New SqlCommand("select * from Tb_PPE_ItemMaster where Category='" + ddlCategory.SelectedItem.Text + "' and ItemGroup='" + ddlGroup.SelectedItem.Text + "'", con)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            con.Close()

            ddlItem.DataSource = dt
            ddlItem.DataTextField = "ItemDesc"
            ddlItem.DataValueField = "RowId"
            ddlItem.DataBind()
            ddlItem.Items.Insert(0, "**Select**")
            ddlItem.Items(0).Value = 0
        Else
            ddlItem.DataSource = Nothing
            ddlItem.DataBind()
            ddlItem.Items.Insert(0, "**Select**")
            ddlItem.Items(0).Value = 0
        End If
        ddlGroup.Focus()
    End Sub

    Protected Sub txtIssuedTo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtIssuedTo.TextChanged
        lblName.Text = ""
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        con.Open()
        cmd = New SqlCommand("select * from empmaster where empcode='" + txtIssuedTo.Text.Trim() + "' and resigned<>'Y'", con)
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        con.Close()
        If dt.Rows.Count > 0 Then
            lblName.Text = dt.Rows(0)("empname").ToString()
        Else
            con.Open()
            cmd = New SqlCommand("select * from Outhrmis.dbo.empmaster where empcode='" + txtIssuedTo.Text.Trim() + "'  and resigned<>'Y'", con)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            con.Close()
            If dt.Rows.Count > 0 Then
                lblName.Text = dt.Rows(0)("empname").ToString()
            Else
                lblmsg.Text = "Invalid Employee"
                lblmsg.ForeColor = Drawing.Color.Red
            End If
        End If
        ddlCategory.Focus()
    End Sub

    Protected Sub ddlItem_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlItem.SelectedIndexChanged
        AvailableStock()
    End Sub
    Protected Sub AvailableStock()
        txtRate.Text = ""
        txtAstock.Text = ""
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        con.Open()
        ' cmd = New SqlCommand("select * from Tb_PPE_ItemMaster where RowId='" + ddlItem.SelectedValue + "'", con)
        cmd = New SqlCommand("SP_PPE_GetRateTotStock_byItem", con)
        cmd.CommandType = CommandType.StoredProcedure
        cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = ddlCategory.SelectedItem.Text.Trim()
        cmd.Parameters.Add("@ItemGroup", SqlDbType.VarChar).Value = ddlGroup.SelectedItem.Text.Trim()
        cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = ddlItem.SelectedItem.Text.Trim()
        cmd.Parameters.Add("@Dept", SqlDbType.VarChar).Value = ddlDept.SelectedValue ' lblDept.Text.Trim()
        cmd.Parameters.Add("@RowId", SqlDbType.Int).Value = ddlItem.SelectedValue
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        con.Close()
        If dt.Rows.Count > 0 Then
            txtRate.Text = dt.Rows(0)("Rate").ToString()
            txtAstock.Text = dt.Rows(0)("TotStock").ToString()
        End If
        ddlItem.Focus()
    End Sub
    Protected Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        txtAmount.Text = ""
        Try
            txtAmount.Text = (Convert.ToDouble(txtRate.Text) * Convert.ToDouble(txtQty.Text)).ToString()
            btnAdd.Focus()
        Catch ex As Exception
            If txtRate.Text.Trim() = "" Then
                lblmsg.Text = "Required:Item"
                lblmsg.ForeColor = Drawing.Color.Red
            End If
            txtQty.Text = ""
            txtQty.Focus()
        End Try

    End Sub
    Protected Sub GetIssueForm()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        con.Open()
        cmd = New SqlCommand("select isnull(max(IssueNo),0)+1  from Tb_PPE_Issueform", con)
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        con.Close()
        If dt.Rows.Count > 0 Then
            lblIssueno.Text = dt.Rows(0)(0).ToString()
        End If
    End Sub

    Protected Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If ddlCategory.SelectedValue <> "0" And ddlGroup.SelectedValue <> "0" And lblName.Text.Trim() <> "" Then
            If Convert.ToDouble(txtAstock.Text.Trim()) < Convert.ToDouble(txtQty.Text.Trim()) Then
                lblmsg.Text = "Available stock is less then Qty"
                lblmsg.ForeColor = Drawing.Color.Red
                Exit Sub
            End If
            lblmsg.Text = ""
            '-------------Abnormal Calc-----------------------
            Dim strAbnormal As String = "N"
            Dim con As SqlConnection = New SqlConnection(constr)
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim dt As DataTable = New DataTable()
            con.Open()
            cmd = New SqlCommand("SP_PPE_LifeSpanCalc", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = ddlCategory.SelectedItem.Text.Trim()
            cmd.Parameters.Add("@ItemGroup", SqlDbType.VarChar).Value = ddlGroup.SelectedItem.Text.Trim()
            cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = ddlItem.SelectedItem.Text.Trim()
            cmd.Parameters.Add("@IssuedTo", SqlDbType.VarChar).Value = txtIssuedTo.Text.Trim()
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            con.Close()
            If dt.Rows.Count > 0 Then
                If dt.Rows(0)(0).ToString.Trim <> "N" And rbtnOption.SelectedItem.Text.Trim = "First" Then
                    lblmsg.Text = "The item already given to particular employee please select Reissue/Replace" 'dt.Rows(0)(0).ToString & "-" & rbtnOption.SelectedItem.Text & 
                    lblmsg.ForeColor = Drawing.Color.Red
                    Exit Sub
                Else

                    If dt.Rows(0)(0).ToString = "F" Then
                        strAbnormal = "N"
                    Else
                        strAbnormal = dt.Rows(0)(0).ToString()
                    End If
                End If

            End If
            '-------------------------------------------------
            If dtItem.Rows.Count = 0 Then
                dtItem = New DataTable()
                dtItem.Columns.Add("RowId")
                dtItem.Columns.Add("Category")
                dtItem.Columns.Add("Group")
                dtItem.Columns.Add("Item")
                dtItem.Columns.Add("Rate")
                dtItem.Columns.Add("Qty")
                dtItem.Columns.Add("Amount")
                dtItem.Columns.Add("Astock")
                dtItem.Columns.Add("Option")
                dtItem.Columns.Add("Abnormal")
                dtItem.Rows.Add("1", ddlCategory.SelectedItem.Text, ddlGroup.SelectedItem.Text, ddlItem.SelectedItem.Text, txtRate.Text.Trim(), txtQty.Text.Trim(), txtAmount.Text.Trim(), txtAstock.Text.Trim(), rbtnOption.SelectedItem.Text, strAbnormal.Trim())
                '
                gvAddedItem.DataSource = dtItem
                gvAddedItem.DataBind()
            Else
                dtItem.Rows.Add(dtItem.Rows.Count + 1, ddlCategory.SelectedItem.Text, ddlGroup.SelectedItem.Text, ddlItem.SelectedItem.Text, txtRate.Text.Trim(), txtQty.Text.Trim(), txtAmount.Text.Trim(), txtAstock.Text.Trim(), rbtnOption.SelectedItem.Text, strAbnormal.Trim())
                gvAddedItem.DataSource = dtItem
                gvAddedItem.DataBind()

            End If

            If gvAddedItem.Rows.Count > 0 Then
                btnSave.Visible = True
                txtIssuedTo.ReadOnly = True
            Else
                btnSave.Visible = False
                txtIssuedTo.ReadOnly = False
            End If
            txtQty.Text = ""
            txtAmount.Text = ""
        ElseIf ddlCategory.SelectedValue = "0" Then
            lblmsg.Text = "Required:Category"
            lblmsg.ForeColor = Drawing.Color.Red
        ElseIf ddlGroup.SelectedValue = "0" Then
            lblmsg.Text = "Required:Group"
            lblmsg.ForeColor = Drawing.Color.Red
        ElseIf lblName.Text.Trim() = "" Then
            lblmsg.Text = " Please enter Correct employee code in Issue To"
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub

    Protected Sub gvAddedItem_RowCommand(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvAddedItem.RowCommand
        If e.CommandName = "DeleteRow" Then
            Try
                Dim i As Integer = Convert.ToInt32(e.CommandArgument)
                Dim dritems As DataRow = dtItem.Rows(i - 1)
                dritems.Delete()
                gvAddedItem.DataSource = dtItem
                gvAddedItem.DataBind()
                If gvAddedItem.Rows.Count > 0 Then
                    btnSave.Visible = True
                    txtIssuedTo.ReadOnly = True
                Else
                    btnSave.Visible = False
                    txtIssuedTo.ReadOnly = False
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Protected Sub gvAddedItem_RowDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvAddedItem.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim lbltot As Label = DirectCast(e.Row.FindControl("lblAmt"), Label)
            dctot = dctot + Convert.ToDouble(lbltot.Text)
            Dim hdnAbnormal As HiddenField = DirectCast(e.Row.FindControl("hdnAbnormal"), HiddenField)
            If hdnAbnormal.Value = "Y" Then
                e.Row.BackColor = Drawing.Color.Red
                e.Row.ForeColor = Drawing.Color.White
            End If
        ElseIf e.Row.RowType = DataControlRowType.Footer Then
            DirectCast(e.Row.FindControl("lblTotAmt"), Label).Text = dctot
        End If
    End Sub

    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click


        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        For i As Integer = 0 To gvAddedItem.Rows.Count - 1
            con.Open()
            cmd = New SqlCommand("SP_PPE_ItemIssueInsert", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@IssuedDept", SqlDbType.VarChar).Value = ddlDept.SelectedValue ' lblDept.Text.Trim()
            cmd.Parameters.Add("@IssueTo", SqlDbType.VarChar).Value = txtIssuedTo.Text.Trim()
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = gvAddedItem.Rows(i).Cells(1).Text
            cmd.Parameters.Add("@ItemGroup", SqlDbType.VarChar).Value = gvAddedItem.Rows(i).Cells(2).Text
            cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = gvAddedItem.Rows(i).Cells(3).Text
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = Convert.ToDouble(gvAddedItem.Rows(i).Cells(4).Text)
            cmd.Parameters.Add("@Qty", SqlDbType.Float).Value = Convert.ToDouble(gvAddedItem.Rows(i).Cells(5).Text)
            cmd.Parameters.Add("@Amount", SqlDbType.Float).Value = Convert.ToDouble(DirectCast(gvAddedItem.Rows(i).FindControl("lblAmt"), Label).Text)
            cmd.Parameters.Add("@ItemOption", SqlDbType.VarChar).Value = DirectCast(gvAddedItem.Rows(i).FindControl("hdnOption"), HiddenField).Value
            cmd.Parameters.Add("@AvailabledStock", SqlDbType.Float).Value = Convert.ToDouble(DirectCast(gvAddedItem.Rows(i).FindControl("hdnAstock"), HiddenField).Value)
            cmd.Parameters.Add("@Abnormal", SqlDbType.Char).Value = DirectCast(gvAddedItem.Rows(i).FindControl("hdnAbnormal"), HiddenField).Value
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = Session("empcode")
            cmd.Parameters.Add("@issueno", SqlDbType.Int).Value = Convert.ToInt32(lblIssueno.Text.Trim())
            cmd.ExecuteNonQuery()
            con.Close()
        Next
        gvAddedItem.DataSource = Nothing
        gvAddedItem.DataBind()
        dtItem = New DataTable()
        btnSave.Visible = False

        ClientScript.RegisterStartupScript(GetType(String), "IssueFormPrint", "winOpen('" + lblIssueno.Text.Trim() + "')", True)
        ' ClientScript.RegisterClientScriptBlock(GetType(String), "InvoicePrint", "winOpen('" + txtInvoice.Text.Trim.ToString() + "','" + scode + "')", True)
        'ClientScript.RegisterStartupScript(GetType(String), "hwa", "alert('Hello World');", True)
        'ClientScript.RegisterStartupScript(GetType(String), "IssueFormPrint", "winOpen('6')", True)
        GetIssueForm()
        ddlItem.SelectedValue = 0
        txtRate.Text = ""
        txtAstock.Text = ""
        txtQty.Text = ""
        txtAmount.Text = ""
        txtIssuedTo.ReadOnly = False
        txtIssuedTo.Text = ""
        lblName.Text = ""
    End Sub

    Protected Sub ddlDept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlDept.SelectedIndexChanged
        AvailableStock()
    End Sub
End Class
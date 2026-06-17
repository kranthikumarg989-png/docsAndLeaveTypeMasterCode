
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class frmItemMaster
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Private Shared dtItem As DataTable = New DataTable()
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (358)
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
        If IsPostBack = False Then
            GetCategory()
            GetPPEItemGroup()
            ddlGroup.Items.Insert(0, "**Select**")
            ddlGroup.Items(0).Value = 0
            lblmsg.Text = ""
            dtItem = New DataTable()
        End If
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
    Protected Sub GetPPEItemGroup()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        con.Open()
        cmd = New SqlCommand("select * from Tb_PPE_ItemMaster", con)
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        con.Close()
        gvItemGroup.DataSource = dt
        gvItemGroup.DataBind()
    End Sub
    Protected Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If ddlCategory.SelectedValue <> "0" And ddlGroup.SelectedValue <> "0" Then
            lblmsg.Text = ""
            If dtItem.Rows.Count = 0 Then
                dtItem = New DataTable()
                dtItem.Columns.Add("RowId")
                dtItem.Columns.Add("Category")
                dtItem.Columns.Add("Group")
                dtItem.Columns.Add("Item")
                dtItem.Columns.Add("Rate")
                dtItem.Columns.Add("Life")
                dtItem.Rows.Add("1", ddlCategory.SelectedItem.Text, ddlGroup.SelectedItem.Text, txtDesc.Text.Trim(), txtRate.Text.Trim(), txtLifeSpan.Text.Trim())
                '
                gvAddedItem.DataSource = dtItem
                gvAddedItem.DataBind()
            Else
                dtItem.Rows.Add(dtItem.Rows.Count + 1, ddlCategory.SelectedItem.Text, ddlGroup.SelectedItem.Text, txtDesc.Text.Trim(), txtRate.Text.Trim(), txtLifeSpan.Text.Trim())
                gvAddedItem.DataSource = dtItem
                gvAddedItem.DataBind()
            End If
            If gvAddedItem.Rows.Count > 0 Then
                btnSave.Visible = True
            Else
                btnSave.Visible = False
            End If
            txtDesc.Text = ""
            txtRate.Text = ""
            txtLifeSpan.Text = ""
        ElseIf ddlCategory.SelectedValue = "0" Then
            lblmsg.Text = "Required:Category"
            lblmsg.ForeColor = Drawing.Color.Red
        ElseIf ddlGroup.SelectedValue = "0" Then
            lblmsg.Text = "Required:Group"
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lblmsg.Text = ""
        dtItem = New DataTable()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        For i As Integer = 0 To gvAddedItem.Rows.Count - 1
            con.Open()
            cmd = New SqlCommand("SP_PPE_ItemMasterInsert", con)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = gvAddedItem.Rows(i).Cells(1).Text
            cmd.Parameters.Add("@ItemGroup", SqlDbType.VarChar).Value = gvAddedItem.Rows(i).Cells(2).Text
            cmd.Parameters.Add("@ItemDesc", SqlDbType.VarChar).Value = gvAddedItem.Rows(i).Cells(3).Text
            cmd.Parameters.Add("@Rate", SqlDbType.Float).Value = Convert.ToDouble(gvAddedItem.Rows(i).Cells(4).Text)
            cmd.Parameters.Add("@LifeSpan", SqlDbType.Float).Value = Convert.ToDouble(gvAddedItem.Rows(i).Cells(5).Text)
            cmd.Parameters.Add("@empcode", SqlDbType.VarChar).Value = Session("empcode")
            cmd.ExecuteNonQuery()
            con.Close()
        Next
        gvAddedItem.DataSource = Nothing
        gvAddedItem.DataBind()
        dtItem = New DataTable()
        btnSave.Visible = False
        GetPPEItemGroup()
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
                Else
                    btnSave.Visible = False
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Protected Sub ddlCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCategory.SelectedIndexChanged
        ddlGroup.Items.Clear()
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
    End Sub
End Class
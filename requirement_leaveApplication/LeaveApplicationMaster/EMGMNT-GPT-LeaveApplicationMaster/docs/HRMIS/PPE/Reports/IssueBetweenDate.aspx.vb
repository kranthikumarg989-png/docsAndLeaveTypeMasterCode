Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class IssueBetweenDate
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        If IsPostBack = False Then
            GetDepartment()
            trItem1.Visible = False
            trItem2.Visible = False
        End If
    End Sub

    Protected Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim category, group, item As String
        category = "All"
        group = "All"
        item = "All"
        If trItem1.Visible = True And trItem2.Visible = True Then
            category = ddlCategory.SelectedItem.Text
            group = ddlGroup.SelectedItem.Text
            item = ddlItem.SelectedItem.Text
        End If
        'Tpe, Dpt, Fdt, Tdt, Cat, Grp, Itm
        ClientScript.RegisterStartupScript(GetType(String), "IssueFormPrint", "IssueRpt('" + rbtnType.SelectedValue + "','" + ddlDept.SelectedValue + "','" + txtFromDt.Text.Trim() + "','" + txtToDt.Text.Trim() + "','" + category + "','" + group + "','" + item + "')", True)
    End Sub

    Protected Sub rbtnsearch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnsearch.SelectedIndexChanged
        If rbtnsearch.SelectedValue = "Dept" Then
            trItem1.Visible = False
            trItem2.Visible = False
        Else
            trItem1.Visible = True
            trItem2.Visible = True
            GetCategory()
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
        ddlCategory.Items.Insert(0, "All")
        ddlCategory.Items(0).Value = 0
        '/--------------------
        ddlGroup.Items.Clear()
        ddlItem.Items.Clear()
        ddlGroup.Items.Insert(0, "All")
        ddlGroup.Items(0).Value = 0
        ddlItem.Items.Insert(0, "All")
        ddlItem.Items(0).Value = 0
        '/----------------------
    End Sub

    Protected Sub ddlCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlCategory.SelectedIndexChanged
        ddlGroup.Items.Clear()
        ddlItem.Items.Clear()
        ddlItem.Items.Insert(0, "All")
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
            ddlGroup.Items.Insert(0, "All")
            ddlGroup.Items(0).Value = 0
        Else
            ddlGroup.DataSource = Nothing
            ddlGroup.DataBind()
            ddlGroup.Items.Insert(0, "All")
            ddlGroup.Items(0).Value = 0
        End If
        ddlCategory.Focus()
    End Sub

    Protected Sub ddlGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlGroup.SelectedIndexChanged

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
            ddlItem.Items.Insert(0, "All")
            ddlItem.Items(0).Value = 0
        Else
            ddlItem.DataSource = Nothing
            ddlItem.DataBind()
            ddlItem.Items.Insert(0, "All")
            ddlItem.Items(0).Value = 0
        End If
        ddlGroup.Focus()
    End Sub
End Class
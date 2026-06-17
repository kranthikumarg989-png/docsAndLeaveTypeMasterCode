Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class frmFMDverification
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (361)
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
            GetItemDetails()
        End If
    End Sub
    Protected Sub GetItemDetails()
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim dt As DataTable = New DataTable()
        con.Open()
        cmd = New SqlCommand("select sum(Amount)as TotAmount,IssueNo from Tb_PPE_Issueform  where ItemOption='Reissue' and FMDstatus is null group by IssueNo", con)
        dr = cmd.ExecuteReader()
        dt.Load(dr)
        con.Close()
        gvItemGroup.DataSource = dt
        gvItemGroup.DataBind()
    End Sub
    Protected Sub gvItemGroup_RowDataBound(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvItemGroup.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            Dim gvitem As GridView = DirectCast(e.Row.FindControl("gvItem"), GridView)
            Dim con As SqlConnection = New SqlConnection(constr)
            Dim cmd As SqlCommand
            Dim dr As SqlDataReader
            Dim dt As DataTable = New DataTable()
            con.Open()
            cmd = New SqlCommand("select * from Tb_PPE_Issueform where Issueno='" + e.Row.Cells(0).Text + "' and ItemOption='Reissue' and FMDstatus is null", con)
            dr = cmd.ExecuteReader()
            dt.Load(dr)
            con.Close()
            gvitem.DataSource = dt
            gvitem.DataBind()
        End If
    End Sub
    Protected Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim cmd As SqlCommand
        For i As Integer = 0 To gvItemGroup.Rows.Count - 1
            Dim rbtnstatus As RadioButtonList = DirectCast(gvItemGroup.Rows(i).FindControl("rbtnStatus"), RadioButtonList)
            If rbtnstatus.SelectedValue <> "P" Then
                con.Open()
                cmd = New SqlCommand("SP_PPE_FMDverifyUpdate", con)
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("@FMDstatus", SqlDbType.VarChar).Value = rbtnstatus.SelectedItem.Text
                cmd.Parameters.Add("@FMDverifiedby", SqlDbType.VarChar).Value = Session("empcode")
                cmd.Parameters.Add("@IssueNo", SqlDbType.VarChar).Value = gvItemGroup.Rows(i).Cells(0).Text
                cmd.ExecuteNonQuery()
                con.Close()
            End If
        Next
        GetItemDetails()
    End Sub
End Class
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.Emanagement.globalinfo
Imports E_Management.Emanagement.EMSapplications
Partial Public Class memorpt
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim sqltext As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (117)
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


        'GridView1.DataBind()
        If (rbl1.SelectedIndex = 2) = True Then
            ddl1.Enabled = False
            tb3.Enabled = False
        End If
        If Session("srt") <> "" Then
            sqltext = Session("qry")
            DS = GetappCharactersetting(sqltext)
            GridView1.DataSource = DS
            GridView1.DataBind()
            Session("srt") = ""
        End If
    End Sub
    Protected Sub rbl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbl1.SelectedIndexChanged
        If rbl1.SelectedValue = "Dept" Then
            ddl1.Enabled = True
            tb3.Enabled = False
            ddl1.Focus()
        ElseIf rbl1.SelectedValue = "Emp" Then
            ddl1.Enabled = False
            tb3.Enabled = True
            tb3.Focus()
        Else
            ddl1.Enabled = False
            tb3.Enabled = False
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        bindgrid()
    End Sub
    Public Sub bindgrid()
        Dim idl As String
        If rbl1.SelectedValue = "Dept" Then
            idl = Val(ddl1.Text)
            Session("qry") = "select Serialno,Emp_no,Emp_name,Dept,CONVERT(VARCHAR(10),sumit_date,110)as Sumit_date,To_dept,Subject,Approvedby,CONVERT(VARCHAR(10),approved_date,110)as Approved_date from memo where sumit_date >='" & (tb1.Text) & "' and sumit_date <='" & (tb2.Text) & "' and (to_dept like '%" & idl & "%' or to_dept like'%All Department%') order by serialno"
        ElseIf rbl1.SelectedValue = "Emp" Then
            Session("qry") = "select Serialno,Emp_no,Emp_name,Dept,CONVERT(VARCHAR(10),sumit_date,110)as Sumit_date,To_dept,Subject,Approvedby,CONVERT(VARCHAR(10),approved_date,110)as Approved_date from memo where sumit_date >='" & (tb1.Text) & "' and sumit_date <='" & (tb2.Text) & "' and emp_no='" & (tb3.Text) & "' order by serialno"
        Else
            Session("qry") = "select Serialno,Emp_no,Emp_name,Dept,CONVERT(VARCHAR(10),sumit_date,110)as Sumit_date,To_dept,Subject,Approvedby,CONVERT(VARCHAR(10),approved_date,110)as Approved_date from memo where sumit_date >='" & (tb1.Text) & "' and sumit_date <='" & (tb2.Text) & "' order by serialno"
        End If
        sqltext = Session("qry")
        DS = GetappCharactersetting(sqltext)
        GridView1.DataSource = DS
        GridView1.DataBind()
    End Sub
    Function GetappCharactersetting(ByVal sqltext As String) As DataSet
        MyGlobal.Con_Str()
        MyGlobal.Open_Con()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand(sqltext, con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function
    Private Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewPageEventArgs) Handles GridView1.PageIndexChanging
        bindgrid()
        GridView1.PageIndex = e.NewPageIndex
        GridView1.DataBind()
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        For i As Integer = 0 To GridView1.Rows.Count - 1
            If GridView1.Rows(i).Cells(5).Text.Contains("All Department") = True Then
                GridView1.Rows(i).Cells(5).Text = GridView1.Rows(i).Cells(5).Text.Replace("All Department", "All Dept")
            End If
        Next
    End Sub
    Private Sub GridView1_Sorting(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewSortEventArgs) Handles GridView1.Sorting
        If Session("qry").ToString.Contains("desc") = True Then
            Session("qry") = Session("qry").ToString.Replace("desc", "")
        Else
            Session("qry") = Session("qry") & " desc"
        End If
        Session("srt") = "srt"
    End Sub
End Class
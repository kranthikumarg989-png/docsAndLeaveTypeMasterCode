Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class BudgetSettings
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (63)
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
        ' Session("empcode") = "014543"
        LblMsg.Text = ""
    End Sub
 
    Protected Sub SubmitOT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitOT.Click
        Dim fd1 As String
        fd1 = txtfrom.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtto.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)

        Dim startdt
        Dim enddt
        startdt = Day(fd)
        enddt = Day(td)

        Dim y, m
        m = strdate(1)
        y = strdate(2)

        Dim dm = System.DateTime.DaysInMonth(y, m)

        Dim res = (fd.AddMonths(1)).AddDays(-1)

        If (res <> td) Or (startdt <> "01" And enddt <> dm) Then
            LblMsg.Text = "Please check the work schedule date "
            Exit Sub
        End If

        Dim thisdt As New DateTime
        thisdt = Date.Now.ToShortDateString()

        ''commented on 19/8/2011'

        'If fd < thisdt Then
        '    LblMsg.Text = "You cannot do Budget setting for PreviousDate"
        '    Exit Sub
        'End If

        If td < fd Then
            LblMsg.Text = "Enter Todate greater than from date"
            Exit Sub
        End If

        If lbledit.Text = "-" Then

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("OT_BudgetSettin")
                Cmd.Parameters.AddWithValue("@fdate", fd)
                Cmd.Parameters.AddWithValue("@tdate", td)
                Cmd.Parameters.AddWithValue("@category", cat.SelectedValue)
                Cmd.Parameters.AddWithValue("@mhr", maxhrs.Text)
                Cmd.Parameters.AddWithValue("@cby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@ctime", DateTime.Now)
                Cmd.Parameters.AddWithValue("@sect", sec.SelectedValue)

                Cmd.ExecuteNonQuery()

                LblMsg.Text = "OT BUDGET SCHEDULED"
                LblMsg.ForeColor = Drawing.Color.Green
                txtfrom.Text = ""
                txtto.Text = ""
                cat.SelectedValue = "-1"
                maxhrs.Text = ""
                sec.SelectedValue = "-1"
                lbledit.Text = "-"

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try

        Else

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()

                Call MyGlobal.dbSp_open("OT_UpdOTBudgetSetting")
                Cmd.Parameters.AddWithValue("@fdate", fd)
                Cmd.Parameters.AddWithValue("@tdate", td)
                Cmd.Parameters.AddWithValue("@category", cat.SelectedValue)
                Cmd.Parameters.AddWithValue("@mhr", maxhrs.Text)
                Cmd.Parameters.AddWithValue("@cby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@ctime", DateTime.Now)
                Cmd.Parameters.AddWithValue("@sect", sec.SelectedValue)
                Cmd.Parameters.AddWithValue("@stat", "S")
                Cmd.Parameters.AddWithValue("@vid", lbledit.Text)
                Cmd.ExecuteNonQuery()

                LblMsg.Text = "OT BUDGET UPDATED & SCHEDULED"
                LblMsg.ForeColor = Drawing.Color.Green

                txtfrom.Text = ""
                txtto.Text = ""
                cat.SelectedValue = "-1"
                maxhrs.Text = ""
                sec.SelectedValue = "-1"
                lbledit.Text = "-"

            Catch ex As SqlException
                LblMsg.Text = ex.Message
                LblMsg.ForeColor = Drawing.Color.Red
            End Try
        End If
        MyGlobal.db_close()

        GridView1.DataBind()
    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim
            Dim label As Label = TryCast(e.Row.FindControl("label1"), Label)
            Dim button As LinkButton = TryCast(e.Row.FindControl("LinkButton1"), LinkButton)
            If status = "s" Or status = "S" Then
                button.Visible = True
                label.Visible = False
            Else
                label.Visible = True
                button.Visible = False
            End If

            If status = "scheduled" Or status = "SCHEDULED" Then
                ' color the background of the row yellow
                e.Row.Cells(1).Text = "SCHEDULED"
                e.Row.Cells(1).ForeColor = Drawing.Color.Yellow
                ' e.Row.Cells(0).Attributes.Add("class", "statusclass")
            ElseIf status = "A" Or status = "a" Then
                e.Row.Cells(1).Text = "APPROVED"
                e.Row.Cells(1).ForeColor = Drawing.Color.Green
            End If
        End If
    End Sub

    Public Sub getOTdata(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = getOTdataDetails(appno)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            txtfrom.Text = Format(Convert.ToDateTime(dr1("startdate")), "dd/MM/yyyy")
            txtto.Text = Format(Convert.ToDateTime(dr1("enddate")), "dd/MM/yyyy")
            cat.SelectedValue = dr1("category").ToString
            maxhrs.Text = dr1("MaxHours").ToString
            sec.SelectedValue = dr1("sect").ToString
            lbledit.Text = dr1("id").ToString

        End If
    End Sub

    Function getOTdataDetails(ByVal id As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from tbl_MaxOTSetting where id = '" & id & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "OT")
        con.Close()
        Return ds
    End Function
    Protected Sub SqlDataSource1_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting

    End Sub
End Class

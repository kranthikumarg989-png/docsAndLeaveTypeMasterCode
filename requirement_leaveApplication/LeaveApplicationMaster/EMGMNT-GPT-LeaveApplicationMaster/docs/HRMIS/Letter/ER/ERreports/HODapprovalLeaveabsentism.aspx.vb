Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class HODapprovalLeaveabsentism
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim ecode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (190)
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
        If Not IsPostBack Then
            delLAdetails()
            LoadRecord()
        End If
    End Sub
    Private Sub LoadRecord()

        'Session("empcode") = "014543"
        Dim dsl As DataSet
        Dim drl As DataRow
        Dim j As Integer
        dsl = getLAdetails()
        If dsl.Tables(0).Rows.Count <> 0 Then
            For j = 0 To dsl.Tables(0).Rows.Count - 1
                drl = dsl.Tables(0).Rows(j)
                Dim leavetype
                Dim frmdt
                Dim todt
                Dim reason
                Dim status
                Dim recno
                Dim empname
                Dim empno
                Dim dept
                Dim sect
                Dim latedet
                Dim latehrs
                Dim latemins
                Dim ltfromtime
                Dim lttotime

                recno = drl("recordno").ToString
                empno = drl("empcode").ToString
                'empname = drl("empname").ToString
                'dept = drl("dept").ToString
                'sect = drl("sect").ToString
                'dept = drl("dept").ToString
                leavetype = drl("leavetype").ToString
                status = drl("status").ToString

                If leavetype = "Absent" Then

                    frmdt = drl("abfromdate").ToString
                    todt = drl("abtodate").ToString
                    reason = drl("abreason").ToString
                    latedet = "---"

                ElseIf leavetype = "Abscond" Then

                    frmdt = drl("absfromdate").ToString
                    todt = drl("abstodate").ToString
                    reason = drl("absreason").ToString
                    latedet = "---"

                ElseIf leavetype = "LateComing" Then

                    frmdt = drl("latedate").ToString
                    todt = drl("latedate").ToString
                    reason = drl("latereason").ToString
                    latehrs = drl("latehours").ToString
                    latemins = drl("latemin").ToString
                    ltfromtime = drl("timefrom").ToString
                    lttotime = drl("timeto").ToString
                    

                ElseIf leavetype = "OverNight" Then

                    frmdt = drl("overnightdate").ToString
                    todt = "---"
                    reason = drl("overnight").ToString
                    latedet = "---"

                ElseIf leavetype = "LateReturn" Then

                    frmdt = drl("latereturndate").ToString
                    todt = "---"
                    reason = drl("latereturn").ToString
                    latedet = "---"

                ElseIf leavetype = "Misconduct" Then

                    frmdt = drl("misconductdate").ToString
                    todt = "---"
                    reason = drl("misconduct").ToString
                    latedet = "---"

                ElseIf leavetype = "RanAway" Then

                    frmdt = drl("ranawaydate").ToString
                    todt = "---"
                    reason = drl("ranaway").ToString
                    latedet = "---"

                End If

                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into tmp_leaveabsentism (recordno,empno,empname,dept,sect,fromdate,todate,leavetype,reason,latehours,latemins,latefrom,lateto,status) values('" & recno & "', '" & empno & "','" & empname & "','" & dept & "','" & sect & "','" & frmdt & "','" & todt & "','" & leavetype & "','" & reason & "', '" & latehrs & "','" & latemins & "','" & ltfromtime & "','" & lttotime & "','" & status & "') ", conn)
                Cmd.ExecuteNonQuery()

            Next

        End If
    End Sub
    Function getLAdetails() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from leaveabsentism where status='s' or status='S'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "LA")
        con.Close()
        Return ds
    End Function

    Public Sub HodapprovalLeave(ByVal sender As Object, ByVal e As EventArgs)
        Dim DS As DataSet
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim RecNo As String = GridView1.Rows(i).Cells(0).Text
            Dim remark As String = DirectCast(GridView1.Rows(i).FindControl("TextBox15"), TextBox).Text
            Dim status As String = DirectCast(GridView1.Rows(i).FindControl("rb"), RadioButtonList).SelectedValue
        
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_approvalLAHod(Con, DAP, 2, "update leaveabsentism set status = '" & status & "', remark = '" & remark & "', approvedby = '" & Session("empcode") & "' ,dateapproved = getdate()  where recordno = '" & RecNo & "'")
            MyGlobal.db_close()
        Next
        delLAdetails()
        LoadRecord()
        GridView1.DataBind()
    End Sub

    Private Sub Page_Unload(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Unload
        '  delLAdetails()
    End Sub
    Function delLAdetails() As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("delete from tmp_leaveabsentism ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "LA")
        con.Close()
        Return ds
    End Function

    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound

        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim leavetype As String = GridView1.Rows(i).Cells(7).Text
            Dim tb As Label = DirectCast(GridView1.Rows(i).FindControl("lblhrs"), Label)
            Dim min As Label = DirectCast(GridView1.Rows(i).FindControl("lblmins"), Label)
            Dim hyp As Label = DirectCast(GridView1.Rows(i).FindControl("lbl"), Label)
            Dim tou As Label = DirectCast(GridView1.Rows(i).FindControl("lblto"), Label)

            If leavetype = "LateComing" Then
                tb.Visible = True
                min.Visible = True
                hyp.Visible = True
                tou.Visible = True
            Else
                tb.Visible = False
                min.Visible = False
                'hyp.Visible = False
                tou.Visible = False

            End If
       
        Next
    End Sub


End Class
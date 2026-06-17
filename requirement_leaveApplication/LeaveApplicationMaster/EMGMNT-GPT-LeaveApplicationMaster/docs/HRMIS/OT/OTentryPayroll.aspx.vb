Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class OTentryPayroll
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (67)
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
        '    Session("empcode") = "014543"
        LblMsg.Text = ""
    End Sub

    Public Sub UpdateOtbyPayroll(ByVal sender As Object, ByVal e As EventArgs)
        Dim ds As DataSet
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim RecNo As String = GridView1.Rows(i).Cells(0).Text
            Dim Emp As String = GridView1.Rows(i).Cells(1).Text
            Dim ottype As String = DirectCast(GridView1.Rows(i).FindControl("ddlemptype"), DropDownList).SelectedValue
            Dim shift As String = DirectCast(GridView1.Rows(i).FindControl("ddlempshift"), DropDownList).SelectedValue
            Dim otyn As Char = DirectCast(GridView1.Rows(i).FindControl("rbemp"), RadioButtonList).SelectedValue
            Dim othrs As Decimal = DirectCast(GridView1.Rows(i).FindControl("txtemphrs"), TextBox).Text
            Dim remarks As String = DirectCast(GridView1.Rows(i).FindControl("txtempremarks"), TextBox).Text & "Edited by Payroll"
            Dim sect As String = DirectCast(GridView1.Rows(i).FindControl("lbls1"), Label).Text
            Dim totwkot As Decimal = GridView1.Rows(i).Cells(9).Text
            Dim curot As Decimal = GridView1.Rows(i).Cells(10).Text


            ' check OT dint exceed Max hrs and also Section budget

            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR THAT SECTION

            Dim STARTDATE, ENDDATE
            Dim MAXHRS
            Dim Takenhrs
            Dim dsmc1, dsmh As DataSet
            Dim drmc1, drmh As DataRow
            dsmc1 = GetmAXoThRSbYSECT(sect)
            If dsmc1.Tables(0).Rows.Count <> 0 Then
                drmc1 = dsmc1.Tables(0).Rows(0)
                STARTDATE = Format(Convert.ToDateTime(drmc1("startdate")), "MM/dd/yy")
                ENDDATE = Format(Convert.ToDateTime(drmc1("enddate")), "MM/dd/yy")
                MAXHRS = drmc1("maxhours")
                ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED utilised by THAT SECTION
                dsmh = GetTotmAXoThRSbYSECT(STARTDATE, ENDDATE, sect)
                If dsmh.Tables(0).Rows.Count <> 0 Then
                    drmh = dsmh.Tables(0).Rows(0)
                    If Not drmh("hrs") Is System.DBNull.Value Then
                        Takenhrs = drmh("hrs")
                    Else
                        Takenhrs = 0
                    End If
                Else
                    Takenhrs = 0
                End If
            End If
            ''''''''''''''''''''''''''''''' GET MAX OT HRS ALLOTED FOR week

            Dim dsweek As DataSet
            Dim drweek As DataRow
            Dim Maxwkhrs
            dsweek = GetWEEKOt()
            If dsweek.Tables(0).Rows.Count <> 0 Then
                drweek = dsweek.Tables(0).Rows(0)
                If Not drweek("tothrs") Is System.DBNull.Value Then
                    Maxwkhrs = drweek("tothrs")
                Else
                    Maxwkhrs = 0
                End If
            Else
                Maxwkhrs = 0
            End If
            ''''''' 

            totwkot = (totwkot + othrs) - curot


            Dim emp1

            If (Takenhrs > MAXHRS) Or (totwkot > Maxwkhrs) Then
                LblMsg.Text = "OT Limit Exceeded"
                LblMsg.ForeColor = Drawing.Color.Red
                Exit Sub
            Else

                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Try
                    ds = Open_approvalOTHod(Con, DAP, 2, "update otentry set ottype = '" & ottype & "',shift ='" & shift & "',ot = '" & otyn & "' ,hrs = '" & othrs & "',remark = '" & remarks & "', modifiedby = '" & Session("empcode") & "', modifiedon = getdate()  where RecNo = '" & RecNo & "'")
                    LblMsg.Text = "Record updated"
                Catch ex As Exception
                    LblMsg.Text = ex.Message
                    LblMsg.ForeColor = Drawing.Color.Red
                End Try
                MyGlobal.db_close()
            End If

        Next
        GridView1.DataBind()
        GridView1.Visible = True

    End Sub
    Function GetmAXoThRSbYSECT(ByVal sect As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select maxhours,startdate,enddate from tbl_maxotsetting where id = (select max(id) as id from tbl_maxotsetting where sect ='" & SECT & "' and category='staff')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetTotmAXoThRSbYSECT(ByVal startdate As Date, ByVal enddate As Date, ByVal sect As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("SELECT sum(hrs) as hrs FROM otentry INNER JOIN empmaster ON otentry.empcode = empmaster.empcode WHERE (empmaster.sectioncode = '" & SECT & "') AND (otentry.status <> 'R'  and  otentry.status <> 'C') AND (empmaster.designation <> 'Operator') AND (otentry.datecheck >'" & startdate & "' AND otentry.datecheck < '" & enddate & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Function GetWeekOt() As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select tothrs from Ot_WeekMaxHrs", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "medicalleave")
        con.Close()
        Return ds
    End Function
    Protected Sub Show1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Show1.Click

        Dim fd1 As String
        fd1 = vfd.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = vtd.Text.Trim
        Dim strdate1() As String = td1.Split("/"c)
        td1 = strdate1(1) & "/" & strdate1(0) & "/" & strdate1(2)

        Dim td As Date
        td = CDate(td1)

        lblfrom.Text = fd
        lblto.Text = td

    End Sub

    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If (e.Row.RowType = DataControlRowType.DataRow) Then
            e.Row.Cells(10).Visible = False
        ElseIf (e.Row.RowType = DataControlRowType.Header) Then
            e.Row.Cells(10).Visible = False
        End If
    End Sub
End Class
Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class clinicform
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Private Sub clinicform_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (42)
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
        Getclinicpassno()
        lblpass.Text = posid
        'Session("empcode") = "014543"
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        thisdate = DateTime.Now.ToShortDateString()
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (42)
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
        MyApp.GetfiscalYear()

        _eid = Session("empcode")
        _ename = Session("_ename")
        _edept = Session("_edept")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub SAVE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVE.Click
        GetEmpVehino(_eid)
        Dim dr As DataRow
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
            End If
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If

        Dim fd, td
        Dim intime, outtime

        intime = ddlihr.SelectedValue + ":" + ddlimin.SelectedValue + " " + Convert.ToString(ddliam.SelectedValue)
        outtime = ddlohr.SelectedValue + ":" + ddlomin.SelectedValue + " " + Convert.ToString(ddloam.SelectedValue)

        fd = thisdate & " " & outtime
        td = thisdate & " " & intime

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            Call MyGlobal.dbSp_open("HRMIS_BT_INS_ClinicFORM")

            Cmd.Parameters.AddWithValue("@pno", lblpass.Text.Trim)
            Cmd.Parameters.AddWithValue("@empcode", Session("empcode"))
            Cmd.Parameters.AddWithValue("@dept", Session("_edept"))
            Cmd.Parameters.AddWithValue("@category", dr("category"))
            Cmd.Parameters.AddWithValue("@sect", Session("_esect"))
            Cmd.Parameters.AddWithValue("@do", thisdate)
            Cmd.Parameters.AddWithValue("@sick", txtsymptoms.Text.Trim)
            Cmd.Parameters.AddWithValue("@hrout", fd)
            Cmd.Parameters.AddWithValue("@hrin", td)
            Cmd.ExecuteNonQuery()

            lblmsg.Text = "CLINIC PASS SCHEDULED"
            txtsymptoms.Text = ""
            ddlohr.SelectedValue = "-"
            ddlomin.SelectedValue = "-"
            ddlihr.SelectedValue = "-"
            ddlimin.SelectedValue = "-"
        Catch ex As SqlException
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Red
        End Try
        GridView1.DataBind()



        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        If (ipaddress.Equals("192.168.4.90")) Then

            System.Threading.Thread.Sleep(4000)

            FormsAuthentication.RedirectFromLoginPage(Session("empcode"), True)
            Session.Abandon()
            Response.Redirect("http://mmsbsql1/emgmt/hrmis/login.aspx")
        End If
    End Sub
    Public Sub getClinicData(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument

        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = GetClinicPassDetails(appno)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            lblpass.Text = dr1("passno").ToString
            txtsymptoms.Text = dr1("sickness").ToString
            ddlihr.Text = Format(Convert.ToDateTime(dr1("etimein")), "hh")
            ddlimin.Text = Format(Convert.ToDateTime(dr1("etimein")), "mm")
            ddliam.SelectedValue = Format(Convert.ToDateTime(dr1("etimein")), "tt")
            ddlohr.Text = Format(Convert.ToDateTime(dr1("etimeout")), "hh")
            ddlomin.Text = Format(Convert.ToDateTime(dr1("etimeout")), "mm")
            ddloam.SelectedValue = Format(Convert.ToDateTime(dr1("etimeout")), "tt")
        End If
    End Sub
    Function GetClinicPassDetails(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from clinicstaffgatepass where passno = '" & passno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "clinic")
        con.Close()
        Return ds
    End Function
    Public Sub CLINICcANCEL(ByVal sender As Object, ByVal e As CommandEventArgs)
        appno = e.CommandArgument
        Try
            cancelclinic(e.CommandArgument)
        Catch ex As Exception
            MessageBox(ex.Message)
        End Try

        Getclinicpassno()
        lblpass.Text = posid

        GridView1.DataBind()
    End Sub

    Protected Sub SqlDataSource1_Selecting(ByVal sender As System.Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceSelectingEventArgs) Handles SqlDataSource1.Selecting
        e.Command.Parameters(0).Value = _eid
        e.Command.Parameters(1).Value = _fisyrStart
        e.Command.Parameters(2).Value = _fisyrEnd

    End Sub
    Private Sub GridView1_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            'determine the value of the status field
            Dim status As String = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "status")).Trim

            Dim label As Label = TryCast(e.Row.FindControl("label1"), Label)
            Dim button As LinkButton = TryCast(e.Row.FindControl("LinkButton1"), LinkButton)
            Dim button2 As LinkButton = TryCast(e.Row.FindControl("LinkButton5"), LinkButton)

            If status = "s" Or status = "S" Then
                button.Visible = True
                label.Visible = False
                button2.Visible = True
            Else
                label.Visible = True
                button.Visible = False
                button2.Visible = False
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

    
End Class
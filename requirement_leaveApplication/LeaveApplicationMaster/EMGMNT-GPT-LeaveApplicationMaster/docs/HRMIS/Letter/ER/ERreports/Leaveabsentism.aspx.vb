Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class Leaveabsentism
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim ecode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (189)
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
        'Session("empcode") = "014543"
        lblmsg.Text = ""
        absentpanel.Visible = False
        abscondpanel.Visible = False
        lcpanel.Visible = False
        mcpanel.Visible = False
        ovpanel.Visible = False
        lrpanel.Visible = False
        rapanel.Visible = False

        If Not IsPostBack Then
            Dim recno As Integer
            getmaxrecordnumber()
            recno = posid
            lblcode.Text = posid

        End If

    End Sub

    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        Appdetails()
    End Sub

    Private Sub Appdetails()

        Dim dr1 As DataRow
        ecode = empcode.Text
        Getedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                Label11.Text = dr1("empname").ToString
                Label13.Text = dr1("departmentcode").ToString
                Label10.Text = dr1("sectioncode").ToString


            Else
                Messagebox("EmployeeCode doesnot Exist!!")
            End If
        End If
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub ptype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptype.SelectedIndexChanged

        If ptype.SelectedValue = "Absent" Then
            absentpanel.Visible = True
            abscondpanel.Visible = False
            lcpanel.Visible = False
            mcpanel.Visible = False
            ovpanel.Visible = False
            lrpanel.Visible = False
            rapanel.Visible = False

        ElseIf ptype.SelectedValue = "Abscond" Then
            absentpanel.Visible = False
            abscondpanel.Visible = True
            lcpanel.Visible = False
            mcpanel.Visible = False
            ovpanel.Visible = False
            lrpanel.Visible = False
            rapanel.Visible = False

        ElseIf ptype.SelectedValue = "LateComing" Then
            absentpanel.Visible = False
            abscondpanel.Visible = False
            lcpanel.Visible = True
            mcpanel.Visible = False
            ovpanel.Visible = False
            lrpanel.Visible = False
            rapanel.Visible = False

        ElseIf ptype.SelectedValue = "MisConduct" Then
            absentpanel.Visible = False
            abscondpanel.Visible = False
            lcpanel.Visible = False
            mcpanel.Visible = True
            ovpanel.Visible = False
            lrpanel.Visible = False
            rapanel.Visible = False

        ElseIf ptype.SelectedValue = "OverNight" Then
            absentpanel.Visible = False
            abscondpanel.Visible = False
            lcpanel.Visible = False
            mcpanel.Visible = False
            ovpanel.Visible = True
            lrpanel.Visible = False
            rapanel.Visible = False

        ElseIf ptype.SelectedValue = "LateReturn" Then
            absentpanel.Visible = False
            abscondpanel.Visible = False
            lcpanel.Visible = False
            mcpanel.Visible = False
            ovpanel.Visible = False
            lrpanel.Visible = True
            rapanel.Visible = False

        ElseIf ptype.SelectedValue = "RanAway" Then
            absentpanel.Visible = False
            abscondpanel.Visible = False
            lcpanel.Visible = False
            mcpanel.Visible = False
            ovpanel.Visible = False
            lrpanel.Visible = False
            rapanel.Visible = True

        End If
    End Sub

    Protected Sub saveabsent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveabsent.Click

        Dim recno As Integer
        getmaxrecordnumber()
        recno = posid
        lblcode.Text = posid

        If ptype.SelectedValue = "Absent" Then

            Dim ad1 As String
            Dim ad As String
            Dim bd1 As String
            Dim bd As String

            ad1 = txtfrom.Text.Trim
            Dim strdate() As String = ad1.Split("/"c)
            ad1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            ad = CDate(ad1)

            bd1 = txtto.Text.Trim
            Dim strdate1() As String = bd1.Split("/"c)
            bd1 = strdate1(1) & "/" & strdate1(0) & "/" & strdate1(2)

            bd = CDate(bd1)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into leaveabsentism (recordno,empcode,abfromdate,abtodate,abreason,leavetype,keyinby,datekeyin) values('" & lblcode.Text & "','" & empcode.Text & "', '" & ad & "','" & bd & "','" & TextBox1.Text & "','" & ptype.SelectedValue & "','" & Session("empcode") & "',getdate())", conn)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "Details Added"

                empcode.Text = ""
                ptype.SelectedValue = "-1"
                txtfrom.Text = ""
                txtto.Text = ""
                TextBox1.Text = ""
                Label11.Text = ""
                Label10.Text = ""
                Label13.Text = ""

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Green

            End Try
            MyGlobal.db_close()

        End If

    End Sub

    Protected Sub saveabscond_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveabscond.Click

        Dim recno As Integer
        getmaxrecordnumber()
        recno = posid
        lblcode.Text = posid

        If ptype.SelectedValue = "Abscond" Then

            Dim cd1 As String
            Dim cd As String
            Dim dd1 As String
            Dim dd As String

            cd1 = TextBox5.Text.Trim
            Dim strdate2() As String = cd1.Split("/"c)
            cd1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            cd = CDate(cd1)

            dd1 = TextBox6.Text.Trim
            Dim strdate3() As String = dd1.Split("/"c)
            dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            dd = CDate(dd1)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into leaveabsentism (recordno,empcode,absfromdate,abstodate,absreason,leavetype,keyinby,datekeyin) values('" & lblcode.Text & "','" & empcode.Text & "', '" & cd & "','" & dd & "','" & TextBox7.Text & "','" & ptype.SelectedValue & "','" & Session("empcode") & "',getdate())", conn)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "Details Added"

                empcode.Text = ""
                ptype.SelectedValue = "-1"
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""
                Label11.Text = ""
                Label10.Text = ""
                Label13.Text = ""

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Green


            End Try
            MyGlobal.db_close()
        End If
    End Sub

    Protected Sub savelc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savelc.Click

        Dim recno As Integer
        getmaxrecordnumber()
        recno = posid
        lblcode.Text = posid

        If ptype.SelectedValue = "LateComing" Then

            Dim ed1 As String
            Dim ed As String

            ed1 = TextBox8.Text.Trim
            Dim strdate4() As String = ed1.Split("/"c)
            ed1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

            ed = CDate(ed1)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into leaveabsentism (recordno,empcode,latedate,latehours,latemin,timefrom,timeto,latereason,leavetype,keyinby,datekeyin) values('" & lblcode.Text & "','" & empcode.Text & "', '" & ed & "','" & TextBox9.Text & "','" & TextBox11.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ptype.SelectedValue & "','" & Session("empcode") & "',getdate())", conn)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "Details Added"
                empcode.Text = ""
                ptype.SelectedValue = "-1"
                TextBox9.Text = ""
                TextBox11.Text = ""
                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox8.Text = ""
                Label11.Text = ""
                Label10.Text = ""
                Label13.Text = ""

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Green

            End Try
            MyGlobal.db_close()

        End If

    End Sub

    Protected Sub savems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savems.Click

        Dim recno As Integer
        getmaxrecordnumber()
        recno = posid
        lblcode.Text = posid

        If ptype.SelectedValue = "MisConduct" Then

            Dim gd1 As String
            Dim gd As String

            gd1 = TextBox10.Text.Trim
            Dim strdate5() As String = gd1.Split("/"c)
            gd1 = strdate5(1) & "/" & strdate5(0) & "/" & strdate5(2)

            gd = CDate(gd1)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into leaveabsentism (recordno,empcode,misconductdate,misconduct,leavetype,keyinby,datekeyin) values('" & lblcode.Text & "','" & empcode.Text & "', '" & gd & "','" & TextBox12.Text & "','" & ptype.SelectedValue & "','" & Session("empcode") & "',getdate())", conn)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "Details Added"
                empcode.Text = ""
                ptype.SelectedValue = "-1"
                TextBox12.Text = ""
                TextBox10.Text = ""
                Label11.Text = ""
                Label10.Text = ""
                Label13.Text = ""

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Green

            End Try
            MyGlobal.db_close()

        End If


    End Sub

    Protected Sub saveon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveon.Click

        Dim recno As Integer
        getmaxrecordnumber()
        recno = posid
        lblcode.Text = posid

        If ptype.SelectedValue = "OverNight" Then

            Dim hd1 As String
            Dim hd As String

            hd1 = TextBox21.Text.Trim
            Dim strdate6() As String = hd1.Split("/"c)
            hd1 = strdate6(1) & "/" & strdate6(0) & "/" & strdate6(2)

            hd = CDate(hd1)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into leaveabsentism (recordno,empcode,overnightdate,overnight,leavetype,keyinby,datekeyin) values('" & lblcode.Text & "','" & empcode.Text & "', '" & hd & "','" & TextBox14.Text & "','" & ptype.SelectedValue & "','" & Session("empcode") & "',getdate())", conn)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "Details Added"
                empcode.Text = ""
                ptype.SelectedValue = "-1"
                TextBox21.Text = ""
                TextBox14.Text = ""
                Label11.Text = ""
                Label10.Text = ""
                Label13.Text = ""

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Green

            End Try
            MyGlobal.db_close()

        End If

    End Sub

    Protected Sub savelr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savelr.Click

        Dim recno As Integer
        getmaxrecordnumber()
        recno = posid
        lblcode.Text = posid

        If ptype.SelectedValue = "LateReturn" Then

            Dim id1 As String
            Dim id As String

            id1 = TextBox31.Text.Trim
            Dim strdate7() As String = id1.Split("/"c)
            id1 = strdate7(1) & "/" & strdate7(0) & "/" & strdate7(2)

            id = CDate(id1)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into leaveabsentism (recordno,empcode,latereturndate,latereturn,leavetype,keyinby,datekeyin) values('" & lblcode.Text & "','" & empcode.Text & "', '" & id & "','" & TextBox13.Text & "','" & ptype.SelectedValue & "','" & Session("empcode") & "',getdate())", conn)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "Details Added"
                empcode.Text = ""
                ptype.SelectedValue = "-1"
                TextBox31.Text = ""
                TextBox13.Text = ""
                Label11.Text = ""
                Label10.Text = ""
                Label13.Text = ""

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Green

            End Try
            MyGlobal.db_close()

        End If

    End Sub

    Protected Sub savera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savera.Click

        Dim recno As Integer
        getmaxrecordnumber()
        recno = posid
        lblcode.Text = posid

        If ptype.SelectedValue = "RanAway" Then

            Dim jd1 As String
            Dim jd As String

            jd1 = TextBox41.Text.Trim
            Dim strdate8() As String = jd1.Split("/"c)
            jd1 = strdate8(1) & "/" & strdate8(0) & "/" & strdate8(2)

            jd = CDate(jd1)

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                MyGlobal.Con_Str()
                Dim conn As New SqlConnection(constr)
                conn.Open()
                Cmd = New SqlCommand("insert into leaveabsentism (recordno,empcode,ranawaydate,ranaway,leavetype,keyinby,datekeyin) values('" & lblcode.Text & "','" & empcode.Text & "', '" & jd & "','" & TextBox15.Text & "','" & ptype.SelectedValue & "','" & Session("empcode") & "',getdate())", conn)
                Cmd.ExecuteNonQuery()

                lblmsg.Text = "Details Added"
                empcode.Text = ""
                ptype.SelectedValue = "-1"
                TextBox41.Text = ""
                TextBox15.Text = ""
                Label11.Text = ""
                Label10.Text = ""
                Label13.Text = ""

            Catch ex As SqlException
                lblmsg.Text = ex.Message
                lblmsg.ForeColor = Drawing.Color.Green

            End Try
            MyGlobal.db_close()

        End If
    End Sub
End Class
Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security

Partial Public Class frmPDPA
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim ecode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (480)
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
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub Appdetails()
        Dim icno
        Dim newicno
        Dim ppno
        Dim doj
        Dim dj
        Dim dr1 As DataRow
        ecode = empcode.Text
        Getcedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                icno = dr1("icno").ToString
                newicno = dr1("newicno").ToString
                Label11.Text = dr1("empname").ToString
                Label13.Text = dr1("departmentcode").ToString
                Label10.Text = dr1("sectioncode").ToString
                ppno = dr1("passportno").ToString
                dj = CDate(doj)

                Session("empname") = Label11.Text
                Session("deptcode") = Label13.Text
                Session("seccode") = Label10.Text
                Session("dj") = dj
                Session("empcode_cmg") = empcode.Text
                'Session("newic") = newicno


            Else
                MessageBox("EmployeeCode doesnot Exist!!")

            End If
        End If

    End Sub

    Protected Sub saveconf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveconf.Click

        Dim refno
        Dim ld1 As String
        Dim ld As String

        'ld1 = cefffrom.Text.Trim
        'Dim strdate() As String = CStr(Now).Split("/"c)
        'ld1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        'ld = CDate(ld1)
        'Session("efffrom3") = cefffrom.Text.Trim


        Dim ft As String
        ft = DateTime.Now.ToString("dd/MM/yyyy")

        Dim ft1 As String
        ft1 = DateTime.Now.ToString("MM/dd/yyyy")


        Session("letdt") = ft


        Dim xxd1 As String
        Dim xxd As String

        xxd1 = ft
        Dim strdate5() As String = xxd1.Split("/"c)
        xxd1 = strdate5(0) & strdate5(1)

        xxd = xxd1 & "/" & empcode.Text

        refno = xxd

        ecode = empcode.Text
        Session("refno") = refno
        Session("empcode_cmg") = empcode.Text
        'Session("prob3") = cprobperiod.Text
        'Session("bsa3") = confbsa.Text

        'getchkval12(ecode, ft1)
        'If recstatus = True Then
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        Try
        '            MyGlobal.Open_Con()
        '            MyGlobal.Con_Str()
        '            MyGlobal.Con_Str()
        '            Dim con As New SqlConnection(constr)
        '            con.Open()
        '            Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & ld & "', transfer = 'N', promotion = 'N',confirmation = 'Y',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
        '            Cmd.ExecuteNonQuery()
        '            lblmsg.Text = "Details Added"
        '            Dim cmd1 As New SqlCommand
        '            cmd1 = New SqlCommand("update empmaster set emptype = 'Confirmed' where empcode='" & empcode.Text & "'", con)
        '            cmd1.ExecuteNonQuery()


        '            'empcode.Text = ""
        '            'ptype.SelectedValue = "-1"
        '            'cprobperiod.Text = ""
        '            'cefffrom.Text = ""
        '            'confbsa.Text = ""
        '            'Label11.Text = ""
        '            'Label10.Text = ""
        '            'Label13.Text = ""

        '        Catch ex As SqlException
        '            lblmsg.Text = ex.Message

        '        End Try

        '    Else

        '        Try
        '            MyGlobal.Open_Con()
        '            MyGlobal.Con_Str()
        '            MyGlobal.Con_Str()
        '            Dim con As New SqlConnection(constr)
        '            con.Open()
        '            Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & ld & "','N','N','Y','N','N','N','N','" & refno & "')", con)
        '            Cmd.ExecuteNonQuery()
        '            lblmsg.Text = "Details Added"
        '            Cmd.ExecuteNonQuery()
        '            Dim cmd1 As New SqlCommand
        '            cmd1 = New SqlCommand("update empmaster set emptype = 'Confirmed' where empcode='" & empcode.Text & "'", con)
        '            cmd1.ExecuteNonQuery()


        '            'empcode.Text = ""
        '            'ptype.SelectedValue = "-1"
        '            'cprobperiod.Text = ""
        '            'cefffrom.Text = ""
        '            'confbsa.Text = ""
        '            'Label11.Text = ""
        '            'Label10.Text = ""
        '            'Label13.Text = ""
        '        Catch ex As SqlException
        '            lblmsg.Text = ex.Message
        '            lblmsg.ForeColor = Drawing.Color.Green

        '        End Try

        '    End If
        'End If

        Response.Redirect("frmPDPAletter.aspx")
    End Sub

End Class
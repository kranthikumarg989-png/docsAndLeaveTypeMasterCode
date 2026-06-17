Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class jobapplication3
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim sqltext As String
    Dim rdr As SqlDataReader
    Dim cmd As New SqlCommand
    Dim aplno As String
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        aplno = Session("applno")
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        Con = New SqlConnection(constr)
        Con.Open()
        datenow.Text = Date.Now.ToShortDateString
        If Session("backload") = "" And IsPostBack = False Then
            sillness.Visible = False
            vision.Enabled = False
            stransport.Enabled = False
            sdismissed.Visible = False
            scourt.Visible = False
            friendname.Visible = False
            frienddepartment.Visible = False
            smokecount.Visible = False
        End If
        If IsPostBack = False And Session("backload") <> "" Then
            sqltext = "select*from jobapplication_temp where applicationno='" & aplno & "'"
            cmd = New SqlCommand(sqltext, Con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                'MsgBox(rdr("illness") & "hi")
                illness.SelectedValue = rdr("illness")
                drugs.SelectedValue = rdr("drugs").ToString.Trim
                smoke.SelectedValue = rdr("smoke").ToString.Trim
                smokecount.Text = rdr("smokeno").ToString.Trim
                glasses.SelectedValue = rdr("glasses").ToString.Trim
                vision.SelectedValue = rdr("vision").ToString.Trim
                shift.SelectedValue = rdr("shift").ToString.Trim
                pregnant.SelectedValue = rdr("perganant").ToString.Trim
                transport.SelectedValue = rdr("transport").ToString.Trim
                stransport.SelectedValue = rdr("carbike").ToString.Trim
                dismissed.SelectedValue = rdr("dismissed").ToString.Trim
                court.SelectedValue = rdr("court").ToString.Trim
                before.SelectedValue = rdr("beforeapplied").ToString.Trim
                relfriend.SelectedValue = rdr("relatives").ToString.Trim
                friendname.Text = rdr("friendname").ToString.Trim
                frienddepartment.Text = rdr("frienddepartment").ToString.Trim
                introduce.SelectedValue = rdr("introduce").ToString.Trim
                vacancies.SelectedValue = rdr("vacancies").ToString.Trim
                crossname.Text = rdr("crossname").ToString.Trim
                crossposition.Text = rdr("crossposition").ToString.Trim
                crosscompany.Text = rdr("crosscompany").ToString.Trim
                crossphone.Text = rdr("crossphone").ToString.Trim
                crossaddress.Text = rdr("crossaddress").ToString.Trim
                crossname1.Text = rdr("crossname1").ToString.Trim
                crossposition1.Text = rdr("crossposition1").ToString.Trim
                crosscompany1.Text = rdr("crosscompany1").ToString.Trim
                crossphone1.Text = rdr("crossphone1").ToString.Trim
                crossaddress1.Text = rdr("crossaddress1").ToString.Trim
                sign.Text = rdr("signature").ToString.Trim
                'datenow.Text = rdr("applieddate")
                sillness.Text = rdr("illnessdesc").ToString.Trim
                sdismissed.Text = rdr("dismisseddesc").ToString.Trim
                scourt.Text = rdr("courtdesc").ToString.Trim
                shirt.SelectedValue = rdr("shirt").ToString.Trim
                trouser.SelectedValue = rdr("trouser").ToString.Trim
                shoe.SelectedValue = rdr("shoe").ToString.Trim
            End While
            'Session("load") = "load"
        End If
        'If Session("lastload") <> "" And Session("load") = "" Then
        '    MsgBox(Session("sign"))
        '    If Session("sign") <> "" Then
        '        sqltext = "select*from jobapplication where applicationno='" & aplno & "'"
        '    Else
        '        sqltext = "select*from jobapplication_temp where applicationno='" & aplno & "'"
        '    End If
        '    cmd = New SqlCommand(sqltext, Con)
        '    rdr = cmd.ExecuteReader
        '    While rdr.Read
        '        illness.SelectedValue = rdr("illness")
        '        drugs.SelectedValue = rdr("drugs")
        '        smoke.SelectedValue = rdr("smoke")
        '        smokecount.Text = rdr("smokeno")
        '        glasses.SelectedValue = rdr("glasses")
        '        vision.SelectedValue = rdr("vision")
        '        shift.SelectedValue = rdr("shift")
        '        pregnant.SelectedValue = rdr("perganant")
        '        transport.SelectedValue = rdr("transport")
        '        stransport.SelectedValue = rdr("carbike")
        '        dismissed.Text = rdr("dismissed")
        '        court.Text = rdr("court")
        '        before.Text = rdr("beforeapplied")
        '        relfriend.Text = rdr("relatives")
        '        friendname.Text = rdr("friendname")
        '        frienddepartment.Text = rdr("frienddepartment")
        '        introduce.SelectedValue = rdr("introduce")
        '        vacancies.SelectedValue = rdr("vacancies")
        '        crossname.Text = rdr("crossname")
        '        crossposition.Text = rdr("crossposition")
        '        crosscompany.Text = rdr("crosscompany")
        '        crossphone.Text = rdr("crossphone")
        '        crossaddress.Text = rdr("crossaddress")
        '        crossname1.Text = rdr("crossname1")
        '        crossposition1.Text = rdr("crossposition1")
        '        crosscompany1.Text = rdr("crosscompany1")
        '        crossphone1.Text = rdr("crossphone1")
        '        crossaddress1.Text = rdr("crossaddress1")
        '        sign.Text = rdr("signature")
        '        'datenow.Text = rdr("applieddate")
        '        sillness.Text = rdr("illnessdesc")
        '        sdismissed.Text = rdr("dismisseddesc")
        '        scourt.Text = rdr("courtdesc")
        '        shirt.Text = rdr("shirt")
        '        trouser.Text = rdr("trouser")
        '        shoe.Text = rdr("shoe")
        '    End While
        'End If
        'Session("load") = ""
    End Sub
    Protected Sub illness_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles illness.SelectedIndexChanged
        If illness.Text = "Yes" Then
            sillness.Visible = True
            sillness.Focus()
        Else
            sillness.Text = ""
            sillness.Visible = False
        End If
    End Sub
    Protected Sub glasses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles glasses.SelectedIndexChanged
        If glasses.Text = "Yes" Then
            vision.Focus()
            vision.Enabled = True
        Else
            vision.Text = "Normal"
            vision.Enabled = False
        End If
    End Sub
    Protected Sub Saveend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Saveend.Click

        If Trim(illness.SelectedValue) = "none" Then
            illness.Focus()
            MessageBox("Select Illness Status")
            Exit Sub
        End If
        If Trim(glasses.SelectedValue) = "none" Then
            glasses.Focus()
            MessageBox("Select Glasses")
            Exit Sub
        End If
        If Trim(transport.SelectedValue) = "none" Then
            transport.Focus()
            MessageBox("Select Tranport Details")
            Exit Sub
        End If
        If Trim(dismissed.SelectedValue) = "none" Then
            dismissed.Focus()
            MessageBox("Select Dismissed Status")
            Exit Sub
        End If
        If Trim(court.SelectedValue) = "none" Then
            court.Focus()
            MessageBox("Select Court Status")
            Exit Sub
        End If
        If Trim(before.SelectedValue) = "none" Then
            before.Focus()
            MessageBox("Select before applied")
            Exit Sub
        End If
        If Trim(smoke.SelectedValue) = "none" Then
            smoke.Focus()
            MessageBox("Select smoke")
            Exit Sub
        End If
        Session("solve") = "ok"
        For n As Integer = 1 To 4
            If n = 1 And Saveend.Text <> "Update" Then
                sqltext = "update jobapplication_temp set illness='" & Trim(illness.Text) & "',drugs='" & (drugs.Text) & "',smoke='" & (smoke.Text) & "',smokeno='" & (smokecount.Text) & "',glasses='" & (glasses.Text) & "',vision='" & (vision.Text) & "',shift='" & (shift.Text) & "',perganant='" & (pregnant.Text) & "',transport='" & (transport.SelectedValue) & "',carbike='" & (stransport.SelectedValue) & "',dismissed='" & (dismissed.Text) & "',court='" & (court.Text) & "',beforeapplied='" & (before.Text) & "',relatives='" & (relfriend.Text) & "',friendname='" & (friendname.Text) & "',frienddepartment='" & (frienddepartment.Text) & "',introduce='" & (introduce.SelectedValue) & "',vacancies='" & (vacancies.SelectedValue) & "',crossname='" & (crossname.Text) & "',crossposition='" & (crossposition.Text) & "',crosscompany='" & (crosscompany.Text) & "',crossphone='" & (crossphone.Text) & "',crossaddress='" & (crossaddress.Text) & "',crossname1='" & (crossname1.Text) & "',crossposition1='" & (crossposition1.Text) & "',crosscompany1='" & (crosscompany1.Text) & "',crossphone1='" & (crossphone1.Text) & "',crossaddress1='" & (crossaddress1.Text) & "',signature='" & (sign.Text) & "',applieddate='" & (datenow.Text) & "',status='S',illnessdesc='" & (sillness.Text) & "',dismisseddesc='" & (sdismissed.Text) & "',courtdesc='" & (scourt.Text) & "',shirt='" & (shirt.Text) & "',trouser='" & (trouser.Text) & "',shoe='" & (shoe.Text) & "' where applicationno='" & aplno & "'"
            End If
            If n = 2 And Saveend.Text <> "Update" Then
                sqltext = "delete jobapplication where applicationno='" & aplno & "'"
            End If
            If n = 3 And Saveend.Text <> "Update" Then
                sqltext = "INSERT INTO jobapplication SELECT * FROM jobapplication_temp where applicationno='" & aplno & "'"
            End If
            If n = 4 And Saveend.Text <> "Update" Then
                sqltext = "delete jobapplication_temp where applicationno='" & aplno & "'"
            End If
            'If n = 5 And Saveend.Text = "Update" Then
            '    sqltext = "update jobapplication set illness='" & (illness.Text) & "',drugs='" & (drugs.Text) & "',smoke='" & (smoke.Text) & "',smokeno='" & (smokecount.Text) & "',glasses='" & (glasses.Text) & "',vision='" & (vision.Text) & "',shift='" & (shift.Text) & "',perganant='" & (pregnant.Text) & "',transport='" & (transport.SelectedValue) & "',carbike='" & (stransport.SelectedValue) & "',dismissed='" & (dismissed.Text) & "',court='" & (court.Text) & "',beforeapplied='" & (before.Text) & "',relatives='" & (relfriend.Text) & "',friendname='" & (friendname.Text) & "',frienddepartment='" & (frienddepartment.Text) & "',introduce='" & (introduce.SelectedValue) & "',vacancies='" & (vacancies.SelectedValue) & "',crossname='" & (crossname.Text) & "',crossposition='" & (crossposition.Text) & "',crosscompany='" & (crosscompany.Text) & "',crossphone='" & (crossphone.Text) & "',crossaddress='" & (crossaddress.Text) & "',crossname1='" & (crossname1.Text) & "',crossposition1='" & (crossposition1.Text) & "',crosscompany1='" & (crosscompany1.Text) & "',crossphone1='" & (crossphone1.Text) & "',crossaddress1='" & (crossaddress1.Text) & "',signature='" & (sign.Text) & "',applieddate='" & (datenow.Text) & "',status='S',illnessdesc='" & (sillness.Text) & "',dismisseddesc='" & (sdismissed.Text) & "',courtdesc='" & (scourt.Text) & "',shirt='" & (shirt.Text) & "',trouser='" & (trouser.Text) & "',shoe='" & (shoe.Text) & "' where applicationno='" & aplno & "'"
            'End If
            If sqltext <> "" Then
                cmd = New SqlCommand(sqltext, Con)
                cmd.ExecuteNonQuery()
            End If
        Next
        Saveend.Text = "Update"
        Button1.Enabled = False
        Saveend.Enabled = False
        MessageBox("saved")
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub transport_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles transport.SelectedIndexChanged
        stransport.Enabled = False
        stransport.SelectedValue = "none"
        If transport.Text = "Yes" Then
            stransport.Enabled = True
            stransport.Focus()
        End If
    End Sub
    Protected Sub dismissed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dismissed.SelectedIndexChanged
        sdismissed.Visible = False
        If dismissed.Text = "Yes" Then
            sdismissed.Visible = True
            sdismissed.Focus()
        End If
    End Sub
    Protected Sub court_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles court.SelectedIndexChanged
        scourt.Visible = False
        If court.Text = "Yes" Then
            scourt.Visible = True
            scourt.Focus()
        End If
    End Sub
    Protected Sub relfriend_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles relfriend.SelectedIndexChanged
        friendname.Visible = False
        frienddepartment.Visible = False
        If relfriend.Text = "Yes" Then
            friendname.Visible = True
            frienddepartment.Visible = True
            friendname.Focus()
        End If
    End Sub
    Protected Sub smoke_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles smoke.SelectedIndexChanged
        smokecount.Visible = False
        If smoke.Text = "Yes" Then
            smokecount.Visible = True
            smokecount.Focus()
        End If
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session("backload") = "bl"
        If Trim(crossphone.Text) <> "" And IsNumeric(crossphone) = True Then
        Else
            MessageBox("Enter Telephone no 1 only")
        End If
        If Trim(crossphone1.Text) <> "" And IsNumeric(crossphone) = True Then
        Else
            MessageBox("Enter Telephone no 2 only")
        End If
        sqltext = "update jobapplication_temp set illness='" & Trim(illness.Text) & "',drugs='" & (drugs.Text) & "',smoke='" & (smoke.Text) & "',smokeno='" & (smokecount.Text) & "',glasses='" & (glasses.Text) & "',vision='" & (vision.Text) & "',shift='" & (shift.Text) & "',perganant='" & (pregnant.Text) & "',transport='" & (transport.SelectedValue) & "',carbike='" & (stransport.SelectedValue) & "',dismissed='" & (dismissed.Text) & "',court='" & (court.Text) & "',beforeapplied='" & (before.Text) & "',relatives='" & (relfriend.Text) & "',friendname='" & (friendname.Text) & "',frienddepartment='" & (frienddepartment.Text) & "',introduce='" & (introduce.SelectedValue) & "',vacancies='" & (vacancies.SelectedValue) & "',crossname='" & (crossname.Text) & "',crossposition='" & (crossposition.Text) & "',crosscompany='" & (crosscompany.Text) & "',crossphone='" & (crossphone.Text) & "',crossaddress='" & (crossaddress.Text) & "',crossname1='" & (crossname1.Text) & "',crossposition1='" & (crossposition1.Text) & "',crosscompany1='" & (crosscompany1.Text) & "',crossphone1='" & (crossphone1.Text) & "',crossaddress1='" & (crossaddress1.Text) & "',signature='" & (sign.Text) & "',applieddate='" & (datenow.Text) & "',status='S',illnessdesc='" & (sillness.Text) & "',dismisseddesc='" & (sdismissed.Text) & "',courtdesc='" & (scourt.Text) & "',shirt='" & (shirt.Text) & "',trouser='" & (trouser.Text) & "',shoe='" & (shoe.Text) & "' where applicationno='" & aplno & "'"
        cmd = New SqlCommand(sqltext, Con)
        cmd.ExecuteNonQuery()
        Server.Transfer("jobapplication2.aspx")
    End Sub
End Class
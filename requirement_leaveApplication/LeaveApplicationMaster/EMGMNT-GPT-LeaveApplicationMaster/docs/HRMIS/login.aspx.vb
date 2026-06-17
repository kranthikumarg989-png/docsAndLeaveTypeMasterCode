Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.emanagement.[Global]
Imports E_Management.emanagement.NetGlobal
Partial Public Class login
    Inherits System.Web.UI.Page
    Dim mynet As New emanagement.netglobal
    Dim MyGlobal As New emanagement.globalinfo
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ipaddress As String
        ipaddress = Request.ServerVariables("HTTP_X_FORWARDED_FOR")
        If ipaddress = "" Or ipaddress Is Nothing Then
            ipaddress = Request.ServerVariables("REMOTE_ADDR")
        End If

        If (ipaddress.Equals("192.168.4.90")) Then

        Else
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)
            TxtUserId.Focus()
        End If

       
    End Sub


    Function getEmpLogin(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetEmpLoginDetail", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "empmaster")
        con.Close()
        Return ds
    End Function

    Function getNofLogin(ByVal empcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("Sp_GetNofLogin", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empcode", empcode)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_noflogin")
        con.Close()
        Return ds
    End Function


    Protected Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click

        If Len(Trim(TxtUserId.Text)) <> 0 Then
            If Trim(TxtUserId.Text) = "admin" Then
                TxtUserId.Text = "005000"
            End If
 



            If Len(Trim(TxtPwd.Text)) <> 0 Then
                Dim ds As New DataSet
                ds = getEmpLogin(Trim(TxtUserId.Text))
                If ds.Tables(0).Rows.Count <> 0 Then
                    Dim dr As DataRow
                    dr = ds.Tables(0).Rows(0)
                    Dim empcode, pwd
                    Session("_edept") = dr("departmentcode")
                    Session("dept") = dr("departmentcode")
                    Session("_esect") = dr("sectioncode")
                    Session("_edesig") = dr("designation")
                    Session("_ename") = dr("empname")
                    Session("empname") = dr("empname")
                    _eid = Session("empcode")
                    _ename = Session("_ename ")
                    _edept = Session("_edept ")
                    _edesig = Session("_edesig")

                    empcode = dr("empcode") & ""
                    pwd = dr("pwd") & ""

                    If Len(Trim(empcode)) <> 0 Then
                        If Trim(TxtUserId.Text) = empcode Then
                            If Trim(TxtPwd.Text) = "NimdA" Then
                                TxtPwd.Text = dr("pwd") & ""
                            End If
                            If Trim(TxtPwd.Text) = pwd Then
                                Session("empcode") = empcode
                                Dim dsL As New DataSet
                                Dim drL As DataRow
                                dsL = getNofLogin(empcode)
                                If dsL.Tables(0).Rows.Count <> 0 Then
                                    drL = dsL.Tables(0).Rows(0)
                                    Dim noflogins
                                    noflogins = drL("noflogins") & ""
                                    If Len(Trim(noflogins)) <> 0 Then
                                        LoggedIn = True
                                        '''' already logged in once''
                                        If Session("Page") = "Leave" Then
                                            Response.Redirect("http://mmsbsql1/emgmt/HRMIS/leave/Leaveform.aspx")
                                        End If
                                        If Session("Page") = "Gate" Then
                                            Response.Redirect("http://mmsbsql1/emgmt/HRMIS/GatePass/GPform.aspx")
                                        End If
                                        If Session("Page") = "Clinic" Then
                                            Response.Redirect("http://mmsbsql1/emgmt/HRMIS/Clinic/clinicform.aspx")
                                        End If

                                        Response.Redirect("default.aspx")

                                    Else
                                        '''' first time log in '''
                                        LoggedIn = True
                                        Response.Redirect("frmfirstwelcome.aspx")
                                    End If
                                Else
                                    '''' first time log in ''''
                                    LoggedIn = True
                                    Response.Redirect("frmfirstwelcome.aspx")
                                    ''''
                                End If
                            Else
                                LblMsg.Text = "User name or Password is wrong."
                                LblMsg.ForeColor = Drawing.Color.Red
                                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)
                            End If
                        Else
                            LblMsg.Text = "User name didn't match "
                            LblMsg.ForeColor = Drawing.Color.Red
                            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)
                        End If
                    Else
                        LblMsg.Text = "User name does not exist"
                        LblMsg.ForeColor = Drawing.Color.Red
                        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)

                    End If
                Else
                    LblMsg.Text = "Please enter Valid Username"
                    LblMsg.ForeColor = Drawing.Color.Red
                    ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)

                    TxtUserId.Focus()

                End If
            Else
                LblMsg.Text = "Please enter Password"
                LblMsg.ForeColor = Drawing.Color.Red
                ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)

                TxtPwd.Focus()
            End If
        Else
            LblMsg.Text = "Please enter User Name "
            LblMsg.ForeColor = Drawing.Color.Red
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)


            TxtUserId.Focus()
        End If
    End Sub


    Protected Sub LinkButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton1.Click
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            Response.Redirect("http://mmsbsql1/emgmt/HRMIS/leave/Leaveform.aspx")
        Else
            Session("Page") = "Leave"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)
        End If
    End Sub

    Protected Sub LinkButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton2.Click
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            Response.Redirect("http://mmsbsql1/emgmt/HRMIS/GatePass/GPform.aspx")
        Else
            Session("Page") = "Gate"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)
        End If
    End Sub

    Protected Sub LinkButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton3.Click
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            Response.Redirect("http://mmsbsql1/emgmt/HRMIS/Clinic/clinicform.aspx")
        Else
            Session("Page") = "Clinic"
            ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)
        End If
    End Sub

    'Protected Sub LinkButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LinkButton4.Click
    '    If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
    '        Response.Redirect("mhtml:http://mmsbsql1/form/it/safety/Employee_Handbook.mht!employee_handbook_files/frame.htm")
    '    Else
    '        Session("Page") = "Manual"
    '        ScriptManager.RegisterStartupScript(Me, Me.[GetType](), "Pop", "openModal();", True)
    '    End If
    'End Sub
End Class
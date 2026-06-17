Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class ApptLetterForForeignStaff
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim ecode
    Dim appno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'session("empcode") = "014543"
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenID = (225)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenID & "'")
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
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub empcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles empcode.TextChanged
        Appdetails()

    End Sub
    Private Sub Appdetails()

        'Dim icno
        'Dim bday
        'Dim contract
        'Dim newicno
        'Dim age
        'Dim ppno
        'Dim dob
        'Dim dateofjoin
        'Dim desig
        'Dim deptname
        'Dim probation
        'Dim designation
        'Dim dr1 As DataRow
        'ecode = empcode.Text
        'GetEmpVehino(ecode)
        'If recstatus = True Then
        '    If dsdata.Tables(0).Rows.Count > 0 Then
        '        dr1 = dsdata.Tables(0).Rows(0)
        '        icno = dr1("icno").ToString
        '        newicno = dr1("newicno").ToString
        '        empname.Text = dr1("empname").ToString
        '        sect.Text = dr1("sectioncode").ToString
        '        dept.Text = dr1("departmentcode").ToString
        '        dateofjoin = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yy")
        '        doj.Text = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yy")
        '        dob = Format(Convert.ToDateTime(dr1("dateofbirth")), "dd/MM/yy")
        '        txtBirthDate.Text = Format(Convert.ToDateTime(dr1("dateofbirth")), "MM/dd/yyyy")

        '        'age = dr1("age").ToString
        '        contract = dr1("contract").ToString
        '        deptname = dr1("departmentname").ToString
        '        designation = desig
        '        Getdesigdet(designation)
        '        If recstatus = True Then
        '            If dsdata.Tables(0).Rows.Count > 0 Then
        '                dr2 = dsdata.Tables(0).Rows(0)
        '                probation = dr2("probation").ToString

        '            End If
        '        End If


        '        If icno = "" Or icno = "-" Or icno = "0" Then
        '            nric.Text = dr1("newicno").ToString
        '        Else
        '            nric.Text = dr1("icno").ToString
        '        End If

        '        Dim CurrentDate As DateTime = DateTime.Today()

        '        Dim BirthDate As DateTime
        '        ' Makes sure the text input is converted to a Date:
        '        BirthDate = txtBirthDate.Text

        '        Dim diff As TimeSpan = CurrentDate.Subtract(BirthDate)
        '        '    'Cint' Converts the output to an Integer (no decimal places)
        '        lblshowage.Text = CInt(diff.Days / 365)


        '        Session("empname") = empname.Text
        '        Session("deptcode") = dept.Text
        '        Session("seccode") = sect.Text
        '        Session("nric") = nric.Text
        '        Session("icno") = nric.Text
        '        Session("desig") = desig
        '        Session("contract") = probation
        '        Session("dateofjoin") = dateofjoin
        '        Session("deptname") = deptname
        '        Session("cmg_age") = lblshowage.Text
        '        'Session("newic") = newicno


        '    Else
        '        MessageBox("EmployeeCode doesnot Exist!!")

        '    End If
        'End If
        Dim icno
        Dim bday
        Dim contract
        Dim newicno
        Dim age
        Dim ppno
        Dim dob
        Dim dateofjoin
        Dim desig
        Dim deptname
        Dim probation
        Dim designation
        Dim foreign
        Dim dr1 As DataRow
        ecode = empcode.Text
        GetEmpVehino(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                icno = dr1("icno").ToString
                newicno = dr1("newicno").ToString
                empname.Text = dr1("empname").ToString
                sect.Text = dr1("sectioncode").ToString
                dept.Text = dr1("departmentcode").ToString
                dateofjoin = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yy")
                doj.Text = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yy")
                dob = Format(Convert.ToDateTime(dr1("dateofbirth")), "dd/MM/yy")
                txtBirthDate.Text = Format(Convert.ToDateTime(dr1("dateofbirth")), "MM/dd/yyyy")
                foreign = dr1("foreignemp").ToString

                'age = dr1("age").ToString
                contract = dr1("contract").ToString
                deptname = dr1("departmentname").ToString
                designation = desig
                Getdesigdet(designation)
                If recstatus = True Then
                    If dsdata.Tables(0).Rows.Count > 0 Then
                        dr2 = dsdata.Tables(0).Rows(0)
                        probation = dr2("probation").ToString

                    End If
                End If

                If foreign = "Y" Then
                    If Not dr1("passportno") Is System.DBNull.Value Then
                        nric.Text = dr1("passportno").ToString
                    End If
                Else
                    If icno = "" Or icno = "-" Or icno = "0" Then
                        nric.Text = dr1("newicno").ToString
                    Else
                        nric.Text = dr1("icno").ToString
                    End If
                End If


                Dim CurrentDate As DateTime = DateTime.Today()

                Dim BirthDate As DateTime
                ' Makes sure the text input is converted to a Date:
                BirthDate = txtBirthDate.Text

                Dim diff As TimeSpan = CurrentDate.Subtract(BirthDate)
                '    'Cint' Converts the output to an Integer (no decimal places)
                lblshowage.Text = CInt(diff.Days / 365)


                Session("empname") = empname.Text
                Session("deptcode") = dept.Text
                Session("seccode") = sect.Text
                Session("nric") = nric.Text
                Session("icno") = nric.Text
                Session("desig") = desig
                Session("contract") = probation
                Session("dateofjoin") = dateofjoin
                Session("deptname") = deptname
                Session("cmg_age") = lblshowage.Text
                'Session("newic") = newicno


            Else
                MessageBox("EmployeeCode doesnot Exist!!")

            End If
        End If
    End Sub
    Protected Sub basicsal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles basicsal.TextChanged
        Dim total As Integer
        Dim bsa As Integer

        If basicsal.Text = "" Then
            basicsal.Text = 0
        End If

        bsa = basicsal.Text
        total = 0

        total = bsa

        tot.Text = total
    End Sub

    Protected Sub hra_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles hra.TextChanged
        Dim total As Integer
        Dim bsa As Integer
        Dim hrall As Integer

        If basicsal.Text = "" Then
            basicsal.Text = 0
        End If
        If hra.Text = "" Then
            hra.Text = 0
        End If


        bsa = basicsal.Text
        hrall = hra.Text
       

        total = 0

        total = (bsa + hrall)

        tot.Text = total
    End Sub


    Protected Sub showaptstaffforeign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showaptstaffforeign.Click
        
        Dim ft As String
        ft = DateTime.Now.ToString("dd/MM/yyyy")

        Dim ft1 As String
        ft1 = DateTime.Now.ToString("MM/dd/yyyy")


        Session("letdt") = ft

        If hra.Text = "" Or hra.Text = "0" Then
            Session("allow") = ""
            Session("curr") = ""
        Else
            Session("allow") = "Position Allowance :"
            Session("curr") = "RM."
        End If

        Session("bsa") = basicsal.Text

        If hra.Text = "0" Or hra.Text = "" Then
            Session("pall") = ""
        Else
            Session("pall") = hra.Text
        End If

        Session("tot") = tot.Text
        Session("target") = target.SelectedValue
        Session("extprob") = contperiod.Text

        Dim xxd1 As String
        Dim xxd As String
        Dim refno

        xxd1 = ft
        Dim strdate5() As String = xxd1.Split("/"c)
        xxd1 = strdate5(1) & strdate5(0)

        xxd = xxd1 & "/" & empcode.Text

        refno = xxd

        ecode = empcode.Text
        Session("refno") = refno

        Dim total As Integer
        Dim bsa As Integer
        Dim hrall As Integer
        Dim allow1 As Integer
        Dim allow2 As Integer

        If basicsal.Text = "" Then
            basicsal.Text = 0
        End If
        If hra.Text = "" Then
            hra.Text = 0
        End If

        bsa = basicsal.Text
        hrall = hra.Text

        Session("nric") = nric.Text
        total = 0

        total = (bsa + hrall + allow1 + allow2)

        tot.Text = total

        getchkval15(ecode, ft1)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Cmd = New SqlCommand("update emp_modified set dateofkeyin = getdate(), printedby = '" & Session("empcode") & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'N',termination = 'N',appointmentletter = 'Y',resign = 'N', refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                    Cmd.ExecuteNonQuery()
                    lblmsg.Text = "Details Added"

                    'empcode.Text = ""
                    'ptype.SelectedValue = "-1"
                    'dtefffrom.Text = ""
                    'newdept.SelectedValue = "-1"
                    'newsect.SelectedValue = "-1"
                    'Label11.Text = ""
                    'Label10.Text = ""
                    'Label13.Text = ""

                Catch ex As SqlException
                    lblmsg.Text = ex.Message

                End Try

            Else

                Try
                    MyGlobal.Open_Con()
                    MyGlobal.Con_Str()
                    MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','N','N','N','N','Y','N','N','" & refno & "')", con)
                    Cmd.ExecuteNonQuery()
                    lblmsg.Text = "Details Added"

                    'empcode.Text = ""
                    'ptype.SelectedValue = "-1"
                    'dtefffrom.Text = ""
                    'newdept.SelectedValue = "-1"
                    'newsect.SelectedValue = "-1"
                    'Label11.Text = ""
                    'Label10.Text = ""
                    'Label13.Text = ""
                Catch ex As SqlException
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Green

                End Try

            End If
        End If

        Response.Redirect("StaffForeignAppointmentLetter.aspx")
    End Sub
End Class
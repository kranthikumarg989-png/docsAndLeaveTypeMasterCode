Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class ApptLetterForStaff
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim ecode
    Dim appno

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '' check access rights 
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (200)
            If GlobalDsRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDsRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
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
                desig = dr1("designation").ToString
                dateofjoin = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yy")
                doj.Text = Format(Convert.ToDateTime(dr1("dateofjoin")), "dd/MM/yy")
                dob = Format(Convert.ToDateTime(dr1("dateofbirth")), "dd/MM/yy")
                txtBirthDate.Text = Format(Convert.ToDateTime(dr1("dateofbirth")), "MM/dd/yyyy")

                'age = dr1("age").ToString
                contract = dr1("contract").ToString
                deptname = dr1("departmentname").ToString
                Designation = desig
                Getdesigdet(Designation)
                If recstatus = True Then
                    If dsdata.Tables(0).Rows.Count > 0 Then
                        dr2 = dsdata.Tables(0).Rows(0)
                        probation = dr2("probation").ToString

                    End If
                End If


                If icno = "" Or icno = "-" Or icno = "0" Then
                    nric.Text = dr1("newicno").ToString
                Else
                    nric.Text = dr1("icno").ToString
                End If

                Dim CurrentDate As DateTime = DateTime.Today()

                Dim BirthDate As DateTime
                ' Makes sure the text input is converted to a Date:
                BirthDate = txtBirthDate.Text

                Dim diff As TimeSpan = CurrentDate.Subtract(BirthDate)
                '    'Cint' Converts the output to an Integer (no decimal places)
                LblShowAge.Text = CInt(diff.Days / 365)

                Session("cmg_age") = LblShowAge.Text
                Session("empname") = empname.Text
                Session("deptcode") = dept.Text
                Session("seccode") = sect.Text
                Session("nric") = nric.Text
                Session("icno") = nric.Text
                Session("desig") = desig
                Session("contract") = probation
                Session("dateofjoin") = dateofjoin
                Session("deptname") = deptname
                Dim dshod As DataSet
                Dim drhod As DataRow
                Dim lvl
                dshod = Getdlevel(ecode)
                If dshod.Tables(0).Rows.Count > 0 Then
                    drhod = dshod.Tables(0).Rows(0)
                    lvl = drhod("dlevel").ToString
                End If
                Session("lvl") = lvl
            Else
                MessageBox("EmployeeCode doesnot Exist!!")

            End If
        End If
    End Sub
   
    Function Getdlevel(ByVal emp As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select dlevel from designation where designationname=(select designation from empmaster where empcode='" & emp & "')", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIlvl")
        con.Close()
        Return ds
    End Function
    Protected Sub showaptstaff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showaptstaff.Click
        Dim ad1 As String
        Dim ad As String

        'ad1 = doc.Text.Trim
        'Dim strdate() As String = ad1.Split("/"c)
        'ad1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        'ad = CDate(ad1)
        'Session("doc") = ad


        Dim ft As String
        ft = DateTime.Now.ToString("dd/MM/yyyy")

        Dim ft1 As String
        ft1 = DateTime.Now.ToString("MM/dd/yyyy")


        Session("letdt") = ft

        'Session("letdt") = dd


        Session("bsa") = basicsal.Text
        Session("pall") = hra.Text
        Session("all1") = all1.Text
        Session("all2") = all2.Text

        If all1.Text = "0" Then
            Session("all1") = ""
        Else
            Session("all1") = all1.Text
        End If


        If all2.Text = "0" Then
            Session("all2") = ""
        Else
            Session("all2") = all2.Text
        End If


        If DDL1.SelectedValue = "-1" Then
            Session("allow1") = ""
            Session("curr") = ""
            Session("a1colon") = ""
        Else
            Session("allow1") = (DDL1.SelectedValue)
            Session("curr") = "RM"
            Session("a1colon") = ":"
        End If

        If DDL2.SelectedValue = "-1" Then
            Session("allow12") = ""
            Session("curr1") = ""
            Session("a2colon") = ""
        Else
            Session("allow12") = (DDL2.SelectedValue)
            Session("curr1") = "RM"
            Session("a2colon") = ":"
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

        If all1.Text = "" Then
            all1.Text = 0
        End If

        If all2.Text = "" Then
            all2.Text = 0
        End If

        bsa = basicsal.Text
        hrall = hra.Text
        allow1 = all1.Text
        allow2 = all2.Text

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
        MessageBox(Session("lvl"))

        If Session("lvl") >= 4 Then
            If Session("all1") = "" And Session("all2") = "" Then
                Response.Redirect("A1StaffApptLetter.aspx")
            ElseIf Session("all1") <> "" And Session("all2") = "" Then
                Response.Redirect("A2StaffApptLetter.aspx")
            Else
                Response.Redirect("StaffApptLetter.aspx")
            End If
        Else
            If Session("all1") = "" And Session("all2") = "" Then
                Response.Redirect("A1dStaffApptLetter.aspx")
            ElseIf Session("all1") <> "" And Session("all2") = "" Then
                Response.Redirect("A2dStaffApptLetter.aspx")
            Else
                Response.Redirect("StaffApptLetterd.aspx")
            End If
        End If


    End Sub

    Protected Sub basicsal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles basicsal.TextChanged
        Dim total As Integer
        Dim bsa As Integer
        Dim hrall As Integer
        Dim allow1 As Integer
        Dim allow2 As Integer

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
        'allow1 = all1.Text
        'allow2 = all2.Text

        total = 0

        total = (bsa + hrall)

        tot.Text = total
    End Sub

    Protected Sub all1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles all1.TextChanged
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

        If all1.Text = "" Then
            all1.Text = 0
        End If


        bsa = basicsal.Text
        hrall = hra.Text
        allow1 = all1.Text
        'allow2 = all2.Text

        total = 0

        total = (bsa + hrall + allow1)

        tot.Text = total
    End Sub

    Protected Sub all2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles all2.TextChanged
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

        If all1.Text = "" Then
            all1.Text = 0
        End If

        If all2.Text = "" Then
            all2.Text = 0
        End If



        bsa = basicsal.Text
        hrall = hra.Text
        allow1 = all1.Text
        allow2 = all2.Text

        total = 0

        total = (bsa + hrall + allow1 + allow2)

        tot.Text = total
    End Sub
End Class
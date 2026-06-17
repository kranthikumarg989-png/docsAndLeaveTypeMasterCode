Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class ChangeSectDeptPromEtc
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
            MyScreenId = (204)
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
        trfrpanel.Visible = False
        promopanel.Visible = False
        promopfppanel.Visible = False
        ctmedpanel.Visible = False
        cetempatanpanel.Visible = False
        cewargapanel.Visible = False
        confpanel.Visible = False
        cepanel.Visible = False
        cepfppanel.Visible = False

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

    Private Sub getcontdet1()
        Dim yd1 As String
        Dim yd As String

        yd1 = CETfrom.Text.Trim
        Dim strdate() As String = yd1.Split("/"c)
        yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim contract
        Dim cont
        Dim et
        Dim doj
        Dim dr1 As DataRow
        ecode = empcode.Text
        cont = ceprobperiod.Text
        getcontdet(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                'contract = dr1("contract").ToString
                doj = dr1("dateofjoin").ToString
                'et = dr1("extendcontract").ToString

                'If contract = "" Then
                '    contract = "0"
                'End If
                'If et = "Y" Then
                '    contract = contract + 12
                'Else
                'End If
                Try
                    'MyGlobal.Open_Con()
                    'MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Dim cmd3 As SqlCommand
                    cmd3 = New SqlCommand("update empmaster set contract = '" & cont & "', extendcontract = 'Y', contracteffectivefrom =  '" & yd & "' where empcode='" & ecode & "'", con)
                    cmd3.ExecuteNonQuery()
                Catch ex As SqlException
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Green
                End Try

            Else
            End If
        End If
    End Sub
    Private Sub getcontdet2()

        Dim yd1 As String
        Dim yd As String

        yd1 = CEOfrom.Text.Trim
        Dim strdate() As String = yd1.Split("/"c)
        yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)
        Dim contract
        Dim cont
        Dim et
        Dim doj
        Dim dr1 As DataRow
        ecode = empcode.Text
        cont = probperiod.Text
        getcontdet(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                'contract = dr1("contract").ToString
                doj = dr1("dateofjoin").ToString
                'et = dr1("extendcontract").ToString

                'If contract = "" Then
                '    contract = "0"
                'End If
                'If et = "Y" Then
                '    contract = contract + 12
                'Else
                'End If

                Try
                    'MyGlobal.Open_Con()
                    'MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Dim cmd3 As SqlCommand
                    cmd3 = New SqlCommand("update empmaster set contract = '" & cont & "', extendcontract = 'Y', contracteffectivefrom =  '" & yd & "' where empcode='" & ecode & "'", con)
                    cmd3.ExecuteNonQuery()
                Catch ex As SqlException
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Green
                End Try
            Else
            End If
        End If
    End Sub
    Private Sub getcontdet3()
        Dim yd1 As String
        Dim yd As String

        yd1 = cefrom.Text.Trim
        Dim strdate() As String = yd1.Split("/"c)
        yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        yd = CDate(yd1)
        Dim contract
        Dim cont
        Dim et
        Dim doj
        Dim dr1 As DataRow
        ecode = empcode.Text
        getcontdet(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                'contract = dr1("contract").ToString
                'et = dr1("extendcontract").ToString

                contract = CEcont.Text

                Try
                    'MyGlobal.Open_Con()
                    'MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Dim cmd3 As SqlCommand
                    cmd3 = New SqlCommand("update empmaster set contract = '" & contract & "', extendcontract = 'Y', contracteffectivefrom =  '" & yd & "' where empcode='" & ecode & "'", con)
                    cmd3.ExecuteNonQuery()
                Catch ex As SqlException
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Green
                End Try
            Else
            End If
        End If
    End Sub
    Private Sub getcontdet4()
        Dim yd1 As String
        Dim yd As String

        yd1 = cepfpefffrom.Text.Trim
        Dim strdate() As String = yd1.Split("/"c)
        yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        yd = CDate(yd1)

        Dim contract
        Dim cont
        Dim et
        Dim doj
        Dim olddept
        Dim dr1 As DataRow
        contract = cepfpcontperiod
        ecode = empcode.Text
        getcontdet(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                ' contract = dr1("contract").ToString
                ' et = dr1("extendcontract").ToString
                doj = dr1("dateofjoin").ToString
                olddept = dr1("departmentcode").ToString

                'If contract = "" Then
                '    contract = "0"
                'End If


                Try
                    'MyGlobal.Open_Con()
                    'MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Dim cmd3 As SqlCommand
                    cmd3 = New SqlCommand("update empmaster set extendcontract = 'Y', contracteffectivefrom =  '" & yd & "', contract = '" & contract & "' where empcode='" & ecode & "'", con)
                    cmd3.ExecuteNonQuery()
                Catch ex As SqlException
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Green
                End Try
            Else
            End If
        End If
    End Sub
    Private Sub Appdetails()
        Dim icno
        Dim newicno
        Dim ppno
        Dim doj
        Dim dj
        Dim nation
        Dim PPIC
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
                Labeldesig.Text = dr1("designation").ToString
                pfplabeldesig.Text = dr1("designation").ToString
                cepfpdesig.Text = dr1("designation").ToString
                cepfpdoj.Text = dr1("dateofjoin").ToString
                ppno = dr1("passportno").ToString
                nation = dr1("foreignemp").ToString
               
                doj = cepfpdoj.Text
                dj = CDate(doj)
                If icno = "" Or icno = "-" Or icno = "0" Then
                    cepfpicno.Text = dr1("newicno").ToString
                Else
                    cepfpicno.Text = dr1("icno").ToString
                End If

                If nation = "Y" Then
                    PPIC = ppno
                Else
                    PPIC = cepfpicno.Text
                End If

                Session("empname") = Label11.Text
                Session("deptcode") = Label13.Text
                Session("seccode") = Label10.Text
                Session("desig") = Labeldesig.Text
                Session("desig1") = pfplabeldesig.Text
                Session("desig2") = cepfpdesig.Text
                Session("doj") = cepfpdoj.Text
                Session("dj") = dj
                Session("ic") = cepfpicno.Text
                Session("empcode_cmg") = empcode.Text
                Session("ppic") = PPIC
                'Session("newic") = newicno


            Else
                MessageBox("EmployeeCode doesnot Exist!!")

            End If
        End If

    End Sub
    Private Sub getinsdet1()
        Dim inscategory
        Dim desig
        Dim insamount
        Dim dr1 As DataRow
        ecode = empcode.Text
        desig = DDL4.SelectedValue
        getinspdata(desig)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                inscategory = dr1("inscategory").ToString
                insamount = dr1("insamount").ToString
                getcrosschk1(ecode)
                If recstatus = True Then
                    If dsdata.Tables(0).Rows.Count > 0 Then
                        Try
                            MyGlobal.Open_Con()
                            MyGlobal.Con_Str()


                            Dim conn As New SqlConnection(constr)
                            conn.Open()
                            Cmd = New SqlCommand("update emp_insurance set category = '" & inscategory & "', insurance = '" & insamount & "' where empcode='" & ecode & "'", conn)
                            Cmd.ExecuteNonQuery()
                        Catch ex As SqlException
                            lblmsg.Text = ex.Message
                            lblmsg.ForeColor = Drawing.Color.Green
                        End Try
                    Else
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub appdet2()
        Dim deptname
        Dim depcode
        Dim dr3 As DataRow
        depcode = Label13.Text
        Getdepdata(depcode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr3 = dsdata.Tables(0).Rows(0)
                deptname = dr3("departmentname").ToString
            End If
        End If
        Session("deptname") = deptname
    End Sub
    Private Sub appdet3()
        Dim deptname
        Dim depcode
        Dim dr5 As DataRow
        depcode = newdept.Text
        Getdepdata(depcode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr5 = dsdata.Tables(0).Rows(0)
                deptname = dr5("departmentname").ToString
            End If
        End If
        Session("newdeptname") = deptname
    End Sub

    Private Sub appdet4()
        Dim sectname
        Dim seccode
        Dim dr4 As DataRow
        seccode = Label10.Text
        Getsecdata(seccode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr4 = dsdata.Tables(0).Rows(0)
                sectname = dr4("sectionname").ToString
            End If
        End If
        Session("sectname") = sectname
    End Sub
    Private Sub appdet5()
        Dim sectname
        Dim seccode
        Dim dr6 As DataRow
        seccode = newsect.Text
        Getsecdata(seccode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr6 = dsdata.Tables(0).Rows(0)
                sectname = dr6("sectionname").ToString
            End If
        End If
        Session("newsectname") = sectname
    End Sub

    Protected Sub ptype_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptype.SelectedIndexChanged


        If ptype.SelectedValue = "Transfer" Then
            trfrpanel.Visible = True
            promopanel.Visible = False
            promopfppanel.Visible = False
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = False
            cewargapanel.Visible = False
            confpanel.Visible = False
            cepanel.Visible = False
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Promotion" Then
            trfrpanel.Visible = False
            promopanel.Visible = True
            promopfppanel.Visible = False
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = False
            cewargapanel.Visible = False
            confpanel.Visible = False
            cepanel.Visible = False
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Contract Termination" Then
            trfrpanel.Visible = False
            promopanel.Visible = False
            promopfppanel.Visible = False
            ctmedpanel.Visible = True
            cetempatanpanel.Visible = False
            cewargapanel.Visible = False
            confpanel.Visible = False
            cepanel.Visible = False
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Contract Extension (Tempatan)" Then
            trfrpanel.Visible = False
            promopanel.Visible = False
            promopfppanel.Visible = False
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = True
            cewargapanel.Visible = False
            confpanel.Visible = False
            cepanel.Visible = False
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Contract Extension (Warga Asing) " Then
            trfrpanel.Visible = False
            promopanel.Visible = False
            promopfppanel.Visible = False
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = False
            cewargapanel.Visible = True
            confpanel.Visible = False
            cepanel.Visible = False
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Promotion - New Group PFP" Then
            trfrpanel.Visible = False
            promopanel.Visible = False
            promopfppanel.Visible = True
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = False
            cewargapanel.Visible = False
            confpanel.Visible = False
            cepanel.Visible = False
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Confirmation" Then
            trfrpanel.Visible = False
            promopanel.Visible = False
            promopfppanel.Visible = False
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = False
            cewargapanel.Visible = False
            confpanel.Visible = True
            cepanel.Visible = False
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Contract Extension" Then
            trfrpanel.Visible = False
            promopanel.Visible = False
            promopfppanel.Visible = False
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = False
            cewargapanel.Visible = False
            confpanel.Visible = False
            cepanel.Visible = True
            cepfppanel.Visible = False


        ElseIf ptype.SelectedValue = "Contract Extension on PFP" Then
            trfrpanel.Visible = False
            promopanel.Visible = False
            promopfppanel.Visible = False
            ctmedpanel.Visible = False
            cetempatanpanel.Visible = False
            cewargapanel.Visible = False
            confpanel.Visible = False
            cepanel.Visible = False
            cepfppanel.Visible = True


        End If
    End Sub

    Protected Sub savetrfr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savetrfr.Click

        If ptype.SelectedValue = "Transfer" Then



            Session("sect") = Label10.Text
            Session("newsect") = newsect.SelectedValue.Trim
            Session("newdept") = newdept.SelectedValue.Trim

            Dim ad1 As String
            Dim ad As String

            ad1 = dtefffrom.Text.Trim
            Dim strdate() As String = ad1.Split("/"c)
            ad1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            ad = CDate(ad1)
            Session("dteff1") = dtefffrom.Text.Trim

            Dim ft As String
            ft = DateTime.Now.ToString("dd/MM/yyyy")

            Dim ft1 As String
            ft1 = DateTime.Now.ToString("MM/dd/yyyy")


            Session("letdt") = ft


            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = ft
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(0) & strdate5(1)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text
            Session("refno") = refno

            getchkval8(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & ad & "', transfer = 'Y', promotion = 'N',confirmation = 'N',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N', refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set departmentcode = '" & newdept.SelectedValue & "', sectioncode = '" & newsect.SelectedValue & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()

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
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & ad & "','Y','N','N','N','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set departmentcode = '" & newdept.SelectedValue & "', sectioncode = '" & newsect.SelectedValue & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()

                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
        appdet2()
        appdet3()

        Response.Redirect("TransferLetter.aspx")

        'empcode.Text = ""
        'ptype.SelectedValue = "-1"
        'dtefffrom.Text = ""
        'newdept.SelectedValue = "-1"
        'newsect.SelectedValue = "-1"
        'Label11.Text = ""
        'Label10.Text = ""
        'Label13.Text = ""

    End Sub

    Protected Sub savepromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savepromo.Click

        If ptype.SelectedValue = "Promotion" Then


            Dim bd1 As String
            Dim bd As String

            bd1 = prodteff.Text.Trim
            Dim strdate1() As String = bd1.Split("/"c)
            bd1 = strdate1(1) & "/" & strdate1(0) & "/" & strdate1(2)

            bd = CDate(bd1)
            Session("efffrom1") = prodteff.Text.Trim

            Dim ft As String
            ft = DateTime.Now.ToString("dd/MM/yyyy")

            Dim ft1 As String
            ft1 = DateTime.Now.ToString("MM/dd/yyyy")


            Session("letdt1") = ft


            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = ft
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(0) & strdate5(1)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text

            Session("refno") = refno
            Session("empcode_cmg") = empcode.Text
            Session("dteff") = prodteff.Text
            Session("newdesig") = pnewdesig.SelectedValue
            Session("oldbsa1") = TextBox3.Text
            Session("oldpa1") = TextBox5.Text
            Session("oldpfp1") = TextBox6.Text
            Session("newbsa1") = nbs.Text
            Session("newpa1") = npa.Text
            Session("newpfp1") = npfpall.Text
            Session("totsal1") = TextBox7.Text



            getchkval9(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try

                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & bd & "', transfer = 'N', promotion = 'Y',confirmation = 'N',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set designation = '" & pnewdesig.SelectedValue & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd2 As New SqlCommand
                        cmd2 = New SqlCommand("update emp_probationpromotees set status = 'Y' where empcode='" & empcode.Text & "'", con)
                        cmd2.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try


                Else
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & bd & "','N','Y','N','N','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set designation = '" & pnewdesig.SelectedValue & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()
                        getpromdet1(ecode)
                        If recstatus = True Then
                            If dsdata.Tables(0).Rows.Count > 0 Then
                                Dim cmd2 As New SqlCommand
                                cmd2 = New SqlCommand("update emp_probationpromotees set status = 'Y' where empcode='" & empcode.Text & "'", con)
                                cmd2.ExecuteNonQuery()
                            End If
                        End If
                        getinsdet1()

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'prodteff.Text = ""
                        'pnewdesig.SelectedValue = "-1"
                        'TextBox3.Text = ""
                        'TextBox5.Text = ""
                        'TextBox6.Text = ""
                        'nbs.Text = ""
                        'npa.Text = ""
                        'npfpall.Text = ""
                        'TextBox7.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                        'Labeldesig.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If

            End If
        End If
        Response.Redirect("PromotionLetter.aspx")


    End Sub

    Protected Sub savepromopfp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savepromopfp.Click

        If ptype.SelectedValue = "Promotion - New Group PFP" Then

            Dim bd1 As String
            Dim bd As String

            bd1 = TextBox1.Text.Trim
            Dim strdate1() As String = bd1.Split("/"c)
            bd1 = strdate1(1) & "/" & strdate1(0) & "/" & strdate1(2)

            bd = CDate(bd1)
            Session("peffdate") = TextBox1.Text.Trim

            Dim ft As String
            ft = DateTime.Now.ToString("dd/MM/yyyy")

            Dim ft1 As String
            ft1 = DateTime.Now.ToString("MM/dd/yyyy")


            Session("letdt") = ft


            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = ft
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(0) & strdate5(1)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text

            Session("refno") = refno

            Session("pnewdesig") = DDL4.SelectedValue
            Session("prodteff") = TextBox1.Text
            Session("obs") = TextBox11.Text
            Session("opa") = TextBox12.Text
            Session("nbs") = pfpnbs.Text
            Session("npa") = pfpnpa.Text
            Session("npfpall") = pfpnpfpall.Text
            Session("totsal") = TextBox13.Text

            getchkval9(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try

                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & bd & "', transfer = 'N', promotion = 'Y',confirmation = 'N',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set designation = '" & DDL4.SelectedValue & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd2 As New SqlCommand
                        cmd2 = New SqlCommand("update emp_probationpromotees set status = 'Y' where empcode='" & empcode.Text & "'", con)
                        cmd2.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'TextBox1.Text = ""
                        'DDL4.SelectedValue = "-1"
                        'TextBox11.Text = ""
                        'TextBox12.Text = ""
                        'pfpnbs.Text = ""
                        'pfpnpa.Text = ""
                        'pfpnpfpall.Text = ""
                        'TextBox13.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                        'pfplabeldesig.Text = ""

                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try


                Else
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & bd & "','N','Y','N','N','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set designation = '" & DDL4.SelectedValue & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()
                        getpromdet1(ecode)
                        If recstatus = True Then
                            If dsdata.Tables(0).Rows.Count > 0 Then
                                Dim cmd2 As New SqlCommand
                                cmd2 = New SqlCommand("update emp_probationpromotees set status = 'Y' where empcode='" & empcode.Text & "'", con)
                                cmd2.ExecuteNonQuery()
                            End If
                        End If
                        getinsdet1()

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'TextBox1.Text = ""
                        'DDL4.SelectedValue = "-1"
                        'TextBox11.Text = ""
                        'TextBox12.Text = ""
                        'pfpnbs.Text = ""
                        'pfpnpa.Text = ""
                        'pfpnpfpall.Text = ""
                        'TextBox13.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                        'pfplabeldesig.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green


                    End Try

                End If

            End If
        End If

        Response.Redirect("Promotion PFPLetter.aspx")
    End Sub

    Protected Sub savectmu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savectmu.Click

        If ptype.SelectedValue = "Contract Termination" Then

            Dim ad1 As String
            Dim ad As String

            ad1 = ctefffrom.Text.Trim
            Dim strdate() As String = ad1.Split("/"c)
            ad1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            ad = CDate(ad1)
            Session("cteffdt") = ad

            Dim ed1 As String
            Dim ed As String

            ed1 = cteffto1.Text.Trim
            Dim strdate3() As String = ed1.Split("/"c)
            ed1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            ed = CDate(ed1)
            Session("ctltdt") = ed

            Dim ft As String
            ft = DateTime.Now.ToString("dd/MM/yyyy")

            Dim ft1 As String
            ft1 = DateTime.Now.ToString("MM/dd/yyyy")


            Session("letdt") = ft


            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = ft
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(0) & strdate5(1)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text
            Session("refno") = refno
            Session("efffrom") = ctefffrom.Text
            Session("effto") = cteffto1.Text
            Session("empcode_cmg") = empcode.Text


            getchkval10(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & ad & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'N',termination = 'Y',appointmentletter = 'N',resign = 'N', lastworkingday = '" & ed & "',letterdate = '" & ad & "', replacealert = 'S',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'ctefffrom.Text = ""
                        'cteffto1.Text = ""
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
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,lastworkingday,letterdate,replacealert,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & ad & "','N','N','N','N','Y','N','N','" & ed & "','" & ad & "','S','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'ctefffrom.Text = ""
                        'cteffto1.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
        Response.Redirect("ContractTermination.aspx")
    End Sub

    Protected Sub savecet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savecet.Click
        If ptype.SelectedValue = "Contract Extension (Tempatan)" Then
            Dim refno
            Dim yd1 As String
            Dim yd As String

            yd1 = CETfrom.Text.Trim
            Dim strdate() As String = yd1.Split("/"c)
            yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            yd = CDate(yd1)
            Session("ctefffrom1") = CETfrom.Text.Trim

            Dim xd1 As String
            Dim xd As String

            xd1 = CETto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("cteffto1") = CETto.Text.Trim

            Dim ft As String
            ft = DateTime.Now.ToString("dd/MM/yyyy")

            Dim ft1 As String
            ft1 = DateTime.Now.ToString("MM/dd/yyyy")


            Session("ltdt") = ft


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
            Session("prob") = ceprobperiod.Text


            getchkval11(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N','" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet1()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'CETfrom.Text = ""
                        'CETto.Text = ""
                        'ceprobperiod.Text = ""
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
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & yd & "','N','N','N','Y','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet1()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'CETfrom.Text = ""
                        'CETto.Text = ""
                        'ceprobperiod.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
        Response.Redirect("ContractExtensionTempatanLetter.aspx")

    End Sub

    Protected Sub savecewa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savecewa.Click

        If ptype.SelectedValue = "Contract Extension (Warga Asing) " Then

            Dim refno
            Dim yd1 As String
            Dim yd As String

            yd1 = CEOfrom.Text.Trim
            Dim strdate() As String = yd1.Split("/"c)
            yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            yd = CDate(yd1)
            Session("efffrom2") = CEOfrom.Text.Trim


            Dim xd1 As String
            Dim xd As String

            xd1 = CEOto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("effto2") = CEOto.Text.Trim

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
            Session("prob") = probperiod.Text

            getchkval11(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet2()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'CEOfrom.Text = ""
                        'CEOto.Text = ""
                        'probperiod.Text = ""
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
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & yd & "','N','N','N','Y','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet2()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()

                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'CEOfrom.Text = ""
                        'CEOto.Text = ""
                        'probperiod.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
        Response.Redirect("ContractExtensionWargaLetter.aspx")
    End Sub

    Protected Sub saveconf_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles saveconf.Click

        If ptype.SelectedValue = "Confirmation" Then
            Dim refno
            Dim ld1 As String
            Dim ld As String

            ld1 = cefffrom.Text.Trim
            Dim strdate() As String = ld1.Split("/"c)
            ld1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            ld = CDate(ld1)
            Session("efffrom3") = cefffrom.Text.Trim


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
            Session("prob3") = cprobperiod.Text
            Session("bsa3") = confbsa.Text

            getchkval12(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & ld & "', transfer = 'N', promotion = 'N',confirmation = 'Y',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set emptype = 'Confirmed' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'cprobperiod.Text = ""
                        'cefffrom.Text = ""
                        'confbsa.Text = ""
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
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & ld & "','N','N','Y','N','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Cmd.ExecuteNonQuery()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set emptype = 'Confirmed' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'cprobperiod.Text = ""
                        'cefffrom.Text = ""
                        'confbsa.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If

        Response.Redirect("ConfirmationLetter.aspx")
    End Sub

    Protected Sub savecext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savecext.Click
        If ptype.SelectedValue = "Contract Extension" Then

            Dim yd1 As String
            Dim yd As String

            yd1 = cefrom.Text.Trim
            Dim strdate() As String = yd1.Split("/"c)
            yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            yd = CDate(yd1)
            Session("efffrom4") = cefrom.Text.Trim


            Dim xd1 As String
            Dim xd As String

            xd1 = ceto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("effto4") = ceto.Text.Trim

            Dim ft As String
            ft = DateTime.Now.ToString("dd/MM/yyyy")

            Dim ft1 As String
            ft1 = DateTime.Now.ToString("MM/dd/yyyy")


            Session("letdt") = ft


            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = ft
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(0) & strdate5(1)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text
            Session("refno") = refno


            Session("empcode_cmg") = empcode.Text
            Session("months") = CEcont.Text
            Session("efffrom") = cefrom.Text
            Session("effto") = ceto.Text
            Session("newbsa4") = TextBox2.Text
            Session("oldbsa4") = TextBox14.Text
            Session("newpa4") = TextBox4.Text
            Session("oldpa4") = TextBox15.Text

            getchkval11(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        'MyGlobal.Open_Con()
                        'MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                        getcontdet3()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("delete emp_appraisalnote where empcode = '" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'CEcont.Text = ""
                        'cefrom.Text = ""
                        'ceto.Text = ""
                        'TextBox2.Text = ""
                        'TextBox14.Text = ""
                        'TextBox4.Text = ""
                        'TextBox15.Text = ""
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
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & yd & "','N','N','N','Y','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet3()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("delete emp_appraisalnote where empcode = '" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'CEcont.Text = ""
                        'cefrom.Text = ""
                        'ceto.Text = ""
                        'TextBox2.Text = ""
                        'TextBox14.Text = ""
                        'TextBox4.Text = ""
                        'TextBox15.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
        Response.Redirect("ContractExtensionLetter.aspx")
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ptype.SelectedValue = "Contract Extension on PFP" Then

            Dim yd1 As String
            Dim yd As String

            yd1 = cepfpefffrom.Text.Trim
            Dim strdate() As String = yd1.Split("/"c)
            yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            yd = CDate(yd1)
            Session("efffrom5") = yd


            Dim gd1 As String
            Dim gd As String

            gd1 = cepfpletdt.Text.Trim
            Dim strdate7() As String = gd1.Split("/"c)
            gd1 = strdate7(1) & "/" & strdate7(0) & "/" & strdate7(2)

            gd = CDate(gd1)
            Session("letdt5") = gd


            Dim xd1 As String
            Dim xd As String

            xd1 = cepfpeffto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("effto5") = xd

            Dim ft As String
            ft = DateTime.Now.ToString("dd/MM/yyyy")

            Dim ft1 As String
            ft1 = DateTime.Now.ToString("MM/dd/yyyy")


            Session("letdt5") = ft


            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = ft
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(0) & strdate5(1)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text
            Session("refno") = refno


            Session("empcode_cmg") = empcode.Text
            Session("months5") = cepfpcontperiod.Text
            Session("efffrom") = cepfpefffrom.Text
            Session("effto") = cepfpeffto.Text
            Session("bassal5") = TextBox16.Text
            Session("nbasicsal5") = TextBox17.Text
            Session("splinc5") = TextBox9.Text
            Session("allamt5") = TextBox8.Text
            Session("posall5") = TextBox10.Text

            getchkval11(ecode, ft1)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & ft1 & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "' where empcode='" & empcode.Text & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet4()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("delete emp_appraisalnote where empcode = '" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'cepfpcontperiod.Text = ""
                        'cepfpefffrom.Text = ""
                        'cepfpeffto.Text = ""
                        'cepfpletdt.Text = ""
                        'TextBox8.Text = ""
                        'TextBox16.Text = ""
                        'TextBox9.Text = ""
                        'TextBox17.Text = ""
                        'TextBox10.Text = ""
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
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & yd & "','N','N','N','Y','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet4()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("delete emp_appraisalnote where empcode = '" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        'empcode.Text = ""
                        'ptype.SelectedValue = "-1"
                        'cepfpcontperiod.Text = ""
                        'cepfpefffrom.Text = ""
                        'cepfpeffto.Text = ""
                        'cepfpletdt.Text = ""
                        'TextBox8.Text = ""
                        'TextBox16.Text = ""
                        'TextBox9.Text = ""
                        'TextBox17.Text = ""
                        'TextBox10.Text = ""
                        'Label11.Text = ""
                        'Label10.Text = ""
                        'Label13.Text = ""

                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
        Response.Redirect("ContractExtensionPFPletter.aspx")
    End Sub

End Class
Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Imports System.Web.Security
Partial Public Class test2
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim ecode

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
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

    Private Sub getcontdet1()
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
                contract = dr1("contract").ToString
                doj = dr1("dateofjoin").ToString
                et = dr1("extendcontract").ToString

                If contract = "" Then
                    contract = "0"
                End If
                If et = "Y" Then
                    contract = contract + 12
                Else
                End If
            Else
            End If
        End If
    End Sub
    Private Sub getcontdet2()
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
                contract = dr1("contract").ToString
                doj = dr1("dateofjoin").ToString
                et = dr1("extendcontract").ToString

                If contract = "" Then
                    contract = "0"
                End If
                If et = "Y" Then
                    contract = contract + 12
                Else
                End If
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
                contract = dr1("contract").ToString
                et = dr1("extendcontract").ToString

                If contract = "" Then
                    contract = "0"
                ElseIf et = "Y" Then
                    contract = CEcont.Text
                Else
                End If


                Try
                    'MyGlobal.Open_Con()
                    'MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Dim cmd3 As SqlCommand
                    cmd3 = New SqlCommand("update empmaster set contract = '" & contract & "', extendcontract = '" & et & "', contracteffectivefrom =  '" & yd & "' where empcode='" & ecode & "'", Con)
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

        ecode = empcode.Text
        getcontdet(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                contract = dr1("contract").ToString
                et = dr1("extendcontract").ToString
                doj = dr1("dateofjoin").ToString
                olddept = dr1("departmentcode").ToString

                If contract = "" Then
                    contract = "0"
                End If


                Try
                    'MyGlobal.Open_Con()
                    'MyGlobal.Con_Str()
                    Dim con As New SqlConnection(constr)
                    con.Open()
                    Dim cmd3 As SqlCommand
                    cmd3 = New SqlCommand("update empmaster set extendcontract = '" & et & "', contracteffectivefrom =  '" & yd & "' where empcode='" & ecode & "'", con)
                    cmd3.ExecuteNonQuery()
                Catch ex As SqlException
                    lblmsg.Text = ex.Message
                    lblmsg.ForeColor = Drawing.Color.Green
                End Try
            Else
            End If
        End If
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Private Sub Appdetails()
        Dim icno
        Dim newicno
        Dim dr1 As DataRow
        ecode = empcode.Text
  
        'getecode
        GetEmpVehino(ecode)
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
                Session("secname") = dr1("sectionname").ToString
                Session("deptname") = dr1("departmentname").ToString

                If icno = "" Or icno = "-" Or icno = "0" Then
                    cepfpicno.Text = dr1("newicno").ToString
                Else
                    cepfpicno.Text = dr1("icno").ToString
                End If
            Else
                MessageBox("EmployeeCode doesnot Exist!!")

            End If
        End If
        Session("empname") = Label11.Text.Trim
        Session("deptcode") = Label13.Text.Trim
        Session("seccode") = Label10.Text.Trim
        Session("desig") = Labeldesig.Text.Trim
        Session("desig1") = pfplabeldesig.Text.Trim
        Session("desig2") = cepfpdesig.Text.Trim
        Session("doj") = cepfpdoj.Text.Trim
        Session("ic") = cepfpicno.Text.Trim

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
                            Cmd = New SqlCommand("update emp_insurance set category = '" & inscategory & "', insurance = '" & insamount & "' where empcode='" & empcode.Text & "'", conn)
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

            Session("newsect") = newsect.SelectedValue.Trim
            Session("newdept") = newdept.SelectedValue.Trim
            Session("empcode") = empcode.Text.Trim

            If newsect.SelectedValue.Trim <> newdept.SelectedValue.Trim Then
                Session("name1") = Session("secname") & (Session("newdept") - Session("newsect"))

            Else
                Session("name1") = Session("secname") & (Session("newdept"))
            End If


            Dim ad1 As String
            Dim ad As String

            ad1 = dtefffrom.Text.Trim
            Dim strdate() As String = ad1.Split("/"c)
            ad1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            ad = CDate(ad1)
            Session("dteff") = ad

            Dim dki
            dki = DateTime.Now

            Dim dd1 As String
            Dim dd As String

            dd1 = dki
            Dim strdate3() As String = dd1.Split("/"c)
            dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            dd = CDate(dd1)

            Session("letdt") = dd

            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd
            Session("refno") = refno

            ecode = empcode.Text

            getchkval8(ecode, dd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
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
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & dd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & ad & "', transfer = 'Y', promotion = 'N',confirmation = 'N',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N', refno = '" & refno & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set departmentcode = '" & newdept.SelectedValue & "', sectioncode = '" & newsect.SelectedValue & "' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()

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

        End If
        Server.Transfer("TransferLetter.aspx")
    End Sub

    Protected Sub savepromo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savepromo.Click

        If ptype.SelectedValue = "Promotion" Then


            Dim bd1 As String
            Dim bd As String

            bd1 = prodteff.Text.Trim
            Dim strdate1() As String = bd1.Split("/"c)
            bd1 = strdate1(1) & "/" & strdate1(0) & "/" & strdate1(2)

            bd = CDate(bd1)

            Session("peffdate") = bd
            Session("pnewdesig") = pnewdesig.SelectedValue.Trim
            Session("prodteff") = prodteff.Text.Trim
            Session("nbs") = nbs.Text.Trim
            Session("npa") = npa.Text.Trim
            Session("npfpall") = npfpall.Text.Trim

            Dim dki
            dki = DateTime.Now

            Dim dd1 As String
            Dim dd As String

            dd1 = dki
            Dim strdate3() As String = dd1.Split("/"c)
            dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            dd = CDate(dd1)

            Session("letdt") = dd

            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd
            Session("refno") = refno

            ecode = empcode.Text

            getchkval9(ecode, dd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
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
                        lblmsg.Text = "Details Added"
                        Dim cmd2 As New SqlCommand
                        cmd2 = New SqlCommand("update emp_probationpromotees set status = 'Y' where empcode='" & empcode.Text & "'", con)
                        cmd2.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

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


                Else
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & dd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & bd & "', transfer = 'N', promotion = 'Y',confirmation = 'N',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "'", con)
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
        Server.Transfer("promotionletter.aspx")
    End Sub

    Protected Sub savepromopfp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savepromopfp.Click

        If ptype.SelectedValue = "Promotion - New Group PFP" Then

            Dim bd1 As String
            Dim bd As String

            bd1 = TextBox1.Text.Trim
            Dim strdate1() As String = bd1.Split("/"c)
            bd1 = strdate1(1) & "/" & strdate1(0) & "/" & strdate1(2)

            bd = CDate(bd1)

            Session("peffdate") = bd
            Session("pnewdesig") = pnewdesig.SelectedValue.Trim
            Session("prodteff") = prodteff.Text.Trim
            Session("nbs") = nbs.Text.Trim
            Session("npa") = npa.Text.Trim
            Session("npfpall") = npfpall.Text.Trim

            Dim dki
            dki = DateTime.Now

            Dim dd1 As String
            Dim dd As String

            dd1 = dki
            Dim strdate3() As String = dd1.Split("/"c)
            dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            dd = CDate(dd1)

            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text

            getchkval9(ecode, dd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
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
                        lblmsg.Text = "Details Added"
                        Dim cmd2 As New SqlCommand
                        cmd2 = New SqlCommand("update emp_probationpromotees set status = 'Y' where empcode='" & empcode.Text & "'", con)
                        cmd2.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        TextBox1.Text = ""
                        DDL4.SelectedValue = "-1"
                        TextBox11.Text = ""
                        TextBox12.Text = ""
                        pfpnbs.Text = ""
                        pfpnpa.Text = ""
                        pfpnpfpall.Text = ""
                        TextBox13.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""
                        pfplabeldesig.Text = ""

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
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & dd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & bd & "', transfer = 'N', promotion = 'Y',confirmation = 'N',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "'", con)
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

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        TextBox1.Text = ""
                        DDL4.SelectedValue = "-1"
                        TextBox11.Text = ""
                        TextBox12.Text = ""
                        pfpnbs.Text = ""
                        pfpnpa.Text = ""
                        pfpnpfpall.Text = ""
                        TextBox13.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""
                        pfplabeldesig.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If

            End If
        End If


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

            Dim dd1 As String
            Dim dd As String

            dd1 = cteffto1.Text.Trim
            Dim strdate3() As String = dd1.Split("/"c)
            dd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            dd = CDate(dd1)
            Session("ctltdt") = dd

            Dim dki
            dki = DateTime.Now

            Dim zd1 As String
            Dim zd As String

            zd1 = dki
            Dim strdate4() As String = dd1.Split("/"c)
            zd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

            zd = CDate(zd1)

            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text

            getchkval10(ecode, zd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,lastworkingday,letterdate,replacealert,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & ad & "','N','N','N','N','Y','N','N','" & dd & "','" & ad & "','S','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        ctefffrom.Text = ""
                        cteffto1.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""

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
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & zd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & ad & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'N',termination = 'Y',appointmentletter = 'N',resign = 'N', lastworkingday = '" & dd & "',letterdate = '" & ad & "', replacealert = 'S',refno = '" & refno & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        ctefffrom.Text = ""
                        cteffto1.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
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
            Session("cteffdt") = yd

            Dim xd1 As String
            Dim xd As String

            xd1 = CETto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("ctltdt") = xd

            Dim dki
            dki = DateTime.Now

            Dim wd1 As String
            Dim wd As String

            wd1 = dki
            Dim strdate4() As String = wd1.Split("/"c)
            wd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

            wd = CDate(wd1)

            Dim xxd1 As String
            Dim xxd As String

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text

            getchkval11(ecode, wd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
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
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "'", con)
                        cmd1.ExecuteNonQuery()

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        CETfrom.Text = ""
                        CETto.Text = ""
                        ceprobperiod.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""

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
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & wd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N','" & refno & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet1()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "'", con)
                        cmd1.ExecuteNonQuery()

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        CETfrom.Text = ""
                        CETto.Text = ""
                        ceprobperiod.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If

    End Sub

    Protected Sub savecewa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savecewa.Click

        If ptype.SelectedValue = "Contract Extension (Warga Asing)" Then

            Dim refno
            Dim yd1 As String
            Dim yd As String

            yd1 = CEOfrom.Text.Trim
            Dim strdate() As String = yd1.Split("/"c)
            yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            yd = CDate(yd1)
            Session("cteffdt") = yd

            Dim xd1 As String
            Dim xd As String

            xd1 = CEOto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("ctltdt") = xd

            Dim dki
            dki = DateTime.Now

            Dim wd1 As String
            Dim wd As String

            wd1 = dki
            Dim strdate4() As String = wd1.Split("/"c)
            wd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

            wd = CDate(wd1)

            Dim xxd1 As String
            Dim xxd As String

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text
            refno = xxd

            ecode = empcode.Text

            getchkval11(ecode, wd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
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
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "'", con)
                        cmd1.ExecuteNonQuery()

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        CEOfrom.Text = ""
                        CEOto.Text = ""
                        probperiod.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""

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
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & wd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet2()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set extendcontract = 'Y',contracteffectivefrom = '" & xd & "'", con)
                        cmd1.ExecuteNonQuery()

                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        CEOfrom.Text = ""
                        CEOto.Text = ""
                        probperiod.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If

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
            Session("cteffdt") = ld

            'Dim md1 As String
            'Dim md As String

            'md1 = CEOto.Text.Trim
            'Dim strdate3() As String = md1.Split("/"c)
            'md1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            'md = CDate(md1)
            'Session("ctltdt") = md

            Dim dki
            dki = DateTime.Now

            Dim nd1 As String
            Dim nd As String

            nd1 = dki
            Dim strdate4() As String = nd1.Split("/"c)
            nd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

            nd = CDate(nd1)

            Dim xxd1 As String
            Dim xxd As String

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text

            getchkval12(ecode, nd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & ld & "','N','N','Y','N','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set emptype = 'Confirmed' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        cprobperiod.Text = ""
                        cefffrom.Text = ""
                        confbsa.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""

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
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & nd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & ld & "', transfer = 'N', promotion = 'N',confirmation = 'Y',extensioncontract = 'N',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        Cmd.ExecuteNonQuery()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("update empmaster set emptype = 'Confirmed' where empcode='" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        cprobperiod.Text = ""
                        cefffrom.Text = ""
                        confbsa.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
    End Sub

    Protected Sub savecext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles savecext.Click
        If ptype.SelectedValue = "Contract Extension" Then

            Dim yd1 As String
            Dim yd As String

            yd1 = cefrom.Text.Trim
            Dim strdate() As String = yd1.Split("/"c)
            yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            yd = CDate(yd1)
            Session("cteffdt") = yd


            Dim xd1 As String
            Dim xd As String

            xd1 = ceto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("ctltdt") = xd

            Dim dki
            dki = DateTime.Now

            Dim wd1 As String
            Dim wd As String

            wd1 = dki
            Dim strdate4() As String = wd1.Split("/"c)
            wd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

            wd = CDate(wd1)

            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd

            ecode = empcode.Text


            getchkval11(ecode, wd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
                    Try
                        'MyGlobal.Open_Con()
                        'MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("insert into emp_modified (empcode,dateofkeyin,printedby,dateeffective,transfer,promotion,confirmation,extensioncontract,termination,appointmentletter,resign,refno) values('" & empcode.Text & "',getdate(),'" & Session("empcode") & "','" & yd & "','N','N','N','Y','N','N','N','" & refno & "')", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet3()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("delete emp_appraisalnote where empcode = '" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        CEcont.Text = ""
                        cefrom.Text = ""
                        ceto.Text = ""
                        TextBox2.Text = ""
                        TextBox14.Text = ""
                        TextBox4.Text = ""
                        TextBox15.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""

                    Catch ex As SqlException
                        lblmsg.Text = ex.Message

                    End Try

                Else

                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & wd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet3()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("delete emp_appraisalnote where empcode = '" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        CEcont.Text = ""
                        cefrom.Text = ""
                        ceto.Text = ""
                        TextBox2.Text = ""
                        TextBox14.Text = ""
                        TextBox4.Text = ""
                        TextBox15.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""
                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If

    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If ptype.SelectedValue = "Contract Extension on PFP" Then

            Dim yd1 As String
            Dim yd As String

            yd1 = cepfpefffrom.Text.Trim
            Dim strdate() As String = yd1.Split("/"c)
            yd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            yd = CDate(yd1)
            Session("cteffdt") = yd


            Dim xd1 As String
            Dim xd As String

            xd1 = cepfpeffto.Text.Trim
            Dim strdate3() As String = xd1.Split("/"c)
            xd1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

            xd = CDate(xd1)
            Session("ctltdt") = xd

            Dim dki
            dki = DateTime.Now

            Dim wd1 As String
            Dim wd As String

            wd1 = dki
            Dim strdate4() As String = wd1.Split("/"c)
            wd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

            wd = CDate(wd1)

            Dim xxd1 As String
            Dim xxd As String
            Dim refno

            xxd1 = dki
            Dim strdate5() As String = xxd1.Split("/"c)
            xxd1 = strdate5(1) & strdate5(0)

            xxd = xxd1 & "/" & empcode.Text

            refno = xxd


            ecode = empcode.Text


            getchkval11(ecode, wd)
            If recstatus = True Then
                If dsdata.Tables(0).Rows.Count > 0 Then
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


                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        cepfpcontperiod.Text = ""
                        cepfpefffrom.Text = ""
                        cepfpeffto.Text = ""
                        cepfpletdt.Text = ""
                        TextBox8.Text = ""
                        TextBox16.Text = ""
                        TextBox9.Text = ""
                        TextBox17.Text = ""
                        TextBox10.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""

                    Catch ex As SqlException
                        lblmsg.Text = ex.Message

                    End Try

                Else

                    Try
                        MyGlobal.Open_Con()
                        MyGlobal.Con_Str()
                        Dim con As New SqlConnection(constr)
                        con.Open()
                        Cmd = New SqlCommand("update emp_modified set dateofkeyin = '" & wd & "', printedby = '" & Session("empcode") & "', dateeffective = '" & yd & "', extensionexpiry = '" & xd & "', transfer = 'N', promotion = 'N',confirmation = 'N',extensioncontract = 'Y',termination = 'N',appointmentletter = 'N',resign = 'N',refno = '" & refno & "'", con)
                        Cmd.ExecuteNonQuery()
                        lblmsg.Text = "Details Added"
                        getcontdet4()
                        Dim cmd1 As New SqlCommand
                        cmd1 = New SqlCommand("delete emp_appraisalnote where empcode = '" & empcode.Text & "'", con)
                        cmd1.ExecuteNonQuery()


                        empcode.Text = ""
                        ptype.SelectedValue = "-1"
                        cepfpcontperiod.Text = ""
                        cepfpefffrom.Text = ""
                        cepfpeffto.Text = ""
                        cepfpletdt.Text = ""
                        TextBox8.Text = ""
                        TextBox16.Text = ""
                        TextBox9.Text = ""
                        TextBox17.Text = ""
                        TextBox10.Text = ""
                        Label11.Text = ""
                        Label10.Text = ""
                        Label13.Text = ""

                    Catch ex As SqlException
                        lblmsg.Text = ex.Message
                        lblmsg.ForeColor = Drawing.Color.Green

                    End Try

                End If
            End If

        End If
    End Sub

End Class
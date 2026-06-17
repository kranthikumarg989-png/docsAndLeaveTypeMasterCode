Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class BTform
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim doj As Date
    Dim thisdate As Date
    Dim appno As String
    Dim btnum As String

    Dim USD, USDLimit
  
    Private Sub BTform_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        ' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (47)
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

        LoadDept()
        ' Session("_edept") = "9000"
        If Session("bteditnum") <> "" Then
            btnum = Session("bteditnum")
            EditBt(btnum)
            Session("btnum") = btnum
            lblappno.Text = btnum
        Else
            GetBtno()
            lblappno.Text = posid
            Session("btnum") = posid
        End If
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (47)
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

        MyApp.GetfiscalYear()
        GetEXR("USD")
        LblUSD.Text = "1RM = " & RecordId & " USD"
        USD = RecordId
        GetUSDLIMIT()
        USDLimit = RecordId
        ' MyGlobal.db_close()
        thisdate = DateTime.Now

    End Sub
    Public Sub EditBt(ByVal rno As String)
        GetBtInfo(btnum)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                txtpdate.Text = Format(Convert.ToDateTime(dr("fromdate")), "dd/MM/yy")
                txtrdate.Text = Format(Convert.ToDateTime(dr("todate")), "dd/MM/yy")
                lblduration.Text = dr("duration").ToString
                txtdetails.Text = dr("trip_details").ToString
                ddlttype.SelectedValue = dr("triptype").ToString
                txtdestination.Text = dr("destination").ToString

                If dr("purpose") Is System.DBNull.Value Then
                    txtpurpose.Visible = False
                Else
                    txtpurpose.Visible = True
                    txtpurpose.Text = dr("purpose").ToString
                    ddlpurpose.SelectedValue = "O"
                End If

                Dim colleague = dr("colleague_details").ToString

                rbdept.SelectedValue = dr("sharedept").ToString.Trim

                If dr("sharedept").ToString = "Y" Then
                    lstsharedept.Visible = True
                    Dim sharedept = dr("sharedepts").ToString
                Else
                    lstsharedept.Visible = False
                End If
                Dim customer = ""
                Dim supplier = ""

                If dr("customer_details") Is System.DBNull.Value Then
                    customer = ""
                Else
                    customer = dr("customer_details").ToString
                End If

                If dr("supplier_details") Is System.DBNull.Value Then
                    supplier = ""
                Else
                    supplier = dr("supplier_details").ToString
                End If
                If dr("othersupplier") Is System.DBNull.Value Or dr("othersupplier") = "" Then
                    txtnewsupp.Text = ""
                    txtnewsupp1.Text = ""
                    cbsupplier.Checked = False
                    txtnewsupp.Visible = False
                    txtnewsupp1.Visible = False
                Else
                    txtnewsupp.Visible = True
                    txtnewsupp1.Visible = True
                    txtnewsupp.Text = dr("othersupplier").ToString
                    txtnewsupp1.Text = dr("sdest").ToString
                    cbsupplier.Checked = True
                End If

                If dr("othercustomer") Is System.DBNull.Value Or dr("othercustomer") = "" Then
                    txtnewcust.Text = ""
                    txtnewcust1.Text = ""
                    cbcustomer.Checked = False
                    txtnewcust.Visible = False
                    txtnewcust1.Visible = False
                Else
                    txtnewcust.Visible = True
                    txtnewcust1.Visible = True
                    txtnewcust.Text = dr("othercustomer").ToString
                    txtnewcust1.Text = dr("cdest").ToString
                    cbcustomer.Checked = True
                End If

                If dr("contactperson") Is System.DBNull.Value Then
                    txtcontact.Text = ""
                Else
                    txtcontact.Text = dr("contactperson").ToString
                End If

                Dim advance

                If dr("advance_amount") Is System.DBNull.Value Then

                Else
                    advance = dr("advance_amount").ToString
                End If

                ddltransport.SelectedValue = dr("transport").ToString

                rdocar.SelectedValue = dr("companycar").ToString

                If dr("vehicleno") Is System.DBNull.Value Then

                Else
                    txtvehicle.Text = dr("vehicleno").ToString
                End If

                ddlplace.SelectedValue = dr("hostel").ToString

                If dr("others") Is System.DBNull.Value Then

                Else
                    txtotherplace.Text = dr("others").ToString
                End If

                If dr("contactno") Is System.DBNull.Value Then

                Else
                    txtpcontact.Text = dr("contactno").ToString
                End If

            End If
        Else
            lblmsg.Text = myerrormsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub
    Protected Sub txtrdate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtrdate.TextChanged
        If txtpdate.Text <> "" Then
            '  If IsDate(CDate(txtpdate.Text)) = True Then

            Dim fd1 As String
            fd1 = txtpdate.Text.Trim
            Dim strdate() As String = fd1.Split("/"c)
            fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            Dim fd As Date
            fd = CDate(fd1)

            Dim td1 As String
            td1 = txtrdate.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            Dim td As Date
            td = CDate(td1)

            Dim n
            n = DateDiff(DateInterval.Day, fd, td)
            If n >= 0 Then
                lblduration.Text = n + 1
                lblmsg.Text = ""
            Else
                lblmsg.Text = "'To Date' should always be greater than 'From Date'. Please select again"
                txtrdate.Text = ""
                lblduration.Text = ""
                txtrdate.Focus()
            End If
  
        End If
    End Sub

    Protected Sub txtpdate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpdate.TextChanged
        If txtrdate.Text <> "" Then
            Dim fd1 As String
            fd1 = txtpdate.Text.Trim
            Dim strdate() As String = fd1.Split("/"c)
            fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            Dim fd As Date
            fd = CDate(fd1)

            Dim td1 As String
            td1 = txtrdate.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            Dim td As Date
            td = CDate(td1)

            Dim n
            n = DateDiff(DateInterval.Day, fd, td)
            If n >= 0 Then
                lblduration.Text = n + 1
                lblmsg.Text = ""
            Else
                lblmsg.Text = "'To Date' should always be greater than 'From Date'. Please select again"
                txtrdate.Text = ""
                lblduration.Text = ""
                txtrdate.Focus()
            End If

        End If
    End Sub
    Protected Sub ddlpurpose_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlpurpose.SelectedIndexChanged
        Dim purpose = ddlpurpose.SelectedValue
        If purpose = "O" Then
            lblpurpose.Visible = True
            txtpurpose.Visible = True
        Else
            lblpurpose.Visible = False
            txtpurpose.Visible = False
        End If
    End Sub

    Protected Sub cbgp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbgp.CheckedChanged
        If cbgp.Checked = True Then
            lbltout.Visible = True
            ddlohr.Visible = True
            ddlomin.Visible = True
            ddloam.Visible = True
            lblin.Visible = True
            ddlihr.Visible = True
            ddlimin.Visible = True
            ddliam.Visible = True
        ElseIf cbgp.Checked = False Then
            lbltout.Visible = False
            ddlohr.Visible = False
            ddlomin.Visible = False
            ddloam.Visible = False
            lblin.Visible = False
            ddlihr.Visible = False
            ddlimin.Visible = False
            ddliam.Visible = False
        End If
    End Sub

    Protected Sub ddldept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldept.SelectedIndexChanged
        Dim dept = ddldept.SelectedValue
        LoadSect()
        Dim Sect = ddlsect.SelectedValue
        lstcolleague.Items.Clear()
        If dept <> "Select" And Sect = "Select" Then
            LoadColleague()
        ElseIf dept <> "Select" And Sect <> "Select" Then
            LoadColleagueBySect()
        End If
    End Sub
    Protected Sub ddlsect_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlsect.SelectedIndexChanged
        Dim dept = ddldept.SelectedValue
        Dim Sect = ddlsect.SelectedValue
        If Sect <> "Select" Then
            LoadColleagueBySect()
        End If
    End Sub
    Public Sub LoadColleague()
        lstcolleague.Items.Clear()
        Dim lintrowcount, i
        Dim emp
        ''''''''''''''''''''''''''''''''''''''''' Get employee details ''''''''''''''''''''' #2
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        DS = Open_Empmaster(Con, DAP, 2, "select empcode + '- ' + empname as empno , empcode from empmaster WHERE departmentcode='" & ddldept.SelectedValue & "'  and resigned = 'N'")
        If DS.Tables("emp").Rows.Count <> 0 Then
            lblmsg.Text = ""
            lstcolleague.DataSource = DS
            lstcolleague.DataMember = "emp"
            lstcolleague.DataValueField = "empcode"
            lstcolleague.DataTextField = "empno"
            lstcolleague.DataBind()
        Else
            lblmsg.Text = "Employee No.Not found"
        End If
        MyGlobal.db_close()
    End Sub
    Public Sub LoadColleagueBySect()
        lstcolleague.Items.Clear()
        ''''''''''''''''''''''''''''''''''''''''' Get employee details ''''''''''''''''''''' #2
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        DS = Open_Empmaster(Con, DAP, 2, "select empcode + '- ' + empname as empno , empcode from empmaster WHERE departmentcode='" & ddldept.SelectedValue & "' and sectioncode = '" & ddlsect.SelectedValue & "' and resigned = 'N'")
        If DS.Tables("emp").Rows.Count <> 0 Then
            lblmsg.Text = ""
            lstcolleague.DataSource = DS
            lstcolleague.DataMember = "emp"
            lstcolleague.DataValueField = "empcode"
            lstcolleague.DataTextField = "empno"
            lstcolleague.DataBind()
        Else
            lblmsg.Text = "Employee No.Not found"
        End If
        MyGlobal.db_close()
    End Sub
    Public Sub LoadDept()
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        DS = Open_Department(Con, DAP, 2, "select departmentcode + ' - ' + departmentname as dept,departmentcode from department order by departmentcode")
        ddldept.DataSource = DS
        ddldept.DataMember = "dept"

        ddldept.DataValueField = "departmentcode"
        ddldept.DataTextField = "dept"
        ddldept.DataBind()
        ddldept.Items.Add("Select")
        ddldept.SelectedValue = "Select"
        MyGlobal.db_close()

    End Sub

    Public Sub LoadSect()
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        DS = Open_Section(Con, DAP, 2, "select sectioncode + ' - ' + sectionname as sect,sectioncode from sectionmaster where departmentcode = '" & ddldept.SelectedValue & "' order by departmentcode")
        ddlsect.DataSource = DS
        ddlsect.DataMember = "sect"

        ddlsect.DataValueField = "sectioncode"
        ddlsect.DataTextField = "sect"
        ddlsect.DataBind()
        ddlsect.Items.Add("Select")
        ddlsect.SelectedValue = "Select"
        MyGlobal.db_close()
    End Sub
    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        ''''''''''''''''DATE FORMAT FOR BUSINESS TRIP '''''''''''''
        Dim fd1 As String
        fd1 = txtpdate.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)

        Dim td1 As String
        td1 = txtrdate.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)
        ''''''''''''''' GET SELECTED COLLEAGUE '''''''''''''''''
        Dim a
        Dim Colleague = ""
        For a = 0 To lstSelcolleague.Items.Count - 1
            Colleague = Colleague & lstSelcolleague.Items(a).Value & ","
        Next
        ''''''''''''''  GET SHARE DEPT '''''''''''''''''''''''''
        Dim B
        Dim Sharedept = ""
        Dim deptcount = 0
        If rbdept.SelectedValue = "Y" Then
            For B = 0 To lstsharedept.Items.Count - 1
                If lstsharedept.Items(B).Selected Then
                    Sharedept = Sharedept & lstsharedept.Items(B).Value & ","
                    deptcount = deptcount + 1
                End If
            Next
        End If
        ''''''''''''' GET SEL CUSTOMER AND SUPPLIER '''''''''''''
        Dim C
        Dim Supplier = ""
        Dim suppcount = 0
        For C = 0 To lstsupplier.Items.Count - 1
            If lstsupplier.Items(C).Selected Then
                Supplier = Supplier & lstsupplier.Items(C).Value & ","
                suppcount = suppcount + 1
            End If
        Next

        Dim D
        Dim Customer = ""
        Dim custcount = 0
        For D = 0 To lstcustomer.Items.Count - 1
            If lstcustomer.Items(D).Selected Then
                Customer = Customer & lstcustomer.Items(D).Value & ","
                custcount = custcount + 1
            End If
        Next

        Dim F
        Dim Advance = ""
        If txtadvance.Items.Count = 0 Then
            'lblmsg.Text = "Please Key in Advance Amount"
            'Exit Sub
            Advance = 0
        Else
            For F = 0 To txtadvance.Items.Count - 1
                Advance = Advance & txtadvance.Items(F).Value & ","
            Next
        End If


        If ddlpurpose.SelectedValue = "O" And txtpurpose.Text = "" Then
            lblmsg.Text = "Key in the purpose of Trip"
            Exit Sub
        Else
            lblmsg.Text = ""
        End If
        If rbdept.SelectedValue = "Y" And lstsharedept.SelectedIndex = "-1" Then
            lblmsg.Text = "Select atleast one share Dept"
            Exit Sub
        Else
            lblmsg.Text = ""
        End If
        If cbcustomer.Checked = True Then
            If txtnewcust.Text = "" Or txtnewcust1.Text = "" Then
                lblmsg.Text = "Key in Non-Registered customer details"
                Exit Sub
            Else
                lblmsg.Text = ""
            End If
        Else
            lblmsg.Text = ""
        End If
        If cbsupplier.Checked = True Then
            If txtnewsupp.Text = "" Or txtnewsupp1.Text = "" Then
                lblmsg.Text = "Key in Non-Registered supplier details"
                Exit Sub
            Else
                lblmsg.Text = ""
            End If
        Else
            lblmsg.Text = ""
        End If
        Dim status
        Dim Btpurpose
        If ddlpurpose.SelectedValue = "O" Then
            status = "SCHEDULED"
            Btpurpose = txtpurpose.Text.Trim
        Else
            status = "NV"
            Btpurpose = ddlpurpose.SelectedValue
        End If


        If ddlpurpose.SelectedValue = "customer" And custcount = "0" And cbcustomer.Checked = False Then
            lblmsg.Text = "Select atleast one customer"
            Exit Sub
        End If

        If ddlpurpose.SelectedValue = "supplier" And suppcount = "0" And cbsupplier.Checked = False Then
            lblmsg.Text = "Select atleast one supplier"
            Exit Sub
        End If

        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Call MyGlobal.dbSp_open("HRMIS_BT_INS_BTFORM")

            Cmd.Parameters.AddWithValue("@rno", lblappno.Text.Trim)
            Cmd.Parameters.AddWithValue("@ecode", Session("empcode"))
            Cmd.Parameters.AddWithValue("@dpt", Session("_edept"))
            Cmd.Parameters.AddWithValue("@adate", thisdate)
            Cmd.Parameters.AddWithValue("@from", fd)
            Cmd.Parameters.AddWithValue("@to", td)
            Cmd.Parameters.AddWithValue("@duration", lblduration.Text.Trim)
            Cmd.Parameters.AddWithValue("@purpose", Btpurpose)
            Cmd.Parameters.AddWithValue("@ttype", ddlttype.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@tdetails", txtdetails.Text.Trim)
            Cmd.Parameters.AddWithValue("@clgdetails ", Colleague)
            Cmd.Parameters.AddWithValue("@clgno", lblselect.Text.Trim)
            Cmd.Parameters.AddWithValue("@sdept", rbdept.SelectedValue)
            Cmd.Parameters.AddWithValue("@sdepts", Sharedept)
            Cmd.Parameters.AddWithValue("@cusdetails", Customer)
            Cmd.Parameters.AddWithValue("@supdetails", Supplier)
            Cmd.Parameters.AddWithValue("@contact", txtcontact.Text.Trim)
            Cmd.Parameters.AddWithValue("@custno", lblnocust.Text.Trim)
            Cmd.Parameters.AddWithValue("@osupplier", txtnewsupp.Text.Trim)
            Cmd.Parameters.AddWithValue("@ocustomer", txtnewcust.Text.Trim)
            Cmd.Parameters.AddWithValue("@advance", Advance)
            Cmd.Parameters.AddWithValue("@transport", ddltransport.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@vno", txtvehicle.Text.Trim)
            Cmd.Parameters.AddWithValue("@hostel", ddlplace.SelectedValue.Trim)
            Cmd.Parameters.AddWithValue("@others", txtotherplace.Text.Trim)
            Cmd.Parameters.AddWithValue("@contactno", txtpcontact.Text.Trim)
            Cmd.Parameters.AddWithValue("@status", status)
            Cmd.Parameters.AddWithValue("@car", rdocar.SelectedValue)
            Cmd.Parameters.AddWithValue("@odest", txtdestination.Text.Trim)
            Cmd.Parameters.AddWithValue("@cdest", txtnewcust1.Text.Trim)
            Cmd.Parameters.AddWithValue("@sdest", txtnewsupp1.Text.Trim)
            Cmd.Parameters.AddWithValue("@total", lbltotamt.Text.Trim)
            Cmd.ExecuteNonQuery()

            ''''APPLY GATEPASS
            If cbgp.Checked = True Then
                GetGatePassID()
                If posid < 0 Then
                    ID = 1
                Else
                    ID = posid + 1
                End If
                Dim intime As String
                Dim outtime As String
                Dim purpose
                purpose = "BT REF " & lblappno.Text & "-" & txtpurpose.Text
                intime = ddlihr.SelectedValue + ":" + ddlimin.SelectedValue + " " + Convert.ToString(ddliam.SelectedValue)
                outtime = ddlohr.SelectedValue + ":" + ddlomin.SelectedValue + " " + Convert.ToString(ddloam.SelectedValue)
                'InsertGatePass(ID, "OFFICIAL", _eid, thisdate, txtdestination.Text.Trim, "--", fd, txtvehicle.Text, purpose, intime, outtime)
                InsertGatePass(ID, "OFFICIAL", Session("empcode"), thisdate, txtdestination.Text.Trim, "--", fd, txtvehicle.Text, purpose, intime, outtime)

                If recstatus = True Then
                    lblmsg.Text = "Business Trip and GatePass scheduled"
                Else
                    lblmsg.Text = myerrormsg & "Business Trip scheduled"
                End If
            Else
                lblmsg.Text = "Business Trip scheduled"
            End If

            If ddlpurpose.SelectedValue <> "O" Then
                ''''''''''''' store data to hrmis_bt_customervisitdetails 
                Dim C1
                Dim Supplier1 = ""
                Dim supadrs
                For C1 = 0 To lstsupplier.Items.Count - 1
                    If lstsupplier.Items(C1).Selected Then
                        Supplier1 = lstsupplier.Items(C1).Value
                        GetSuppDestination(Supplier1)
                        If recstatus = True Then
                            Dim dr As DataRow
                            If dsdata.Tables(0).Rows.Count > 0 Then
                                dr = dsdata.Tables(0).Rows(0)
                                supadrs = dr("address").ToString
                                InsertCustomerDetails(Supplier1, lblappno.Text.Trim, supadrs)
                            End If
                        Else
                            lblmsg.Text = myerrormsg
                        End If
                    End If
                Next

                Dim D1
                Dim Customer1 = ""
                Dim custadrs
                For D1 = 0 To lstcustomer.Items.Count - 1
                    If lstcustomer.Items(D1).Selected Then
                        Customer1 = lstcustomer.Items(D1).Value
                        GetCustDestination(Customer1)
                        If recstatus = True Then
                            Dim dr1 As DataRow
                            If dsdata.Tables(0).Rows.Count > 0 Then
                                dr1 = dsdata.Tables(0).Rows(0)
                                custadrs = dr1("address").ToString
                                InsertCustomerDetails(Customer1, lblappno.Text.Trim, custadrs)
                            End If
                        Else
                            lblmsg.Text = myerrormsg
                            lblmsg.ForeColor = Drawing.Color.Red
                        End If
                    End If
                Next
                '''''''''' insert Non registered customer and supplier
                If cbcustomer.Checked = True Then
                    InsertCustomerDetails(txtnewcust.Text.Trim, lblappno.Text.Trim, txtnewcust1.Text.Trim)
                End If
                If cbsupplier.Checked = True Then
                    InsertCustomerDetails(txtnewsupp.Text.Trim, lblappno.Text.Trim, txtnewsupp1.Text.Trim)
                End If
                clearcontrols()
                Response.Redirect("btform2.aspx")
            End If

            Response.Redirect("~/hrmis/business trip/reports/btprintform.aspx?rno=" & lblappno.Text & "")
            clearcontrols()
            ' Response.Redirect("btselfstatus.aspx")
            Call MyGlobal.db_close()
        Catch ex As Exception
            lblmsg.Text = ex.Message
            lblmsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End Try
    End Sub
    Public Sub InsertCustomerDetails(ByVal visitor As String, ByVal rno As Integer, ByVal adrs As String)
        Try
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            Call MyGlobal.dbSp_open("HRMIS_BT_tempvisitor")
            Cmd.Parameters.AddWithValue("@visitor", visitor)
            Cmd.Parameters.AddWithValue("@btrno", rno)
            Cmd.Parameters.AddWithValue("@dest", adrs)
            Cmd.ExecuteNonQuery()
            Call MyGlobal.db_close()
        Catch ex As Exception
            lblmsg.Text = ex.Message & "Customer/supplier Details cannot store"
            lblmsg.ForeColor = Drawing.Color.Red
            Exit Sub
        End Try
    End Sub
    Protected Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click
        If lstcolleague.SelectedIndex = -1 Then
            Exit Sub
        End If
        Dim i
        Dim count
        '''''''''''''' To add items to second listbox
        For i = 0 To lstcolleague.Items.Count - 1
            If lstcolleague.Items(i).Selected Then
                Dim item As New ListItem()
                item.Value = lstcolleague.Items(i).Value
                item.Text = lstcolleague.Items(i).Text
                lstSelcolleague.Items.Add(item)
                ' lstcolleague.Items.Remove(item)
            End If
        Next
        '''''''''''''''To remove items from first list box
        For i = 0 To lstSelcolleague.Items.Count - 1
            Dim item As New ListItem()
            item.Value = lstSelcolleague.Items(i).Value
            item.Text = lstSelcolleague.Items(i).Text
            lstcolleague.Items.Remove(item)
        Next
        Label2.Visible = True
        lblselect.Text = lstSelcolleague.Items.Count
    End Sub

    Protected Sub btnremove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnremove.Click
        If lstSelcolleague.SelectedIndex = -1 Then
            Exit Sub
        End If
        Dim i
        Dim count
        '''''''''''''''to add items to first list box
        For i = 0 To lstSelcolleague.Items.Count - 1
            If lstSelcolleague.Items(i).Selected Then
                Dim item As New ListItem()
                item.Value = lstSelcolleague.Items(i).Value
                item.Text = lstSelcolleague.Items(i).Text
                lstcolleague.Items.Add(item)
                'lstSelcolleague.Items.Remove(item)
                count = count + 1
            End If
        Next
        Dim tot = lstSelcolleague.Items.Count - count
        Label2.Visible = True
        lblselect.Text = tot
        '''''''''''''' To remove items from second listbox
        For i = 0 To lstcolleague.Items.Count - 1
            Dim item As New ListItem()
            item.Value = lstcolleague.Items(i).Value
            item.Text = lstcolleague.Items(i).Text
            lstSelcolleague.Items.Remove(item)
        Next
    End Sub

    Protected Sub rbdept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbdept.SelectedIndexChanged
        If rbdept.SelectedValue = "Y" Then
            lblshare.Visible = True
            lstsharedept.Visible = True
        Else
            lblshare.Visible = False
            lstsharedept.Visible = False
        End If
        lstsharedept.Focus()
    End Sub

    Protected Sub cbcustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbcustomer.CheckedChanged
        If cbcustomer.Checked = True Then
            lblcust.Visible = True
            txtnewcust.Visible = True
            txtnewcust1.Visible = True
            txtnewcust.Focus()

        ElseIf cbcustomer.Checked = False Then
            lblcust.Visible = False
            txtnewcust.Visible = False
            txtnewcust1.Visible = False
            txtcontact.Focus()
        End If
    End Sub

    Protected Sub cbsupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbsupplier.CheckedChanged
        If cbsupplier.Checked = True Then
            lblsupp.Visible = True
            txtnewsupp.Visible = True
            txtnewsupp1.Visible = True
            txtnewsupp.Focus()
        ElseIf cbsupplier.Checked = False Then
            lblsupp.Visible = False
            txtnewsupp.Visible = False
            txtnewsupp1.Visible = False
            txtcontact.Focus()
        End If
    End Sub
    Protected Sub ddlcurrency_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddlcurrency.SelectedIndexChanged
        If txtamt.Text.Trim = "" Then
            Exit Sub
        End If
        Dim amt = txtamt.Text.Trim
        Dim currency = ddlcurrency.SelectedValue
        Dim amtrqd
        Dim lstadv
        Dim TotUsd, CurUsd, TotRM, CurRM
        CurRM = lbltotamt.Text.Trim
        CurUsd = lblcurusd.Text.Trim
        If CurUsd = "" Then
            CurUsd = "0"
        End If
        amtrqd = amt & " " & currency
        GetEXR(currency)
        '  lstadv = txtadvance.Text.Trim & vbCrLf & "$ " & amtrqd & " (EXR= " & RecordId & ")"
        lstadv = "$ " & amtrqd & " (EXR= " & System.Math.Round(RecordId, 4) & " )"
        txtadvance.Items.Add(lstadv)
        txtadvance.DataValueField = amtrqd
        txtadvance.DataTextField = lstadv
        txtadvance.Focus()

        TotRM = CurRM + (amt * RecordId)
        TotUsd = TotRM / USD
        TotUsd = CurUsd + TotUsd

        lbltotamt.Text = System.Math.Round(TotRM, 2)
        If TotUsd > USDLimit Then
            lblusdmsg.Text = " Exceeding the Max.USD Limit !!!"
        Else
            lblusdmsg.Text = ""
        End If

    End Sub
    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        Dim i
        Dim SelVal
        Dim myarray
        Dim USDCalc, RMcalc
        If txtadvance.SelectedIndex = -1 Then
            Exit Sub
        End If
        For i = 0 To txtadvance.Items.Count - 1
            If txtadvance.Items(i).Selected = True Then
                SelVal = txtadvance.Items(i).Value
            End If
        Next
        txtadvance.Items.Remove(SelVal)
        txtadvance.Focus()
        ''''' CALCULATE USD VALUE
        myarray = Split(SelVal, " ")
        RMcalc = myarray(1) * myarray(4)
        USDCalc = RMcalc / USD
        RMcalc = lbltotamt.Text - RMcalc
        If RMcalc < 0 Then
            RMcalc = 0
        End If
        lbltotamt.Text = System.Math.Round(RMcalc, 2)
        If USDCalc > USDLimit Then
            lblusdmsg.Text = " Exceeding the Max.USD Limit !!!"
        Else
            lblusdmsg.Text = ""
        End If
    End Sub
    Protected Sub lstcustomer_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstcustomer.SelectedIndexChanged
        If lstcustomer.SelectedIndex = -1 Then
            Exit Sub
        End If
        Dim I
        Dim j = 0
        For I = 0 To lstcustomer.Items.Count - 1
            If lstcustomer.Items(I).Selected Then
                j = j + 1
                lblnocust.Text = j
            End If
        Next
        Label1.Visible = True
        lstcustomer.Focus()
    End Sub
    Protected Sub txtnewcust_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnewcust.TextChanged
        Label1.Visible = True
        If lblnocust.Text = "" Then
            lblnocust.Text = "0"
        End If
        lblnocust.Text = lblnocust.Text + 1
    End Sub
    Public Sub clearcontrols()

        txtpdate.Text = ""
        txtrdate.Text = ""
        lblduration.Text = ""
        txtdetails.Text = ""
        txtdestination.Text = ""
        ddlttype.SelectedValue = "-1"
        cbgp.Checked = False
        lstcustomer.SelectedIndex = -1
        lstsupplier.SelectedIndex = -1
        ddldept.SelectedValue = "Select"
        '  ddlsect.SelectedValue = "Select"

        rbdept.SelectedValue = "N"
        cbsupplier.Checked = False
        cbcustomer.Checked = False
        txtnewsupp.Text = ""
        txtnewsupp1.Text = ""
        txtnewcust.Text = ""
        txtnewcust1.Text = ""
        txtnewsupp.Visible = False
        txtnewsupp1.Visible = False
        txtnewcust.Visible = False
        txtnewcust1.Visible = False

        txtamt.Text = ""
        txtadvance.Items.Clear()
        txtcontact.Text = ""
        txtvehicle.Text = ""
        ddltransport.SelectedValue = "-1"
        ddlplace.SelectedValue = "-1"
        txtotherplace.Text = ""
        txtpcontact.Text = ""
        LblUSD.Text = ""

        lstcolleague.Items.Clear()
        lstSelcolleague.Items.Clear()
        lstsharedept.SelectedIndex = -1
        Label1.Visible = False
        lblnocust.Text = ""
        Label2.Visible = False
        lblselect.Text = ""
        lblappno.Text = ""

    End Sub
End Class
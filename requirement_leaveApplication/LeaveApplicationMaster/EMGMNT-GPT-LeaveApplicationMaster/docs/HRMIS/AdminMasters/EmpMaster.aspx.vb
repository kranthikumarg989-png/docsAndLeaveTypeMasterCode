Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class EmpMaster1
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications

    Private Sub EmpMaster1_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        'Session("empcode") = "014543"
        'Session("_edept ") = "9000"
        'Session("dept") = "9000"

        _eid = Session("empcode")
        _ename = Session("_ename ")
        _edept = Session("_edept ")

        '_eid = "014543"
        '_ename = "Sathya Vamshi Anigalla"
        '_edept = "9000"

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        MyApp.GetfiscalYear()
        GetMaxEmpID()
        Dim id, rno As Integer

        If posid < 0 Then
            id = 1
        Else
            id = posid + 1
        End If
        txtempcode.Text = Formatempcode(id)
        txtempcode.Enabled = False
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (18)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
    End Sub

    Protected Sub btnempsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnempsave.Click
        '##Check Old EmpCode When Transfer Emp from One Company to Another Company
        If RbtnTEmpYes.Checked = True Then
            If TxtOldEmpCode.Text.Trim.Equals("") Then
                lblmsg.Text = "Please Enter Old Employee Code"
                Exit Sub
            End If

            Dim SqlDs1 As New DataSet
            SqlDs1 = New DataSet()
            SqlDs1 = CheckOldEmpCode()

            Try
                If SqlDs1.Tables(0).Rows.Count >= 1 Then
                    lblmsg.Text = "Valid EmpCode"
                Else
                    lblmsg.Text = "Old EmpCode is not a valid EmpCode! Please Check!"
                    Exit Sub
                End If
            Catch ex As Exception
                lblmsg.Text = "Please Select Company Name!"
                Exit Sub
            End Try
        End If
        'Check Old EmpCode When Transfer Emp from One Company to Another Company##

        SaveEMpmaster(txtempcode.Text.Trim)

        Session("emptxt") = txtempcode.Text
        'MsgBox(Session("emptxt"))
        Response.Redirect("EmpmasterPrintRpt.aspx")

    End Sub

    Private Function Formatempcode(ByVal uid As Integer)
        Dim EmpCode As String = ""
        If Len(Trim(uid)) = 1 Then
            EmpCode = "00000" & uid
        ElseIf Len(Trim(uid)) = 2 Then
            EmpCode = "0000" & uid
        ElseIf Len(Trim(uid)) = 3 Then
            EmpCode = "000" & uid
        ElseIf Len(Trim(uid)) = 4 Then
            EmpCode = "00" & uid
        ElseIf Len(Trim(uid)) = 5 Then
            EmpCode = "0" & uid
        ElseIf Len(Trim(uid)) = 6 Then
            EmpCode = uid
        End If
        Return EmpCode
    End Function
    Private Sub btnempedit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnempedit.Click
        CLrEmpMaster()

        txtempcode.Text = ""
        txtempcode.Enabled = True
    End Sub
    Private Sub emp_details()
        Dim ecode
        Dim masterempcode
        Dim dr1 As DataRow
        ecode = txtempcode.Text
        Getcedata(ecode)
        If recstatus = True Then
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr1 = dsdata.Tables(0).Rows(0)
                masterempcode = dr1("empcode").ToString
            Else
                lblmsg.Text = MyerrorMsg & " EmployeeCode doesnot Exist!!"
                lblmsg.ForeColor = Drawing.Color.Red
                ' MessageBox("EmployeeCode doesnot Exist!!")
            End If
        End If
        ' CLrEmpMaster()
        txtempcode.Enabled = "false"
        Exit Sub
    End Sub
    Private Sub txtempcode_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtempcode.TextChanged
        imgemp.ImageUrl = ""
        TextBox1.Text = ""

        emp_details()

        GetEmpVehino(txtempcode.Text.Trim)
        Dim fn As String
        fn = txtempcode.Text.Trim
        fn = fn + ".jpg"
        fn = "~/emppic/" & fn

        imgemp.ImageUrl = Trim(fn)

        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                txtempname.Text = dr("empname").ToString
                edesignation.SelectedValue = dr("designation").ToString
                deseccode.SelectedValue = dr("sectioncode").ToString
                edeptcode.SelectedValue = dr("departmentcode").ToString
                decategory.Text = dr("category").ToString
                txtempdoj.Text = Format(Convert.ToDateTime(dr("dateofjoin")), "dd/MM/yy")
                demptype.SelectedValue = dr("emptype").ToString
                If Not dr("contract") Is System.DBNull.Value Then
                    txtempcontract.Text = dr("contract").ToString
                End If
                If Not dr("stayinhostel") Is System.DBNull.Value Then
                    rdhostel.SelectedValue = dr("stayinhostel").ToString
                End If
                If Len(Trim(dr("hostelname") & "")) <> 0 Then
                    dehosname.SelectedValue = dr("hostelname").ToString
                End If
                If Len(Trim(dr("routename") & "")) <> 0 Then
                    deroute.SelectedValue = dr("routename").ToString
                End If
                If Len(Trim(dr("areaname") & "")) <> 0 Then
                    deArea.SelectedValue = dr("areaname").ToString
                End If
                If Len(Trim(dr("transportneeded") & "")) <> 0 Then
                    rdtransport.SelectedValue = dr("transportneeded").ToString
                End If
                rdforeign.SelectedValue = dr("foreignemp").ToString
                If Not dr("passportno") Is System.DBNull.Value Then
                    txtpassport.Text = dr("passportno").ToString
                End If
                If Not dr("icno") Is System.DBNull.Value Then
                    txtoldic.Text = dr("icno").ToString
                End If
                If Not dr("newicno") Is System.DBNull.Value Then
                    txtnewic.Text = dr("newicno").ToString
                End If
                txtaccount.Text = dr("accountno").ToString
                If Len(Trim(dr("bank") & "")) <> 0 Then
                    Debank.SelectedValue = dr("bank").ToString
                End If

                If Not dr("epf") Is System.DBNull.Value Then
                    txtepf.Text = dr("epf").ToString
                End If
                If Not dr("sosco") Is System.DBNull.Value Then
                    txtsosco.Text = dr("sosco").ToString
                End If
                Txtdob.Text = Format(Convert.ToDateTime(dr("dateofbirth")), "dd/MM/yy")

                If Not dr("dateofservice") Is System.DBNull.Value Then
                    txtdos.Text = Format(Convert.ToDateTime(dr("dateofservice")), "dd/MM/yy")

                End If
                
                If Len(Trim(dr("nationality") & "")) <> 0 Then
                    denation.SelectedValue = dr("nationality").ToString.Trim
                End If
                If Len(Trim(dr("religion") & "")) <> 0 Then
                    Dereligion.SelectedValue = dr("religion").ToString
                End If
                If Len(Trim(dr("race") & "")) <> 0 Then
                    derace.SelectedValue = dr("race").ToString
                End If
                Rdgender.SelectedValue = dr("sex").ToString
                txtblood.Text = dr("bloodgroup").ToString
                demarital.SelectedValue = dr("maritalstatus").ToString
                If Not dr("noofchildren") Is System.DBNull.Value Then
                    txtchildren.Text = dr("noofchildren").ToString
                End If
                If Not dr("address1") Is System.DBNull.Value Then
                    txtadrs1.Text = dr("address1").ToString
                End If
                If Not dr("address2") Is System.DBNull.Value Then
                    Txtadrs2.Text = dr("address2").ToString
                End If
                If Not dr("address3") Is System.DBNull.Value Then
                    Txtadrs3.Text = dr("address3").ToString
                End If
                If Not dr("postalcode") Is System.DBNull.Value Then
                    Txtposcode.Text = dr("postalcode")
                End If
                If Not dr("pphone") Is System.DBNull.Value Then
                    Txtphone.Text = dr("pphone").ToString
                End If
                If Not dr("php") Is System.DBNull.Value Then
                    Txthp.Text = dr("php").ToString
                End If
                If Not dr("email") Is System.DBNull.Value Then
                    txtemail.Text = dr("email").ToString
                End If
                dElevel.SelectedValue = dr("edulevel").ToString.Trim
                If Not dr("workingexp") Is System.DBNull.Value Then
                    txteduwork.Text = dr("workingexp").ToString
                End If
                If Not dr("others") Is System.DBNull.Value Then
                    txteduothers.Text = dr("others").ToString
                End If
                If Not dr("yearofexp") Is System.DBNull.Value Then
                    txteduexp.Text = dr("yearofexp").ToString
                End If
                rdcar.SelectedValue = dr("carpass").ToString
                rdnb.SelectedValue = dr("computerpass").ToString
                rdhp.SelectedValue = dr("hppass").ToString
                rdlogin.SelectedValue = dr("remotelogin").ToString

                If Not dr("EmergencyContactPerson").ToString Is System.DBNull.Value Then
                    TxtContactPerson.Text = dr("EmergencyContactPerson").ToString
                End If


                If Not dr("EmergencyAddress").ToString Is System.DBNull.Value Then
                    TxtContactAddress.Text = dr("EmergencyAddress").ToString
                End If

                If Not dr("EmergencyTelephone").ToString Is System.DBNull.Value Then
                    TxtContactNo.Text = dr("EmergencyTelephone").ToString
                End If

                If Not dr("ImageURL").ToString Is System.DBNull.Value Then
                    imgemp.ImageUrl = dr("ImageURL").ToString
                    Session("imageurl") = dr("ImageURL").ToString
                End If

            End If
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
        GetUniformDet(txtempcode.Text.Trim)
        If recstatus = True Then
            Dim dr As DataRow
            If dsdata.Tables(0).Rows.Count > 0 Then
                dr = dsdata.Tables(0).Rows(0)
                If Not dr("trousers") Is System.DBNull.Value Then
                    Txttrousers.Text = dr("trousers").ToString
                End If
                If Not dr("shirt") Is System.DBNull.Value Then
                    txtshirt.Text = dr("shirt").ToString
                End If
                If Not dr("shoe") Is System.DBNull.Value Then
                    txtshoes.Text = dr("shoe").ToString
                End If
                If Not dr("tno") Is System.DBNull.Value Then
                    txtnotrousers.Text = dr("tno").ToString
                End If
                If Not dr("shino") Is System.DBNull.Value Then
                    txtnoshirt.Text = dr("shino").ToString
                End If
                If Not dr("shono") Is System.DBNull.Value Then
                    txtnoshoes.Text = dr("shono").ToString
                End If
                If Not dr("jackno") Is System.DBNull.Value Then
                    txtnojacket.Text = dr("jackno").ToString
                End If
                If Not dr("capno") Is System.DBNull.Value Then
                    txtnocap.Text = dr("capno").ToString
                End If
                If Not dr("dategiven") Is System.DBNull.Value Then
                    txtdou.Text = Format(Convert.ToDateTime(dr("dategiven")), "dd/MM/yy")
                End If




            End If
        Else
            lblmsg.Text = MyerrorMsg
            lblmsg.ForeColor = Drawing.Color.Red
        End If
    End Sub
    Public Sub SaveEMpmaster(ByVal emp As String)
        'Dim fd1 As String
        'fd1 = txtempdoj.Text.Trim
        'Dim strdate() As String = fd1.Split("/"c)
        'fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        'Dim fd As Date
        'fd = CDate(fd1)   '''' for date of join

        'Dim td1 As String
        'td1 = Txtdob.Text.Trim
        'Dim strdate2() As String = td1.Split("/"c)
        'td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        'Dim td As Date
        'td = CDate(td1)  '''' for date of birth

        'Dim ud1 As String
        'ud1 = txtdou.Text.Trim
        'Dim strdate3() As String = ud1.Split("/"c)
        'ud1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        'Dim ud As Date
        'ud = CDate(ud1)  '''' for date of birth

        'InsertempMaster(txtempcode.Text.Trim, txtempname.Text.Trim, edesignation.SelectedValue.Trim, deseccode.SelectedValue.Trim, edeptcode.SelectedValue.Trim, txtemail.Text.Trim, decategory.SelectedValue.Trim, fd, demptype.SelectedValue.Trim, Rdgender.SelectedValue.Trim, rdforeign.SelectedValue.Trim, td, txtoldic.Text.Trim, txtnewic.Text.Trim, txtpassport.Text.Trim, txtadrs1.Text.Trim, Txtadrs2.Text.Trim, Txtadrs3.Text.Trim, Txtposcode.Text.Trim, rdhostel.SelectedValue.Trim, rdtransport.SelectedValue.Trim, deArea.SelectedValue.Trim, deroute.SelectedValue.Trim, derace.SelectedValue.Trim, Dereligion.SelectedValue.Trim, Txtphone.Text, Txthp.Text.Trim, txtblood.Text.Trim, denation.SelectedValue.Trim, demarital.SelectedValue.Trim, txtchildren.Text.Trim, txtepf.Text.Trim, txtsosco.Text.Trim, dElevel.SelectedValue.Trim, txteduwork.Text.Trim, txteduothers.Text.Trim, txtempcontract.Text.Trim, dehosname.SelectedValue.Trim, txtaccount.Text.Trim, Debank.SelectedValue.Trim, txteduexp.Text.Trim, _eid, rdhp.SelectedValue.Trim, rdnb.SelectedValue.Trim, rdcar.SelectedValue.Trim, rdlogin.SelectedValue.Trim)
        'If recstatus = True Then
        '    InsertUnifrom(txtempcode.Text.Trim, Txttrousers.Text.Trim, txtshirt.Text.Trim, txtshoes.Text.Trim, txtnotrousers.Text.Trim, txtnoshirt.Text.Trim, txtnoshoes.Text.Trim, txtnojacket.Text.Trim, txtnocap.Text.Trim, ud)
        '    If recstatus = True Then
        '        MessageBox("Record Saved successfully")
        '    Else
        '        lblmsg.Text = MyerrorMsg & " Uniform Record Not Saved !!"
        '        lblmsg.ForeColor = Drawing.Color.Red
        '        MessageBox("Unifrom records Not Saved")
        '    End If
        '    CLrEmpMaster()
        'ElseIf recstatus = False Then
        '    lblmsg.Text = MyerrorMsg & " Sorry!! Record Not Saved !!"
        '    lblmsg.ForeColor = Drawing.Color.Red
        '    'MessageBox("Sorry!! Record Not Saved !!")
        'End If

        Dim fd1 As String
        fd1 = txtempdoj.Text.Trim
        Dim strdate() As String = fd1.Split("/"c)
        fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

        Dim fd As Date
        fd = CDate(fd1)   '''' for date of join

        Dim td1 As String
        td1 = Txtdob.Text.Trim
        Dim strdate2() As String = td1.Split("/"c)
        td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

        Dim td As Date
        td = CDate(td1)  '''' for date of birth

        Dim ud1 As String
        ud1 = txtdou.Text.Trim
        Dim strdate3() As String = ud1.Split("/"c)
        ud1 = strdate3(1) & "/" & strdate3(0) & "/" & strdate3(2)

        Dim ud As Date
        ud = CDate(ud1)  '''' for uniform

        Dim sd1 As String
        sd1 = txtdos.Text.Trim
        Dim strdate4() As String = sd1.Split("/"c)
        sd1 = strdate4(1) & "/" & strdate4(0) & "/" & strdate4(2)

        Dim sd As Date
        sd = CDate(sd1)  '''' for date of service


        InsertempMaster(txtempcode.Text.Trim, txtempname.Text.Trim, edesignation.SelectedValue.Trim, deseccode.SelectedValue.Trim, edeptcode.SelectedValue.Trim, txtemail.Text.Trim, decategory.SelectedValue.Trim, fd, demptype.SelectedValue.Trim, Rdgender.SelectedValue.Trim, rdforeign.SelectedValue.Trim, td, txtoldic.Text.Trim, txtnewic.Text.Trim, txtpassport.Text.Trim, txtadrs1.Text.Trim, Txtadrs2.Text.Trim, Txtadrs3.Text.Trim, Txtposcode.Text.Trim, rdhostel.SelectedValue.Trim, rdtransport.SelectedValue.Trim, deArea.SelectedValue.Trim, deroute.SelectedValue.Trim, derace.SelectedValue.Trim, Dereligion.SelectedValue.Trim, Txtphone.Text, Txthp.Text.Trim, txtblood.Text.Trim, denation.SelectedValue.Trim, demarital.SelectedValue.Trim, txtchildren.Text.Trim, txtepf.Text.Trim, txtsosco.Text.Trim, dElevel.SelectedValue.Trim, txteduwork.Text.Trim, txteduothers.Text.Trim, txtempcontract.Text.Trim, dehosname.SelectedValue.Trim, txtaccount.Text.Trim, Debank.SelectedValue.Trim, txteduexp.Text.Trim, _eid, rdhp.SelectedValue.Trim, rdnb.SelectedValue.Trim, rdcar.SelectedValue.Trim, rdlogin.SelectedValue.Trim, sd, TxtContactPerson.Text, TxtContactAddress.Text, TxtContactNo.Text, Session("imageurl"))
        If recstatus = True Then
            InsertUnifrom(txtempcode.Text.Trim, Txttrousers.Text.Trim, txtshirt.Text.Trim, txtshoes.Text.Trim, txtnotrousers.Text.Trim, txtnoshirt.Text.Trim, txtnoshoes.Text.Trim, txtnojacket.Text.Trim, txtnocap.Text.Trim, ud)

            '##Save Cn Remarks If Emp Info Transfer from one Company to Another Company
            If RbtnTEmpYes.Checked = True Then
                UpdateTransferredEmpCode()
            End If
            'Save Cn Remarks If Emp Info Transfer from one Company to Another Company##

            Session("emptxt") = txtempcode.Text

            Response.Redirect("EmpmasterPrintRpt.aspx")

            '            Response.Write("<script>window.location.href='EmpmasterPrintRpt.aspx';</script>")


            

            If recstatus = True Then
                CLrEmpMaster()
                MessageBox("Record Saved successfully")
            Else

                MessageBox(MyerrorMsg & ". Record not saved")
            End If
        ElseIf recstatus = False Then
            MessageBox("Sorry!! Record Not Saved !!")
        End If

    End Sub


    Private Function CheckOldEmpCode() As DataSet

        Dim ClsObj As New CRMlognetglobal

        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim SqlDs As New DataSet
        Dim SqlAd As New SqlDataAdapter

        ClsObj.db_cn()

        If CmbOldCompany.Text = "MMSB" Then
            'MMSB HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        ElseIf CmbOldCompany.Text = "MMEL" Then
            'MEL HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.MelHrmis & "; Connect Timeout=6000000")
        ElseIf CmbOldCompany.Text = "MLI" Then
            'MLI HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.MliHrmis & "; Connect Timeout=6000000")
        ElseIf CmbOldCompany.Text = "OUTHRMIS" Then
            'OutSource HRMIS Connection String
            SqlCon = New SqlConnection(CRMlognetglobal.OutHrmis & "; Connect Timeout=6000000")
        Else
            Exit Function
        End If

        SqlCon.Open()

        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "CN_CheckTransferredEmpCode"
        SqlCmd.Connection = SqlCon

        SqlCmd.Parameters.Clear()

        SqlCmd.Parameters.AddWithValue("@OldEmpCode", TxtOldEmpCode.Text)

        SqlAd = New SqlDataAdapter(SqlCmd)

        SqlDs = New DataSet

        SqlAd.Fill(SqlDs, "Details")

        SqlCon.Close()

        Return SqlDs



    End Function


    Private Function UpdateTransferredEmpCode()

        Dim ClsObj As New CRMlognetglobal

        Dim SqlCon As New SqlConnection
        Dim SqlCmd As New SqlCommand
        Dim SqlDs As New DataSet
        Dim SqlAd As New SqlDataAdapter

        Dim Rmrks As String = "From " & CmbOldCompany.Text & " To MMSB - Emp Code From " & TxtOldEmpCode.Text & " To " & txtempcode.Text

        'HRMIS Connection String
        ClsObj.db_cn()
        SqlCon = New SqlConnection(CRMlognetglobal.sConnString2 & "; Connect Timeout=6000000")
        SqlCon.Open()


        SqlCmd.CommandType = CommandType.StoredProcedure
        SqlCmd.CommandText = "CN_UpdateTransferredEmpCode"
        SqlCmd.Connection = SqlCon

        SqlCmd.Parameters.Clear()
        SqlCmd.Parameters.AddWithValue("@NewEmpCode", txtempcode.Text)
        SqlCmd.Parameters.AddWithValue("@OldEmpCode", TxtOldEmpCode.Text)
        SqlCmd.Parameters.AddWithValue("@Remarks", Rmrks)

        SqlCmd.ExecuteNonQuery()

        SqlCon.Close()

    End Function

    Private Sub btnuploadpic_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnuploadpic.Click
        If txtempcode.Text = "" Then
            MessageBox("please keyin EmpCode before upload pic")
            Exit Sub
        End If

        Dim fn As String
        fn = txtempcode.Text.Trim
        fn = fn + ".jpg"
        ' fn = "F:\\E-Management\emppic\" & fn
        fn = Server.MapPath("~/emppic/" & fn)

        If (FileUpload1.PostedFile.ContentLength = 0) Then
            lblfile.Text = "Cannot upload zero length file"
        Else
            FileUpload1.PostedFile.SaveAs(fn)
            lblfile.Text = "Image Uploaded Successfully !! "
            Dim nfn As String
            nfn = txtempcode.Text.Trim
            nfn = nfn + ".jpg"
            nfn = "~/emppic/" & nfn
            imgemp.ImageUrl = Trim(nfn)
            Session("imageurl") = nfn
        End If


    End Sub
    Public Sub CLrEmpMaster()
        GetMaxEmpID()
        Dim id, rno As Integer
        ' MessageBox(posid)
        If posid < 0 Then
            id = 1
        Else
            id = posid + 1
        End If
        TextBox1.Text = ""
        txtempcode.Text = Formatempcode(id)
        txtempname.Text = ""
        edesignation.SelectedValue = "-1"
        deseccode.SelectedValue = "-1"
        edeptcode.SelectedValue = "-1"
        txtemail.Text = "0"
        decategory.SelectedValue = "-1"
        txtempdoj.Text = ""
        demptype.SelectedValue = "-1"
        rdforeign.SelectedValue = "N"
        Txtdob.Text = ""
        txtoldic.Text = "0"
        txtnewic.Text = "0"
        txtpassport.Text = "0"
        txtadrs1.Text = ""
        Txtadrs2.Text = "0"
        Txtadrs3.Text = "0"
        Txtposcode.Text = "0"
        rdhostel.SelectedValue = "N"
        rdtransport.SelectedValue = "N"
        Txtphone.Text = "0"
        Txthp.Text = "0"
        txtblood.Text = "-"
        txtchildren.Text = "0"
        txtepf.Text = "0"
        txtsosco.Text = "0"
        txteduwork.Text = "--"
        txteduothers.Text = "-"
        txtempcontract.Text = "0"
        txtaccount.Text = ""
        txteduexp.Text = "0"
        rdhp.SelectedValue = "0"
        rdnb.SelectedValue = "0"
        rdcar.SelectedValue = "0"
        rdlogin.SelectedValue = "0"
        imgemp.ImageUrl = ""
        Txttrousers.Text = "0"
        txtshoes.Text = "0"
        txtshirt.Text = "0"
        txtnotrousers.Text = "0"
        txtnoshoes.Text = "0"
        txtnoshirt.Text = "0"
        txtnojacket.Text = "0"
        txtnocap.Text = "0"
        txtdou.Text = "0"
        txtdos.Text = ""
    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

        imgemp.ImageUrl = ""

        'GetJobAppDetails()
        Dim dsh As DataSet
        Dim drh As DataRow

        dsh = GetJobAppDetails()
        Try

            If dsh.Tables(0).Rows.Count > 0 Then
                drh = dsh.Tables(0).Rows(0)

                txtempname.Text = drh("name").ToString
                edesignation.SelectedValue = drh("POST").ToString

                rdforeign.SelectedValue = "N"



                txtoldic.Text = ""
                txtempdoj.Text = DateTime.Today.ToString("dd/MM/yy")
                txtdos.Text = DateTime.Today.ToString("dd/MM/yy")
                demptype.SelectedValue = "Contract"
                decategory.SelectedValue = "Employee"

                If Not drh("ic").ToString Is System.DBNull.Value Then
                    txtnewic.Text = drh("ic").ToString
                End If


                If Not drh("address").ToString Is System.DBNull.Value Then
                    txtadrs1.Text = drh("address").ToString

                End If
                If Not drh("telno").ToString Is System.DBNull.Value Then
                    Txtphone.Text = drh("telno").ToString
                End If
                If Not drh("telno").ToString Is System.DBNull.Value Then
                    Txthp.Text = drh("telno").ToString
                End If
                'If Not drh("bloodgroup").ToString Is System.DBNull.Value Then
                '    txtblood.Text = drh("bloodgroup").ToString
                'End If
                If Not drh("dob").ToString Is System.DBNull.Value Then
                    Txtdob.Text = Format(Convert.ToDateTime(drh("dob").ToString), "dd/MM/yy")
                End If

                If Not drh("race").ToString Is System.DBNull.Value Then
                    derace.SelectedValue = drh("race").ToString
                End If

                If Not drh("religion").ToString Is System.DBNull.Value Then
                    Dereligion.SelectedValue = drh("religion").ToString
                End If

                If Not drh("Sex").ToString Is System.DBNull.Value Then
                    If drh("sex").ToString = "Male" Then
                        Rdgender.SelectedIndex = 0
                    Else
                        Rdgender.SelectedIndex = 1
                    End If
                End If

                If Not drh("religion").ToString Is System.DBNull.Value Then
                    Dereligion.SelectedValue = drh("religion").ToString
                End If

                If Not drh("race").ToString Is System.DBNull.Value Then
                    derace.SelectedValue = drh("race").ToString
                End If

                If Not drh("Nationality").ToString Is System.DBNull.Value Then
                    denation.SelectedValue = drh("Nationality").ToString
                End If
                If Not drh("Nationality").ToString Is System.DBNull.Value Then
                    demarital.SelectedValue = drh("Mart").ToString
                End If
                If Not drh("epf").ToString Is System.DBNull.Value Then
                    txtepf.Text = drh("epf").ToString
                End If

                If Not drh("sosco").ToString Is System.DBNull.Value Then
                    txtsosco.Text = drh("sosco").ToString
                End If

                If Not drh("uni1").ToString Is System.DBNull.Value And drh("uni1").ToString = "" Then
                    dElevel.Text = "COLLEGE"
                ElseIf Not drh("sec1").ToString Is System.DBNull.Value Then
                    dElevel.Text = "SPM"
                ElseIf Not drh("pri1").ToString Is System.DBNull.Value Then
                    dElevel.Text = "PMR"
                End If

                If Not drh("Name1").ToString Is System.DBNull.Value Then
                    TxtContactPerson.Text = drh("Name1").ToString
                End If

                If Not drh("add2").ToString Is System.DBNull.Value Then
                    TxtContactAddress.Text = drh("add2").ToString
                End If

                If Not drh("telno2").ToString Is System.DBNull.Value Then
                    TxtContactNo.Text = drh("telno2").ToString
                End If

                If Not drh("imageurl").ToString Is System.DBNull.Value Then
                    imgemp.ImageUrl = drh("imageurl").ToString.Replace("~", "http://mmsbsql1/hiring")
                    Session("imageurl") = drh("imageurl").ToString.Replace("~", "http://mmsbsql1/hiring")

                End If

                txtempcontract.Text = "6"

            Else
                MessageBox("Please check the IC number, there is no information on application form!")
            End If



        Catch ex As Exception

        End Try

        GetMaxEmpID()
        Dim id, rno As Integer

        If posid < 0 Then
            id = 1
        Else
            id = posid + 1
        End If
        txtempcode.Text = Formatempcode(id)
        txtempcode.Enabled = False
    End Sub

    Function GetJobAppDetails() As DataSet

        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("HRMIS_GETJOBapplnNo_Rev1", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@appno", TextBox1.Text.Trim)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "KPIMajor")
        con.Close()
        Return ds
    End Function

    

    Protected Sub RbtnTEmpYes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtnTEmpYes.CheckedChanged
        LblOldCompany.Visible = True
        LblOldEmpCode.Visible = True
        CmbOldCompany.Visible = True
        TxtOldEmpCode.Visible = True
    End Sub

    Protected Sub RbtnTEmpNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RbtnTEmpNo.CheckedChanged
        LblOldCompany.Visible = False
        LblOldEmpCode.Visible = False
        CmbOldCompany.Visible = False
        TxtOldEmpCode.Visible = False
    End Sub

    
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Session("emptxt") = txtempcode.Text
        'MsgBox(Session("emptxt"))
        Response.Redirect("EmpmasterPrintRpt.aspx")
    End Sub

    Protected Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        CLrEmpMaster()
    End Sub
End Class
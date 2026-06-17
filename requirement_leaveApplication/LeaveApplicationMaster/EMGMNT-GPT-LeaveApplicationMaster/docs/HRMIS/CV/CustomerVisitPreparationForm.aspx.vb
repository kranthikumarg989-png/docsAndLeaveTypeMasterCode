Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Image
Imports System.IO.Stream
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports E_Management.crmlognetglobal
'Imports TallComponents.PDF
Imports System.Web.Security


Partial Public Class CustomerVisitPreparationForm
    Inherits Messagebox

    Dim TMpDs As New DataSet
    Dim I As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then
                CmbCustomerName.Items.Clear()
                Dim mynet As New CRMlognetglobal
                mynet.db_cn()
                mynet.db_open()

                TMpDs = New DataSet()
                TMpDs = mynet.SelectAllCustomer(mynet.sConnString)

                CmbCustomerName.Items.Add("-Select-")
                For I = 0 To TMpDs.Tables(0).Rows.Count - 1
                    CmbCustomerName.Items.Add(TMpDs.Tables(0).Rows(I).Item(0))
                Next


                If Session("cvrefno").ToString.Length >= 1 Then




                    TMpDs = New DataSet()
                    TMpDs = mynet.SelectCVData(mynet.sConnString2, Session("cvrefno"))
                    Button1.Text = Session("btncaption").ToString

                    Dim Dt1 As Date = TMpDs.Tables(0).Rows(0).Item(1)
                    Dim Dt2 As Date = TMpDs.Tables(0).Rows(0).Item(2)

                    TxtFrom.Text = Dt1.ToString("dd-MMM-yyyy")
                    TxtTo.Text = Dt2.ToString("dd-MMM-yyyy")

                    TxtFrom.ReadOnly = True
                    TxtTo.ReadOnly = True

                    Label2.Visible = True
                    LblNoOfDays.Visible = True

                    LblNoOfDays.Text = TMpDs.Tables(0).Rows(0).Item(3)

                    TxtOtherCustomer.Text = TMpDs.Tables(0).Rows(0).Item(4)
                    TxtOtherCustomer.ReadOnly = True

                    CmbCustomerName.Enabled = False

                    Dim DspDept As String()
                    DspDept = TMpDs.Tables(0).Rows(0).Item(5).ToString.Split("-")

                    For TmpI As Integer = 0 To DspDept.Length - 1
                        If DspDept(TmpI) = "CV" Then
                            CeramicValve.Checked = True
                        ElseIf DspDept(TmpI) = "FS" Then
                            FerriteSheet.Checked = True
                        ElseIf DspDept(TmpI) = "FM" Then
                            FerriteMagnet.Checked = True
                        ElseIf DspDept(TmpI) = "TPH" Then
                            TPH.Checked = True
                        ElseIf DspDept(TmpI) = "Substrate" Then
                            Substrate.Checked = True
                        End If
                    Next



                    TxtNoOfCustomer.Text = TMpDs.Tables(0).Rows(0).Item(6)
                    TxtNoOfCustomer.ReadOnly = True

                    TxtAttendance.Text = TMpDs.Tables(0).Rows(0).Item(7)
                    TxtDesignation.Text = TMpDs.Tables(0).Rows(0).Item(8)

                    TxtAttendance.ReadOnly = True
                    TxtDesignation.ReadOnly = True

                    TxtAttendance2.Text = TMpDs.Tables(0).Rows(0).Item(91)
                    TxtDesignation2.Text = TMpDs.Tables(0).Rows(0).Item(92)

                    TxtAttendance2.ReadOnly = True
                    TxtDesignation2.ReadOnly = True

                    TxtAttendance3.Text = TMpDs.Tables(0).Rows(0).Item(93)
                    TxtDesignation3.Text = TMpDs.Tables(0).Rows(0).Item(94)

                    TxtAttendance3.ReadOnly = True
                    TxtDesignation3.ReadOnly = True

                    TxtRequestedBy.Text = TMpDs.Tables(0).Rows(0).Item(95)
                    TxtRequestorEID.Text = TMpDs.Tables(0).Rows(0).Item(96)


                    TxtRequestedBy.ReadOnly = True
                    TxtRequestorEID.ReadOnly = True

                    TxtReason.Text = TMpDs.Tables(0).Rows(0).Item(9)
                    TxtReason.ReadOnly = True


                    Dim CVRights As String()
                    Session("cvrights") = Session("cvrights").ToString.TrimEnd(",")
                    CVRights = Session("cvrights").ToString.Split(",")

                    For Tmpi As Integer = 0 To CVRights.Length - 1
                        SalesPanel.Enabled = False
                        SalesRemarks.ReadOnly = True

                        ProductionPanel.Enabled = False
                        ProductionRemarks.ReadOnly = True

                        QAPanel.Enabled = False
                        QARemarks.ReadOnly = True

                        AdminPanel.Enabled = False
                        AdminRemarks.ReadOnly = True

                        ITPanel.Enabled = False
                        ITRemarks.ReadOnly = True

                        TMPanel.Enabled = False
                        TMRemarks.ReadOnly = True
                    Next

                    For Tmpi As Integer = 0 To CVRights.Length - 1

                        If CVRights(Tmpi) = "SALES" Then
                            SalesPanel.Enabled = True
                            SalesRemarks.ReadOnly = False
                            SalesAck.Text = Session("empname").ToString

                        End If

                        If CVRights(Tmpi) = "PRODUCTION" Then
                            ProductionPanel.Enabled = True
                            ProductionRemarks.ReadOnly = False
                            ProductionAck.Text = Session("empname").ToString

                        End If

                        If CVRights(Tmpi) = "QA" Then
                            QAPanel.Enabled = True
                            QARemarks.ReadOnly = False
                            QAAck1.Text = Session("empname").ToString
                        End If

                        If CVRights(Tmpi) = "ADMIN" Then
                            AdminPanel.Enabled = True
                            AdminRemarks.ReadOnly = False
                            AdminAck.Text = Session("empname").ToString

                        End If

                        If CVRights(Tmpi) = "IT" Then
                            ITPanel.Enabled = True
                            ITRemarks.ReadOnly = False
                            ITAck.Text = Session("empname").ToString
                        End If


                        If CVRights(Tmpi) = "TM" Then
                            TMPanel.Enabled = True
                            TMRemarks.ReadOnly = False
                            TMAck.Text = Session("empname").ToString
                        End If



                    Next
                    
                    If TMpDs.Tables(0).Rows(0).Item(10) = 1 Then
                        Safety.Checked = True
                    Else
                        Safety.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(11) = 1 Then
                        Company.Checked = True
                    Else
                        Company.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(12) = 1 Then
                        Profile1.Checked = True
                    Else
                        Profile1.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(13) = 1 Then
                        Beverages.Checked = True
                    Else
                        Beverages.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(14) = 1 Then
                        Towels.Checked = True
                    Else
                        Towels.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(15) = 1 Then
                        Souvenirs.Checked = True
                    Else
                        Souvenirs.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(16) = 1 Then
                        Stationery.Checked = True
                    Else
                        Stationery.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(17) = 1 Then
                        SafetyPPE.Checked = True
                    Else
                        SafetyPPE.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(18) = 1 Then
                        SalesOthers.Checked = True
                    Else
                        SalesOthers.Checked = False
                    End If

                    SalesOthers1.Text = TMpDs.Tables(0).Rows(0).Item(19)

                    If TMpDs.Tables(0).Rows(0).Item(21) = 1 Then
                        FiveS.Checked = True
                    Else
                        FiveS.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(21) = 1 Then
                        Production.Checked = True
                    Else
                        Production.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(22) = 1 Then
                        ProductionOthers.Checked = True
                    Else
                        ProductionOthers.Checked = False
                    End If

                    ProductionOthers1.Text = TMpDs.Tables(0).Rows(0).Item(23)

                    If TMpDs.Tables(0).Rows(0).Item(24) = 1 Then
                        ProcessFlow.Checked = True
                    Else
                        ProcessFlow.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(25) = 1 Then
                        QualityPlan.Checked = True
                    Else
                        QualityPlan.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(26) = 1 Then
                        ClaimStatus.Checked = True
                    Else
                        ClaimStatus.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(27) = 1 Then
                        QualityOthers.Checked = True
                    Else
                        QualityOthers.Checked = False
                    End If

                    QualityOthers1.Text = TMpDs.Tables(0).Rows(0).Item(28)


                    If TMpDs.Tables(0).Rows(0).Item(29) = 1 Then
                        Arrival.Checked = True
                    Else
                        Arrival.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(30) = 1 Then
                        Departure.Checked = True
                    Else
                        Departure.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(31) = 1 Then
                        Accommodation.Checked = True
                    Else
                        Accommodation.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(32) = 1 Then
                        Lunch.Checked = True
                    Else
                        Lunch.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(33) = 1 Then
                        Dinner.Checked = True
                    Else
                        Dinner.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(34) = 1 Then
                        WelcomeBoard.Checked = True
                    Else
                        WelcomeBoard.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(35) = 1 Then
                        WIFI.Checked = True
                    Else
                        WIFI.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(36) = 1 Then
                        ITOthers.Checked = True
                    Else
                        ITOthers.Checked = False
                    End If

                    ITOthers1.Text = TMpDs.Tables(0).Rows(0).Item(37)

                    If TMpDs.Tables(0).Rows(0).Item(38) = 1 Then
                        Meeting.Checked = True
                    Else
                        Meeting.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(39) = 1 Then
                        TMOthers.Checked = True
                    Else
                        TMOthers.Checked = False
                    End If

                    TMOthers1.Text = TMpDs.Tables(0).Rows(0).Item(40)

                    If TMpDs.Tables(0).Rows(0).Item(41) = 1 Then
                        RID.Checked = True

                    Else
                        RID.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(44) = 1 Then
                        CSID.Checked = True
                    Else
                        CSID.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(47) = 1 Then
                        OSHI.Checked = True
                    Else
                        OSHI.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(50) = 1 Then
                        SU.Checked = True
                    Else
                        SU.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(53) = 1 Then
                        TPH1.Checked = True
                    Else
                        TPH1.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(56) = 1 Then
                        CV.Checked = True
                    Else
                        CV.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(59) = 1 Then
                        FM.Checked = True
                    Else
                        FM.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(62) = 1 Then
                        FS.Checked = True
                    Else
                        FS.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(65) = 1 Then
                        QAAck.Checked = True
                    Else
                        QAAck.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(68) = 1 Then
                        Admin.Checked = True
                    Else
                        Admin.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(71) = 1 Then
                        Security.Checked = True
                    Else
                        Security.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(74) = 1 Then
                        IT.Checked = True
                    Else
                        IT.Checked = False
                    End If


                    If TMpDs.Tables(0).Rows(0).Item(77) = 1 Then
                        MD.Checked = True
                    Else
                        MD.Checked = False
                    End If

                    If TMpDs.Tables(0).Rows(0).Item(80) = 1 Then
                        EA.Checked = True
                    Else
                        EA.Checked = False
                    End If

                    SalesRemarks.Text = TMpDs.Tables(0).Rows(0).Item(83)
                    ProductionRemarks.Text = TMpDs.Tables(0).Rows(0).Item(84)
                    QARemarks.Text = TMpDs.Tables(0).Rows(0).Item(85)
                    AdminRemarks.Text = TMpDs.Tables(0).Rows(0).Item(86)
                    ITRemarks.Text = TMpDs.Tables(0).Rows(0).Item(87)
                    TMRemarks.Text = TMpDs.Tables(0).Rows(0).Item(88)

                    
                    Dim SmsMsg As String
                    SmsMsg = "Customer Visit" & vbCrLf & "Name:" & TxtOtherCustomer.Text & vbCrLf & "From " & TxtFrom.Text & " To " & TxtTo.Text & ", No of Days:" & LblNoOfDays.Text
                    SmsMsg = SmsMsg & vbCrLf & "Purpose:" & TxtReason.Text
                    SmsMsg = SmsMsg & vbCrLf & "Dept:" & TMpDs.Tables(0).Rows(0).Item(5)
                    SmsMsg = SmsMsg & vbCrLf & "Requested by:" & TxtRequestedBy.Text & "(" & TxtRequestorEID.Text & ")" & vbCrLf & " Respective Person Incharge Please Acknowledge By System - Ref No:" & Session("cvrefno").ToString

                    TMRemarks.Text = SmsMsg
                    Session("reprefno") = Session("cvrefno").ToString
                    Session("cvrefno1") = Session("cvrefno").ToString
                    Session("cvrefno") = ""
                Else
                    Button1.Text = "Save"
                    TxtRequestorEID.Text = Session("empcode").ToString
                End If

            End If

        Catch ex As Exception
            Button1.Text = "Save"
            TxtRequestorEID.Text = Session("empcode").ToString
        End Try




    End Sub

    Protected Sub From1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles From1.SelectionChanged
        TxtFrom.Text = ""
        TxtFrom.Text = From1.SelectedDate.ToString("dd-MMM-yyyy")
        From1.Visible = False
        TxtTo.Text = ""
        LblNoOfDays.Text = ""
        Label2.Visible = False
        LblNoOfDays.Visible = False



    End Sub

    Protected Sub To1_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles To1.SelectionChanged
        TxtTo.Text = ""
        TxtTo.Text = To1.SelectedDate.ToString("dd-MMM-yyyy")
        To1.Visible = False
        LblNoOfDays.Text = Val(DateDiff(DateInterval.Day, Convert.ToDateTime(TxtFrom.Text), Convert.ToDateTime(TxtTo.Text))) + 1
        Label2.Visible = True
        LblNoOfDays.Visible = True

    End Sub

    Protected Sub ImageButton1_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton1.Click
        From1.Visible = True
    End Sub

    Protected Sub ImageButton2_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButton2.Click
        To1.Visible = True
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        If TxtFrom.Text.Trim.Equals("") Then
            msg("Please Enter From Date")
            Exit Sub
        End If

        If TxtTo.Text.Trim.Equals("") Then
            msg("Please Enter To Date")
            Exit Sub
        End If

        If TxtOtherCustomer.Text.Trim.Equals("") Then
            msg("Please Select Customer Name")
            Exit Sub
        End If

        If TxtNoOfCustomer.Text.Trim.Equals("") Then
            msg("Please Enter No of Attendence")
            Exit Sub
        End If

        If TxtReason.Text.Trim.Equals("") Then
            msg("Please Enter purpose of Visit")
            Exit Sub
        End If

        If TxtRequestedBy.Text.Trim.Equals("") Then
            msg("Please Enter RequestedBY")
            Exit Sub
        End If


        If TxtRequestorEID.Text.Trim.Equals("") Then
            msg("Please Enter Requestor Employee ID")
            Exit Sub
        End If

        Dim Dt1 As New DateTime
        Dim Dt2 As New DateTime
        Dim Dt3 As New DateTime
        Dim Dt4 As New DateTime
        Dim Dt5 As New DateTime
        Dim Dt6 As New DateTime
        Dim Dt7 As New DateTime
        Dim Dt8 As New DateTime
        Dim Dt9 As New DateTime
        Dim Dt10 As New DateTime
        Dim Dt11 As New DateTime
        Dim Dt12 As New DateTime
        Dim Dt13 As New DateTime
        Dim Dt14 As New DateTime


        Dim mynet As New CRMlognetglobal
        mynet.db_cn()
        mynet.db_open()

        TMpDs = New DataSet()
        TMpDs = mynet.SelectCVData(mynet.sConnString2, Session("cvrefno1"))

        Dim VRidAck As String = "-"
        Dim VCsidAck As String = "-"
        Dim VOshiAck As String = "-"

        Dim VSUAck As String = "-"
        Dim VTPHAck As String = "-"
        Dim VCVAck As String = "-"
        Dim VFMAck As String = "-"
        Dim VFSAck As String = "-"
        Dim VQAAck As String = "-"
        Dim VAdminAck As String = "-"
        Dim VSecurityAck As String = "-"
        Dim VItAck As String = "-"
        Dim VMDAck As String = "-"
        Dim VEAAck As String = "-"
 

        Dim Dept As String = ""

        If CeramicValve.Checked = True Then
            Dept = "CV"
        End If

        If FerriteMagnet.Checked = True Then
            Dept = Dept + "-" + "FM"
        End If

        If FerriteSheet.Checked = True Then
            Dept = Dept + "-" + "FS"
        End If


        If Substrate.Checked = True Then
            Dept = Dept + "-" + "Substrate"
        End If


        If TPH.Checked = True Then
            Dept = Dept + "-" + "TPH"
        End If

        If Dept.Trim.Equals("") Then
            msg("Please Select Department")
            Exit Sub

        End If

        Dim Sfty As Integer

        If Safety.Checked = True Then
            Sfty = 1
        Else
            Sfty = 0
        End If

        Dim Cmpny As Integer

        If Company.Checked = True Then
            Cmpny = 1
        Else
            Cmpny = 0
        End If

        Dim Prfl As Integer

        If Profile1.Checked = True Then
            Prfl = 1
        Else
            Prfl = 0
        End If

        Dim Bevrgs As Integer

        If Beverages.Checked = True Then
            Bevrgs = 1
        Else
            Bevrgs = 0
        End If

        Dim Twls As Integer

        If Towels.Checked = True Then
            Twls = 1
        Else
            Twls = 0
        End If

        Dim Suvnrs As Integer

        If Souvenirs.Checked = True Then
            Suvnrs = 1
        Else
            Suvnrs = 0
        End If

        Dim Stnry As Integer

        If Stationery.Checked = True Then
            Stnry = 1
        Else
            Stnry = 0
        End If

        Dim SftyPpe As Integer

        If SafetyPPE.Checked = True Then
            SftyPpe = 1
        Else
            SftyPpe = 0
        End If

        Dim Slsothrs As Integer

        If SalesOthers.Checked = True Then
            Slsothrs = 1
        Else
            Slsothrs = 0
        End If


        Dim FvS As Integer

        If FiveS.Checked = True Then
            FvS = 1
        Else
            FvS = 0
        End If

        Dim Prdctn As Integer

        If Production.Checked = True Then
            Prdctn = 1
        Else
            Prdctn = 0
        End If

        Dim PrdctnOthrs As Integer

        If ProductionOthers.Checked = True Then
            PrdctnOthrs = 1
        Else
            PrdctnOthrs = 0
        End If

        Dim PrsFlw As Integer

        If ProcessFlow.Checked = True Then
            PrsFlw = 1
        Else
            PrsFlw = 0
        End If

        Dim QltyPln As Integer

        If QualityPlan.Checked = True Then
            QltyPln = 1
        Else
            QltyPln = 0
        End If


        Dim Claimsts As Integer

        If ClaimStatus.Checked = True Then
            Claimsts = 1
        Else
            Claimsts = 0
        End If

        Dim QAOthrs As Integer

        If QualityOthers.Checked = True Then
            QAOthrs = 1
        Else
            QAOthrs = 0
        End If

        Dim Arvl As Integer

        If Arrival.Checked = True Then
            Arvl = 1
        Else
            Arvl = 0
        End If

        Dim Dprtr As Integer

        If Departure.Checked = True Then
            Dprtr = 1
        Else
            Dprtr = 0
        End If

        Dim Accm As Integer

        If Accommodation.Checked = True Then
            Accm = 1
        Else
            Accm = 0
        End If

        Dim Lnch As Integer

        If Lunch.Checked = True Then
            Lnch = 1
        Else
            Lnch = 0
        End If

        Dim Dinr As Integer

        If Dinner.Checked = True Then
            Dinr = 1
        Else
            Dinr = 0
        End If

        Dim Admn As Integer

        If Admin.Checked = True Then
            Admn = 1
            If TMpDs.Tables(0).Rows(0).Item(69).ToString.Equals("-") Then
                VAdminAck = Admin.Text
                Dt10 = DateTime.Now
            Else
                VAdminAck = TMpDs.Tables(0).Rows(0).Item(69)
                Dt10 = TMpDs.Tables(0).Rows(0).Item(70)
            End If
            
        Else
            Admn = 0
            Dt10 = DateTime.Now
        End If

        Dim Scrty As Integer

        If Security.Checked = True Then
            Scrty = 1
            If TMpDs.Tables(0).Rows(0).Item(72).ToString.Equals("-") Then
                VSecurityAck = Admin.Text
                Dt11 = DateTime.Now
            Else
                VSecurityAck = TMpDs.Tables(0).Rows(0).Item(72)
                Dt11 = TMpDs.Tables(0).Rows(0).Item(72)
            End If

        Else
            Scrty = 0
            Dt11 = DateTime.Now
        End If

        Dim WlcmBrd As Integer

        If WelcomeBoard.Checked = True Then
            WlcmBrd = 1
        Else
            WlcmBrd = 0
        End If

        Dim Wi As Integer

        If WIFI.Checked = True Then
            Wi = 1
        Else
            Wi = 0
        End If

        Dim ItOthrs As Integer

        If ITOthers.Checked = True Then
            ItOthrs = 1
        Else
            ItOthrs = 0
        End If

        Dim Mtng As Integer

        If Meeting.Checked = True Then
            Mtng = 1
        Else
            Mtng = 0
        End If

        Dim TmOthrs As Integer

        If TMOthers.Checked = True Then
            TmOthrs = 1
        Else
            TmOthrs = 0
        End If

        Dim RD As Integer

        If RID.Checked = True Then
            RD = 1
            If TMpDs.Tables(0).Rows(0).Item(42).ToString.Equals("-") Then
                VRidAck = SalesAck.Text
                Dt1 = DateTime.Now
            Else
                VRidAck = TMpDs.Tables(0).Rows(0).Item(42)
                Dt1 = TMpDs.Tables(0).Rows(0).Item(43)
            End If

            
        Else
            RD = 0
            Dt1 = DateTime.Now
        End If

        Dim CSD As Integer

        If CSID.Checked = True Then
            CSD = 1
            If TMpDs.Tables(0).Rows(0).Item(45).ToString.Equals("-") Then
                VCsidAck = SalesAck.Text
                Dt2 = DateTime.Now
            Else

                VCsidAck = TMpDs.Tables(0).Rows(0).Item(45)
                Dt2 = TMpDs.Tables(0).Rows(0).Item(46)
            End If


        Else
            CSD = 0
            Dt2 = DateTime.Now
        End If

        Dim OSH As Integer

        If OSHI.Checked = True Then
            OSH = 1
            If TMpDs.Tables(0).Rows(0).Item(48).ToString.Equals("-") Then
                VOshiAck = SalesAck.Text
                Dt3 = DateTime.Now
            Else
                VOshiAck = TMpDs.Tables(0).Rows(0).Item(48)
                Dt3 = TMpDs.Tables(0).Rows(0).Item(49)
            End If

        Else
            OSH = 0
            Dt3 = DateTime.Now
        End If

        Dim CVAck As Integer

        If CV.Checked = True Then
            CVAck = 1
            If TMpDs.Tables(0).Rows(0).Item(57).ToString.Equals("-") Then
                VCVAck = ProductionAck.Text
                Dt6 = DateTime.Now
            Else
                VCVAck = TMpDs.Tables(0).Rows(0).Item(57)
                Dt6 = TMpDs.Tables(0).Rows(0).Item(58)
            End If
        Else
            CVAck = 0
            Dt6 = DateTime.Now
        End If


        Dim SubAck As Integer

        If SU.Checked = True Then
            SubAck = 1
            If TMpDs.Tables(0).Rows(0).Item(51).ToString.Equals("-") Then
                VSUAck = ProductionAck.Text
                Dt4 = DateTime.Now
            Else
                VSUAck = TMpDs.Tables(0).Rows(0).Item(51)
                Dt4 = TMpDs.Tables(0).Rows(0).Item(52)
            End If

        Else
            SubAck = 0
            Dt4 = DateTime.Now
        End If

        Dim FMAck As Integer

        If FM.Checked = True Then
            FMAck = 1
            If TMpDs.Tables(0).Rows(0).Item(60).ToString.Equals("-") Then
                VFMAck = ProductionAck.Text
                Dt7 = DateTime.Now

            Else
                VFMAck = TMpDs.Tables(0).Rows(0).Item(60)
                Dt7 = TMpDs.Tables(0).Rows(0).Item(61)

            End If


        Else
            FMAck = 0
            Dt7 = DateTime.Now
        End If

        Dim FSAck As Integer

        If FS.Checked = True Then
            FSAck = 1
            If TMpDs.Tables(0).Rows(0).Item(63).ToString.Equals("-") Then
                VFSAck = ProductionAck.Text
                Dt8 = DateTime.Now
            Else
                VFSAck = TMpDs.Tables(0).Rows(0).Item(63)
                Dt8 = TMpDs.Tables(0).Rows(0).Item(64)
            End If

        Else
            FSAck = 0
            Dt8 = DateTime.Now
        End If


        Dim TPHAck As Integer

        If TPH1.Checked = True Then
            TPHAck = 1
            If TMpDs.Tables(0).Rows(0).Item(54).ToString.Equals("-") Then
                VTPHAck = ProductionAck.Text
                Dt5 = DateTime.Now
            Else
                VTPHAck = TMpDs.Tables(0).Rows(0).Item(54)
                Dt5 = TMpDs.Tables(0).Rows(0).Item(55)
            End If


        Else
            TPHAck = 0
            Dt5 = DateTime.Now
        End If

        Dim QAck As Integer

        If QAAck.Checked = True Then
            QAck = 1
            If TMpDs.Tables(0).Rows(0).Item(66).ToString.Equals("-") Then
                VQAAck = QAAck1.Text
                Dt9 = DateTime.Now
            Else
                VQAAck = TMpDs.Tables(0).Rows(0).Item(66)
                Dt9 = TMpDs.Tables(0).Rows(0).Item(67)
            End If

        Else
            QAck = 0
            Dt9 = DateTime.Now
        End If

        Dim It1 As Integer
        If IT.Checked = True Then
            It1 = 1
            If TMpDs.Tables(0).Rows(0).Item(75).ToString.Equals("-") Then
                VItAck = ITAck.Text
                Dt12 = DateTime.Now

            Else
                VItAck = TMpDs.Tables(0).Rows(0).Item(75)
                Dt12 = TMpDs.Tables(0).Rows(0).Item(76)

            End If

        Else
            It1 = 0
            Dt12 = DateTime.Now
        End If

        Dim Md1 As Integer
        If MD.Checked = True Then
            Md1 = 1
            If TMpDs.Tables(0).Rows(0).Item(78).ToString.Equals("-") Then
                VMDAck = TMAck.Text
                Dt13 = DateTime.Now
            Else
                VMDAck = TMpDs.Tables(0).Rows(0).Item(78)
                Dt13 = TMpDs.Tables(0).Rows(0).Item(79)
            End If

        Else
            Md1 = 0
            Dt13 = DateTime.Now
        End If

        Dim Ea1 As Integer
        If EA.Checked = True Then
            Ea1 = 1
            If TMpDs.Tables(0).Rows(0).Item(81).ToString.Equals("-") Then
                VEAAck = ProductionAck.Text
                Dt14 = DateTime.Now
            Else
                VEAAck = TMpDs.Tables(0).Rows(0).Item(81)
                Dt14 = TMpDs.Tables(0).Rows(0).Item(82)
            End If

        Else
            Ea1 = 0
            Dt14 = DateTime.Now
        End If




        If Button1.Text = "Save" Then
            Dept = Dept.TrimStart("-")
            mynet.InssertCustomerVisitPreparationForm(mynet.sConnString2, 0, Convert.ToDateTime(TxtFrom.Text), Convert.ToDateTime(TxtTo.Text), Val(LblNoOfDays.Text), TxtOtherCustomer.Text.Replace(",", ""), Dept, Val(TxtNoOfCustomer.Text), TxtAttendance.Text, TxtDesignation.Text, TxtReason.Text, Sfty, Cmpny, Prfl, Bevrgs, Twls, Suvnrs, Stnry, SftyPpe, Slsothrs, SalesOthers1.Text, FvS, Prdctn, PrdctnOthrs, ProductionOthers1.Text, PrsFlw, QltyPln, Claimsts, QAOthrs, QualityOthers1.Text, Arvl, Dprtr, Accm, Lnch, Dinr, WlcmBrd, Wi, ItOthrs, ITOthers1.Text, Mtng, TmOthrs, TMOthers1.Text, RD, "-", DateTime.Now, CSD, "-", DateTime.Now, OSH, "-", DateTime.Now, SubAck, "-", DateTime.Now, TPHAck, "-", DateTime.Now, CVAck, "-", DateTime.Now, FMAck, "-", DateTime.Now, FSAck, "-", DateTime.Now, QAck, "-", DateTime.Now, Admn, "-", DateTime.Now, Scrty, "-", DateTime.Now, It1, "-", DateTime.Now, Md1, "-", DateTime.Now, Ea1, "-", DateTime.Now, SalesRemarks.Text, ProductionRemarks.Text, QARemarks.Text, AdminRemarks.Text, ITRemarks.Text, TMRemarks.Text, Session("empcode").ToString, DateTime.Now, TxtAttendance2.Text, TxtDesignation2.Text, TxtAttendance3.Text, TxtDesignation3.Text, TxtRequestedBy.Text, TxtRequestorEID.Text, "S")

            Dim TmpDs1 As New DataSet
            TmpDs1 = mynet.SelectCVRefNo(mynet.sConnString2)
            Dim RefNo1 As String

            If TmpDs1.Tables(0).Rows.Count >= 1 Then
                RefNo1 = TmpDs1.Tables(0).Rows(0).Item(0)
            End If

            'Dim SmsMsg As String
            'SmsMsg = "Customer Visit" & vbCrLf & "Name:" & TxtOtherCustomer.Text & vbCrLf & "From " & TxtFrom.Text & " To " & TxtTo.Text & ", No of Days:" & LblNoOfDays.Text & vbCrLf & "Attendance Name and Designation:" & TxtAttendance.Text & "-" & TxtDesignation.Text
            'If Val(TxtNoOfCustomer.Text) = 3 Then
            '    SmsMsg = SmsMsg & "," & TxtAttendance2.Text & "-" & TxtDesignation2.Text & "," & TxtAttendance3.Text & "-" & TxtDesignation3.Text
            'ElseIf Val(TxtNoOfCustomer.Text) = 2 Then
            '    SmsMsg = SmsMsg & "," & TxtAttendance2.Text & "-" & TxtDesignation2.Text
            'End If
            'SmsMsg = SmsMsg & vbCrLf & "Purpose:" & TxtReason.Text
            'SmsMsg = SmsMsg & vbCrLf & "Department:" & Dept
            'SmsMsg = SmsMsg & vbCrLf & "Requested by:" & TxtRequestedBy.Text & "(" & TxtRequestorEID.Text & ")" & vbCrLf & "Kindly Approve - Ref No:" & RefNo1

            mynet.db_cn()
            mynet.dbSMS_open()

            mynet.InsertSMSLINK(mynet.sConnStringSMS, "MMSB", "CV", RefNo1, "S", TxtRequestorEID.Text, DateTime.Now)
            msg("Successfully updated")

            TxtFrom.Text = ""
            TxtTo.Text = ""
            TxtOtherCustomer.Text = ""
            LblNoOfDays.Visible = False
            Label2.Visible = False
            TxtNoOfCustomer.Text = ""
            TxtAttendance.Text = ""
            TxtAttendance2.Text = ""
            TxtAttendance3.Text = ""
            TxtDesignation.Text = ""
            TxtDesignation2.Text = ""
            TxtDesignation3.Text = ""
            TxtReason.Text = ""
            TxtFrom.Focus()


        Else

            If QAPanel.Enabled = True Then
                If QAAck.Checked = False Then
                    msg("For Acknowledgement! Please Select QA Acknowledgement Checkbox!")
                    Exit Sub
                End If
            End If

            If SalesPanel.Enabled = True Then
                If RID.Checked = False And OSHI.Checked = False And CSID.Checked = False Then
                    msg("For Acknowledgement! Please Select Sales Acknowledgement Checkbox!")
                    Exit Sub
                End If
            End If

            If AdminPanel.Enabled = True Then
                If Admin.Checked = False And Security.Checked = False Then
                    msg("For Acknowledgement! Please Select Admin Acknowledgement Checkbox!")
                    Exit Sub
                End If
            End If


            If ITPanel.Enabled = True Then
                If IT.Checked = False Then
                    msg("For Acknowledgement! Please Select IT Acknowledgement Checkbox!")
                    Exit Sub
                End If
            End If

            If ProductionPanel.Enabled = True Then
                If CV.Checked = False And FM.Checked = False And FS.Checked = False And SU.Checked = False And TPH1.Checked = False Then
                    msg("For Acknowledgement! Please Select Production Acknowledgement Checkbox!")
                    Exit Sub
                End If
            End If

            If TMPanel.Enabled = True Then
                If MD.Checked = False And EA.Checked = False Then
                    msg("For Approval! Please Select Top Management Acknowledgement Checkbox!")
                    Exit Sub
                End If
            End If

            Dept = Dept.TrimStart("-")

            mynet.InssertCustomerVisitPreparationForm(mynet.sConnString2, Session("cvrefno1"), Convert.ToDateTime(TxtFrom.Text), Convert.ToDateTime(TxtTo.Text), Val(LblNoOfDays.Text), TxtOtherCustomer.Text.Replace(",", ""), Dept, Val(TxtNoOfCustomer.Text), TxtAttendance.Text, TxtDesignation.Text, TxtReason.Text, Sfty, Cmpny, Prfl, Bevrgs, Twls, Suvnrs, Stnry, SftyPpe, Slsothrs, SalesOthers1.Text, FvS, Prdctn, PrdctnOthrs, ProductionOthers1.Text, PrsFlw, QltyPln, Claimsts, QAOthrs, QualityOthers1.Text, Arvl, Dprtr, Accm, Lnch, Dinr, WlcmBrd, Wi, ItOthrs, ITOthers1.Text, Mtng, TmOthrs, TMOthers1.Text, RD, VRidAck, Dt1, CSD, VCsidAck, Dt2, OSH, VOshiAck, Dt3, SubAck, VSUAck, Dt4, TPHAck, VTPHAck, Dt5, CVAck, VCVAck, Dt6, FMAck, VFMAck, Dt7, FSAck, VFSAck, Dt8, QAck, VQAAck, Dt9, Admn, VAdminAck, Dt10, Scrty, VSecurityAck, Dt11, It1, VItAck, Dt12, Md1, VMDAck, Dt13, Ea1, VEAAck, Dt14, SalesRemarks.Text, ProductionRemarks.Text, QARemarks.Text, AdminRemarks.Text, ITRemarks.Text, TMRemarks.Text, Session("empcode").ToString, DateTime.Now, TxtAttendance2.Text, TxtDesignation2.Text, TxtAttendance3.Text, TxtDesignation3.Text, TxtRequestedBy.Text, TxtRequestorEID.Text, "A")

            If Button1.Text = "Approve" Then
                Session("frm") = TxtFrom.Text
                Session("to") = TxtTo.Text
                Session("custother") = TxtOtherCustomer.Text.Replace("'", " ").Replace(".", " ")
                Session("mlsts") = "t"
                Session("cvdepartment") = Dept

                Response.Redirect("customervisitreport.aspx")

            Else

                Response.Redirect("customervisitapprovalform.aspx")

            End If
        End If

    End Sub

    Protected Sub CmbCustomerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbCustomerName.SelectedIndexChanged
        TxtOtherCustomer.Text = CmbCustomerName.Text
    End Sub
End Class
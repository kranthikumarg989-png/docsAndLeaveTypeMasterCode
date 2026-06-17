Imports System
Imports System.Web
Imports System.Data.SqlClient
Imports System.Web.SessionState
Namespace Emanagement
    Public Class globalinfo
        ' ******************************* Declare Database ****************************
        Public Shared Con, Con1, Con2 As New SqlConnection
        Public Shared DAP As New SqlDataAdapter
        Public Shared DS, dssafety As New DataSet
        Public Shared DR As DataRow
        Public Shared Cmd As SqlCommand
        Public Shared constr, conSMSstr, CONdmiS, conFMD, conCRMstr As String
        Public Shared cb, cb1, cbStored As SqlCommandBuilder
        Public Shared sver, dbname, uid, pw
        Public Shared con_mel, con_lig, con_os As String

 



        Public Function Con_Str()
            '************ CONNECTION STRING ***********
            constr = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;Max Pool Size=100000;connection lifetime=0 "
            conSMSstr = "Data Source=192.168.0.241;Initial Catalog=sms;uid=sa;Max Pool Size=100000;connection lifetime=0 "
            conDMIS = "Data Source=192.168.0.241;Initial Catalog=DOCUMENTCONTROL;uid=sa;Max Pool Size=100000;connection lifetime=0 "

            conFMD = "Data Source=192.168.0.241;Initial Catalog=FMS;uid=sa;Max Pool Size=100000;connection lifetime=0 "

            con_mel = "Data Source=192.168.0.252;Initial Catalog=melhrmis;uid=sa;Max Pool Size=100000;connection lifetime=0 "
            con_lig = "Data Source=192.168.0.241;Initial Catalog=mlihrmis;uid=sa;Max Pool Size=100000;connection lifetime=0 "
            con_Os = "Data Source=192.168.0.241;Initial Catalog=outhrmis;uid=sa;Max Pool Size=100000;connection lifetime=0 "

            conCRMstr = "Data Source=192.168.0.241;Initial Catalog=mmCRM;uid=sa;Max Pool Size=100000;connection lifetime=0 "

        End Function
        Public Function rptcon()
            '************ crystalreport servername  configuration change setting***********
            sver = "192.168.0.241"
            dbname = "hrmis"
            uid = "sa"
            pw = ""
        End Function

        Public Function Open_Con_mel()
            '************* CALLING CONNECTION *********
            Con = New SqlConnection(con_mel)
            Con1 = New SqlConnection(Con_mel)
            Con2 = New SqlConnection(con_mel)
            DAP = New SqlDataAdapter
        End Function
        Public Function Open_Con_lit()
            '************* CALLING CONNECTION *********
            Con = New SqlConnection(con_lig)
            Con1 = New SqlConnection(con_lig)
            Con2 = New SqlConnection(con_lig)
            DAP = New SqlDataAdapter
        End Function
        Public Function Open_Con_out()
            '************* CALLING CONNECTION *********
            Con = New SqlConnection(con_Os)
            Con1 = New SqlConnection(con_Os)
            Con2 = New SqlConnection(con_Os)
            DAP = New SqlDataAdapter
        End Function

        Public Function Open_Con()
            '************* CALLING CONNECTION *********
            Con = New SqlConnection(constr)
            Con1 = New SqlConnection(constr)
            Con2 = New SqlConnection(constr)
            DAP = New SqlDataAdapter
        End Function
        Public Function Open_Con_dMIS()
            '************* CALLING CONNECTION *********
            Con = New SqlConnection(conDMIS)
            Con1 = New SqlConnection(conDMIS)
            Con2 = New SqlConnection(conDMIS)
            DAP = New SqlDataAdapter
        End Function
        Public Sub dbSp_open_dmis(ByVal SP As String)
            Con = New SqlConnection(conDMIS)
            Con.Open()
            Cmd = New SqlCommand(SP, Con)
            Cmd.CommandType = CommandType.StoredProcedure
            DAP = New SqlDataAdapter(Cmd)
        End Sub

        ' .................................... for SP ..................................
        Public Sub dbSp_open(ByVal SP As String)
            Con = New SqlConnection(constr)
            Con.Open()
            Cmd = New SqlCommand(SP, Con)
            Cmd.CommandType = CommandType.StoredProcedure
            DAP = New SqlDataAdapter(Cmd)
        End Sub
        Public Function Open_Con_FMD()
            '************* CALLING CONNECTION *********
            Con = New SqlConnection(conFMD)
            Con1 = New SqlConnection(conFMD)
            Con2 = New SqlConnection(conFMD)
            DAP = New SqlDataAdapter
        End Function
        Public Sub dbSp_open_FMD(ByVal SP As String)
            Con = New SqlConnection(conFMD)
            Con.Open()
            Cmd = New SqlCommand(SP, Con)
            Cmd.CommandType = CommandType.StoredProcedure
            DAP = New SqlDataAdapter(Cmd)
        End Sub
        Public Function Open_Con_SMS()
            '************* CALLING CONNECTION *********
            Con = New SqlConnection(conSMSstr)
            Con1 = New SqlConnection(conSMSstr)
            Con2 = New SqlConnection(conSMSstr)
            DAP = New SqlDataAdapter
        End Function

        Public Sub dbSp_open_SMS(ByVal SP As String)
            Con = New SqlConnection(conSMSstr)
            Con.Open()
            Cmd = New SqlCommand(SP, Con)
            Cmd.CommandType = CommandType.StoredProcedure
            DAP = New SqlDataAdapter(Cmd)
        End Sub
        Public Sub db_close()
            Con.Close()
        End Sub

        Public Shared Function Open_Empmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM empmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "emp")
            Return DS
        End Function
        Public Shared Function Open_Department(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM department " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "Dept")
            Return DS
        End Function
        Public Shared Function Open_Section(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM sectionmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "sect")
            Return DS
        End Function
        Public Shared Function Open_BT(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM acc_businesstrip " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "bt")
            Return DS
        End Function
        Public Shared Function Open_Currency(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT     * FROM         Pur_currencymaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "currency")
            Return DS
        End Function
        Public Shared Function Open_TC(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM hrmis_tc_travellingclaimnew " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "TC")
            Return DS
        End Function
        Public Shared Function Open_clinic(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM clinicstaffgatepass " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "clinic")
            Return DS
        End Function
      
        Public Shared Function Open_Letter(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strselection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM HRMIS_ER_LETTER " & strselection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strselection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "letter")
            Return DS
        End Function
        Public Shared Function Open_Lettermasterstatus(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strselection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM HRMIS_ER_MASTER_LETTER " & strselection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strselection, cnn)
            End Select
            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "Lettermasterstatus")
            Return DS
        End Function

        Public Shared Function Open_appcharacter(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM app_charactersetting " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function

        Public Shared Function Open_MaxOTsettings(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM tbl_MaxOTSetting " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function

        Public Shared Function Open_MaxWeeklyOT(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM OT_WeekMaxHrs " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_PHMASTER(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM TMS_PHMASTER " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function


        Public Shared Function Open_OTeligible(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM OT_ElligibleStaff " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_approvalOTHod(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM otentry " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_Tempot(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Ot_TempTotWeekhrs " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_SubKPI(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM kpi_subsetting" & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_KPIGrade(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM kpi_grade_result" & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_KPIDAILY(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM kpi_DAILYUPDATE" & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function

        '' programmer one files
        Public Shared Function Open_approvalLAHod(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM leaveabsentism " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function

        Public Shared Function Open_safetyDE(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Safety_dispossaldetails " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function

        Public Shared Function Open_sludgemaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM sludgemaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "SM")
            Return DS
        End Function

        Public Shared Function Open_sludgeinventory(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM sludgeinventory " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "SI")
            Return DS
        End Function

        Public Shared Function Open_sludgeupd(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM sludgeinventory " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dssafety = New DataSet
            da.Fill(dssafety, "SIU")
            Return dssafety
        End Function



        Public Shared Function Open_DomwasteCons(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Safety_domesticwasteconsignment" & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dssafety = New DataSet
            da.Fill(dssafety, "condet")
            Return dssafety
        End Function
        Public Shared Function Open_Domwasteitem(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Safety_domesticwasteconsignmentdetails" & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dssafety = New DataSet
            da.Fill(dssafety, "condet")
            Return dssafety
        End Function
        Public Shared Function Open_Schedwasteitem(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Safety_schedulewasteconsignmentdetails" & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dssafety = New DataSet
            da.Fill(dssafety, "condet")
            Return dssafety
        End Function
        Public Shared Function Open_appraisal(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM app_operatorappraisal " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_empappraisal(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM emp_appraisalnote " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function
        Public Shared Function Open_appraisalnote(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM emp_appraisalnote " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "character")
            Return DS
        End Function

        Public Shared Function Open_Fir_temperaturecheck(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Fir_temperaturecheck" & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "tmp")
            Return DS
        End Function
    End Class
End Namespace

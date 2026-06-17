'''''''#author: ravi''
' Dt: Dec28' 05 ' ''''''''''
Imports System
Imports System.Web
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Namespace emanagement
    Public Class netglobal
        Inherits System.Web.UI.Page
        Const bannerColor = "#5EB9BB"
        Const backColor = "#99CCCC"
        Const reportBackColor = "White"
        Const tableHeaderColor = "#01A8B6"
        Const tablebodycolor = "#E1FFFF"
        Const TableheaderColor_L = "#01A8B6"
        Const Approvebodycolor = "#E1FFF"
        Const Viewed_Color = "#76CFD2"

        Const InterviewSubject = "Interview"
        Public Shared curclick As Integer = 0
        Private fstrDBResult As String
        Private fstrDBErrorMsg As String
        Public Shared sconnstrings As String
        Public Shared ErrInConn
        Public Shared strPath, MsgBoxTitle, strUser As String
        Public Shared decr, encr, objfso As Object
        Public Shared tmpserver_name As String
        Public Shared tmpuser_id As String
        Public Shared newDecString As String
        Public Shared newEncString As String
        Public Shared strInsert As String
        Public Shared tmpDatabase_name As String
        Public Shared bdbserver As String
        Public Shared modulelink As String
        Public Shared eTraining_database, txtConnPath As String
        Public Shared conn_path, tmpPassword, tempstring As String
        Public Shared AdminnConnEncr, HRConnEncr, DBconnEncr As String
        Public Shared AdminnConnDecr, HRConnDencr, DBconnDecr As String

        Public Shared COMP_CD
        Public Shared ihrms_cnn, adocon
        Public Shared tablewidth
        Public Shared fs, result
        Public Shared iW, jW
        Public Shared sConnString, sConnStringM, sConnStringSMS, sConnString1, sConnString2, sConnString3, sConnStringHR, Admin_cnn, SConnStrPur As String
        Public Shared uid, pwd, cnnstring As String
        Public Shared password, userId, lcuserid, lcpassword, lcmessage, lccurrent_Password, tmpcompNAME, tmpCompCode As String

        Public Shared ds, dsS, ds1, ds2, ds3, ds4, ds5, ds11, ds12, dsGetScrNames, dsPerm, dsFrmName, dsStored, dsCur, dsDEnq, dsCVInvoProd As DataSet
        Public Shared dr, dr1, dr2, dr11, dr5, drGetScrNames, drFrmname, drPerm, drDEnq As DataRow
        Public Shared cb, cb1, cbStored As SqlCommandBuilder
        Public Shared daconnHR As SqlDataAdapter
        Public Shared daConnWeb, daConnWeb1, daConnWeb2, daConnWeb3, daConnWebSMS, da11, daConnWebHR, daConnWebHR1, daConnWebPur As SqlDataAdapter
        Public Shared daConnADMIN As SqlDataAdapter
        Public Shared DBInsert, DBedit As SqlCommand
        Public Shared DAeHrmsWeb As SqlDataAdapter
        Public Shared DataReader As SqlDataReader
        Public Shared dbConnEClaim As SqlConnection
        Public Shared dbConnWeb, dbConnWeb1, dbConnWeb2, dbConnWeb3, dbConnWebHR, dbConnWebSMS, dbConnWebHR1, dbConnWebpur As SqlConnection
        Public Shared dbConnEHrmsWeb As SqlConnection
        Public Shared dbConnHR, SQL_Conn, conn, connhr, dbConnADMIN As SqlConnection
        Public Shared command As SqlCommand
        Public Shared command1 As SqlCommand
        Public Shared adapter As SqlDataAdapter
        Public Shared adapter1 As SqlDataAdapter
        Public Shared drStored As DataRow
        'Dim Sqlcommand As Sqlcommand
        'Dim sqldbCommand As SqlClient.Sqlcommand
        Public Shared LoginDT As DateTime
        Public Shared pdtflag As Boolean

        'Public Shared smssqlServerName As String
        'Public Shared smssqlDBName As String
        'Public Shared smssqlUid As String
        'Public Shared smssqlPwd As String

        ' Create Connection Statement
        Public Function db_cn()
            tmpserver_name = "CRM"
            tmpDatabase_name = "mmCRM"
            'sConnString = "Data Source=mmsbsql2;Initial Catalog=mmCRM;uid=sa;Pwd="";;pwd=S3T64v+"
            'sConnString2 = "Data Source=mmsbsql2;Initial Catalog=HRMIS;uid=sa;Pwd="";;pwd=S3T64v+"
            'sConnString = "Data Source=CRM;Initial Catalog=mmCRM;uid=sa;Pwd="";;pwd=ASV"
            'sConnString2 = "Data Source=CRM;Initial Catalog=HRMIS;uid=sa;Pwd="";;pwd=ASV"
            'sConnString = "Data Source=NB09;Initial Catalog=PoHrmis;uid=sa;Pwd="";;pwd=;Max Pool Size=100;connection lifetime=30"
            'sConnStringSMS = "Data Source=NB09;Initial Catalog=POSSEHL;uid=sa;Pwd="";;pwd=;Max Pool Size=100;connection lifetime=30"
            'sConnString2 = "Data Source=NB09;Initial Catalog=PoHRMIS;uid=sa;Pwd="";;pwd=;Max Pool Size=100;connection lifetime=30"
            'sConnString = "Data Source=CRM;Initial Catalog=mmCRM;uid=sa;Pwd="";;pwd=;Max Pool Size=100;connection lifetime=30"
            'sConnString2 = "Data Source=192.168.0.241;Initial Catalog=HRMIS;uid=sa;Pwd="";;pwd=;Max Pool Size=100;connection lifetime=30"
            'SconnStrPur = "Data Source=192.168.0.241;Initial Catalog=purchasing;uid=sa;Pwd="";;pwd=;Max Pool Size=100;connection lifetime=30"
            'sConnString = "Data Source=MEIPL;Initial Catalog=meipl_survey;uid=sa;Pwd="";;pwd=MEIPL4rM;Max Pool Size=100;connection lifetime=30"
            'sConnString2 = "Data Source=MEIPL;Initial Catalog=HRMIS;uid=sa;;pwd=MEIPL4rM;Max Pool Size=100;connection lifetime=30"
            sConnString = "Data Source=192.168.0.241;Initial Catalog=PoHrmis;uid=sa;Max Pool Size=100;connection lifetime=30"
            sConnStringSMS = "Data Source=192.168.0.241;Initial Catalog=SMS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
            sConnString2 = "Data Source=192.168.0.241;Initial Catalog=HRMIS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
            sConnString = "Data Source=192.168.0.241;Initial Catalog=HRMIS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
            sConnStringM = "Data Source=192.168.0.248;Initial Catalog=MMaintenance;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
            'sConnStringSMS = "Data Source=NB09;Initial Catalog=POSSEHL;uid=sa;Pwd="";;Max Pool Size=100;connection lifetime=30"
            'sConnString2 = "Data Source=NB09;Initial Catalog=PoHRMIS;uid=sa;Pwd="";;Max Pool Size=100;connection lifetime=30"
            'sqlServerName = "10.10.10.197"
            'sqlDBName = "PoHrmis"
            'sqlUid = "sa"
            'sqlPwd = "pemhr"
            'smssqlServerName = "NB09"
            'smssqlDBName = "SMS"
            'smssqlUid = "sa"
            'smssqlPwd = ""
        End Function
        Public Function GetLogonInfo() As TableLogOnInfo
            Dim LogonInfo As New TableLogOnInfo
            LogonInfo.ConnectionInfo.ServerName = "192.168.0.241"
            LogonInfo.ConnectionInfo.UserID = "sa"
            LogonInfo.ConnectionInfo.Password = ""
            LogonInfo.ConnectionInfo.DatabaseName = "mmCRM"
            Return LogonInfo
        End Function
        Public Sub db_open()
            dbConnWeb = New SqlConnection(sConnString)
            daConnWeb = New SqlDataAdapter
        End Sub

        Public Sub dbHR_open()
            dbConnWebHR = New SqlConnection(sConnString2)
            daConnWebHR = New SqlDataAdapter
        End Sub

        Public Sub dbPuR_open()
            dbConnWebpur = New SqlConnection(SConnStrPur)
            daConnWebPur = New SqlDataAdapter
        End Sub

        Public Sub dbSMS_open()
            dbConnWebSMS = New SqlConnection(sConnStringSMS)
            daConnWebSMS = New SqlDataAdapter
        End Sub

        Public Sub dbHR1_open()
            dbConnWebHR1 = New SqlConnection(sConnString2)
            daConnWebHR1 = New SqlDataAdapter
        End Sub

        Public Sub dbSp_open(ByVal sp As String)
            dbConnWeb = New SqlConnection(sConnString)
            dbConnWeb.Open()
            command = New SqlCommand(sp, dbConnWeb)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
        End Sub

        Public Sub dbSp1_open(ByVal sp1 As String)
            dbConnWeb1 = New SqlConnection(sConnString)
            dbConnWeb1.Open()
            command1 = New SqlCommand(sp1, dbConnWeb1)
            command1.CommandType = CommandType.StoredProcedure
            adapter1 = New SqlDataAdapter(command1)
        End Sub
        Public Sub dbSpSMS_open(ByVal sp As String)
            dbConnWebSMS = New SqlConnection(sConnStringSMS)
            dbConnWebSMS.Open()
            command = New SqlCommand(sp, dbConnWebSMS)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
        End Sub

        Public Function dsSp_open(ByVal srcTable As String)
            dsStored = New DataSet
            adapter.Fill(dsStored, srcTable)
            dbConnWeb.Close()
            Return dsStored
        End Function

        Public Sub db_open1()
            dbConnWeb1 = New SqlConnection(sConnString)
            daConnWeb1 = New SqlDataAdapter
        End Sub

        Public Sub db_open2()
            dbConnWeb2 = New SqlConnection(sConnString)
            daConnWeb2 = New SqlDataAdapter
        End Sub

        Public Sub db_open3()
            dbConnWeb3 = New SqlConnection(sConnString)
            daConnWeb3 = New SqlDataAdapter
        End Sub

        Public Sub db_close2()
            dbConnWeb2.Close()
        End Sub
        Public Sub db_close3()
            dbConnWeb3.Close()
        End Sub
        Public Sub db_close()
            dbConnWeb.Close()
        End Sub
        Public Sub dbSp_close()
            dbConnWeb.Close()
        End Sub
        Public Sub db_close1()
            dbConnWeb1.Close()
        End Sub
        Public Sub dbHR_close()
            dbConnWebHR.Close()
        End Sub
        Public Sub dbSMS_close()
            dbConnWebSMS.Close()
        End Sub
        Public Sub dbHR1_close()
            dbConnWebHR1.Close()
        End Sub

        Public Shared Function Round(ByVal d As Decimal, ByVal decimals As Integer) As Decimal
            Return System.Math.Round(d, 4)
        End Function
        Public Shared Function Roundto2(ByVal d As Decimal, ByVal decimals As Integer) As Decimal
            Return System.Math.Round(d, 2)
        End Function
        Public Shared Function Roundto1(ByVal d As Decimal, ByVal decimals As Integer) As Decimal
            Return System.Math.Round(d, 1)
        End Function

        'Public Function ChkLastLogin(ByVal ses As String)
        '    db_cn()
        '    db_open()
        '    Dim uidHere = ses 'Session("userID")
        '    ds = Open_Users(dbConnWeb, daConnWeb, 2, "select noflogins,Date_time from users WHERE userID = '" & uidHere & "' ")
        '    If ds.Tables("users").Rows.Count > 0 Then
        '        dr = ds.Tables("users").Rows(0)
        '        Dim iHere
        '        Dim dHere
        '        If Not TypeOf (dr("noflogins")) Is System.DBNull Then
        '            dr("noflogins") = Val(dr("noflogins")) + 1
        '            iHere = dr("noflogins")
        '        Else
        '            dr("noflogins") = 1
        '            iHere = 1
        '        End If
        '        dr("Date_time") = Now  ' CDate(Format(Now, "dd/MM/yyyy hh:mm"))
        '        dHere = dr("Date_Time")
        '        ds = Open_Users(dbConnWeb, daConnWeb, 2, "UPDATE users SET noflogins ='" & iHere & "', Date_Time ='" & dHere & "' WHERE userID = '" & uidHere & "' ")
        '    End If
        '    db_close()
        'End Function
        Public Function ChkLastLogin(ByVal ses As String)
            db_cn()
            db_open()
            Dim uidHere = ses 'Session("userID")
            ds = Open_Users(dbConnWeb, daConnWeb, 2, "select noflogins,empcode from tbl_noflogins WHERE empcode = '" & uidHere & "' ")
            If ds.Tables("users").Rows.Count > 0 Then
                dr = ds.Tables("users").Rows(0)
                Dim iHere
                Dim dHere
                If Not TypeOf (dr("noflogins")) Is System.DBNull Then
                    dr("noflogins") = Val(dr("noflogins")) + 1
                    iHere = dr("noflogins")
                Else
                    dr("noflogins") = 1
                    iHere = 1
                End If
                'dr("Date_time") = Now  ' CDate(Format(Now, "dd/MM/yyyy hh:mm"))
                'dHere = dr("Date_Time")
                ds = Open_Users(dbConnWeb, daConnWeb, 2, "UPDATE tbl_noflogins SET noflogins ='" & iHere & "' WHERE empcode = '" & uidHere & "' ")
            End If
            db_close()
        End Function
        Public Shared Function Open_cussamplereturn(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM cussamplereturn " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "cussamplereturn")
            Return ds1
        End Function

        Public Shared Function Open_FORSURVEY(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM cussamplereturn " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "FORSURVEY")
            Return ds1
        End Function

        Public Shared Function Open_uploading(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM uploading " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "uploading")
            Return ds1
        End Function

        Public Shared Function Open_SMS_LINK(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM SMS_LINK " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "SMS_LINK")
            Return ds1
        End Function
        Public Shared Function Open_FORSURVEY1(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM cussamplereturn " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "FORSURVEY1")
            Return ds1
        End Function

        Public Shared Function Open_ReturnGoods(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM returngoods " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "ReturnGoods")
            Return ds1
        End Function

        Public Shared Function Open_acc_customerrequesttemp(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM acc_customerrequesttemp " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "acc_customerrequesttemp")
            Return ds1
        End Function

        ''''''''''''''''''''''''open tables'''''''''''''
        Public Shared Function Open_Users(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM users " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "users")
            Return ds
        End Function
        Public Shared Function Open_HRUsers(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM hrusers " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "HRusers")
            Return ds
        End Function
        Public Shared Function Open_PoHOD(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM PoHOD " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "PoHOD")
            Return ds
        End Function
        Public Shared Function Open_PosEMP(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM employee " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "PosEMP")
            Return ds
        End Function
        Public Shared Function Open_PosLeaveEnt(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Leaveentitlement " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "PosLeaveEnt")
            Return ds
        End Function
        Public Shared Function Open_PosLeaveMFlg(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT sum(noday) as Coun FROM Leave " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "PosLeaveMFlg")
            Return ds
        End Function
        Public Shared Function Open_Country(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM country " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "Country")
            Return ds
        End Function
        Public Shared Function Open_ShipmentCost(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM ShipmentCost " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "ShipmentCost")
            Return ds
        End Function

        Public Shared Function Open_BookedInvNos(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM BookedInvNos " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "BookedInvNos")
            Return ds
        End Function
        Public Shared Function Open_department(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM department " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "department")
            Return ds
        End Function

        Public Shared Function Open_SalesVsCustomer(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM SalesVsCustomer " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "SalesVsCustomer")
            Return ds
        End Function

        Public Shared Function Open_BuildCapacity(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM BuildCapacity " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "BuildCapacity")
            Return ds
        End Function

        Public Shared Function Open_SubCustomers(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM SubCustomers " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "SubCustomers")
            Return ds1
        End Function

        Public Shared Function Open_CurrencyMaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM CurrencyMaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dsCur = New DataSet
            da.Fill(dsCur, "CurrencyMaster")
            Return dsCur
        End Function

        Public Shared Function Open_Budget_LC3Yexchangeprice(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Budget_LC3Yexchange " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dsCur = New DataSet
            da.Fill(dsCur, "Budget_LC3Yexchangeprice")
            Return dsCur
        End Function

        Public Shared Function Open_CVINVOProdMaster(ByVal cnn As SqlConnection, ByVal daCvInvoProd As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    daCvInvoProd.SelectCommand = New SqlCommand("SELECT * FROM CurrencyMaster " & strSelection, cnn)
                Case 2
                    daCvInvoProd.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(daCvInvoProd)
            dsCVInvoProd = New DataSet
            daCvInvoProd.Fill(dsCVInvoProd, "CVINVOProdMaster")
            Return dsCVInvoProd
        End Function

        Public Shared Function Open_hlpgdept(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM hlpgdept " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "hlpgdept")
            Return ds
        End Function

        Public Shared Function Open_hlpgdept4(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM hlpgdept " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds4 = New DataSet
            da.Fill(ds4, "hlpgdept4")
            Return ds4
        End Function

        Public Shared Function Open_empmasterUsers(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand("SELECT * FROM users " & strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da)
            ds1 = New DataSet
            da.Fill(ds1, "empmasterusers")
            Return ds1
        End Function
        Public Shared Function Open_empmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM empmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "empmaster")
            Return ds
        End Function
        Public Shared Function Open_Productmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM productmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "productmaster")
            Return ds
        End Function
        Public Shared Function Open_Enqmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Enqmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "Enqmaster")
            Return ds
        End Function
        Public Shared Function Open_Quotmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Quotmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "Quotmaster")
            Return ds
        End Function
        Public Shared Function Open_QuotmasterForApp(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Quotmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "QuotmasterForApp")
            Return ds
        End Function

        Public Shared Function Open_POmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM POmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "POmaster")
            Return ds
        End Function
        Public Shared Function Open_PO_EDmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM PO_EDmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "PO_EDmaster")
            Return ds
        End Function

        Public Shared Function Open_POmasterForInv(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM POmaster " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "POmaster")
            Return ds1
        End Function
        Public Shared Function Open_OSmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM OSmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "OSmaster")
            Return ds
        End Function

        Public Shared Function Open_DebCredMaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM DebCredMaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "DebCredMaster")
            Return ds
        End Function

        Public Shared Function Open_DebCredDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM DebCredDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "DebCredDetail")
            Return ds
        End Function

        Public Shared Function Open_DSchedule(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM DSchedule " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "DSchedule")
            Return ds
        End Function

        Public Shared Function Open_DSchedule1(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM DSchedule " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "DSchedule1")
            Return ds1
        End Function
        Public Shared Function Open_DelvoDSchedule(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM DSchedule " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "DelvoDSchedule")
            Return ds1
        End Function
        Public Shared Function Open_DelvoDSchedule1(ByVal cnn As SqlConnection, ByVal da2 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da2.SelectCommand = New SqlCommand("SELECT * FROM DSchedule " & strSelection, cnn)
                Case 2
                    da2.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da2)
            ds2 = New DataSet
            da2.Fill(ds2, "DelvoDSchedule1")
            Return ds2
        End Function
        Public Shared Function Open_DelvoDSchedule2(ByVal cnn As SqlConnection, ByVal da3 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da3.SelectCommand = New SqlCommand("SELECT * FROM DSchedule " & strSelection, cnn)
                Case 2
                    da3.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da3)
            ds3 = New DataSet
            da3.Fill(ds3, "DelvoDSchedule2")
            Return ds3
        End Function
        Public Shared Function Open_DelvoDSchedule3(ByVal cnn As SqlConnection, ByVal da4 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da4.SelectCommand = New SqlCommand("SELECT * FROM DSchedule " & strSelection, cnn)
                Case 2
                    da4.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da4)
            ds4 = New DataSet
            da4.Fill(ds4, "DelvoDSchedule3")
            Return ds4
        End Function
        Public Shared Function Open_DelvoDSchedule4(ByVal cnn As SqlConnection, ByVal da5 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da5.SelectCommand = New SqlCommand("SELECT * FROM DSchedule " & strSelection, cnn)
                Case 2
                    da5.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da5)
            ds5 = New DataSet
            da5.Fill(ds5, "DelvoDSchedule4")
            Return ds5
        End Function
        Public Shared Function Open_DelvoInvo(ByVal cnn As SqlConnection, ByVal da5 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da5.SelectCommand = New SqlCommand("SELECT * FROM invdetail " & strSelection, cnn)
                Case 2
                    da5.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da5)
            ds5 = New DataSet
            da5.Fill(ds5, "DelvoInvo")
            Return ds5
        End Function
        Public Shared Function Open_INVMaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM INVMaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "INVMaster")
            Return ds
        End Function
        Public Shared Function Open_INVMasterREV(ByVal cnn As SqlConnection, ByVal da3 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da3.SelectCommand = New SqlCommand("SELECT * FROM INVMasterREV " & strSelection, cnn)
                Case 2
                    da3.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da3)
            ds3 = New DataSet
            da3.Fill(ds3, "INVMasterREV")
            Return ds3
        End Function
        Public Shared Function Open_INVDetailREV(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM INVdetailREV " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "INVdetailREV")
            Return ds
        End Function
        Public Shared Function Open_RESETINVDetail(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM INVDetail " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "INVdetail")
            Return ds1
        End Function
        Public Shared Function Open_INVMaster12(ByVal cnn As SqlConnection, ByVal da12 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da12.SelectCommand = New SqlCommand("SELECT * FROM INVMaster " & strSelection, cnn)
                Case 2
                    da12.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da12)
            ds12 = New DataSet
            da12.Fill(ds12, "INVMaster")
            Return ds12
        End Function
        Public Shared Function Open_BDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM BDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "BDetail")
            Return ds
        End Function
        Public Shared Function Open_NormalUser(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM NormalUser " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "NormalUser")
            Return ds
        End Function
        ''''''''''''''''''''''''''purchasing'''''''''''''''''''''''''''''''''''''''
        Public Shared Function Open_Stock(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Stock " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "Stock")
            Return ds
        End Function
        Public Shared Function Open_OtherOverHead(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM OtherOverHead " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "OtherOverHead")
            Return ds
        End Function

        Public Shared Function Open_AdminOtherCost(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM AdminOtherCost " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "AdminOtherCost")
            Return ds
        End Function

        Public Shared Function Open_budgetmaster(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM budgetmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "budgetmaster")
            Return ds
        End Function
        ''''''''''''''''''''''''''''''''''''''''''''''purchasing'''''''''''''''''''''

        Public Shared Function Open_InvHeader(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM InvHeader " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "InvHeader")
            Return ds
        End Function
        Public Shared Function Open_MISempmaster(ByVal cnn As SqlConnection, ByVal daA As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    daA.SelectCommand = New SqlCommand("SELECT * FROM empmaster " & strSelection, cnn)
                Case 2
                    daA.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(daA)
            dsS = New DataSet
            daA.Fill(dsS, "empmaster")
            Return dsS
        End Function
        Public Shared Function Open_EnqDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM EnqDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dsDEnq = New DataSet
            da.Fill(dsDEnq, "EnqDetail")
            Return dsDEnq
        End Function

        Public Shared Function Open_QuotDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM QuotDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "QuotDetail")
            Return ds
        End Function

        Public Shared Function Open_LQPQuotDetail(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM QuotDetail " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "LQPQuotDetail")
            Return ds1
        End Function

        Public Shared Function Open_PODetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM PODetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "PODetail")
            Return ds
        End Function
        Public Shared Function Open_PO_EDDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM PO_EDDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "PO_EDDetail")
            Return ds
        End Function
        Public Shared Function Open_OSDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM OSDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "OSDetail")
            Return ds
        End Function
        Public Shared Function Open_OSDetailforDS(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM OSDetail " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "OSDetailforDS")
            Return ds1
        End Function
        Public Shared Function Open_INVDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM INVDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "INVDetail")
            Return ds
        End Function
        Public Shared Function Open_INVDetail1(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM INVDetail " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "INVDetail")
            Return ds1
        End Function
        Public Shared Function Open_INVDetailforCOCV(ByVal cnn As SqlConnection, ByVal da11 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da11.SelectCommand = New SqlCommand("SELECT * FROM INVDetail " & strSelection, cnn)
                Case 2
                    da11.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da11)
            ds11 = New DataSet
            da11.Fill(ds11, "INVDetailforCOCV")
            Return ds11
        End Function
        Public Shared Function Open_INVMASTDETA(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "INVMASTDETA")
            Return ds
        End Function

        Public Shared Function Open_Modscr(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM modscr " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            dsGetScrNames = New DataSet
            da.Fill(dsGetScrNames, "modscr")
            Return dsGetScrNames
        End Function


        Public Shared Function open_CustMaster(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM custmaster " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "CustMaster")
            Return ds1
        End Function

        Public Shared Function Open_ModAccPerm(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM ModAccPerm " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            dsPerm = New DataSet
            da1.Fill(dsPerm, "ModAccPerm")
            Return dsPerm
        End Function

        Public Shared Function open_access_module(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "access_module")
            Return ds
        End Function

        Public Shared Function open_SYSPARAM(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "sysparam")
            Return ds
        End Function

        Public Shared Function open_Events(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "EVENTS")
            Return ds
        End Function

        Public Shared Function Open_NewCustReg(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM newcustregmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "newcustreg")
            Return ds
        End Function

        Public Shared Function Open_ConClosingStock(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM ConClosingStock " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "ConClosingStock")
            Return ds
        End Function

        Public Shared Function Open_CustomerProdDesc(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM CustomerProdDesc " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "CustomerProdDesc")
            Return ds
        End Function

        Public Shared Function Open_CoMmast(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM commaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "commast")
            Return ds
        End Function

        Public Shared Function Open_COUSAGE(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM COUSAGE " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "COUSAGE")
            Return ds
        End Function

        Public Shared Function Open_COUSAGE_BUDGET(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM COUSAGE_BUDGET " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "COUSAGE_BUDGET")
            Return ds
        End Function

        Public Shared Function Open_COUSAGE_est_BUDGET(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM COUSAGE_est_BUDGET " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "COUSAGE_est_BUDGET")
            Return ds
        End Function

        Public Shared Function Open_Sales_BUDGET(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM Sales_BUDGET " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "Sales_BUDGET")
            Return ds
        End Function

        Public Shared Function Open_COtoCV(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM COtoCV " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "COtoCV")
            Return ds
        End Function

        Public Shared Function Open_COtoCVDetail(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM COtoCVDetail " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "COtoCVDetail")
            Return ds
        End Function

        Public Shared Function Open_ChkUserPerm(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet

            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM newcustregmaster " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)


            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "newcustreg")
            Return ds
        End Function

        Public Function SimpleCrypt(ByVal Text As String) As String
            Dim strTempChar As String, i As Integer
            For i = 1 To Len(Text)
                If Asc(Mid$(Text, i, 1)) < 128 Then
                    strTempChar = CType(Asc(Mid$(Text, i, 1)) + 128, String)
                ElseIf Asc(Mid$(Text, i, 1)) > 128 Then
                    strTempChar = CType(Asc(Mid$(Text, i, 1)) - 128, String)
                End If
                Mid$(Text, i, 1) = Chr(CType(strTempChar, Integer))
            Next
            Return Text
        End Function
        Public Function CanViewOrNot(ByVal username As String) As String

        End Function

        '''''''''''''''''''''''''formating date'''''''''''''''''''''''''''''''''''''''

        'Function date_format()
        '    Dim lcdate2
        '    'lcDate2=request.Cookies("EHRMSWEB")("Dateformat")
        '    lcDate2 = session("Dateformat")
        '    If lcDate2 = "DD/MM/YYYY" Then
        '        date_format = 1
        '    ElseIf lcDate2 = "MM/DD/YYYY" Then
        '        date_format = 2
        '    ElseIf lcDate2 = "YYYY/MM/DD" Then
        '        date_format = 3
        '    ElseIf lcDate2 = "YYYY/DD/MM" Then
        '        date_format = 4
        '    Else
        '        date_format = 1
        '    End If
        'End Function

        'Function date_date_long(ByVal psDate)
        '    Dim lndatefmt, tmppsdate, daycounter, lcday, moncounter, lcmon, lcyear, yearcounter, lcresult
        '    'alert(psdate)
        '    lnDateFmt = date_format()
        '    'alert("dateformat is"&lnDateFmt)
        '    If IsDate(psDate) Then
        '        tmppsdate = psDate
        '        '31/12/2000 
        '        If lnDateFmt = 1 Then
        '            If psDate <> "" And IsDate(psDate) Then
        '                Daycounter = InStr(1, tmppsdate, "/")
        '                If Daycounter > 0 Then
        '                    lcDay = Mid(tmppsdate, 1, Daycounter - 1)
        '                    If Len(lcDay) < 2 Then
        '                        lcDay = "0" & lcDay
        '                    End If
        '                End If
        '                Moncounter = InStr(Daycounter + 1, tmppsdate, "/")
        '                If Moncounter > 0 Then
        '                    lcMon = Mid(tmppsdate, DayCounter + 1, Moncounter - (daycounter + 1))
        '                    If Len(lcMon) < 2 Then
        '                        lcMon = "0" & lcMon
        '                    End If
        '                End If
        '                lcyear = Right(tmppsdate, Len(tmppsdate) - moncounter)
        '            End If
        '            '12/31/2002 
        '        ElseIf lnDateFmt = 2 Then
        '            '  alert("I am second")
        '            If psDate <> "" And IsDate(psDate) Then
        '                Moncounter = InStr(1, tmppsdate, "/")
        '                If Moncounter > 0 Then
        '                    lcMon = Mid(tmppsdate, 1, Moncounter - 1)
        '                    If Len(lcMon) < 2 Then
        '                        lcMon = "0" & lcMon
        '                    End If
        '                End If
        '                Daycounter = InStr(Moncounter + 1, tmppsdate, "/")
        '                If Daycounter > 0 Then
        '                    lcDay = Mid(tmppsdate, MonCounter + 1, Daycounter - (Moncounter + 1))
        '                    If Len(lcDay) < 2 Then
        '                        lcDay = "0" & lcDay
        '                    End If
        '                End If
        '                lcyear = Right(tmppsdate, Len(tmppsdate) - Daycounter)
        '            End If
        '            '2000/12/31 
        '        ElseIf lnDateFmt = 3 Then
        '            If psDate <> "" And IsDate(psDate) Then
        '                yearcounter = InStr(1, tmppsdate, "/")
        '                If Yearcounter > 0 Then
        '                    lcYear = Mid(tmppsdate, 1, Yearcounter - 1)
        '                    'if len(lcYear) < 2 then
        '                    '	lcYear = "0" & lcYear
        '                    'end if
        '                End If
        '                Moncounter = InStr(Yearcounter + 1, tmppsdate, "/")
        '                If Moncounter > 0 Then
        '                    lcMon = Mid(tmppsdate, YearCounter + 1, Moncounter - (Yearcounter + 1))
        '                    If Len(lcMon) < 2 Then
        '                        lcMon = "0" & lcMon
        '                    End If
        '                End If
        '                lcDay = Right(tmppsdate, Len(tmppsdate) - Moncounter)
        '                If Len(lcDay) < 2 Then
        '                    lcDay = "0" & lcDay
        '                End If
        '            End If
        '            '2000/31/12 - 4
        '        ElseIf lnDateFmt = 4 Then
        '            If psDate <> "" And IsDate(psDate) Then
        '                yearcounter = InStr(1, tmppsdate, "/")
        '                If Yearcounter > 0 Then
        '                    lcYear = Mid(tmppsdate, 1, Yearcounter - 1)
        '                    'if len(lcYear) < 2 then
        '                    '	lcYear = "0" & lcYear
        '                    'end if
        '                End If
        '                Daycounter = InStr(Yearcounter + 1, tmppsdate, "/")
        '                If Daycounter > 0 Then
        '                    lcDay = Mid(tmppsdate, YearCounter + 1, Daycounter - (Yearcounter + 1))
        '                    If Len(lcDay) < 2 Then
        '                        lcDay = "0" & lcDay
        '                    End If
        '                End If
        '                lcMon = Right(tmppsdate, Len(tmppsdate) - Daycounter)
        '                If Len(lcMon) < 2 Then
        '                    lcMon = "0" & lcMon
        '                End If
        '            End If
        '        End If
        '        lcResult = CLng(lcyear & lcMon & lcDay)
        '    Else
        '        lcResult = 0
        '    End If
        '    date_date_long = lcResult
        '    'return : 20001201
        'End Function

        '-------------------------------------------------------------------------------
        'Description: Gets DataTable
        'Input      : Command Object, Table Name
        'Output     : Data Table from the Data Set
        'Created on : 1st September 2006
        'Created by :  
        'Modification Details: 
        '-------------------------------------------------------------------------------
        Public Function SrsGetDataSet(ByVal lCmdOleDB As OleDb.OleDbCommand) As DataSet

            'Getting Data thru Stored Procedure
            '----------------------------
            Dim lConnOleDB As New OleDb.OleDbConnection
            Dim lAdapOleDB As New OleDb.OleDbDataAdapter
            Dim ldsSrsDataSet As New DataSet

            'Step1 : Setting up ODBC data base Connection
            lConnOleDB.ConnectionString = sconnstrings

            'Step2: Setting up ODBC Command
            lCmdOleDB.Connection = lConnOleDB

            'Step3 : Setting up ODBC Data Adapter
            lAdapOleDB.SelectCommand = lCmdOleDB

            'Step4 : Set up Dataset values
            Try
                lConnOleDB.Open()
                lAdapOleDB.Fill(ldsSrsDataSet)
                Return ldsSrsDataSet
                fstrDBResult = "Success"
            Catch e As Exception
                fstrDBResult = "Failed"
                Call SrsErrorHandler(e, lCmdOleDB)
            Finally
                'Step5 : Close the Connection
                lConnOleDB.Close()
            End Try

        End Function
        Public Function SrsSingleTrans(ByVal lCmdOleDB As OleDb.OleDbCommand) As Boolean
            Dim lConnOleDB As New OleDb.OleDbConnection

            Dim lintUpdatedRecords As Integer
            'Step1 : Setting up OLEDB Connection string
            lConnOleDB.ConnectionString = sconnstrings

            Try
                lConnOleDB.Open()
                lCmdOleDB.Connection = lConnOleDB
                lintUpdatedRecords = lCmdOleDB.ExecuteNonQuery()
                fstrDBResult = "Success"
                Return True
            Catch e As Exception
                Call SrsErrorHandler(e, lCmdOleDB)
                fstrDBResult = "Failed"
                Return False
            Finally
                lConnOleDB.Close()
            End Try

        End Function

        Public Function InputParaVarChar(ByVal lstrParamNM As String, ByVal lintLength As Integer, ByVal lstrParamVal As String) As OleDb.OleDbParameter
            Try
                Dim lParamOleDB As New OleDb.OleDbParameter(lstrParamNM, OleDb.OleDbType.VarChar, lintLength)
                lParamOleDB.Value = lstrParamVal
                lParamOleDB.Direction = ParameterDirection.Input
                Return lParamOleDB
            Catch ex As Exception
                fstrDBErrorMsg = ex.Message
            End Try

        End Function
        Public Function InputParaInteger(ByVal lstrParamNM As String, ByVal lstrParamVal As String) As OleDb.OleDbParameter
            Try
                Dim lParamOleDB As New OleDb.OleDbParameter(lstrParamNM, OleDb.OleDbType.Integer)
                lParamOleDB.Value = lstrParamVal
                lParamOleDB.Direction = ParameterDirection.Input
                Return lParamOleDB
            Catch ex As Exception
                fstrDBErrorMsg = ex.Message
            End Try
        End Function
        Public Function InputParaDouble(ByVal lstrParamNM As String, ByVal lstrParamVal As String) As OleDb.OleDbParameter
            Try
                Dim lParamOleDB As New OleDb.OleDbParameter(lstrParamNM, OleDb.OleDbType.Double)
                lParamOleDB.Value = lstrParamVal
                lParamOleDB.Direction = ParameterDirection.Input
                Return lParamOleDB
            Catch ex As Exception
                fstrDBErrorMsg = ex.Message
            End Try
        End Function
        Public Function OutPutParaInteger(ByVal lstrparamNm As String, ByVal lstrparamval As String) As OleDb.OleDbParameter
            Try
                Dim lParamOleDB As New OleDb.OleDbParameter(lstrparamNm, OleDb.OleDbType.Integer)
                lParamOleDB.Value = lstrparamval
                lParamOleDB.Direction = ParameterDirection.Output
                Return lParamOleDB
            Catch ex As Exception
                fstrDBErrorMsg = ex.Message
            End Try
        End Function
        Public Function InputParaBoolean(ByVal lstrParamNM As String, ByVal lstrParamVal As String) As OleDb.OleDbParameter
            Try
                Dim lParamOleDB As New OleDb.OleDbParameter(lstrParamNM, OleDb.OleDbType.Boolean)
                lParamOleDB.Value = lstrParamVal
                lParamOleDB.Direction = ParameterDirection.Input
                Return lParamOleDB
            Catch ex As Exception
                fstrDBErrorMsg = ex.Message
            End Try
        End Function
        Public Function InputParaByte(ByVal lstrParamNM As String, ByVal lstrParamVal As String) As OleDb.OleDbParameter
            Try
                Dim lParamOleDB As New OleDb.OleDbParameter(lstrParamNM, OleDb.OleDbType.Binary)
                lParamOleDB.Value = lstrParamVal
                lParamOleDB.Direction = ParameterDirection.Input
                Return lParamOleDB
            Catch ex As Exception
                fstrDBErrorMsg = ex.Message
            End Try
        End Function
        Public Function InputParaDateTime(ByVal lstrParamNM As String, ByVal lstrParamVal As Date) As OleDb.OleDbParameter
            Try
                Dim lParamOleDB As New OleDb.OleDbParameter(lstrParamNM, OleDb.OleDbType.Date)
                lParamOleDB.Value = lstrParamVal
                lParamOleDB.Direction = ParameterDirection.Input
                Return lParamOleDB
            Catch ex As Exception
                fstrDBErrorMsg = ex.Message
            End Try

        End Function

        Public Function Getname(ByVal strSql As String) As System.Data.DataSet
            Dim lConnOleDB As New OleDb.OleDbConnection
            Dim lAdbOleDB As OleDb.OleDbDataAdapter
            Dim lds As New Data.DataSet
            Try
                lConnOleDB.ConnectionString = sconnstrings
                lConnOleDB.Open()
                lAdbOleDB = New OleDb.OleDbDataAdapter(strSql, lConnOleDB)
                lAdbOleDB.Fill(lds, "Table")
                Return lds
            Catch ex As Exception
                fstrDBResult = "Failed"
                fstrDBErrorMsg = ex.ToString()
            Finally
                lConnOleDB.Close()
            End Try
        End Function

        Public Function SrsGetDataTable(ByVal lCmdOleDB As OleDb.OleDbCommand, ByVal lstrTableNM As String) As DataTable

            'Getting Data thru Stored Procedure
            '----------------------------
            Dim lConnOleDB As New OleDb.OleDbConnection
            Dim lAdapOleDB As New OleDb.OleDbDataAdapter
            Dim ldsSrsDataSet As New DataSet

            'Step1 : Setting up ODBC data base Connection
            lConnOleDB.ConnectionString = sconnstrings

            'Step2: Setting up ODBC Command
            lCmdOleDB.Connection = lConnOleDB

            'Step3 : Setting up ODBC Data Adapter
            lAdapOleDB.Dispose()
            lAdapOleDB.SelectCommand = lCmdOleDB

            'Step4 : Set up Dataset values
            Try
                lConnOleDB.Open()
                lAdapOleDB.Fill(ldsSrsDataSet, lstrTableNM)
                Return ldsSrsDataSet.Tables(lstrTableNM)
                fstrDBResult = "Success"
            Catch e As Exception
                fstrDBResult = "Failed"
                Call SrsErrorHandler(e, lCmdOleDB)
            Finally
                'Step5 : Close the Connection
                lConnOleDB.Close()
            End Try

        End Function
        Private Sub SrsErrorHandler(ByVal e As Exception, ByVal lCmdOleDB As OleDb.OleDbCommand)
            Dim lstrMessage As String = "Error at " & lCmdOleDB.CommandText & " - " & e.Message
            'Send this error to desired email to check unknown errors
            fstrDBErrorMsg = lstrMessage
            Exit Sub
        End Sub
        'Public Function GetLogonInfo() As TableLogOnInfo
        '    Dim LogonInfo As New TableLogOnInfo
        '    LogonInfo.ConnectionInfo.ServerName = "192.168.0.241"
        '    LogonInfo.ConnectionInfo.UserID = "sa"
        '    LogonInfo.ConnectionInfo.Password = ""
        '    LogonInfo.ConnectionInfo.DatabaseName = "mmCRM"
        '    Return LogonInfo
        'End Function

        Public Shared Function Open_NormalUser1(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM NormalUser1 " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            ds = New DataSet
            da.Fill(ds, "NormalUser1")
            Return ds
        End Function
        Public Sub msg(ByVal message As String)
            RegisterClientScriptBlock(Guid.NewGuid().ToString(), "<script language=""JavaScript"">" & getalertscript(message) & "</script>")
        End Sub
        Public Function getalertscript(ByVal message As String) As String
            Return "alert(' " & message.Replace("'", "\'") & "');"
        End Function

        Public ReadOnly Property SrsDBResult() As String
            Get
                Return fstrDBResult
            End Get
        End Property
        Public ReadOnly Property SrsDBErrorMessage() As String
            Get
                Return fstrDBErrorMsg
            End Get
        End Property
        Public Function Update_EMPmaster_status(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM cussamplereturn " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            DS = New DataSet
            da1.Fill(DS, "update_empmaster_status")
            Return DS
        End Function
        ''------------ -----------------




        '' mould maintenance
        Public Sub dbM_close()
            dbConnWeb.Close()
        End Sub
        Public Sub dbM_open()
            dbConnWeb = New SqlConnection(sConnStringM)
            daConnWeb = New SqlDataAdapter
        End Sub
        Public Sub dbSpM_open(ByVal sp As String)
            dbConnWeb = New SqlConnection(sConnStringM)
            dbConnWeb.Open()
            command = New SqlCommand(sp, dbConnWeb)
            command.CommandType = CommandType.StoredProcedure
            adapter = New SqlDataAdapter(command)
        End Sub





        Public Function Update_MMSmaster_status(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM cussamplereturn " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "update_mmsmaster_status")
            Return ds1
        End Function

        Public Function Update_MouldRequest_status(ByVal cnn As SqlConnection, ByVal da1 As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da1.SelectCommand = New SqlCommand("SELECT * FROM cussamplereturn " & strSelection, cnn)
                Case 2
                    da1.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb1 = New SqlCommandBuilder(da1)
            ds1 = New DataSet
            da1.Fill(ds1, "update_MouldRequest_status")
            Return ds1
        End Function


    End Class
End Namespace

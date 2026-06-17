'''''''#author: ravi''
' Dt: Dec28' 05 ' ''''''''''
Imports System.Data
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class CRMlognetglobal
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
    Public Shared sConnString, sConnStringSMS, sConnString1, sConnString2, sConnString3, sConnStringHR, Admin_cnn, SConnStrPur As String
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
    Public Shared sConnString4 As String


    Public Shared MelHrmis As String
    Public Shared MliHrmis As String
    Public Shared OutHrmis As String

    ' Create Connection Statement
    Public Function db_cn()
        tmpserver_name = "CRM"
        tmpDatabase_name = "mmCRM"
        'sConnString = "Data Source=mmsbsql2;Initial Catalog=mmCRM;uid=sa;pwd=S3T64v+"
        'sConnString2 = "Data Source=mmsbsql2;Initial Catalog=HRMIS;uid=sa;pwd=S3T64v+"
        'sConnString = "Data Source=CRM;Initial Catalog=mmCRM;uid=sa;pwd=ASV"
        'sConnString2 = "Data Source=CRM;Initial Catalog=HRMIS;uid=sa;pwd=ASV"
        sConnString = "Data Source=192.168.0.241;Initial Catalog=mmCRM;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        sConnStringSMS = "Data Source=192.168.0.241;Initial Catalog=SMS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        sConnString2 = "Data Source=192.168.0.241;Initial Catalog=HRMIS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        sConnString3 = "Data Source=192.168.0.241;Initial Catalog=Purchasing;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        sConnString4 = "Data Source=192.168.0.241;Initial Catalog=LogisticBills;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        'sConnString = "Data Source=CRM;Initial Catalog=mmCRM;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        'sConnString2 = "Data Source=192.168.0.241;Initial Catalog=HRMIS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        'SconnStrPur = "Data Source=192.168.0.241;Initial Catalog=purchasing;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        'sConnString = "Data Source=MEIPL;Initial Catalog=meipl_survey;uid=sa;pwd=MEIPL4rM;Max Pool Size=100;connection lifetime=30"
        'sConnString2 = "Data Source=MEIPL;Initial Catalog=HRMIS;uid=sa;pwd=MEIPL4rM;Max Pool Size=100;connection lifetime=30"
        MelHrmis = "Data Source=192.168.0.252;Initial Catalog=MelHRMIS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        MliHrmis = "Data Source=192.168.0.241;Initial Catalog=MliHRMIS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"
        OutHrmis = "Data Source=192.168.0.241;Initial Catalog=OutHRMIS;uid=sa;pwd=;Max Pool Size=100;connection lifetime=30"

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

    Public Sub dbCRM_open()
        dbConnWebSMS = New SqlConnection(sConnString)
        daConnWebSMS = New SqlDataAdapter
    End Sub

    Public Sub db_open11()
        dbConnWeb = New SqlConnection(sConnString4)
        daConnWeb = New SqlDataAdapter
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
    Public Shared Function Roundto1(ByVal d As Decimal, ByVal decimals As Integer) As Decimal
        Return System.Math.Round(d, 1)
    End Function

    Public Function ChkLastLogin(ByVal ses As String)
        db_cn()
        db_open()
        Dim uidHere = ses 'Session("userID")
        ds = Open_Users(dbConnWeb, daConnWeb, 2, "select noflogins,Date_time from users WHERE userID = '" & uidHere & "' ")
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
            dr("Date_time") = Now  ' CDate(Format(Now, "dd/MM/yyyy hh:mm"))
            dHere = dr("Date_Time")
            ds = Open_Users(dbConnWeb, daConnWeb, 2, "UPDATE users SET noflogins ='" & iHere & "', Date_Time ='" & dHere & "' WHERE userID = '" & uidHere & "' ")
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
        da = New SqlDataAdapter()

        cnn = New SqlConnection(sConnString)
        cnn.Open()
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
    'Created by : Shiva
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
        Dim MyGlobal As New emanagement.globalinfo
        Dim str As String = MyGlobal.ConCRMStr

        Dim lConnOleDB As New SqlConnection
        Dim lAdbOleDB As New SqlDataAdapter
        Dim lds As New Data.DataSet
        Try
            lConnOleDB = New SqlConnection(str)
            lConnOleDB.Open()
            lAdbOleDB = New SqlDataAdapter(strSql, lConnOleDB)
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
    Public Function GetLogonInfo() As TableLogOnInfo
        Dim LogonInfo As New TableLogOnInfo
        LogonInfo.ConnectionInfo.ServerName = "192.168.0.241"
        LogonInfo.ConnectionInfo.UserID = "sa"
        LogonInfo.ConnectionInfo.Password = ""
        LogonInfo.ConnectionInfo.DatabaseName = "mmCRM"
        Return LogonInfo
    End Function

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
    ''------------Shiva-----------------

	'' logistics ''
	   Public Shared Function CustomReportFun(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Dt1 As Date, ByVal Dt2 As Date) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select B.Department, A.InvNo, '-' as Qty, B.DDate, B.CustomFormNo,B.HsCode , Sum(C.ProdQty) AS ProdQty, sum(C.LocalAmount) as ProdAmt,C.Remarks  From InvMaster A, Log_CustomerBillUploading B, InvDetail C Where A.InvNo=B.InvNo and C.InvNo=A.InvNo and DDate Between '" & Dt1.ToString("MM/dd/yyyy") & "' and '" & Dt2.ToString("MM/dd/yyyy") & "' Group By B.Department, A.InvNo, B.DDate, B.CustomFormNo,B.HsCode, C.Remarks", cnn)



        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function


    Public Shared Function BillsofLadingFun(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Str1 As String) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select * From Log_CustomerBillUploading Where InVNo='" & Str1 & "'", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    'Public Shared Function QuotationStatus(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Str1 As String) As DataSet
    '    'On Error Resume Next
    '    da.SelectCommand = New SqlCommand("Select * From Log_CustomerBillUploading Where InVNo='" & Str1 & "'", cnn)
    '    cb = New SqlCommandBuilder(da)
    '    ds = New DataSet
    '    da.Fill(ds, "NormalUser1")
    '    Return ds
    'End Function

    Public Shared Function QuotationStatus(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select Distinct(ApprovedStatus) From Log_VehicleQuotation Order By ApprovedStatus", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function QuotationBasedonStatus(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Stat As String) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select * From Log_VehicleQuotation Where ApprovedStatus='" & Stat & "'  Order By ApprovedStatus", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function QuotationArrival(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select Distinct(ArrivalPlace) From Log_VehicleQuotation Order By ArrivalPlace", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function QuotationBasedonArrival(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Stat As String) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select * From Log_VehicleQuotation Where ArrivalPlace='" & Stat & "'  Order By ArrivalPlace", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function ForwarderType(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select Distinct(F_Type) From Log_ForwardersMaster Order By F_Type", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function ForwarderDetailsBasedOnType(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Stat As String) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select * From Log_ForwardersMaster Where F_Type='" & Stat & "'  Order By F_Type", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function VehicleInfo(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Opt As Integer) As DataSet
        'On Error Resume Next
        If Opt = 1 Then
            da.SelectCommand = New SqlCommand("Select Distinct(VehicleType) From Log_VehicleRegistration Order By VehicleType", cnn)
            cb = New SqlCommandBuilder(da)

        ElseIf Opt = 2 Then
            da.SelectCommand = New SqlCommand("Select Distinct(TransportName) From Log_VehicleRegistration Order By TransportName", cnn)
            cb = New SqlCommandBuilder(da)

        ElseIf Opt = 3 Then
            da.SelectCommand = New SqlCommand("Select Distinct(ArrivalPlace) From Log_VehicleRegistration Order By ArrivalPlace", cnn)
            cb = New SqlCommandBuilder(da)

        End If

        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function VehicleInfoByVehicleType(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Stat As String, ByVal Opt As Integer) As DataSet
        'On Error Resume Next
        If Opt = 1 Then
            da.SelectCommand = New SqlCommand("Select * From Log_VehicleRegistration Where VehicleType='" & Stat & "' Order By VehicleType", cnn)
            cb = New SqlCommandBuilder(da)

        ElseIf Opt = 2 Then
            da.SelectCommand = New SqlCommand("Select * From Log_VehicleRegistration Where  TransportName='" & Stat & "' Order By TransportName", cnn)
            cb = New SqlCommandBuilder(da)

        ElseIf Opt = 3 Then
            da.SelectCommand = New SqlCommand("Select * From Log_VehicleRegistration Where ArrivalPlace='" & Stat & "' Order By ArrivalPlace", cnn)
            cb = New SqlCommandBuilder(da)

        End If

        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds

    End Function

    Public Shared Function DeptFromWeightReg(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select Distinct(Department) From Log_WtM3Registration Order By  Department", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function WeightInfoBasedDept(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Str As String) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select * From Log_WtM3Registration Where Department='" & Str & "'  Order By  Department", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function
    ''121212

    Public Shared Function ReportLogisticExpense(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Dt1 As Date, ByVal Dt2 As Date, ByVal Dept As String) As DataSet
        'On Error Resume Next

        da.SelectCommand = New SqlCommand("Select * From Log_ForwarderInvoiceDetails Where DepartmentName='" & Dept & "' and  CreatedOn Between '" & Dt1.ToString("MM/dd/yyyy") & "' and '" & Dt2.ToString("MM/dd/yyyy") & "' Order By  DepartmentName, InvoiceNo", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function ReportLogisticExpenseByDept(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal Dept As String) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select * From Log_ForwarderInvoiceDetails Where DepartmentName='" & Dept & "'  Order By  DepartmentName, InvoiceNo", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function


    Public Shared Function UniqueDepartment(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter) As DataSet
        'On Error Resume Next
        da.SelectCommand = New SqlCommand("Select Distinct DepartmentName From Log_ForwarderInvoiceDetails Order By DepartmentName", cnn)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function


    ''' 21012013 '' safety functions ''''
    Public Shared Function InsertTblDailyBallMillCheckStreet(ByVal ConStr As String, _
   ByVal CrDate As DateTime, _
   ByVal AStatus As String, _
   ByVal SBSL1 As String, _
   ByVal SBSL2 As String, _
   ByVal SBSL3 As String, _
   ByVal SBSL4 As String, _
   ByVal SBSL5 As String, _
   ByVal SBSL6 As String, _
   ByVal SBSL7 As String, _
   ByVal SBSL8 As String, _
   ByVal SBSL9 As String, _
   ByVal SBSL10 As String, _
   ByVal SBSL11 As String, _
   ByVal SBSL12 As String, _
   ByVal SBSL13 As String, _
   ByVal SBSL14 As String, _
   ByVal SBSL15 As String, _
   ByVal SBSL16 As String, _
   ByVal SBSL17 As String, _
   ByVal SBSL18 As String, _
   ByVal SBSL19 As String, _
   ByVal SBSL20 As String, _
   ByVal SBSL21 As String, _
   ByVal SBIW1 As Double, _
   ByVal SBIW2 As Double, _
   ByVal SBIW3 As Double, _
   ByVal SBIW4 As Double, _
   ByVal SBIW5 As Double, _
   ByVal SBIW6 As Double, _
   ByVal SBIW7 As Double, _
   ByVal SBIW8 As Double, _
   ByVal SBIW9 As Double, _
   ByVal SBIW10 As Double, _
   ByVal SBIW11 As Double, _
   ByVal SBIW12 As Double, _
   ByVal SBIW13 As Double, _
   ByVal SBIW14 As Double, _
   ByVal SBIW15 As Double, _
   ByVal SBIW16 As Double, _
   ByVal SBIW17 As Double, _
   ByVal SBIW18 As Double, _
   ByVal SBIW19 As Double, _
   ByVal SBIW20 As Double, _
   ByVal SBIW21 As Double, _
   ByVal SBOW1 As Double, _
   ByVal SBOW2 As Double, _
   ByVal SBOW3 As Double, _
   ByVal SBOW4 As Double, _
   ByVal SBOW5 As Double, _
   ByVal SBOW6 As Double, _
   ByVal SBOW7 As Double, _
   ByVal SBOW8 As Double, _
   ByVal SBOW9 As Double, _
   ByVal SBOW10 As Double, _
   ByVal SBOW11 As Double, _
   ByVal SBOW12 As Double, _
   ByVal SBOW13 As Double, _
   ByVal SBOW14 As Double, _
   ByVal SBOW15 As Double, _
   ByVal SBOW16 As Double, _
   ByVal SBOW17 As Double, _
   ByVal SBOW18 As Double, _
   ByVal SBOW19 As Double, _
   ByVal SBOW20 As Double, _
   ByVal SBOW21 As Double, _
   ByVal SBCL1 As String, _
   ByVal SBCL2 As String, _
   ByVal SBCL3 As String, _
   ByVal SBCL4 As String, _
   ByVal SBCL5 As String, _
   ByVal SBCL6 As String, _
   ByVal SBCL7 As String, _
   ByVal SBCL8 As String, _
   ByVal SBCL9 As String, _
   ByVal SBCL10 As String, _
   ByVal SBCL11 As String, _
   ByVal SBCL12 As String, _
   ByVal SBCL13 As String, _
   ByVal SBCL14 As String, _
   ByVal SBCL15 As String, _
   ByVal SBCL16 As String, _
   ByVal SBCL17 As String, _
   ByVal SBCL18 As String, _
   ByVal SBCL19 As String, _
   ByVal SBCL20 As String, _
   ByVal SBCL21 As String, _
   ByVal SBCN1 As String, _
   ByVal SBCN2 As String, _
   ByVal SBCN3 As String, _
   ByVal SBCN4 As String, _
   ByVal SBCN5 As String, _
   ByVal SBCN6 As String, _
   ByVal SBCN7 As String, _
   ByVal SBCN8 As String, _
   ByVal SBCN9 As String, _
   ByVal SBCN10 As String, _
   ByVal SBCN11 As String, _
   ByVal SBCN12 As String, _
   ByVal SBCN13 As String, _
   ByVal SBCN14 As String, _
   ByVal SBCN15 As String, _
   ByVal SBCN16 As String, _
   ByVal SBCN17 As String, _
   ByVal SBCN18 As String, _
   ByVal SBCN19 As String, _
   ByVal SBCN20 As String, _
   ByVal SBCN21 As String, _
   ByVal SBSND1 As String, _
   ByVal SBSND2 As String, _
   ByVal SBSND3 As String, _
   ByVal SBSND4 As String, _
   ByVal SBSND5 As String, _
   ByVal SBSND6 As String, _
   ByVal SBSND7 As String, _
   ByVal SBSND8 As String, _
   ByVal SBSND9 As String, _
   ByVal SBSND10 As String, _
   ByVal SBSND11 As String, _
   ByVal SBSND12 As String, _
   ByVal SBSND13 As String, _
   ByVal SBSND14 As String, _
   ByVal SBSND15 As String, _
   ByVal SBSND16 As String, _
   ByVal SBSND17 As String, _
   ByVal SBSND18 As String, _
   ByVal SBSND19 As String, _
   ByVal SBSND20 As String, _
   ByVal SBSND21 As String, _
   ByVal SBVBN1 As String, _
   ByVal SBVBN2 As String, _
   ByVal SBVBN3 As String, _
   ByVal SBVBN4 As String, _
   ByVal SBVBN5 As String, _
   ByVal SBVBN6 As String, _
   ByVal SBVBN7 As String, _
   ByVal SBVBN8 As String, _
   ByVal SBVBN9 As String, _
   ByVal SBVBN10 As String, _
   ByVal SBVBN11 As String, _
   ByVal SBVBN12 As String, _
   ByVal SBVBN13 As String, _
   ByVal SBVBN14 As String, _
   ByVal SBVBN15 As String, _
   ByVal SBVBN16 As String, _
   ByVal SBVBN17 As String, _
   ByVal SBVBN18 As String, _
   ByVal SBVBN19 As String, _
   ByVal SBVBN20 As String, _
   ByVal SBVBN21 As String, _
   ByVal SBREM1 As String, _
   ByVal SBREM2 As String, _
   ByVal SBREM3 As String, _
   ByVal SBREM4 As String, _
   ByVal SBREM5 As String, _
   ByVal SBREM6 As String, _
   ByVal SBREM7 As String, _
   ByVal SBREM8 As String, _
   ByVal SBREM9 As String, _
   ByVal SBREM10 As String, _
   ByVal SBREM11 As String, _
   ByVal SBREM12 As String, _
   ByVal SBREM13 As String, _
   ByVal SBREM14 As String, _
   ByVal SBREM15 As String, _
   ByVal SBREM16 As String, _
   ByVal SBREM17 As String, _
   ByVal SBREM18 As String, _
   ByVal SBREM19 As String, _
   ByVal SBREM20 As String, _
   ByVal SBREM21 As String, _
   ByVal EPNTCLP1 As String, _
   ByVal EPNTCLP2 As String, _
   ByVal EPNTCLP3 As String, _
   ByVal EPNTCLP4 As String, _
   ByVal EPNTCLP5 As String, _
   ByVal EPNTCLP6 As String, _
   ByVal EPNTCLP7 As String, _
   ByVal EPNTCLP8 As String, _
   ByVal EPNTCLP9 As String, _
   ByVal EPNTCLP10 As String, _
   ByVal EPNTCLP11 As String, _
   ByVal EPNTCLP12 As String, _
   ByVal EPNTCLP13 As String, _
   ByVal EPNTCLP14 As String, _
   ByVal EPNTWRE1 As String, _
   ByVal EPNTWRE2 As String, _
   ByVal EPNTWRE3 As String, _
   ByVal EPNTWRE4 As String, _
   ByVal EPNTWRE5 As String, _
   ByVal EPNTWRE6 As String, _
   ByVal EPNTWRE7 As String, _
   ByVal EPNTWRE8 As String, _
   ByVal EPNTWRE9 As String, _
   ByVal EPNTWRE10 As String, _
   ByVal EPNTWRE11 As String, _
   ByVal EPNTWRE12 As String, _
   ByVal EPNTWRE13 As String, _
   ByVal EPNTWRE14 As String, _
   ByVal EPNTREM1 As String, _
   ByVal EPNTREM2 As String, _
   ByVal EPNTREM3 As String, _
   ByVal EPNTREM4 As String, _
   ByVal EPNTREM5 As String, _
   ByVal EPNTREM6 As String, _
   ByVal EPNTREM7 As String, _
   ByVal EPNTREM8 As String, _
   ByVal EPNTREM9 As String, _
   ByVal EPNTREM10 As String, _
   ByVal EPNTREM11 As String, _
   ByVal EPNTREM12 As String, _
   ByVal EPNTREM13 As String, _
   ByVal EPNTREM14 As String, _
   ByVal NPNTCN1 As String, _
   ByVal NPNTCN2 As String, _
   ByVal NPNTCN3 As String, _
   ByVal NPNTCN4 As String, _
   ByVal NPNTCN5 As String, _
   ByVal NPNTCN6 As String, _
   ByVal NPNTCN7 As String, _
   ByVal NPNTCN8 As String, _
   ByVal NPNTCN9 As String, _
   ByVal NPNTCN10 As String, _
   ByVal NPNTCN11 As String, _
   ByVal NPNTCN12 As String, _
   ByVal NPNTREM1 As String, _
   ByVal NPNTREM2 As String, _
   ByVal NPNTREM3 As String, _
   ByVal NPNTREM4 As String, _
   ByVal NPNTREM5 As String, _
   ByVal NPNTREM6 As String, _
   ByVal NPNTREM7 As String, _
   ByVal NPNTREM8 As String, _
   ByVal NPNTREM9 As String, _
   ByVal NPNTREM10 As String, _
   ByVal NPNTREM11 As String, _
   ByVal NPNTREM12 As String, _
   ByVal XYLNOZZLE As String, _
   ByVal IPANOZZLE As String, _
   ByVal RIPNOZZLE As String, _
   ByVal XYLLEAK As String, _
   ByVal IPALEAK As String, _
   ByVal RIPLEAK As String, _
   ByVal CHREM1 As String, _
   ByVal CHREM2 As String, _
   ByVal CHREM3 As String, _
   ByVal CRNCN1 As String, _
   ByVal CRNCN2 As String, _
   ByVal CRNCN3 As String, _
   ByVal CRNREM1 As String, _
   ByVal CRNREM2 As String, _
   ByVal CRNREM3 As String, _
   ByVal FANCN1 As String, _
   ByVal FANCN2 As String, _
   ByVal FANCN3 As String, _
   ByVal FANCN4 As String, _
   ByVal FANCN5 As String, _
   ByVal FANCN6 As String, _
   ByVal FANCN7 As String, _
   ByVal FANCN8 As String, _
   ByVal FANCN9 As String, _
   ByVal FANCN10 As String, _
   ByVal FANREM1 As String, _
   ByVal FANREM2 As String, _
   ByVal FANREM3 As String, _
   ByVal FANREM4 As String, _
   ByVal FANREM5 As String, _
   ByVal FANREM6 As String, _
   ByVal FANREM7 As String, _
   ByVal FANREM8 As String, _
   ByVal FANREM9 As String, _
   ByVal FANREM10 As String, _
   ByVal CREATEDBY As String, ByVal OverallStatus As String) As Boolean
        Try


            Dim Con As New SqlConnection
            Con = New SqlConnection(ConStr)
            Con.Open()
            Dim Cmd As New SqlCommand
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "SP_INS_TblBallMillCheckSheet"
            Cmd.Connection = Con


            Cmd.Parameters.AddWithValue("@CDate", CrDate.ToString("MM/dd/yyyy"))
            Cmd.Parameters.AddWithValue("@AStatus", AStatus)
            Cmd.Parameters.AddWithValue("@SBSL1", SBSL1)
            Cmd.Parameters.AddWithValue("@SBSL2", SBSL2)
            Cmd.Parameters.AddWithValue("@SBSL3", SBSL3)
            Cmd.Parameters.AddWithValue("@SBSL4", SBSL4)
            Cmd.Parameters.AddWithValue("@SBSL5", SBSL5)
            Cmd.Parameters.AddWithValue("@SBSL6", SBSL6)
            Cmd.Parameters.AddWithValue("@SBSL7", SBSL7)
            Cmd.Parameters.AddWithValue("@SBSL8", SBSL8)
            Cmd.Parameters.AddWithValue("@SBSL9", SBSL9)
            Cmd.Parameters.AddWithValue("@SBSL10", SBSL10)
            Cmd.Parameters.AddWithValue("@SBSL11", SBSL11)
            Cmd.Parameters.AddWithValue("@SBSL12", SBSL12)
            Cmd.Parameters.AddWithValue("@SBSL13", SBSL13)
            Cmd.Parameters.AddWithValue("@SBSL14", SBSL14)
            Cmd.Parameters.AddWithValue("@SBSL15", SBSL15)
            Cmd.Parameters.AddWithValue("@SBSL16", SBSL16)
            Cmd.Parameters.AddWithValue("@SBSL17", SBSL17)
            Cmd.Parameters.AddWithValue("@SBSL18", SBSL18)
            Cmd.Parameters.AddWithValue("@SBSL19", SBSL19)
            Cmd.Parameters.AddWithValue("@SBSL20", SBSL20)
            Cmd.Parameters.AddWithValue("@SBSL21", SBSL21)
            Cmd.Parameters.AddWithValue("@SBIW1", SBIW1)
            Cmd.Parameters.AddWithValue("@SBIW2", SBIW2)
            Cmd.Parameters.AddWithValue("@SBIW3", SBIW3)
            Cmd.Parameters.AddWithValue("@SBIW4", SBIW4)
            Cmd.Parameters.AddWithValue("@SBIW5", SBIW5)
            Cmd.Parameters.AddWithValue("@SBIW6", SBIW6)
            Cmd.Parameters.AddWithValue("@SBIW7", SBIW7)
            Cmd.Parameters.AddWithValue("@SBIW8", SBIW8)
            Cmd.Parameters.AddWithValue("@SBIW9", SBIW9)
            Cmd.Parameters.AddWithValue("@SBIW10", SBIW10)
            Cmd.Parameters.AddWithValue("@SBIW11", SBIW11)
            Cmd.Parameters.AddWithValue("@SBIW12", SBIW12)
            Cmd.Parameters.AddWithValue("@SBIW13", SBIW13)
            Cmd.Parameters.AddWithValue("@SBIW14", SBIW14)
            Cmd.Parameters.AddWithValue("@SBIW15", SBIW15)
            Cmd.Parameters.AddWithValue("@SBIW16", SBIW16)
            Cmd.Parameters.AddWithValue("@SBIW17", SBIW17)
            Cmd.Parameters.AddWithValue("@SBIW18", SBIW18)
            Cmd.Parameters.AddWithValue("@SBIW19", SBIW19)
            Cmd.Parameters.AddWithValue("@SBIW20", SBIW20)
            Cmd.Parameters.AddWithValue("@SBIW21", SBIW21)
            Cmd.Parameters.AddWithValue("@SBOW1", SBOW1)
            Cmd.Parameters.AddWithValue("@SBOW2", SBOW2)
            Cmd.Parameters.AddWithValue("@SBOW3", SBOW3)
            Cmd.Parameters.AddWithValue("@SBOW4", SBOW4)
            Cmd.Parameters.AddWithValue("@SBOW5", SBOW5)
            Cmd.Parameters.AddWithValue("@SBOW6", SBOW6)
            Cmd.Parameters.AddWithValue("@SBOW7", SBOW7)
            Cmd.Parameters.AddWithValue("@SBOW8", SBOW8)
            Cmd.Parameters.AddWithValue("@SBOW9", SBOW9)
            Cmd.Parameters.AddWithValue("@SBOW10", SBOW10)
            Cmd.Parameters.AddWithValue("@SBOW11", SBOW11)
            Cmd.Parameters.AddWithValue("@SBOW12", SBOW12)
            Cmd.Parameters.AddWithValue("@SBOW13", SBOW13)
            Cmd.Parameters.AddWithValue("@SBOW14", SBOW14)
            Cmd.Parameters.AddWithValue("@SBOW15", SBOW15)
            Cmd.Parameters.AddWithValue("@SBOW16", SBOW16)
            Cmd.Parameters.AddWithValue("@SBOW17", SBOW17)
            Cmd.Parameters.AddWithValue("@SBOW18", SBOW18)
            Cmd.Parameters.AddWithValue("@SBOW19", SBOW19)
            Cmd.Parameters.AddWithValue("@SBOW20", SBOW20)
            Cmd.Parameters.AddWithValue("@SBOW21", SBOW21)
            Cmd.Parameters.AddWithValue("@SBCL1", SBCL1)
            Cmd.Parameters.AddWithValue("@SBCL2", SBCL2)
            Cmd.Parameters.AddWithValue("@SBCL3", SBCL3)
            Cmd.Parameters.AddWithValue("@SBCL4", SBCL4)
            Cmd.Parameters.AddWithValue("@SBCL5", SBCL5)
            Cmd.Parameters.AddWithValue("@SBCL6", SBCL6)
            Cmd.Parameters.AddWithValue("@SBCL7", SBCL7)
            Cmd.Parameters.AddWithValue("@SBCL8", SBCL8)
            Cmd.Parameters.AddWithValue("@SBCL9", SBCL9)
            Cmd.Parameters.AddWithValue("@SBCL10", SBCL10)
            Cmd.Parameters.AddWithValue("@SBCL11", SBCL11)
            Cmd.Parameters.AddWithValue("@SBCL12", SBCL12)
            Cmd.Parameters.AddWithValue("@SBCL13", SBCL13)
            Cmd.Parameters.AddWithValue("@SBCL14", SBCL14)
            Cmd.Parameters.AddWithValue("@SBCL15", SBCL15)
            Cmd.Parameters.AddWithValue("@SBCL16", SBCL16)
            Cmd.Parameters.AddWithValue("@SBCL17", SBCL17)
            Cmd.Parameters.AddWithValue("@SBCL18", SBCL18)
            Cmd.Parameters.AddWithValue("@SBCL19", SBCL19)
            Cmd.Parameters.AddWithValue("@SBCL20", SBCL20)
            Cmd.Parameters.AddWithValue("@SBCL21", SBCL21)
            Cmd.Parameters.AddWithValue("@SBCN1", SBCN1)
            Cmd.Parameters.AddWithValue("@SBCN2", SBCN2)
            Cmd.Parameters.AddWithValue("@SBCN3", SBCN3)
            Cmd.Parameters.AddWithValue("@SBCN4", SBCN4)
            Cmd.Parameters.AddWithValue("@SBCN5", SBCN5)
            Cmd.Parameters.AddWithValue("@SBCN6", SBCN6)
            Cmd.Parameters.AddWithValue("@SBCN7", SBCN7)
            Cmd.Parameters.AddWithValue("@SBCN8", SBCN8)
            Cmd.Parameters.AddWithValue("@SBCN9", SBCN9)
            Cmd.Parameters.AddWithValue("@SBCN10", SBCN10)
            Cmd.Parameters.AddWithValue("@SBCN11", SBCN11)
            Cmd.Parameters.AddWithValue("@SBCN12", SBCN12)
            Cmd.Parameters.AddWithValue("@SBCN13", SBCN13)
            Cmd.Parameters.AddWithValue("@SBCN14", SBCN14)
            Cmd.Parameters.AddWithValue("@SBCN15", SBCN15)
            Cmd.Parameters.AddWithValue("@SBCN16", SBCN16)
            Cmd.Parameters.AddWithValue("@SBCN17", SBCN17)
            Cmd.Parameters.AddWithValue("@SBCN18", SBCN18)
            Cmd.Parameters.AddWithValue("@SBCN19", SBCN19)
            Cmd.Parameters.AddWithValue("@SBCN20", SBCN20)
            Cmd.Parameters.AddWithValue("@SBCN21", SBCN21)
            Cmd.Parameters.AddWithValue("@SBSND1", SBSND1)
            Cmd.Parameters.AddWithValue("@SBSND2", SBSND2)
            Cmd.Parameters.AddWithValue("@SBSND3", SBSND3)
            Cmd.Parameters.AddWithValue("@SBSND4", SBSND4)
            Cmd.Parameters.AddWithValue("@SBSND5", SBSND5)
            Cmd.Parameters.AddWithValue("@SBSND6", SBSND6)
            Cmd.Parameters.AddWithValue("@SBSND7", SBSND7)
            Cmd.Parameters.AddWithValue("@SBSND8", SBSND8)
            Cmd.Parameters.AddWithValue("@SBSND9", SBSND9)
            Cmd.Parameters.AddWithValue("@SBSND10", SBSND10)
            Cmd.Parameters.AddWithValue("@SBSND11", SBSND11)
            Cmd.Parameters.AddWithValue("@SBSND12", SBSND12)
            Cmd.Parameters.AddWithValue("@SBSND13", SBSND13)
            Cmd.Parameters.AddWithValue("@SBSND14", SBSND14)
            Cmd.Parameters.AddWithValue("@SBSND15", SBSND15)
            Cmd.Parameters.AddWithValue("@SBSND16", SBSND16)
            Cmd.Parameters.AddWithValue("@SBSND17", SBSND17)
            Cmd.Parameters.AddWithValue("@SBSND18", SBSND18)
            Cmd.Parameters.AddWithValue("@SBSND19", SBSND19)
            Cmd.Parameters.AddWithValue("@SBSND20", SBSND20)
            Cmd.Parameters.AddWithValue("@SBSND21", SBSND21)
            Cmd.Parameters.AddWithValue("@SBVBN1", SBVBN1)
            Cmd.Parameters.AddWithValue("@SBVBN2", SBVBN2)
            Cmd.Parameters.AddWithValue("@SBVBN3", SBVBN3)
            Cmd.Parameters.AddWithValue("@SBVBN4", SBVBN4)
            Cmd.Parameters.AddWithValue("@SBVBN5", SBVBN5)
            Cmd.Parameters.AddWithValue("@SBVBN6", SBVBN6)
            Cmd.Parameters.AddWithValue("@SBVBN7", SBVBN7)
            Cmd.Parameters.AddWithValue("@SBVBN8", SBVBN8)
            Cmd.Parameters.AddWithValue("@SBVBN9", SBVBN9)
            Cmd.Parameters.AddWithValue("@SBVBN10", SBVBN10)
            Cmd.Parameters.AddWithValue("@SBVBN11", SBVBN11)
            Cmd.Parameters.AddWithValue("@SBVBN12", SBVBN12)
            Cmd.Parameters.AddWithValue("@SBVBN13", SBVBN13)
            Cmd.Parameters.AddWithValue("@SBVBN14", SBVBN14)
            Cmd.Parameters.AddWithValue("@SBVBN15", SBVBN15)
            Cmd.Parameters.AddWithValue("@SBVBN16", SBVBN16)
            Cmd.Parameters.AddWithValue("@SBVBN17", SBVBN17)
            Cmd.Parameters.AddWithValue("@SBVBN18", SBVBN18)
            Cmd.Parameters.AddWithValue("@SBVBN19", SBVBN19)
            Cmd.Parameters.AddWithValue("@SBVBN20", SBVBN20)
            Cmd.Parameters.AddWithValue("@SBVBN21", SBVBN21)


            Cmd.Parameters.AddWithValue("@SBREM1", SBREM1)
            Cmd.Parameters.AddWithValue("@SBREM2", SBREM2)
            Cmd.Parameters.AddWithValue("@SBREM3", SBREM3)
            Cmd.Parameters.AddWithValue("@SBREM4", SBREM4)
            Cmd.Parameters.AddWithValue("@SBREM5", SBREM5)
            Cmd.Parameters.AddWithValue("@SBREM6", SBREM6)
            Cmd.Parameters.AddWithValue("@SBREM7", SBREM7)
            Cmd.Parameters.AddWithValue("@SBREM8", SBREM8)
            Cmd.Parameters.AddWithValue("@SBREM9", SBREM9)
            Cmd.Parameters.AddWithValue("@SBREM10", SBREM10)
            Cmd.Parameters.AddWithValue("@SBREM11", SBREM11)
            Cmd.Parameters.AddWithValue("@SBREM12", SBREM12)
            Cmd.Parameters.AddWithValue("@SBREM13", SBREM13)
            Cmd.Parameters.AddWithValue("@SBREM14", SBREM14)
            Cmd.Parameters.AddWithValue("@SBREM15", SBREM15)
            Cmd.Parameters.AddWithValue("@SBREM16", SBREM16)
            Cmd.Parameters.AddWithValue("@SBREM17", SBREM17)
            Cmd.Parameters.AddWithValue("@SBREM18", SBREM18)
            Cmd.Parameters.AddWithValue("@SBREM19", SBREM19)
            Cmd.Parameters.AddWithValue("@SBREM20", SBREM20)
            Cmd.Parameters.AddWithValue("@SBREM21", SBREM21)
            Cmd.Parameters.AddWithValue("@EPNTCLP1", EPNTCLP1)
            Cmd.Parameters.AddWithValue("@EPNTCLP2", EPNTCLP2)
            Cmd.Parameters.AddWithValue("@EPNTCLP3", EPNTCLP3)
            Cmd.Parameters.AddWithValue("@EPNTCLP4", EPNTCLP4)
            Cmd.Parameters.AddWithValue("@EPNTCLP5", EPNTCLP5)
            Cmd.Parameters.AddWithValue("@EPNTCLP6", EPNTCLP6)
            Cmd.Parameters.AddWithValue("@EPNTCLP7", EPNTCLP7)
            Cmd.Parameters.AddWithValue("@EPNTCLP8", EPNTCLP8)
            Cmd.Parameters.AddWithValue("@EPNTCLP9", EPNTCLP9)
            Cmd.Parameters.AddWithValue("@EPNTCLP10", EPNTCLP10)
            Cmd.Parameters.AddWithValue("@EPNTCLP11", EPNTCLP11)
            Cmd.Parameters.AddWithValue("@EPNTCLP12", EPNTCLP12)
            Cmd.Parameters.AddWithValue("@EPNTCLP13", EPNTCLP13)
            Cmd.Parameters.AddWithValue("@EPNTCLP14", EPNTCLP14)
            Cmd.Parameters.AddWithValue("@EPNTWRE1", EPNTWRE1)
            Cmd.Parameters.AddWithValue("@EPNTWRE2", EPNTWRE2)
            Cmd.Parameters.AddWithValue("@EPNTWRE3", EPNTWRE3)
            Cmd.Parameters.AddWithValue("@EPNTWRE4", EPNTWRE4)
            Cmd.Parameters.AddWithValue("@EPNTWRE5", EPNTWRE5)
            Cmd.Parameters.AddWithValue("@EPNTWRE6", EPNTWRE6)
            Cmd.Parameters.AddWithValue("@EPNTWRE7", EPNTWRE7)
            Cmd.Parameters.AddWithValue("@EPNTWRE8", EPNTWRE8)
            Cmd.Parameters.AddWithValue("@EPNTWRE9", EPNTWRE9)
            Cmd.Parameters.AddWithValue("@EPNTWRE10", EPNTWRE10)
            Cmd.Parameters.AddWithValue("@EPNTWRE11", EPNTWRE11)
            Cmd.Parameters.AddWithValue("@EPNTWRE12", EPNTWRE12)
            Cmd.Parameters.AddWithValue("@EPNTWRE13", EPNTWRE13)
            Cmd.Parameters.AddWithValue("@EPNTWRE14", EPNTWRE14)
            Cmd.Parameters.AddWithValue("@EPNTREM1", EPNTREM1)
            Cmd.Parameters.AddWithValue("@EPNTREM2", EPNTREM2)
            Cmd.Parameters.AddWithValue("@EPNTREM3", EPNTREM3)
            Cmd.Parameters.AddWithValue("@EPNTREM4", EPNTREM4)
            Cmd.Parameters.AddWithValue("@EPNTREM5", EPNTREM5)
            Cmd.Parameters.AddWithValue("@EPNTREM6", EPNTREM6)
            Cmd.Parameters.AddWithValue("@EPNTREM7", EPNTREM7)
            Cmd.Parameters.AddWithValue("@EPNTREM8", EPNTREM8)
            Cmd.Parameters.AddWithValue("@EPNTREM9", EPNTREM9)
            Cmd.Parameters.AddWithValue("@EPNTREM10", EPNTREM10)
            Cmd.Parameters.AddWithValue("@EPNTREM11", EPNTREM11)
            Cmd.Parameters.AddWithValue("@EPNTREM12", EPNTREM12)
            Cmd.Parameters.AddWithValue("@EPNTREM13", EPNTREM13)
            Cmd.Parameters.AddWithValue("@EPNTREM14", EPNTREM14)
            Cmd.Parameters.AddWithValue("@NPNTCN1", NPNTCN1)
            Cmd.Parameters.AddWithValue("@NPNTCN2", NPNTCN2)
            Cmd.Parameters.AddWithValue("@NPNTCN3", NPNTCN3)
            Cmd.Parameters.AddWithValue("@NPNTCN4", NPNTCN4)
            Cmd.Parameters.AddWithValue("@NPNTCN5", NPNTCN5)
            Cmd.Parameters.AddWithValue("@NPNTCN6", NPNTCN6)
            Cmd.Parameters.AddWithValue("@NPNTCN7", NPNTCN7)
            Cmd.Parameters.AddWithValue("@NPNTCN8", NPNTCN8)
            Cmd.Parameters.AddWithValue("@NPNTCN9", NPNTCN9)
            Cmd.Parameters.AddWithValue("@NPNTCN10", NPNTCN10)
            Cmd.Parameters.AddWithValue("@NPNTCN11", NPNTCN11)
            Cmd.Parameters.AddWithValue("@NPNTCN12", NPNTCN12)
            Cmd.Parameters.AddWithValue("@NPNTREM1", NPNTREM1)
            Cmd.Parameters.AddWithValue("@NPNTREM2", NPNTREM2)
            Cmd.Parameters.AddWithValue("@NPNTREM3", NPNTREM3)
            Cmd.Parameters.AddWithValue("@NPNTREM4", NPNTREM4)
            Cmd.Parameters.AddWithValue("@NPNTREM5", NPNTREM5)
            Cmd.Parameters.AddWithValue("@NPNTREM6", NPNTREM6)
            Cmd.Parameters.AddWithValue("@NPNTREM7", NPNTREM7)
            Cmd.Parameters.AddWithValue("@NPNTREM8", NPNTREM8)
            Cmd.Parameters.AddWithValue("@NPNTREM9", NPNTREM9)
            Cmd.Parameters.AddWithValue("@NPNTREM10", NPNTREM10)
            Cmd.Parameters.AddWithValue("@NPNTREM11", NPNTREM11)
            Cmd.Parameters.AddWithValue("@NPNTREM12", NPNTREM12)
            Cmd.Parameters.AddWithValue("@XYLNOZZLE", XYLNOZZLE)
            Cmd.Parameters.AddWithValue("@IPANOZZLE", IPANOZZLE)
            Cmd.Parameters.AddWithValue("@RIPNOZZLE", RIPNOZZLE)
            Cmd.Parameters.AddWithValue("@XYLLEAK", XYLLEAK)
            Cmd.Parameters.AddWithValue("@IPALEAK", IPALEAK)
            Cmd.Parameters.AddWithValue("@RIPLEAK", RIPLEAK)
            Cmd.Parameters.AddWithValue("@CHREM1", CHREM1)
            Cmd.Parameters.AddWithValue("@CHREM2", CHREM2)
            Cmd.Parameters.AddWithValue("@CHREM3", CHREM3)
            Cmd.Parameters.AddWithValue("@CRNCN1", CRNCN1)
            Cmd.Parameters.AddWithValue("@CRNCN2", CRNCN2)
            Cmd.Parameters.AddWithValue("@CRNCN3", CRNCN3)
            Cmd.Parameters.AddWithValue("@CRNREM1", CRNREM1)
            Cmd.Parameters.AddWithValue("@CRNREM2", CRNREM2)
            Cmd.Parameters.AddWithValue("@CRNREM3", CRNREM3)
            Cmd.Parameters.AddWithValue("@FANCN1", FANCN1)
            Cmd.Parameters.AddWithValue("@FANCN2", FANCN2)
            Cmd.Parameters.AddWithValue("@FANCN3", FANCN3)
            Cmd.Parameters.AddWithValue("@FANCN4", FANCN4)
            Cmd.Parameters.AddWithValue("@FANCN5", FANCN5)
            Cmd.Parameters.AddWithValue("@FANCN6", FANCN6)
            Cmd.Parameters.AddWithValue("@FANCN7", FANCN7)
            Cmd.Parameters.AddWithValue("@FANCN8", FANCN8)
            Cmd.Parameters.AddWithValue("@FANCN9", FANCN9)
            Cmd.Parameters.AddWithValue("@FANCN10", FANCN10)
            Cmd.Parameters.AddWithValue("@FANREM1", FANREM1)
            Cmd.Parameters.AddWithValue("@FANREM2", FANREM2)
            Cmd.Parameters.AddWithValue("@FANREM3", FANREM3)
            Cmd.Parameters.AddWithValue("@FANREM4", FANREM4)
            Cmd.Parameters.AddWithValue("@FANREM5", FANREM5)
            Cmd.Parameters.AddWithValue("@FANREM6", FANREM6)
            Cmd.Parameters.AddWithValue("@FANREM7", FANREM7)
            Cmd.Parameters.AddWithValue("@FANREM8", FANREM8)
            Cmd.Parameters.AddWithValue("@FANREM9", FANREM9)
            Cmd.Parameters.AddWithValue("@FANREM10", FANREM10)
            Cmd.Parameters.AddWithValue("@CREATEDBY", CREATEDBY)
            Cmd.Parameters.AddWithValue("@OverallStatus", OverallStatus)


            Return Cmd.ExecuteNonQuery()
        Catch ex As Exception



        End Try
    End Function

    Public Shared Function BallMillCheckSheet(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select * From Tbl_BallMillCheckSheet Where SNO in(Select Max(SNO) From Tbl_BallMillCheckSheet)", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function OverallBallMillCheckSheet(ByVal cnn As String, ByVal SNO As Integer) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select * From Tbl_BallMillCheckSheet Where SNO=" & SNO & " Order By SNO Desc", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function


    Public Shared Function BallMillOverallData(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select SNO,Convert(varchar(10),CDate,103) as CDate, CreatedBy From Tbl_BallMillCheckSheet Order By SNO Desc", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function


    Public Shared Function BallMillOverallDataPreparedBy(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select Distinct(CreatedBy) From Tbl_BallMillCheckSheet Order By CreatedBy", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function BallMillOverallDataByUser(ByVal cnn As String, ByVal PreparedBy As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select SNO,Convert(varchar(10),CDate,103) as CDate, CreatedBy From Tbl_BallMillCheckSheet Where CreatedBy='" & PreparedBy & "' Order By SNO Desc", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    ''' 

    '''TPH - Ball Mill Check Sheet - 30-01-2013

    Public Shared Function InsertTblDailyBallMillCheckStreet_TPH(ByVal ConStr As String, _
ByVal CrDate As DateTime, _
ByVal AStatus As String, _
ByVal SBSL1 As String, _
ByVal SBSL2 As String, _
ByVal SBSL3 As String, _
ByVal SBSL4 As String, _
ByVal SBSL5 As String, _
ByVal SBSL6 As String, _
ByVal SBSL7 As String, _
ByVal SBSL8 As String, _
ByVal SBSL9 As String, _
ByVal SBSL10 As String, _
ByVal SBSL11 As String, _
ByVal SBSL12 As String, _
ByVal SBSL13 As String, _
ByVal SBSL14 As String, _
ByVal SBSL15 As String, _
ByVal SBSL16 As String, _
ByVal SBSL17 As String, _
ByVal SBSL18 As String, _
ByVal SBSL19 As String, _
ByVal SBSL20 As String, _
ByVal SBSL21 As String, _
ByVal SBIW1 As Double, _
ByVal SBIW2 As Double, _
ByVal SBIW3 As Double, _
ByVal SBIW4 As Double, _
ByVal SBIW5 As Double, _
ByVal SBIW6 As Double, _
ByVal SBIW7 As Double, _
ByVal SBIW8 As Double, _
ByVal SBIW9 As Double, _
ByVal SBIW10 As Double, _
ByVal SBIW11 As Double, _
ByVal SBIW12 As Double, _
ByVal SBIW13 As Double, _
ByVal SBIW14 As Double, _
ByVal SBIW15 As Double, _
ByVal SBIW16 As Double, _
ByVal SBIW17 As Double, _
ByVal SBIW18 As Double, _
ByVal SBIW19 As Double, _
ByVal SBIW20 As Double, _
ByVal SBIW21 As Double, _
ByVal SBOW1 As Double, _
ByVal SBOW2 As Double, _
ByVal SBOW3 As Double, _
ByVal SBOW4 As Double, _
ByVal SBOW5 As Double, _
ByVal SBOW6 As Double, _
ByVal SBOW7 As Double, _
ByVal SBOW8 As Double, _
ByVal SBOW9 As Double, _
ByVal SBOW10 As Double, _
ByVal SBOW11 As Double, _
ByVal SBOW12 As Double, _
ByVal SBOW13 As Double, _
ByVal SBOW14 As Double, _
ByVal SBOW15 As Double, _
ByVal SBOW16 As Double, _
ByVal SBOW17 As Double, _
ByVal SBOW18 As Double, _
ByVal SBOW19 As Double, _
ByVal SBOW20 As Double, _
ByVal SBOW21 As Double, _
ByVal SBCL1 As String, _
ByVal SBCL2 As String, _
ByVal SBCL3 As String, _
ByVal SBCL4 As String, _
ByVal SBCL5 As String, _
ByVal SBCL6 As String, _
ByVal SBCL7 As String, _
ByVal SBCL8 As String, _
ByVal SBCL9 As String, _
ByVal SBCL10 As String, _
ByVal SBCL11 As String, _
ByVal SBCL12 As String, _
ByVal SBCL13 As String, _
ByVal SBCL14 As String, _
ByVal SBCL15 As String, _
ByVal SBCL16 As String, _
ByVal SBCL17 As String, _
ByVal SBCL18 As String, _
ByVal SBCL19 As String, _
ByVal SBCL20 As String, _
ByVal SBCL21 As String, _
ByVal SBCN1 As String, _
ByVal SBCN2 As String, _
ByVal SBCN3 As String, _
ByVal SBCN4 As String, _
ByVal SBCN5 As String, _
ByVal SBCN6 As String, _
ByVal SBCN7 As String, _
ByVal SBCN8 As String, _
ByVal SBCN9 As String, _
ByVal SBCN10 As String, _
ByVal SBCN11 As String, _
ByVal SBCN12 As String, _
ByVal SBCN13 As String, _
ByVal SBCN14 As String, _
ByVal SBCN15 As String, _
ByVal SBCN16 As String, _
ByVal SBCN17 As String, _
ByVal SBCN18 As String, _
ByVal SBCN19 As String, _
ByVal SBCN20 As String, _
ByVal SBCN21 As String, _
ByVal SBSND1 As String, _
ByVal SBSND2 As String, _
ByVal SBSND3 As String, _
ByVal SBSND4 As String, _
ByVal SBSND5 As String, _
ByVal SBSND6 As String, _
ByVal SBSND7 As String, _
ByVal SBSND8 As String, _
ByVal SBSND9 As String, _
ByVal SBSND10 As String, _
ByVal SBSND11 As String, _
ByVal SBSND12 As String, _
ByVal SBSND13 As String, _
ByVal SBSND14 As String, _
ByVal SBSND15 As String, _
ByVal SBSND16 As String, _
ByVal SBSND17 As String, _
ByVal SBSND18 As String, _
ByVal SBSND19 As String, _
ByVal SBSND20 As String, _
ByVal SBSND21 As String, _
ByVal SBVBN1 As String, _
ByVal SBVBN2 As String, _
ByVal SBVBN3 As String, _
ByVal SBVBN4 As String, _
ByVal SBVBN5 As String, _
ByVal SBVBN6 As String, _
ByVal SBVBN7 As String, _
ByVal SBVBN8 As String, _
ByVal SBVBN9 As String, _
ByVal SBVBN10 As String, _
ByVal SBVBN11 As String, _
ByVal SBVBN12 As String, _
ByVal SBVBN13 As String, _
ByVal SBVBN14 As String, _
ByVal SBVBN15 As String, _
ByVal SBVBN16 As String, _
ByVal SBVBN17 As String, _
ByVal SBVBN18 As String, _
ByVal SBVBN19 As String, _
ByVal SBVBN20 As String, _
ByVal SBVBN21 As String, _
ByVal SBREM1 As String, _
ByVal SBREM2 As String, _
ByVal SBREM3 As String, _
ByVal SBREM4 As String, _
ByVal SBREM5 As String, _
ByVal SBREM6 As String, _
ByVal SBREM7 As String, _
ByVal SBREM8 As String, _
ByVal SBREM9 As String, _
ByVal SBREM10 As String, _
ByVal SBREM11 As String, _
ByVal SBREM12 As String, _
ByVal SBREM13 As String, _
ByVal SBREM14 As String, _
ByVal SBREM15 As String, _
ByVal SBREM16 As String, _
ByVal SBREM17 As String, _
ByVal SBREM18 As String, _
ByVal SBREM19 As String, _
ByVal SBREM20 As String, _
ByVal SBREM21 As String, _
ByVal EPNTCLP1 As String, _
ByVal EPNTCLP2 As String, _
ByVal EPNTCLP3 As String, _
ByVal EPNTCLP4 As String, _
ByVal EPNTCLP5 As String, _
ByVal EPNTCLP6 As String, _
ByVal EPNTCLP7 As String, _
ByVal EPNTCLP8 As String, _
ByVal EPNTCLP9 As String, _
ByVal EPNTCLP10 As String, _
ByVal EPNTCLP11 As String, _
ByVal EPNTCLP12 As String, _
ByVal EPNTCLP13 As String, _
ByVal EPNTCLP14 As String, _
ByVal EPNTWRE1 As String, _
ByVal EPNTWRE2 As String, _
ByVal EPNTWRE3 As String, _
ByVal EPNTWRE4 As String, _
ByVal EPNTWRE5 As String, _
ByVal EPNTWRE6 As String, _
ByVal EPNTWRE7 As String, _
ByVal EPNTWRE8 As String, _
ByVal EPNTWRE9 As String, _
ByVal EPNTWRE10 As String, _
ByVal EPNTWRE11 As String, _
ByVal EPNTWRE12 As String, _
ByVal EPNTWRE13 As String, _
ByVal EPNTWRE14 As String, _
ByVal EPNTREM1 As String, _
ByVal EPNTREM2 As String, _
ByVal EPNTREM3 As String, _
ByVal EPNTREM4 As String, _
ByVal EPNTREM5 As String, _
ByVal EPNTREM6 As String, _
ByVal EPNTREM7 As String, _
ByVal EPNTREM8 As String, _
ByVal EPNTREM9 As String, _
ByVal EPNTREM10 As String, _
ByVal EPNTREM11 As String, _
ByVal EPNTREM12 As String, _
ByVal EPNTREM13 As String, _
ByVal EPNTREM14 As String, _
ByVal NPNTCN1 As String, _
ByVal NPNTCN2 As String, _
ByVal NPNTCN3 As String, _
ByVal NPNTCN4 As String, _
ByVal NPNTCN5 As String, _
ByVal NPNTCN6 As String, _
ByVal NPNTCN7 As String, _
ByVal NPNTCN8 As String, _
ByVal NPNTCN9 As String, _
ByVal NPNTCN10 As String, _
ByVal NPNTCN11 As String, _
ByVal NPNTCN12 As String, _
ByVal NPNTREM1 As String, _
ByVal NPNTREM2 As String, _
ByVal NPNTREM3 As String, _
ByVal NPNTREM4 As String, _
ByVal NPNTREM5 As String, _
ByVal NPNTREM6 As String, _
ByVal NPNTREM7 As String, _
ByVal NPNTREM8 As String, _
ByVal NPNTREM9 As String, _
ByVal NPNTREM10 As String, _
ByVal NPNTREM11 As String, _
ByVal NPNTREM12 As String, _
ByVal XYLNOZZLE As String, _
ByVal IPANOZZLE As String, _
ByVal RIPNOZZLE As String, _
ByVal XYLLEAK As String, _
ByVal IPALEAK As String, _
ByVal RIPLEAK As String, _
ByVal CHREM1 As String, _
ByVal CHREM2 As String, _
ByVal CHREM3 As String, _
ByVal CRNCN1 As String, _
ByVal CRNCN2 As String, _
ByVal CRNCN3 As String, _
ByVal CRNREM1 As String, _
ByVal CRNREM2 As String, _
ByVal CRNREM3 As String, _
ByVal FANCN1 As String, _
ByVal FANCN2 As String, _
ByVal FANCN3 As String, _
ByVal FANCN4 As String, _
ByVal FANCN5 As String, _
ByVal FANCN6 As String, _
ByVal FANCN7 As String, _
ByVal FANCN8 As String, _
ByVal FANCN9 As String, _
ByVal FANCN10 As String, _
ByVal FANREM1 As String, _
ByVal FANREM2 As String, _
ByVal FANREM3 As String, _
ByVal FANREM4 As String, _
ByVal FANREM5 As String, _
ByVal FANREM6 As String, _
ByVal FANREM7 As String, _
ByVal FANREM8 As String, _
ByVal FANREM9 As String, _
ByVal FANREM10 As String, _
ByVal CREATEDBY As String, ByVal OverallStatus As String) As Boolean
        Try


            Dim Con As New SqlConnection
            Con = New SqlConnection(ConStr)
            Con.Open()
            Dim Cmd As New SqlCommand
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "SP_INS_TblBallMillCheckSheet_TPH"
            Cmd.Connection = Con


            Cmd.Parameters.AddWithValue("@CDate", CrDate.ToString("MM/dd/yyyy"))
            Cmd.Parameters.AddWithValue("@AStatus", AStatus)
            Cmd.Parameters.AddWithValue("@SBSL1", SBSL1)
            Cmd.Parameters.AddWithValue("@SBSL2", SBSL2)
            Cmd.Parameters.AddWithValue("@SBSL3", SBSL3)
            Cmd.Parameters.AddWithValue("@SBSL4", SBSL4)
            Cmd.Parameters.AddWithValue("@SBSL5", SBSL5)
            Cmd.Parameters.AddWithValue("@SBSL6", SBSL6)
            Cmd.Parameters.AddWithValue("@SBSL7", SBSL7)
            Cmd.Parameters.AddWithValue("@SBSL8", SBSL8)
            Cmd.Parameters.AddWithValue("@SBSL9", SBSL9)
            Cmd.Parameters.AddWithValue("@SBSL10", SBSL10)
            Cmd.Parameters.AddWithValue("@SBSL11", SBSL11)
            Cmd.Parameters.AddWithValue("@SBSL12", SBSL12)
            Cmd.Parameters.AddWithValue("@SBSL13", SBSL13)
            Cmd.Parameters.AddWithValue("@SBSL14", SBSL14)
            Cmd.Parameters.AddWithValue("@SBSL15", SBSL15)
            Cmd.Parameters.AddWithValue("@SBSL16", SBSL16)
            Cmd.Parameters.AddWithValue("@SBSL17", SBSL17)
            Cmd.Parameters.AddWithValue("@SBSL18", SBSL18)
            Cmd.Parameters.AddWithValue("@SBSL19", SBSL19)
            Cmd.Parameters.AddWithValue("@SBSL20", SBSL20)
            Cmd.Parameters.AddWithValue("@SBSL21", SBSL21)
            Cmd.Parameters.AddWithValue("@SBIW1", SBIW1)
            Cmd.Parameters.AddWithValue("@SBIW2", SBIW2)
            Cmd.Parameters.AddWithValue("@SBIW3", SBIW3)
            Cmd.Parameters.AddWithValue("@SBIW4", SBIW4)
            Cmd.Parameters.AddWithValue("@SBIW5", SBIW5)
            Cmd.Parameters.AddWithValue("@SBIW6", SBIW6)
            Cmd.Parameters.AddWithValue("@SBIW7", SBIW7)
            Cmd.Parameters.AddWithValue("@SBIW8", SBIW8)
            Cmd.Parameters.AddWithValue("@SBIW9", SBIW9)
            Cmd.Parameters.AddWithValue("@SBIW10", SBIW10)
            Cmd.Parameters.AddWithValue("@SBIW11", SBIW11)
            Cmd.Parameters.AddWithValue("@SBIW12", SBIW12)
            Cmd.Parameters.AddWithValue("@SBIW13", SBIW13)
            Cmd.Parameters.AddWithValue("@SBIW14", SBIW14)
            Cmd.Parameters.AddWithValue("@SBIW15", SBIW15)
            Cmd.Parameters.AddWithValue("@SBIW16", SBIW16)
            Cmd.Parameters.AddWithValue("@SBIW17", SBIW17)
            Cmd.Parameters.AddWithValue("@SBIW18", SBIW18)
            Cmd.Parameters.AddWithValue("@SBIW19", SBIW19)
            Cmd.Parameters.AddWithValue("@SBIW20", SBIW20)
            Cmd.Parameters.AddWithValue("@SBIW21", SBIW21)
            Cmd.Parameters.AddWithValue("@SBOW1", SBOW1)
            Cmd.Parameters.AddWithValue("@SBOW2", SBOW2)
            Cmd.Parameters.AddWithValue("@SBOW3", SBOW3)
            Cmd.Parameters.AddWithValue("@SBOW4", SBOW4)
            Cmd.Parameters.AddWithValue("@SBOW5", SBOW5)
            Cmd.Parameters.AddWithValue("@SBOW6", SBOW6)
            Cmd.Parameters.AddWithValue("@SBOW7", SBOW7)
            Cmd.Parameters.AddWithValue("@SBOW8", SBOW8)
            Cmd.Parameters.AddWithValue("@SBOW9", SBOW9)
            Cmd.Parameters.AddWithValue("@SBOW10", SBOW10)
            Cmd.Parameters.AddWithValue("@SBOW11", SBOW11)
            Cmd.Parameters.AddWithValue("@SBOW12", SBOW12)
            Cmd.Parameters.AddWithValue("@SBOW13", SBOW13)
            Cmd.Parameters.AddWithValue("@SBOW14", SBOW14)
            Cmd.Parameters.AddWithValue("@SBOW15", SBOW15)
            Cmd.Parameters.AddWithValue("@SBOW16", SBOW16)
            Cmd.Parameters.AddWithValue("@SBOW17", SBOW17)
            Cmd.Parameters.AddWithValue("@SBOW18", SBOW18)
            Cmd.Parameters.AddWithValue("@SBOW19", SBOW19)
            Cmd.Parameters.AddWithValue("@SBOW20", SBOW20)
            Cmd.Parameters.AddWithValue("@SBOW21", SBOW21)
            Cmd.Parameters.AddWithValue("@SBCL1", SBCL1)
            Cmd.Parameters.AddWithValue("@SBCL2", SBCL2)
            Cmd.Parameters.AddWithValue("@SBCL3", SBCL3)
            Cmd.Parameters.AddWithValue("@SBCL4", SBCL4)
            Cmd.Parameters.AddWithValue("@SBCL5", SBCL5)
            Cmd.Parameters.AddWithValue("@SBCL6", SBCL6)
            Cmd.Parameters.AddWithValue("@SBCL7", SBCL7)
            Cmd.Parameters.AddWithValue("@SBCL8", SBCL8)
            Cmd.Parameters.AddWithValue("@SBCL9", SBCL9)
            Cmd.Parameters.AddWithValue("@SBCL10", SBCL10)
            Cmd.Parameters.AddWithValue("@SBCL11", SBCL11)
            Cmd.Parameters.AddWithValue("@SBCL12", SBCL12)
            Cmd.Parameters.AddWithValue("@SBCL13", SBCL13)
            Cmd.Parameters.AddWithValue("@SBCL14", SBCL14)
            Cmd.Parameters.AddWithValue("@SBCL15", SBCL15)
            Cmd.Parameters.AddWithValue("@SBCL16", SBCL16)
            Cmd.Parameters.AddWithValue("@SBCL17", SBCL17)
            Cmd.Parameters.AddWithValue("@SBCL18", SBCL18)
            Cmd.Parameters.AddWithValue("@SBCL19", SBCL19)
            Cmd.Parameters.AddWithValue("@SBCL20", SBCL20)
            Cmd.Parameters.AddWithValue("@SBCL21", SBCL21)
            Cmd.Parameters.AddWithValue("@SBCN1", SBCN1)
            Cmd.Parameters.AddWithValue("@SBCN2", SBCN2)
            Cmd.Parameters.AddWithValue("@SBCN3", SBCN3)
            Cmd.Parameters.AddWithValue("@SBCN4", SBCN4)
            Cmd.Parameters.AddWithValue("@SBCN5", SBCN5)
            Cmd.Parameters.AddWithValue("@SBCN6", SBCN6)
            Cmd.Parameters.AddWithValue("@SBCN7", SBCN7)
            Cmd.Parameters.AddWithValue("@SBCN8", SBCN8)
            Cmd.Parameters.AddWithValue("@SBCN9", SBCN9)
            Cmd.Parameters.AddWithValue("@SBCN10", SBCN10)
            Cmd.Parameters.AddWithValue("@SBCN11", SBCN11)
            Cmd.Parameters.AddWithValue("@SBCN12", SBCN12)
            Cmd.Parameters.AddWithValue("@SBCN13", SBCN13)
            Cmd.Parameters.AddWithValue("@SBCN14", SBCN14)
            Cmd.Parameters.AddWithValue("@SBCN15", SBCN15)
            Cmd.Parameters.AddWithValue("@SBCN16", SBCN16)
            Cmd.Parameters.AddWithValue("@SBCN17", SBCN17)
            Cmd.Parameters.AddWithValue("@SBCN18", SBCN18)
            Cmd.Parameters.AddWithValue("@SBCN19", SBCN19)
            Cmd.Parameters.AddWithValue("@SBCN20", SBCN20)
            Cmd.Parameters.AddWithValue("@SBCN21", SBCN21)
            Cmd.Parameters.AddWithValue("@SBSND1", SBSND1)
            Cmd.Parameters.AddWithValue("@SBSND2", SBSND2)
            Cmd.Parameters.AddWithValue("@SBSND3", SBSND3)
            Cmd.Parameters.AddWithValue("@SBSND4", SBSND4)
            Cmd.Parameters.AddWithValue("@SBSND5", SBSND5)
            Cmd.Parameters.AddWithValue("@SBSND6", SBSND6)
            Cmd.Parameters.AddWithValue("@SBSND7", SBSND7)
            Cmd.Parameters.AddWithValue("@SBSND8", SBSND8)
            Cmd.Parameters.AddWithValue("@SBSND9", SBSND9)
            Cmd.Parameters.AddWithValue("@SBSND10", SBSND10)
            Cmd.Parameters.AddWithValue("@SBSND11", SBSND11)
            Cmd.Parameters.AddWithValue("@SBSND12", SBSND12)
            Cmd.Parameters.AddWithValue("@SBSND13", SBSND13)
            Cmd.Parameters.AddWithValue("@SBSND14", SBSND14)
            Cmd.Parameters.AddWithValue("@SBSND15", SBSND15)
            Cmd.Parameters.AddWithValue("@SBSND16", SBSND16)
            Cmd.Parameters.AddWithValue("@SBSND17", SBSND17)
            Cmd.Parameters.AddWithValue("@SBSND18", SBSND18)
            Cmd.Parameters.AddWithValue("@SBSND19", SBSND19)
            Cmd.Parameters.AddWithValue("@SBSND20", SBSND20)
            Cmd.Parameters.AddWithValue("@SBSND21", SBSND21)
            Cmd.Parameters.AddWithValue("@SBVBN1", SBVBN1)
            Cmd.Parameters.AddWithValue("@SBVBN2", SBVBN2)
            Cmd.Parameters.AddWithValue("@SBVBN3", SBVBN3)
            Cmd.Parameters.AddWithValue("@SBVBN4", SBVBN4)
            Cmd.Parameters.AddWithValue("@SBVBN5", SBVBN5)
            Cmd.Parameters.AddWithValue("@SBVBN6", SBVBN6)
            Cmd.Parameters.AddWithValue("@SBVBN7", SBVBN7)
            Cmd.Parameters.AddWithValue("@SBVBN8", SBVBN8)
            Cmd.Parameters.AddWithValue("@SBVBN9", SBVBN9)
            Cmd.Parameters.AddWithValue("@SBVBN10", SBVBN10)
            Cmd.Parameters.AddWithValue("@SBVBN11", SBVBN11)
            Cmd.Parameters.AddWithValue("@SBVBN12", SBVBN12)
            Cmd.Parameters.AddWithValue("@SBVBN13", SBVBN13)
            Cmd.Parameters.AddWithValue("@SBVBN14", SBVBN14)
            Cmd.Parameters.AddWithValue("@SBVBN15", SBVBN15)
            Cmd.Parameters.AddWithValue("@SBVBN16", SBVBN16)
            Cmd.Parameters.AddWithValue("@SBVBN17", SBVBN17)
            Cmd.Parameters.AddWithValue("@SBVBN18", SBVBN18)
            Cmd.Parameters.AddWithValue("@SBVBN19", SBVBN19)
            Cmd.Parameters.AddWithValue("@SBVBN20", SBVBN20)
            Cmd.Parameters.AddWithValue("@SBVBN21", SBVBN21)
            Cmd.Parameters.AddWithValue("@SBREM1", SBREM1)
            Cmd.Parameters.AddWithValue("@SBREM2", SBREM2)
            Cmd.Parameters.AddWithValue("@SBREM3", SBREM3)
            Cmd.Parameters.AddWithValue("@SBREM4", SBREM4)
            Cmd.Parameters.AddWithValue("@SBREM5", SBREM5)
            Cmd.Parameters.AddWithValue("@SBREM6", SBREM6)
            Cmd.Parameters.AddWithValue("@SBREM7", SBREM7)
            Cmd.Parameters.AddWithValue("@SBREM8", SBREM8)
            Cmd.Parameters.AddWithValue("@SBREM9", SBREM9)
            Cmd.Parameters.AddWithValue("@SBREM10", SBREM10)
            Cmd.Parameters.AddWithValue("@SBREM11", SBREM11)
            Cmd.Parameters.AddWithValue("@SBREM12", SBREM12)
            Cmd.Parameters.AddWithValue("@SBREM13", SBREM13)
            Cmd.Parameters.AddWithValue("@SBREM14", SBREM14)
            Cmd.Parameters.AddWithValue("@SBREM15", SBREM15)
            Cmd.Parameters.AddWithValue("@SBREM16", SBREM16)
            Cmd.Parameters.AddWithValue("@SBREM17", SBREM17)
            Cmd.Parameters.AddWithValue("@SBREM18", SBREM18)
            Cmd.Parameters.AddWithValue("@SBREM19", SBREM19)
            Cmd.Parameters.AddWithValue("@SBREM20", SBREM20)
            Cmd.Parameters.AddWithValue("@SBREM21", SBREM21)
            Cmd.Parameters.AddWithValue("@EPNTCLP1", EPNTCLP1)
            Cmd.Parameters.AddWithValue("@EPNTCLP2", EPNTCLP2)
            Cmd.Parameters.AddWithValue("@EPNTCLP3", EPNTCLP3)
            Cmd.Parameters.AddWithValue("@EPNTCLP4", EPNTCLP4)
            Cmd.Parameters.AddWithValue("@EPNTCLP5", EPNTCLP5)
            Cmd.Parameters.AddWithValue("@EPNTCLP6", EPNTCLP6)
            Cmd.Parameters.AddWithValue("@EPNTCLP7", EPNTCLP7)
            Cmd.Parameters.AddWithValue("@EPNTCLP8", EPNTCLP8)
            Cmd.Parameters.AddWithValue("@EPNTCLP9", EPNTCLP9)
            Cmd.Parameters.AddWithValue("@EPNTCLP10", EPNTCLP10)
            Cmd.Parameters.AddWithValue("@EPNTCLP11", EPNTCLP11)
            Cmd.Parameters.AddWithValue("@EPNTCLP12", EPNTCLP12)
            Cmd.Parameters.AddWithValue("@EPNTCLP13", EPNTCLP13)
            Cmd.Parameters.AddWithValue("@EPNTCLP14", EPNTCLP14)
            Cmd.Parameters.AddWithValue("@EPNTWRE1", EPNTWRE1)
            Cmd.Parameters.AddWithValue("@EPNTWRE2", EPNTWRE2)
            Cmd.Parameters.AddWithValue("@EPNTWRE3", EPNTWRE3)
            Cmd.Parameters.AddWithValue("@EPNTWRE4", EPNTWRE4)
            Cmd.Parameters.AddWithValue("@EPNTWRE5", EPNTWRE5)
            Cmd.Parameters.AddWithValue("@EPNTWRE6", EPNTWRE6)
            Cmd.Parameters.AddWithValue("@EPNTWRE7", EPNTWRE7)
            Cmd.Parameters.AddWithValue("@EPNTWRE8", EPNTWRE8)
            Cmd.Parameters.AddWithValue("@EPNTWRE9", EPNTWRE9)
            Cmd.Parameters.AddWithValue("@EPNTWRE10", EPNTWRE10)
            Cmd.Parameters.AddWithValue("@EPNTWRE11", EPNTWRE11)
            Cmd.Parameters.AddWithValue("@EPNTWRE12", EPNTWRE12)
            Cmd.Parameters.AddWithValue("@EPNTWRE13", EPNTWRE13)
            Cmd.Parameters.AddWithValue("@EPNTWRE14", EPNTWRE14)
            Cmd.Parameters.AddWithValue("@EPNTREM1", EPNTREM1)
            Cmd.Parameters.AddWithValue("@EPNTREM2", EPNTREM2)
            Cmd.Parameters.AddWithValue("@EPNTREM3", EPNTREM3)
            Cmd.Parameters.AddWithValue("@EPNTREM4", EPNTREM4)
            Cmd.Parameters.AddWithValue("@EPNTREM5", EPNTREM5)
            Cmd.Parameters.AddWithValue("@EPNTREM6", EPNTREM6)
            Cmd.Parameters.AddWithValue("@EPNTREM7", EPNTREM7)
            Cmd.Parameters.AddWithValue("@EPNTREM8", EPNTREM8)
            Cmd.Parameters.AddWithValue("@EPNTREM9", EPNTREM9)
            Cmd.Parameters.AddWithValue("@EPNTREM10", EPNTREM10)
            Cmd.Parameters.AddWithValue("@EPNTREM11", EPNTREM11)
            Cmd.Parameters.AddWithValue("@EPNTREM12", EPNTREM12)
            Cmd.Parameters.AddWithValue("@EPNTREM13", EPNTREM13)
            Cmd.Parameters.AddWithValue("@EPNTREM14", EPNTREM14)
            Cmd.Parameters.AddWithValue("@NPNTCN1", NPNTCN1)
            Cmd.Parameters.AddWithValue("@NPNTCN2", NPNTCN2)
            Cmd.Parameters.AddWithValue("@NPNTCN3", NPNTCN3)
            Cmd.Parameters.AddWithValue("@NPNTCN4", NPNTCN4)
            Cmd.Parameters.AddWithValue("@NPNTCN5", NPNTCN5)
            Cmd.Parameters.AddWithValue("@NPNTCN6", NPNTCN6)
            Cmd.Parameters.AddWithValue("@NPNTCN7", NPNTCN7)
            Cmd.Parameters.AddWithValue("@NPNTCN8", NPNTCN8)
            Cmd.Parameters.AddWithValue("@NPNTCN9", NPNTCN9)
            Cmd.Parameters.AddWithValue("@NPNTCN10", NPNTCN10)
            Cmd.Parameters.AddWithValue("@NPNTCN11", NPNTCN11)
            Cmd.Parameters.AddWithValue("@NPNTCN12", NPNTCN12)
            Cmd.Parameters.AddWithValue("@NPNTREM1", NPNTREM1)
            Cmd.Parameters.AddWithValue("@NPNTREM2", NPNTREM2)
            Cmd.Parameters.AddWithValue("@NPNTREM3", NPNTREM3)
            Cmd.Parameters.AddWithValue("@NPNTREM4", NPNTREM4)
            Cmd.Parameters.AddWithValue("@NPNTREM5", NPNTREM5)
            Cmd.Parameters.AddWithValue("@NPNTREM6", NPNTREM6)
            Cmd.Parameters.AddWithValue("@NPNTREM7", NPNTREM7)
            Cmd.Parameters.AddWithValue("@NPNTREM8", NPNTREM8)
            Cmd.Parameters.AddWithValue("@NPNTREM9", NPNTREM9)
            Cmd.Parameters.AddWithValue("@NPNTREM10", NPNTREM10)
            Cmd.Parameters.AddWithValue("@NPNTREM11", NPNTREM11)
            Cmd.Parameters.AddWithValue("@NPNTREM12", NPNTREM12)
            Cmd.Parameters.AddWithValue("@XYLNOZZLE", XYLNOZZLE)
            Cmd.Parameters.AddWithValue("@IPANOZZLE", IPANOZZLE)
            Cmd.Parameters.AddWithValue("@RIPNOZZLE", RIPNOZZLE)
            Cmd.Parameters.AddWithValue("@XYLLEAK", XYLLEAK)
            Cmd.Parameters.AddWithValue("@IPALEAK", IPALEAK)
            Cmd.Parameters.AddWithValue("@RIPLEAK", RIPLEAK)
            Cmd.Parameters.AddWithValue("@CHREM1", CHREM1)
            Cmd.Parameters.AddWithValue("@CHREM2", CHREM2)
            Cmd.Parameters.AddWithValue("@CHREM3", CHREM3)
            Cmd.Parameters.AddWithValue("@CRNCN1", CRNCN1)
            Cmd.Parameters.AddWithValue("@CRNCN2", CRNCN2)
            Cmd.Parameters.AddWithValue("@CRNCN3", CRNCN3)
            Cmd.Parameters.AddWithValue("@CRNREM1", CRNREM1)
            Cmd.Parameters.AddWithValue("@CRNREM2", CRNREM2)
            Cmd.Parameters.AddWithValue("@CRNREM3", CRNREM3)
            Cmd.Parameters.AddWithValue("@FANCN1", FANCN1)
            Cmd.Parameters.AddWithValue("@FANCN2", FANCN2)
            Cmd.Parameters.AddWithValue("@FANCN3", FANCN3)
            Cmd.Parameters.AddWithValue("@FANCN4", FANCN4)
            Cmd.Parameters.AddWithValue("@FANCN5", FANCN5)
            Cmd.Parameters.AddWithValue("@FANCN6", FANCN6)
            Cmd.Parameters.AddWithValue("@FANCN7", FANCN7)
            Cmd.Parameters.AddWithValue("@FANCN8", FANCN8)
            Cmd.Parameters.AddWithValue("@FANCN9", FANCN9)
            Cmd.Parameters.AddWithValue("@FANCN10", FANCN10)
            Cmd.Parameters.AddWithValue("@FANREM1", FANREM1)
            Cmd.Parameters.AddWithValue("@FANREM2", FANREM2)
            Cmd.Parameters.AddWithValue("@FANREM3", FANREM3)
            Cmd.Parameters.AddWithValue("@FANREM4", FANREM4)
            Cmd.Parameters.AddWithValue("@FANREM5", FANREM5)
            Cmd.Parameters.AddWithValue("@FANREM6", FANREM6)
            Cmd.Parameters.AddWithValue("@FANREM7", FANREM7)
            Cmd.Parameters.AddWithValue("@FANREM8", FANREM8)
            Cmd.Parameters.AddWithValue("@FANREM9", FANREM9)
            Cmd.Parameters.AddWithValue("@FANREM10", FANREM10)
            Cmd.Parameters.AddWithValue("@CREATEDBY", CREATEDBY)
            Cmd.Parameters.AddWithValue("@OverallStatus", OverallStatus)

            Return Cmd.ExecuteNonQuery()

        Catch ex As Exception



        End Try
    End Function

    Public Shared Function BallMillCheckSheet_TPH(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select * From Tbl_TPHBallMillCheckSheet Where SNO in(Select Max(SNO) From Tbl_TPHBallMillCheckSheet)", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function BallMillOverallData_TPH(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select SNO,Convert(varchar(10),CDate,103) as CDate, CreatedBy From Tbl_TPHBallMillCheckSheet Order By SNO Desc", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function OverallBallMillCheckSheet_TPH(ByVal cnn As String, ByVal SNO As Integer) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select * From Tbl_TPHBallMillCheckSheet Where SNO=" & SNO & " Order By SNO Desc", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function BallMillOverallDataPreparedBy_TPH(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select Distinct(CreatedBy) From Tbl_TPHBallMillCheckSheet Order By CreatedBy", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function

    Public Shared Function BallMillOverallDataByUser_TPH(ByVal cnn As String, ByVal PreparedBy As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Dim da As New SqlDataAdapter
        da.SelectCommand = New SqlCommand("Select SNO,Convert(varchar(10),CDate,103) as CDate, CreatedBy From Tbl_TPHBallMillCheckSheet Where CreatedBy='" & PreparedBy & "' Order By SNO Desc", Con)
        cb = New SqlCommandBuilder(da)
        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function



    '' customer visit module

    Public Shared Function SelectAllCustomer(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectAllCustomer"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "NormalUser1")
        Return ds
    End Function


    Public Shared Function InssertCustomerVisitPreparationForm(ByVal ConStr As String, _
     ByVal UID As Integer, _
  ByVal VisitFrom As Date, _
  ByVal VisitTo As Date, _
  ByVal NoofDays As Integer, _
  ByVal CustomerName As String, _
  ByVal Department As String, _
  ByVal NoofCustomer As Integer, _
  ByVal AttendanceName As String, _
  ByVal AttendanceDesignation As String, _
  ByVal PurposeOfVisit As String, _
  ByVal Safety As Integer, _
  ByVal Company As Integer, _
  ByVal Profile1 As Integer, _
  ByVal Beverages As Integer, _
  ByVal Towels As Integer, _
  ByVal Souvenirs As Integer, _
  ByVal Stationery As Integer, _
  ByVal SafetyPPE As Integer, _
  ByVal SalesOthers As Integer, _
  ByVal SalesOthers1 As String, _
  ByVal FiveS As Integer, _
  ByVal ProductionArrangement As Integer, _
  ByVal ProductionOthers As Integer, _
  ByVal ProductionOthers1 As String, _
  ByVal ProcessFlow As Integer, _
  ByVal QualityPlan As Integer, _
  ByVal ClaimStatus As Integer, _
  ByVal QAOthers As Integer, _
  ByVal QAOthers1 As String, _
  ByVal Arrival As Integer, _
  ByVal Departure As Integer, _
  ByVal Accommodation As Integer, _
  ByVal Lunch As Integer, _
  ByVal Dinner As Integer, _
  ByVal WelcomeBoard As Integer, _
  ByVal WirelessIpAddress As Integer, _
  ByVal ItOthers As Integer, _
  ByVal ItOthers1 As String, _
  ByVal MeetingAttendance As Integer, _
  ByVal TMOthers As Integer, _
  ByVal TMOthers1 As String, _
  ByVal RID As Integer, _
  ByVal RIDAck As String, _
  ByVal RIDAckOn As Date, _
  ByVal CSID As Integer, _
  ByVal CSIDAck As String, _
  ByVal CSIDAckOn As Date, _
  ByVal OSHI As Integer, _
  ByVal OSHIAck As String, _
  ByVal OSHIAckOn As Date, _
  ByVal Sub1 As Integer, _
  ByVal SubAck As String, _
  ByVal SubAckOn As Date, _
   ByVal TPH As Integer, _
  ByVal TPHAck As String, _
  ByVal TPHAckOn As Date, _
  ByVal CV As Integer, _
  ByVal CVAck As String, _
  ByVal CVAckOn As Date, _
  ByVal FM As Integer, _
  ByVal FMAck As String, _
  ByVal FMAckOn As Date, _
  ByVal FS As Integer, _
  ByVal FSAck As String, _
  ByVal FSAckOn As Date, _
  ByVal QA As Integer, _
  ByVal QAAck As String, _
  ByVal QAAckOn As Date, _
  ByVal Admin As Integer, _
  ByVal AdminAck As String, _
  ByVal AdminAckOn As Date, _
  ByVal Security As Integer, _
  ByVal SecurityAck As String, _
  ByVal SecurityAckOn As Date, _
  ByVal It As Integer, _
  ByVal ITAck As String, _
  ByVal ITAckOn As Date, _
  ByVal Md As Integer, _
  ByVal MDAck As String, _
  ByVal MDAckOn As Date, _
  ByVal Ea As Integer, _
  ByVal EAAck As String, _
  ByVal EAAckOn As Date, _
  ByVal SalesRemarks As String, _
  ByVal ProductionRemarks As String, _
  ByVal QARemarks As String, _
  ByVal AdminRemarks As String, _
  ByVal ITRemarks As String, _
  ByVal TMRemarks As String, _
  ByVal CreatedBy As String, _
  ByVal CreatedOn As Date, _
  ByVal AttendanceName2 As String, _
  ByVal AttendanceDesignation2 As String, _
  ByVal AttendanceName3 As String, _
  ByVal AttendanceDesignation3 As String, _
  ByVal RequestedBy As String, _
  ByVal RequestorEID As String, _
  ByVal Astatus As String)

        Try
            Dim Con As New SqlConnection
            Con = New SqlConnection(ConStr)
            Con.Open()
            Dim Cmd As New SqlCommand
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "CV_InsertCustomerVisitPreparetionForm"
            Cmd.Connection = Con

            Cmd.Parameters.AddWithValue("@UID", UID)
            Cmd.Parameters.AddWithValue("@VisitFrom", VisitFrom)
            Cmd.Parameters.AddWithValue("@VisitTo", VisitTo)
            Cmd.Parameters.AddWithValue("@NoofDays", NoofDays)
            Cmd.Parameters.AddWithValue("@CustomerName", CustomerName)
            Cmd.Parameters.AddWithValue("@Department", Department)
            Cmd.Parameters.AddWithValue("@NoofCustomer", NoofCustomer)
            Cmd.Parameters.AddWithValue("@AttendanceName", AttendanceName)
            Cmd.Parameters.AddWithValue("@AttendanceDesignation", AttendanceDesignation)
            Cmd.Parameters.AddWithValue("@PurposeOfVisit", PurposeOfVisit)
            Cmd.Parameters.AddWithValue("@Safety", Safety)
            Cmd.Parameters.AddWithValue("@Company", Company)
            Cmd.Parameters.AddWithValue("@Profile1", Profile1)
            Cmd.Parameters.AddWithValue("@Beverages", Beverages)
            Cmd.Parameters.AddWithValue("@Towels", Towels)
            Cmd.Parameters.AddWithValue("@Souvenirs", Souvenirs)
            Cmd.Parameters.AddWithValue("@Stationery", Stationery)
            Cmd.Parameters.AddWithValue("@SafetyPPE", SafetyPPE)
            Cmd.Parameters.AddWithValue("@SalesOthers", SalesOthers)
            Cmd.Parameters.AddWithValue("@SalesOthers1", SalesOthers1)

            Cmd.Parameters.AddWithValue("@FiveS", FiveS)
            Cmd.Parameters.AddWithValue("@ProductionArrangement", ProductionArrangement)
            Cmd.Parameters.AddWithValue("@ProductionOthers", ProductionOthers)
            Cmd.Parameters.AddWithValue("@ProductionOthers1", ProductionOthers1)
            Cmd.Parameters.AddWithValue("@ProcessFlow", ProcessFlow)
            Cmd.Parameters.AddWithValue("@QualityPlan", QualityPlan)
            Cmd.Parameters.AddWithValue("@ClaimStatus", ClaimStatus)
            Cmd.Parameters.AddWithValue("@QAOthers", QAOthers)
            Cmd.Parameters.AddWithValue("@QAOthers1", QAOthers1)
            Cmd.Parameters.AddWithValue("@Arrival", Arrival)
            Cmd.Parameters.AddWithValue("@Departure", Departure)
            Cmd.Parameters.AddWithValue("@Accommodation", Accommodation)
            Cmd.Parameters.AddWithValue("@Lunch", Lunch)
            Cmd.Parameters.AddWithValue("@Dinner", Dinner)
            Cmd.Parameters.AddWithValue("@WelcomeBoard", WelcomeBoard)
            Cmd.Parameters.AddWithValue("@WirelessIpAddress", WirelessIpAddress)
            Cmd.Parameters.AddWithValue("@ItOthers", ItOthers)
            Cmd.Parameters.AddWithValue("@ItOthers1", ItOthers1)
            Cmd.Parameters.AddWithValue("@MeetingAttendance", MeetingAttendance)
            Cmd.Parameters.AddWithValue("@TMOthers", TMOthers)
            Cmd.Parameters.AddWithValue("@TMOthers1", TMOthers1)
            Cmd.Parameters.AddWithValue("@RID", RID)
            Cmd.Parameters.AddWithValue("@RIDAck", RIDAck)
            Cmd.Parameters.AddWithValue("@RIDAckOn", RIDAckOn)
            Cmd.Parameters.AddWithValue("@CSID", CSID)
            Cmd.Parameters.AddWithValue("@CSIDAck", CSIDAck)
            Cmd.Parameters.AddWithValue("@CSIDAckOn", CSIDAckOn)
            Cmd.Parameters.AddWithValue("@OSHI", OSHI)
            Cmd.Parameters.AddWithValue("@OSHIAck", OSHIAck)
            Cmd.Parameters.AddWithValue("@OSHIAckOn", OSHIAckOn)
            Cmd.Parameters.AddWithValue("@Sub", Sub1)
            Cmd.Parameters.AddWithValue("@SubAck", SubAck)
            Cmd.Parameters.AddWithValue("@SubAckOn", SubAckOn)
            Cmd.Parameters.AddWithValue("@TPH", TPH)
            Cmd.Parameters.AddWithValue("@TPHAck", TPHAck)
            Cmd.Parameters.AddWithValue("@TPHAckOn", TPHAckOn)
            Cmd.Parameters.AddWithValue("@CV", CV)
            Cmd.Parameters.AddWithValue("@CVAck", CVAck)
            Cmd.Parameters.AddWithValue("@CVAckOn", CVAckOn)
            Cmd.Parameters.AddWithValue("@FM", FM)
            Cmd.Parameters.AddWithValue("@FMAck", FMAck)
            Cmd.Parameters.AddWithValue("@FMAckOn", FMAckOn)
            Cmd.Parameters.AddWithValue("@FS", FS)
            Cmd.Parameters.AddWithValue("@FSAck", FSAck)
            Cmd.Parameters.AddWithValue("@FSAckOn", FSAckOn)
            Cmd.Parameters.AddWithValue("@QA", QA)
            Cmd.Parameters.AddWithValue("@QAAck", QAAck)
            Cmd.Parameters.AddWithValue("@QAAckOn", QAAckOn)
            Cmd.Parameters.AddWithValue("@Admin", Admin)
            Cmd.Parameters.AddWithValue("@AdminAck", AdminAck)
            Cmd.Parameters.AddWithValue("@AdminAckOn", AdminAckOn)
            Cmd.Parameters.AddWithValue("@Security", Security)
            Cmd.Parameters.AddWithValue("@SecurityAck", SecurityAck)
            Cmd.Parameters.AddWithValue("@SecurityAckOn", SecurityAckOn)
            Cmd.Parameters.AddWithValue("@IT", It)
            Cmd.Parameters.AddWithValue("@ITAck", ITAck)
            Cmd.Parameters.AddWithValue("@ITAckOn", ITAckOn)
            Cmd.Parameters.AddWithValue("@MD", Md)
            Cmd.Parameters.AddWithValue("@MDAck", MDAck)
            Cmd.Parameters.AddWithValue("@MDAckOn", MDAckOn)
            Cmd.Parameters.AddWithValue("@EA", Ea)
            Cmd.Parameters.AddWithValue("@EAAck", EAAck)
            Cmd.Parameters.AddWithValue("@EAAckOn", EAAckOn)
            Cmd.Parameters.AddWithValue("@SalesRemarks", SalesRemarks)
            Cmd.Parameters.AddWithValue("@ProductionRemarks", ProductionRemarks)
            Cmd.Parameters.AddWithValue("@QARemarks", QARemarks)
            Cmd.Parameters.AddWithValue("@AdminRemarks", AdminRemarks)
            Cmd.Parameters.AddWithValue("@ITRemarks", ITRemarks)
            Cmd.Parameters.AddWithValue("@TMRemarks", TMRemarks)
            Cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
            Cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn)

            Cmd.Parameters.AddWithValue("@AttendanceName2", AttendanceName2)
            Cmd.Parameters.AddWithValue("@AttendanceDesignation2", AttendanceDesignation2)

            Cmd.Parameters.AddWithValue("@AttendanceName3", AttendanceName3)
            Cmd.Parameters.AddWithValue("@AttendanceDesignation3", AttendanceDesignation3)

            Cmd.Parameters.AddWithValue("@RequestedBy", RequestedBy)
            Cmd.Parameters.AddWithValue("@RequestorEID", RequestorEID)
            Cmd.Parameters.AddWithValue("@Astatus", Astatus)
            Cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try

    End Function

    Public Shared Function SelectCVRefNo(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "CV_SelectRefNo"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function


    Public Shared Function SelectPendingCVForm(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "CV_SelectPendingCVForm"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectCVAccessRights(ByVal cnn As String, ByVal empid As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "CV_SelectCVAccessRights"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@empid", empid)

        Cmd.Connection = Con

        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function


    Public Shared Function SelectCVData(ByVal cnn As String, ByVal RefNo As Integer) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "CV_SelectCVData"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@RefNo", RefNo)

        Cmd.Connection = Con

        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectCVApprovedDetails(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "CV_SelectCVApprovedDetails"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function


    Public Shared Function InsertSMSLINK(ByVal cnn As String, ByVal CompanyID As String, ByVal Typ As String, ByVal No As String, ByVal Status As String, ByVal CBy As String, ByVal CDt As DateTime)

        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "Insert_SMS_LINK"
        Cmd.Connection = Con
        Cmd.Parameters.AddWithValue("@CompanyID", CompanyID)
        Cmd.Parameters.AddWithValue("@type_3", Typ)
        Cmd.Parameters.AddWithValue("@number_4", No)
        Cmd.Parameters.AddWithValue("@status_5", Status)
        Cmd.Parameters.AddWithValue("@CreatedBy_6", CBy)
        Cmd.Parameters.AddWithValue("@CDate_7", CDt)
        Cmd.ExecuteNonQuery()
    End Function

    '' customer visit #

    '' Video Conference Request
    Public Shared Function InsertVCRequest(ByVal ConStr As String, _
ByVal EmployeeId As String, _
ByVal EmployeeName As String, _
ByVal MeetingType As String, _
ByVal MeetingGroup As String, _
ByVal Meetingwith As String, _
ByVal Purpose As String, _
ByVal MeetingDate As DateTime, _
ByVal MeetingStartTime As DateTime, _
ByVal MeetingendTime As DateTime, _
ByVal TotalHours As String, _
ByVal CreatedOn As String, _
ByVal Department As String)
        Try

            Dim Con As New SqlConnection
            Con = New SqlConnection(ConStr)
            Con.Open()
            Dim Cmd As New SqlCommand
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "VC_InsertRequest"
            Cmd.Connection = Con

            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@EmployeeId", EmployeeId)
            Cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName)
            Cmd.Parameters.AddWithValue("@MeetingType", MeetingType)
            Cmd.Parameters.AddWithValue("@MeetingGroup", MeetingGroup)
            Cmd.Parameters.AddWithValue("@Meetingwith", Meetingwith)
            Cmd.Parameters.AddWithValue("@Purpose", Purpose)
            Cmd.Parameters.AddWithValue("@MeetingDate", MeetingDate)
            Cmd.Parameters.AddWithValue("@MeetingStarttime", MeetingStarttime)
            Cmd.Parameters.AddWithValue("@MeetingendTime", MeetingendTime)
            Cmd.Parameters.AddWithValue("@TotalHours", TotalHours)
            Cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn)
            Cmd.Parameters.AddWithValue("@Department", "MMSB")

            Cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Function

    Public Shared Function SelectAllVCDataByEID(ByVal cnn As String, ByVal EmployeeId As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Clear()

        Cmd.CommandText = "VC_SelectAllDataByEID"
        Cmd.Parameters.AddWithValue("@EmployeeID", EmployeeId)
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectAllVCData(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Clear()

        Cmd.CommandText = "VC_SelectAllData"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectVCScheduledData(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Clear()

        Cmd.CommandText = "VC_SelectAllScheduledData"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function


    Public Shared Function SelectVCRejectedData(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Clear()
        Cmd.CommandText = "VC_SelectAllRejectedData"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function UpdateVCRequest(ByVal ConStr As String, _
ByVal EmployeeId As String, _
ByVal Options As String, _
ByVal Refno As Integer)
        Try

            Dim Con As New SqlConnection
            Con = New SqlConnection(ConStr)
            Con.Open()
            Dim Cmd As New SqlCommand
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "VC_UpdateVCRequest"
            Cmd.Connection = Con

            Cmd.Parameters.Clear()
            Cmd.Parameters.AddWithValue("@refno", Refno)
            Cmd.Parameters.AddWithValue("@Aby", EmployeeId)
            Cmd.Parameters.AddWithValue("@Options", Options)

            Cmd.ExecuteNonQuery()

        Catch ex As Exception

        End Try
    End Function

    Public Shared Function SelectVCMaxId(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "VC_SelectMaxUid"
        Cmd.Parameters.Clear()

        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectAprrovedDataforTimeSlot(ByVal cnn As String, ByVal Dt1 As DateTime, ByVal Dt2 As DateTime) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "VC_SelectApprovedDataByDate"

        Cmd.Parameters.Clear()

        Cmd.Parameters.AddWithValue("@Dt1", Dt1)
        Cmd.Parameters.AddWithValue("@Dt2", Dt2)

        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectMeetingDetails(ByVal cnn As String, ByVal Dt1 As DateTime, ByVal Dt2 As DateTime) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Clear()

        Cmd.CommandText = "VC_SelectMeetingSchedule"
        Cmd.Parameters.AddWithValue("@Dt1", Dt1)
        Cmd.Parameters.AddWithValue("@Dt2", Dt2)

        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function
    '' Video Conference Request ##
    ' ## Substrate Casting Check Sheet

    Public Shared Function InsertSCastingDailyCheckSheet( _
 ByVal IssueHighlighted As String, _
 ByVal CDate1 As DateTime, _
 ByVal Department As String, _
 ByVal CTime As DateTime, _
 ByVal Section As String, _
 ByVal BZ11 As Double, _
 ByVal BZ12 As Double, _
 ByVal BZ13 As Double, _
 ByVal BZ14 As Double, _
 ByVal BZ15 As Double, _
 ByVal BZ16 As Double, _
 ByVal BZ21 As Double, _
 ByVal BZ22 As Double, _
 ByVal BZ23 As Double, _
 ByVal BZ24 As Double, _
 ByVal BZ25 As Double, _
 ByVal BZ26 As Double, _
 ByVal BZ31 As Double, _
 ByVal BZ32 As Double, _
 ByVal BZ33 As Double, _
 ByVal BZ34 As Double, _
 ByVal BZ35 As Double, _
 ByVal BZ36 As Double, _
 ByVal BZ41 As Double, _
 ByVal BZ42 As Double, _
 ByVal BZ43 As Double, _
 ByVal BZ44 As Double, _
 ByVal BZ45 As Double, _
 ByVal BZ46 As Double, _
 ByVal CZ11 As Double, _
 ByVal CZ12 As Double, _
 ByVal CZ13 As Double, _
 ByVal CZ14 As Double, _
 ByVal CZ15 As Double, _
 ByVal CZ16 As Double, _
 ByVal CZ21 As Double, _
 ByVal CZ22 As Double, _
 ByVal CZ23 As Double, _
 ByVal CZ24 As Double, _
 ByVal CZ25 As Double, _
 ByVal CZ26 As Double, _
 ByVal CZ31 As Double, _
 ByVal CZ32 As Double, _
 ByVal CZ33 As Double, _
 ByVal CZ34 As Double, _
 ByVal CZ35 As Double, _
 ByVal CZ36 As Double, _
 ByVal CZ41 As Double, _
 ByVal CZ42 As Double, _
 ByVal CZ43 As Double, _
 ByVal CZ44 As Double, _
 ByVal CZ45 As Double, _
 ByVal CZ46 As Double, _
 ByVal QZ11 As Double, _
 ByVal QZ12 As Double, _
 ByVal QZ13 As Double, _
 ByVal QZ14 As Double, _
 ByVal QZ15 As Double, _
 ByVal QZ16 As Double, _
 ByVal QZ21 As Double, _
 ByVal QZ22 As Double, _
 ByVal QZ23 As Double, _
 ByVal QZ24 As Double, _
 ByVal QZ25 As Double, _
 ByVal QZ26 As Double, _
 ByVal QZ31 As Double, _
 ByVal QZ32 As Double, _
 ByVal QZ33 As Double, _
 ByVal QZ34 As Double, _
 ByVal QZ35 As Double, _
 ByVal QZ36 As Double, _
 ByVal QZ41 As Double, _
 ByVal QZ42 As Double, _
 ByVal QZ43 As Double, _
 ByVal QZ44 As Double, _
 ByVal QZ45 As Double, _
 ByVal QZ46 As Double, _
 ByVal SZ11 As Double, _
 ByVal SZ12 As Double, _
 ByVal SZ13 As Double, _
 ByVal SZ14 As Double, _
 ByVal SZ15 As Double, _
 ByVal SZ16 As Double, _
 ByVal SZ21 As Double, _
 ByVal SZ22 As Double, _
 ByVal SZ23 As Double, _
 ByVal SZ24 As Double, _
 ByVal SZ25 As Double, _
 ByVal SZ26 As Double, _
 ByVal SZ31 As Double, _
 ByVal SZ32 As Double, _
 ByVal SZ33 As Double, _
 ByVal SZ34 As Double, _
 ByVal SZ35 As Double, _
 ByVal SZ36 As Double, _
 ByVal SZ41 As Double, _
 ByVal SZ42 As Double, _
 ByVal SZ43 As Double, _
 ByVal SZ44 As Double, _
 ByVal SZ45 As Double, _
 ByVal SZ46 As Double, _
 ByVal NZ11 As Double, _
 ByVal NZ12 As Double, _
 ByVal NZ13 As Double, _
 ByVal NZ14 As Double, _
 ByVal NZ15 As Double, _
 ByVal NZ16 As Double, _
 ByVal NZ21 As Double, _
 ByVal NZ22 As Double, _
 ByVal NZ23 As Double, _
 ByVal NZ24 As Double, _
 ByVal NZ25 As Double, _
 ByVal NZ26 As Double, _
 ByVal NZ31 As Double, _
 ByVal NZ32 As Double, _
 ByVal NZ33 As Double, _
 ByVal NZ34 As Double, _
 ByVal NZ35 As Double, _
 ByVal NZ36 As Double, _
 ByVal NZ41 As Double, _
 ByVal NZ42 As Double, _
 ByVal NZ43 As Double, _
 ByVal NZ44 As Double, _
 ByVal NZ45 As Double, _
 ByVal NZ46 As Double, _
 ByVal GZ11 As Double, _
 ByVal GZ12 As Double, _
 ByVal GZ13 As Double, _
 ByVal GZ14 As Double, _
 ByVal GZ15 As Double, _
 ByVal GZ16 As Double, _
 ByVal GZ21 As Double, _
 ByVal GZ22 As Double, _
 ByVal GZ23 As Double, _
 ByVal GZ24 As Double, _
 ByVal GZ25 As Double, _
 ByVal GZ26 As Double, _
 ByVal GZ31 As Double, _
 ByVal GZ32 As Double, _
 ByVal GZ33 As Double, _
 ByVal GZ34 As Double, _
 ByVal GZ35 As Double, _
 ByVal GZ36 As Double, _
 ByVal GZ41 As Double, _
 ByVal GZ42 As Double, _
 ByVal GZ43 As Double, _
 ByVal GZ44 As Double, _
 ByVal GZ45 As Double, _
 ByVal GZ46 As Double, _
 ByVal FZ11 As Double, _
 ByVal FZ12 As Double, _
 ByVal FZ13 As Double, _
 ByVal FZ14 As Double, _
 ByVal FZ15 As Double, _
 ByVal FZ16 As Double, _
 ByVal FZ21 As Double, _
 ByVal FZ22 As Double, _
 ByVal FZ23 As Double, _
 ByVal FZ24 As Double, _
 ByVal FZ25 As Double, _
 ByVal FZ26 As Double, _
 ByVal FZ31 As Double, _
 ByVal FZ32 As Double, _
 ByVal FZ33 As Double, _
 ByVal FZ34 As Double, _
 ByVal FZ35 As Double, _
 ByVal FZ36 As Double, _
 ByVal FZ41 As Double, _
 ByVal FZ42 As Double, _
 ByVal FZ43 As Double, _
 ByVal FZ44 As Double, _
 ByVal FZ45 As Double, _
 ByVal FZ46 As Double, _
 ByVal EZ11 As Double, _
 ByVal EZ12 As Double, _
 ByVal EZ13 As Double, _
 ByVal EZ14 As Double, _
 ByVal EZ15 As Double, _
 ByVal EZ16 As Double, _
 ByVal EZ21 As Double, _
 ByVal EZ22 As Double, _
 ByVal EZ23 As Double, _
 ByVal EZ24 As Double, _
 ByVal EZ25 As Double, _
 ByVal EZ26 As Double, _
 ByVal EZ31 As Double, _
 ByVal EZ32 As Double, _
 ByVal EZ33 As Double, _
 ByVal EZ34 As Double, _
 ByVal EZ35 As Double, _
 ByVal EZ36 As Double, _
 ByVal EZ41 As Double, _
 ByVal EZ42 As Double, _
 ByVal EZ43 As Double, _
 ByVal EZ44 As Double, _
 ByVal EZ45 As Double, _
 ByVal EZ46 As Double, _
 ByVal JZ11 As Double, _
 ByVal JZ12 As Double, _
 ByVal JZ13 As Double, _
 ByVal JZ14 As Double, _
 ByVal JZ15 As Double, _
 ByVal JZ16 As Double, _
 ByVal JZ21 As Double, _
 ByVal JZ22 As Double, _
 ByVal JZ23 As Double, _
 ByVal JZ24 As Double, _
 ByVal JZ25 As Double, _
 ByVal JZ26 As Double, _
 ByVal JZ31 As Double, _
 ByVal JZ32 As Double, _
 ByVal JZ33 As Double, _
 ByVal JZ34 As Double, _
 ByVal JZ35 As Double, _
 ByVal JZ36 As Double, _
 ByVal JZ41 As Double, _
 ByVal JZ42 As Double, _
 ByVal JZ43 As Double, _
 ByVal JZ44 As Double, _
 ByVal JZ45 As Double, _
 ByVal JZ46 As Double, _
 ByVal LZ11 As Double, _
 ByVal LZ12 As Double, _
 ByVal LZ13 As Double, _
 ByVal LZ14 As Double, _
 ByVal LZ15 As Double, _
 ByVal LZ16 As Double, _
 ByVal LZ21 As Double, _
 ByVal LZ22 As Double, _
 ByVal LZ23 As Double, _
 ByVal LZ24 As Double, _
 ByVal LZ25 As Double, _
 ByVal LZ26 As Double, _
 ByVal LZ31 As Double, _
 ByVal LZ32 As Double, _
 ByVal LZ33 As Double, _
 ByVal LZ34 As Double, _
 ByVal LZ35 As Double, _
 ByVal LZ36 As Double, _
 ByVal LZ41 As Double, _
 ByVal LZ42 As Double, _
 ByVal LZ43 As Double, _
 ByVal LZ44 As Double, _
 ByVal LZ45 As Double, _
 ByVal LZ46 As Double, _
 ByVal MZ11 As Double, _
 ByVal MZ12 As Double, _
 ByVal MZ13 As Double, _
 ByVal MZ14 As Double, _
 ByVal MZ15 As Double, _
 ByVal MZ16 As Double, _
 ByVal MZ21 As Double, _
 ByVal MZ22 As Double, _
 ByVal MZ23 As Double, _
 ByVal MZ24 As Double, _
 ByVal MZ25 As Double, _
 ByVal MZ26 As Double, _
 ByVal MZ31 As Double, _
 ByVal MZ32 As Double, _
 ByVal MZ33 As Double, _
 ByVal MZ34 As Double, _
 ByVal MZ35 As Double, _
 ByVal MZ36 As Double, _
 ByVal MZ41 As Double, _
 ByVal MZ42 As Double, _
 ByVal MZ43 As Double, _
 ByVal MZ44 As Double, _
 ByVal MZ45 As Double, _
 ByVal MZ46 As Double, _
 ByVal BSL As Double, _
 ByVal BCL As Double, _
 ByVal BCN As Double, _
 ByVal BSN As Double, _
 ByVal CSL As Double, _
 ByVal CCL As Double, _
 ByVal CCN As Double, _
 ByVal CSN As Double, _
 ByVal QSL As Double, _
 ByVal QCL As Double, _
 ByVal QCN As Double, _
 ByVal QSN As Double, _
 ByVal SSL As Double, _
 ByVal SCL As Double, _
 ByVal SCN As Double, _
 ByVal SSN As Double, _
 ByVal NSL As Double, _
 ByVal NCL As Double, _
 ByVal NCN As Double, _
 ByVal NSN As Double, _
 ByVal GSL As Double, _
 ByVal GCL As Double, _
 ByVal GCN As Double, _
 ByVal GSN As Double, _
 ByVal FSL As Double, _
 ByVal FCL As Double, _
 ByVal FCN As Double, _
 ByVal FSN As Double, _
 ByVal ESL As Double, _
 ByVal ECL As Double, _
 ByVal ECN As Double, _
 ByVal ESN As Double, _
 ByVal JSL As Double, _
 ByVal JCL As Double, _
 ByVal JCN As Double, _
 ByVal JSN As Double, _
 ByVal LSL As Double, _
 ByVal LCL As Double, _
 ByVal LCN As Double, _
 ByVal LSN As Double, _
 ByVal MSL As Double, _
 ByVal MCL As Double, _
 ByVal MCN As Double, _
 ByVal MSN As Double, _
 ByVal BREM As String, _
 ByVal CREM As String, _
 ByVal QREM As String, _
 ByVal SREM As String, _
 ByVal NREM As String, _
 ByVal GREM As String, _
 ByVal FREM As String, _
 ByVal EREM As String, _
 ByVal JREM As String, _
 ByVal LREM As String, _
 ByVal MREM As String, _
 ByVal BGM As Double, _
 ByVal BEPC As Double, _
 ByVal BGMREM As String, _
 ByVal CGM As Double, _
 ByVal CEPC As Double, _
 ByVal CGMREM As String, _
 ByVal QGM As Double, _
 ByVal QEPC As Double, _
 ByVal QGMREM As String, _
 ByVal SGM As Double, _
 ByVal SEPC As Double, _
 ByVal SGMREM As String, _
 ByVal NGM As Double, _
 ByVal NEPC As Double, _
 ByVal NGMREM As String, _
 ByVal GGM As Double, _
 ByVal GEPC As Double, _
 ByVal GGMREM As String, _
 ByVal FGM As Double, _
 ByVal FEPC As Double, _
 ByVal FGMREM As String, _
 ByVal EGM As Double, _
 ByVal EEPC As Double, _
 ByVal EGMREM As String, _
 ByVal JGM As Double, _
 ByVal JEPC As Double, _
 ByVal JGMREM As String, _
 ByVal LGM As Double, _
 ByVal LEPC As Double, _
 ByVal LGMREM As String, _
 ByVal MGM As Double, _
 ByVal MEPC As Double, _
 ByVal MGMREM As String, _
 ByVal BPNO1 As Double, _
 ByVal BPNO2 As Double, _
 ByVal BPNO3 As Double, _
 ByVal BPREM As String, _
 ByVal CPNO1 As Double, _
 ByVal CPNO2 As Double, _
 ByVal CPNO3 As Double, _
 ByVal CPREM As String, _
 ByVal QPNO1 As Double, _
 ByVal QPNO2 As Double, _
 ByVal QPNO3 As Double, _
 ByVal QPREM As String, _
 ByVal SPNO1 As Double, _
 ByVal SPNO2 As Double, _
 ByVal SPNO3 As Double, _
 ByVal SPREM As String, _
 ByVal NPNO1 As Double, _
 ByVal NPNO2 As Double, _
 ByVal NPNO3 As Double, _
 ByVal NPREM As String, _
 ByVal GPNO1 As Double, _
 ByVal GPNO2 As Double, _
 ByVal GPNO3 As Double, _
 ByVal GPREM As String, _
 ByVal FPNO1 As Double, _
 ByVal FPNO2 As Double, _
 ByVal FPNO3 As Double, _
 ByVal FPREM As String, _
 ByVal EPNO1 As Double, _
 ByVal EPNO2 As Double, _
 ByVal EPNO3 As Double, _
 ByVal EPREM As String, _
 ByVal JPNO1 As Double, _
 ByVal JPNO2 As Double, _
 ByVal JPNO3 As Double, _
 ByVal JPREM As String, _
 ByVal LPNO1 As Double, _
 ByVal LPNO2 As Double, _
 ByVal LPNO3 As Double, _
 ByVal LPREM As String, _
 ByVal MPNO1 As Double, _
 ByVal MPNO2 As Double, _
 ByVal MPNO3 As Double, _
 ByVal MPREM As String, _
 ByVal BPNT1 As Double, _
 ByVal BPNT2 As Double, _
 ByVal BPNT3 As Double, _
 ByVal BPNT4 As Double, _
 ByVal BPNT5 As Double, _
 ByVal EFBREM As String, _
 ByVal CPNT1 As Double, _
 ByVal CPNT2 As Double, _
 ByVal CPNT3 As Double, _
 ByVal CPNT4 As Double, _
 ByVal CPNT5 As Double, _
 ByVal EFCREM As String, _
 ByVal QPNT1 As Double, _
 ByVal QPNT2 As Double, _
 ByVal QPNT3 As Double, _
 ByVal QPNT4 As Double, _
 ByVal QPNT5 As Double, _
 ByVal EFQREM As String, _
 ByVal SPNT1 As Double, _
 ByVal SPNT2 As Double, _
 ByVal SPNT3 As Double, _
 ByVal SPNT4 As Double, _
 ByVal SPNT5 As Double, _
 ByVal EFSREM As String, _
 ByVal NPNT1 As Double, _
 ByVal NPNT2 As Double, _
 ByVal NPNT3 As Double, _
 ByVal NPNT4 As Double, _
 ByVal NPNT5 As Double, _
 ByVal EFNREM As String, _
 ByVal GPNT1 As Double, _
 ByVal GPNT2 As Double, _
 ByVal GPNT3 As Double, _
 ByVal GPNT4 As Double, _
 ByVal GPNT5 As Double, _
 ByVal EFGREM As String, _
 ByVal FPNT1 As Double, _
 ByVal FPNT2 As Double, _
 ByVal FPNT3 As Double, _
 ByVal FPNT4 As Double, _
 ByVal FPNT5 As Double, _
 ByVal EFFREM As String, _
 ByVal EPNT1 As Double, _
 ByVal EPNT2 As Double, _
 ByVal EPNT3 As Double, _
 ByVal EPNT4 As Double, _
 ByVal EPNT5 As Double, _
 ByVal EFEREM As String, _
 ByVal JPNT1 As Double, _
 ByVal JPNT2 As Double, _
 ByVal JPNT3 As Double, _
 ByVal JPNT4 As Double, _
 ByVal JPNT5 As Double, _
 ByVal EFJREM As String, _
 ByVal LPNT1 As Double, _
 ByVal LPNT2 As Double, _
 ByVal LPNT3 As Double, _
 ByVal LPNT4 As Double, _
 ByVal LPNT5 As Double, _
 ByVal EFLREM As String, _
 ByVal MPNT1 As Double, _
 ByVal MPNT2 As Double, _
 ByVal MPNT3 As Double, _
 ByVal MPNT4 As Double, _
 ByVal MPNT5 As Double, _
 ByVal EFMREM As String, _
 ByVal BBFPNT1 As Double, _
 ByVal BBFPNT2 As Double, _
 ByVal BBFPNT3 As Double, _
 ByVal BBFREM As String, _
 ByVal CBFPNT1 As Double, _
 ByVal CBFPNT2 As Double, _
 ByVal CBFPNT3 As Double, _
 ByVal CBFREM As String, _
 ByVal QBFPNT1 As Double, _
 ByVal QBFPNT2 As Double, _
 ByVal QBFPNT3 As Double, _
 ByVal QBFREM As String, _
 ByVal SBFPNT1 As Double, _
 ByVal SBFPNT2 As Double, _
 ByVal SBFPNT3 As Double, _
 ByVal SBFREM As String, _
 ByVal NBFPNT1 As Double, _
 ByVal NBFPNT2 As Double, _
 ByVal NBFPNT3 As Double, _
 ByVal NBFREM As String, _
 ByVal GBFPNT1 As Double, _
 ByVal GBFPNT2 As Double, _
 ByVal GBFPNT3 As Double, _
 ByVal GBFREM As String, _
 ByVal FBFPNT1 As Double, _
 ByVal FBFPNT2 As Double, _
 ByVal FBFPNT3 As Double, _
 ByVal FBFREM As String, _
 ByVal EBFPNT1 As Double, _
 ByVal EBFPNT2 As Double, _
 ByVal EBFPNT3 As Double, _
 ByVal EBFREM As String, _
 ByVal JBFPNT1 As Double, _
 ByVal JBFPNT2 As Double, _
 ByVal JBFPNT3 As Double, _
 ByVal JBFREM As String, _
 ByVal LBFPNT1 As Double, _
 ByVal LBFPNT2 As Double, _
 ByVal LBFPNT3 As Double, _
 ByVal LBFREM As String, _
 ByVal MBFPNT1 As Double, _
 ByVal MBFPNT2 As Double, _
 ByVal MBFPNT3 As Double, _
 ByVal MBFREM As String, _
 ByVal OverallRemarks As String, _
 ByVal CreatedBy As String, _
 ByVal CreatedOn As DateTime, _
 ByVal EmployeeName As String, _
 ByVal ModifiedBy As String, _
 ByVal ModifiedOn As DateTime, ByVal Cnn As String) As Boolean

        Try
            Dim Con As New SqlConnection
            Con = New SqlConnection(Cnn)
            Con.Open()
            Dim Cmd As New SqlCommand
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "SP_SDailyCastingCheckSheet"
            Cmd.Parameters.Clear()
            Cmd.Connection = Con
            Cmd.Parameters.AddWithValue("@IssueHighlighted", IssueHighlighted)
            Cmd.Parameters.AddWithValue("@CDate", CDate1)
            Cmd.Parameters.AddWithValue("@Department", Department)
            Cmd.Parameters.AddWithValue("@CTime", CTime)
            Cmd.Parameters.AddWithValue("@Section", Section)
            Cmd.Parameters.AddWithValue("@BZ11", BZ11)
            Cmd.Parameters.AddWithValue("@BZ12", BZ12)
            Cmd.Parameters.AddWithValue("@BZ13", BZ13)
            Cmd.Parameters.AddWithValue("@BZ14", BZ14)
            Cmd.Parameters.AddWithValue("@BZ15", BZ15)
            Cmd.Parameters.AddWithValue("@BZ16", BZ16)
            Cmd.Parameters.AddWithValue("@BZ21", BZ21)
            Cmd.Parameters.AddWithValue("@BZ22", BZ22)
            Cmd.Parameters.AddWithValue("@BZ23", BZ23)
            Cmd.Parameters.AddWithValue("@BZ24", BZ24)
            Cmd.Parameters.AddWithValue("@BZ25", BZ25)
            Cmd.Parameters.AddWithValue("@BZ26", BZ26)
            Cmd.Parameters.AddWithValue("@BZ31", BZ31)
            Cmd.Parameters.AddWithValue("@BZ32", BZ32)
            Cmd.Parameters.AddWithValue("@BZ33", BZ33)
            Cmd.Parameters.AddWithValue("@BZ34", BZ34)
            Cmd.Parameters.AddWithValue("@BZ35", BZ35)
            Cmd.Parameters.AddWithValue("@BZ36", BZ36)
            Cmd.Parameters.AddWithValue("@BZ41", BZ41)
            Cmd.Parameters.AddWithValue("@BZ42", BZ42)
            Cmd.Parameters.AddWithValue("@BZ43", BZ43)
            Cmd.Parameters.AddWithValue("@BZ44", BZ44)
            Cmd.Parameters.AddWithValue("@BZ45", BZ45)
            Cmd.Parameters.AddWithValue("@BZ46", BZ46)
            Cmd.Parameters.AddWithValue("@CZ11", CZ11)
            Cmd.Parameters.AddWithValue("@CZ12", CZ12)
            Cmd.Parameters.AddWithValue("@CZ13", CZ13)
            Cmd.Parameters.AddWithValue("@CZ14", CZ14)
            Cmd.Parameters.AddWithValue("@CZ15", CZ15)
            Cmd.Parameters.AddWithValue("@CZ16", CZ16)
            Cmd.Parameters.AddWithValue("@CZ21", CZ21)
            Cmd.Parameters.AddWithValue("@CZ22", CZ22)
            Cmd.Parameters.AddWithValue("@CZ23", CZ23)
            Cmd.Parameters.AddWithValue("@CZ24", CZ24)
            Cmd.Parameters.AddWithValue("@CZ25", CZ25)
            Cmd.Parameters.AddWithValue("@CZ26", CZ26)
            Cmd.Parameters.AddWithValue("@CZ31", CZ31)
            Cmd.Parameters.AddWithValue("@CZ32", CZ31)
            Cmd.Parameters.AddWithValue("@CZ33", CZ33)
            Cmd.Parameters.AddWithValue("@CZ34", CZ34)
            Cmd.Parameters.AddWithValue("@CZ35", CZ35)
            Cmd.Parameters.AddWithValue("@CZ36", CZ36)
            Cmd.Parameters.AddWithValue("@CZ41", CZ41)
            Cmd.Parameters.AddWithValue("@CZ42", CZ42)
            Cmd.Parameters.AddWithValue("@CZ43", CZ43)
            Cmd.Parameters.AddWithValue("@CZ44", CZ44)
            Cmd.Parameters.AddWithValue("@CZ45", CZ45)
            Cmd.Parameters.AddWithValue("@CZ46", CZ46)
            Cmd.Parameters.AddWithValue("@QZ11", QZ11)
            Cmd.Parameters.AddWithValue("@QZ12", QZ12)
            Cmd.Parameters.AddWithValue("@QZ13", QZ13)
            Cmd.Parameters.AddWithValue("@QZ14", QZ14)
            Cmd.Parameters.AddWithValue("@QZ15", QZ15)
            Cmd.Parameters.AddWithValue("@QZ16", QZ16)
            Cmd.Parameters.AddWithValue("@QZ21", QZ21)
            Cmd.Parameters.AddWithValue("@QZ22", QZ22)
            Cmd.Parameters.AddWithValue("@QZ23", QZ23)
            Cmd.Parameters.AddWithValue("@QZ24", QZ24)
            Cmd.Parameters.AddWithValue("@QZ25", QZ25)
            Cmd.Parameters.AddWithValue("@QZ26", QZ26)
            Cmd.Parameters.AddWithValue("@QZ31", QZ31)
            Cmd.Parameters.AddWithValue("@QZ32", QZ32)
            Cmd.Parameters.AddWithValue("@QZ33", QZ33)
            Cmd.Parameters.AddWithValue("@QZ34", QZ34)
            Cmd.Parameters.AddWithValue("@QZ35", QZ35)
            Cmd.Parameters.AddWithValue("@QZ36", QZ36)
            Cmd.Parameters.AddWithValue("@QZ41", QZ41)
            Cmd.Parameters.AddWithValue("@QZ42", QZ42)
            Cmd.Parameters.AddWithValue("@QZ43", QZ43)
            Cmd.Parameters.AddWithValue("@QZ44", QZ44)
            Cmd.Parameters.AddWithValue("@QZ45", QZ45)
            Cmd.Parameters.AddWithValue("@QZ46", QZ46)
            Cmd.Parameters.AddWithValue("@SZ11", SZ11)
            Cmd.Parameters.AddWithValue("@SZ12", SZ12)
            Cmd.Parameters.AddWithValue("@SZ13", SZ13)
            Cmd.Parameters.AddWithValue("@SZ14", SZ14)
            Cmd.Parameters.AddWithValue("@SZ15", SZ15)
            Cmd.Parameters.AddWithValue("@SZ16", SZ16)
            Cmd.Parameters.AddWithValue("@SZ21", SZ21)
            Cmd.Parameters.AddWithValue("@SZ22", SZ22)
            Cmd.Parameters.AddWithValue("@SZ23", SZ23)
            Cmd.Parameters.AddWithValue("@SZ24", SZ24)
            Cmd.Parameters.AddWithValue("@SZ25", SZ25)
            Cmd.Parameters.AddWithValue("@SZ26", SZ26)
            Cmd.Parameters.AddWithValue("@SZ31", SZ31)
            Cmd.Parameters.AddWithValue("@SZ32", SZ32)
            Cmd.Parameters.AddWithValue("@SZ33", SZ33)
            Cmd.Parameters.AddWithValue("@SZ34", SZ34)
            Cmd.Parameters.AddWithValue("@SZ35", SZ35)
            Cmd.Parameters.AddWithValue("@SZ36", SZ36)
            Cmd.Parameters.AddWithValue("@SZ41", SZ41)
            Cmd.Parameters.AddWithValue("@SZ42", SZ42)
            Cmd.Parameters.AddWithValue("@SZ43", SZ43)
            Cmd.Parameters.AddWithValue("@SZ44", SZ44)
            Cmd.Parameters.AddWithValue("@SZ45", SZ45)
            Cmd.Parameters.AddWithValue("@SZ46", SZ46)
            Cmd.Parameters.AddWithValue("@NZ11", NZ11)
            Cmd.Parameters.AddWithValue("@NZ12", NZ12)
            Cmd.Parameters.AddWithValue("@NZ13", NZ13)
            Cmd.Parameters.AddWithValue("@NZ14", NZ14)
            Cmd.Parameters.AddWithValue("@NZ15", NZ15)
            Cmd.Parameters.AddWithValue("@NZ16", NZ16)
            Cmd.Parameters.AddWithValue("@NZ21", NZ21)
            Cmd.Parameters.AddWithValue("@NZ22", NZ22)
            Cmd.Parameters.AddWithValue("@NZ23", NZ23)
            Cmd.Parameters.AddWithValue("@NZ24", NZ24)
            Cmd.Parameters.AddWithValue("@NZ25", NZ25)
            Cmd.Parameters.AddWithValue("@NZ26", NZ26)
            Cmd.Parameters.AddWithValue("@NZ31", NZ31)
            Cmd.Parameters.AddWithValue("@NZ32", NZ32)
            Cmd.Parameters.AddWithValue("@NZ33", NZ33)
            Cmd.Parameters.AddWithValue("@NZ34", NZ34)
            Cmd.Parameters.AddWithValue("@NZ35", NZ35)
            Cmd.Parameters.AddWithValue("@NZ36", NZ36)
            Cmd.Parameters.AddWithValue("@NZ41", NZ41)
            Cmd.Parameters.AddWithValue("@NZ42", NZ42)
            Cmd.Parameters.AddWithValue("@NZ43", NZ43)
            Cmd.Parameters.AddWithValue("@NZ44", NZ44)
            Cmd.Parameters.AddWithValue("@NZ45", NZ45)
            Cmd.Parameters.AddWithValue("@NZ46", NZ46)


            Cmd.Parameters.AddWithValue("@GZ11", GZ11)
            Cmd.Parameters.AddWithValue("@GZ12", GZ12)
            Cmd.Parameters.AddWithValue("@GZ13", GZ13)
            Cmd.Parameters.AddWithValue("@GZ14", GZ14)
            Cmd.Parameters.AddWithValue("@GZ15", GZ15)
            Cmd.Parameters.AddWithValue("@GZ16", GZ16)
            Cmd.Parameters.AddWithValue("@GZ21", GZ21)
            Cmd.Parameters.AddWithValue("@GZ22", GZ22)
            Cmd.Parameters.AddWithValue("@GZ23", GZ23)
            Cmd.Parameters.AddWithValue("@GZ24", GZ24)
            Cmd.Parameters.AddWithValue("@GZ25", GZ25)
            Cmd.Parameters.AddWithValue("@GZ26", GZ26)
            Cmd.Parameters.AddWithValue("@GZ31", GZ31)
            Cmd.Parameters.AddWithValue("@GZ32", GZ32)
            Cmd.Parameters.AddWithValue("@GZ33", GZ33)
            Cmd.Parameters.AddWithValue("@GZ34", GZ34)
            Cmd.Parameters.AddWithValue("@GZ35", GZ35)
            Cmd.Parameters.AddWithValue("@GZ36", GZ36)
            Cmd.Parameters.AddWithValue("@GZ41", GZ41)
            Cmd.Parameters.AddWithValue("@GZ42", GZ42)
            Cmd.Parameters.AddWithValue("@GZ43", GZ43)
            Cmd.Parameters.AddWithValue("@GZ44", GZ44)
            Cmd.Parameters.AddWithValue("@GZ45", GZ45)
            Cmd.Parameters.AddWithValue("@GZ46", GZ46)


            Cmd.Parameters.AddWithValue("@FZ11", FZ11)
            Cmd.Parameters.AddWithValue("@FZ12", FZ12)
            Cmd.Parameters.AddWithValue("@FZ13", FZ13)
            Cmd.Parameters.AddWithValue("@FZ14", FZ14)
            Cmd.Parameters.AddWithValue("@FZ15", FZ15)
            Cmd.Parameters.AddWithValue("@FZ16", FZ16)
            Cmd.Parameters.AddWithValue("@FZ21", FZ21)
            Cmd.Parameters.AddWithValue("@FZ22", FZ22)
            Cmd.Parameters.AddWithValue("@FZ23", FZ23)
            Cmd.Parameters.AddWithValue("@FZ24", FZ24)
            Cmd.Parameters.AddWithValue("@FZ25", FZ25)
            Cmd.Parameters.AddWithValue("@FZ26", FZ26)
            Cmd.Parameters.AddWithValue("@FZ31", FZ31)
            Cmd.Parameters.AddWithValue("@FZ32", FZ32)
            Cmd.Parameters.AddWithValue("@FZ33", FZ33)
            Cmd.Parameters.AddWithValue("@FZ34", FZ34)
            Cmd.Parameters.AddWithValue("@FZ35", FZ35)
            Cmd.Parameters.AddWithValue("@FZ36", FZ36)
            Cmd.Parameters.AddWithValue("@FZ41", FZ41)
            Cmd.Parameters.AddWithValue("@FZ42", FZ42)
            Cmd.Parameters.AddWithValue("@FZ43", FZ43)
            Cmd.Parameters.AddWithValue("@FZ44", FZ44)
            Cmd.Parameters.AddWithValue("@FZ45", FZ45)
            Cmd.Parameters.AddWithValue("@FZ46", FZ46)

            Cmd.Parameters.AddWithValue("@EZ11", EZ11)
            Cmd.Parameters.AddWithValue("@EZ12", EZ12)
            Cmd.Parameters.AddWithValue("@EZ13", EZ13)
            Cmd.Parameters.AddWithValue("@EZ14", EZ14)
            Cmd.Parameters.AddWithValue("@EZ15", EZ15)
            Cmd.Parameters.AddWithValue("@EZ16", EZ16)
            Cmd.Parameters.AddWithValue("@EZ21", EZ21)
            Cmd.Parameters.AddWithValue("@EZ22", EZ22)
            Cmd.Parameters.AddWithValue("@EZ23", EZ23)
            Cmd.Parameters.AddWithValue("@EZ24", EZ24)
            Cmd.Parameters.AddWithValue("@EZ25", EZ25)
            Cmd.Parameters.AddWithValue("@EZ26", EZ26)
            Cmd.Parameters.AddWithValue("@EZ31", EZ31)
            Cmd.Parameters.AddWithValue("@EZ32", EZ32)
            Cmd.Parameters.AddWithValue("@EZ33", EZ33)
            Cmd.Parameters.AddWithValue("@EZ34", EZ34)
            Cmd.Parameters.AddWithValue("@EZ35", EZ35)
            Cmd.Parameters.AddWithValue("@EZ36", EZ36)
            Cmd.Parameters.AddWithValue("@EZ41", EZ41)
            Cmd.Parameters.AddWithValue("@EZ42", EZ42)
            Cmd.Parameters.AddWithValue("@EZ43", EZ43)
            Cmd.Parameters.AddWithValue("@EZ44", EZ44)
            Cmd.Parameters.AddWithValue("@EZ45", EZ45)
            Cmd.Parameters.AddWithValue("@EZ46", EZ46)

            Cmd.Parameters.AddWithValue("@JZ11", JZ11)
            Cmd.Parameters.AddWithValue("@JZ12", JZ12)
            Cmd.Parameters.AddWithValue("@JZ13", JZ13)
            Cmd.Parameters.AddWithValue("@JZ14", JZ14)
            Cmd.Parameters.AddWithValue("@JZ15", JZ15)
            Cmd.Parameters.AddWithValue("@JZ16", JZ16)
            Cmd.Parameters.AddWithValue("@JZ21", JZ21)
            Cmd.Parameters.AddWithValue("@JZ22", JZ22)
            Cmd.Parameters.AddWithValue("@JZ23", JZ23)
            Cmd.Parameters.AddWithValue("@JZ24", JZ24)
            Cmd.Parameters.AddWithValue("@JZ25", JZ25)
            Cmd.Parameters.AddWithValue("@JZ26", JZ26)
            Cmd.Parameters.AddWithValue("@JZ31", JZ31)
            Cmd.Parameters.AddWithValue("@JZ32", JZ32)
            Cmd.Parameters.AddWithValue("@JZ33", JZ33)
            Cmd.Parameters.AddWithValue("@JZ34", JZ34)
            Cmd.Parameters.AddWithValue("@JZ35", JZ35)
            Cmd.Parameters.AddWithValue("@JZ36", JZ36)
            Cmd.Parameters.AddWithValue("@JZ41", JZ41)
            Cmd.Parameters.AddWithValue("@JZ42", JZ42)
            Cmd.Parameters.AddWithValue("@JZ43", JZ43)
            Cmd.Parameters.AddWithValue("@JZ44", JZ44)
            Cmd.Parameters.AddWithValue("@JZ45", JZ45)
            Cmd.Parameters.AddWithValue("@JZ46", JZ46)


            Cmd.Parameters.AddWithValue("@LZ11", LZ11)
            Cmd.Parameters.AddWithValue("@LZ12", LZ12)
            Cmd.Parameters.AddWithValue("@LZ13", LZ13)
            Cmd.Parameters.AddWithValue("@LZ14", LZ14)
            Cmd.Parameters.AddWithValue("@LZ15", LZ15)
            Cmd.Parameters.AddWithValue("@LZ16", LZ16)
            Cmd.Parameters.AddWithValue("@LZ21", LZ21)
            Cmd.Parameters.AddWithValue("@LZ22", LZ22)
            Cmd.Parameters.AddWithValue("@LZ23", LZ23)
            Cmd.Parameters.AddWithValue("@LZ24", LZ24)
            Cmd.Parameters.AddWithValue("@LZ25", LZ25)
            Cmd.Parameters.AddWithValue("@LZ26", LZ26)
            Cmd.Parameters.AddWithValue("@LZ31", LZ31)
            Cmd.Parameters.AddWithValue("@LZ32", LZ32)
            Cmd.Parameters.AddWithValue("@LZ33", LZ33)
            Cmd.Parameters.AddWithValue("@LZ34", LZ34)
            Cmd.Parameters.AddWithValue("@LZ35", LZ35)
            Cmd.Parameters.AddWithValue("@LZ36", LZ36)
            Cmd.Parameters.AddWithValue("@LZ41", LZ41)
            Cmd.Parameters.AddWithValue("@LZ42", LZ42)
            Cmd.Parameters.AddWithValue("@LZ43", LZ43)
            Cmd.Parameters.AddWithValue("@LZ44", LZ44)
            Cmd.Parameters.AddWithValue("@LZ45", LZ45)
            Cmd.Parameters.AddWithValue("@LZ46", LZ46)


            Cmd.Parameters.AddWithValue("@MZ11", MZ11)
            Cmd.Parameters.AddWithValue("@MZ12", MZ12)
            Cmd.Parameters.AddWithValue("@MZ13", MZ13)
            Cmd.Parameters.AddWithValue("@MZ14", MZ14)
            Cmd.Parameters.AddWithValue("@MZ15", MZ15)
            Cmd.Parameters.AddWithValue("@MZ16", MZ16)
            Cmd.Parameters.AddWithValue("@MZ21", MZ21)
            Cmd.Parameters.AddWithValue("@MZ22", MZ22)
            Cmd.Parameters.AddWithValue("@MZ23", MZ23)
            Cmd.Parameters.AddWithValue("@MZ24", MZ24)
            Cmd.Parameters.AddWithValue("@MZ25", MZ25)
            Cmd.Parameters.AddWithValue("@MZ26", MZ26)
            Cmd.Parameters.AddWithValue("@MZ31", MZ31)
            Cmd.Parameters.AddWithValue("@MZ32", MZ32)
            Cmd.Parameters.AddWithValue("@MZ33", MZ33)
            Cmd.Parameters.AddWithValue("@MZ34", MZ34)
            Cmd.Parameters.AddWithValue("@MZ35", MZ35)
            Cmd.Parameters.AddWithValue("@MZ36", MZ36)
            Cmd.Parameters.AddWithValue("@MZ41", MZ41)
            Cmd.Parameters.AddWithValue("@MZ42", MZ42)
            Cmd.Parameters.AddWithValue("@MZ43", MZ43)
            Cmd.Parameters.AddWithValue("@MZ44", MZ44)
            Cmd.Parameters.AddWithValue("@MZ45", MZ45)
            Cmd.Parameters.AddWithValue("@MZ46", MZ46)


            Cmd.Parameters.AddWithValue("@BSL", BSL)
            Cmd.Parameters.AddWithValue("@BCL", BCL)
            Cmd.Parameters.AddWithValue("@BCN", BCN)
            Cmd.Parameters.AddWithValue("@BSN", BSN)
            Cmd.Parameters.AddWithValue("@CSL", CSL)
            Cmd.Parameters.AddWithValue("@CCL", CCL)
            Cmd.Parameters.AddWithValue("@CCN", CCN)
            Cmd.Parameters.AddWithValue("@CSN", CSN)
            Cmd.Parameters.AddWithValue("@QSL", QSL)
            Cmd.Parameters.AddWithValue("@QCL", QCL)
            Cmd.Parameters.AddWithValue("@QCN", QCN)
            Cmd.Parameters.AddWithValue("@QSN", QSN)
            Cmd.Parameters.AddWithValue("@SSL", SSL)
            Cmd.Parameters.AddWithValue("@SCL", SCL)
            Cmd.Parameters.AddWithValue("@SCN", SCN)
            Cmd.Parameters.AddWithValue("@SSN", SSN)
            Cmd.Parameters.AddWithValue("@NSL", NSL)
            Cmd.Parameters.AddWithValue("@NCL", NCL)
            Cmd.Parameters.AddWithValue("@NCN", NCN)
            Cmd.Parameters.AddWithValue("@NSN", NSN)

            Cmd.Parameters.AddWithValue("@GSL", GSL)
            Cmd.Parameters.AddWithValue("@GCL", GCL)
            Cmd.Parameters.AddWithValue("@GCN", GCN)
            Cmd.Parameters.AddWithValue("@GSN", GSN)

            Cmd.Parameters.AddWithValue("@FSL", FSL)
            Cmd.Parameters.AddWithValue("@FCL", FCL)
            Cmd.Parameters.AddWithValue("@FCN", FCN)
            Cmd.Parameters.AddWithValue("@FSN", FSN)

            Cmd.Parameters.AddWithValue("@ESL", ESL)
            Cmd.Parameters.AddWithValue("@ECL", ECL)
            Cmd.Parameters.AddWithValue("@ECN", ECN)
            Cmd.Parameters.AddWithValue("@ESN", ESN)

            Cmd.Parameters.AddWithValue("@JSL", JSL)
            Cmd.Parameters.AddWithValue("@JCL", JCL)
            Cmd.Parameters.AddWithValue("@JCN", JCN)
            Cmd.Parameters.AddWithValue("@JSN", JSN)

            Cmd.Parameters.AddWithValue("@LSL", LSL)
            Cmd.Parameters.AddWithValue("@LCL", LCL)
            Cmd.Parameters.AddWithValue("@LCN", LCN)
            Cmd.Parameters.AddWithValue("@LSN", LSN)

            Cmd.Parameters.AddWithValue("@MSL", MSL)
            Cmd.Parameters.AddWithValue("@MCL", MCL)
            Cmd.Parameters.AddWithValue("@MCN", MCN)
            Cmd.Parameters.AddWithValue("@MSN", MSN)

            Cmd.Parameters.AddWithValue("@BREM", BREM)
            Cmd.Parameters.AddWithValue("@CREM", CREM)
            Cmd.Parameters.AddWithValue("@QREM", QREM)
            Cmd.Parameters.AddWithValue("@SREM", SREM)
            Cmd.Parameters.AddWithValue("@NREM", NREM)

            Cmd.Parameters.AddWithValue("@GREM", GREM)
            Cmd.Parameters.AddWithValue("@FREM", FREM)
            Cmd.Parameters.AddWithValue("@EREM", EREM)
            Cmd.Parameters.AddWithValue("@JREM", JREM)
            Cmd.Parameters.AddWithValue("@LREM", LREM)
            Cmd.Parameters.AddWithValue("@MREM", MREM)

            Cmd.Parameters.AddWithValue("@BGM", BGM)
            Cmd.Parameters.AddWithValue("@BEPC", BEPC)
            Cmd.Parameters.AddWithValue("@BGMREM", BGMREM)
            Cmd.Parameters.AddWithValue("@CGM", CGM)
            Cmd.Parameters.AddWithValue("@CEPC", CEPC)
            Cmd.Parameters.AddWithValue("@CGMREM", CGMREM)
            Cmd.Parameters.AddWithValue("@QGM", QGM)
            Cmd.Parameters.AddWithValue("@QEPC", QEPC)
            Cmd.Parameters.AddWithValue("@QGMREM", QGMREM)
            Cmd.Parameters.AddWithValue("@SGM", SGM)
            Cmd.Parameters.AddWithValue("@SEPC", SEPC)
            Cmd.Parameters.AddWithValue("@SGMREM", SGMREM)
            Cmd.Parameters.AddWithValue("@NGM", NGM)
            Cmd.Parameters.AddWithValue("@NEPC", NEPC)
            Cmd.Parameters.AddWithValue("@NGMREM", NGMREM)

            Cmd.Parameters.AddWithValue("@GGM", GGM)
            Cmd.Parameters.AddWithValue("@GEPC", GEPC)
            Cmd.Parameters.AddWithValue("@GGMREM", GGMREM)

            Cmd.Parameters.AddWithValue("@FGM", FGM)
            Cmd.Parameters.AddWithValue("@FEPC", FEPC)
            Cmd.Parameters.AddWithValue("@FGMREM", FGMREM)

            Cmd.Parameters.AddWithValue("@EGM", EGM)
            Cmd.Parameters.AddWithValue("@EEPC", EEPC)
            Cmd.Parameters.AddWithValue("@EGMREM", EGMREM)

            Cmd.Parameters.AddWithValue("@JGM", JGM)
            Cmd.Parameters.AddWithValue("@JEPC", JEPC)
            Cmd.Parameters.AddWithValue("@JGMREM", JGMREM)

            Cmd.Parameters.AddWithValue("@LGM", LGM)
            Cmd.Parameters.AddWithValue("@LEPC", LEPC)
            Cmd.Parameters.AddWithValue("@LGMREM", LGMREM)

            Cmd.Parameters.AddWithValue("@MGM", MGM)
            Cmd.Parameters.AddWithValue("@MEPC", MEPC)
            Cmd.Parameters.AddWithValue("@MGMREM", MGMREM)

            Cmd.Parameters.AddWithValue("@BPNO1", BPNO1)
            Cmd.Parameters.AddWithValue("@BPNO2", BPNO2)
            Cmd.Parameters.AddWithValue("@BPNO3", BPNO3)
            Cmd.Parameters.AddWithValue("@BPREM", BPREM)
            Cmd.Parameters.AddWithValue("@CPNO1", CPNO1)
            Cmd.Parameters.AddWithValue("@CPNO2", CPNO2)
            Cmd.Parameters.AddWithValue("@CPNO3", CPNO3)
            Cmd.Parameters.AddWithValue("@CPREM", CPREM)
            Cmd.Parameters.AddWithValue("@QPNO1", QPNO1)
            Cmd.Parameters.AddWithValue("@QPNO2", QPNO2)
            Cmd.Parameters.AddWithValue("@QPNO3", QPNO3)
            Cmd.Parameters.AddWithValue("@QPREM", QPREM)
            Cmd.Parameters.AddWithValue("@SPNO1", SPNO1)
            Cmd.Parameters.AddWithValue("@SPNO2", SPNO2)
            Cmd.Parameters.AddWithValue("@SPNO3", SPNO3)
            Cmd.Parameters.AddWithValue("@SPREM", SPREM)
            Cmd.Parameters.AddWithValue("@NPNO1", NPNO1)
            Cmd.Parameters.AddWithValue("@NPNO2", NPNO2)
            Cmd.Parameters.AddWithValue("@NPNO3", NPNO3)
            Cmd.Parameters.AddWithValue("@NPREM", NPREM)

            Cmd.Parameters.AddWithValue("@GPNO1", GPNO1)
            Cmd.Parameters.AddWithValue("@GPNO2", GPNO2)
            Cmd.Parameters.AddWithValue("@GPNO3", GPNO3)
            Cmd.Parameters.AddWithValue("@GPREM", GPREM)

            Cmd.Parameters.AddWithValue("@FPNO1", FPNO1)
            Cmd.Parameters.AddWithValue("@FPNO2", FPNO2)
            Cmd.Parameters.AddWithValue("@FPNO3", FPNO3)
            Cmd.Parameters.AddWithValue("@FPREM", FPREM)

            Cmd.Parameters.AddWithValue("@EPNO1", EPNO1)
            Cmd.Parameters.AddWithValue("@EPNO2", EPNO2)
            Cmd.Parameters.AddWithValue("@EPNO3", EPNO3)
            Cmd.Parameters.AddWithValue("@EPREM", EPREM)

            Cmd.Parameters.AddWithValue("@JPNO1", JPNO1)
            Cmd.Parameters.AddWithValue("@JPNO2", JPNO2)
            Cmd.Parameters.AddWithValue("@JPNO3", JPNO3)
            Cmd.Parameters.AddWithValue("@JPREM", JPREM)

            Cmd.Parameters.AddWithValue("@LPNO1", LPNO1)
            Cmd.Parameters.AddWithValue("@LPNO2", LPNO2)
            Cmd.Parameters.AddWithValue("@LPNO3", LPNO3)
            Cmd.Parameters.AddWithValue("@LPREM", LPREM)

            Cmd.Parameters.AddWithValue("@MPNO1", MPNO1)
            Cmd.Parameters.AddWithValue("@MPNO2", MPNO2)
            Cmd.Parameters.AddWithValue("@MPNO3", MPNO3)
            Cmd.Parameters.AddWithValue("@MPREM", MPREM)

            Cmd.Parameters.AddWithValue("@BPNT1", BPNT1)
            Cmd.Parameters.AddWithValue("@BPNT2", BPNT2)
            Cmd.Parameters.AddWithValue("@BPNT3", BPNT3)
            Cmd.Parameters.AddWithValue("@BPNT4", BPNT4)
            Cmd.Parameters.AddWithValue("@BPNT5", BPNT5)
            Cmd.Parameters.AddWithValue("@EFBREM", EFBREM)
            Cmd.Parameters.AddWithValue("@CPNT1", CPNT1)
            Cmd.Parameters.AddWithValue("@CPNT2", CPNT2)
            Cmd.Parameters.AddWithValue("@CPNT3", CPNT3)
            Cmd.Parameters.AddWithValue("@CPNT4", CPNT4)
            Cmd.Parameters.AddWithValue("@CPNT5", CPNT5)
            Cmd.Parameters.AddWithValue("@EFCREM", EFCREM)
            Cmd.Parameters.AddWithValue("@QPNT1", QPNT1)
            Cmd.Parameters.AddWithValue("@QPNT2", QPNT2)
            Cmd.Parameters.AddWithValue("@QPNT3", QPNT3)
            Cmd.Parameters.AddWithValue("@QPNT4", QPNT4)
            Cmd.Parameters.AddWithValue("@QPNT5", QPNT5)
            Cmd.Parameters.AddWithValue("@EFQREM", EFQREM)
            Cmd.Parameters.AddWithValue("@SPNT1", SPNT1)
            Cmd.Parameters.AddWithValue("@SPNT2", SPNT2)
            Cmd.Parameters.AddWithValue("@SPNT3", SPNT3)
            Cmd.Parameters.AddWithValue("@SPNT4", SPNT4)
            Cmd.Parameters.AddWithValue("@SPNT5", SPNT5)
            Cmd.Parameters.AddWithValue("@EFSREM", EFSREM)
            Cmd.Parameters.AddWithValue("@NPNT1", NPNT1)
            Cmd.Parameters.AddWithValue("@NPNT2", NPNT2)
            Cmd.Parameters.AddWithValue("@NPNT3", NPNT3)
            Cmd.Parameters.AddWithValue("@NPNT4", NPNT4)
            Cmd.Parameters.AddWithValue("@NPNT5", NPNT5)
            Cmd.Parameters.AddWithValue("@EFNREM", EFNREM)

            Cmd.Parameters.AddWithValue("@GPNT1", GPNT1)
            Cmd.Parameters.AddWithValue("@GPNT2", GPNT2)
            Cmd.Parameters.AddWithValue("@GPNT3", GPNT3)
            Cmd.Parameters.AddWithValue("@GPNT4", GPNT4)
            Cmd.Parameters.AddWithValue("@GPNT5", GPNT5)
            Cmd.Parameters.AddWithValue("@EFGREM", EFGREM)

            Cmd.Parameters.AddWithValue("@FPNT1", FPNT1)
            Cmd.Parameters.AddWithValue("@FPNT2", FPNT2)
            Cmd.Parameters.AddWithValue("@FPNT3", FPNT3)
            Cmd.Parameters.AddWithValue("@FPNT4", FPNT4)
            Cmd.Parameters.AddWithValue("@FPNT5", FPNT5)
            Cmd.Parameters.AddWithValue("@EFFREM", EFFREM)

            Cmd.Parameters.AddWithValue("@EPNT1", EPNT1)
            Cmd.Parameters.AddWithValue("@EPNT2", EPNT2)
            Cmd.Parameters.AddWithValue("@EPNT3", EPNT3)
            Cmd.Parameters.AddWithValue("@EPNT4", EPNT4)
            Cmd.Parameters.AddWithValue("@EPNT5", EPNT5)
            Cmd.Parameters.AddWithValue("@EFEREM", EFEREM)


            Cmd.Parameters.AddWithValue("@JPNT1", JPNT1)
            Cmd.Parameters.AddWithValue("@JPNT2", JPNT2)
            Cmd.Parameters.AddWithValue("@JPNT3", JPNT3)
            Cmd.Parameters.AddWithValue("@JPNT4", JPNT4)
            Cmd.Parameters.AddWithValue("@JPNT5", JPNT5)
            Cmd.Parameters.AddWithValue("@EFJREM", EFJREM)

            Cmd.Parameters.AddWithValue("@LPNT1", LPNT1)
            Cmd.Parameters.AddWithValue("@LPNT2", LPNT2)
            Cmd.Parameters.AddWithValue("@LPNT3", LPNT3)
            Cmd.Parameters.AddWithValue("@LPNT4", LPNT4)
            Cmd.Parameters.AddWithValue("@LPNT5", LPNT5)
            Cmd.Parameters.AddWithValue("@EFLREM", EFLREM)

            Cmd.Parameters.AddWithValue("@MPNT1", MPNT1)
            Cmd.Parameters.AddWithValue("@MPNT2", MPNT2)
            Cmd.Parameters.AddWithValue("@MPNT3", MPNT3)
            Cmd.Parameters.AddWithValue("@MPNT4", MPNT4)
            Cmd.Parameters.AddWithValue("@MPNT5", MPNT5)
            Cmd.Parameters.AddWithValue("@EFMREM", EFMREM)

            Cmd.Parameters.AddWithValue("@BBFPNT1", BBFPNT1)
            Cmd.Parameters.AddWithValue("@BBFPNT2", BBFPNT2)
            Cmd.Parameters.AddWithValue("@BBFPNT3", BBFPNT3)
            Cmd.Parameters.AddWithValue("@BBFREM", BBFREM)
            Cmd.Parameters.AddWithValue("@CBFPNT1", CBFPNT1)
            Cmd.Parameters.AddWithValue("@CBFPNT2", CBFPNT2)
            Cmd.Parameters.AddWithValue("@CBFPNT3", CBFPNT3)
            Cmd.Parameters.AddWithValue("@CBFREM", CBFREM)
            Cmd.Parameters.AddWithValue("@QBFPNT1", QBFPNT1)
            Cmd.Parameters.AddWithValue("@QBFPNT2", QBFPNT2)
            Cmd.Parameters.AddWithValue("@QBFPNT3", QBFPNT3)
            Cmd.Parameters.AddWithValue("@QBFREM", QBFREM)
            Cmd.Parameters.AddWithValue("@SBFPNT1", SBFPNT1)
            Cmd.Parameters.AddWithValue("@SBFPNT2", SBFPNT2)
            Cmd.Parameters.AddWithValue("@SBFPNT3", SBFPNT3)
            Cmd.Parameters.AddWithValue("@SBFREM", SBFREM)
            Cmd.Parameters.AddWithValue("@NBFPNT1", NBFPNT1)
            Cmd.Parameters.AddWithValue("@NBFPNT2", NBFPNT2)
            Cmd.Parameters.AddWithValue("@NBFPNT3", NBFPNT3)
            Cmd.Parameters.AddWithValue("@NBFREM", NBFREM)

            Cmd.Parameters.AddWithValue("@GBFPNT1", GBFPNT1)
            Cmd.Parameters.AddWithValue("@GBFPNT2", GBFPNT2)
            Cmd.Parameters.AddWithValue("@GBFPNT3", GBFPNT3)
            Cmd.Parameters.AddWithValue("@GBFREM", GBFREM)

            Cmd.Parameters.AddWithValue("@FBFPNT1", FBFPNT1)
            Cmd.Parameters.AddWithValue("@FBFPNT2", FBFPNT2)
            Cmd.Parameters.AddWithValue("@FBFPNT3", FBFPNT3)
            Cmd.Parameters.AddWithValue("@FBFREM", FBFREM)

            Cmd.Parameters.AddWithValue("@EBFPNT1", EBFPNT1)
            Cmd.Parameters.AddWithValue("@EBFPNT2", EBFPNT2)
            Cmd.Parameters.AddWithValue("@EBFPNT3", EBFPNT3)
            Cmd.Parameters.AddWithValue("@EBFREM", EBFREM)

            Cmd.Parameters.AddWithValue("@JBFPNT1", JBFPNT1)
            Cmd.Parameters.AddWithValue("@JBFPNT2", JBFPNT2)
            Cmd.Parameters.AddWithValue("@JBFPNT3", JBFPNT3)
            Cmd.Parameters.AddWithValue("@JBFREM", JBFREM)

            Cmd.Parameters.AddWithValue("@LBFPNT1", LBFPNT1)
            Cmd.Parameters.AddWithValue("@LBFPNT2", LBFPNT2)
            Cmd.Parameters.AddWithValue("@LBFPNT3", LBFPNT3)
            Cmd.Parameters.AddWithValue("@LBFREM", LBFREM)

            Cmd.Parameters.AddWithValue("@MBFPNT1", MBFPNT1)
            Cmd.Parameters.AddWithValue("@MBFPNT2", MBFPNT2)
            Cmd.Parameters.AddWithValue("@MBFPNT3", MBFPNT3)
            Cmd.Parameters.AddWithValue("@MBFREM", MBFREM)

            Cmd.Parameters.AddWithValue("@OverallRemarks", OverallRemarks)
            Cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
            Cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn)

            Cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName)
            Cmd.Parameters.AddWithValue("@ModifiedBy", ModifiedBy)
            Cmd.Parameters.AddWithValue("@ModifiedOn", ModifiedOn)

            Dim X As Integer
            X = Cmd.ExecuteNonQuery()

            If X = 0 Then
                Return False
            Else
                Return True
            End If


        Catch ex As Exception
            Return False
        End Try

    End Function


    Public Shared Function SelectSCastingReportID(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectSCastingCheckSheet"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectSCastingReport(ByVal cnn As String, ByVal UID As Integer) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectSDailyCastingCheckSheet"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@UID", UID)
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SCastingPreparedBy(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectSCastingPreparedByList"
        Cmd.Parameters.Clear()

        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds

    End Function

    Public Shared Function SCastingOverallData(ByVal cnn As String, ByVal EmpName As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectOverallSCastingData"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("EmpName", EmpName)

        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds

    End Function

    ' Substrate Casting Check Sheet ##


    ' ## TPH Casting Check Sheet

    Public Shared Function InsertTCastingDailyCheckSheet( _
    ByVal IssueHighlighted As String, _
    ByVal CDate1 As DateTime, _
    ByVal Department As String, _
    ByVal CTime As DateTime, _
    ByVal Section As String, _
    ByVal WZ1 As Double, _
     ByVal WZ2 As Double, _
     ByVal WZ3 As Double, _
     ByVal WZ4 As Double, _
     ByVal WSL As Double, _
     ByVal WCL As Double, _
     ByVal WCN As Double, _
     ByVal WSN As Double, _
     ByVal WREM As String, _
     ByVal XZ1 As Double, _
     ByVal XZ2 As Double, _
     ByVal XZ3 As Double, _
     ByVal XZ4 As Double, _
     ByVal XSL As Double, _
     ByVal XCL As Double, _
     ByVal XCN As Double, _
     ByVal XSN As Double, _
     ByVal XREM As String, _
     ByVal YZ1 As Double, _
     ByVal YZ2 As Double, _
     ByVal YZ3 As Double, _
     ByVal YZ4 As Double, _
     ByVal YSL As Double, _
     ByVal YCL As Double, _
     ByVal YCN As Double, _
     ByVal YSN As Double, _
     ByVal YREM As String, _
     ByVal ZZ1 As Double, _
     ByVal ZZ2 As Double, _
     ByVal ZZ3 As Double, _
     ByVal ZZ4 As Double, _
     ByVal ZSL As Double, _
     ByVal ZCL As Double, _
     ByVal ZCN As Double, _
     ByVal ZSN As Double, _
     ByVal ZREM As String, _
     ByVal WFAN1 As Double, _
     ByVal WFAN2 As Double, _
     ByVal WFAN3 As Double, _
     ByVal WBFREM As String, _
     ByVal XFAN1 As Double, _
     ByVal XFAN2 As Double, _
     ByVal XFAN3 As Double, _
     ByVal XBFREM As String, _
     ByVal YFAN1 As Double, _
     ByVal YFAN2 As Double, _
     ByVal YFAN3 As Double, _
     ByVal YBFREM As String, _
     ByVal ZFAN1 As Double, _
     ByVal ZFAN2 As Double, _
     ByVal ZFAN3 As Double, _
     ByVal ZBFREM As String, _
     ByVal WFP1 As Double, _
     ByVal WFP2 As Double, _
     ByVal WFP3 As Double, _
     ByVal WPREM As String, _
     ByVal XFP1 As Double, _
     ByVal XFP2 As Double, _
     ByVal XFP3 As Double, _
     ByVal XPREM As String, _
     ByVal YFP1 As Double, _
     ByVal YFP2 As Double, _
     ByVal YFP3 As Double, _
     ByVal YPREM As String, _
     ByVal ZFP1 As Double, _
     ByVal ZFP2 As Double, _
     ByVal ZFP3 As Double, _
     ByVal ZPREM As String, _
     ByVal WEEFAN1 As Double, _
     ByVal WEEFAN2 As Double, _
     ByVal WEEFAN3 As Double, _
     ByVal WEEREM As String, _
     ByVal XEEFAN1 As Double, _
     ByVal XEEFAN2 As Double, _
     ByVal XEEFAN3 As Double, _
     ByVal XEEREM As String, _
     ByVal YEEFAN1 As Double, _
     ByVal YEEFAN2 As Double, _
     ByVal YEEFAN3 As Double, _
     ByVal YEEREM As String, _
     ByVal ZEEFAN1 As Double, _
     ByVal ZEEFAN2 As Double, _
     ByVal ZEEFAN3 As Double, _
     ByVal ZEEREM As String, _
     ByVal EFPNT1 As Double, _
     ByVal EFPNT1REM As String, _
     ByVal EFPNT2 As Double, _
     ByVal EFPNT2REM As String, _
     ByVal EFPNT3 As Double, _
     ByVal EFPNT3REM As String, _
     ByVal EFPNT4 As Double, _
     ByVal EFPNT4REM As String, _
     ByVal EFPNT5 As Double, _
     ByVal EFPNT5REM As String, _
     ByVal EFPNT6 As Double, _
     ByVal EFPNT6REM As String, _
     ByVal EFPNT7 As Double, _
     ByVal EFPNT7REM As String, _
     ByVal WGM As Double, _
     ByVal WEPC As Double, _
     ByVal WGMREM As String, _
     ByVal XGM As Double, _
     ByVal XEPC As Double, _
     ByVal XGMREM As String, _
     ByVal YGM As Double, _
     ByVal YEPC As Double, _
     ByVal YGMREM As String, _
     ByVal ZGM As Double, _
     ByVal ZEPC As Double, _
     ByVal ZGMREM As String, _
    ByVal OverallRemarks As String, _
    ByVal CreatedBy As String, _
    ByVal CreatedOn As DateTime, _
    ByVal EmployeeName As String, _
    ByVal Cnn As String, _
    ByVal WGMOP As Double, _
     ByVal WEPCOP As Double, _
     ByVal XGMOP As Double, _
     ByVal XEPCOP As Double, _
     ByVal YGMOP As Double, _
     ByVal YEPCOP As Double, _
     ByVal ZGMOP As Double, _
     ByVal ZEPCOP As Double _
     ) As Boolean

        Try
            Dim Con As New SqlConnection
            Con = New SqlConnection(Cnn)
            Con.Open()
            Dim Cmd As New SqlCommand
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.CommandText = "SP_TDailyCastingCheckSheet"
            Cmd.Parameters.Clear()
            Cmd.Connection = Con

            Cmd.Parameters.AddWithValue("@IssueHighlighted", IssueHighlighted)
            Cmd.Parameters.AddWithValue("@CDate", CDate1)
            Cmd.Parameters.AddWithValue("@Department", Department)
            Cmd.Parameters.AddWithValue("@CTime", CTime)
            Cmd.Parameters.AddWithValue("@Section", Section)
            Cmd.Parameters.AddWithValue("@WZ1", WZ1)
            Cmd.Parameters.AddWithValue("@WZ2", WZ2)
            Cmd.Parameters.AddWithValue("@WZ3", WZ3)
            Cmd.Parameters.AddWithValue("@WZ4", WZ4)
            Cmd.Parameters.AddWithValue("@WSL", WSL)
            Cmd.Parameters.AddWithValue("@WCL", WCL)
            Cmd.Parameters.AddWithValue("@WCN", WCN)
            Cmd.Parameters.AddWithValue("@WSN", WSN)
            Cmd.Parameters.AddWithValue("@WREM", WREM)
            Cmd.Parameters.AddWithValue("@XZ1", XZ1)
            Cmd.Parameters.AddWithValue("@XZ2", XZ2)
            Cmd.Parameters.AddWithValue("@XZ3", XZ3)
            Cmd.Parameters.AddWithValue("@XZ4", XZ4)
            Cmd.Parameters.AddWithValue("@XSL", XSL)
            Cmd.Parameters.AddWithValue("@XCL", XCL)
            Cmd.Parameters.AddWithValue("@XCN", XCN)
            Cmd.Parameters.AddWithValue("@XSN", XSN)
            Cmd.Parameters.AddWithValue("@XREM", XREM)
            Cmd.Parameters.AddWithValue("@YZ1", YZ1)
            Cmd.Parameters.AddWithValue("@YZ2", YZ2)
            Cmd.Parameters.AddWithValue("@YZ3", YZ3)
            Cmd.Parameters.AddWithValue("@YZ4", YZ4)
            Cmd.Parameters.AddWithValue("@YSL", YSL)
            Cmd.Parameters.AddWithValue("@YCL", YCL)
            Cmd.Parameters.AddWithValue("@YCN", YCN)
            Cmd.Parameters.AddWithValue("@YSN", YSN)
            Cmd.Parameters.AddWithValue("@YREM", YREM)
            Cmd.Parameters.AddWithValue("@ZZ1", ZZ1)
            Cmd.Parameters.AddWithValue("@ZZ2", ZZ2)
            Cmd.Parameters.AddWithValue("@ZZ3", ZZ3)
            Cmd.Parameters.AddWithValue("@ZZ4", ZZ4)
            Cmd.Parameters.AddWithValue("@ZSL", ZSL)
            Cmd.Parameters.AddWithValue("@ZCL", ZCL)
            Cmd.Parameters.AddWithValue("@ZCN", ZCN)
            Cmd.Parameters.AddWithValue("@ZSN", ZSN)
            Cmd.Parameters.AddWithValue("@ZREM", ZREM)
            Cmd.Parameters.AddWithValue("@WFAN1", WFAN1)
            Cmd.Parameters.AddWithValue("@WFAN2", WFAN2)
            Cmd.Parameters.AddWithValue("@WFAN3", WFAN3)
            Cmd.Parameters.AddWithValue("@WBFREM", WBFREM)
            Cmd.Parameters.AddWithValue("@XFAN1", XFAN1)
            Cmd.Parameters.AddWithValue("@XFAN2", XFAN2)
            Cmd.Parameters.AddWithValue("@XFAN3", XFAN3)
            Cmd.Parameters.AddWithValue("@XBFREM", XBFREM)
            Cmd.Parameters.AddWithValue("@YFAN1", YFAN1)
            Cmd.Parameters.AddWithValue("@YFAN2", YFAN2)
            Cmd.Parameters.AddWithValue("@YFAN3", YFAN3)
            Cmd.Parameters.AddWithValue("@YBFREM", YBFREM)
            Cmd.Parameters.AddWithValue("@ZFAN1", ZFAN1)
            Cmd.Parameters.AddWithValue("@ZFAN2", ZFAN2)
            Cmd.Parameters.AddWithValue("@ZFAN3", ZFAN3)
            Cmd.Parameters.AddWithValue("@ZBFREM", ZBFREM)
            Cmd.Parameters.AddWithValue("@WFP1", WFP1)
            Cmd.Parameters.AddWithValue("@WFP2", WFP2)
            Cmd.Parameters.AddWithValue("@WFP3", WFP3)
            Cmd.Parameters.AddWithValue("@WPREM", WPREM)
            Cmd.Parameters.AddWithValue("@XFP1", XFP1)
            Cmd.Parameters.AddWithValue("@XFP2", XFP2)
            Cmd.Parameters.AddWithValue("@XFP3", XFP3)
            Cmd.Parameters.AddWithValue("@XPREM", XPREM)
            Cmd.Parameters.AddWithValue("@YFP1", YFP1)
            Cmd.Parameters.AddWithValue("@YFP2", YFP2)
            Cmd.Parameters.AddWithValue("@YFP3", YFP3)
            Cmd.Parameters.AddWithValue("@YPREM", YPREM)
            Cmd.Parameters.AddWithValue("@ZFP1", ZFP1)
            Cmd.Parameters.AddWithValue("@ZFP2", ZFP2)
            Cmd.Parameters.AddWithValue("@ZFP3", ZFP3)
            Cmd.Parameters.AddWithValue("@ZPREM", ZPREM)
            Cmd.Parameters.AddWithValue("@WEEFAN1", WEEFAN1)
            Cmd.Parameters.AddWithValue("@WEEFAN2", WEEFAN2)
            Cmd.Parameters.AddWithValue("@WEEFAN3", WEEFAN3)
            Cmd.Parameters.AddWithValue("@WEEREM", WEEREM)
            Cmd.Parameters.AddWithValue("@XEEFAN1", XEEFAN1)
            Cmd.Parameters.AddWithValue("@XEEFAN2", XEEFAN2)
            Cmd.Parameters.AddWithValue("@XEEFAN3", XEEFAN3)
            Cmd.Parameters.AddWithValue("@XEEREM", XEEREM)
            Cmd.Parameters.AddWithValue("@YEEFAN1", YEEFAN1)
            Cmd.Parameters.AddWithValue("@YEEFAN2", YEEFAN2)
            Cmd.Parameters.AddWithValue("@YEEFAN3", YEEFAN3)
            Cmd.Parameters.AddWithValue("@YEEREM", YEEREM)
            Cmd.Parameters.AddWithValue("@ZEEFAN1", ZEEFAN1)
            Cmd.Parameters.AddWithValue("@ZEEFAN2", ZEEFAN2)
            Cmd.Parameters.AddWithValue("@ZEEFAN3", ZEEFAN3)
            Cmd.Parameters.AddWithValue("@ZEEREM", ZEEREM)
            Cmd.Parameters.AddWithValue("@EFPNT1", EFPNT1)
            Cmd.Parameters.AddWithValue("@EFPNT1REM", EFPNT1REM)
            Cmd.Parameters.AddWithValue("@EFPNT2", EFPNT2)
            Cmd.Parameters.AddWithValue("@EFPNT2REM", EFPNT2REM)
            Cmd.Parameters.AddWithValue("@EFPNT3", EFPNT3)
            Cmd.Parameters.AddWithValue("@EFPNT3REM", EFPNT3REM)
            Cmd.Parameters.AddWithValue("@EFPNT4", EFPNT4)
            Cmd.Parameters.AddWithValue("@EFPNT4REM", EFPNT4REM)
            Cmd.Parameters.AddWithValue("@EFPNT5", EFPNT5)
            Cmd.Parameters.AddWithValue("@EFPNT5REM", EFPNT5REM)
            Cmd.Parameters.AddWithValue("@EFPNT6", EFPNT6)
            Cmd.Parameters.AddWithValue("@EFPNT6REM", EFPNT6REM)
            Cmd.Parameters.AddWithValue("@EFPNT7", EFPNT7)
            Cmd.Parameters.AddWithValue("@EFPNT7REM", EFPNT7REM)
            Cmd.Parameters.AddWithValue("@WGM", WGM)
            Cmd.Parameters.AddWithValue("@WEPC", WEPC)
            Cmd.Parameters.AddWithValue("@WGMREM", WGMREM)
            Cmd.Parameters.AddWithValue("@XGM", XGM)
            Cmd.Parameters.AddWithValue("@XEPC", XEPC)
            Cmd.Parameters.AddWithValue("@XGMREM", XGMREM)
            Cmd.Parameters.AddWithValue("@YGM", YGM)
            Cmd.Parameters.AddWithValue("@YEPC", YEPC)
            Cmd.Parameters.AddWithValue("@YGMREM", YGMREM)
            Cmd.Parameters.AddWithValue("@ZGM", ZGM)
            Cmd.Parameters.AddWithValue("@ZEPC", ZEPC)
            Cmd.Parameters.AddWithValue("@ZGMREM", ZGMREM)
            Cmd.Parameters.AddWithValue("@OverallRemarks", OverallRemarks)
            Cmd.Parameters.AddWithValue("@CreatedBy", CreatedBy)
            Cmd.Parameters.AddWithValue("@CreatedOn", CreatedOn)
            Cmd.Parameters.AddWithValue("@EmployeeName", EmployeeName)
            Cmd.Parameters.AddWithValue("@WGMOP", WGMOP)
            Cmd.Parameters.AddWithValue("@WEPCOP", WEPCOP)
            Cmd.Parameters.AddWithValue("@XGMOP", XGMOP)
            Cmd.Parameters.AddWithValue("@XEPCOP", XEPCOP)
            Cmd.Parameters.AddWithValue("@YGMOP", YGMOP)
            Cmd.Parameters.AddWithValue("@YEPCOP", YEPCOP)
            Cmd.Parameters.AddWithValue("@ZGMOP", ZGMOP)
            Cmd.Parameters.AddWithValue("@ZEPCOP", ZEPCOP)
            Dim X As Integer
            X = Cmd.ExecuteNonQuery()

            If X = 0 Then
                Return False
            Else
                Return True
            End If


        Catch ex As Exception
            Return False
        End Try

    End Function

    Public Shared Function SelectTCastingReportID(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectTCastingCheckSheet"
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function SelectTCastingReport(ByVal cnn As String, ByVal UID As Integer) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectTDailyCastingCheckSheet"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("@UID", UID)
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function

    Public Shared Function TCastingPreparedBy(ByVal cnn As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectTCastingPreparedByList"
        Cmd.Parameters.Clear()

        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds

    End Function

    Public Shared Function TCastingOverallData(ByVal cnn As String, ByVal EmpName As String) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter

        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.CommandText = "SP_SelectOverallTCastingData"
        Cmd.Parameters.Clear()
        Cmd.Parameters.AddWithValue("EmpName", EmpName)

        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds

    End Function

    ' TPH Casting Check Sheet ##


    Public Shared Function CheckOverlapping(ByVal cnn As String, ByVal Date1 As DateTime, ByVal Date2 As DateTime) As DataSet
        'On Error Resume Next
        Dim Con As New SqlConnection
        Con = New SqlConnection(cnn)
        Con.Open()
        Dim Cmd As New SqlCommand
        Dim da As New SqlDataAdapter


        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.Clear()

        Cmd.CommandText = "VC_CheckOverlapping"
        Cmd.Parameters.AddWithValue("@Start2", Date1)
        Cmd.Parameters.AddWithValue("@End2", Date2)
        Cmd.Connection = Con
        da = New SqlDataAdapter(Cmd)

        ds = New DataSet
        da.Fill(ds, "RefNo")
        Return ds
    End Function
End Class

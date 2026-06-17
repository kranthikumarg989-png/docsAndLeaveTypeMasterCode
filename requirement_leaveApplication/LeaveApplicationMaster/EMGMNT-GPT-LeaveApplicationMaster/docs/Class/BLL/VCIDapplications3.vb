Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports E_Management.Emanagement.SqlHelper
Imports E_Management.Emanagement.globalinfo
Imports System.Collections
Namespace emanagement
    Public Class VCIDapplications3

        Public Shared dsdata As New DataSet
        Public Shared dsdata1 As New DataSet
        Public Shared SQLstat As String
        Public Shared posid As Integer
        Public Shared recstatus As Boolean
        Public Shared _ename As String
        Public Shared _eid As String
        Public Shared _edept As String
        Public Shared _esect As String
        Public Shared _edesig As String
        Public Shared _fisyrStart As Date
        Public Shared _fisyrEnd As Date
        Public Shared _curdttime As Date
        Public Shared RecordId As Decimal

        'Public Shared _pfisyrStart As Date
        'Public Shared _pfisyrEnd As Date
        Private fstrDBErrorMsg As String
        Dim lParamOleDB As New OleDb.OleDbParameter




        ' ######### function to get current fiscal year ########
        Public Sub GetfiscalYear()
            Dim fmon As Integer
            fmon = Month(Date.Now)

            If fmon <= 3 Then
                _fisyrStart = DateTime.Today.AddYears(-1)
                _fisyrEnd = DateTime.Today
            Else
                _fisyrStart = DateTime.Today
                _fisyrEnd = DateTime.Today.AddYears(1)
            End If

            _fisyrStart = "04/01/" & Year(_fisyrStart)
            _fisyrEnd = "3/31/" & Year(_fisyrEnd)

            '  _pfisyrStart = "04/01/" & Year(_fisyrStart)
            '  _pfisyrEnd = "03/31/" & Year(_fisyrEnd)
            _curdttime = Date.Now
        End Sub
        ' ######### function to get max(recordno) from department table ########
        Public Shared Function GetPCMrecNo() As Integer
            SQLstat = "SELECT isnull(max(productcode),0)+1 AS productcode from VCID_productclassmaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetPRNo() As Integer
            SQLstat = "SELECT isnull(max(cast(prno as int)),0)+1 AS prno from VCID_PRMaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function GetWPNo(ByVal WPNO As String) As Integer
            SQLstat = "SELECT   ISNULL(MAX(Cast(PRNO as int)), 0) AS WPNO  FROM VCID_PRMaster WHERE WorkPermitNo='" & WPNO & "' and PRstatus<>'C' and WorkPermitNo<>'0'"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function Getmaxrevno() As Integer
            SQLstat = "SELECT isnull(max(revno),0)+1 AS revno from VCID_Quotationdetail"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetJSSrecNo() As Integer
            SQLstat = "SELECT isnull(max(jobscopecode),0)+1 AS jobscopecode from VCID_jobscopemaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function cancelquote(ByVal txt As String) As DataSet
            SQLstat = "update VCID_quotationmaster set approvalstatus = 'C' where quotationno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MsgBox(ex.Message)
            End Try
            Return dsdata
        End Function
        Public Shared Function Getquoteno() As Integer
            SQLstat = "SELECT isnull(max(quotationno),0)+1 AS qno FROM VCID_quotationmaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function Getrevqno(ByVal qno As String) As Integer
            SQLstat = "SELECT isnull(max(revno),0)+1 AS rno FROM VCID_quotationdetail where refquoteno = '" & qno & "'"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function getchkval8(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and dateofkeyin= '" & fdate & "' and transfer='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                'MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function Getcedata(ByVal txt As String) As DataSet
            SQLstat = "select * from empmaster where empcode = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                'MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Getmaxmprc() As Integer
            SQLstat = "SELECT isnull(max(mprcno),0)+1 AS mprcno from VCID_MPRCMAster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        '''''''''''''''''''GET Currency Rate'''''''''''''''''''''''
        Public Shared Function GetEXR(ByVal currency As String) As Integer
            SQLstat = ("select exchangeprice from pur_currencymaster where recordno = (select max(recordno) from pur_currencymaster where currencycode = '" & currency & "')")
            RecordId = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return RecordId
        End Function

    End Class
End Namespace




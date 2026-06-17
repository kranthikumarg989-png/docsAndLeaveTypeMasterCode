Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports E_Management.Emanagement.SqlHelper
Imports E_Management.Emanagement.globalinfo
Imports System.Collections
Namespace emanagement
    Public Class VCIDapplications1

        Public Shared dsdata As New DataSet
        Public Shared dsdata1 As New DataSet
        Public Shared SQLstat As String
        Public Shared posid As Integer
        Public Shared recstatus As Boolean
        Public Shared RecordId As Decimal
        Private fstrDBErrorMsg As String
        Public Shared _eid As String
        Dim lParamOleDB As New OleDb.OleDbParameter


        '''' VCID
        Public Shared Function GetMaxPrNo() As Integer
            SQLstat = "SELECT isnull(max(prno),0)+1 AS prno FROM VCID_PRMaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function GetPrDetails(ByVal sno As String) As DataSet
            ' SQLstat = "select * from vcid_prmaster where prno = '" & sno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "VCID_PRdetails", sno)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MsgBox(ex.Message)
            End Try
            Return dsdata
        End Function
    End Class
End Namespace









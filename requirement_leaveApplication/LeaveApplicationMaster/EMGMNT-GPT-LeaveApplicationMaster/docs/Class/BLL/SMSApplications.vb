Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports E_Management.Emanagement.SqlHelper
Imports E_Management.Emanagement.globalinfo
Imports System.Collections
Namespace emanagement
    Public Class SMSApplications
        Public Shared dsdata, dsaccess As New DataSet
        ' Public Shared draccess As New DataRow
        Public Shared dsdata1 As New DataSet
        Public Shared SQLstat As String
        Public Shared posids As Integer
        Public Shared recstatus As Boolean

        Public Shared Function GetMaxID() As Integer
            SQLstat = "SELECT isnull(max(id),0)+1 AS sno FROM tbl_SmsAssignment"
            posids = emanagement.SqlHelper.ExecuteScalar(conSMSstr, CommandType.Text, SQLstat)
            Return posids
        End Function
    End Class
End Namespace


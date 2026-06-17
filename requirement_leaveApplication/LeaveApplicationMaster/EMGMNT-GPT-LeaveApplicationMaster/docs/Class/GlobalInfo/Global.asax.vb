Imports System.Web
Imports System.Web.SessionState


Namespace Emanagement

    Public Class [Global]
        Inherits System.Web.HttpApplication
        Public Shared sqlName As String
        Public Shared sqlDBName As String
        Public Shared sqlUid As String
        Public Shared sqlPwd As String
        Public Const hrmisConnStr As String = "ConnectionString"

        Public Shared sqlServerName As String
        Public Const CfgKeyConnString As String = "ConnectionString"
        Public Shared smssqlServerName As String
        Public Shared smssqlDBName As String
        Public Shared smssqlUid As String
        Public Shared smssqlPwd As String
        Public Shared crmsqlServerName As String
        Public Shared crmsqlDBName As String
        Public Shared crmsqlUid As String
        Public Shared crmsqlPwd As String
        Public Shared LoggedIn As Boolean

        Sub Application_Start(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when the application is started
            sqlName = "192.168.0.240"
            sqlServerName = "192.168.0.240"
            sqlDBName = "hrmis"
            sqlUid = ""
            sqlPwd = ""

            smssqlServerName = "192.168.0.241"
            smssqlDBName = "SMS"
            smssqlUid = ""
            smssqlPwd = ""

            crmsqlServerName = "192.168.0.241"
            crmsqlDBName = "mmCRM"
            crmsqlUid = "sa"
            crmsqlPwd = ""

        End Sub
        Sub Application_StartSSS()
            ' Fires when the application is started
            sqlName = "192.168.0.240"
            sqlServerName = "192.168.0.240"
            sqlDBName = "Hrmis"
            sqlUid = ""
            sqlPwd = ""

            smssqlServerName = "192.168.0.241"
            smssqlDBName = "SMS"
            smssqlUid = ""
            smssqlPwd = ""

            crmsqlServerName = "192.168.0.241"
            crmsqlDBName = "mmCRM"
            crmsqlUid = "sa"
            crmsqlPwd = ""


        End Sub
        Sub Session_Start(ByVal sender As Object, ByVal e As EventArgs)
            'Fires when the session is started
            'When a session starts on the server the following code will be run
            'Set the server locale
            'MsgBox(Session.LCID)
            'Session.LCID = 1033

        End Sub

        Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires at the beginning of each request
        End Sub

        Sub Application_AuthenticateRequest(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires upon attempting to authenticate the use
        End Sub

        Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when an error occurs
        End Sub

        Sub Session_End(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when the session ends
        End Sub

        Sub Application_End(ByVal sender As Object, ByVal e As EventArgs)
            ' Fires when the application ends
        End Sub
    End Class
End Namespace
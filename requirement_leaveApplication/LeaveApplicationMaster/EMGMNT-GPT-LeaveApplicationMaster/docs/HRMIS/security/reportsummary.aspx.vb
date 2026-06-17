Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports E_Management.Emanagement.globalinfo
Imports E_Management.Emanagement.EMSapplications
Partial Public Class reportsummary
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim str, ans As String
    Dim cmd As New SqlCommand
    Dim rdr As SqlDataReader
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Con_Str()
        MyGlobal.Open_Con()
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MyGlobal.Con_Str()
        MyGlobal.Open_Con()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        For i As Integer = 1 To 4
            If i = 1 Then
                str = "select count(status)from staffgatepass where status='RETURNED' and gatepasstype= 'personal' and (outdate >='" & (tb1.Text) & "' and outdate<='" & (tb2.Text) & "')"
            ElseIf i = 2 Then
                str = "select count(status)from staffgatepass where status='RETURNED' and gatepasstype= 'official' and (outdate >='" & (tb1.Text) & "' and outdate<='" & (tb2.Text) & "')"
            ElseIf i = 3 Then
                str = "select count(status) from clinicstaffgatepass where status='F' and (dateapplied >='" & (tb1.Text) & "' and dateapplied <='" & (tb2.Text) & "')"
            ElseIf i = 4 Then
                str = "select count(status) from acc_customerapplication where status='out' and (date1>='" & (tb1.Text) & "' and date1<='" & (tb2.Text) & "')"
            End If
            cmd = New SqlCommand(str, con)
            rdr = cmd.ExecuteReader
            While rdr.Read
                ans = rdr(0)
                If i = 1 Then
                    gppers.Text = ans
                ElseIf i = 2 Then
                    gpoff.Text = ans
                ElseIf i = 3 Then
                    clinicpass.Text = ans
                ElseIf i = 4 Then
                    Customerpass.Text = ans
                End If
            End While
            rdr.Close()
        Next
        total.Text = "Total = " & Val(gppers.Text) + Val(gpoff.Text)
    End Sub
End Class
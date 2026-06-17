Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class DomWasteVerification
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (141)
            If GlobalDSRights.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In GlobalDSRights.Tables(0).Select("scrid = '" & MyScreenId & "'")
                    MyScreenStat = row("scrstatus").ToString
                Next
            Else
                MyScreenStat = 0
            End If

            If MyScreenStat = 0 Then
                ' MessageBox("Sorry!!! You are not having Access to this screen")
                Response.Redirect("~\hrmis\default.aspx")
            End If
        Else
            Response.Redirect("~\logout.aspx")
        End If
        'Session("empcode") = "014543"
    End Sub
    Public Sub getDomWaste(ByVal sender As Object, ByVal e As CommandEventArgs)
        Dim appno
        Dim i As Integer
        Dim majortype As String = GridView1.Rows(i).Cells(6).Text
        appno = e.CommandArgument
        Session("domwasteconsign") = appno
        If majortype = "Schedule Waste" Then
            Response.Redirect("SchWasteConsignment.aspx")
        ElseIf majortype = "Domestic Waste" Then
            Response.Redirect("DomWasteConsignment.aspx")
        End If
    End Sub
    'Protected Sub domveri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles domveri.Click

    '    MyGlobal.Open_Con()
    '    MyGlobal.Con_Str()
    '    BindDWVgrid()
    'End Sub
    'Private Sub BindDWVgrid()

    '    Dim opn
    '    Dim myval

    '    'Bind Grid view

    '    MyGlobal.Con_Str()
    '    Dim ds1 As New DataSet()
    '    Dim con As New SqlConnection(constr)
    '    con.Open()
    '    Dim Command As New SqlCommand
    '    Command = New SqlCommand("OT_GetEmpID_fetch", con)
    '    Command.CommandType = CommandType.StoredProcedure
    '    Command.Parameters.AddWithValue("@dept", myval)
    '    Command.Parameters.AddWithValue("@Operation", opn)
    '    Dim DataAdap = New SqlDataAdapter(Command)
    '    DataAdap.Fill(ds1, "OTRec")
    '    GridView1.DataSource = ds1
    '    GridView1.DataBind()
    '    con.Close()


    'End Sub

End Class
Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports System.Web.Security

Partial Public Class requestordetails
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        thisdate = DateTime.Now.ToShortDateString()

        Dim getreqdet As String
        If Not IsPostBack Then
            If Session("detreq") <> "" Then
                getreqdet = Session("detreq")
                fetchreq(getreqdet)
            Else
                getreqdet = ""
            End If
        End If

    End Sub
    Public Sub fetchreq(ByVal record As String)

        Dim ds As New DataSet
        Dim dr1 As DataRow
        ds = GetDetails(record)
        If ds.Tables(0).Rows.Count <> 0 Then
            dr1 = ds.Tables(0).Rows(0)
            recordno.Text = dr1("recordno").ToString
            dateapplied.Text = Format(Convert.ToDateTime(dr1("dateapplied")), "dd/MM/yy")
            dept.Text = dr1("dept").ToString
            empcode.Text = dr1("empcode").ToString
            empname.Text = dr1("empname").ToString
            sect.Text = dr1("sect").ToString
            datedispossal.Text = Format(Convert.ToDateTime(dr1("datedispossal")), "dd/MM/yy")
            timedispossal.Text = dr1("timedispossal").ToString
            dateverification.Text = dr1("dateverification").ToString
            timeverification.Text = dr1("timeverification").ToString
            personincharge.Text = dr1("personincharge").ToString
            HODcheckedby.Text = dr1("HODcheckedby").ToString
        End If
    End Sub
    Function GetDetails(ByVal record As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select *, empname from Safety_schedulewasteconsignment , empmaster where recordno = '" & record & "' and empmaster.empcode = Safety_schedulewasteconsignment.empcode ", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "RD")
        con.Close()
        Return ds
    End Function

End Class

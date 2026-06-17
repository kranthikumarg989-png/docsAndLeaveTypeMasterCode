Imports System.Data.SqlClient
Imports System.IO
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PrintAppraisal
    Inherits System.Web.UI.Page

    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim da As SqlDataAdapter
    Dim rdr, rdr1 As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        HtmlEditor1.HtmlModeEditable = False
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '  If Request.QueryString("ln") <> "" Then
        LoadEditor(Request.QueryString("ln"))
        ' Else

        ' End If
    End Sub
    Private Sub LoadEditor(ByVal ln As String)

        'Dim strcontent As String
        'Dim oldvalue, newvalue

        'Dim dr As SqlDataReader
        'Dim da As SqlDataAdapter

        'Dim con As New SqlConnection(constr)
        'con.Open()

        'Cmd = New SqlCommand("hrmis_CMG_GetLetterRevNo_preview", con)
        'Cmd.CommandType = CommandType.StoredProcedure
        'Cmd.Parameters.AddWithValue("@ln", ln)
        'dr = Cmd.ExecuteReader()
        'While (dr.Read())
        'strcontent = DR("letterlink").ToString()
        Dim fn As String
        fn = "F:\E-Management\CMGLetterIssued\appointment_promot177.HTML"
        Dim filePath As String = fn
        Dim objStreamReader As StreamReader
        objStreamReader = File.OpenText(filePath)
        Dim contents As String = objStreamReader.ReadToEnd()
        HtmlEditor1.Text = contents
        'End While
        Page.ClientScript.RegisterStartupScript(Me.[GetType](), "Print", "javascript:window.print();", True)
        'Con.Close()
        'Cmd.Dispose()

    End Sub
End Class
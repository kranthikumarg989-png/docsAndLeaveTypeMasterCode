Imports System.Data
Imports System
Imports System.io
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class PrintSaveLetter
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim thisdate As Date
    Dim da As SqlDataAdapter
    Dim rdr, rdr1 As SqlDataReader

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        If Request.QueryString("ln") <> "" Then
            LoadEditor(Request.QueryString("ln"))
        Else

        End If
    End Sub
    Private Sub LoadEditor(ByVal ln As String)

        Dim strcontent As String
        Dim oldvalue, newvalue

        Dim dr As SqlDataReader
        Dim da As SqlDataAdapter

        Dim con As New SqlConnection(constr)
        con.Open()

        Cmd = New SqlCommand("hrmis_CMG_GetLetterRevNo_preview", con)
        Cmd.CommandType = CommandType.StoredProcedure
        Cmd.Parameters.AddWithValue("@ln", ln)
        dr = Cmd.ExecuteReader()
        While (dr.Read())
            strcontent = dr("letterlink").ToString()
            Dim fn As String
            fn = "F:\E-Management\CMGLetter\" & strcontent
            Dim filePath As String = fn
            Dim objStreamReader As StreamReader
            objStreamReader = File.OpenText(filePath)
            Dim contents As String = objStreamReader.ReadToEnd()


            'HtmlEditor1.Text = contents
        End While

        con.Close()
        Cmd.Dispose()

    End Sub

End Class
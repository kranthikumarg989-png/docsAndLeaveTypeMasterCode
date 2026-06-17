Imports System
Imports System.Data
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Letter_intro
    Inherits System.Web.UI.Page
    Dim myglobal As New Emanagement.globalinfo
    Dim myapp As New Emanagement.EMSapplications
    Dim dt
    Dim cmdst As String
    Dim cmdstr As New SqlCommand
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'session("_edept")="9000"
        myglobal.open_con()
        myglobal.Con_Str()
    End Sub
    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim sts, user As String
        dt = Date.Now.ToString
        sts = "Scheduled"
        user = "user"
        Con.Open()
        cmdst = "insert into hrmis_er_letter values('" & Trim(TextBox1.Text) & "','" & Trim(sts) & "','" & Trim(user) & "','" & dt & "','" & Trim(user) & "','" & dt & "','" & (DropDownList1.SelectedItem.Text) & "')"
        cmdstr = New SqlCommand(cmdst, Con)
        cmdstr.ExecuteNonQuery()
    End Sub
    Protected Sub UpdategpApproval(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim nbr
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim slno As String = GridView1.Rows(i).Cells(0).Text
            Dim cs As String = DirectCast(GridView1.Rows(i).FindControl("checkbox1"), CheckBox).Checked
            If cs = True Then
                nbr = slno
            End If
            myglobal.Open_Con()
            myglobal.Con_Str()
            DS = Open_Letter(Con, DAP, 2, "delete from hrmis_er_letter where slno = '" & nbr & "' ")
            myglobal.db_close()
        Next
        GridView1.DataBind()
    End Sub
End Class
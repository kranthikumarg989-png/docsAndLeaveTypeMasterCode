Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class Traininglist
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications
    Dim empcode As String
    Dim code As Integer

    Private Sub Page_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        'Dim code As Integer
        'Gettrlist()
        'code = posid
        'lbl.Text = posid

        titleddl.SelectedValue = "-1"

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (148)
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

        MyApp.GetfiscalYear()
        _eid = Session("empcode")
        Label1.Text = ""

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub
    Protected Sub btnadd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnadd.Click



        Try
            MyGlobal.Con_Str()
            Dim con As New SqlConnection(constr)
            con.Open()
            Cmd = New SqlCommand("insert into td_traininglist (td_title,td_code,td_programme, DepartmentCode, DepartmentName, SectionCode, SectionName, Method, Type ) values('" & titleddl.SelectedValue & "', '" & lbl.Text & "', '" & CmbProgramme.SelectedItem.Text & "','" & CmbDepartment.SelectedValue & "','" & CmbDepartment.SelectedItem.Text & "','" & CmbSection.SelectedValue & "','" & CmbSection.SelectedItem.Text & "','" & CmbMethod.SelectedItem.Text & "','" & CmbType.SelectedItem.Text & "' ) ", con)
            Cmd.ExecuteNonQuery()
            Label1.Text = "Training list Saved successfully"
            Gettrlist()
            code = posid
            lbl.Text = posid
           
        Catch ex As Exception
            messagebox(ex.Message)
            Label1.Text = ex.Message
        End Try
        
        GridView1.DataBind()

    End Sub
    'titleddl.SelectedValue = "-1"
    '        prgm.Text = ""
End Class
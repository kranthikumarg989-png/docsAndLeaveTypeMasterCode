Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class staffOTElligible
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
            MyScreenId = (70)
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
    End Sub
    Protected Sub rb1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.SelectedIndexChanged

        If rb1.SelectedValue = "Dept" Then
            Deptddl.Visible = True
            Secddl.Visible = False
            code.Visible = False
            depart.Visible = True
            section.Visible = False
            ecode.Visible = False

        ElseIf rb1.SelectedValue = "sect" Then
            Deptddl.Visible = False
            Secddl.Visible = True
            code.Visible = False
            depart.Visible = False
            section.Visible = True
            ecode.Visible = False

        ElseIf rb1.SelectedValue = "ecode" Then
            Deptddl.Visible = False
            Secddl.Visible = False
            code.Visible = True
            depart.Visible = False
            section.Visible = False
            ecode.Visible = True

        End If


    End Sub
    Protected Sub Submitelig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SubmitElig.Click

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        BindOTgrid()
    End Sub
    Private Sub bindOTGrid()

        Dim opn
        Dim Dept As String
        Dept = Deptddl.SelectedValue
        Dim sect As String
        sect = Secddl.SelectedValue
        Dim ecode As String
        ecode = code.Text
        Dim myval

        If rb1.SelectedValue = "Dept" And Deptddl.SelectedValue <> "-1" Then
            ' messagebox("Please choose a department")
            myval = Dept
            opn = "Dept"
        ElseIf rb1.SelectedValue = "sect" And Secddl.SelectedValue <> "-1" Then
            ' messagebox("Please choose a Section")
            myval = sect
            opn = "sect"
        ElseIf rb1.SelectedValue = "ecode" And code.Text <> "" Then
            ' messagebox("Please enter a employee code")
            myval = ecode
            opn = "emp"
        End If

        If rb1.SelectedValue = "Dept" And Deptddl.SelectedValue = "-1" Then
            MessageBox("Please choose a department")
            Exit Sub
        ElseIf rb1.SelectedValue = "sect" And Secddl.SelectedValue = "-1" Then
            MessageBox("Please choose a Section")
            Exit Sub
        ElseIf rb1.SelectedValue = "ecode" And code.Text = "" Then
            MessageBox("Please enter a employee code")
            Exit Sub
        End If

        Dim ds As DataSet
        Dim dr2 As DataRow
        ds = GetappEMployeeRec(myval, opn)
        Dim per1
        Dim i
        If ds.Tables(0).Rows.Count <> 0 Then
            dr2 = ds.Tables(0).Rows(0)
            per1 = dr2("empcode")
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()

            For i = 1 To ds.Tables(0).Rows.Count
                Call MyGlobal.dbSp_open("OT_InsElligibleStaff")
                Cmd.Parameters.AddWithValue("@empno", per1)
                Cmd.ExecuteNonQuery()

            Next
        End If

        'Bind Grid view

        MyGlobal.Con_Str()
        Dim ds1 As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("OT_GetEmpID_fetch", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@dept", myval)
        Command.Parameters.AddWithValue("@Operation", opn)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds1, "OTRec")
        GridView1.DataSource = ds1
        GridView1.DataBind()
        con.Close()


    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Function GetappEMployeeRec(ByVal selval As String, ByVal opn As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("OT_GetEmpID", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@dept", selval)
        Command.Parameters.AddWithValue("@Operation", opn)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "character")
        con.Close()
        Return ds
    End Function

    Public Sub Hodapproval(ByVal sender As Object, ByVal e As System.EventArgs)
        For i As Integer = 0 To GridView1.Rows.Count - 1
            Dim val As Integer
            Dim rno As String = DirectCast(GridView1.Rows(i).FindControl("label2"), Label).Text
            Dim elligible As CheckBox = DirectCast(GridView1.Rows(i).FindControl("CheckBox1"), CheckBox)
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            If elligible.Checked = True Then
                val = "-1"
            Else
                val = "0"
            End If

            Try
                ds = Open_OTeligible(con, DAP, 2, "update OT_ElligibleStaff set elligible = '" & val & "' where recno = '" & rno & "'")
            Catch ex As Exception
                MessageBox(ex.Message)
            End Try

            MyGlobal.db_close()
        Next
        bindOTGrid()
        GridView1.DataBind()
    End Sub

    Private Sub Deptddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Deptddl.SelectedIndexChanged
        bindOTGrid()
    End Sub

    Private Sub Secddl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Secddl.SelectedIndexChanged
        bindOTGrid()
    End Sub

    Private Sub code_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles code.TextChanged
        bindOTGrid()
    End Sub
    Private Sub GridView1_RowCreated(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView1.RowCreated
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False

        End If
        If e.Row.RowType = DataControlRowType.DataRow Then
            e.Row.Cells(7).Visible = False
            e.Row.Cells(6).Visible = False
        End If
        If e.Row.RowType = DataControlRowType.Footer Then
            e.Row.Cells(6).Visible = False
            e.Row.Cells(7).Visible = False

        End If
    End Sub
End Class

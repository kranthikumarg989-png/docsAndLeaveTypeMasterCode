Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class jobcode
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim rno, recno, sno As Integer
    Dim dept, desig As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()

        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (131)
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

        dept = ddldept.SelectedValue.Trim
        desig = ddldesig.SelectedValue.Trim
    End Sub

    Protected Sub btnsave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsave.Click

        Dim j As Integer = 0
        dept = ddldept.SelectedValue.Trim
        desig = ddldesig.SelectedValue.Trim

        InsertJobCode(dept, desig, txtcode.Text.Trim)

        If recstatus = True Then
            lblerr.Text = "Congrats! Jobcode Saved successfully"
            Dim i As Integer = 0

            For i = 0 To cbtechnical.Items.Count - 1
                If cbtechnical.Items(i).Selected Then
                    Inserttechskill(txtcode.Text.Trim, cbtechnical.Items(i).Value)
                End If
            Next

            For j = 0 To cbbehaviour.Items.Count - 1
                If cbbehaviour.Items(j).Selected Then
                    InsertBehavior(txtcode.Text.Trim, cbbehaviour.Items(j).Value)
                End If
            Next
            txtcode.Text = ""
        Else
            lblerr.Text = "Error!!Record not saved"
        End If
    End Sub

    Protected Sub ddldept_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldept.SelectedIndexChanged
        If dept <> "-1" And desig <> "-1" Then
            chkcodeAvail(dept, desig)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    txtcode.Text = dr("jobcode").ToString
                    lblerr.Text = "Warning!!! REcord already Exist !if you want to Edit,modify jobcode and click save.It will overwrite existing jobcode" & "(" & txtcode.Text.Trim & ") for the selected dept & designation"""
                    Dim dst As New DataSet
                    Dim dsb As DataSet

                    Dim drt As DataRow
                    Dim drb As DataRow
                    Dim i, k
                    dst = GetSkillset("Behavior", txtcode.Text.Trim)
                    Dim lintrowcount, rc
                    If dst.Tables(0).Rows.Count <> 0 Then
                        lintrowcount = dst.Tables(0).Rows.Count
                        For k = 0 To lintrowcount - 1
                            drt = dst.Tables(0).Rows(k)
                            For i = 0 To cbbehaviour.Items.Count - 1
                                If drt("skill").ToString = cbbehaviour.Items(i).Value Then
                                    cbbehaviour.Items(i).Selected = True
                                End If
                            Next
                        Next
                    End If

                    Dim j, l
                    dsb = GetSkillset2("Technical Skill", txtcode.Text.Trim)

                    If dsb.Tables(0).Rows.Count <> 0 Then
                        rc = dsb.Tables(0).Rows.Count
                        For l = 0 To rc - 1
                            drb = dsb.Tables(0).Rows(l)
                            For j = 0 To cbtechnical.Items.Count - 1
                                If drb("skill").ToString = cbtechnical.Items(j).Value Then
                                    cbtechnical.Items(j).Selected = True
                                End If
                            Next
                        Next
                    End If

                Else
                    lblerr.Text = ""
                    txtcode.Text = ""
                End If
            Else
                lblerr.Text = ""
                txtcode.Text = ""
            End If
        End If
    End Sub
    Function GetSkillset(ByVal skill As String, ByVal jcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim dst As New DataSet

        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select skill from man_skillmatch where skilltitle='" & skill & "' and jobcode = '" & jcode & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(dst, "JS")
        con.Close()
        Return dst
    End Function
    Function GetSkillset2(ByVal skill As String, ByVal jcode As String) As DataSet
        MyGlobal.Con_Str()
        Dim dsb As New DataSet
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select skill from man_skillmatch where skilltitle='" & skill & "' and jobcode = '" & jcode & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(dsb, "JS2")
        con.Close()
        Return dsb
    End Function

    Protected Sub ddldesig_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ddldesig.SelectedIndexChanged
        If dept <> "-1" And desig <> "-1" Then
            chkcodeAvail(dept, desig)
            If recstatus = True Then
                Dim dr As DataRow
                If dsdata.Tables(0).Rows.Count > 0 Then
                    dr = dsdata.Tables(0).Rows(0)
                    txtcode.Text = dr("jobcode").ToString
                    lblerr.Text = "Warning!!! REcord already Exist !if you want to Edit,modify jobcode and click save.It will overwrite existing jobcode" & "(" & txtcode.Text.Trim & ") for the selected dept & designation"""

                    Dim dst As New DataSet
                    Dim dsb As DataSet

                    Dim drt As DataRow
                    Dim drb As DataRow
                    Dim i, k
                    dst = GetSkillset("Behavior", txtcode.Text.Trim)
                    Dim lintrowcount, rc
                    If dst.Tables(0).Rows.Count <> 0 Then
                        lintrowcount = dst.Tables(0).Rows.Count
                        For k = 0 To lintrowcount - 1
                            drt = dst.Tables(0).Rows(k)
                            For i = 0 To cbbehaviour.Items.Count - 1
                                If drt("skill").ToString = cbbehaviour.Items(i).Value Then
                                    cbbehaviour.Items(i).Selected = True
                                End If
                            Next
                        Next
                    End If

                    Dim j, l
                    dsb = GetSkillset2("Technical Skill", txtcode.Text.Trim)

                    If dsb.Tables(0).Rows.Count <> 0 Then
                        rc = dsb.Tables(0).Rows.Count
                        For l = 0 To rc - 1
                            drb = dsb.Tables(0).Rows(l)
                            For j = 0 To cbtechnical.Items.Count - 1
                                If drb("skill").ToString = cbtechnical.Items(j).Value Then
                                    cbtechnical.Items(j).Selected = True
                                End If
                            Next
                        Next
                    End If
                Else
                    lblerr.Text = ""
                    txtcode.Text = ""
                End If
             Else
                lblerr.Text = ""
                txtcode.Text = ""
            End If
        End If
    End Sub

End Class
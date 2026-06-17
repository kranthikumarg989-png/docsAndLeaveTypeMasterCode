Imports System.Data.SqlClient
Imports System.Data
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Image
Imports System.IO.Stream
Imports System.Collections
Imports System.ComponentModel
Imports System.Web
Imports System.Web.SessionState
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports E_Management.crmlognetglobal
Imports System.Web.Security


Partial Public Class CustomerVisitApprovalForm
    Inherits Messagebox
    Dim TmpDs As New DataSet
    Dim mynet As New CRMlognetglobal
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If IsPostBack = False Then

                
                mynet.db_cn()
                mynet.db_open()


                TmpDs = New DataSet()
                TmpDs = mynet.SelectPendingCVForm(mynet.sConnString2)
                GridView1.DataSource = TmpDs.Tables(0)
                GridView1.DataBind()


                TmpDs = New DataSet()
                TmpDs = mynet.SelectCVApprovedDetails(mynet.sConnString2)
                GridView2.DataSource = TmpDs.Tables(0)
                GridView2.DataBind()


                TmpDs = New DataSet()
                TmpDs = mynet.SelectCVAccessRights(mynet.sConnString2, Session("empcode").ToString())

                If TmpDs.Tables(0).Rows.Count >= 1 Then
                    For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                        If TmpDs.Tables(0).Rows(0).Item(3) = "TM" Then
                            Label1.Visible = True
                            GridView1.Visible = True
                            Exit For
                        End If
                    Next
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub




    Sub Fun1(ByVal sender As Object, ByVal e As EventArgs)

        Dim row As GridViewRow = GridView1.SelectedRow

        TmpDs = New DataSet()
        TmpDs = mynet.SelectCVAccessRights(mynet.sConnString2, Session("empcode").ToString())

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            Session("cvrights") = ""
            For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                If TmpDs.Tables(0).Rows(0).Item(3) = "TM" Then

                    Session("cvrights") = TmpDs.Tables(0).Rows(0).Item(3)

                    Session("cvrefno") = row.Cells(0).Text

                    Session("btncaption") = "Approve"

                    Response.Redirect("CustomerVisitPreparationForm.aspx")

                ElseIf Tmpi = TmpDs.Tables(0).Rows.Count - 1 Then
                    msg("Approval can be done only by Top Management!")
                End If
            Next
        Else
            msg("You dont have access rights to approve customer visit!")
        End If
    End Sub



    Sub Fun2(ByVal sender As Object, ByVal e As EventArgs)

        Dim row As GridViewRow = GridView2.SelectedRow

        TmpDs = New DataSet()
        TmpDs = mynet.SelectCVAccessRights(mynet.sConnString2, Session("empcode").ToString())

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            Session("cvrights") = ""
            For Tmpi As Integer = 0 To TmpDs.Tables(0).Rows.Count - 1
                Session("cvrights") = Session("cvrights") & TmpDs.Tables(0).Rows(0).Item(3) & ","
                Session("cvrefno") = row.Cells(0).Text
            Next

            Session("btncaption") = "Acknowledge"


            Response.Redirect("CustomerVisitPreparationForm.aspx")

        Else
            msg("You dont have access rights to approve customer visit!")
        End If
    End Sub

    Sub FunEdit(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Session("reprefno") = GridView1.Rows(e.NewEditIndex).Cells(0).Text()
        Response.Redirect("CustomerVisitReport.aspx")
    End Sub

    Sub FunEdit2(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        Session("reprefno") = GridView2.Rows(e.NewEditIndex).Cells(0).Text()
        Response.Redirect("CustomerVisitReport.aspx")
    End Sub

End Class
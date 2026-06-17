Imports System.Data
Imports System.Web.Security
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO.Path
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Partial Public Class BTCVform
    Inherits System.Web.UI.Page
    Dim MyGlobal As New emanagement.globalinfo
    Dim MyApp As New emanagement.EMSapplications

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      

     

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (49)
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
        If Request.QueryString("rno") <> "" Then
            Label3.Text = Request.QueryString("rno")
            FileUploadcontrol.Visible = True
            btnupload.Visible = True
            Label3.Visible = True
            Label5.Visible = True
            Label2.Visible = True
        Else
            FileUploadcontrol.Visible = False
            btnupload.Visible = False
            Label3.Visible = False
            Label5.Visible = False
            Label2.Visible = False
        End If

    End Sub
    Public Sub UpdateCV(ByVal sender As Object, ByVal e As EventArgs)
        For i As Integer = 0 To GridView2.Rows.Count - 1
            Dim rno As String = GridView2.Rows(i).Cells(1).Text
            Dim details As String = DirectCast(GridView2.Rows(i).FindControl("textbox4"), TextBox).Text
            Dim participants As String = DirectCast(GridView2.Rows(i).FindControl("textbox3"), TextBox).Text
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            DS = Open_BT(Con, DAP, 2, "update HRMIS_BT_CUSTOMERVISITDETAILS set partipiciants = '" & participants & "' , details = '" & details & "'  where rno = '" & rno & "'")
            MyGlobal.db_close()
        Next
        GridView2.DataBind()
    End Sub

    Protected Sub btnupload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnupload.Click

        If FileUploadcontrol.HasFile Then
            Try
                Dim filename As String = FileUploadcontrol.PostedFile.FileName
                Dim ext As String = System.IO.Path.GetExtension(FileUploadcontrol.PostedFile.FileName)
                Dim Myfile As String = Label3.Text.Trim & ext
                Dim myfilefullpath As String = Server.MapPath("~/cvreport/" & Myfile)
                '  FileUploadcontrol.SaveAs("~/CVreport/" & Myfile)
                FileUploadcontrol.SaveAs(myfilefullpath)
                statuslabel.Text = "Upload status: File uploaded!"
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                DS = Open_BT(Con, DAP, 2, "update acc_businesstrip set rptname = '" & Myfile & "' , cvrpt = 'Y'  where recno = '" & Label3.Text & "'")
                MyGlobal.db_close()
            Catch ex As Exception
                statuslabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message
            End Try
        End If
    End Sub
End Class
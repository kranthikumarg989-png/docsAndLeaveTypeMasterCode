Imports System
Imports System.Data
Imports System.IO
Imports System.Data.SqlClient
Partial Public Class Letter_pre1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim cmg, er As Char
        HtmlEditor1.Text.Replace(cmg, er)
    End Sub

    Protected Sub EditHtml_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditHtml.Click
        Dim filePath As String = "C:/Users/Administrator/Desktop/E-Management/CMG_MASTER_LETTERS/appointment_unsucREV0.html"
        Dim objStreamReader As StreamReader
        objStreamReader = File.OpenText(filePath)
        Dim contents As String = objStreamReader.ReadToEnd()
        HtmlEditor1.Text = contents
        objStreamReader.Close()
        Dim s = Name.Text
        Dim s1 = EmpNo.Text
        Dim s2 = Department.Text
        Dim s3 = Designation.Text
        Dim s4 = Nomonths.Text
        Dim s5 = Probationperiod.Text
        Dim s6 = Issuedate.Text
        'Dim c
        If HtmlEditor1.Text.Contains("CMG.NAME") = True Then
            HtmlEditor1.Text = HtmlEditor1.Text.Replace("CMG.NAME", s)
        End If

        If HtmlEditor1.Text.Contains("CMG.EMPNO") = True Then

            HtmlEditor1.Text = HtmlEditor1.Text.Replace("CMG.EMPNO", s1)
        End If

        If HtmlEditor1.Text.Contains("CMG.DEPARTMENT") = True Then
            HtmlEditor1.Text = HtmlEditor1.Text.Replace("CMG.DEPARTMENT", s2)
        End If

        If HtmlEditor1.Text.Contains("CMG.DESIGNATION") = True Then
            HtmlEditor1.Text = HtmlEditor1.Text.Replace("CMG.DESIGNATION", s3)
        End If

        If HtmlEditor1.Text.Contains("CMG.NOMONTHS") = True Then
            HtmlEditor1.Text = HtmlEditor1.Text.Replace("CMG.NOMONTHS", s4)
        End If

        If HtmlEditor1.Text.Contains("CMG.PROBATIONPERIOD") = True Then
            HtmlEditor1.Text = HtmlEditor1.Text.Replace("CMG.PROBATIONPERIOD", s5)
        End If

        If HtmlEditor1.Text.Contains("CMG.LETTERDATE") = True Then
            HtmlEditor1.Text = HtmlEditor1.Text.Replace("CMG.LETTERDATE", s6)
        End If
        ' Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.HtmlEditor1.HtmlModeEditable = False
        Me.HtmlEditor1.DesignModeEditable = False

    End Sub
    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'WriteToFile(Server.MapPath("~/refers/TextFile.txt"), HtmlEditor1.Text)
        Dim objSW As StreamWriter
        Dim objFS As FileStream
        Dim s1 = EmpNo.Text
        objFS = New FileStream("C:/Users/Administrator/Desktop/CMG_LETTERS/Appointment Letter_" + s1 + ".html", FileMode.Create)
        ' app.activeDocumen.exportFile(ExportFormat.JPG,personName+".JPEG"); 
        objSW = New StreamWriter(objFS)
        objSW.Write(HtmlEditor1.Text)

        MessageBox("Letter Created Successfully")
        HtmlEditor1.Text = ""
        Name.Text = ""
        EmpNo.Text = ""
        Department.Text = ""
        Designation.Text = ""
        Nomonths.Text = ""
        Probationperiod.Text = ""
        Issuedate.Text = ""
        objSW.Close()
        objFS.Close()

    End Sub


    
End Class
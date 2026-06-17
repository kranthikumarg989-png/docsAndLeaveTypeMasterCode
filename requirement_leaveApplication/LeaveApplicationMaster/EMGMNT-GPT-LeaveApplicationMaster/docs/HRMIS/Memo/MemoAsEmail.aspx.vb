Imports System.Net.Mail
Imports System.Threading
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports E_Management.Emanagement.netglobal

Partial Public Class MemoAsEmail
    Inherits System.Web.UI.Page
    Dim constr As String = "Data Source=192.168.0.241;Initial Catalog=hrmis;uid=sa;"
    Dim MyGlobal As New Emanagement.globalinfo
    Dim GlblInt As Integer



    Function CallSP(ByVal Options As String, ByVal MemoId As Integer, ByVal Designation As String, ByVal EmpCode As String, ByVal EmpName As String, ByVal EMAilSendBy As String) As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        Try
            con.Open()
            Dim Command As New SqlCommand
            Command = New SqlCommand("SP_Memo_Rev1", con)
            Command.CommandType = CommandType.StoredProcedure
            Command.Parameters.AddWithValue("@Options", Options)
            Command.Parameters.AddWithValue("@MemoId", MemoId)
            Command.Parameters.AddWithValue("@Designation", Designation)
            Command.Parameters.AddWithValue("@EmpCode", EmpCode)
            Command.Parameters.AddWithValue("@EmpName", EmpName)
            Command.Parameters.AddWithValue("@EMailSendBy", EMAilSendBy)
            Dim DataAdap = New SqlDataAdapter(Command)
            DataAdap.Fill(ds, "tbl_Addmtbl")
            con.Close()
            Return ds

        Catch ex As Exception
            con.Close()
        End Try
    End Function

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        '' check access rights 
        If Session("empcode") <> "" Or Len(Session("empcode")) <> 0 Then
            MyScreenId = (575)
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

        If IsPostBack = False Then
            Dim Ds As New DataSet
            Ds = New DataSet
            Ds = CallSP("DistinctID", 0, "-", 0, 0, 0)
            CmbMemo.DataTextField = "MemoId"
            CmbMemo.DataValueField = "MemoId"
            CmbMemo.DataSource = Ds.Tables(0)
            CmbMemo.DataBind()

            Ds = New DataSet
            Ds = CallSP("DistinctDesignation", 0, "-", 0, 0, 0)
            CmbDesignation.DataTextField = "Designation"
            CmbDesignation.DataValueField = "Designation"
            CmbDesignation.DataSource = Ds.Tables(0)
            CmbDesignation.DataBind()

            Ds = New DataSet
            Ds = CallSP("GridData", 0, 0, 0, 0, 0)

            GridView1.DataSource = Ds.Tables(0)
            GridView1.DataBind()

        End If
    End Sub

    Protected Sub CmbMemo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbMemo.SelectedIndexChanged
       

    End Sub

    Protected Sub BtnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSend.Click
        BtnSend.Enabled = False



        GridView1.DataSource = Nothing
        GridView1.DataBind()

        LblMsg.BackColor = Drawing.Color.Green
        LblMsg.ForeColor = Drawing.Color.Yellow

        Dim GlblDst As New DataSet

        GlblDst = New DataSet
        GlblDst = CallSP("Email", 0, CmbDesignation.SelectedItem.Text, 0, 0, 0)

        LblMsg.Text = "Sending eMail.. Please wait.."
        GlblInt = 0

        For Tmpi As Integer = 0 To GlblDst.Tables(0).Rows.Count - 1
            CallSP("Insert", CmbMemo.SelectedItem.Text, CmbDesignation.SelectedItem.Text, GlblDst.Tables(0).Rows(Tmpi).Item(1).ToString, GlblDst.Tables(0).Rows(Tmpi).Item(2).ToString, Session("empcode"))
            SendSMTP(GlblDst.Tables(0).Rows(Tmpi).Item(0).ToString)
            System.Threading.Thread.Sleep(5000)
        Next

       
        LblMsg.Text = "Mail has been sent!"

        Dim Ds As New DataSet
        Ds = CallSP("GridData", 0, 0, 0, 0, 0)
        GridView1.DataSource = Ds.Tables(0)
        GridView1.DataBind()

        BtnSend.Enabled = True

    End Sub

    Public Sub SendSMTP(ByVal ToAddr As String)
        Dim insMail As New MailMessage()
        Try
            Dim Ds1 As New DataSet
            Ds1 = New DataSet
            Ds1 = CallSP("MemoData", CmbMemo.SelectedItem.Text, "-", 0, 0, 0)


            Dim Str As New StringBuilder()

            'Str.AppendLine("<HTML><BODY><CENTER>MEMO</CENTER><BR/><BR/><BR/><Table Cellpadding=1 CellSpacing=1><Tr>")
            'Str.AppendLine("<TD><b>SL NO: <b></Td><Td>" + Ds1.Tables(0).Rows(0).Item(0).ToString + "</Td></Tr><Tr>")
            'Str.AppendLine("<TD><b>Date:</b></Td><Td>" + Ds1.Tables(0).Rows(0).Item(5).ToString + "</Td></Tr><Tr>")
            'Str.AppendLine("<TD><b>Issued By:</b></Td><Td>" + Ds1.Tables(0).Rows(0).Item(1).ToString + "-" + Ds1.Tables(0).Rows(0).Item(2).ToString + "</Td></Tr><Tr>")
            'Str.AppendLine("<TD><b>Dept Issue:</b></Td><Td>" + Ds1.Tables(0).Rows(0).Item(3).ToString + "</Td></Tr><Tr>")
            'Str.AppendLine("<TD><b>To Dept:</b></Td><Td>" + Ds1.Tables(0).Rows(0).Item(6).ToString + "</Td></Tr><Tr>")

            'Str.AppendLine("<TD><b>Subject:</Td><Td>" + Ds1.Tables(0).Rows(0).Item(4).ToString + "</b></Td></Tr></Table><Br/><Br/>")

            'Str.AppendLine(Ds1.Tables(0).Rows(0).Item(9).ToString + "<BR/>")
            'Str.AppendLine(Ds1.Tables(0).Rows(0).Item(10).ToString + "<BR/>")
            'Str.AppendLine(Ds1.Tables(0).Rows(0).Item(11).ToString + "<BR/><BR/>")

            'Str.AppendLine("<Table Cellpadding=1 CellSpacing=1><Tr><Td>Approved By</Td><Td>Signature</Td><Tr>")
            'Str.AppendLine("<Td>" + Ds1.Tables(0).Rows(0).Item(12).ToString + "</Td>")
            'Str.AppendLine("<Td>" + Ds1.Tables(0).Rows(0).Item(8).ToString + "</Td>")
            'Str.AppendLine("<Tr><Td>Approved Date & Time</Td><Td>Current Date & Time</Td></Tr>")
            'Str.AppendLine("<Tr><Td>Date:" + Ds1.Tables(0).Rows(0).Item(13).ToString + "  " + Ds1.Tables(0).Rows(0).Item(14).ToString + "</Td><Td> Date:" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss") + "</Td></Tr></Table>")

            Str.AppendLine("                                      MEMO" & vbCrLf & vbCrLf)
            Str.AppendLine("SL NO: " + Ds1.Tables(0).Rows(0).Item(0).ToString & vbCrLf)
            Str.AppendLine("Date:" + Ds1.Tables(0).Rows(0).Item(5).ToString.Substring(0, 10) & vbCrLf)
            Str.AppendLine("Issued By:" + Ds1.Tables(0).Rows(0).Item(1).ToString + "-" + Ds1.Tables(0).Rows(0).Item(2).ToString & vbCrLf)
            Str.AppendLine("Dept Issue:" + Ds1.Tables(0).Rows(0).Item(3).ToString & vbCrLf)
            Str.AppendLine("To Dept:" + Ds1.Tables(0).Rows(0).Item(6).ToString & vbCrLf)

            Str.AppendLine("Subject:" + Ds1.Tables(0).Rows(0).Item(4).ToString & vbCrLf)

            Str.AppendLine(Ds1.Tables(0).Rows(0).Item(9).ToString & vbCrLf)
            Str.AppendLine(Ds1.Tables(0).Rows(0).Item(10).ToString & vbCrLf)
            Str.AppendLine(Ds1.Tables(0).Rows(0).Item(11).ToString & vbCrLf)

            Str.AppendLine("Approved By " & vbCrLf)
            Str.AppendLine(Ds1.Tables(0).Rows(0).Item(12).ToString & vbCrLf & vbCrLf)
            Str.AppendLine("Signature" & vbCrLf)
            Str.AppendLine(Ds1.Tables(0).Rows(0).Item(8).ToString & vbCrLf & vbCrLf)
            Str.AppendLine("Approved Date & Time: " & vbCrLf)
            Str.AppendLine("Date:" + Ds1.Tables(0).Rows(0).Item(13).ToString.Substring(0, 10) + " " + Ds1.Tables(0).Rows(0).Item(14).ToString.Substring(11) & vbCrLf & vbCrLf)
            Str.AppendLine("Current Date & Time")
            Str.AppendLine("Date:" + DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss"))
            'MessageBox(Str.ToString)





            insMail.From = New MailAddress("dashboard@maruwa.com.my")


            With insMail
                .Subject = "MEMO NO:." + Ds1.Tables(0).Rows(0).Item(0).ToString + " : " + Ds1.Tables(0).Rows(0).Item(4).ToString
                .Body = Str.ToString
            End With

            'insMail.Priority = MailPriority.Normal

            Dim smtp As New System.Net.Mail.SmtpClient
            'smtp.Host = "58.26.100.35"
            smtp.Host = "172.16.0.11"
            smtp.Port = 25

            'For Tmpi As Integer = 0 To Ds1.Tables(0).Rows.Count - 1
            '    insMail.To.Add(Ds1.Tables(0).Rows(Tmpi).Item(0))
            '    smtp.Send(insMail)
            'Next


            insMail.To.Add(ToAddr)
            smtp.Send(insMail)


            insMail.Dispose()


        Catch err As Exception
            insMail.Dispose()
            'MsgBox(err.Message)
        End Try
    End Sub

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    

    
    Protected Sub CmbDesignation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbDesignation.SelectedIndexChanged

    End Sub
End Class
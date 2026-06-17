Imports System.Data
Imports System
Imports System.Globalization
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications
Imports e_management.emanagement.NetGlobal
Partial Public Class OnlineMeeting
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        MyGlobal.Open_Con()
        MyGlobal.Con_Str()
        txtboxmessage.Focus()
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtboxmessage.Text.Trim.Equals("") Then
            LblMsg.Text = "Please enter valid message!"
            Exit Sub
        End If
        If C1.Checked = True Then
            FUN1("+60176065022")
            '            FUN1("+601116666543")
        End If

        If C2.Checked = True Then
            FUN1("+60126065119")
            '            FUN1("+601116666543")
        End If

        If C3.Checked = True Then
            FUN1("+60126976503")
        End If

        If C4.Checked = True Then
            FUN1("+60126382010")
        End If

        If C5.Checked = True Then
            FUN1("+60169323802")
        End If

        If C6.Checked = True Then
            FUN1("+60126811551")
        End If

        If C7.Checked = True Then
            FUN1("+60169963186")
        End If

        If C8.Checked = True Then
            FUN1("+60132014398")
        End If

        If C9.Checked = True Then
            FUN1("+60167017782")
        End If

        If C10.Checked = True Then
            FUN1("+60126088322")
        End If

        If C11.Checked = True Then
            FUN1("+60126826800")
        End If

        If C12.Checked = True Then
            FUN1("+60164959644")
        End If

        If C13.Checked = True Then
            FUN1("+60126352411")
        End If

        If C14.Checked = True Then
            FUN1("+60126016430")
        End If

        If C15.Checked = True Then
            FUN1("+60122116951")
        End If

        If C16.Checked = True Then
            FUN1("+60172118405")
        End If

        If C17.Checked = True Then
            FUN1("+60189094637")
        End If

        If C18.Checked = True Then
            FUN1("+60136374393")
        End If

        If C19.Checked = True Then
            FUN1("+60172406617")
        End If

        If C20.Checked = True Then
            FUN1("+60126811002")
        End If

        If C21.Checked = True Then
            FUN1("+60126117400")
        End If

        If C22.Checked = True Then
            FUN1("+60126037007")
        End If

        If C23.Checked = True Then
            FUN1("+60176987476")
        End If

        If C24.Checked = True Then
            FUN1("+60102549311")
        End If


        If C25.Checked = True Then
            FUN1("+819067637297")
        End If

        If C26.Checked = True Then
            FUN1("+819039557403")
        End If

        If C27.Checked = True Then
            FUN1("+819091815366")
        End If

        If C28.Checked = True Then
            FUN1("+886910120574")
        End If

        If C29.Checked = True Then
            FUN1("+8613817978208")
        End If

        If C30.Checked = True Then
            FUN1("+8613816848205")
        End If

        If C31.Checked = True Then
            FUN1("+818026408370")
        End If

        If C32.Checked = True Then
            FUN1("+818015958504")
        End If


        If C33.Checked = True Then
            FUN1("+819058659031")
        End If

        If C34.Checked = True Then
            'FUN1("+818015958504")
        End If

        If C35.Checked = True Then
            FUN1("+819024081134")
        End If

        If C36.Checked = True Then
            FUN1("+818010786781")
        End If

        If C37.Checked = True Then
            FUN1("+819071730226")
        End If

        If C38.Checked = True Then
            FUN1("+819024079192")
        End If

        If C39.Checked = True Then
            FUN1("+819085714857")
        End If

        If C40.Checked = True Then
            FUN1("+819071646208")
        End If

        If C41.Checked = True Then
            FUN1("+819054554815")
        End If

        If C42.Checked = True Then
            FUN1("+819078700784")
        End If

        If C43.Checked = True Then
            FUN1("+818025255055")
        End If

        If C44.Checked = True Then
            FUN1("+818020910441")
        End If

        If C45.Checked = True Then
            FUN1("+819014161552")
        End If

        If C46.Checked = True Then
            'FUN1("+")
        End If

        If C47.Checked = True Then
            'FUN1("+")
        End If

        If C48.Checked = True Then
            'FUN1("+")
        End If

        If C49.Checked = True Then
            'FUN1("+")
        End If

        If C50.Checked = True Then
            FUN1("+819067637297")
        End If

        LblMsg.Text = "SMS successfully sent!"
        txtboxmessage.Text = ""
        txtboxmessage.Focus()

    End Sub


    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim mynet As New Emanagement.netglobal

    Private Sub FUN1(ByVal MobileNo As String)
        Try
            mynet.db_cn()
            mynet.dbSMS_open()
            Call mynet.dbSpSMS_open("insert_outgoing_2")
            command.Parameters.AddWithValue("@number_2", mobileno)
            command.Parameters.AddWithValue("@message_3", Trim(txtboxmessage.Text))
            command.Parameters.AddWithValue("@starttime_4", CStr(Now))
            command.Parameters.AddWithValue("@endtime_5", CStr(Now))
            command.Parameters.AddWithValue("@fkey_6", " ")
            command.Parameters.AddWithValue("@priority", "15")
            command.ExecuteNonQuery()
            mynet.dbSMS_close()
            LblMsg.Text = "Congratulations! You have Saved successfully. "
            LblMsg.ForeColor = Drawing.Color.DarkGreen
        Catch ex As Exception
            LblMsg.Text = ex.Message
            LblMsg.ForeColor = Drawing.Color.Red
        End Try
    End Sub

    
    Protected Sub SA1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SA1.CheckedChanged
        If SA1.Checked = True Then
            C1.Checked = True
            C2.Checked = True
            C3.Checked = True
            C4.Checked = True
            C5.Checked = True
            C6.Checked = True
            C7.Checked = True
            C8.Checked = True
            C9.Checked = True
            C10.Checked = True
            C11.Checked = True
            C12.Checked = True
            C13.Checked = True
            C14.Checked = True
            C15.Checked = True
            C16.Checked = True
            C17.Checked = True
            C18.Checked = True
            C19.Checked = True
            C20.Checked = True
            C21.Checked = True
            C22.Checked = True
            C23.Checked = True
            C24.Checked = True
        Else
            C1.Checked = False
            C2.Checked = True
            C3.Checked = True
            C4.Checked = True
            C5.Checked = True
            C6.Checked = False
            C7.Checked = False
            C8.Checked = False
            C9.Checked = False
            C10.Checked = False
            C11.Checked = False
            C12.Checked = False
            C13.Checked = False
            C14.Checked = False
            C15.Checked = False
            C16.Checked = False
            C17.Checked = False
            C18.Checked = False
            C19.Checked = False
            C20.Checked = False
            C21.Checked = False
            C22.Checked = False
            C23.Checked = False
            C24.Checked = False
        End If
    End Sub

    Protected Sub SA2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SA2.CheckedChanged
        If SA2.Checked = True Then
            C25.Checked = True
            C26.Checked = True
            C27.Checked = True
        Else
            C25.Checked = False
            C26.Checked = False
            C27.Checked = False
        End If
    End Sub


    Protected Sub SA3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SA3.CheckedChanged
        If SA3.Checked = True Then
            C28.Checked = True
            C29.Checked = True
            C30.Checked = True
            C31.Checked = True
            C32.Checked = True

        Else
            C28.Checked = False
            C29.Checked = False
            C30.Checked = False
            C31.Checked = False
            C32.Checked = False

        End If
    End Sub

    Protected Sub SA4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SA4.CheckedChanged
        If SA4.Checked = True Then
            C33.Checked = True
            C34.Checked = True
            C35.Checked = True
            C36.Checked = True
            C37.Checked = True
            C38.Checked = True
            C39.Checked = True
            C40.Checked = True
            C41.Checked = True
            C42.Checked = True
            C43.Checked = True
            C44.Checked = True
            C45.Checked = True
            C46.Checked = True
            C47.Checked = True
            C48.Checked = True
            C49.Checked = True
            C50.Checked = True
        Else
            C33.Checked = False
            C34.Checked = False
            C35.Checked = False
            C36.Checked = False
            C37.Checked = False
            C38.Checked = False
            C39.Checked = False
            C40.Checked = False
            C41.Checked = False
            C42.Checked = False
            C43.Checked = False
            C44.Checked = False
            C45.Checked = False
            C46.Checked = False
            C47.Checked = False
            C48.Checked = False
            C49.Checked = False
            C50.Checked = False
        End If
    End Sub
End Class
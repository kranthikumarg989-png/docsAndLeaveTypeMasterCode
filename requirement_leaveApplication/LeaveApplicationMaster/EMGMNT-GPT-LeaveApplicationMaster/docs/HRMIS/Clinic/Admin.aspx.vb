Imports System.Data
Imports System
Imports System.Data.SqlClient
Imports E_Management.emanagement.globalinfo
Imports E_Management.emanagement.EMSapplications


Partial Public Class Admin
    Inherits System.Web.UI.Page
    Dim MyGlobal As New Emanagement.globalinfo
    Dim MyApp As New Emanagement.EMSapplications
    Dim thisdate As Date
    Dim appno As String

    Private Sub Admin_Init(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
      
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If IsPostBack = False Then
            MyGlobal.Open_Con()
            MyGlobal.Con_Str()
            GetREcMedical()
            LBLPASS.Text = posid
        End If

        Dim TmpDs As New DataSet


        If IsPostBack = False Then
            TmpDs = New DataSet()
            TmpDs = SP_Fun1("EmpCode", DateTime.Now, DateTime.Now, "-", "-", "-")
            'Lbl1.Text = TmpDs.Tables(0).Rows.Count
            DDLEmpcode.DataSource = TmpDs.Tables(0)
            DDLEmpcode.DataValueField = "EmpCode"
            DDLEmpcode.DataTextField = "EmpName"
            DDLEmpcode.DataBind()
            DDLEmpcode.Items.Insert(0, "-Select-")

            TmpDs = New DataSet()
            TmpDs = CallSP("ClinicName", "")
            'Lbl1.Text = TmpDs.Tables(0).Rows.Count
            DDLClinicName.DataSource = TmpDs.Tables(0)
            DDLClinicName.DataValueField = "ClinicName"
            DDLClinicName.DataTextField = "ClinicName"
            DDLClinicName.DataBind()
            DDLClinicName.Items.Insert(0, "-Select-")

            thisdate = DateTime.Now.ToShortDateString()

            MyApp.GetfiscalYearforLeave()
          


            Dim clinicnum As String

       
            If Session("cliniceditnum") <> "0" Then
                clinicnum = Session("cliniceditnum")
                editclinic(clinicnum)
            Else
                clinicnum = "0"

            End If

            If (Session("cltype") = "NoEntry") Then
                DDLEmpcode.Enabled = True
                CmbReason.Enabled = True

                DDLEmpcode.Visible = True
                CmbReason.Visible = True

                LblAppliedDate.Visible = True

                TxtAppliedOn.Visible = True

                Try
                    GetMedicalReason()
                    If recstatus = True Then
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            CmbReason.DataSource = dsdata.Tables(0)
                            CmbReason.DataTextField = "Reason"
                            CmbReason.DataValueField = "Reason"
                            CmbReason.DataBind()
                            CmbReason.Items.Insert(0, "-Select-")
                        End If
                    End If
                Catch ex As Exception
                    MessageBox(ex.ToString)

                End Try
            Else
                DDLEmpcode.Visible = False
                CmbReason.Visible = False
                DDLEmpcode.Enabled = False
                CmbReason.Enabled = False
                LblAppliedDate.Visible = False
                TxtOthers.Visible = False
                TxtAppliedOn.Visible = False

            End If

        End If

    End Sub

    Public Shared Function GetMedicalReason() As DataSet
        Try
            dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "SP_HRMIS_MedicalReason", "-")
            recstatus = True
        Catch ex As Exception
            recstatus = False
            MyerrorMsg = ex.Message
        End Try
        Return dsdata
    End Function

    Private Sub MessageBox(ByVal msg As String)
        Dim lbl As New Label()
        lbl.Text = "<script language='javascript'> window.alert('" + msg + "')</script>"
        Page.Controls.Add(lbl)
    End Sub

    Protected Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click



        Dim mc
        mc = rdomc.SelectedValue
        Dim xceed As Decimal
        xceed = 0
        If txtcost.Text > lblbal.Text Then
            xceed = txtcost.Text - lblbal.Text
        End If

        If txtempcode.Text = "" Or txtempcode.Text = "-Select-" Then
            MessageBox("Please select employee name!")
            Exit Sub
        End If

        If txtsymptom.Text = "" Then
            MessageBox("Please key in symptoms!'")
            Exit Sub
        End If

        If DDLClinicName.Text = "" Or DDLClinicName.Text = "-Select-" Then
            MessageBox("Please selecct the clinic name!")
            Exit Sub
        End If

        If lbldate.Text = "" Then
            MessageBox("Please select visit date!")
            Exit Sub
        End If

        If TxtBillNo.Text.Trim.Equals("") Then
            MessageBox("Please key in bill number!")
            Exit Sub
        End If

        Dim TmpDs As New DataSet

        TmpDs = CallSP(DDLClinicName.Text, TxtBillNo.Text)

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            MessageBox("Bill number already exists!")
            Exit Sub
        End If

        If mc = "Y" Then
            If txtfrom.Text = "" Or txtto.Text = "" Or txtdays.Text = "" Then
                MessageBox("Please key in Mc details")
                Exit Sub
            End If

            Dim fd1 As String
            fd1 = txtfrom.Text.Trim
            Dim strdate() As String = fd1.Split("/"c)
            fd1 = strdate(1) & "/" & strdate(0) & "/" & strdate(2)

            Dim fd As Date
            fd = CDate(fd1)

            Dim td1 As String
            td1 = txtto.Text.Trim
            Dim strdate2() As String = td1.Split("/"c)
            td1 = strdate2(1) & "/" & strdate2(0) & "/" & strdate2(2)

            Dim td As Date
            td = CDate(td1)
        

            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("InsTreatmententrywithMC")

                Cmd.Parameters.AddWithValue("@rno", LBLPASS.Text)
                Cmd.Parameters.AddWithValue("@emp", txtempcode.Text)
                Cmd.Parameters.AddWithValue("@bill", txtcost.Text)
                Cmd.Parameters.AddWithValue("@appdate", lbldate.Text)
                Cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text)
                Cmd.Parameters.AddWithValue("@mc", "Y")
                Cmd.Parameters.AddWithValue("@days", txtdays.Text)
                Cmd.Parameters.AddWithValue("@from", fd)
                Cmd.Parameters.AddWithValue("@to", td)
                Cmd.Parameters.AddWithValue("@exceed", xceed)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@cpass", Session("cliniceditnum"))
                Cmd.Parameters.AddWithValue("@ClinicName", DDLClinicName.Text)
                Cmd.Parameters.AddWithValue("@Flag", TxtBillNo.Text)
                Cmd.ExecuteNonQuery()
                Session("cliniceditnum") = ""
                Response.Redirect("clinicpassqueue.aspx")

            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        Else
            Try
                MyGlobal.Open_Con()
                MyGlobal.Con_Str()
                Call MyGlobal.dbSp_open("InsTreatmententrywithoutMC")
                Cmd.Parameters.AddWithValue("@rno", LBLPASS.Text)
                Cmd.Parameters.AddWithValue("@emp", txtempcode.Text)
                Cmd.Parameters.AddWithValue("@bill", txtcost.Text.Trim)
                Cmd.Parameters.AddWithValue("@appdate", lbldate.Text)
                Cmd.Parameters.AddWithValue("@remarks", txtRemarks.Text.Trim)
                Cmd.Parameters.AddWithValue("@mc", "N")
                Cmd.Parameters.AddWithValue("@exceed", xceed)
                Cmd.Parameters.AddWithValue("@keyinby", Session("empcode"))
                Cmd.Parameters.AddWithValue("@cpass", Session("cliniceditnum"))
                Cmd.Parameters.AddWithValue("@ClinicName", DDLClinicName.Text)
                Cmd.Parameters.AddWithValue("@Flag", TxtBillNo.Text)
                Cmd.ExecuteNonQuery()
                Session("cliniceditnum") = ""

                Response.Write("<script>alert('Successfully updated!')</script>")
                Response.Write("<script>window.location.href='clinicpassqueue.aspx';</script>")


            Catch ex As SqlException
                MessageBox(ex.Message)
                Exit Sub
            End Try
        End If
    End Sub
    Public Sub editclinic(ByVal passno As String)

        Try

            Dim ds As New DataSet
            Dim dr1 As DataRow

            If passno > 0 Then
                ds = GetClinicPassDetails(passno)
                If ds.Tables(0).Rows.Count <> 0 Then
                    dr1 = ds.Tables(0).Rows(0)
                    txtempcode.Text = dr1("empcode").ToString
                    txtsymptom.Text = dr1("sickness").ToString
                    lbldate.Text = dr1("dateapplied").ToString
                    GetEmpVehino(txtempcode.Text.Trim)
                    Dim dr As DataRow
                    If recstatus = True Then
                        If dsdata.Tables(0).Rows.Count > 0 Then
                            dr = dsdata.Tables(0).Rows(0)
                            txtdept.Text = dr("departmentcode") & "-" & dr("sectioncode")
                            txtempname.Text = dr("empname").ToString
                        End If
                    Else
                        lblmsg.Text = MyerrorMsg
                    End If
                End If

            End If
            Dim DsM As New DataSet
            Dim DrM As DataRow
            Dim bal As Decimal
            Dim Usedamt As Decimal

            DsM = GetBalanceAmt(txtempcode.Text.Trim)
            If DsM.Tables(0).Rows.Count <> 0 Then
                DrM = DsM.Tables(0).Rows(0)
                If Not DrM("amt") Is System.DBNull.Value Then
                    Usedamt = DrM("amt").ToString
                    If Usedamt > 150 Then
                        bal = 0
                    Else
                        bal = 150 - Usedamt
                    End If
                    lblbal.Text = Math.Round(bal, 2)
                Else
                    lblbal.Text = 150
                End If
            Else
                lblbal.Text = 150
            End If
            Dim dst As New DataSet
            Dim drt As DataRow
            If passno > 0 Then

                dst = GettreatmentDetails(passno)
                If dst.Tables(0).Rows.Count <> 0 Then
                    drt = dst.Tables(0).Rows(0)

                    txtcost.Text = drt("billamount").ToString
                    LBLPASS.Text = drt("RECORDNO").ToString
                    If Not drt("remarks") Is System.DBNull.Value Then
                        txtRemarks.Text = drt("remarks").ToString
                    End If
                    If drt("mcissued") = "Y" Then
                        txtfrom.Text = Format(Convert.ToDateTime(drt("fromdate")), "dd/MM/yy")
                        txtto.Text = Format(Convert.ToDateTime(drt("fromdate")), "dd/MM/yy")
                        txtdays.Text = drt("noofdays").ToString
                        LBLFROM.Visible = True
                        txtfrom.Visible = True
                        txtto.Visible = True
                        lblsym.Visible = True
                        txtdays.Visible = True
                        lbldays.Visible = True
                    Else
                        LBLFROM.Visible = False
                        txtfrom.Visible = False
                        txtto.Visible = False
                        lblsym.Visible = False
                        txtdays.Visible = False
                        lbldays.Visible = False

                    End If

                End If

                rdomc.SelectedValue = drt("mcissued").ToString
            End If

        Catch ex As Exception

        End Try
    End Sub
    Function GetClinicPassDetails(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from clinicstaffgatepass where passno = '" & passno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "clinic")
        con.Close()
        Return ds
    End Function
    Function GettreatmentDetails(ByVal passno As String) As DataSet
        MyGlobal.Con_Str()
        Dim dsT As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("select * from tbldiagnose where clinicpass = '" & passno & "'", con)
        Command.CommandType = CommandType.Text
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(dsT, "treatment")
        con.Close()
        Return dsT
    End Function
    Function GetBalanceAmt(ByVal empno As String) As DataSet
        MyGlobal.Con_Str()
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()

        Dim Command As New SqlCommand
        Command = New SqlCommand("sp_clinicbalamt", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@empno", empno)
        Command.Parameters.AddWithValue("@from", _fisyrStart1)
        Command.Parameters.AddWithValue("@to", _fisyrEnd1)
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbldiagnose")
        con.Close()
        Return ds
    End Function
    Protected Sub rdomc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdomc.SelectedIndexChanged
        If rdomc.SelectedValue = "Y" Then
            LBLFROM.Visible = True
            txtfrom.Visible = True
            txtto.Visible = True
            lblsym.Visible = True
            txtdays.Visible = True
            lbldays.Visible = True
        Else
            LBLFROM.Visible = False
            txtfrom.Visible = False
            txtto.Visible = False
            lblsym.Visible = False
            txtdays.Visible = False
            lbldays.Visible = False
        End If
    End Sub

    Function CallSP(ByVal Option1 As String, ByVal Option2 As String) As DataSet

        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim Command As New SqlCommand
        Command = New SqlCommand("ClinicName_SP", con)
        Command.CommandType = CommandType.StoredProcedure
        Command.Parameters.AddWithValue("@Option1", Option1)
        Command.Parameters.AddWithValue("@Option2", Option2)
        Command.Connection = con
        Dim DataAdap = New SqlDataAdapter(Command)
        DataAdap.Fill(ds, "tbl_Clinic")
        con.Close()
        Return ds
    End Function
    Public Function SP_Fun1(ByVal Options As String, ByVal Date1 As DateTime, ByVal Date2 As DateTime, ByVal DCode As String, ByVal SCode As String, ByVal Ecode As String) As DataSet
        Dim ds As New DataSet()
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim sqlcmd As New SqlCommand
        sqlcmd = New SqlCommand
        sqlCmd.CommandType = CommandType.StoredProcedure
        sqlCmd.CommandText = "SP_CanteenData"
        sqlCmd.Parameters.Clear()
        sqlCmd.Parameters.AddWithValue("@Options", Options)
        sqlCmd.Parameters.AddWithValue("@Date1", Date1)
        sqlCmd.Parameters.AddWithValue("@Date2", Date2)
        sqlCmd.Parameters.AddWithValue("@DCode", DCode)
        sqlCmd.Parameters.AddWithValue("@SCode", SCode)
        sqlcmd.Parameters.AddWithValue("@Ecode", Ecode)
        sqlcmd.Connection = con
        Dim DataAdap = New SqlDataAdapter(sqlcmd)
        DataAdap.Fill(ds, "cn1")
        con.Close()
        Return ds
    End Function

    
    Protected Sub DDLEmpcode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDLEmpcode.SelectedIndexChanged

        txtempcode.Text = DDLEmpcode.SelectedValue
        txtempname.Text = DDLEmpcode.Text
        Dim TmpDs As New DataSet
        TmpDs = New DataSet
        TmpDs = CallSP("dept", txtempcode.Text)

        If TmpDs.Tables(0).Rows.Count >= 1 Then
            txtdept.Text = TmpDs.Tables(0).Rows(0).Item(0) & "-" & TmpDs.Tables(0).Rows(0).Item(1)
        End If

        editclinic(0)

    End Sub

    Protected Sub CmbReason_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbReason.SelectedIndexChanged
        If CmbReason.Text = "Others" Then
            TxtOthers.Visible = True
            TxtOthers.Focus()
        Else
            TxtOthers.Visible = False
            txtsymptom.Text = CmbReason.Text
            txtRemarks.Text = txtsymptom.Text
        End If

    End Sub

    Protected Sub TxtOthers_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtOthers.TextChanged
        If TxtOthers.Text.Trim.Equals("") Then
            MessageBox("Please key in valid reason")
            txtsymptom.Text = ""
            Exit Sub
        End If
        txtsymptom.Text = TxtOthers.Text
        txtRemarks.Text = txtsymptom.Text
    End Sub

    Protected Sub TxtAppliedOn_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAppliedOn.TextChanged
        lbldate.Text = TxtAppliedOn.Text
    End Sub
End Class
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Configuration
Imports E_Management.Emanagement.SqlHelper
Imports E_Management.Emanagement.globalinfo
Imports System.Collections
Namespace emanagement
    Public Class EMSapplications
        Public Shared dsdata, GlobalDSRights As New DataSet
        Public Shared dsdata1 As New DataSet
        Public Shared SQLstat As String
        Public Shared posid As Integer
        Public Shared recstatus As Boolean
        Public Shared _ename As String
        Public Shared _eid As String
        Public Shared _edept As String
        Public Shared _esect As String
        Public Shared _edesig As String
        Public Shared _fisyrStart As Date
        Public Shared _fisyrEnd As Date
        Public Shared _curdttime As Date
        Public Shared RecordId As Decimal
        Public Shared MyerrorMsg As String
        Public Shared MyScreenId, MyScreenStat As Integer
        'Public Shared _pfisyrStart As Date
        'Public Shared _pfisyrEnd As Date
        Private fstrDBErrorMsg As String
        Dim lParamOleDB As New OleDb.OleDbParameter


        Public Shared _fisyrStart1 As Date
        Public Shared _fisyrEnd1 As Date

        Public Sub GetfiscalYearforLeave()

            _fisyrStart1 = DateTime.Today
            _fisyrEnd1 = DateTime.Today

            _fisyrStart1 = "01/01/" & Year(_fisyrStart1)
            _fisyrEnd1 = "12/31/" & Year(_fisyrEnd1)

            _curdttime = DateTime.Now

        End Sub

        Public Shared Function CheckDate(ByVal fy As Date, ByVal doj As Date) As Integer

            If fy > doj Then
                Return 1
            Else
                Return 0
            End If

        End Function

        ' ######### function to get current fiscal year ########
        Public sub  GetfiscalYear() 
            Dim fmon As Integer
            fmon = Month(Date.Now)

            If fmon <= 3 Then
                _fisyrStart = DateTime.Today.AddYears(-1)
                _fisyrEnd = DateTime.Today
            Else
                _fisyrStart = DateTime.Today
                _fisyrEnd = DateTime.Today.AddYears(1)
            End If

            _fisyrStart = "04/01/" & Year(_fisyrStart)
            _fisyrEnd = "3/31/" & Year(_fisyrEnd)

            '  _pfisyrStart = "04/01/" & Year(_fisyrStart)
            '  _pfisyrEnd = "03/31/" & Year(_fisyrEnd)
            _curdttime = DateTime.Now

        End Sub

        ' ######### function to get max(passno) from staffgatepass table ########

        Public Shared Function GetGatePassID() As Integer
            SQLstat = "select max(passno) from staffgatepass"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ' ######### function to empdetails from empmaster table ########
        Public Shared Function GetEmpVehino(ByVal txt As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_empdetails", txt)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

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

        Public Shared Function getdesigname(ByVal txt As String) As DataSet
            SQLstat = "select * from designation where designationname = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to GPdetails from staffgatepass table ########

        Public Shared Function GetEmpVehino_opt(ByVal txt As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_empdetails_opt", txt)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to empdetails from empmaster table ########
        Public Shared Function GetEmpVehinoall(ByVal txt As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_empdetailsall", txt)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to cancel bt  ########

        Public Shared Function cancelBT(ByVal txt As String) As DataSet
            SQLstat = "update acc_businesstrip set BTstatus = 'CANCELLED' where recno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to empdetails from empmaster table ########
        Public Shared Function GetLeaveLevel(ByVal txt As String, ByVal exp As Integer) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_getleavelevel", txt, exp)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        ' ######### function to GPdetails from staffgatepass table ########

        Public Shared Function GetGatePassDetails(ByVal txt As String) As DataSet
            SQLstat = "select * from staffgatepass where passno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to CSpassdetails from staffgatepass table ########

        Public Shared Function GetCustPassDetails(ByVal txt As String) As DataSet
            SQLstat = "select * from acc_customerapplication where recno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to get uniform details  ########

        Public Shared Function GetUniformDet(ByVal txt As String) As DataSet
            SQLstat = "select * from emp_uniform where empcode = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function GetEmpPpdetails(ByVal txt As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "GetEmpPPWpDetails", txt)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
     

        ' ######### function to cancel gatepass  ########

        Public Shared Function cancelGatePass(ByVal txt As String) As DataSet
            SQLstat = "update staffgatepass set status = 'CANCELLED' where passno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        ' ######### function to cancel gatepass  ########

        Public Shared Function cancelclinic(ByVal txt As String) As DataSet
            SQLstat = "update clinicstaffgatepass set status = 'C' where passno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to cancel cust/supp pass  ########

        Public Shared Function cancelcsPass(ByVal txt As String) As DataSet
            SQLstat = "update acc_customerapplication set status = 'C' where recno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to insert gatepass into staffgatepass table ########
        Public Shared Function InsertGatePass(ByVal gpid As String _
                          , ByVal gptype As String _
                          , ByVal empcode As String _
                          , ByVal date1 As Date _
                          , ByVal location As String _
                          , ByVal mobile As String _
                          , ByVal outdate1 As Date _
                          , ByVal vehicle As String _
                          , ByVal purpose As String _
                          , ByVal intime As String _
                          , ByVal outtime As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_INSGatePass", gptype, empcode, date1, location, mobile, vehicle, outdate1, purpose, intime, outtime, "0", gpid, "SCHEDULED")
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        ' ######### function to Update gatepass into staffgatepass table ########
        Public Shared Function UpdateGatePass(ByVal gpid As String _
                          , ByVal gptype As String _
                          , ByVal empcode As String _
                          , ByVal date1 As Date _
                          , ByVal location As String _
                          , ByVal mobile As String _
                          , ByVal outdate1 As Date _
                          , ByVal vehicle As String _
                          , ByVal purpose As String _
                          , ByVal intime As String _
                          , ByVal outtime As String _
                          , ByVal passno As String _
                        ) As Integer

            Dim vardate1 As String
            Dim varoutdate1 As String
            Dim intime1 As String
            Dim outtime1 As String

            vardate1 = Format(date1, "MM/dd/yyyy")
            varoutdate1 = Format(outdate1, "MM/dd/yyyy")
            intime1 = vardate1 + " " + intime
            outtime1 = varoutdate1 + " " + outtime

            SQLstat = "update staffgatepass set gatepasstype='" & gptype & "',date1='" & vardate1 & "',location='" & location & "',mobile='" & mobile & "',pvehicleno='" & vehicle & "',outdate='" & varoutdate1 & "',indate = '" & varoutdate1 & "',purpose='" & purpose & "',intime='" & intime & "',outtime='" & outtime & "',modifiedby='" & _eid & "' ,modifiedtime='" & _curdttime & "' where passno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception

                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        Public Shared Function UpdateApproval(ByVal passno As String, ByVal status As String, ByVal emp As String)
            SQLstat = "update staffgatepass set status='" & status & "' , approvedby = '" & emp & "',approveddate = '" & _curdttime & "'  where passno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        ' ######### function to insert into acc_customerapplication  table ########
        Public Shared Function InsertCustomerPass(ByVal empid As String _
                          , ByVal vtype As String _
                          , ByVal cname As String _
                          , ByVal pic As String _
                          , ByVal noperson As Integer _
                          , ByVal contactno As String _
                          , ByVal cad As String _
                          , ByVal arrtime As String _
                          , ByVal purpose As String _
                          , ByVal rarea As String _
                          , ByVal mydate As Date _
                          , ByVal _edept As String _
                          , ByVal seldept As String _
                          , ByVal vname As String _
                          , ByVal taxibook As String _
                          , ByVal taxicost As String _
                          , ByVal hotelbook As String _
                          , ByVal hcost As String _
                          , ByVal hname As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "H_custGP_insert_new", empid, vtype, cname, pic, noperson, contactno, cad, arrtime, purpose, rarea, mydate, _edept, seldept, vname, taxibook, taxicost, hotelbook, hcost, hname, "A")
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        ' ######### function to Get Total Personal Gp ########
        Public Shared Function GetTotOffGp(ByVal empid As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "HRMIS_GPoff2", empid, _fisyrStart, _fisyrEnd)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return dsdata
        End Function
        ' ######### function to Get Total Personal Gp ########
        Public Shared Function GetTotPerGp(ByVal empid As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "HRMIS_GPper2", empid, _fisyrStart, _fisyrEnd)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return dsdata
        End Function

        ' ######### function to Get Total Pending Gp ########
        Public Shared Function GetTotPending(ByVal empid As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "HRMIS_GPpending", empid, _fisyrStart, _fisyrEnd)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return dsdata
        End Function

        ' ######### function to update into acc_customerapplication  table ########
        Public Shared Function UpdateCustomerPass(ByVal empid As String _
                          , ByVal vtype As String _
                          , ByVal cname As String _
                          , ByVal pic As String _
                          , ByVal noperson As Integer _
                          , ByVal contactno As String _
                          , ByVal cad As Date _
                          , ByVal arrtime As String _
                          , ByVal purpose As String _
                          , ByVal rarea As String _
                          , ByVal mydate As Date _
                          , ByVal _edept As String _
                          , ByVal seldept As String _
                          , ByVal vname As String _
                          , ByVal taxibook As String _
                          , ByVal taxicost As String _
                          , ByVal hotelbook As String _
                          , ByVal hcost As String _
                          , ByVal hname As String _
                          , ByVal Pno As Integer _
                          , ByVal status As String) As Integer

            Dim arrdate1 As String
            Dim curdate1 As String
            Dim arrtime1 As String
            arrdate1 = Format(cad, "MM/dd/yy")
            curdate1 = Format(mydate, "MM/dd/yy")
            arrtime1 = arrdate1 + " " + arrtime

            SQLstat = "update acc_customerapplication  set [visitortype] = '" & vtype & "',[companyname] = '" & cname & "' ,personincharge = '" & vname & "',[noofperson] = '" & noperson & "',[contactno] = '" & contactno & "',[arrivaldate] = '" & arrdate1 & "',[arrivaltime] = '" & arrtime1 & "',[purpose]= '" & purpose & "',[receptionarea] = '" & rarea & "' ,[date1] = '" & curdate1 & "',[department] = '" & _edept & "'  ,[visitdepartment] = '" & seldept & "',[companypersonincharge] = '" & pic & "',[taxibooking] = '" & taxibook & "',[taxicost] = '" & taxicost & "',[hotelarrangement] = '" & hotelbook & "' ,[hotelcost] = '" & hcost & "',[hotelname] = '" & hname & "',modifiedby = '" & empid & "' , modifiedtime = getdate(),status= '" & status & "' where recno = '" & Pno & "'"
            Try
                ' posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "H_custGP_update", empid, vtype, cname, pic, noperson, contactno, cad, arrtime, purpose, rarea, mydate, _edept, seldept, vname, taxibook, taxicost, hotelbook, hcost, hname, Pno, status)
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        Public Shared Function UpdatefncCVApproval(ByVal passno As String, ByVal status As String)
            SQLstat = "update   acc_customerapplication set status='" & status & "' , approvedby = '" & _eid & "' ,approveddate = '" & _curdttime & "' where recno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        Public Shared Function getcvdata(ByVal txt As String) As DataSet
            SQLstat = "select status from acc_customerapplication  WHERE (status = 'Approved')  AND (datepart(mm, arrivaldate) >= datepart(mm,  getdate())) AND (datepart(yy, arrivaldate) >= datepart(yy,  getdate())) "
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

  
        Public Shared Function GetGpHistory(ByVal empid As String, ByVal fy As Date, ByVal ly As Date) As DataSet
            Dim d1 As String
            Dim d2 As String

            d1 = Format(fy, "MM/dd/yy")
            d2 = Format(ly, "MM/dd/yy")

            SQLstat = " SELECT [status] ,convert(varchar,date1,105) as AppliedOn, [purpose] as Purpose, convert(varchar,outdate,105) as GpDate , right(convert(varchar,outtime,100),7) as TimeOut,right(convert(varchar,intime,100),7) as TimeIn, [location], [gatepasstype] as GpType  FROM [staffgatepass] WHERE (([outdate] >= '" & d1 & "') AND ([outdate] <= '" & d2 & "') AND ([empcode] = '" & empid & "') and status <> 'CANCELLED')  order by passno desc"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function CountAnnualLeaveTaken(ByVal empid As String, ByVal fy As Date, ByVal ly As Date) As DataSet
            Dim d1 As String
            Dim d2 As String

            d1 = Format(fy, "MM/dd/yy")
            d2 = Format(ly, "MM/dd/yy")

            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_getannual", fy, ly, empid)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function CountMedicalLeaveTaken(ByVal empid As String, ByVal fy As Date, ByVal ly As Date) As DataSet
            Dim d1 As String
            Dim d2 As String

            d1 = Format(fy, "MM/dd/yy")
            d2 = Format(ly, "MM/dd/yy")

            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_getmedical", fy, ly, empid)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function


        Public Shared Function GetCfwdLeave(ByVal id As String, ByVal yr As Integer) As DataSet
            SQLstat = "select * from leavecf where empcode='" & id & "' and fortheyear ='" & yr & "'"

            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function SetCfwdLeave(ByVal empid As String, ByVal fy As Date, ByVal ly As Date) As DataSet
            Dim d1 As String
            Dim d2 As String

            d1 = Format(fy, "MM/dd/yy")
            d2 = Format(ly, "MM/dd/yy")

            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_GetTotalLeave", empid, fy, ly)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function InsertcfwdLeave(ByVal empid As String, ByVal bl As Decimal, ByVal yr As Integer, ByVal balc As Integer, ByVal cfd As Integer) As DataSet
            SQLstat = "insert into leavecf (empcode,leaveremain,fortheyear,remain,cfwd) values('" & empid & "','" & bl & "','" & yr & "','" & balc & "','" & cfd & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to get max(appno) from leave table ########

        Public Shared Function GetLeaveID() As Integer
            SQLstat = "select max(appno) from leaveform"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ' ######### function to insert into leaveform  table ########
        Public Shared Function InsertLeave(ByVal empid As String _
                          , ByVal thisdate As Date _
                          , ByVal adays As Decimal _
                          , ByVal workfor As Decimal _
                          , ByVal fd As Date _
                          , ByVal td As Date _
                          , ByVal ltype As String _
                          , ByVal reason As String _
                          , ByVal ltime As String _
                          , ByVal carry As Char _
                          , ByVal nocf As Decimal _
                          , ByVal bakdate As Char _
                          , ByVal rno As Integer, ByVal Pic1 As String, ByVal Pic11 As String, ByVal Pic2 As String, ByVal Pic22 As String, ByVal AnnualBal As String, ByVal MedicalBal As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_InsLeavenew", empid, thisdate, adays, workfor, fd, td, ltype, reason, ltime, carry, nocf, bakdate, rno, "SCHEDULED", Pic1, Pic11, Pic2, Pic22, AnnualBal, MedicalBal)
                'posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_InsLeave", "014543", thisdate, "3", "1", fd, td, "annual", "reason", "1", "Y", "1", "N", "365789", "1", "1", "1")
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        ' ######### function to update into leaveform  table ########
        Public Shared Function UpdateLeave(ByVal rno As Integer _
                          , ByVal empid As String _
                          , ByVal thisdate As Date _
                          , ByVal adays As Decimal _
                          , ByVal workfor As Decimal _
                          , ByVal fd As Date _
                          , ByVal td As Date _
                          , ByVal ltype As String _
                          , ByVal reason As String _
                          , ByVal ltime As String _
                          , ByVal carry As Char _
                          , ByVal nocf As Decimal _
                          , ByVal bakdate As Char) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_updleave_new", rno, empid, thisdate, adays, workfor, fd, td, ltype, reason, ltime, carry, nocf, "SCHEDULED", bakdate)
                'posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_InsLeave", "014543", thisdate, "3", "1", fd, td, "annual", "reason", "1", "Y", "1", "N", "365789", "1", "1", "1")
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdatecfwdLeave(ByVal empid As String, ByVal yr As Integer, ByVal bal As Decimal) As DataSet
            SQLstat = "update leavecf set remain = '" & bal & "' where empcode ='" & empid & "' and fortheyear = '" & yr & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to CSpassdetails from staffgatepass table ########

        Public Shared Function getLeaveDetails(ByVal txt As String) As DataSet
            SQLstat = "select * from leaveform where appno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to cancel gatepass  ########
        Public Shared Function cancelLeave(ByVal txt As String) As DataSet
            SQLstat = "update Leaveform set status = 'CANCELLED' where appno = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function UpdateLVApproval(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
                  ByVal typ As String, ByVal workfor As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "',statusreason = '" & remarks & "'  where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVCApproval(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
       ByVal typ As String, ByVal workfor As Decimal, ByVal noc As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,nocf = '" & noc & "',grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason ='" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVRApproval(ByVal passno As String, ByVal status As String, ByVal remarks As String, ByVal emp As String)
            SQLstat = "update Leaveform set status='" & status & "' , approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason = '" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVRCancel(ByVal passno As String, ByVal status As String)
            SQLstat = "update Leaveform set status='" & status & "' , rejectedby = '" & _eid & "' ,rejecteddate = '" & _curdttime & "'  where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVRERApproval(ByVal passno As String, ByVal status As String, ByVal sreason As String, ByVal emp As String)
            SQLstat = "update Leaveform set status='" & status & "' ,statusreason = '" & sreason & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "'  where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVERApproval(ByVal passno As String, ByVal status As String, ByVal ty As String, ByVal emp As String)
            SQLstat = "update Leaveform set status='" & status & "' ,leavetype1 = '" & ty & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "'  where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        Public Shared Function GetLVHistory(ByVal empid As String, ByVal fy As Date, ByVal ly As Date) As DataSet
            Dim d1 As String
            Dim d2 As String

            d1 = Format(fy, "MM/dd/yy")
            d2 = Format(ly, "MM/dd/yy")

            SQLstat = " SELECT [status] ,convert(varchar,applicationdate,105) as AppliedOn,days as AppliedDays, convert(varchar,fromdate,105) + '~' + convert(varchar,todate,105) as LeaveDate, leavetype,reason as Reason,carryfwd,backdate  FROM [leaveform] WHERE (([fromdate] >= '" & d1 & "') AND ([fromdate] <= '" & d2 & "') AND ([empno] = '" & empid & "') and status <> 'CANCELLED')  order by appno desc"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        ' ######### function to insert into leavelevel  table ########
        Public Shared Function InsertLeaveLevel(ByVal llevel As Decimal _
                          , ByVal exp As Decimal _
                          , ByVal probation As Decimal _
                          , ByVal aleave As Decimal _
                          , ByVal mleave As Decimal) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_insLeaveMaster", llevel, exp, probation, aleave, mleave)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        ' ######### select emp by dept table ########
        Public Shared Function GetEmpByDept(ByVal dept As String) As DataSet
            SQLstat = "select * from empmaster where departmentcode = ('" & dept & "') and resigned = 'N'"
            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function
        ' ######### select emp by dept table ########
        Public Shared Function GetEmpall() As DataSet
            SQLstat = "select * from empmaster where resigned = 'N'"
            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function
        ' ######### select emp by desig table ########
        Public Shared Function GetEmpByDesig(ByVal dept As String) As DataSet
            SQLstat = "select * from empmaster where designation = ('" & dept & "') and resigned = 'N'"
            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function
        ' ######### select emp by desig table ########
        Public Shared Function GetEmpBysect(ByVal sect As String) As DataSet
            SQLstat = "select * from empmaster where sectioncode = ('" & sect & "') and resigned = 'N'"
            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function
        ' ######### Delete Report temp  table ########
        Public Shared Function DeleteTempTab() As DataSet
            SQLstat = "delete from leave_entitilement_rpt_temp"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### Delete Report temp  table ########
        Public Shared Function DeleteTempleave() As DataSet
            SQLstat = "delete from leavesummary_temp"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function InsertTempTable(ByVal emp As String _
        , ByVal ann As Decimal _
        , ByVal bann As Decimal _
        , ByVal med As Decimal _
        , ByVal bmed As Decimal, ByVal prt As Decimal) As DataSet
            SQLstat = "Insert into leave_entitilement_rpt_temp(empno,annualent,balannual,medicalent,balmedical,prorate) values('" & emp & "','" & ann & "','" & bann & "','" & med & "','" & bmed & "','" & prt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        ' ######### select emp by desig table ########
        Public Shared Function CheckEmpDetails(ByVal dept As String, ByVal emp As String) As DataSet
            SQLstat = "select * from empmaster where departmentcode = ('" & dept & "') and resigned = 'N' and empcode ='" & emp & "'"
            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function
        ' ######### select emp by desig table ########
        Public Shared Function CheckEmpExist(ByVal emp As String) As DataSet
            SQLstat = "select * from empmaster where resigned = 'N' and empcode ='" & emp & "'"
            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function

        Public Shared Function Countallleave(ByVal empid As String, ByVal fy As Date, ByVal ly As Date, ByVal ltype As String) As DataSet
            Dim d1 As String
            Dim d2 As String

            d1 = Format(fy, "MM/dd/yy")
            d2 = Format(ly, "MM/dd/yy")

            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_Getallleave", fy, ly, empid, ltype)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function Countotherleave(ByVal empid As String, ByVal fy As Date, ByVal ly As Date) As DataSet
            Dim d1 As String
            Dim d2 As String

            d1 = Format(fy, "MM/dd/yy")
            d2 = Format(ly, "MM/dd/yy")

            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "hrmis_otherleave", fy, ly, empid)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
      
        Public Shared Function Insertallleave(ByVal emp As String _
               , ByVal ann As Decimal _
               , ByVal med As Decimal _
               , ByVal bann As Decimal _
               , ByVal bmed As Decimal _
               , ByVal emer As Decimal _
               , ByVal emerup As Decimal _
               , ByVal pemer As Decimal _
               , ByVal pemerup As Decimal _
               , ByVal up As Decimal, ByVal hosp As Decimal, ByVal other As Decimal) As Integer
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "insleavetemp", emp, ann, med, bann, bmed, emer, pemer, emerup, pemerup, up, other, hosp)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return recstatus
        End Function

        '''''''''''''''''''''''''''''''''''''''''' MASTER SCREEN CODES'''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ' ######### function to get max(positionid) from designation table ########

        Public Shared Function getpositionID() As Integer
            SQLstat = "select max(positionid) from designation"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ' ######### function to insert record to designation table ########
        Public Shared Function InsertDesignation(ByVal name As String _
                            , ByVal desiglevel As String _
                            , ByVal desigcode As String _
                            , ByVal desigprob As Integer _
                            , ByVal desiginsCat As String _
                            , ByVal desigins As Double _
                            , ByVal desigctq As Integer, ByVal pos As Integer, ByVal emp As String) As Integer

            '   SQLstat = "insert into designation values('aaaprogrammer',3,'checking',4,'c',700000,20,3,45,'a','rathi',12,'rathi',12)"
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "mis_insdesignation_NEW", name, desiglevel, desigcode, desigprob, desiginsCat, desigins, desigctq, pos, emp, emp)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function getDesigInfo(ByVal txt As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "MIS_getdesiginfo", txt)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata

        End Function

        Public Shared Function populatedesig() As DataSet
            SQLstat = "select * from designation "
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function updateDesig(ByVal dname As String _
                                   , ByVal lvl As Integer _
                                   , ByVal dcode As String _
                                   , ByVal prob As Integer _
                                   , ByVal inscat As Char _
                                   , ByVal amt As Double _
                                   , ByVal ctq As Integer _
                                   , ByVal cby As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "MIS_UPDdesignation_NEW", dname, lvl, dcode, prob, inscat, amt, ctq, cby)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return posid
        End Function

        ' ######### function to get max(positionid) from department table ########
        Public Shared Function getDeptposID() As Integer
            SQLstat = "select max(recordno) from department"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        ' ######### function to insert record to department table ########
        Public Shared Function InsertDepartment(ByVal fcode As String _
                            , ByVal fname As String _
                            , ByVal fjhead As String _
                            , ByVal foffice As String _
                            , ByVal fsection As String _
                            , ByVal fprefix As String _
                            , ByVal fpcode As Integer _
                           , ByVal fdid As Integer _
                            , ByVal ename As String _
                           ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "mis_insdepartment_NEW", fcode, fname, fjhead, foffice, fsection, fprefix, fpcode, fdid, ename, _curdttime)
           
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function

        ' ######### function to insert record to Section table ########
        Public Shared Function InsertSection(ByVal fcode As String _
                            , ByVal fname As String _
                            , ByVal fdcode As String _
                            , ByVal fxdcode As String _
                            , ByVal fadept As String _
                            , ByVal facode As String _
                            , ByVal fpcode As String _
                            , ByVal ename As String _
                                   , ByVal modified As Date) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "mis_insSection_NEW", fcode, fname, fdcode, fxdcode, fadept, facode, fpcode, ename, ename, modified)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function

        ' ######### function to get max(empno) from empmaster table ########

        Public Shared Function GetMaxEmpID() As Integer
            SQLstat = "SELECT MAX(empcode) AS Expr1 FROM empmaster WHERE  (empcode <> 'SAFE0001')"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        ' ######### function to insert record to empmaster table ########

        Public Shared Function InsertempMaster(ByVal empcode As String _
                            , ByVal empname As String _
                            , ByVal desig As String _
                            , ByVal sect As String _
                            , ByVal dept As String _
                            , ByVal email As String _
                            , ByVal category As String _
                            , ByVal fy As Date _
                            , ByVal etype As String _
                            , ByVal gender As String _
                            , ByVal foreign As String _
                            , ByVal ly As Date _
                            , ByVal oldic As String _
                            , ByVal newic As String _
                            , ByVal pp As String _
                            , ByVal add1 As String _
                            , ByVal add2 As String _
                            , ByVal add3 As String _
                            , ByVal pcode As String _
                            , ByVal hostel As String _
                            , ByVal transport As String _
                            , ByVal area As String _
                            , ByVal route As String _
                            , ByVal race As String _
                            , ByVal religion As String _
                            , ByVal phone As String _
                            , ByVal hp As String _
                            , ByVal blood As String _
                            , ByVal nation As String _
                            , ByVal marital As String _
                            , ByVal children As String _
                            , ByVal epf As String _
                            , ByVal sosco As String _
                            , ByVal elevel As String _
                            , ByVal work As String _
                            , ByVal others As String _
                            , ByVal contract As String _
                            , ByVal hosteln As String _
                            , ByVal account As String _
                            , ByVal bank As String _
                            , ByVal exp As String _
                            , ByVal ename As String _
                            , ByVal hpass As String _
                            , ByVal nb As String _
                            , ByVal car As String _
                            , ByVal login As String _
                            , ByVal DOS As Date _
                            , ByVal EmergencyContactPerson As String _
                            , ByVal EmergencyAddress As String _
                            , ByVal EmergencyTelephone As String _
                            , ByVal ImageUrl As String _
                            ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_ADMIN_INS_EMPMASTER", empcode, empname, desig, sect, dept, email, category, fy, etype, gender, foreign, ly, oldic, newic, pp, add1, add2, add3, pcode, hostel, transport, area, route, race, religion, phone, hp, blood, nation, marital, children, epf, sosco, elevel, work, others, contract, hosteln, account, bank, exp, ename, hpass, nb, car, login, DOS, EmergencyContactPerson, EmergencyAddress, EmergencyTelephone, ImageUrl)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return recstatus
        End Function
        ' InsertUnifrom(_eid, Txttrousers.Text.Trim, txtshirt.Text.Trim, txtshoes.Text.Trim, txtnotrousers.Text.Trim, txtnoshirt.Text.Trim, txtnoshoes.Text.Trim, txtnojacket.Text.Trim, txtnocap.Text.Trim, ud)
        ' ######### function to insert record to Section table ########
        Public Shared Function InsertUnifrom(ByVal ename As String _
                            , ByVal trousers As String _
                            , ByVal shirt As String _
                            , ByVal shoes As String _
                            , ByVal notrousers As String _
                            , ByVal noshirt As String _
                            , ByVal noshoe As String _
                            , ByVal nojacket As String _
                            , ByVal nocap As String _
                            , ByVal ud As Date) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_ADMIN_INS_UNIFORM", ename, trousers, shirt, shoes, notrousers, noshirt, noshoe, nojacket, nocap, ud)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        '''''''''''''''''''''''''''''''''''''''''''''''''''JS  codes'''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Public Shared Function GetJobPurpose(ByVal emp As String) As DataSet
            SQLstat = "select * from [man_jobpurpose] where empcode='" & emp & "' order by version desc"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function GetJobcode(ByVal emp As String) As DataSet
            SQLstat = "SELECT * FROM empmaster INNER JOIN man_jobcode ON empmaster.departmentcode = man_jobcode.departmentcode AND empmaster.designation = man_jobcode.designation WHERE (empmaster.empcode = '" & emp & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function CheckRecordAvail(ByVal emp As String) As DataSet
            SQLstat = "select * from man_jobpurpose where empcode='" & emp & "' order by version desc"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function InsertJpurpose(ByVal ename As String _
                           , ByVal jcode As String _
                           , ByVal jpurpose As String _
                           , ByVal setby As String _
                           , ByVal version As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "hrmis_js_jobpurpose", ename, jcode, jpurpose, setby, version)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function

        Public Shared Function Getsno(ByVal emp As String) As Integer
            SQLstat = "SELECT isnull(max(sno),0)+1 AS sno FROM man_temp_keygoal WHERE  (empcode = '" & emp & "')  "
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function InsertToJS(ByVal sno As Integer _
                               , ByVal empcode As String _
                               , ByVal a As String) As Integer
            SQLstat = "insert into man_temp_keygoal(sno,empcode,man_keyresult)values('" & sno & "','" & empcode & "','" & a & "')"
            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function GetRevno(ByVal emp As String) As Integer
            SQLstat = "SELECT isnull(max(revno),0)+1 AS revno FROM  man_jobspecification WHERE  (empcode = '" & emp & "')"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetRecno() As Integer
            SQLstat = "SELECT isnull(max(recordno),0)+1 AS recno  FROM  man_jobspecification"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ' ######### function to insert into JS table ########
        Public Shared Function InsertJS(ByVal rec As Integer _
                          , ByVal rev As Integer _
                          , ByVal fd As Date _
                          , ByVal td As Date _
                          , ByVal emp As String _
                          , ByVal jcode As String _
                          , ByVal jpurpose As String _
                          , ByVal pending As String _
                          , ByVal tech As String _
                          , ByVal beh As String _
                        ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "hrmis_js_insert_new", rec, rev, fd, td, emp, jcode, jpurpose, pending, tech, beh)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertKeyskill(ByVal sno As Integer _
                       , ByVal emp As String _
                       , ByVal key As String _
                       , ByVal recno As String) As Integer
            ' SQLstat = "insert into man_keygoal (sno,empcode,man_keyresult,recordno) values ('" & sno & "','" & emp & "','" & key & "','" & recno & "')"

            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, "man_key", sno, emp, key, recno)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertKeyskilltemp(ByVal sno As Integer _
                , ByVal emp As String _
                , ByVal key As String) As Integer
            ' SQLstat = "insert into man_temp_keygoal (sno,empcode,man_keyresult,rno) values ('" & sno & "','" & emp & "','" & key & "','" & recno & "')"

            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, "man_temp_key", sno, emp, key)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function GetKeyskill(ByVal emp As String) As DataSet
            SQLstat = "select * from man_temp_keygoal where empcode='" & emp & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to get max(positionid) from department table ########
        Public Shared Function DelKeyTemp(ByVal emp As String) As Integer
            SQLstat = "delete from man_temp_keygoal where empcode = '" & emp & "'"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetJS(ByVal emp As String, ByVal rev As Integer) As DataSet
            SQLstat = "select * from man_jobspecification where empcode='" & emp & "' and revno = '" & rev & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function GetEmpTempGoal(ByVal emp As String, ByVal rev As Integer) As DataSet
            SQLstat = "select * from man_keygoal where empcode='" & emp & "' and recordno = '" & rev & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function chkcodeAvail(ByVal dept As String, ByVal desig As String) As DataSet
            SQLstat = "select * from man_jobcode where departmentcode ='" & dept & "' and designation= '" & desig & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function InsertJobCode(ByVal dept As String _
              , ByVal desig As String _
              , ByVal code As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, "insJobcode", dept, desig, code)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertBehavior(ByVal jcode As String _
           , ByVal skill As String _
          ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, "insbehavior", jcode, skill)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function Inserttechskill(ByVal jcode As String _
    , ByVal skill As String _
   ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, "instech", jcode, skill)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertGoal(ByVal sno As Integer _
           , ByVal desc As String _
           , ByVal eid As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, "hrmis_js_goalset_new)", sno, desc, eid)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function GetGoalNo() As Integer
            SQLstat = "SELECT isnull(max(sno),0)+1 AS sno  FROM man_goalalign"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetGroupCode() As Integer
            SQLstat = "select isnull(max(number),0)+1 from trans_groupmaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetshiftCode() As Integer
            SQLstat = "select isnull(max(number),0)+1 from trans_shifttime"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetBusCode() As Integer
            SQLstat = "select isnull(max(number),0)+1 from trans_cost"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function GetSuppCode() As Integer
            SQLstat = "select isnull(max(supplierno),0)+1 from trans_supplier"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function Getptcode() As Integer
            SQLstat = "select isnull(max(srno),0)+1 from  trans_pickuptimemaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function Getservicecode() As Integer
            SQLstat = "select isnull(max(recordno),0)+1 from  vehicleservice"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ' ######### function to get max(recordid) from pv_btvisadetails table ########
        Public Shared Function getBTrecID() As Integer
            SQLstat = "select isnull(max(recordno),0)+1 from pv_btvisadetails"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ' ######### function to insert record to trans_areamaster  table ########
        Public Shared Function Insertarea(ByVal frcode As String _
                                         , ByVal farea As String _
                                         , ByVal created As String _
                                       ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTAREA", frcode, farea, created)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function Insertroute(ByVal frcode As String _
                                       , ByVal froute As String _
                                       , ByVal ename As String _
                                      ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTROUTE", frcode, froute, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function Inserttgroup(ByVal rno As Integer _
                                                  , ByVal tgcode As String _
                                                  , ByVal tgname As String _
                                                  , ByVal ename As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTGROUPnew", rno, tgcode, tgname, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function Insertshift(ByVal rno As Integer _
                                                        , ByVal tgcode As String _
                                                        , ByVal shcode As String _
                                                        , ByVal tgname As String _
                                                        , ByVal ename As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTSHIFT1", rno, tgcode, shcode, tgname, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertCost(ByVal rno As Integer _
                                                         , ByVal route As String _
                                                         , ByVal cost As String _
                                                         , ByVal capacity As String _
                                                         , ByVal type As String _
                                                         , ByVal ename As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTCOST", rno, route, cost, capacity, type, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function Insertsupplier(ByVal sno As Integer, ByVal fsname As String _
                           , ByVal fadrs As String _
                           , ByVal fphone As String _
                           , ByVal fhp As String _
                           , ByVal ffax As String _
                           , ByVal fic As String _
                           , ByVal fcname As String _
                           , ByVal fcregno As String _
                           , ByVal ename As String _
                          ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTSUP", sno, fsname, fadrs, fphone, fhp, ffax, fic, fcname, fcregno, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function Insertvehicle(ByVal emp As String _
                                                                , ByVal vno As String _
                                                                , ByVal allowance As Decimal _
                                                                , ByVal vtype As String _
                                                                ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTOWNVEHICLE", emp, vno, allowance, vtype)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function

        Public Shared Function Insertempmasterroute(ByVal emp As String _
                                                                     , ByVal route As String _
                                                                     , ByVal area As String _
                                                                     ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTINDIVIDUALALLOCATION", emp, route, area)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertPTime(ByVal rno As Integer _
                                                                , ByVal route As String _
                                                                , ByVal area As String _
                                                                , ByVal sa As String _
                                                                , ByVal sb As String _
                                                                , ByVal sc As String _
                                                                , ByVal sm As String _
                                                                , ByVal sn As String _
                                                                , ByVal ename As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_TRANSPORT_INSERTPICKUPTIME", rno, route, area, sa, sb, sc, sm, sn, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function GetrouteareaPkup(ByVal route As String, ByVal area As String) As DataSet
            SQLstat = "select * from trans_pickuptimemaster where route='" & route & "' and area = '" & area & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Getvmdetails(ByVal rno As Integer) As DataSet
            SQLstat = "select * from vehicledetail where rno = '" & rno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Getvmdetails1(ByVal VNO As String) As DataSet
            SQLstat = "select * from vehicledetail where vehicleno = '" & VNO & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to insert record to vehicledetails table ########
        Public Shared Function Insertvehicledetails(ByVal fvno As String _
                           , ByVal fmodel As String _
                           , ByVal fcategory As String _
                           , ByVal fpur As Date _
                           , ByVal fchasis As String _
                           , ByVal ffuel As String _
                           , ByVal fcolor As String _
                           , ByVal feno As String _
                           , ByVal fecc As String _
                           , ByVal fmyr As Integer _
                           , ByVal fseats As Integer _
                           , ByVal fdept As String _
                           , ByVal ename As String _
                          ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_compv_Insvehicledetails", fvno, fmodel, fcategory, fpur, fchasis, ffuel, fcolor, feno, fecc, fmyr, fseats, fdept, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        ' ######### function to insert record to vehicledetails table ########
        Public Shared Function Updatevehicledetails(ByVal rno As String _
                           , ByVal fmodel As String _
                           , ByVal fcategory As String _
                           , ByVal fpur As Date _
                           , ByVal fchasis As String _
                           , ByVal ffuel As String _
                           , ByVal fcolor As String _
                           , ByVal feno As String _
                           , ByVal fecc As String _
                           , ByVal fmyr As Integer _
                           , ByVal fseats As Integer _
                           , ByVal fdept As String _
                           , ByVal ename As String _
                          ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_compv_updvehicledetails", rno, fchasis, fmodel, fecc, feno, fcategory, ffuel, fdept, fseats, fcolor, fpur, fmyr, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        ' ######### function to insert record to summondetails table ########
        Public Shared Function Insertsummon(ByVal vno As String _
                           , ByVal sd As Date _
                           , ByVal dd As Date _
                           , ByVal reason As String _
                           , ByVal amt As Decimal _
                           , ByVal pd As Date _
                           , ByVal name As String _
                           , ByVal emp As String _
                          ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_CT_inssummon", vno, sd, dd, reason, amt, pd, name, emp)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function InsertRoadTax(ByVal vno As String _
                                                              , ByVal fd As Date _
                                                              , ByVal td As Date _
                                                              , ByVal amt As Decimal _
                                                              , ByVal emp As String _
                                                              ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HrMIS_compv_insRT", vno, fd, td, amt, emp)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertInsurance(ByVal vno As String _
                                                        , ByVal fd As Date _
                                                        , ByVal td As Date _
                                                        , ByVal amt As Decimal _
                                                        , ByVal emp As String _
                                                        ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HrMIS_compv_insVINS", vno, fd, td, amt, emp)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function Insertcentre(ByVal centre As String, ByVal ad1 As String, ByVal ad2 As String) As Integer
            SQLstat = "insert into servicecentre(centre,address1,address2)values('" & centre & "','" & ad1 & "','" & ad2 & "')                                 "
            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function InsertTempItem(ByVal vno As String _
                                                    , ByVal item As String _
                                                    , ByVal desc As String _
                                                    , ByVal amt As Decimal _
                                                    , ByVal sd As Date _
                                                    ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_compV_instempVservice", vno, item, desc, amt, sd)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function InsertVService(ByVal vno As String, ByVal sd As Date _
                                  , ByVal mode As String _
                                  , ByVal pd As Date _
                                  , ByVal cno As String _
                                  , ByVal read1 As String _
                                  , ByVal read2 As String _
                                  , ByVal centre As String _
                                  , ByVal ename As String _
                                  , ByVal rno As Integer _
                                  , ByVal others As String _
                                 ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_CompV_InsServicedetails", vno, sd, mode, pd, cno, read1, read2, centre, ename, rno, others)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function GetServiceinfo(ByVal VNO As String) As DataSet
            SQLstat = "select * from tempvehicleservice where vehicleno = '" & VNO & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function InsertServiceDesc(ByVal vno As String _
                                                   , ByVal item As String _
                                                   , ByVal desc As String _
                                                   , ByVal amt As Decimal _
                                                   , ByVal sd As Date _
                                                   ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_compV_inVservice", vno, item, desc, amt, sd, _eid)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function DeldescTemp(ByVal vno As String) As Integer
            SQLstat = "delete from tempvehicleservice where vehicleno = '" & vno & "'"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function DelTempChar() As Integer
            SQLstat = "delete from app_charsettingtemp"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function UpdVService(ByVal rno As String, ByVal tot As Decimal) As Integer
            SQLstat = "update vehicleservice set amount = " & tot & " where recordno = " & rno & ""
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ' ######## function to insert record to passportdetails table ########
        Public Shared Function Insertpassportdetails(ByVal ecode As String _
                           , ByVal ppno As String _
                           , ByVal name As String _
                           , ByVal pedate As Date _
                           , ByVal pissuedcountry As String _
                           , ByVal pissuedplace As String _
                           , ByVal egrp As String _
                           , ByVal country As String _
                           , ByVal adrs As String _
                           , ByVal arrived As Date, ByVal KDNRefno As String, ByVal KDNApproval As String, ByVal Agent As String, ByVal FatherName As String, ByVal MotherName As String, ByVal ContactNo As String, ByVal ContractPeriod As Integer, ByVal Barcode As String) As Integer

            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "H_PV_passportmaster", ecode, ppno, name, pedate, pissuedcountry, pissuedplace, egrp, country, adrs, arrived, _eid, KDNRefno, KDNApproval, Agent, FatherName, MotherName, ContactNo, ContractPeriod, Barcode)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function


        ' ######### function to insert record to pv_btvisadetails  table ########
        Public Shared Function InsertBTVisa(ByVal fecode As String _
                            , ByVal fcountry As String _
                            , ByVal fvtype As String _
                            , ByVal fjtype As String _
                            , ByVal fperiod As String _
                            , ByVal fexpiry As DateTime _
                            , ByVal ename As String _
                            , ByVal frno As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "H_PV_INSBTvisamaster", fecode, fcountry, fvtype, fjtype, fperiod, fexpiry, ename, frno)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function Inserttfgroup(ByVal tgcode As String _
                                               , ByVal tgname As String _
                                               , ByVal fname As String, ByVal emp As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "HRMIS_PV_INSERTGROUP", tgcode, tgname, fname, emp)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        ' ######### function to insert record to vehicledetails table ########
        Public Shared Function InsertMissingPerson(ByVal emp As String _
                           , ByVal md As Date _
                           , ByVal pno As String _
                           , ByVal station As String _
                           , ByVal pofficer As String _
                           , ByVal pplace As String _
                           , ByVal cd As Date _
                           , ByVal fno As String _
                           , ByVal amt As Decimal _
                           , ByVal imm As String _
                           , ByVal iofficer As String _
                           , ByVal iplace As String _
                           , ByVal idd As Date _
                           , ByVal ierofficer As String _
                           , ByVal embassy As String _
                           , ByVal eplace As String _
                           , ByVal eofficer As String _
                           , ByVal emd As Date _
                           , ByVal erofficer As String _
                           , ByVal eamt As Decimal _
                           , ByVal ename As String _
                          ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "H_PV_insMissingperson", emp, md, pno, station, pofficer, pplace, cd, fno, amt, imm, iofficer, iplace, idd, ierofficer, embassy, eplace, eofficer, emd, erofficer, eamt, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function GetEMpMissDetails(ByVal VNO As String) As DataSet
            SQLstat = "select * from missingperson where empno = '" & VNO & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        ' ######### function to insert record to vehicledetails table ########
        Public Shared Function UpdateMissingPerson(ByVal emp As String _
                           , ByVal md As Date _
                           , ByVal pno As String _
                           , ByVal station As String _
                           , ByVal pofficer As String _
                           , ByVal pplace As String _
                           , ByVal cd As Date _
                           , ByVal fno As String _
                           , ByVal amt As Decimal _
                           , ByVal imm As String _
                           , ByVal iofficer As String _
                           , ByVal iplace As String _
                           , ByVal idd As Date _
                           , ByVal ierofficer As String _
                           , ByVal embassy As String _
                           , ByVal eplace As String _
                           , ByVal eofficer As String _
                           , ByVal emd As Date _
                           , ByVal erofficer As String _
                           , ByVal eamt As Decimal _
                          ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "H_PV_UpdMissingperson", emp, md, pno, station, pofficer, pplace, cd, fno, amt, imm, iofficer, iplace, idd, ierofficer, embassy, eplace, eofficer, emd, erofficer, eamt)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        ' ######### function to insert record to pv_btvisadetails  table ########
        Public Shared Function Spousechildren(ByVal ecode As String, ByVal name As String _
                            , ByVal pp As String _
                            , ByVal ppexp As String _
                            , ByVal relation As String _
                            , ByVal country As String _
                            , ByVal vexpiry As DateTime _
                           ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "Spousechildren", ecode, name, pp, ppexp, relation, country, vexpiry)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function

        ' ######### function to insert record to vehicledetails table ########
        Public Shared Function InsertWPDetails(ByVal emp As String _
                           , ByVal pno As String, ByVal vf As Date, ByVal vt As Date _
                           , ByVal yrno As Integer _
                           , ByVal refno As String _
                           , ByVal idate As Date _
                           , ByVal place As String _
                           , ByVal bgno As String _
                           , ByVal bgdate As Date _
                           , ByVal bamt As Decimal _
                           , ByVal insdate As Date _
                           , ByVal ino As String _
                           , ByVal wpno As String _
                           , ByVal vtype As String _
                           , ByVal rno As String _
                           , ByVal pass As Decimal _
                           , ByVal levy As Decimal _
                           , ByVal visa As Decimal _
                           , ByVal process As Decimal _
                           , ByVal ename As String _
                                                   ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "H_PV_inswpDetails", emp, pno, vf, vt, yrno, refno, idate, place, bgno, bgdate, bamt, insdate, ino, wpno, vtype, rno, pass, levy, visa, process, ename)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        ' ######### function to insert record to vehicledetails table ########
        Public Shared Function UpdateWPDetails(ByVal sno As Integer _
                                     , ByVal vf As Date _
                                     , ByVal vt As Date _
                           , ByVal yrno As Integer _
                           , ByVal refno As String _
                           , ByVal idate As Date _
                           , ByVal place As String _
                           , ByVal bgno As String _
                           , ByVal bgdate As Date _
                           , ByVal bamt As Decimal _
                           , ByVal insdate As Date _
                           , ByVal ino As String _
                           , ByVal wpno As String _
                           , ByVal vtype As String _
                           , ByVal rno As String _
                           , ByVal pass As Decimal _
                           , ByVal levy As Decimal _
                           , ByVal visa As Decimal _
                           , ByVal process As Decimal _
                           , ByVal ename As String _
                           , ByVal ContractRenewed As Date _
                                                   ) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "hr_pv_updwpdetails", sno, vf, vt, yrno, refno, idate, place, bgno, bgdate, bamt, insdate, ino, wpno, vtype, rno, pass, levy, visa, process, ename, ContractRenewed)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function GetWpDetails(ByVal VNO As String) As DataSet
            SQLstat = "select * from workpermitdetails where rno = '" & VNO & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function ChkWpTable(ByVal VNO As String) As DataSet
            SQLstat = "select * from workpermitdetails where empcode = '" & VNO & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function UpdatePpExp(ByVal eno As String _
                                           , ByVal pno As String _
                                           , ByVal status As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "UpdPpExpDetails", pno, eno, _eid, status)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdatevisaExp(ByVal rno As Integer _
                                           , ByVal pno As String _
                                           , ByVal status As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "UpdvisaExpDetails", pno, rno, _eid, status)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function InsertTempShift(ByVal gcode As String _
                                           , ByVal sdate As Date _
                                           , ByVal scode As String) As Integer
            SQLstat = "insert into trans_shiftfinaltemp(groupcode,shiftdate,shiftcode) values ('" & gcode & "','" & sdate & "','" & scode & "')"
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return recstatus
        End Function
        Public Shared Function DelshiftTemp() As Integer
            SQLstat = "delete from trans_shiftfinaltemp"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function GetTempShift() As DataSet
            SQLstat = "select groupcode,convert(varchar,shiftdate,101) as shiftdate1,shiftcode from trans_shiftfinaltemp"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function InsertCalender(ByVal gcode As String _
                                        , ByVal sdate As Date _
                                        , ByVal scode As String) As Integer
            Try
                posid = emanagement.SqlHelper.ExecuteNonQuery(constr, "hr_insertcalender", gcode, sdate, scode)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return recstatus
        End Function
        '''''''''''''''''''Business trip code'''''''''''''''''''''''

        Public Shared Function GetBtno() As Integer
            SQLstat = "SELECT isnull(max(RECNO),0)+1 AS appno FROM ACC_BUSINESSTRIP"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        '''''''''''''''''''GET Currency Rate'''''''''''''''''''''''

        Public Shared Function GetEXR(ByVal currency As String) As Integer
            SQLstat = ("select exchangeprice from pur_currencymaster where recordno = (select max(recordno) from pur_currencymaster where currencycode = '" & currency & "')")
            RecordId = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return RecordId
        End Function
        '''''''''''''''''''GET USD limit'''''''''''''''''''''''

        Public Shared Function GetUSDLIMIT() As Integer
            SQLstat = ("select amount from HRMIS_BT_USDlimit")
            RecordId = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return RecordId
        End Function
        '''''''''''''''''''GET Cust dest'''''''''''''''''''''''

        Public Shared Function GetCustDestination(ByVal cust As String) As DataSet
            SQLstat = "select distinct cust_group as address from custmaster where customer ='" & cust & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        '''''''''''''''''''GET Supp dest'''''''''''''''''''''''

        Public Shared Function GetSuppDestination(ByVal supp As String) As DataSet
            SQLstat = "select distinct COUNTRY as address from pur_SUPPLIERMASTER where suppliername ='" & supp & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function updateBT(ByVal VNO As String) As DataSet
            SQLstat = "update acc_businesstrip set btstatus = 'SCHEDULED' WHERE recno = '" & VNO & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        '''''''''''''''''''GET Supp dest'''''''''''''''''''''''

        Public Shared Function GetBtInfo(ByVal rno As String) As DataSet
            SQLstat = "select * from acc_businesstrip where recno ='" & rno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        '''''''''''''''''''Travelling claim code'''''''''''''''''''''''

        Public Shared Function GetTCrno() As Integer
            SQLstat = "SELECT isnull(max(RNO),0)+1 AS rno FROM HRMIS_TC_Travellingclaimnew"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function GetREcMedical() As Integer
            SQLstat = "SELECT isnull(max(recordno),0)+1 AS rno FROM tbldiagnose"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        '''''''''''''''''''GET Fare Details ''''''''''''''''''''''

        Public Shared Function GetFareDetails(ByVal rno As String) As DataSet
            SQLstat = "select * from hrmis_bt_taxiflightentry where rno ='" & rno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        '''''''''''''''''''clinic pass  code'''''''''''''''''''''''

        Public Shared Function Getclinicpassno() As Integer
            SQLstat = "SELECT isnull(max(passno),0)+1 AS rno FROM clinicstaffgatepass"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        ''''''''''''''PROGRAMMER MAHA CODES
        Public Shared Function getmaxrecordnumber() As Integer
            SQLstat = "select isnull(max(recordno),0)+1 AS recno  from leaveabsentism"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function Getedata(ByVal txt As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "training_empdetails", txt)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function Getcedata(ByVal txt As String) As DataSet
            SQLstat = "SELECT     *  FROM         empmaster INNER JOIN                        department ON empmaster.departmentcode = department.departmentcode WHERE (empmaster.empcode = ('" & txt & "')) AND (empmaster.resigned = 'N')" ' --commented on 16-06-2014 for Indon Letter --  "select * from empmaster where empcode = ('" & txt & "') and resigned ='N'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As SqlException
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Getppdata(ByVal txt As String) As DataSet
            SQLstat = "select * from passportdetails where empcode = '" & txt & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function getchkval1(ByVal txt As String) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and appointmentletter='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval8(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and dateofkeyin= '" & fdate & "' and transfer='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval9(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and dateofkeyin= '" & fdate & "' and promotion='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval10(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and dateofkeyin= '" & fdate & "' and termination='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval11(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and dateofkeyin= '" & fdate & "' and extensioncontract ='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval12(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and dateofkeyin= '" & fdate & "' and confirmation ='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getcontdet(ByVal txt As String) As DataSet
            SQLstat = "select * from empmaster where empcode = '" & txt & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getcrosschk1(ByVal txt As String) As DataSet
            SQLstat = "select * from emp_insurance where empcode = '" & txt & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getpromdet1(ByVal txt As String) As DataSet
            SQLstat = "select * from emp_probationpromotees where empcode = '" & txt & "' and status='S'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getinspdata(ByVal txt As String) As DataSet
            SQLstat = "select * from designation where designationname = '" & txt & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function


        Public Shared Function getchkval2(ByVal txt As String, ByVal ldate As Date) As DataSet
            SQLstat = "select * from emp_certification where empcode = '" & txt & "' and letterdate='" & ldate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval3(ByVal txt As String, ByVal ldate As Date) As DataSet
            SQLstat = "select * from emp_3daytrainingletter where name = '" & txt & "' and letterdate='" & ldate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval4(ByVal txt As String, ByVal ldate As Date) As DataSet
            SQLstat = "select * from emp_probationpromotees where empcode = '" & txt & "' and letterdate='" & ldate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval5(ByVal txt As String, ByVal ldate As Date) As DataSet
            SQLstat = "select * from emp_unsuccessfulpromotion where empcode = '" & txt & "' and letterdate='" & ldate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval6(ByVal txt As String, ByVal ldate As Date) As DataSet
            SQLstat = "select * from emp_probationextend where empcode = '" & txt & "' and vdate='" & ldate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval7(ByVal txt As String, ByVal ldate As Date) As DataSet
            SQLstat = "select * from emp_probationpromotionextend where empcode = '" & txt & "' and vdate='" & ldate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function Getcdata(ByVal txt As String) As DataSet
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, "certi_empdetails", txt)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Gettrcode() As Integer
            SQLstat = "SELECT isnull(max(td_code),0)+1 AS code  FROM  td_trainingtitles"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function Gettrcatcode() As Integer
            SQLstat = "SELECT isnull(max(categorycode),0)+1 AS code  FROM  td_categorymaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function GetRno() As Integer
            SQLstat = "SELECT isnull(max(recordno),0)+1 AS recno  FROM  Safety_domesticwasteconsignment"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function Gettrlist() As Integer
            SQLstat = "SELECT isnull(max(td_code),0)+1 AS code  FROM  td_traininglist"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function InsertDEdata(ByVal recno As Integer _
                        , ByVal item As String _
                        , ByVal code As String) As Integer
            SQLstat = "insert into Safety_domesticwasteconsignmentdetails (recordno, items, code) values ('" & recno & "','" & item & "','" & code & "')"

            Try
                posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                MyerrorMsg = ex.Message
                recstatus = False
            End Try
            Return recstatus
        End Function
        Public Shared Function GetDEdata(ByVal emp As String) As DataSet
            SQLstat = "select * from safety_temp where empcode='" & emp & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function GetSDWdata(ByVal Description As String) As DataSet
            SQLstat = "select * from safety_schedulemaster where Description='" & Description & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function GetSDWsave(ByVal Description As String, ByVal emp As String) As DataSet
            SQLstat = "select * from safety_temp where vdesc='" & Description & "' and empcode ='" & emp & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function GetsafetytempRec(ByVal Description As String, ByVal emp As String) As DataSet
            SQLstat = "select *,* from safety_temp,safety_schedulemaster where safety_temp.empcode ='" & emp & "' and vdesc = '" & Description & "' and safety_temp.item = safety_schedulemaster.item "
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function DelDEdata(ByVal emp As String) As Integer
            SQLstat = "delete from safety_temp where empcode = '" & emp & "'"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function DelDEdata_desc(ByVal emp As String, ByVal desc As String) As Integer
            SQLstat = "delete from safety_temp where empcode = '" & emp & "' and vdesc = '" & desc & "'"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function Getskillcode(ByVal td_skillcode As String, ByVal area As String) As DataSet
            SQLstat = "select * from td_skillmaster where td_skillcode='" & td_skillcode & "' "
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function GetDEdetails(ByVal item As String) As DataSet
            SQLstat = "select * from safety_schedulemaster where item = '" & item & "' and  description='Schedule Waste' "
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata

        End Function

        Public Shared Function GetDEsubtotal1(ByVal item As String) As DataSet
            SQLstat = "select sum(total) as tot1 from Safety_schedulewasteconsignmentdetails,Safety_domesticwasteconsignment where(Safety_domesticwasteconsignment.recordno = Safety_schedulewasteconsignmentdetails.recordno)and items = '" & item & "' "
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function GetDEsubtotal2(ByVal item As String) As DataSet
            SQLstat = "select sum(dispossalqty) as tot2 from Safety_dispossaldetails where items = '" & item & "' and Major='Schedule Waste'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function


        Public Shared Function getchkval14(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from hr_pfp where empcode = '" & txt & "' and vdate= '" & fdate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function


        Public Shared Function getchkval13(ByVal txt As String, ByVal fdate As Date) As DataSet
            SQLstat = "select * from hr_increment where empcode = '" & txt & "' and letterdate= '" & fdate & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                ' recstatus = False
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function Open_gatepass(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strSelection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM staffgatepass " & strSelection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strSelection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "gatepass")
            Return DS
        End Function



        Public Shared Function Open_gatepassreturn(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strselection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM staffgatepass " & strselection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strselection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "gatepassreturn")
            Return DS
        End Function



        Public Shared Function Open_customerpassin(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strselection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM acc_customerapplication " & strselection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strselection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "customerpassin")
            Return DS
        End Function



        Public Shared Function Open_customerpassout(ByVal cnn As SqlConnection, ByVal da As SqlDataAdapter, ByVal mode As Integer, Optional ByVal strselection As String = "") As DataSet
            'On Error Resume Next
            Select Case mode
                Case 1
                    da.SelectCommand = New SqlCommand("SELECT * FROM acc_customerapplication " & strselection, cnn)
                Case 2
                    da.SelectCommand = New SqlCommand(strselection, cnn)
            End Select

            cb = New SqlCommandBuilder(da)
            DS = New DataSet
            da.Fill(DS, "customerpassout")
            Return DS
        End Function
        Public Shared Function Getsno_manpower() As Integer
            SQLstat = "SELECT isnull(max(requisitionno),0)+1 AS sno FROM  man_replace"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function

        Public Shared Function chkcodeAvail1(ByVal job As String) As DataSet
            SQLstat = "select * from man_jobcode where jobcode ='" & job & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function GetTPMcode() As Integer
            SQLstat = "SELECT isnull(max(code),0)+1 AS codeno FROM  td_ProvidedMaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function Getdesigdet(ByVal txt As String) As DataSet
            SQLstat = "select * from designation where designationname = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getchkval15(ByVal txt As String, ByVal fdate As Date) As DataSet

            Dim d1 As String
            d1 = Format(fdate, "MM/dd/yyyy")

            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and dateofkeyin= '" & d1 & "' and appointmentletter='Y'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function getSWDsum_SWdet(ByVal dep As String, ByVal frd As Date, ByVal tod As Date) As DataSet

            SQLstat = "SELECT sum(weight) as totweightS FROM Safety_domesticwasteconsignment,Safety_schedulewasteconsignmentdetails where majortype= 'Schedule Waste' and dept='" & dep & "' and dateapplied > '" & frd & "' and dateapplied < '" & tod & "' and Safety_domesticwasteconsignment.recordno = Safety_schedulewasteconsignmentdetails.recordno"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function getSWDsum_DWdet(ByVal dep As String, ByVal frd As Date, ByVal tod As Date) As DataSet


            SQLstat = "SELECT sum(weight) as totweightD FROM Safety_domesticwasteconsignment,Safety_domesticwasteconsignmentdetails where majortype= 'Domestic Waste' and dept='" & dep & "' and dateapplied > '" & frd & "' and dateapplied < '" & tod & "' and Safety_domesticwasteconsignment.recordno = Safety_domesticwasteconsignmentdetails.recordno"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Getdepdata(ByVal txt As String) As DataSet
            SQLstat = "select * from department where departmentcode = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Getsecdata(ByVal txt As String) As DataSet
            SQLstat = "select * from sectionmaster where sectioncode = ('" & txt & "')"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function ppgroupmastercode() As Integer
            SQLstat = "SELECT isnull(max(groupcode),0)+1 AS groupcode FROM groupmaster"
            posid = emanagement.SqlHelper.ExecuteScalar(constr, CommandType.Text, SQLstat)
            Return posid
        End Function
        Public Shared Function getchkval0(ByVal txt As String) As DataSet
            SQLstat = "select * from emp_modified where empcode = '" & txt & "' and resign='N'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function chksubmajor(ByVal ecode As String) As DataSet
            SQLstat = "select * from KPI_MajorSetting where Employee_Code = '" & ecode & "' and individual <> 'yes'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        Public Shared Function Getkpidetails(ByVal txt As String, ByVal yer As String) As DataSet
            SQLstat = "select * from KPI_IndividualSetting where Employee_Code = '" & txt & "' and KPI_Year = '" & yer & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function
        '''' mm approvals
        Public Shared Function UpdateLVApprovalMel(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
                    ByVal typ As String, ByVal workfor As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "',statusreason = '" & remarks & "'  where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_mel, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVCApprovalmel(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
       ByVal typ As String, ByVal workfor As Decimal, ByVal noc As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,nocf = '" & noc & "',grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason ='" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_mel, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVRApprovalmel(ByVal passno As String, ByVal status As String, ByVal remarks As String, ByVal emp As String)
            SQLstat = "update Leaveform set status='" & status & "' , approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason = '" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_mel, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdatecfwdLeavemel(ByVal empid As String, ByVal yr As Integer, ByVal bal As Decimal) As DataSet
            SQLstat = "update leavecf set remain = '" & bal & "' where empcode ='" & empid & "' and fortheyear = '" & yr & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_mel, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function UpdateLVApprovalos(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
                  ByVal typ As String, ByVal workfor As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "',statusreason = '" & remarks & "'  where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_os, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVCApprovalos(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
       ByVal typ As String, ByVal workfor As Decimal, ByVal noc As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,nocf = '" & noc & "',grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason ='" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_os, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVRApprovalOs(ByVal passno As String, ByVal status As String, ByVal remarks As String, ByVal emp As String)
            SQLstat = "update Leaveform set status='" & status & "' , approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason = '" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_os, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdatecfwdLeaveos(ByVal empid As String, ByVal yr As Integer, ByVal bal As Decimal) As DataSet
            SQLstat = "update leavecf set remain = '" & bal & "' where empcode ='" & empid & "' and fortheyear = '" & yr & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_os, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function UpdateLVApprovallig(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
                  ByVal typ As String, ByVal workfor As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "',statusreason = '" & remarks & "'  where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_lig, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVCApprovallig(ByVal passno As String, ByVal status As String, ByVal granted As Decimal, _
       ByVal typ As String, ByVal workfor As Decimal, ByVal noc As Decimal, ByVal remarks As String, ByVal emp As String)

            SQLstat = "update Leaveform set status='" & status & "' ,nocf = '" & noc & "',grantedleave = '" & granted & "' ,workfor = '" & workfor & "',leavetype1 = '" & typ & "', approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason ='" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_lig, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateLVRApprovallig(ByVal passno As String, ByVal status As String, ByVal remarks As String, ByVal emp As String)
            SQLstat = "update Leaveform set status='" & status & "' , approvedby = '" & emp & "' ,approveddate = '" & _curdttime & "' ,statusreason = '" & remarks & "' where appno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_lig, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdatecfwdLeavelig(ByVal empid As String, ByVal yr As Integer, ByVal bal As Decimal) As DataSet
            SQLstat = "update leavecf set remain = '" & bal & "' where empcode ='" & empid & "' and fortheyear = '" & yr & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_lig, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata
        End Function

        Public Shared Function UpdateApprovalmmsb(ByVal passno As String, ByVal status As String, ByVal emp As String)
            SQLstat = "update staffgatepass set status='" & status & "' , approvedby = '" & emp & "',approveddate = '" & _curdttime & "'  where passno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        ''05-05-2014 recruitmentapproval error correction
        Public Shared Function UpdateRecruitApprovalmmsb(ByVal status As String, ByVal stsrea As String, ByVal approvedby As String, ByVal dt As String, ByVal recno As String)
            'SQLstat = "update staffgatepass set status='" & status & "' , approvedby = '" & emp & "',approveddate = '" & _curdttime & "'  where passno='" & passno & "'"
            SQLstat = "update man_request set status = '" & status & "',statusreason='" & stsrea & "',approvedby='" & approvedby & "',dateapproval='" & dt & "' where requisitionno = '" & recno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        ''###
        Public Shared Function UpdateApprovalmel(ByVal passno As String, ByVal status As String, ByVal emp As String)
            SQLstat = "update staffgatepass set status='" & status & "' , approvedby = '" & emp & "',approveddate = '" & _curdttime & "'  where passno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_mel, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateApprovalmlg(ByVal passno As String, ByVal status As String, ByVal emp As String)
            SQLstat = "update staffgatepass set status='" & status & "' , approvedby = '" & emp & "',approveddate = '" & _curdttime & "'  where passno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_lig, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        Public Shared Function UpdateApprovalMOU(ByVal passno As String, ByVal status As String, ByVal emp As String)
            SQLstat = "update staffgatepass set status='" & status & "' , approvedby = '" & emp & "',approveddate = '" & _curdttime & "'  where passno='" & passno & "'"
            Try
                dsdata = emanagement.SqlHelper.ExecuteDataset(con_os, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            ' Return posid
            Return recstatus
        End Function
        '04042014
        Public Shared Function GetEmpByDeptByCategory(ByVal dept As String, ByVal Category As String) As DataSet
            If Category = "S" Then
                SQLstat = "select * from empmaster where departmentcode = ('" & dept & "') and resigned = 'N' and designation <> 'OPERATOR'"
            ElseIf Category = "LO" Then
                SQLstat = "select * from empmaster where departmentcode = ('" & dept & "') and resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='N'"
            ElseIf Category = "FO" Then
                SQLstat = "select * from empmaster where departmentcode = ('" & dept & "') and resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='Y'"
            End If

            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function


        Public Shared Function GetEmpBysectByCategory(ByVal sect As String, ByVal Category As String) As DataSet

            If Category = "S" Then
                SQLstat = "select * from empmaster where sectioncode = ('" & sect & "') and resigned = 'N' and designation <> 'OPERATOR'"
            ElseIf Category = "LO" Then
                SQLstat = "select * from empmaster where sectioncode = ('" & sect & "') and resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='N'"
            ElseIf Category = "FO" Then
                SQLstat = "select * from empmaster where sectioncode = ('" & sect & "') and resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='Y'"
            End If



            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function


        Public Shared Function GetEmpByDesigByCategory(ByVal dept As String, ByVal Category As String) As DataSet

            If Category = "S" Then
                SQLstat = "select * from empmaster where designation =('" & dept & "') and resigned = 'N' and designation <> 'OPERATOR'"
            ElseIf Category = "LO" Then
                SQLstat = "select * from empmaster where designation =('" & dept & "') and resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='N'"
            ElseIf Category = "FO" Then
                SQLstat = "select * from empmaster where designation =('" & dept & "') and resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='Y'"
            End If

            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function


        Public Shared Function GetEmpallByCategory(ByVal Category As String) As DataSet

            If Category = "S" Then
                SQLstat = "select * from empmaster where resigned = 'N' and designation <> 'OPERATOR'"
            ElseIf Category = "LO" Then
                SQLstat = "select * from empmaster where resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='N'"
            ElseIf Category = "FO" Then
                SQLstat = "select * from empmaster where resigned = 'N' and designation = 'OPERATOR' and ForeignEmp='Y'"
            End If


            Try
                dsdata1 = emanagement.SqlHelper.ExecuteDataset(constr, CommandType.Text, SQLstat)
                recstatus = True
            Catch ex As Exception
                recstatus = False
                MyerrorMsg = ex.Message
            End Try
            Return dsdata1
        End Function




    End Class
End Namespace




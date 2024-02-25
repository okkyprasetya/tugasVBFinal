Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports System.Net.Mail
Imports System.Security.Cryptography
Imports studentAdmission.BO.studentAdmission.BO
Imports studentAdmission.myInterface.MyInterfaces.DAL

Namespace DAL
    Public Class studentDAL
        Implements IStudentRepository

        Private Const strConn As String = "Server=.\BSISqlExpress;Database=finalProject;Trusted_Connection=True;"

        Public Function GetAll() As IEnumerable(Of Users) Implements IStudentRepository.GetAll
            Dim users As New List(Of Users)()
            Using conn As New SqlConnection(strConn)
                Dim strSql As String = "SELECT * FROM dbo.UserData WHERE RoleID = 2"
                Dim cmd As New SqlCommand(strSql, conn)
                conn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    While dr.Read()
                        users.Add(New Users() With {
                            .userId = Convert.ToInt32(dr("UserID")),
                            .uFName = dr("FirstName").ToString(),
                            .uMName = dr("MiddleName").ToString(),
                            .uLName = dr("LastName").ToString(),
                            .userEmail = dr("UserEmail").ToString(),
                            .roleID = Convert.ToInt32(dr("RoleID"))
                        })
                    End While
                End If

                dr.Close()
                cmd.Dispose()
            End Using

            Return users
        End Function

        Public Sub finalizeMyData(uid As Integer) Implements IStudentRepository.finalizeMyData
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.finalizeApplicantData", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure

                ' Add parameters
                cmd.Parameters.AddWithValue("@UserId", uid)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub AddUser(firstName As String, middleName As String, lastName As String, emailAddress As String, password As String) Implements IUserRepository.AddUser
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.addApplicant", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure

                ' Add parameters
                cmd.Parameters.AddWithValue("@fname", firstName)
                cmd.Parameters.AddWithValue("@midname", middleName)
                cmd.Parameters.AddWithValue("@lname", lastName)
                cmd.Parameters.AddWithValue("@password", password)
                cmd.Parameters.AddWithValue("@email", emailAddress)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub EditUser(firstName As String, middleName As String, lastName As String, uid As Integer) Implements IUserRepository.EditUser
            Throw New NotImplementedException()
        End Sub

        Public Sub DeleteUser(uid As Integer) Implements IUserRepository.DeleteUser
            Throw New NotImplementedException()
        End Sub

        Private Function IUserRepository_GetDataByID(ID As Integer) As IEnumerable(Of Users) Implements IUserRepository.GetDataByID
            Dim users As New List(Of Users)()
            Using conn As New SqlConnection(strConn)
                Dim strSql As String = "SELECT * FROM dbo.UserData where userID = @ID"
                Dim cmd As New SqlCommand(strSql, conn)
                cmd.Parameters.AddWithValue("@ID", ID)

                conn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    While dr.Read()
                        users.Add(New Users() With {
                            .userId = Convert.ToInt32(dr("UserID")),
                            .uFName = dr("FirstName").ToString(),
                            .uMName = dr("MiddleName").ToString(),
                            .uLName = dr("LastName").ToString(),
                            .userEmail = dr("UserEmail").ToString(),
                            .roleID = Convert.ToInt32(dr("RoleID"))
                        })
                    End While
                End If

                dr.Close()
                cmd.Dispose()
            End Using

            Return users
            Throw New NotImplementedException()
        End Function

        Public Sub editGeneralData(GUID As Integer, nis As String, Datebirth As String, isScholarship As Boolean, scholarshipID As Integer) Implements IStudentRepository.editGeneralData
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.completeApplicantData", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                ' Add parameters
                cmd.Parameters.AddWithValue("@UGDataID", GUID)
                cmd.Parameters.AddWithValue("@nis", nis)
                cmd.Parameters.AddWithValue("@datebirth", Datebirth)
                cmd.Parameters.AddWithValue("@isScholarship", isScholarship)
                cmd.Parameters.AddWithValue("@scholarshipID", scholarshipID)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub editPersonalData(GUID As Integer, fatherName As String, fatherAddress As String, fatherJob As String, fathersalary As SqlMoney, motherName As String, motherAddress As String, motherJob As String, motherSalary As SqlMoney, siblingsNumber As Integer, hobi As String, KKDocument As String, BirthDocument As String) Implements IStudentRepository.editPersonalData
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.completePersonalData", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                ' Add parameters
                cmd.Parameters.AddWithValue("@UGDataID", GUID)
                cmd.Parameters.AddWithValue("@FatherName", fatherName)
                cmd.Parameters.AddWithValue("@FatherAddress", fatherAddress)
                cmd.Parameters.AddWithValue("@FatherJob", fatherJob)
                cmd.Parameters.AddWithValue("@FatherSalary", fathersalary)
                cmd.Parameters.AddWithValue("@MotherName", motherName)
                cmd.Parameters.AddWithValue("@MotherAddress", motherAddress)
                cmd.Parameters.AddWithValue("@MotherJob", motherJob)
                cmd.Parameters.AddWithValue("@MotherSalary", motherSalary)
                cmd.Parameters.AddWithValue("@SiblingsNumber", siblingsNumber)
                cmd.Parameters.AddWithValue("@Hobi", hobi)
                cmd.Parameters.AddWithValue("@KKDocument", KKDocument)
                cmd.Parameters.AddWithValue("@BirthDocument", BirthDocument)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub editAcademicData(GUID As Integer, raportSummaries As Integer, raportDocument As String) Implements IStudentRepository.editAcademicData
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.completeAcademicData", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                ' Add parameters
                cmd.Parameters.AddWithValue("@UGDataID", GUID)
                cmd.Parameters.AddWithValue("@RaportSummaries", raportSummaries)
                cmd.Parameters.AddWithValue("@RaportDocument", raportDocument)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub addAchievementRecord(GUID As Integer, title As String, level As String, description As String, achivementDocument As String) Implements IStudentRepository.addAchievementRecord
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.addAchievement", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                ' Add parameters
                cmd.Parameters.AddWithValue("@UGDataID", GUID)
                cmd.Parameters.AddWithValue("@Title", title)
                cmd.Parameters.AddWithValue("@Level", level)
                cmd.Parameters.AddWithValue("@Description", description)
                cmd.Parameters.AddWithValue("@Document", achivementDocument)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub authLogin(email As String, password As String) Implements IUserRepository.authLogin
            Throw New NotImplementedException()
        End Sub

        Public Sub viewRank() Implements IUserRepository.viewRank
            Dim Rank As New List(Of rank)()
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.AssignBillsToStudent", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure

                conn.Open()
                Dim dr As SqlDataReader = cmd.ExecuteReader()

                If dr.HasRows Then
                    While dr.Read()
                        Rank.Add(New rank() With {
                            .rank = Convert.ToInt32(dr("Rank")),
                            .registrationID = dr("RegistrationID").ToString(),
                            .Name = dr("Name").ToString(),
                            .TotalScore = dr("TotalScore").ToString()
                        })
                    End While
                End If

                dr.Close()
                cmd.Dispose()
            End Using
            Throw New NotImplementedException()
        End Sub
    End Class
End Namespace


Imports System.Data.SqlClient
Imports studentAdmission.BO.studentAdmission.BO
Imports studentAdmission.myInterface.MyInterfaces.DAL

Namespace DAL
    Public Class verificatorDAL
        Implements IVerificatorRepository

        Private Const strConn As String = "Server=.\BSISqlExpress;Database=finalProject;Trusted_Connection=True;"

        Public Sub AddUser(firstName As String, middleName As String, lastName As String, emailAddress As String, password As String)
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.addVerificator", conn)
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
        End Sub

        Public Sub EditUser(firstName As String, middleName As String, lastName As String, uid As Integer)
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.editVerificatorData", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure

                ' Add parameters
                cmd.Parameters.AddWithValue("@fname", firstName)
                cmd.Parameters.AddWithValue("@mname", middleName)
                cmd.Parameters.AddWithValue("@lname", lastName)
                cmd.Parameters.AddWithValue("@uid", uid)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Sub

        Public Sub DeleteUser(uid As Integer)
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.deleteVerificator", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure

                ' Add parameters
                cmd.Parameters.AddWithValue("@uid", uid)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Sub



        Public Function GetAll() As IEnumerable(Of Users) Implements IVerificatorRepository.GetAll
            Dim users As New List(Of Users)()
            Using conn As New SqlConnection(strConn)
                Dim strSql As String = "SELECT * FROM dbo.UserData WHERE RoleID = 1"
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

        Private Function GetDataByID(ID As Integer) As IEnumerable(Of Users) Implements IVerificatorRepository.GetDataByID
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

        Public Sub verifyPersonalData(verificatorID As Integer, ugID As Integer) Implements IVerificatorRepository.verifyPersonalData
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.verifyPersonalData", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                ' Add parameters
                cmd.Parameters.AddWithValue("@verificatorID", verificatorID)
                cmd.Parameters.AddWithValue("@UGDataID", ugID)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub verifyAcademicData(verificatorID As Integer, ugID As Integer) Implements IVerificatorRepository.verifyAcademicData
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.verifyAcademicData", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                ' Add parameters
                cmd.Parameters.AddWithValue("@verificatorID", verificatorID)
                cmd.Parameters.AddWithValue("@UGDataID", ugID)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub verifyAchievementRecord(verificatorID As Integer, ugID As Integer) Implements IVerificatorRepository.verifyAchievementRecord
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.verifyAchievementRecord", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure
                ' Add parameters
                cmd.Parameters.AddWithValue("@verificatorID", verificatorID)
                cmd.Parameters.AddWithValue("@UGDataID", ugID)

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub finalizeRank() Implements IVerificatorRepository.finalizeRank
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.finalizeLeaderboard", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Public Sub assignBills() Implements IVerificatorRepository.assignBills
            Using conn As New SqlConnection(strConn)
                Dim cmd As New SqlCommand("dbo.AssignBillsToStudent", conn)
                cmd.CommandType = System.Data.CommandType.StoredProcedure

                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
            Throw New NotImplementedException()
        End Sub

        Private Sub IUserRepository_AddUser(firstName As String, middleName As String, lastName As String, emailAddress As String, password As String) Implements IUserRepository.AddUser
            Throw New NotImplementedException()
        End Sub

        Private Sub IUserRepository_EditUser(firstName As String, middleName As String, lastName As String, uid As Integer) Implements IUserRepository.EditUser
            Throw New NotImplementedException()
        End Sub

        Private Sub IUserRepository_DeleteUser(uid As Integer) Implements IUserRepository.DeleteUser
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


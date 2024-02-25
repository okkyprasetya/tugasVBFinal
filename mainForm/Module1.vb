Imports studentAdmission.BO.studentAdmission.BO
Imports studentAdmission.DAL.DAL
Imports YourProjectNamespace.DAL

Module Module1
    Sub Main(args As String())
        'DOTNET FRAMEWORK VB'
        ' Instantiate repositories
        Dim verificatorRepository As New verificatorDAL()
        Dim studentRepository As New studentDAL()

        '''''''''''''
        'Retrieve all verificator only
        Console.WriteLine("Retrieving all Verificator:")
        Dim allUsers = verificatorRepository.GetAll()
        For Each user In allUsers
            Console.WriteLine($"UserID: {user.userId}, Name: {user.uFName} {user.uMName} {user.uLName}, Email: {user.userEmail}, RoleID: {user.roleID}")
        Next

        ' Add a new verificator
        Console.WriteLine(vbCrLf & "Adding a new user:")
        verificatorRepository.AddUser("John", "Doe", "john.doe@example.com", "password123", "password123")

        ' Update verificator
        Console.WriteLine(vbCrLf & "Updating an existing user:")
        verificatorRepository.EditUser("Jane", "Smith", "jane.smith@example.com", 30)

        '' Delete a verificator
        Console.WriteLine(vbCrLf & "Deleting a user:")
        verificatorRepository.DeleteUser(34)


        'Retrieve all students
        Console.WriteLine("Retrieve all students: ")
        Dim allStudent = studentRepository.GetAll()
        For Each student In allStudent
            Console.WriteLine($"UserID: {student.userId}, Name: {student.uFName} {student.uMName} {student.uLName}, Email: {student.userEmail}, RoleID: {student.roleID}")
        Next

        'Add a new student/ register student'
        Console.WriteLine("Register student")
        studentRepository.AddUser("Michael", "Liu", ".S", "okky@gmail.com", "1234")

        ''Complete data by student (only general data)'
        Console.WriteLine("Completing data: ")
        Console.WriteLine(vbCrLf & "Updating an existing user:")
        studentRepository.editGeneralData(20, "1234567", "1999-10-01", True, 2)

        'complete academic data
        Console.WriteLine("Completing personal data")
        Console.WriteLine(vbCrLf & "Updating an existing user:")
        studentRepository.editAcademicData(20, 95, "Raport 20.pdf")

        'complete personal data
        Console.WriteLine("Completing personal data")
        Console.WriteLine(vbCrLf & "Updating an existing user:")
        studentRepository.editPersonalData(20, "Bapak1", "addres 1", "job1", 4500000, "Ibu2", "addres 2", "job1", 3500000, 2, "Sepakbola", "KK1.Pdf", "BD1.pdf")

        'add achievement record
        Console.WriteLine("Completing personal data")
        Console.WriteLine(vbCrLf & "Updating an existing user:")
        studentRepository.addAchievementRecord(20, "Juara 1 KTI", "Nasional", "Menang juara 1", "Piagam.pdf")

        'finalize my data
        Console.WriteLine("Completing personal data")
        Console.WriteLine(vbCrLf & "Finalizing user data:")
        studentRepository.finalizeMyData(32)

        'data verification by verificator'
        Console.WriteLine("Completing personal data")
        Console.WriteLine(vbCrLf & "Academic Data Verification")
        verificatorRepository.verifyAcademicData(2, 20)

        Console.WriteLine(vbCrLf & "Personal Data Verification")
        verificatorRepository.verifyPersonalData(2, 20)

        Console.WriteLine(vbCrLf & "Achievement Record Verification")
        verificatorRepository.verifyAcademicData(2, 20)

        'show leaderboar
        Console.WriteLine("Current Leaderboard")
        verificatorRepository.viewRank()

        Console.WriteLine("Current Leaderboard")
        studentRepository.viewRank()

        'finalize leaderboard
        Console.WriteLine("Finalize leaderboard")
        verificatorRepository.finalizeRank()

        'assign bills'
        Console.WriteLine("AssignBills")
        verificatorRepository.assignBills()

        Console.WriteLine(vbCrLf & "Press any key to exit...")
        Console.ReadKey()
    End Sub
End Module

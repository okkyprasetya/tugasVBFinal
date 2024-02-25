Imports System.Data.SqlTypes
Imports MyInterfaces.DAL

Namespace MyInterfaces.DAL
    Public Interface IStudentRepository
        Inherits IUserRepository
        Sub finalizeMyData(UID As Integer)

        Sub editGeneralData(GUID As Integer, nis As String, Datebirth As String, isScholarship As Boolean, scholarshipID As Integer)

        Sub editPersonalData(GUID As Integer, fatherName As String, fatherAddress As String, fatherJob As String, fathersalary As SqlMoney, motherName As String, motherAddress As String, motherJob As String, motherSalary As SqlMoney, siblingsNumber As Integer, hobi As String, KKDocument As String, BirthDocument As String)

        Sub editAcademicData(GUID As Integer, raportSummaries As Integer, raportDocument As String)

        Sub addAchievementRecord(GUID As Integer, title As String, level As String, description As String, achivementDocument As String)
    End Interface
End Namespace

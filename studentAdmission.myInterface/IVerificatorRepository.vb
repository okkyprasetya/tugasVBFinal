Imports MyInterfaces.DAL

Namespace MyInterfaces.DAL
    Public Interface IVerificatorRepository
        Inherits IUserRepository
        Sub verifyPersonalData(verificatorID As Integer, ugID As Integer)
        Sub verifyAcademicData(verificatorID As Integer, ugID As Integer)
        Sub verifyAchievementRecord(verificatorID As Integer, ugID As Integer)
        Sub finalizeRank()
        Sub assignBills()

    End Interface
End Namespace

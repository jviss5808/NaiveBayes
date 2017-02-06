Public Class BayesEngine
    Public Vocabulary As New Dictionary(Of String, Integer)
    Public DocumentList As New List(Of DocumentClass)
    Public TotalDocuments As Integer = 0

    Public Function Learn(byval text As List(Of String)) As String
        Dim maxProbability As Double = 0.0
        Dim classification As String = ""

        for each documentClass in DocumentList
            Dim P_cj = documentClass.NumDocuments / TotalDocuments
            Dim n = documentClass.WordPositions

        Next

        Return classification
    End Function
End Class

Public Class DocumentClass
    Public ClassDescriptor As String = String.Empty
    Public NumDocuments As Integer = 0
    Public Vocabulary As New Dictionary(Of String, Integer)
    Public Words As New List(Of String)


    ReadOnly Property WordPositions As Integer
        Get
            Return Words.Count
        End Get
    End Property

End Class
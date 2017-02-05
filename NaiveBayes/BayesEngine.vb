Public Class BayesEngine
    Public Vocabulary As New Dictionary(Of String, Integer)
    Public DocumentList As New List(Of Document)
End Class

Public Class Document
    Public DocumentClass As String = String.Empty
    Public NumDocuments As Integer = 0
    Public Vocabulary As New Dictionary(Of String, Integer)
    Public Words As New List(Of String)
End Class
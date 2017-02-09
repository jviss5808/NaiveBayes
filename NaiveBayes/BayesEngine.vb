Imports System.Security.Cryptography

Public Class BayesEngine
    Public GlobalVocabulary As New Dictionary(Of String, Integer)
    Public DocumentList As New List(Of DocumentClass)
    Public TotalDocuments As Integer = 0

    Public Sub Learn()

        Dim globalVocabSize = GlobalVocabulary.Count

        for i = 0 to DocumentList.Count - 1

            Dim n = DocumentList(i).Words
            
            for each word in GlobalVocabulary.keys

                Dim nk as Integer = 0
                if DocumentList(i).DocumentDictionary.ContainsKey(word) Then
                    nk = DocumentList(i).DocumentDictionary(word)    
                End If

                Dim wordProbability = (nk + 1)/(n + globalVocabSize)
                DocumentList(i).ProbabilityDictionary.Add(word, wordProbability)
                
            Next
        Next

    End Sub

    Public Function Classify(validationText As List(Of String)) As String
        Dim maxProbability as Double = -9999999999
        Dim documentClassification as String = ""

        dim testVal = Math.Log10(.2) + Math.Log10(.8)
        dim testVal2 = Math.Log10(.2) + Math.Log10(.2) 

        for i = 0 to DocumentList.Count - 1
            DIm currentDocumentProbabilityDictionary = DocumentList(i).ProbabilityDictionary
            Dim P_cj = DocumentList(i).NumDocuments / TotalDocuments
            Dim currentProbability as Double = 0
            Dim currentWordProbability As Double = 0
            for each word in validationText
                if currentDocumentProbabilityDictionary.ContainsKey(word)
                    currentWordProbability = currentDocumentProbabilityDictionary(word)
                    if currentProbability = 0 Then
                        currentProbability = Math.Log10(currentWordProbability)
                    Else 
                        currentProbability += Math.log10(currentWordProbability)
                    End If
                End If
            Next

            currentProbability += Math.Log10(P_cj)

            'Dim rand = new Random
            'currentProbability = rand.Next(1000) * rand.Next(10)

            if currentProbability > maxProbability Then
                maxProbability = currentProbability
                documentClassification = DocumentList(i).ClassDescriptor
            End If
        Next

        return documentClassification
    End Function


End Class


Public Class DocumentClass
    Public ClassDescriptor As String = String.Empty
    Public NumDocuments As Integer = 0
    Public ProbabilityDictionary As New Dictionary(Of String, Double)
    Public DocumentDictionary As New Dictionary(Of String, INteger)
    Public Words as integer


End Class
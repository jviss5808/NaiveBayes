Imports System.IO
Imports System.Security.Cryptography

' Small helper class, encapsulates a single document
Public Class DocumentClass
    ' Holds the string descrption of the class
    Public ClassDescriptor As String = String.Empty

    ' The number of training documents in a particular class
    Public NumDocuments As Integer = 0

    ' The dictionary holding the probability of a given word
    Public ProbabilityDictionary As New Dictionary(Of String, Double)

    'Dictionary holding all unique words and respective frequencies
    Public DocumentDictionary As New Dictionary(Of String, Integer)

    ' Number of words in a given docuement
    Public Words As Integer

    ' The count of documents that were correctly classified as this type
    Public CorrectClassificationCount As New Integer

    ' The count of documents wthat were incorrectly classified as this type
    Public IncorrectClassificationCount As New Integer

End Class

Public Class BayesEngine
    ' The global vocabulary of all unique words and respective counts
    Public GlobalVocabulary As New Dictionary(Of String, Integer)
    Public DocumentList As New List(Of DocumentClass)
    Public TotalDocuments As Integer = 0

    Public Sub Learn()

        Dim globalVocabSize = GlobalVocabulary.Count

        ' Rip through each document
        For i = 0 To DocumentList.Count - 1

            Dim n = DocumentList(i).Words

            ' Go through each word in the global vocabulary (all unique words in all documents)
            For Each word In GlobalVocabulary.Keys

                ' Is the word used in the current document? If so, with what frequency (nk)?
                Dim nk As Integer = 0
                If DocumentList(i).DocumentDictionary.ContainsKey(word) Then
                    nk = DocumentList(i).DocumentDictionary(word)
                End If

                ' Compute the word probability
                Dim wordProbability = (nk + 1) / (n + globalVocabSize)

                ' Set the LUT/dictionary value (probability) for this word
                DocumentList(i).ProbabilityDictionary.Add(word, wordProbability)

            Next
        Next

    End Sub

    Public Function Classify(validationText As List(Of String)) As String
        Dim maxProbability As Double = -99999
        Dim documentType As String = ""

        ' Go through each trained document (that we have a probability dictionary for)
        For i = 0 To DocumentList.Count - 1

            Dim currentDocumentProbabilityDictionary = DocumentList(i).ProbabilityDictionary

            ' Calculate the probability estimate of a this class
            Dim P_cj = DocumentList(i).NumDocuments / TotalDocuments
            Dim currentSummedProbability As Double = 0
            Dim currentWordProbability As Double = 0

            ' Rip through each word in the validation text (this is a single validation document)
            For Each word In validationText

                ' If the word is in the current document types dictionary, what's the probability
                If currentDocumentProbabilityDictionary.ContainsKey(word) Then
                    currentWordProbability = currentDocumentProbabilityDictionary(word)
                    If currentSummedProbability = 0 Then
                        currentSummedProbability = Math.Log10(currentWordProbability)
                    Else
                        currentSummedProbability += Math.Log10(currentWordProbability)
                    End If
                End If
            Next

            currentSummedProbability += Math.Log10(P_cj)

            ' Is the document type the most likely candidate? If so, latch the current probability and document type
            If currentSummedProbability > maxProbability Then
                maxProbability = currentSummedProbability
                documentType = DocumentList(i).ClassDescriptor
            End If
        Next

        Return documentType
    End Function


    Public Sub RemoveMostFrequentWords(numMostFrequentWords As Integer)
        ' This isn't terribly efficient... I know, but this is a machine learning class, not a data structures class!
        ' Go through the dicitionaries n times, each time removing the word with the highest frequency
        For i = 0 To numMostFrequentWords - 1
            Dim highestFrequency = 0
            Dim highestFrequencyWord = ""
            For Each word In GlobalVocabulary
                If word.Value > highestFrequency Then
                    highestFrequency = word.Value
                    highestFrequencyWord = word.Key
                End If
            Next


            ' Remove the word from the dictionaries
            GlobalVocabulary.Remove(highestFrequencyWord)
            For j = 0 To DocumentList.Count - 1
                DocumentList(j).DocumentDictionary.Remove(highestFrequencyWord)
            Next

        Next
    End Sub

    Public Sub RemoveMostFrequentEnglishWords()
        ' Filter out the most common 100 english words (these have been stemmed by porter stemmer)
        Using sr As New StreamReader("MostCommonEnglishWords.txt")
            Dim wordArr = sr.ReadLine().Split(" ")

            For i = 0 To wordArr.Length - 1
                ' Remove the word from the dictionaries
                If GlobalVocabulary.ContainsKey(wordArr(i)) Then
                    GlobalVocabulary.Remove(wordArr(i))
                    For j = 0 To DocumentList.Count - 1
                        DocumentList(j).DocumentDictionary.Remove(wordArr(i))
                    Next
                End If
            Next
        End Using
    End Sub

End Class


Imports System.Drawing.Text
Imports System.IO
Public Class Main
    Public BayesEngine As BayesEngine
    Private Sub btnTrain_Click(sender As Object, e As EventArgs) Handles btnTrain.Click
        Train(nudNumWordsToRemove.Value, true)
    End Sub

    Private Function Train(numMostFrequentWordsToRemove As Integer, displayResults As Boolean) As Double
        ' Clear HMI and initialize
        BayesEngine = New BayesEngine()
        Dim prevDocumentType As String = ""
        Dim currentDocument As DocumentClass
        richTextBox.Clear()

        ' Capture some timing info
        Dim startTime = DateTime.Now()

        ' Read the training text and generate appropriate classes
        Using sr As New StreamReader("training.txt")
            While Not sr.EndOfStream
                ' Each line is a document
                Dim currentLine = sr.ReadLine()

                ' Split the document by spaces giving us an array of words
                Dim wordArr = currentLine.Split(" ")

                ' The first word is the document type
                Dim currentDocumentType = wordArr(0)

                ' If we have a new document type...
                If currentDocumentType <> prevDocumentType Then
                    prevDocumentType = currentDocumentType
                    ' We're processing a new document, add the previous one we were creating to the document list
                    If Not currentDocument Is Nothing Then BayesEngine.DocumentList.Add(currentDocument)
                    currentDocument = New DocumentClass
                    currentDocument.ClassDescriptor = currentDocumentType
                End If

                ' Keep track of number of documents we're reading
                BayesEngine.TotalDocuments += 1
                currentDocument.NumDocuments += 1

                ' Go through each word in the current document
                For i = 1 To wordArr.Length - 1
                    Dim currentWord = wordArr(i)

                    ' Populate the global vocabulary (the key is the word, the value is the frequency)
                    If BayesEngine.GlobalVocabulary.ContainsKey(currentWord) Then
                        BayesEngine.GlobalVocabulary(currentWord) += 1
                    Else
                        BayesEngine.GlobalVocabulary.Add(currentWord, 1)
                    End If

                    ' Populate the class vocabulary (the key is the word, the value is the frequency)
                    If currentDocument.DocumentDictionary.ContainsKey(currentWord) Then
                        currentDocument.DocumentDictionary(currentWord) += 1
                    Else
                        currentDocument.DocumentDictionary.Add(currentWord, 1)
                    End If

                    currentDocument.Words += 1

                Next
            End While

        End Using

        ' Add the current document to the document list
        BayesEngine.DocumentList.Add(currentDocument)

        ' This will filter the most common 100 english words from the dictionary
        if cbFilterMostCommonEnglishWords.checked Then
            BayesEngine.RemoveMostFrequentEnglishWords()
        End If

        ' Remove the n most frequent words from the global vocabulary from the dictionaries
        BayesEngine.RemoveMostFrequentWords(numMostFrequentWordsToRemove)
        
        ' Now that we're done reading the data, perform the training
        BayesEngine.Learn()
        
        ' How long did she take?
        Dim trainingTime = (DateTime.Now - startTime).TotalMilliseconds

        If displayResults Then
            richTextBox.AppendText(String.Format("Training Time: {0} ms{1}", trainingTime.ToString("0.00"), vbNewLine))
            ' Display some feedback on the UI
            For Each document In BayesEngine.DocumentList
                richTextBox.AppendText(String.Format("Class: {0} {1} Num Docs: {2}{3}", document.ClassDescriptor, vbTab, document.NumDocuments, vbNewLine))
            Next
        End If

    End Function

    Private Sub btnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        Validate(displayResults:=True)
    End Sub

    Private Function Validate(displayResults As Boolean) As Double
        Dim numDocuments = 0
        Dim correctClassifications = 0

        Dim startTime = DateTime.Now
        ' Read the training text and generate appropriate classes
        Using sr As New StreamReader("validation.txt")
            While Not sr.EndOfStream
                ' Each line is a document
                Dim currentLine = sr.ReadLine()

                ' Split the document by spaces giving us an array of words
                Dim wordArr = currentLine.Split(" ")

                ' Turn it into a list, it just makes life easier
                Dim wordListTrimmed = wordArr.ToList()

                ' Remove the 0th item (this is the document type)
                Dim testDocumentClass = wordListTrimmed(0)
                wordListTrimmed.RemoveAt(0)

                ' Let 'er rip!
                Dim documentClassification = BayesEngine.Classify(wordListTrimmed)

                ' Were we correct? Track global accuracy
                Dim correctlyClassified as Boolean = false
                If documentClassification = testDocumentClass Then
                    correctClassifications += 1
                    correctlyClassified = true
                End If

                ' Track class specific accuracy
                for i = 0 to BayesEngine.DocumentList.Count - 1
                    If testDocumentClass = BayesEngine.DocumentList(i).ClassDescriptor
                        if correctlyClassified Then
                            BayesEngine.DocumentList(i).CorrectClassificationCount += 1
                        Else 
                            BayesEngine.DocumentList(i).IncorrectClassificationCount += 1
                        End If
                        
                    End If
                Next

                numDocuments += 1
            End While
        End Using

        ' How long did she take
        Dim totalRunTime = (DateTime.Now - startTime).TotalMilliseconds

        ' Write class specific results
        using sw As New StreamWriter("ClassificationAccuracy.csv")
            sw.WriteLine("Document Class, Accuracy")
            for each document in BayesEngine.DocumentList
                Dim docAccuracy as Double = document.CorrectClassificationCount / (document.CorrectClassificationCount + document.IncorrectClassificationCount)
                sw.WriteLine(String.Format("{0}, {1}", document.ClassDescriptor, docAccuracy))
            Next
        End Using

        ' What was the global accuracy
        Dim accuracy As Double = correctClassifications / numDocuments
        If displayResults Then
            MessageBox.Show(String.Format("Accuracy: {0}%{1}RunTime: {2} ms", (accuracy * 100).ToString("0.00"), vbNewLine, totalRunTime.ToString("0.00")))
        End If

        Return accuracy
    End Function

    Private Sub btnOptimize_Click(sender As Object, e As EventArgs) Handles btnOptimize.Click
        dim accuracyList as New List(Of Double)
        Dim numWordsRemovedList as New List(Of Integer)

        ' We're going to try to remove the most frequent 0 - n number of words from the global vocabulary
        ' and output the accuracy. This will allow us to find the optimal number of most frequent words to remove
        for i = 0 to 50
            Dim numWordsToRemove = i
            Train(numWordsToRemove, displayResults := false)
            Dim accuracy = validate(displayResults := false)

            accuracyList.Add(accuracy)
            numWordsRemovedList.Add(numWordsToRemove)
        Next

        WriteResults(accuracyList, numWordsRemovedList)
    End Sub

    Private sub WriteResults(accuracyList As List(Of double), numWordsRemovedList As List(Of Integer))
        Using sw As New StreamWriter("results.csv")
            sw.WriteLine("Words Removed, Accuracy")
            for i = 0 to accuracyList.Count - 1
                sw.WriteLine(String.Format("{0},{1}", numWordsRemovedList(i), accuracyList(i)))
            Next
        End Using
        
    End sub
End Class

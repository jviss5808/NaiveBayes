Imports System.IO
Public Class Main
    Public  BayesEngine As New BayesEngine
    Private Sub btnReadTrainingData_Click(sender As Object, e As EventArgs) Handles btnReadTrainingData.Click
       
        Dim prevDocumentType As String = ""
        Dim currentDocument As DocumentClass

        ' Read the training text and generate appropriate classes
        using sr as New StreamReader("training.txt")
            While Not sr.EndOfStream
                ' Each line is a document
                dim currentLine = sr.ReadLine()

                ' Split the document by spaces giving us an array of words
                Dim wordArr = currentLine.Split(" ")

                ' The first word is the document type
                Dim currentDocumentType = wordArr(0)

                ' If we have a new document type...
                If currentDocumentType <> prevDocumentType
                    prevDocumentType = currentDocumentType
                    ' We're processing a new document, add the previous one to the document list
                    If not currentDocument Is Nothing Then bayesEngine.DocumentList.Add(currentDocument)
                    currentDocument = New DocumentClass
                    currentDocument.ClassDescriptor = currentDocumentType
                End If

                bayesEngine.TotalDocuments += 1
                currentDocument.NumDocuments += 1

                For i = 1 To wordArr.Length - 1
                    Dim currentWord = wordArr(i)

                    ' Populate the global vocabulary
                    If bayesEngine.GlobalVocabulary.ContainsKey(currentWord)
                        bayesEngine.GlobalVocabulary(currentWord) += 1
                    Else
                        bayesEngine.GlobalVocabulary.Add(currentWord, 1)
                    End If

                    ' Populate the class vocabulary
                    If currentDocument.DocumentDictionary.ContainsKey(currentWord)
                        currentDocument.DocumentDictionary(currentWord) += 1
                    Else
                        currentDocument.DocumentDictionary.Add(currentWord, 1)
                    End If

                    currentDocument.Words += 1

                Next
            End While
            
        End Using
        
        ' Add the current document to the document list
        bayesEngine.DocumentList.Add(currentDocument)

        BayesEngine.Learn()

        For each document In bayesEngine.DocumentList
            richTextBox.AppendText(String.Format("Class: {0} {1} Num Docs: {2}{3}", document.ClassDescriptor, vbTab, document.NumDocuments, vbnewline))
        Next

    End Sub

    Private Sub btnLearn_Click(sender As Object, e As EventArgs) Handles btnLearn.Click
        Dim numDocuments = 0
        Dim correctClassifications = 0

        dim startTime = DateTime.now
        ' Read the training text and generate appropriate classes
        using sr as New StreamReader("validation.txt")
            While Not sr.EndOfStream
                ' Each line is a document
                dim currentLine = sr.ReadLine()

                ' Split the document by spaces giving us an array of words
                Dim wordArr = currentLine.Split(" ")
                Dim wordListTrimmed = wordArr.ToList()
                wordListTrimmed.RemoveAt(0)

                Dim classification = BayesEngine.Classify(wordListTrimmed)

                if classification = wordArr(0)
                    correctClassifications += 1
                End If

                richTextBox.AppendText(vbNewLine + String.Format("Class: {0} {1} Classification: {2}{3}", wordArr(0), vbTab, classification, vbnewline))
                numDocuments += 1
            End While
        End Using
        dim totalRunTime = (DateTime.Now - startTime).TotalMilliseconds

        dim accuracy as Double = correctClassifications / numDocuments
        MessageBox.Show(String.Format("Accuracy: {0}%{1}RunTime: {2} ms", (accuracy * 100).ToString("0.00"), vbNewLine, totalRunTime.ToString("0.00")))
            
    End Sub

    Private Sub btnTestIntelligence_Click(sender As Object, e As EventArgs) 

    End Sub
End Class

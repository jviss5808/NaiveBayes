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
                    If bayesEngine.Vocabulary.ContainsKey(currentWord)
                        bayesEngine.Vocabulary(currentWord) += 1
                    Else
                        bayesEngine.Vocabulary.Add(currentWord, 1)
                    End If

                    ' Populate the class vocabulary
                    If currentDocument.Vocabulary.ContainsKey(currentWord)
                        currentDocument.Vocabulary(currentWord) += 1
                    Else
                        currentDocument.Vocabulary.Add(currentWord, 1)
                    End If
                    currentDocument.Words.Add(currentWord)

                Next
            End While
            
        End Using
        
        ' Add the current document to the document list
        bayesEngine.DocumentList.Add(currentDocument)

        For each document In bayesEngine.DocumentList
            richTextBox.AppendText(String.Format("Class: {0} {1} Num Docs: {2}{3}", document.ClassDescriptor, vbTab, document.NumDocuments, vbnewline))
        Next

    End Sub

    Private Sub btnLearn_Click(sender As Object, e As EventArgs) Handles btnLearn.Click
        ' Read the training text and generate appropriate classes
        using sr as New StreamReader("validation.txt")
            While Not sr.EndOfStream
                ' Each line is a document
                dim currentLine = sr.ReadLine()

                ' Split the document by spaces giving us an array of words
                Dim wordArr = currentLine.Split(" ")
                Dim wordListTrimmed = wordArr.ToList()
                wordListTrimmed.RemoveAt(0)

                Dim classification = BayesEngine.Learn(wordListTrimmed)

                richTextBox.AppendText(vbNewLine + String.Format("Class: {0} {1} Classification: {2}{3}", wordArr(0), vbTab, classification, vbnewline))
                exit sub
            End While
        End Using
            

    End Sub
End Class

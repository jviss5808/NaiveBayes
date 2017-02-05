Imports System.IO
Public Class Main
    Private Sub trainBtn_Click(sender As Object, e As EventArgs) Handles trainBtn.Click
        Dim bayesEngine As New BayesEngine
        Dim prevDocumentType As String = ""
        Dim currentDocument As Document

        using sr as New StreamReader("training.txt")
            While Not sr.EndOfStream
                dim currentLine = sr.ReadLine()
                Dim wordArr = currentLine.Split(" ")
                Dim currentDocumentType = wordArr(0)

                If currentDocumentType <> prevDocumentType
                    prevDocumentType = currentDocumentType
                    ' We're processing a new document, add the previous one to the document list
                    If not currentDocument Is Nothing Then bayesEngine.DocumentList.Add(currentDocument)
                    currentDocument = New Document
                    currentDocument.DocumentClass = currentDocumentType
                End If

                currentDocument.NumDocuments += 1

                ' Populate the global vocabulary
                For i = 1 To wordArr.Length - 1
                    Dim currentWord = wordArr(i)
                    If bayesEngine.Vocabulary.ContainsKey(currentWord)
                        bayesEngine.Vocabulary(currentWord) += 1
                    Else
                        bayesEngine.Vocabulary.Add(currentWord, 1)
                    End If

                    If currentDocument.Vocabulary.ContainsKey(currentWord)
                        currentDocument.Vocabulary(currentWord) += 1
                    Else
                        currentDocument.Vocabulary.Add(currentWord, 1)
                    End If
                    currentDocument.Words.Add(currentWord)

                Next
            End While
            
        End Using

        bayesEngine.DocumentList.Add(currentDocument)

        For each document In bayesEngine.DocumentList
            richTextBox.AppendText(String.Format("Class: {0} {1} Num Docs: {2}{3}", document.DocumentClass, vbTab, document.NumDocuments, vbnewline))
        Next

        Dim someVal = 10
    End Sub
End Class

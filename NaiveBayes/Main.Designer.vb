<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnReadTrainingData = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.richTextBox = New System.Windows.Forms.RichTextBox()
        Me.btnLearn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'btnReadTrainingData
        '
        Me.btnReadTrainingData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnReadTrainingData.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnReadTrainingData.Location = New System.Drawing.Point(2, 2)
        Me.btnReadTrainingData.Margin = New System.Windows.Forms.Padding(2)
        Me.btnReadTrainingData.Name = "btnReadTrainingData"
        Me.btnReadTrainingData.Size = New System.Drawing.Size(330, 77)
        Me.btnReadTrainingData.TabIndex = 0
        Me.btnReadTrainingData.Text = "Read Training Data"
        Me.btnReadTrainingData.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnReadTrainingData, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.richTextBox, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLearn, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.3908!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.6092!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(669, 444)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'richTextBox
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.richTextBox, 2)
        Me.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox.Location = New System.Drawing.Point(2, 83)
        Me.richTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.richTextBox.Name = "richTextBox"
        Me.richTextBox.Size = New System.Drawing.Size(665, 359)
        Me.richTextBox.TabIndex = 1
        Me.richTextBox.Text = ""
        '
        'btnLearn
        '
        Me.btnLearn.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnLearn.Location = New System.Drawing.Point(336, 2)
        Me.btnLearn.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLearn.Name = "btnLearn"
        Me.btnLearn.Size = New System.Drawing.Size(331, 77)
        Me.btnLearn.TabIndex = 2
        Me.btnLearn.Text = "Learn"
        Me.btnLearn.UseVisualStyleBackColor = true
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(669, 444)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Main"
        Me.Text = "Naive Bayes"
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents btnReadTrainingData As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents richTextBox As RichTextBox
    Friend WithEvents btnLearn As Button
End Class

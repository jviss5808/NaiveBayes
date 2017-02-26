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
        Me.btnTrain = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnValidate = New System.Windows.Forms.Button()
        Me.richTextBox = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.nudNumWordsToRemove = New System.Windows.Forms.NumericUpDown()
        Me.btnOptimize = New System.Windows.Forms.Button()
        Me.cbFilterMostCommonEnglishWords = New System.Windows.Forms.CheckBox()
        Me.TableLayoutPanel1.SuspendLayout
        CType(Me.nudNumWordsToRemove,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'btnTrain
        '
        Me.btnTrain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnTrain.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnTrain.Location = New System.Drawing.Point(2, 2)
        Me.btnTrain.Margin = New System.Windows.Forms.Padding(2)
        Me.btnTrain.Name = "btnTrain"
        Me.btnTrain.Size = New System.Drawing.Size(238, 84)
        Me.btnTrain.TabIndex = 0
        Me.btnTrain.Text = "Train"
        Me.btnTrain.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnTrain, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnValidate, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.richTextBox, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.nudNumWordsToRemove, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnOptimize, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cbFilterMostCommonEnglishWords, 2, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(2)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.96403!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.405406!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.77477!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(726, 444)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnValidate
        '
        Me.btnValidate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnValidate.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnValidate.Location = New System.Drawing.Point(244, 2)
        Me.btnValidate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnValidate.Name = "btnValidate"
        Me.btnValidate.Size = New System.Drawing.Size(238, 84)
        Me.btnValidate.TabIndex = 2
        Me.btnValidate.Text = "Validate"
        Me.btnValidate.UseVisualStyleBackColor = true
        '
        'richTextBox
        '
        Me.TableLayoutPanel1.SetColumnSpan(Me.richTextBox, 3)
        Me.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox.Location = New System.Drawing.Point(2, 113)
        Me.richTextBox.Margin = New System.Windows.Forms.Padding(2)
        Me.richTextBox.Name = "richTextBox"
        Me.richTextBox.Size = New System.Drawing.Size(722, 329)
        Me.richTextBox.TabIndex = 1
        Me.richTextBox.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label1.Location = New System.Drawing.Point(23, 93)
        Me.Label1.Margin = New System.Windows.Forms.Padding(3, 5, 3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Number of Most Frequent Words to Remove"
        '
        'nudNumWordsToRemove
        '
        Me.nudNumWordsToRemove.Location = New System.Drawing.Point(245, 91)
        Me.nudNumWordsToRemove.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.nudNumWordsToRemove.Name = "nudNumWordsToRemove"
        Me.nudNumWordsToRemove.Size = New System.Drawing.Size(120, 20)
        Me.nudNumWordsToRemove.TabIndex = 4
        Me.nudNumWordsToRemove.Value = New Decimal(New Integer() {18, 0, 0, 0})
        '
        'btnOptimize
        '
        Me.btnOptimize.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOptimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.btnOptimize.Location = New System.Drawing.Point(487, 3)
        Me.btnOptimize.Name = "btnOptimize"
        Me.btnOptimize.Size = New System.Drawing.Size(236, 82)
        Me.btnOptimize.TabIndex = 5
        Me.btnOptimize.Text = "Find Optimal Num Words To Remove"
        Me.btnOptimize.UseVisualStyleBackColor = true
        '
        'cbFilterMostCommonEnglishWords
        '
        Me.cbFilterMostCommonEnglishWords.AutoSize = true
        Me.cbFilterMostCommonEnglishWords.Location = New System.Drawing.Point(487, 91)
        Me.cbFilterMostCommonEnglishWords.Name = "cbFilterMostCommonEnglishWords"
        Me.cbFilterMostCommonEnglishWords.Size = New System.Drawing.Size(232, 17)
        Me.cbFilterMostCommonEnglishWords.TabIndex = 6
        Me.cbFilterMostCommonEnglishWords.Text = "Filter Top 100 Most Common English Words"
        Me.cbFilterMostCommonEnglishWords.UseVisualStyleBackColor = true
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(726, 444)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Main"
        Me.Text = "Naive Bayes"
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.TableLayoutPanel1.PerformLayout
        CType(Me.nudNumWordsToRemove,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents btnTrain As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents richTextBox As RichTextBox
    Friend WithEvents btnValidate As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents nudNumWordsToRemove As NumericUpDown
    Friend WithEvents btnOptimize As Button
    Friend WithEvents cbFilterMostCommonEnglishWords As CheckBox
End Class

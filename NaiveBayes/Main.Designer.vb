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
        Me.trainBtn = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.richTextBox = New System.Windows.Forms.RichTextBox()
        Me.TableLayoutPanel1.SuspendLayout
        Me.SuspendLayout
        '
        'trainBtn
        '
        Me.trainBtn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trainBtn.Location = New System.Drawing.Point(3, 3)
        Me.trainBtn.Name = "trainBtn"
        Me.trainBtn.Size = New System.Drawing.Size(278, 41)
        Me.trainBtn.TabIndex = 0
        Me.trainBtn.Text = "Train"
        Me.trainBtn.UseVisualStyleBackColor = true
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50!))
        Me.TableLayoutPanel1.Controls.Add(Me.trainBtn, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.richTextBox, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.3908!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.60919!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(284, 261)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'richTextBox
        '
        Me.richTextBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.richTextBox.Location = New System.Drawing.Point(3, 50)
        Me.richTextBox.Name = "richTextBox"
        Me.richTextBox.Size = New System.Drawing.Size(278, 208)
        Me.richTextBox.TabIndex = 1
        Me.richTextBox.Text = ""
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9!, 20!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 261)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "Main"
        Me.Text = "Naive Bayes"
        Me.TableLayoutPanel1.ResumeLayout(false)
        Me.ResumeLayout(false)

End Sub

    Friend WithEvents trainBtn As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents richTextBox As RichTextBox
End Class

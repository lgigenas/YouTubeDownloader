<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        btnDescargar = New Button()
        txtUrl = New TextBox()
        txtLog = New TextBox()
        SuspendLayout()
        ' 
        ' btnDescargar
        ' 
        btnDescargar.Location = New Point(12, 71)
        btnDescargar.Name = "btnDescargar"
        btnDescargar.Size = New Size(75, 23)
        btnDescargar.TabIndex = 0
        btnDescargar.Text = "Descargar"
        btnDescargar.UseVisualStyleBackColor = True
        ' 
        ' txtUrl
        ' 
        txtUrl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtUrl.Location = New Point(12, 31)
        txtUrl.Name = "txtUrl"
        txtUrl.Size = New Size(429, 23)
        txtUrl.TabIndex = 1
        ' 
        ' txtLog
        ' 
        txtLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtLog.Location = New Point(12, 115)
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.Size = New Size(429, 128)
        txtLog.TabIndex = 2
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(453, 255)
        Controls.Add(txtLog)
        Controls.Add(txtUrl)
        Controls.Add(btnDescargar)
        MinimumSize = New Size(469, 294)
        Name = "Form1"
        Text = "YouTubeDownloader"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnDescargar As Button
    Friend WithEvents txtUrl As TextBox
    Friend WithEvents txtLog As TextBox

End Class

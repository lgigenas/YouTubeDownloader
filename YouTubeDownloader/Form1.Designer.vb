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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        btnDescargar = New Button()
        txtUrl = New TextBox()
        txtLog = New TextBox()
        Label1 = New Label()
        Label2 = New Label()
        cmbFormato = New ComboBox()
        SuspendLayout()
        ' 
        ' btnDescargar
        ' 
        btnDescargar.Location = New Point(12, 78)
        btnDescargar.Name = "btnDescargar"
        btnDescargar.Size = New Size(75, 23)
        btnDescargar.TabIndex = 0
        btnDescargar.Text = "Descargar"
        btnDescargar.UseVisualStyleBackColor = True
        ' 
        ' txtUrl
        ' 
        txtUrl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtUrl.BackColor = Color.FromArgb(CByte(255), CByte(255), CByte(192))
        txtUrl.ForeColor = Color.Black
        txtUrl.Location = New Point(12, 42)
        txtUrl.Name = "txtUrl"
        txtUrl.Size = New Size(429, 23)
        txtUrl.TabIndex = 1
        ' 
        ' txtLog
        ' 
        txtLog.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtLog.Location = New Point(12, 120)
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.ReadOnly = True
        txtLog.Size = New Size(429, 178)
        txtLog.TabIndex = 2
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(12, 18)
        Label1.Name = "Label1"
        Label1.Size = New Size(97, 15)
        Label1.TabIndex = 3
        Label1.Text = "URL de YouTube:"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(124, 81)
        Label2.Name = "Label2"
        Label2.Size = New Size(55, 15)
        Label2.TabIndex = 4
        Label2.Text = "Formato:"
        ' 
        ' cmbFormato
        ' 
        cmbFormato.DropDownStyle = ComboBoxStyle.DropDownList
        cmbFormato.FormattingEnabled = True
        cmbFormato.Location = New Point(185, 78)
        cmbFormato.Name = "cmbFormato"
        cmbFormato.Size = New Size(121, 23)
        cmbFormato.TabIndex = 5
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(453, 310)
        Controls.Add(cmbFormato)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(txtLog)
        Controls.Add(txtUrl)
        Controls.Add(btnDescargar)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(469, 294)
        Name = "Form1"
        Text = "YouTube Downloader (by Leo)"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnDescargar As Button
    Friend WithEvents txtUrl As TextBox
    Friend WithEvents txtLog As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbFormato As ComboBox

End Class

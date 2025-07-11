Imports System.IO

Public Class Form1

    Private ytDlpPath As String = Path.Combine(Path.GetTempPath(), "yt-dlp.exe")
    Private ffmpegPath As String = Path.Combine(Path.GetTempPath(), "ffmpeg.exe")
    Private outputFolder As String = Path.Combine(Application.StartupPath, "Descargas")



    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        cmbFormato.Items.Add("Audio (MP3)")
        cmbFormato.Items.Add("Video (MP4)")
        cmbFormato.SelectedIndex = 0 ' Valor por defecto


        Try
            ExtractEmbeddedResource("YouTubeDownloader.yt-dlp.exe", ytDlpPath)
            ExtractEmbeddedResource("YouTubeDownloader.ffmpeg.exe", ffmpegPath)
        Catch ex As Exception
            MessageBox.Show("Error al extraer ejecutables: " & ex.Message)
            Application.Exit()
        End Try



    End Sub

    Private Sub ExtractEmbeddedResource(resourceName As String, outputPath As String)
        Using stream = Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
            If stream Is Nothing Then
                Throw New Exception("No se encontró el recurso: " & resourceName)
            End If
            Using output = New FileStream(outputPath, FileMode.Create)
                stream.CopyTo(output)
            End Using
        End Using
    End Sub

    Private Sub btnDescargar_Click(sender As Object, e As EventArgs) Handles btnDescargar.Click
        Dim url As String = txtUrl.Text.Trim()
        If String.IsNullOrWhiteSpace(url) Then
            MessageBox.Show("Por favor ingresá una URL.")
            Return
        End If

        ' Abrir el selector de carpeta
        Using fbd As New FolderBrowserDialog
            fbd.Description = "Elegí la carpeta donde se guardarán los MP3"
            If fbd.ShowDialog() <> DialogResult.OK Then
                txtLog.AppendText("Descarga cancelada por el usuario." & vbCrLf)
                Return
            End If
            outputFolder = fbd.SelectedPath
            txtLog.AppendText("Carpeta seleccionada: " & outputFolder & vbCrLf)
        End Using

        btnDescargar.Enabled = False
        txtLog.AppendText("Iniciando descarga..." & vbCrLf)


        Dim args As String = ""

        If cmbFormato.SelectedItem.ToString() = "Audio (MP3)" Then
            args = $"--extract-audio --audio-format mp3 --audio-quality 192K --ffmpeg-location ""{ffmpegPath}"" -o ""{Path.Combine(outputFolder, "%(title)s.%(ext)s")}"" {url}"
        ElseIf cmbFormato.SelectedItem.ToString() = "Video (MP4)" Then
            args = $"-f bestvideo[ext=mp4]+bestaudio[ext=m4a]/mp4 --merge-output-format mp4 --ffmpeg-location ""{ffmpegPath}"" -o ""{Path.Combine(outputFolder, "%(title)s.%(ext)s")}"" {url}"
        End If


        Dim proc As New Process()
        proc.StartInfo.FileName = ytDlpPath
        proc.StartInfo.Arguments = args
        proc.StartInfo.UseShellExecute = False
        proc.StartInfo.RedirectStandardOutput = True
        proc.StartInfo.RedirectStandardError = True
        proc.StartInfo.CreateNoWindow = True

        AddHandler proc.OutputDataReceived, Sub(s, ev)
                                                If ev.Data IsNot Nothing Then
                                                    txtLog.Invoke(Sub() txtLog.AppendText(ev.Data & vbCrLf))
                                                End If
                                            End Sub

        AddHandler proc.ErrorDataReceived, Sub(s, ev)
                                               If ev.Data IsNot Nothing Then
                                                   txtLog.Invoke(Sub() txtLog.AppendText("ERROR: " & ev.Data & vbCrLf))
                                               End If
                                           End Sub

        AddHandler proc.Exited, Sub()
                                    Me.Invoke(Sub()
                                                  btnDescargar.Enabled = True
                                                  MessageBox.Show("Descarga finalizada.", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                              End Sub)
                                End Sub

        Try
            proc.EnableRaisingEvents = True
            proc.Start()
            proc.BeginOutputReadLine()
            proc.BeginErrorReadLine()
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar la descarga: " & ex.Message)
            btnDescargar.Enabled = True
        End Try

    End Sub



End Class

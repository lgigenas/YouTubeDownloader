Imports System.IO

Public Class Form1

    Private ytDlpPath As String = Path.Combine(Path.GetTempPath(), "yt-dlp.exe")
    Private ffmpegPath As String = Path.Combine(Path.GetTempPath(), "ffmpeg.exe")
    Private outputFolder As String = Path.Combine(Application.StartupPath, "Descargas")


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Try
            ExtractEmbeddedResource("YouTubeDownloader.Resources.yt-dlp.exe", ytDlpPath)
            ExtractEmbeddedResource("YouTubeDownloader.Resources.ffmpeg.exe", ffmpegPath)
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

        If Not Directory.Exists(outputFolder) Then
            Directory.CreateDirectory(outputFolder)
        End If

        txtLog.AppendText("Iniciando descarga..." & vbCrLf)

        Dim args As String = $"--extract-audio --audio-format mp3 --audio-quality 192K --ffmpeg-location ""{ffmpegPath}"" -o ""{outputFolder}\%(title)s.%(ext)s"" {url}"

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

        Try
            proc.Start()
            proc.BeginOutputReadLine()
            proc.BeginErrorReadLine()
        Catch ex As Exception
            MessageBox.Show("Error al ejecutar la descarga: " & ex.Message)
        End Try
    End Sub



End Class

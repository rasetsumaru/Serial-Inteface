
Public NotInheritable Class Form_SplashScreen

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Form events"

    Private Sub Form_SplashScreen_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

        Try

            Dim FileOpen As String

            FileOpen = Command()

            If Not FileOpen = "" Then

                FileOpen = FileOpen.Substring(1, FileOpen.Length() - 2)

                If Strings.Right(FileOpen, 5).Equals(".sgss") Or Strings.Right(FileOpen, 5).Equals(".sgsr") Then

                    FileDirectory = Strings.Left(FileOpen, FileOpen.LastIndexOf("\"))
                    FileName = Strings.Right(FileOpen, FileOpen.Length - FileOpen.LastIndexOf("\") - 1)

                    Dim nome_arquivo_ini As String = FileDirectory & "\" & FileName

                    Dim FirmwareData As String = ReadFileChecksum(nome_arquivo_ini, "Firmware", "FR000", SGS_Firmware.Firmware)

                    SGS_Firmware.Firmware = FirmwareData.Substring(0, FirmwareData.IndexOf(" "))
                    SGS_Firmware.ReadFirmwareLibrary()

                    If Strings.Right(FileOpen, 5).Equals(".sgss") Then

                        OpenFormSettings()

                    End If

                    If Strings.Right(FileOpen, 5).Equals(".sgsr") Then

                        OpenFormRecipe()

                    End If

                End If

            End If

            Select Case FileSystem

                Case 1

                    OpenFormRecipe()

                Case 2

                    OpenFormSettings()

            End Select

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

    Private Sub Form_SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try

            If My.Application.Info.Title <> "" Then
                ApplicationTitle.Text = My.Application.Info.Title
            Else
                ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
            End If

            Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

            Copyright.Text = My.Application.Info.Copyright

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

End Class

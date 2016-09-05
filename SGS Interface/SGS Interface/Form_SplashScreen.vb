Public NotInheritable Class Form_SplashScreen

    Private Sub Form_SplashScreen_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed

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

    End Sub

    'TODO: Este formulário pode ser facilmente configurado como a tela inicial da aplicação através da edição da aba "Aplicação"
    '  no Designer de Projeto ("Propriedades" dentro do menu "Projetos").


    Private Sub Form_SplashScreen_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Configura o texto do diálogo em tempo de execução de acordo com a informação do assembly da aplicação.  

        'TODO: Personalize a informação do assembly da aplicação no painel "Aplicação" do diálogo 
        '  propriedades do projeto (dentro do menu "Project").

        'Título da Aplicação
        If My.Application.Info.Title <> "" Then
            ApplicationTitle.Text = My.Application.Info.Title
        Else
            'Se o título da aplicação estiver faltando, utiliza o nome da aplicação sem a extensão
            ApplicationTitle.Text = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)
        End If

        'Formata a informação de versão utilizando o texto configurado no controlador de Versão em tempo de design como a
        '  cadeia de caractere de formatação.  Isto facilita uma localização efetiva quando necessário.
        '  Informação de compilação e revisão poderiam ser incluídos utilizando o seguinte código e modificando o 
        '  texto designtime do controle de versão para "Versão {0}.{1:00}.{2}.{3}" ou algo similar.  Verifique
        '  String.Format() na Ajuda para mais informação.
        '
        '    Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision)

        Version.Text = System.String.Format(Version.Text, My.Application.Info.Version.Major, My.Application.Info.Version.Minor)

        'Informação de Copyright
        Copyright.Text = My.Application.Info.Copyright
    End Sub

End Class

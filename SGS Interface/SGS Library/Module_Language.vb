
Public Module Module_Language

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Functions"

    ' Função de leitura das linguagens
    Public Sub ReadLanguageLibrary()

        Try

            Select Case Language

                Case Is = "English"
                    LanguageEnglish()
                Case Is = "PortuguesBr"

                    LanguagePTBR()

            End Select

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

#Region "Language"

    ' Language English
    Private Sub LanguageEnglish()

        Try

            Label0000 = "Close"
            Label0001 = "Application close"
            Label0002 = "Connect"
            Label0003 = "Connect device"
            Label0004 = "Disconnect"
            Label0005 = "Disconnect device"
            Label0006 = "PCB Interface"
            Label0007 = "USB Usart send"
            Label0008 = "USB Usart receive"
            Label0009 = "Message box"
            Label0010 = "Ok"
            Label0011 = "No"
            Label0012 = "Yes"
            Label0013 = "Connection Status"
            Label0014 = "Product:"
            Label0015 = "Serial:"
            Label0016 = "Hardware:"
            Label0017 = "Firmware:"
            Label0018 = "Disconnected"
            Label0019 = "Confirm message box"
            Label0020 = "Accept suggestion"
            Label0021 = "Deny suggestion"
            Label0022 = "Create recipes"
            Label0023 = "Create new recipe file"
            Label0024 = "File properties"
            Label0025 = "SGS 500 recipes|*.sgsr|SGS 500 settings|*.sgss"
            Label0026 = "Save an SGS-500 file"
            Label0027 = "Browse"
            Label0028 = "Confirm"
            Label0029 = "Cancel"
            Label0030 = "Directory:"

            Message0000 = "USB Usart connected"
            Message0001 = "USB Usart disconnected"
            Message0002 = "Communication failure"
            Message0003 = "Device not found"
            Message0004 = "There is a device connected to the software. Do you want to disconnect it?"
            Message0005 = "The system configuration file not found. The program will load the default settings."

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

    ' Language PortuguesBr
    Private Sub LanguagePTBR()

        Try

            Label0000 = "Fechar"
            Label0001 = "Fechar aplicativo"
            Label0002 = "Conectar"
            Label0003 = "Conectar dispositivo"
            Label0004 = "Desconectar"
            Label0005 = "Desconectar dispositivo"
            Label0006 = "PCB Interface"
            Label0007 = "USB Usart enviar"
            Label0008 = "USB Usart receber"
            Label0009 = "Caixa de messagem"
            Label0010 = "Ok"
            Label0011 = "Não"
            Label0012 = "Sim"
            Label0013 = "Status da Conexão"
            Label0014 = "Produto:"
            Label0015 = "Serial:"
            Label0016 = "Hardware:"
            Label0017 = "Firmware:"
            Label0018 = "Desconectado"
            Label0019 = "Confimar caixa de mensagem"
            Label0020 = "Aceitar suggestion"
            Label0021 = "Negar suggestion"
            Label0022 = "Criar receitas"
            Label0023 = "Criar novo arquivo de receita"
            Label0024 = "Propriedades do arquivo"
            Label0025 = "SGS 500 receitas|*.sgsr|SGS 500 configurações|*.sgss"
            Label0026 = "Salvar um arquivo SGS-500"
            Label0027 = "Procurar"
            Label0028 = "Confirmar"
            Label0029 = "Cancelar"
            Label0030 = "Diretório:"

            Message0000 = "USB Usart conectado"
            Message0001 = "USB Usart desconectado"
            Message0002 = "Falha de comuncação"
            Message0003 = "Dispositivo não encontrado"
            Message0004 = "Existe um dispositivo conectado ao software. Deseja desconectá-lo?"
            Message0005 = "O arquivo de configurações do sistema não encontrado. O programa irá carregar as configurações padrão."

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

End Module

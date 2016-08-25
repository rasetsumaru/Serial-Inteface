
Public Module Module_Language

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Functions"

    ' Função de leitura das linguagens
    Public Sub ReadLanguageLibrary()

        Try

            Select Case Language

                Case Is = LanguageSelect(0)
                    LanguageEnglish()
                Case Is = LanguageSelect(1)
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
            Label0022 = "Create file"
            Label0023 = "Create new file"
            Label0024 = "SGS recipes|*.sgsr|SGS settings|*.sgss"
            Label0025 = "Save an SGS file"
            Label0026 = "Open an SGS file"
            Label0027 = "Edit recipe"
            Label0028 = "Parameters"
            Label0029 = "Name:"
            Label0030 = "Level:"
            Label0031 = "Limits:"
            Label0032 = "Select:"
            Label0033 = "Lower resistance:"
            Label0034 = "Upper resistance:"
            Label0035 = "Lower frequency:"
            Label0036 = "Upper frequency:"
            Label0037 = "Sweep speed:"
            Label0038 = "WAV"
            Label0039 = "Playback timeout:"
            Label0040 = "Memory"
            Label0041 = "Previous"
            Label0042 = "Next"
            Label0043 = "Go to previous recipe"
            Label0044 = "Go to next recipe"
            Label0045 = "Save changes to the file"
            Label0046 = "Close the edition window"

            Message0000 = "USB Usart connected"
            Message0001 = "USB Usart disconnected"
            Message0002 = "Communication failure"
            Message0003 = "Device not found"
            Message0004 = "There is a device connected to the software. Do you want to disconnect it?"
            Message0005 = "The system configuration file not found. The program will load the default settings."
            Message0006 = "Error: Invalid character or characters limit exceeded"
            Message0007 = "Warning: Range of resistance changed"
            Message0008 = "Error: Value out of range or invalid character"

            List0000 = {"Single", "Double", "Continue"}

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
            Label0022 = "Criar arquivo"
            Label0023 = "Criar novo arquivo"
            Label0024 = "SGS receitas|*.sgsr|SGS configurações|*.sgss"
            Label0025 = "Salvar um arquivo SGS"
            Label0026 = "Abrir um arquivo SGS"
            Label0027 = "Editar receita"
            Label0028 = "Parâmetros"
            Label0029 = "Nome:"
            Label0030 = "Nivel:"
            Label0031 = "Limites:"
            Label0032 = "Seleção:"
            Label0033 = "Resistencia inferior:"
            Label0034 = "Resistencia superior:"
            Label0035 = "Frequencia inferior:"
            Label0036 = "Frequencia superior:"
            Label0037 = "Velocidade de sweep:"
            Label0038 = "WAV"
            Label0039 = "Intervalo sem reprodução:"
            Label0040 = "Memória"
            Label0041 = "Anterior"
            Label0042 = "Seguinte"
            Label0043 = "Exibe a receita anterior"
            Label0044 = "Exibe a receita seguinte"
            Label0045 = "Salvar alterações no arquivo"
            Label0046 = "Fecha a janela de edição"

            Message0000 = "USB Usart conectado"
            Message0001 = "USB Usart desconectado"
            Message0002 = "Falha de comuncação"
            Message0003 = "Dispositivo não encontrado"
            Message0004 = "Existe um dispositivo conectado ao software. Deseja desconectá-lo?"
            Message0005 = "O arquivo de configurações do sistema não encontrado. O programa irá carregar as configurações padrão."
            Message0006 = "Erro: Caractere inválido ou limite de caracteres excedido"
            Message0007 = "Atenção: Limites de resistência alterados"
            Message0008 = "Erro: Valor fora dos limites ou caractere inválido"

            List0000 = {"Simples", "Duplo", "Continuo"}

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

End Module

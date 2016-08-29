
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
            Label0047 = "Lower limit: "
            Label0048 = "Upper limit: "
            Label0049 = "Maximum length: "
            Label0050 = "Acceptable characters: "
            Label0051 = "Select sweep mode"
            Label0052 = "Select memory position"
            Label0053 = "Enable help provider"
            Label0054 = "Open file"
            Label0055 = "Open an existing file"
            Label0056 = "Upload"
            Label0057 = "Upload data from device"
            Label0058 = "Download"
            Label0059 = "Download data to device"
            Label0060 = "Edit settings"
            Label0061 = "Enable automatic reset:"
            Label0062 = "Enable inspection:"
            Label0063 = "Lot size:"
            Label0064 = "Operation timeout:"
            Label0065 = "Printer:"
            Label0066 = "Save file"
            Label0067 = "Enables automatic reset of counters"
            Label0068 = "Enables the failure inspection tool"
            Label0069 = "Enables and select the printer protocol"

            Message0000 = "USB Usart connected"
            Message0001 = "USB Usart disconnected"
            Message0002 = "Communication failure"
            Message0003 = "Device not found"
            Message0004 = "There is a device connected to the software. Do you want to disconnect it?"
            Message0005 = "The system configuration file not found. The program will load the default settings."
            Message0006 = "Error: Invalid character or characters limit exceeded"
            Message0007 = "Warning: Range of resistance changed"
            Message0008 = "Error: Value out of range or invalid character"
            Message0009 = "Firmware mismatch or incompatible file"
            Message0010 = "File saved successfully"
            Message0011 = "Memory index doesn't exist"

            List0000 = {"Single", "Double", "Continue"}
            List0001 = {"Switch off", "Switch on"}
            List0002 = {"Switch off", "EPL mode", "ZPL mode"}

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
            Label0047 = "Limite inferior: "
            Label0048 = "Limite superior: "
            Label0049 = "Tamanho máximo: "
            Label0050 = "Caracteres aceitáveis: "
            Label0051 = "Selecione o modo de sweep"
            Label0052 = "Selecione a posição da memória"
            Label0053 = "Habilitar provedor de ajuda"
            Label0054 = "Abrir arquivo"
            Label0055 = "Abrir um arquivo existente"
            Label0056 = "Enviar"
            Label0057 = "Enviar dados para o dispositivo"
            Label0058 = "Carregar"
            Label0059 = "Carregar dados do dispositovo"
            Label0060 = "Editar configurações"
            Label0061 = "Habilitar reset automático:"
            Label0062 = "Habilitar inspeção:"
            Label0063 = "Tamanho do lote:"
            Label0064 = "Intervalo de operação:"
            Label0065 = "Impressora:"
            Label0066 = "Salvar arquivo"
            Label0067 = "Habilita o reset automático dos contadores"
            Label0068 = "Habilita a ferramenta de inspeção de falhas"
            Label0069 = "Habilita e seleciona o protocolo de impressão"

            Message0000 = "USB Usart conectado"
            Message0001 = "USB Usart desconectado"
            Message0002 = "Falha de comuncação"
            Message0003 = "Dispositivo não encontrado"
            Message0004 = "Existe um dispositivo conectado ao software. Deseja desconectá-lo?"
            Message0005 = "O arquivo de configurações do sistema não encontrado. O programa irá carregar as configurações padrão."
            Message0006 = "Erro: Caractere inválido ou limite de caracteres excedido"
            Message0007 = "Atenção: Limites de resistência alterados"
            Message0008 = "Erro: Valor fora dos limites ou caractere inválido"
            Message0009 = "Firmware divergente ou arquivo incompatível"
            Message0010 = "Arquivo salvo com sucesso"
            Message0011 = "Índice de memória não existe"

            List0000 = {"Simples", "Duplo", "Continuo"}
            List0001 = {"Desligado", "Ligado"}
            List0002 = {"Desligado", "Modo EPL", "Modo ZPL"}

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

End Module

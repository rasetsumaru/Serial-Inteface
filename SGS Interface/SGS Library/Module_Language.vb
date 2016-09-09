
Public Module Module_Language

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Functions"

    ' Função de leitura das linguagens
    Public Sub ReadLanguageLibrary()

        Try

            Select Case Language

                Case Is = 0
                    LanguageEnglish()
                Case Is = 1
                    LanguagePTBR()
                Case Is = 2
                    LanguageItaliano()

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

            LanguageSelect = {"English", "PortugueseBr", "Italian"}

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
            Label0038 = "WAV:"
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
            Label0061 = "Operating mode:"
            Label0062 = "Enable automatic reset:"
            Label0063 = "Enable inspection:"
            Label0064 = "Lot size:"
            Label0065 = "Operation timeout:"
            Label0066 = "Printer:"
            Label0067 = "Save file"
            Label0068 = "Select operating mode"
            Label0069 = "Enables automatic reset of counters"
            Label0070 = "Enables the failure inspection tool"
            Label0071 = "Enables and select the printer protocol"
            Label0072 = "Sync clock"
            Label0073 = "Synchronize device date and time"
            Label0074 = "Language:"
            Label0075 = "Select application language"

            Message0000 = "USB Usart connected."
            Message0001 = "USB Usart disconnected."
            Message0002 = "Communication failure."
            Message0003 = "Device not found."
            Message0004 = "There is a device connected to the software. Do you want to disconnect it?"
            Message0005 = "The system configuration file not found. The program will load the default settings."
            Message0006 = "Error: Invalid character or characters limit exceeded."
            Message0007 = "Warning: Range of resistance changed."
            Message0008 = "Error: Value out of range or invalid character."
            Message0009 = "Firmware mismatch or incompatible file."
            Message0010 = "File saved successfully."
            Message0011 = "Memory index doesn't exist."
            Message0012 = "File transfer completed successfully."
            Message0013 = "Updated clock."
            Message0014 = "Cannot read file from disk."
            Message0015 = "Failure to open the serial port"
            Message0016 = "Try again?"

            List0000 = {"Single", "Double", "Continue"}
            List0001 = {"Sine", "Sine/WAV", "WAV"}
            List0002 = {"Switch off", "Switch on"}
            List0003 = {"Switch off", "EPL mode", "ZPL mode"}

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

    ' Language PortuguesBr
    Private Sub LanguagePTBR()

        Try

            LanguageSelect = {"Inglês", "PortuguêsBR", "Italiano"}

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
            Label0020 = "Aceitar sugestão"
            Label0021 = "Negar sugestão"
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
            Label0038 = "WAV:"
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
            Label0056 = "Carregar"
            Label0057 = "Carregar dados do dispositivo"
            Label0058 = "Enviar"
            Label0059 = "Enviar dados para o dispositivo"
            Label0060 = "Editar configurações"
            Label0061 = "Modo de operação:"
            Label0062 = "Habilitar reset automático:"
            Label0063 = "Habilitar inspeção:"
            Label0064 = "Tamanho do lote:"
            Label0065 = "Intervalo de operação:"
            Label0066 = "Impressora:"
            Label0067 = "Salvar arquivo"
            Label0068 = "Selecione o modo de operação"
            Label0069 = "Habilita o reset automático dos contadores"
            Label0070 = "Habilita a ferramenta de inspeção de falhas"
            Label0071 = "Habilita e seleciona o protocolo de impressão"
            Label0072 = "Sinc. o relógio"
            Label0073 = "Sincronizar data e hora do dispositivo"
            Label0074 = "Linguagem:"
            Label0075 = "Selecione a linguagem do aplicativo"

            Message0000 = "USB Usart conectado."
            Message0001 = "USB Usart desconectado."
            Message0002 = "Falha de comuncação."
            Message0003 = "Dispositivo não encontrado."
            Message0004 = "Existe um dispositivo conectado ao software. Deseja desconectá-lo?"
            Message0005 = "O arquivo de configurações do sistema não encontrado. O programa irá carregar as configurações padrão."
            Message0006 = "Erro: Caractere inválido ou limite de caracteres excedido."
            Message0007 = "Atenção: Limites de resistência alterados."
            Message0008 = "Erro: Valor fora dos limites ou caractere inválido."
            Message0009 = "Firmware divergente ou arquivo incompatível."
            Message0010 = "Arquivo salvo com sucesso."
            Message0011 = "Índice de memória não existe."
            Message0012 = "Transferência do arquivo realizada com sucesso."
            Message0013 = "Relógio atualizado."
            Message0014 = "Não foi possível ler o arquivo do disco."
            Message0015 = "Falha ao abrir a porta serial"
            Message0016 = "Tentar novamente?"

            List0000 = {"Simples", "Duplo", "Continuo"}
            List0001 = {"Sine", "Sine/WAV", "WAV"}
            List0002 = {"Desligado", "Ligado"}
            List0003 = {"Desligado", "Modo EPL", "Modo ZPL"}

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

    'Language Italiano
    Private Sub LanguageItaliano()

        Try

            LanguageSelect = {"Inglese", "PortugueseBr", "Italiano"}

            Label0000 = "Vicino"
            Label0001 = "Applicazione vicino"
            Label0002 = "Collegare"
            Label0003 = "Collegare il dispositivo"
            Label0004 = "Disconnect"
            Label0005 = "Disconnettersi dal dispositivo"
            Label0006 = "Interfaccia PCB"
            Label0007 = "USB USART invio"
            Label0008 = "USB USART ricevere"
            Label0009 = "Casella dei messaggi"
            Label0010 = "Ok"
            Label0011 = "No"
            Label0012 = "Sì"
            Label0013 = "Stato connessione"
            Label0014 = "Prodotto:"
            Label0015 = "Seriale:"
            Label0016 = "Hardware:"
            Label0017 = "Firmware:"
            Label0018 = "Scollegato"
            Label0019 = "Finestra di messaggio conferma"
            Label0020 = "Accetta suggerimento"
            Label0021 = "Nega suggerimento"
            Label0022 = "Creare il file"
            Label0023 = "Crea nuovo file"
            Label0024 = "SGS ricette |*.sgsr|SGS impostazioni |*.sgss"
            Label0025 = "Salvare un file SGS"
            Label0026 = "Aprire un file di SGS"
            Label0027 = "Modifica ricetta"
            Label0028 = "Parametri"
            Label0029 = "Nome:"
            Label0030 = "Livello:"
            Label0031 = "Limiti:"
            Label0032 = "Selezionare:"
            Label0033 = "Minore resistenza:"
            Label0034 = "Resistenza superiore:"
            Label0035 = "Frequenza più bassa:"
            Label0036 = "Frequenza superiore:"
            Label0037 = "Velocità di sweep:"
            Label0038 = "WAV:"
            Label0039 = "Timeout di riproduzione:"
            Label0040 = "Memoria:"
            Label0041 = "Precedente"
            Label0042 = "Prossimo"
            Label0043 = "Vai alla ricetta precedente"
            Label0044 = "Vai alla prossima ricetta"
            Label0045 = "Salvare le modifiche al file"
            Label0046 = "Chiudere la finestra edizione"
            Label0047 = "Limite inferiore: "
            Label0048 = "Limite superiore: "
            Label0049 = "Lunghezza massima: "
            Label0050 = "Caratteri accettabili: "
            Label0051 = "Selezionare la modalità di sweep"
            Label0052 = "Selezionare la posizione di memoria"
            Label0053 = "Abilita fornitore di aiuto"
            Label0054 = "File aperto"
            Label0055 = "Aprire un file esistente"
            Label0056 = "Caricare"
            Label0057 = "Carica i dati dal dispositivo"
            Label0058 = "Scaricare"
            Label0059 = "Trasmissione dati a dispositivi"
            Label0060 = "Modifica impostazioni"
            Label0061 = "Modalità di funzionamento:"
            Label0062 = "Attiva ripristino automatico:"
            Label0063 = "Abilita ispezione:"
            Label0064 = "Dimensione del lotto:"
            Label0065 = "Timeout funzionamento:"
            Label0066 = "Stampante:"
            Label0067 = "Salvare il file "
            Label0068 = "Selezionare la modalità operativa"
            Label0069 = "Abilita il ripristino automatico dei contatori"
            Label0070 = "Consente lo strumento di ispezione fallimento"
            Label0071 = "Abilita e selezionare il protocollo di stampa"
            Label0072 = "Clock sync"
            Label0073 = "Sincronizzare la data e l' ora del dispositivo"
            Label0074 = "Lingua:"
            Label0075 = "Selezionare la lingua dell'applicazione"

            Message0000 = "USB USART collegato."
            Message0001 = "USART USB scollegato."
            Message0002 = "Errore di comunicazione."
            Message0003 = "Dispositivo non trovato."
            Message0004 = "Vi è un dispositivo collegato al software. Si vuole staccare?"
            Message0005 = "Il file di configurazione del sistema non trovato. Il programma caricherà le impostazioni predefinite."
            Message0006 = "Errore : carattere o caratteri non validi Limite superato."
            Message0007 = "Attenzione : Gamma di resistenza è cambiato."
            Message0008 = "Errore : Valore fuori campo o carattere non valido."
            Message0009 = "Mancata corrispondenza del firmware o un file non compatibile."
            Message0010 = "File salvato con successo."
            Message0011 = "Indice di memoria non esiste."
            Message0012 = "Trasferimento file completato con successo."
            Message0013 = "Orologio aggiornato."
            Message0014 = "Impossibile leggere il file dal disco."
            Message0015 = "La mancata per aprire la porta seriale"
            Message0016 = "Riprovare?"

            List0000 = {"Singolo", "Doppio", "Continuare"}
            List0001 = {"Sinusoidale", "Sinusoidale/WAV", "WAV"}
            List0002 = {"Spegnere", "Accendere"}
            List0003 = {"Spegnere", "Modalità EPL", "Modalità ZPL"}

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

End Module


Public Module Module_Firmware

#Region "Declarations"

    Private Declare Auto Function WritePrivateProfileString Lib "Kernel32" (ByVal lpAppName As String, ByVal lpKeyName As String, ByVal ByVallpString As String, ByVal lpFileName As String) As Integer

#End Region

#Region "Functions"

    ' Função de leitura dos firmwares
    Public Sub ReadFirmwareLibrary()

        Try

            Select Case Firmware

                Case Is = FirmwareSelect(0)
                    Firmware159()

                Case Is = FirmwareSelect(1)
                    Firmware160()

            End Select

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

#Region "Firmware"

    ' Firmware 1.59
    Private Sub Firmware159()

        Try

            FirmwareString = "                  130  130    20    20   1  200 0   1     1  1  "
            SettingsString = " 0    1 0     0     0     1  2 0 0                              "

            ParametersFormat = {"", "00.00 Rms", "00000", "", "00.00 Ohm", "00.00 Ohm", "00000 Hz", "00000 Hz", "000 '%", "000 Rec", "00 seg"}
            ValidationRecipeMinimum = {"16", "2", "1", "0", "1,30", "1,30", "20", "20", "1", "1", "1"}
            ValidationRecipeMaximum = {"[^0-9a-zA-Z ]+", "18", "50000", "2", "30", "30", "30000", "30000", "100", "255", "10"}

            SettingsFormat = {"", "", "0000", "00 seg", ""}
            ValidationSettingMinimum = {"0", "0", "1", "2", "0"}
            ValidationSettingMaximum = {"1", "1", "50000", "10", "2"}

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

    ' Firmware 1.60
    Private Sub Firmware160()

        Try

            FirmwareString = "                  130  130    20    20   1  200 0   1     1  1  "
            SettingsString = " 0    1 0     0     0     1  2 0 0                              "

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub
#End Region

End Module

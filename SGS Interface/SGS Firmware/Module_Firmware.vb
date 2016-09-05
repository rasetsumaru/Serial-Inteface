
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
            ValidationRecipeMaximum = {"[^0-9a-zA-Z ]+", "18", "30000", "2", "30", "30", "30000", "30000", "100", "255", "10"}

            SettingsFormat = {"", "", "", "00000", "00 seg", ""}
            ValidationSettingMinimum = {"0", "0", "0", "1", "2", "0"}
            ValidationSettingMaximum = {"2", "1", "1", "30000", "10", "2"}

            ListValidateEdit = {"1,30", "18,00", "7,00", "30,00", "130", "700"}

            ListRecipeEditSubstrings = {5, 16, 21, 5, 26, 5, 31, 6, 37, 6, 43, 4, 47, 5, 52, 2, 54, 4, 58, 6, 64, 3}
            ListRecipeEditEdit = {0, 6, 9, 7, 1, 2, 3, 4, 5, 8, 10}
            ListSaveEditRamRecipeEqualizer = {16, 5, 5, 6, 6, 4, 5, 2, 4, 6, 3}
            ListSaveEditRamEdit = {0, 4, 5, 6, 7, 8, 1, 3, 9, 2, 10}
            ListSettingsLoadSubstrings = {5, 2, 12, 2, 26, 6, 32, 3, 35, 2, 37, 2}
            ListSettingsLoadEdit = {0, 5, 1, 2, 3, 4}
            ListSaveSettingsSubstrings = {5, 2, 12, 2, 26, 6, 32, 3, 35, 2, 37, 2}
            ListSaveSettingsEdit = {0, 5, 1, 2, 3, 4}
            ListSaveSettingsSettingEqualizer = {2, 2, 6, 3, 2, 2}

            RecipesSize = 500

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

    ' Firmware 1.60
    Private Sub Firmware160()

        Try

        Catch ex As Exception

            WritePrivateProfileString("Error >> " & Format(Now, "MM/dd/yyyy"), " >> " & Format(Now, "HH:mm:ss") & " >> Erro = ", ex.Message & " - " & ex.StackTrace & " - " & ex.Source, NomeArquivoINI(DirLogsError))

        End Try

    End Sub

#End Region

End Module

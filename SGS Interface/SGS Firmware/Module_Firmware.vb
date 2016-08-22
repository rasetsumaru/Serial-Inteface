
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

            ParametersFormat = {"", "00.00", "00000", "", "00.00", "00.00", "00000", "00000", "000", "000", "00"}

            'Dim resistancelowermim, resistanceuppermax As Integer

            'If variables[0][5] < 1000 Then
            'resistancelowermim = 0130
            'resistanceuppermax = 1800
            '
            'Else
            'resistancelowermim = 0700
            'resistanceuppermax = 3000
            'End If
            '
            'MinimumLimitList(00) = 200
            'MinimumLimitList(01) = 1
            'MinimumLimitList(02) = resistancelowermim
            'MinimumLimitList(03) = 0 'currentrecipe[5]
            'MinimumLimitList(04) = 20
            'MinimumLimitList(05) = 0 'currentrecipe[7]
            'MinimumLimitList(06) = 1
            'MinimumLimitList(07) = 1
            'MinimumLimitList(08) = 1
            '
            'MaximumLimitList(00) = 1800
            'MaximumLimitList(01) = 50000
            'MaximumLimitList(02) = 0 'currentrecipe[6]
            'MaximumLimitList(03) = resistanceuppermax
            'MaximumLimitList(04) = 0 'currentrecipe[8]
            'MaximumLimitList(05) = 30000
            'MaximumLimitList(06) = 100
            'MaximumLimitList(07) = 255
            'MaximumLimitList(08) = 10

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

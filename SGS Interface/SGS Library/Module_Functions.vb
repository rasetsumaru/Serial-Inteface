
Public Module Module_Functions

#Region "Functions"

    'Nome do Arquivo *.ini
    Public Function NomeArquivoINI(ByVal Diretorio As String) As String

        Dim nome_arquivo_ini As String = AppDomain.CurrentDomain.BaseDirectory().Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 3, 3)
        nome_arquivo_ini = nome_arquivo_ini.Substring(0, nome_arquivo_ini.LastIndexOf("\"))

        Return nome_arquivo_ini & Diretorio

    End Function

#End Region

End Module

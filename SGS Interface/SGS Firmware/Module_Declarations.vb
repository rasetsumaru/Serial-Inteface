
Public Module Module_Declarations

#Region "Config"

    Public DirLogsError As String = "\System\SGSError.ini"

#End Region

#Region "Firmwares"

    Public Firmware As String
    Public Settings As String

    Public FirmwareSelect() As String = {"1.59", "1.60"}

#End Region

#Region "Strings"

    Public FirmwareString As String = "                  130  130    20    20   1  200 0   1     1  1  "
    Public SettingsString As String = " 0    1 0     0     0     1  2 0 0                              "

#End Region

#Region "Lists"

    Public ParametersFormat() As String = {"", "00.00 Rms", "00000", "", "00.00 Ohm", "00.00 Ohm", "00000 Hz", "00000 Hz", "000 '%", "000 Rec", "00 seg"}
    Public ValidationRecipeMinimum() As String = {"16", "2", "1", "0", "1,30", "1,30", "20", "20", "1", "1", "1"}
    Public ValidationRecipeMaximum() As String = {"[^0-9a-zA-Z ]+", "18", "30000", "2", "30", "30", "30000", "30000", "100", "255", "10"}

    Public SettingsFormat() As String = {"", "", "", "00000", "00 seg", ""}
    Public ValidationSettingMinimum() As String = {"0", "0", "0", "1", "2", "0"}
    Public ValidationSettingMaximum() As String = {"2", "1", "1", "30000", "10", "2"}

    Public ListValidateEdit() As String = {"1,30", "18,00", "7,00", "30,00", "130", "700"}

    Public ListRecipeEditSubstrings() As Integer = {5, 16, 21, 5, 26, 5, 31, 6, 37, 6, 43, 4, 47, 5, 52, 2, 54, 4, 58, 6, 64, 3}
    Public ListRecipeEditEdit() As Integer = {0, 6, 9, 7, 1, 2, 3, 4, 5, 8, 10}

    Public ListSaveEditRamRecipeEqualizer() As Integer = {16, 5, 5, 6, 6, 4, 5, 2, 4, 6, 3}
    Public ListSaveEditRamEdit() As Integer = {0, 4, 5, 6, 7, 8, 1, 3, 9, 2, 10}
    Public ListSettingsLoadSubstrings() As Integer = {5, 2, 12, 2, 26, 6, 32, 3, 35, 2, 37, 2}
    Public ListSettingsLoadEdit() As Integer = {0, 5, 1, 2, 3, 4}
    Public ListSaveSettingsSubstrings() As Integer = {5, 2, 12, 2, 26, 6, 32, 3, 35, 2, 37, 2}
    Public ListSaveSettingsEdit() As Integer = {0, 5, 1, 2, 3, 4}
    Public ListSaveSettingsSettingEqualizer() As Integer = {2, 2, 6, 3, 2, 2}

#End Region

#Region "Integers"

    Public RecipesSize As Integer = 500

#End Region

End Module

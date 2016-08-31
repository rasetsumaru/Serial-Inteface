
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

    Public ParametersFormat() As String = {"", "00.00 Rms", "00000", "", "00.00 Ohm", "00.00 Ohm", "00000 Hz", "00000 Hz", "000 %", "000 Rec", "00 seg"}
    Public ValidationRecipeMinimum() As String = {"16", "2", "1", "0", "1,30", "1,30", "20", "20", "1", "1", "1"}
    Public ValidationRecipeMaximum() As String = {"[^0-9a-zA-Z ]+", "18", "50000", "2", "30", "30", "30000", "30000", "100", "255", "10"}

    Public SettingsFormat() As String = {"", "", "", "00000", "00 seg", ""}
    Public ValidationSettingMinimum() As String = {"0", "0", "0", "1", "2", "0"}
    Public ValidationSettingMaximum() As String = {"2", "1", "1", "50000", "10", "2"}

#End Region

End Module

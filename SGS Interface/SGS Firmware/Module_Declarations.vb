
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
    Public ValidationMinimum() As String = {"16", "2", "1", "0", "1,30", "1,30", "20", "20", "1", "1", "1"}
    Public ValidationMaximum() As String = {"[^0-9a-zA-Z ]+", "18", "50000", "2", "30", "30", "30000", "30000", "100", "255", "10"}

#End Region



#Region "Limits"

    'Public MinimumLimit0000 As Integer
    'Public MinimumLimit0001 As Integer
    'Public MinimumLimit0002 As Integer
    'Public MinimumLimit0003 As Integer
    'Public MinimumLimit0004 As Integer
    'Public MinimumLimit0005 As Integer
    'Public MinimumLimit0006 As Integer
    'Public MinimumLimit0007 As Integer
    'Public MinimumLimit0008 As Integer
    'Public MinimumLimit0009 As Integer
    'Public MinimumLimit0010 As Integer
    '
    'Public MaximumLimit0000 As Integer
    'Public MaximumLimit0001 As Integer
    'Public MaximumLimit0002 As Integer
    'Public MaximumLimit0003 As Integer
    'Public MaximumLimit0004 As Integer
    'Public MaximumLimit0005 As Integer
    'Public MaximumLimit0006 As Integer
    'Public MaximumLimit0007 As Integer
    'Public MaximumLimit0008 As Integer
    'Public MaximumLimit0009 As Integer
    'Public MaximumLimit0010 As Integer
    '
    'Public MinimumLimitList As Integer()
    'Public MaximumLimitList As Integer()

#End Region

End Module


Public Module Module_Declarations

#Region "Config"

    Public DirLogsError As String = "\System\SGSError.ini"

#End Region

#Region "Language"

    Public Language As String
    Public LanguageSelect() As String = {"English", "PortuguesBr"}

#End Region

#Region "Labels"

    Public Label0000 As String = "Close"
    Public Label0001 As String = "Application close."
    Public Label0002 As String = "Connect"
    Public Label0003 As String = "Connect device"
    Public Label0004 As String = "Disconnect"
    Public Label0005 As String = "Disconnect device"
    Public Label0006 As String = "PCB Interface"
    Public Label0007 As String = "USB Usart send"
    Public Label0008 As String = "USB Usart receive"
    Public Label0009 As String = "Message box"
    Public Label0010 As String = "Ok"
    Public Label0011 As String = "No"
    Public Label0012 As String = "Yes"
    Public Label0013 As String = "Connection Status"
    Public Label0014 As String = "Product:"
    Public Label0015 As String = "Serial:"
    Public Label0016 As String = "Hardware:"
    Public Label0017 As String = "Firmware:"
    Public Label0018 As String = "Disconnected"
    Public Label0019 As String = "Confirm message box"
    Public Label0020 As String = "Accept suggestion"
    Public Label0021 As String = "Deny suggestion"
    Public Label0022 As String = "Create file"
    Public Label0023 As String = "Create new file"
    Public Label0024 As String = "SGS recipes|*.sgsr|SGS settings|*.sgss"
    Public Label0025 As String = "Save an SGS file"
    Public Label0026 As String = "Open an SGS file"

#End Region

#Region "Messages"

    Public Message0000 As String = "USB Usart connected"
    Public Message0001 As String = "USB Usart disconnected"
    Public Message0002 As String = "Communication failure"
    Public Message0003 As String = "Device not found"
    Public Message0004 As String = "There is a device connected to the software. Do you want to disconnect it?"
    Public Message0005 As String = "The system configuration file not found. The program will load the default settings."

#End Region

#Region "Lists"

    Public List0000() As String = {"Single", "Double", "Continue"}

#End Region

End Module

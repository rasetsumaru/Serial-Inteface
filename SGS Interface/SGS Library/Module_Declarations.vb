
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
    Public Label0027 As String = "Edit recipe"
    Public Label0028 As String = "Parameters"
    Public Label0029 As String = "Name:"
    Public Label0030 As String = "Level:"
    Public Label0031 As String = "Limits:"
    Public Label0032 As String = "Select:"
    Public Label0033 As String = "Lower resistance:"
    Public Label0034 As String = "Upper resistance:"
    Public Label0035 As String = "Lower frequency:"
    Public Label0036 As String = "Upper frequency:"
    Public Label0037 As String = "Sweep speed:"
    Public Label0038 As String = "WAV"
    Public Label0039 As String = "Playback timeout:"
    Public Label0040 As String = "Memory"
    Public Label0041 As String = "Previous"
    Public Label0042 As String = "Next"
    Public Label0043 As String = "Go to previous recipe"
    Public Label0044 As String = "Go to next recipe"
    Public Label0045 As String = "Save changes to the file"
    Public Label0046 As String = "Close the edition window"
    Public Label0047 As String = "Lower limit: "
    Public Label0048 As String = "Upper limit: "
    Public Label0049 As String = "Maximum length: "
    Public Label0050 As String = "Acceptable characters: "
    Public Label0051 As String = "Select sweep mode"
    Public Label0052 As String = "Select memory position"
    Public Label0053 As String = "Enable help provider"

    Public Label0054 As String = "Open file"
    Public Label0055 As String = "Open an existing file"
    Public Label0056 As String = "Upload"
    Public Label0057 As String = "Upload data from device"
    Public Label0058 As String = "Download"
    Public Label0059 As String = "Download data to device"

#End Region

#Region "Messages"

    Public Message0000 As String = "USB Usart connected"
    Public Message0001 As String = "USB Usart disconnected"
    Public Message0002 As String = "Communication failure"
    Public Message0003 As String = "Device not found"
    Public Message0004 As String = "There is a device connected to the software. Do you want to disconnect it?"
    Public Message0005 As String = "The system configuration file not found. The program will load the default settings."
    Public Message0006 As String = "Error: Invalid character or characters limit exceeded"
    Public Message0007 As String = "Warning: Range of resistance changed"
    Public Message0008 As String = "Error: Value out of range or invalid character"
    Public Message0009 As String = "Firmware mismatch or incompatible file"

#End Region

#Region "Lists"

    Public List0000() As String = {"Single", "Double", "Continue"}

#End Region

End Module

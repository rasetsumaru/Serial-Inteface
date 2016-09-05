
Public Module Module_Declarations

#Region "Config"

    Public DirLogsError As String = "\System\SGSError.ini"

#End Region

#Region "Language"

    Public Language As Integer
    Public LanguageSelect() As String = {"English", "PortugueseBr", "Italian"}

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
    Public Label0038 As String = "WAV:"
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
    Public Label0060 As String = "Edit settings"
    Public Label0061 As String = "Operating mode:"
    Public Label0062 As String = "Enable automatic reset:"
    Public Label0063 As String = "Enable inspection:"
    Public Label0064 As String = "Lot size:"
    Public Label0065 As String = "Operation timeout:"
    Public Label0066 As String = "Printer:"
    Public Label0067 As String = "Save file"
    Public Label0068 As String = "Select operating mode"
    Public Label0069 As String = "Enables automatic reset of counters"
    Public Label0070 As String = "Enables the failure inspection tool"
    Public Label0071 As String = "Enables and select the printer protocol"
    Public Label0072 As String = "Sync clock"
    Public Label0073 As String = "Synchronize device date and time"
    Public Label0074 As String = "Language:"
    Public Label0075 As String = "Select application language"

#End Region

#Region "Messages"

    Public Message0000 As String = "USB Usart connected."
    Public Message0001 As String = "USB Usart disconnected."
    Public Message0002 As String = "Communication failure."
    Public Message0003 As String = "Device not found."
    Public Message0004 As String = "There is a device connected to the software. Do you want to disconnect it?"
    Public Message0005 As String = "The system configuration file not found. The program will load the default settings."
    Public Message0006 As String = "Error: Invalid character or characters limit exceeded."
    Public Message0007 As String = "Warning: Range of resistance changed."
    Public Message0008 As String = "Error: Value out of range or invalid character."
    Public Message0009 As String = "Firmware mismatch or incompatible file."
    Public Message0010 As String = "File saved successfully."
    Public Message0011 As String = "Memory index doesn't exist."
    Public Message0012 As String = "File transfer completed successfully."
    Public Message0013 As String = "Updated clock."
    Public Message0014 As String = "Cannot read file from disk."
    Public Message0015 As String = "Failure to open the serial port"
    Public Message0016 As String = "Try again?"

#End Region

#Region "Lists"

    Public List0000() As String = {"Single", "Double", "Continue"}
    Public List0001() As String = {"Sine", "Sine/WAV", "WAV"}
    Public List0002() As String = {"Switch off", "Switch on"}
    Public List0003() As String = {"Switch off", "EPL mode", "ZPL mode"}

#End Region

End Module

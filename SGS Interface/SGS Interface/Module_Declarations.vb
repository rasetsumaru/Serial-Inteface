
Module Module_Declarations

#Region "Usart communication"

    Public UsartRx As String
    Public UsartTx As String
    Public UsartConnected As Boolean
    Public UsartPorts As Integer

    Public UsartRxControl As Integer
    Public UsartRxTimeout As Integer

#End Region

#Region "Form"

    Public drag As Boolean
    Public mousex As Integer
    Public mousey As Integer

#End Region

#Region "Config"

    Public FormTop As Integer
    Public FormLeft As Integer
    Public TimerNowInterval As Integer
    Public TimerConnectedInterval As Integer
    Public TimerDisconnectedInterval As Integer
    Public TimerUsartTxInterval As Integer
    Public TimerUsartRxInterval As Integer

#End Region

#Region "Address"

    Public DirConfig As String = "\System\SGSConfig.ini"
    Public DirLogsError As String = "\System\SGSError.ini"

#End Region


    Public FileDirectory As String
    Public FileName As String
    Public FileSystem As Integer

    Public RecipeList(500) As String

    Public CurrentSettings As String

    Public RecipeIndex As Integer
    Public RecipeControl As Integer

    Public LoadMessage As Integer

    Public ListCurrentParameters() As String = {"", "", "", "", "", "", "", "", "", "", ""}
    Public ListCurrentSettings() As String = {"", "", "", "", "", ""}


End Module


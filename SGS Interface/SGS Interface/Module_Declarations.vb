
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

    Public RecipeIndex As Integer
    Public RecipeControl As Integer

    Public LoadMessage As Integer


    Public CurrentParameter0000 As String
    Public CurrentParameter0001 As String
    Public CurrentParameter0002 As String
    Public CurrentParameter0003 As String
    Public CurrentParameter0004 As String
    Public CurrentParameter0005 As String
    Public CurrentParameter0006 As String
    Public CurrentParameter0007 As String
    Public CurrentParameter0008 As String
    Public CurrentParameter0009 As String
    Public CurrentParameter0010 As String

    Public ListCurrentParameters() As String = {CurrentParameter0000, CurrentParameter0001, CurrentParameter0002, CurrentParameter0003, CurrentParameter0004, CurrentParameter0005, CurrentParameter0006, CurrentParameter0007, CurrentParameter0008, CurrentParameter0009, CurrentParameter0010}


End Module


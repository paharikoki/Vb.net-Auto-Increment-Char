Imports System.Data.Odbc
Module Module1
    Public Conn As OdbcConnection
    Public Da As OdbcDataAdapter
    Public Ds As DataSet
    Public Rd As OdbcDataReader
    Public Cmd As OdbcCommand
    Public Mydb As String = "Driver={MySQL ODBC 3.51 Driver};database=autoincrement;server=localhost;uid=root;"

    Public Sub Koneksi()
        Conn = New OdbcConnection(Mydb)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub

End Module

Imports System.Data.Odbc
Public Class Form1
    Sub awal()
        Dim filldata As String = "select * from tb_makanan"
        Koneksi()
        Da = New OdbcDataAdapter(filldata, Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tb_makanan")


        DataGridView1.DataSource = Ds.Tables("tb_makanan")

        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmMakanan.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmKategori.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        awal()
    End Sub
End Class

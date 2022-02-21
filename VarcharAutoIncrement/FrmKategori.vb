Imports System.Data.Odbc
Public Class FrmKategori
    Sub awal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox2.MaxLength = 3
        Dim FillData As String = "Select * from tb_kategori"
        Koneksi()
        Da = New OdbcDataAdapter(FillData, Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tb_kategori")

        DataGridView1.DataSource = Ds.Tables("tb_kategori")
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Koneksi()
        Dim InsertData As String = "insert into tb_kategori (nama,kode) values ('" & TextBox1.Text & "','" & TextBox2.Text & "')"
        Cmd = New OdbcCommand(InsertData, Conn)
        Cmd.ExecuteNonQuery()
        awal()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub FrmKategori_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub
End Class
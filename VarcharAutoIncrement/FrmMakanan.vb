Imports System.Data.Odbc
Public Class FrmMakanan
    Dim kode, kodeincre, incre, id As String
    Sub awal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox2.Text = 0
        TextBox3.Text = 0
        ComboBox1.Text = ""
        ComboBox1.Items.Clear()
        Dim FillKate As String = "select * from tb_kategori "
        Koneksi()
        Cmd = New OdbcCommand(FillKate, Conn)
        Rd = Cmd.ExecuteReader()
        While Rd.Read
            ComboBox1.Items.Add(Rd("nama"))
        End While

        Dim FillData As String = "select * from tb_makanan "
        Koneksi()
        Da = New OdbcDataAdapter(FillData, Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tb_makanan")

        DataGridView1.DataSource = Ds.Tables("tb_makanan")
        DataGridView1.ReadOnly = True
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Me.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim SelectKate As String = "select * from tb_kategori where nama='" & ComboBox1.Text & "'"
        Koneksi()
        Cmd = New OdbcCommand(SelectKate, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()

        kode = Rd("kode")
        id = Rd("id")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim GetData As String = "select * from tb_makanan where id_kategori='" & id & "'"
        Koneksi()
        Cmd = New OdbcCommand(GetData, Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Dim hitung As Long
            Dim awalkode As String

            awalkode = Mid(Rd("kode_makanan").ToString, 4, 3)
            hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 3) + 1
            incre = kode + Microsoft.VisualBasic.Right("000" & hitung, 3)
            Label6.Text = incre
        Else
            incre = kode + "001"
            Label6.Text = incre
        End If

        Dim InsertData As String = "Insert Into tb_makanan values('" & Label6.Text & "','" & id & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "')"
        Koneksi()
        Cmd = New OdbcCommand(InsertData, Conn)
        Cmd.ExecuteNonQuery()
        MessageBox.Show("Berhasil Menambahkan Data")
        awal()
    End Sub

    Private Sub FrmMakanan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        awal()
    End Sub
End Class
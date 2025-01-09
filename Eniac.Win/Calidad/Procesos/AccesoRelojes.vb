Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data.Common
Imports System.Configuration
Imports System.Data.SqlClient
Imports System.Globalization

Imports System.Data
Imports System.Data.OleDb
Imports System.IO

Public Class AccesoRelojes
#Region "Campos"

   Private myConnection As DbConnection
   Private myProvider As DbProviderFactory
   Private myTransaction As DbTransaction
   Private myCommand As DbCommand
   Private myCommandSQL As DbCommand
   Private myCommandODBC As DbCommand


   Private _oleDBCommand As OleDbCommand
   Private _cadenaConexion1 As String

#End Region
   Private Sub AccesoRelojes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Me.Text = Me.Text & " - Version: " & My.Application.Info.Version.ToString()

      Dim MiCultura As CultureInfo = DirectCast(System.Globalization.CultureInfo.CurrentCulture.Clone(), CultureInfo)
      Dim MiFormato As NumberFormatInfo = New CultureInfo(System.Globalization.CultureInfo.CurrentCulture.ToString(), False).NumberFormat
      MiFormato.NumberDecimalSeparator = "."
      MiFormato.NumberGroupSeparator = ","
      MiFormato.NumberDecimalDigits = 2
      MiFormato.CurrencyDecimalDigits = 2
      MiFormato.CurrencyDecimalSeparator = "."
      MiFormato.CurrencyGroupSeparator = ","
      MiCultura.NumberFormat = MiFormato
      MiCultura.DateTimeFormat.DateSeparator = "/"
      MiCultura.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
      MiCultura.DateTimeFormat.ShortTimePattern = "HH:mm:ss"

      System.Threading.Thread.CurrentThread.CurrentCulture = MiCultura


   End Sub


   Private Sub btnCargarInfo_Click(sender As Object, e As EventArgs) Handles btnCargarInfo.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         If String.IsNullOrEmpty(Me.txtCarpeta.Text) Then
            Exit Sub
         End If

         Dim cconexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source= " & Me.txtCarpeta.Text & ";Persist Security Info=True;Jet OLEDB:Database Password= " & Me.txtContraseña.Text

         Dim cnn As New OleDbConnection(cconexion)

         Dim Da As New OleDbDataAdapter
         Dim Ds As New DataSet
         Dim consulta As String
         consulta = "select * from t_fichadas"
         Da = New OleDbDataAdapter(consulta, cnn)
         Ds.Tables.Add("Fichadas")
         Da.Fill(Ds.Tables("Fichadas"))
         Me.dgvFichadas.DataSource = Ds.Tables("Fichadas")
         Me.tssFichadas.Text = (Me.dgvFichadas.RowCount - 1).ToString() & " Registros"

         consulta = "select * from t_legajos"
         Da = New OleDbDataAdapter(consulta, cnn)
         Ds.Tables.Add("Legajos")
         Da.Fill(Ds.Tables("Legajos"))
         Me.dgvLegajos.DataSource = Ds.Tables("Legajos")
         Me.tssLegajos.Text = (Me.dgvLegajos.RowCount - 1).ToString() & " Registros"

         consulta = "select * from t_sectores"
         Da = New OleDbDataAdapter(consulta, cnn)
         Ds.Tables.Add("Sectores")
         Da.Fill(Ds.Tables("Sectores"))
         Me.dgvSectores.DataSource = Ds.Tables("Sectores")
         Me.tssSectores.Text = (Me.dgvSectores.RowCount - 1).ToString() & " Registros"

         consulta = "select * from t_TiposDeCategoria"
         Da = New OleDbDataAdapter(consulta, cnn)
         Ds.Tables.Add("Categorias")
         Da.Fill(Ds.Tables("Categorias"))
         Me.dgvCategorias.DataSource = Ds.Tables("Categorias")
         Me.tssCategorias.Text = (Me.dgvCategorias.RowCount - 1).ToString() & " Registros"

         consulta = "select * from t_Nodos"
         Da = New OleDbDataAdapter(consulta, cnn)
         Ds.Tables.Add("Nodos")
         Da.Fill(Ds.Tables("Nodos"))
         Me.dgvNodos.DataSource = Ds.Tables("Nodos")
         Me.tssNodos.Text = (Me.dgvNodos.RowCount - 1).ToString() & " Registros"

         Me.btnMigrarDatos.Enabled = True

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try


   End Sub

   Private Sub btnBuscarBase_Click(sender As Object, e As EventArgs) Handles btnBuscarBase.Click
      Dim ArchivoStream As Stream = Nothing
      Dim ofdArchivo As New OpenFileDialog()

      ofdArchivo.Multiselect = True
      ofdArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      ofdArchivo.Filter = "Archivo de texto (*.mdb)|*.mdb|Todos los Archivos (*.*)|*.*"
      ofdArchivo.FilterIndex = 1
      ofdArchivo.RestoreDirectory = True
      Dim str As System.Text.StringBuilder = New System.Text.StringBuilder()

      If ofdArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = ofdArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               For Each ar As String In ofdArchivo.FileNames
                  ' Me.Archivos.Add(ar)
                  str.Append(ar).AppendLine()
               Next

               Me.txtCarpeta.Text = str.ToString()
               'Si bien aca lo pude abrir, solo es para obtener el path.
            End If


         Catch Ex As Exception
            MessageBox.Show("ATENCION: No se puede leer el archivo. Error: " & Ex.Message)
         Finally
            If (ArchivoStream IsNot Nothing) Then
               ArchivoStream.Close()
            End If
         End Try
      End If
   End Sub

   Private Sub btnMigrarDatos_Click(sender As Object, e As EventArgs) Handles btnMigrarDatos.Click
      Try

         Me.MigrarTablas()
         'If Me.tbcPrincipal.SelectedTab Is tbpFichadas Then
         '   ' Me.MigrarSubRubros_a_Rubros()
         'ElseIf Me.tbcPrincipal.SelectedTab Is tbpLegajos Then
         '   ' Me.MigrarProductos()
         'ElseIf Me.tbcPrincipal.SelectedTab Is tbpCategorias Then
         '   ' Me.MigrarLocalidades()
         'ElseIf Me.tbcPrincipal.SelectedTab Is tbpSectores Then
         '   Me.MigrarClientes()
         'ElseIf Me.tbcPrincipal.SelectedTab Is tbpNodos Then
         '   Me.MigrarNodos()
         'End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Public Sub MigrarTablas()
      Try

         Me.Cursor = Cursors.WaitCursor

         Me.txtTablasMigradas.Text = "Nodos"
         Dim oNodos As Reglas.Nodos = New Reglas.Nodos
         Dim Nodos As DataTable = DirectCast(dgvNodos.DataSource, DataTable)
         oNodos.MigrarNodos(Nodos, Me.pgb)

         Me.txtTablasMigradas.Text = "Sectores"
         Dim oSectores As Reglas.Sectores = New Reglas.Sectores
         Dim Sectores As DataTable = DirectCast(dgvSectores.DataSource, DataTable)
         oSectores.MigrarSectores(Sectores, Me.pgb)

         Me.txtTablasMigradas.Text = "Categorias"
         Dim oCategorias As Reglas.CategoriasLegajos = New Reglas.CategoriasLegajos
         Dim Categorias As DataTable = DirectCast(dgvCategorias.DataSource, DataTable)
         oCategorias.MigrarCategorias(Categorias, Me.pgb)

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron las tablas EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Me.txtTablasMigradas.Text = String.Empty

         Me.pgb.Value = 0

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub
End Class
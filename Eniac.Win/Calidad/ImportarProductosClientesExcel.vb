Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO
Imports System.Globalization

#End Region

Public Class ImportarProductosClientesExcel

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String
   Private ColumnaCodigoCliente As Integer = 2
   Private ColumnaNombreCliente As Integer = 3
   Private ColumnaNumeroChasis As Integer = 4
   Private ColumnaNumeroCarroceria As Integer = 5
   Private ClientesConError As Integer
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Me._publicos.CargaComboMarcas(Me.cmbMarca)

      Me.cboAccion.Items.Insert(0, "Todas")
      Me.cboAccion.Items.Insert(1, "Altas")
      Me.cboAccion.Items.Insert(2, "Modificar")

      Me.cboEstado.Items.Insert(0, "Todos")
      Me.cboEstado.Items.Insert(1, "Validos")
      Me.cboEstado.Items.Insert(2, "Invalidos")

      Me.cmbDescripcionCorte.Items.Insert(0, "No Cortar")
      Me.cmbDescripcionCorte.Items.Insert(1, "Cortar")
      Me.cmbDescripcionCorte.Items.Insert(2, "Avisar y Cortar")

      Me.CargarValoresIniciales()

      Me._estaCargando = False

   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarClientesExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If ClientesConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ClientesConError.ToString() & " Clientes que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.dgvDetalle.RowCount - ClientesConError).ToString() & " Clientes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.prbImportando.Value = 0
         'Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click

      Dim ArchivoStream As Stream = Nothing
      Dim DialogoAbrirArchivo As New OpenFileDialog()

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoAbrirArchivo.Filter = "Todos los Archivos (*.*)|*.*|Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx"
      DialogoAbrirArchivo.FilterIndex = 1
      DialogoAbrirArchivo.RestoreDirectory = True

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = DialogoAbrirArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               Me.txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
               'Si bien aca lo pude abrir, solo es para obtener el path.
               Me.txtRangoCeldas.Focus()
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

   Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged

      If Not Me._estaCargando Then
         Me.tsbImportar.Enabled = (Me.cboEstado.Text <> "Invalidos")
      End If

   End Sub

   Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click

      Try

         If Me.txtArchivoOrigen.Text.Trim() = "" Then
            Exit Sub
         End If

         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         RangoExcel = "[" & Me.txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"
         If RangoExcel = "" Or RangoExcel = "An : Fn" Then
            MsgBox("Debe indicar el rango de celdas a leer del archivo Excel")
            Me.txtRangoCeldas.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.Mostrar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""

      Me.txtRangoCeldas.Text = "A1 : Fn"

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0


      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'If Not Me._dt Is Nothing Then
      '   Me._dt.Rows.Clear()
      'End If

      Me.prbImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", System.Type.GetType("System.Boolean"))
         '.Columns.Add("LineaExcel", System.Type.GetType("System.Int64"))
         .Columns.Add("Accion", System.Type.GetType("System.String"))
         .Columns.Add("AccionProducto", System.Type.GetType("System.String"))
         .Columns.Add("CodigoCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NumeroChasis", System.Type.GetType("System.String"))
         .Columns.Add("NroCarroceria", System.Type.GetType("System.String"))
         .Columns.Add("Mensaje", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Sub AbrirExcel(ByVal ArchivoXLS As String)

      Dim m_sConn1 As String

      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If

      ConexionExcel = New System.Data.OleDb.OleDbConnection(m_sConn1)
      ConexionExcel.Open()

   End Sub

   Private Sub Mostrar()

      Try

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oClientes As Eniac.Reglas.Clientes = New Eniac.Reglas.Clientes
         Dim oProducto As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Dim oLocalidad As Eniac.Reglas.Localidades = New Eniac.Reglas.Localidades

         Dim AnchoNombreCliente As Integer
         AnchoNombreCliente = oPublicos.GetAnchoCampo("Clientes", "NombreCliente")

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         ClientesConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Dim ds As DataSet = New DataSet()
         Dim DA As New System.Data.OleDb.OleDbDataAdapter

         Me.AbrirExcel(txtArchivoOrigen.Text)

         DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String
         Dim AccionProducto As String

         Dim i As Integer = 0

         prbImportando.Maximum = ds.Tables(0).Rows.Count
         prbImportando.Minimum = 0
         prbImportando.Value = 0

         For Each dr In ds.Tables(0).Rows
            i += 1
            prbImportando.Value = i

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True
            Mensaje = ""


            drCl("CodigoCliente") = dr(ColumnaCodigoCliente).ToString()
            drCl("NombreCliente") = dr(ColumnaNombreCliente).ToString.Trim.Replace("'", "´")
            Accion = IIf(oClientes.ExisteCodigoLetras(drCl("CodigoCliente")), "M", "A")

            drCl("NumeroChasis") = dr(ColumnaNumeroChasis).ToString.Trim.Replace("'", "´")
            drCl("NroCarroceria") = dr(ColumnaNumeroCarroceria).ToString.Trim.Replace("'", "´")
            AccionProducto = IIf(oProducto.Existe(drCl("NroCarroceria")), "M", "A")

            'drCl("NombreCategoriaFiscal") = dr(ColumnaNombreCategoriaFiscal).ToString.Trim.Replace("'", "´")
            'Dim catFisc As DataTable = New Reglas.CategoriasFiscales().GetPorNombreExacto(drCl("NombreCategoriaFiscal"))
            'If catFisc.Rows.Count = 0 Then
            '   Importar = False
            '   If Mensaje.Length > 0 Then Mensaje += " - "
            '   Mensaje += "NO Existe La Categoria Fiscal"
            'End If




            drCl("Importa") = Importar

            If Not Importar Then
               ClientesConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "X"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = Accion
            drCl("AccionProducto") = AccionProducto


            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And _
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               dt.Rows.Add(drCl)
            End If

         Next

         ConexionExcel.Close()

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ClientesConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         prbImportando.Value = 0
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try

   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      Dim reg As Eniac.Reglas.ProductosClientes = New Eniac.Reglas.ProductosClientes()

      reg.ImportarProductosClientes(actual.Sucursal.Id, dtDatos, actual.Nombre, Me.prbImportando, IdFuncion)



   End Sub

#End Region

End Class
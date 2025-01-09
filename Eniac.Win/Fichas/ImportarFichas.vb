Option Strict On
Option Explicit On

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
Imports Infragistics.Win.UltraWinDataSource
'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO
Imports System.Text
Imports System.Globalization

#End Region

Public Class ImportarFichas


#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   'Private ConexionExcel As System.Data.OleDb.OleDbConnection

   '  Private ColumnaNombreFantasia As Integer = 0
   '  Private ColumnaCantidad As Integer = 4

   'Private ColumnaNombreProducto As Integer = 0
   'Private ColumnaCodigoProveedor As Integer = 1   'Predeterminado 1 Columna
   'Private ColumnaNombreProducto2 As Integer = 2
   'Private ColumnaPrecioVenta As Integer = 3
   'Private ProductosConError As Integer
   Private _estaCargando As Boolean = True
   Private _OrdenCompra As Long = 0

   Private _rangoCeldasColumnaDesdeDefault As String
   Private _rangoCeldasColumnaHastaDefault As String
   Private _rangoCeldasFilaDesdeDefault As String
   Private _rangoCeldasFilaHastaDefault As String

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      _rangoCeldasColumnaDesdeDefault = txtRangoCeldasColumnaDesde.Text
      _rangoCeldasColumnaHastaDefault = txtRangoCeldasColumnaHasta.Text
      _rangoCeldasFilaDesdeDefault = txtRangoCeldasFilaDesde.Text
      _rangoCeldasFilaHastaDefault = txtRangoCeldasFilaHasta.Text

      Me._publicos = New Publicos()

      Me.cboAccion.Items.Insert(0, "Todas")
      Me.cboAccion.Items.Insert(1, "Altas")
      Me.cboAccion.Items.Insert(2, "Modificar")

      Me.cboEstado.Items.Insert(0, "Todos")
      Me.cboEstado.Items.Insert(1, "Validos")
      Me.cboEstado.Items.Insert(2, "Invalidos")

      Me.CargarValoresIniciales()

      Ayudante.Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreCliente", "NombreProducto", "NombreVendedor", "NombreCobrador"})

      Me._estaCargando = False

   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarProductosExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         MostrarCantidadRegistros(ugDetalle.Rows.Count)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click

      Try

         'Por si logra repetir la accion.
         If Not Me.tsbImportar.Enabled Then Exit Sub

         Me.tsbImportar.Enabled = False

         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         If DirectCast(ugDetalle.DataSource, DataTable).Select("Not Importa").Length > 0 AndAlso
            ShowPregunta("ATENCION: Existen Fichas que NO se Importarán. ¿ Confirma el Proceso ?") <> Windows.Forms.DialogResult.Yes Then
            Me.tsbImportar.Enabled = True
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         ugDetalle.DisplayLayout.Bands(0).Columns("EstadoImporta").Hidden = False
         tspImportando.Visible = True

         Dim sw As Stopwatch = New Stopwatch()
         sw.Start()

         Me.ImportarDatos()

         sw.Stop()

         ShowMessage(String.Format("¡¡¡ Se importaron Fichas EXITOSAMENTE !!! Tiempo transcurrido: {0}", sw.Elapsed.ToString()))
         tspImportando.Value = 0

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click
      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            Using ArchivoStream As Stream = DialogoAbrirArchivo.OpenFile()
               If (ArchivoStream IsNot Nothing) Then
                  Me.txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
                  'Si bien aca lo pude abrir, solo es para obtener el path.
                  Me.txtRangoCeldasFilaHasta.Focus()
               End If
            End Using
         Catch Ex As Exception
            ShowMessage(String.Format("ATENCION: No se puede leer el archivo. Error: {0}", Ex.Message))
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
         tspImportando.Value = 0

         If String.IsNullOrWhiteSpace(Me.txtArchivoOrigen.Text) Then
            Exit Sub
         End If

         If Not IO.File.Exists(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: El archivo a Importar NO Existe")
            Exit Sub
         End If

         If String.IsNullOrWhiteSpace(txtRangoCeldasColumnaDesde.Text) Or
            String.IsNullOrWhiteSpace(txtRangoCeldasColumnaHasta.Text) Or
            Not IsNumeric(txtRangoCeldasFilaDesde.Text) Or
            Not IsNumeric(txtRangoCeldasFilaHasta.Text) Then
            ShowMessage("Debe indicar el rango de celdas a leer del archivo Excel")
            txtRangoCeldasFilaHasta.Focus()
            Exit Sub
         End If

         Dim rangoExcel As String = String.Format("[{0}{1}:{2}{3}]",
                                                  txtRangoCeldasColumnaDesde.Text.Trim(),
                                                  txtRangoCeldasFilaDesde.Text.Trim(),
                                                  txtRangoCeldasColumnaHasta.Text.Trim(),
                                                  txtRangoCeldasFilaHasta.Text.Trim())

         Me.Cursor = Cursors.WaitCursor
         Me.tsbImportar.Enabled = True

         LeerExcel(rangoExcel)
         ugDetalle.DisplayLayout.Bands(0).Columns("EstadoImporta").Hidden = True

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

      txtRangoCeldasColumnaDesde.Text = _rangoCeldasColumnaDesdeDefault
      txtRangoCeldasColumnaHasta.Text = _rangoCeldasColumnaHastaDefault
      txtRangoCeldasFilaDesde.Text = _rangoCeldasFilaDesdeDefault
      txtRangoCeldasFilaHasta.Text = _rangoCeldasFilaHastaDefault

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      tspImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", GetType(Boolean))
         .Columns.Add("EstadoImporta", GetType(String))

         .Columns.Add("Accion", GetType(String))
         .Columns.Add("Mensaje", GetType(String))


         .Columns.Add("Fecha", GetType(DateTime))
         .Columns.Add(Entidades.Venta.Columnas.IdTipoComprobante.ToString(), GetType(String))
         .Columns.Add(Entidades.Venta.Columnas.Letra.ToString(), GetType(String))
         .Columns.Add(Entidades.Venta.Columnas.CentroEmisor.ToString(), GetType(Short))
         .Columns.Add(Entidades.Venta.Columnas.NumeroComprobante.ToString(), GetType(Long))
         .Columns.Add(Entidades.Cliente.Columnas.IdCliente.ToString(), GetType(Long))
         .Columns.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), GetType(Long))
         .Columns.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), GetType(String))

         .Columns.Add(Entidades.Producto.Columnas.IdProducto.ToString(), GetType(String))
         .Columns.Add(Entidades.Producto.Columnas.NombreProducto.ToString(), GetType(String))

         .Columns.Add("Cantidad", GetType(Decimal))

         .Columns.Add(Entidades.CajaNombre.Columnas.IdCaja.ToString(), GetType(Integer))
         .Columns.Add(Entidades.VentaFormaPago.Columnas.DescripcionFormasPago.ToString(), GetType(String))

         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("CantidadCuotas", GetType(Integer))

         .Columns.Add("CuotasPagas", GetType(Integer))
         .Columns.Add("ImportePagado", GetType(Decimal))

         .Columns.Add("CuotasImpagas", GetType(Integer))
         .Columns.Add("ImporteImpago", GetType(Decimal))

         .Columns.Add("Saldo", GetType(Decimal))

         ' .Columns.Add("NroDocVendedor", GetType(String))
         .Columns.Add("CodigoVendedor", GetType(Integer))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("CodigoCobrador", GetType(Integer))
         .Columns.Add("NombreCobrador", GetType(String))

         .Columns.Add("Entidad_Vendedor", GetType(Object))
         .Columns.Add("Entidad_Cobrador", GetType(Object))
         .Columns.Add("Entidad_FormaPago", GetType(Object))

      End With

      Return dtTemp

   End Function

   Private Sub HabilitaControles(habilita As Boolean)
      btnMostrar.Enabled = habilita
      btnExaminar.Enabled = habilita
      tsbImportar.Enabled = habilita
      tsbRefrescar.Enabled = habilita
      tsbSalir.Enabled = habilita
   End Sub

   Private Sub LeerExcel(rangoExcel As String)
      Me.Cursor = Cursors.WaitCursor

      Dim dt As DataTable = CrearDT()
      Dim lector As ImportarFichasLeerArchivoEstandar = New ImportarFichasLeerArchivoEstandar(New Reglas.BusquedasCacheadas, txtFormatoFechas.Text)

      MostrarCantidadRegistros(0)

      Try
         tspImportando.Visible = True
         tslRegistroActual.Visible = True
         HabilitaControles(False)
         Try
            AddHandler lector.IniciaImportacion, Sub(s, e)
                                                    tspImportando.Maximum = e.CantidadTotalDeRegistros
                                                    MostrarCantidadRegistros(e.CantidadTotalDeRegistros)
                                                 End Sub
            AddHandler lector.AvanceImportacion, Sub(s, e)
                                                    tspImportando.Value = e.RegistrosProcesados
                                                    tslRegistroActual.Text = e.RegistrosProcesados.ToString()
                                                    Application.DoEvents()
                                                 End Sub
            AddHandler lector.FinalizaImportacion, Sub(s, e)
                                                      tspImportando.Value = 0
                                                   End Sub
            lector.Importar(txtArchivoOrigen.Text, dt, rangoExcel, cboEstado.Text, cboAccion.Text)
         Finally

         End Try

         Me.ugDetalle.DataSource = dt

         Me.FormatearGrilla()

         MostrarCantidadRegistros(dt.Rows.Count)

         ''Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.
         'If Me.cboEstado.Text = "Validos" Then
         '   ProductosConError = 0
         'End If
      Catch ex As Exception
         If ex.Message.Contains("FROM") Then
            ShowMessage(String.Format("Rango de Celdas Invalidos. {0}", ex.Message))
            Me.txtRangoCeldasFilaHasta.Focus()
         Else
            ShowError(ex)
         End If
         Exit Sub
      Finally
         Me.Cursor = Cursors.Default
         tspImportando.Visible = False
         tslRegistroActual.Visible = False
         HabilitaControles(True)
      End Try

   End Sub

   'Public Function RemoveDiacritics(stIn As String) As String

   '   Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
   '   Dim sb As New StringBuilder()

   '   For ich As Integer = 0 To stFormD.Length - 1
   '      Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
   '      If uc <> UnicodeCategory.NonSpacingMark Then
   '         sb.Append(stFormD(ich))
   '      End If
   '   Next

   '   Return (sb.ToString().Normalize(NormalizationForm.FormC))

   'End Function

   Public Sub MostrarCantidadRegistros(cantidad As Integer)
      Me.tssRegistros.Text = String.Format("{0} Registros", cantidad)
   End Sub

   Private Sub FormatearGrilla()
      ugDetalle.DisplayLayout.Bands(0).Columns("Mensaje").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
   End Sub

   Private Sub MostrarAccion(accion As String, ficha As Entidades.Venta)
      If String.IsNullOrWhiteSpace(accion) Then
         MostrarInfo(accion)
      Else
         MostrarInfo(String.Format("{0} - {1} {2} {3:0000}-{4:00000000})", accion, ficha.IdTipoComprobante, ficha.LetraComprobante, ficha.CentroEmisor, ficha.NumeroComprobante))
      End If
   End Sub
   Private Sub MostrarInfo(mensaje As String)
      tstInfo.Text = mensaje
   End Sub

   Private Sub ImportarDatos()
      Try
         Cursor = Cursors.WaitCursor

         Dim rCrm As Reglas.ImportarFichas = New Reglas.ImportarFichas()
         Try
            AddHandler rCrm.IniciaGrabacion, Sub(s, e)
                                                tspImportando.Maximum = e.CantidadTotalDeRegistros
                                                MostrarCantidadRegistros(e.CantidadTotalDeRegistros)
                                             End Sub
            AddHandler rCrm.AvanceGrabacion, Sub(s, e)
                                                tspImportando.Value = e.RegistrosProcesados
                                                tslRegistroActual.Text = e.RegistrosProcesados.ToString()
                                                MostrarAccion(e.Accion, e.Comprobante)
                                                Application.DoEvents()
                                             End Sub
            AddHandler rCrm.FinalizaGrabacion, Sub(s, e)
                                                  tspImportando.Value = 0
                                                  MostrarInfo("")
                                               End Sub
            rCrm.Grabar(DirectCast(ugDetalle.DataSource, DataTable), Today, IdFuncion)
         Finally

         End Try

         MostrarCantidadRegistros(ugDetalle.Rows.Count)

      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

#End Region

   Private Function GetValorString(dr As DataRow, indiceColumna As Integer) As String
      Return Ayudante.ImportarExcel.GetValorString(dr, indiceColumna)
   End Function

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      If e.Row.Cells("Accion").Value.ToString() = "X" Then
         e.Row.Cells("Importa").Appearance.BackColor = Color.Yellow
         e.Row.Cells("Importa").ActiveAppearance.BackColor = Color.Yellow
      ElseIf e.Row.Cells("Accion").Value.ToString() = "E" Then
         e.Row.Cells("Importa").Appearance.BackColor = Color.LightCoral
         e.Row.Cells("Importa").ActiveAppearance.BackColor = Color.LightCoral
      Else
         e.Row.Cells("Importa").Appearance.BackColor = Color.LimeGreen
         e.Row.Cells("Importa").ActiveAppearance.BackColor = Color.LimeGreen
      End If

      If e.Row.Cells("EstadoImporta").Value.Equals("OK") Then
         e.Row.Cells("EstadoImporta").Appearance.BackColor = Color.LimeGreen
         e.Row.Cells("EstadoImporta").ActiveAppearance.BackColor = Color.LimeGreen
      ElseIf e.Row.Cells("EstadoImporta").Value.Equals("ERROR") Then
         e.Row.Cells("EstadoImporta").Appearance.BackColor = Color.LightCoral
         e.Row.Cells("EstadoImporta").ActiveAppearance.BackColor = Color.LightCoral
      End If

   End Sub

   Private Sub Controles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRangoCeldasFilaHasta.KeyDown, txtRangoCeldasFilaDesde.KeyDown, txtRangoCeldasColumnaHasta.KeyDown, txtRangoCeldasColumnaDesde.KeyDown, cboEstado.KeyDown, cboAccion.KeyDown
      PresionarTab(e)
   End Sub
End Class
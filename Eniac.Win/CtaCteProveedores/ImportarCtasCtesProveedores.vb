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

Public Class ImportarCtasCtesProveedores

   Private Class ColumnasExcel
      Public Const SucursalIndex As Integer = 0
      Public Const CodigoProveedorIndex As Integer = 1
      Public Const NombreProveedorIndex As Integer = 2
      Public Const TipoComprobanteIndex As Integer = 3
      Public Const LetraIndex As Integer = 4
      Public Const EmisorIndex As Integer = 5
      Public Const NumeroComprobanteIndex As Integer = 6
      Public Const FechaIndex As Integer = 7
      Public Const FechaVencimientoIndex As Integer = 8
      Public Const ImporteIndex As Integer = 9
      Public Const ObservacionIndex As Integer = 10

   End Class

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
   Private ProductosConError As Integer
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
      'Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
      Me.CargarColumnasASumar()

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
         Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"
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

         If ProductosConError > 0 AndAlso MessageBox.Show("ATENCION: Existen Ctas Ctes que NO se Importarán. ¿ Confirma el Proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Me.tsbImportar.Enabled = True
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         ugDetalle.DisplayLayout.Bands(0).Columns("EstadoImporta").Hidden = False
         tspImportando.Visible = True

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & Me.ugDetalle.Rows.Count - ProductosConError & " Cuentas Corrientes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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



         'If Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
         '   MessageBox.Show("ATENCION: Debe seleccionar el Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '   Exit Sub
         'End If

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

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      '   e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      'e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      'e.Layout.Override.SpecialRowSeparatorHeight = 6

      'e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      'e.Layout.ViewStyle = ViewStyle.SingleBand

      'e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

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

#End Region

#Region "Metodos"

   Private Sub CargarColumnasASumar()

      Me.ugDetalle.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

      If Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Count = 0 Then

         Me.ugDetalle.DisplayLayout.Override.SummaryDisplayArea = Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed


         Dim columnToSummarize1 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteTotal")
         Dim summary1 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("ImporteTotal", SummaryType.Sum, columnToSummarize1)
         summary1.DisplayFormat = "{0:N2}"
         summary1.Appearance.TextHAlign = HAlign.Right

         'Dim columnToSummarize2 As UltraGridColumn = Me.ugDetalle.DisplayLayout.Bands(0).Columns("Cantidad")
         'Dim summary2 As SummarySettings = Me.ugDetalle.DisplayLayout.Bands(0).Summaries.Add("Cantidad", SummaryType.Sum, columnToSummarize2)
         'summary2.DisplayFormat = "{0:N2}"
         'summary2.Appearance.TextHAlign = HAlign.Right

         Me.ugDetalle.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

      End If

   End Sub

   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""

      txtRangoCeldasColumnaDesde.Text = _rangoCeldasColumnaDesdeDefault
      txtRangoCeldasColumnaHasta.Text = _rangoCeldasColumnaHastaDefault
      txtRangoCeldasFilaDesde.Text = _rangoCeldasFilaDesdeDefault
      txtRangoCeldasFilaHasta.Text = _rangoCeldasFilaHastaDefault

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0

      'Me.bscProveedor.Text = ""
      'Me.bscCodigoProveedor.Text = ""
      'Me.txtOrdenCompra.Text = ""

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
         '.Columns.Add("LineaExcel", GetType("System.Int64"))
         .Columns.Add("Accion", GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.IdSucursal.ToString(), GetType(Integer))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.IdProveedor.ToString(), GetType(Long))
         .Columns.Add(Entidades.Proveedor.Columnas.CodigoProveedor.ToString(), GetType(Long))
         .Columns.Add(Entidades.Proveedor.Columnas.NombreProveedor.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.IdTipoComprobante.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.Letra.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.CentroEmisor.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.NumeroComprobante.ToString(), GetType(String))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.Fecha.ToString(), GetType(DateTime))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.FechaVencimiento.ToString(), GetType(DateTime))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.ImporteTotal.ToString(), GetType(Decimal))
         .Columns.Add(Entidades.CuentaCorrienteProv.Columnas.Observacion.ToString(), GetType(String))

         .Columns.Add("Mensaje", GetType(String))
      End With

      Return dtTemp

   End Function

   Private Function AbrirExcel(ByVal ArchivoXLS As String) As System.Data.OleDb.OleDbConnection
      Dim ConexionExcel As System.Data.OleDb.OleDbConnection
      Dim m_sConn1 As String

      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If


      ConexionExcel = New System.Data.OleDb.OleDbConnection(m_sConn1)

      Return ConexionExcel
   End Function

   Private Sub ColumnasGrilla()

      If Me._estaCargando Then Exit Sub

      Me.ugDetalle.DisplayLayout.Bands(0).Columns("NombreProducto").Width = 200

   End Sub

   Private Sub LeerExcel(rangoExcel As String)
      Try

         Dim formatoFechas As String = txtFormatoFechas.Text

         BusquedasCacheadas.Reset()

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Reglas.Publicos = New Reglas.Publicos

         ProductosConError = 0

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Dim PrimeraFila As Boolean = True

         Dim rCuentasCorrientes As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
         Dim rProveedors As Reglas.Proveedores = New Reglas.Proveedores()


         Using ConexionExcel As System.Data.OleDb.OleDbConnection = AbrirExcel(txtArchivoOrigen.Text)
            ConexionExcel.Open()
            Using DA As System.Data.OleDb.OleDbDataAdapter = New System.Data.OleDb.OleDbDataAdapter("Select * From " + rangoExcel, ConexionExcel)
               Using ds As DataSet = New DataSet()
                  DA.Fill(ds)

                  Dim lineaProcesada As Long = 0
                  Dim drTemp As DataRow

                  Try
                     For Each dr As DataRow In ds.Tables(0).Rows
                        lineaProcesada += 1

                        Dim Accion As String = "A"
                        Dim Importa As Boolean = True
                        Dim Mensaje As StringBuilder = New StringBuilder()

                        drCl = dt.NewRow()


                        If IsNumeric(dr(ColumnasExcel.SucursalIndex)) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.IdSucursal.ToString()) = Convert.ToInt32(dr(ColumnasExcel.SucursalIndex))
                           drTemp = BusquedasCacheadas.Instancia.BuscaSucursal(Integer.Parse(dr(ColumnasExcel.SucursalIndex).ToString()))
                           If drTemp Is Nothing Then
                              Accion = "X"
                              Mensaje.AppendFormat("La sucursal no existe - ")
                           End If
                        ElseIf Not String.IsNullOrWhiteSpace(GetValorString(dr, ColumnasExcel.SucursalIndex)) Then
                           Accion = "X"
                           Mensaje.AppendFormat("La sucursal no es numerica - ")
                        End If

                        Dim nombreProveedor As String = GetValorString(dr, ColumnasExcel.NombreProveedorIndex)
                        If Not String.IsNullOrWhiteSpace(nombreProveedor) Then
                           drCl(Entidades.Proveedor.Columnas.NombreProveedor.ToString()) = nombreProveedor
                           drTemp = BusquedasCacheadas.Instancia.BuscaProveedores(nombreProveedor)
                           If drTemp IsNot Nothing Then
                              drCl(Entidades.CuentaCorrienteProv.Columnas.IdProveedor.ToString()) = drTemp(Entidades.Proveedor.Columnas.IdProveedor.ToString())
                              drCl(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()) = drTemp(Entidades.Proveedor.Columnas.CodigoProveedor.ToString())
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("No existe el Proveedor - ")
                           End If
                        Else
                           Dim CodigoProveedorStr As String = GetValorString(dr, ColumnasExcel.CodigoProveedorIndex)
                           If IsNumeric(CodigoProveedorStr) AndAlso Convert.ToInt64(CodigoProveedorStr) > 0 Then
                              Dim CodigoProveedor As Long = Convert.ToInt64(ColumnasExcel.CodigoProveedorIndex.ToString())
                              drCl(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()) = CodigoProveedor
                              drTemp = BusquedasCacheadas.Instancia.BuscaProveedorPorCodigo(CodigoProveedor)
                              If drTemp IsNot Nothing Then
                                 drCl(Entidades.CuentaCorrienteProv.Columnas.IdProveedor.ToString()) = drTemp(Entidades.Proveedor.Columnas.IdProveedor.ToString())
                                 drCl(Entidades.Proveedor.Columnas.NombreProveedor.ToString()) = drTemp(Entidades.Proveedor.Columnas.NombreProveedor.ToString())
                              Else
                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe el Proveedor - ")
                              End If
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("No existe el Proveedor - ")
                           End If
                        End If



                        Dim TipoComprobante As String = GetValorString(dr, ColumnasExcel.TipoComprobanteIndex)
                        If Not String.IsNullOrWhiteSpace(TipoComprobante) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.IdTipoComprobante.ToString()) = TipoComprobante
                           drTemp = BusquedasCacheadas.Instancia.BuscaComprobante(TipoComprobante)
                           If drTemp IsNot Nothing Then
                              drCl(Entidades.CuentaCorrienteProv.Columnas.IdTipoComprobante.ToString()) = drTemp("IdTipoComprobante")

                              ' # No está permitido importar si el Tipo de Comprobante Es Recibo o Es Antipo.
                              If drTemp.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.EsAnticipo.ToString()) Or
                                 drTemp.Field(Of Boolean)(Entidades.TipoComprobante.Columnas.EsRecibo.ToString()) Then

                                 Accion = "X"
                                 Mensaje.AppendFormat("No se pueden importar Recibos y/o Anticipos - ")
                              End If
                           Else
                              Accion = "X"
                              Mensaje.AppendFormat("No existe el Tipo de Comprobante - ")
                           End If
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("No posee Tipo de Comprobante - ")
                        End If

                        If Not String.IsNullOrWhiteSpace(GetValorString(dr, ColumnasExcel.LetraIndex)) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.Letra.ToString()) = dr(ColumnasExcel.LetraIndex)
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("El comprobante no tiene letra - ")
                        End If

                        If IsNumeric(dr(ColumnasExcel.EmisorIndex)) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.CentroEmisor.ToString()) = Convert.ToInt32(dr(ColumnasExcel.EmisorIndex))
                        ElseIf Not String.IsNullOrWhiteSpace(GetValorString(dr, ColumnasExcel.EmisorIndex)) Then
                           Accion = "X"
                           Mensaje.AppendFormat("El emisor no es numerico - ")
                        End If

                        If IsNumeric(dr(ColumnasExcel.NumeroComprobanteIndex)) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.NumeroComprobante.ToString()) = Convert.ToInt32(dr(ColumnasExcel.NumeroComprobanteIndex))
                        ElseIf Not String.IsNullOrWhiteSpace(GetValorString(dr, ColumnasExcel.NumeroComprobanteIndex)) Then
                           Accion = "X"
                           Mensaje.AppendFormat("El numero de comprobante no es numerico - ")
                        End If

                        Dim fecha As DateTime = Nothing
                        If Not IsDBNull(dr(ColumnasExcel.FechaIndex)) AndAlso
                           DateTime.TryParseExact(dr(ColumnasExcel.FechaIndex).ToString(), formatoFechas,
                                                  Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, fecha) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.Fecha.ToString()) = fecha
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("La Fecha tiene un formato incorrecto - ")
                        End If

                        fecha = Nothing
                        If Not IsDBNull(dr(ColumnasExcel.FechaVencimientoIndex)) AndAlso
                          DateTime.TryParseExact(dr(ColumnasExcel.FechaVencimientoIndex).ToString(), formatoFechas,
                                                 Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, fecha) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.FechaVencimiento.ToString()) = fecha
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("La Fecha de vencimiento tiene un formato incorrecto - ")
                        End If

                        If IsNumeric(dr(ColumnasExcel.ImporteIndex)) Then
                           drCl(Entidades.CuentaCorrienteProv.Columnas.ImporteTotal.ToString()) = Convert.ToDecimal(dr(ColumnasExcel.ImporteIndex))
                        ElseIf Not String.IsNullOrWhiteSpace(GetValorString(dr, ColumnasExcel.ImporteIndex)) Then
                           Accion = "X"
                           Mensaje.AppendFormat("El importe no es numerico - ")
                        End If

                        drCl(Entidades.CuentaCorrienteProv.Columnas.Observacion.ToString()) = dr(ColumnasExcel.ObservacionIndex).ToString()

                        If Accion = "A" Then

                           If rCuentasCorrientes.Existe(Integer.Parse(drCl(Entidades.CuentaCorrienteProv.Columnas.IdSucursal.ToString()).ToString()),
                                                         Long.Parse(drCl(Entidades.CuentaCorrienteProv.Columnas.IdProveedor.ToString()).ToString()),
                                                          drCl(Entidades.CuentaCorrienteProv.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                          drCl(Entidades.CuentaCorrienteProv.Columnas.Letra.ToString()).ToString(),
                                                          Integer.Parse(drCl(Entidades.CuentaCorrienteProv.Columnas.CentroEmisor.ToString()).ToString()),
                                                          Long.Parse(drCl(Entidades.CuentaCorrienteProv.Columnas.NumeroComprobante.ToString()).ToString())) Then
                              Accion = "E"
                              Mensaje.AppendFormat("El Comprobante existe - ")
                           End If

                        End If



                        Importa = True
                        drCl("Accion") = Accion
                        If Accion = "X" Or Accion = "E" Then
                           Importa = False
                           drCl("Mensaje") = Mensaje.ToString()
                           ProductosConError += 1
                        End If

                        drCl("Importa") = Importa

                        If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importa) Or (Me.cboEstado.Text = "Invalidos" And Not Importa)) And
                           (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
                           dt.Rows.Add(drCl)
                        End If
                     Next
                  Catch ex As Exception
                     Throw New Exception(String.Format("Error procesando línea {0}: {1}", lineaProcesada, ex.Message), ex)
                  End Try
               End Using
            End Using

            ConexionExcel.Close()
         End Using

         Me.ugDetalle.DataSource = dt

         Me.FormatearGrilla()

         Me.tssRegistros.Text = dt.Rows.Count.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Then
            ProductosConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldasFilaHasta.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try

   End Sub

   Public Function RemoveDiacritics(stIn As String) As String

      Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
      Dim sb As New StringBuilder()

      For ich As Integer = 0 To stFormD.Length - 1
         Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
         If uc <> UnicodeCategory.NonSpacingMark Then
            sb.Append(stFormD(ich))
         End If
      Next

      Return (sb.ToString().Normalize(NormalizationForm.FormC))

   End Function

   Private Sub FormatearGrilla()

      ugDetalle.DisplayLayout.Bands(0).Columns("Mensaje").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

      'For Each dr As UltraGridRow In Me.ugDetalle.Rows
      '   If dr.Cells("Accion").Value.ToString() = "X" Then
      '      dr.Cells("Importa").Appearance.BackColor = Color.Yellow
      '   ElseIf dr.Cells("Accion").Value.ToString() = "E" Then
      '      dr.Cells("Importa").Appearance.BackColor = Color.LightCoral
      '   Else
      '      dr.Cells("Importa").Appearance.BackColor = Color.LimeGreen
      '   End If
      'Next
   End Sub

   Private Sub ImportarDatos()
      Try
         Cursor = Cursors.WaitCursor

         Dim rCtaCte As Reglas.CuentasCorrientesProv = New Reglas.CuentasCorrientesProv()
         rCtaCte.Importar(DirectCast(ugDetalle.DataSource, DataTable), tspImportando, Me.IdFuncion)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Function GetValorString(dr As DataRow, indiceColumna As Integer) As String
      Return Ayudante.ImportarExcel.GetValorString(dr, indiceColumna)
   End Function

#End Region

End Class
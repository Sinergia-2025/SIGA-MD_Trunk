Imports System.Drawing.Printing
Imports Eniac.Entidades.Extensiones.Encoders
Public Class EmisionDeEtiquetasCodBarra

#Region "Campos"

   Private _publicos As Publicos
   Private _filtroMultiplesMarcas As MFMarcas
   Private _filtroMultiplesRubros As MFRubros
   Private _proveedorGrilla As Entidades.Proveedor
   Private printDoc As PrintDocument = New PrintDocument()
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            _filtroMultiplesMarcas = New MFMarcas()
            _filtroMultiplesRubros = New MFRubros()
            _publicos.CargaComboTiposComprobantes(cmbTiposComprobantes, False, Entidades.TipoComprobante.Tipos.COMPRAS.ToString())
            cmbTiposComprobantes.SelectedIndex = -1

            _publicos.CargaComboFormatosEtiquetas(cmbFormatos, Entidades.FormatoEtiqueta.Tipos.CODIGOBARRA, True)

            cmbFormatos.SelectedIndex = 0

            txtCabecera.Visible = False

            dgvDetalle.Columns("PrecioVentaSinIVA").Visible = Not Reglas.Publicos.PreciosConIVA
            dgvDetalle.Columns("PrecioVentaConIVA").Visible = Reglas.Publicos.PreciosConIVA

            dgvSeleccionados.Columns("gPrecioVentaSinIVA").Visible = Not Reglas.Publicos.PreciosConIVA
            dgvSeleccionados.Columns("gPrecioVentaConIVA").Visible = Reglas.Publicos.PreciosConIVA

            cmbMarca.Inicializar(False, True, True)
            cmbRubro.Inicializar(False, True, True)

            CargarImpresorasInstaladas()
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(
         Sub()
            chbProveedor.Checked = False

            txtCodigo.Text = String.Empty
            txtProducto.Text = String.Empty

            If cmbTiposComprobantes.Items.Count > 0 Then
               cmbTiposComprobantes.SelectedIndex = -1
            End If
            _proveedorGrilla = Nothing

            cmbMarca.Refrescar()
            cmbRubro.Refrescar()

            cmbFormatos.SelectedIndex = 0

            txtCabecera.Text = String.Empty
            txtCantidad.Text = "1"

            Dim oProd = New Reglas.Productos()

            If TypeOf (dgvDetalle.DataSource) Is DataTable Then
               DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
            End If

            If TypeOf (dgvSeleccionados.DataSource) Is DataTable Then
               DirectCast(dgvSeleccionados.DataSource, DataTable).Rows.Clear()
            End If
            MostrarAtributosSeleccinados()

            Me.ChbComp.Checked = False

            Me.chbMostrarProveedorHabitual.Enabled = False
            '   Me.chbMostrarProveedorHabitual.Checked = False

            chbTodos.Checked = False
            tssRegistros.Text = ""
            txtCodigo.Focus()
         End Sub)

   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(
         Sub()
            If dgvDetalle.RowCount = 0 Then Exit Sub

            dgvSeleccionados.EndEdit()

            Dim Filtros = String.Empty

            Dim dt = GenerarDT()

            If dt.Rows.Count = 0 Then
               ShowMessage("No marco productos para Emitir la Etiqueta de Precios.")
               Exit Sub
            End If

            Dim parm = New List(Of Microsoft.Reporting.WinForms.ReportParameter)()

            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Reglas.Publicos.NombreFantasia))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("DescripcionAdicional", Reglas.Publicos.DescripcionAdicionalEmpresa))
            parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

            Dim formatoEtiqueta = GetFormatoEtiqueta()

            Dim frmImprime = New VisorReportes(formatoEtiqueta.ArchivoAImprimir, "dsPrecios_EtiquetasDePrecios", dt, parm, formatoEtiqueta.ArchivoAImprimirEmbebido, 1) '# 1 = Cantidad Copias

            frmImprime.Text = Text
            frmImprime.WindowState = FormWindowState.Normal
            frmImprime.StartPosition = FormStartPosition.CenterScreen
            frmImprime.Width = 900
            frmImprime.Show()

         End Sub)

   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region



   Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
      TryCatched(
         Sub()
            If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
               ShowMessage("ATENCION: Activo el filtro de Proveedor pero NO selecciono")
               bscCodigoProveedor.Focus()
               Exit Sub
            End If
            If ChbComp.Checked And bscComprobantes.Text.ValorNumericoPorDefecto(0L) = 0 Then
               ShowMessage("ATENCION: NO seleccionó un comprombante de Compra valido")
               ChbComp.Focus()
               Exit Sub
            End If
            CargarDatosGrilla()

            If dgvDetalle.Rows.Count > 0 Then
               btnBuscar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Try
         Me.Cursor = Cursors.WaitCursor

         For Each dr As DataGridViewRow In Me.dgvDetalle.Rows
            dr.Cells("Imprime").Value = Me.chbTodos.Checked
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(
         Sub()
            If dgvDetalle.RowCount = 0 Then Exit Sub
            If TypeOf (dgvDetalle.DataSource) IsNot DataTable Then Exit Sub
            dgvDetalle.EndEdit()

            Dim dt As DataTable
            'Registros Seleccionados Actualmente
            If dgvSeleccionados.Rows.Count > 0 Then
               dt = DirectCast(dgvSeleccionados.DataSource, DataTable)
            Else
               dt = CrearDT()
            End If

            Dim dtOrigen = DirectCast(dgvDetalle.DataSource, DataTable)

            Dim drSeleccionados = dtOrigen.AsEnumerable().Where(Function(drx) drx.Field(Of Boolean)("Imprime")).ToList()

            If drSeleccionados.Any(Function(drx) drx.Field(Of Short?)("TipoAtributo01").HasValue) And
               drSeleccionados.Any(Function(drx) Not drx.Field(Of Short?)("TipoAtributo01").HasValue) Then
               ShowMessage(String.Format("Seleccionó productos que utilizan {0} y productos que no. No puede mezclar productos con esta caracteristica diferente",
                                         Reglas.Publicos.AtributosProductos.TipoAtributo.DescripcionAtributoProducto01))
               Exit Sub
            End If
            If drSeleccionados.Any(Function(drx) drx.Field(Of Short?)("TipoAtributo02").HasValue) And
               drSeleccionados.Any(Function(drx) Not drx.Field(Of Short?)("TipoAtributo02").HasValue) Then
               ShowMessage(String.Format("Seleccionó productos que utilizan {0} y productos que no. No puede mezclar productos con esta caracteristica diferente",
                                         Reglas.Publicos.AtributosProductos.TipoAtributo.DescripcionAtributoProducto02))
               Exit Sub
            End If
            If drSeleccionados.Any(Function(drx) drx.Field(Of Short?)("TipoAtributo03").HasValue) And
               drSeleccionados.Any(Function(drx) Not drx.Field(Of Short?)("TipoAtributo03").HasValue) Then
               ShowMessage(String.Format("Seleccionó productos que utilizan {0} y productos que no. No puede mezclar productos con esta caracteristica diferente",
                                         Reglas.Publicos.AtributosProductos.TipoAtributo.DescripcionAtributoProducto03))
               Exit Sub
            End If
            If drSeleccionados.Any(Function(drx) drx.Field(Of Short?)("TipoAtributo04").HasValue) And
               drSeleccionados.Any(Function(drx) Not drx.Field(Of Short?)("TipoAtributo04").HasValue) Then
               ShowMessage(String.Format("Seleccionó productos que utilizan {0} y productos que no. No puede mezclar productos con esta caracteristica diferente",
                                         Reglas.Publicos.AtributosProductos.TipoAtributo.DescripcionAtributoProducto04))
               Exit Sub
            End If

            Dim movAtributo01 As Entidades.AtributoProducto = Nothing
            Dim movAtributo02 As Entidades.AtributoProducto = Nothing
            Dim movAtributo03 As Entidades.AtributoProducto = Nothing
            Dim movAtributo04 As Entidades.AtributoProducto = Nothing

            Dim primeroDR = drSeleccionados.FirstOrDefault(
                                 Function(drx) drx.Field(Of Short?)("TipoAtributo01").HasValue Or
                                               drx.Field(Of Short?)("TipoAtributo02").HasValue Or
                                               drx.Field(Of Short?)("TipoAtributo03").HasValue Or
                                               drx.Field(Of Short?)("TipoAtributo04").HasValue)
            If primeroDR IsNot Nothing Then
               movAtributo01 = New Entidades.AtributoProducto(primeroDR.Field(Of Short?)("TipoAtributo01").IfNull(),
                                                              primeroDR.Field(Of Integer?)("GrupoAtributo01").IfNull())
               movAtributo02 = New Entidades.AtributoProducto(primeroDR.Field(Of Short?)("TipoAtributo02").IfNull(),
                                                              primeroDR.Field(Of Integer?)("GrupoAtributo02").IfNull())
               movAtributo03 = New Entidades.AtributoProducto(primeroDR.Field(Of Short?)("TipoAtributo03").IfNull(),
                                                              primeroDR.Field(Of Integer?)("GrupoAtributo03").IfNull())
               movAtributo04 = New Entidades.AtributoProducto(primeroDR.Field(Of Short?)("TipoAtributo04").IfNull(),
                                                              primeroDR.Field(Of Integer?)("GrupoAtributo04").IfNull())

               Using frm = New SeleccionaAtributosProductos()
                  With frm
                     .Atributo01 = movAtributo01
                     .Atributo02 = movAtributo02
                     .Atributo03 = movAtributo03
                     .Atributo04 = movAtributo04
                  End With
                  '-- Invoca Formulario.- -----------------------------
                  If frm.ShowDialog() = DialogResult.Cancel Then
                     Exit Sub
                  End If
                  '-- Aloja los datos recuperados.- --
                  With frm
                     movAtributo01 = .Atributo01
                     movAtributo02 = .Atributo02
                     movAtributo03 = .Atributo03
                     movAtributo04 = .Atributo04
                  End With
               End Using
            End If

            For Each dr In drSeleccionados
               For i = 1 To txtCantidad.ValorNumericoPorDefecto(0I)
                  Dim drCl = dt.NewRow()

                  drCl("Imprime") = True

                  drCl("IdSucursal") = dr("IdSucursal")
                  drCl("NombreSucursal") = dr("NombreSucursal")
                  drCl("IdProducto") = dr("IdProducto")
                  drCl("NombreProducto") = dr("NombreProducto")
                  drCl("PrecioVentaSinIVA") = dr("PrecioVentaSinIVA")
                  drCl("Alicuota") = dr("Alicuota")
                  drCl("PrecioVentaConIVA") = dr("PrecioVentaConIVA")
                  drCl("Stock") = dr("Stock")
                  drCl("StockInicial") = dr("StockInicial")
                  drCl("IdMarca") = dr("IdMarca")
                  drCl("NombreMarca") = dr("NombreMarca")
                  drCl("IdRubro") = dr("IdRubro")
                  drCl("NombreRubro") = dr("NombreRubro")
                  drCl("FechaActualizacion") = dr("FechaActualizacion")
                  drCl("CodigoDeBarras") = dr("CodigoDeBarras")
                  drCl("EAN13") = dr("EAN13")
                  drCl("EAN128") = dr("EAN128")
                  drCl("Lote") = dr("Lote")
                  drCl("Lote_EAN128") = dr("Lote_EAN128")

                  If movAtributo01 IsNot Nothing Then
                     drCl("Atributo1_Titulo") = Reglas.Publicos.AtributosProductos.TipoAtributo.DescripcionAtributoProducto01
                     drCl("Atributo1_Descripcion") = movAtributo01.Descripcion
                  End If

                  If movAtributo02 IsNot Nothing Then
                     drCl("Atributo2_Titulo") = Reglas.Publicos.AtributosProductos.TipoAtributo.DescripcionAtributoProducto02
                     drCl("Atributo2_Descripcion") = movAtributo02.Descripcion
                  End If

                  drCl("Alto") = dr("Alto")
                  drCl("Ancho") = dr("Ancho")
                  drCl("Largo") = dr("Largo")
                  drCl("Ubicacion") = dr("Ubicacion")

                  dt.Rows.Add(drCl)

                  dr("Imprime") = False
               Next
            Next

            dgvSeleccionados.DataSource = dt
            MostrarAtributosSeleccinados()


            tssRegistros.Text = dgvSeleccionados.RowCount.ToString() & " Registros"
         End Sub)

   End Sub

   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      Try
         If Me.dgvSeleccionados.Rows.Count > 0 And Me.dgvSeleccionados.SelectedCells.Count > 0 Then
            Me.dgvSeleccionados.Rows.RemoveAt(Me.dgvSeleccionados.SelectedCells(0).OwningRow.Index)
            'If Me.dgvSeleccionados.Rows.Count > 0 Then
            '   Me.dgvSeleccionados.FirstDisplayedScrollingRowIndex = 0
            '   Me.dgvSeleccionados.Rows(0).Selected = True
            'End If
         End If
         MostrarAtributosSeleccinados()
         Me.tssRegistros.Text = Me.dgvSeleccionados.RowCount.ToString() & " Registros"

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub MostrarAtributosSeleccinados()
      Dim mostrar1 = False
      Dim mostrar2 = False
      If TypeOf (dgvSeleccionados.DataSource) Is DataTable Then
         Dim dt = DirectCast(dgvSeleccionados.DataSource, DataTable)
         mostrar1 = dt.AsEnumerable().Any(Function(dr) Not String.IsNullOrWhiteSpace(dr.Field(Of String)("Atributo1_Titulo")))
         mostrar2 = dt.AsEnumerable().Any(Function(dr) Not String.IsNullOrWhiteSpace(dr.Field(Of String)("Atributo2_Titulo")))
      End If
      dgvSeleccionados.Columns(gAtributo1_Titulo.Name).Visible = mostrar1
      dgvSeleccionados.Columns(gAtributo1_Descripcion.Name).Visible = mostrar1
      dgvSeleccionados.Columns(gAtributo2_Titulo.Name).Visible = mostrar2
      dgvSeleccionados.Columns(gAtributo2_Descripcion.Name).Visible = mostrar2
   End Sub

   Private Sub CargarDatosGrilla()

      Dim oProd As Reglas.Productos = New Reglas.Productos()

      Dim idTipoComprobante As String = String.Empty
      Dim letra As String = String.Empty
      Dim emisor As Integer = 0
      Dim numeroComprobante As Long = 0
      Dim idProveedor As Long = 0


      If chbProveedor.Checked Then
         idProveedor = Long.Parse(bscCodigoProveedor.Tag.ToString())
         If cmbTiposComprobantes.SelectedIndex <> -1 Then
            idTipoComprobante = cmbTiposComprobantes.SelectedValue.ToString()
            letra = txtLetra.Text
            emisor = txtEmisor.ValorNumericoPorDefecto(0I)
            numeroComprobante = bscComprobantes.Text.ValorNumericoPorDefecto(0L)
         End If
      End If

      Dim imprimeLote As Boolean = GetFormatoEtiqueta().ImprimeLote

      Dim dt As DataTable
      dt = oProd.GetPreciosEtiquetas({actual.Sucursal.Id},
                                     txtCodigo.Text.Trim(), txtProducto.Text.Trim(),
                                     cmbMarca.GetMarcas(True), cmbRubro.GetRubros(True),
                                     Nothing,
                                     Publicos.ListaPreciosPredeterminada,
                                     fechaActualizadoDesde:=Nothing, fechaActualizadoHasta:=Nothing, stock:="TODOS",
                                     idTipoComprobante, letra, emisor, numeroComprobante, idProveedor,
                                     imprimeLote, Me.chbMostrarProveedorHabitual.Checked)


      dt.Columns.Add("EAN13", Type.GetType("System.String"))
      dt.Columns.Add("EAN128", Type.GetType("System.String"))
      dt.Columns.Add("Lote_EAN128", GetType(String))

      Dim cadena As String

      For Each dr As DataRow In dt.Rows

         If String.IsNullOrEmpty(dr("CodigoDeBarras").ToString()) Then
            dr("CodigoDeBarras") = dr("IdProducto").ToString.Trim()
         End If

         Try
            cadena = Mid(dr("CodigoDeBarras").ToString(), 1, Len(dr("CodigoDeBarras").ToString()) - 1)
         Catch ex As Exception
            cadena = ""
         End Try

         If cadena.Length() <= 7 Then
            dr("EAN13") = Me.ConvertirEAN8(cadena)
         Else
            dr("EAN13") = Me.ConvertirEAN13(cadena)
         End If

         'dr("EAN128") = Me.Bar128B(dr("IdProducto").ToString())
         dr("EAN128") = dr("IdProducto").ToString().ToCode128()
         dr("Lote_EAN128") = dr("Lote").ToString().ToCode128()
      Next

      Me.dgvDetalle.DataSource = dt

      Me.dgvDetalle.Columns("Lote").Visible = imprimeLote
      Me.dgvSeleccionados.Columns("Lote2").Visible = imprimeLote

      Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      If Me.dgvDetalle.Rows.Count > 0 Then
         Me.chbTodos.Enabled = True
         If Me.dgvDetalle.Rows.Count = 1 Then
            Me.dgvDetalle.Rows(0).Cells("Imprime").Value = True
            Me.btnInsertar.PerformClick()
            If Me.txtCodigo.Text.Trim().Length > 0 Then
               Me.txtCodigo.Focus()
               Me.txtCodigo.SelectAll()
            Else
               Me.txtProducto.Focus()
               Me.txtProducto.SelectAll()
            End If
         Else
            Me.dgvDetalle.Focus()
         End If
      Else
         Me.txtCodigo.Focus()
         Me.chbTodos.Enabled = False
      End If

      Me.chbTodos.Checked = False

   End Sub

   Private Function GenerarDT() As DataTable

      Dim maxColumnas As Integer = GetFormatoEtiqueta().MaximoColumnas

      Dim dt = CrearDT2()
      Dim dtSelec = DirectCast(dgvSeleccionados.DataSource, DataTable).AsEnumerable()

      Dim Col As Integer = 0
      Dim drCl As DataRow = Nothing
      For Each dr In dtSelec

         'If Not dr.Cells("gImprime").Value Is Nothing AndAlso dr.Cells("gImprime").Value.ToString() <> "" Then
         '   If Boolean.Parse(dr.Cells("gImprime").Value.ToString()) Then

         Col += 1
         If Col = 1 Then
            drCl = dt.NewRow()
         End If

         Dim idProducto = dr.Field(Of String)("IdProducto").Trim()
         drCl("IdProducto" & Col.ToString()) = idProducto

         If Not String.IsNullOrEmpty(dr.Field(Of String)("CodigoDeBarras")) Then
            drCl("CodigoDeBarras" & Col.ToString()) = dr("CodigoDeBarras")
            drCl("EAN13" & Col.ToString()) = dr("EAN13")
            drCl("EAN128" & Col.ToString()) = dr("EAN128")

         Else
            'drCl("IdProducto" & Col.ToString()) = dr.Cells("gIdProducto").Value.ToString.Trim()
            drCl("CodigoDeBarras" & Col.ToString()) = idProducto
            drCl("EAN13" & Col.ToString()) = dr("EAN13")
            drCl("EAN128" & Col.ToString()) = dr("EAN128")
         End If
         drCl("EAN128") = dr("EAN128")

         drCl("Lote_EAN128") = dr("Lote_EAN128")

         drCl("Atributo1_Titulo" & Col.ToString()) = dr(gAtributo1_Titulo.DataPropertyName)
         drCl("Atributo2_Titulo" & Col.ToString()) = dr(gAtributo2_Titulo.DataPropertyName)
         drCl("Atributo1_Descripcion" & Col.ToString()) = dr(gAtributo1_Descripcion.DataPropertyName)
         drCl("Atributo2_Descripcion" & Col.ToString()) = dr(gAtributo2_Descripcion.DataPropertyName)


         drCl("NombreProducto" & Col.ToString()) = dr("NombreProducto")
         drCl("IdMarca" & Col.ToString()) = dr("IdMarca")
         drCl("NombreMarca" & Col.ToString()) = dr("NombreMarca")
         drCl("IdRubro" & Col.ToString()) = dr("IdRubro")
         drCl("NombreRubro" & Col.ToString()) = dr("NombreRubro")
         drCl("Alicuota" & Col.ToString()) = dr("Alicuota")

         If Reglas.Publicos.PreciosConIVA Then
            drCl("PrecioVenta" & Col.ToString()) = dr("PrecioVentaConIVA")
         Else
            drCl("PrecioVenta" & Col.ToString()) = dr("PrecioVentaSinIVA")
         End If

         drCl("FechaActualizacion" & Col.ToString()) = dr("FechaActualizacion")
         drCl("FechaActualizacion" & Col.ToString()) = dr("FechaActualizacion")

         drCl("Lote") = dr("Lote")

         drCl("TextoCabecera" & Col.ToString()) = txtCabecera.Text

         drCl("Alto" & Col.ToString()) = dr("Alto")
         drCl("Ancho" & Col.ToString()) = dr("Ancho")
         drCl("Largo" & Col.ToString()) = dr("Largo")
         drCl("Ubicacion" & Col.ToString()) = dr("Ubicacion")


         If Col = maxColumnas Then
            dt.Rows.Add(drCl)
            Col = 0
         End If

      Next

      'como son 3 columnas, verifico que inserte la fila por mas que no haya completado la fila
      If Col < maxColumnas And Col <> 0 Then
         dt.Rows.Add(drCl)
      End If

      Return dt

   End Function

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("Imprime", GetType(Boolean))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("NombreSucursal", GetType(String))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("PrecioVentaSinIVA", GetType(Decimal))
         .Columns.Add("Alicuota", GetType(Decimal))
         .Columns.Add("PrecioVentaConIVA", GetType(Decimal))
         .Columns.Add("Stock", GetType(Decimal))
         .Columns.Add("StockInicial", GetType(Decimal))
         .Columns.Add("IdMarca", GetType(Integer))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("IdRubro", GetType(Integer))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("FechaActualizacion", GetType(Date))
         .Columns.Add("CodigoDeBarras", GetType(String))
         .Columns.Add("EAN13", GetType(String))
         .Columns.Add("EAN128", GetType(String))
         .Columns.Add("Lote_EAN128", GetType(String))
         .Columns.Add("Lote", GetType(String))

         .Columns.Add("Atributo1_Titulo", GetType(String))
         .Columns.Add("Atributo2_Titulo", GetType(String))
         .Columns.Add("Atributo1_Descripcion", GetType(String))
         .Columns.Add("Atributo2_Descripcion", GetType(String))

         .Columns.Add("Alto", GetType(Decimal))
         .Columns.Add("Ancho", GetType(Decimal))
         .Columns.Add("Largo", GetType(Decimal))
         .Columns.Add("Ubicacion", GetType(String))

      End With
      Return dtTemp
   End Function

   Private Function CrearDT2() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("IdProducto1", GetType(String))
         .Columns.Add("NombreProducto1", GetType(String))
         .Columns.Add("Tamano1", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida1", GetType(String))
         .Columns.Add("IdMarca1", GetType(Integer))
         .Columns.Add("NombreMarca1", GetType(String))
         .Columns.Add("IdRubro1", GetType(Integer))
         .Columns.Add("NombreRubro1", GetType(String))
         .Columns.Add("IdTipoImpuesto1", GetType(String))
         .Columns.Add("Alicuota1", GetType(Decimal))
         .Columns.Add("PrecioFabrica1", GetType(Decimal))
         .Columns.Add("PrecioCosto1", GetType(Decimal))
         .Columns.Add("PrecioVenta1", GetType(Decimal))
         .Columns.Add("FechaActualizacion1", GetType(Date))
         .Columns.Add("TextoCabecera1", GetType(String))
         .Columns.Add("CodigoDeBarras1", GetType(String))
         .Columns.Add("EAN131", GetType(String))
         .Columns.Add("EAN128", GetType(String))
         .Columns.Add("EAN1281", GetType(String))
         .Columns.Add("Lote_EAN128", GetType(String))
         .Columns.Add("Atributo1_Titulo1", GetType(String))
         .Columns.Add("Atributo2_Titulo1", GetType(String))
         .Columns.Add("Atributo1_Descripcion1", GetType(String))
         .Columns.Add("Atributo2_Descripcion1", GetType(String))
         .Columns.Add("Alto1", GetType(Decimal))
         .Columns.Add("Ancho1", GetType(Decimal))
         .Columns.Add("Largo1", GetType(Decimal))
         .Columns.Add("Ubicacion1", GetType(String))


         .Columns.Add("IdProducto2", GetType(String))
         .Columns.Add("NombreProducto2", GetType(String))
         .Columns.Add("Tamano2", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida2", GetType(String))
         .Columns.Add("IdMarca2", GetType(Integer))
         .Columns.Add("NombreMarca2", GetType(String))
         .Columns.Add("IdRubro2", GetType(Integer))
         .Columns.Add("NombreRubro2", GetType(String))
         .Columns.Add("IdTipoImpuesto2", GetType(String))
         .Columns.Add("Alicuota2", GetType(Decimal))
         .Columns.Add("PrecioFabrica2", GetType(Decimal))
         .Columns.Add("PrecioCosto2", GetType(Decimal))
         .Columns.Add("PrecioVenta2", GetType(Decimal))
         .Columns.Add("FechaActualizacion2", GetType(Date))
         .Columns.Add("TextoCabecera2", GetType(String))
         .Columns.Add("CodigoDeBarras2", GetType(String))
         .Columns.Add("EAN132", GetType(String))
         .Columns.Add("EAN1282", GetType(String))
         .Columns.Add("Atributo1_Titulo2", GetType(String))
         .Columns.Add("Atributo2_Titulo2", GetType(String))
         .Columns.Add("Atributo1_Descripcion2", GetType(String))
         .Columns.Add("Atributo2_Descripcion2", GetType(String))
         .Columns.Add("Alto2", GetType(Decimal))
         .Columns.Add("Ancho2", GetType(Decimal))
         .Columns.Add("Largo2", GetType(Decimal))
         .Columns.Add("Ubicacion2", GetType(String))


         .Columns.Add("IdProducto3", GetType(String))
         .Columns.Add("NombreProducto3", GetType(String))
         .Columns.Add("Tamano3", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida3", GetType(String))
         .Columns.Add("IdMarca3", GetType(Integer))
         .Columns.Add("NombreMarca3", GetType(String))
         .Columns.Add("IdRubro3", GetType(Integer))
         .Columns.Add("NombreRubro3", GetType(String))
         .Columns.Add("IdTipoImpuesto3", GetType(String))
         .Columns.Add("Alicuota3", GetType(Decimal))
         .Columns.Add("PrecioFabrica3", GetType(Decimal))
         .Columns.Add("PrecioCosto3", GetType(Decimal))
         .Columns.Add("PrecioVenta3", GetType(Decimal))
         .Columns.Add("FechaActualizacion3", GetType(Date))
         .Columns.Add("TextoCabecera3", GetType(String))
         .Columns.Add("CodigoDeBarras3", GetType(String))
         .Columns.Add("EAN133", GetType(String))
         .Columns.Add("EAN1283", GetType(String))
         .Columns.Add("Atributo1_Titulo3", GetType(String))
         .Columns.Add("Atributo2_Titulo3", GetType(String))
         .Columns.Add("Atributo1_Descripcion3", GetType(String))
         .Columns.Add("Atributo2_Descripcion3", GetType(String))
         .Columns.Add("Alto3", GetType(Decimal))
         .Columns.Add("Ancho3", GetType(Decimal))
         .Columns.Add("Largo3", GetType(Decimal))
         .Columns.Add("Ubicacion3", GetType(String))


         .Columns.Add("IdProducto4", GetType(String))
         .Columns.Add("NombreProducto4", GetType(String))
         .Columns.Add("Tamano4", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida4", GetType(String))
         .Columns.Add("IdMarca4", GetType(Integer))
         .Columns.Add("NombreMarca4", GetType(String))
         .Columns.Add("IdRubro4", GetType(Integer))
         .Columns.Add("NombreRubro4", GetType(String))
         .Columns.Add("IdTipoImpuesto4", GetType(String))
         .Columns.Add("Alicuota4", GetType(Decimal))
         .Columns.Add("PrecioFabrica4", GetType(Decimal))
         .Columns.Add("PrecioCosto4", GetType(Decimal))
         .Columns.Add("PrecioVenta4", GetType(Decimal))
         .Columns.Add("FechaActualizacion4", GetType(Date))
         .Columns.Add("TextoCabecera4", GetType(String))
         .Columns.Add("CodigoDeBarras4", GetType(String))
         .Columns.Add("EAN134", GetType(String))
         .Columns.Add("EAN1284", GetType(String))
         .Columns.Add("Atributo1_Titulo4", GetType(String))
         .Columns.Add("Atributo2_Titulo4", GetType(String))
         .Columns.Add("Atributo1_Descripcion4", GetType(String))
         .Columns.Add("Atributo2_Descripcion4", GetType(String))
         .Columns.Add("Alto4", GetType(Decimal))
         .Columns.Add("Ancho4", GetType(Decimal))
         .Columns.Add("Largo4", GetType(Decimal))
         .Columns.Add("Ubicacion4", GetType(String))


         .Columns.Add("IdProducto5", GetType(String))
         .Columns.Add("NombreProducto5", GetType(String))
         .Columns.Add("Tamano5", GetType(Decimal))
         .Columns.Add("IdUnidadDeMedida5", GetType(String))
         .Columns.Add("IdMarca5", GetType(Integer))
         .Columns.Add("NombreMarca5", GetType(String))
         .Columns.Add("IdRubro5", GetType(Integer))
         .Columns.Add("NombreRubro5", GetType(String))
         .Columns.Add("IdTipoImpuesto5", GetType(String))
         .Columns.Add("Alicuota5", GetType(Decimal))
         .Columns.Add("PrecioFabrica5", GetType(Decimal))
         .Columns.Add("PrecioCosto5", GetType(Decimal))
         .Columns.Add("PrecioVenta5", GetType(Decimal))
         .Columns.Add("FechaActualizacion5", GetType(Date))
         .Columns.Add("TextoCabecera5", GetType(String))
         .Columns.Add("CodigoDeBarras5", GetType(String))
         .Columns.Add("EAN135", GetType(String))
         .Columns.Add("Lote", GetType(String))
         .Columns.Add("Atributo1_Titulo5", GetType(String))
         .Columns.Add("Atributo2_Titulo5", GetType(String))
         .Columns.Add("Atributo1_Descripcion5", GetType(String))
         .Columns.Add("Atributo2_Descripcion5", GetType(String))
         .Columns.Add("Alto5", GetType(Decimal))
         .Columns.Add("Ancho5", GetType(Decimal))
         .Columns.Add("Largo5", GetType(Decimal))
         .Columns.Add("Ubicacion5", GetType(String))

      End With
      Return dtTemp
   End Function

   Private Function ConvertirEAN13(cadena As String) As String
      Dim EAN13 As String = ""
      Dim i%, checksum%, first%, CodeBarre$

      Dim tableA As Boolean

      If Len(cadena) = 12 Then

         For i% = 1 To 12
            If Asc(Mid$(cadena, i%, 1)) < 48 Or Asc(Mid$(cadena, i%, 1)) > 57 Then
               i% = 0
               Exit For
            End If
         Next
         If i% = 13 Then
            For i% = 12 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            checksum% = checksum% * 3
            For i% = 11 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            cadena = cadena & (10 - checksum% Mod 10) Mod 10


            CodeBarre$ = Microsoft.VisualBasic.Left(cadena, 1) & Chr(65 + Integer.Parse(Val(Mid$(cadena, 2, 1)).ToString()))

            first% = Integer.Parse(Val(Microsoft.VisualBasic.Left(cadena, 1)).ToString())

            For i% = 3 To 7
               tableA = False
               Select Case i%
                  Case 3
                     Select Case first%
                        Case 0 To 3
                           tableA = True
                     End Select
                  Case 4
                     Select Case first%
                        Case 0, 4, 7, 8
                           tableA = True
                     End Select
                  Case 5
                     Select Case first%
                        Case 0, 1, 4, 5, 9
                           tableA = True
                     End Select
                  Case 6
                     Select Case first%
                        Case 0, 2, 5, 6, 7
                           tableA = True
                     End Select
                  Case 7
                     Select Case first%
                        Case 0, 3, 6, 8, 9
                           tableA = True
                     End Select
               End Select
               If tableA Then
                  CodeBarre$ = CodeBarre$ & Chr(65 + Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString()))
               Else
                  CodeBarre$ = CodeBarre$ & Chr(75 + Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString()))
               End If
            Next
            CodeBarre$ = CodeBarre$ & "*"
            For i% = 8 To 13
               CodeBarre$ = CodeBarre$ & Chr(97 + Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString()))
            Next
            CodeBarre$ = CodeBarre$ & "+"
            EAN13 = CodeBarre$
         End If
      End If
      Return EAN13
   End Function

   Private Function ConvertirEAN8(cadena As String) As String
      Dim EAN8 As String = ""
      Dim i%, checksum%, CodeBarre$
      ' Dim tableA As Boolean

      If Len(cadena) = 7 Then

         For i% = 1 To 7
            If Asc(Mid$(cadena, i%, 1)) < 48 Or Asc(Mid$(cadena, i%, 1)) > 57 Then
               i% = 0
               Exit For
            End If
         Next
         If i% = 8 Then

            For i% = 7 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            checksum% = checksum% * 3
            For i% = 6 To 1 Step -2
               checksum% += Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString())
            Next
            cadena = cadena & (10 - checksum% Mod 10) Mod 10

            CodeBarre$ = ":"
            For i% = 1 To 4
               CodeBarre$ = CodeBarre$ & Chr(65 + Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString()))
            Next
            CodeBarre$ = CodeBarre$ & "*"
            For i% = 5 To 8
               CodeBarre$ = CodeBarre$ & Chr(97 + Integer.Parse(Val(Mid$(cadena, i%, 1)).ToString()))
            Next
            CodeBarre$ = CodeBarre$ & "+"
            EAN8$ = CodeBarre$
         End If
      End If
      Return EAN8
   End Function

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Dim oProveedor As Eniac.Reglas.Proveedores = New Eniac.Reglas.Proveedores()
      Me._proveedorGrilla = oProveedor.GetUno(Long.Parse(Me.bscCodigoProveedor.Tag.ToString()))
      chbMostrarProveedorHabitual.Enabled = True

      bscComprobantes.Focus()
   End Sub

#End Region

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged

      'txtLetra.Enabled = chbProveedor.Checked
      'txtEmisor.Enabled = chbProveedor.Checked
      'bscComprobantes.Enabled = chbProveedor.Checked

      bscCodigoProveedor.Enabled = chbProveedor.Checked
      bscProveedor.Enabled = chbProveedor.Checked

      'Me.chbMostrarProveedorHabitual.Enabled = False
      'Me.chbMostrarProveedorHabitual.Checked = False

      chbMostrarProveedorHabitual.Enabled = chbProveedor.Checked

      ChbComp.Enabled = chbProveedor.Checked

      If Not chbProveedor.Checked Then

         'txtLetra.Text = ""
         'txtEmisor.Text = ""
         'bscComprobantes.Text = ""

         'If cmbTiposComprobantes.Items.Count > 0 Then
         '   cmbTiposComprobantes.SelectedIndex = -1
         'End If
         ChbComp.Checked = False
         chbMostrarProveedorHabitual.Checked = False

         bscCodigoProveedor.Text = ""
         bscCodigoProveedor.Tag = Nothing
         bscProveedor.Text = ""

         _proveedorGrilla = Nothing

      Else
         bscCodigoProveedor.Focus()
         'If Me.cmbTiposComprobantes.Items.Count > 0 Then
         '   Me.cmbTiposComprobantes.SelectedIndex = -1
         'End If
      End If

      cmbTiposComprobantes.Focus()
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         If Me.bscCodigoProveedor.Text.Trim.Length > 0 Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = oProveedores.GetFiltradoPorCodigo(codigoProveedor)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnBuscar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscComprobante_BuscadorClick() Handles bscComprobantes.BuscadorClick
      Try
         If _proveedorGrilla IsNot Nothing Then
            Dim numero As Long = 0
            If Me.bscComprobantes.Text <> "" Then
               numero = Long.Parse(Me.bscComprobantes.Text.ToString())
            End If

            Dim oComprobantes As Reglas.Compras = New Reglas.Compras
            Me.PreparaGrillaComprobantes(Me.bscComprobantes)

            Me.bscComprobantes.Datos = oComprobantes.GetPorRangoFechas({actual.Sucursal},
                                               actual.Sucursal.IdEmpresa, 0, Nothing, Nothing,
                                               Me._proveedorGrilla.IdProveedor,
                                               0, "TODOS", "TODOS", "TODOS",
                                               String.Empty, numero, 0, 0,
                                               String.Empty, 0, String.Empty, 0,
                                               idMoneda:=Entidades.Moneda.Peso, tipoConversion:=Entidades.Moneda_TipoConversion.Comprobante, cotizDolar:=0)

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscComprobante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscComprobantes.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            If _proveedorGrilla IsNot Nothing Then
               Me.CargarComprobante(e.FilaDevuelta)
               Me.btnBuscar.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub CargarComprobante(dr As DataGridViewRow)
      Me.cmbTiposComprobantes.SelectedValue = dr.Cells("IdTipoComprobante").Value.ToString()
      Me.txtLetra.Text = dr.Cells("Letra").Value.ToString()
      Me.txtEmisor.Text = dr.Cells("CentroEmisor").Value.ToString()
      Me.bscComprobantes.Text = dr.Cells("NumeroComprobante").Value.ToString()
   End Sub
   'Public Sub PreparaGrillaComprobantes(buscador As Eniac.Controles.Buscador)
   '   With buscador
   '      .Titulo = "Comprobantes pendientes"
   '      .ColumnasOcultas = New String() {"Sucursal", "IdProveedor", "CodigoProveedor", "IdFormasPago", "Observacion", "IdTipoComprobante"}
   '      .ColumnasTitulos = New String() {"Sucursal", "Vencimiento", "Tipo", "Letra", "Emisor", "Número", "Cuota", "Emisión", "Importe", "Saldo"}
   '      .ColumnasFormato = New String() {"", "dd/MM/yyyy", "", "", "", "", "", "dd/MM/yyyy", "#,##0.00", "#,##0.00"}
   '      .ColumnasAlineacion = New System.Windows.Forms.DataGridViewContentAlignment() {DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleLeft, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleCenter, DataGridViewContentAlignment.MiddleRight, DataGridViewContentAlignment.MiddleRight}
   '      .ColumnasAncho = New Integer() {0, 70, 100, 40, 40, 60, 40, 70, 70, 70}
   '   End With
   'End Sub

   Private Sub PreparaGrillaComprobantes(buscador As Eniac.Controles.Buscador2)
      With buscador
         .ConfigBuscador = New Controles.ConfigBuscador() _
                          With {.Titulo = "Comprobantes",
                                .AnchoAyuda = 712}

         Dim col As Eniac.Controles.ColumnaBuscador
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 1
         col.Nombre = "NombreTipoComprobante"
         col.Titulo = "Tipo"
         col.Ancho = 200
         col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 2
         col.Nombre = "Letra"
         col.Titulo = "L."
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 25
         .ColumnasVisibles.Add(col)
         '-- 
         col = New Controles.ColumnaBuscador
         col.Orden = 3
         col.Nombre = "CentroEmisor"
         col.Titulo = "Emisor"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 40
         .ColumnasVisibles.Add(col)

         col = New Controles.ColumnaBuscador
         col.Orden = 4
         col.Nombre = "NumeroComprobante"
         col.Titulo = "Número"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 5
         col.Nombre = "Fecha"
         col.Titulo = "Fecha"
         col.Alineacion = DataGridViewContentAlignment.MiddleCenter
         col.Ancho = 80
         .ColumnasVisibles.Add(col)
         '--
         col = New Controles.ColumnaBuscador
         col.Orden = 6
         col.Nombre = "ImporteTotal"
         col.Titulo = "Importe Total"
         col.Alineacion = DataGridViewContentAlignment.MiddleRight
         col.Ancho = 100
         col.Formato = "N2"
         .ColumnasVisibles.Add(col)
         'col = New Controles.ColumnaBuscador
         'col.Orden = 6
         'col.Nombre = "CodigoCliente"
         'col.Titulo = "Código"
         'col.Alineacion = DataGridViewContentAlignment.MiddleRight
         'col.Ancho = 70
         '.ColumnasVisibles.Add(col)

         'col = New Controles.ColumnaBuscador
         'col.Orden = 7
         'col.Nombre = "NombreCliente"
         'col.Titulo = "Cliente"
         'col.Alineacion = DataGridViewContentAlignment.MiddleLeft
         'col.Ancho = 250
         '.ColumnasVisibles.Add(col)
      End With
   End Sub

   Private Sub CargarImpresorasInstaladas()
      Dim i As Integer
      Dim pkInstalledPrinters As String

      Dim instance As PrinterSettings = New PrinterSettings()

      For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
         pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)

         Me.cmbImpresora.Items.Add(pkInstalledPrinters)
      Next

      'agrego una impresora vacia
      Me.cmbImpresora.Items.Add("")

   End Sub

   Private Sub comboInstalledPrinters_SelectionChanged(sender As Object, e As EventArgs)
      ' Set the printer to a printer in the combo box when the selection changes.
      If Me.cmbImpresora.SelectedIndex <> -1 Then
         ' The combo box's Text property returns the selected item's text, which is the printer name.
         printDoc.PrinterSettings.PrinterName = Me.cmbImpresora.SelectedText
      End If
   End Sub

   Private Function GetFormatoEtiqueta() As Entidades.FormatoEtiqueta
      Dim result = cmbFormatos.ItemSeleccionado(Of Entidades.FormatoEtiqueta)()
      If result Is Nothing Then result = New Entidades.FormatoEtiqueta()
      Return result
   End Function

   Private Sub ChbComp_CheckedChanged(sender As Object, e As EventArgs) Handles ChbComp.CheckedChanged

      bscComprobantes.Enabled = ChbComp.Checked

      'Me.chbMostrarProveedorHabitual.Enabled = False
      'Me.chbMostrarProveedorHabitual.Checked = False
      If chbProveedor.Checked Then
         chbMostrarProveedorHabitual.Enabled = Not ChbComp.Checked
      End If


      If Not ChbComp.Checked Then
         '   chbMostrarProveedorHabitual.Enabled = True
         txtLetra.Text = ""
         txtEmisor.Text = ""
         bscComprobantes.Text = ""

         If cmbTiposComprobantes.Items.Count > 0 Then
            cmbTiposComprobantes.SelectedIndex = -1
         End If
      Else
         bscCodigoProveedor.Focus()
      End If

      bscComprobantes.Focus()
   End Sub

   Private Sub chbMostrarProveedorHabitual_CheckedChanged(sender As Object, e As EventArgs) Handles chbMostrarProveedorHabitual.CheckedChanged
      Try
         If chbProveedor.Checked Then
            ChbComp.Enabled = Not chbMostrarProveedorHabitual.Checked
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class
Imports Eniac.Reglas

Public Class CargosClientes

#Region "Campos"
   Private _dtCargosClientes As DataTable
   Private _automat As Boolean = False

   Private Const _selecColumn As String = "Selec"
   Private Const _precioListaColumn As String = "PrecioListaNuevo"
   Private Const _descuentoRecargoPorc1Column As String = "DescuentoRecargoPorc1Nuevo"
   Private Const _descuentoRecargoPorcGralColumn As String = "DescuentoRecargoPorcGral"
   Private Const _cantidadColumn As String = "cantidad"
   Private Const _montoColumn As String = "MontoNuevo"
   Private Const _importeColumn As String = "ImporteNuevo"
   Private Const _observacionesColumn As String = "Observacion"
   Private _estaCargando As Boolean = True
   Private _publicos As Publicos

   Private _cargosClientesObservaciones As List(Of Entidades.CargoClienteObservacion)
   Private _mostrarDescRec As Boolean = Reglas.Publicos.CargosUtilizaDescuentosRecargos
   Private _ColorColumnasEditables As Color = System.Drawing.Color.FromArgb(224, 224, 224)
   Private _DecimalesEnPrecio As Integer = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnPrecio

   Private _listaSucursales As List(Of Entidades.Sucursal)
   Private _utilizaCentroCostos As Boolean = False

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         _publicos = New Publicos()

         _publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
         cmbTiposLiquidacion.SelectedIndex = 0

         _publicos.CargaComboCategorias(Me.cmbCategorias)
         _publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
         cmbZonaGeografica.SelectedIndex = -1

         _publicos.CargaComboTipoClientes(Me.cmbTipoCliente)

         ' Me._publicos.CargaComboCobradores2(cmbCobrador)
         Me._publicos.CargaComboEmpleados(cmbCobrador, Entidades.Publicos.TiposEmpleados.COBRADOR)

         Dim aFiltrosPeriodos = New ArrayList()
         aFiltrosPeriodos.Insert(0, "<")
         aFiltrosPeriodos.Insert(1, "<=")
         aFiltrosPeriodos.Insert(2, "=")
         aFiltrosPeriodos.Insert(3, ">=")
         aFiltrosPeriodos.Insert(4, ">")
         cmbFiltrosPcs.DataSource = aFiltrosPeriodos

         '-- REQ-34811.- ----------------------------------------------------------------
         _publicos.CargaComboDesdeEnum(cmbActivo, GetType(Entidades.Publicos.SiNoTodos))
         cmbActivo.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         '-------------------------------------------------------------------------------

         If Reglas.Publicos.CuitEmpresa = "33711345499" Then
            chbCantidadPcs.Visible = True
            cmbFiltrosPcs.Visible = True
            txtPcs.Visible = True
         End If

         FechaLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         Refrescar()

         LeerPreferencias()

         _estaCargando = False

         _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

         ugDetalleFacturacion.AgregarFiltroEnLinea({"NombreCliente", "NombreVendedor", "NombreProducto", "NombreLocalidad", "NombreProvincia", "NombreCentroCosto", "Observacion"}, {"Ver", "Imprimir", "VerEstandar"})
         ugCargos.AgregarFiltroEnLinea({"NombreCargo"})

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F4 And tsbGrabar.Enabled Then
         tsbGrabar.PerformClick()
      ElseIf keyData = Keys.F8 Then
         btnCalcular.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function

#End Region

#Region "Eventos"
   Private Sub cmbTiposLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposLiquidacion.SelectedIndexChanged
      Try
         If Not _estaCargando Then
            Me.FechaLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
            Refrescar()
            Me.LeerPreferencias()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbTodos_CheckedChanged(sender As Object, e As EventArgs) Handles chbTodos.CheckedChanged
      Me.Cursor = Cursors.WaitCursor

      For Each dr As UltraGridRow In ugCargos.Rows
         dr.Cells(_selecColumn).Value = Me.chbTodos.Checked
      Next
      CalculaTotal()
      Me.Cursor = Cursors.Default
   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      Me.cmbCategorias.Enabled = Me.chbCategoria.Checked

      If Me.chbCategoria.Checked Then
         Me.cmbCategorias.SelectedIndex = 0
         Me.cmbCategorias.Focus()
      Else
         Me.cmbCategorias.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged
      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Me.chbZonaGeografica.Checked = True Then
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If
         Me.cmbZonaGeografica.Focus()
      Else
         Me.cmbZonaGeografica.SelectedIndex = -1
      End If
   End Sub

   Private Sub chbCobrador_CheckedChanged(sender As Object, e As EventArgs) Handles chbCobrador.CheckedChanged

      Me.cmbCobrador.Enabled = Me.chbCobrador.Checked
      'cmbOrigenCobrador.Enabled = chbCobrador.Checked
      If Not Me.chbCobrador.Checked Then
         Me.cmbCobrador.SelectedIndex = -1
      Else
         If Me.cmbCobrador.Items.Count > 0 Then
            Me.cmbCobrador.SelectedIndex = 0
         End If

         Me.cmbCobrador.Focus()

      End If

   End Sub

   Private Sub chbCantidadPcs_CheckedChanged(sender As Object, e As EventArgs) Handles chbCantidadPcs.CheckedChanged
      Me.cmbFiltrosPcs.Enabled = Me.chbCantidadPcs.Checked
      Me.txtPcs.Enabled = Me.chbCantidadPcs.Checked
      If Not Me.chbCantidadPcs.Checked Then
         Me.cmbFiltrosPcs.SelectedIndex = -1
         Me.txtPcs.Text = ""
      Else
         If Me.cmbFiltrosPcs.Items.Count > 0 Then
            Me.cmbFiltrosPcs.SelectedIndex = 0
         End If

         Me.txtPcs.Focus()

      End If
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      Try

         Me.Refrescar()

         Me.LeerPreferencias()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbPreferencias_Click_1(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         Dim pre As Preferencias = New Preferencias(Me.ugResumen, True)
         pre.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoClienteHistorial_BuscadorClick() Handles bscCodigoClienteHistorial.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoClienteHistorial)
         'Me.bscCodigoCliente.Datos = entidad.GetFiltradoPorCodigo(Me.bscCodigoCliente.Text)
         Dim codigoCliente As Long = -1
         If Me.bscCodigoClienteHistorial.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoClienteHistorial.Text.Trim())
         End If

         Me.bscCodigoClienteHistorial.Datos = entidad.GetFiltradoPorCodigo(codigoCliente, True, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoClienteHistorial_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteHistorial.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteHistorial(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreClienteHistorial_BuscadorClick() Handles bscNombreClienteHistorial.BuscadorClick
      Try
         Dim entidad As Reglas.Clientes = New Reglas.Clientes()
         Me._publicos.PreparaGrillaClientes2(Me.bscNombreClienteHistorial)
         Me.bscNombreClienteHistorial.Datos = entidad.GetFiltradoPorNombre(Me.bscNombreClienteHistorial.Text, True)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub bscNombreClienteHistorial_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreClienteHistorial.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteHistorial(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos


                  For Each dr1 As DataRow In Me._dtCargosClientes.Rows
                     dr1("sel2") = True
                  Next

                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos

                  For Each dr1 As DataRow In Me._dtCargosClientes.Rows
                     dr1("sel2") = False
                  Next

                  Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos

                  For Each dr1 As DataRow In Me._dtCargosClientes.Rows
                     dr1("sel2") = Not CBool(dr1("sel2"))
                  Next

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         Me.ugResumen.UpdateData()
         Me._dtCargosClientes.AcceptChanges()
      End Try
   End Sub

   Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
      Try

         If Me.ugResumen.Rows.Count = 0 Then Exit Sub


         Me.Cursor = Cursors.WaitCursor

         Me.BarraInicializa("Calculando precios...", 0, Me.ugResumen.Rows.Count)

         Me.CalcularNuevosPrecios()

         Me.ugResumen.Focus()
         Dim aUGRow As UltraGridRow = Me.ugResumen.GetRow(ChildRow.First)
         Me.ugResumen.ActiveRow = aUGRow
         Me.ugResumen.ActiveCell = aUGRow.Cells("PrecioLista")
         Me.ugResumen.PerformAction(UltraGridAction.EnterEditMode, False, False)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.BarraFinaliza()
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      If Me.chkExpandAll.Checked Then
         Me.ugDetalle.Rows.ExpandAll(True)
      Else
         Me.ugDetalle.Rows.CollapseAll(True)
      End If
   End Sub
   Private Sub chkExpandAllTwo_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAllTwo.CheckedChanged
      If Me.chkExpandAllTwo.Checked Then
         Me.ugDetalleFacturacion.Rows.ExpandAll(True)
      Else
         Me.ugDetalleFacturacion.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub btnConsultar2_Click(sender As Object, e As EventArgs) Handles btnConsultar2.Click
      TryCatched(
         Sub()
            CargaGrillaDetalle()
            If ugDetalle.Rows.Count > 0 Then
               btnConsultar2.Focus()
            Else
               ShowMessage("¡¡¡NO hay registros que cumplan con la seleccion !!!")
               Exit Sub
            End If
         End Sub)
   End Sub

#Region "Eventos Toolbar"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      Try
         LimpiarFiltros()
         Refrescar()
         Me.LeerPreferencias()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click

      Try
         Cursor = Cursors.WaitCursor
         Me.ugCargos.UpdateData()
         Me._dtCargosClientes.AcceptChanges()

         Dim reg As Reglas.CargosClientes = New Reglas.CargosClientes()

         'reg.GrabarCargosClientes(actual.Sucursal.IdSucursal, Me._dtCargosClientes, Me._cargosClientesObservaciones,
         '                         Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         Dim idCategoria As Integer = 0
         Dim idZonaGeografica As String = ""
         Dim idCobrador As Integer = 0
         Dim cantidadPcs As Integer = 0

         Dim idCliente As Long = 0
         If Me.chbCliente.Checked Then
            If Not Me.bscCodigoCliente.Selecciono Or Not Me.bscNombreCliente.Selecciono Then
               MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.bscCodigoCliente.Focus()
               Exit Sub
            Else
               idCliente = Long.Parse(bscCodigoCliente.Tag.ToString())
            End If
         End If

         If chbCategoria.Checked AndAlso cmbCategorias.SelectedValue IsNot Nothing Then
            idCategoria = CInt(cmbCategorias.SelectedValue)
         End If
         If chbZonaGeografica.Checked AndAlso cmbZonaGeografica.SelectedValue IsNot Nothing Then
            idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
         End If
         If chbCobrador.Checked Then
            idCobrador = Integer.Parse(cmbCobrador.SelectedValue.ToString())
         End If

         If chbCantidadPcs.Checked Then
            cantidadPcs = Integer.Parse(txtPcs.Text.ToString())
         End If

         ' Verifico que todos los clientes que se encuentren con Cargos Asignados, estén activos
         Dim dv As DataView = New DataView(_dtCargosClientes, "Selec AND Not Activo", "", DataViewRowState.CurrentRows)
         If dv.Count > 0 Then
            Throw New Exception(String.Format("El cliente ({0}) {1} posee cargos asignados y se encuentra inactivo. No se puede continuar con la grabación.",
                                 dv(0)("CodigoCliente"), dv(0)("NombreCliente")))
         End If
         reg.GrabarCargosClientes(actual.Sucursal.IdSucursal, Me._dtCargosClientes, Me._cargosClientesObservaciones, Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()),
                                  idCliente, idCategoria, idZonaGeografica, idCobrador, cmbFiltrosPcs.Text, cantidadPcs)
         MessageBox.Show("Se actualizaron los Cargos para el Cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Refrescar()
         Me.LeerPreferencias()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try

         If Me.ugCargos.Rows.Count = 0 Then Exit Sub
         Me.Cursor = Cursors.WaitCursor
         Dim Filtros As String = String.Empty

         If tbcLiquidacion.SelectedTab Is Me.tbpCarga Then
            If Me.ugClientes.Rows.Count = 0 Then Exit Sub
         ElseIf tbcLiquidacion.SelectedTab Is Me.tbpResumen Then
            If Me.ugResumen.Rows.Count = 0 Then Exit Sub
         End If

         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresa + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         If tbcLiquidacion.SelectedTab Is Me.tbpCarga Then
            Me.UltraGridPrintDocument1.Grid = Me.ugClientes
         ElseIf tbcLiquidacion.SelectedTab Is Me.tbpResumen Then
            Me.UltraGridPrintDocument1.Grid = Me.ugResumen
         End If

         Me.UltraPrintPreviewDialog1.Document = Me.UltraGridPrintDocument1

         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + Date.Today.ToString("dd/MM/yyyy")

         Me.UltraPrintPreviewDialog1.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      Try
         Me.sfdExportar.FileName = Me.Name & "_ResumenCargos.xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               If Me.tbcLiquidacion.SelectedTab Is Me.tbpCarga Then
                  Me.UltraGridExcelExporter1.Export(Me.ugClientes, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
               Else
                  Me.UltraGridExcelExporter1.Export(Me.ugResumen, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      Try
         Me.sfdExportar.FileName = Me.Name & "_ResumenCargos.pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"
         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               If Me.tbcLiquidacion.SelectedTab Is Me.tbpCarga Then
                  Me.UltraGridDocumentExporter1.Export(Me.ugClientes, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
               Else
                  Me.UltraGridDocumentExporter1.Export(Me.ugResumen, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
               End If
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

#End Region

#Region "Eventos Grilla Clientes"

   Private Sub dgvClientes_AfterRowActivate(sender As Object, e As EventArgs) Handles ugClientes.AfterRowActivate
      Try

         ugCargos.Enabled = ugClientes.ActiveRow.ListObject IsNot Nothing

         Me._automat = True

         Me.chbTodos.Checked = False

         If ugClientes.ActiveRow IsNot Nothing AndAlso ugClientes.ActiveRow IsNot Nothing AndAlso
             TypeOf (ugClientes.ActiveRow.ListObject) Is DataRowView Then
            ugCargos.DisplayLayout.Bands(0).Columns(_selecColumn).CellActivation = Activation.AllowEdit
            Dim drCliente As DataRow = DirectCast(ugClientes.ActiveRow.ListObject, DataRowView).Row

            Me.GetObservacionesCliente(Long.Parse(drCliente(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString()),
                                       Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

            Me.txtCodigoCliente.Text = drCliente(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString()
            Me.txtCodigoCliente.Tag = drCliente(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString()

            Me.CargarGrillaCargos(drCliente)
         Else
            ugCargos.DisplayLayout.Bands(0).Columns(_selecColumn).CellActivation = Activation.NoEdit
         End If

         CalculaTotal()

         Me._automat = False
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
#End Region

#Region "Eventos Grilla Cargos"
   Private Sub ugCargos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugCargos.InitializeRow
      Dim dr As DataRow = ugCargos.FilaSeleccionada(Of DataRow)(e.Row)
      If dr IsNot Nothing Then
         If Decimal.Parse(dr(Entidades.Cargo.Columnas.Monto.ToString()).ToString()) <> Decimal.Parse(dr(Entidades.Cargo.ColumnasCargos.MontoOriginal.ToString()).ToString()) Then
            SetColorCelda(e.Row.Cells(Entidades.Cargo.Columnas.Monto.ToString()), Color.Cyan, Color.Black)
         Else
            SetColorCelda(e.Row.Cells(Entidades.Cargo.Columnas.Monto.ToString()), Nothing, Nothing)
         End If
         If Not String.IsNullOrEmpty(dr(_precioListaColumn).ToString()) Then
            If Decimal.Parse(dr(_precioListaColumn).ToString()) <> Decimal.Parse(dr(Entidades.Cargo.ColumnasCargos.MontoOriginal.ToString()).ToString()) Then
               SetColorCelda(e.Row.Cells(_precioListaColumn), Color.Cyan, Color.Black)
            Else
               SetColorCelda(e.Row.Cells(_precioListaColumn), Nothing, Nothing)
            End If
         Else
            dr(_precioListaColumn) = 0
         End If
         If Not String.IsNullOrEmpty(dr(_descuentoRecargoPorc1Column).ToString()) Then
            If Decimal.Parse(dr(_descuentoRecargoPorc1Column).ToString()) <> 0 Then
               SetColorCelda(e.Row.Cells(_descuentoRecargoPorc1Column), Color.Cyan, Color.Black)
            Else
               SetColorCelda(e.Row.Cells(_descuentoRecargoPorc1Column), Nothing, Nothing)
            End If
         Else
            dr(_descuentoRecargoPorc1Column) = 0
         End If
         If Not String.IsNullOrEmpty(dr(_montoColumn).ToString()) Then
            If Decimal.Parse(dr(_montoColumn).ToString()) <> 0 Then
               SetColorCelda(e.Row.Cells(_montoColumn), Color.Cyan, Color.Black)
            Else
               SetColorCelda(e.Row.Cells(_montoColumn), Nothing, Nothing)
            End If
         Else
            dr(_montoColumn) = 0
         End If


         'If Decimal.Parse(dr(Entidades.CargoCliente.Columnas.DescuentoRecargoPorc2.ToString()).ToString()) <> 0 Then
         '   SetColorCelda(e.Row.Cells(Entidades.CargoCliente.Columnas.DescuentoRecargoPorc2.ToString()), Color.Cyan, Color.Black)
         'Else
         '   SetColorCelda(e.Row.Cells(Entidades.CargoCliente.Columnas.PrecioLista.ToString()), Nothing, Nothing)
         'End If

         If Decimal.Parse(dr(Entidades.CargoCliente.Columnas.Cantidad.ToString()).ToString()) <> 1D Then
            SetColorCelda(e.Row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()), Color.Cyan, Color.Black)
         Else
            SetColorCelda(e.Row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()), Nothing, Nothing)
         End If

         EvaluaActivarCeldas(e.Row)
      End If
   End Sub

   Private Sub ugCargos_CellChange(sender As Object, e As CellEventArgs) Handles ugCargos.CellChange
      Try
         If e.Cell.Column.Key = _selecColumn Then
            ugCargos.UpdateData()
            Dim dr As DataRow = ugCargos.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            If dr IsNot Nothing Then

               Dim drC = _dtCargosClientes.Select(String.Format("IdCargo = {0}", dr("IdCargo")))
               drC(0)("Cantidad") = dr("Cantidad")

               If CBool(dr(_selecColumn)) Then
                  dr(_precioListaColumn) = dr("MontoCargo")
                  dr(_montoColumn) = dr("MontoCargo")
                  dr("PrecioListaNuevoSinIVA") = dr("MontoCargoSinIVA")
                  dr("MontoNuevoSinIVA") = dr("MontoCargoSinIVA")
               Else
                  dr("Cantidad") = 0
                  dr(_precioListaColumn) = 0
                  dr(_montoColumn) = 0
                  dr("PrecioListaNuevoSinIVA") = 0
                  dr("MontoNuevoSinIVA") = 0
               End If
            End If
            EvaluaActivarCeldas(e.Cell.Row)
         End If
         'If e.Cell.Column.Key = "Cantidad" Then
         '   ugCargos.UpdateData()

         '   Dim dr As DataRow = ugCargos.FilaSeleccionada(Of DataRow)(e.Cell.Row)
         '   If dr IsNot Nothing Then
         '      Dim drC = _dtCargosClientes.Select(String.Format("IdCargo = {0}", dr("IdCargo")))
         '      drC(0)("Cantidad") = dr("Cantidad")
         '   End If
         'End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugCargos_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugCargos.AfterCellUpdate
      Dim dr As DataRow = ugCargos.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Dim cantidad As Decimal = If(IsNumeric(dr(_cantidadColumn)), Decimal.Parse(dr(_cantidadColumn).ToString()), 0)
         Dim precioLista As Decimal = If(IsNumeric(dr(_precioListaColumn)), Decimal.Parse(dr(_precioListaColumn).ToString()), 0)
         Dim descuentoRecargoPorcGral As Decimal = If(IsNumeric(dr(_descuentoRecargoPorcGralColumn)), Decimal.Parse(dr(_descuentoRecargoPorcGralColumn).ToString()), 0)
         Dim descuentoRecargoPorc1 As Decimal = If(IsNumeric(dr(_descuentoRecargoPorc1Column)), Decimal.Parse(dr(_descuentoRecargoPorc1Column).ToString()), 0)
         Dim monto As Decimal = If(IsNumeric(dr(_montoColumn)), Decimal.Parse(dr(_montoColumn).ToString()), 0)
         Dim montoParaImporte As Decimal = monto
         If e.Cell.Column.Key = _precioListaColumn Or e.Cell.Column.Key = _descuentoRecargoPorc1Column Then
            Dim nuevoMonto As Decimal
            nuevoMonto = precioLista
            nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorcGral / 100))
            nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorc1 / 100))
            dr(_montoColumn) = Math.Round(nuevoMonto, 2)
            montoParaImporte = nuevoMonto
         ElseIf e.Cell.Column.Key = _montoColumn Then
            If precioLista <> 0 Then
               precioLista = precioLista * (1 + (descuentoRecargoPorcGral / 100))
               dr(_descuentoRecargoPorc1Column) = Math.Round(((monto / precioLista) - 1) * 100, 2)
            Else
               dr(_descuentoRecargoPorc1Column) = 0
            End If
         End If
         If String.IsNullOrEmpty(dr("Cantidad").ToString()) Then
            dr("Cantidad") = 0
         Else
            Dim drC = _dtCargosClientes.Select(String.Format("IdCargo = {0}", dr("IdCargo")))
            drC(0)("Cantidad") = dr("Cantidad")
         End If
         dr(_importeColumn) = Math.Round(montoParaImporte * cantidad, 2)
         Me.CalculaTotal()
      End If
   End Sub
#End Region

#Region "Eventos Grilla Resumen"
   Private Sub dgvResumen_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugResumen.InitializeRow
      If e.Row.Cells.Contains(_importeColumn) Then
         e.Row.Cells(_importeColumn).Value = CDec(e.Row.Cells(Entidades.Cargo.Columnas.Monto.ToString()).Value) *
                                             CDec(e.Row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()).Value)
      End If
   End Sub

   Private Sub ugResumen_AfterCellUpdate(sender As Object, e As CellEventArgs) Handles ugResumen.AfterCellUpdate

      If e.Cell.Row.Index = -1 Then Exit Sub


      Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row
      Dim cantidad As Decimal = If(IsNumeric(dr(_cantidadColumn)), Decimal.Parse(dr(_cantidadColumn).ToString()), 0)
      Dim precioLista As Decimal = If(IsNumeric(dr("PrecioListaNuevo")), Decimal.Parse(dr("PrecioListaNuevo").ToString()), 0)
      Dim precioListaSinIVA As Decimal = If(IsNumeric(dr("PrecioListaNuevoSinIVA")), Decimal.Parse(dr("PrecioListaNuevoSinIVA").ToString()), 0)
      Dim descuentoRecargoPorcGral As Decimal = If(IsNumeric(dr("descuentoRecargoPorcGral")), Decimal.Parse(dr("descuentoRecargoPorcGral").ToString()), 0)
      Dim descuentoRecargoPorc1 As Decimal = If(IsNumeric(dr("DescuentoRecargoPorc1Nuevo")), Decimal.Parse(dr("DescuentoRecargoPorc1Nuevo").ToString()), 0)
      Dim monto As Decimal = If(IsNumeric(dr("MontoNuevo")), Decimal.Parse(dr("MontoNuevo").ToString()), 0)
      Dim montoSinIVA As Decimal = If(IsNumeric(dr("MontoNuevoSinIVA")), Decimal.Parse(dr("MontoNuevoSinIVA").ToString()), 0)

      Dim montoParaImporte As Decimal = monto
      Dim montoParaImporteSinIVA As Decimal = montoSinIVA

      If e.Cell.Column.Key = "PrecioListaNuevo" Or e.Cell.Column.Key = "DescuentoRecargoPorc1Nuevo" Then

         Dim nuevoMonto As Decimal

         'Circuito Normal (cambiar)
         If Not Me.rdbMontoSinCambiar.Checked Then

            nuevoMonto = precioLista
            nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorcGral / 100))
            nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorc1 / 100))
            dr("MontoNuevo") = Math.Round(nuevoMonto, 2)
            montoParaImporte = nuevoMonto

         Else

            'GAR: 15/06/2019 - Y los otros Campos???
            dr("PrecioListaNuevo") = precioLista
            descuentoRecargoPorc1 = (monto / precioLista - 1) * 100 - descuentoRecargoPorcGral
            dr("DescuentoRecargoPorc1Nuevo") = Math.Round(descuentoRecargoPorc1, 2)

         End If


      ElseIf e.Cell.Column.Key = "MontoNuevo" Then

         If precioLista <> 0 Then
            precioLista = precioLista * (1 + (descuentoRecargoPorcGral / 100))
            dr("DescuentoRecargoPorc1Nuevo") = Math.Round(((monto / precioLista) - 1) * 100, 2)
         Else
            dr("DescuentoRecargoPorc1Nuevo") = 0
         End If

      End If

      If e.Cell.Column.Key = "PrecioListaNuevoSinIVA" Then
         Dim nuevoMontoSinIVA As Decimal

         'Circuito Normal (cambiar)
         If Not Me.rdbMontoSinCambiar.Checked Then

            nuevoMontoSinIVA = precioListaSinIVA
            nuevoMontoSinIVA = nuevoMontoSinIVA * (1 + (descuentoRecargoPorcGral / 100))
            nuevoMontoSinIVA = nuevoMontoSinIVA * (1 + (descuentoRecargoPorc1 / 100))
            dr("MontoNuevoSinIVA") = Math.Round(nuevoMontoSinIVA, 2)
            dr("MontoNuevo") = Math.Round(nuevoMontoSinIVA * 1.21, 2)
            dr("PrecioListaNuevo") = Math.Round(Decimal.Parse(dr("PrecioListaNuevoSinIVA").ToString()) * 1.21, 2)
            montoParaImporteSinIVA = nuevoMontoSinIVA
            montoParaImporte = Decimal.Parse((montoParaImporteSinIVA * 1.21).ToString())

         Else

            'GAR: 15/06/2019 - Y los otros Campos???
            dr("PrecioListaNuevoSinIVA") = precioListaSinIVA
            descuentoRecargoPorc1 = (montoSinIVA / precioListaSinIVA - 1) * 100 - descuentoRecargoPorcGral
            dr("DescuentoRecargoPorc1Nuevo") = Math.Round(descuentoRecargoPorc1, 2)

         End If

      ElseIf e.Cell.Column.Key = "MontoNuevoSinIVA" Then
         If precioListaSinIVA <> 0 Then
            precioListaSinIVA = precioListaSinIVA * (1 + (descuentoRecargoPorcGral / 100))
            dr("DescuentoRecargoPorc1Nuevo") = Math.Round(((montoSinIVA / precioListaSinIVA) - 1) * 100, 2)
         Else
            dr("DescuentoRecargoPorc1Nuevo") = 0
         End If
         dr("MontoNuevo") = Math.Round(Decimal.Parse(dr("MontoNuevoSinIVA").ToString()) * 1.21, 2)
         montoParaImporte = Decimal.Parse(dr("MontoNuevo").ToString())
      End If

      dr("ImporteNuevo") = Math.Round(montoParaImporte * cantidad, 2)
      dr("ImporteNuevoSinIVA") = Math.Round(montoParaImporte * cantidad / 1.21, 2)

   End Sub

   Private Sub llbCliente_LinkClicked(sender As Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llbCliente.LinkClicked

      Try
         MostrarMasInfo()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Function MostrarMasInfo() As DialogResult

      Dim clie As Entidades.Cliente = Nothing
      If Me.bscCodigoCliente.Selecciono Or Me.bscNombreCliente.Selecciono Then
         clie = New Eniac.Reglas.Clientes().GetUno(Long.Parse(Me.bscCodigoCliente.Tag.ToString()), incluirFoto:=True)
      End If
      Dim result As DialogResult = Ayudante.MasInfoCliente.MostrarMasInfo.Mostrar(clie)
      If result = Windows.Forms.DialogResult.OK Then
         Me.bscCodigoCliente.Text = clie.CodigoCliente.ToString()
         Dim prevPermitido As Boolean = bscCodigoCliente.Permitido
         Me.bscCodigoCliente.Enabled = True
         Me.bscCodigoCliente.PresionarBoton()
         bscCodigoCliente.Permitido = prevPermitido
         If clie.NroDocCliente = 0 Then
            result = DialogResult.Cancel
         End If
      End If
      Return result

   End Function
   Private Sub ugResumen_BeforeRowActivate(sender As Object, e As RowEventArgs) Handles ugResumen.BeforeRowActivate
      Try
         If e.Row.Index = -1 Then Exit Sub
         Me.FechaLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         If Not Me.ugDetalle.DataSource Is Nothing Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
         End If
         If Not Me.ugDetalleFacturacion.DataSource Is Nothing Then
            DirectCast(Me.ugDetalleFacturacion.DataSource, DataTable).Rows.Clear()
         End If

         'Agregaro pero no soluciono nada.
         'Me.bscCodigoClienteHistorial.Enabled = True
         'Me.bscNombreClienteHistorial.Enabled = True
         'Me.bscCodigoClienteFacturacion.Enabled = True
         'Me.bscNombreClienteFacturacion.Enabled = True
         'Me.bscCodigoClienteHistorial.Selecciono = False
         'Me.bscCodigoClienteFacturacion.Selecciono = False
         '------------------

         Me.bscCodigoClienteHistorial.Text = e.Row.Cells("CodigoCliente").Value.ToString()
         Me.bscCodigoClienteHistorial.Tag = e.Row.Cells("IdCliente").Value.ToString()
         Me.bscNombreClienteHistorial.Text = e.Row.Cells("NombreCliente").Value.ToString()

         Me.bscCodigoClienteFacturacion.Text = e.Row.Cells("CodigoCliente").Value.ToString()
         Me.bscCodigoClienteFacturacion.Tag = e.Row.Cells("IdCliente").Value.ToString()
         Me.bscNombreClienteFacturacion.Text = e.Row.Cells("NombreCliente").Value.ToString()

         Me.lblVieneDeTab.Text = "Seleccionado en: " & Me.tbpResumen.Text
         Me.lblVieneDeTabFac.Text = "Seleccionado en: " & Me.tbpResumen.Text

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugClientes_BeforeRowActivate(sender As Object, e As RowEventArgs) Handles ugClientes.BeforeRowActivate
      Try
         If e.Row.Index = -1 Then Exit Sub
         Me.FechaLiquidacion(CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         If Not Me.ugDetalle.DataSource Is Nothing Then
            DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
         End If
         If Not Me.ugDetalleFacturacion.DataSource Is Nothing Then
            DirectCast(Me.ugDetalleFacturacion.DataSource, DataTable).Rows.Clear()
         End If

         Me.bscCodigoClienteHistorial.Text = e.Row.Cells("CodigoCliente").Value.ToString()
         Me.bscCodigoClienteHistorial.Tag = e.Row.Cells("IdCliente").Value.ToString()
         Me.bscNombreClienteHistorial.Text = e.Row.Cells("NombreCliente").Value.ToString()

         Me.bscCodigoClienteFacturacion.Text = e.Row.Cells("CodigoCliente").Value.ToString()
         Me.bscCodigoClienteFacturacion.Tag = e.Row.Cells("IdCliente").Value.ToString()
         Me.bscNombreClienteFacturacion.Text = e.Row.Cells("NombreCliente").Value.ToString()

         Me.lblVieneDeTab.Text = "Seleccionado en: " & Me.tbpCarga.Text
         Me.lblVieneDeTabFac.Text = "Seleccionado en: " & Me.tbpCarga.Text

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Eventos Observaciones"
   Private Sub bscObservacionDetalle_BuscadorClick() Handles bscObservacionDetalle.BuscadorClick
      Try
         Dim oObservacion As Reglas.Observaciones = New Reglas.Observaciones
         Me._publicos.PreparaGrillaObservaciones(Me.bscObservacionDetalle)
         Me.bscObservacionDetalle.Datos = oObservacion.GetPorNombre(Me.bscObservacionDetalle.Text.Trim(), "VENTA")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub bscObservacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscObservacionDetalle.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarObservacion(e.FilaDevuelta)
            Me.btnInsertarObservacion.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub btnInsertarObservacion_Click(sender As Object, e As EventArgs) Handles btnInsertarObservacion.Click
      Try
         If Me.bscObservacionDetalle.Text <> "" Then
            If Me.ValidarInsertaObservacion() Then
               Me.InsertarObservacion()
               Me.bscObservacionDetalle.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub

   Private Sub btnEliminarObservacion_Click(sender As Object, e As EventArgs) Handles btnEliminarObservacion.Click
      Try
         If Me.dgvObservaciones.SelectedRows.Count > 0 Then
            If MessageBox.Show("Esta seguro de eliminar la Observación?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Me.EliminarLineaObservacion()
               Me.RenumerarObservacionesDetalle()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub chbObservaciones_CheckedChanged(sender As Object, e As EventArgs) Handles chbObservaciones.CheckedChanged
      Try
         If Me.chbObservaciones.Checked Then
            With ugCargos.DisplayLayout.Bands(0)
               .Columns(_observacionesColumn).Hidden = False
            End With
         Else
            With ugCargos.DisplayLayout.Bands(0)
               .Columns(_observacionesColumn).Hidden = True
            End With
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try
   End Sub

   Private Sub dgvObservaciones_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvObservaciones.CellDoubleClick

      Try

         'limpia los textbox, y demas controles
         Me.LimpiarCamposObservDetalles()

         'carga la observacion seleccionada de la grilla en los textbox 
         Me.CargarObservDetalleCompleto(Me.dgvObservaciones.Rows(e.RowIndex))

         'elimina el producto de la grilla
         Me.EliminarLineaObservacion()

         'Tengo que renumerar por la forma que asigno el numero de linea.
         Me.RenumerarObservacionesDetalle()

         Me.bscObservacionDetalle.Focus()
         'Me.bscObservacionDetalle.SelectAll()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End Try

   End Sub
#End Region

#End Region

#Region "Metodos privados"

   Private Sub CargarGrillaCargos(drCliente As DataRow)

      If chbSoloConImportes.Checked Then
         '# Cargo solo los cargos que tienen importes asignados
         Dim dt As DataTable = _dtCargosClientes.Clone()
         For Each row As DataRow In _dtCargosClientes.Select(String.Format("{0} = {1} AND Selec = True", Entidades.Cliente.Columnas.IdCliente.ToString(), drCliente(Entidades.Cliente.Columnas.IdCliente.ToString())))
            dt.ImportRow(row)
         Next

         '# Si el cliente tiene cargos con importes, muestro solo esos, caso contrario por más que tenga activado el check, lo desactivo y muestro la lista completa
         If dt.Rows.Count > 0 Then
            Me.ugCargos.DataSource = dt
            Exit Sub
         End If
      End If
      ugCargos.DataSource = New DataView(_dtCargosClientes,
                                               String.Format("{0} = {1}", Entidades.Cliente.Columnas.IdCliente.ToString(), drCliente(Entidades.Cliente.Columnas.IdCliente.ToString())),
                                                             "", DataViewRowState.CurrentRows)

   End Sub

   Private Sub LimpiarFiltros()
      chbCategoria.Checked = False
      chbCobrador.Checked = False
      chbZonaGeografica.Checked = False
      chbCantidadPcs.Checked = False
      chbCliente.Checked = False
      chbSoloConImportes.Checked = False
      tbcLiquidacion.SelectedTab = tbpCarga
      tbcCargos.SelectedTab = tbpCargos
      '# Vuelvo a activar los controles
      bscCodigoClienteHistorial.Enabled = True
      bscNombreClienteHistorial.Enabled = True
      bscCodigoClienteFacturacion.Enabled = True
      bscNombreClienteFacturacion.Enabled = True

      chkTipoCliente.Checked = False
      cmbTipoCliente.SelectedIndex = -1
   End Sub

   Private Sub Refrescar()
      ''Dim col As DataColumn

      'Traigo todos los registros de CargosClientes

      If Me.chbCategoria.Checked And Me.cmbCategorias.SelectedIndex = -1 Then
         MessageBox.Show("ATENCION: NO seleccionó una Categoría aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCategorias.Focus()
         Exit Sub
      End If

      If Me.chbZonaGeografica.Checked And Me.cmbZonaGeografica.SelectedIndex = -1 Then
         MessageBox.Show("ATENCION: NO seleccionó una Zona Geográfica aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbZonaGeografica.Focus()
         Exit Sub
      End If
      If Me.chbCliente.Checked And (Not Me.bscCodigoCliente.Selecciono Or Not Me.bscNombreCliente.Selecciono) Then
         MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.bscCodigoCliente.Focus()
         Exit Sub
      End If

      chbSoloConImportes.Checked = False

      Me.rdbMontoDesdeLista.Checked = True

      Dim idCategoria As Integer? = 0
      Dim idZonaGeografica As String = ""

      Dim idCobrador As Integer = 0

      Dim CantidadPcs As Integer = 0

      Dim idCliente As Long = 0

      Dim idTipoCliente As Integer = 0


      If Me.chbCliente.Checked Then
         idCliente = Long.Parse(bscCodigoCliente.Tag.ToString())
      End If

      If chbCategoria.Checked AndAlso cmbCategorias.SelectedValue IsNot Nothing Then
         idCategoria = CInt(cmbCategorias.SelectedValue)
      End If

      If chbZonaGeografica.Checked AndAlso cmbZonaGeografica.SelectedValue IsNot Nothing Then
         idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
      End If

      If chbCobrador.Checked Then
         idCobrador = DirectCast(cmbCobrador.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      If chbCantidadPcs.Checked Then
         CantidadPcs = Integer.Parse(txtPcs.Text.ToString())
      End If

      If chkTipoCliente.Checked Then
         idTipoCliente = Integer.Parse(cmbTipoCliente.SelectedValue.ToString())
      End If


      _dtCargosClientes = New Reglas.CargosClientes().GetCargosClientes(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()), idCategoria,
                                                                        idZonaGeografica, idCobrador,
                                                                        Me.cmbFiltrosPcs.Text, CantidadPcs, True, idCliente, idTipoCliente)

      For Each dr As DataRow In _dtCargosClientes.Select("DescuentoRecargoPorcGral <> ClienteDescuentoRecargoPorc")
         Dim precioLista As Decimal = If(IsNumeric(dr(_precioListaColumn)), Decimal.Parse(dr(_precioListaColumn).ToString()), 0)
         dr(_descuentoRecargoPorcGralColumn) = dr("ClienteDescuentoRecargoPorc")
         Dim descuentoRecargoPorcGral As Decimal = If(IsNumeric(dr(_descuentoRecargoPorcGralColumn)), Decimal.Parse(dr(_descuentoRecargoPorcGralColumn).ToString()), 0)
         Dim descuentoRecargoPorc1 As Decimal = If(IsNumeric(dr(_descuentoRecargoPorc1Column)), Decimal.Parse(dr(_descuentoRecargoPorc1Column).ToString()), 0)
         Dim nuevoMonto As Decimal

         nuevoMonto = precioLista
         nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorcGral / 100))
         nuevoMonto = nuevoMonto * (1 + (descuentoRecargoPorc1 / 100))
         dr(Entidades.Cargo.Columnas.Monto.ToString()) = nuevoMonto
      Next

      Dim dtClientes As DataTable
      'Traigo todos los Clientes y las cargo en la grilla
      Dim oClientes As Reglas.Clientes = New Reglas.Clientes()
      dtClientes = oClientes.GetAsignacionCargos(idCategoria, idZonaGeografica, idCobrador,
                                                 Me.cmbFiltrosPcs.Text, CantidadPcs, idCliente, DirectCast(cmbActivo.SelectedValue, Entidades.Publicos.SiNoTodos), idTipoCliente)
      ugClientes.DataSource = dtClientes
      Me.FormatearGrillaClientes()

      ugResumen.DataSource = New DataView(_dtCargosClientes, "Selec", "", DataViewRowState.CurrentRows)
      FormatearGrillaResumen()
      Me.AgregarSeleccion()

      ugCargos.DataSource = New DataView(_dtCargosClientes, String.Format("1 = 2"), "", DataViewRowState.CurrentRows)
      Me.chbObservaciones.Checked = Reglas.Publicos.VerObservacion()
      Me.FormatearGrillaCargos()

      Dim oObservaciones As Reglas.CargosClientesObservaciones = New Reglas.CargosClientesObservaciones()

      _cargosClientesObservaciones = oObservaciones.GetPorSucursal(actual.Sucursal.IdSucursal, Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      dgvObservaciones.DataSource = _cargosClientesObservaciones

      If Me.ugClientes.Rows.Count <> 0 Then
         Me.GetObservacionesCliente(Long.Parse(ugClientes.Rows(0).Cells("IdCliente").Value.ToString()),
                                      Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
      End If

      Me.tssRegistros.Text = Me.ugResumen.Rows.Count.ToString() & " Registros"
      'Me.FormatearGrillaObservaciones()

      If Not Me.ugDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If



   End Sub

   Private Sub CalculaTotal()
      'Dim total As Decimal = 0
      'For Each dr As DataRow In _dtCargos.Rows
      '   If CBool(dr(_selecColumn)) Then
      '      total += CDec(dr(Entidades.Cargo.Columnas.Monto.ToString())) * CDec(dr(Entidades.CargoCliente.Columnas.Cantidad.ToString()))
      '   End If
      'Next
      'txtImporte.Text = total.ToString("N2")
   End Sub

   Private Sub SetColorCelda(cell As UltraGridCell, backColor As Color, foreColor As Color)
      cell.Appearance.BackColor = backColor
      cell.Appearance.ForeColor = foreColor
      cell.ActiveAppearance.BackColor = backColor
      cell.ActiveAppearance.ForeColor = foreColor
   End Sub

   Private Sub EvaluaActivarCeldas(row As UltraGridRow)
      Dim dr As DataRow = ugCargos.FilaSeleccionada(Of DataRow)(row)
      Dim importes As Boolean = False
      Dim cantidades As Boolean = False
      Dim observacion As Boolean = False

      If dr IsNot Nothing Then
         importes = Boolean.Parse(dr(_selecColumn).ToString()) 'And Boolean.Parse(dr(Entidades.Cargo.Columnas.ModificaImporte.ToString()).ToString())
         cantidades = Boolean.Parse(dr(_selecColumn).ToString()) 'And Boolean.Parse(dr(Entidades.Cargo.Columnas.ModificaCantidad.ToString()).ToString())
         observacion = Boolean.Parse(dr(_selecColumn).ToString())
      End If

      row.Cells(Entidades.CargoCliente.Columnas.PrecioLista.ToString()).Activation = If(importes, Activation.AllowEdit, Activation.NoEdit)
      row.Cells(Entidades.CargoCliente.Columnas.DescuentoRecargoPorc1.ToString()).Activation = If(importes, Activation.AllowEdit, Activation.NoEdit)
      row.Cells(Entidades.Cargo.Columnas.Monto.ToString()).Activation = If(importes, Activation.AllowEdit, Activation.NoEdit)
      row.Cells(Entidades.CargoCliente.Columnas.Cantidad.ToString()).Activation = If(cantidades, Activation.AllowEdit, Activation.NoEdit)
      row.Cells(Entidades.CargoCliente.Columnas.Observacion.ToString()).Activation = If(observacion, Activation.AllowEdit, Activation.NoEdit)

   End Sub

#Region "Metodos Formatear Grillas"
   Private Sub FormatearGrillaResumen()

      With ugResumen.DisplayLayout.Bands(0)

         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
            column.CellActivation = Activation.NoEdit
         Next

         Dim col As Integer = 0

         .Columns("Sel").FormatearColumna("", col, 30, HAlign.Center, True, , , Activation.AllowEdit).Style = UltraWinGrid.ColumnStyle.CheckBox
         .Columns("Sel2").FormatearColumna("", col, 30, HAlign.Center, , , , Activation.AllowEdit).Style = UltraWinGrid.ColumnStyle.CheckBox

         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).FormatearColumna("Código", col, 60, HAlign.Right).MinWidth = 60

         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Hidden = True
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Hidden = True

         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FormatearColumna("Cliente", col, 200)

         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FormatearColumna("Nombre de Fantasia", col, 150)

         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).FormatearColumna("Categoría", col, 80)

         .Columns("NombreCobrador").FormatearColumna("Cobrador", col, 120)

         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).FormatearColumna("Zona Geografica", col, 80)
         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).FormatearColumna("Nombre Cargo", col, 120)

         .Columns(Entidades.CargoCliente.Columnas.PrecioLista.ToString()).FormatearColumna("Precio Lista", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("PrecioListaSinIVA").FormatearColumna("Precio Lista S/ IVA", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("PrecioListaNuevo").FormatearColumna("Nuevo Precio Lista", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2, Activation.AllowEdit)
         .Columns("PrecioListaNuevo").CellAppearance.BackColor = _ColorColumnasEditables
         .Columns("PrecioListaNuevoSinIVA").FormatearColumna("Nuevo Precio Lista S/ IVA", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2, Activation.AllowEdit)
         .Columns("PrecioListaNuevoSinIVA").CellAppearance.BackColor = _ColorColumnasEditables

         .Columns("descuentoRecargoPorcGral").FormatearColumna("% Gral", col, 50, HAlign.Right, Not _mostrarDescRec, "N2")

         .Columns(Entidades.CargoCliente.Columnas.DescuentoRecargoPorc1.ToString()).FormatearColumna("Desc/Rec", col, 70, HAlign.Right, Not _mostrarDescRec, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("DescuentoRecargoPorc1Nuevo").FormatearColumna("Nuevo Desc/Rec", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2, Activation.AllowEdit)
         .Columns("DescuentoRecargoPorc1Nuevo").CellAppearance.BackColor = _ColorColumnasEditables



         .Columns(Entidades.Cargo.Columnas.Monto.ToString()).FormatearColumna("Monto", col, 70, HAlign.Right, Not _mostrarDescRec, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("MontoSinIVA").FormatearColumna("Monto S/ IVA", col, 70, HAlign.Right, Not _mostrarDescRec, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("MontoNuevo").FormatearColumna("Nuevo Monto", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2, Activation.AllowEdit)
         .Columns("MontoNuevo").CellAppearance.BackColor = _ColorColumnasEditables
         .Columns("MontoNuevoSinIVA").FormatearColumna("Nuevo Monto S/ IVA", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2, Activation.AllowEdit)
         .Columns("MontoNuevoSinIVA").CellAppearance.BackColor = _ColorColumnasEditables

         .Columns(Entidades.CargoCliente.Columnas.Cantidad.ToString()).FormatearColumna("Cantidad", col, 60, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns(_importeColumn).FormatearColumna("Importe", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("ImporteSinIVA").FormatearColumna("Importe S/ IVA", col, 70, HAlign.Right, Not _mostrarDescRec, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("ImporteNuevo").FormatearColumna("Nuevo Importe", col, 70, HAlign.Right, True, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("ImporteNuevo").CellAppearance.BackColor = Color.DarkSeaGreen
         .Columns("ImporteNuevoSinIVA").FormatearColumna("Nuevo Importe S/ IVA", col, 70, HAlign.Right, False, "N2", Formatos.MaskInput.Decimales9_2)
         .Columns("ImporteNuevoSinIVA").CellAppearance.BackColor = Color.DarkSeaGreen

         .Columns("FechaUltimoCambioPrecio").FormatearColumna("Ult. Modif. Precio", col, 80, HAlign.Center, , "dd/MM/yyyy")
         .Columns("Meses").FormatearColumna("Meses", col, 50, HAlign.Right)

         .Columns(Entidades.CargoCliente.Columnas.Observacion.ToString()).FormatearColumna("Observaciones", col, 250)

         If Reglas.Publicos.ExtrasSinergia Then
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Hidden = False
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Header.Caption = "PCs"
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Width = 50
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Header.VisiblePosition = 9
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).CellAppearance.TextHAlign = HAlign.Right
         End If

      End With


      ugResumen.DisplayLayout.Override.WrapHeaderText = DefaultableBoolean.True
      ugResumen.DisplayLayout.AutoFitStyle = AutoFitStyle.None
      Me.ugResumen.AgregarFiltroEnLinea({"NombreCliente", "NombreDeFantasia", "Observacion"})
      Me.ugResumen.AgregarTotalesSuma({_importeColumn})

      Me.ugResumen.AgregarTotalesSuma({"Monto"})
      Me.ugResumen.AgregarTotalesSuma({"MontoNuevo"})

      Me.ugResumen.AgregarTotalesSuma({"ImporteSinIVA"})
      Me.ugResumen.AgregarTotalesSuma({"ImporteNuevo"})
      Me.ugResumen.AgregarTotalesSuma({"ImporteNuevoSinIVA"})

      Me.ugResumen.DisplayLayout.UseFixedHeaders = True

      Me.ugResumen.DisplayLayout.Override.FixedCellSeparatorColor = Color.Red
      Me.ugResumen.DisplayLayout.Bands(0).Override.FixedHeaderIndicator = FixedHeaderIndicator.None
      Me.ugResumen.DisplayLayout.Bands(0).Columns("Sel2").Header.Fixed = True
      Me.ugResumen.DisplayLayout.Bands(0).Columns("CodigoCliente").Header.Fixed = True
      Me.ugResumen.DisplayLayout.Bands(0).Columns("NombreCliente").Header.Fixed = True

   End Sub

   Private Sub FormatearGrillaClientes()

      With ugClientes.DisplayLayout.Bands(0)

         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
            column.CellActivation = Activation.NoEdit
         Next

         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Header.Caption = "Código"
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Width = 50
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Header.VisiblePosition = 1
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Hidden = True
         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Header.Caption = "Tp.Doc"
         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Header.VisiblePosition = 2
         .Columns(Entidades.Cliente.Columnas.TipoDocCliente.ToString()).Width = 60

         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Hidden = True
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Header.Caption = "Nro.Doc"
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Header.VisiblePosition = 3
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Width = 100
         .Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.Caption = "Cliente"
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Width = 250
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.VisiblePosition = 4
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         .Columns(Entidades.Cliente.Columnas.Activo.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.Activo.ToString()).Header.Caption = "Activo"
         .Columns(Entidades.Cliente.Columnas.Activo.ToString()).Width = 50
         .Columns(Entidades.Cliente.Columnas.Activo.ToString()).Header.VisiblePosition = 5
         .Columns(Entidades.Cliente.Columnas.Activo.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Header.Caption = "Nombre de Fantasia"
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Width = 250
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).Header.VisiblePosition = 6
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains

         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Header.Caption = "Categoría"
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Width = 150
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Header.VisiblePosition = 7

         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Header.Caption = "Zona Geografica"
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Width = 150
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Header.VisiblePosition = 8

         '.Columns(Entidades.Cobrador.Columnas.NombreCobrador.ToString()).Hidden = False
         '.Columns(Entidades.Cobrador.Columnas.NombreCobrador.ToString()).Header.Caption = "Cobrador"
         '.Columns(Entidades.Cobrador.Columnas.NombreCobrador.ToString()).Width = 150
         '.Columns(Entidades.Cobrador.Columnas.NombreCobrador.ToString()).Header.VisiblePosition = 8

         If Reglas.Publicos.ExtrasSinergia Then
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Hidden = False
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Header.Caption = "PCs"
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Width = 50
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Header.VisiblePosition = 9
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).CellAppearance.TextHAlign = HAlign.Right
         End If

      End With

      ugClientes.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      ugClientes.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
      ugClientes.DisplayLayout.Override.FilterUIType = FilterUIType.FilterRow
      ugClientes.DisplayLayout.Override.FilterOperatorLocation = FilterOperatorLocation.AboveOperand
      ugClientes.DisplayLayout.Override.FilterOperatorDefaultValue = FilterOperatorDefaultValue.Equals
      ugClientes.DisplayLayout.Override.FilterRowAppearance.BackColor = Color.AntiqueWhite

   End Sub

   Private Sub FormatearGrillaCargos()
      With ugCargos.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
            column.CellActivation = Activation.NoEdit
         Next
         Dim col As Integer = 0

         .Columns(_selecColumn).FormatearColumna("Sel.", col, 60, HAlign.Center, False, , , Activation.AllowEdit).MaxWidth = 60
         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString()).FormatearColumna("Nombre cargo", col, 200, , False, , , Activation.NoEdit)
         .Columns(_cantidadColumn).FormatearColumna("Cant.", col, 80, HAlign.Right, False, "N2", , Activation.AllowEdit)

         .Columns(_precioListaColumn).FormatearColumna("Lista", col, 80, HAlign.Right, False, "N2", , Activation.AllowEdit)
         .Columns(_precioListaColumn).CellAppearance.BackColor = _ColorColumnasEditables

         .Columns(_descuentoRecargoPorcGralColumn).FormatearColumna("% Gral", col, 80, HAlign.Right, Not _mostrarDescRec, "N2", , Activation.NoEdit)
         .Columns(_descuentoRecargoPorc1Column).FormatearColumna("%", col, 80, HAlign.Right, Not _mostrarDescRec, "N2", , Activation.AllowEdit)
         .Columns(_descuentoRecargoPorc1Column).CellAppearance.BackColor = _ColorColumnasEditables

         .Columns(_montoColumn).FormatearColumna("Precio", col, 80, HAlign.Right, Not _mostrarDescRec, "N2", , Activation.AllowEdit)
         .Columns(_montoColumn).CellAppearance.BackColor = _ColorColumnasEditables

         .Columns("ImporteNuevo").FormatearColumna("Monto", col, 80, HAlign.Right, False, "N2", , Activation.AllowEdit)

         If Me.chbObservaciones.Checked Then
            .Columns(_observacionesColumn).Hidden = False
         Else
            .Columns(_observacionesColumn).Hidden = True
         End If
         .Columns(_observacionesColumn).CellActivation = Activation.AllowEdit
      End With

      ugCargos.AgregarTotalesSuma({"PrecioListaNuevo", "MontoNuevo", "ImporteNuevo"})

   End Sub

   Private Sub FormatearGrillaObservaciones()
      With dgvObservaciones
         .Columns("Usuario").Visible = False
         .Columns("Password").Visible = False
         .Columns("IdSucursal").Visible = False
         .Columns("IdCliente").Visible = False
         .Columns("Linea").Visible = False
         .Columns("IdTipoLiquidacion").Visible = False
         .Columns("Observacion").HeaderText = "Observación"
         .Columns("Observacion").Visible = True
         .Columns("Observacion").Width = 200
         .Columns("Observacion").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub
#End Region

#Region "Métodos Observaciones"
   Private Sub InsertarObservacion()

      Dim oLineaDetalle As Entidades.CargoClienteObservacion = New Entidades.CargoClienteObservacion()

      With oLineaDetalle
         .IdSucursal = actual.Sucursal.Id
         .IdCliente = Long.Parse(txtCodigoCliente.Tag.ToString)
         .Linea = Me.dgvObservaciones.RowCount + 1
         .Observacion = Me.bscObservacionDetalle.Text
         .IdTipoLiquidacion = Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString())
      End With

      Me._cargosClientesObservaciones.Add(oLineaDetalle)

      GetObservacionesCliente(Long.Parse(txtCodigoCliente.Tag.ToString()), Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
      Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1

      Me.LimpiarCamposObservDetalles()

      'Me.bscObservacionDetalle.Focus()

   End Sub

   Private Sub EliminarLineaObservacion()
      Dim lineaaeliminar As Entidades.CargoClienteObservacion = _cargosClientesObservaciones.Find(Function(occo) occo.IdCliente = Long.Parse(Me.dgvObservaciones.SelectedRows(0).Cells("IdCliente").Value.ToString()) AndAlso
                                                                                                                 occo.IdSucursal = Integer.Parse(Me.dgvObservaciones.SelectedRows(0).Cells("IdSucursal").Value.ToString()) AndAlso
                                                                                                                 occo.Linea = Integer.Parse(Me.dgvObservaciones.SelectedRows(0).Cells("Linea").Value.ToString()) AndAlso
                                                                                                                 occo.IdTipoLiquidacion = Integer.Parse(Me.dgvObservaciones.SelectedRows(0).Cells("IdTipoLiquidacion").Value.ToString()))

      _cargosClientesObservaciones.Remove(lineaaeliminar)
      GetObservacionesCliente(Long.Parse(txtCodigoCliente.Tag.ToString()), Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
   End Sub

   Private Sub LimpiarCamposObservDetalles()
      Me.bscObservacionDetalle.Text = ""
   End Sub

   Private Sub CargarObservacion(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("DetalleObservacion").Value.ToString.Trim()
   End Sub

   Private Sub CargarObservDetalleCompleto(dr As DataGridViewRow)
      Me.bscObservacionDetalle.Text = dr.Cells("Observacion").Value.ToString()
   End Sub

   Private Sub RenumerarObservacionesDetalle()

      Dim Linea As Integer = 0

      For Each vObs As Entidades.CargoClienteObservacion In Me._cargosClientesObservaciones.Where(Function(x) x.IdSucursal = actual.Sucursal.IdSucursal _
                                                                                                     And x.IdCliente = Long.Parse(txtCodigoCliente.Tag.ToString()) _
                                                                                                     And x.IdTipoLiquidacion = Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         Linea += 1
         vObs.Linea = Linea
      Next

      Me.GetObservacionesCliente(Long.Parse(txtCodigoCliente.Tag.ToString()), Integer.Parse(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
      If Linea > 0 Then
         Me.dgvObservaciones.FirstDisplayedScrollingRowIndex = Me.dgvObservaciones.Rows.Count - 1
      End If
      Me.dgvObservaciones.Refresh()

   End Sub

   Private Sub GetObservacionesCliente(IdCliente As Long, IdTipoLiquidacion As Integer)
      dgvObservaciones.DataSource = Nothing
      If _cargosClientesObservaciones.Count > 0 Then
         dgvObservaciones.DataSource = _cargosClientesObservaciones.Where(Function(obs) obs.IdSucursal = actual.Sucursal.IdSucursal And
                                                                                          obs.IdCliente = IdCliente And obs.IdTipoLiquidacion = IdTipoLiquidacion).ToArray()
         Me.FormatearGrillaObservaciones()

      End If
      dgvObservaciones.Refresh()

   End Sub
   'TODO agregar funcionalidad cuando haga falta
   Private Function ValidarInsertaObservacion() As Boolean

      'If Me.dgvObservaciones.RowCount = Me._cantMaxItemsObserv Then
      '   MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItemsObserv.ToString() & " lineas de Observaciones para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   Me.btnInsertarObservacion.Focus()
      '   Return False
      'End If

      ''Sumo Lineas del Comprobante + Lineas de Observaciones.

      'Dim LineasDetalle As Integer = 0

      ''Integer.Parse(IIf(DirectCast(Me.cmbTiposComprobantes.SelectedItem, Entidades.TipoComprobante).EsRemitoTransportista, Me.dgvRemitoTransp.RowCount, Me.dgvProductos.RowCount).ToString())

      'If LineasDetalle + Me.dgvObservaciones.RowCount = Me._cantMaxItems Then
      '   MessageBox.Show("No puede ingresar mas de " & Me._cantMaxItems.ToString() & " lineas (Productos y Observaciones) para este tipo de comprobante.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      '   Me.btnInsertarObservacion.Focus()
      '   Return False
      'End If

      Return True

   End Function
#End Region

   Protected Overridable Sub LeerPreferencias()
      Try
         Dim nameGrid As String = Me.ugResumen.FindForm().Name & "Grid.xml"

         If System.IO.File.Exists(nameGrid) Then
            Me.ugResumen.DisplayLayout.LoadFromXml(nameGrid)
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub AgregarSeleccion()

      Me.ugResumen.DisplayLayout.Bands(0).Columns("Sel2").Width = 30

      Dim blnSeleccionar As Boolean
      If Reglas.Publicos.ActualizarPreciosMostrarTodos Then
         blnSeleccionar = True
         Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos
      Else
         blnSeleccionar = False
         Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos
      End If

      For Each dr As UltraGridRow In Me.ugResumen.Rows
         dr.Cells("sel2").Value = blnSeleccionar
      Next

   End Sub

   Private Sub CargarDatosClienteHistorial(dr As DataGridViewRow)
      Me.bscCodigoClienteHistorial.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoClienteHistorial.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscNombreClienteHistorial.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoClienteHistorial.Enabled = False
      Me.bscNombreClienteHistorial.Enabled = False
      'Me.bscCodigoFiltro.Text = dr.Cells("CodigoCliente").Value.ToString()
      'Me.bscCodigoFiltro.Tag = dr.Cells("IdCliente").Value.ToString()
      'Me.bscClienteFiltro.Text = dr.Cells("NombreCliente").Value.ToString()
   End Sub

   Private Sub BarraFinaliza()
      Me.tssInfo.Text = String.Empty
      Me.tspBarra.Value = Me.tspBarra.Maximum
      Me.tspBarra.Visible = False
      Me.tspBarra.Value = 0
   End Sub

   Private Sub BarraInicializa(texto As String, valorInicial As Integer, maximoValor As Integer)
      Me.tspBarra.Visible = True
      Me.tspBarra.Maximum = maximoValor
      Me.tspBarra.Value = valorInicial
      Me.tssInfo.Text = texto
   End Sub

   Private Sub CalcularNuevosPrecios()


      Dim preciolista As Decimal = 0
      Dim PrecioListaNuevo As Decimal = 0
      Dim Monto As Decimal = 0
      Dim Importe As Decimal = 0
      Dim MontoNuevo As Decimal = 0
      Dim ImporteNuevo As Decimal = 0
      Dim dR1Nuevo As Decimal = 0
      Dim cantidad As Decimal = 0
      Dim descuentoRecargoPorcGral As Decimal = 0

      For Each dr As UltraGridRow In Me.ugResumen.Rows

         If Boolean.Parse(dr.Cells("Sel2").Value.ToString()) Then

            preciolista = If(IsNumeric(dr.Cells("PrecioLista").Value), Decimal.Parse(dr.Cells("PrecioLista").Value.ToString()), 0)

            Dim alicuota As Decimal = If(IsNumeric(dr.Cells("Alicuota").Value), Decimal.Parse(dr.Cells("Alicuota").Value.ToString()), 0)
            Dim porcImpuestoInterno As Decimal = If(IsNumeric(dr.Cells("PorcImpuestoInterno").Value), Decimal.Parse(dr.Cells("PorcImpuestoInterno").Value.ToString()), 0)
            Dim importeImpuestoInterno As Decimal = If(IsNumeric(dr.Cells("ImporteImpuestoInterno").Value), Decimal.Parse(dr.Cells("ImporteImpuestoInterno").Value.ToString()), 0)
            Dim origenPorcImpInt As Entidades.OrigenesPorcImpInt = DirectCast([Enum].Parse(GetType(Entidades.OrigenesPorcImpInt), dr.Cells("OrigenPorcImpInt").Value.ToString()), Entidades.OrigenesPorcImpInt)


            'Obtener el nuevo precio de fabrica y setearlo a la grilla
            PrecioListaNuevo = Me.GetPrecioListaNuevo(preciolista)
            dr.Cells("PrecioListaNuevo").Value = Math.Round(PrecioListaNuevo, Me._DecimalesEnPrecio)
            dr.Cells("PrecioListaNuevoSinIVA").Value = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(PrecioListaNuevo, alicuota, porcImpuestoInterno, importeImpuestoInterno, origenPorcImpInt), Me._DecimalesEnPrecio)

            dR1Nuevo = If(IsNumeric(dr.Cells("DescuentoRecargoPorc1").Value), Decimal.Parse(dr.Cells("DescuentoRecargoPorc1").Value.ToString()), 0)
            descuentoRecargoPorcGral = If(IsNumeric(dr.Cells("descuentoRecargoPorcGral").Value), Decimal.Parse(dr.Cells("descuentoRecargoPorcGral").Value.ToString()), 0)

            Monto = Decimal.Parse(dr.Cells("Monto").Value.ToString())

            dr.Cells("DescuentoRecargoPorc1Nuevo").Value = Math.Round(dR1Nuevo, 6)

            MontoNuevo = Me.GetMontoNuevo(PrecioListaNuevo, Monto, dR1Nuevo, descuentoRecargoPorcGral)
            'Obtener el nuevo precio de costo y setearlo a la grilla

            dr.Cells("MontoNuevo").Value = Decimal.Round(MontoNuevo, Me._DecimalesEnPrecio)
            dr.Cells("MontoNuevoSinIVA").Value = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(MontoNuevo, alicuota, porcImpuestoInterno, importeImpuestoInterno, origenPorcImpInt), Me._DecimalesEnPrecio)

            ImporteNuevo = MontoNuevo * Decimal.Parse(dr.Cells("Cantidad").Value.ToString())

            dr.Cells("ImporteNuevo").Value = Math.Round(ImporteNuevo, 2)
            dr.Cells("ImporteNuevoSinIVA").Value = Math.Round(Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(ImporteNuevo, alicuota, porcImpuestoInterno, importeImpuestoInterno, origenPorcImpInt), Me._DecimalesEnPrecio)

         End If
         Me.tspBarra.Value += 1
      Next


      With Me.ugResumen.DisplayLayout.Bands(0)
         '.Columns("PrecioListaNuevo").CellActivation = Activation.AllowEdit
         '.Columns("MontoNuevo").CellActivation = Activation.AllowEdit
         '.Columns("PrecioListaNuevoSinIVA").CellActivation = Activation.AllowEdit
         '.Columns("MontoNuevoSinIVA").CellActivation = Activation.AllowEdit

         '.Columns("DescuentoRecargoPorc1Nuevo").CellActivation = Activation.AllowEdit


         '.Columns("PrecioListaNuevo").Hidden = False
         '.Columns("MontoNuevo").Hidden = False
         '.Columns("ImporteNuevo").Hidden = False
         '.Columns("PrecioListaNuevoSinIVA").Hidden = False
         '.Columns("MontoNuevoSinIVA").Hidden = False
         '.Columns("ImporteNuevoSinIVA").Hidden = False
         '.Columns("DescuentoRecargoPorc1Nuevo").Hidden = False

      End With
   End Sub

   Private Function GetPrecioListaNuevo(precioLista As Decimal) As Decimal
      Dim porcPrecioLista As Decimal = If(IsNumeric(txtAjustePrecioLista.Text), Decimal.Round(Decimal.Parse(Me.txtAjustePrecioLista.Text) / 100, 4), 0)
      Return precioLista * (1 + porcPrecioLista)
   End Function

   Private Function GetMontoNuevo(precioListaNuevo As Decimal, Monto As Decimal, dR1 As Decimal, DRGral As Decimal) As Decimal

      If Me.rdbMontoSinCambiar.Checked Then
         Return Monto
         Exit Function
      End If

      Dim porcMonto1 As Decimal = Decimal.Round(Decimal.Parse(Me.txtAjusteMonto.Text) / 100, 4)
      Dim MontoNuevo As Decimal = 0

      If rdbMontoDesdeLista.Checked Then
         MontoNuevo = precioListaNuevo
         MontoNuevo = MontoNuevo * (1 + (DRGral / 100))
         MontoNuevo = MontoNuevo * (1 + (dR1 / 100))
      Else
         MontoNuevo = Monto
      End If

      If porcMonto1 <> 0 Then
         MontoNuevo = MontoNuevo + Decimal.Round(MontoNuevo * porcMonto1, 4)
      End If

      Return MontoNuevo

   End Function

   Private Sub FechaLiquidacion(IdTipoLiquidacion As Integer)

      Dim oliq As Reglas.Liquidaciones = New Reglas.Liquidaciones()
      Dim UltimaLiquidacion As Integer

      UltimaLiquidacion = oliq.GetUltimoPeriodoLiquidacion(IdTipoLiquidacion)

      Dim Fecha As Date
      If UltimaLiquidacion > 1 Then
         Fecha = Date.Parse(UltimaLiquidacion.ToString.Substring(0, 4) & "-" & UltimaLiquidacion.ToString.Substring(4, 2) & "-01")
      Else
         Fecha = Date.Now.AddMonths(-1)
      End If

      Me.dtpDesde.Value = Fecha.AddMonths(-12)
      Me.dtpHasta.Value = Fecha
      Me.DtpDesdeFact.Value = Fecha.AddMonths(-12)
      Me.DtpHastaFact.Value = Fecha.UltimoDiaMes(ultimoSegundo:=True)
   End Sub

   Private Sub CargaGrillaDetalle()
      ugDetalle.DisplayLayout.ClearGroupByColumns()

      Dim periodoDesde = Integer.Parse(dtpDesde.Value.ToString("yyyyMM"))
      Dim periodoHasta = Integer.Parse(dtpHasta.Value.ToString("yyyyMM"))
      Dim codigoCliente = Long.Parse(bscCodigoClienteHistorial.Text)

      'Paso una lista de sucursales con la sucursal actual para tenerlo listo para cuando pidan filtrar por múltiples sucursales
      Dim LiquidacionesCargos = New Reglas.LiquidacionesCargos()
      ugDetalle.DataSource = LiquidacionesCargos.GetInformeDetalle({actual.Sucursal},
                                                                   periodoDesde, periodoHasta,
                                                                   codigoCliente,
                                                                   cmbTiposLiquidacion.ValorSeleccionado(Of Integer))
      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      AjustarColumnasGrilla()
   End Sub

   Private Overloads Sub AjustarColumnasGrilla()

      Dim tit = New Dictionary(Of String, String)()

      tit.Add(Entidades.LiquidacionCargo.Columnas.PeriodoLiquidacion.ToString(), "")
      tit.Add(Entidades.Cliente.Columnas.CodigoCliente.ToString(), "")
      tit.Add(Entidades.Cliente.Columnas.NombreCliente.ToString(), "")
      tit.Add(Entidades.Cliente.Columnas.NombreDeFantasia.ToString(), "")
      tit.Add(Entidades.Categoria.Columnas.NombreCategoria.ToString(), "")
      tit.Add(Entidades.ZonaGeografica.Columnas.NombreZonaGeografica.ToString(), "")
      tit.Add(Entidades.LiquidacionDetalleCliente.Columnas.Importe.ToString(), "")
      tit.Add(Entidades.LiquidacionDetalleCliente.Columnas.NombreCargo.ToString(), "")
      tit.Add("ImporteSinIVA", "")
      tit.Add(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString(), "")
      tit.Add(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString(), "")
      tit.Add(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString(), "")
      tit.Add("PrecioListaSinIVA", "")

      For Each col As Infragistics.Win.UltraWinGrid.UltraGridColumn In Me.ugDetalle.DisplayLayout.Bands(0).Columns
         If Not tit.ContainsKey(col.Key) Then
            col.Hidden = True
         End If
      Next

      ugDetalle.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(), Entidades.Cliente.Columnas.NombreDeFantasia.ToString()})
      ugDetalle.AgregarTotalesSuma({Entidades.LiquidacionDetalleCliente.Columnas.Importe.ToString()})
      ugDetalle.AgregarTotalesSuma({"ImporteSinIVA"})

   End Sub

#End Region

   Private Sub ugResumen_KeyDown(sender As Object, e As KeyEventArgs) Handles ugResumen.KeyDown
      'Try
      '   ''If the pressed key is not valid for movement, we cancel the execution on the method.
      '   If e.KeyCode = System.Windows.Forms.Keys.Enter Then

      '      Me.ugResumen.PerformAction(UltraGridAction.NextCellByTab, False, False)

      '      e.Handled = True
      '   End If

      'Catch ex As Exception
      '   BaseForm.ShowMessage(ex.Message, FindForm.Text)
      'End Try
   End Sub
   Private Sub BtnConsultar3_Click(sender As Object, e As EventArgs) Handles BtnConsultar3.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalleFacturacion()

         With Me.ugDetalleFacturacion.DisplayLayout.Bands(0)
            .Columns("Cantidad").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
         End With

         If ugDetalleFacturacion.Rows.Count > 0 Then
            Me.BtnConsultar3.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub
   Private Sub CargaGrillaDetalleFacturacion()
      Dim IdCliente As Long = 0
      IdCliente = Long.Parse(Me.bscCodigoClienteFacturacion.Tag.ToString())

      Dim dtDetalle As DataTable, dt As DataTable
      dtDetalle = GetRegla().GetDetallePorProductos({actual.Sucursal}, Me.DtpDesdeFact.Value, Me.DtpHastaFact.Value, IdCliente)
      dt = Me.CrearDT()
      CopiaDT(dtDetalle, dt)
      Me.ugDetalleFacturacion.DataSource = dt

      ugDetalleFacturacion.AgregarTotalesSuma({"ImporteTotalNeto", "ImporteImpuesto", "ImporteImpuestoInterno", "ImporteTotal", "Tamano"})

      ugDetalleFacturacion.DisplayLayout.Bands(0).Columns("ImporteImpuestoInterno").Hidden = dt.Select("ImporteImpuestoInterno <> 0").Length = 0

      ugDetalleFacturacion.DisplayLayout.Bands(0).Columns(Entidades.VentaProducto.Columnas.IdCentroCosto.ToString()).Hidden = Not _utilizaCentroCostos
      ugDetalleFacturacion.DisplayLayout.Bands(0).Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = Not _utilizaCentroCostos

      'Me.tssRegistros.Text = Me.ugDetalleFacturacion.Rows.Count.ToString() & " Registros"
   End Sub
   Protected Overridable Function GetRegla() As Eniac.Reglas.VentasProductos
      Return New Eniac.Reglas.VentasProductos()
   End Function
   Protected Overridable Function CrearDT() As DataTable
      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("Imprimir")
         .Columns.Add("VerEstandar")
         .Columns.Add("Fecha", System.Type.GetType("System.DateTime"))
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("IdTipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("TipoComprobante", System.Type.GetType("System.String"))
         .Columns.Add("Letra", System.Type.GetType("System.String"))
         .Columns.Add("CentroEmisor", System.Type.GetType("System.Int32"))
         .Columns.Add("NumeroComprobante", System.Type.GetType("System.Int64"))
         .Columns.Add("IdCliente", System.Type.GetType("System.Int64"))
         .Columns.Add("NombreCliente", System.Type.GetType("System.String"))
         .Columns.Add("NombreZonaGeografica", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoriaFiscal", System.Type.GetType("System.String"))
         .Columns.Add("FormaDePago", System.Type.GetType("System.String"))
         .Columns.Add("NombreVendedor", System.Type.GetType("System.String"))
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("Orden", GetType(Integer))
         .Columns.Add("Tamano", System.Type.GetType("System.Decimal"))
         .Columns.Add("IdUnidadDeMedida", System.Type.GetType("System.String"))
         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("NombreSubRubro", GetType(String))
         .Columns.Add("NombreSubSubRubro", GetType(String))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
         '.AppendLine("      ,VP.Costo")
         .Columns.Add("PrecioLista", System.Type.GetType("System.Decimal"))
         .Columns.Add("Precio", System.Type.GetType("System.Decimal"))
         .Columns.Add("DescuentoRecargoPorc", System.Type.GetType("System.Decimal"))
         .Columns.Add("DescuentoRecargoPorc2", System.Type.GetType("System.Decimal"))
         .Columns.Add("DescuentoRecargoPorcGral", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrecioNeto", System.Type.GetType("System.Decimal"))
         '.AppendLine("      ,VP.Utilidad")
         .Columns.Add("AlicuotaImpuesto", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotalNeto", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteImpuesto", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteImpuestoInterno", System.Type.GetType("System.Decimal"))
         .Columns.Add("ImporteTotal", System.Type.GetType("System.Decimal"))
         .Columns.Add("Usuario", System.Type.GetType("System.String"))
         .Columns.Add("NombreLocalidad", System.Type.GetType("System.String"))
         .Columns.Add("NombreProvincia", System.Type.GetType("System.String"))
         .Columns.Add("NombreListaPrecios", System.Type.GetType("System.String"))
         .Columns.Add("NombreCategoria", System.Type.GetType("System.String"))

         .Columns.Add(Entidades.ContabilidadCentroCosto.Columnas.IdCentroCosto.ToString(), GetType(String))
         .Columns.Add(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString(), GetType(String))
         .Columns.Add(Entidades.Venta.Columnas.Observacion.ToString(), GetType(String))
         .Columns.Add("DetalleProducto", GetType(String))

         .Columns.Add(Entidades.VentaProducto.Columnas.TipoOperacion.ToString(), GetType(String))
         .Columns.Add(Entidades.VentaProducto.Columnas.Nota.ToString(), GetType(String))

         .Columns.Add("IdTransportista", GetType(Integer))
         .Columns.Add("NombreTransportista", GetType(String))

         .Columns.Add("IdFormula", GetType(Integer))
         .Columns.Add("NombreFormula", GetType(String))
         .Columns.Add("CantComponentes", GetType(Integer))
         .Columns.Add("NombreCaja", GetType(String))

      End With

      Return dtTemp
   End Function
   Protected Overridable Sub CopiaDR(dr As DataRow, drCl As DataRow)

      drCl("Ver") = "..."
      drCl("Imprimir") = "..."
      drCl("VerEstandar") = "..."
      drCl("IdSucursal") = dr("IdSucursal")
      drCl("Fecha") = Date.Parse(dr("Fecha").ToString())
      drCl("IdTipoComprobante") = dr("IdTipoComprobante").ToString()
      drCl("TipoComprobante") = dr("DescripcionAbrev").ToString()
      drCl("Letra") = dr("Letra").ToString()
      drCl("CentroEmisor") = Integer.Parse(dr("CentroEmisor").ToString())
      drCl("NumeroComprobante") = Long.Parse(dr("NumeroComprobante").ToString())
      drCl("IdCliente") = Long.Parse(dr("IdCliente").ToString())
      drCl("NombreCliente") = dr("NombreCliente").ToString()
      drCl("NombreZonaGeografica") = dr("NombreZonaGeografica").ToString()
      drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
      drCl("FormaDePago") = dr("FormaDePago").ToString()
      drCl("NombreVendedor") = dr("NombreEmpleado").ToString()
      drCl("IdProducto") = dr("IdProducto").ToString()
      drCl("NombreProducto") = dr("NombreProducto").ToString()
      drCl("Orden") = dr("Orden")
      If Not String.IsNullOrEmpty(dr("IdUnidadDeMedida").ToString()) Then
         drCl("Tamano") = Decimal.Parse(dr("Tamano").ToString())
         drCl("IdUnidadDeMedida") = dr("IdUnidadDeMedida")
      End If
      drCl("NombreMarca") = dr("NombreMarca").ToString()
      drCl("NombreRubro") = dr("NombreRubro").ToString()
      drCl("NombreSubRubro") = dr("NombreSubRubro").ToString()
      drCl("NombreSubSubRubro") = dr("NombreSubSubRubro").ToString()
      drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())
      drCl("PrecioLista") = Decimal.Parse(dr("PrecioLista").ToString())
      drCl("Precio") = Decimal.Parse(dr("Precio").ToString())
      drCl("DescuentoRecargoPorc") = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
      drCl("DescuentoRecargoPorc2") = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
      drCl("DescuentoRecargoPorcGral") = Decimal.Parse(dr("DescuentoRecargoPorcGral").ToString())
      drCl("PrecioNeto") = Decimal.Parse(dr("PrecioNeto").ToString())
      drCl("AlicuotaImpuesto") = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
      drCl("ImporteTotalNeto") = Decimal.Parse(dr("ImporteTotalNeto").ToString())
      drCl("ImporteImpuesto") = Decimal.Parse(dr("ImporteImpuesto").ToString())
      drCl("ImporteImpuestoInterno") = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())
      drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotalNeto").ToString()) + Decimal.Parse(dr("ImporteImpuesto").ToString())
      drCl("Usuario") = dr("Usuario").ToString()
      drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
      drCl("NombreProvincia") = dr("NombreProvincia").ToString()
      drCl("NombreListaPrecios") = dr("NombreListaPrecios").ToString()
      drCl("NombreCategoria") = dr("NombreCategoria").ToString()

      drCl(Entidades.VentaProducto.Columnas.IdCentroCosto.ToString()) = dr(Entidades.VentaProducto.Columnas.IdCentroCosto.ToString()).ToString()
      drCl(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()) = dr(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).ToString()

      drCl(Entidades.Venta.Columnas.Observacion.ToString()) = dr(Entidades.Venta.Columnas.Observacion.ToString()).ToString()
      drCl("DetalleProducto") = dr("DetalleProducto").ToString()

      drCl(Entidades.VentaProducto.Columnas.TipoOperacion.ToString()) = dr(Entidades.VentaProducto.Columnas.TipoOperacion.ToString())
      drCl(Entidades.VentaProducto.Columnas.Nota.ToString()) = dr(Entidades.VentaProducto.Columnas.Nota.ToString())

      drCl("IdTransportista") = dr("IdTransportista")
      drCl("NombreTransportista") = dr("NombreTransportista")

      drCl("IdFormula") = dr("IdFormula")
      drCl("NombreFormula") = dr("NombreFormula")
      drCl("CantComponentes") = dr("CantComponentes")
      drCl("NombreCaja") = dr("NombreCaja")

   End Sub
   Protected Overridable Sub CopiaDT(dtOrigen As DataTable, dtDestino As DataTable)
      Dim TotalNeto As Decimal = 0
      Dim TotalImpuestos As Decimal = 0
      Dim Total As Decimal = 0

      Dim drCl As DataRow
      For Each dr As DataRow In dtOrigen.Rows
         drCl = dtDestino.NewRow()

         CopiaDR(dr, drCl)

         dtDestino.Rows.Add(drCl)

         TotalNeto = TotalNeto + Decimal.Parse(drCl("ImporteTotalNeto").ToString())
         TotalImpuestos = TotalImpuestos + Decimal.Parse(drCl("ImporteImpuesto").ToString())
         Total = Total + Decimal.Parse(drCl("ImporteTotal").ToString())
      Next

      'txtSubtotal.Text = TotalNeto.ToString("N2")
      'txtImpuestos.Text = TotalImpuestos.ToString("N2")
      'txtTotal.Text = Total.ToString("N2")

   End Sub

   Private Sub bscClienteFacturacion_BuscadorClick() Handles bscNombreClienteFacturacion.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscNombreClienteFacturacion)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscNombreClienteFacturacion.Datos = oClientes.GetFiltradoPorNombre(Me.bscNombreClienteFacturacion.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscClienteFacturacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreClienteFacturacion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteFacturacion(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub CargarDatosClienteFacturacion(dr As DataGridViewRow)
      Me.bscNombreClienteFacturacion.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoClienteFacturacion.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoClienteFacturacion.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscNombreClienteFacturacion.Enabled = False
      Me.bscCodigoClienteFacturacion.Enabled = False
   End Sub
   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      Me.bscNombreCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      Me.bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      Me.bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      Me.bscCodigoCliente.Selecciono = True
      Me.bscNombreCliente.Selecciono = True
   End Sub
   Private Sub bscCodigoClienteFacturacion_BuscadorClick() Handles bscCodigoClienteFacturacion.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoClienteFacturacion)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoClienteFacturacion.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoClienteFacturacion.Text.Trim())
         End If
         Me.bscCodigoClienteFacturacion.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub bscCodigoClienteFacturacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoClienteFacturacion.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosClienteFacturacion(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub ugDetalleFacturacion_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalleFacturacion.ClickCellButton
      If e.Cell.Row.Index <> -1 Then

         Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim dr As DataRow = ugDetalleFacturacion.FilaSeleccionada(Of DataRow)(e.Cell.Row)

            If dr IsNot Nothing Then
               If (e.Cell.Column.Key = "Ver" Or e.Cell.Column.Key = "VerEstandar" Or e.Cell.Column.Key = "Imprimir") Then

                  'Integer.Parse(dr("IdSucursal").ToString())
                  Dim venta As Entidades.Venta = oVentas.GetUna(Integer.Parse(dr("IdSucursal").ToString()),
                                                                dr("IdTipoComprobante").ToString(),
                                                                dr("Letra").ToString(),
                                                                Short.Parse(dr("CentroEmisor").ToString()),
                                                                Long.Parse(dr("NumeroComprobante").ToString()))

                  Dim oImpr As Impresion = New Impresion(venta)

                  If e.Cell.Column.Key <> "Imprimir" Then
                     If venta.Impresora.TipoImpresora = "NORMAL" Then
                        Dim ReporteEstandar As Boolean = e.Cell.Column.Key = "VerEstandar"
                        oImpr.ImprimirComprobanteNoFiscal(True, ReporteEstandar)

                        'If venta.Percepciones IsNot Nothing Then
                        '   For Each perc As Entidades.PercepcionVenta In venta.Percepciones
                        '      If perc.ImporteTotal <> 0 Then
                        '         Dim ret As PercepcionImprimir = New PercepcionImprimir()
                        '         ret.ImprimirPercepcion(venta, perc)
                        '      End If
                        '   Next
                        'End If

                     Else
                        oImpr.ReImprimirComprobanteFiscal()
                     End If

                  Else
                     If venta.Impresora.TipoImpresora = "NORMAL" Then

                        oImpr.ImprimirComprobanteNoFiscal(False)

                     ElseIf Not venta.TipoComprobante.GrabaLibro Then

                        Dim fc As FacturacionComunes = New FacturacionComunes()
                        fc.ImprimirComprobante(venta, venta.TipoComprobante.EsFiscal)

                     Else
                        ShowMessage("No es posible Reimprimir en la Impresora Fiscal un Comprobante FISCAL.")
                     End If

                  End If
               End If         'If (e.Cell.Column.Key = "Ver" Or e.Cell.Column.Key = "VerEstandar" Or e.Cell.Column.Key = "Imprimir") Then
               If e.Cell.Column.Key = "CantComponentes" Then
                  Using frm As New ConsultarProductosFormulas()
                     Dim rVPF As Reglas.VentasProductosFormulas = New Reglas.VentasProductosFormulas()
                     Dim dt As DataTable = rVPF.GetAll(Integer.Parse(dr(Entidades.VentaProducto.Columnas.IdSucursal.ToString()).ToString()),
                                                       dr(Entidades.VentaProducto.Columnas.IdTipoComprobante.ToString()).ToString(),
                                                       dr(Entidades.VentaProducto.Columnas.Letra.ToString()).ToString(),
                                                       Integer.Parse(dr(Entidades.VentaProducto.Columnas.CentroEmisor.ToString()).ToString()),
                                                       Long.Parse(dr(Entidades.VentaProducto.Columnas.NumeroComprobante.ToString()).ToString()),
                                                       dr(Entidades.VentaProducto.Columnas.IdProducto.ToString()).ToString(),
                                                       Integer.Parse(dr(Entidades.VentaProducto.Columnas.Orden.ToString()).ToString()))
                     If dt.Rows.Count > 0 Then
                        frm.ShowDialog(dt)
                     End If
                  End Using
               End If         'If e.Cell.Column.Key = "CantComponentes" Then
            End If            'If dr IsNot Nothing Then
         Catch ex As Exception
            ShowError(ex)
         Finally
            Me.Cursor = Cursors.Default
         End Try
      End If
   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCliente_BuscadorClick() Handles bscNombreCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscNombreCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscNombreCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscNombreCliente.Text.Trim(), False)
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscNombreCliente.Enabled = Me.chbCliente.Checked
      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscNombreCliente.Text = String.Empty
      Me.bscCodigoCliente.Focus()
   End Sub

   Private Sub tbcLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcLiquidacion.SelectedIndexChanged


      If tbcLiquidacion.SelectedTab.Equals(tbpHistorial) Then
         If Not bscCodigoClienteHistorial.Selecciono And Not String.IsNullOrWhiteSpace(bscCodigoClienteHistorial.Text) Then
            bscCodigoClienteHistorial.PresionarBoton()
            btnConsultar2.PerformClick()
            Me.bscCodigoClienteHistorial.Enabled = False
            Me.bscNombreClienteHistorial.Enabled = False
         End If
      ElseIf tbcLiquidacion.SelectedTab.Equals(tbpFacturacion) Then
         If Not bscCodigoClienteFacturacion.Selecciono And Not String.IsNullOrWhiteSpace(bscCodigoClienteFacturacion.Text) Then
            bscCodigoClienteFacturacion.PresionarBoton()
            BtnConsultar3.PerformClick()
            Me.bscCodigoClienteFacturacion.Enabled = False
            Me.bscNombreClienteFacturacion.Enabled = False
         End If
      ElseIf tbcLiquidacion.SelectedTab.Equals(tbpCarga) Then
         If ugClientes.ActiveRow IsNot Nothing Then
            Me.bscCodigoClienteHistorial.Text = ugClientes.ActiveRow.Cells.Item("CodigoCliente").Value.ToString()
            Me.bscCodigoClienteHistorial.Tag = ugClientes.ActiveRow.Cells.Item("IdCliente").Value.ToString()
            Me.bscNombreClienteHistorial.Text = ugClientes.ActiveRow.Cells.Item("NombreCliente").Value.ToString()

            Me.bscCodigoClienteFacturacion.Text = ugClientes.ActiveRow.Cells.Item("CodigoCliente").Value.ToString()
            Me.bscCodigoClienteFacturacion.Tag = ugClientes.ActiveRow.Cells.Item("IdCliente").Value.ToString()
            Me.bscNombreClienteFacturacion.Text = ugClientes.ActiveRow.Cells.Item("NombreCliente").Value.ToString()

            Me.lblVieneDeTab.Text = "Seleccionado en: " & Me.tbpCarga.Text
            Me.lblVieneDeTabFac.Text = "Seleccionado en: " & Me.tbpCarga.Text
         End If
      ElseIf tbcLiquidacion.SelectedTab.Equals(tbpResumen) Then
         If ugResumen.ActiveRow IsNot Nothing Then
            Me.bscCodigoClienteHistorial.Text = ugResumen.ActiveRow.Cells.Item("CodigoCliente").Value.ToString()
            Me.bscCodigoClienteHistorial.Tag = ugResumen.ActiveRow.Cells.Item("IdCliente").Value.ToString()
            Me.bscNombreClienteHistorial.Text = ugResumen.ActiveRow.Cells.Item("NombreCliente").Value.ToString()

            Me.bscCodigoClienteFacturacion.Text = ugResumen.ActiveRow.Cells.Item("CodigoCliente").Value.ToString()
            Me.bscCodigoClienteFacturacion.Tag = ugResumen.ActiveRow.Cells.Item("IdCliente").Value.ToString()
            Me.bscNombreClienteFacturacion.Text = ugResumen.ActiveRow.Cells.Item("NombreCliente").Value.ToString()

            Me.lblVieneDeTab.Text = "Seleccionado en: " & Me.tbpResumen.Text
            Me.lblVieneDeTabFac.Text = "Seleccionado en: " & Me.tbpResumen.Text
         End If
      Else

         '# Vuelvo a activar los controles
         Me.bscCodigoClienteHistorial.Enabled = True
         Me.bscNombreClienteHistorial.Enabled = True
         Me.bscCodigoClienteFacturacion.Enabled = True
         Me.bscNombreClienteFacturacion.Enabled = True
      End If
   End Sub

   Private Sub chbSoloConImportes_CheckedChanged(sender As Object, e As EventArgs) Handles chbSoloConImportes.CheckedChanged
      Try
         Dim drCliente As DataRow = DirectCast(ugClientes.ActiveRow.ListObject, DataRowView).Row
         Me.CargarGrillaCargos(drCliente)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugCargos_KeyDown(sender As Object, e As KeyEventArgs) Handles ugCargos.KeyDown
      Try
         ''If the pressed key is not valid for movement, we cancel the execution on the method.
         If e.KeyCode = System.Windows.Forms.Keys.Enter Then

            Me.ugCargos.PerformAction(UltraGridAction.NextCellByTab, False, False)

            e.Handled = True
         End If

      Catch ex As Exception

      End Try
   End Sub

   Private Sub chkTipoCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chkTipoCliente.CheckedChanged
      Me.cmbTipoCliente.Enabled = Me.chkTipoCliente.Checked
      If Not Me.chkTipoCliente.Checked Then
         Me.cmbTipoCliente.SelectedIndex = -1
      Else
         If Me.cmbTipoCliente.Items.Count > 0 Then
            Me.cmbTipoCliente.SelectedIndex = 0
         End If
         Me.cmbTipoCliente.Focus()
      End If
   End Sub
End Class
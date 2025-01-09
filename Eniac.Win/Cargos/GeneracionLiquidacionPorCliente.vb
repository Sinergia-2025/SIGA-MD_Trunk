#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Infragistics.Win.UltraWinDataSource
Imports Infragistics.Win.UltraWinGrid
Imports Infragistics.Win
#End Region
Public Class GeneracionLiquidacionPorCliente

#Region "Campos"

   Private _publicos As Publicos
   Private _conceptos As DataSet
   Private _inmuebsinprop As DataTable
   Private _propexpensas As DataTable
   Private _estaCargando As Boolean = True
   Private _mostrarDescRec As Boolean = Reglas.Publicos.CargosUtilizaDescuentosRecargos

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnum))

         Me._publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)
         Me.cmbTiposLiquidacion.SelectedIndex = 0

         Me.FechaLiquidacion()

         Me._publicos = New Publicos()

         Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
         Me._estaCargando = False

         Me.PreferenciasLeer(Me.ugCargos, tsbPreferencias)

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

#End Region

#Region "Eventos"
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      Try
         If Me.TabControl1.SelectedTab Is tpCargos Then
            Me.PreferenciasCargar(Me.ugCargos, ugCargos.Name, tsbPreferencias)
         ElseIf Me.TabControl1.SelectedTab Is tpDetalles Then
            Me.PreferenciasCargar(Me.ugCargosDetalle, ugCargosDetalle.Name, tsbPreferencias)
         ElseIf Me.TabControl1.SelectedTab Is tpObservaciones Then
            Me.PreferenciasCargar(Me.ugObservaciones, ugObservaciones.Name, tsbPreferencias)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub GeneracionLiquidacion_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnConsultar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultar.Click

      Try

         Me.tsbGeneracion.Enabled = True
         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         If ugCargos.Rows.Count > 0 Then
            Me.btnConsultar.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("ATENCION: NO hay registros que cumplan con la selección !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If
      Catch ex As Exception

         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAExcel.Click

      Try

         If TabControl1.SelectedTab Is Me.tpCargos Then
            If Me.ugCargos.Rows.Count = 0 Then Exit Sub
         ElseIf TabControl1.SelectedTab Is Me.tpDetalles Then
            If Me.ugCargosDetalle.Rows.Count = 0 Then Exit Sub
         ElseIf TabControl1.SelectedTab Is Me.tpObservaciones Then
            If Me.ugObservaciones.Rows.Count = 0 Then Exit Sub
         End If

         Dim grid As UltraGrid = New UltraGrid()
         Dim Nombre As String = String.Empty

         If TabControl1.SelectedTab Is Me.tpCargos Then
            grid = Me.ugCargos
         ElseIf TabControl1.SelectedTab Is Me.tpDetalles Then
            grid = Me.ugCargosDetalle
            Nombre = "_Detalle"
         ElseIf TabControl1.SelectedTab Is Me.tpObservaciones Then
            grid = Me.ugObservaciones
            Nombre = "_Observaciones"
         End If

         Me.sfdExportar.FileName = Me.Name + Nombre & ".xls"
         Me.sfdExportar.Filter = "Archivos excel|*.xls"

         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.Cursor = Cursors.WaitCursor
               Me.UltraGridExcelExporter1.Export(grid, Me.sfdExportar.FileName, Infragistics.Documents.Excel.WorkbookFormat.Excel97To2003)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsmiAPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsmiAPDF.Click

      Try

         If TabControl1.SelectedTab Is Me.tpCargos Then
            If Me.ugCargos.Rows.Count = 0 Then Exit Sub
         ElseIf TabControl1.SelectedTab Is Me.tpDetalles Then
            If Me.ugCargosDetalle.Rows.Count = 0 Then Exit Sub
         ElseIf TabControl1.SelectedTab Is Me.tpObservaciones Then
            If Me.ugObservaciones.Rows.Count = 0 Then Exit Sub
         End If

         Dim grid As UltraGrid = New UltraGrid()
         Dim Nombre As String = String.Empty

         If TabControl1.SelectedTab Is Me.tpCargos Then
            grid = Me.ugCargos
         ElseIf TabControl1.SelectedTab Is Me.tpDetalles Then
            grid = Me.ugCargosDetalle
            Nombre = "_Detalle"
         ElseIf TabControl1.SelectedTab Is Me.tpObservaciones Then
            grid = Me.ugObservaciones
            Nombre = "_Observaciones"
         End If

         Me.sfdExportar.FileName = Me.Name + Nombre & ".pdf"
         Me.sfdExportar.Filter = "Archivos pdf|*.pdf"

         If Me.sfdExportar.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If Not String.IsNullOrEmpty(Me.sfdExportar.FileName.Trim()) Then
               Me.Cursor = Cursors.WaitCursor
               Me.UltraGridDocumentExporter1.Export(grid, Me.sfdExportar.FileName, DocumentExport.GridExportFileFormat.PDF)
            End If
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImprimir.Click

      Try

         If TabControl1.SelectedTab Is Me.tpCargos Then
            If Me.ugCargos.Rows.Count = 0 Then Exit Sub
         ElseIf TabControl1.SelectedTab Is Me.tpDetalles Then
            If Me.ugCargosDetalle.Rows.Count = 0 Then Exit Sub
         ElseIf TabControl1.SelectedTab Is Me.tpObservaciones Then
            If Me.ugObservaciones.Rows.Count = 0 Then Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim Filtros As String = String.Empty

         Filtros = "Periodo: " & Me.dtpPeriodo.Value.ToString("MM/yyyy")
         Dim Titulo As String

         Titulo = Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         If TabControl1.SelectedTab Is Me.tpCargos Then
            Me.UltraGridPrintDocument1.Grid = Me.ugCargos
         ElseIf TabControl1.SelectedTab Is Me.tpDetalles Then
            Me.UltraGridPrintDocument1.Grid = Me.ugCargosDetalle
         ElseIf TabControl1.SelectedTab Is Me.tpObservaciones Then
            Me.UltraGridPrintDocument1.Grid = Me.ugObservaciones
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

   Private Sub chkExpandAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkExpandAll.CheckedChanged
      If chkExpandAll.Checked Then
         Me.ugCargosDetalle.Rows.ExpandAll(True)
      Else
         Me.ugCargosDetalle.Rows.CollapseAll(True)
      End If
   End Sub

   Private Sub ugDetalle_InitializeLayout(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs)

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

      e.Layout.Bands(0).SortedColumns.Add("Rubro", False, True)
      e.Layout.Bands(0).SortedColumns.Add("Concepto", False, True)

   End Sub

   Private Sub tsbGeneracion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGeneracion.Click
      Try
         Me.Cursor = Cursors.WaitCursor

         Me.GeneracionLiquidacion(actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         Me.Cursor = Cursors.Default
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbEliminarLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbEliminarLiquidacion.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         '-- REQ-44355.- -----------------------------------------------------------------------------------------------------------------------------------------------------
         Dim oliq As Reglas.Liquidaciones = New Reglas.Liquidaciones()
         Dim UltimaLiquidacion As Integer
         UltimaLiquidacion = oliq.GetUltimaLiquidacion(actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         'puede Eliminar los Cargos solo en caso de NO estar Facturados
         If oliq.GetUno(UltimaLiquidacion, actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString())).FechaFacturado > Date.Parse("1900-01-01") Then
            ShowMessage("No se puede Eliminar ya que existen asociados comprobantes de Ventas, primero se deben eliminar los mismos.")
         Else
            Me.EliminarLiquidacion(actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         End If
         '--------------------------------------------------------------------------------------------------------------------------------------------------------------------
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
            If marcar.HasValue Then
            dr.Cells("Select").Value = marcar.Value
         Else
            dr.Cells("Select").Value = Not CBool(dr.Cells("Select").Value)
            End If
      Next
   End Sub

   Private Sub RefrescarDatosGrilla()

      Me.rbSinLiquidar.Checked = True

      Me.FechaLiquidacion()

      Me.chkExpandAll.Checked = False
      Me.chkExpandAll.Enabled = False
      Me.tsbGeneracion.Enabled = False

      Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

      If Not Me.ugCargosDetalle.DataSource Is Nothing Then
         DirectCast(Me.ugCargosDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugCargos.DataSource Is Nothing Then
         DirectCast(Me.ugCargos.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me.ugObservaciones.DataSource Is Nothing Then
         DirectCast(Me.ugObservaciones.DataSource, DataTable).Rows.Clear()
      End If

      Me.ugCargos.DisplayLayout.Bands(0).Summaries.Clear()
      Me.ugCargosDetalle.DisplayLayout.Bands(0).Summaries.Clear()

   End Sub

   Private Sub CargaGrillaDetalle()

      Dim oliq As Reglas.Liquidaciones = New Reglas.Liquidaciones()

      Dim UltimaLiquidacion As Integer
      UltimaLiquidacion = oliq.GetUltimaLiquidacion(actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      If Me.rbSinLiquidar.Checked Then

         Dim Fecha As Date
         If UltimaLiquidacion > 1 Then
            Fecha = Date.Parse(UltimaLiquidacion.ToString.Substring(0, 4) & "-" & UltimaLiquidacion.ToString.Substring(4, 2) & "-01")
         Else
            Fecha = Date.Now.AddMonths(-1)
         End If

         Me.dtpPeriodo.Value = Fecha.AddMonths(1)

         Me.tsbEliminarLiquidacion.Enabled = False
         Me._conceptos = oliq.GetMovimientosLiquidacionPorCliente(actual.Sucursal.IdSucursal, Integer.Parse(dtpPeriodo.Value.ToString("yyyyMM")), CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))
         Me.ugCargos.DataSource = Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes)
         Me.ugCargosDetalle.DataSource = Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientesDetalle)
         Me.ugObservaciones.DataSource = Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableLiquidacionObservaciones)
         'Me.ugObservaciones.DataSource = Me._conceptos.Tables(2)

         If UltimaLiquidacion = 0 OrElse oliq.GetUno(UltimaLiquidacion, actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString())).FechaFacturado > Date.Parse("1900-01-01") Then
            Me.tsbGeneracion.Enabled = True
         Else
            Me.tsbGeneracion.Enabled = False
         End If
      Else

         If UltimaLiquidacion <= 1 Then
            Me.tsbGeneracion.Enabled = False
            Me.tsbEliminarLiquidacion.Enabled = False
            Me.ugCargos.DataSource = Nothing
            Me.ugCargosDetalle.DataSource = Nothing
            Throw New Exception("Indico Ultima Liquidacion pero Nunca se Liquido por Primera Vez.")
         End If

         'puede Eliminar los Cargos solo en caso de NO estar Facturados
         If oliq.GetUno(UltimaLiquidacion, actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString())).FechaFacturado > Date.Parse("1900-01-01") Then
            Me.tsbEliminarLiquidacion.Enabled = False
         Else
            Me.tsbEliminarLiquidacion.Enabled = True
         End If

         Dim periodo As Integer
         periodo = UltimaLiquidacion

         Me.tsbGeneracion.Enabled = False

         Me._conceptos = oliq.GetUltimaLiquidacionPorCliente(actual.Sucursal.IdSucursal, periodo, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

         Me.ugCargos.DataSource = Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes)
         Me.ugCargosDetalle.DataSource = Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientesDetalle)
         Me.ugObservaciones.DataSource = Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableLiquidacionObservaciones)


         Me.dtpPeriodo.Value = Date.Parse(UltimaLiquidacion.ToString.Substring(0, 4) & "-" & UltimaLiquidacion.ToString.Substring(4, 2) & "-01")

      End If

      Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes).Columns.Add("Select", GetType(Boolean))
      Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientesDetalle).Columns.Add("Select", GetType(Boolean))

      '# Creo la relación entre la tabla de Clientes Cargos y el Detalle de la misma
      Dim Relacion As DataRelation = New DataRelation("CargosRelacion",
                            {Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes).Columns("IdLiquidacionCargo")},
                            {Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientesDetalle).Columns("IdLiquidacionCargo")})
      _conceptos.Relations.Add(Relacion)

      FormatearGrillaCliente()
      FormatearGrillaAdicionales()
      FormatearGrillaObservaciones()

      '# Por defecto, todos marcado
      For Each row As DataRow In Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes).Rows
         row("Select") = True
      Next

      Me.cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

      Me.LeerPreferenciasMultiples()

   End Sub

   Private Sub FormatearGrillaAdicionales()
      With Me.ugCargosDetalle.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.CellActivation = Activation.ActivateOnly
            column.Hidden = True
         Next

         Dim col As Integer = 0

         .Columns(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString).FormatearColumna("#", col, 30, HAlign.Right).MinWidth = 30
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).FormatearColumna("Código", col, 60, HAlign.Right).MinWidth = 60
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).FormatearColumna("Nombre", col, 270).HiddenWhenGroupBy = DefaultableBoolean.False
         .Columns(Entidades.Categoria.Columnas.NombreCategoria.ToString).FormatearColumna("Categoría", col, 150)
         .Columns(Entidades.Cargo.Columnas.NombreCargo.ToString).FormatearColumna("Adicional", col, 180)
         .Columns(Entidades.LiquidacionDetalleCliente.Columnas.CantidadAdicional.ToString()).FormatearColumna("Cantidad", col, 125, HAlign.Right, , "N2", "{double:-9.2}")

         If _mostrarDescRec Then

            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.PrecioLista.ToString()).FormatearColumna("P.Lista", col, 115, HAlign.Right, , "N2", "{double:-9.2}")
            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorcGral.ToString()).FormatearColumna("% Gral", col, 115, HAlign.Right, , "N2", "{double:-9.2}")
            .Columns(Entidades.LiquidacionDetalleCliente.Columnas.DescuentoRecargoPorc1.ToString()).FormatearColumna("D/R %", col, 115, HAlign.Right, , "N2", "{double:-9.2}")
         End If

         .Columns(Entidades.LiquidacionDetalleCliente.Columnas.PrecioAdicional.ToString()).FormatearColumna("Precio", col, 115, HAlign.Right, , "N2", "{double:-9.2}")

         .Columns("importe").FormatearColumna("Importe", col, 115, HAlign.Right, , "N2", "{double:-9.2}")
         .Columns("importeAlquiler").Hidden = True

         .Columns(Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString()).FormatearColumna("Observaciones", col, 280)

         .SortedColumns.Clear()
         .SortedColumns.Add(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString), False)

         .Columns("Select").FormatearColumna("S", 0, 50, HAlign.Center)
         .Columns("Select").Header.Appearance.TextHAlign = HAlign.Center
      End With
      'ugCargosDetalle.AgregarTotalesSuma({"importe", "importeAlquiler"})

      ugCargosDetalle.DisplayLayout.Override.SummaryDisplayArea = CType(Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or
                                                                                Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter, Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)

      Ayudante.Grilla.AgregarTotalCustomColumna(ugCargosDetalle,
                                                      "importeAlquiler",
                                                      New Ayudante.CustomSummaries.SummaryTotalSeleccionado(DirectCast(Me.ugCargosDetalle.DataSource, DataTable), "importeAlquiler", "Select"))

      Ayudante.Grilla.AgregarTotalCustomColumna(ugCargosDetalle,
                                                      "importe",
                                                      New Ayudante.CustomSummaries.SummaryTotalSeleccionado(DirectCast(Me.ugCargosDetalle.DataSource, DataTable), "importe", "Select"))

      ugCargosDetalle.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(), Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString()})


   End Sub

   Private Sub FormatearGrillaObservaciones()
      With Me.ugObservaciones.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.CellActivation = Activation.ActivateOnly
            column.Hidden = True
         Next

         'columna de IdLiquidacionCargo
         .Columns(Entidades.Cliente.Columnas.IdCliente.ToString).Hidden = True
         .Columns(Entidades.Cliente.Columnas.IdCliente.ToString).Header.Caption = "Id Cliente"
         .Columns(Entidades.Cliente.Columnas.IdCliente.ToString).Width = 60
         .Columns(Entidades.Cliente.Columnas.IdCliente.ToString).MinWidth = 60
         .Columns(Entidades.Cliente.Columnas.IdCliente.ToString).Header.VisiblePosition = 0

         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Hidden = False
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Header.Caption = "Codigo"
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Width = 60
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).MinWidth = 60
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Header.VisiblePosition = 1

         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Header.Caption = "Nombre"
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Width = 200
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).HiddenWhenGroupBy = DefaultableBoolean.False
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Header.VisiblePosition = 2

         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Header.Caption = "Nombre de Fantasía"
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Width = 200
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).HiddenWhenGroupBy = DefaultableBoolean.False
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Header.VisiblePosition = 3

         .Columns(Entidades.CargoClienteObservacion.Columnas.Linea.ToString).Hidden = False
         .Columns(Entidades.CargoClienteObservacion.Columnas.Linea.ToString).Header.Caption = "Linea"
         .Columns(Entidades.CargoClienteObservacion.Columnas.Linea.ToString).Width = 40
         .Columns(Entidades.CargoClienteObservacion.Columnas.Linea.ToString).Header.VisiblePosition = 4

         .Columns(Entidades.CargoClienteObservacion.Columnas.Observacion.ToString).Hidden = False
         .Columns(Entidades.CargoClienteObservacion.Columnas.Observacion.ToString).Header.Caption = "Observación"
         .Columns(Entidades.CargoClienteObservacion.Columnas.Observacion.ToString).Width = 300
         .Columns(Entidades.CargoClienteObservacion.Columnas.Observacion.ToString).Header.VisiblePosition = 5


         .SortedColumns.Clear()
         '.SortedColumns.Add(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString), False)

      End With
      ugCargosDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      ugCargosDetalle.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True

      ugObservaciones.AgregarFiltroEnLinea({Entidades.Cliente.Columnas.NombreCliente.ToString(),
                                            Entidades.Cliente.Columnas.NombreDeFantasia.ToString(),
                                            Entidades.LiquidacionDetalleCliente.Columnas.Observacion.ToString()})
   End Sub

   Private Sub FormatearGrillaCliente()


      With Me.ugCargos.DisplayLayout.Bands(0)

         For Each column As UltraGridColumn In .Columns
            column.CellActivation = Activation.ActivateOnly
            column.Hidden = True
         Next

         .Columns(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString).Hidden = False
         .Columns(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString).Header.Caption = "#"
         .Columns(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString).Width = 30
         .Columns(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString).MinWidth = 30
         .Columns(Entidades.LiquidacionCargo.Columnas.IdLiquidacionCargo.ToString).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Hidden = False
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Header.Caption = "Código"
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Width = 60
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).MinWidth = 60
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).Header.VisiblePosition = 1
         .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString).CellAppearance.TextHAlign = HAlign.Right

         '-- REQ-44281.- ------------------------------------------------------------------------------
         If Reglas.Publicos.ClienteMuestraCodigoClienteLetras Then
            .Columns(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString()).Hidden = False
            .Columns(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString()).Header.Caption = "Cod. Letras"
            .Columns(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString()).Header.VisiblePosition = 2
            .Columns(Entidades.Cliente.Columnas.CodigoClienteLetras.ToString()).Width = 80
         End If
         '---------------------------------------------------------------------------------------------

         '.Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Hidden = True
         '.Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Header.Caption = "Nro.Doc"
         '.Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Header.VisiblePosition = 3
         '.Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).Width = 100
         '.Columns(Entidades.Cliente.Columnas.NroDocCliente.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Header.Caption = "Cliente"
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Width = 250
         .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString).Header.VisiblePosition = 4

         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Header.Caption = "Nombre de Fantasia"
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Width = 250
         .Columns(Entidades.Cliente.Columnas.NombreDeFantasia.ToString).Header.VisiblePosition = 5

         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Header.Caption = "Categoría"
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Width = 120
         .Columns(Entidades.Cliente.Columnas.NombreCategoria.ToString()).Header.VisiblePosition = 6

         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Hidden = False
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Header.Caption = "Zona Geografica"
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Width = 120
         .Columns(Entidades.Cliente.Columnas.NombreZonaGeografica.ToString()).Header.VisiblePosition = 7

         If Reglas.Publicos.ExtrasSinergia Then
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Hidden = False
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Header.Caption = "PCs"
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Width = 50
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).Header.VisiblePosition = 8
            .Columns(Entidades.Cliente.Columnas.CantidadDePCs.ToString()).CellAppearance.TextHAlign = HAlign.Right
         End If

         .Columns("importe").Hidden = True   'False
         .Columns("importe").Header.Caption = "Cargos"
         .Columns("importe").Width = 80
         .Columns("importe").Format = "N2"
         .Columns("importe").MaskInput = "{double:-9.2}"
         .Columns("importe").CellAppearance.TextHAlign = HAlign.Right
         .Columns("importe").Header.VisiblePosition = 9

         .Columns("importeTotal").Hidden = False
         .Columns("importeTotal").Header.Caption = "Total"
         .Columns("importeTotal").Width = 80
         .Columns("importeTotal").Format = "N2"
         .Columns("importeTotal").MaskInput = "{double:-9.2}"
         .Columns("importeTotal").CellAppearance.TextHAlign = HAlign.Right
         .Columns("importeTotal").Header.VisiblePosition = 10

         .SortedColumns.Clear()
         .SortedColumns.Add(.Columns(Entidades.Cliente.Columnas.NombreCliente.ToString), False)

         If .Summaries.Count = 0 Then

            ugCargos.DisplayLayout.Override.SummaryDisplayArea = CType(Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.BottomFixed Or
                                                                                Infragistics.Win.UltraWinGrid.SummaryDisplayAreas.GroupByRowsFooter, Infragistics.Win.UltraWinGrid.SummaryDisplayAreas)

            ugCargos.DisplayLayout.Bands(0).SummaryFooterCaption = "Totales:"

            Ayudante.Grilla.AgregarTotalCustomColumna(ugCargos,
                                                      "importe",
                                                      New Ayudante.CustomSummaries.SummaryTotalSeleccionado(DirectCast(Me.ugCargos.DataSource, DataTable), "importe", "Select"))

            Ayudante.Grilla.AgregarTotalCustomColumna(ugCargos,
                                                      Entidades.VentaCajero.Columnas.ImporteTotal.ToString(),
                                                      New Ayudante.CustomSummaries.SummaryTotalSeleccionado(DirectCast(Me.ugCargos.DataSource, DataTable), "importeTotal", "Select"))
         End If

         .Columns("Select").FormatearColumna("S", 0, 50, HAlign.Center).CellActivation = If(Me.rbSinLiquidar.Checked, Activation.AllowEdit, Activation.ActivateOnly)
         .Columns("Select").Header.Appearance.TextHAlign = HAlign.Center
      End With
      ugCargos.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      ugCargos.DisplayLayout.Override.AllowRowFiltering = DefaultableBoolean.True
      ugCargos.DisplayLayout.Bands(1).Hidden = True '# Solo dejo visible la banda padre


      '# Agrego filtro en linea
      Me.ugCargos.AgregarFiltroEnLinea({"NombreCliente", "NombreDeFantasia"})
   End Sub

   Private Sub GeneracionLiquidacion(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)

      Try
         Dim oLiquidacion As Reglas.Liquidaciones = New Reglas.Liquidaciones()
         Dim rCargosClientes As Reglas.CargosClientes = New Reglas.CargosClientes()

         '# Verifico que todos los clientes que se encuentren con Cargos Asignados, estén activos
         For Each dr As DataRow In _conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes).Select("Not Activo AND Select")
            Throw New Exception("El cliente (" & dr("CodigoCliente").ToString() & ") " & dr("NombreCliente").ToString() & " posee cargos asignados y se encuentra inactivo. No se puede continuar con la grabación.")
         Next

         '# Validar el parámetro si se permite generar o no liquidaciones sin clientes seleccionados
         If Not Reglas.Publicos.CargosPermiteGenerarLiquidacionSinClientes AndAlso _conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes).Select("Select").Count = 0 Then
            Throw New Exception("No se puede generar una Liquidacion sin Clientes seleccionados.")
         End If

         oLiquidacion.GuardarLiquidacionCliente(Me._conceptos, Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM")), IdSucursal, IdTipoLiquidacion)

         Me.RefrescarDatosGrilla()

         ShowMessage("La liquidación se generó existosamente.")

      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub EliminarLiquidacion(ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer)

      Try

         If MessageBox.Show("¿Está seguro que desea eliminar la liquidación seleccionada?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Throw New Exception("Cancelado por el usuario")
         End If

         Dim Periodo As Integer

         Periodo = Integer.Parse(Me.dtpPeriodo.Value.ToString("yyyyMM"))

         Dim oLiquidacion As Reglas.Liquidaciones = New Reglas.Liquidaciones()

         oLiquidacion.EliminarLiquidacion(CInt(Me.dtpPeriodo.Value.ToString("yyyyMM")), IdSucursal, IdTipoLiquidacion)

         MessageBox.Show("La eliminación se realizó con éxito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.RefrescarDatosGrilla()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Function ExisteEnColeccionPropietarios(ByVal colProp As List(Of Entidades.Cliente), ByVal Propietario As Entidades.Cliente) As Boolean

      For Each p As Entidades.Cliente In colProp
         If p.IdCliente = Propietario.IdCliente Then
            Return True
         End If
      Next

      Return False

   End Function

   Private Sub FechaLiquidacion()

      Dim oliq As Reglas.Liquidaciones = New Reglas.Liquidaciones()
      Dim UltimaLiquidacion As Integer

      UltimaLiquidacion = oliq.GetUltimaLiquidacion(actual.Sucursal.IdSucursal, CInt(Me.cmbTiposLiquidacion.SelectedValue.ToString()))

      Dim Fecha As Date
      If UltimaLiquidacion > 1 Then
         Fecha = Date.Parse(UltimaLiquidacion.ToString.Substring(0, 4) & "-" & UltimaLiquidacion.ToString.Substring(4, 2) & "-01")
      Else
         Fecha = Date.Now.AddMonths(-1)
      End If

      Me.dtpPeriodo.Value = Fecha.AddMonths(1)

      Me.dtpPeriodo.Enabled = Not (UltimaLiquidacion > 1)

   End Sub

#End Region

   Private Sub cmbTiposLiquidacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTiposLiquidacion.SelectedIndexChanged
      Try
         If Not Me._estaCargando Then
            Me.tsbGeneracion.Enabled = False
            Me.tsbEliminarLiquidacion.Enabled = False
            Me.FechaLiquidacion()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click

      If Me.ugCargos.Rows.Count = 0 Then Exit Sub

      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnum Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnum)
               Case Reglas.Publicos.TodosEnum.MararTodos
                  MarcarDesmarcar(True, ugCargos.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarTodos

               Case Reglas.Publicos.TodosEnum.DesmarcarTodos
                  MarcarDesmarcar(False, ugCargos.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MararTodos

               Case Reglas.Publicos.TodosEnum.MarcarFiltrados
                  MarcarDesmarcar(True, ugCargos.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.DesmarcarFiltrados

               Case Reglas.Publicos.TodosEnum.DesmarcarFiltrados
                  MarcarDesmarcar(False, ugCargos.Rows.GetFilteredInNonGroupByRows())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnum.MarcarFiltrados

               Case Reglas.Publicos.TodosEnum.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugCargos.Rows.ToArray())

               Case Reglas.Publicos.TodosEnum.InvertirMarcasFiltrados
                  MarcarDesmarcar(Nothing, ugCargos.Rows.GetFilteredInNonGroupByRows())


            End Select
            Me.ugCargos.UpdateData()
            Me.ugCargosDetalle.UpdateData()

         End If
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
         ugCargos.UpdateData()
      End Try
   End Sub

   Private Sub ugCargos_CellChange(sender As Object, e As CellEventArgs) Handles ugCargos.CellChange
      Me.ugCargos.UpdateData()
   End Sub

   Private Sub ugCargos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugCargos.InitializeRow

      If Me.ugCargos.Rows.Count = 0 Then Exit Sub

      For Each rowCliente As DataRow In Me._conceptos.Tables(Reglas.Liquidaciones.NombreDataTableCargosClientes).Rows
         For Each rowDetalle As DataRow In rowCliente.GetChildRows(Me._conceptos.Relations("CargosRelacion"))
            Me.ugCargos.UpdateData()
            rowDetalle("Select") = rowCliente("Select")
            Me.ugCargosDetalle.UpdateData()
         Next
      Next

   End Sub

   Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Me.LeerPreferenciasMultiples()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub LeerPreferenciasMultiples()

      If TabControl1.SelectedTab Is tpCargos Then
         PreferenciasLeer(grid:=ugCargos, sufijoXML:=ugCargos.Name.ToString(), tsbPreferencias:=tsbPreferencias)
      End If

      If TabControl1.SelectedTab Is tpDetalles Then
         PreferenciasLeer(grid:=ugCargosDetalle, sufijoXML:=ugCargosDetalle.Name.ToString(), tsbPreferencias:=tsbPreferencias)
      End If

      If TabControl1.SelectedTab Is tpObservaciones Then
         PreferenciasLeer(grid:=ugObservaciones, sufijoXML:=ugObservaciones.Name.ToString(), tsbPreferencias:=tsbPreferencias)
      End If

   End Sub
End Class
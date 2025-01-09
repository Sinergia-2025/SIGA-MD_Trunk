Imports Eniac.Entidades
Imports Infragistics.Win.UltraWinGrid.DocumentExport
Imports Infragistics.Win.UltraWinGrid.ExcelExport

Public Class MRPCostosProcesosProductivos
#Region "Campos"
   Private _publicos As Publicos

#End Region


#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         _publicos.CargaComboDesdeEnum(Me.cmbTodos, GetType(Reglas.Publicos.TodosEnumSI))

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         FormateaGrillas()
         tsbModificarProceso.Enabled = False

      End Sub)
   End Sub

   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnConsultar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"
#Region "Eventos Filtros"
#Region "Eventos Buscador Producto"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto, bscNombreProducto))
   End Sub

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto)
         bscCodigoProducto.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS", True)
      End Sub)
   End Sub
   Private Sub bscNombreProducto_BuscadorClick() Handles bscNombreProducto.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProducto)
         bscNombreProducto.Datos = New Reglas.Productos().GetPorNombre(bscNombreProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS", True)
      End Sub)
   End Sub

   Private Sub bscProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion, bscNombreProducto.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub cmbMarcas_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMarcas.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim marcas = cmbMarcas.GetMarcas(todosVacio:=True)
                    cmbModelos.ConcatenarNombreMarca = marcas.CountSecure() <> 1
                    cmbModelos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                           marcas:=marcas)
                 End Sub)
   End Sub
   Private Sub cmbRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim rubros = cmbRubros.GetRubros(todosVacio:=True)
                    cmbSubRubros.ConcatenarNombreRubro = rubros.CountSecure() <> 1
                    cmbSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                             rubros:=rubros)
                 End Sub)
   End Sub
   Private Sub cmbSubRubros_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubros.AfterSelectedIndexChanged
      TryCatched(Sub()
                    Dim subRubros = cmbSubRubros.GetSubRubros(todosVacio:=True)
                    cmbSubSubRubros.ConcatenarNombreSubRubro = subRubros.CountSecure() <> 1
                    cmbSubSubRubros.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True,
                                                subRubro:=subRubros)
                 End Sub)

   End Sub

#End Region
#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub()
                    If utcGrillas.SelectedTab.Index = 0 Then
                       ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1})
                    End If
                    If utcGrillas.SelectedTab.Index = 1 Then
                       ugDatos.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1})
                    End If
                    If utcGrillas.SelectedTab.Index = 2 Then
                       ugCostosCeros.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1})
                    End If
                 End Sub)
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub()
                    If utcGrillas.SelectedTab.Index = 0 Then
                       ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion())
                    End If
                    If utcGrillas.SelectedTab.Index = 1 Then
                       ugDatos.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion())
                    End If
                    If utcGrillas.SelectedTab.Index = 2 Then
                       ugCostosCeros.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion())
                    End If
                 End Sub)
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub()
                    If utcGrillas.SelectedTab.Index = 0 Then
                       ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion())
                    End If
                    If utcGrillas.SelectedTab.Index = 1 Then
                       ugDatos.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion())
                    End If
                    If utcGrillas.SelectedTab.Index = 2 Then
                       ugCostosCeros.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion())
                    End If
                 End Sub)
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region
#End Region

#Region "Metodos"
   Private Function CargarFiltrosImpresion() As String

      Dim filtro = New StringBuilder()
      With filtro
         If chbProducto.Checked Then
            .AppendFormat(" - Producto: {0} - {1}", bscCodigoProducto.Text, bscNombreProducto.Text)
         End If

         If cmbMarcas.Visible Then cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=True, muestraNombre:=False)
         If cmbModelos.Visible Then cmbModelos.CargarFiltrosImpresionModelos(filtro, muestraId:=True, muestraNombre:=False)
         If cmbRubros.Visible Then cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubRubros.Visible Then cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargarFiltrosImpresionSubSubRubros(filtro, muestraId:=True, muestraNombre:=False)

      End With

      Return filtro.ToString()
   End Function

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProducto.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProducto.Permitido = False
         bscCodigoProducto.Permitido = False
         bscNombreProducto.Selecciono = True
         bscCodigoProducto.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub RefrescarDatosGrilla()

      chbProducto.Checked = False

      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      ugDetalle.ClearFilas()
      ugDatos.ClearFilas()
      ugCostosCeros.ClearFilas()

      For ind = 1 To 2
         utcGrillas.Tabs(ind).Visible = False
      Next
      tsbModificarProceso.Enabled = False
      utcGrillas.Tabs(0).Selected = True
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProducto.Checked And Not bscCodigoProducto.Selecciono And Not bscNombreProducto.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle(onLoad:=False)

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If
      End Sub)
   End Sub

   Private Sub CargaGrillaDetalle(onLoad As Boolean)

      Dim rProcesosP = New Reglas.MRPProcesosProductivos()

      Dim dsDetalle = rProcesosP.GetProcesosProductivosCostos(If(chbProducto.Checked, bscCodigoProducto.Text, String.Empty),
                                                              cmbMarcas.GetMarcas(todosVacio:=True), cmbRubros.GetRubros(todosVacio:=True),
                                                              cmbSubRubros.GetSubRubros(todosVacio:=True), cmbSubSubRubros.GetSubSubRubros(todosVacio:=True))

      ugDetalle.DataSource = dsDetalle

      FormateaGrillas()

   End Sub

   Public Sub FormateaGrillas()
      FormateaGrillaProductos()
   End Sub

   Public Sub FormateaGrillaProductos()
      With ugDetalle.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         '-- Agrega Filtros.- ---
         Grilla.AgregarFiltroEnLinea(ugDetalle, {"IdProducto", "NombreProducto", "DescripcionProceso", "NombreMarca", "NombreRubro", "NombreSubRubro"})
         '-- Setea las Columnas.- 
         .Columns("Masivo").Hidden = False
         .Columns("Masivo").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox
         .Columns("Masivo").Header.VisiblePosition = pos
         .Columns("Masivo").Width = 50

         pos += 1

         .Columns("IdProducto").FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Nombre Producto", pos, 200)

         .Columns("NombreMoneda").FormatearColumna("Moneda", pos, 70, HAlign.Left)

         .Columns("DescripcionProceso").FormatearColumna("Descripción Proceso", pos, 200)

         .Columns("NombreMarca").FormatearColumna("Marca", pos, 150)
         .Columns("NombreRubro").FormatearColumna("Rubro", pos, 150)
         .Columns("NombreSubRubro").FormatearColumna("Sub Rubro", pos, 150)

         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoManoObraInterna.ToString()).FormatearColumna("Costo MO Interno", pos, 80, HAlign.Right,, "N2")
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoManoObraExterna.ToString()).FormatearColumna("Costo MO Externo", pos, 80, HAlign.Right,, "N2")
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoMateriaPrima.ToString()).FormatearColumna("Costo Materia Prima", pos, 80, HAlign.Right,, "N2")
         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoTotalProceso.ToString()).FormatearColumna("Costo total Proceso", pos, 80, HAlign.Right,, "N2")

         .Columns("FechaActualizaCostos").FormatearColumna("Fecha Actualizacion", pos, 100, HAlign.Center)
         .Columns("FechaAltaProceso").FormatearColumna("Fecha Alta Proc.", pos, 100, HAlign.Center)
         .Columns("FechaModificaProceso").FormatearColumna("Fecha Modif. Proc.", pos, 100, HAlign.Center)

      End With
   End Sub

   Private Sub btnTodos_Click(sender As Object, e As EventArgs) Handles btnTodos.Click
      Try
         If cmbTodos.SelectedValue IsNot Nothing AndAlso TypeOf (cmbTodos.SelectedValue) Is Reglas.Publicos.TodosEnumSI Then

            Me.Cursor = Cursors.WaitCursor

            Select Case DirectCast(cmbTodos.SelectedValue, Reglas.Publicos.TodosEnumSI)
               Case Reglas.Publicos.TodosEnumSI.MarcarTodos
                  MarcarDesmarcar(True, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.DesmarcarTodos

               Case Reglas.Publicos.TodosEnumSI.DesmarcarTodos
                  MarcarDesmarcar(False, ugDetalle.Rows.ToArray())
                  cmbTodos.SelectedValue = Reglas.Publicos.TodosEnumSI.MarcarTodos

               Case Reglas.Publicos.TodosEnumSI.InvertirMarcasTodos
                  MarcarDesmarcar(Nothing, ugDetalle.Rows.ToArray())

               Case Else

            End Select
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         ugDetalle.UpdateData()
      End Try
   End Sub
   Private Sub MarcarDesmarcar(marcar As Boolean?, rows As UltraGridRow())
      For Each dr As UltraGridRow In rows
         If marcar.HasValue Then
            dr.Cells("Masivo").Value = marcar.Value
         Else
            dr.Cells("Masivo").Value = Not CBool(dr.Cells("Masivo").Value)
         End If
      Next
   End Sub

   Private Sub cmdCalculoMasivo_Click(sender As Object, e As EventArgs) Handles cmdCalculoMasivo.Click
      TryCatched(
      Sub()
         If ugDetalle.Rows.Count = 0 Then Exit Sub
         ugDetalle.UpdateData()

         Dim eProcesos = New List(Of MRPProcesoProductivo)
         Dim eProducto = New List(Of MRPProcesoProductivoProducto)
         Dim alertaCostoCero As Boolean = False

         For Each drProcesos As DataRow In DirectCast(Me.ugDetalle.DataSource, DataTable).Select("Masivo")
            Dim eProc = New Reglas.MRPProcesosProductivos().GetUno(Integer.Parse(drProcesos("IdProcesoProductivo").ToString()), drProcesos("IdProducto").ToString())
            Dim vCostoTiempos = New Reglas.MRPProcesosProductivosOperaciones().CalculaCostosTiempos(eProc.Operaciones, True, New Reglas.Productos().GetUno(drProcesos("IdProducto").ToString(), False, True).Moneda.FactorConversion)
            With eProc
               .NewCostoManoObraInterna = vCostoTiempos.CostoManoObraInterna
               .NewCostoManoObraExterna = vCostoTiempos.CostoManoObraExterna
               .NewCostoMateriaPrima = vCostoTiempos.CostoMateriaPrima
               .NewCostoTotalProceso = vCostoTiempos.CostosTotalProceso
               .CostoProductoSucursal = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.Id, eProc.IdProductoProceso).PrecioCosto
            End With
            eProcesos.Add(eProc)
            '-------------------------------------
            For Each eOpr In eProc.Operaciones
               For Each eProd In eOpr.ProductosNecesario
                  Select Case eProd.NewPrecioCostoProducto
                     Case = 0
                        eProd.EstadoValorGrilla = "0"
                        alertaCostoCero = True
                     Case > eProd.PrecioCostoProducto
                        eProd.EstadoValorGrilla = ">"
                     Case < eProd.PrecioCostoProducto
                        eProd.EstadoValorGrilla = "<"
                     Case = eProd.PrecioCostoProducto
                        eProd.EstadoValorGrilla = "="
                  End Select
                  '--
                  Dim eProcProd = New Reglas.MRPProcesosProductivos().GetUno(eProc.IdProcesoProductivo, eProc.IdProductoProceso)
                  eProd.CodigoProcesoProductivo = eProcProd.CodigoProcesoProductivo
                  eProd.NombreProcesoProductivo = eProcProd.DescripcionProceso
                  '--
                  eProd.FechaUltimaActualizacion = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.Id, eProd.IdProductoProceso).FechaActualizacion
                  '-- PE-41092.- ------------------------------------
                  Dim sProd = eProducto.Where(Function(x) x.IdProductoProceso = eProd.IdProductoProceso And x.IdProcesoProductivo = eProd.IdProcesoProductivo).ToList()
                  If sProd.Count = 0 Then
                     eProducto.Add(eProd)
                  End If
                  '---------------------------------------------------
               Next
            Next
            '-------------------------------------
         Next
         ugDatos.DataSource = eProcesos
         ugCostosCeros.DataSource = eProducto

         FormateaGrillaDatos()

         For ind = 1 To 2
            utcGrillas.Tabs(ind).Visible = True
         Next

         If alertaCostoCero Then
            utcGrillas.Tabs(2).Appearance.BackColor = Color.Red
         Else
            utcGrillas.Tabs(2).Appearance.BackColor = Nothing
         End If
         utcGrillas.Tabs(1).Selected = True
         tsbModificarProceso.Enabled = True
      End Sub)

   End Sub

   Public Sub FormateaGrillaDatos()
      With ugDatos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         '-- Agrega Filtros.- ---
         Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreProducto", "DescripcionProceso", "NombreMarca", "NombreRubro", "NombreSubRubro"})

         .Columns("IdProductoProceso").FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Nombre Producto", pos, 200)

         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoManoObraInterna.ToString()).FormatearColumna("Costo MO Interno", pos, 80, HAlign.Right,, "N2")
         .Columns("NewCostoManoObraInterna").FormatearColumna("Costo MO Interno Nuevo", pos, 80, HAlign.Right,, "N2")

         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoManoObraExterna.ToString()).FormatearColumna("Costo MO Externo", pos, 80, HAlign.Right,, "N2")
         .Columns("NewCostoManoObraExterna").FormatearColumna("Costo MO Externo Nuevo", pos, 80, HAlign.Right,, "N2")

         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoMateriaPrima.ToString()).FormatearColumna("Costo Materia Prima", pos, 80, HAlign.Right,, "N2")
         .Columns("NewCostoMateriaPrima").FormatearColumna("Costo Materia Prima Nuevo", pos, 80, HAlign.Right,, "N2")

         .Columns(Entidades.MRPProcesoProductivo.Columnas.CostoTotalProceso.ToString()).FormatearColumna("Costo Total Actual", pos, 80, HAlign.Right,, "N2")
         .Columns("NewCostoTotalProceso").FormatearColumna("Costo Total Nuevo", pos, 80, HAlign.Right,, "N2")

         .Columns("CostoProductoSucursal").FormatearColumna("Costo Producto Actual", pos, 80, HAlign.Right,, "N2")

      End With

      With ugCostosCeros.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()

         Dim pos = 0I
         '-- Agrega Filtros.- ---
         Grilla.AgregarFiltroEnLinea(ugDetalle, {"NombreProducto", "DescripcionProceso", "NombreMarca", "NombreRubro", "NombreSubRubro"})

         .Columns("CodigoProcesoProductivo").FormatearColumna("Código Proceso", pos, 80, HAlign.Right)
         .Columns("NombreProcesoProductivo").FormatearColumna("Nombre Proceso", pos, 200)

         .Columns("NombreMonedaProducto").FormatearColumna("Moneda", pos, 70, HAlign.Left)

         .Columns("IdProductoProceso").FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Nombre Producto", pos, 250)
         .Columns("CantidadSolicitada").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, "N2")

         .Columns("PrecioCostoProducto").FormatearColumna("Costo Unitario Actual", pos, 80, HAlign.Right,, "N2")
         .Columns("NewPrecioCostoProducto").FormatearColumna("Costo Unitario Nuevo", pos, 80, HAlign.Right,, "N2")

         .Columns("CostosProducto").FormatearColumna("Total Costo Actual", pos, 90, HAlign.Right,, "N2")
         .Columns("NewCostosProducto").FormatearColumna("Total Costo Nuevo", pos, 90, HAlign.Right,, "N2")

         .Columns("FechaUltimaActualizacion").FormatearColumna("Fecha Ultima Act.", pos, 90, HAlign.Center)
         .Columns("EstadoValorGrilla").FormatearColumna("Estado", pos, 80, HAlign.Center)


      End With
   End Sub

   Private Sub tsbModificarProceso_Click(sender As Object, e As EventArgs) Handles tsbModificarProceso.Click

      Try
         If ShowPregunta(String.Format("¿Desea actualizar los Procesos Productivos Seleccionados?")) = Windows.Forms.DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            ModificaProcesosProductivos()
            tsbRefrescar.PerformClick()
            Cursor = Cursors.Default
         End If
      Catch ex As Exception
         Dim ex1 = New Entidades.EniacException(ex.Message)
         ShowError(ex, True)
         Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ModificaProcesosProductivos()
      For Each drProcesos In DirectCast(Me.ugDatos.DataSource, List(Of MRPProcesoProductivo))
         drProcesos.CostoManoObraInterna = drProcesos.NewCostoManoObraInterna
         drProcesos.CostoManoObraExterna = drProcesos.NewCostoManoObraExterna
         drProcesos.CostoMateriaPrima = drProcesos.NewCostoMateriaPrima
         drProcesos.CostoTotalProceso = drProcesos.NewCostoTotalProceso
         For Each drOperacion In drProcesos.Operaciones
            For Each drCategorias In drOperacion.CategoriasEmpleados
               drCategorias.ValorHoraCategoria = drCategorias.NewValorHoraCategoria
            Next
            For Each drProductoN In drOperacion.ProductosNecesario
               drProductoN.PrecioCostoProducto = drProductoN.NewPrecioCostoProducto
            Next
         Next
         Dim rMRPProcesos = New Reglas.MRPProcesosProductivos()
         rMRPProcesos.Actualizar(drProcesos)
      Next
   End Sub
   Private Sub ugCostosCeros_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugCostosCeros.InitializeRow
      TryCatched(Sub() InitializaRow(e.Row))
   End Sub
   Private Sub InitializaRow(row As UltraGridRow)
      '---------------------------------------------------------------------------------
      If row IsNot Nothing Then
         Select Case row.Cells("EstadoValorGrilla").Value.ToString()
            Case "="
               row.Cells("EstadoValorGrilla").Color(Nothing, Nothing)
            Case "0"
               row.Cells("EstadoValorGrilla").Color(Nothing, Color.Red)
            Case ">"
               row.Cells("EstadoValorGrilla").Color(Nothing, Color.Green)
            Case "<"
               row.Cells("EstadoValorGrilla").Color(Nothing, Color.Yellow)
         End Select
      End If

      '---------------------------------------------------------------------------------

   End Sub


#End Region
End Class
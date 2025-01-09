Public Class InformedeStock

#Region "Campos"

   Private _publicos As Publicos

   '-- REQ-34669.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------
   Private _DatosAtributoProducto As DataTable

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         Dim oUsuario = New Reglas.Usuarios()

         _publicos.CargaComboDesdeEnum(cmbTipoInforme, GetType(Entidades.EnumSql.Stock_TipoReporte))

         _publicos.CargaComboDesdeEnum(cmbOrdenadoPor, GetType(Entidades.EnumSql.InformeStock_OrdenadoPor),
                                       hideBrowsable:=Not Reglas.Publicos.ProductoTieneSubRubro)

         _publicos.CargaComboDesdeEnum(cmbTipoDeposito, Entidades.SucursalDeposito.TiposDepositos.OPERATIVO)

         _publicos.CargaComboDesdeEnum(cmbStockUnificadoPor, GetType(Entidades.EnumSql.InformeStock_UnificadoPor))

         'Seguridad del campo Precio de Costo
         _publicos.CargaComboDesdeEnum(cmbMostrarPrecio, GetType(Entidades.EnumSql.InformeStock_MostrarPrecio),
                                       hideBrowsable:=Not oUsuario.TienePermisos("ConsultarPrecios-PrecioCosto"))
         cmbSucursal.Initializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
         'cmbDepositos.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, {})

         cmbMarcas.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)
         cmbRubros.Inicializar(permiteSinSeleccion:=False, seleccionMultiple:=True, seleccionTodos:=True)

         pnlModelos.Visible = Reglas.Publicos.ProductoTieneModelo
         pnlSubRubros.Visible = Reglas.Publicos.ProductoTieneSubRubro
         pnlSubSubRubros.Visible = Reglas.Publicos.ProductoTieneSubSubRubro

         ugDetalle.DisplayLayout.Bands(0).Columns("NombreModelo").Hidden = Not Reglas.Publicos.ProductoTieneModelo
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubRubro
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreSubSubRubro").Hidden = Not Reglas.Publicos.ProductoTieneSubSubRubro

         '--------------------------------------------------------------------------------

         chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

         Select Case Reglas.Publicos.InformeDeStockMostrarPrecioPredeterminado
            Case "Ninguno"
               cmbMostrarPrecio.SelectedValue = Entidades.EnumSql.InformeStock_MostrarPrecio.Ninguno
            Case "PrecioDeCosto"
               cmbMostrarPrecio.SelectedValue = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioCosto
            Case "PrecioDeVenta"
               cmbMostrarPrecio.SelectedValue = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioVenta
         End Select

         ugDetalle.AgregarTotalesSuma({"Stock"})
         ugDetalle.AgregarFiltroEnLinea({"NombreProducto", "NombreProducto"})

         RefrescarDatosGrilla()

         PreferenciasLeer(ugDetalle, tsbPreferencias)
         '-- REQ-35218.- ---------------------------------
         VerificaValorAtributos()
         tbcInformeStock.TabPages.Remove(tbpAtributoProducto)
         '------------------------------------------------
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

   Private Sub tbcInformeStock_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tbcInformeStock.SelectedIndexChanged
      TryCatched(
      Sub()
         If tbcInformeStock.SelectedTab.Name = tbpAtributoProducto.Name Then
            CargaDatosStockAtributos()
         Else
            ugStockAtributo.DataSource = Nothing
         End If
      End Sub)
   End Sub
   Private Sub ugDetalle_ClickCell(sender As Object, e As ClickCellEventArgs) Handles ugDetalle.ClickCell
      TryCatched(Sub() VisualizaStockAtributoProducto())
   End Sub
   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
            ShowMessage("ATENCION: Activo el filtro de Proveedor, Debe seleccionar uno.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la selección !!!")
         End If
      End Sub)
   End Sub

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Name, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub
   Private Sub tsbImprimir2_Click(sender As Object, e As EventArgs) Handles tsbImprimir2.Click
      TryCatched(
      Sub()
         Dim parm = New ReportParameterCollection(CargarFiltrosImpresion()) '  New List(Of Microsoft.Reporting.WinForms.ReportParameter)()

         Dim mostrarPrecio = cmbMostrarPrecio.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_MostrarPrecio)()
         parm.Add("MuestraPrecios", (mostrarPrecio <> Entidades.EnumSql.InformeStock_MostrarPrecio.Ninguno))

         Dim strReporte = String.Empty
         Dim ordenarPor = cmbOrdenadoPor.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_OrdenadoPor)()
         Select Case ordenarPor

            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Alfabetico

               If Not chbProveedor.Checked Then
                  strReporte = "ListadoDeStock.rdlc"  'Estandar
               Else
                  If chbEmbalaje.Checked Then
                     strReporte = "ListadoDeStock_Alfabetico_Proveedor.rdlc"
                  Else
                     strReporte = "ListadoDeStock.rdlc"  'Estandar
                  End If
               End If

            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Marca
               strReporte = "ListadoDeStock_Marca.rdlc"

            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Rubro
               strReporte = "ListadoDeStock_Rubro.rdlc"

            Case Entidades.EnumSql.InformeStock_OrdenadoPor.SubRubro
               strReporte = "ListadoDeStock_SubRubro.rdlc"

            Case Entidades.EnumSql.InformeStock_OrdenadoPor.Codigo
               strReporte = "ListadoDeStock_Codigo.rdlc"

         End Select

         Dim frmImprime = New VisorReportes("Eniac.Win." & strReporte, "SistemaDataSet_ListadoDeStock", DirectCast(Me.ugDetalle.DataSource, DataTable), parm, True, 1) With {
            .Text = "Listado de Stock",
            .WindowState = FormWindowState.Maximized
         } '# 1 = Cantidad Copias
         frmImprime.Show()
      End Sub)
   End Sub
   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub
   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub
#End Region

#Region "Eventos Filtros"
   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim habilitaDeposito = False
         'If cmbSucursal.SelectedIndex > 0 Then
         Dim sucursales = cmbSucursal.GetSucursales()
         If sucursales.Length > 0 Then
            cmbDepositos.Inicializar(True, True, True, sucursales)
            habilitaDeposito = cmbDepositos.GetDepositos().Count > 1
         End If
         'End If
         cmbDepositos.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      End Sub)
   End Sub
   Private Sub chbTipoDeposito_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoDeposito.CheckedChanged
      TryCatched(Sub() chbTipoDeposito.FiltroCheckedChanged(cmbTipoDeposito))
   End Sub
#Region "Eventos Buscador Proveedores"
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region
   Private Sub chbEmbalaje_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmbalaje.CheckedChanged
      TryCatched(
      Sub()
         If cmbOrdenadoPor.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_OrdenadoPor)() <> Entidades.EnumSql.InformeStock_OrdenadoPor.Alfabetico Then
            chbEmbalaje.Enabled = False
            chbEmbalaje.Checked = False
         End If
      End Sub)
   End Sub

#Region "Eventos Buscador Proveedores"
   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(Sub() chbProducto.FiltroCheckedChanged(usaPermitido:=True, bscCodigoProducto2, bscProducto2))
   End Sub
   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub cmbMostrarPrecio_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbMostrarPrecio.SelectedValueChanged
      TryCatched(
      Sub()
         MostrarColumnasPrecios()
         AsignaExpresionPrecioVenta(ugDetalle.DataSource(Of DataTable))
      End Sub)
   End Sub
   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      TryCatched(
      Sub()
         MostrarColumnasPrecios()
         AsignaExpresionPrecioVenta(ugDetalle.DataSource(Of DataTable))
      End Sub)
   End Sub

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

   Private Sub cmbOrdenadoPor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbOrdenadoPor.SelectedValueChanged
      TryCatched(
      Sub()
         chbEmbalaje.Checked = False
         chbEmbalaje.Enabled = cmbOrdenadoPor.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_OrdenadoPor)() = Entidades.EnumSql.InformeStock_OrdenadoPor.Alfabetico
      End Sub)
   End Sub
   Private Sub cmbStockUnificadoPor_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbStockUnificadoPor.SelectedValueChanged
      TryCatched(
      Sub()
         ugDetalle.ClearFilas()

         Dim stockUnificadoPor = cmbStockUnificadoPor.ValorSeleccionado(Entidades.EnumSql.InformeStock_UnificadoPor.Sucursal)

         ugDetalle.DisplayLayout.Bands(0).Columns("CodigoDeposito").Hidden = stockUnificadoPor < Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion
         ugDetalle.DisplayLayout.Bands(0).Columns("CodigoUbicacion").Hidden = stockUnificadoPor < Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreDeposito").Hidden = stockUnificadoPor < Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion
         ugDetalle.DisplayLayout.Bands(0).Columns("NombreUbicacion").Hidden = stockUnificadoPor < Entidades.EnumSql.InformeStock_UnificadoPor.Ubicacion

         ugDetalle.DisplayLayout.Bands(0).Columns("IdEmpresa").Hidden = stockUnificadoPor <> Entidades.EnumSql.InformeStock_UnificadoPor.Empresa
      End Sub)
   End Sub

#End Region

#End Region

#Region "Metodos"
   Private Sub CargaDatosStockAtributos()
      '-- Recupera Datos Generales.- -----
      _DatosAtributoProducto = New Reglas.AtributosProductos().GetStockAtributoProductos(ugDetalle.ActiveRow.Cells("idProducto").Value.ToString(),
                                                                                         ugDetalle.ActiveRow.Cells("idSucursal").Value.ToString().ToInt32.IfNull(),
                                                                                         ugDetalle.ActiveRow.Cells("GrupoAtributo01").Value.ToString().ToInt32.IfNull(),
                                                                                         ugDetalle.ActiveRow.Cells("TipoAtributo01").Value.ToString().ToInt32.IfNull(),
                                                                                         ugDetalle.ActiveRow.Cells("GrupoAtributo02").Value.ToString().ToInt32.IfNull(),
                                                                                         ugDetalle.ActiveRow.Cells("TipoAtributo02").Value.ToString().ToInt32.IfNull())
      '-- Carga los datos a la grilla.- --
      SeteaAtributoProductoSource()
      '-- Formatea Grilla.- --------------
      FormateaGrilla()
      '-----------------------------------------------------------------------------------------------------
   End Sub

   Private Sub SeteaAtributoProductoSource()
      ugStockAtributo.DataSource = _DatosAtributoProducto
   End Sub
   Private Sub FormateaGrilla()
      With ugStockAtributo.DisplayLayout.Bands(0)
         '-- Configura solo las visibles.- --
         .Columns("IdAtributo").Hidden = True
         If (ugDetalle.ActiveRow.Cells("GrupoAtributo02").Value.ToString().ToInt32.IfNull() + ugDetalle.ActiveRow.Cells("TipoAtributo02").Value.ToString().ToInt32.IfNull()) > 0 Then
            .Columns("DescripcionAtributo").Header.Caption = New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion
         Else
            .Columns("DescripcionAtributo").Hidden = True
         End If
         '-- Recorre Columnas y establece el Header.- ------------
         For Each col In .Columns.OfType(Of UltraGridColumn).Where(Function(c) c.Key.StartsWith("Atrib1_"))
            col.Header.Caption = col.Header.Caption.Split("_"c)(2)
            col.Header.Appearance.TextHAlign = HAlign.Center
            col.CellAppearance.TextHAlign = HAlign.Right
            col.CellActivation = Activation.NoEdit
         Next
         '--------------------------------------------------------
      End With
   End Sub
   ''' <summary>
   ''' Obtienen los Nombres de los Tipos de Atributos de Parametros.- ----------------
   ''' </summary>
   Private Sub VerificaValorAtributos()
      tbpAtributoProducto.Text = ""
      '-- Atributo 001.- -------------------------------------------------------------
      If TipoAtributo01 > 0 And TipoAtributo02 > 0 Then
         '-- Carga Valores Check.- ---------------------------------------------------
         tbpAtributoProducto.Text = String.Format("{0}-{1}",
                                                  New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion,
                                                  New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion)
      End If
   End Sub
   ''' <summary>
   ''' Activa o Desactiva la Tab de Stock Producto Atributo.- 
   ''' </summary>
   Private Sub VisualizaStockAtributoProducto()
      Try
         If ugDetalle.ActiveCell Is Nothing Then Exit Sub

         With tbcInformeStock.TabPages
            If ugDetalle.ActiveRow.Cells("Atributos").Value.ToString().ToInt32() > 0 Then
               If tbcInformeStock.TabCount = 1 Then
                  .Insert(1, tbpAtributoProducto)
               End If
            Else
               .Remove(tbpAtributoProducto)
            End If
         End With
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub RefrescarDatosGrilla()

      ugDetalle.ClearFilas()

      chbProveedor.Checked = False

      cmbOrdenadoPor.SelectedValue = Entidades.EnumSql.InformeStock_OrdenadoPor.Alfabetico
      cmbTipoInforme.SelectedValue = Entidades.EnumSql.Stock_TipoReporte.General
      cmbStockUnificadoPor.SelectedValue = Entidades.EnumSql.InformeStock_UnificadoPor.Sucursal

      cmbSucursal.Refrescar()
      cmbMarcas.Refrescar()
      cmbModelos.Refrescar()
      cmbRubros.Refrescar()
      cmbSubRubros.Refrescar()
      cmbSubSubRubros.Refrescar()

      cmbDepositos.Refrescar()

      chbTipoDeposito.Checked = False

      'chbDeposito.Checked = False

      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

      Select Case Reglas.Publicos.InformeDeStockMostrarPrecioPredeterminado
         Case "Ninguno"
            cmbMostrarPrecio.SelectedValue = Entidades.EnumSql.InformeStock_MostrarPrecio.Ninguno
         Case "PrecioDeCosto"
            cmbMostrarPrecio.SelectedValue = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioCosto
         Case "PrecioDeVenta"
            cmbMostrarPrecio.SelectedValue = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioVenta
      End Select

      btnConsultar.Focus()

   End Sub

   Private Sub CargaGrillaDetalle()
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim rubros As Entidades.Rubro() = cmbRubros.GetRubros(True)
      Dim subRubros As Entidades.SubRubro() = cmbSubRubros.GetSubRubros(True)

      Dim tipoOperacion = If(chbTipoDeposito.Checked, cmbTipoDeposito.ValorSeleccionado(Of Entidades.SucursalDeposito.TiposDepositos), DirectCast(Nothing, Entidades.SucursalDeposito.TiposDepositos?))

      Dim rListadoDeStock = New Reglas.ProductosSucursales()
      Dim dt = rListadoDeStock.GetListadoDeStock(
                                    cmbSucursal.GetSucursales(),
                                    cmbDepositos.GetDepositos(todosVacio:=False),
                                    If(chbProducto.Checked, bscCodigoProducto2.Text, String.Empty),
                                    cmbMarcas.GetMarcas(True),
                                    cmbModelos.GetModelos(True),
                                    rubros,
                                    If(rubros.Length = 1, cmbSubRubros.GetSubRubros(True), {}),
                                    If(subRubros.Length = 1, cmbSubSubRubros.GetSubSubRubros(True), {}),
                                    cmbTipoInforme.ValorSeleccionado(Of Entidades.EnumSql.Stock_TipoReporte)(),
                                    cmbOrdenadoPor.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_OrdenadoPor)(),
                                    idProveedor,
                                    chbProveedorHabitual.Checked,
                                    Publicos.ListaPreciosPredeterminada,
                                    cmbStockUnificadoPor.ValorSeleccionado(Entidades.EnumSql.InformeStock_UnificadoPor.Sucursal), tipoOperacion,
                                    cmbSucursal.TodosSelected)
      dt.Columns.Add("PrecioVenta", GetType(Decimal))
      AsignaExpresionPrecioVenta(dt)

      ugDetalle.DataSource = dt

      ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = cmbSucursal.GetSucursales().Count < 2

      ugDetalle.DisplayLayout.Bands(0).Columns("CodigoProductoProveedor").Hidden = Not chbProveedor.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("Embalaje").Hidden = Not chbProveedor.Checked

      ugDetalle.AgregarTotalesSuma({"Stock"})

      PreferenciasLeer(ugDetalle, tsbPreferencias)
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Permitido = False
         bscCodigoProveedor.Permitido = False
         chbProveedorHabitual.Enabled = True
         If cmbOrdenadoPor.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_OrdenadoPor)() = Entidades.EnumSql.InformeStock_OrdenadoPor.Alfabetico Then
            chbEmbalaje.Enabled = True
            chbEmbalaje.Checked = False
         Else
            chbEmbalaje.Enabled = False
            chbEmbalaje.Checked = False
         End If
         btnConsultar.Focus()
      End If
   End Sub
   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Permitido = False
         bscCodigoProducto2.Permitido = False
         bscProducto2.Selecciono = True
         bscCodigoProducto2.Selecciono = True
         btnConsultar.Focus()
      End If
   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro
         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, muestraId:=True, muestraNombre:=False)
         cmbDepositos.CargarFiltrosImpresionDepositos(filtro, muestraId:=False, muestraNombre:=True)
         If chbTipoDeposito.Checked Then .AppendFormat(" - {0}: {1}", chbTipoDeposito.Text, cmbTipoDeposito.Text)
         If chbProveedor.Checked Then .AppendFormat(" - {0}: {1} - {2}", chbProveedor.Text, bscCodigoProveedor.Text, bscProveedor.Text)
         If chbProveedorHabitual.Checked Then .AppendFormat(" (Habitual)")
         If chbEmbalaje.Checked Then .AppendFormat(" - {0}", chbEmbalaje.Text)
         If chbProducto.Checked Then .AppendFormat(" - {0}: {1} - {2}", chbProducto.Text, bscCodigoProducto2.Text, bscProducto2.Text)

         If cmbMostrarPrecio.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_MostrarPrecio) <> Entidades.EnumSql.InformeStock_MostrarPrecio.Ninguno Then
            .AppendFormat(" - {0}{1}", cmbMostrarPrecio.Text, If(chbConIVA.Checked, " Con IVA", " Sin IVA"))
         End If

         If cmbMarcas.Visible Then cmbMarcas.CargarFiltrosImpresionMarcas(filtro, muestraId:=True, muestraNombre:=False)
         If cmbModelos.Visible Then cmbModelos.CargarFiltrosImpresionModelos(filtro, muestraId:=True, muestraNombre:=False)
         If cmbRubros.Visible Then cmbRubros.CargarFiltrosImpresionRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubRubros.Visible Then cmbSubRubros.CargarFiltrosImpresionSubRubros(filtro, muestraId:=True, muestraNombre:=False)
         If cmbSubSubRubros.Visible Then cmbSubSubRubros.CargarFiltrosImpresionSubSubRubros(filtro, muestraId:=True, muestraNombre:=False)

         .AppendFormat(" - {0}: {1}", lblTipoInforme.Text, cmbTipoInforme.Text)
         .AppendFormat(" - {0}: {1}", lblStockUnificadoPor.Text, cmbStockUnificadoPor.Text)
         .AppendFormat(" - {0}: {1}", lblOrdenadoPor.Text, cmbOrdenadoPor.Text)

      End With

      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub MostrarColumnasPrecios()
      With ugDetalle.DisplayLayout.Bands(0)
         If .Columns.Exists("PrecioVentaConImpuestos") And .Columns.Exists("PrecioCostoConImpuestos") And .Columns.Exists("PrecioVentaSinImpuestos") And .Columns.Exists("PrecioCostoSinImpuestos") Then
            Dim mostrarPrecio = cmbMostrarPrecio.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_MostrarPrecio)()
            .Columns("PrecioVentaConImpuestos").Hidden = Not (chbConIVA.Checked And mostrarPrecio = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioVenta)
            .Columns("PrecioCostoConImpuestos").Hidden = Not (chbConIVA.Checked And mostrarPrecio = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioCosto)
            .Columns("PrecioVentaSinImpuestos").Hidden = Not (Not chbConIVA.Checked And mostrarPrecio = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioVenta)
            .Columns("PrecioCostoSinImpuestos").Hidden = Not (Not chbConIVA.Checked And mostrarPrecio = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioCosto)
         End If
      End With
   End Sub

   Public Sub AsignaExpresionPrecioVenta(dt As DataTable)
      If dt IsNot Nothing AndAlso dt.Columns.Contains("PrecioVenta") Then
         Dim mostrarPrecioVenta = cmbMostrarPrecio.ValorSeleccionado(Of Entidades.EnumSql.InformeStock_MostrarPrecio)() = Entidades.EnumSql.InformeStock_MostrarPrecio.PrecioVenta
         Dim expresionPrecioVenta As String = String.Concat(If(mostrarPrecioVenta, "PrecioVenta", "PrecioCosto"), If(chbConIVA.Checked, "Con", "Sin"), "Impuestos")
         dt.Columns("PrecioVenta").Expression = expresionPrecioVenta
      End If
   End Sub

#End Region

End Class
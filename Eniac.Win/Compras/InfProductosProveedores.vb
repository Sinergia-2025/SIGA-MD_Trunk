Public Class InfProductosProveedores

#Region "Campos"

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False
   Private _IdProducto As String
   Private _tit As Dictionary(Of String, String)

#End Region

#Region "Constructores"


   Public Sub New()
      InitializeComponent()
   End Sub


   Public Sub New(idProducto As String)
      Me.New()
      Dim oprod As Reglas.Productos = New Reglas.Productos()
      Dim prod As Entidades.Producto = oprod.GetUno(idProducto)
      _IdProducto = prod.IdProducto
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboMarcas(cmbMarca)

         _publicos.CargaComboMonedas(cmbMoneda)

         ' Incializo el combo de Rubros
         ' Pongo en 'Todos' los combos de Rubros, Sub, y SubSub
         cmbRubro.Inicializar(True, True, True)
         cmbSubRubro.Inicializar(True, True, True, {})
         cmbSubSubRubro.Inicializar(True, True, True, {})

         cmbRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
         cmbSubSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)

         ' Verifico si se utiliza SubRubro
         If Not Reglas.Publicos.ProductoTieneSubRubro Then
            chbSubRubro.Visible = False
            cmbSubRubro.Visible = False
         End If

         ' Verifico si se utiliza SubSubRubro
         If Not Reglas.Publicos.ProductoTieneSubSubRubro Then
            chbSubSubRubro.Visible = False
            cmbSubSubRubro.Visible = False
         End If

         dtpDesde.Value = Date.Today
         dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

         If ConsultarAutomaticamente Then
            chbProducto.Checked = True
            bscCodigoProducto2.Text = _IdProducto.ToString()
            bscCodigoProducto2.PresionarBoton()
            btnConsultar.PerformClick()
         End If

         PreferenciasLeer(ugDetalle, tsbPreferencias)
         ugDetalle.AgregarFiltroEnLinea({"NombreProveedor", "NombreProducto", "CodigoProductoProveedor", "NombreMarca", "NombreRubro", "NombreSubRubro", "NombreSubSubRubro", "NombreMoneda"})

         _tit = GetColumnasVisiblesGrilla(ugDetalle)
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

   Private Sub cmbRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRubro.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim habilitaSubRubro As Boolean = False
         If cmbRubro.SelectedIndex > 0 Then
            Dim rubros As Entidades.Rubro() = cmbRubro.GetRubros()
            If rubros.Length = 1 Then
               cmbSubRubro.Inicializar(True, True, True, rubros)
               habilitaSubRubro = True
            End If
         End If
         cmbSubRubro.Enabled = habilitaSubRubro
         cmbSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      End Sub)
   End Sub

   Private Sub cmbSubRubro_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.AfterSelectedIndexChanged
      TryCatched(
      Sub()
         Dim habilitaSubSubRubro As Boolean = False
         If cmbSubRubro.SelectedIndex > 0 Then
            Dim subRubros As Entidades.SubRubro() = cmbSubRubro.GetSubRubros()
            If subRubros.Length = 1 Then
               cmbSubSubRubro.Inicializar(True, True, True, subRubros)
               habilitaSubSubRubro = True
            End If
         End If
         cmbSubSubRubro.Enabled = habilitaSubSubRubro
         cmbSubSubRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      End Sub)
   End Sub

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      bscCodigoProveedor.Enabled = chbProveedor.Checked
      bscProveedor.Enabled = chbProveedor.Checked

      chbProveedorHabitual.Checked = False
      chbProveedorHabitual.Enabled = chbProveedor.Checked

      bscCodigoProveedor.Text = String.Empty
      bscCodigoProveedor.Tag = Nothing
      bscProveedor.Text = String.Empty

      bscCodigoProveedor.Focus()
   End Sub

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscProveedor)
         bscProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged
      TryCatched(
      Sub()
         bscCodigoProducto2.Enabled = chbProducto.Checked
         bscProducto2.Enabled = chbProducto.Checked

         'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
         If Not chbProducto.Checked Then
            bscCodigoProducto2.Text = String.Empty
            bscProducto2.Text = String.Empty
         Else
            'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
            chbMarca.Checked = False
            bscCodigoProducto2.Focus()
         End If
      End Sub)

   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProducto2)
         bscCodigoProducto2.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscProducto2)
         bscProducto2.Datos = New Reglas.Productos().GetPorNombre(bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "COMPRAS")
      End Sub)
   End Sub
   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion, bscProducto2.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProducto(e.FilaDevuelta))
   End Sub

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged
      TryCatched(
      Sub()
         cmbMarca.Enabled = chbMarca.Checked

         If Not chbMarca.Checked Then
            cmbMarca.SelectedIndex = -1
         Else
            cmbMarca.SelectedIndex = 0
            'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
            'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
            chbProducto.Checked = False
            cmbMarca.Focus()
         End If
      End Sub)
   End Sub

   Private Sub chbFecha_CheckedChanged(sender As Object, e As EventArgs) Handles chbFecha.CheckedChanged
      TryCatched(
      Sub()
         chkMesCompleto.Enabled = chbFecha.Checked
         dtpDesde.Enabled = chbFecha.Checked
         dtpHasta.Enabled = chbFecha.Checked

         If Not chbFecha.Checked Then
            chkMesCompleto.Checked = False
            dtpDesde.Value = Date.Today
            dtpHasta.Value = Date.Today.Date.UltimoSegundoDelDia()
         Else
            dtpDesde.Focus()
         End If
      End Sub)
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged
      TryCatched(Sub() chkMesCompleto.FiltroCheckedChangedMesCompleto(dtpDesde, dtpHasta))
   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
      Sub()
         If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro.")
            bscCodigoProveedor.Focus()
            Exit Sub
         End If

         If chbProducto.Checked And Not bscCodigoProducto2.Selecciono And Not bscProducto2.Selecciono Then
            ShowMessage("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.")
            bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If chbMarca.Checked And cmbMarca.SelectedIndex = -1 Then
            ShowMessage("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.")
            cmbMarca.Focus()
            Exit Sub
         End If

         chkExpandAll.Enabled = True
         chkExpandAll.Checked = False

         CargaGrillaDetalle()

         If ugDetalle.Rows.Count > 0 Then
            btnConsultar.Focus()
         Else
            ShowMessage("NO hay registros que cumplan con la seleccion !!!")
         End If

         tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
      End Sub)
   End Sub

   Private Sub chkExpandAll_CheckedChanged(sender As Object, e As EventArgs) Handles chkExpandAll.CheckedChanged
      TryCatched(Sub() ugDetalle.ColapsarExpandir(chkExpandAll.Checked))
   End Sub

   Private Sub chbMoneda_CheckedChanged(sender As Object, e As EventArgs) Handles chbMoneda.CheckedChanged
      TryCatched(
      Sub()
         If chbMoneda.Checked Then
            cmbMoneda.SelectedIndex = 0
            cmbMoneda.Enabled = True
            cmbMoneda.Focus()
         Else
            cmbMoneda.SelectedIndex = -1
            cmbMoneda.Enabled = False
         End If
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
         bscProveedor.Enabled = False
         bscCodigoProveedor.Enabled = False

         btnConsultar.Focus()
      End If
   End Sub

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
         bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscProducto2.Enabled = False
         bscCodigoProducto2.Enabled = False
      End If
   End Sub

   Private Sub RefrescarDatosGrilla()

      chbProveedor.Checked = False

      chbProducto.Checked = False
      chbMarca.Checked = False
      cmbRubro.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()
      chbFecha.Checked = False
      chbMoneda.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False

      ugDetalle.ClearFilas()

      btnConsultar.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim idProducto = If(chbProducto.Checked, bscCodigoProducto2.Text.Trim(), String.Empty)
      Dim idMarca = If(chbMarca.Checked, Integer.Parse(cmbMarca.SelectedValue.ToString()), 0I)
      Dim idMoneda = 0I

      Dim fechaDesde As Date = Nothing
      Dim fechaHasta As Date = Nothing
      If chbFecha.Checked Then
         fechaDesde = dtpDesde.Value
         fechaHasta = dtpHasta.Value
      End If

      Dim rubros = cmbRubro.GetRubros(True)
      Dim subrubros = cmbSubRubro.GetSubRubros(True)
      Dim subsubrubros = cmbSubSubRubro.GetSubSubRubros(True)

      If chbMoneda.Checked Then
         If IsNumeric(cmbMoneda.SelectedValue) Then
            idMoneda = Integer.Parse(cmbMoneda.SelectedValue.ToString())
         End If
      End If

      Dim regla = New Reglas.ProductosProveedores()
      Dim dtDetalle = regla.GetInforme(idProveedor, chbProveedorHabitual.Checked, idProducto,
                                       idMarca, rubros, subrubros, subsubrubros,
                                       fechaDesde, fechaHasta, idMoneda)

      ugDetalle.DataSource = dtDetalle

      AjustarColumnasGrilla(ugDetalle, _tit)

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

   End Sub

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()

      With filtro
         If chbProveedor.Checked Then
            .AppendFormat("Proveedor{2}: {0} - {1} - ", bscCodigoProveedor.Text, bscProveedor.Text, If(chbProveedorHabitual.Checked, " Habitual", String.Empty))
         End If
         If chbProducto.Checked Then
            .AppendFormat("Producto: {0} - {1} - ", bscCodigoProducto2.Text, bscProducto2.Text)
         End If
         If chbMarca.Checked Then
            .AppendFormat("Marca: {0} - ", cmbMarca.Text)
         End If

         cmbRubro.CargarFiltrosImpresionRubros(filtro, False, True)
         .Append(" - ")

         ' Verifico si se utiliza SubRubro
         If Reglas.Publicos.ProductoTieneSubRubro Then
            cmbSubRubro.CargarFiltrosImpresionSubRubros(filtro, False, True)
            .Append(" - ")
         End If

         ' Verifico si se utiliza SubSubRubro
         If Reglas.Publicos.ProductoTieneSubSubRubro Then
            cmbSubSubRubro.CargarFiltrosImpresionSubRubros(filtro, False, True)
            .Append(" - ")
         End If

         If chbFecha.Checked Then
            .AppendFormat("Rango de Fechas: desde el {0:dd/MM/yyy} hasta el {1:dd/MM/yyy}", dtpDesde.Value, dtpHasta.Value)
         End If
      End With
      Return filtro.ToString.Trim().Trim("-"c).Trim()
   End Function

#End Region

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

End Class
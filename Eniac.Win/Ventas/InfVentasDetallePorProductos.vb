Public Class InfVentasDetallePorProductos

#Region "Campos"

   Private _publicos As Publicos
   Private IdUsuario As String = actual.Nombre

   Private _paraBusqueda As Boolean = False
   Private _codigoCliente As Long? = Nothing
   Private _idProducto As String = String.Empty

   Private _utilizaCentroCostos As Boolean = False

   Private _vieneDeOnLoad As Boolean = False


#End Region

   Public Property Producto As String
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Short
   Public Property NumeroComprobante As Long

   '-- REQ-35221.- --------------------------------------------------------------------------------------------------
   Private ReadOnly TipoAtributo01 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto01
   Private ReadOnly TipoAtributo02 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto02
   Private ReadOnly TipoAtributo03 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto03
   Private ReadOnly TipoAtributo04 As Short = Reglas.Publicos.AtributosProductos.TipoAtributo.TipoAtributoProducto04
   '-----------------------------------------------------------------------------------------------------------------


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            dtpDesde.Value = Date.Today
            dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

            _utilizaCentroCostos = Reglas.Publicos.TieneModuloContabilidad AndAlso Reglas.ContabilidadPublicos.UtilizaCentroCostos

            _publicos.CargaComboMarcas(Me.cmbMarca)
            _publicos.CargaComboRubros(Me.cmbRubro, False, False)
            _publicos.CargaComboCategorias(Me.cmbCategoria)
            _publicos.CargaComboTransportistas(Me.cmbTransportista)
            cmbTransportista.SelectedIndex = -1

            'Me._publicos.CargaComboSubRubros(Me.cmbSubRubro)
            'If Not Publicos.ProductoTieneSubRubro Then
            '   Me.chbSubRubro.Visible = False
            '   Me.cmbSubRubro.Visible = False
            '   Me.dgvDetalle.DisplayLayout.Bands(0).Columns("NombreSubRubro").Hidden = True
            'End If

            _vieneDeOnLoad = True
            'Me._publicos.CargaComboTiposComprobantes(Me.cmbTiposComprobantes, False, "VENTAS", , , , , True)
            'Me.cmbTiposComprobantes.SelectedIndex = -1
            cmbTiposComprobantes.Initializar(False, "VENTAS")
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
            _vieneDeOnLoad = False

            With Me.cboLetra
               .DisplayMember = "LetraFiscal"
               .ValueMember = "LetraFiscal"
               .DataSource = New Reglas.VentasNumeros().GetLetrasFiscales()
               .SelectedIndex = -1
            End With

            With Me.cmbEmisor
               .DisplayMember = "CentroEmisor"
               .ValueMember = "CentroEmisor"
               .DataSource = New Reglas.VentasNumeros().GetCentrosEmisores()
               .SelectedIndex = -1
            End With


            'Si el Usuario no tiene Vendedores asociados limpio la variable para que no filtre en el cargar combo.
            If New Reglas.Empleados().GetPorUsuario(IdUsuario).Rows.Count = 0 Then
               IdUsuario = ""
            End If

            _publicos.CargaComboDesdeEnum(cmbOrigenVendedor, GetType(Entidades.OrigenFK))
            cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual

            _publicos.CargaComboDesdeEnum(cmbOrigenCategoria, GetType(Entidades.OrigenFK))
            cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

            _publicos.CargaComboEmpleados(Me.cmbVendedor, Entidades.Publicos.TiposEmpleados.VENDEDOR, IdUsuario)
            If IdUsuario = "" Then
               cmbVendedor.SelectedIndex = -1
            Else
               chbVendedor.Checked = True
               chbVendedor.Enabled = False  'Para que no pueda modificarlo manualmente
            End If
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreVendedor").Hidden = (Me.cmbVendedor.Items.Count = 1)

            _publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")
            cmbFormaPago.SelectedIndex = -1
            _publicos.CargaComboUsuarios(Me.cmbUsuario)

            _publicos.CargaComboZonasGeograficas(Me.cmbZonaGeografica)
            cmbZonaGeografica.SelectedIndex = -1

            _publicos.CargaComboListaPreciosVentasDescripcion(Me.cmbListaPrecios)

            _publicos.CargaComboDesdeEnum(cmbTipoCliente, GetType(Entidades.Cliente.ClienteVinculado))

            cmbGrabanLibro.Items.Insert(0, "TODOS")
            cmbGrabanLibro.Items.Insert(1, "SI")
            cmbGrabanLibro.Items.Insert(2, "NO")
            cmbGrabanLibro.SelectedIndex = 0

            cmbAfectaCaja.Items.Insert(0, "TODOS")
            cmbAfectaCaja.Items.Insert(1, "SI")
            cmbAfectaCaja.Items.Insert(2, "NO")
            cmbAfectaCaja.SelectedIndex = 1

            cmbIngresosBrutos.Items.Insert(0, "TODOS")
            cmbIngresosBrutos.Items.Insert(1, "SI")
            cmbIngresosBrutos.Items.Insert(2, "NO")
            cmbIngresosBrutos.SelectedIndex = 0

            cmbProdDescRec.Items.Insert(0, "TODOS")
            cmbProdDescRec.Items.Insert(1, "SI")
            cmbProdDescRec.Items.Insert(2, "NO")
            cmbProdDescRec.SelectedIndex = 0

            Dim aCantidad As ArrayList = New ArrayList
            aCantidad.Insert(0, "Negativo ( < 0 )")
            aCantidad.Insert(1, "Igual a Cero ( = 0 )")
            aCantidad.Insert(2, "Mayor a Cero ( > 0 )")
            cmbCantidad.DataSource = aCantidad
            cmbCantidad.SelectedIndex = -1   '0

            _publicos.CargaComboProvincias(Me.cmbProvincia)

            cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.NORMAL)
            If Reglas.Publicos.ProductoPermiteEsCambiable Then
               cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.CAMBIO)
            End If
            If Reglas.Publicos.ProductoPermiteEsBonificable Then
               cmbTipoOperacion.Items.Add(Entidades.Producto.TiposOperaciones.BONIFICACION)
            End If

            cmbTipoOperacion.SelectedItem = Entidades.Producto.TiposOperaciones.NORMAL

            chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA

            '# Historia Clínica
            If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
               gbHistoriaClinica.Visible = True
            End If

            ''Da la posibilidad de que podamos elegir las columnas que queremos mostrar u ocultar con un botón a la izquierda de la cabecera.
            'ugDetalle.DisplayLayout.Override.RowSelectorHeaderStyle = Infragistics.Win.UltraWinGrid.RowSelectorHeaderStyle.ColumnChooserButton
            'ugDetalle.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.True

            CargarColumnasASumar()

            chbSubRubro.Visible = Reglas.Publicos.ProductoTieneSubRubro
            cmbSubRubro.Visible = chbSubRubro.Visible
            chbSubSubRubro.Visible = Reglas.Publicos.ProductoTieneSubSubRubro
            cmbSubSubRubro.Visible = chbSubSubRubro.Visible

            With ugDetalle.DisplayLayout.Bands(0)
               .Columns("ImporteImpuestoInterno").Hidden = True
               .Columns(Entidades.VentaProducto.Columnas.TipoOperacion.ToString()).Hidden = Not Reglas.Publicos.ProductoPermiteEsCambiable And Not Reglas.Publicos.ProductoPermiteEsBonificable
               .Columns(Entidades.VentaProducto.Columnas.Nota.ToString()).Hidden = .Columns(Entidades.VentaProducto.Columnas.TipoOperacion.ToString()).Hidden
               .Columns(Entidades.SubRubro.Columnas.NombreSubRubro.ToString()).Hidden = Not chbSubRubro.Visible
               .Columns(Entidades.SubSubRubro.Columnas.NombreSubSubRubro.ToString()).Hidden = Not chbSubSubRubro.Visible
               '-- REQ-35222.- ------------------------------------------------------
               .Columns("DescripcionAtributo01").Header.Caption = If(TipoAtributo01 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo01).Descripcion)
               .Columns("DescripcionAtributo01").Hidden = (TipoAtributo01 = 0)
               '-- Atributo 02.- ------------------------------------------------------
               .Columns("DescripcionAtributo02").Header.Caption = If(TipoAtributo02 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo02).Descripcion)
               .Columns("DescripcionAtributo02").Hidden = (TipoAtributo02 = 0)
               '-- Atributo 03.- ------------------------------------------------------
               .Columns("DescripcionAtributo03").Header.Caption = If(TipoAtributo03 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo03).Descripcion)
               .Columns("DescripcionAtributo03").Hidden = (TipoAtributo03 = 0)
               '-- Atributo 04.- ------------------------------------------------------
               .Columns("DescripcionAtributo04").Header.Caption = If(TipoAtributo04 = 0, "", New Reglas.TiposAtributosProductos().GetUno(TipoAtributo04).Descripcion)
               .Columns("DescripcionAtributo04").Hidden = (TipoAtributo04 = 0)
               '---------------------------------------------------------------------
            End With

            'Hay que colocarlo del CargarColumnasASumar porque sino da error.
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            ugDetalle.DisplayLayout.Bands(0).Columns("NombreLocalidad").Hidden = False
            ugDetalle.DisplayLayout.Bands(0).Columns("NombreProvincia").Hidden = False

            If _paraBusqueda Then
               If Not String.IsNullOrWhiteSpace(_idProducto) Then
                  chbProducto.Checked = True
                  bscCodigoProducto2.Text = _idProducto
                  bscCodigoProducto2.PresionarBoton()
               End If

               If _codigoCliente.HasValue Then
                  chbCliente.Checked = True
                  bscCodigoCliente.Text = _codigoCliente.Value.ToString()
                  bscCodigoCliente.PresionarBoton()
               End If


               dtpDesde.Value = dtpDesde.Value.AddYears(-1)

               If bscCodigoCliente.Selecciono Or bscCodigoProducto2.Selecciono Then
                  btnConsultar.PerformClick()
               End If
            End If

            cmbSucursal.Initializar(False, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            ugDetalle.DisplayLayout.Bands(0).Columns("IdSucursal").Hidden = Not cmbSucursal.Enabled

            ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.VentaProducto.Columnas.IdCentroCosto.ToString()).Hidden = Not _utilizaCentroCostos
            ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = Not _utilizaCentroCostos

            cmbCajas.Inicializar(cmbSucursal.GetSucursales(), blnMiraUsuario:=True, blnMiraPC:=False, blnCajasModificables:=False)

            ugDetalle.AgregarFiltroEnLinea({"NombreCliente", "NombreVendedor", "NombreProducto", "NombreLocalidad", "NombreProvincia", "NombreCentroCosto", "Observacion"}, {"Ver", "Imprimir", "VerEstandar"})

         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         If _paraBusqueda Then
            Close()
         End If
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub chbPaciente_CheckedChanged(sender As Object, e As EventArgs) Handles chbPaciente.CheckedChanged
      TryCatched(
         Sub()
            If Not chbPaciente.Checked Then
               bscCodigoPaciente.Text = ""
               bscPaciente.Text = ""
               bscCodigoPaciente.Enabled = False
               bscPaciente.Enabled = False
            Else
               bscCodigoPaciente.Enabled = True
               bscPaciente.Enabled = True
            End If
         End Sub)
   End Sub

   Private Sub chbDoctor_CheckedChanged(sender As Object, e As EventArgs) Handles chbDoctor.CheckedChanged
      TryCatched(
         Sub()
            If Not chbDoctor.Checked Then
               bscCodigoDoctor.Text = ""
               bscDoctor.Text = ""
               bscCodigoDoctor.Enabled = False
               bscDoctor.Enabled = False
            Else
               bscCodigoDoctor.Enabled = True
               bscDoctor.Enabled = True
            End If
         End Sub)
   End Sub

   Private Sub chbFechaCirugia_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCirugia.CheckedChanged
      TryCatched(
         Sub()
            dtpFechaCirugia.Enabled = chbFechaCirugia.Checked
            If Not chbFechaCirugia.Checked Then
               dtpFechaCirugia.Value = Date.Today
            End If
         End Sub)
   End Sub

   Private Sub bscCodigoPaciente_BuscadorClick() Handles bscCodigoPaciente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoPaciente)
            Dim codigoPaciente = bscCodigoPaciente.Text.ValorNumericoPorDefecto(-1L)
            '# Valido que esté configurado la categoria para los Pacientes
            If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
               ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
               Exit Sub
            End If
            bscCodigoPaciente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoPaciente, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
         End Sub)

   End Sub
   Private Sub bscPaciente_BuscadorClick() Handles bscPaciente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscPaciente)
            '# Valido que esté configurado la categoria para los Pacientes
            If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaPaciente) Then
               ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Pacientes. Debe configurarla para poder continuar.")
               Exit Sub
            End If
            bscPaciente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscPaciente.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaPaciente))
         End Sub)
   End Sub
   Private Sub bscCodigoPaciente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoPaciente.BuscadorSeleccion, bscPaciente.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoPaciente, bscPaciente))
   End Sub


   Private Sub bscCodigoDoctor_BuscadorClick() Handles bscCodigoDoctor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoDoctor)
            Dim codigoDoctor = bscCodigoDoctor.Text.ValorNumericoPorDefecto(-1L)
            '# Valido que esté configurado la categoria para los Doctores
            If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
               ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
               Exit Sub
            End If
            bscCodigoDoctor.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoDoctor, True, True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
         End Sub)
   End Sub
   Private Sub bscDoctor_BuscadorClick() Handles bscDoctor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscDoctor)
            '# Valido que esté configurado la categoria para los Doctores
            If String.IsNullOrEmpty(Reglas.Publicos.IdCategoriaDoctor) Then
               ShowMessage("ATENCIÓN: No se ha configurado una categoría para los Doctores. Debe configurarla para poder continuar.")
               Exit Sub
            End If
            bscDoctor.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscDoctor.Text.Trim(), True, idCategoria:=Integer.Parse(Reglas.Publicos.IdCategoriaDoctor))
         End Sub)
   End Sub
   Private Sub bscCodigoDoctor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoDoctor.BuscadorSeleccion, bscDoctor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCliente(e.FilaDevuelta, bscCodigoDoctor, bscDoctor))
   End Sub



   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub

   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         If Me.ugDetalle.Rows.Count = 0 Then Exit Sub

         Dim Filtros As String = txtFiltros.Text
         Dim Titulo As String

         Titulo = Reglas.Publicos.NombreEmpresaImpresion + Environment.NewLine + Environment.NewLine + Me.Text + Environment.NewLine + Environment.NewLine + Filtros

         Dim UltraPrintPreviewD As Infragistics.Win.Printing.UltraPrintPreviewDialog
         UltraPrintPreviewD = New Infragistics.Win.Printing.UltraPrintPreviewDialog(Me.components)
         UltraPrintPreviewD.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
         UltraPrintPreviewD.Name = "UltraPrintPreviewDialog1"

         UltraPrintPreviewD.Document = Me.UltraGridPrintDocument1
         UltraPrintPreviewD.Name = Me.Text

         Me.UltraPrintPreviewDialog1.Name = Me.Text
         Me.UltraGridPrintDocument1.Header.TextCenter = Titulo
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.Bold = DefaultableBoolean.True
         Me.UltraGridPrintDocument1.Header.Appearance.FontData.SizeInPoints = 12
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Left = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Right = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Top = 20
         Me.UltraGridPrintDocument1.DefaultPageSettings.Margins.Bottom = 40
         Me.UltraGridPrintDocument1.DefaultPageSettings.Landscape = True
         Me.UltraGridPrintDocument1.Footer.TextLeft = "Sucursal: " + actual.Sucursal.Nombre
         Me.UltraGridPrintDocument1.Footer.TextCenter = "Impreso: " + DateTime.Today.ToString("dd/MM/yyyy")


         Me.Cursor = Cursors.Default

         UltraPrintPreviewD.MdiParent = Me.MdiParent
         UltraPrintPreviewD.Show()
         UltraPrintPreviewD.Focus()


      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsmiAExcel_Click(sender As Object, e As EventArgs) Handles tsmiAExcel.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.xls", Name), Text, UltraGridExcelExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub tsmiAPDF_Click(sender As Object, e As EventArgs) Handles tsmiAPDF.Click
      TryCatched(Sub() ugDetalle.Exportar(String.Format("{0}.pdf", Name), Text, UltraGridDocumentExporter1, CargarFiltrosImpresion()))
   End Sub

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      UltraGridPrintDocument1.Footer.TextRight = "Página: " + Me.UltraGridPrintDocument1.PageNumber.ToString()
   End Sub

   Private Sub tsbPreferencias_Click(sender As Object, e As EventArgs) Handles tsbPreferencias.Click
      TryCatched(Sub() PreferenciasCargar(ugDetalle, tsbPreferencias))
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub chkMesCompleto_CheckedChanged(sender As Object, e As EventArgs) Handles chkMesCompleto.CheckedChanged

      Dim FechaTemp As Date

      Try

         If chkMesCompleto.Checked Then

            FechaTemp = New Date(Me.dtpDesde.Value.Year, Me.dtpDesde.Value.Month, 1)
            Me.dtpDesde.Value = FechaTemp

            'Voy 1 Mes para adelante a partir del dia 1, luego bajo 1 Segundo.
            FechaTemp = Me.dtpDesde.Value.AddMonths(1).AddSeconds(-1)
            dtpHasta.Value = FechaTemp

         End If

         Me.dtpDesde.Enabled = Not Me.chkMesCompleto.Checked
         Me.dtpHasta.Enabled = Not Me.chkMesCompleto.Checked

      Catch ex As Exception

         chkMesCompleto.Checked = False

         ShowError(ex)

      End Try

   End Sub

   Private Sub chbMarca_CheckedChanged(sender As Object, e As EventArgs) Handles chbMarca.CheckedChanged

      Me.cmbMarca.Enabled = Me.chbMarca.Checked

      If Not Me.chbMarca.Checked Then
         Me.cmbMarca.SelectedIndex = -1
      Else
         Me.cmbMarca.SelectedIndex = 0
         'Si elijo una marca, limpio el producto seleccionado (hipoteticamente)
         'El Rubro lo dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
         Me.cmbMarca.Focus()
      End If

   End Sub

   Private Sub chbRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbRubro.CheckedChanged

      Me.cmbRubro.Enabled = Me.chbRubro.Checked

      If Not Me.chbRubro.Checked Then
         Me.cmbRubro.SelectedIndex = -1
         chbSubRubro.Checked = False
         chbSubRubro.Enabled = False
      Else
         Me.cmbRubro.SelectedIndex = 0
         'Si elijo una marca, limpio el producto seleccionado (hipotericamente)
         'La Marca la dejo porque puede intencionalmente hacer un filtro combinado
         Me.chbProducto.Checked = False
         chbSubRubro.Enabled = True
         Me.cmbRubro.Focus()
      End If
   End Sub

   Private Sub chbSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubRubro.CheckedChanged

      Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

      If Not Me.chbSubRubro.Checked Then
         Me.cmbSubRubro.SelectedIndex = -1
         chbSubSubRubro.Checked = False
         chbSubSubRubro.Enabled = False
      Else
         If cmbSubRubro.Items.Count > 0 Then
            Me.cmbSubRubro.SelectedIndex = 0
         End If
         chbSubSubRubro.Enabled = True
         Me.cmbSubRubro.Focus()
      End If
   End Sub

   Private Sub chbSubSubRubro_CheckedChanged(sender As Object, e As EventArgs) Handles chbSubSubRubro.CheckedChanged

      Me.cmbSubSubRubro.Enabled = Me.chbSubSubRubro.Checked

      If Not Me.chbSubSubRubro.Checked Then
         Me.cmbSubSubRubro.SelectedIndex = -1
      Else
         If cmbSubRubro.Items.Count > 0 Then
            Me.cmbSubSubRubro.SelectedIndex = 0
         End If
         Me.cmbSubSubRubro.Focus()
      End If

   End Sub

   Private Sub chbTipoComprobante_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoComprobante.CheckedChanged
      Try
         Me.cmbTiposComprobantes.Enabled = Me.chbTipoComprobante.Checked

         If Not Me.chbTipoComprobante.Checked Then
            'Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.SelectedValue = Convert.ToInt32(Entidades.TipoComprobante.ValoresFijosIdTipoComprobante.Todos).ToString()
         Else
            Me.cmbTiposComprobantes.SelectedIndex = -1
            Me.cmbTiposComprobantes.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbLetra_CheckedChanged(sender As Object, e As EventArgs) Handles chbLetra.CheckedChanged
      Me.cboLetra.Enabled = Me.chbLetra.Checked
      If Not Me.chbLetra.Checked Then
         Me.cboLetra.SelectedIndex = -1
      Else
         If Me.cboLetra.Items.Count > 0 Then
            Me.cboLetra.SelectedIndex = 0
         End If
      End If
      Me.cboLetra.Focus()
   End Sub

   Private Sub chbEmisor_CheckedChanged(sender As Object, e As EventArgs) Handles chbEmisor.CheckedChanged
      Me.cmbEmisor.Enabled = Me.chbEmisor.Checked
      If Not Me.chbEmisor.Checked Then
         Me.cmbEmisor.SelectedIndex = -1
      Else
         If Me.cmbEmisor.Items.Count > 0 Then
            Me.cmbEmisor.SelectedIndex = 0
         End If
      End If
      Me.cmbEmisor.Focus()
   End Sub

   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      Me.txtNumero.Enabled = Me.chbNumero.Checked
      If Not Me.chbNumero.Checked Then
         Me.txtNumero.Text = ""
      Else
         Me.txtNumero.Focus()
      End If
   End Sub

   Private Sub chbProducto_CheckedChanged(sender As Object, e As EventArgs) Handles chbProducto.CheckedChanged


      Me.bscCodigoProducto2.Enabled = Me.chbProducto.Checked
      Me.bscProducto2.Enabled = Me.chbProducto.Checked

      'Cuando quito el check del producto, limpio el producto seleccionado (hipoteticamente)
      If Not Me.chbProducto.Checked Then
         Me.bscCodigoProducto2.Text = String.Empty
         Me.bscProducto2.Text = String.Empty
      Else
         'Cuando Marco el producto limpio la marca y el rubro seleccionado (hipoteticamente)
         Me.chbMarca.Checked = False
         Me.chbRubro.Checked = False
         Me.bscCodigoProducto2.Focus()
      End If

   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Reglas.Productos = New Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProducto(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged

      Me.bscCodigoCliente.Enabled = Me.chbCliente.Checked
      Me.bscCliente.Enabled = Me.chbCliente.Checked


      Me.bscCodigoCliente.Text = String.Empty
      Me.bscCodigoCliente.Tag = Nothing
      Me.bscCliente.Text = String.Empty

      Me.bscCodigoCliente.Focus()

   End Sub

   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick, bscCodigoCliente.BuscadorClick
      Dim codigoCliente As Long = -1
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCodigoCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         If Me.bscCodigoCliente.Text.Trim.Length > 0 Then
            codigoCliente = Long.Parse(Me.bscCodigoCliente.Text.Trim())
         End If
         Me.bscCodigoCliente.Datos = oClientes.GetFiltradoPorCodigo(codigoCliente, True, False)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCodigoCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      Try
         Me._publicos.PreparaGrillaClientes2(Me.bscCliente)
         Dim oClientes As Reglas.Clientes = New Reglas.Clientes
         Me.bscCliente.Datos = oClientes.GetFiltradoPorNombre(Me.bscCliente.Text.Trim(), False)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCliente.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosCliente(e.FilaDevuelta, bscCodigoCliente, bscCliente)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbVendedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbVendedor.CheckedChanged
      Me.cmbVendedor.Enabled = Me.chbVendedor.Checked
      If Not Me.chbVendedor.Checked Then
         Me.cmbVendedor.SelectedIndex = -1
      Else
         Me.cmbVendedor.SelectedIndex = 0
         Me.cmbVendedor.Focus()
      End If
   End Sub

   Private Sub chbTransportista_CheckedChanged(sender As Object, e As EventArgs) Handles chbTransportista.CheckedChanged
      Me.cmbTransportista.Enabled = Me.chbTransportista.Checked
      If Not Me.chbTransportista.Checked Then
         Me.cmbTransportista.SelectedIndex = -1
      Else
         Me.cmbTransportista.SelectedIndex = 0
         Me.cmbTransportista.Focus()
      End If
   End Sub

   Private Sub chbUsuario_CheckedChanged(sender As Object, e As EventArgs) Handles chbUsuario.CheckedChanged
      Try
         Me.cmbUsuario.Enabled = Me.chbUsuario.Checked

         If Not Me.chbUsuario.Checked Then
            Me.cmbUsuario.SelectedIndex = -1
         Else
            If Me.cmbUsuario.Items.Count > 0 Then
               Me.cmbUsuario.SelectedIndex = 0
            End If
         End If

         Me.cmbUsuario.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbFormaPago_CheckedChanged(sender As Object, e As EventArgs) Handles chbFormaPago.CheckedChanged

      Try
         Me.cmbFormaPago.Enabled = Me.chbFormaPago.Checked

         If Not Me.chbFormaPago.Checked Then
            Me.cmbFormaPago.SelectedIndex = -1
         Else
            If Me.cmbFormaPago.Items.Count > 0 Then
               Me.cmbFormaPago.SelectedIndex = 0
            End If
         End If

         Me.cmbFormaPago.Focus()

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub chbLote_CheckedChanged(sender As Object, e As EventArgs) Handles chbLote.CheckedChanged
      Try
         Me.bscLote.Enabled = Me.chbLote.Checked
         Me.bscLote.Text = String.Empty
         Me.bscLote.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscLote_BuscadorClick() Handles bscLote.BuscadorClick
      Try
         Me._publicos.PreparaGrillaLotes(Me.bscLote)
         Dim oLote As Reglas.ProductosLotes = New Reglas.ProductosLotes()
         Me.bscLote.Datos = oLote.GetFiltradoPorId(Me.bscLote.Text, Entidades.Usuario.Actual.Sucursal.Id)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscLote_BuscadorSeleccion(sender As Object, e As Eniac.Controles.BuscadorEventArgs) Handles bscLote.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscLote.Text = e.FilaDevuelta.Cells("IdLote").Value.ToString()
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   'Private Sub chbSubRubro_CheckedChanged( sender As Object,  e As EventArgs) Handles chbSubRubro.CheckedChanged
   '   Try
   '      Me.cmbSubRubro.Enabled = Me.chbSubRubro.Checked

   '      If Not Me.chbSubRubro.Checked Then
   '         Me.cmbSubRubro.SelectedIndex = -1
   '      Else
   '         If Me.cmbSubRubro.Items.Count > 0 Then
   '            Me.cmbSubRubro.SelectedIndex = 0
   '         End If
   '      End If

   '      Me.cmbSubRubro.Focus()
   '   Catch ex As Exception
   '      ShowError(ex)
   '   End Try

   'End Sub

   Private Sub chbCantidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbCantidad.CheckedChanged
      Try
         Me.cmbCantidad.Enabled = Me.chbCantidad.Checked

         If Not Me.chbCantidad.Checked Then
            Me.cmbCantidad.SelectedIndex = -1
         Else
            Me.cmbCantidad.SelectedIndex = 0
            Me.cmbCantidad.Focus()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged

      Me.bscCodigoProveedor.Enabled = Me.chbProveedor.Checked
      Me.bscProveedor.Enabled = Me.chbProveedor.Checked

      If Me.chbProveedor.Checked Then
         Me.bscCodigoProveedor.Focus()
      End If

      Me.bscCodigoProveedor.Text = String.Empty
      Me.bscCodigoProveedor.Tag = Nothing
      Me.bscProveedor.Text = String.Empty

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
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores
         Me.bscProveedor.Datos = oProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedorProv_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbZonaGeografica_CheckedChanged(sender As Object, e As EventArgs) Handles chbZonaGeografica.CheckedChanged

      Me.cmbZonaGeografica.Enabled = Me.chbZonaGeografica.Checked

      If Not Me.chbZonaGeografica.Checked Then
         Me.cmbZonaGeografica.SelectedIndex = -1
      Else
         If Me.cmbZonaGeografica.Items.Count > 0 Then
            Me.cmbZonaGeografica.SelectedIndex = 0
         End If
         Me.cmbZonaGeografica.Focus()
      End If

   End Sub

   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged

      Me.bscCodigoLocalidad.Enabled = Me.chbLocalidad.Checked
      Me.bscNombreLocalidad.Enabled = Me.chbLocalidad.Checked

      Me.bscCodigoLocalidad.Text = String.Empty
      Me.bscNombreLocalidad.Text = String.Empty

      If Me.chbLocalidad.Checked Then
         Me.bscCodigoLocalidad.Focus()
      End If

   End Sub

   Private Sub bscCodigoLocalidad_BuscadorClick() Handles bscCodigoLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscCodigoLocalidad)
         Me.bscCodigoLocalidad.Datos = oLocalidades.GetPorCodigo(Integer.Parse("0" & Me.bscCodigoLocalidad.Text))
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscCodigoLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorClick() Handles bscNombreLocalidad.BuscadorClick
      Try
         Dim oLocalidades As Reglas.Localidades = New Reglas.Localidades
         Me._publicos.PreparaGrillaLocalidades(Me.bscNombreLocalidad)
         Me.bscNombreLocalidad.Datos = oLocalidades.GetPorNombre(Me.bscNombreLocalidad.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscNombreLocalidad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreLocalidad.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarLocalidad(e.FilaDevuelta)
            Me.btnConsultar.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbProvincia_CheckedChanged(sender As Object, e As EventArgs) Handles chbProvincia.CheckedChanged

      Me.cmbProvincia.Enabled = Me.chbProvincia.Checked

      If Not Me.chbProvincia.Checked Then
         Me.cmbProvincia.SelectedIndex = -1
      Else
         If Me.cmbProvincia.Items.Count > 0 Then
            Me.cmbProvincia.SelectedIndex = 0
         End If
         Me.cmbProvincia.Focus()
      End If

   End Sub

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click

      Try

         If Me.chbMarca.Checked And Me.cmbMarca.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó una Marca aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbMarca.Focus()
            Exit Sub
         End If

         If Me.chbRubro.Checked And Me.cmbRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un Rubro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbRubro.Focus()
            Exit Sub
         End If

         If Me.chbSubRubro.Checked And Me.cmbSubRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un SubRubro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbSubRubro.Focus()
            Exit Sub
         End If

         If Me.chbSubSubRubro.Checked And Me.cmbSubSubRubro.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: NO seleccionó un SubSubRubro aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbSubSubRubro.Focus()
            Exit Sub
         End If

         If Me.chbProducto.Checked And Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Producto aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoProducto2.Focus()
            Exit Sub
         End If

         If Me.chbCliente.Checked And Not Me.bscCodigoCliente.Selecciono And Not Me.bscCliente.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoCliente.Focus()
            Exit Sub
         End If

         If Me.chbLote.Checked And Not Me.bscLote.Selecciono Then
            MessageBox.Show("ATENCION: NO seleccionó un Lote aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscLote.Focus()
            Exit Sub
         End If

         If chbLetra.Checked And cboLetra.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: NO seleccionó una Letra aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cboLetra.Focus()
            Exit Sub
         End If

         If chbEmisor.Checked And cmbEmisor.SelectedIndex < 0 Then
            MessageBox.Show("ATENCION: NO seleccionó un Emisor aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            cmbEmisor.Focus()
            Exit Sub
         End If

         If chbNumero.Checked And (Not IsNumeric(txtNumero.Text) OrElse Long.Parse(txtNumero.Text) <= 0) Then
            MessageBox.Show("ATENCION: NO ingresó un Número aunque activó ese Filtro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtNumero.Focus()
            Exit Sub
         End If
         If Me.chbPaciente.Checked AndAlso Not Me.bscCodigoPaciente.Selecciono AndAlso Not Me.bscPaciente.Selecciono Then
            ShowMessage("ATENCION: NO ingresó un Paciente aunque activó ese Filtro.")
            bscCodigoPaciente.Focus()
            Exit Sub
         End If
         If Me.chbDoctor.Checked AndAlso Not Me.bscCodigoDoctor.Selecciono AndAlso Not Me.bscDoctor.Selecciono Then
            ShowMessage("ATENCION: NO ingresó un Doctor aunque activó ese Filtro.")
            bscCodigoDoctor.Focus()
            Exit Sub
         End If

         Me.chkExpandAll.Enabled = True
         Me.chkExpandAll.Checked = False

         Me.Cursor = Cursors.WaitCursor

         Me.CargaGrillaDetalle()

         With Me.ugDetalle.DisplayLayout.Bands(0)
            .Columns("Cantidad").Format = "N" + Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesMostrarEnCantidad.ToString()
         End With


         If ugDetalle.Rows.Count > 0 Or _paraBusqueda Then
            'Me.btnConsultar.Focus()
            txtFiltros.AutoSize = True
            txtFiltros.Text = CargarFiltrosImpresion()
            TabControl1.SelectedTab = tbpDatos
            ugDetalle.Focus()
         Else
            Me.Cursor = Cursors.Default
            MessageBox.Show("NO hay registros que cumplan con la seleccion !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

      Catch ex As Exception
         Me.tssRegistros.Text = "0 Registros"
         ShowError(ex)
      Finally
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

   Private Sub ugDetalle_InitializeLayout(sender As Object, e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles ugDetalle.InitializeLayout

      e.Layout.Override.SpecialRowSeparator = SpecialRowSeparator.SummaryRow

      e.Layout.Override.SpecialRowSeparatorAppearance.BackColor = Color.FromArgb(218, 217, 241)

      e.Layout.Override.SpecialRowSeparatorHeight = 6

      e.Layout.Override.BorderStyleSpecialRowSeparator = UIElementBorderStyle.RaisedSoft

      e.Layout.ViewStyle = ViewStyle.SingleBand

      e.Layout.ViewStyleBand = ViewStyleBand.OutlookGroupBy

   End Sub

   Private Sub chbCategoria_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoria.CheckedChanged
      Me.cmbCategoria.Enabled = Me.chbCategoria.Checked

      If Not Me.chbCategoria.Checked Then
         Me.cmbCategoria.SelectedIndex = -1
      Else
         If Me.cmbCategoria.Items.Count > 0 Then
            Me.cmbCategoria.SelectedIndex = 0
         End If

         Me.cmbCategoria.Focus()

      End If
   End Sub

   Private Sub chbListaPrecios_CheckedChanged(sender As Object, e As EventArgs) Handles chbListaPrecios.CheckedChanged
      Try
         Me.cmbListaPrecios.Enabled = Me.chbListaPrecios.Checked

         If Not Me.chbListaPrecios.Checked Then
            Me.cmbListaPrecios.SelectedIndex = -1
         Else
            Me.cmbListaPrecios.SelectedIndex = 0
            Me.cmbListaPrecios.Focus()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbTipoOperacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoOperacion.CheckedChanged
      Try
         Me.cmbTipoOperacion.Enabled = Me.chbTipoOperacion.Checked

         If Not Me.chbTipoOperacion.Checked Then
            Me.cmbTipoOperacion.SelectedIndex = -1
            'Me.cmbNota.Text = ""
            'Me.cmbNota.Enabled = True
         Else
            'Me.cmbNota.Enabled = False
            If Me.cmbTipoOperacion.Items.Count > 0 Then
               Me.cmbTipoOperacion.SelectedIndex = 0
            End If
         End If

         Me.cmbTipoOperacion.Focus()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
      Try
         If cmbTipoOperacion.SelectedIndex > -1 Then
            _publicos.CargaComboObservaciones(cmbNota, DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones))
         Else
            cmbNota.Items.Clear()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarDatosCliente(dr As DataGridViewRow, controlCodigo As Eniac.Controles.Buscador2, controlNombre As Eniac.Controles.Buscador2)
      If dr IsNot Nothing Then
         controlNombre.Text = dr.Cells("NombreCliente").Value.ToString()
         controlCodigo.Text = dr.Cells("CodigoCliente").Value.ToString()
         controlCodigo.Tag = dr.Cells("IdCliente").Value.ToString()
         controlNombre.Enabled = False
         controlCodigo.Enabled = False
         controlNombre.Selecciono = True
         controlCodigo.Selecciono = True
      End If
   End Sub

   Private Sub CargarDatosProducto(dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      Me.bscProducto2.Enabled = False
      Me.bscCodigoProducto2.Enabled = False
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      Me.bscProveedor.Enabled = False
      Me.bscCodigoProveedor.Enabled = False
   End Sub

   Private Sub CargarLocalidad(dr As DataGridViewRow)
      Me.bscCodigoLocalidad.Text = dr.Cells("IdLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Text = dr.Cells("NombreLocalidad").Value.ToString()
      Me.bscNombreLocalidad.Enabled = False
      Me.bscCodigoLocalidad.Enabled = False
   End Sub

   Private Sub RefrescarDatosGrilla()

      chkMesCompleto.Checked = False
      dtpDesde.Value = Date.Today
      dtpHasta.Value = Date.Today.UltimoSegundoDelDia()

      chbTipoComprobante.Checked = False

      chbProducto.Checked = False
      chbMarca.Checked = False
      chbRubro.Checked = False
      chbProducto.Checked = False

      bscLote.Text = String.Empty

      cmbIngresosBrutos.SelectedIndex = 0
      cmbProdDescRec.SelectedIndex = 0

      chbCantidad.Checked = False

      chbCliente.Checked = False

      If IdUsuario = "" Then
         chbVendedor.Checked = False
         cmbOrigenVendedor.SelectedValue = Entidades.OrigenFK.Actual
      End If

      cmbGrabanLibro.SelectedIndex = 0
      cmbAfectaCaja.SelectedIndex = 1
      cmbTipoCliente.SelectedIndex = 0

      chbFormaPago.Checked = False
      chbUsuario.Checked = False
      chbProveedor.Checked = False
      chbZonaGeografica.Checked = False
      chbTransportista.Checked = False

      chbLocalidad.Checked = False
      chbProvincia.Checked = False
      chbListaPrecios.Checked = False

      chkExpandAll.Checked = False
      chkExpandAll.Enabled = False
      chbCategoria.Checked = False
      cmbOrigenCategoria.SelectedValue = Entidades.OrigenFK.Actual

      'Me.rbtCatActual.Checked = True

      cmbNota.Text = String.Empty
      chbTipoOperacion.Checked = False

      If Not Me.ugDetalle.DataSource Is Nothing Then
         'Me.UltraDataSource2
         DirectCast(Me.ugDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'Me.txtSubtotal.Text = "0.00"
      'Me.txtImpuestos.Text = "0.00"
      'Me.txtTotal.Text = "0.00"

      TabControl1.SelectedTab = tbpFiltros

      'Se puede resetear el control de Sucursal de dos formas
      '1.- Seleccionando el valor         - Si tenemos que llevarlo a un valor que no sea el default
      'cmbSucursal.SelectedValue = actual.Sucursal.IdSucursal
      '2.- Ejecutando el método Refrescar - Si tenemos que llevarlo al valor default
      cmbSucursal.Refrescar()
      chbConIVA.Checked = Reglas.Publicos.ConsultarPreciosConIVA
      dtpDesde.Focus()

      chbPaciente.Checked = False
      chbDoctor.Checked = False
      chbFechaCirugia.Checked = False

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargarColumnasASumar()
      ugDetalle.AgregarTotalesSuma({"ImporteTotalNeto", "ImporteImpuesto", "ImporteImpuestoInterno", "ImporteTotal", "Tamano", "Cantidad", "Kilos",
                                    "ImporteDR1", "ImporteDR1ConIva", "ImporteDR2", "ImporteDR2ConIva", "ImporteDRGral", "ImporteDRGralConIva"})
   End Sub

   Private Sub CargaGrillaDetalle()

      Dim idProducto As String = String.Empty
      Dim idMarca As Integer = 0
      Dim idModelo As Integer = 0
      Dim idRubro As Integer = 0
      Dim idSubRubro As Integer = 0
      Dim idSubSubRubro As Integer = 0
      Dim lote As String = String.Empty

      Dim idCliente As Long = 0

      Dim tipoComprobante As String = String.Empty

      Dim idVendedor As Integer = 0
      Dim origenVendedor As Entidades.OrigenFK
      Dim idFormaDePago As Integer = 0

      Dim idUsuario As String = String.Empty

      Dim porcUtilidadDesde As Decimal = -1
      Dim porcUtilidadHasta As Decimal = -1

      Dim cantidad As String = String.Empty

      Dim idProveedor As Long = 0
      Dim idTransportista As Integer = 0
      Dim idZonaGeografica As String = String.Empty

      Dim idLocalidad As Integer = 0
      Dim idProvincia As String = String.Empty

      Dim idCategoria As Integer = 0
      Dim origenCategoria As Entidades.OrigenFK
      Dim listaPrecios As String = ""
      Dim tipoCategoria As String = String.Empty

      Dim tipoOperacion As Entidades.Producto.TiposOperaciones?

      'Dim EsComercial As String = "TODOS"
      Dim esComercial As Boolean?

      If Me.chbProducto.Checked Then
         idProducto = Me.bscCodigoProducto2.Text.Trim()
      End If

      If Me.chbMarca.Checked Then
         idMarca = Integer.Parse(Me.cmbMarca.SelectedValue.ToString())
      End If

      If Me.chbRubro.Checked Then
         idRubro = Integer.Parse(Me.cmbRubro.SelectedValue.ToString())
      End If

      If Me.cmbSubRubro.Enabled Then
         idSubRubro = Integer.Parse(Me.cmbSubRubro.SelectedValue.ToString())
      End If

      If Me.cmbSubSubRubro.Enabled Then
         idSubSubRubro = Integer.Parse(Me.cmbSubSubRubro.SelectedValue.ToString())
      End If

      If Me.chbLote.Checked Then
         lote = Me.bscLote.Text
      End If

      If Me.chbCliente.Checked Then
         idCliente = Long.Parse(Me.bscCodigoCliente.Tag.ToString())
      End If

      If Me.chbVendedor.Checked Then
         idVendedor = DirectCast(Me.cmbVendedor.SelectedItem, Entidades.Empleado).IdEmpleado
      End If

      If chbTransportista.Checked Then
         idTransportista = Integer.Parse(cmbTransportista.SelectedValue.ToString())
      End If

      If Me.cmbZonaGeografica.Enabled Then
         idZonaGeografica = DirectCast(Me.cmbZonaGeografica.SelectedItem, Entidades.ZonaGeografica).IdZonaGeografica
      End If

      If Me.cmbFormaPago.Enabled Then
         idFormaDePago = Integer.Parse(Me.cmbFormaPago.SelectedValue.ToString())
      End If

      If Me.cmbUsuario.Enabled Then
         'IdUsuario = DirectCast(Me.cmbUsuario.SelectedItem, Entidades.Usuario).Usuario
         idUsuario = Me.cmbUsuario.SelectedValue.ToString()
      End If

      Select Case Me.cmbCantidad.SelectedIndex
         Case 0
            cantidad = " < 0"
         Case 1
            cantidad = " = 0"
         Case 2
            cantidad = " > 0"
      End Select

      If Me.chbProveedor.Checked Then
         idProveedor = Long.Parse(Me.bscCodigoProveedor.Tag.ToString())
      End If

      If Me.chbLocalidad.Checked Then
         idLocalidad = Integer.Parse(Me.bscCodigoLocalidad.Text)
      End If

      If Me.chbProvincia.Checked Then
         idProvincia = Me.cmbProvincia.SelectedValue.ToString()
      End If

      If Me.cmbCategoria.Enabled Then
         idCategoria = Integer.Parse(Me.cmbCategoria.SelectedValue.ToString())
      End If

      If Me.cmbListaPrecios.Enabled Then
         listaPrecios = Me.cmbListaPrecios.SelectedValue.ToString()
      End If

      If cmbTipoOperacion.Enabled Then
         tipoOperacion = DirectCast(cmbTipoOperacion.SelectedItem, Entidades.Producto.TiposOperaciones)
      End If

      '# Historia Clínica
      Dim idPaciente As Long?
      Dim idDoctor As Long?
      Dim fechaCirugia As Date?
      If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then

         If Me.chbPaciente.Checked AndAlso Me.bscCodigoPaciente.Selecciono AndAlso Me.bscPaciente.Selecciono Then
            idPaciente = Long.Parse(Me.bscCodigoPaciente.Tag.ToString())
         End If
         If Me.chbDoctor.Checked AndAlso Me.bscCodigoDoctor.Selecciono AndAlso Me.bscDoctor.Selecciono Then
            idDoctor = Long.Parse(Me.bscCodigoDoctor.Tag.ToString())
         End If
         If Me.chbFechaCirugia.Checked Then
            fechaCirugia = Me.dtpFechaCirugia.Value
         End If

      End If

      'TipoCategoria = IIf(Me.rbtCatMovimiento.Checked, "MOVIMIENTO", "ACTUAL").ToString()
      origenVendedor = DirectCast(cmbOrigenVendedor.SelectedValue, Entidades.OrigenFK)
      origenCategoria = DirectCast(cmbOrigenCategoria.SelectedValue, Entidades.OrigenFK)

      Dim tipoCliente = cmbTipoCliente.ValorSeleccionado(Of Entidades.Cliente.ClienteVinculado)()

      Dim dtDetalle As DataTable, dt As DataTable

      Dim tiposComprobantes As List(Of Entidades.TipoComprobante) = New List(Of Entidades.TipoComprobante)()
      tiposComprobantes.AddRange(cmbTiposComprobantes.GetTiposComprobantes())

      dtDetalle = GetRegla().GetDetallePorProductos(
                           cmbSucursal.GetSucursales(), dtpDesde.Value, dtpHasta.Value,
                           idProducto, idMarca, idModelo, idRubro, idSubRubro, idSubSubRubro,
                           idZonaGeografica,
                           tipoComprobante,
                           idVendedor, origenVendedor, idCliente,
                           cmbGrabanLibro.Text, cmbAfectaCaja.Text, idFormaDePago, idUsuario,
                           porcUtilidadDesde, porcUtilidadHasta,
                           cantidad, cmbIngresosBrutos.Text, cmbProdDescRec.Text,
                           idProveedor, idLocalidad, idProvincia,
                           idCategoria, listaPrecios, origenCategoria,
                           tiposComprobantes,
                           esComercial, idTransportista,
                           tipoOperacion,
                           cmbNota.Text,
                           If(chbLetra.Checked, cboLetra.Text, ""),
                           If(chbEmisor.Checked, Short.Parse(cmbEmisor.Text), 0S),
                           If(chbNumero.Checked, Long.Parse(txtNumero.Text), 0),
                           cmbCajas.GetCajas(True),
                           -1,
                           String.Empty,
                           idPaciente, idDoctor, fechaCirugia,
                           tipoCliente,
                           productoEsComercial:=Entidades.Publicos.SiNoTodos.TODOS)

      dt = Me.CrearDT()
      CopiaDT(dtDetalle, dt)
      ugDetalle.DataSource = dt

      FormatearGrilla()

      'Muestro la columna si algun registro tiene valor.
      Me.ugDetalle.DisplayLayout.Bands(0).Columns("ImporteImpuestoInterno").Hidden = dt.Select("ImporteImpuestoInterno <> 0").Length = 0

      ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.VentaProducto.Columnas.IdCentroCosto.ToString()).Hidden = Not _utilizaCentroCostos
      ugDetalle.DisplayLayout.Bands(0).Columns(Entidades.ContabilidadCentroCosto.Columnas.NombreCentroCosto.ToString()).Hidden = Not _utilizaCentroCostos

      Me.tssRegistros.Text = Me.ugDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Protected Overridable Function GetRegla() As Eniac.Reglas.VentasProductos
      Return New Eniac.Reglas.VentasProductos()
   End Function

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
      drCl("NombreClienteVinculado") = dr("NombreClienteVinculado").ToString()

      '-- REQ-34155.- -----------------------------------------------------
      drCl("TelefonoCliente") = dr("TelefonoCliente").ToString()
      '--------------------------------------------------------------------
      drCl("NombreZonaGeografica") = dr("NombreZonaGeografica").ToString()
      drCl("NombreCategoriaFiscal") = dr("NombreCategoriaFiscal").ToString()
      drCl("FormaDePago") = dr("FormaDePago").ToString()
      drCl("NombreVendedor") = dr("NombreEmpleado").ToString()
      drCl("IdProducto") = dr("IdProducto").ToString()
      drCl("NombreProducto") = dr("NombreProducto").ToString()
      drCl("NombreActualProducto") = dr("NombreActualProducto").ToString()
      drCl("Orden") = dr("Orden")
      If Not String.IsNullOrEmpty(dr("IdUnidadDeMedida").ToString()) Then
         drCl("Tamano") = Decimal.Parse(dr("Tamano").ToString())
         drCl("IdUnidadDeMedida") = dr("IdUnidadDeMedida")
      End If
      drCl("CodigoDeBarras") = dr("CodigoDeBarras")
      drCl("NombreMarca") = dr("NombreMarca").ToString()
      drCl("NombreRubro") = dr("NombreRubro").ToString()
      drCl("NombreSubRubro") = dr("NombreSubRubro").ToString()
      drCl("NombreSubSubRubro") = dr("NombreSubSubRubro").ToString()
      drCl("Cantidad") = Decimal.Parse(dr("Cantidad").ToString())
      drCl("PrecioLista") = Decimal.Parse(dr("PrecioLista").ToString())
      drCl("PrecioListaConIva") = Decimal.Parse(dr("PrecioListaConIva").ToString())
      drCl("Precio") = Decimal.Parse(dr("Precio").ToString())
      drCl("PrecioConIVA") = Decimal.Parse(dr("PrecioConIva").ToString())
      drCl("DescuentoRecargoPorc") = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
      drCl("DescuentoRecargoPorc2") = Decimal.Parse(dr("DescuentoRecargoPorc2").ToString())
      drCl("DescuentoRecargoPorcGral") = Decimal.Parse(dr("DescuentoRecargoPorcGral").ToString())

      'Dim oCategoriaFiscalEmpresa As Entidades.CategoriaFiscal = New Reglas.CategoriasFiscales()._GetUno(Publicos.CategoriaFiscalEmpresa)
      'Dim ivaDiscriminado As Boolean
      'ivaDiscriminado = oCategoriaFiscalEmpresa.IvaDiscriminado

      'If ivaDiscriminado Then
      drCl("ImporteDR1") = Decimal.Parse(dr("ImporteDR1").ToString()) '-.PE-32144.-
      drCl("ImporteDR2") = Decimal.Parse(dr("ImporteDR2").ToString()) '-.PE-32144.-
      drCl("ImporteDRGral") = Decimal.Parse(dr("ImporteDRGral").ToString()) '-.PE-32144.-
      'Else
      drCl("ImporteDR1ConIva") = Decimal.Parse(dr("ImporteDR1ConIva").ToString()) '-.PE-32144.- Con Iva 
      drCl("ImporteDR2ConIva") = Decimal.Parse(dr("ImporteDR2ConIva").ToString()) '-.PE-32144.- Con Iva
      drCl("ImporteDRGralConIva") = Decimal.Parse(dr("ImporteDRGralConIva").ToString()) '-.PE-32144.- Con Iva
      'End If

      drCl("PrecioNeto") = Decimal.Parse(dr("PrecioNeto").ToString())
      drCl("PrecioNetoConIva") = Decimal.Parse(dr("PrecioNetoConIva").ToString())
      drCl("AlicuotaImpuesto") = Decimal.Parse(dr("AlicuotaImpuesto").ToString())
      drCl("ImporteTotalNeto") = Decimal.Parse(dr("ImporteTotalNeto").ToString())
      drCl("ImporteImpuesto") = Decimal.Parse(dr("ImporteImpuesto").ToString())
      drCl("ImporteImpuestoInterno") = Decimal.Parse(dr("ImporteImpuestoInterno").ToString())
      drCl("ImporteTotal") = Decimal.Parse(dr("ImporteTotalNeto").ToString()) + Decimal.Parse(dr("ImporteImpuesto").ToString()) + Decimal.Parse(dr("ImporteImpuestoInterno").ToString())
      drCl("Usuario") = dr("Usuario").ToString()
      drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
      drCl("NombreProvincia") = dr("NombreProvincia").ToString()
      drCl("Direccion") = dr("Direccion").ToString()
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

      drCl("IdEstadoVenta") = dr("IdEstadoVenta")
      drCl("NombreEstadoVenta") = dr("NombreEstadoVenta")

      If Not IsDBNull(dr("IdPaciente")) Then
         drCl("IdPaciente") = dr.Field(Of Long)("IdPaciente")
         drCl("NombrePaciente") = dr.Field(Of String)("NombrePaciente")
      End If
      If Not IsDBNull(dr("IdDoctor")) Then
         drCl("IdDoctor") = dr.Field(Of Long)("IdDoctor")
         drCl("NombreDoctor") = dr.Field(Of String)("NombreDoctor")
      End If
      If Not IsDBNull(dr("FechaCirugia")) Then
         drCl("FechaCirugia") = dr.Field(Of Date)("FechaCirugia")
      End If
      '-- REQ-35222.- ------------------------------------------------------------
      drCl("IdaAtributoProducto01") = dr("IdaAtributoProducto01")
      drCl("DescripcionAtributo01") = dr("DescripcionAtributo01")
      drCl("IdaAtributoProducto02") = dr("IdaAtributoProducto02")
      drCl("DescripcionAtributo02") = dr("DescripcionAtributo02")
      drCl("IdaAtributoProducto03") = dr("IdaAtributoProducto03")
      drCl("DescripcionAtributo03") = dr("DescripcionAtributo03")
      drCl("IdaAtributoProducto04") = dr("IdaAtributoProducto04")
      drCl("DescripcionAtributo04") = dr("DescripcionAtributo04")
      '---------------------------------------------------------------------------

      drCl("ProveedorHabitual") = dr("ProveedorHabitual")
      drCl("CodigoProductoProveedor") = dr("CodigoProductoProveedor")

      drCl("NumeroOrdenCompra") = dr("NumeroOrdenCompra")
      drCl("ProveedorOC") = dr("ProveedorOC")

      drCl(Entidades.VentaProducto.Columnas.Kilos.ToString()) = dr.Field(Of Decimal)(Entidades.VentaProducto.Columnas.Kilos.ToString())

   End Sub

   Protected Overridable Function CrearDT() As DataTable
      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Ver")
         .Columns.Add("Imprimir")
         .Columns.Add("VerEstandar")
         .Columns.Add("IdSucursal", GetType(Integer))
         .Columns.Add("Fecha", GetType(Date))
         .Columns.Add("IdTipoComprobante", GetType(String))
         .Columns.Add("TipoComprobante", GetType(String))
         .Columns.Add("Letra", GetType(String))
         .Columns.Add("CentroEmisor", GetType(Integer))
         .Columns.Add("NumeroComprobante", GetType(Long))
         .Columns.Add("IdCliente", GetType(Long))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("NombreClienteVinculado", GetType(String))

         '--REQ-34155.- ----------------------------------
         .Columns.Add("TelefonoCliente", GetType(String))
         '------------------------------------------------
         .Columns.Add("NombreZonaGeografica", GetType(String))
         .Columns.Add("NombreCategoriaFiscal", GetType(String))
         .Columns.Add("FormaDePago", GetType(String))
         .Columns.Add("NombreVendedor", GetType(String))
         .Columns.Add("IdProducto", GetType(String))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("NombreActualProducto", GetType(String))
         .Columns.Add("Orden", GetType(Integer))
         .Columns.Add("Tamano", GetType(Decimal))
         .Columns.Add("CodigoDeBarras", GetType(String))
         .Columns.Add("IdUnidadDeMedida", GetType(String))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("NombreSubRubro", GetType(String))
         .Columns.Add("NombreSubSubRubro", GetType(String))
         .Columns.Add("Cantidad", GetType(Decimal))
         '.AppendLine("      ,VP.Costo")
         .Columns.Add("PrecioLista", GetType(Decimal))
         .Columns.Add("PrecioListaConIva", GetType(Decimal))
         .Columns.Add("Precio", GetType(Decimal))
         .Columns.Add("PrecioConIva", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorc2", GetType(Decimal))
         .Columns.Add("DescuentoRecargoPorcGral", GetType(Decimal))
         .Columns.Add("ImporteDR1", GetType(Decimal)) '-.PE-32144.-
         .Columns.Add("ImporteDR2", GetType(Decimal)) '-.PE-32144.-
         .Columns.Add("ImporteDRGral", GetType(Decimal)) '-.PE-32144.-
         .Columns.Add("ImporteDR1ConIva", GetType(Decimal)) '-.PE-32144.-
         .Columns.Add("ImporteDR2ConIva", GetType(Decimal)) '-.PE-32144.-
         .Columns.Add("ImporteDRGralConIva", GetType(Decimal)) '-.PE-32144.-
         .Columns.Add("PrecioNeto", GetType(Decimal))
         .Columns.Add("PrecioNetoConIva", GetType(Decimal))

         '.AppendLine("      ,VP.Utilidad")
         .Columns.Add("AlicuotaImpuesto", GetType(Decimal))
         .Columns.Add("ImporteTotalNeto", GetType(Decimal))
         .Columns.Add("ImporteImpuesto", GetType(Decimal))
         .Columns.Add("ImporteImpuestoInterno", GetType(Decimal))
         .Columns.Add("ImporteTotal", GetType(Decimal))
         .Columns.Add("Usuario", GetType(String))
         .Columns.Add("NombreLocalidad", GetType(String))
         .Columns.Add("NombreProvincia", GetType(String))
         .Columns.Add("Direccion", GetType(String))
         .Columns.Add("NombreListaPrecios", GetType(String))
         .Columns.Add("NombreCategoria", GetType(String))

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
         .Columns.Add("IdEstadoVenta", GetType(Integer))
         .Columns.Add("NombreEstadoVenta", GetType(String))

         .Columns.Add("IdPaciente", GetType(Long))
         .Columns.Add("IdDoctor", GetType(Long))
         .Columns.Add("NombrePaciente", GetType(String))
         .Columns.Add("NombreDoctor", GetType(String))
         .Columns.Add("FechaCirugia", GetType(Date))
         '-- REQ-35222.- -----------------------------------------------------------
         .Columns.Add("IdaAtributoProducto01", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo01", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto02", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo02", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto03", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo03", System.Type.GetType("System.String"))
         .Columns.Add("IdaAtributoProducto04", System.Type.GetType("System.String"))
         .Columns.Add("DescripcionAtributo04", System.Type.GetType("System.String"))
         '--------------------------------------------------------------------------

         .Columns.Add("ProveedorHabitual", GetType(String))
         .Columns.Add("CodigoProductoProveedor", GetType(String))

         .Columns.Add("NumeroOrdenCompra", GetType(String))
         .Columns.Add("ProveedorOC", GetType(String))

         .Columns.Add(Entidades.VentaProducto.Columnas.Kilos.ToString(), GetType(Decimal))
      End With

      Return dtTemp
   End Function

   Protected Overridable Sub FormatearGrilla()

   End Sub

   Private Function CargarFiltrosImpresion() As String

      Dim filtro As System.Text.StringBuilder = New System.Text.StringBuilder()
      Dim Primero As Boolean = True
      With filtro

         cmbSucursal.CargarFiltrosImpresionSucursales(filtro, True, False)

         .AppendFormat("Fecha: Desde {0} Hasta {1} - ", Me.dtpDesde.Text, dtpHasta.Text)

         cmbTiposComprobantes.CargarFiltrosImpresionTiposComprobantes(filtro, True, False)

         If chbLetra.Checked Then
            .AppendFormat(" Letra: {0} - ", cboLetra.Text)
         End If

         If chbEmisor.Checked Then
            .AppendFormat(" Emisor: {0} - ", cmbEmisor.Text)
         End If

         If chbNumero.Checked Then
            .AppendFormat(" Número: {0} - ", txtNumero.Text)
         End If

         If Me.bscCodigoProducto2.Text.Length > 0 And Me.bscProducto2.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoProducto2.Text, Me.bscProducto2.Text)
         End If

         If Me.cmbVendedor.SelectedIndex >= 0 Then
            .AppendFormat(" Vendedor: {0} - ", Me.cmbVendedor.Text)
         End If

         If Me.cmbTransportista.SelectedIndex >= 0 Then
            .AppendFormat(" Transportista: {0} - ", Me.cmbTransportista.Text)
         End If

         If Me.cmbAfectaCaja.SelectedIndex > 0 Then
            .AppendFormat(" Afecta Caja: {0} -", Me.cmbAfectaCaja.Text)
         End If

         If Me.cmbGrabanLibro.SelectedIndex > 0 Then     '0 Es TODOS
            .AppendFormat(" Graban Libro: {0} - ", Me.cmbGrabanLibro.Text)
         End If

         If Me.cmbUsuario.SelectedIndex >= 0 Then
            .AppendFormat(" Usuario: {0} - ", Me.cmbUsuario.Text)
         End If

         If Me.cmbFormaPago.SelectedIndex >= 0 Then
            .AppendFormat(" Forma de Pago: {0} -", Me.cmbFormaPago.Text)
         End If

         If Me.cmbIngresosBrutos.SelectedIndex > 0 Then
            .AppendFormat(" Ingresos Brutos: {0} -", Me.cmbIngresosBrutos.Text)
         End If

         If Me.cmbZonaGeografica.SelectedIndex >= 0 Then
            .AppendFormat(" Zona Geografica: {0} -", Me.cmbZonaGeografica.Text)
         End If

         If Me.cmbMarca.SelectedIndex >= 0 Then
            .AppendFormat(" Marca: {0} -", Me.cmbMarca.Text)
         End If

         If Me.cmbRubro.SelectedIndex >= 0 Then
            .AppendFormat(" Rubro: {0} -", Me.cmbRubro.Text)
         End If

         If Me.cmbSubRubro.SelectedIndex >= 0 Then
            .AppendFormat(" SubRubro: {0} -", Me.cmbSubRubro.Text)
         End If

         If Me.cmbSubSubRubro.SelectedIndex >= 0 Then
            .AppendFormat(" SubSubRubro: {0} -", Me.cmbSubSubRubro.Text)
         End If

         If Me.cmbProvincia.SelectedIndex >= 0 Then
            .AppendFormat(" Provincia: {0} -", Me.cmbProvincia.Text)
         End If

         If Me.cmbListaPrecios.SelectedIndex >= 0 Then
            .AppendFormat(" Lista de Precios: {0} -", Me.cmbListaPrecios.Text)
         End If

         If Me.cmbCantidad.SelectedIndex >= 0 Then
            .AppendFormat(" Cantidad: {0} -", Me.cmbCantidad.Text)
         End If

         If Me.bscLote.Text.Length > 0 Then
            .AppendFormat(" Lote: {0} ", Me.bscLote.Text)
         End If

         If Me.cmbProdDescRec.SelectedIndex > 0 Then
            .AppendFormat(" Descuento / Recargo: {0} -", Me.cmbProdDescRec.Text)
         End If

         If Me.bscCodigoCliente.Text.Length > 0 And Me.bscCliente.Text.Length > 0 Then
            .AppendFormat(" Cliente: {0} - {1} - ", Me.bscCodigoCliente.Text, Me.bscCliente.Text)
         End If

         If Me.bscCodigoProveedor.Text.Length > 0 And Me.bscProveedor.Text.Length > 0 Then
            .AppendFormat(" Proveedor: {0} - {1} - ", Me.bscCodigoProveedor.Text, Me.bscProveedor.Text)
         End If

         If Me.bscCodigoLocalidad.Text.Length > 0 And Me.bscNombreLocalidad.Text.Length > 0 Then
            .AppendFormat(" Localidad: {0} - {1} - ", Me.bscCodigoLocalidad.Text, Me.bscNombreLocalidad.Text)
         End If

         If Me.chbCategoria.Checked Then
            .AppendFormat(" Categoría {0} - ", Me.cmbCategoria.Text)
         End If

         If Reglas.Publicos.FacturacionMuestraHistoriaClinica Then
            If Me.chbPaciente.Checked Then
               .AppendFormat(" Paciente: {0} - ", Me.bscPaciente.Text)
            End If
            If Me.chbDoctor.Checked Then
               .AppendFormat(" Doctor: {0} - ", Me.bscDoctor.Text)
            End If
            If Me.chbFechaCirugia.Checked Then
               .AppendFormat(" Fecha de Cirugía: {0} - ", Me.dtpFechaCirugia.Value.ToString())
            End If
         End If

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

#End Region

   Public Function ShowDialogParaBusqueda(idCliente As Long?, codigoCliente As Long?, idProducto As String) As DialogResult

      _codigoCliente = codigoCliente
      _idProducto = idProducto

      _paraBusqueda = True

      Return Me.ShowDialog()
   End Function

   Private Sub ugDetalle_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalle.ClickCellButton
      If e.Cell.Row.Index <> -1 Then

         Try
            Me.Cursor = Cursors.WaitCursor
            Dim oVentas As Reglas.Ventas = New Reglas.Ventas()
            Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)

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

   Private Sub cmbRubro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbRubro.SelectedValueChanged
      If cmbRubro.SelectedIndex < 0 Then
         cmbSubRubro.SelectedIndex = -1
      Else
         _publicos.CargaComboSubRubros(cmbSubRubro, False, False, {DirectCast(cmbRubro.SelectedItem, Entidades.Rubro)})
      End If
   End Sub

   Private Sub cmbSubRubro_SelectedValueChanged(sender As Object, e As EventArgs) Handles cmbSubRubro.SelectedValueChanged
      If cmbSubRubro.SelectedIndex < 0 Then
         cmbSubSubRubro.SelectedIndex = -1
      Else
         _publicos.CargaComboSubSubRubros(cmbSubSubRubro, False, False, DirectCast(cmbSubRubro.SelectedItem, Entidades.SubRubro).IdSubRubro)
      End If
   End Sub

   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      Try
         If cmbSucursal.SelectedIndex > 0 Then
            Dim rubros As Entidades.Sucursal() = cmbSucursal.GetSucursales()
            'If rubros.Length = 1 Then
            cmbCajas.Inicializar(cmbSucursal.GetSucursales(), blnMiraUsuario:=True, blnMiraPC:=False, blnCajasModificables:=False)
            'End If
         End If
         cmbCajas.SelectedValue = CInt(Entidades.Sucursal.ValoresFijosIdSucursal.Todos)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ugDetalle_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugDetalle.DoubleClickCell
      Try
         If e.Cell.Row.Index <> -1 Then
            'CONDICION PARA QUE SOLO SE CIERRE DE LA PANTALLA DE DONDE ES INVOCADA
            'La utilizan ucNovedadesService, PedidosClientesV2, FacturacionV2
            Dim dr As DataRow = ugDetalle.FilaSeleccionada(Of DataRow)(e.Cell.Row)
            Producto = dr("IdProducto").ToString()
            IdTipoComprobante = dr("IdtipoComprobante").ToString()
            Letra = dr("Letra").ToString()
            CentroEmisor = Short.Parse(dr("CentroEmisor").ToString())
            NumeroComprobante = Long.Parse(dr("NumeroComprobante").ToString())
            DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub chbConIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbConIVA.CheckedChanged
      ugDetalle.DisplayLayout.Bands(0).Columns("Precio").Hidden = chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("PrecioConIva").Hidden = Not chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("PrecioLista").Hidden = chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("PrecioListaConIva").Hidden = Not chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("PrecioNeto").Hidden = chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("PrecioNetoConIva").Hidden = Not chbConIVA.Checked

      ugDetalle.DisplayLayout.Bands(0).Columns("ImporteDR1").Hidden = chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("ImporteDR1ConIva").Hidden = Not chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("ImporteDR2").Hidden = chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("ImporteDR2ConIva").Hidden = Not chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("ImporteDRGral").Hidden = chbConIVA.Checked
      ugDetalle.DisplayLayout.Bands(0).Columns("ImporteDRGralConIva").Hidden = Not chbConIVA.Checked

   End Sub
End Class
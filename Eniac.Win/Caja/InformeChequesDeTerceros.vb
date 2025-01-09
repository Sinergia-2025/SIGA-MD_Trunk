Public Class InformeChequesDeTerceros

#Region "Campos"

   Private _publicos As Publicos
   Public ConsultarAutomaticamente As Boolean = False
   Public ConsultarAutomaticamenteDesdeRecibos As Boolean = False
   Private _filtroMultiplesEstados As MFMarcas

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New Publicos()

            'Me._publicos.CargaComboEstadosCheques(Me.cmbEstado)

            'Dim TodasLasCajas As Integer = New Reglas.CajasNombres().GetAll(actual.Sucursal.IdSucursal).Rows.Count
            'If TodasLasCajas <> Me.cmbCajas.Items.Count Then
            '   Me.chbCaja.Checked = True
            '   Me.chbCaja.Enabled = False  'Para que no pueda modificarlo manualmente
            'End If

            dtpFechaCobroDesde.Value = Date.Today
            dtpFechaCobroHasta.Value = Date.Today

            _publicos.CargaComboLocalidades(cmbLocalidad)
            _publicos.CargaComboBancos(cmbBanco)

            '# Tipos de Cheques Filtro
            _publicos.CargaComboTiposCheques(cmbTiposCheques)
            cmbTiposCheques.SelectedIndex = -1

            cmbEstadosCheques_M.Inicializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True)

            ugDetalle.DataSource = CrearDT()

            ' inicializo el combo de sucursales con opción de Selección multiple
            cmbSucursal.Initializar(permiteSinSeleccion:=True, seleccionMultiple:=True, seleccionTodos:=True, IdFuncion)
            cmbSucursal.Enabled = Reglas.Publicos.ConsultarMultipleSucursal

            InicializaCajas()

            FormatearColumnas()
            ugDetalle.AgregarTotalesSuma({"Importe"})
            PreferenciasLeer(ugDetalle, tsbPreferencias)

            If ConsultarAutomaticamente Then
               chbFechaCobro.Checked = True
               dtpFechaCobroDesde.Value = Date.Today.AddMonths(-1)
               'Me.chbEstado.Checked = True
               cmbEstadosCheques_M.SelectedValue = "ENCARTERA"
               btnConsultar.PerformClick()
            End If
            If ConsultarAutomaticamenteDesdeRecibos Then btnConsultar.PerformClick()
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
      TryCatched(Sub() RefrescarDatosGrilla())
   End Sub
   Private Sub tsbImprimir_Click(sender As Object, e As EventArgs) Handles tsbImprimir.Click
      TryCatched(Sub() ugDetalle.Imprimir(Name, CargarFiltrosImpresion(), New ImprimirUltraGridParams() With {.Landscape = True, .FitWidthToPages = 1}))
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

   Private Sub UltraGridPrintDocument1_PagePrinting(sender As Object, e As Infragistics.Win.Printing.PagePrintingEventArgs) Handles UltraGridPrintDocument1.PagePrinting
      TryCatched(Sub() UltraGridPrintDocument1.Footer.TextRight = String.Format("Página: {0}", UltraGridPrintDocument1.PageNumber))
   End Sub


#Region "Eventos Filtros"
   Private Sub cmbSucursal_AfterSelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbSucursal.AfterSelectedIndexChanged
      TryCatched(Sub() InicializaCajas())
   End Sub
   Private Sub chbFechaCobro_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaCobro.CheckedChanged
      TryCatched(
         Sub()
            If Not chbFechaCobro.Checked Then
               dtpFechaCobroDesde.Value = Date.Now
               dtpFechaCobroHasta.Value = Date.Now
            End If
            dtpFechaCobroDesde.Enabled = chbFechaCobro.Checked
            dtpFechaCobroHasta.Enabled = chbFechaCobro.Checked
         End Sub)
   End Sub
   Private Sub chbFechaEnCarteraAl_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaEnCarteraAl.CheckedChanged
      TryCatched(
         Sub()
            If Not chbFechaEnCarteraAl.Checked Then
               dtpFechaEnCarteraAl.Value = Date.Now
            End If
            dtpFechaEnCarteraAl.Enabled = chbFechaEnCarteraAl.Checked
         End Sub)
   End Sub
   Private Sub chbNumero_CheckedChanged(sender As Object, e As EventArgs) Handles chbNumero.CheckedChanged
      TryCatched(
       Sub()
          txtNumero.Enabled = chbNumero.Checked
          If Not chbNumero.Checked Then
             txtNumero.Text = String.Empty
          Else
             txtNumero.Focus()
          End If
       End Sub)
   End Sub
   Private Sub chbTitular_CheckedChanged(sender As Object, e As EventArgs) Handles chbTitular.CheckedChanged
      TryCatched(
      Sub()
         txtTitular.Enabled = chbTitular.Checked
         If Not chbTitular.Checked Then
            txtTitular.Text = String.Empty
         Else
            txtTitular.Focus()
         End If
      End Sub)
   End Sub
   Private Sub chbBanco_CheckedChanged(sender As Object, e As EventArgs) Handles chbBanco.CheckedChanged
      TryCatched(Sub() chbBanco.FiltroCheckedChanged(cmbBanco))
   End Sub
   Private Sub chbLocalidad_CheckedChanged(sender As Object, e As EventArgs) Handles chbLocalidad.CheckedChanged
      TryCatched(Sub() chbLocalidad.FiltroCheckedChanged(cmbLocalidad))
   End Sub
   Private Sub chbIngreso_CheckedChanged(sender As Object, e As EventArgs) Handles chbIngreso.CheckedChanged
      TryCatched(
         Sub()
            If Not chbIngreso.Checked Then
               dtpDesdeFechaIng.Value = Date.Now
               dtpHastaFechaIng.Value = Date.Now
            End If
            dtpDesdeFechaIng.Enabled = chbIngreso.Checked
            dtpHastaFechaIng.Enabled = chbIngreso.Checked
         End Sub)
   End Sub
   Private Sub chbTipoCheque_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoCheque.CheckedChanged
      TryCatched(
         Sub()
            cmbTiposCheques.Enabled = chbTipoCheque.Checked
            If Not chbTipoCheque.Checked Then
               cmbTiposCheques.SelectedIndex = -1
            End If
         End Sub)
   End Sub
   Private Sub chbCliente_CheckedChanged(sender As Object, e As EventArgs) Handles chbCliente.CheckedChanged
      TryCatched(Sub() chbCliente.FiltroCheckedChanged(bscCodigoCliente, bscCliente))
   End Sub
   Private Sub bscCodigoCliente_BuscadorClick() Handles bscCodigoCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCodigoCliente)
            Dim codigoCliente = bscCodigoCliente.Text.ValorNumericoPorDefecto(-1L)
            bscCodigoCliente.Datos = New Reglas.Clientes().GetFiltradoPorCodigo(codigoCliente, True, False)
         End Sub)
   End Sub
   Private Sub bscCliente_BuscadorClick() Handles bscCliente.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaClientes2(bscCliente)
            bscCliente.Datos = New Reglas.Clientes().GetFiltradoPorNombre(bscCliente.Text.Trim(), False)
         End Sub)
   End Sub
   Private Sub bscCodigoCliente_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCliente.BuscadorSeleccion, bscCliente.BuscadorSeleccion
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosCliente(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
   Private Sub chbProveedor_CheckedChanged(sender As Object, e As EventArgs) Handles chbProveedor.CheckedChanged
      TryCatched(Sub() chbProveedor.FiltroCheckedChanged(bscCodigoProveedor, bscProveedor))
   End Sub
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
         Sub()
            _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
            Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
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
      TryCatched(
         Sub()
            If Not e.FilaDevuelta Is Nothing Then
               CargarDatosProveedor(e.FilaDevuelta)
            End If
         End Sub)
   End Sub
#End Region

   Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
      TryCatched(
         Sub()
            If chbBanco.Checked And cmbBanco.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó un Banco aunque activó ese Filtro")
               cmbBanco.Focus()
               Exit Sub
            End If
            If chbLocalidad.Checked And cmbLocalidad.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó una Localidad aunque activó ese Filtro")
               cmbLocalidad.Focus()
               Exit Sub
            End If
            If chbNumero.Checked And txtNumero.ValorNumericoPorDefecto(0L) = 0 Then
               ShowMessage("ATENCION: NO seleccionó un Numero aunque activó ese Filtro")
               txtNumero.Focus()
               Exit Sub
            End If
            If chbCliente.Checked And Not bscCodigoCliente.Selecciono And Not bscCliente.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Cliente aunque activó ese Filtro")
               bscCodigoCliente.Focus()
               Exit Sub
            End If
            If chbProveedor.Checked And Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
               ShowMessage("ATENCION: NO seleccionó un Proveedor aunque activó ese Filtro")
               bscCodigoProveedor.Focus()
               Exit Sub
            End If
            If chbTitular.Checked And String.IsNullOrEmpty(txtTitular.Text.Trim()) Then
               ShowMessage("ATENCION: NO seleccionó un Titular aunque activó ese Filtro")
               txtTitular.Focus()
               Exit Sub
            End If
            If chbTipoCheque.Checked And cmbTiposCheques.SelectedIndex = -1 Then
               ShowMessage("ATENCION: NO seleccionó un Tipo de Cheque aunque activó ese Filtro")
               cmbTiposCheques.Focus()
               Exit Sub
            End If
            If chbObservacion.Checked And String.IsNullOrEmpty(txtObservacion.Text.Trim()) Then
               ShowMessage("ATENCION: NO seleccionó la Observación aunque activó ese Filtro")
               txtTitular.Focus()
               Exit Sub
            End If

            CargaGrillaDetalle()

            If ugDetalle.Rows.Count > 0 Then
               btnConsultar.Focus()
            Else
               ShowMessage("ATENCION: NO hay registros que cumplan con la selección !!!")
            End If
         End Sub)
   End Sub


#End Region

#Region "Metodos"

   Public Sub InicializarPublicos()
      _publicos = New Publicos()
   End Sub

   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      bscProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
      bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
      bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString()
      bscProveedor.Enabled = False
      bscCodigoProveedor.Enabled = False

      btnConsultar.Focus()
   End Sub

   Private Sub CargarDatosCliente(dr As DataGridViewRow)
      bscCliente.Text = dr.Cells("NombreCliente").Value.ToString()
      bscCodigoCliente.Text = dr.Cells("CodigoCliente").Value.ToString()
      bscCodigoCliente.Tag = dr.Cells("IdCliente").Value.ToString()
      bscCliente.Enabled = False
      bscCodigoCliente.Enabled = False

      btnConsultar.Focus()
   End Sub

   Private Sub RefrescarDatosGrilla()
      'chbEstado.Checked = False

      chbFechaCobro.Checked = False
      chbIngreso.Checked = False
      chbFechaEnCarteraAl.Checked = False
      chbNumero.Checked = False
      chbTipoCheque.Checked = False
      chbBanco.Checked = False
      chbLocalidad.Checked = False
      chbCliente.Checked = False
      chbProveedor.Checked = False
      chbTitular.Checked = False
      chbObservacion.Checked = False
      cmbEstadosCheques_M.Refrescar()
      rdbOrdenCobro.Checked = True

      cmbSucursal.Refrescar()
      cmbCajas.Refrescar()

      ugDetalle.ClearFilas()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Private Sub CargaGrillaDetalle()
      Dim cajas = cmbCajas.GetCajas(todosVacio:=False)

      Dim fechaCobroDesde As Date = Nothing
      Dim fechaCobroHasta As Date = Nothing
      If chbFechaCobro.Checked Then
         fechaCobroDesde = dtpFechaCobroDesde.Value
         fechaCobroHasta = dtpFechaCobroHasta.Value
      End If

      Dim fechaIngresoDesde As Date = Nothing
      Dim fechaIngresoHasta As Date = Nothing
      If chbIngreso.Checked Then
         fechaIngresoDesde = dtpDesdeFechaIng.Value
         fechaIngresoHasta = dtpHastaFechaIng.Value()
      End If

      Dim fechaEnCarteraAl As Date = Nothing
      If chbFechaEnCarteraAl.Checked Then
         fechaEnCarteraAl = dtpFechaEnCarteraAl.Value
      End If

      Dim numero = txtNumero.ValorSeleccionado(chbNumero, 0L)
      Dim idBanco = cmbBanco.ValorSeleccionado(chbBanco, 0I)
      Dim idLocalidad = cmbLocalidad.ValorSeleccionado(chbLocalidad, 0I)
      Dim idCliente = If(chbCliente.Checked, Long.Parse(bscCodigoCliente.Tag.ToString()), 0L)
      Dim idProveedor = If(chbProveedor.Checked, Long.Parse(bscCodigoProveedor.Tag.ToString()), 0L)
      Dim titular = If(chbTitular.Checked, txtTitular.Text, String.Empty)
      Dim orden = If(rdbOrdenCobro.Checked, Entidades.Cheque.Ordenamiento.FECHACOBRO, Entidades.Cheque.Ordenamiento.NOMBREYFECHACOBRO)
      Dim tipoCheque = cmbTiposCheques.ValorSeleccionado(chbTipoCheque, String.Empty)
      Dim observacion = If(chbObservacion.Checked, txtObservacion.Text, String.Empty)

      Dim oCheques As Reglas.Cheques = New Reglas.Cheques()
      Using dtDetalle = oCheques.GetInforme(
                                    cmbSucursal.GetSucursales(), cajas, cmbEstadosCheques_M.GetEstados(True),
                                    fechaCobroDesde, fechaCobroHasta, fechaEnCarteraAl,
                                    numero, idBanco, idLocalidad, esPropio:=False,
                                    idCliente, idProveedor, titular,
                                    fechaIngresoDesde, fechaIngresoHasta,
                                    idCuentaBancaria:=0, orden, tipoCheque,
                                    conciliado:=Nothing, observacion)

         Dim dt = CrearDT()
         For Each dr In dtDetalle.Rows.OfType(Of DataRow)()

            Dim drCl = dt.NewRow()
            drCl("IdTipoCheque") = dr.Field(Of String)(Entidades.Cheque.Columnas.IdTipoCheque.ToString())
            drCl("NombreTipoCheque") = dr.Field(Of String)("NombreTipoCheque")
            If Not String.IsNullOrEmpty(dr("NombreCajaIngreso").ToString()) Then
               drCl("NombreCajaIngreso") = dr("NombreCajaIngreso")
            End If

            drCl("IdBanco") = dr("IdBanco")
            drCl("NombreBanco") = dr("NombreBanco").ToString()
            drCl("IdBancoSucursal") = Integer.Parse(dr("IdBancoSucursal").ToString())
            drCl("IdLocalidad") = dr("IdLocalidad")
            drCl("NombreLocalidad") = dr("NombreLocalidad").ToString()
            drCl("NumeroCheque") = Long.Parse(dr("NumeroCheque").ToString())

            drCl("FechaEmision") = Date.Parse(dr("FechaEmision").ToString())
            drCl("FechaCobro") = Date.Parse(dr("FechaCobro").ToString())
            drCl("Titular") = dr("Titular").ToString()
            drCl("Cuit") = dr("Cuit").ToString()
            drCl("Importe") = Decimal.Parse(dr("Importe").ToString())
            drCl("IdEstadoCheque") = dr("IdEstadoCheque").ToString()

            If Not String.IsNullOrEmpty(dr("NombreCliente").ToString()) Then
               drCl("NombreCliente") = dr("NombreCliente").ToString()
            End If

            If Not String.IsNullOrEmpty(dr("NroPlanillaIngreso").ToString()) Then

               drCl("FechaIngreso") = Date.Parse(dr("FechaIngreso").ToString())

               drCl("NroPlanillaIngreso") = Integer.Parse(dr("NroPlanillaIngreso").ToString())
               drCl("NroMovimientoIngreso") = Integer.Parse(dr("NroMovimientoIngreso").ToString())
               'If Not String.IsNullOrEmpty(dr("FechaIngreso").ToString()) Then
               'Fec = Date.Parse(dr("FechaIngreso").ToString())
               'drCl("Ingreso") = "P: " & dr("NroPlanillaIngreso").ToString() & " - M: " & dr("NroMovimientoIngreso").ToString() & " - " & Fec.ToString("dd/MM/yyyy HH:mm") & " / " & dr("ObservacionIngreso").ToString()

               drCl("Ingreso") = "P: " & dr("NroPlanillaIngreso").ToString() & " - M: " & dr("NroMovimientoIngreso").ToString() & " / " & dr("ObservacionIngreso").ToString()
               'End If
            End If

            If Not String.IsNullOrEmpty(dr("NombreProveedor").ToString()) Then
               drCl("NombreProveedor") = dr("NombreProveedor").ToString()
            End If

            If Not String.IsNullOrEmpty(dr("NroPlanillaEgreso").ToString()) Then
               drCl("FechaEgreso") = Date.Parse(dr("FechaEgreso").ToString())
               drCl("NroPlanillaEgreso") = Integer.Parse(dr("NroPlanillaEgreso").ToString())
               drCl("NroMovimientoEgreso") = Integer.Parse(dr("NroMovimientoEgreso").ToString())
               'If Not String.IsNullOrEmpty(dr("FechaEgreso").ToString()) Then
               'Fec = Date.Parse(dr("FechaEgreso").ToString())
               'drCl("Egreso") = "P: " & dr("NroPlanillaEgreso").ToString() & " - M: " & dr("NroMovimientoEgreso").ToString() & " - " & Fec.ToString("dd/MM/yyyy HH:mm") & " / " & dr("ObservacionEgreso").ToString()

               drCl("Egreso") = "P: " & dr("NroPlanillaEgreso").ToString() & " - M: " & dr("NroMovimientoEgreso").ToString() & " / " & dr("ObservacionEgreso").ToString()
               'End If
            End If
            If Not String.IsNullOrEmpty(dr("ProveedorPreasignado").ToString()) Then
               drCl("ProveedorPreasignado") = dr("ProveedorPreasignado").ToString()
            End If

            drCl("NroOperacion") = dr.Field(Of String)(Entidades.Cheque.Columnas.NroOperacion.ToString())

            drCl("SituacionCobro") = dr("SituacionCobro")
            '--REQ-36301.- -------------------------------
            drCl("idSituacionCheque") = dr("idSituacionCheque")
            drCl("NombreSituacionCheque") = dr("NombreSituacionCheque")
            '---------------------------------------------
            drCl("Observacion") = dr("Observacion")

            dt.Rows.Add(drCl)
         Next

         '# Cargo los datos en grilla + Filtros dinámicos
         ugDetalle.DataSource = dt
         AgregarFiltroEnLinea(ugDetalle, {"NombreBanco", "Titular", "Cuit", "NombreCliente", "NombreProveedor", "Observacion"})

         tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"
      End Using
   End Sub

   Private Sub FormatearColumnas()
      For Each cl As UltraGridColumn In ugDetalle.DisplayLayout.Bands(0).Columns
         cl.Hidden = True
         cl.CellActivation = Activation.NoEdit
      Next

      Dim pos = 0I
      With ugDetalle.DisplayLayout.Bands(0)
         .Columns("IdTipoCheque").FormatearColumna("Tipo de Cheque", pos, 50, HAlign.Center)
         .Columns("NombreTipoCheque").FormatearColumna("Tipo de Cheque", pos, 150, HAlign.Left, hidden:=True)

         .Columns("NombreCajaIngreso").FormatearColumna("Caja", pos, 80)
         .Columns("NombreBanco").FormatearColumna("Nombre Banco", pos, 100)
         .Columns("IdBancoSucursal").FormatearColumna("Suc.", pos, 40, HAlign.Right)
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 100)
         .Columns("NumeroCheque").FormatearColumna("Número", pos, 70, HAlign.Right)
         .Columns("FechaEmision").FormatearColumna("Emisión", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("FechaCobro").FormatearColumna("Cobro", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("Titular").FormatearColumna("Titular", pos, 160)
         .Columns("Cuit").FormatearColumna(My.Resources.RTextos.Cuit, pos, 80)
         .Columns("Importe").FormatearColumna("Importe", pos, 80, HAlign.Right, , "N2")
         .Columns("IdEstadoCheque").FormatearColumna("Estado", pos, 100)
         .Columns("NombreCliente").FormatearColumna("Nombre Cliente", pos, 200)
         .Columns("FechaIngreso").FormatearColumna("Ingreso", pos, 70, HAlign.Center,, "dd/MM/yyyy")
         .Columns("Ingreso").FormatearColumna("Movimiento Ingreso", pos, 250)
         .Columns("FechaEgreso").FormatearColumna("Egreso", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("NombreProveedor").FormatearColumna("Nombre Proveedor", pos, 200)
         .Columns("Egreso").FormatearColumna("Movimiento Egreso", pos, 250)
         .Columns("ProveedorPreasignado").FormatearColumna("Proveedor Preasignado", pos, 200)

         .Columns("NroOperacion").FormatearColumna("Nro. Operación", pos, 100, HAlign.Right)
         .Columns("SituacionCobro").FormatearColumna("Situación de Cobro", pos, 120)
         '--REQ-36301.- --------------------------------------------------------------------
         .Columns("NombreSituacionCheque").FormatearColumna("Situación de Cheque", pos, 120)
         '----------------------------------------------------------------------------------
         .Columns("Observacion").FormatearColumna("Observacion", pos, 100)
      End With
   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         '.Columns.Add("IdCajaIngreso", GetType(Int32"))
         .Columns.Add("IdTipoCheque", GetType(String))
         .Columns.Add("NombreTipoCheque", GetType(String))
         .Columns.Add("NombreCajaIngreso", GetType(String))
         .Columns.Add("IdBanco", GetType(Integer))
         .Columns.Add("NombreBanco", GetType(String))
         .Columns.Add("IdBancoSucursal", GetType(Integer))
         .Columns.Add("IdLocalidad", GetType(Integer))
         .Columns.Add("NombreLocalidad", GetType(String))
         .Columns.Add("NumeroCheque", GetType(Long))
         .Columns.Add("NroOperacion", GetType(String))
         .Columns.Add("FechaEmision", GetType(Date))
         .Columns.Add("FechaCobro", GetType(Date))
         .Columns.Add("Titular", GetType(String))
         .Columns.Add("Cuit", GetType(String))
         .Columns.Add("Importe", GetType(Decimal))
         .Columns.Add("IdEstadoCheque", GetType(String))
         .Columns.Add("NombreCliente", GetType(String))
         .Columns.Add("FechaIngreso", GetType(Date))
         .Columns.Add("Ingreso", GetType(String))
         .Columns.Add("NroPlanillaIngreso", GetType(Integer))
         .Columns.Add("NroMovimientoIngreso", GetType(Integer))
         .Columns.Add("NombreProveedor", GetType(String))
         .Columns.Add("FechaEgreso", GetType(Date))
         .Columns.Add("Egreso", GetType(String))
         .Columns.Add("NroPlanillaEgreso", GetType(Integer))
         .Columns.Add("NroMovimientoEgreso", GetType(Integer))
         .Columns.Add("ProveedorPreasignado", GetType(String))
         .Columns.Add("SituacionCobro", GetType(String))

         .Columns.Add("IdSituacionCheque", GetType(Integer))
         .Columns.Add("NombreSituacionCheque", GetType(String))
         .Columns.Add("Observacion", GetType(String))

      End With

      Return dtTemp

   End Function

   Private Function CargarFiltrosImpresion() As String
      Dim filtro = New StringBuilder()
      With filtro

         If cmbSucursal.Enabled Then
            cmbSucursal.CargarFiltrosImpresionSucursales(filtro, False, True)
         End If

         If cmbCajas.Enabled Then
            'Filtros = Fitros & "Caja: " & Me.cmbCajas.Text
            .AppendFormat("Caja: {0} - ", cmbCajas.Text)
         End If

         If dtpFechaCobroDesde.Enabled Then
            'Filtros = Filtros & "Rango de Fechas: desde el " & Me.dtpFechaCobroDesde.Text & " hasta el " & Me.dtpFechaCobroHasta.Text
            .AppendFormat("Fecha desde el {0} hasta el {1} - ", dtpFechaCobroDesde.Text, dtpFechaCobroHasta.Text)
         End If

         If dtpFechaEnCarteraAl.Enabled Then
            'If Filtros.Length > 0 Then Filtros = Filtros & " / "
            'Filtros = Filtros & "En Cartera Al: " & Me.dtpFechaEnCarteraAl.Text
            .AppendFormat("En Cartera al: {0}", dtpFechaEnCarteraAl.Text)
         End If

         If txtNumero.Enabled Then
            'If Filtros.Length > 0 Then Filtros = Filtros & " / "
            'Filtros = Filtros & "Numero: " & Me.txtNumero.Text
            .AppendFormat("Número: {0}", txtNumero.Text)
         End If

         If cmbBanco.Enabled Then
            'If Filtros.Length > 0 Then Filtros = Filtros & " / "
            'Filtros = Filtros & "Banco: " & Me.cmbBanco.Text
            .AppendFormat("Banco: {0}", cmbBanco.Text)
         End If

         If cmbLocalidad.Enabled Then
            'If Filtros.Length > 0 Then Filtros = Filtros & " / "
            'Filtros = Filtros & "Localidad: " & Me.cmbLocalidad.Text
            .AppendFormat("Localidad: {0}", cmbLocalidad.Text)
         End If

         If chbCliente.Checked And bscCodigoCliente.Selecciono Or bscCliente.Selecciono Then
            'If Filtros.Length > 0 Then Filtros = Filtros & " / "
            'Filtros = Filtros & "Cliente: " & Me.bscCodigoCliente.Text.Trim() & " - " & Me.bscCliente.Text.Trim()
            .AppendFormat("Cliente: {0} - {1}", bscCodigoCliente.Text.Trim(), bscCliente.Text.Trim())
         End If

         If chbProveedor.Checked And bscCodigoProveedor.Selecciono Or bscProveedor.Selecciono Then
            'If Filtros.Length > 0 Then Filtros = Filtros & " / "
            'Filtros = Filtros & "Proveedor: " & Me.bscCodigoProveedor.Text.Trim() & " - " & Me.bscProveedor.Text.Trim()
            .AppendFormat("Proveedor: {0} - {1}", bscCodigoProveedor.Text.Trim(), bscProveedor.Text.Trim())
         End If

      End With
      Return filtro.ToString.Trim().Trim("-"c)
   End Function

   Private Sub InicializaCajas()
      cmbCajas.Inicializar(cmbSucursal.GetSucursales(), blnMiraUsuario:=True, blnMiraPC:=False, blnCajasModificables:=False)
   End Sub

   Private Sub chbObservacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbObservacion.CheckedChanged
      TryCatched(
   Sub()
      txtObservacion.Enabled = chbObservacion.Checked
      If Not chbObservacion.Checked Then
         txtObservacion.Text = String.Empty
      Else
         txtObservacion.Focus()
      End If
   End Sub)
   End Sub

#End Region

End Class
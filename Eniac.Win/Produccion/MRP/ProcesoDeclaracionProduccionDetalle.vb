'Imports Eniac.Entidades
Imports Eniac.Entidades

Public Class ProcesoDeclaracionProduccionDetalle

#Region "Campos"
   Public Property OrdenesProduccionMRP As Entidades.OrdenProduccionMRP
   Public Property NovedadesProduccion As Entidades.NovedadProduccionMRP

   Public Property novNecesarios As Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
   Public Property novResultante As Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
   Public Property novTiempos As Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPTiempo)

   Private _cargandoInicio As Boolean

   Private _publicos As Publicos
   Private _detalle As DataRow

#End Region

#Region "New"
   Private Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(detalle As DataRow)
      Me.New()
      _detalle = detalle
      uttProductosNecesarios.State = Infragistics.Win.Misc.TileState.Large
   End Sub
#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()
            _cargandoInicio = True

            '-- Carga Combos de Depositos.- --------------------------------------------------------------
            _publicos.CargaComboDepositos(cmbDepositoNecesario, actual.Sucursal.IdSucursal, miraUsuario:=True, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.SI)
            _publicos.CargaComboDepositos(cmbDepositoResultante, actual.Sucursal.IdSucursal, miraUsuario:=True, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.SI)
            '-- Carga combo de Responsables.- ------------------------------------------------------------
            _publicos.CargaComboEmpleados(cmbResponsable, Entidades.Publicos.TiposEmpleados.RESPPROD)
            cmbResponsable.SelectedIndex = -1
            '-- Carga combo de tipos de Tiempos.- --------------------------------------------------------
            _publicos.CargaComboDesdeEnum(cmbTipoOperacion, GetType(Reglas.Publicos.TipoOperacionesTiempos))
            cmbTipoOperacion.SelectedIndex = -1
            '-- Carga combo de conceptos de Tiempos.- ----------------------------------------------------
            _publicos.CargaComboConceptosNoProductivo(cmbConceptoOperacion)
            '-- Limpieza General del Formulario.- --------------------------------------------------------
            LimpiaGeneral()
            '---------------------------------------------------------------------------------------------
            CargaCabeceraOrdenProduccion()
            '---------------------------------------------------------------------------------------------
            LimpiaOperacion()
            '---------------------------------------------------------------------------------------------
            _cargandoInicio = False
            '-- Carga las Grillas de Novedades por Defecto.- ----------------------------------------------
            ugProductosNecesarios.DataSource = novNecesarios
            FormateGrillaNecesarios()
            ugProductosResultantes.DataSource = novResultante
            FormateGrillaResultantes()
            ugDetalleTiempos.DataSource = novTiempos
            FormateGrillaTiempos()
         End Sub)
   End Sub
#End Region


#Region "Metodos"
   Private Function GetOperacionActivaTiempos() As Entidades.NovedadProduccionMRPTiempo
      Return ugDetalleTiempos.FilaSeleccionada(Of Entidades.NovedadProduccionMRPTiempo)
   End Function
   Private Function GetOperacionActivaNecesarios() As Entidades.NovedadProduccionMRPProducto
      Return ugProductosNecesarios.FilaSeleccionada(Of Entidades.NovedadProduccionMRPProducto)
   End Function
   Private Function GetOperacionActivaResultantes() As Entidades.NovedadProduccionMRPProducto
      Return ugProductosResultantes.FilaSeleccionada(Of Entidades.NovedadProduccionMRPProducto)
   End Function

   Private Sub CargaCabeceraOrdenProduccion()
      '-- Carga Orden de Produccion.- -------------------------------------------------------------------------------------------------------
      OrdenesProduccionMRP = New Reglas.OrdenesProduccionMRP().GetTodas(_detalle.Field(Of Integer)("IdSucursal"),
                                                                        _detalle.Field(Of String)("IdTipoComprobante"),
                                                                        _detalle.Field(Of String)("Letra"),
                                                                        _detalle.Field(Of Integer)("CentroEmisor"),
                                                                        _detalle.Field(Of Integer)("NumeroOrdenProduccion"), 1, _detalle.Field(Of String)("IdProducto"))
      '-- Carga Datos de Cabecera.- ---------------------------------------------------------------------------------------------------------
      txtOrdenProduccion.Text = String.Format("{0} {1} {2:0000}-{3:00000000}",
                                              _detalle.Field(Of String)("IdTipoComprobante"), _detalle.Field(Of String)("Letra"),
                                              _detalle.Field(Of Integer)("CentroEmisor"), _detalle.Field(Of Integer)("NumeroOrdenProduccion"))
      txtCliente.Text = String.Format("{0}", _detalle.Field(Of String)("NombreCliente"))
      txtProducto.Text = String.Format("{0} - {1}", _detalle.Field(Of String)("IdProducto"), _detalle.Field(Of String)("NombreProducto"))

      txtPedido.Text = String.Empty
      If Not String.IsNullOrEmpty(_detalle.Field(Of String)("IdTipoComprobantePedido")) Then
         txtPedido.Text = String.Format("{0} {1} {2:0000}-{3:00000000}",
                                              _detalle.Field(Of String)("IdTipoComprobantePedido"), _detalle.Field(Of String)("LetraPedido"),
                                              _detalle.Field(Of Integer)("CentroPedido"), _detalle.Field(Of Integer)("NumeroPedido"))
      End If
      '--------------------------------------------------------------------------------------------------------------------------------------
      CargaComboOperaciones(cmbOperacionDeclaracion, OrdenesProduccionMRP.Operaciones)
      '--------------------------------------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub CargarTiemposDeclarados()
      If ValidarTiemposDeclarados() Then
         '------------------------------------------------------
         InsertarTiemposDeclarados()
         '------------------------------------------------------
         LimpiaTiempos()
         '------------------------------------------------------
      End If
   End Sub
   Private Function ValidarTiemposDeclarados() As Boolean
      If cmbTipoOperacion.SelectedIndex <> -1 Then
         '-- Valida Concepto.- ------------------------------
         If (cmbTipoOperacion.SelectedValue.ToString() = Reglas.Publicos.TipoOperacionesTiempos.TIEMPONOPRODUCTIVO.ToString()) AndAlso cmbConceptoOperacion.SelectedIndex = -1 Then
            ShowMessage("Debe ingresar un Concepto para el tipo de Tiempo seleccionado!!!.")
            cmbConceptoOperacion.Select()
            Return False
         End If
         Dim oTiempos = novTiempos.Where(Function(x) x.IdTipoDeclaracion = cmbTipoOperacion.SelectedValue.ToString()).ToList()
         If oTiempos.Count > 0 Then
            ShowMessage(String.Format("El Tipo de Tiempos {0} ya fue declarado para la Operacion {1}", cmbTipoOperacion.SelectedValue.ToString(), cmbOperacionDeclaracion.Text.ToString()))
            Return False
         End If
      Else
         ShowMessage("Debe seleccionar un tipo de Tiempo para informar!!!.")
         cmbTipoOperacion.Select()
         Return False
      End If
      '-- Valida Tiempos.- -------------------------------
      If dtpDesdeOperacion.Value >= dtpHastaOperacion.Value Then
         ShowMessage("Fecha Desde debe ser menor a Fecha Hasta!!!.")
         dtpDesdeOperacion.Select()
         Return False
      End If
      Return True
   End Function
   Private Sub InsertarTiemposDeclarados()
      Dim oLineaTiempo = New Entidades.NovedadProduccionMRPTiempo
      With oLineaTiempo
         .NumeroNovedadesProducccion = 0
         .CodigoOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()
         .IdTipoDeclaracion = cmbTipoOperacion.SelectedValue.ToString()
         .FechaHoraInicio = dtpDesdeOperacion.Value
         .FechaHoraFin = dtpHastaOperacion.Value
         .Tiempo = dtpHastaOperacion.Value.Subtract(dtpDesdeOperacion.Value).ToString()
         .IdConcepto = 0
         .DescripcionConcepto = String.Empty
         If cmbTipoOperacion.SelectedValue.ToString() = Reglas.Publicos.TipoOperacionesTiempos.TIEMPONOPRODUCTIVO.ToString() Then
            .IdConcepto = Integer.Parse(cmbConceptoOperacion.SelectedValue.ToString())
            .DescripcionConcepto = cmbConceptoOperacion.Text.ToString()
         End If
      End With
      novTiempos.Add(oLineaTiempo)
      FormateGrillaTiempos()
   End Sub
   Private Sub EliminaTiemposDeclarados()
      Dim eOprTiempos = GetOperacionActivaTiempos()
      If eOprTiempos IsNot Nothing Then
         If ShowPregunta(String.Format("¿Desea eliminar la operación {0}?", eOprTiempos.IdTipoDeclaracion)) = Windows.Forms.DialogResult.Yes Then
            novTiempos.Remove(eOprTiempos)
            ugDetalleTiempos.Rows.Refresh(RefreshRow.ReloadData)
            FormateGrillaTiempos()
            LimpiaTiempos()
         End If
      End If
   End Sub

   Private Sub CargaOPNecesariosResultantes(listaOperaciones As Entidades.OrdenProduccionMRPOperacion)
      Dim codOperacion = listaOperaciones.CodigoProcProdOperacion
      '-- Productos Necesarios.- ----------------------------------------------------------------------------
      For Each proPN In listaOperaciones.ProductosNecesarios.Where(Function(x) x.MRPProducto.EsProductoNecesario = True)
         Dim novPN = New Entidades.NovedadProduccionMRPProducto()
         With novPN
            .CodigoOperacion = codOperacion
            '-- Carga Datos Producto.- ----------------------------------------------------------------------
            Dim eProducto = New Reglas.Productos().GetUno(proPN.MRPProducto.IdProductoProceso, False, False, Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
            .IdProducto = eProducto.IdProducto
            .NombreProducto = eProducto.NombreProducto
            .UnidadMedidaProd = eProducto.UnidadDeMedida.NombreUnidadDeMedida
            .IdMonedaProducto = eProducto.Moneda.IdMoneda
            .NombreMonedaProducto = eProducto.Moneda.NombreMoneda
            '------------------------------------------------------------------------------------------------
            .EsProductoNecesario = proPN.MRPProducto.EsProductoNecesario
            .EsProductoAgregado = False
            .Cantidad = proPN.MRPProducto.CantidadSolicitada
            .CantidadPendiente = (proPN.MRPProducto.CantidadSolicitada - proPN.CantidadProcesada)
            .CantidadProcesada = proPN.CantidadProcesada
            .PrecioCosto = proPN.MRPProducto.PrecioCostoProducto
            '-- Carga Datos de Deposito y Ubicacion.- -------------------------------------------------------
            Dim eDepoUbic = New Reglas.SucursalesUbicaciones().GetUno(proPN.MRPProducto.IdDepositoOrigen, proPN.MRPProducto.IdSucursal, proPN.MRPProducto.IdUbicacionOrigen)
            .IdSucursal = proPN.MRPProducto.IdSucursal
            .IdDeposito = proPN.MRPProducto.IdDepositoOrigen
            .NombreDeposito = eDepoUbic.NombreDeposito
            .IdUbicacion = proPN.MRPProducto.IdUbicacionOrigen
            .NombreUbicacion = eDepoUbic.NombreUbicacion
            '------------------------------------------------------------------------------------------------
            .CantidadInformada = 0
         End With
         novNecesarios.Add(novPN)
      Next
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosNecesarios.DataSource = novNecesarios
      ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaNecesarios()

      '-- Productos Resultantes.- ---------------------------------------------------------------------------
      For Each proPR In listaOperaciones.ProductosResultantes.Where(Function(x) x.MRPProducto.EsProductoNecesario = False)
         Dim novPR = New Entidades.NovedadProduccionMRPProducto()
         With novPR
            .CodigoOperacion = codOperacion
            '-- Carga Datos Producto.- ----------------------------------------------------------------------
            Dim eProducto = New Reglas.Productos().GetUno(proPR.MRPProducto.IdProductoProceso, False, False, Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
            .IdProducto = eProducto.IdProducto
            .NombreProducto = eProducto.NombreProducto
            .UnidadMedidaProd = eProducto.UnidadDeMedida.NombreUnidadDeMedida
            .IdMonedaProducto = eProducto.Moneda.IdMoneda
            .NombreMonedaProducto = eProducto.Moneda.NombreMoneda
            '------------------------------------------------------------------------------------------------
            .EsProductoNecesario = proPR.MRPProducto.EsProductoNecesario
            .EsProductoAgregado = False
            .Cantidad = proPR.MRPProducto.CantidadSolicitada
            .CantidadPendiente = (proPR.MRPProducto.CantidadSolicitada - proPR.CantidadProcesada)
            .CantidadProcesada = proPR.CantidadProcesada
            '-- Carga Datos de Deposito y Ubicacion.- -------------------------------------------------------
            Dim eDepoUbic = New Reglas.SucursalesUbicaciones().GetUno(proPR.MRPProducto.IdDepositoOrigen, proPR.MRPProducto.IdSucursal, proPR.MRPProducto.IdUbicacionOrigen)
            .IdSucursal = eDepoUbic.IdSucursal
            .IdDeposito = eDepoUbic.IdDeposito
            .NombreDeposito = eDepoUbic.NombreDeposito
            .IdUbicacion = eDepoUbic.IdUbicacion
            .NombreUbicacion = eDepoUbic.NombreUbicacion
            '------------------------------------------------------------------------------------------------
            .CantidadInformada = 0
         End With
         novResultante.Add(novPR)
      Next
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosResultantes.DataSource = novResultante
      ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaResultantes()

   End Sub
   Private Sub InsertarProductoResultante()
      '-- Inserta Producto Necesario.- --------------------------------------------------------------------------------------------
      Dim oprSeleccionada = GetOperacionActivaResultantes()
      If oprSeleccionada IsNot Nothing Then
         If novResultante.Where(Function(x) x.IdProducto = bscCodigoProductoResultante.Text).Count > 0 Then
            ShowMessage("El Producto ya esta Asignado a la lista de Resultantes.")
            LimpiaResultantes()
            bscCodigoProductoResultante.Focus()
            Exit Sub
         End If
      End If

      txtCantidadResultante.Text = Decimal.Parse(txtCantidadResultante.Text).ToString("##,##0.00")
      Dim oLineaPR = New Entidades.NovedadProduccionMRPProducto
      With oLineaPR
         .CodigoOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()
         .IdProducto = bscCodigoProductoResultante.Text
         .NombreProducto = bscNombreProductoResultante.Text
         '-- 
         .Cantidad = 1
         .CantidadInformada = Decimal.Parse(txtCantidadResultante.Text)
         '-- 
         .EsProductoNecesario = False
         .EsProductoAgregado = True
         '-- 
         Dim eProd = New Reglas.Productos().GetUno(bscCodigoProductoResultante.Text, False, True)
         .UnidadMedidaProd = eProd.UnidadDeMedida.NombreUnidadDeMedida
         .PrecioCosto = eProd.PrecioCosto

         '-- 
         .IdSucursal = actual.Sucursal.Id
         .IdDeposito = Integer.Parse(cmbDepositoResultante.SelectedValue.ToString())
         .NombreDeposito = cmbDepositoResultante.Text
         .IdUbicacion = Integer.Parse(cmbUbicacionResultante.SelectedValue.ToString())
         .NombreUbicacion = cmbUbicacionResultante.Text
         '--
         .IdMonedaProducto = Integer.Parse(txtMonedaResultante.Tag.ToString())
         .NombreMonedaProducto = txtMonedaResultante.Text

      End With
      novResultante.Add(oLineaPR)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaResultantes()
      LimpiaResultantes()
      '-- Setea Controles.- -------------------------------------------------------------------------------------------------------
      cmbDepositoResultante.Enabled = False
      cmbUbicacionResultante.Enabled = False
      bscCodigoProductoResultante.Focus()
      '----------------------------------------------------------------------------------------------------------------------------
   End Sub
   Private Sub InsertarProductoNecesario()
      '-- Inserta Producto Necesario.- --------------------------------------------------------------------------------------------
      Dim oprSeleccionada = GetOperacionActivaNecesarios()
      If oprSeleccionada IsNot Nothing Then
         If novNecesarios.Where(Function(x) x.IdProducto = bscCodigoProductoNecesario.Text).Count > 0 Then
            ShowMessage("El Producto ya esta Asignado a la lista de Necesarios.")
            LimpiaNecesarios()
            bscCodigoProductoNecesario.Focus()
            Exit Sub
         End If
      End If
      txtCantidadNecesaria.Text = Decimal.Parse(txtCantidadNecesaria.Text).ToString("##,##0.00")
      Dim oLineaPN = New Entidades.NovedadProduccionMRPProducto
      With oLineaPN
         .CodigoOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()
         .IdProducto = bscCodigoProductoNecesario.Text
         .NombreProducto = bscNombreProductoNecesario.Text
         '-- 
         .Cantidad = 1
         .CantidadInformada = Decimal.Parse(txtCantidadNecesaria.Text)
         '-- 
         .EsProductoNecesario = True
         .EsProductoAgregado = True
         '-- 
         Dim eProd = New Reglas.Productos().GetUno(bscCodigoProductoNecesario.Text, False, True)
         .UnidadMedidaProd = eProd.UnidadDeMedida.NombreUnidadDeMedida
         .PrecioCosto = eProd.PrecioCosto
         '-- 
         .IdSucursal = actual.Sucursal.Id
         .IdDeposito = Integer.Parse(cmbDepositoNecesario.SelectedValue.ToString())
         .NombreDeposito = cmbDepositoNecesario.Text
         .IdUbicacion = Integer.Parse(cmbUbicacionNecesario.SelectedValue.ToString())
         .NombreUbicacion = cmbUbicacionNecesario.Text
         '--
         .IdMonedaProducto = Integer.Parse(txtMonedaNecesario.Tag.ToString())
         .NombreMonedaProducto = txtMonedaNecesario.Text

      End With
      novNecesarios.Add(oLineaPN)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaNecesarios()
      LimpiaNecesarios()
      '-- Setea Controles.- -------------------------------------------------------------------------------------------------------
      cmbDepositoNecesario.Enabled = False
      cmbUbicacionNecesario.Enabled = False
      bscCodigoProductoNecesario.Focus()
      '----------------------------------------------------------------------------------------------------------------------------
   End Sub

   Private Sub GrabaDatosNovedadProduccion()
      NovedadesProduccion = New Entidades.NovedadProduccionMRP
      With NovedadesProduccion
         .IdSucursal = actual.Sucursal.IdSucursal
         .IdTipoComprobante = _detalle.Field(Of String)("IdTipoComprobante")
         .LetraComprobante = _detalle.Field(Of String)("Letra")
         .CentroEmisor = _detalle.Field(Of Integer)("CentroEmisor")
         .NumeroOrdenProduccion = _detalle.Field(Of Integer)("NumeroOrdenProduccion")
         .Orden = 1
         .IdProducto = _detalle.Field(Of String)("IdProducto")
         .IdProcesoProductivo = _detalle.Field(Of Long)("IdProcesoProductivo")
         .CodigoOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()
         .IdOperacion = OrdenesProduccionMRP.Operaciones.Where(Function(x) x.CodigoProcProdOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()).ElementAt(0).IdOperacion
         .UsuarioAlta = actual.Nombre
         .FechaAlta = Date.Today
         .FechaNovedad = dtpFechaOperacion.Value
         .IdEmpleado = Integer.Parse(cmbResponsable.SelectedValue.ToString())

         .TiemposNovedades = novTiempos
         .ProductosNecesarios = novNecesarios
         .ProductosResultantes = novResultante
         .ClaseCentroProductor = DirectCast(gpbTiemposOperaciones.Tag, Entidades.MRPCentroProductor.ClaseCentrosProd)

      End With
      '-- Carga Novedades.- ----------------------------------------
      Dim rNovedadPro = New Reglas.NovedadesProduccionMRP()
      Dim eOPO As Entidades.OrdenProduccionMRPOperacion = Nothing
      '-- Actualiza Estados de Tareas.- ----------------------------
      If chbFinalizaTarea.Checked Then
         eOPO = New Entidades.OrdenProduccionMRPOperacion
         eOPO = OrdenesProduccionMRP.Operaciones.Where(Function(x) x.CodigoProcProdOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()).ElementAt(0)
         eOPO.IdEstadoTarea = Entidades.MRPProcesoProductivoOperacion.EstadoAsignaTarea.FINALIZADA.ToString()
         eOPO.FechaComienzo = Date.Today
      End If

      rNovedadPro.ActualizarDeclaracion(NovedadesProduccion, eOPO, OrdenesProduccionMRP, IdFuncion)
      '--------------------------------------------------------------------------------------------------------------------------------------
   End Sub
   Private Function ValidaDatosNovedadProduccion() As Boolean
      If cmbResponsable.SelectedIndex = -1 Then
         ShowMessage("Debe seleccionar un usuario Responsable.")
         cmbResponsable.Focus()
         Return False
      End If
      Return True
   End Function
   Public Sub CargaComboOperaciones(combo As Controles.ComboBox, lis As List(Of Entidades.OrdenProduccionMRPOperacion))
      With combo
         .DisplayMember = "DescripcionOperacion"
         .ValueMember = "CodigoProcProdOperacion"
         .DataSource = lis.Where(Function(x) x.IdEstadoTarea <> Reglas.Publicos.EstadoAsignaTarea.FINALIZADA.ToString()).ToList()
         .SelectedIndex = 0
      End With
   End Sub

   Private Sub CargarProductoResultante(dr As DataGridViewRow)
      If Not String.IsNullOrEmpty((dr.Cells("IdProcesoProductivoDefecto").Value.ToString())) Then
         ShowMessage("El Producto Seleccionado, no puede tener asociado Proceso Productivo!!!")
         bscCodigoProductoResultante.Text = String.Empty
         bscNombreProductoResultante.Text = String.Empty
         txtMonedaResultante.Text = String.Empty
         txtMonedaResultante.Tag = String.Empty

         cmbDepositoResultante.SelectedIndex = 0

         txtCantidadResultante.Text = "0.0000"
         bscCodigoProductoResultante.Focus()
      Else
         '-- Carga datos de Buscador.-----
         bscCodigoProductoResultante.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProductoResultante.Text = dr.Cells("NombreProducto").Value.ToString()
         '-- Carga Moneda.- --------------
         txtMonedaResultante.Text = dr.Cells("NombreMoneda").Value.ToString()
         txtMonedaResultante.Tag = dr.Cells("IdMoneda").Value.ToString()
         '-- Asigna Deposito Defecto.- ---
         cmbDepositoResultante.Enabled = True
         cmbDepositoResultante.SelectedValue = Integer.Parse(dr.Cells("IdDepositoDefecto").Value.ToString.Trim())
         If cmbDepositoResultante.SelectedIndex <> -1 Then
            cmbUbicacionResultante.Enabled = True
            cmbUbicacionResultante.SelectedValue = Integer.Parse(dr.Cells("IdUbicacionDefecto").Value.ToString.Trim())
         Else
            cmbDepositoResultante.SelectedIndex = 0
         End If
         '-- Asigna Cantidad Defecto.- ---
         txtCantidadResultante.Text = "1.0000"
         txtCantidadResultante.Focus()
      End If
   End Sub
   Private Sub CargarProductoNecesario(dr As DataGridViewRow)
      '-- Carga datos de Buscador.-
      bscCodigoProductoNecesario.Text = dr.Cells("IdProducto").Value.ToString.Trim()
      bscNombreProductoNecesario.Text = dr.Cells("NombreProducto").Value.ToString()
      '-- Carga Moneda.- --------------
      txtMonedaNecesario.Text = dr.Cells("NombreMoneda").Value.ToString()
      txtMonedaNecesario.Tag = dr.Cells("IdMoneda").Value.ToString()
      '-- Asigna Deposito Defecto.- ---
      cmbDepositoNecesario.Enabled = True
      cmbDepositoNecesario.SelectedValue = Integer.Parse(dr.Cells("IdDepositoDefecto").Value.ToString.Trim())
      If cmbDepositoNecesario.SelectedIndex <> -1 Then
         cmbUbicacionNecesario.Enabled = True
         cmbUbicacionNecesario.SelectedValue = Integer.Parse(dr.Cells("IdUbicacionDefecto").Value.ToString.Trim())
      Else
         cmbDepositoNecesario.SelectedIndex = 0
      End If
      '-- Posiciona cursor.-
      txtCantidadNecesaria.Focus()
   End Sub

   Private Sub CambiaHorariosTiempos()
      dtpDesdeOperacion.Value = dtpFechaOperacion.Value.Date
      dtpHastaOperacion.Value = dtpFechaOperacion.Value.Date.AddHours(23)
   End Sub
#End Region

#Region "Formateo de Grillas"
   Private Sub FormateGrillaNecesarios()
      ugProductosNecesarios.Rows.Refresh(RefreshRow.ReloadData)
      With ugProductosNecesarios.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         '-- Formatea las Columnas.- -------------------------
         .Columns("Lotes").FormatearColumna("Lote", pos, 40, HAlign.Center)
         .Columns("IdProducto").FormatearColumna("Codigo", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Descripción", pos, 200, HAlign.Left)
         .Columns("CantidadInformada").FormatearColumna("Informar", pos, 80, HAlign.Right,, "N4", Formatos.MaskInput.CustomMaskInput(9, 4), Activation.AllowEdit).Color(Nothing, Color.LightCyan)
         .Columns("Cantidad").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, "N4")
         .Columns("CantidadPendiente").FormatearColumna("Pendiente", pos, 80, HAlign.Right,, "N4")
         .Columns("CantidadProcesada").FormatearColumna("Procesada", pos, 80, HAlign.Right,, "N4")
         .Columns("UnidadMedidaProd").FormatearColumna("U.M.", pos, 70, HAlign.Left)
         .Columns("EsProductoAgregado").FormatearColumna("Agregado", pos, 70, HAlign.Center)
         .Columns("NombreDeposito").FormatearColumna("Depósito", pos, 120, HAlign.Left)
         .Columns("NombreUbicacion").FormatearColumna("Ubicación", pos, 120, HAlign.Left)
      End With


   End Sub
   Private Sub FormateGrillaResultantes()
      ugProductosResultantes.Rows.Refresh(RefreshRow.ReloadData)
      With ugProductosResultantes.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         '-- Formatea las Columnas.- -------------------------
         .Columns("Lotes").FormatearColumna("Lote", pos, 40, HAlign.Center)
         .Columns("IdProducto").FormatearColumna("Codigo", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Descripción", pos, 200, HAlign.Left)
         .Columns("CantidadInformada").FormatearColumna("Informar", pos, 80, HAlign.Right,, "N4", Formatos.MaskInput.CustomMaskInput(9, 4), Activation.AllowEdit).Color(Nothing, Color.LightCyan)
         .Columns("Cantidad").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, "N4")
         .Columns("CantidadPendiente").FormatearColumna("Pendiente", pos, 80, HAlign.Right,, "N4")
         .Columns("CantidadProcesada").FormatearColumna("Procesada", pos, 80, HAlign.Right,, "N4")
         .Columns("UnidadMedidaProd").FormatearColumna("U.M.", pos, 70, HAlign.Left)
         .Columns("EsProductoAgregado").FormatearColumna("Agregado", pos, 70, HAlign.Center)
         .Columns("NombreDeposito").FormatearColumna("Depósito", pos, 120, HAlign.Left)
         .Columns("NombreUbicacion").FormatearColumna("Ubicación", pos, 120, HAlign.Left)
      End With
   End Sub
   Private Sub FormateGrillaTiempos()
      ugDetalleTiempos.Rows.Refresh(RefreshRow.ReloadData)
      With ugDetalleTiempos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         .Columns("IdTipoDeclaracion").FormatearColumna("Tipo", pos, 120, HAlign.Left)
         .Columns("FechaHoraInicio").FormatearColumna("Fecha Desde", pos, 100, HAlign.Center)
         .Columns("FechaHoraFin").FormatearColumna("Fecha Hasta", pos, 100, HAlign.Center)
         .Columns("Tiempo").FormatearColumna("Tiempo", pos, 80, HAlign.Center)
         .Columns("DescripcionConcepto").FormatearColumna("Concepto", pos, 120, HAlign.Left)
      End With
   End Sub
#End Region

#Region "Limpieza Campos"
   Private Sub LimpiaEntidadesNovedad()
      novNecesarios = New Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosNecesarios.DataSource = novNecesarios
      ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaNecesarios()

      novResultante = New Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPProducto)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosResultantes.DataSource = novResultante
      ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaResultantes()

      novTiempos = New Entidades.ListConBorrados(Of Entidades.NovedadProduccionMRPTiempo)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugDetalleTiempos.DataSource = novTiempos
      ugDetalleTiempos.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaTiempos()
   End Sub
   Private Sub LimpiaGeneral()
      txtOrdenProduccion.Text = String.Empty
      txtCliente.Text = String.Empty
      txtProducto.Text = String.Empty
      txtPedido.Text = String.Empty
   End Sub
   Private Sub LimpiaOperacion()
      LimpiaEntidadesNovedad()
      '------------------------------------------
      cmbOperacionDeclaracion.SelectedIndex = -1
      cmbResponsable.SelectedIndex = -1
      chbFinalizaTarea.Checked = False
      dtpFechaOperacion.Value = Date.Today
      '-- Desactiva el agrupador de Tiempos.- ---
      gpbTiemposOperaciones.Enabled = False
      '-- Desactiva el agrupador de Tiempos.- ---
      utpProcesosProductivos.Enabled = False
      '------------------------------------------
      LimpiaTiempos()
      LimpiaNecesarios()
      LimpiaResultantes()
      '------------------------------------------
   End Sub
   Private Sub LimpiaTiempos()
      cmbTipoOperacion.SelectedIndex = 0

      CambiaHorariosTiempos()

      cmbConceptoOperacion.SelectedIndex = -1
   End Sub
   Private Sub LimpiaNecesarios()
      bscCodigoProductoNecesario.Text = String.Empty
      bscNombreProductoNecesario.Text = String.Empty
      cmbDepositoNecesario.SelectedIndex = 0
      cmbUbicacionNecesario.SelectedIndex = 0
      txtCantidadNecesaria.Text = "0.0000"
      txtMonedaNecesario.Text = String.Empty
   End Sub
   Private Sub LimpiaResultantes()
      bscCodigoProductoResultante.Text = String.Empty
      bscNombreProductoResultante.Text = String.Empty
      txtMonedaResultante.Text = String.Empty
      txtMonedaResultante.Tag = String.Empty
      cmbDepositoResultante.SelectedIndex = 0
      txtCantidadResultante.Text = "0.0000"
      bscCodigoProductoResultante.Focus()
   End Sub
#End Region

#Region "Eventos"
   Protected Overrides Sub OnClosing(e As System.ComponentModel.CancelEventArgs)
      If DialogResult <> DialogResult.OK Then
         e.Cancel = ShowPregunta(String.Format("¿Está seguro de querer cerrar la Declaracion sin guardar? Se perderan los cambios que haya realizado"), MessageBoxDefaultButton.Button2) = DialogResult.No
      End If
      MyBase.OnClosing(e)
   End Sub
   Private Sub cmbOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbOperacionDeclaracion.SelectedIndexChanged
      btnAceptar.Enabled = True
      cmbResponsable.Enabled = True
      chbFinalizaTarea.Checked = False
      gpbTiemposOperaciones.Tag = Entidades.MRPCentroProductor.ClaseCentrosProd.INT

      If cmbOperacionDeclaracion.SelectedIndex > -1 Then
         Dim eOperacion = OrdenesProduccionMRP.Operaciones.Where(Function(x) x.CodigoProcProdOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()).ElementAt(0)
         '-- Limpia Campos de Tiempos.- ---
         LimpiaTiempos()
         '--------------------------------------------------------------------------------------------------------------------------------------
         _cargandoInicio = True
         cmbTipoOperacion.SelectedIndex = 0
         cmbResponsable.SelectedIndex = -1

         If eOperacion.IdEmpleado <> 0 Then
            cmbResponsable.SelectedValue = eOperacion.IdEmpleado
            '-- Activa el agrupador de Tiempos.- ---
            gpbTiemposOperaciones.Enabled = (gpbTiemposOperaciones.Tag.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
            '-- Activa el agrupador de Tiempos.- ---
            utpProcesosProductivos.Enabled = True
            '---------------------------------------
         End If

         _cargandoInicio = False
         '-- Marca el agrupador de Tiempos.- ---
         Dim claseCentro = New Reglas.MRPCentrosProductores().GetUno(eOperacion.CentroProductorOperacion).ClaseCentroProductor
         gpbTiemposOperaciones.Tag = claseCentro
         '-- Recupera Novedades de envio.- ------------------------------------------------------------------------------------
         If claseCentro = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT AndAlso eOperacion.TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION Then
            Dim rOP = New Reglas.NovedadesProduccionMRP()
            '  Dim operAnter = (Integer.Parse(eOperacion.CodigoProcProdOperacion) - 1).ToString("000")
            Dim operAnter = Integer.Parse(eOperacion.CodigoProcProdOperacion) - 1
            Dim dtDetalle = rOP.GetInformeDeclaraciones(0, operAnter, Nothing, Nothing,
                                                        eOperacion.IdTipoComprobante, eOperacion.LetraComprobante, eOperacion.CentroEmisor, eOperacion.NumeroOrdenProduccion, eOperacion.NumeroOrdenProduccion,
                                                        eOperacion.IdProducto, 0, eOperacion.IdProcesoProductivo,
                                                        String.Empty, String.Empty, 0, 0, 0, 0, 0)
            If dtDetalle.Rows.Count = 0 Then
               ShowMessage("No se puede Declarar una Operacion de Recepción sin haber Declarado su vinculada de Envío.")
               '-- Activa el agrupador de Tiempos.- ---
               gpbTiemposOperaciones.Enabled = False
               '-- Activa el agrupador de Tiempos.- ---
               utpProcesosProductivos.Enabled = False
               '---------------------------------------
               Exit Sub
            End If
         End If
         '---------------------------------------------------------------------------------------------------------------------
         '-- Cargar Necesarios - Resultantes.- -------------------------------------------------------------------------------------------------
         If Not _cargandoInicio Then
            LimpiaEntidadesNovedad()
            CargaOPNecesariosResultantes(eOperacion)
         End If
         CambiaHorariosTiempos()
      End If
   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoNecesario.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim dr = cmbDepositoNecesario.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               _publicos.CargaComboUbicaciones(cmbUbicacionNecesario, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
               cmbUbicacionNecesario.SelectedIndex = 0
            End If
         End Sub)
   End Sub
   Private Sub cmbDepositoResultante_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoResultante.SelectedIndexChanged
      TryCatched(
         Sub()
            Dim dr = cmbDepositoResultante.ItemSeleccionado(Of DataRow)()
            If dr IsNot Nothing Then
               _publicos.CargaComboUbicaciones(cmbUbicacionResultante, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
               cmbUbicacionResultante.SelectedIndex = 0
            End If
         End Sub)
   End Sub
   Private Sub cmbTipoOperacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoOperacion.SelectedIndexChanged
      If Not _cargandoInicio Then
         cmbConceptoOperacion.Enabled = (cmbTipoOperacion.SelectedValue.ToString() = Reglas.Publicos.TipoOperacionesTiempos.TIEMPONOPRODUCTIVO.ToString())
         cmbConceptoOperacion.SelectedIndex = -1
      End If
      CambiaHorariosTiempos()
   End Sub

   Private Sub btnInsertaTiempos_Click(sender As Object, e As EventArgs) Handles btnInsertaTiempos.Click
      TryCatched(
         Sub()
            '-- Inserta Tiempo Operacion.- ----------------------------------------------------------------------------------------------
            CargarTiemposDeclarados()
            '----------------------------------------------------------------------------------------------------------------------------
         End Sub)
   End Sub
   Private Sub btnBorraTiempos_Click(sender As Object, e As EventArgs) Handles btnBorraTiempos.Click
      TryCatched(
         Sub()
            '-- Elimina Tiempo Operacion.- ----------------------------------------------------------------------------------------------
            EliminaTiemposDeclarados()
            '----------------------------------------------------------------------------------------------------------------------------
         End Sub)
   End Sub

   Private Sub bscCodigoProductoResultante_BuscadorClick() Handles bscCodigoProductoResultante.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProductoResultante)
         Me.bscCodigoProductoResultante.Datos = oProductos.GetPorCodigo(Me.bscCodigoProductoResultante.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreProductoResultante_BuscadorClick() Handles bscNombreProductoResultante.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscNombreProductoResultante)
         Me.bscNombreProductoResultante.Datos = oProductos.GetPorNombre(Me.bscNombreProductoResultante.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub CargaProductoResultante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreProductoResultante.BuscadorSeleccion, bscCodigoProductoResultante.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoResultante(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub bscCodigoProductoNecesario_BuscadorClick() Handles bscCodigoProductoNecesario.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProductoNecesario)
         Me.bscCodigoProductoNecesario.Datos = oProductos.GetPorCodigo(Me.bscCodigoProductoNecesario.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub bscNombreProductoNecesario_BuscadorClick() Handles bscNombreProductoNecesario.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscNombreProductoNecesario)
         Me.bscNombreProductoNecesario.Datos = oProductos.GetPorNombre(Me.bscNombreProductoNecesario.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub CargaProductoNecesario_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoNecesario.BuscadorSeleccion, bscNombreProductoNecesario.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProductoNecesario(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnInsertarProductoResultante_Click(sender As Object, e As EventArgs) Handles btnInsertarProductoResultante.Click
      TryCatched(
         Sub()
            If (Not bscCodigoProductoResultante.FilaDevuelta Is Nothing) Or (Not bscNombreProductoResultante.FilaDevuelta Is Nothing) Then
               If Decimal.Parse(txtCantidadResultante.Text) = 0 Then
                  ShowMessage("La Cantidad ingresada no puede ser Cero.")
                  txtCantidadResultante.Focus()
                  Exit Sub
               End If
               InsertarProductoResultante()
               '------------------------------------------------------
               bscCodigoProductoResultante.Focus()
            End If
         End Sub)
   End Sub
   Private Sub btnEliminarProductoResultante_Click(sender As Object, e As EventArgs) Handles btnEliminarProductoResultante.Click
      Try
         Dim oprSeleccionada = GetOperacionActivaResultantes()
         If oprSeleccionada IsNot Nothing AndAlso oprSeleccionada.EsProductoAgregado Then
            If ShowPregunta(String.Format("¿Desea eliminar el Producto Resultante {0}?", oprSeleccionada.NombreProducto)) = Windows.Forms.DialogResult.Yes Then
               novResultante.Remove(oprSeleccionada)
               ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaResultantes()
               bscCodigoProductoResultante.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugProductosResultantes_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugProductosResultantes.ClickCellButton
      TryCatched(
      Sub()
         Dim oprSeleccionada = GetOperacionActivaResultantes()
         If oprSeleccionada IsNot Nothing Then
            Using frm = New ProductosSeleccionLoteMultiple(oprSeleccionada)
               frm._prodNecesario = False

               frm.ShowDialog(Me)
               ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaResultantes()
            End Using
         End If
      End Sub)
   End Sub
   Private Sub ModificaUbicacionResultante_Click(sender As Object, e As EventArgs) Handles btnModificaResultante.Click
      TryCatched(
      Sub()
         Dim oprSeleccionada = GetOperacionActivaResultantes()
         If oprSeleccionada IsNot Nothing AndAlso oprSeleccionada.ProductosLotes.Count = 0 Then
            Using frm = New ProductoCambiarDepositoUbicacion(oprSeleccionada)
               frm.ShowDialog(Me)
               ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaResultantes()
            End Using
         End If
      End Sub)
   End Sub

   Private Sub btnInsertarProductoNecesario_Click(sender As Object, e As EventArgs) Handles btnInsertarProductoNecesario.Click
      TryCatched(
         Sub()
            If (Not bscCodigoProductoNecesario.FilaDevuelta Is Nothing) Or (Not bscNombreProductoNecesario.FilaDevuelta Is Nothing) Then
               If Decimal.Parse(txtCantidadNecesaria.Text) = 0 Then
                  ShowMessage("La Cantidad ingresada no puede ser Cero.")
                  txtCantidadNecesaria.Focus()
                  Exit Sub
               End If
               InsertarProductoNecesario()
               '------------------------------------------------------
               bscCodigoProductoNecesario.Focus()
            End If
         End Sub)
   End Sub
   Private Sub btnEliminarProductoNecesario_Click(sender As Object, e As EventArgs) Handles btnEliminarProductoNecesario.Click
      Try
         Dim oprSeleccionada = GetOperacionActivaNecesarios()
         If oprSeleccionada IsNot Nothing AndAlso oprSeleccionada.EsProductoAgregado Then
            If ShowPregunta(String.Format("¿Desea eliminar el Producto Necesario {0}?", oprSeleccionada.NombreProducto)) = Windows.Forms.DialogResult.Yes Then
               novNecesarios.Remove(oprSeleccionada)
               ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaNecesarios()
               bscCodigoProductoNecesario.Focus()
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugProductosNecesarios_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugProductosNecesarios.ClickCellButton
      TryCatched(
      Sub()
         Dim oprSeleccionada = GetOperacionActivaNecesarios()
         If oprSeleccionada IsNot Nothing Then
            Using frm = New ProductosSeleccionLoteMultiple(oprSeleccionada)
               frm._prodNecesario = True

               frm.ShowDialog(Me)
               ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaNecesarios()
            End Using
         End If
      End Sub)
   End Sub
   Private Sub ModificaUbicacionNecesarios_Click(sender As Object, e As EventArgs) Handles btnModificaNecesarios.Click
      TryCatched(
      Sub()
         Dim oprSeleccionada = GetOperacionActivaNecesarios()
         If oprSeleccionada IsNot Nothing AndAlso oprSeleccionada.ProductosLotes.Count = 0 Then
            Using frm = New ProductoCambiarDepositoUbicacion(oprSeleccionada)
               frm.ShowDialog(Me)
            End Using
         End If
      End Sub)
   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         Me.Cursor = Cursors.WaitCursor
         Dim respuesta As DialogResult

         respuesta = ShowPregunta(String.Format(Traducciones.TraducirTexto("¿Desea guardar la novedad de la Operacion Seleccionada: {0}?", Me, "__DeclaracionNovedades"),
                                                cmbOperacionDeclaracion.Text))
         If respuesta = Windows.Forms.DialogResult.Yes Then
            If ValidaDatosNovedadProduccion() Then
               GrabaDatosNovedadProduccion()
               respuesta = ShowPregunta("¿Desea informar otra novedad?")
               If respuesta = Windows.Forms.DialogResult.Yes Then
                  '-- Limpieza General del Formulario.- --------------------------------------------------------
                  LimpiaGeneral()
                  '---------------------------------------------------------------------------------------------
                  CargaCabeceraOrdenProduccion()
                  '---------------------------------------------------------------------------------------------
                  LimpiaOperacion()
                  '---------------------------------------------------------------------------------------------
                  _cargandoInicio = False
                  '-- Carga las Grillas de Novedades por Defecto.- ----------------------------------------------
                  ugProductosNecesarios.DataSource = novNecesarios
                  FormateGrillaNecesarios()
                  ugProductosResultantes.DataSource = novResultante
                  FormateGrillaResultantes()
                  ugDetalleTiempos.DataSource = novTiempos
                  FormateGrillaTiempos()
               Else
                  Close(DialogResult.OK)
               End If
            End If
         End If
         Me.Cursor = Cursors.Default
      Catch ex As Exception
         Me.Cursor = Cursors.Default
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dtpFechaOperacion_ValueChanged(sender As Object, e As EventArgs) Handles dtpFechaOperacion.ValueChanged
      CambiaHorariosTiempos()
   End Sub

   Private Sub cmbResponsable_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbResponsable.SelectedIndexChanged
      If Not _cargandoInicio AndAlso cmbOperacionDeclaracion.SelectedIndex > -1 Then
         Dim eEmpleado = New Reglas.Empleados().GetUno(Integer.Parse(cmbResponsable.SelectedValue.ToString()))
         Dim eCatego = OrdenesProduccionMRP.Operaciones.Where(Function(x) x.CodigoProcProdOperacion = cmbOperacionDeclaracion.SelectedValue.ToString()).ElementAt(0).CategoriasEmpleados.Where(Function(o) o.MRPCategoriaEmpleado.IdCategoriaEmpleado = eEmpleado.IdCategoriaEmpleado)
         '--------------------------------------------------------------------------------------------------------------------------------------
         If eCatego.Count = 0 Then
            ShowMessage("El empleado NO pertenece a una categoría de empleado valida, por favor ingrese un empleado con permiso para realizar esta tarea")
         End If
         '-- Activa el agrupador de Tiempos.- ---
         gpbTiemposOperaciones.Enabled = (gpbTiemposOperaciones.Tag.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
         '-- Activa el agrupador de Tiempos.- ---
         utpProcesosProductivos.Enabled = True
         '---------------------------------------
      End If
   End Sub

   Private Sub ugProductosNecesarios_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugProductosNecesarios.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.NovedadProduccionMRPProducto)()
         If e.Row.Band.Index = 0 Then
            Dim prod = New Reglas.Productos().GetUno(dr.IdProducto, False, False).Lote
            With e.Row
               If Not prod Then
                  .Cells("Lotes").Activation = Activation.Disabled
               Else
                  .Cells("Lotes").ButtonAppearance.BackColor = Color.Blue
                  .Cells("CantidadInformada").Activation = Activation.NoEdit
               End If
            End With
         End If
      End Sub)
   End Sub
   Private Sub ugProductosResultantes_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugProductosResultantes.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of Entidades.NovedadProduccionMRPProducto)()
         If e.Row.Band.Index = 0 Then
            Dim prod = New Reglas.Productos().GetUno(dr.IdProducto, False, False).Lote
            With e.Row
               If Not prod Then
                  .Cells("Lotes").Activation = Activation.Disabled
               Else
                  .Cells("Lotes").ButtonAppearance.BackColor = Color.Blue
                  .Cells("CantidadInformada").Activation = Activation.NoEdit
               End If
            End With
         End If
      End Sub)
   End Sub

#End Region
End Class
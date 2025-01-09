Imports Eniac.Entidades

Public Class MRPProcesosProductivosDetalle
#Region "Campos"
   Private _publicos As Publicos
   Private _cargandoInicio As Boolean

   Private _visualizaErrores As Boolean = True

   Private _errores As List(Of MRPErrores)
   Public Property sucOrigen As Integer
   Public Property tsbPAPTiempos As Decimal
#End Region

#Region "Constructores"
   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.MRPProcesoProductivo)
      InitializeComponent()
      _entidad = entidad
      uttCentrosProductores.State = Misc.TileState.Large
   End Sub
#End Region

#Region "Propiedades"
   Private ReadOnly Property ProcesoProductivo() As Entidades.MRPProcesoProductivo
      Get
         Return DirectCast(_entidad, Entidades.MRPProcesoProductivo)
      End Get
   End Property

#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()
         sucOrigen = actual.Sucursal.IdSucursal

         _cargandoInicio = True
         '-- Carga Combos de Depositos.- 
         _publicos.CargaComboDepositos(cmbDepositoTarea, sucOrigen, miraUsuario:=False, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.SI)
         _publicos.CargaComboDepositos(cmbDepositoOrigen, sucOrigen, miraUsuario:=False, permiteEscritura:=True, Entidades.Publicos.SiNoTodos.SI)

         BindearControles(_entidad, _liSources)

         _cargandoInicio = False
         '-- Carga las Grillas de Procesos Productivos.- ---------------------------------------------------------
         ugProductosNecesarios.DataSource = New List(Of Entidades.MRPProcesoProductivoProducto)
         FormateGrillaNecesarios()
         ugProductosResultantes.DataSource = New List(Of Entidades.MRPProcesoProductivoProducto)
         FormateGrillaResultantes()
         ugCategoriasEmpleados.DataSource = New List(Of Entidades.MRPProcesoProductivoCategoriaEmpleado)
         FormateGrillaCategoriasEmpleados()
         '--------------------------------------------------------------------------------------------------------
         If StateForm = Eniac.Win.StateForm.Insertar Then
            If ProcesoProductivo.IdProductoProceso IsNot Nothing Then
               bscCodigoProductoPrincipal.Text = ProcesoProductivo.IdProductoProceso.Trim()
               bscCodigoProductoPrincipal.PresionarBoton()
               '--
               InicializaCopia()
               '--
               If ProcesoProductivo.IdArchivoAdjunto IsNot Nothing Then
                  cmbArchivoAdjunto.SelectedValue = ProcesoProductivo.IdArchivoAdjunto
               End If
               tsbTiempoTotalProceso.ValueDecimal = ProcesoProductivo.TiempoTotalProceso
               '-- Visualiza Carga Operaciones.-
               gpbProcesosProductivosOperaciones.Enabled = True

            End If
            '-- Inicializa Activo.- --
            chbActivoProcesoProd.Checked = False
            bscCodigoProductoPrincipal.Select()
            InicializaCostos()
         Else
            bscCodigoProductoPrincipal.Text = ProcesoProductivo.IdProductoProceso.Trim()
            bscCodigoProductoPrincipal.PresionarBoton()

            bscCodigoProductoPrincipal.Enabled = False
            bscNombreProductoPrincipal.Enabled = False
            If ProcesoProductivo.IdArchivoAdjunto IsNot Nothing Then
               cmbArchivoAdjunto.SelectedValue = ProcesoProductivo.IdArchivoAdjunto
            End If
            tsbTiempoTotalProceso.ValueDecimal = ProcesoProductivo.TiempoTotalProceso
            '-- Visualiza Carga Operaciones.-
            gpbProcesosProductivosOperaciones.Enabled = True

            btnRecalculoProcesoProductivo.Visible = True
            btnImprimirProceso.Visible = True
            If Me.StateForm = Eniac.Win.StateForm.Consultar Then
               btnAceptar.Enabled = False
               btnRecalculoProcesoProductivo.Visible = False
            End If
         End If

         ugDetalleTareas.DataSource = ProcesoProductivo.Operaciones
         FormateGrillaTareas()
         If ugDetalleTareas.Rows.Count > 0 Then
            '-- Valida el estado de las operaciones.- --
            For Ind = 0 To (ugDetalleTareas.Rows.Count - 1)
               ugDetalleTareas.ActiveRow = ugDetalleTareas.Rows(Ind)
               CargaDatosOperacion()
            Next
            ugDetalleTareas.ActiveRow = ugDetalleTareas.Rows(0)
            CargaDatosOperacion()
         End If
         '--------------------------------------------------------------------------------------------------------
      End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPProcesosProductivos()
   End Function
   Protected Overrides Function ValidarDetalle() As String
      If New Reglas.MRPProcesosProductivos().GetPorCodigoPP(txtCodigoProcesoProductivo.Text).Count > 0 AndAlso StateForm = Eniac.Win.StateForm.Insertar Then
         txtCodigoProcesoProductivo.Focus()
         Return String.Format("El Codigo Ingresado ({0}) ya fue asignado.", txtCodigoProcesoProductivo.Text)
      End If
      '-- Valida Centros productores por Operacion.- ------------------------------------------------------------
      Dim myError = New StringBuilder()
      For Each eOpr In ProcesoProductivo.Operaciones
         If eOpr.CentroProductorOperacion = 0 Then
            myError.AppendFormat("La Operacion {0} ({1})  no posee Centro Productor.", eOpr.CodigoProcProdOperacion, eOpr.DescripcionOperacion).AppendLine()
         End If
      Next
      If myError.Length <> 0 Then
         myError.AppendFormat("No se puede guardar el Proceso Productivo").AppendLine()
         Return myError.ToString()
      End If
      '-- Valida Centros productores por Operacion.- ------------------------------------------------------------
      Dim myErr = New StringBuilder()
      For Each eOpr In ProcesoProductivo.Operaciones
         For Each ePN In eOpr.ProductosNecesario
            If ePN.CantidadSolicitada = 0 Then
               myErr.AppendFormat("El Producto {0} de La Operacion {1} ({2}) posee Cantidad en Cero.", ePN.IdProductoProceso, eOpr.CodigoProcProdOperacion, eOpr.DescripcionOperacion).AppendLine()
            End If
         Next
      Next
      If myErr.Length <> 0 Then
         myErr.AppendFormat("No se puede guardar el Proceso Productivo").AppendLine()
         Return myErr.ToString()
      End If
      '----------------------------------------------------------------------------------------------------------
      If chbActivoProcesoProd.Checked Then
         '-- Valida que posea Archivo Adjunto.- -----------------------------------------------------------------
         If cmbArchivoAdjunto.SelectedIndex = -1 Then
            Return String.Format("Proceso Productivo {0} Sin Archivo Adjunto.-", txtCodigoProcesoProductivo.Text)
         End If
         '-- Valida que existan operaciones.- -------------------------------------------------------------------
         If ProcesoProductivo.Operaciones.Count = 0 Then
            Return String.Format("Proceso Productivo {0} Sin Operaciones Asignadas.-", txtCodigoProcesoProductivo.Text)
         Else
            '-- Valida la totalidad de las Oepraciones.- --------------
            Dim ultima = ProcesoProductivo.Operaciones.Max(Function(x) x.CodigoProcProdOperacion)
            For Each oPR As Entidades.MRPProcesoProductivoOperacion In ProcesoProductivo.Operaciones
               If ValidaOperaciones(oPR) = "ERR" AndAlso oPR.TipoOperacionExterna <> MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION Then
                  chbActivoProcesoProd.Focus()
                  Return String.Format("Una o mas Operaciones estan incompletas. El Proceso Productivo {0} debe estar Inactivo !!!", txtCodigoProcesoProductivo.Text)
               End If
               If oPR.CodigoProcProdOperacion = ultima AndAlso oPR.ProductosResultantes.Where(Function(x) x.IdProductoProceso = bscCodigoProductoPrincipal.Text).Count = 0 Then
                  Return String.Format("La última Operacion( {0} ) del Proceso Productivo {1} debe Resultar en un Producto {2}.-", ultima, txtCodigoProcesoProductivo.Text, bscCodigoProductoPrincipal.Text)
               End If
            Next
         End If
         '-- Valida que el producto principal no sea resultante agregado de otro proceso productivo.- -----------
         Dim dt = New Reglas.MRPProcesosProductivosProductos().ValidaProductosResultanteAsignadoOtroPP(ProcesoProductivo.IdProductoProceso, ProcesoProductivo.IdProductoProceso)
         If dt.Rows().Count > 0 Then
            _errores = New List(Of MRPErrores)
            For Each dr As DataRow In dt.Rows()
               _errores.Add(CargaErrores(dr.Field(Of String)("CodigoProcesoProductivo"), dr.Field(Of String)("DescripcionProceso")))
            Next
            ugErrores.DataSource = _errores
            FormateGrillaErroresActivacion()
            ErroresTiles(False)
            Return String.Format("No se puede activar el Proceso Prod.({0}) por que es Producto Resultante de una operacion de otro/s Proc. Prod", txtCodigoProcesoProductivo.Text)
         End If
         '--------------------------------------------------------------------------------------------------------
      End If
      '----------------------------------------------------------------------------------------------------------
      Return MyBase.ValidarDetalle()
   End Function
#End Region

#Region "Métodos"
   Private Sub InicializaCopia()
      For Each cOpr In ProcesoProductivo.Operaciones
         cOpr.IdOperacion = 0
         For Each cCat In cOpr.CategoriasEmpleados
            cCat.IdOperacion = 0
            cCat.IdProcesoProductivo = 0
         Next
         For Each cProN In cOpr.ProductosNecesario
            cProN.IdOperacion = 0
            cProN.IdProcesoProductivo = 0
         Next
         For Each cProR In cOpr.ProductosResultantes
            cProR.IdOperacion = 0
            cProR.IdProcesoProductivo = 0
         Next
      Next
   End Sub
   ''' <summary>
   ''' Calculo de Costos Proceso Productivo
   ''' </summary>
   Private Sub CalculaCostosProcesoProductivo(recalculo As Boolean)
      Dim cotiza = New Reglas.Monedas().GetUna(Integer.Parse(txtNombreMoneda.Tag.ToString())).FactorConversion
      Dim vCostoTiempos = New Reglas.MRPProcesosProductivosOperaciones().CalculaCostosTiempos(ProcesoProductivo.Operaciones, recalculo, cotiza)

      txtCostoManoObraInterna.Text = vCostoTiempos.CostoManoObraInterna.ToString("N2")
      txtCostoManoObraExterna.Text = vCostoTiempos.CostoManoObraExterna.ToString("N2")
      txtCostoMateriaPrima.Text = vCostoTiempos.CostoMateriaPrima.ToString("N2")
      txtCostoTotalProceso.Text = vCostoTiempos.CostosTotalProceso.ToString("N2")
      tsbTiempoTotalProceso.ValueDecimal = vCostoTiempos.TiempoTotalProceso
   End Sub
   Private Sub InicializaCostos()
      txtCostoManoObraInterna.Text = "0.00"
      txtCostoManoObraExterna.Text = "0.00"
      txtCostoMateriaPrima.Text = "0.00"
      txtCostoTotalProceso.Text = "0.00"
   End Sub
   Private Sub CargarProductoPrincipal(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         If Not IsDBNull(dr.Cells(Entidades.Producto.Columnas.IdFormula.ToString()).Value) Then    '  "EsCompuesto"
            ShowMessage("El producto Seleccionado tiene fórmula. No admite Proceso Productivo.")
            Exit Sub
         End If

         '-- Carga datos de Buscador.-
         bscCodigoProductoPrincipal.Text = dr.Cells("IdProducto").Value.ToString().Trim()
         bscNombreProductoPrincipal.Text = dr.Cells("NombreProducto").Value.ToString()
         '-- Sugiere Valores de Codigo y Descripcion.-
         If String.IsNullOrEmpty(txtCodigoProcesoProductivo.Text) And String.IsNullOrEmpty(txtDescripcionProcesoProductivo.Text) Then
            txtCodigoProcesoProductivo.Text = dr.Cells("IdProducto").Value.ToString.Trim()
            txtDescripcionProcesoProductivo.Text = dr.Cells("NombreProducto").Value.ToString()
         End If
         '-- Carga Moneda del Producto.- --
         txtNombreMoneda.Text = dr.Cells("NombreMoneda").Value.ToString().ToUpper()
         txtNombreMoneda.Tag = dr.Cells("IdMoneda").Value.ToString().ToUpper()

         Dim eProd = New Reglas.Productos().GetUno(bscCodigoProductoPrincipal.Text)
         txtUnidadMedida.Text = eProd.UnidadDeMedida.NombreUnidadDeMedida
         '-- Carga Combo de Adjuntos.- 
         _publicos.CargaComboAdjuntos(cmbArchivoAdjunto, dr.Cells("IdProducto").Value.ToString.Trim())
         bttn_Adjunto.Enabled = cmbArchivoAdjunto.Items.Count > 0
         '-- Visualiza Carga Operaciones.-
         gpbProcesosProductivosOperaciones.Enabled = True

         txtCodigoProcesoProductivo.Focus()
      End If
   End Sub
   Private Sub CargarProductoNecesario(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         '-- Carga datos de Buscador.-
         bscCodigoProductoNecesario.Text = dr.Cells("IdProducto").Value.ToString.Trim()
         bscNombreProductoNecesario.Text = dr.Cells("NombreProducto").Value.ToString()

         txtMonedaNecesario.Text = dr.Cells("NombreMoneda").Value.ToString()
         txtMonedaNecesario.Tag = dr.Cells("IdMoneda").Value.ToString()

         cmbDepositoOrigen.Enabled = True
         cmbDepositoOrigen.SelectedValue = Integer.Parse(dr.Cells("IdDepositoDefecto").Value.ToString.Trim())
         If cmbDepositoOrigen.SelectedIndex <> -1 Then
            cmbUbicacionOrigen.Enabled = True
            cmbUbicacionOrigen.SelectedValue = Integer.Parse(dr.Cells("IdUbicacionDefecto").Value.ToString.Trim())
         Else
            cmbDepositoOrigen.SelectedIndex = 0
         End If
         txtUnidadMedidaProdNec.Text = dr.Cells("IdUnidadDeMedida").Value.ToString()
         '-- Posiciona cursor.-
         txtCantidadNecesaria.Focus()
      End If
   End Sub
   Private Sub CargarProductoResultante(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         '-- Carga datos de Buscador.-
         '-- REQ-41858.- -----------------------------------------------------------------------------
         If Not String.IsNullOrEmpty((dr.Cells("IdProcesoProductivoDefecto").Value.ToString())) AndAlso dr.Cells("IdProducto").Value.ToString().Trim() <> bscCodigoProductoResultante.Text Then
            ShowMessage("El Producto Seleccionado, no puede tener asociado Proceso Productivo!!!")
            bscCodigoProductoResultante.Text = String.Empty
            bscNombreProductoResultante.Text = String.Empty
            txtCantidadResultante.Text = "0.0000"
            bscCodigoProductoResultante.Focus()
            '-----------------------------------------------------------------------------------------
         Else
            bscCodigoProductoResultante.Text = dr.Cells("IdProducto").Value.ToString.Trim()
            bscNombreProductoResultante.Text = dr.Cells("NombreProducto").Value.ToString()
            txtCantidadResultante.Text = "1.0000"
            txtCantidadResultante.Focus()
         End If
      End If
   End Sub
   Private Sub CargarNormasFabricacion(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         '-- Carga datos de Buscador.-
         bscNormasFabricacion.Text = dr.Cells("Descripcion").Value.ToString.Trim()
         If txtDispositivos.Text = "-" Or String.IsNullOrEmpty(txtDispositivos.Text) Then
            txtDispositivos.Text = dr.Cells("DetalleDispositivos").Value.ToString()
         End If
         If txtMetodos.Text = "-" Or String.IsNullOrEmpty(txtMetodos.Text) Then
            txtMetodos.Text = dr.Cells("DetalleMetodos").Value.ToString()
         End If
         If txtSeguridad.Text = "-" Or String.IsNullOrEmpty(txtSeguridad.Text) Then
            txtSeguridad.Text = dr.Cells("DetalleSeguridad").Value.ToString()
         End If
         If txtControlCalidad.Text = "-" Or String.IsNullOrEmpty(txtControlCalidad.Text) Then
            txtControlCalidad.Text = dr.Cells("DetalleControlCalidad").Value.ToString()
         End If
      End If
   End Sub
   Private Sub CargarDatosProveedor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreProveedor.Text = dr.Cells("NombreProveedor").Value.ToString()
         bscCodigoProveedor.Text = dr.Cells("CodigoProveedor").Value.ToString()
         bscCodigoProveedor.Tag = dr.Cells("IdProveedor").Value.ToString
         txtCostoExterno.Enabled = True
         txtCostoExterno.Focus()
      End If
   End Sub
   Private Sub CargarDatosTareas(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscNombreTareas.Text = dr.Cells("Descripcion").Value.ToString()
         bscNombreTareas.Tag = If(Not String.IsNullOrEmpty(dr.Cells("IdCentroProductor").Value.ToString()), dr.Cells("IdCentroProductor").Value.ToString(), "0")
         txtCodigoTarea.Text = If(ugDetalleTareas.Rows.Count = 0, "010", (ProcesoProductivo.Operaciones.Max(Function(x) Integer.Parse(x.CodigoProcProdOperacion)) + 10).ToString("000"))
         txtCodigoTarea.Tag = dr.Cells("IdTarea").Value.ToString()
         txtCodigoTarea.ReadOnly = False
         bscNombreTareas.Select()
      End If
   End Sub
   Private Sub CargarDatosCategoriaEmpleados(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         bscCategoriaEmpleados.Text = dr.Cells("Descripcion").Value.ToString()
         bscCategoriaEmpleados.Tag = dr.Cells("IdCategoriaEmpleado").Value.ToString()
         txtValorHoraCategoria.Text = dr.Cells("ValorHoraProduccion").Value.ToString()
         '------------------------------------------------------------------------------------------------------------------------------------------------------------
         txtCantidaCategoriaEmpleado.Focus()
      End If
   End Sub
   Private Sub CargarDatosCentroProductor(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim operacionSeleccionada = GetOperacionActiva()
         bscCodigoCentroProductor.Text = dr.Cells("CodigoCentroProductor").Value.ToString
         bscCodigoCentroProductor.Tag = dr.Cells("IdCentroProductor").Value.ToString
         bscCentrosProductores.Text = dr.Cells("Descripcion").Value.ToString()
         '-- Carga Dotacion.- --------------------------------------------------------------------------------------------------------------------------------------- 
         txtDotacionCentroProductor.Text = dr.Cells("Dotacion").Value.ToString()
         '-- Tiempos de Procesos.- ----------------------------------------------------------------------------------------------------------------------------------
         tsbPAPTiempos = Decimal.Parse(dr.Cells("TiempoPAP").Value.ToString())
         tsbPAPHorasHombre.ValueDecimal = Decimal.Parse(dr.Cells("HorasHombrePAP").Value.ToString())
         tsbProTiempos.ValueDecimal = Decimal.Parse(dr.Cells("TiempoProductivo").Value.ToString())
         tsbProHorasHombre.ValueDecimal = Decimal.Parse(dr.Cells("HorasHombreProductivo").Value.ToString())
         '-- Habilita segun Clase de Centro productor.- -------------------------------------------------------------------------------------------------------------
         bscCodigoProveedor.Enabled = (dr.Cells("ClaseCentroProductor").Value.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())
         bscNombreProveedor.Enabled = (dr.Cells("ClaseCentroProductor").Value.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString())

         gpbCategoriasEmpleados.Enabled = (dr.Cells("ClaseCentroProductor").Value.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString())
         '-- Carga Clase de Centro Productivo.- ---------------------------------------------------------------------------------------------------------------------
         If dr.Cells("ClaseCentroProductor").Value.ToString() = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString() Then
            txtClaseCentroProductor.Text = "EXTERNO"
            txtClaseCentroProductor.Tag = Entidades.MRPCentroProductor.ClaseCentrosProd.EXT.ToString()
            If Not String.IsNullOrEmpty(dr.Cells("IdProveedor").Value.ToString()) Then
               bscCodigoProveedor.Text = New Reglas.Proveedores().GetUno(Long.Parse(dr.Cells("IdProveedor").Value.ToString()), False).CodigoProveedor.ToString()
               bscCodigoProveedor.PresionarBoton()
            End If
            txtCostoExterno.Text = "0.00"
            txtUnidadesHora.Text = "0.00"
            txtUnidadesHora.Enabled = False
         Else
            txtClaseCentroProductor.Text = "INTERNO"
            txtClaseCentroProductor.Tag = Entidades.MRPCentroProductor.ClaseCentrosProd.INT.ToString()
            txtUnidadesHora.Enabled = True
            txtUnidadesHora.Text = "1.00"
            txtUnidadesHora.Focus()
         End If
         '-- Carga Normas de Fabricacion.- -------------------------------------------------------------------------------------------------------------------------
         If Not String.IsNullOrEmpty(dr.Cells("IdNormaFabricacion").Value.ToString()) Then
            Dim eNorma = New Reglas.MRPNormasFabricacion().GetUno(Integer.Parse(dr.Cells("IdNormaFabricacion").Value.ToString()))
            txtDispositivos.Text = eNorma.DetalleDispositivos
            txtMetodos.Text = eNorma.DetalleMetodos
            txtSeguridad.Text = eNorma.DetalleSeguridad
            txtControlCalidad.Text = eNorma.DetalleControlCalidad
         End If
         '-- Descarga las categorias de existir. -----------------------------------------------------------------------------------------------------------------
         If ugCategoriasEmpleados.Rows.Count > 0 Then
            ugCategoriasEmpleados.Rows.Refresh(RefreshRow.FireInitializeRow)
         Else
            Dim eCategoria = New Reglas.MRPCentrosProductoresCategoriasEmpleados().GetTodas(Integer.Parse(dr.Cells("IdCentroProductor").Value.ToString()), 0)
            If eCategoria.Count > 0 Then
               txtUnidadesHora.Text = "1.00"
               txtUnidadesHora.Focus()
               For Each eCE In eCategoria
                  bscCategoriaEmpleados.Text = eCE.NombreCategoriaEmpleado
                  bscCategoriaEmpleados.Tag = eCE.IdCategoriaEmpleado
                  txtCantidaCategoriaEmpleado.Text = eCE.CantidadCategoria.ToString()
                  txtValorHoraCategoria.Text = eCE.ValorHoraCategoria.ToString()
                  InsertarCategoriaEmpleados()
               Next
            End If
         End If
         '-- Formatea Grilla de Empleados.- ------------------------------------------------------------------------------------------------------------------------
         FormateGrillaCategoriasEmpleados()
         '----------------------------------------------------------------------------------------------------------------------------------------------------------

         If bscCodigoProveedor.Enabled Then
            bscCodigoProveedor.Focus()
         Else
            bscCategoriaEmpleados.Focus()
         End If

      End If

   End Sub

   Private Sub CargarProcesoProductivo()
      With ProcesoProductivo
         .IdProductoProceso = bscCodigoProductoPrincipal.Text
         '------------------------------------------------------------
         .TiempoTotalProceso = tsbTiempoTotalProceso.ValueDecimal
         If cmbArchivoAdjunto.Items.Count > 0 Then
            .IdArchivoAdjunto = Integer.Parse(cmbArchivoAdjunto.SelectedValue.ToString())
         End If
         '------------------------------------------------------------
      End With
   End Sub
   Public Function ValidarInsertaTarea() As Boolean
      If String.IsNullOrEmpty(txtCodigoTarea.Text) Then
         ShowMessage("Debe ingresar un Codigo de tarea Valido.")
         txtCodigoTarea.Select()
         Return False
      End If
      Return True
   End Function
   Private Sub InsertarTarea()
      Dim oLineaTarea = New Entidades.MRPProcesoProductivoOperacion
      With oLineaTarea
         .CodigoProcProdOperacion = txtCodigoTarea.Text
         .DescripcionOperacion = bscNombreTareas.Text
         .IdTareaOperacion = Integer.Parse(bscNombreTareas.Tag.ToString())
         .IdCodigoTarea = Integer.Parse(txtCodigoTarea.Tag.ToString())
         .SucursalOperacion = sucOrigen
         .DepositoOperacion = Integer.Parse(cmbDepositoTarea.SelectedValue.ToString())
         .NombreDeposito = cmbDepositoTarea.Text
         .UbicacionOperacion = Integer.Parse(cmbUbicacionTarea.SelectedValue.ToString())
         .NombreUbicacion = cmbUbicacionTarea.Text
         .EstadoOperacion = "NEW"
      End With
      ProcesoProductivo.Operaciones.Add(oLineaTarea)
      FormateGrillaTareas()
   End Sub

   ''' <summary>
   ''' Carga Producto Resultante Automaticamente.- 
   ''' </summary>
   Private Sub CargaResultanteAutomatico()
      Dim eOper = ProcesoProductivo.Operaciones.Where(Function(x) x.CodigoProcProdOperacion = txtCodigoTarea.Text)
      Dim oLineaPR = New Entidades.MRPProcesoProductivoProducto
      With oLineaPR
         .CodigoProcProdOperacion = eOper.ElementAt(0).CodigoProcProdOperacion
         .IdProductoProceso = bscCodigoProductoPrincipal.Text
         .NombreProducto = bscNombreProductoPrincipal.Text
         .CantidadSolicitada = 1
         .EsProductoNecesario = False
         Dim eProd = New Reglas.Productos().GetUno(bscCodigoProductoPrincipal.Text)
         .UnidadMedidaProd = eProd.UnidadDeMedida.NombreUnidadDeMedida
         .NombreDeposito = New Reglas.SucursalesDepositos().GetUno(eProd.IdDeposito, actual.Sucursal.IdSucursal).NombreDeposito
         .NombreUbicacion = New Reglas.SucursalesUbicaciones().GetUno(eProd.IdDeposito, actual.Sucursal.IdSucursal, eProd.IdUbicacion).NombreUbicacion
         .PrecioCostoProducto = eProd.PrecioCosto
         .CostosProducto = (eProd.PrecioCosto * 1)
      End With
      eOper.ElementAt(0).ProductosResultantes.Add(oLineaPR)
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
   End Sub

   Private Sub InsertarProductoNecesario()
      Dim operacionSeleccionada = GetOperacionActiva()
      If operacionSeleccionada IsNot Nothing Then
         If operacionSeleccionada.ProductosNecesario.Where(Function(x) x.IdProductoProceso = bscCodigoProductoNecesario.Text).Count > 0 Then
            ShowMessage("El Producto ya esta Asignado a la lista de Necesarios.")
            LimpiaResultantes()
            bscCodigoProductoResultante.Focus()
            Exit Sub
         End If
         If Decimal.Parse(txtCantidadNecesaria.Text) <= 0 Then
            ShowMessage("El Producto no puede ser ingresado con cantidades menores o iguales a cero.")
            LimpiaResultantes()
            bscCodigoProductoNecesario.Focus()
            Exit Sub
         Else
            txtCantidadNecesaria.Text = Decimal.Parse(txtCantidadNecesaria.Text).ToString("##,##0.0000")
         End If
         Dim oLineaPN = New Entidades.MRPProcesoProductivoProducto
         With oLineaPN
            .CodigoProcProdOperacion = operacionSeleccionada.CodigoProcProdOperacion
            .IdProductoProceso = bscCodigoProductoNecesario.Text
            .NombreProducto = bscNombreProductoNecesario.Text
            .CantidadSolicitada = Decimal.Parse(txtCantidadNecesaria.Text)
            .EsProductoNecesario = True
            Dim eProd = New Reglas.Productos().GetUno(bscCodigoProductoNecesario.Text, False, True)
            .UnidadMedidaProd = eProd.UnidadDeMedida.NombreUnidadDeMedida
            '-- 
            .IdSucursalOrigen = actual.Sucursal.Id
            .IdDepositoOrigen = Integer.Parse(cmbDepositoOrigen.SelectedValue.ToString())
            .NombreDeposito = cmbDepositoOrigen.Text
            .IdUbicacionOrigen = Integer.Parse(cmbUbicacionOrigen.SelectedValue.ToString())
            .NombreUbicacion = cmbUbicacionOrigen.Text
            '--
            .IdMonedaProducto = Integer.Parse(txtMonedaNecesario.Tag.ToString())
            .NombreMonedaProducto = txtMonedaNecesario.Text
            Dim cotiza = New Reglas.Monedas().GetUna(Integer.Parse(txtMonedaNecesario.Tag.ToString())).FactorConversion
            '--
            .PrecioCostoProducto = eProd.PrecioCosto
            .CostosProducto = (eProd.PrecioCosto * Decimal.Parse(txtCantidadNecesaria.Text))
            .CostosProductoMoneda = (eProd.PrecioCosto * cotiza)
            '-- REQ-41537.- -----------------------------------------------------------------------------------------------
            Dim oOperAnt = ProcesoProductivo.Operaciones.Where(Function(x) x.CodigoProcProdOperacion < operacionSeleccionada.CodigoProcProdOperacion).OrderByDescending(Function(a) a.CodigoProcProdOperacion)
            If oOperAnt.Count > 0 Then
               If oOperAnt.ElementAt(0).ProductosResultantes.Where(Function(x) x.IdProductoProceso = oLineaPN.IdProductoProceso).Count > 0 Then
                  .PrecioCostoProducto = 0
                  .CostosProducto = 0
                  .CostosProductoMoneda = 0
               End If
            End If
            '--------------------------------------------------------------------------------------------------------------
         End With
         operacionSeleccionada.ProductosNecesario.Add(oLineaPN)
         '-- Refresca los Datos de la Grilla.- ---------------------
         ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
         '-- Formate Grilla.- --------------------------------------
         FormateGrillaNecesarios()
         LimpiaNecesarios()
      End If
   End Sub
   Private Sub InsertarProductoResultante()
      Dim operacionSeleccionada = GetOperacionActiva()

      If operacionSeleccionada IsNot Nothing Then
         If operacionSeleccionada.ProductosResultantes.Where(Function(x) x.IdProductoProceso = bscCodigoProductoResultante.Text).Count > 0 Then
            ShowMessage("El Producto ya esta Asignado a la lista de Resultantes.")
            LimpiaResultantes()
            bscCodigoProductoResultante.Focus()
            Exit Sub
         End If
         If Decimal.Parse(txtCantidadResultante.Text) <= 0 Then
            ShowMessage("El Producto no puede ser ingresado con cantidades menores o iguales a cero.")
            LimpiaResultantes()
            bscCodigoProductoResultante.Focus()
            Exit Sub
         Else
            txtCantidadResultante.Text = Decimal.Parse(txtCantidadResultante.Text).ToString("##,##0.0000")
         End If
         Dim oLineaPR = New Entidades.MRPProcesoProductivoProducto
         With oLineaPR
            .CodigoProcProdOperacion = operacionSeleccionada.CodigoProcProdOperacion
            .IdProductoProceso = bscCodigoProductoResultante.Text
            .NombreProducto = bscNombreProductoResultante.Text

            .CantidadSolicitada = Decimal.Parse(txtCantidadResultante.Text())
            .EsProductoNecesario = False
            Dim eProd = New Reglas.Productos().GetUno(bscCodigoProductoResultante.Text)
            .UnidadMedidaProd = eProd.UnidadDeMedida.NombreUnidadDeMedida
            '-- 
            .IdSucursalOrigen = actual.Sucursal.Id
            .IdDepositoOrigen = eProd.IdDeposito
            .NombreDeposito = New Reglas.SucursalesDepositos().GetUno(eProd.IdDeposito, actual.Sucursal.IdSucursal).NombreDeposito
            .IdUbicacionOrigen = eProd.IdUbicacion
            .NombreUbicacion = New Reglas.SucursalesUbicaciones().GetUno(eProd.IdDeposito, actual.Sucursal.IdSucursal, eProd.IdUbicacion).NombreUbicacion
            '--
            .PrecioCostoProducto = eProd.PrecioCosto
            .CostosProducto = (eProd.PrecioCosto * 1)
         End With
         operacionSeleccionada.ProductosResultantes.Add(oLineaPR)
      End If
      '-- Refresca los Datos de la Grilla.- ---------------------
      ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
      '-- Formate Grilla.- --------------------------------------
      FormateGrillaResultantes()
      LimpiaResultantes()
   End Sub
   Private Sub InsertarCategoriaEmpleados()
      Dim operacionSeleccionada = GetOperacionActiva()
      If operacionSeleccionada IsNot Nothing Then
         Dim oLineaCE = New Entidades.MRPProcesoProductivoCategoriaEmpleado
         With oLineaCE
            .CodigoProcProdOperacion = operacionSeleccionada.CodigoProcProdOperacion
            .IdCategoriaEmpleado = Integer.Parse(bscCategoriaEmpleados.Tag.ToString())
            .NombreCategoriaEmpleado = bscCategoriaEmpleados.Text
            .CantidadCategoria = Decimal.Parse(txtCantidaCategoriaEmpleado.Text)
            .ValorHoraCategoria = Decimal.Parse(txtValorHoraCategoria.Text)
         End With
         operacionSeleccionada.CategoriasEmpleados.Add(oLineaCE)
         '-- Refresca los Datos de la Grilla.- ---------------------
         ugCategoriasEmpleados.Rows.Refresh(RefreshRow.FireInitializeRow)
         '-- Formate Grilla.- --------------------------------------
         FormateGrillaCategoriasEmpleados()
         LimpiaCategoriaEmpleados()
         '------------------------------------------------------------------------------------------------------------------------------------------------------------
      End If
   End Sub

   ''' <summary>
   ''' Obtienen la Operacion activa del DataSource.-
   ''' </summary>
   ''' <returns></returns>
   Private Function GetOperacionActiva() As Entidades.MRPProcesoProductivoOperacion
      Return ugDetalleTareas.FilaSeleccionada(Of Entidades.MRPProcesoProductivoOperacion)
   End Function

   ''' <summary>
   ''' Almacena los Datos de una Operacion.-
   ''' </summary>
   Private Sub CargaDatosOperacion()
      '-- Grabar datos que no sean listas.- -----------------------------------
      '-- Obtiene Operacion Seleccionada.- -------------------------------------------------
      Dim operacionSeleccionada = GetOperacionActiva()
      '-------------------------------------------------------------------------------------
      If operacionSeleccionada IsNot Nothing Then
         '----------------------------------------------------------------------------------
         With operacionSeleccionada
            '-- Cargar Centro Productor.- --------------------------------------------------
            If bscCodigoCentroProductor.Selecciono Or bscCentrosProductores.Selecciono Then
               .CentroProductorOperacion = Integer.Parse(bscCodigoCentroProductor.Tag.ToString())
               .DotacionCentroProductor = Integer.Parse(txtDotacionCentroProductor.Text)
               .ClaseCentroProductor = If(txtClaseCentroProductor.Tag.ToString() = "INT", Entidades.MRPCentroProductor.ClaseCentrosProd.INT, Entidades.MRPCentroProductor.ClaseCentrosProd.EXT)
               '-- Carga Id Proveedor de ser necesario.- -----------------------------------
               .Proveedor = If(txtClaseCentroProductor.Tag.ToString() = "EXT" AndAlso (bscCodigoProveedor.Selecciono Or bscNombreProveedor.Selecciono), Long.Parse(bscCodigoProveedor.Tag.ToString()), 0)
               .CostoExterno = Decimal.Parse(txtCostoExterno.Text)

               If Not .TipoOperacionExterna.HasValue AndAlso txtClaseCentroProductor.Tag.ToString() = "EXT" Then
                  .TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.ENVIO
               End If

            End If
            '-- Carga UnidadesHora.- ------------------------------------------------------------
            .UnidadesHora = Decimal.Parse(txtUnidadesHora.Text)
            '-- Carga Tiempos.- ------------------------------------------------------------
            .PAPTiemposMaquina = tsbPAPTiempos
            .PAPTiemposHHombre = tsbPAPHorasHombre.ValueDecimal
            .ProdTiemposMaquina = tsbProTiempos.ValueDecimal
            .ProdTiemposHHombre = tsbProHorasHombre.ValueDecimal
            '-- Carga las Normas.- ---------------------------------------------------------
            .NormasDispositivos = txtDispositivos.Text
            .NormasMetodos = txtMetodos.Text
            .NormasSeguridad = txtSeguridad.Text
            .NormasControlCalidad = txtControlCalidad.Text
            '-- Proceso de Validacion.- ----------------------------------------------------
            .EstadoOperacion = ValidaOperaciones(operacionSeleccionada)
         End With
         '----------------------------------------------------------------------------------
      End If
      '-- Recalcula los totales Costo-tiempos.- --------------------------------------------
      CalculaCostosProcesoProductivo(False)
      '-- Posiciona Tile Principal.- -------------------------------------------------------
      uttCentrosProductores.State = Infragistics.Win.Misc.TileState.Large
      uttDispositivos.State = uttCentrosProductores.State
      '-- Formatea Grilla de Tareas.- ------------------------------------------------------
      FormateGrillaTareas()
   End Sub

   Private Function CargaErrores(operacion As String, mensaje As String) As MRPErrores
      Return New MRPErrores() With {.IdOperacion = operacion, .Descripcion = mensaje}
   End Function
   ''' <summary>
   ''' Valida el contenido de las Operaciones.-
   ''' </summary>
   ''' <param name="operacion">Operacion de Validacion</param>
   ''' <returns></returns>
   Private Function ValidaOperaciones(operacion As Entidades.MRPProcesoProductivoOperacion) As String
      _errores = New List(Of MRPErrores)

      Dim errorValida = "OKS"
      '-- Valida Productos Necesarios.- ----------------
      If operacion.ProductosNecesario.Count = 0 Then
         _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, "La Operación requiere al menos un producto Necesario"))
         errorValida = "ERR"
      End If
      '-- Valida Productos Resultantes.- ---------------
      If operacion.ProductosResultantes.Count = 0 Then
         _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, "La Operación requiere al menos un producto Resultante."))
         errorValida = "ERR"
      End If
      '-- Valida Centro Productor.- --------------------
      If operacion.CentroProductorOperacion = 0 Then
         _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, "La Operación requiere un Centro Productor."))
         errorValida = "ERR"
      Else
         '-- Valida Categorias de Empleados.- --------------
         If operacion.ClaseCentroProductor = Entidades.MRPCentroProductor.ClaseCentrosProd.INT Then
            If operacion.CategoriasEmpleados.Count = 0 Then
               _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, "Centro Productor Interno, Requiere de categoria de Empleados."))
               errorValida = "ERR"
            End If
            If operacion.CategoriasEmpleados.Sum(Function(x) x.CantidadCategoria) <> operacion.DotacionCentroProductor Then
               _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, "La cantidad de categoria de Empleados difiere de la dotacion asignada."))
               errorValida = "ERR"
            End If
         Else
            '-- Valida Proveedor.- ------------------------------------------------------------
            If operacion.Proveedor = 0 Then
               _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, "Centro Productor Externo, Requiere de un Proveedor asociado."))
               errorValida = "ERR"
            End If
         End If
      End If
      If String.IsNullOrEmpty(operacion.NormasDispositivos) Or String.IsNullOrEmpty(operacion.NormasMetodos) Or String.IsNullOrEmpty(operacion.NormasSeguridad) Or String.IsNullOrEmpty(operacion.NormasControlCalidad) Then
         _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, "Una o más Normas de Fabrica no han sido especificadas."))
         errorValida = "ERR"
      End If
      '-- Valida la totalidad de las Oepraciones.- --------------
      Dim ultima = ProcesoProductivo.Operaciones.Max(Function(x) x.CodigoProcProdOperacion)
      For Each oPR In ProcesoProductivo.Operaciones
         If oPR.CodigoProcProdOperacion = ultima AndAlso oPR.ProductosResultantes.Where(Function(x) x.IdProductoProceso = bscCodigoProductoPrincipal.Text).Count = 0 Then
            _errores.Add(CargaErrores(operacion.CodigoProcProdOperacion, String.Format("La última Operacion( {0} ) del Proceso Productivo {1} debe Resultar en un Producto {2}.-", ultima, txtCodigoProcesoProductivo.Text, bscCodigoProductoPrincipal.Text)))
            errorValida = "ERR"
         End If
      Next
      Return errorValida
   End Function
   ''' <summary>
   ''' Realiza el Calculo de Unidad por hora de produccion.- 
   ''' </summary>
   Private Sub CalculaUnidadesHora()
      If Decimal.Parse(txtUnidadesHora.Text) > 0 Then
         tsbProHorasHombre.ValueDecimal = (1 / Decimal.Parse(txtUnidadesHora.Text))
      End If
   End Sub
#End Region

#Region "Eventos"
   Private Sub btnImprimirProceso_Click(sender As Object, e As EventArgs) Handles btnImprimirProceso.Click
      TryCatched(
      Sub()
         Dim impresion = New ImpresionProcesosProductivosMRP()
         Dim eMrpProcProd = New Reglas.MRPProcesosProductivos().GetUno(ProcesoProductivo.IdProcesoProductivo, ProcesoProductivo.IdProductoProceso)
         For Each eMrpOper In eMrpProcProd.Operaciones
            impresion.ImprimirProcesoProductivoOperacion(eMrpOper, False)
         Next
      End Sub)
   End Sub

   Private Sub ugDetalleTareas_ClickCellButton(sender As Object, e As CellEventArgs) Handles ugDetalleTareas.ClickCellButton
      TryCatched(
      Sub()
         Dim drGrilla = ugDetalleTareas.FilaSeleccionada(Of Entidades.MRPProcesoProductivoOperacion)
         If drGrilla Is Nothing Then
            Throw New Exception("Debe seleccionar una Orden para poder continuar")
         End If
         Dim dr = New Reglas.MRPProcesosProductivosOperaciones().GetUna(drGrilla.IdProcesoProductivo, drGrilla.IdOperacion)
         If dr IsNot Nothing AndAlso drGrilla.IdProcesoProductivo > 0 AndAlso drGrilla.IdOperacion > 0 Then
            Dim impresion = New ImpresionProcesosProductivosMRP()
            impresion.ImprimirProcesoProductivoOperacion(dr, True)
         Else
            Throw New Exception("Operacion no perteneciente al Proceso Productivo previamente guardado")
         End If
         '-----------------------------------------------------------------------
      End Sub)
   End Sub

   Private Sub uttDispositivos_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttDispositivos.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            txtDispositivos.Focus()
         End If
      End Sub)
   End Sub
   Private Sub uttSeguridad_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttSeguridad.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            txtSeguridad.Focus()
         End If
      End Sub)
   End Sub
   Private Sub uttMetodos_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttMetodos.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            txtMetodos.Focus()
         End If
      End Sub)
   End Sub
   Private Sub uttControlCalidad_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttControlCalidad.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            txtControlCalidad.Focus()
         End If
      End Sub)
   End Sub
   Private Sub uttCentrosProductores_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttCentrosProductores.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            'bscCentrosProductores.Focus()
         End If
      End Sub)
   End Sub
   Private Sub uttProductosNecesarios_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttProductosNecesarios.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            bscCodigoProductoNecesario.Focus()
         End If
      End Sub)
   End Sub
   Private Sub uttProductosResultantes_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttProductosResultantes.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            bscCodigoProductoResultante.Focus()
         End If
      End Sub)
   End Sub
   Private Sub uttNormasFabricacion_StateChanged(sender As Object, e As Misc.TileStateChangedEventArgs) Handles uttNormasFabricacion.StateChanged
      TryCatched(
      Sub()
         If e.Tile.State = Misc.TileState.Large Then
            bscNormasFabricacion.Focus()
         End If
      End Sub)
   End Sub

#Region "Eventos Buscador Proveedores"
   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscCodigoProveedor)
         Dim codigoProveedor = bscCodigoProveedor.Text.ValorNumericoPorDefecto(-1L)
         bscCodigoProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorCodigo(codigoProveedor)
      End Sub)
   End Sub
   Private Sub bscNombreProveedor_BuscadorClick() Handles bscNombreProveedor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProveedores2(bscNombreProveedor)
         bscNombreProveedor.Datos = New Reglas.Proveedores().GetFiltradoPorNombre(bscNombreProveedor.Text.Trim())
      End Sub)
   End Sub
   Private Sub bscCodigoProveedor_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion, bscNombreProveedor.BuscadorSeleccion
      TryCatched(Sub() CargarDatosProveedor(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Producto Principal"
   Private Sub bscCodigoProductoPrincipal_BuscadorClick() Handles bscCodigoProductoPrincipal.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProductoPrincipal)
         bscCodigoProductoPrincipal.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProductoPrincipal.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscNombreProductoPrincipal_BuscadorClick() Handles bscNombreProductoPrincipal.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProductoPrincipal)
         bscNombreProductoPrincipal.Datos = New Reglas.Productos().GetPorNombre(bscNombreProductoPrincipal.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProductoPrincipal_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoPrincipal.BuscadorSeleccion, bscNombreProductoPrincipal.BuscadorSeleccion
      TryCatched(Sub() CargarProductoPrincipal(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub cmbArchivoAdjunto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbArchivoAdjunto.SelectedIndexChanged
      TryCatched(
      Sub()
         If Not _cargandoInicio Then
            txtTipoAdjunto.Text = New Reglas.ProductosLinks().GetUno(bscCodigoProductoPrincipal.Text, Integer.Parse(cmbArchivoAdjunto.SelectedValue.ToString())).NombreTipoAdjunto
         End If
      End Sub)
   End Sub

#Region "Eventos Buscador Producto Necesario"
   Private Sub bscCodigoProductoNecesario_BuscadorClick() Handles bscCodigoProductoNecesario.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProductoNecesario)
         bscCodigoProductoNecesario.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProductoNecesario.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscNombreProductoNecesario_BuscadorClick() Handles bscNombreProductoNecesario.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProductoNecesario)
         bscNombreProductoNecesario.Datos = New Reglas.Productos().GetPorNombre(bscNombreProductoNecesario.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscCodigoProductoNecesario_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoNecesario.BuscadorSeleccion, bscNombreProductoNecesario.BuscadorSeleccion
      TryCatched(Sub() CargarProductoNecesario(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Producto Resultante"
   Private Sub bscCodigoProductoResultante_BuscadorClick() Handles bscCodigoProductoResultante.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscCodigoProductoResultante)
         bscCodigoProductoResultante.Datos = New Reglas.Productos().GetPorCodigo(bscCodigoProductoResultante.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub bscNombreProductoResultante_BuscadorClick() Handles bscNombreProductoResultante.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaProductos2(bscNombreProductoResultante)
         bscNombreProductoResultante.Datos = New Reglas.Productos().GetPorNombre(bscNombreProductoResultante.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      End Sub)
   End Sub
   Private Sub CargaProductoResultante_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoProductoResultante.BuscadorSeleccion, bscNombreProductoResultante.BuscadorSeleccion
      TryCatched(Sub() CargarProductoResultante(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub cmbDepositoTarea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoTarea.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositoTarea.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            _publicos.CargaComboUbicaciones(cmbUbicacionTarea, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
            cmbUbicacionTarea.SelectedIndex = 0
         End If
      End Sub)
   End Sub

#Region "Eventos Buscador Tareas"
   Private Sub bscNombreTareas_BuscadorClick() Handles bscNombreTareas.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPTareas(bscNombreTareas)
         bscNombreTareas.Datos = New Reglas.MRPTareas().GetFiltradoPorNombre(bscNombreTareas.Text.Trim(), Entidades.Publicos.SiNoTodos.SI)
      End Sub)
   End Sub
   Private Sub bscNombreTareas_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreTareas.BuscadorSeleccion
      TryCatched(Sub() CargarDatosTareas(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Centros Productores"
   Private Sub bscCodigoCentroProductor_BuscadorClick() Handles bscCodigoCentroProductor.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPCentrosProductores(bscCodigoCentroProductor)
         bscCodigoCentroProductor.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorCodigo(bscCodigoCentroProductor.Text.Trim(), Entidades.Publicos.SiNoTodos.TODOS, True)
      End Sub)
   End Sub
   Private Sub bscCentrosProductores_BuscadorClick() Handles bscCentrosProductores.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPCentrosProductores(bscCentrosProductores)
         bscCentrosProductores.Datos = New Reglas.MRPCentrosProductores().GetFiltradoPorNombre(bscCentrosProductores.Text.Trim(), Entidades.Publicos.SiNoTodos.SI, Entidades.Publicos.SiNoTodos.TODOS)
      End Sub)
   End Sub
   Private Sub bscCentrosProductores_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCodigoCentroProductor.BuscadorSeleccion, bscCentrosProductores.BuscadorSeleccion
      TryCatched(Sub() CargarDatosCentroProductor(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Normas de Fabricación"
   Private Sub bscNormasFabricacion_BuscadorClick() Handles bscNormasFabricacion.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaMRPNormas(bscNormasFabricacion)
         bscNormasFabricacion.Datos = New Reglas.MRPNormasFabricacion().GetFiltradoPorNombre(bscNormasFabricacion.Text)
      End Sub)
   End Sub
   Private Sub bscNormasFabricacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNormasFabricacion.BuscadorSeleccion
      TryCatched(Sub() CargarNormasFabricacion(e.FilaDevuelta))
   End Sub
#End Region

   Private Sub txtCantidadNecesaria_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadNecesaria.KeyPress
      TryCatched(
      Sub()
         If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnInsertarProductoNecesario.PerformClick()
         End If
      End Sub)
   End Sub

   Private Sub bscCategoriaEmpleados_BuscadorClick() Handles bscCategoriaEmpleados.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCatgoriasEmpleados2(bscCategoriaEmpleados)
         bscCategoriaEmpleados.Datos = New Reglas.MRPCategoriasEmpleados().GetFiltradoPorNombre(bscCategoriaEmpleados.Text.Trim(), Entidades.Publicos.SiNoTodos.SI)
      End Sub)
   End Sub
   Private Sub bscCategoriaEmpleados_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscCategoriaEmpleados.BuscadorSeleccion
      TryCatched(
      Sub()
         If Not e.FilaDevuelta Is Nothing Then
            CargarDatosCategoriaEmpleados(e.FilaDevuelta)
         End If
      End Sub)
   End Sub

   Private Sub btnInsertarTareas_Click(sender As Object, e As EventArgs) Handles btnInsertarTareas.Click
      TryCatched(
      Sub()
         If (Not bscNombreTareas.FilaDevuelta Is Nothing) And txtCodigoTarea.Text <> "" Then
            If ValidarInsertaTarea() Then
               '-- Actualiza controles Tile.- ------------------------
               utpProcesosProductivos.Enabled = True
               '-- Inserta Tarea Operacion.- -------------------------
               InsertarTarea()
               '-- Carga Producto Resultante.- -----------------------
               CargaResultanteAutomatico()
               '------------------------------------------------------
               LimpiaCamposTareas()
               '------------------------------------------------------
               txtCodigoTarea.ReadOnly = True
               bscNombreTareas.Focus()
            End If
         End If
      End Sub)
   End Sub
   Private Sub btnBorrarTareas_Click(sender As Object, e As EventArgs) Handles btnBorrarTareas.Click
      TryCatched(
      Sub()
         Dim eOperacion = GetOperacionActiva()
         If eOperacion IsNot Nothing Then
            If eOperacion.TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION AndAlso eOperacion.IdOperacionExternaVinculada.HasValue Then
               ShowMessage("No se puede eliminar una operacion de Recepción, Vinculada a una de Envio")
               Exit Sub
            End If
            If ShowPregunta(String.Format("¿Desea eliminar la operación {0}?", eOperacion.CodigoProcProdOperacion)) = Windows.Forms.DialogResult.Yes Then
               '-- Borro operacion Actual.-
               ProcesoProductivo.Operaciones.Remove(eOperacion)
               If eOperacion.TipoOperacionExterna = Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.ENVIO AndAlso eOperacion.IdOperacionExternaVinculada > 0 Then
                  Dim borr = ProcesoProductivo.Operaciones.Where(Function(x) x.IdOperacion = eOperacion.IdOperacionExternaVinculada.IfNull())
                  If borr.Count > 0 Then
                     ProcesoProductivo.Operaciones.Remove(DirectCast(borr(0), Entidades.MRPProcesoProductivoOperacion))
                  End If
               End If
               ugDetalleTareas.Rows.Refresh(RefreshRow.ReloadData)
               FormateGrillaTareas()
               LimpiezaDatosOperacion()
            End If
            '-- Recalcula los totales Costo-tiempos.- --------------------------------------------
            CalculaCostosProcesoProductivo(False)
            btnErrores.Visible = False
         End If
      End Sub)
   End Sub

   Private Sub btnInsertarProductoNecesario_Click(sender As Object, e As EventArgs) Handles btnInsertarProductoNecesario.Click
      TryCatched(
      Sub()
         '-- Inserta Producto Necesario.- --------------------------------------------------------------------------------------------
         If (Not bscCodigoProductoNecesario.FilaDevuelta Is Nothing) Or (Not bscNombreProductoNecesario.FilaDevuelta Is Nothing) Then
            If Decimal.Parse(txtCantidadNecesaria.Text) = 0 Then
               ShowMessage("La Cantidad ingresada no puede ser Cero.")
               txtCantidadNecesaria.Focus()
               Exit Sub
            End If
            InsertarProductoNecesario()
            cmbDepositoOrigen.Enabled = False
            cmbUbicacionOrigen.Enabled = False
            bscCodigoProductoNecesario.Focus()
         End If
         '----------------------------------------------------------------------------------------------------------------------------
      End Sub)
   End Sub
   Private Sub btnEliminarProductoNecesario_Click(sender As Object, e As EventArgs) Handles btnEliminarProductoNecesario.Click
      TryCatched(
      Sub()
         '-- Elimina Producto Necesario.- ------------------------------------------------------------------------------------------------------
         Dim eRegNecesario = ugProductosNecesarios.FilaSeleccionada(Of Entidades.MRPProcesoProductivoProducto)()
         Dim operacionSeleccionada = GetOperacionActiva()
         If eRegNecesario IsNot Nothing AndAlso operacionSeleccionada IsNot Nothing Then
            If ShowPregunta(String.Format("¿Desea eliminar la Categoría {0}?", eRegNecesario.NombreProducto)) = Windows.Forms.DialogResult.Yes Then
               operacionSeleccionada.ProductosNecesario.Remove(eRegNecesario)
               ugProductosNecesarios.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaNecesarios()
               bscCodigoProductoNecesario.Focus()
            End If
         End If
         LimpiaNecesarios()
         '--------------------------------------------------------------------------------------------------------------------------------------
      End Sub)
   End Sub

   Private Sub btnInsertarProductoResultante_Click(sender As Object, e As EventArgs) Handles btnInsertarProductoResultante.Click
      TryCatched(
      Sub()
         If (Not bscCodigoProductoResultante.FilaDevuelta Is Nothing) Or (Not bscNombreProductoResultante.FilaDevuelta Is Nothing) Then
            InsertarProductoResultante()
            '------------------------------------------------------
            bscCodigoProductoResultante.Focus()
         End If
      End Sub)
   End Sub
   Private Sub btnEliminarProductoResultante_Click(sender As Object, e As EventArgs) Handles btnEliminarProductoResultante.Click
      TryCatched(
      Sub()
         Dim eRegResultante = ugProductosResultantes.FilaSeleccionada(Of Entidades.MRPProcesoProductivoProducto)()
         Dim operacionSeleccionada = GetOperacionActiva()
         If eRegResultante IsNot Nothing AndAlso operacionSeleccionada IsNot Nothing Then
            '-- REQ-41858.- -----------------------------------------------------------
            If eRegResultante.IdProductoProceso = bscCodigoProductoPrincipal.Text Then
               ShowMessage("No se Puede Eliminar el registro del Producto Principal.")
               '-----------------------------------------------------------------------
            Else
               If ShowPregunta(String.Format("¿Desea eliminar el Producto Resultante {0}?", eRegResultante.NombreProducto)) = Windows.Forms.DialogResult.Yes Then
                  operacionSeleccionada.ProductosResultantes.Remove(eRegResultante)
                  ugProductosResultantes.Rows.Refresh(RefreshRow.FireInitializeRow)
                  FormateGrillaResultantes()
               End If
            End If
            bscCodigoProductoResultante.Focus()
         End If
      End Sub)
   End Sub

   Private Sub btnInsertarCategoriaEmpleado_Click(sender As Object, e As EventArgs) Handles btnInsertarCategoriaEmpleado.Click
      TryCatched(
      Sub()
         If Not bscCategoriaEmpleados.Selecciono Or bscCategoriaEmpleados.FilaDevuelta Is Nothing Then
            ShowMessage("Debe seleccionar una Categoria de Empleado.")
            bscCategoriaEmpleados.Focus()
            Exit Sub
         End If
         If Decimal.Parse(txtCantidaCategoriaEmpleado.Text) = 0 Then
            ShowMessage("La Cantidad ingresada no puede ser Cero.")
            txtCantidaCategoriaEmpleado.Focus()
            Exit Sub

         End If
         If String.IsNullOrEmpty(txtCantidaCategoriaEmpleado.Text) Then
            ShowMessage("Debe ingresar una Cantidad Valida.")
            txtCantidaCategoriaEmpleado.Focus()
            Exit Sub
         End If
         If Decimal.Parse(txtCantidaCategoriaEmpleado.Text) > Integer.Parse(txtDotacionCentroProductor.Text) Then
            ShowMessage("La cantidad debe ser menor o igual a la dotacion.")
            txtCantidaCategoriaEmpleado.Focus()
            Exit Sub
         End If
         Dim operacionSeleccionada = GetOperacionActiva()
         If operacionSeleccionada IsNot Nothing Then
            If (operacionSeleccionada.CategoriasEmpleados.Sum(Function(x) x.CantidadCategoria) + Decimal.Parse(txtCantidaCategoriaEmpleado.Text)) > Integer.Parse(txtDotacionCentroProductor.Text) Then
               ShowMessage("La cantidad total supera a la dotacion permitida.")
               txtCantidaCategoriaEmpleado.Focus()
               Exit Sub
            End If
         End If
         InsertarCategoriaEmpleados()
         '-- Habilito Borrar.- --
         btnEliminarCategoriaEmpleado.Enabled = True
         '------------------------------------------------------
         bscCategoriaEmpleados.Focus()
      End Sub)

   End Sub
   Private Sub btnEliminarCategoriaEmpleado_Click(sender As Object, e As EventArgs) Handles btnEliminarCategoriaEmpleado.Click
      TryCatched(
      Sub()
         Dim eRegCategoria = ugCategoriasEmpleados.FilaSeleccionada(Of Entidades.MRPProcesoProductivoCategoriaEmpleado)()
         Dim operacionSeleccionada = GetOperacionActiva()
         If eRegCategoria IsNot Nothing AndAlso operacionSeleccionada IsNot Nothing Then
            If ShowPregunta(String.Format("¿Desea eliminar la Categoría {0}?", eRegCategoria.NombreCategoriaEmpleado)) = Windows.Forms.DialogResult.Yes Then
               operacionSeleccionada.CategoriasEmpleados.Remove(eRegCategoria)
               ugCategoriasEmpleados.Rows.Refresh(RefreshRow.FireInitializeRow)
               FormateGrillaCategoriasEmpleados()
            End If
         End If
      End Sub)
   End Sub
   Private Sub ugCategoriasEmpleados_DoubleClickCell(sender As Object, e As DoubleClickCellEventArgs) Handles ugCategoriasEmpleados.DoubleClickCell
      TryCatched(
      Sub()
         Dim _RegCategoria = ugCategoriasEmpleados.FilaSeleccionada(Of Entidades.MRPProcesoProductivoCategoriaEmpleado)(e.Cell.Row)
         Dim operacionSeleccionada = GetOperacionActiva()
         If _RegCategoria IsNot Nothing AndAlso operacionSeleccionada IsNot Nothing Then
            bscCategoriaEmpleados.Text = _RegCategoria.NombreCategoriaEmpleado
            bscCategoriaEmpleados.Tag = _RegCategoria.IdCategoriaEmpleado
            bscCategoriaEmpleados.Selecciono = True

            txtCantidaCategoriaEmpleado.Text = _RegCategoria.CantidadCategoria.ToString()
            txtValorHoraCategoria.Text = _RegCategoria.ValorHoraCategoria.ToString()
            '------------------------------------------------------------------------------------------------------------
            operacionSeleccionada.CategoriasEmpleados.Remove(_RegCategoria)
            ugCategoriasEmpleados.Rows.Refresh(RefreshRow.FireInitializeRow)
            FormateGrillaCategoriasEmpleados()
            '-- Deshabilito Borrar.- --
            btnEliminarCategoriaEmpleado.Enabled = False
            '-- Posiciona el cursor.- --
            bscCategoriaEmpleados.Focus()
         End If
      End Sub)
   End Sub

   Private Sub ugDetalleTareas_AfterRowActivate(sender As Object, e As EventArgs) Handles ugDetalleTareas.AfterRowActivate
      TryCatched(
      Sub()
         utpProcesosProductivos.Enabled = True
         ErroresTiles(True)
         uttDispositivos.State = uttCentrosProductores.State
         '-- Limpia Campos.- ------------------------------------------------------------------
         LimpiezaDatosOperacion()
         Dim operacionSeleccionada = GetOperacionActiva()
         If operacionSeleccionada IsNot Nothing Then
            With operacionSeleccionada
               '-- Descarga Grilla Necesarios.- -----------------------------------------------
               ugProductosNecesarios.DataSource = .ProductosNecesario
               FormateGrillaNecesarios()
               '-- Descargar Grilla Resultantes.- ---------------------------------------------
               ugProductosResultantes.DataSource = .ProductosResultantes
               FormateGrillaResultantes()
               '-- Descarga Grilla Categorias Empleados.- -------------------------------------
               ugCategoriasEmpleados.DataSource = .CategoriasEmpleados
               FormateGrillaCategoriasEmpleados()
               '-- Descarga Centro Productor.- ------------------------------------------------
               Dim nuevo As Boolean = True
               If .CentroProductorOperacion = 0 Then
                  .CentroProductorOperacion = .IdTareaOperacion
                  nuevo = False
               End If
               If (.CentroProductorOperacion + .IdTareaOperacion) > 0 Then
                  '-- Cargo Centro Productor.- ------------------------------------------------
                  bscCodigoCentroProductor.Text = New Reglas.MRPCentrosProductores().GetUno(.CentroProductorOperacion).CodigoCentroProductor
                  bscCodigoCentroProductor.PresionarBoton()
               End If
               If nuevo Then
                  '-- Descarga Tiempos.- ------------------------------------------------------
                  tsbPAPTiempos = .PAPTiemposMaquina
                  tsbPAPHorasHombre.ValueDecimal = .PAPTiemposHHombre
                  tsbProTiempos.ValueDecimal = .ProdTiemposMaquina
                  tsbProHorasHombre.ValueDecimal = .ProdTiemposHHombre
                  '-- Descarga Normas.- -------------------------------------------------------
                  txtDispositivos.Text = .NormasDispositivos
                  txtMetodos.Text = .NormasMetodos
                  txtSeguridad.Text = .NormasSeguridad
                  txtControlCalidad.Text = .NormasControlCalidad
               End If
               '-- Cargo Proveedor de ser factible.- ------------------------------------------
               If .Proveedor <> 0 Then
                  bscCodigoProveedor.Text = New Reglas.Proveedores().GetUno(.Proveedor, False).CodigoProveedor.ToString()
                  bscCodigoProveedor.PresionarBoton()
               Else
                  txtCostoExterno.Enabled = False
               End If
               txtCostoExterno.Text = .CostoExterno.ToString("N2")
               txtUnidadesHora.Text = .UnidadesHora.ToString("N2")
               '-------------------------------------------------------------------------------
               utpCentrosProductores.Enabled = (operacionSeleccionada.TipoOperacionExterna.ToString() <> Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION.ToString())
               utpProductosNecesarios.Enabled = (operacionSeleccionada.TipoOperacionExterna.ToString() <> Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION.ToString())
               utpProductosResultantes.Enabled = (operacionSeleccionada.TipoOperacionExterna.ToString() <> Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION.ToString())
               utpNormasFabricacion.Enabled = (operacionSeleccionada.TipoOperacionExterna.ToString() <> Entidades.MRPProcesoProductivoOperacion.OperacionesExternas.RECEPCION.ToString())
            End With
         End If
         '-- Posiciona el Cursor.- ------------------------------------------------------------
         bscCodigoCentroProductor.Focus()
         '-------------------------------------------------------------------------------------
      End Sub)
   End Sub

   Protected Overrides Sub Aceptar()
      Dim mensaje = ValidarDetalle()
      If String.IsNullOrEmpty(mensaje) Then
         '-- Recalcula los totales Costo-tiempos.- --------------------------------------------
         CalculaCostosProcesoProductivo(False)
         '-- Cargar Proceso Productivo.- -----------------------------------------------
         CargarProcesoProductivo()
         '-----------------------------------------------------------------------------
         _cargandoInicio = True
         MyBase.Aceptar()
      Else
         MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
      End If
   End Sub

   Private Sub txtCantidaCategoriaEmpleado_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidaCategoriaEmpleado.KeyPress
      TryCatched(
      Sub()
         If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnInsertarCategoriaEmpleado.PerformClick()
         End If
      End Sub)
   End Sub

   Protected Overrides Sub OnClosing(e As ComponentModel.CancelEventArgs)
      TryCatched(
      Sub()
         If DialogResult <> DialogResult.OK Then
            If StateForm = Eniac.Win.StateForm.Consultar Then
               e.Cancel = False
            Else
               e.Cancel = ShowPregunta(String.Format("¿Está seguro de querer cerrar el Proceso Productivo sin guardar? Se perderan los cambios que haya realizado"), MessageBoxDefaultButton.Button2) = DialogResult.No
            End If
         End If
      End Sub)
      MyBase.OnClosing(e)
   End Sub

   Private Sub utpProcesosProductivos_Leave(sender As Object, e As EventArgs) Handles utpProcesosProductivos.Leave
      '-- Carga los datos de las Operaciones.- 
      TryCatched(Sub() CargaDatosOperacion())
   End Sub

   Private Sub txtCodigoProcesoProductivo_Leave(sender As Object, e As EventArgs) Handles txtCodigoProcesoProductivo.Leave
      TryCatched(
       Sub()
          If New Reglas.MRPProcesosProductivos().GetPorCodigoPP(txtCodigoProcesoProductivo.Text).Count > 0 Then
             ShowMessage("El Codigo Ingresado ya fue asignado.")
          End If
       End Sub)
   End Sub

   Private Sub txtUnidadesHora_Leave(sender As Object, e As EventArgs) Handles txtUnidadesHora.Leave
      TryCatched(Sub() CalculaUnidadesHora())
   End Sub

   Private Sub txtUnidadesHora_Enter(sender As Object, e As EventArgs) Handles txtUnidadesHora.Enter
      TryCatched(Sub() CalculaUnidadesHora())
   End Sub

   Private Sub btnErrores_Click(sender As Object, e As EventArgs) Handles btnErrores.Click
      TryCatched(Sub() ErroresTiles(False))
   End Sub
   Private Sub AceptarErrrores_Click(sender As Object, e As EventArgs) Handles btnAceptarErrores.Click
      TryCatched(Sub() ErroresTiles(True))
   End Sub

   Private Sub txtCantidadResultante_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCantidadResultante.KeyPress
      TryCatched(
      Sub()
         If e.KeyChar = Convert.ToChar(Keys.Enter) Then
            btnInsertarProductoResultante.PerformClick()
         End If
      End Sub)
   End Sub

   Private Sub btnRecalculoProcesoProductivo_Click(sender As Object, e As EventArgs) Handles btnRecalculoProcesoProductivo.Click
      '-- Recalcula los totales Costo-tiempos.- --------------------------------------------
      TryCatched(Sub() CalculaCostosProcesoProductivo(True))
   End Sub

   Private Sub cmbDepositoOrigen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbDepositoOrigen.SelectedIndexChanged
      TryCatched(
      Sub()
         Dim dr = cmbDepositoOrigen.ItemSeleccionado(Of DataRow)()
         If dr IsNot Nothing Then
            _publicos.CargaComboUbicaciones(cmbUbicacionOrigen, dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"))
            cmbUbicacionOrigen.SelectedIndex = 0
         End If
      End Sub)
   End Sub

   Private Sub bttn_Adjunto_Click(sender As Object, e As EventArgs) Handles bttn_Adjunto.Click
      TryCatched(
      Sub()
         Dim adjunto = New Reglas.ProductosLinks().GetUno(bscCodigoProductoPrincipal.Text, Integer.Parse(cmbArchivoAdjunto.SelectedValue.ToString()))
         If Not String.IsNullOrWhiteSpace(adjunto.Link) AndAlso System.IO.File.Exists(adjunto.Link) Then
            Dim Proceso = New Process()
            Proceso.StartInfo.FileName = adjunto.Link
            Proceso.Start()
         Else
            ShowMessage(String.Format("Problemas para poder visualizar el archivo Adjunto. {0}El mismo pudo haber sido movido. Comprobar.{0}Documento: {1} ", Environment.NewLine, adjunto.Link))
         End If
      End Sub)
   End Sub

#End Region

#Region "Formateo de Grillas"
   Private Sub FormateGrillaNecesarios()
      ugProductosNecesarios.Rows.Refresh(RefreshRow.ReloadData)
      With ugProductosNecesarios.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         .Columns("IdProductoProceso").FormatearColumna("Producto", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Descripción", pos, 250, HAlign.Left)
         .Columns("NombreMonedaProducto").FormatearColumna("Moneda", pos, 70, HAlign.Left)

         .Columns("CantidadSolicitada").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, "N4")
         .Columns("PrecioCostoProducto").FormatearColumna("Precio Costo", pos, 100, HAlign.Right, , "N4")
         .Columns("CostosProducto").FormatearColumna("Costo Total", pos, 100, HAlign.Right,, "N4")

         .Columns("UnidadMedidaProd").FormatearColumna("U.M.", pos, 70, HAlign.Left)
         .Columns("NombreDeposito").FormatearColumna("Depósito", pos, 120, HAlign.Left)
         .Columns("NombreUbicacion").FormatearColumna("Ubicación", pos, 120, HAlign.Left)

         .Columns("CostosProductoMoneda").FormatearColumna("Costo Final $", pos, 100, HAlign.Right,, "N4")

         .Columns("EsProductoNecesario").Hidden = True
      End With
      ugProductosNecesarios.AgregarFiltroEnLinea({"NombreProducto"})
      ugProductosNecesarios.AgregarTotalesSuma({"CantidadSolicitada", "CostosProductoMoneda"})
   End Sub
   Private Sub FormateGrillaResultantes()
      ugProductosResultantes.Rows.Refresh(RefreshRow.ReloadData)

      With ugProductosResultantes.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         .Columns("IdProductoProceso").FormatearColumna("Producto", pos, 80, HAlign.Right)
         .Columns("NombreProducto").FormatearColumna("Descripción", pos, 300, HAlign.Left)
         .Columns("CantidadSolicitada").FormatearColumna("Cantidad", pos, 80, HAlign.Right,, "N4")
         .Columns("PrecioCostoProducto").FormatearColumna("Precio Costo", pos, 100, HAlign.Right,, "N4")
         .Columns("CostosProducto").FormatearColumna("Costo", pos, 100, HAlign.Right,, "N4")
         .Columns("UnidadMedidaProd").FormatearColumna("U.M.", pos, 70, HAlign.Left)
         .Columns("NombreDeposito").FormatearColumna("Depósito", pos, 120, HAlign.Left)
         .Columns("NombreUbicacion").FormatearColumna("Ubicación", pos, 120, HAlign.Left)
         .Columns("EsProductoNecesario").Hidden = True
      End With
      ugProductosResultantes.AgregarFiltroEnLinea({"NombreProducto"})
      ugProductosResultantes.AgregarTotalesSuma({"PrecioProducto", "CostosProducto"})
   End Sub
   Private Sub FormateGrillaCategoriasEmpleados()
      ugCategoriasEmpleados.Rows.Refresh(RefreshRow.ReloadData)

      With ugCategoriasEmpleados.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         .Columns("NombreCategoriaEmpleado").FormatearColumna("Categoría", pos, 330, HAlign.Left)
         .Columns("ValorHoraCategoria").FormatearColumna("Valor Hora", pos, 120, HAlign.Right,, "N2")
         .Columns("CantidadCategoria").FormatearColumna("Cantidad", pos, 120, HAlign.Right,, "N2")
      End With
      ugCategoriasEmpleados.AgregarTotalesSuma({"CantidadCategoria"})
   End Sub
   Private Sub FormateGrillaTareas()
      '-- Refresca los Datos de la Grilla.- -------------
      ugDetalleTareas.Rows.Refresh(RefreshRow.ReloadData)
      ugDetalleTareas.DisplayLayout.Bands(0).SortedColumns.RefreshSort(True)

      With ugDetalleTareas.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()

         .Columns("Estado").FormatearColumna("", pos, 15, HAlign.Right)
         If Me.StateForm <> Eniac.Win.StateForm.Insertar Then
            .Columns("Visualizar").FormatearColumna("Ver", pos, 30, HAlign.Center)
         End If
         .Columns("CodigoProcProdOperacion").FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns("DescripcionOperacion").FormatearColumna("Descripción", pos, 200, HAlign.Left)

         .Columns("NombreDeposito").FormatearColumna("Deposito", pos, 100, HAlign.Left)
         .Columns("NombreUbicacion").FormatearColumna("Ubicacion", pos, 100, HAlign.Left)
      End With

      If ugDetalleTareas.ActiveRow IsNot Nothing AndAlso ugDetalleTareas.ActiveRow.Cells("EstadoOperacion").Value IsNot Nothing Then
         Select Case ugDetalleTareas.ActiveRow.Cells("EstadoOperacion").Value.ToString()
            Case "NEW"
               btnErrores.Visible = False
               ugDetalleTareas.ActiveRow.Cells("Estado").Color(Nothing, Nothing)
            Case "ERR"
               btnErrores.Visible = _visualizaErrores
               ugErrores.DataSource = _errores
               FormateGrillaErrores()
               ugDetalleTareas.ActiveRow.Cells("Estado").Color(Nothing, Color.Red)
            Case "OKS"
               btnErrores.Visible = False
               ugDetalleTareas.ActiveRow.Cells("Estado").Color(Nothing, Color.Green)
         End Select
      End If
      '---------------------------------------------------------------------------------
   End Sub
   Private Sub FormateGrillaErrores()
      ugErrores.Rows.Refresh(RefreshRow.ReloadData)

      With ugErrores.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         .Columns("IdOperacion").FormatearColumna("Operacion", pos, 80, HAlign.Right)
         .Columns("Descripcion").FormatearColumna("Descripción", pos, 450, HAlign.Left)
      End With
      ugErrores.AgregarFiltroEnLinea({"IdOperacion", "Descripcion"})
   End Sub
   Private Sub FormateGrillaErroresActivacion()
      ugErrores.Rows.Refresh(RefreshRow.ReloadData)

      With ugErrores.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         '-- Oculta las Columnas.- -------------------------
         .OcultaTodasLasColumnas()
         .Columns("IdOperacion").FormatearColumna("Proceso Productivo", pos, 100, HAlign.Right)
         .Columns("Descripcion").FormatearColumna("Descripción", pos, 450, HAlign.Left)
      End With
      ugErrores.AgregarFiltroEnLinea({"IdOperacion", "Descripcion"})
   End Sub
#End Region

#Region "Limpieza Campos"
   Private Sub LimpiaCamposTareas()
      bscNombreTareas.Text = String.Empty
      txtCodigoTarea.Text = String.Empty
      cmbDepositoTarea.SelectedIndex = 0
   End Sub
   Private Sub LimpiaNecesarios()
      bscCodigoProductoNecesario.Text = String.Empty
      bscNombreProductoNecesario.Text = String.Empty
      txtCantidadNecesaria.Text = "0.0000"
      txtMonedaNecesario.Text = String.Empty
      cmbDepositoOrigen.SelectedIndex = 0
      cmbUbicacionOrigen.SelectedIndex = 0
      txtUnidadMedidaProdNec.Text = String.Empty
      bscCodigoProductoNecesario.Focus()
   End Sub
   Private Sub LimpiaResultantes()
      bscCodigoProductoResultante.Text = String.Empty
      bscNombreProductoResultante.Text = String.Empty
      txtCantidadResultante.Text = "0.0000"
      bscCodigoProductoResultante.Focus()
   End Sub
   Private Sub LimpiaCentroProductor()
      bscCodigoCentroProductor.Text = String.Empty
      bscCentrosProductores.Text = String.Empty
      txtClaseCentroProductor.Text = String.Empty
      txtDotacionCentroProductor.Text = "0"
      txtUnidadesHora.Text = "1.00"
      bscCodigoProveedor.Text = String.Empty
      bscNombreProveedor.Text = String.Empty
      txtCostoExterno.Text = "0.00"
      tsbPAPTiempos = 0
      tsbPAPHorasHombre.ValueDecimal = 0
      tsbProTiempos.ValueDecimal = 0
      tsbProHorasHombre.ValueDecimal = 0
      LimpiaCategoriaEmpleados()
   End Sub
   Private Sub LimpiaCategoriaEmpleados()
      bscCategoriaEmpleados.Text = String.Empty
      bscCategoriaEmpleados.Tag = String.Empty
      txtValorHoraCategoria.Text = "0.00"
      txtCantidaCategoriaEmpleado.Text = "0"
   End Sub
   Private Sub LimpiezaDatosOperacion()
      utpCentrosProductores.Enabled = True
      utpProductosNecesarios.Enabled = True
      utpProductosResultantes.Enabled = True
      utpNormasFabricacion.Enabled = True
      '-- Limpia Campos.- ------------------------------
      bscCodigoCentroProductor.Text = String.Empty
      bscCentrosProductores.Text = String.Empty
      txtClaseCentroProductor.Text = String.Empty
      txtDotacionCentroProductor.Text = "0"
      bscCodigoProveedor.Text = String.Empty
      bscNombreProveedor.Text = String.Empty
      txtCostoExterno.Text = "0.00"
      bscCategoriaEmpleados.Text = String.Empty
      txtCantidaCategoriaEmpleado.Text = "0"
      '-- Limpia Normas.- -----------------------------------
      bscNormasFabricacion.Text = String.Empty
      txtDispositivos.Text = String.Empty
      txtMetodos.Text = String.Empty
      txtSeguridad.Text = String.Empty
      txtControlCalidad.Text = String.Empty
   End Sub
   Private Sub ErroresTiles(tipoErr As Boolean)
      uttCentrosProductores.Visible = tipoErr
      uttProductosNecesarios.Visible = tipoErr
      uttProductosResultantes.Visible = tipoErr
      uttNormasFabricacion.Visible = tipoErr
      uttErrores.Visible = Not tipoErr
   End Sub

#End Region

End Class
Public Class MRPErrores
   Public Enum Columnas
      IdOperacion
      Descripcion
   End Enum
   Public Sub New()
      IdOperacion = String.Empty
      Descripcion = String.Empty
   End Sub

   Public Property IdOperacion As String
   Public Property Descripcion As String

End Class
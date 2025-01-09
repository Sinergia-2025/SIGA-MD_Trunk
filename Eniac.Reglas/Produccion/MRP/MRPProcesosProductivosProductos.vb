#Region "Option"
Option Strict On
Option Explicit On
#End Region
Imports Eniac.Entidades

Public Class MRPProcesosProductivosProductos
   Inherits Base

   Dim conta As Integer = 0

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = MRPProcesoProductivoProducto.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- -----------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoProducto), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoProducto), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoProducto), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ---------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoProducto), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoProducto), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, MRPProcesoProductivoProducto), TipoSP._D)
   End Sub
   '-------------------------------------------------------------------------------------------------
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosProductos(Me.da).ProcesosProductivosProductos_GA()
   End Function

   Public Function _GetAll(idProcesoProductivo As Long, idOperacion As Integer, esNecesario As Entidades.Publicos.SiNoTodos) As System.Data.DataTable
      Return New SqlServer.MRPProcesosProductivosProductos(Me.da).ProcesosProductivosProductos_GA(idProcesoProductivo, idOperacion, esNecesario)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPProcesoProductivoProducto, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPProcesosProductivosProductos(da)
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Procesos Productivos Productos.- --------
            sqlC.ProcesosProductivosProductos_I(en.IdOperacion, en.IdProcesoProductivo, en.IdProductoProceso, en.CantidadSolicitada, en.PrecioCostoProducto,
                                                en.EsProductoNecesario, en.IdSucursalOrigen, en.IdDepositoOrigen, en.IdUbicacionOrigen)
         Case TipoSP._U
            '-- Modifica Procesos Productivos Productos.- --------------------
            sqlC.ProcesosProductivosProductos_U(en.IdOperacion, en.IdProcesoProductivo, en.IdProductoProceso, en.CantidadSolicitada, en.PrecioCostoProducto,
                                                en.EsProductoNecesario, en.IdSucursalOrigen, en.IdDepositoOrigen, en.IdUbicacionOrigen)
         Case TipoSP._D
            '-- Elimina Procesos Productivos Productos.- --------------------
            sqlC.ProcesosProductivosProductos_D(en.IdOperacion, en.IdProcesoProductivo, en.IdProductoProceso)
      End Select
   End Sub
   Private Sub CargarUno(o As MRPProcesoProductivoProducto, dr As DataRow)
      With o
         .IdOperacion = dr.Field(Of Integer)(MRPProcesoProductivoProducto.Columnas.IdOperacion.ToString())
         .IdProcesoProductivo = dr.Field(Of Long)(MRPProcesoProductivoProducto.Columnas.IdProcesoProductivo.ToString())
         .IdProductoProceso = dr.Field(Of String)(MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString())
         .CantidadSolicitada = dr.Field(Of Decimal)(MRPProcesoProductivoProducto.Columnas.CantidadSolicitada.ToString())
         .PrecioCostoProducto = dr.Field(Of Decimal)(MRPProcesoProductivoProducto.Columnas.PrecioCostoProducto.ToString())
         .CostosProducto = dr.Field(Of Decimal)(MRPProcesoProductivoProducto.Columnas.CantidadSolicitada.ToString()) * dr.Field(Of Decimal)(MRPProcesoProductivoProducto.Columnas.PrecioCostoProducto.ToString())

         .EsProductoNecesario = dr.Field(Of Boolean)(MRPProcesoProductivoProducto.Columnas.EsProductoNecesario.ToString())
         Dim eProd = New Reglas.Productos().GetUno(dr.Field(Of String)(MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString()), False, True)
         .NombreProducto = eProd.NombreProducto
         .UnidadMedidaProd = eProd.UnidadDeMedida.NombreUnidadDeMedida

         Dim cotiza = New Reglas.Monedas().GetUna(eProd.Moneda.IdMoneda).FactorConversion
         .NombreMonedaProducto = eProd.Moneda.NombreMoneda
         .CostosProductoMoneda = .PrecioCostoProducto * cotiza

         .IdSucursalOrigen = dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdSucursalOrigen.ToString()).IfNull()
         .IdDepositoOrigen = dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdDepositoOrigen.ToString()).IfNull()
         .NombreDeposito = New Reglas.SucursalesDepositos().GetUno(dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdDepositoOrigen.ToString()).IfNull(),
                                                                   dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdSucursalOrigen.ToString()).IfNull()).NombreDeposito
         .IdUbicacionOrigen = dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdUbicacionOrigen.ToString()).IfNull()
         .NombreUbicacion = New Reglas.SucursalesUbicaciones().GetUno(dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdDepositoOrigen.ToString()).IfNull(),
                                                                      dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdSucursalOrigen.ToString()).IfNull(),
                                                                      dr.Field(Of Integer?)(MRPProcesoProductivoProducto.Columnas.IdUbicacionOrigen.ToString()).IfNull()).NombreUbicacion
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodos(IdProcesoProductivo As Long, idOperacion As Integer, esNecesario As Entidades.Publicos.SiNoTodos) As ListConBorrados(Of MRPProcesoProductivoProducto)
      Dim dt = _GetAll(IdProcesoProductivo, idOperacion, esNecesario)
      Dim o As MRPProcesoProductivoProducto
      Dim oLis = New ListConBorrados(Of MRPProcesoProductivoProducto)
      For Each dr As DataRow In dt.Rows
         o = New MRPProcesoProductivoProducto
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Sub ActualizaProcesosProductivosProductos(entidad As MRPProcesoProductivoOperacion)
      If entidad.ProductosNecesario IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.ProductosNecesario.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPN In entidad.ProductosNecesario
            If oPN.IdOperacion = 0 And oPN.IdProcesoProductivo = 0 Then
               oPN.IdOperacion = entidad.IdOperacion
               oPN.IdProcesoProductivo = entidad.IdProcesoProductivo
               _Insertar(oPN)
            Else
               _Actualizar(oPN)
            End If
         Next
         '----------------------------------------------------------------------------
      End If
      If entidad.ProductosResultantes IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.ProductosResultantes.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPR In entidad.ProductosResultantes
            If oPR.IdOperacion = 0 And oPR.IdProcesoProductivo = 0 Then
               oPR.IdOperacion = entidad.IdOperacion
               oPR.IdProcesoProductivo = entidad.IdProcesoProductivo
               _Insertar(oPR)
            Else
               _Actualizar(oPR)
            End If
         Next
         '----------------------------------------------------------------------------
      End If
   End Sub

   Public Sub ObtieneListaNecesariosRequerimento(idProceso As Long, eNesesarios As List(Of Entidades.MRPProductosNecesarios), cantidadPadre As Decimal, drP As DataRow, ByRef nodoPadre As Integer)
      Dim dt = New SqlServer.MRPProcesosProductivosProductos(da).ObtieneListaNecesarios(idProceso, True)
      For Each dr As DataRow In dt.Rows
         conta += 1
         Dim ePN As New Entidades.MRPProductosNecesarios
         With ePN
            .nodo = conta
            .IdSucursal = drP.Field(Of Integer)("IdSucursal")
            .IdTipoComprobante = drP.Field(Of String)("IdTipoComprobante")
            .LetraComprobante = drP.Field(Of String)("Letra")
            .CentroEmisor = drP.Field(Of Integer)("CentroEmisor")
            .NumeroOrdenProduccion = drP.Field(Of Integer)("NumeroOrdenProduccion")
            .Orden = drP.Field(Of Integer)("Orden")
            .FechaEntrega = drP.Field(Of DateTime)("FechaEntrega")
            .FechaFinaliza = drP.Field(Of DateTime)("FechaEstado")
            .IdProductoProceso = dr.Field(Of String)(MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString())
            .NombreProductoProceso = dr.Field(Of String)("NombreProducto")
            .CantidadSolicitada = dr.Field(Of Decimal)(MRPProcesoProductivoProducto.Columnas.CantidadSolicitada.ToString()) * cantidadPadre
            .EsProductoNecesario = True
            .nodoPadre = nodoPadre
            '--
            eNesesarios.Add(ePN)
            ObtieneListaNecesariosRequerimento(ePN.IdProcesoProductivo, eNesesarios, ePN.CantidadSolicitada, drP, .nodo)
            '--
         End With
      Next
   End Sub

   Public Function ValidaMRPProcesosProductosDepositos(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = New SqlServer.MRPProcesosProductivosProductos(da).GetCantidadSucursalesDepositos(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function

   Public Function ValidaProductosResultanteAsignadoOtroPP(idProducto As String, idProductoProceso As String) As DataTable
      Return New SqlServer.MRPProcesosProductivosProductos(da).GetProductoExisteEnOtroPP(idProducto, idProductoProceso)
   End Function

#End Region
End Class

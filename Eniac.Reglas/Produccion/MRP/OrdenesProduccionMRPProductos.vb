#Region "Option"
Option Strict On
Option Explicit On
#End Region
Imports System.Drawing
Imports System.Net
Imports Eniac.Entidades

Public Class OrdenesProduccionMRPProductos
   Inherits Base

   Dim conta As Integer = 0

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = OrdenProduccionMRPProducto.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   '-- Con Transaccion.- --------------------------------------------------------------------------------------------
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPProducto), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPProducto), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPProducto), TipoSP._D))
   End Sub
   '-- Sin transacciones.- ------------------------------------------------------------------------------------------
   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPProducto), TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPProducto), TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, OrdenProduccionMRPProducto), TipoSP._D)
   End Sub
   '-----------------------------------------------------------------------------------------------------------------
   Public Function _GetAll(idSucursal As Integer,
                           idTipoComprobante As String,
                           letra As String,
                           centroEmisor As Integer,
                           numeroOrdenProduccion As Long,
                           orden As Integer,
                           idProducto As String,
                           idProcesosProductivos As Long,
                           idOperacion As Integer,
                           esNecesario As Entidades.Publicos.SiNoTodos) As System.Data.DataTable

      Return New SqlServer.OrdenesProduccionMRPProductos(Me.da).OrdenesProduccionMRPProductos_GA(idSucursal:=idSucursal,
                                                                                                 idTipoComprobante:=idTipoComprobante,
                                                                                                 letra:=letra,
                                                                                                 centroEmisor:=centroEmisor,
                                                                                                 numeroOrdenProduccion:=numeroOrdenProduccion,
                                                                                                 orden:=orden,
                                                                                                 idProducto:=idProducto,
                                                                                                 idProcesoProductivo:=idProcesosProductivos,
                                                                                                 idOperacion:=idOperacion,
                                                                                                 esNecesario:=esNecesario)
   End Function

#End Region

#Region "Metodos Privados"
   Private Function GetSQL() As SqlServer.OrdenesProduccionMRPProductos
      Return New SqlServer.OrdenesProduccionMRPProductos(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.OrdenProduccionMRPProducto, tipo As TipoSP)
      Dim sqlC = GetSQL()
      Select Case tipo
         Case TipoSP._I
            '-- Inserta Orden de Produccion MRP Productos.- --------
            sqlC.OrdenesProduccionMRPProductos_I(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                                 en.MRPProducto.IdProcesoProductivo, en.MRPProducto.IdOperacion, en.MRPProducto.IdProductoProceso, en.MRPProducto.CantidadSolicitada,
                                                 en.MRPProducto.PrecioCostoProducto, en.MRPProducto.EsProductoNecesario, en.MRPProducto.IdSucursalOrigen, en.MRPProducto.IdDepositoOrigen,
                                                 en.MRPProducto.IdUbicacionOrigen, en.EstadoCompra, en.CantidadProcesada, en.CantidadUnitaria)
         Case TipoSP._U
            '-- Modifica Orden de Produccion MRP Productos.- --------
            sqlC.OrdenesProduccionMRPProductos_U(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                                 en.MRPProducto.IdProcesoProductivo, en.MRPProducto.IdOperacion, en.MRPProducto.IdProductoProceso, en.MRPProducto.CantidadSolicitada,
                                                 en.MRPProducto.PrecioCostoProducto, en.MRPProducto.EsProductoNecesario, en.MRPProducto.IdSucursalOrigen, en.MRPProducto.IdDepositoOrigen,
                                                 en.MRPProducto.IdUbicacionOrigen, en.CantidadProcesada, en.CantidadUnitaria)
         Case TipoSP._D
            '-- Elimina ORden de Produccion MRP Productos.- --------------------
            sqlC.OrdenesProduccionMRPProductos_D(en.IdSucursal, en.IdTipoComprobante, en.LetraComprobante, en.CentroEmisor, en.NumeroOrdenProduccion, en.Orden, en.IdProducto,
                                                 en.MRPProducto.IdProcesoProductivo, en.MRPProducto.IdOperacion, en.MRPProducto.IdProductoProceso, en.MRPProducto.EsProductoNecesario)
      End Select
   End Sub
   Private Sub CargarUno(o As OrdenProduccionMRPProducto, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.IdSucursal.ToString())
         .IdTipoComprobante = dr.Field(Of String)(OrdenProduccionMRPProducto.Columnas.IdTipoComprobante.ToString())
         .LetraComprobante = dr.Field(Of String)(OrdenProduccionMRPProducto.Columnas.LetraComprobante.ToString())
         .CentroEmisor = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.CentroEmisor.ToString())
         .NumeroOrdenProduccion = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.NumeroOrdenProduccion.ToString())
         .Orden = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.Orden.ToString())
         .IdProducto = dr.Field(Of String)(OrdenProduccionMRPProducto.Columnas.IdProducto.ToString())
         .CantidadProcesada = dr.Field(Of Decimal)(OrdenProduccionMRPProducto.Columnas.CantidadProcesada.ToString())
         .CantidadUnitaria = dr.Field(Of Decimal)(OrdenProduccionMRPProducto.Columnas.CantidadUnitaria.ToString())
         With .MRPProducto
            .IdOperacion = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.IdOperacion.ToString())
            .IdProcesoProductivo = dr.Field(Of Long)(OrdenProduccionMRPProducto.Columnas.IdProcesoProductivo.ToString())
            .IdProductoProceso = dr.Field(Of String)(OrdenProduccionMRPProducto.Columnas.IdProductoProceso.ToString())
            .NombreProducto = dr.Field(Of String)("NombreProductoSecundario")
            .UnidadMedidaProd = dr.Field(Of String)("UnidadMedidaSecundaria")
            .CantidadSolicitada = dr.Field(Of Decimal)(OrdenProduccionMRPProducto.Columnas.CantidadSolicitada.ToString())
            .PrecioCostoProducto = dr.Field(Of Decimal)(OrdenProduccionMRPProducto.Columnas.PrecioCostoProducto.ToString())
            .EsProductoNecesario = dr.Field(Of Boolean)(OrdenProduccionMRPProducto.Columnas.EsProductoNecesario.ToString())
            If Not String.IsNullOrEmpty(dr("IdDepositoOrigen").ToString()) Then
               .IdSucursalOrigen = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.IdSucursalOrigen.ToString())
               .IdDepositoOrigen = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.IdDepositoOrigen.ToString())
               .IdUbicacionOrigen = dr.Field(Of Integer)(OrdenProduccionMRPProducto.Columnas.IdUbicacionOrigen.ToString())
            End If
         End With
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            numeroOrdenProduccion As Long,
                            orden As Integer,
                            idProducto As String,
                            idProcesosProductivos As Long,
                            idOperacion As Integer,
                            esNecesario As Entidades.Publicos.SiNoTodos) As ListConBorrados(Of OrdenProduccionMRPProducto)
      Dim dt = _GetAll(idSucursal:=idSucursal,
                       idTipoComprobante:=idTipoComprobante,
                       letra:=letra,
                       centroEmisor:=centroEmisor,
                       numeroOrdenProduccion:=
                       numeroOrdenProduccion,
                       orden:=orden,
                       idProducto:=idProducto,
                       idProcesosProductivos:=idProcesosProductivos,
                       idOperacion:=idOperacion,
                       esNecesario:=esNecesario)
      Dim o As OrdenProduccionMRPProducto
      Dim oLis = New ListConBorrados(Of OrdenProduccionMRPProducto)
      For Each dr As DataRow In dt.Rows
         o = New OrdenProduccionMRPProducto
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function
   Public Sub ActualizaDesdeOrdenesProduccionMRPOperaciones(entidad As OrdenProduccionMRPOperacion)
      '-------------------------------------------------------------------------------
      If entidad.ProductosNecesarios IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.ProductosNecesarios.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPN In entidad.ProductosNecesarios
            If oPN.NumeroOrdenProduccion > 0 Then
               _Actualizar(oPN)
            Else
               With oPN
                  .IdSucursal = entidad.IdSucursal
                  .IdTipoComprobante = entidad.IdTipoComprobante
                  .LetraComprobante = entidad.LetraComprobante
                  .CentroEmisor = entidad.CentroEmisor
                  .NumeroOrdenProduccion = entidad.NumeroOrdenProduccion
                  .Orden = entidad.Orden
                  .IdProducto = entidad.IdProducto
                  .EstadoCompra = "PENDIENTE"
               End With
               _Insertar(oPN)
            End If
         Next
         '----------------------------------------------------------------------------
      End If
      '-------------------------------------------------------------------------------
      If entidad.ProductosResultantes IsNot Nothing Then
         '-- Elimina los Borrados.- --------------------------------------------------
         For Each ent In entidad.ProductosResultantes.Borrados
            _Borrar(ent)
         Next
         '----------------------------------------------------------------------------
         For Each oPR In entidad.ProductosResultantes
            If oPR.NumeroOrdenProduccion > 0 Then
               _Actualizar(oPR)
            Else
               With oPR
                  .IdSucursal = entidad.IdSucursal
                  .IdTipoComprobante = entidad.IdTipoComprobante
                  .LetraComprobante = entidad.LetraComprobante
                  .CentroEmisor = entidad.CentroEmisor
                  .NumeroOrdenProduccion = entidad.NumeroOrdenProduccion
                  .Orden = entidad.Orden
                  .IdProducto = entidad.IdProducto
               End With
               _Insertar(oPR)
            End If
         Next
         '----------------------------------------------------------------------------
      End If
      '-------------------------------------------------------------------------------
   End Sub

   Public Function CopiaOrdenProduccionMRPProductos(operacion As MRPProcesoProductivoOperacion, cantidad As Decimal, idSucursal As Integer, idProducto As String, esNecesario As Entidades.Publicos.SiNoTodos) As ListConBorrados(Of OrdenProduccionMRPProducto)
      Dim eOPMrpPrs = New ListConBorrados(Of OrdenProduccionMRPProducto)()
      For Each eProcProdPR In If(esNecesario = Entidades.Publicos.SiNoTodos.SI, operacion.ProductosNecesario, operacion.ProductosResultantes)
         Dim eOPMrpPr = New Entidades.OrdenProduccionMRPProducto()
         With eOPMrpPr
            .IdSucursal = idSucursal
            .IdProducto = idProducto
            .CantidadUnitaria = eProcProdPR.CantidadSolicitada
            With .MRPProducto
               .IdOperacion = eProcProdPR.IdOperacion
               .IdProcesoProductivo = eProcProdPR.IdProcesoProductivo
               .IdProductoProceso = eProcProdPR.IdProductoProceso
               .CantidadSolicitada = (eProcProdPR.CantidadSolicitada * cantidad)
               .PrecioCostoProducto = (eProcProdPR.PrecioCostoProducto)
               .EsProductoNecesario = (esNecesario = Entidades.Publicos.SiNoTodos.SI)
               .IdSucursalOrigen = eProcProdPR.IdSucursalOrigen
               .IdDepositoOrigen = eProcProdPR.IdDepositoOrigen
               .IdUbicacionOrigen = eProcProdPR.IdUbicacionOrigen
            End With
         End With
         eOPMrpPrs.Add(eOPMrpPr)
      Next
      Return eOPMrpPrs
   End Function

   Public Sub VinculaOrdenProduccion(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroOrdenProduccion As Long, orden As Integer,
                                     esNecesario As Boolean, idProducto As String,
                                     idSucursalOP As Integer, idTipoComprobanteOP As String, letraOP As String, centroEmisorOP As Integer, numeroOrdenProduccionOP As Long, ordenOP As Integer)
      Dim sqlC = GetSQL()
      sqlC.VinculaOrdenProduccion(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden,
                                  esNecesario, idProducto,
                                  idSucursalOP, idTipoComprobanteOP, letraOP, centroEmisorOP, numeroOrdenProduccionOP, ordenOP)
   End Sub
   Public Sub VinculaRequerimientosCompra(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroOrdenProduccion As Long,
                                          orden As Integer,
                                          esNecesario As Integer,
                                          idProducto As String,
                                          idRequerimientoCompra As Long, ordenRQ As Integer)
      Dim sqlC = GetSQL()

      sqlC.VinculaRequerimientoCompra(idSucursal:=idSucursal,
                                      idTipoComprobante:=idTipoComprobante,
                                      letra:=letra,
                                      centroEmisor:=centroEmisor,
                                      numeroOrdenProduccion:=numeroOrdenProduccion,
                                      orden:=orden,
                                      esNecesario:=esNecesario,
                                      idProducto:=idProducto,
                                      idRequerimientoCompra:=idRequerimientoCompra, ordenRQ:=ordenRQ)
   End Sub

   Public Sub ActualizarEstadoOrdenProdMRPPro(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroOrdenProduccion As Long,
                                              orden As Integer,
                                              esNecesario As Boolean,
                                              idProducto As String,
                                              newEstado As String)
      Dim sqlC = GetSQL()
      sqlC.ActualizarEstadoOrdenProdMRPPro(idSucursal, idTipoComprobante, letra, centroEmisor, numeroOrdenProduccion, orden,
                                           esNecesario, idProducto,
                                           newEstado)
   End Sub
   Public Sub ActualizarCantidadOrdProdMRPPro(idSucursal As Integer,
                                              idTipoComprobante As String,
                                              letra As String,
                                              centroEmisor As Integer,
                                              numeroOrdenProduccion As Long,
                                              orden As Integer,
                                              IdProcesoProductivio As Long,
                                              idProducto As String,
                                              idOperacion As Integer,
                                              esNecesario As Boolean,
                                              cantidadProceso As Decimal)
      Dim sqlC = GetSQL()

      sqlC.ActualizarCantidadOrdProdMRPPro(idSucursal,
                                           idTipoComprobante,
                                           letra,
                                           centroEmisor,
                                           numeroOrdenProduccion,
                                           orden,
                                           IdProcesoProductivio,
                                           idProducto,
                                           idOperacion,
                                           esNecesario,
                                           cantidadProceso)
   End Sub

   Public Sub ObtieneListaNecesarios(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, nrocomprobante As Integer,
                                     idProceso As Long, eNesesarios As List(Of Entidades.MRPProductosNecesarios), cantidadPadre As Decimal, drP As DataRow,
                                     ByRef nodoPadre As Integer, idProductoPadre As String, OP As OrdenProduccion)

      Dim dt = New DataTable
      If nodoPadre = 0 Then
         dt = GetSQL().ObtieneListaNecesariosP(idSucursal, idTipoComprobante, letra, centroEmisor,
                                                                                      nrocomprobante, idProceso, False, idProductoPadre)
      Else
         dt = GetSQL().ObtieneListaNecesarios(idProceso, False, idProductoPadre)
      End If
      For Each dr As DataRow In dt.Rows
         conta += 1
         Dim ePN As New Entidades.MRPProductosNecesarios
         With ePN
            '--------------------------------------------
            .Cliente = OP.Cliente
            .Transportista = OP.Transportista
            .FormaPago = OP.FormaPago
            .TipoComprobanteFact = OP.TipoComprobanteFact
            .EstadoVisita = OP.EstadoVisita
            '--------------------------------------------
            .nodo = conta
            .IdSucursal = drP.Field(Of Integer)("IdSucursal")
            .IdTipoComprobante = drP.Field(Of String)("IdTipoComprobante")
            .LetraComprobante = drP.Field(Of String)("Letra")
            .CentroEmisor = drP.Field(Of Integer)("CentroEmisor")
            .NumeroOrdenProduccion = drP.Field(Of Integer)("NumeroOrdenProduccion")
            .Orden = drP.Field(Of Integer)("Orden")
            .FechaEntrega = drP.Field(Of DateTime)("FechaEntrega")
            .FechaFinaliza = drP.Field(Of DateTime)("FechaEstado")
            .IdProcesoProductivo = dr.Field(Of Long)("IdProcesoProductivoDefecto")
            .TiempoProcesoProductivo = dr.Field(Of Decimal)("TiempoTotalProceso")
            .IdProductoProceso = dr.Field(Of String)(MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString())
            .NombreProductoProceso = dr.Field(Of String)("NombreProducto")
            '-- PE-41030.- ---------------------------------------------------------------------------------------------------------------------------------------
            .CantidadSolicitada = dr.Field(Of Decimal)("CantidadUnitaria") * cantidadPadre
            .CantidadUnitaria = dr.Field(Of Decimal)("CantidadUnitaria")
            '-- REQ-42263.- --------------------------------------------------------------------------------------------------------------------------------------
            .ProcesoActivo = dr.Field(Of Boolean)("ProcesoActivo")
            '-----------------------------------------------------------------------------------------------------------------------------------------------------
            .CantidadProcesoProd = dr.Field(Of Decimal)(MRPProcesoProductivoProducto.Columnas.CantidadSolicitada.ToString())
            .EsProductoNecesario = True
            .DepositoDefecto = dr.Field(Of Integer)("IdDepositoOrigen")
            .nodoPadre = nodoPadre
            '--
            eNesesarios.Add(ePN)
            ObtieneListaNecesarios(0, String.Empty, String.Empty, 0, 0, ePN.IdProcesoProductivo, eNesesarios, ePN.CantidadSolicitada, drP, .nodo, dr.Field(Of String)(MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString()), OP)
            '--
         End With
      Next
   End Sub
   Public Sub ObtieneListaNecesariosRequerimento(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, nrocomprobante As Integer, idcliente As Long, nombrecliente As String,
                                                 idProceso As Long, eNesesarios As List(Of Entidades.MRPProductosNecesarios), cantidadPadre As Decimal, drP As DataRow, ByRef nodoPadre As Integer)

      Dim dt = New DataTable
      If nodoPadre = 0 Then
         dt = GetSQL().ObtieneListaNecesariosP(idSucursal, idTipoComprobante, letra, centroEmisor,
                                                                                      nrocomprobante, idProceso, True, String.Empty)
      Else
         dt = GetSQL().ObtieneListaNecesarios(idProceso, True, String.Empty)
      End If
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

            .IdCriticidad = drP.Field(Of String)("IdCriticidad")
            .IdResponsable = drP.Field(Of Integer)("IdResponsable")

            .FechaFinaliza = drP.Field(Of DateTime)("FechaEstado")
            .IdProductoProceso = dr.Field(Of String)(MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString())
            .NombreProductoProceso = dr.Field(Of String)("NombreProducto")
            '-- PE-41030.- ---------------------------------------------------------------------------------------------------------------------------------------
            .CantidadSolicitada = dr.Field(Of Decimal)("CantidadUnitaria") * cantidadPadre
            .CantidadUnitaria = dr.Field(Of Decimal)("CantidadUnitaria")
            '-- PE-42158.- ---------------------------------------------------------------------------------------------------------------------------------------
            .IdProductoOrigen = drP.Field(Of String)("IdProducto")
            '-----------------------------------------------------------------------------------------------------------------------------------------------------
            .EsProductoNecesario = True
            .DepositoDefecto = dr.Field(Of Integer)("IdDepositoOrigen")
            Dim ePro = New Reglas.Productos().GetUno(dr.Field(Of String)(MRPProcesoProductivoProducto.Columnas.IdProductoProceso.ToString()))
            .UnidadMedidaDestino = If(ePro.KilosEsUMCompras, "KGS.", ePro.UnidadDeMedida.NombreUnidadDeMedida)
            .UnidadMedidaCompra = ePro.UnidadDeMedidaCompra.IdUnidadDeMedida
            .StockMaximo = ePro.StockMaximo
            .StockMinimo = ePro.StockMinimo
            .IdCliente = idcliente
            .NombreCliente = nombrecliente
            .nodoPadre = nodoPadre
            '--
            eNesesarios.Add(ePN)
            ObtieneListaNecesariosRequerimento(0, String.Empty, String.Empty, 0, 0, idcliente, nombrecliente, ePN.IdProcesoProductivo, eNesesarios, ePN.CantidadSolicitada, drP, .nodo)
            '--
         End With
      Next
   End Sub


   Public Function CalculaNecesidadesGrilla(eProdNec As List(Of Entidades.MRPProductosNecesarios), eTipDep As Entidades.Publicos.SiNoTodos, eDepD As Integer, infCompleto As Boolean) As List(Of Entidades.MRPProductosNecesarios)

      Dim lStockVirtual As New List(Of StockVirtual)
      '-- Agrupo por cada producto y cantidad stock.-
      Dim gPs = From Rows In eProdNec
                Group Rows By Rows.IdProductoProceso, Rows.CantidadStock Into Group
      '-- Obtengo Stock Virtual por cada producto.-
      For Each oPn In gPs
         Dim eStockVirtual As New StockVirtual
         '-- Obtiene Stock en relacion al Deposito.-
         Dim depDef = New Reglas.ProductosSucursales().GetUno(actual.Sucursal.IdSucursal, oPn.IdProductoProceso).IdDepositoDefecto
         '-- Carga los datos de Stock.- 
         With eStockVirtual
            .IdProducto = oPn.IdProductoProceso.ToString()
            .CantidadStock = GetStockNecesidades(oPn.IdProductoProceso.ToString(), eTipDep, If(eTipDep = Entidades.Publicos.SiNoTodos.SI, depDef, eDepD))
         End With
         lStockVirtual.Add(eStockVirtual)
      Next
      '-- Calculo Padre Stock Padres.-
      For Each oPn In eProdNec
         '-- Busca Stock virtual.- 
         Dim valorStock = lStockVirtual.Where(Function(x) x.IdProducto = oPn.IdProductoProceso)
         '-- Obtiene Stock
         oPn.CantidadStock = valorStock.ElementAt(0).CantidadStock
         If (oPn.CantidadStock - oPn.CantidadSolicitada) > 0 Then
            oPn.CantidadFabricar = 0
            valorStock.ElementAt(0).CantidadStock -= oPn.CantidadSolicitada
         Else
            oPn.CantidadFabricar = (oPn.CantidadStock - oPn.CantidadSolicitada) * -1
            valorStock.ElementAt(0).CantidadStock = 0
         End If
         Dim hPN = eProdNec.Where(Function(x) x.nodoPadre = oPn.nodo).ToList()
         If hPN.Count > 0 Then
            hPN.ElementAt(0).CantidadSolicitada = oPn.CantidadFabricar * hPN.ElementAt(0).CantidadUnitaria
         End If
      Next
      If infCompleto Then
         Return eProdNec.OrderBy(Function(x) x.nodo).ToList()
      End If
      Return eProdNec.OrderBy(Function(x) x.nodo).Where(Function(x) x.CantidadSolicitada > 0).ToList()

   End Function

   Private Function GetStockNecesidades(eProd As String, eTipDep As Entidades.Publicos.SiNoTodos, eDepD As Integer) As Decimal
      If eTipDep = Entidades.Publicos.SiNoTodos.TODOS Then
         Return New Reglas.ProductosSucursales().GetSucursalProductosStock(actual.Sucursal.IdSucursal, eProd.ToString())
      End If
      Return New Reglas.ProductosSucursales().GetSucursalesDepositoStock(actual.Sucursal.IdSucursal, eDepD, eProd.ToString())
   End Function

   Public Function ValidaOrdenesProduccionProductosDepositos(idSucursal As Integer, IdDeposito As Integer) As Boolean
      Dim dt = GetSQL().GetCantidadSucursalesDepositos(idSucursal, IdDeposito)
      Return dt.Rows(0).Field(Of Integer)("Cantidad") > 0
   End Function

   Public Function GetInformeProductos(idEstado As Publicos.EstadoAsignaTarea?, codigoProcProdOperacion As String, fechaDesde As Date?, fechaHasta As Date?,
                                       idTipoComprobante As String, letraFiscal As String, centroEmisor As Integer, numeroDesde As Long, numeroHasta As Long,
                                       idProducto As String, idCliente As Long?,
                                       idTipoComprobantePedido As String, letraFiscalPedido As String, centroEmisorPedido As Integer, numeroPedidoDesde As Long, numeroPedidoHasta As Long, lineaPedido As Integer,
                                       planMaestroNumero As Integer, esResultante As Entidades.Publicos.SiNoTodos) As DataTable
      Return GetSQL().GetInformeProductos(If(idEstado.HasValue, idEstado.ToString(), String.Empty), codigoProcProdOperacion, fechaDesde, fechaHasta,
                                          idTipoComprobante, letraFiscal, centroEmisor, numeroDesde, numeroHasta,
                                          idProducto, idCliente,
                                          idTipoComprobantePedido, letraFiscalPedido, centroEmisorPedido, numeroPedidoDesde, numeroPedidoHasta, lineaPedido,
                                          planMaestroNumero, esResultante)

   End Function

   Public Function ValidaOrdenProduccionSeaHija(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Integer,
                                                numeroOrdenProduccion As Long,
                                                orden As Integer,
                                                idProducto As String) As Boolean

      Dim sql = New SqlServer.OrdenesProduccionMRPProductos(Me.da)

      Dim dt = sql.OrdenesProduccionMRPProductos_GHija(idSucursal,
                                                       idTipoComprobante,
                                                       letra,
                                                       centroEmisor,
                                                       numeroOrdenProduccion,
                                                       orden,
                                                       idProducto)
      Return dt.Rows.Count > 0

   End Function
#End Region

   Public Class StockVirtual
      Public Property IdProducto As String
      Public Property CantidadStock As Decimal
   End Class
End Class

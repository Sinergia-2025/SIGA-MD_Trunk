Option Strict On
Option Explicit On

Public Class CRMNovedadesProductosNrosSerie
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.CRMNovedadProductoNrosSerie.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMNovedadProductoNrosSerie.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Sub _Inserta(entidad As Entidades.CRMNovedadProductoNrosSerie)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.CRMNovedadProductoNrosSerie)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.CRMNovedadProductoNrosSerie)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
#End Region

#Region "Métodos Públicos"


   Public Function GetTodos(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idproducto As String) As List(Of Entidades.CRMNovedadProductoNrosSerie)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad, letra, centroEmisor, idNovedad, idproducto)

      Return CargaLista(dt, Sub(o, dr) CargarUno(DirectCast(o, Entidades.CRMNovedadProductoNrosSerie), dr), Function() New Entidades.CRMNovedadProductoNrosSerie())
   End Function

   Public Overloads Function GetAll(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idproducto As String) As System.Data.DataTable
      Return New SqlServer.CRMNovedadesProductosNrosSerie(Me.da).CRMNovedadesProductosNrosSerie_GA(idTipoNovedad, letra, centroEmisor, idNovedad, idproducto)
   End Function

   Private Sub CargarUno(o As Entidades.CRMNovedadProductoNrosSerie, dr As DataRow)
      With o
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()))
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())
         .LetraNovedad = dr.Field(Of String)(Entidades.CRMNovedadProductoNrosSerie.Columnas.LetraNovedad.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMNovedadProductoNrosSerie.Columnas.CentroEmisor.ToString())
         .IdProducto = dr.Field(Of String)(Entidades.CRMNovedadProductoNrosSerie.Columnas.IdProducto.ToString())
         .OrdenProducto = dr.Field(Of Integer)(Entidades.CRMNovedadProductoNrosSerie.Columnas.OrdenProducto.ToString())
         .NroSerie = dr.Field(Of String)(Entidades.CRMNovedadProductoNrosSerie.Columnas.NroSerie.ToString())
         .IdSucursal = dr.Field(Of Integer)(Entidades.CRMNovedadProductoNrosSerie.Columnas.IdSucursal.ToString())
         .IdDeposito = dr.Field(Of Integer)(Entidades.CRMNovedadProductoNrosSerie.Columnas.IdDeposito.ToString())
         .IdUbicacion = dr.Field(Of Integer)(Entidades.CRMNovedadProductoNrosSerie.Columnas.IdUbicacion.ToString())
      End With
   End Sub

   'Private Sub CargarAjusteStock(novedad As Entidades.CRMNovedad)
   '   If novedad.AjustarStock = Entidades.Publicos.AjustaStock.NOAJUSTA Then Exit Sub
   '   If novedad.ProductosNovedad.Count = 0 Then Exit Sub

   '   If String.IsNullOrWhiteSpace(Publicos.CRMNovedadesMovimientoConsumo) Then Throw New Exception("No está configurado el tipo de movimiento para Consumo. Parámetros del Sistema -> RMA -> Movimiento para Consumo")
   '   If String.IsNullOrWhiteSpace(Publicos.CRMNovedadesMovimientoReversado) Then Throw New Exception("No está configurado el tipo de movimiento para Reversado. Parámetros del Sistema -> RMA -> Movimiento para Reversado")

   '   Dim idTipoMovimiento = If(novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR, Publicos.CRMNovedadesMovimientoConsumo, Publicos.CRMNovedadesMovimientoReversado)
   '   Dim eMov = New Entidades.MovimientoStock()
   '   With eMov
   '      .Sucursal = New Sucursales(da).GetUna(actual.Sucursal.Id, False)
   '      '-- Recupera el Tipo de Movimiento.- --
   '      .TipoMovimiento = New TiposMovimientos(da).GetUno(idTipoMovimiento)
   '      '--------------------------------------
   '      .FechaMovimiento = Date.Now
   '      .DescuentoRecargo = 0
   '      .Total = 0
   '      .PercepcionIVA = 0
   '      .PercepcionIB = 0
   '      .PercepcionGanancias = 0
   '      .PercepcionVarias = 0
   '      .Comentarios = String.Empty
   '      .Observacion = String.Empty
   '      .Usuario = actual.Nombre
   '      '-- Carga los productos 

   '      Dim paraConsumir = Function(p As Entidades.CRMNovedadProducto) Not p.StockConsumidoProducto
   '      Dim paraRevertir = Function(p As Entidades.CRMNovedadProducto) p.StockConsumidoProducto

   '      'rNovedad.ProductosNovedad.Where(Function(p) Not p.StockConsumidoProducto).ToList().
   '      novedad.ProductosNovedad.Where(If(novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR, paraConsumir, paraRevertir)).ToList().
   '         ForEach(
   '            Sub(en)
   '               Dim eProdSuc = New ProductosSucursales(da)._GetUno(eMov.Sucursal.IdSucursal, en.IdProducto)
   '               Dim eLineaMov = New Entidades.MovimientoStockProducto()
   '               With eLineaMov
   '                  '-- Define Valores.- --
   '                  .CantidadAfectada = Entidades.MovimientoStockProducto.Afecta.DISPONIBLE
   '                  .NombreProducto = en.NombreProducto
   '                  .Cantidad = en.CantidadProducto
   '                  .IdProducto = en.IdProducto
   '                  .IdDeposito = eProdSuc.IdDepositoDefecto
   '                  .IdUbicacion = eProdSuc.IdUbicacionDefecto
   '                  '-- Inicializa Valores.- --
   '                  .DescuentoRecargo = 0
   '                  .PorcentajeIVA = 0
   '                  .TotalProducto = 0
   '                  .ImporteTotal = 0
   '                  .Precio = 0
   '                  .IVA = 0
   '                  .Stock = eProdSuc.Stock
   '                  .Usuario = actual.Nombre
   '                  .IdLote = String.Empty
   '                  .VtoLote = Nothing
   '                  .Orden = eMov.Productos.Count + 1
   '                  .IdSucursal = actual.Sucursal.Id
   '               End With
   '               eMov.Productos.Add(eLineaMov)
   '               ActualizaStockConsumidoProducto(en, novedad.AjustarStock = Entidades.Publicos.AjustaStock.CONSUMIR)
   '            End Sub)
   '   End With
   '   If eMov.Productos.Count > 0 Then
   '      Dim rMovimientos = New MovimientosStock(da)
   '      rMovimientos._Insertar(eMov, dtExpensas:=Nothing, Entidades.Entidad.MetodoGrabacion.Automatico, String.Empty) ' "CRMNovedadesABMCRM")
   '   End If
   'End Sub

#End Region

#Region "Métodos Privados"
   Private Sub EjecutaSP(en As Entidades.CRMNovedadProductoNrosSerie, tipo As TipoSP)
      Dim sCRMNovedadesProductos = New SqlServer.CRMNovedadesProductosNrosSerie(da)
      '-- Verifica Tipo de Operacion.- --
      Select Case tipo
         Case TipoSP._I
            '   sCRMNovedadesProductos.CRMNovedadesProductosNrosSerie_I(en.IdTipoNovedad,
            '                                                  en.LetraNovedad,
            '                                                  en.CentroEmisor,
            '                                                  en.IdNovedad,
            '                                                  en.IdProducto,
            '                                                  en.OrdenProducto,
            '                                                  en.NombreProducto,
            '                                                  en.CantidadProducto,
            '                                                  en.PrecioProducto,
            '                                                  en.IdListaPrecios,
            '                                                  en.StockConsumidoProducto, en.IdUbicacionActual, en.IdDepositoActual, en.IdUbicacionActual,
            '                                                  en.IdsucursalAnterior, en.IdDepositoAnterior,
            '                                                  en.IdUbicacionAnterior, en.StockReservadoProducto)
            'Case TipoSP._U
            '   sCRMNovedadesProductos.CRMNovedadesProductos_U(en.IdTipoNovedad,
            '                                                  en.LetraNovedad,
            '                                                  en.CentroEmisor,
            '                                                  en.IdNovedad,
            '                                                  en.IdProducto,
            '                                                  en.OrdenProducto,
            '                                                  en.CantidadProducto,
            '                                                  en.PrecioProducto,
            '                                                  en.StockConsumidoProducto, en.IdUbicacionActual, en.IdDepositoActual, en.IdUbicacionActual,
            '                                                  en.IdsucursalAnterior, en.IdDepositoAnterior,
            '                                                  en.IdUbicacionAnterior, en.StockReservadoProducto)
            'Case TipoSP._D
            '   sCRMNovedadesProductos.CRMNovedadesProductos_D(en.IdTipoNovedad,
            '                                                  en.LetraNovedad,
            '                                                  en.CentroEmisor,
            '                                                  en.IdNovedad,
            '                                                  en.IdProducto,
            '                                                  en.OrdenProducto)
      End Select
   End Sub

   Private Sub ActualizaStockConsumidoProducto(en As Entidades.CRMNovedadProducto, stockConsumidoProducto As Boolean)
      Dim sql = New SqlServer.CRMNovedadesProductos(da)
      sql.CRMNovedadesProductos_U_StockConsumido(en.IdTipoNovedad, en.LetraNovedad, en.CentroEmisor, en.IdNovedad,
                                                 en.IdProducto, en.OrdenProducto,
                                                 stockConsumidoProducto)
   End Sub

#End Region

End Class
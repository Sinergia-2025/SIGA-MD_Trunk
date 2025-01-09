<Obsolete("Se reemplaza por MovimientosStock", True)>
Public Class MovimientosVentas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "MovimientosVentas"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   <Obsolete("No usar este método, usar Insertar(Entidad, MetodoGrabacion, String")>
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)

   End Sub

   Public Overloads Sub Insertar(entidad As Eniac.Entidades.Entidad, MetodoGrabacion As Entidades.Entidad.MetodoGrabacion, IdFuncion As String)
      Dim oMov = DirectCast(entidad, Entidades.MovimientoVenta)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim movNum As Reglas.MovimientosNumeros = New Reglas.MovimientosNumeros(da)

         'Actualizo los Comprobantes de Compra si el tipo de movimiento tiene comprobantes asociados
         'en caso contrario no togo los comprobantes
         If Not String.IsNullOrEmpty(oMov.TipoMovimiento.ComprobantesAsociados) Then
            Dim comp As Ventas = New Ventas(da)
            oMov.Venta.Cliente = oMov.Cliente
            oMov.Venta.Subtotal = oMov.Neto
            oMov.Venta.DescuentoRecargo = 0
            oMov.Venta.TotalImpuestos = oMov.TotalImpuestos
            oMov.Venta.ImporteTotal = oMov.Total
            'creo un producto
            Dim pro As Entidades.VentaProducto
            For Each mcpro As Entidades.MovimientoVentaProducto In oMov.Productos
               pro = New Entidades.VentaProducto()
               pro.Producto = mcpro.ProductoSucursal.Producto
               pro.Cantidad = mcpro.Cantidad
               pro.Precio = mcpro.Precio
               pro.Orden = mcpro.Orden
               oMov.Venta.VentasProductos.Add(pro)
            Next
            'graba los comprobantes de venta
            comp.Insertar(oMov.Venta, MetodoGrabacion, IdFuncion)
         End If

         Me.GrabaMovimientoVenta(oMov)

         ''Acepto toda la transacción
         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub GrabaMovimientoVenta(mov As Entidades.MovimientoVenta)

      Dim mPro As Reglas.MovimientosVentasProductos = New Reglas.MovimientosVentasProductos(da)
      Dim movNum As Reglas.MovimientosNumeros = New Reglas.MovimientosNumeros(da)
      'Dim omovstock As Reglas.MovimientosStock
      'Dim movstock As Entidades.MovimientoStock

      'Recupero el ultimo numero de movimiento y le sumo uno para el nuevo
      mov.NumeroMovimiento = movNum.GetUltimoNroMovimiento(mov.Sucursal.Id, mov.TipoMovimiento.IdTipoMovimiento) + 1

      'Grabo la cabecera del movimiento
      Me.EjecutaSP(mov, TipoSP._I)

      Dim oPro As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
      Dim rMVPNS As Reglas.MovimientosVentasProductosNrosSerie = New Reglas.MovimientosVentasProductosNrosSerie(da)

      For Each m As Entidades.MovimientoVentaProducto In mov.Productos

         m.MovimientoVenta = mov

         m.Cantidad = m.Cantidad * mov.TipoMovimiento.CoeficienteStock

         ''Inserto el detalle del movimiento
         mPro.EjecutaSP(m, TipoSP._I)

         'Entra en caso de No ser un producto Compuesto y que descuenta de sus componentes.
         'Porque se hizo la produccion antes/despues de llamar a esta funcion
         If Not (m.ProductoSucursal.Producto.EsCompuesto And m.ProductoSucursal.Producto.DescontarStockComponentes) Then

            oPro.ActualizarStock(m.MovimientoVenta.Sucursal.Id, m.ProductoSucursal.Producto.IdProducto, m.Cantidad, 0, 0, 0, 0, m.IdaAtributoProducto01,
                                 m.IdaAtributoProducto02, m.IdaAtributoProducto03, m.IdaAtributoProducto04)

         End If

         '# Nros de Serie
         For Each ePNS As Entidades.MovimientoVentaProductoNroSerie In m.ProductosNrosSerie
            ePNS.IdSucursal = mov.Sucursal.Id
            ePNS.IdTipoMovimiento = mov.TipoMovimiento.IdTipoMovimiento
            ePNS.NumeroMovimiento = mov.NumeroMovimiento
            ePNS.Cantidad = CInt((m.Cantidad / Math.Abs(m.Cantidad)))
            rMVPNS._Inserta(ePNS)
         Next

      Next

      ''Actualizo el número de movimiento en la tabla MovimientosNumeros
      Dim oMovNum As Entidades.MovimientoNumero = New Entidades.MovimientoNumero()
      oMovNum.Sucursal = mov.Sucursal
      oMovNum.TipoMovimiento = mov.TipoMovimiento
      oMovNum.Numero = mov.NumeroMovimiento
      movNum.ActualizarNumero(oMovNum)

   End Sub


#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(mov As Entidades.MovimientoVenta, tipo As TipoSP)
      Try
            Dim idCliente As Long = 0

         'Diego: agregue el "NOT". No se estaba grabando, es un poco raro.
            If mov.Cliente.IdCliente <> 0 Then
                idCliente = mov.Cliente.IdCliente
            End If


         Dim sql As SqlServer.MovimientosVentas = New SqlServer.MovimientosVentas(Me.da)

         Select Case tipo
            Case TipoSP._I

               sql.MovimientosVentas_I(mov.Sucursal.Id,
                                       mov.TipoMovimiento.IdTipoMovimiento,
                                       mov.NumeroMovimiento,
                                       mov.FechaMovimiento,
                                       mov.Neto,
                                       mov.Total,
                                       mov.Venta.CategoriaFiscal.IdCategoriaFiscal,
                                       mov.Venta.TipoComprobante.IdTipoComprobante,
                                       mov.Venta.LetraComprobante,
                                       mov.Venta.Impresora.CentroEmisor,
                                       mov.Venta.NumeroComprobante,
                                       mov.Usuario,
                                       mov.Observacion,
                                       mov.TotalImpuestos,
                                            mov.Cliente.IdCliente)

               'Tiene que tomar la letra del comprobante, no del cliente, ejeplo: en Remito es distinta.
               'movimiento.Cliente.CategoriaFiscal.LetraFiscal, movimiento.Venta.Impresora.CentroEmisor, _

            Case TipoSP._D

               sql.MovimientosVentas_D(mov.Sucursal.Id, mov.TipoMovimiento.IdTipoMovimiento, mov.NumeroMovimiento)

         End Select


      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Function GetUnoPorComprobante(idSucursal As Integer,
                                        idTipoComprobante As String,
                                        letra As String,
                                        centroEmisor As Short,
                                        numeroComprobante As Long) As Entidades.MovimientoVenta

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT idSucursal")
         .AppendLine("      ,IdTipoMovimiento")
         .AppendLine("      ,NumeroMovimiento")
         .AppendLine("      ,FechaMovimiento")
         .AppendLine("      ,Neto")
         .AppendLine("      ,TotalImpuestos")
         .AppendLine("      ,Total")
            .AppendLine("      ,IdCliente")
            .AppendLine("      ,IdCategoriaFiscal")
         .AppendLine("      ,IdTipoComprobante")
         .AppendLine("      ,Letra")
         .AppendLine("      ,CentroEmisor")
         .AppendLine("      ,NumeroComprobante")
         .AppendLine("      ,Usuario")
         .AppendLine("      ,Observacion")
         .AppendLine(" FROM MovimientosVentas")
         .AppendLine(" WHERE V.IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("   AND V.Letra = '" & letra & "'")
         .AppendLine("   AND V.CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("   AND V.NumeroComprobante = " & numeroComprobante.ToString())
      End With

      Dim dt As DataTable = da.GetDataTable(stb.ToString())

      Dim oMovVenta As Entidades.MovimientoVenta = New Entidades.MovimientoVenta()

      If dt.Rows.Count > 0 Then
         With oMovVenta
            .IdSucursal = Integer.Parse(dt.Rows(0)("IdSucursal").ToString())
            .TipoMovimiento = New Reglas.TiposMovimientos(da).GetUno(dt.Rows(0)("IdTipoMovimiento").ToString())
            .NumeroMovimiento = Integer.Parse(dt.Rows(0)("NumeroMovimiento").ToString())
            .FechaMovimiento = Date.Parse(dt.Rows(0)("FechaMovimiento").ToString())
            .Neto = Decimal.Parse(dt.Rows(0)("Neto").ToString())
            .TotalImpuestos = Decimal.Parse(dt.Rows(0)("TotalImpuestos").ToString())
            .Total = Decimal.Parse(dt.Rows(0)("Total").ToString())
            .Cliente = New Reglas.Clientes(da).GetUno(Long.Parse(dt.Rows(0)("IdCliente").ToString()))
            .IdCategoriaFiscal = Short.Parse(dt.Rows(0)("IdCategoriaFiscal").ToString())
            .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dt.Rows(0)("IdTipoComprobante").ToString())
            .Letra = dt.Rows(0)("Letra").ToString()
            .CentroEmisor = Integer.Parse(dt.Rows(0)("CentroEmisor").ToString())
            .NumeroComprobante = Long.Parse(dt.Rows(0)("NumeroComprobante").ToString())
            .Usuario = dt.Rows(0)("Usuario").ToString()
            .Observacion = dt.Rows(0)("Observacion").ToString()
         End With

         With stb
            .Length = 0

            .AppendLine("SELECT idSucursal")
            .AppendLine("      ,IdTipoMovimiento")
            .AppendLine("      ,NumeroMovimiento")
            .AppendLine("      ,Orden")
            .AppendLine("      ,IdProducto")
            .AppendLine("      ,Cantidad")
            .AppendLine("      ,Precio")

            .AppendLine("  FROM MovimientosVentasProductos")
            .AppendLine(" WHERE VP.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND IdTipoMovimiento = '" & oMovVenta.TipoMovimiento.IdTipoMovimiento & "'")
            .AppendLine("   AND NumeroMovimiento = " & oMovVenta.NumeroMovimiento.ToString())

         End With

         Dim dtMovVtaPro As DataTable = da.GetDataTable(stb.ToString())
         Dim oMVP As Entidades.MovimientoVentaProducto
         For Each dr As DataRow In dtMovVtaPro.Rows
            oMVP = New Entidades.MovimientoVentaProducto()
            With oMVP
               .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
               .MovimientoVenta = oMovVenta
               .ProductoSucursal = New Reglas.ProductosSucursales(da)._GetUno(Integer.Parse(dr("IdSucursal").ToString()), dr("IdProducto").ToString())
               .Cantidad = Decimal.Parse(dr("Cantidad").ToString())
               .Precio = Decimal.Parse(dr("Precio").ToString())
            End With
            oMovVenta.Productos.Add(oMVP)
         Next
      Else
         Throw New Exception("No existe este comprobante de venta.")
      End If

      Return oMovVenta

   End Function

   Public Function GetTipoYNumeroPorComprobante(idSucursal As Integer,
                                                idTipoComprobante As String,
                                                letra As String,
                                                centroEmisor As Short,
                                                numeroComprobante As Long) As DataTable
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexion Then da.OpenConection()
         Dim stb As StringBuilder = New StringBuilder()

         With stb
            .Length = 0
            '.AppendLine("ALTER TABLE MovimientosVentas SET (LOCK_ESCALATION = DISABLE)")
            .AppendLine("SELECT IdTipoMovimiento")
            .AppendLine("      ,NumeroMovimiento")
            .AppendLine(" FROM MovimientosVentas")
            .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND IdTipoComprobante = '" & idTipoComprobante & "'")
            .AppendLine("   AND Letra = '" & letra & "'")
            .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
            .AppendLine("   AND NumeroComprobante = " & numeroComprobante.ToString())
         End With

         Return da.GetDataTable(stb.ToString())
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Function

#End Region

#Region "Metodos Friend"

   Friend Sub EliminarPorComprobante(idSucursal As Integer,
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Short,
                                     numeroComprobante As Long)


      Dim dtMov As DataTable

      'Obtengo todos los movimientos relacionados al comprobante
      dtMov = Me.GetTipoYNumeroPorComprobante(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)

      If dtMov.Rows.Count > 0 Then

         Dim dtMovProd As DataTable

         Dim sql As SqlServer.MovimientosVentas = New SqlServer.MovimientosVentas(Me.da)
         Dim sql2 As SqlServer.MovimientosVentasProductos = New SqlServer.MovimientosVentasProductos(Me.da)
         Dim ProdSuc As Reglas.ProductosSucursales = New Reglas.ProductosSucursales(da)
         Dim MovProd As Reglas.MovimientosVentasProductos = New Reglas.MovimientosVentasProductos(da)

         For Each dr As DataRow In dtMov.Rows

            'Por cada movimiento obtengo los productos relacionamos al movimiento

            dtMovProd = MovProd.GetMovimientos(idSucursal, dr("IdTipoMovimiento").ToString(), Long.Parse(dr("NumeroMovimiento").ToString()))

            For Each m As DataRow In dtMovProd.Rows
               'Ajusto el stock Inicial del producto en cuestion
               ProdSuc.ActualizarStockInicial(idSucursal, m("IdProducto").ToString(), Decimal.Parse(m("Cantidad").ToString()))
            Next

            'Borro todos los productos relacionado en este movimiento (Detalle)
            sql2.MovimientosVentasProductos_D(idSucursal,
                                             dr("IdTipoMovimiento").ToString(),
                                             Long.Parse(dr("NumeroMovimiento").ToString()))


            'Borro el movimiento (Cabecera)
            sql.MovimientosVentas_D(idSucursal,
                                    dr("IdTipoMovimiento").ToString(),
                                    Long.Parse(dr("NumeroMovimiento").ToString()))

         Next

      End If

   End Sub

#End Region

   Private Sub CargarUno(o As Entidades.MovimientoVenta, dr As DataRow)
      With o
         .Sucursal = New Reglas.Sucursales(Me.da).GetUna(Int32.Parse(dr(Entidades.MovimientoVenta.Columnas.IdSucursal.ToString()).ToString()), False)
         .IdSucursal = Int32.Parse(dr(Entidades.MovimientoVenta.Columnas.IdSucursal.ToString()).ToString())
         .TipoMovimiento = New Reglas.TiposMovimientos(Me.da).GetUno(dr(Entidades.MovimientoVenta.Columnas.IdTipoMovimiento.ToString()).ToString())
         .NumeroMovimiento = Long.Parse(dr(Entidades.MovimientoVenta.Columnas.NumeroMovimiento.ToString()).ToString())
         .FechaMovimiento = DateTime.Parse(dr(Entidades.MovimientoVenta.Columnas.FechaMovimiento.ToString()).ToString())
         .Neto = Decimal.Parse(dr(Entidades.MovimientoVenta.Columnas.Neto.ToString()).ToString())
         .Total = Decimal.Parse(dr(Entidades.MovimientoVenta.Columnas.Total.ToString()).ToString())
         .Cliente = New Reglas.Clientes(Me.da).GetUno(Long.Parse(dr(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString()))
         .Venta.CategoriaFiscal = New Reglas.CategoriasFiscales(Me.da)._GetUno(Short.Parse(dr(Entidades.MovimientoVenta.Columnas.IdCategoriaFiscal.ToString()).ToString()))
         .Letra = dr(Entidades.MovimientoVenta.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Int32.Parse(dr(Entidades.MovimientoVenta.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroComprobante = Long.Parse(dr(Entidades.MovimientoVenta.Columnas.NumeroComprobante.ToString()).ToString())
         .Usuario = dr(Entidades.MovimientoVenta.Columnas.Usuario.ToString()).ToString()
         .Observacion = dr(Entidades.MovimientoVenta.Columnas.Observacion.ToString()).ToString()
         .TotalImpuestos = Decimal.Parse(dr(Entidades.MovimientoVenta.Columnas.TotalImpuestos.ToString()).ToString())
      End With
   End Sub

   Public Function GetTodos() As List(Of Entidades.MovimientoVenta)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.MovimientoVenta
         Dim oLis As List(Of Entidades.MovimientoVenta) = New List(Of Entidades.MovimientoVenta)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.MovimientoVenta()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Me.da.CommitTransaction()
         Return oLis

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(IdSucursal As Integer,
                           IdTipoMovimiento As String,
                           NumeroMovimiento As Long,
                           Orden As Long,
                           IdProducto As String) As Entidades.MovimientoVenta
      Try
         Me.da.OpenConection()

         Return Me._GetUno(IdSucursal, IdTipoMovimiento, NumeroMovimiento)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(IdSucursal As Integer,
                           IdTipoMovimiento As String,
                           NumeroMovimiento As Long) As Entidades.MovimientoVenta

      Dim sql As SqlServer.MovimientosVentas = New SqlServer.MovimientosVentas(Me.da)

      Dim dt As DataTable = sql.MovimientosVentas_G1(IdSucursal, IdTipoMovimiento, NumeroMovimiento)

      Dim o As Entidades.MovimientoVenta = New Entidades.MovimientoVenta()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el MovimientoVenta.")
      End If

      Return o

   End Function

End Class
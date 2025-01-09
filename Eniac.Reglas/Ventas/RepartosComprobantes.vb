#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class RepartosComprobantes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoComprobante.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Inserta(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Actualiza(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Borra(entidad)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overloads Sub Borrar(idSucursal As Integer, idReparto As Integer)
      Dim sql As SqlServer.RepartosComprobantes = New SqlServer.RepartosComprobantes(Me.da)
      sql.RepartosComprobantes_D(idSucursal, idReparto)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.RepartosComprobantes = New SqlServer.RepartosComprobantes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Throw New NotImplementedException("GetAll() no fue implementado. Usar GetAll(Integer, Integer)")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idReparto As Integer) As System.Data.DataTable
      Return New SqlServer.RepartosComprobantes(Me.da).RepartosComprobantes_GA(idSucursal, idReparto)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.RepartoComprobante, ByVal tipo As TipoSP)

      Dim sqlC As SqlServer.RepartosComprobantes = New SqlServer.RepartosComprobantes(da)
      Dim rRepComPro As Reglas.RepartosComprobantesProductos = New RepartosComprobantesProductos(da)

      Select Case tipo
         Case TipoSP._I
            If en.Orden = 0 Then
               en.Orden = GetCodigoMaximo(en.IdSucursal, en.IdReparto) + 1
            End If

            If en.Venta IsNot Nothing And Not en.ImporteTotalFact.HasValue Then
               en.ImporteTotalFact = en.Venta.ImporteTotal
            End If

            If en.Recibo IsNot Nothing And Not en.ImporteTotalRecibo.HasValue Then
               en.ImporteTotalRecibo = en.Recibo.ImporteTotal
            End If

            sqlC.RepartosComprobantes_I(en.IdSucursal,
                                        en.IdReparto,
                                        en.Orden,
                                        en.IdTipoComprobantePedido,
                                        en.LetraPedido,
                                        en.CentroEmisorPedido,
                                        en.NumeroPedido,
                                        en.IdTipoComprobanteFact,
                                        en.LetraFact,
                                        en.CentroEmisorFact,
                                        en.NumeroComprobante,
                                        en.IdSucursalRecibo,
                                        en.IdTipoComprobanteRecibo,
                                        en.LetraRecibo,
                                        en.CentroEmisorRecibo,
                                        en.NumeroComprobanteRecibo,
                                        en.ImporteTotalFact,
                                        en.ImporteTotalRecibo)
            rRepComPro.InsertaDesdeRepartoComprobante(en)
         Case TipoSP._U
            'Throw New NotImplementedException("El método _U de RepartoComprobante no está implementado.")
            sqlC.RepartosComprobantes_U(en.IdSucursal,
                                        en.IdReparto,
                                        en.Orden,
                                        en.IdTipoComprobantePedido,
                                        en.LetraPedido,
                                        en.CentroEmisorPedido,
                                        en.NumeroPedido,
                                        en.IdTipoComprobanteFact,
                                        en.LetraFact,
                                        en.CentroEmisorFact,
                                        en.NumeroComprobante,
                                        en.IdSucursalRecibo,
                                        en.IdTipoComprobanteRecibo,
                                        en.LetraRecibo,
                                        en.CentroEmisorRecibo,
                                        en.NumeroComprobanteRecibo,
                                        en.ImporteTotalFact,
                                        en.Recibo.ImporteTotal)
         Case TipoSP._D
            rRepComPro.Borra(New Entidades.RepartoComprobanteProducto() With {.IdSucursal = en.IdSucursal, .IdReparto = en.IdReparto, .Orden = en.Orden})
            sqlC.RepartosComprobantes_D(en.IdSucursal, en.IdReparto, en.Orden)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.RepartoComprobante, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.RepartoComprobante.Columnas.IdSucursal.ToString).ToString())
         .IdReparto = Integer.Parse(dr(Entidades.RepartoComprobante.Columnas.IdReparto.ToString).ToString())
         .Orden = Integer.Parse(dr(Entidades.RepartoComprobante.Columnas.Orden.ToString).ToString())

         If Not String.IsNullOrWhiteSpace(dr(Entidades.RepartoComprobante.Columnas.IdTipoComprobantePedido.ToString()).ToString()) And
            Not String.IsNullOrWhiteSpace(dr(Entidades.RepartoComprobante.Columnas.LetraPedido.ToString()).ToString()) And
            IsNumeric(dr(Entidades.RepartoComprobante.Columnas.CentroEmisorPedido.ToString())) And
            IsNumeric(dr(Entidades.RepartoComprobante.Columnas.NumeroPedido.ToString())) Then
            Try
               .Pedido = New Reglas.Pedidos(da).GetUno(Integer.Parse(dr(Entidades.RepartoComprobante.Columnas.IdSucursal.ToString()).ToString()),
                                                       dr(Entidades.RepartoComprobante.Columnas.IdTipoComprobantePedido.ToString()).ToString(),
                                                       dr(Entidades.RepartoComprobante.Columnas.LetraPedido.ToString()).ToString(),
                                                       Integer.Parse(dr(Entidades.RepartoComprobante.Columnas.CentroEmisorPedido.ToString()).ToString()),
                                                       Long.Parse(dr(Entidades.RepartoComprobante.Columnas.NumeroPedido.ToString()).ToString()))
            Catch ex As Exception
               Throw New Exception(String.Format("Error Cargando Reparto con sucursal {0} y Número {1}: {2}", .IdSucursal, .IdReparto, ex.Message), ex)
            End Try
         End If

         If Not String.IsNullOrWhiteSpace(dr(Entidades.RepartoComprobante.Columnas.IdTipoComprobanteFact.ToString()).ToString()) And
            Not String.IsNullOrWhiteSpace(dr(Entidades.RepartoComprobante.Columnas.LetraFact.ToString()).ToString()) And
            IsNumeric(dr(Entidades.RepartoComprobante.Columnas.CentroEmisorFact.ToString())) And
            IsNumeric(dr(Entidades.RepartoComprobante.Columnas.NumeroComprobante.ToString())) Then
            Try
               .Venta = New Reglas.Ventas(da).GetUna(Integer.Parse(dr(Entidades.RepartoComprobante.Columnas.IdSucursal.ToString()).ToString()),
                                                     dr(Entidades.RepartoComprobante.Columnas.IdTipoComprobanteFact.ToString()).ToString(),
                                                     dr(Entidades.RepartoComprobante.Columnas.LetraFact.ToString()).ToString(),
                                                     Short.Parse(dr(Entidades.RepartoComprobante.Columnas.CentroEmisorFact.ToString()).ToString()),
                                                     Long.Parse(dr(Entidades.RepartoComprobante.Columnas.NumeroComprobante.ToString()).ToString()))
            Catch ex As Exception
               Throw New Exception(String.Format("Error Cargando Reparto con sucursal {0} y Número {1}: {2}", .IdSucursal, .IdReparto, ex.Message), ex)
            End Try
         End If

         If IsNumeric(dr(Entidades.RepartoComprobante.Columnas.ImporteTotalFact.ToString())) Then
            .ImporteTotalFact = Decimal.Parse(dr(Entidades.RepartoComprobante.Columnas.ImporteTotalFact.ToString()).ToString())
         End If

         If IsNumeric(dr(Entidades.RepartoComprobante.Columnas.IdSucursalRecibo.ToString())) And
            Not String.IsNullOrWhiteSpace(dr(Entidades.RepartoComprobante.Columnas.IdTipoComprobanteRecibo.ToString()).ToString()) And
            Not String.IsNullOrWhiteSpace(dr(Entidades.RepartoComprobante.Columnas.LetraRecibo.ToString()).ToString()) And
            IsNumeric(dr(Entidades.RepartoComprobante.Columnas.CentroEmisorRecibo.ToString())) And
            IsNumeric(dr(Entidades.RepartoComprobante.Columnas.NumeroComprobanteRecibo.ToString())) Then
            Try
               .Recibo = New Reglas.CuentasCorrientes(da)._GetUna(Integer.Parse(dr(Entidades.RepartoComprobante.Columnas.IdSucursalRecibo.ToString()).ToString()),
                                                                  dr(Entidades.RepartoComprobante.Columnas.IdTipoComprobanteRecibo.ToString()).ToString(),
                                                                  dr(Entidades.RepartoComprobante.Columnas.LetraRecibo.ToString()).ToString(),
                                                                  Short.Parse(dr(Entidades.RepartoComprobante.Columnas.CentroEmisorRecibo.ToString()).ToString()),
                                                                  Long.Parse(dr(Entidades.RepartoComprobante.Columnas.NumeroComprobanteRecibo.ToString()).ToString()))
            Catch ex As Exception
               Throw New Exception(String.Format("Error Cargando Reparto con sucursal {0} y Número {1}: {2}", .IdSucursal, .IdReparto, ex.Message), ex)
            End Try
         End If

         If IsNumeric(dr(Entidades.RepartoComprobante.Columnas.ImporteTotalRecibo.ToString())) Then
            .ImporteTotalRecibo = Decimal.Parse(dr(Entidades.RepartoComprobante.Columnas.ImporteTotalRecibo.ToString()).ToString())
         End If

         .Productos = New Reglas.RepartosComprobantesProductos(da).GetTodos(.IdSucursal, .IdReparto, .Orden)

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobante), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobante), TipoSP._U)
   End Sub

   Public Sub Merge(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobante), TipoSP._M)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobante), TipoSP._D)
   End Sub

   Public Sub InsertaDesdeReparto(ByVal r As Eniac.Entidades.Reparto)
      For Each rc As Entidades.RepartoComprobante In r.Comprobantes
         rc.IdSucursal = r.IdSucursal
         rc.IdReparto = r.IdReparto
         Inserta(rc)
      Next
   End Sub

   Public Function ExisteFactura(idSucursal As Integer,
                                 idReparto As Integer,
                                 idTipoComprobanteFact As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long) As Entidades.RepartoComprobante
      Dim dt As DataTable = New SqlServer.RepartosComprobantes(da).ExisteFactura(idSucursal,
                                                                                 idReparto,
                                                                                 idTipoComprobanteFact,
                                                                                 letra,
                                                                                 centroEmisor,
                                                                                 numeroComprobante)
      Dim o As Entidades.RepartoComprobante = New Entidades.RepartoComprobante
      '# Si solo se encuentra un registro se carga la entidad, caso contrario no.
      If dt.Rows.Count = 1 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
         Return o
      End If
      Return Nothing
   End Function

   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          orden As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.RepartoComprobante
      Dim dt As DataTable = New SqlServer.RepartosComprobantes(da).RepartosComprobantes_G1(idSucursal, idReparto, orden)
      Dim o As Entidades.RepartoComprobante = New Entidades.RepartoComprobante()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         ElseIf accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No se encontró el RepartoComprobante con Sucursal = {0}, Número = {1} y Orden {2}", idSucursal, idReparto, orden))
         End If
      End If
      Return o
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer) As List(Of Entidades.RepartoComprobante)
      Return CargaLista(New SqlServer.RepartosComprobantes(da).RepartosComprobantes_GA(idSucursal, idReparto), Sub(o, dr) CargarUno(DirectCast(o, Entidades.RepartoComprobante), dr), Function() New Entidades.RepartoComprobante())
   End Function

   Public Function GetCodigoMaximo(idSucursal As Integer, idReparto As Integer) As Integer
      Return New SqlServer.RepartosComprobantes(da).GetCodigoMaximo(idSucursal, idReparto)
   End Function


   Public Sub ActualizarComprobantePorComprobante(vtaActual As Eniac.Entidades.Venta, vtaNueva As Eniac.Entidades.Venta)
      ActualizarComprobantePorComprobante(vtaNueva.IdSucursal,
                                          vtaActual.IdTipoComprobante, vtaActual.LetraComprobante, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                                          vtaNueva.IdTipoComprobante, vtaNueva.LetraComprobante, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)
   End Sub
   Public Sub ActualizarComprobantePorComprobante(idSucursal As Integer,
                                                  idTipoComprobanteOrigen As String, letraOrigen As String, centroEmisorOrigen As Integer, numeroComprobanteOrigen As Long,
                                                  idTipoComprobanteDestino As String, letraDestino As String, centroEmisorDestino As Integer, numeroComprobanteDestino As Long)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then Me.da.OpenConection()

         Dim sqlC As SqlServer.RepartosComprobantes = New SqlServer.RepartosComprobantes(da)
         Dim sqlRCC As SqlServer.RepartosCobranzasComprobantes = New SqlServer.RepartosCobranzasComprobantes(da)

         sqlC.ActualizarComprobantePorComprobante(idSucursal,
                                                  idTipoComprobanteOrigen, letraOrigen, centroEmisorOrigen, numeroComprobanteOrigen,
                                                  idTipoComprobanteDestino, letraDestino, centroEmisorDestino, numeroComprobanteDestino)

         sqlRCC.ActualizarComprobantePorComprobante(idSucursal,
                                                  idTipoComprobanteOrigen, letraOrigen, centroEmisorOrigen, numeroComprobanteOrigen,
                                                  idTipoComprobanteDestino, letraDestino, centroEmisorDestino, numeroComprobanteDestino)

      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Sub

   Public Sub ActualizarReciboPorRecibo(vtaActual As Eniac.Entidades.CuentaCorriente, vtaNueva As Eniac.Entidades.CuentaCorriente)
      ActualizarReciboPorRecibo(vtaNueva.IdSucursal,
                                vtaActual.TipoComprobante.IdTipoComprobante, vtaActual.Letra, vtaActual.CentroEmisor, vtaActual.NumeroComprobante,
                                vtaNueva.IdSucursal,
                                vtaNueva.TipoComprobante.IdTipoComprobante, vtaNueva.Letra, vtaNueva.CentroEmisor, vtaNueva.NumeroComprobante)
   End Sub
   Public Sub ActualizarReciboPorRecibo(idSucursalOrigen As Integer,
                                        idTipoComprobanteOrigen As String, letraOrigen As String, centroEmisorOrigen As Integer, numeroComprobanteOrigen As Long,
                                        idSucursalDestino As Integer,
                                        idTipoComprobanteDestino As String, letraDestino As String, centroEmisorDestino As Integer, numeroComprobanteDestino As Long)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Closed
      Try
         If blnAbreConexion Then Me.da.OpenConection()

         Dim sqlC As SqlServer.RepartosComprobantes = New SqlServer.RepartosComprobantes(da)

         sqlC.ActualizarReciboPorRecibo(idSucursalOrigen,
                                        idTipoComprobanteOrigen, letraOrigen, centroEmisorOrigen, numeroComprobanteOrigen,
                                        idSucursalDestino,
                                        idTipoComprobanteDestino, letraDestino, centroEmisorDestino, numeroComprobanteDestino)

      Finally
         If blnAbreConexion Then Me.da.CloseConection()
      End Try
   End Sub

   Public Function _GetTodos(idSucursal As Integer, idReparto As Integer) As List(Of Entidades.RepartoComprobante)
      Try
         Dim dt As DataTable = GetAll(idSucursal, idReparto)
         Dim o As Entidades.RepartoComprobante
         Dim oLis As List(Of Entidades.RepartoComprobante) = New List(Of Entidades.RepartoComprobante)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.RepartoComprobante()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next
         Return oLis
      Catch
         Throw
      End Try
   End Function
#End Region

#Region "Friend"
   Friend Function GetPorPedido(idSucursal As Integer,
                                idTipoComprobante As String,
                                letra As String,
                                centroEmisor As Short,
                                numeroPedido As Long) As DataTable
      Return New SqlServer.RepartosComprobantes(da).RepartosComprobantes_G_PorPedido(idSucursal,
                                                                                     idTipoComprobante,
                                                                                     letra,
                                                                                     centroEmisor,
                                                                                     numeroPedido)
   End Function
   Public Sub ActualizarPedido(idSucursal As Integer, idReparto As Integer, orden As Integer,
                               idTipoComprobantePedido As String, letraPedido As String, centroEmisorPedido As Short, numeroPedido As Long)
      Dim sql As SqlServer.RepartosComprobantes = New SqlServer.RepartosComprobantes(da)
      sql.ActualizarPedido(idSucursal, idReparto, orden,
                           idTipoComprobantePedido, letraPedido, centroEmisorPedido, numeroPedido)
   End Sub
#End Region

End Class
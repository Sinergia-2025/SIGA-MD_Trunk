#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ProductosOfertas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProductoOferta.NombreTabla
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

#End Region

#Region "Metodos Privados"
   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoOferta), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoOferta), TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoOferta), TipoSP._D)
   End Sub
   Private Sub EjecutaSP(ByVal en As Entidades.ProductoOferta, ByVal tipo As TipoSP)

      Dim sql As SqlServer.ProductosOfertas = New SqlServer.ProductosOfertas(da)
      Select Case tipo
         Case TipoSP._I
            sql.ProductosOfertas_I(en.IdProducto, en.IdOferta, en.FechaDesde, en.FechaHasta, en.LimiteStock, en.CantidadConsumida, en.PrecioOferta, en.Activa)
         Case TipoSP._U
            sql.ProductosOfertas_U(en.IdProducto, en.IdOferta, en.FechaDesde, en.FechaHasta, en.LimiteStock, en.CantidadConsumida, en.PrecioOferta, en.Activa)
         Case TipoSP._D
            sql.ProductosOfertas_D(en.IdProducto, en.IdOferta)
      End Select
   End Sub
   Private Sub CargarUno(ByVal o As Entidades.ProductoOferta, ByVal dr As DataRow)
      With o
         .IdProducto = dr(Entidades.ProductoOferta.Columnas.IdProducto.ToString()).ToString()
         .IdOferta = Integer.Parse(dr(Entidades.ProductoOferta.Columnas.IdOferta.ToString()).ToString())
         .FechaDesde = Date.Parse(dr(Entidades.ProductoOferta.Columnas.FechaDesde.ToString()).ToString())
         .FechaHasta = Date.Parse(dr(Entidades.ProductoOferta.Columnas.FechaHasta.ToString()).ToString())
         .LimiteStock = Decimal.Parse(dr(Entidades.ProductoOferta.Columnas.LimiteStock.ToString()).ToString())
         .CantidadConsumida = Decimal.Parse(dr(Entidades.ProductoOferta.Columnas.CantidadConsumida.ToString()).ToString())
         .PrecioOferta = Decimal.Parse(dr(Entidades.ProductoOferta.Columnas.PrecioOferta.ToString()).ToString())
         .Activa = Boolean.Parse(dr(Entidades.ProductoOferta.Columnas.Activa.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetTodos(idProducto As String) As List(Of Entidades.ProductoOferta)
      Return CargaLista(New SqlServer.ProductosOfertas(da).ProductosOfertas_GA(idProducto),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoOferta())
   End Function
   Public Function GetUno(idProducto As String, idOferta As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoOferta
      Return CargaEntidad(New SqlServer.ProductosOfertas(da).ProductosOfertas_G1(idProducto, idOferta),
                      Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoOferta(),
                      accion, String.Format("No existe una oferta con IdProducto = {0} y IdOferta = {1}", idProducto, idOferta))
   End Function
   Public Function GetOfertaVigente(ByVal fechaComprobante As Date, ByVal idProducto As String, accion As AccionesSiNoExisteRegistro) As Entidades.ProductoOferta
      Dim dt As DataTable = New SqlServer.ProductosOfertas(da).ProductosOfertas_G_Oferta(fechaComprobante, idProducto, 0)
      Dim o As Entidades.ProductoOferta = New Entidades.ProductoOferta()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No existe oferta para el producto {0} en la fecha {1:dd/MM/yyyy}", idProducto, fechaComprobante))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Public Sub ActualizarDesdeProducto(producto As Eniac.Entidades.Producto)
      If producto.ProductosOfertas IsNot Nothing Then
         Dim actuales As List(Of Entidades.ProductoOferta) = GetTodos(producto.IdProducto)
         Dim algunError As Boolean = False
         Dim mensajeError As StringBuilder = New StringBuilder()
         For Each ofertaActual As Entidades.ProductoOferta In actuales
            Dim oferta As Entidades.ProductoOferta = producto.ProductosOfertas.FirstOrDefault(Function(po) po.IdProducto = ofertaActual.IdProducto And po.IdOferta = ofertaActual.IdOferta)
            If oferta IsNot Nothing Then
               oferta.CantidadConsumida = ofertaActual.CantidadConsumida
            Else
               If ExisteOfertaAplicada(ofertaActual.IdProducto, ofertaActual.IdOferta) Then
                  algunError = True
                  mensajeError.AppendFormatLine("Ya se registró al menos una venta con la oferta del {0:dd/MM/yyyy} al {1:dd/MM/yyyy}. No es posible borrar la misma.", ofertaActual.FechaDesde, ofertaActual.FechaHasta)
               End If
            End If
         Next

         If algunError Then
            Throw New Exception(mensajeError.ToString())
         End If

         BorraDesdeProducto(producto)
         InsertaDesdeProducto(producto)
      End If
   End Sub
   Public Function ExisteOfertaAplicada(idProducto As String, idOferta As Integer) As Boolean
      Dim dt As DataTable = New SqlServer.ProductosOfertas(da).ProductosOfertas_Count_OfertaAplicada(idProducto, idOferta)
      Return Integer.Parse(dt.Rows(0)(0).ToString()) > 0
   End Function
   Public Sub VerificaDisponibilidadOferta(fecha As DateTime, idProducto As String, idOferta As Integer)
      CargaEntidad(New SqlServer.ProductosOfertas(da).ProductosOfertas_G_Oferta(fecha, idProducto, idOferta),
               Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoOferta(),
               AccionesSiNoExisteRegistro.Excepcion, String.Format("La oferta con IdProducto = {0} y IdOferta = {1} ya no está disponible", idProducto, idOferta))
   End Sub

   Public Sub ConsumirCantidadOferta(ByVal idProducto As String, ByVal idOferta As Integer, ByVal cantidad As Decimal)
      Dim sqlOferta As SqlServer.ProductosOfertas = New SqlServer.ProductosOfertas(da)
      sqlOferta.ConsumirCantidadOferta(idProducto, idOferta, cantidad)
   End Sub
   Public Sub InsertaDesdeProducto(entidad As Eniac.Entidades.Producto)
      If entidad.ProductosOfertas IsNot Nothing Then
         For Each ent As Entidades.ProductoOferta In entidad.ProductosOfertas
            ent.IdProducto = entidad.IdProducto
            Inserta(ent)
         Next
      End If
   End Sub
   Public Sub BorraDesdeProducto(en As Eniac.Entidades.Producto)
      Borra(New Entidades.ProductoOferta() With {.IdProducto = en.IdProducto, .IdOferta = 0})
   End Sub

   Public Function GetCodigoMaximo(idProducto As String) As Integer
      Return New SqlServer.ProductosOfertas(da).GetCodigoMaximo(idProducto)
   End Function

#End Region
End Class
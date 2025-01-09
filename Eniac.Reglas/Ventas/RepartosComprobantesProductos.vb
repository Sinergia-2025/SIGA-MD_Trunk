#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class RepartosComprobantesProductos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoComprobanteProducto.NombreTabla
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
   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.RepartosComprobantesProductos = New SqlServer.RepartosComprobantesProductos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Throw New NotImplementedException("GetAll() no fue implementado. Usar GetAll(Integer, Integer)")
   End Function
   Public Overloads Function GetAll(idSucursal As Integer, idReparto As Integer, orden As Integer) As System.Data.DataTable
      Return New SqlServer.RepartosComprobantesProductos(Me.da).RepartosComprobantesProductos_GA(idSucursal, idReparto, orden)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(ByVal en As Entidades.RepartoComprobanteProducto, ByVal tipo As TipoSP)

      Dim sqlC As SqlServer.RepartosComprobantesProductos = New SqlServer.RepartosComprobantesProductos(da)
      Select Case tipo
         Case TipoSP._I
            If en.OrdenProducto = 0 Then
               en.OrdenProducto = GetCodigoMaximo(en.IdSucursal, en.IdReparto, en.Orden)
            End If
            sqlC.RepartosComprobantesProductos_I(en.IdSucursal,
                                                 en.IdReparto,
                                                 en.Orden,
                                                 en.IdProducto,
                                                 en.OrdenProducto,
                                                 en.NombreProducto,
                                                 en.Cantidad,
                                                 en.CantidadCambio,
                                                 en.Precio,
                                                 en.PrecioConImp)
         Case TipoSP._U
            sqlC.RepartosComprobantesProductos_U(en.IdSucursal,
                                                 en.IdReparto,
                                                 en.Orden,
                                                 en.IdProducto,
                                                 en.OrdenProducto,
                                                 en.NombreProducto,
                                                 en.Cantidad,
                                                 en.CantidadCambio,
                                                 en.Precio,
                                                 en.PrecioConImp)
         Case TipoSP._D
            sqlC.RepartosComprobantesProductos_D(en.IdSucursal, en.IdReparto, en.Orden, en.IdProducto, en.OrdenProducto)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.RepartoComprobanteProducto, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.IdSucursal.ToString).ToString())
         .IdReparto = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.IdReparto.ToString).ToString())
         .Orden = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.Orden.ToString).ToString())
         .IdProducto = dr(Entidades.RepartoComprobanteProducto.Columnas.IdProducto.ToString).ToString()
         .OrdenProducto = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.OrdenProducto.ToString).ToString())

         .NombreProducto = dr(Entidades.RepartoComprobanteProducto.Columnas.NombreProducto.ToString).ToString()
         .Cantidad = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.Cantidad.ToString).ToString())
         .CantidadCambio = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.CantidadCambio.ToString).ToString())
         .Precio = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.Precio.ToString).ToString())
         .PrecioConImp = Integer.Parse(dr(Entidades.RepartoComprobanteProducto.Columnas.PrecioConImp.ToString).ToString())

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobanteProducto), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobanteProducto), TipoSP._U)
   End Sub

   Public Sub Merge(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobanteProducto), TipoSP._M)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.RepartoComprobanteProducto), TipoSP._D)
   End Sub

   Public Sub InsertaDesdeRepartoComprobante(ByVal rc As Eniac.Entidades.RepartoComprobante)
      For Each rcp As Entidades.RepartoComprobanteProducto In rc.Productos
         rcp.IdSucursal = rc.IdSucursal
         rcp.IdReparto = rc.IdReparto
         rcp.Orden = rc.Orden
         Inserta(rcp)
      Next
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idReparto As Integer,
                          orden As Integer,
                          idProducto As String,
                          ordenProducto As Integer,
                          accion As AccionesSiNoExisteRegistro) As Entidades.RepartoComprobanteProducto
      Dim dt As DataTable = New SqlServer.RepartosComprobantesProductos(da).RepartosComprobantesProductos_G1(idSucursal, idReparto, orden, idProducto, ordenProducto)
      Dim o As Entidades.RepartoComprobanteProducto = New Entidades.RepartoComprobanteProducto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         ElseIf accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No se encontró el RepartoComprobanteProducto con Sucursal {0}, Número {1}, Orden {2}, Producto ´{3}´ y Orden Producto {4}", idSucursal, idReparto, orden, idProducto, ordenProducto))
         End If
      End If
      Return o
   End Function

   Public Function GetTodos(idSucursal As Integer, idReparto As Integer, orden As Integer) As List(Of Entidades.RepartoComprobanteProducto)
      Return CargaLista(New SqlServer.RepartosComprobantesProductos(da).RepartosComprobantesProductos_GA(idSucursal, idReparto, orden), Sub(o, dr) CargarUno(DirectCast(o, Entidades.RepartoComprobanteProducto), dr), Function() New Entidades.RepartoComprobanteProducto())
   End Function

   Public Function GetCodigoMaximo(idSucursal As Integer, idReparto As Integer, orden As Integer) As Integer
      Return New SqlServer.RepartosComprobantesProductos(da).GetCodigoMaximo(idSucursal, idReparto, orden)
   End Function

#End Region

End Class
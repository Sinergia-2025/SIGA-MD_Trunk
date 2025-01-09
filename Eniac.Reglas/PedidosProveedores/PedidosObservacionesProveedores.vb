Option Explicit On
Option Strict On
Imports System.Text
Public Class PedidosObservacionesProveedores
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "PedidosObservacionesProveedores"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Inserta(DirectCast(entidad, Entidades.PedidoObservacionProveedor))
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Borra(DirectCast(entidad, Entidades.PedidoObservacionProveedor))
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   <Obsolete("Usar GetAll(Integer, String, String, Integer, Long", True)>
   Public Overrides Function GetAll() As DataTable
      Return MyBase.GetAll()
   End Function
   Public Overloads Function GetAll(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Integer,
                                    numeroPedido As Long) As DataTable
      Return New SqlServer.PedidosObservacionesProveedores(da).PedidosObservacionesProveedores_GA(idSucursal,
                                                                            idTipoComprobante,
                                                                            letra,
                                                                            centroEmisor,
                                                                            numeroPedido)
   End Function
#End Region

#Region "Metodos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.PedidoObservacionProveedor)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.PedidoObservacionProveedor)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub Borra(ByVal pedido As Eniac.Entidades.Pedido)
      Dim sql As SqlServer.PedidosObservacionesProveedores = New SqlServer.PedidosObservacionesProveedores(Me.da)
      sql.PedidosObservacionesProveedores_D(pedido.IdSucursal, pedido.IdTipoComprobante, pedido.LetraComprobante, pedido.CentroEmisor, pedido.NumeroPedido, 0)
   End Sub

   Public Sub InsertaObservacionesDesdePedido(ByVal oPedidos As Entidades.PedidoProveedor)

      Dim orden As Integer = 0
      For Each observacion As Entidades.PedidoObservacionProveedor In oPedidos.PedidosObservaciones
         orden += 1
         observacion.IdSucursal = oPedidos.IdSucursal
         observacion.IdTipoComprobante = oPedidos.IdTipoComprobante
         observacion.Letra = oPedidos.LetraComprobante
         observacion.CentroEmisor = oPedidos.CentroEmisor
         observacion.NumeroPedido = oPedidos.NumeroPedido
         observacion.Linea = orden
         Inserta(observacion)
      Next
   End Sub

   Friend Sub EjecutaSP(ByVal ent As Entidades.PedidoObservacionProveedor, ByVal tipo As TipoSP)
      Dim sql As SqlServer.PedidosObservacionesProveedores = New SqlServer.PedidosObservacionesProveedores(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.PedidosObservacionesProveedores_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroPedido, ent.Linea, ent.Observacion)

            'Case TipoSP._U

         Case TipoSP._D
            sql.PedidosObservacionesProveedores_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroPedido, 0)
      End Select
   End Sub

   Private Sub CargarUna(ByVal o As Entidades.PedidoObservacionProveedor, ByVal dr As DataRow)
      With o
         .IdSucursal = Int32.Parse(dr(Entidades.PedidoObservacionProveedor.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.PedidoObservacionProveedor.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.PedidoObservacionProveedor.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.PedidoObservacionProveedor.Columnas.Linea.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.PedidoObservacionProveedor.Columnas.NumeroPedido.ToString()).ToString())
         .Linea = Integer.Parse(dr(Entidades.PedidoObservacionProveedor.Columnas.Linea.ToString()).ToString())
         .Observacion = dr(Entidades.PedidoObservacionProveedor.Columnas.Observacion.ToString()).ToString()
      End With
   End Sub

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroPedido As Long,
                          linea As Integer) As Entidades.PedidoObservacionProveedor
      Dim sql As SqlServer.PedidosObservacionesProveedores = New SqlServer.PedidosObservacionesProveedores(da)

      Dim dt As DataTable = sql.PedidosObservacionesProveedores_G1(idSucursal,
                                                        idTipoComprobante,
                                                        letra,
                                                        centroEmisor,
                                                        numeroPedido,
                                                        linea)
      If dt.Rows.Count > 0 Then
         Dim o As Entidades.PedidoObservacionProveedor = New Entidades.PedidoObservacionProveedor()
         CargarUna(o, dt.Rows(0))
         Return o
      Else
         Throw New Exception("No existe la Observación del Pedido.")
      End If
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            numeroPedido As Long) As List(Of Entidades.PedidoObservacionProveedor)
      Dim lst As List(Of Entidades.PedidoObservacionProveedor) = New List(Of Entidades.PedidoObservacionProveedor)()

      Dim dt As DataTable = GetAll(idSucursal,
                                   idTipoComprobante,
                                   letra,
                                   centroEmisor,
                                   numeroPedido)
      For Each dr As DataRow In dt.Rows
         Dim o As Entidades.PedidoObservacionProveedor = New Entidades.PedidoObservacionProveedor()
         CargarUna(o, dr)
         lst.Add(o)
      Next
      Return lst
   End Function
#End Region

End Class
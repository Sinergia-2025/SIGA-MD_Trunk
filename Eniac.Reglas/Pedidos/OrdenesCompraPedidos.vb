Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class OrdenesCompraPedidos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "OrdenesCompraPedidosPedidos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "OrdenesCompraPedidosPedidos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.OrdenesCompraPedidos = New SqlServer.OrdenesCompraPedidos(Me.da)
      Return sql.Buscar(actual.Sucursal.IdSucursal, entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overloads Function GetAll() As System.Data.DataTable
      Return New SqlServer.OrdenesCompraPedidos(Me.da).OrdenesCompraPedidos_GA(actual.Sucursal.IdSucursal)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.Pedido = DirectCast(entidad, Entidades.Pedido)

      Try
         'da.OpenConection()
         ' da.BeginTransaction()

         Dim sql As SqlServer.OrdenesCompraPedidos = New SqlServer.OrdenesCompraPedidos(Me.da)

         Select Case tipo

            Case TipoSP._I
               sql.OrdenesCompraPedidos_I(en.IdSucursal, en.NumeroOrdenCompra, en.Cliente.IdCliente, en.TipoComprobante.IdTipoComprobante, _
                                          en.LetraComprobante, en.CentroEmisor, en.NumeroPedido)

            Case TipoSP._U
               ' sql.OrdenesCompraPedidos_U(en.NumeroOrdenCompraPedido, en.IdProveedor, en.IdFormasPago, en.FechaPedidos, en.Usuario)

            Case TipoSP._D
               sql.OrdenesCompraPedidos_D(en.IdSucursal, en.NumeroOrdenCompra, en.Cliente.IdCliente)

         End Select

         ' da.CommitTransaction()

      Catch ex As Exception
         'da.RollbakTransaction()
         Throw ex

      Finally
         'da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.OrdenCompraPedido, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.OrdenCompraPedido.Columnas.IdSucursal.ToString()).ToString())
         .NumeroOrdenCompra = Long.Parse(dr(Entidades.OrdenCompraPedido.Columnas.NumeroOrdenCompra.ToString()).ToString())
         .IdCliente = Long.Parse(dr(Entidades.OrdenCompraPedido.Columnas.IdCliente.ToString()).ToString())
         .TipoComprobante = New Reglas.TiposComprobantes(da).GetUno(dr(Entidades.OrdenCompraPedido.Columnas.IdTipoComprobante.ToString()).ToString())
         .LetraComprobante = dr(Entidades.OrdenCompraPedido.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.OrdenCompraPedido.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroPedido = Long.Parse(dr(Entidades.OrdenCompraPedido.Columnas.NumeroPedido.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.OrdenCompraPedido)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.OrdenCompraPedido
      Dim oLis As List(Of Entidades.OrdenCompraPedido) = New List(Of Entidades.OrdenCompraPedido)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.OrdenCompraPedido()
         Me.CargarUna(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal IdSucursal As Integer, ByVal NumeroOrdenCompraPedido As Long) As Entidades.OrdenCompraPedido
      Dim sql As SqlServer.OrdenesCompraPedidos = New SqlServer.OrdenesCompraPedidos(Me.da)
      Dim dt As DataTable = sql.OrdenesCompraPedidos_G1(IdSucursal, NumeroOrdenCompraPedido)
      Dim o As Entidades.OrdenCompraPedido = New Entidades.OrdenCompraPedido()
      If dt.Rows.Count > 0 Then
         Me.CargarUna(o, dt.Rows(0))
      Else
         Throw New Exception("No Existe el Pedido.")
      End If
      Return o
   End Function

   Public Function Get1(ByVal IdSucursal As Integer, ByVal NumeroOrdenCompraPedido As Long) As DataTable
      Dim sql As SqlServer.OrdenesCompraPedidos = New SqlServer.OrdenesCompraPedidos(Me.da)
      Return sql.OrdenesCompraPedidos_G1(IdSucursal, NumeroOrdenCompraPedido)
   End Function

   Public Function ExistePedido(IdSucursal As Integer, ordenCompra As Long, idCliente As Long) As Boolean
      Return New SqlServer.OrdenesCompraPedidos(Me.da).ExistePedido(IdSucursal, ordenCompra, idCliente)
   End Function

#End Region

End Class

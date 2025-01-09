#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class TiposComprobantesProductos
   Inherits Eniac.Reglas.Base
#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoComprobanteProducto.NombreTabla
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
      Dim sql As SqlServer.TiposComprobantesProductos = New SqlServer.TiposComprobantesProductos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposComprobantesProductos(Me.da).TiposComprobantesProductos_GA()
   End Function
#End Region
#Region "Metodos Privados"
   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.TipoComprobanteProducto), TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.TipoComprobanteProducto), TipoSP._U)
   End Sub

   Public Sub Merge(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.TipoComprobanteProducto), TipoSP._M)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.TipoComprobanteProducto), TipoSP._D)
   End Sub
   Private Sub EjecutaSP(ByVal en As Entidades.TipoComprobanteProducto, ByVal tipo As TipoSP)

      Dim sql As SqlServer.TiposComprobantesProductos = New SqlServer.TiposComprobantesProductos(da)
      Select Case tipo
         Case TipoSP._I
            sql.TiposComprobantesProductos_I(en.IdTipoComprobante, en.IdProducto, en.Cantidad)
         Case TipoSP._U
            sql.TiposComprobantesProductos_U(en.IdTipoComprobante, en.IdProducto, en.Cantidad)

         Case TipoSP._D
            sql.TiposComprobantesProductos_D(en.IdTipoComprobante, en.IdProducto)
      End Select
   End Sub
   Private Sub CargarUno(ByVal o As Entidades.TipoComprobanteProducto, ByVal dr As DataRow)
      With o

         .IdTipoComprobante = dr(Entidades.TipoComprobanteProducto.Columnas.IdTipoComprobante.ToString()).ToString()
         .IdProducto = dr(Entidades.TipoComprobanteProducto.Columnas.IdProducto.ToString()).ToString()
         .NombreProducto = dr(Entidades.Producto.Columnas.NombreProducto.ToString()).ToString()
         .Cantidad = Decimal.Parse(dr(Entidades.TipoComprobanteProducto.Columnas.Cantidad.ToString()).ToString())

      End With
   End Sub
#End Region
#Region "Metodos publicos"
   Public Function GetUno(idTipoComprobante As String,
                          idProducto As String,
                          accion As AccionesSiNoExisteRegistro) As Entidades.TipoComprobanteProducto
      Dim dt As DataTable = New SqlServer.TiposComprobantesProductos(da).TiposComprobantesProductos_G1(IdTipoComprobante, IdProducto)
      Dim o As Entidades.TipoComprobanteProducto = New Entidades.TipoComprobanteProducto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         ElseIf accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No se encontró el Producto {1} del Tipo de Comprobante {0}", idTipoComprobante, idProducto))
         End If
      End If
      Return o
   End Function

   Public Function GetTodos(idTipoComprobanteProducto As String) As List(Of Entidades.TipoComprobanteProducto)
      Return CargaLista(New SqlServer.TiposComprobantesProductos(da).TiposComprobantesProductos_GA(idTipoComprobanteProducto),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.TipoComprobanteProducto), dr), Function() New Entidades.TipoComprobanteProducto())
   End Function
#End Region
End Class

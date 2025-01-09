Option Explicit On
Option Strict On
Public Class ProductosModelosTipos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ProductoModeloTipo.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProductoModeloTipo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModeloTipo), TipoSP._I)
   End Sub
   Public Sub _Actualiza(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModeloTipo), TipoSP._U)
   End Sub
   Public Sub _Borra(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModeloTipo), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModeloTipo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModeloTipo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModeloTipo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.ProductosModelosTipos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProductosModelosTipos(da).GetCodigoMaximo() + 1
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sProductosModelosTipos As SqlServer.ProductosModelosTipos = New SqlServer.ProductosModelosTipos(da)
      Return sProductosModelosTipos.ProductosModelosTipos_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(idProductoModeloTipo As Integer) As Entidades.ProductoModeloTipo
      Dim sProductosModelosTipos As SqlServer.ProductosModelosTipos = New SqlServer.ProductosModelosTipos(da)
      Return CargaEntidad(sProductosModelosTipos.ProductosModelosTipos_G1(idProductoModeloTipo),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoModeloTipo(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Tipo de Modelo {0}", idProductoModeloTipo))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProductoModeloTipo)
      Dim dt As DataTable = Me.GetAll()
      Dim eProductoModeloTipo As Entidades.ProductoModeloTipo
      Dim lista As List(Of Entidades.ProductoModeloTipo) = New List(Of Entidades.ProductoModeloTipo)
      For Each dr As DataRow In dt.Rows
         eProductoModeloTipo = New Entidades.ProductoModeloTipo()
         Me.CargarUno(eProductoModeloTipo, dr)
         lista.Add(eProductoModeloTipo)
      Next
      Return lista
   End Function


   Public Function GetPorNombre(ProductoModeloTipo As String) As DataTable
      Dim sProductosModelosTipos As SqlServer.ProductosModelosTipos = New SqlServer.ProductosModelosTipos(da)
      Return sProductosModelosTipos.ProductosModelosTipos_GetPorNombre(ProductoModeloTipo)
   End Function
#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProductoModeloTipo, tipo As TipoSP)
      Dim sProductosModelosTipos As SqlServer.ProductosModelosTipos = New SqlServer.ProductosModelosTipos(da)
      Select Case tipo
         Case TipoSP._I
            If en.IdProductoModeloTipo = 0 Then
               en.IdProductoModeloTipo = Me.GetCodigoMaximo()
            End If
            sProductosModelosTipos.ProductosModelosTipos_I(en.IdProductoModeloTipo,
                                                               en.NombreProductoModeloTipo)
         Case TipoSP._U
            sProductosModelosTipos.ProductosModelosTipos_U(en.IdProductoModeloTipo,
                                                               en.NombreProductoModeloTipo)
         Case TipoSP._D
            sProductosModelosTipos.ProductosModelosTipos_D(en.IdProductoModeloTipo)
      End Select
   End Sub

   Private Sub CargarUno(eProductoModeloTipo As Entidades.ProductoModeloTipo, dr As DataRow)
      With eProductoModeloTipo
         .IdProductoModeloTipo = dr.Field(Of Integer)(Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString())
         .NombreProductoModeloTipo = dr.Field(Of String)(Entidades.ProductoModeloTipo.Columnas.NombreProductoModeloTipo.ToString())
      End With
   End Sub

#End Region

End Class

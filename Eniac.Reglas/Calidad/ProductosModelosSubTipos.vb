Option Explicit On
Option Strict On
Public Class ProductosModelosSubTipos
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ProductoModeloSubTipo.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProductoModeloSubTipo.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModeloSubTipo), TipoSP._I)
   End Sub
   Public Sub _Actualiza(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModeloSubTipo), TipoSP._U)
   End Sub
   Public Sub _Borra(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoModeloSubTipo), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModeloSubTipo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModeloSubTipo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoModeloSubTipo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.ProductosModelosSubTipos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProductosModelosSubTipos(da).GetCodigoMaximo() + 1
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sProductosModelosSubTipos As SqlServer.ProductosModelosSubTipos = New SqlServer.ProductosModelosSubTipos(da)
      Return sProductosModelosSubTipos.ProductosModelosSubTipos_GA()
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(idProductoModeloSubTipo As Integer) As Entidades.ProductoModeloSubTipo
      Dim sProductosModelosSubTipos As SqlServer.ProductosModelosSubTipos = New SqlServer.ProductosModelosSubTipos(da)
      Return CargaEntidad(sProductosModelosSubTipos.ProductosModelosSubTipos_G1(idProductoModeloSubTipo),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoModeloSubTipo(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Tipo de Modelo {0}", idProductoModeloSubTipo))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProductoModeloSubTipo)
      Dim dt As DataTable = Me.GetAll()
      Dim eProductoModeloSubTipo As Entidades.ProductoModeloSubTipo
      Dim lista As List(Of Entidades.ProductoModeloSubTipo) = New List(Of Entidades.ProductoModeloSubTipo)
      For Each dr As DataRow In dt.Rows
         eProductoModeloSubTipo = New Entidades.ProductoModeloSubTipo()
         Me.CargarUno(eProductoModeloSubTipo, dr)
         lista.Add(eProductoModeloSubTipo)
      Next
      Return lista
   End Function


   Public Function GetPorNombre(ProductoModeloSubTipo As String) As DataTable
      Dim sProductosModelosSubTipos As SqlServer.ProductosModelosSubTipos = New SqlServer.ProductosModelosSubTipos(da)
      Return sProductosModelosSubTipos.ProductosModelosSubTipos_GetPorNombre(ProductoModeloSubTipo)
   End Function

   Public Function GetxTipoModelo(IdProductoModeloTipo As Integer) As DataTable
      Dim sProductosModelosSubTipos As SqlServer.ProductosModelosSubTipos = New SqlServer.ProductosModelosSubTipos(da)
      Return sProductosModelosSubTipos.ProductosModelosSubTipos_GetPorTipo(IdProductoModeloTipo)
   End Function
#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProductoModeloSubTipo, tipo As TipoSP)
      Dim sProductosModelosSubTipos As SqlServer.ProductosModelosSubTipos = New SqlServer.ProductosModelosSubTipos(da)
      Select Case tipo
         Case TipoSP._I
            If en.IdProductoModeloSubTipo = 0 Then
               en.IdProductoModeloSubTipo = Me.GetCodigoMaximo()
            End If
            sProductosModelosSubTipos.ProductosModelosSubTipos_I(en.IdProductoModeloSubTipo,
                                                               en.NombreProductoModeloSubTipo,
                                                               en.IdProductoModeloTipo)
         Case TipoSP._U
            sProductosModelosSubTipos.ProductosModelosSubTipos_U(en.IdProductoModeloSubTipo,
                                                               en.NombreProductoModeloSubTipo,
                                                               en.IdProductoModeloTipo)
         Case TipoSP._D
            sProductosModelosSubTipos.ProductosModelosSubTipos_D(en.IdProductoModeloSubTipo)
      End Select
   End Sub

   Private Sub CargarUno(eProductoModeloSubTipo As Entidades.ProductoModeloSubTipo, dr As DataRow)
      With eProductoModeloSubTipo
         .IdProductoModeloSubTipo = dr.Field(Of Integer)(Entidades.ProductoModeloSubTipo.Columnas.IdProductoModeloSubTipo.ToString())
         .NombreProductoModeloSubTipo = dr.Field(Of String)(Entidades.ProductoModeloSubTipo.Columnas.NombreProductoModeloSubTipo.ToString())
         .IdProductoModeloTipo = dr.Field(Of Integer)(Entidades.ProductoModeloTipo.Columnas.IdProductoModeloTipo.ToString())
      End With

   End Sub

#End Region

End Class

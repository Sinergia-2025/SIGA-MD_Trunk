Option Explicit On
Option Strict On
Public Class ProductosTiposServicios
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.ProductoTipoServicio.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ProductoTipoServicio.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoTipoServicio), TipoSP._I)
   End Sub
   Public Sub _Actualiza(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoTipoServicio), TipoSP._U)
   End Sub
   Public Sub _Borra(e As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(e, Entidades.ProductoTipoServicio), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoTipoServicio), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoTipoServicio), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ProductoTipoServicio), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.ProductosTiposServicios(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ProductosTiposServicios(da).GetCodigoMaximo() + 1
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Dim sListasControlTipos As SqlServer.ProductosTiposServicios = New SqlServer.ProductosTiposServicios(da)
      Return sListasControlTipos.ProductosTiposServicios_GA()
   End Function


#End Region

#Region "Métodos Públicos"

   Public Function GetABMProdCalidad() As System.Data.DataTable
      Dim sListasControlTipos As SqlServer.ProductosTiposServicios = New SqlServer.ProductosTiposServicios(da)
      Return sListasControlTipos.ProductosTiposServicios_GABMCalidad()
   End Function

   Public Function GetUno(idProductoTipoServicio As Integer) As Entidades.ProductoTipoServicio
      Dim sProductosTiposServicios As SqlServer.ProductosTiposServicios = New SqlServer.ProductosTiposServicios(da)
      Return CargaEntidad(sProductosTiposServicios.ProductosTiposServicios_G1(idProductoTipoServicio),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ProductoTipoServicio(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Tipo de Lista de Control {0}", idProductoTipoServicio))
   End Function

   Public Function GetTodos() As List(Of Entidades.ProductoTipoServicio)
      Dim dt As DataTable = Me.GetAll()
      Dim eProductoTipoServicio As Entidades.ProductoTipoServicio
      Dim lista As List(Of Entidades.ProductoTipoServicio) = New List(Of Entidades.ProductoTipoServicio)
      For Each dr As DataRow In dt.Rows
         eProductoTipoServicio = New Entidades.ProductoTipoServicio()
         Me.CargarUno(eProductoTipoServicio, dr)
         lista.Add(eProductoTipoServicio)
      Next
      Return lista
   End Function

   Public Function ListasDeControlFueraDeRango(rangoDesde As Integer,
                                               rangoHasta As Integer,
                                               idTipoListaControl As Integer) As DataTable
      Return New SqlServer.ListasControlTipos(da).ListasDeControlFueraDeRango(rangoDesde, rangoHasta, idTipoListaControl)
   End Function

   Public Function ConsultarSolapamientoListasDeControl(rangoDesde As Integer,
                                                     rangoHasta As Integer,
                                                     idTipoListaControl As Integer) As DataTable
      Return New SqlServer.ListasControlTipos(da).ConsultarSolapamientoListasDeControl(rangoDesde, rangoHasta, idTipoListaControl)
   End Function

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.ProductoTipoServicio, tipo As TipoSP)
      Dim sProductosTiposServicios As SqlServer.ProductosTiposServicios = New SqlServer.ProductosTiposServicios(da)
      Select Case tipo
         Case TipoSP._I
            sProductosTiposServicios.ProductosTiposServicios_I(en.IdProductoTipoServicio,
                                                               en.NombreProductoTipoServicio,
                                                               en.Prefijo)
         Case TipoSP._U
            sProductosTiposServicios.ProductosTiposServicios_U(en.IdProductoTipoServicio,
                                                               en.NombreProductoTipoServicio,
                                                               en.Prefijo)
         Case TipoSP._D
            sProductosTiposServicios.ProductosTiposServicios_D(en.IdProductoTipoServicio)
      End Select
   End Sub

   Private Sub CargarUno(eProductoTipoServicio As Entidades.ProductoTipoServicio, dr As DataRow)
      With eProductoTipoServicio
         .IdProductoTipoServicio = dr.Field(Of Integer)(Entidades.ProductoTipoServicio.Columnas.IdProductoTipoServicio.ToString())
         .NombreProductoTipoServicio = dr.Field(Of String)(Entidades.ProductoTipoServicio.Columnas.NombreProductoTipoServicio.ToString())
         .Prefijo = dr.Field(Of String)(Entidades.ProductoTipoServicio.Columnas.Prefijo.ToString())
      End With
   End Sub

#End Region

End Class

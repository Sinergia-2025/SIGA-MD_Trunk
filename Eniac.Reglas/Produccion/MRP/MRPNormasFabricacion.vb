#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class MRPNormasFabricacion
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.MRPNormaFabricacion.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPNormaFabricacion), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPNormaFabricacion), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.MRPNormaFabricacion), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.MRPNormasFabricacion(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.MRPNormasFabricacion(Me.da).NormasFabricacion_GA()
   End Function

   Public Function GetFiltradoPorNombre(nombreNorma As String) As DataTable
      Return New SqlServer.MRPNormasFabricacion(da).NormasFabricacion_Nombre(nombreNorma)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPNormaFabricacion, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPNormasFabricacion(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.NormasFabricacion_I(en.IdNormaFab, en.CodigoNormaFab, en.Descripcion, en.DetalleDispositivos, en.DetalleMetodos, en.DetalleSeguridad, en.DetalleControlCalidad, en.Activo)
         Case TipoSP._U
            sqlC.NormasFabricacion_U(en.IdNormaFab, en.CodigoNormaFab, en.Descripcion, en.DetalleDispositivos, en.DetalleMetodos, en.DetalleSeguridad, en.DetalleControlCalidad, en.Activo)
         Case TipoSP._D
            sqlC.NormasFabricacion_D(en.IdNormaFab)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPNormaFabricacion, dr As DataRow)
      With o
         .IdNormaFab = dr.Field(Of Integer)(Entidades.MRPNormaFabricacion.Columnas.IdNormaFab.ToString())
         .CodigoNormaFab = dr.Field(Of String)(Entidades.MRPNormaFabricacion.Columnas.CodigoNormaFab.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.MRPNormaFabricacion.Columnas.Descripcion.ToString())
         .DetalleDispositivos = dr.Field(Of String)(Entidades.MRPNormaFabricacion.Columnas.DetalleDispositivos.ToString())
         .DetalleMetodos = dr.Field(Of String)(Entidades.MRPNormaFabricacion.Columnas.DetalleMetodos.ToString())
         .DetalleSeguridad = dr.Field(Of String)(Entidades.MRPNormaFabricacion.Columnas.DetalleSeguridad.ToString())
         .DetalleControlCalidad = dr.Field(Of String)(Entidades.MRPNormaFabricacion.Columnas.DetalleControlCalidad.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.MRPNormaFabricacion.Columnas.Activo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idNormaFab As Integer) As Entidades.MRPNormaFabricacion
      Return GetUno(idNormaFab, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idNormaFab As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MRPNormaFabricacion
      Return CargaEntidad(New SqlServer.MRPNormasFabricacion(Me.da).NormasFabricacion_G1(idNormaFab),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPNormaFabricacion(),
                          accion, Function() String.Format("No existe Norma de Fabricacion con Id: {0}", idNormaFab))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPNormaFabricacion)
      Return CargaLista(New SqlServer.MRPNormasFabricacion(Me.da).NormasFabricacion_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPNormaFabricacion())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MRPNormasFabricacion(Me.da).GetCodigoMaximo()
   End Function
   Public Function Existe(codigoSeccion As String) As Boolean
      Return New SqlServer.MRPNormasFabricacion(da).Existe(codigoSeccion)
   End Function

#End Region

End Class

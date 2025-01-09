Public Class SucursalesUbicacionesEstados
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.SucursalUbicacionEstado.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacionEstado), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacionEstado), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.SucursalUbicacionEstado), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.SucursalesUbicacionesEstados(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.SucursalesUbicacionesEstados(Me.da).SucursalesUbicacionesEstados_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.SucursalUbicacionEstado, tipo As TipoSP)
      Dim sqlC = New SqlServer.SucursalesUbicacionesEstados(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.SucursalesUbicacionesEstados_I(en.IdEstado, en.NombreEstado, en.OrdenEstado, en.Activo)
         Case TipoSP._U
            sqlC.SucursalesUbicacionesEstados_U(en.IdEstado, en.NombreEstado, en.OrdenEstado, en.Activo)
         Case TipoSP._D
            sqlC.SucursalesUbicacionesEstados_D(en.IdEstado)
      End Select

   End Sub
   Private Sub CargarUno(o As Entidades.SucursalUbicacionEstado, dr As DataRow)
      With o
         .IdEstado = dr.Field(Of Integer)(Entidades.SucursalUbicacionEstado.Columnas.IdEstado.ToString())
         .NombreEstado = dr.Field(Of String)(Entidades.SucursalUbicacionEstado.Columnas.NombreEstado.ToString())
         .OrdenEstado = dr.Field(Of Integer)(Entidades.SucursalUbicacionEstado.Columnas.OrdenEstado.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.SucursalUbicacionEstado.Columnas.Activo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(idEstado As Integer) As Entidades.SucursalUbicacionEstado
      Return GetUno(idEstado, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstado As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.SucursalUbicacionEstado
      Return CargaEntidad(New SqlServer.SucursalesUbicacionesEstados(Me.da).SucursalesUbicacionesEstados_G1(idEstado),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SucursalUbicacionEstado(),
                          accion, Function() String.Format("No existe Sucursal Ubicacion Estado ({0})", idEstado))
   End Function
   Public Function GetTodos() As List(Of Entidades.SucursalUbicacionEstado)
      Return CargaLista(New SqlServer.SucursalesUbicacionesEstados(Me.da).SucursalesUbicacionesEstados_GA(),
                      Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.SucursalUbicacionEstado())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SucursalesUbicacionesEstados(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetOrdenMinimo() As Integer
      Return New SqlServer.SucursalesUbicacionesEstados(Me.da).GetOrdenMinimo(Entidades.SucursalUbicacionEstado.Columnas.IdEstado.ToString(),
                                                                              "EstadosUbicaciones",
                                                                              "OrdenEstado = (SELECT MIN(OrdenEstado) FROM EstadosUbicaciones)")
   End Function
#End Region
End Class

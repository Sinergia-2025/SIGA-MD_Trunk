Public Class Aplicaciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Aplicaciones", accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Aplicacion)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Aplicacion)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Aplicacion)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Aplicaciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Aplicaciones(da).Aplicaciones_GA(propietarioAplicacion:=Nothing)
   End Function
   Public Overloads Function GetAll(propietarioAplicacion As Entidades.AplicacionPropietario?) As DataTable
      Return New SqlServer.Aplicaciones(da).Aplicaciones_GA(propietarioAplicacion)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.Aplicacion, tipo As TipoSP)
      Dim sqlC = New SqlServer.Aplicaciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Aplicaciones_I(en.IdAplicacion, en.NombreAplicacion, en.IdAplicacionBase, en.PropietarioAplicacion)
         Case TipoSP._U
            sqlC.Aplicaciones_U(en.IdAplicacion, en.NombreAplicacion, en.IdAplicacionBase, en.PropietarioAplicacion)
         Case TipoSP._D
            sqlC.Aplicaciones_D(en.IdAplicacion)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.Aplicacion, dr As DataRow)
      With o
         .IdAplicacion = dr.Field(Of String)(Entidades.Aplicacion.Columnas.IdAplicacion.ToString())
         .NombreAplicacion = dr.Field(Of String)(Entidades.Aplicacion.Columnas.NombreAplicacion.ToString())
         .IdAplicacionBase = dr.Field(Of String)(Entidades.Aplicacion.Columnas.IdAplicacionBase.ToString()).IfNull()
         .PropietarioAplicacion = dr.Field(Of String)(Entidades.Aplicacion.Columnas.PropietarioAplicacion.ToString()).StringToEnum(Entidades.AplicacionPropietario.PROPIO)
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.Aplicacion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Aplicacion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Aplicacion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idAplicacion As String) As DataTable
      Return New SqlServer.Aplicaciones(da).Aplicaciones_G1(idAplicacion)
   End Function
   Public Function GetUno(idAplicacion As String) As Entidades.Aplicacion
      Return GetUno(idAplicacion, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idAplicacion As String, accion As AccionesSiNoExisteRegistro) As Entidades.Aplicacion
      Return CargaEntidad(Get1(idAplicacion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Aplicacion(),
                          accion, String.Format("No existe Aplicación con IdAplicacion ´{0}´", idAplicacion))
   End Function
   Public Function GetTodos() As List(Of Entidades.Aplicacion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Aplicacion())
   End Function

   Public Function GetFiltradoPorCodigo(idAplicacion As String) As DataTable
      Return GetFiltradoPorCodigo(idAplicacion, Entidades.AplicacionPropietario.PROPIO)
   End Function
   Public Function GetFiltradoPorCodigo(idAplicacion As String, propietarioAplicacion As Entidades.AplicacionPropietario?) As DataTable
      Dim sql = New SqlServer.Aplicaciones(da)
      Dim dt = sql.Aplicaciones_GA(idAplicacion, nombreAplicacion:=String.Empty, idExacto:=True, nombreExacto:=False, propietarioAplicacion)
      If dt.Rows.Count = 0 Then
         dt = sql.Aplicaciones_GA(idAplicacion, nombreAplicacion:=String.Empty, idExacto:=False, nombreExacto:=False, propietarioAplicacion)
      End If
      Return dt
   End Function
   Public Function GetFiltradoPorNombre(nombreAplicacion As String) As DataTable
      Return GetFiltradoPorNombre(nombreAplicacion, Entidades.AplicacionPropietario.PROPIO)
   End Function
   Public Function GetFiltradoPorNombre(nombreAplicacion As String, propietarioAplicacion As Entidades.AplicacionPropietario?) As DataTable
      Return New SqlServer.Aplicaciones(da).Aplicaciones_GA(idAplicacion:=String.Empty, nombreAplicacion:=nombreAplicacion, idExacto:=False, nombreExacto:=False, propietarioAplicacion)
   End Function

#End Region

End Class
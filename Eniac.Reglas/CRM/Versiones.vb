Public Class Versiones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "Versiones"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.Version)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.Version)))
   End Sub

   Public Sub Merge(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.Version)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.Version)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Versiones = New SqlServer.Versiones(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Versiones(da).Versiones_GA(groupByNroVersion:=False)
   End Function

   Public Sub _Insertar(entidad As Entidades.Version)
      EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.Version)
      EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Merge(entidad As Entidades.Version)
      EjecutaSP(entidad, TipoSP._M)
   End Sub

   Public Sub _Borrar(entidad As Entidades.Version)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Version, tipo As TipoSP)
      Dim sql = New SqlServer.Versiones(da)
      Select Case tipo
         Case TipoSP._I
            sql.Versiones_I(en.IdAplicacion, en.NroVersion, en.VersionFecha, en.IdAplicacionBase, en.NroVersionAplicacionBase,
                            en.VersionFramework, en.VersionReportViewer, en.VersionLenguaje)
         Case TipoSP._U
            sql.Versiones_U(en.IdAplicacion, en.NroVersion, en.VersionFecha, en.IdAplicacionBase, en.NroVersionAplicacionBase,
                            en.VersionFramework, en.VersionReportViewer, en.VersionLenguaje)
         Case TipoSP._M
            sql.Versiones_M(en.IdAplicacion, en.NroVersion, en.VersionFecha, en.IdAplicacionBase, en.NroVersionAplicacionBase,
                            en.VersionFramework, en.VersionReportViewer, en.VersionLenguaje)
         Case TipoSP._D
            sql.Versiones_D(en.IdAplicacion, en.NroVersion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Version, dr As DataRow)
      With o
         .IdAplicacion = dr(Entidades.Version.Columnas.IdAplicacion.ToString()).ToString()
         .NroVersion = dr(Entidades.Version.Columnas.NroVersion.ToString()).ToString()
         .VersionFecha = Date.Parse(dr(Entidades.Version.Columnas.VersionFecha.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Version.Columnas.IdAplicacionBase.ToString()).ToString()) Then
            .IdAplicacionBase = dr(Entidades.Version.Columnas.IdAplicacionBase.ToString()).ToString()
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.Version.Columnas.NroVersionAplicacionBase.ToString()).ToString()) Then
            .NroVersionAplicacionBase = dr(Entidades.Version.Columnas.NroVersionAplicacionBase.ToString()).ToString()
         End If
         .VersionFramework = dr(Entidades.Version.Columnas.VersionFramework.ToString()).ToString()
         .VersionReportViewer = dr(Entidades.Version.Columnas.VersionReportViewer.ToString()).ToString()
         .VersionLenguaje = dr(Entidades.Version.Columnas.VersionLenguaje.ToString()).ToString()

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idAplicacion As String, nroVersion As String, Optional accion As AccionesSiNoExisteRegistro = AccionesSiNoExisteRegistro.Vacio) As Entidades.Version
      Return CargaEntidad(New SqlServer.Versiones(da).Versiones_G1(idAplicacion, nroVersion),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Version(),
                          accion, String.Format("No se encontro la versión {1} de la Aplicación {0}.", idAplicacion, nroVersion))
   End Function

   Private Overloads Function CargaLista(dt As DataTable) As List(Of Entidades.Version)
      Return CargaLista(dt, Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Version())
   End Function

   Public Function GetTodos() As List(Of Entidades.Version)
      Return CargaLista(GetAll())
   End Function
   Public Function GetTodos(aplicacion As String, versionDesde As String, versionHasta As String) As List(Of Entidades.Version)
      Return CargaLista(New SqlServer.Versiones(da).Versiones_GA(aplicacion, versionDesde, versionHasta))
   End Function

   Public Function GetTodos(idAplicacion As String, groupByNroVersion As Boolean) As List(Of Entidades.Version)
      Return CargaLista(New SqlServer.Versiones(da).Versiones_GA(idAplicacion, groupByNroVersion))
   End Function

   Public Function GetUltimaPorAplicacion(idAplicacion As String) As DataTable
      Return New SqlServer.Versiones(da).GetUltimaPorAplicacion(idAplicacion)
   End Function

   Public Function ExisteVersion(idAplicacion As String, nroVersion As String) As Boolean
      Return GetUno(idAplicacion, nroVersion, AccionesSiNoExisteRegistro.Nulo) IsNot Nothing
   End Function

#End Region

End Class
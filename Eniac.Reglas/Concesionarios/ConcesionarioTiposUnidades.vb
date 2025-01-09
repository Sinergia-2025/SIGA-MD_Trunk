Public Class ConcesionarioTiposUnidades
   Inherits Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = Entidades.ConcesionarioTipoUnidad.NombreTabla
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ConcesionarioTipoUnidad.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioTipoUnidad), TipoSP._I))

   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioTipoUnidad), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioTipoUnidad), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ConcesionarioTiposUnidades = New SqlServer.ConcesionarioTiposUnidades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ConcesionarioTiposUnidades(Me.da).TiposUnidades_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionarioTipoUnidad, tipo As TipoSP)
      Dim sTipoUnid As SqlServer.ConcesionarioTiposUnidades = New SqlServer.ConcesionarioTiposUnidades(da)
      Select Case tipo
         Case TipoSP._I
            sTipoUnid.TiposUnidades_I(en.IdTipoUnidad, en.NombreTipoUnidad, en.DescripcionTipoUnidad, en.MuestraEnCerokm, en.MuestraEnUsado, en.SolicitaDistribucionEje)
         Case TipoSP._U
            sTipoUnid.TiposUnidades_U(en.IdTipoUnidad, en.NombreTipoUnidad, en.DescripcionTipoUnidad, en.MuestraEnCerokm, en.MuestraEnUsado, en.SolicitaDistribucionEje)
         Case TipoSP._D
            sTipoUnid.TiposUnidades_D(en.IdTipoUnidad, en.NombreTipoUnidad)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionarioTipoUnidad, dr As DataRow)
      With o
         .IdTipoUnidad = dr.Field(Of Integer)(Entidades.ConcesionarioTipoUnidad.columnas.IdTipoUnidad.ToString())
         .NombreTipoUnidad = dr.Field(Of String)(Entidades.ConcesionarioTipoUnidad.columnas.NombreTipoUnidad.ToString())
         .DescripcionTipoUnidad = dr.Field(Of String)(Entidades.ConcesionarioTipoUnidad.columnas.DescripcionTipoUnidad.ToString())
         .MuestraEnCerokm = dr.Field(Of Boolean)(Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnCerokm.ToString())
         .MuestraEnUsado = dr.Field(Of Boolean)(Entidades.ConcesionarioTipoUnidad.columnas.MuestraEnUsado.ToString())
         .SolicitaDistribucionEje = dr.Field(Of Boolean)(Entidades.ConcesionarioTipoUnidad.columnas.SolicitaDistribucionEje.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   'GET UNO
   Public Function GetUno(idTipoUnidad As Integer) As Entidades.ConcesionarioTipoUnidad
      Return GetUno(idTipoUnidad, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(IdTipoUnidad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionarioTipoUnidad
      Return CargaEntidad(New SqlServer.ConcesionarioTiposUnidades(Me.da).TiposUnidades_G1(IdTipoUnidad),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionarioTipoUnidad(),
         accion, Function() String.Format("No existe la Unidad con Id: {0}", IdTipoUnidad))
   End Function
   'GET TODOS
   Public Function GetTodos(ceroKM As Entidades.Publicos.SiNoTodos) As List(Of Entidades.ConcesionarioTipoUnidad)
      Return CargaLista(New SqlServer.ConcesionarioTiposUnidades(Me.da).TiposUnidades_GA(ceroKM),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionarioTipoUnidad())
   End Function
   'GET CODIGOMAXIMO
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ConcesionarioTiposUnidades(Me.da).GetCodigoMaximo()
   End Function
   'GET POR CODIGO
   Public Function GetPorCodigo(idUnidad As Integer) As DataTable
      Return New SqlServer.ConcesionarioTiposUnidades(da).TiposUnidades_G1(idUnidad)
   End Function
   'GET POR NOMBRE
   Public Function GetPorNombre(nombreTipoUnidad As String) As DataTable
      Return New SqlServer.ConcesionarioTiposUnidades(da).TiposUnidades_GA(nombreTipoUnidad, nombreExacto:=False)
   End Function
#End Region
End Class

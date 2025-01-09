Public Class ConcesionarioSubTiposUnidades
   Inherits Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = Entidades.ConcesionarioSubTipoUnidad.NombreTabla
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ConcesionarioSubTipoUnidad.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioSubTipoUnidad), TipoSP._I))

   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioSubTipoUnidad), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioSubTipoUnidad), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ConcesionarioSubTiposUnidades = New SqlServer.ConcesionarioSubTiposUnidades(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ConcesionarioSubTiposUnidades(da).SubTiposUnidades_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionarioSubTipoUnidad, tipo As TipoSP)
      Dim sSubTipoUnid As SqlServer.ConcesionarioSubTiposUnidades = New SqlServer.ConcesionarioSubTiposUnidades(da)
      Select Case tipo
         Case TipoSP._I
            sSubTipoUnid.SubTiposUnidades_I(en.IdSubTipoUnidad, en.NombreSubTipoUnidad, en.DescripcionSubTipoUnidad, en.IdTipoUnidad, en.SolicitaCantPuertasLaterales, en.SolicitaCantPisos, en.SolicitaVolumen)
         Case TipoSP._U
            sSubTipoUnid.SubTipoUnidades_U(en.IdSubTipoUnidad, en.NombreSubTipoUnidad, en.DescripcionSubTipoUnidad, en.IdTipoUnidad, en.SolicitaCantPuertasLaterales, en.SolicitaCantPisos, en.SolicitaVolumen)
         Case TipoSP._D
            sSubTipoUnid.SubTiposUnidades_D(en.IdSubTipoUnidad, en.NombreSubTipoUnidad)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionarioSubTipoUnidad, dr As DataRow)
      With o
         .IdSubTipoUnidad = dr.Field(Of Integer)(Entidades.ConcesionarioSubTipoUnidad.columnas.IdSubTipoUnidad.ToString())
         .NombreSubTipoUnidad = dr.Field(Of String)(Entidades.ConcesionarioSubTipoUnidad.columnas.NombreSubTipoUnidad.ToString())
         .DescripcionSubTipoUnidad = dr.Field(Of String)(Entidades.ConcesionarioSubTipoUnidad.columnas.DescripcionSubTipoUnidad.ToString())
         .IdTipoUnidad = dr.Field(Of Integer)(Entidades.ConcesionarioSubTipoUnidad.columnas.IdTipoUnidad.ToString())
         .SolicitaCantPuertasLaterales = dr.Field(Of Boolean)(Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPuertasLaterales.ToString())
         .SolicitaCantPisos = dr.Field(Of Boolean)(Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaCantPisos.ToString())
         .SolicitaVolumen = dr.Field(Of Boolean)(Entidades.ConcesionarioSubTipoUnidad.columnas.SolicitaVolumen.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   'GET UNO
   Public Function GetUno(idSubTipoUnidad As Integer) As Entidades.ConcesionarioSubTipoUnidad
      Return GetUno(idSubTipoUnidad, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idSubTipoUnidad As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionarioSubTipoUnidad
      Return CargaEntidad(New SqlServer.ConcesionarioSubTiposUnidades(da).SubTiposUnidades_G1(idSubTipoUnidad),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionarioSubTipoUnidad(),
         accion, Function() String.Format("No existe el Tipo de Unidad con Id: {0}", idSubTipoUnidad))
   End Function
   'GET TODOS
   Public Function GetTodos() As List(Of Entidades.ConcesionarioSubTipoUnidad)
      Return CargaLista(New SqlServer.ConcesionarioSubTiposUnidades(da).SubTiposUnidades_GA(),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionarioSubTipoUnidad())
   End Function
   Public Function GetTodos(idTipoUnidad As Integer) As List(Of Entidades.ConcesionarioSubTipoUnidad)
      Return CargaLista(New SqlServer.ConcesionarioSubTiposUnidades(da).SubTiposUnidades_GA(idTipoUnidad),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionarioSubTipoUnidad())
   End Function
   'GET CODIGOMAXIMO
   Public Function GetCodigoMaximo(ByVal idUnidad As Integer) As Integer
      Return New SqlServer.ConcesionarioSubTiposUnidades(da).GetCodigoMaximo()
   End Function
#End Region
End Class

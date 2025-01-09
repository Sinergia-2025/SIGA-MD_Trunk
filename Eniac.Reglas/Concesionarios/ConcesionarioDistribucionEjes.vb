Public Class ConcesionarioDistribucionEjes
   Inherits Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = Entidades.ConcesionarioDistribucionEje.NombreTabla
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.ConcesionarioDistribucionEje.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioDistribucionEje), TipoSP._I))

   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioDistribucionEje), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ConcesionarioDistribucionEje), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ConcesionarioDistribucionEjes = New SqlServer.ConcesionarioDistribucionEjes(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.ConcesionarioDistribucionEjes(da).DistribucionEje_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.ConcesionarioDistribucionEje, tipo As TipoSP)
      Dim sDistribEjes As SqlServer.ConcesionarioDistribucionEjes = New SqlServer.ConcesionarioDistribucionEjes(da)
      Select Case tipo
         Case TipoSP._I
            sDistribEjes.DistrubicionEjes_I(en.IdEje, en.NombreEje, en.DescripcionEje, en.IdTipoUnidad)
         Case TipoSP._U
            sDistribEjes.DistribucionEjes_U(en.IdEje, en.NombreEje, en.DescripcionEje, en.IdTipoUnidad)
         Case TipoSP._D
            sDistribEjes.DistribucionEjes_D(en.IdEje, en.NombreEje)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.ConcesionarioDistribucionEje, dr As DataRow)
      With o
         .IdEje = dr.Field(Of Integer)(Entidades.ConcesionarioDistribucionEje.columnas.IdEje.ToString())
         .NombreEje = dr.Field(Of String)(Entidades.ConcesionarioDistribucionEje.columnas.NombreEje.ToString())
         .DescripcionEje = dr.Field(Of String)(Entidades.ConcesionarioDistribucionEje.columnas.DescripcionEje.ToString())
         .IdTipoUnidad = dr.Field(Of Integer)(Entidades.ConcesionarioDistribucionEje.columnas.IdTipoUnidad.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   'GET UNO
   Public Function GetUno(idEje As Integer) As Entidades.ConcesionarioDistribucionEje
      Return GetUno(idEje, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idEje As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ConcesionarioDistribucionEje
      Return CargaEntidad(New SqlServer.ConcesionarioDistribucionEjes(da).DistribucionEje_G1(idEje),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionarioDistribucionEje(),
         accion, Function() String.Format("No existe el Eje con Id: {0}", idEje))
   End Function
   'GET TODOS
   Public Function GetTodos() As List(Of Entidades.ConcesionarioDistribucionEje)
      Return CargaLista(New SqlServer.ConcesionarioDistribucionEjes(da).DistribucionEje_GA(),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.ConcesionarioDistribucionEje())
   End Function
   Public Function GetTodos(idTipoUnidad As Integer) As List(Of Entidades.ConcesionarioDistribucionEje)
      Return CargaLista(New SqlServer.ConcesionarioDistribucionEjes(da).DistribucionEje_GA(idTipoUnidad),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ConcesionarioDistribucionEje())
   End Function
   'GET CODIGOMAXIMO
   Public Function GetCodigoMaximo(ByVal idEje As Integer) As Integer
      Return New SqlServer.ConcesionarioDistribucionEjes(da).GetCodigoMaximo()
   End Function
#End Region
End Class

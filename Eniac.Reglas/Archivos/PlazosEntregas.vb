#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class PlazosEntregas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.PlazoEntrega.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PlazoEntrega), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PlazoEntrega), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.PlazoEntrega), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.PlazosEntregas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.PlazosEntregas(Me.da).PlazosEntregas_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.PlazoEntrega, tipo As TipoSP)
      Dim sqlC = New SqlServer.PlazosEntregas(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.PlazosEntregas_I(en.IdPlazoEntrega, en.DescripcionPlazoEntrega, en.ActivoPlazoEntrega)
         Case TipoSP._U
            sqlC.PlazosEntregas_U(en.IdPlazoEntrega, en.DescripcionPlazoEntrega, en.ActivoPlazoEntrega)
         Case TipoSP._D
            sqlC.PlazosEntregas_D(en.IdPlazoEntrega)
      End Select
   End Sub
   Private Sub CargarUno(o As Entidades.PlazoEntrega, dr As DataRow)
      With o
         .IdPlazoEntrega = dr.Field(Of Integer)(Entidades.PlazoEntrega.Columnas.IdPlazoEntrega.ToString())
         .DescripcionPlazoEntrega = dr.Field(Of String)(Entidades.PlazoEntrega.Columnas.DescripcionPlazoentrega.ToString())
         .ActivoPlazoEntrega = dr.Field(Of Boolean)(Entidades.PlazoEntrega.Columnas.ActivoPlazoEntrega.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function GetUno(IdPlazoEntrega As Integer) As Entidades.PlazoEntrega
      Return GetUno(IdPlazoEntrega, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(IdPlazoEntrega As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.PlazoEntrega
      Return CargaEntidad(New SqlServer.PlazosEntregas(da).PlazosEntregas_G1(IdPlazoEntrega),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.PlazoEntrega(),
                          accion, Function() String.Format("No existe Plazo de Entrega con Id: {0}", IdPlazoEntrega))
   End Function
   Public Function GetTodos() As List(Of Entidades.PlazoEntrega)
      Return CargaLista(New SqlServer.PlazosEntregas(Me.da).PlazosEntregas_GA(),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.PlazoEntrega())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.PlazosEntregas(Me.da).GetCodigoMaximo()
   End Function
   Public Function GetFiltradoPorCodigo(codigo As Integer) As DataTable
      Return New SqlServer.PlazosEntregas(da).GetFiltradoPorCodigo(codigo)
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String) As DataTable
      Return New SqlServer.PlazosEntregas(da).GetFiltradoPorDescripcion(descripcion)
   End Function
#End Region
End Class

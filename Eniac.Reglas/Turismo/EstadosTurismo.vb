#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class EstadosTurismo
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "EstadosTurismo"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.EstadoTurismo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.EstadoTurismo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.EstadoTurismo), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.EstadosTurismo = New SqlServer.EstadosTurismo(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.EstadosTurismo(Me.da).EstadosTurismo_GA()
   End Function


   Public Overloads Function GetAll(ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.EstadosTurismo(Me.da).EstadosTurismo_GA(ordenarPosicion)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.EstadoTurismo, tipo As TipoSP)

      Dim sqlC As SqlServer.EstadosTurismo = New SqlServer.EstadosTurismo(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.EstadosTurismo_I(en.IdEstadoTurismo, en.NombreEstadoTurismo, en.Posicion,
                                        en.Finalizado, en.PorDefecto, en.SolicitaPasajeros, en.Color)
         Case TipoSP._U
            sqlC.EstadosTurismo_U(en.IdEstadoTurismo, en.NombreEstadoTurismo, en.Posicion,
                                        en.Finalizado, en.PorDefecto, en.SolicitaPasajeros, en.Color)
         Case TipoSP._D
            sqlC.EstadosTurismo_D(en.IdEstadoTurismo)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.EstadoTurismo, ByVal dr As DataRow)
      With o
         .IdEstadoTurismo = dr.Field(Of Integer)(Entidades.EstadoTurismo.Columnas.IdEstadoTurismo.ToString())
         .NombreEstadoTurismo = dr.Field(Of String)(Entidades.EstadoTurismo.Columnas.NombreEstadoTurismo.ToString())
         .Posicion = dr.Field(Of Integer)(Entidades.EstadoTurismo.Columnas.Posicion.ToString())
         .Finalizado = dr.Field(Of Boolean)(Entidades.EstadoTurismo.Columnas.Finalizado.ToString())
         .PorDefecto = dr.Field(Of Boolean)(Entidades.EstadoTurismo.Columnas.PorDefecto.ToString())
         .SolicitaPasajeros = dr.Field(Of Boolean)(Entidades.EstadoTurismo.Columnas.SolicitaPasajeros.ToString())
         If IsNumeric(dr(Entidades.EstadoTurismo.Columnas.Color.ToString())) Then
            .Color = dr.Field(Of Integer)(Entidades.EstadoTurismo.Columnas.Color.ToString())
         Else
            .Color = Nothing
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idEstadoTurismo As Integer) As Entidades.EstadoTurismo
      Return GetUno(idEstadoTurismo, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idEstadoTurismo As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.EstadoTurismo
      Return CargaEntidad(New SqlServer.EstadosTurismo(Me.da).EstadosTurismo_G1(idEstadoTurismo),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.EstadoTurismo(),
                          accion, Function() String.Format("No existe Tipo de Vehículo con Id: {0}", idEstadoTurismo))
   End Function

   Public Function GetTodos(Optional ordenarPosicion As Boolean = False) As List(Of Entidades.EstadoTurismo)
      Return CargaLista(Me.GetAll(ordenarPosicion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.EstadoTurismo), dr),
                        Function() New Entidades.EstadoTurismo())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.EstadosTurismo(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetEstadoPorDefecto() As Integer
      Return New SqlServer.EstadosTurismo(Me.da).EstadosTurismo_GxDefecto()
   End Function

   Public Function GetEstadoColorPorNombre(nombre As String) As Integer
      Return New SqlServer.EstadosTurismo(Me.da).EstadosTurismo_GxNombre(nombre)
   End Function

   Public Function GetEstadoFinalizado() As DataTable
      Return New SqlServer.EstadosTurismo(Me.da).EstadosTurismo_GFinalizado()
   End Function

   Public Function GetEstadoSolicitaPasajero() As DataTable
      Return New SqlServer.EstadosTurismo(Me.da).EstadosTurismo_GSolicitaPasajero()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.EstadosTurismo(Me.da).
                                       GetCodigoMaximo(Entidades.EstadoTurismo.Columnas.Posicion.ToString(),
                                                       "EstadosTurismo"))
   End Function

#End Region

End Class
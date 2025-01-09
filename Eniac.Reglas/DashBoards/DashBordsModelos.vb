#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class DashBordsModelos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.DashBoardModelo.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardModelo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardModelo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardModelo), TipoSP._D))
   End Sub
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.DashBoardModelos(Me.da).DashBoards_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.DashBoardModelo, tipo As TipoSP)
      Dim sqlC = New SqlServer.DashBoardModelos(da)
      Select Case tipo
         Case TipoSP._I
            'sqlC.DashBoards_I(en.IdTipoVehiculo,
            '                  en.NombreTipoVehiculo,
            '                  en.CapacidadMaxima)
         Case TipoSP._U
            'sqlC.DashBoards_U(en.IdTipoVehiculo,
            '                  en.NombreTipoVehiculo,
            '                  en.CapacidadMaxima)
         Case TipoSP._D
            'sqlC.DashBoards_D(en.IdTipoVehiculo)
      End Select
   End Sub
   ''' <summary>
   ''' Trae los Datos de un Modelo de DashBoard.- --
   ''' </summary>
   ''' <param name="idDashBoard">Id de Modelo</param>
   ''' <returns></returns>
   Public Function GetUno(idDashBoard As Integer) As Entidades.DashBoardModelo
      Return GetUno(idDashBoard, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idDashBoard As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.DashBoardModelo
      Return CargaEntidad(New SqlServer.DashBoardModelos(Me.da).DashBoard_G1(idDashBoard),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.DashBoardModelo(),
                          accion, Function() String.Format("No existe DashBoard con Id: {0}", idDashBoard))
   End Function
   Public Sub CargarUno(oDashBoard As Entidades.DashBoardModelo, dr As DataRow)
      '----------------------------------------------------
      With oDashBoard
         .IdModelo = dr.Field(Of Integer)("IdModelo")
         .Descripcion = dr.Field(Of String)("Descripcion")
         .Estados = dr.Field(Of Boolean)("Estados")
         .IdModeloDB = dr.Field(Of Integer)("IdModeloDB")
      End With
      '----------------------------------------------------
   End Sub

#End Region

End Class

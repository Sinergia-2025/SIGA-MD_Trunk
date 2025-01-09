#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class DashBordsTipos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.DashBoardTipo.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardTipo), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardTipo), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardTipo), TipoSP._D))
   End Sub
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.DashBoardTipos(Me.da).DashBoards_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.DashBoardTipo, tipo As TipoSP)
      Dim sqlC = New SqlServer.DashBoardTipos(da)
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

   Public Function GetUno(idDashBoard As Integer) As Entidades.DashBoardTipo
      Return GetUno(idDashBoard, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idDashBoard As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.DashBoardTipo
      Return CargaEntidad(New SqlServer.DashBoardTipos(Me.da).DashBoard_G1(idDashBoard),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.DashBoardTipo(),
                          accion, Function() String.Format("No existe DashBoard con Id: {0}", idDashBoard))
   End Function
   Public Sub CargarUno(oDashBoard As Entidades.DashBoardTipo, dr As DataRow)
      '----------------------------------------------------
      With oDashBoard
         .IdDashTipos = dr.Field(Of Integer)("IdDashTipos")
         .Descripcion = dr.Field(Of String)("Descripcion")
         .NombreObjeto = dr.Field(Of String)("NombreObjeto")
         .Estados = dr.Field(Of Boolean)("Estados")
         .LocationX = dr.Field(Of Integer)("LocationX")
         .LocationY = dr.Field(Of Integer)("LocationY")
      End With
      '----------------------------------------------------
   End Sub

#End Region

End Class

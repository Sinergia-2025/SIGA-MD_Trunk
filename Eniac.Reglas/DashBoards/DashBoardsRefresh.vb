#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class DashBoardsRefresh
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
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.DashBoardRefresh(Me.da).DashBoards_GA()
   End Function
#End Region

   Public Function GetUno(idDashBoard As Integer) As Entidades.DashBoardRefresh
      Return GetUno(idDashBoard, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idDashBoard As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.DashBoardRefresh
      Return CargaEntidad(New SqlServer.DashBoardRefresh(Me.da).DashBoard_G1(idDashBoard),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.DashBoardRefresh(),
                          accion, Function() String.Format("No existe DashBoard con Id: {0}", idDashBoard))
   End Function
   Public Sub CargarUno(oDashBoard As Entidades.DashBoardRefresh, dr As DataRow)
      '----------------------------------------------------
      With oDashBoard
         .IdDashRefresh = dr.Field(Of Integer)("IdDashRefresh")
         .Descripcion = dr.Field(Of String)("Descripcion")
      End With
      '----------------------------------------------------
   End Sub

End Class

#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class DashBoardTableros
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
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardTablero), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardTablero), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.DashBoardTablero), TipoSP._D))
   End Sub
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.DashBoardModelos(Me.da).DashBoards_GA()
   End Function
#End Region

#Region "Metodos Privados"
   ''' <summary>
   ''' Procedimiento para Ejecucion de SP.- --
   ''' </summary>
   ''' <param name="en">Entidad</param>
   ''' <param name="tipo">Tipo Operacion</param>
   Private Sub EjecutaSP(en As Entidades.DashBoardTablero, tipo As TipoSP)
      Dim sqlC = New SqlServer.DashBoardTableros(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.DashBordsTableros_I(en.IdTableros,
                                     en.Descripcion,
                                     en.Estados)
         Case TipoSP._U
            sqlC.DashBordsTableros_U(en.IdTableros,
                                     en.Descripcion,
                                     en.Estados)
         Case TipoSP._D
            sqlC.DashBordsTableros_D(en.IdTableros)
      End Select
   End Sub
   ''' <summary>
   ''' Carga los datos de un DashBoard.- --
   ''' </summary>
   ''' <param name="oDashBoard">Objeto DashBoard</param>
   ''' <param name="dr">Data Row</param>
   Public Sub CargarUno(oDashBoard As Entidades.DashBoardTablero, dr As DataRow)
      With oDashBoard
         .IdTableros = dr.Field(Of Integer)("idTableros")
         .Descripcion = dr.Field(Of String)("Descripcion")
         .Estados = dr.Field(Of Boolean)("Estados")
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Function GetUno(idDashBoard As Integer) As Entidades.DashBoardTablero
      Return GetUno(idDashBoard, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idDashBoard As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.DashBoardTablero
      Return CargaEntidad(New SqlServer.DashBoardTableros(Me.da).DashBoard_G1(idDashBoard),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.DashBoardTablero(),
                          accion, Function() String.Format("No existe DashBoardTablero con Id: {0}", idDashBoard))
   End Function

#End Region

End Class

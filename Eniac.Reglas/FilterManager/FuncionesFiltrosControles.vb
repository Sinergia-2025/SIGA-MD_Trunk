#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Public Class FuncionesFiltrosControles
      Inherits Eniac.Reglas.Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         Me.NombreEntidad = Entidades.FilterManager.FuncionFiltroControl.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroControl)))
      End Sub

      Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroControl)))
      End Sub

      Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroControl)))
      End Sub

      Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
         Dim sql As SqlServer.FilterManager.FuncionesFiltrosControles = New SqlServer.FilterManager.FuncionesFiltrosControles(Me.da)
         Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As System.Data.DataTable
         Return New SqlServer.FilterManager.FuncionesFiltrosControles(Me.da).FuncionesFiltrosControles_GA()
      End Function

      Public Overloads Function GetAll(idFuncion As String, idFiltro As Integer) As System.Data.DataTable
         Return New SqlServer.FilterManager.FuncionesFiltrosControles(Me.da).FuncionesFiltrosControles_GA(idFuncion, idFiltro)
      End Function
#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As Entidades.FilterManager.FuncionFiltroControl, tipo As TipoSP)
         Dim sqlC As SqlServer.FilterManager.FuncionesFiltrosControles = New SqlServer.FilterManager.FuncionesFiltrosControles(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.FuncionesFiltrosControles_I(en.IdFuncion, en.IdFiltro, en.NombreControl, en.ValorControl)
            Case TipoSP._U
               sqlC.FuncionesFiltrosControles_U(en.IdFuncion, en.IdFiltro, en.NombreControl, en.ValorControl)
            Case TipoSP._D
               sqlC.FuncionesFiltrosControles_D(en.IdFuncion, en.IdFiltro, en.NombreControl)
         End Select
      End Sub

      Private Sub CargarUno(o As Entidades.FilterManager.FuncionFiltroControl, dr As DataRow)
         With o
            .IdFuncion = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFuncion.ToString())
            .IdFiltro = dr.Field(Of Integer)(Entidades.FilterManager.FuncionFiltroControl.Columnas.IdFiltro.ToString())
            .NombreControl = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltroControl.Columnas.NombreControl.ToString())
            .ValorControl = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltroControl.Columnas.ValorControl.ToString())
         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As Entidades.FilterManager.FuncionFiltroControl)
         Me.EjecutaSP(entidad, TipoSP._I)
      End Sub
      Public Sub _Insertar(entidad As Entidades.FilterManager.FuncionFiltro)
         For Each en In entidad.Controles
            en.IdFuncion = entidad.IdFuncion
            en.IdFiltro = entidad.IdFiltro
            _Insertar(en)
         Next
      End Sub

      Public Sub _Actualizar(entidad As Entidades.FilterManager.FuncionFiltroControl)
         Me.EjecutaSP(entidad, TipoSP._U)
      End Sub

      Public Sub _Borrar(entidad As Entidades.FilterManager.FuncionFiltroControl)
         Me.EjecutaSP(entidad, TipoSP._D)
      End Sub
      Public Sub _Borrar(en As Entidades.FilterManager.FuncionFiltro)
         _Borrar(New Entidades.FilterManager.FuncionFiltroControl() With {.IdFuncion = en.IdFuncion, .IdFiltro = en.IdFiltro})
      End Sub

      Public Function GetUno(idFuncion As String, idFiltro As Integer, nombreControl As String) As Entidades.FilterManager.FuncionFiltroControl
         Return GetUno(idFuncion, idFiltro, nombreControl, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idFuncion As String, idFiltro As Integer, nombreControl As String, accion As AccionesSiNoExisteRegistro) As Entidades.FilterManager.FuncionFiltroControl
         Return CargaEntidad(New SqlServer.FilterManager.FuncionesFiltrosControles(Me.da).FuncionesFiltrosControles_G1(idFuncion, idFiltro, nombreControl),
                             Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FilterManager.FuncionFiltroControl(),
                             accion, Function() String.Format("No existe Filtro de Función con IdFunción: {0}, IdFiltro: {1} y NombreControl: {2}", idFuncion, idFiltro, nombreControl))
      End Function

      Public Function GetTodos(idFuncion As String, filtro As Integer) As List(Of Entidades.FilterManager.FuncionFiltroControl)
         Return CargaLista(Me.GetAll(idFuncion, filtro),
                           Sub(o, dr) CargarUno(DirectCast(o, Entidades.FilterManager.FuncionFiltroControl), dr),
                           Function() New Entidades.FilterManager.FuncionFiltroControl())
      End Function

#End Region
   End Class
End Namespace
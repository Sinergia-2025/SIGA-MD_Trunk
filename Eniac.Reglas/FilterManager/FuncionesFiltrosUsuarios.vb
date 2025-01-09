#Region "Option"
Option Strict On
Option Explicit On
#End Region
Namespace FilterManager
   Public Class FuncionesFiltrosUsuarios
      Inherits Eniac.Reglas.Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         Me.NombreEntidad = Entidades.FilterManager.FuncionFiltroUsuario.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroUsuario)))
      End Sub

      Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroUsuario)))
      End Sub

      Public Sub Merge(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroUsuario)))
      End Sub

      Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroUsuario)))
      End Sub

      Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
         Dim sql As SqlServer.FilterManager.FuncionesFiltrosUsuarios = New SqlServer.FilterManager.FuncionesFiltrosUsuarios(Me.da)
         Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As System.Data.DataTable
         Return New SqlServer.FilterManager.FuncionesFiltrosUsuarios(Me.da).FuncionesFiltrosUsuarios_GA()
      End Function

#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As Entidades.FilterManager.FuncionFiltroUsuario, tipo As TipoSP)
         Dim sqlC As SqlServer.FilterManager.FuncionesFiltrosUsuarios = New SqlServer.FilterManager.FuncionesFiltrosUsuarios(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.FuncionesFiltrosUsuarios_I(en.IdFuncion, en.Usuario, en.IdSucursal, en.IdFiltro)
            Case TipoSP._U
               sqlC.FuncionesFiltrosUsuarios_U(en.IdFuncion, en.Usuario, en.IdSucursal, en.IdFiltro)
            Case TipoSP._M
               sqlC.FuncionesFiltrosUsuarios_M(en.IdFuncion, en.Usuario, en.IdSucursal, en.IdFiltro)
            Case TipoSP._D
               sqlC.FuncionesFiltrosUsuarios_D(en.IdFuncion, en.Usuario, en.IdSucursal)
         End Select
      End Sub

      Private Sub CargarUno(o As Entidades.FilterManager.FuncionFiltroUsuario, dr As DataRow)
         With o
            .IdFuncion = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFuncion.ToString())
            .Usuario = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdUsuario.ToString())
            .IdSucursal = dr.Field(Of Integer)(Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdSucursal.ToString())
            .IdFiltro = dr.Field(Of Integer)(Entidades.FilterManager.FuncionFiltroUsuario.Columnas.IdFiltro.ToString())
         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As Entidades.FilterManager.FuncionFiltroUsuario)
         Me.EjecutaSP(entidad, TipoSP._I)
      End Sub

      Public Sub _Actualizar(entidad As Entidades.FilterManager.FuncionFiltroUsuario)
         Me.EjecutaSP(entidad, TipoSP._U)
      End Sub

      Public Sub _Merge(entidad As Entidades.FilterManager.FuncionFiltroUsuario)
         Me.EjecutaSP(entidad, TipoSP._M)
      End Sub

      Public Sub _Borrar(entidad As Entidades.FilterManager.FuncionFiltroUsuario)
         Me.EjecutaSP(entidad, TipoSP._D)
      End Sub

      Public Sub _Borrar(en As Entidades.FilterManager.FuncionFiltro)
         _Borrar(New Entidades.FilterManager.FuncionFiltroUsuario() With {.IdFuncion = en.IdFuncion, .IdFiltro = en.IdFiltro})
      End Sub

      Public Function GetUno(idFuncion As String, idUsuario As String, idSucursal As Integer) As Entidades.FilterManager.FuncionFiltroUsuario
         Return GetUno(idFuncion, idUsuario, idSucursal, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idFuncion As String, idUsuario As String, idSucursal As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.FilterManager.FuncionFiltroUsuario
         Return CargaEntidad(New SqlServer.FilterManager.FuncionesFiltrosUsuarios(Me.da).FuncionesFiltrosUsuarios_G1(idFuncion, idUsuario, idSucursal),
                             Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FilterManager.FuncionFiltroUsuario(),
                             accion, Function() String.Format("No existe Filtro de Función por defecto para IdFunción: {0}, IdUsuario: {1} y IdSucursal: {2}", idFuncion, idUsuario, idSucursal))
      End Function

      Public Function GetTodos() As List(Of Entidades.FilterManager.FuncionFiltroUsuario)
         Return CargaLista(Me.GetAll(),
                           Sub(o, dr) CargarUno(DirectCast(o, Entidades.FilterManager.FuncionFiltroUsuario), dr),
                           Function() New Entidades.FilterManager.FuncionFiltroUsuario())
      End Function

#End Region
   End Class
End Namespace
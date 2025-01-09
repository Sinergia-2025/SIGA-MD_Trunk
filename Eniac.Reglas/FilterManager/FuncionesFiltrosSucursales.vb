#Region "Option"
Option Strict On
Option Explicit On
#End Region
Namespace FilterManager
   Public Class FuncionesFiltrosSucursales
      Inherits Eniac.Reglas.Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         Me.NombreEntidad = Entidades.FilterManager.FuncionFiltroSucursal.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroSucursal)))
      End Sub

      Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroSucursal)))
      End Sub

      Public Sub Merge(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Merge(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroSucursal)))
      End Sub

      Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltroSucursal)))
      End Sub

      Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
         Dim sql As SqlServer.FilterManager.FuncionesFiltrosSucursales = New SqlServer.FilterManager.FuncionesFiltrosSucursales(Me.da)
         Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As System.Data.DataTable
         Return New SqlServer.FilterManager.FuncionesFiltrosSucursales(Me.da).FuncionesFiltrosSucursales_GA()
      End Function

#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As Entidades.FilterManager.FuncionFiltroSucursal, tipo As TipoSP)
         Dim sqlC As SqlServer.FilterManager.FuncionesFiltrosSucursales = New SqlServer.FilterManager.FuncionesFiltrosSucursales(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.FuncionesFiltrosSucursales_I(en.IdFuncion, en.IdSucursal, en.IdFiltro)
            Case TipoSP._U
               sqlC.FuncionesFiltrosSucursales_U(en.IdFuncion, en.IdSucursal, en.IdFiltro)
            Case TipoSP._M
               sqlC.FuncionesFiltrosSucursales_M(en.IdFuncion, en.IdSucursal, en.IdFiltro)
            Case TipoSP._D
               sqlC.FuncionesFiltrosSucursales_D(en.IdFuncion, en.IdSucursal)
         End Select
      End Sub

      Private Sub CargarUno(o As Entidades.FilterManager.FuncionFiltroSucursal, dr As DataRow)
         With o
            .IdFuncion = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFuncion.ToString())
            .IdSucursal = dr.Field(Of Integer)(Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdSucursal.ToString())
            .IdFiltro = dr.Field(Of Integer)(Entidades.FilterManager.FuncionFiltroSucursal.Columnas.IdFiltro.ToString())
         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As Entidades.FilterManager.FuncionFiltroSucursal)
         Me.EjecutaSP(entidad, TipoSP._I)
      End Sub

      Public Sub _Actualizar(entidad As Entidades.FilterManager.FuncionFiltroSucursal)
         Me.EjecutaSP(entidad, TipoSP._U)
      End Sub

      Public Sub _Merge(entidad As Entidades.FilterManager.FuncionFiltroSucursal)
         Me.EjecutaSP(entidad, TipoSP._M)
      End Sub

      Public Sub _Borrar(entidad As Entidades.FilterManager.FuncionFiltroSucursal)
         Me.EjecutaSP(entidad, TipoSP._D)
      End Sub

      Public Sub _Borrar(en As Entidades.FilterManager.FuncionFiltro)
         _Borrar(New Entidades.FilterManager.FuncionFiltroSucursal() With {.IdFuncion = en.IdFuncion, .IdFiltro = en.IdFiltro})
      End Sub

      Public Function GetUno(idFuncion As String, idSucursal As Integer) As Entidades.FilterManager.FuncionFiltroSucursal
         Return GetUno(idFuncion, idSucursal, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idFuncion As String, idSucursal As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.FilterManager.FuncionFiltroSucursal
         Return CargaEntidad(New SqlServer.FilterManager.FuncionesFiltrosSucursales(Me.da).FuncionesFiltrosSucursales_G1(idFuncion, idSucursal),
                             Sub(o, dr) CargarUno(o, dr), Function() New Entidades.FilterManager.FuncionFiltroSucursal(),
                             accion, Function() String.Format("No existe Filtro de Función por defecto para IdFunción: {0} y IdSucursal: {1}", idFuncion, idSucursal))
      End Function

      Public Function GetTodos() As List(Of Entidades.FilterManager.FuncionFiltroSucursal)
         Return CargaLista(Me.GetAll(),
                           Sub(o, dr) CargarUno(DirectCast(o, Entidades.FilterManager.FuncionFiltroSucursal), dr),
                           Function() New Entidades.FilterManager.FuncionFiltroSucursal())
      End Function

#End Region
   End Class
End Namespace
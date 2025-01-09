#Region "Option"
Option Strict On
Option Explicit On
Option Infer On
#End Region
Namespace FilterManager
   Public Class FuncionesFiltros
      Inherits Eniac.Reglas.Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         Me.NombreEntidad = Entidades.FilterManager.FuncionFiltro.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltro)))
      End Sub

      Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltro)))
      End Sub

      Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.FilterManager.FuncionFiltro)))
      End Sub

      Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
         Dim sql As SqlServer.FilterManager.FuncionesFiltros = New SqlServer.FilterManager.FuncionesFiltros(Me.da)
         Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As System.Data.DataTable
         Return New SqlServer.FilterManager.FuncionesFiltros(Me.da).FuncionesFiltros_GA()
      End Function

      Public Overloads Function GetAll(idFuncion As String) As System.Data.DataTable
         If String.IsNullOrWhiteSpace(idFuncion) Then
            Return GetAll()
         Else
            Return GetAll(idFuncion, nullOrIdSucursal:=actual.Sucursal.Id, nullOrIdUsuario:=actual.Nombre)
         End If
      End Function
      Public Overloads Function GetAll(idFuncion As String, nullOrIdSucursal As Integer, nullOrIdUsuario As String) As System.Data.DataTable
         Return New SqlServer.FilterManager.FuncionesFiltros(Me.da).FuncionesFiltros_GA(idFuncion, nullOrIdSucursal, nullOrIdUsuario)
      End Function
#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As Entidades.FilterManager.FuncionFiltro, tipo As TipoSP)
         Dim sqlC As SqlServer.FilterManager.FuncionesFiltros = New SqlServer.FilterManager.FuncionesFiltros(da)
         Dim rControl = New FuncionesFiltrosControles(da)
         Dim rUsuario = New FuncionesFiltrosUsuarios(da)
         Dim rSucursal = New FuncionesFiltrosSucursales(da)
         Select Case tipo
            Case TipoSP._I
               If en.IdFiltro = 0 Then en.IdFiltro = GetCodigoMaximo(en.IdFuncion) + 1
               sqlC.FuncionesFiltros_I(en.IdFuncion, en.IdFiltro, en.IdSucursal, en.Usuario, en.NombreFiltro)
               rControl._Insertar(en)
            Case TipoSP._U
               sqlC.FuncionesFiltros_U(en.IdFuncion, en.IdFiltro, en.IdSucursal, en.Usuario, en.NombreFiltro)
               rControl._Borrar(en)
               rControl._Insertar(en)
            Case TipoSP._D
               rUsuario._Borrar(en)
               rSucursal._Borrar(en)
               rControl._Borrar(en)
               sqlC.FuncionesFiltros_D(en.IdFuncion, en.IdFiltro)
         End Select
      End Sub

      Private Sub CargarUno(o As Entidades.FilterManager.FuncionFiltro, dr As DataRow, porDefectoCallback As Func(Of String, Integer, Boolean))
         With o
            .IdFuncion = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltro.Columnas.IdFuncion.ToString())
            .IdFiltro = dr.Field(Of Integer)(Entidades.FilterManager.FuncionFiltro.Columnas.IdFiltro.ToString())
            Dim v As Integer? = dr.Field(Of Integer?)(Entidades.FilterManager.FuncionFiltro.Columnas.IdSucursal.ToString())
            .IdSucursal = If(v.HasValue, v.Value, 0)
            .Usuario = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltro.Columnas.IdUsuario.ToString())
            .NombreFiltro = dr.Field(Of String)(Entidades.FilterManager.FuncionFiltro.Columnas.NombreFiltro.ToString())

            .PorDefecto = porDefectoCallback(.IdFuncion, .IdFiltro)

            .Controles = New FuncionesFiltrosControles(da).GetTodos(.IdFuncion, .IdFiltro)
         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As Entidades.FilterManager.FuncionFiltro)
         Me.EjecutaSP(entidad, TipoSP._I)
      End Sub

      Public Sub _Actualizar(entidad As Entidades.FilterManager.FuncionFiltro)
         Me.EjecutaSP(entidad, TipoSP._U)
      End Sub

      Public Sub _Borrar(entidad As Entidades.FilterManager.FuncionFiltro)
         Me.EjecutaSP(entidad, TipoSP._D)
      End Sub

      Public Function GetUno(idFuncion As String, idFiltro As Integer) As Entidades.FilterManager.FuncionFiltro
         Return GetUno(idFuncion, idFiltro, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idFuncion As String, idFiltro As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.FilterManager.FuncionFiltro
         Dim def As Entidades.FilterManager.FuncionFiltro = GetDefault(idFuncion)
         Return CargaEntidad(New SqlServer.FilterManager.FuncionesFiltros(Me.da).FuncionesFiltros_G1(idFuncion, idFiltro),
                             Sub(o, dr) CargarUno(o, dr, Function(u, i) def IsNot Nothing AndAlso def.IdFuncion = u AndAlso def.IdFiltro = i),
                             Function() New Entidades.FilterManager.FuncionFiltro(),
                             accion, Function() String.Format("No existe Filtro de Función con IdFunción: {0} y IdFiltro: {1}", idFuncion, idFiltro))
      End Function

      Public Function GetDefault(idFuncion As String) As Entidades.FilterManager.FuncionFiltro
         Return GetDefault(idFuncion, AccionesSiNoExisteRegistro.Nulo)
      End Function
      Public Function GetDefault(idFuncion As String, accion As AccionesSiNoExisteRegistro) As Entidades.FilterManager.FuncionFiltro
         Dim sql As New SqlServer.FilterManager.FuncionesFiltros(Me.da)
         Dim dt As DataTable = sql.FuncionesFiltros_G_Default(idFuncion, actual.Sucursal.Id, actual.Nombre)
         If dt.Rows.Count = 0 Then
            dt = sql.FuncionesFiltros_G_Default(idFuncion, actual.Sucursal.Id, idUsuario:=String.Empty)  'Si no encuentro para el usuario busco el general para toda la sucursal
         End If

         Return CargaEntidad(dt,
                             Sub(o, dr) CargarUno(o, dr, Function(u, i) True), Function() New Entidades.FilterManager.FuncionFiltro(),
                             accion, Function() String.Format("No existe Filtro por defecto para la Función con IdFunción: {0}", idFuncion))
      End Function

      Public Function GetTodos(idFuncion As String) As List(Of Entidades.FilterManager.FuncionFiltro)
         Return GetTodos(idFuncion, actual.Sucursal.Id, actual.Nombre)
      End Function
      Public Function GetTodos(idFuncion As String, nullOrIdSucursal As Integer, nullOrIdUsuario As String) As List(Of Entidades.FilterManager.FuncionFiltro)
         Dim def As Entidades.FilterManager.FuncionFiltro = GetDefault(idFuncion)
         Return CargaLista(Me.GetAll(idFuncion, nullOrIdSucursal, nullOrIdUsuario),
                           Sub(o, dr) CargarUno(DirectCast(o, Entidades.FilterManager.FuncionFiltro), dr, Function(u, i) def IsNot Nothing AndAlso def.IdFuncion = u AndAlso def.IdFiltro = i),
                           Function() New Entidades.FilterManager.FuncionFiltro())
      End Function

      Public Sub EliminarDefaultUsuario(dr As Entidades.FilterManager.FuncionFiltro)
         EjecutaConTransaccion(Sub()
                                  Dim r As New FuncionesFiltrosUsuarios(da)
                                  r._Borrar(New Entidades.FilterManager.FuncionFiltroUsuario() With {.IdFuncion = dr.IdFuncion,
                                                                                                     .IdSucursal = actual.Sucursal.Id,
                                                                                                     .Usuario = actual.Nombre})
                               End Sub)
      End Sub
      Public Sub CambiarDefaultSoloUsuario(dr As Entidades.FilterManager.FuncionFiltro)
         EjecutaConTransaccion(Sub()
                                  Dim r As New FuncionesFiltrosUsuarios(da)
                                  r._Merge(New Entidades.FilterManager.FuncionFiltroUsuario() With {.IdFuncion = dr.IdFuncion,
                                                                                                    .Usuario = actual.Nombre,
                                                                                                    .IdSucursal = actual.Sucursal.Id,
                                                                                                    .IdFiltro = dr.IdFiltro})
                               End Sub)
      End Sub
      Public Sub CambiarDefaultTodosLosUsuario(dr As Entidades.FilterManager.FuncionFiltro)
         EjecutaConTransaccion(Sub()
                                  Dim r As New FuncionesFiltrosUsuarios(da)
                                  r._Borrar(New Entidades.FilterManager.FuncionFiltroUsuario() With {.IdFuncion = dr.IdFuncion,
                                                                                                     .IdSucursal = actual.Sucursal.Id})
                                  Dim s As New FuncionesFiltrosSucursales(da)
                                  s._Merge(New Entidades.FilterManager.FuncionFiltroSucursal() With {.IdFuncion = dr.IdFuncion,
                                                                                                     .IdSucursal = actual.Sucursal.Id,
                                                                                                     .IdFiltro = dr.IdFiltro})
                               End Sub)
      End Sub

      Public Function GetCodigoMaximo(idFuncion As String) As Integer
         Return New SqlServer.FilterManager.FuncionesFiltros(Me.da).GetCodigoMaximo(idFuncion)
      End Function

#End Region

   End Class
End Namespace
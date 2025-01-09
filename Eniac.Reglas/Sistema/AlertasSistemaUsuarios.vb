Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaUsuarios
      Inherits Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         NombreEntidad = AlertaSistemaUsuario.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, AlertaSistemaUsuario)))
      End Sub
      Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, AlertaSistemaUsuario)))
      End Sub
      Public Overrides Sub Borrar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, AlertaSistemaUsuario)))
      End Sub

      Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaUsuarios(da).Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As DataTable
         Return New SqlServer.Sistema.AlertasSistemaUsuarios(da).AlertasSistemaUsuarios_GA()
      End Function
      Public Overloads Function GetAll(idAlertaSistema As Integer) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaUsuarios(da).AlertasSistemaUsuarios_GA(idAlertaSistema)
      End Function
#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As AlertaSistemaUsuario, tipo As TipoSP)
         Dim sqlC = New SqlServer.Sistema.AlertasSistemaUsuarios(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AlertasSistemaUsuarios_I(en.IdAlertaSistema, en.IdUsuario)
            Case TipoSP._U
               sqlC.AlertasSistemaUsuarios_U(en.IdAlertaSistema, en.IdUsuario)
            Case TipoSP._D
               sqlC.AlertasSistemaUsuarios_D(en.IdAlertaSistema, en.IdUsuario)
         End Select
      End Sub

      Private Sub CargarUno(o As AlertaSistemaUsuario, dr As DataRow)
         With o
            .IdAlertaSistema = dr.Field(Of Integer)(AlertaSistemaUsuario.Columnas.IdAlertaSistema.ToString())
            .IdUsuario = dr.Field(Of String)(AlertaSistemaUsuario.Columnas.IdUsuario.ToString())
            .NombreUsuario = dr.Field(Of String)("NombreUsuario")
         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As AlertaSistemaUsuario)
         EjecutaSP(entidad, TipoSP._I)
      End Sub
      Public Sub _Actualizar(entidad As AlertaSistemaUsuario)
         EjecutaSP(entidad, TipoSP._U)
      End Sub
      Public Sub _Borrar(entidad As AlertaSistemaUsuario)
         EjecutaSP(entidad, TipoSP._D)
      End Sub
      Public Sub _Insertar(entidad As AlertaSistema)
         entidad.Usuarios.ForEach(
            Sub(c)
               c.IdAlertaSistema = entidad.IdAlertaSistema
               _Insertar(c)
            End Sub)
      End Sub
      Public Sub _Actualizar(entidad As AlertaSistema)
         _Borrar(entidad)
         _Insertar(entidad)
      End Sub
      Public Sub _Borrar(entidad As AlertaSistema)
         _Borrar(New AlertaSistemaUsuario() With {.IdAlertaSistema = entidad.IdAlertaSistema})
      End Sub

      Public Function GetUno(idAlertaSistema As Integer, IdUsuario As String) As AlertaSistemaUsuario
         Return GetUno(idAlertaSistema, IdUsuario, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idAlertaSistema As Integer, IdUsuario As String, accion As AccionesSiNoExisteRegistro) As AlertaSistemaUsuario
         Return CargaEntidad(New SqlServer.Sistema.AlertasSistemaUsuarios(da).AlertasSistemaUsuarios_G1(idAlertaSistema, IdUsuario),
                             Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaUsuario(),
                             accion, Function() String.Format("No existe Alerta con Id: {0} y Usuario: {1}", idAlertaSistema, IdUsuario))
      End Function
      Public Function GetTodos(idAlertaSistema As Integer) As List(Of AlertaSistemaUsuario)
         Return CargaLista(GetAll(idAlertaSistema),
                           Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaUsuario())
      End Function

#End Region

   End Class
End Namespace
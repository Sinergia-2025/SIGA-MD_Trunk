Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaRoles
      Inherits Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         NombreEntidad = AlertaSistemaRol.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, AlertaSistemaRol)))
      End Sub
      Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, AlertaSistemaRol)))
      End Sub
      Public Overrides Sub Borrar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, AlertaSistemaRol)))
      End Sub

      Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaRoles(da).Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As DataTable
         Return New SqlServer.Sistema.AlertasSistemaRoles(da).AlertasSistemaRoles_GA()
      End Function
      Public Overloads Function GetAll(idAlertaSistema As Integer) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaRoles(da).AlertasSistemaRoles_GA(idAlertaSistema)
      End Function
#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As AlertaSistemaRol, tipo As TipoSP)
         Dim sqlC = New SqlServer.Sistema.AlertasSistemaRoles(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AlertasSistemaRoles_I(en.IdAlertaSistema, en.IdRol)
            Case TipoSP._U
               sqlC.AlertasSistemaRoles_U(en.IdAlertaSistema, en.IdRol)
            Case TipoSP._D
               sqlC.AlertasSistemaRoles_D(en.IdAlertaSistema, en.IdRol)
         End Select
      End Sub

      Private Sub CargarUno(o As AlertaSistemaRol, dr As DataRow)
         With o
            .IdAlertaSistema = dr.Field(Of Integer)(AlertaSistemaRol.Columnas.IdAlertaSistema.ToString())
            .IdRol = dr.Field(Of String)(AlertaSistemaRol.Columnas.IdRol.ToString())
            .NombreRol = dr.Field(Of String)("NombreRol")
         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As AlertaSistemaRol)
         EjecutaSP(entidad, TipoSP._I)
      End Sub
      Public Sub _Actualizar(entidad As AlertaSistemaRol)
         EjecutaSP(entidad, TipoSP._U)
      End Sub
      Public Sub _Borrar(entidad As AlertaSistemaRol)
         EjecutaSP(entidad, TipoSP._D)
      End Sub
      Public Sub _Insertar(entidad As AlertaSistema)
         entidad.Roles.ForEach(
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
         _Borrar(New AlertaSistemaRol() With {.IdAlertaSistema = entidad.IdAlertaSistema})
      End Sub

      Public Function GetUno(idAlertaSistema As Integer, IdRol As String) As AlertaSistemaRol
         Return GetUno(idAlertaSistema, IdRol, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idAlertaSistema As Integer, IdRol As String, accion As AccionesSiNoExisteRegistro) As AlertaSistemaRol
         Return CargaEntidad(New SqlServer.Sistema.AlertasSistemaRoles(da).AlertasSistemaRoles_G1(idAlertaSistema, IdRol),
                             Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaRol(),
                             accion, Function() String.Format("No existe Alerta con Id: {0} y Rol: {1}", idAlertaSistema, IdRol))
      End Function
      Public Function GetTodos(idAlertaSistema As Integer) As List(Of AlertaSistemaRol)
         Return CargaLista(GetAll(idAlertaSistema),
                           Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaRol())
      End Function

#End Region

   End Class
End Namespace
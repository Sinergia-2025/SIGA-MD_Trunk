Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistemaPermisos
      Inherits Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         NombreEntidad = AlertaSistemaPermiso.NombreTabla
         da = accesoDatos
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, AlertaSistemaPermiso)))
      End Sub
      Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, AlertaSistemaPermiso)))
      End Sub
      Public Overrides Sub Borrar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, AlertaSistemaPermiso)))
      End Sub

      Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaPermisos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As DataTable
         Return New SqlServer.Sistema.AlertasSistemaPermisos(da).AlertasSistemaPermisos_GA()
      End Function
      Public Overloads Function GetAll(idAlertaSistema As Integer) As DataTable
         Return New SqlServer.Sistema.AlertasSistemaPermisos(da).AlertasSistemaPermisos_GA(idAlertaSistema)
      End Function
#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As AlertaSistemaPermiso, tipo As TipoSP)
         Dim sqlC = New SqlServer.Sistema.AlertasSistemaPermisos(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.AlertasSistemaPermisos_I(en.IdAlertaSistema, en.IdFuncion)
            Case TipoSP._U
               sqlC.AlertasSistemaPermisos_U(en.IdAlertaSistema, en.IdFuncion)
            Case TipoSP._D
               sqlC.AlertasSistemaPermisos_D(en.IdAlertaSistema, en.IdFuncion)
         End Select
      End Sub

      Private Sub CargarUno(o As AlertaSistemaPermiso, dr As DataRow)
         With o
            .IdAlertaSistema = dr.Field(Of Integer)(AlertaSistemaPermiso.Columnas.IdAlertaSistema.ToString())
            .IdFuncion = dr.Field(Of String)(AlertaSistemaPermiso.Columnas.IdFuncion.ToString())
            .NombreFuncion = dr.Field(Of String)("NombreFuncion")

            .IdFuncionPadre = dr.Field(Of String)("IdFuncionPadre")
            .NombreFuncionPadre = dr.Field(Of String)("NombreFuncionPadre")
            .Posicion = dr.Field(Of Integer)("Posicion")

            .Pantalla = dr.Field(Of String)("Pantalla")
            .Archivo = dr.Field(Of String)("Archivo")

         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As AlertaSistemaPermiso)
         EjecutaSP(entidad, TipoSP._I)
      End Sub
      Public Sub _Actualizar(entidad As AlertaSistemaPermiso)
         EjecutaSP(entidad, TipoSP._U)
      End Sub
      Public Sub _Borrar(entidad As AlertaSistemaPermiso)
         EjecutaSP(entidad, TipoSP._D)
      End Sub
      Public Sub _Insertar(entidad As AlertaSistema)
         entidad.Permisos.ForEach(
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
         _Borrar(New AlertaSistemaPermiso() With {.IdAlertaSistema = entidad.IdAlertaSistema})
      End Sub

      Public Function GetUno(idAlertaSistema As Integer, idFuncion As String) As AlertaSistemaPermiso
         Return GetUno(idAlertaSistema, idFuncion, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idAlertaSistema As Integer, idFuncion As String, accion As AccionesSiNoExisteRegistro) As AlertaSistemaPermiso
         Return CargaEntidad(New SqlServer.Sistema.AlertasSistemaPermisos(da).AlertasSistemaPermisos_G1(idAlertaSistema, idFuncion),
                             Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaPermiso(),
                             accion, Function() String.Format("No existe Alerta con Id: {0} y Función: {1}", idAlertaSistema, idFuncion))
      End Function
      Public Function GetTodos(idAlertaSistema As Integer) As List(Of AlertaSistemaPermiso)
         Return CargaLista(GetAll(idAlertaSistema),
                           Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistemaPermiso())
      End Function

#End Region

   End Class
End Namespace
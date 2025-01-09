Namespace SistemaE
   Public Class AlertaSistema
      Inherits Entidad

      Public Const NombreTabla As String = "AlertasSistema"
      Public Enum Columnas
         IdAlertaSistema
         TituloAlerta
         ConsultaAlerta
         PermisosCondicion
         IdFuncionClick
         ParametrosPantalla
         UtilizaConsultaGenerica

      End Enum

      Public Property IdAlertaSistema As Integer
      Public Property TituloAlerta As String
      Public Property ConsultaAlerta As String
      Public Property PermisosCondicion As CondicionesPermisoAlerta
      Public Property IdFuncionClick As String
      Public Property ParametrosPantalla As String
      Public Property UtilizaConsultaGenerica As Boolean

      Public Property Condiciones As New List(Of AlertaSistemaCondicion)()
      Public Property Permisos As New List(Of AlertaSistemaPermiso)()
      Public Property Roles As New List(Of AlertaSistemaRol)()
      Public Property Usuarios As New List(Of AlertaSistemaUsuario)()

      Public Function EvaluaPermisos(action As Func(Of String, Boolean)) As Boolean
         Dim result = True
         If Permisos.Any() Then
            If PermisosCondicion = Entidades.SistemaE.CondicionesPermisoAlerta.AND Then
               result = Permisos.All(Function(p) action(p.IdFuncion))
            ElseIf PermisosCondicion = Entidades.SistemaE.CondicionesPermisoAlerta.OR Then
               result = Not Permisos.All(Function(p) action(p.IdFuncion))
            End If
         End If
         Return result
      End Function
   End Class

   Public Enum CondicionesPermisoAlerta
      <Description("Todos los permisos")> [AND]
      <Description("Alguno de los permisos")> [OR]
   End Enum

End Namespace
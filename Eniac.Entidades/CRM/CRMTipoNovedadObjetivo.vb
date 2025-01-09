Public Class CRMTipoNovedadObjetivo
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "CRMTiposNovedadesObjetivos"

   Public Enum Columnas
      IdTipoNovedad
      PeriodoObjetivo
      IdUsuarioActualizacion
      FechaActualizacion

   End Enum

   Public Sub New()
      Usuarios = New List(Of CRMTipoNovedadObjetivoUsuario)()
   End Sub

   Public Property IdTipoNovedad As String
   Public Property PeriodoObjetivo As DateTime
   Public Property IdUsuarioActualizacion As String
   Public Property FechaActualizacion As DateTime

   Public Property Usuarios As ICollection(Of CRMTipoNovedadObjetivoUsuario)

End Class
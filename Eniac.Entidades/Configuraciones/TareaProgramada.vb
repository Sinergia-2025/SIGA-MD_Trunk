Public Class TareaProgramada
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "TareasProgramadas"
   Public Enum Columnas
      IdTareaProgramada
      IdFuncion
      Usuario
      Observacion
      UltimaFechaEjecucion
   End Enum

   Public Sub New()
      Horarios = New List(Of TareaProgramadaHorario)()
   End Sub

#Region "Propiedades"
   Public Property IdTareaProgramada As Integer
   Public Property IdFuncion As String
   'Public Property Usuario As Date?
   Public Property Observacion As String
   Public Property UltimaFechaEjecucion As Date?

   Public Property Horarios As List(Of TareaProgramadaHorario)

#End Region
End Class
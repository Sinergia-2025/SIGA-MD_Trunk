<Serializable()>
Public Class Traduccion
   Inherits Eniac.Entidades.Entidad
   Public Enum Idiomas
      es_AR
   End Enum

   Public Enum Columnas
      IdFuncion
      Pantalla
      Control
      IdIdioma
      Texto
   End Enum

#Region "Propiedades"
   Public Property IdFuncion As String
   Public Property Pantalla As String
   Public Property Control As String
   Public Property IdIdioma As String
   Public Property Texto As String
#End Region

End Class
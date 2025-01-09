Public Class Feriado
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      FechaFeriado
      NombreFeriado
   End Enum

   Public Sub New()
   End Sub
   Public Sub New(fechaFeriado As Date)
      Me.New()
      Me.FechaFeriado = fechaFeriado
   End Sub

   Public Property FechaFeriado As Date
   Public Property NombreFeriado As String
End Class

Public Class DiasHabiles
   Public Property Lunes As Integer
   Public Property Martes As Integer
   Public Property Miercoles As Integer
   Public Property Jueves As Integer
   Public Property Viernes As Integer
   Public Property Sabados As Integer
   Public Property Domingos As Integer
   Public Property Feriados As Integer

   Public ReadOnly Property Habiles As Integer
      Get
         Return Lunes + Martes + Miercoles + Jueves + Viernes
      End Get
   End Property

End Class

Public Class CalendarioExcepcion
   Inherits Eniac.Entidades.Entidad
   Public Enum Columnas
      IdCalendario
      IdDiaSemana
      IdExcepcion
      FechaExcepcion
   End Enum

   Public Property IdCalendario As Integer
   Private _idDiaSemana As System.DayOfWeek
   Public Property IdDiaSemana As System.DayOfWeek
      Get
         Return _idDiaSemana
      End Get
      Set(value As System.DayOfWeek)
         _idDiaSemana = value
         _nombreDiaSemana = value.NombreDiaSemana()
      End Set
   End Property
   Public Property IdExcepcion As Integer
   Public Property FechaExcepcion As Date

   Private _nombreDiaSemana As String
   Public Property NombreDiaSemana() As String
      Get
         If String.IsNullOrWhiteSpace(_nombreDiaSemana) Then
            _nombreDiaSemana = IdDiaSemana.NombreDiaSemana()
         End If
         Return _nombreDiaSemana
      End Get
      Set(ByVal value As String)
         _nombreDiaSemana = value
      End Set
   End Property
End Class
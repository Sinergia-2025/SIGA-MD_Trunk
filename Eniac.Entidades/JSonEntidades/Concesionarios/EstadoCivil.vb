Namespace JSonEntidades.Concesionarios.Alcorta
   Public Class EstadoCivil
      Public Const NombreTabla As String = "EstadosCiviles"

      Public Enum Campos
         IdEstadoCivil
         NombreEstadoCivil
      End Enum

#Region "Propiedades"
      Public Property IdEstadoCivil() As Integer
      Public Property NombreEstadoCivil() As String
#End Region
   End Class
   Public Class EstadoCivilResponse
      Public Enum Campos
         sync
      End Enum
      Public Property sync As Boolean
   End Class
End Namespace

Namespace JSonEntidades.Concesionarios.Alcorta
   Public Class Banco
      Public Enum Campos
         IdBanco
         NombreBanco
         DebitoDirecto
         Convenio
         Servicio
         IdEmpresa
      End Enum

      Public Property IdBanco As Integer
      Public Property NombreBanco As String
      Public Property DebitoDirecto As Boolean
      Public Property Convenio As Integer
      Public Property Servicio As String
      Public Property IdEmpresa() As Integer
   End Class

   Public Class BancoResponse
      Public Enum Campos
         sync
      End Enum
      Public Property sync As Boolean
   End Class

End Namespace

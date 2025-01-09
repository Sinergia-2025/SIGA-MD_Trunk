<Serializable()>
Public Class ParametroArchivo
   Inherits Eniac.Entidades.Entidad

   Public Enum Parametros
      TICKETACCESOFEX
      TICKETACCESOFE
      TICKETACCESOBFE
      TICKETACCESOPN4
      CERTIFICADOFE
   End Enum

#Region "Propiedades"
   Public Property IdEmpresa As Integer
   Public Property IdParametroArchivo() As String
   Public Property ValorParametroArchivo() As String

#End Region

End Class
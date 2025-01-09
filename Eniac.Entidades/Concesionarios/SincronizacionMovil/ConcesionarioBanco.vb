<Serializable()>
Public Class ConcesionarioBanco

   Public Const NombreTabla As String = "Bancos"

#Region "Propiedades"
   Public Property IdBanco() As Integer
   Public Property NombreBanco() As String
   Public Property DebitoDirecto() As Boolean
   Public Property Convenio() As Integer
   Public Property Servicio() As String
   Public Property IdEmpresa() As Integer
#End Region

End Class

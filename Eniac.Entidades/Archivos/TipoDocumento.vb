<Serializable()>
<Description("TiposDocumento")>
Public Class TipoDocumento
   Inherits Eniac.Entidades.Entidad

   Public Enum TiposDocumentos
      CUIT
      CUIL
      DNI
   End Enum

#Region "Campos"

   Private _tipoDocumento As String = ""
   Private _nombreTipoDocumento As String = ""
   Private _esAutoincremental As Boolean = False

#End Region

#Region "Propiedades"

   <System.ComponentModel.Description("TipoDocumento")> _
   Public Property TipoDocumento() As String
      Get
         Return Me._tipoDocumento
      End Get
      Set(ByVal value As String)
         Me._tipoDocumento = value
      End Set
   End Property
   Public Property NombreTipoDocumento() As String
      Get
         Return Me._nombreTipoDocumento
      End Get
      Set(ByVal value As String)
         Me._nombreTipoDocumento = value
      End Set
   End Property
   Public Property EsAutoincremental() As Boolean
      Get
         Return Me._esAutoincremental
      End Get
      Set(ByVal value As Boolean)
         Me._esAutoincremental = value
      End Set
   End Property

#End Region

End Class
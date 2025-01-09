<Serializable()> _
Public Class ProductoWeb
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      Caracteristica1
      ValorCaracteristica1
      Caracteristica2
      ValorCaracteristica2
      Caracteristica3
      ValorCaracteristica3
      Foto2
      Foto3
      FechaActualizacionWeb
      EsParaConstructora
      EsParaIndustria
      EsParaCooperativaElectrica
      EsParaMayorista
      EsParaMinorista
   End Enum


#Region "Propiedades"


   Public Property IdProducto As String
   Public Property Caracteristica1 As String
   Public Property ValorCaracteristica1 As String
   Public Property Caracteristica2 As String
   Public Property ValorCaracteristica2 As String
   Public Property Caracteristica3 As String
   Public Property ValorCaracteristica3 As String
   Public Property Foto2 As System.Drawing.Image
   Public Property Foto3 As System.Drawing.Image
   Public Property EsParaConstructora As Boolean
   Public Property EsParaIndustria As Boolean
   Public Property EsParaCooperativaElectrica As Boolean
   Public Property EsParaMayorista As Boolean
   Public Property EsParaMinorista As Boolean

#End Region


End Class
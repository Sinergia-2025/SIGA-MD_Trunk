<Serializable()>
Public Class SueldosTiposVinculoFamiliar
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      idTipoVinculoFamiliar
      NombreVinculoFamiliar
   End Enum

   Private _idTipoVinculoFamiliar As String
   Public Property idTipoVinculoFamiliar() As String
      Get
         Return Me._idTipoVinculoFamiliar
      End Get
      Set(ByVal value As String)
         Me._idTipoVinculoFamiliar = value
      End Set
   End Property

   Private _nombreVinculoFamiliar As String
   Public Property NombreVinculoFamiliar() As String
      Get
         Return Me._nombreVinculoFamiliar
      End Get
      Set(ByVal value As String)
         Me._nombreVinculoFamiliar = value
      End Set
   End Property

End Class
Public Class Sector
   Inherits Entidad

   Public Const NombreTabla As String = "Sectores"

   Public Enum Columnas
      IdSector
      NombreSector
      Observaciones
      IdAreaComun
   End Enum

   Public Property IdSector As Long?
   Public Property NombreSector As String
   Public Property Observaciones As String
   Public Sub New()

   End Sub
   Public Sub New(areaComun As AreaComun)
      Me.New()
      _areaComun = areaComun
   End Sub

   Private _areaComun As AreaComun
   Public Property AreaComun() As AreaComun
      Get
         Return _areaComun
      End Get
      Set(ByVal value As AreaComun)
         _areaComun = value
      End Set
   End Property
   Public ReadOnly Property IdAreaComun() As String
      Get
         If AreaComun Is Nothing Then Return String.Empty
         Return AreaComun.IdAreaComun
      End Get
   End Property

   Public ReadOnly Property NombreAreaComun() As String
      Get
         If AreaComun Is Nothing Then Return String.Empty
         Return AreaComun.NombreAreaComun
      End Get
   End Property

End Class

Public Class CalidadListaControlConfig
   Inherits Entidad
   Public Const NombreTabla As String = "CalidadListasControlConfig"

   Public Enum Columnas
      IdListaControl
      IdListaControlItem
      Orden

   End Enum

   Public Property IdListaControl As Integer
   Public Property Item As CalidadListaControlItem
   Public Property Orden As Integer

   Public Sub New()
      Item = New CalidadListaControlItem()
   End Sub


#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdListaControlItem As Integer
      Get
         Return Item.IdListaControlItem
      End Get
   End Property
   Public ReadOnly Property NombreListaControlItem As String
      Get
         Return Item.NombreListaControlItem
      End Get
   End Property
   Public ReadOnly Property NombreListaControlItemGrupo As String
      Get
         If Item.Grupo Is Nothing Then Return String.Empty
         Return Item.Grupo.NombreListaControlItemGrupo
      End Get
   End Property
   Public ReadOnly Property NombreListaControlItemSubGrupo As String
      Get
         If Item.SubGrupo Is Nothing Then Return String.Empty
         Return Item.SubGrupo.NombreListaControlItemSubGrupo
      End Get
   End Property

#End Region

End Class
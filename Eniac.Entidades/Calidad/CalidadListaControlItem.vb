Public Class CalidadListaControlItem
   Inherits Entidad
   Public Const NombreTabla As String = "CalidadListasControlItems"

   Public Enum Columnas
      IdListaControlItem
      NombreListaControlItem
      IdListaControlItemGrupo
      IdListaControlItemSubGrupo
      NivelInspeccion
      ValorAQL
      Observacion

   End Enum

   Public Property IdListaControlItem As Integer
   Public Property NombreListaControlItem As String
   Public Property Grupo As CalidadListaControlItemGrupo

   Public Property SubGrupo As CalidadListaControlItemSubGrupo
   Public Property NivelInspeccion As NivelInspeccionMRP
   Public Property ValorAQL As Decimal
   Public Property Observacion As String

   Public Sub New()
      Grupo = New CalidadListaControlItemGrupo()
      SubGrupo = New CalidadListaControlItemSubGrupo()
   End Sub

#Region "Propiedades ReadOnly"
   Public ReadOnly Property IdListaControlItemGrupo As String
      Get
         Return Grupo.IdListaControlItemGrupo
      End Get
   End Property
   Public ReadOnly Property IdListaControlItemSubGrupo As String
      Get
         Return SubGrupo.IdListaControlItemSubGrupo
      End Get
   End Property
   Public ReadOnly Property NombreListaControlItemGrupo As String
      Get
         Return Grupo.NombreListaControlItemGrupo
      End Get
   End Property
   Public ReadOnly Property NombreListaControlItemSubGrupo As String
      Get
         Return SubGrupo.NombreListaControlItemSubGrupo
      End Get
   End Property
#End Region

End Class
Public Class CRMTipoNovedadObjetivoUsuario
   Inherits Entidades.Entidad

   Public Const NombreTabla As String = "CRMTiposNovedadesObjetivosUsuarios"

   Public Enum Columnas
      IdTipoNovedad
      PeriodoObjetivo
      IdUsuario
      Objetivo
      ObjetivoMinimo

   End Enum

   Public Property IdTipoNovedad As String
   Public Property PeriodoObjetivo As DateTime
   Public Property IdUsuario As String
   Public Property Objetivo As Decimal
   Public Property ObjetivoMinimo As Decimal

   Public Property NombreUsuario As String               ' No persistido. Solo para mostrar en grilla
   Public Property DiasHabiles As Integer                ' No persistido. Solo para mostrar en grilla
   Public ReadOnly Property ObjetivoDiario As Decimal    ' No persistido. Solo para mostrar en grilla
      Get
         Return Objetivo / DiasHabiles
      End Get
   End Property

End Class
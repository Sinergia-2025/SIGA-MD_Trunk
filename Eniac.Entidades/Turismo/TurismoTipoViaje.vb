Public Class TurismoTipoViaje
   Inherits Entidad

   Public Const NombreTabla As String = "TurismoTiposViajes"
   Public Enum Columnas
      IdTipoViaje
      DescripcionTipoViaje
      CantidadDiasUltimaCuota
      IdInteres

   End Enum

#Region "Propiedades"
   Public Property IdTipoViaje As Integer
   Public Property DescripcionTipoViaje As String
   Public Property CantidadDiasUltimaCuota As Integer
   Public Property IdInteres As Integer?

#End Region

End Class
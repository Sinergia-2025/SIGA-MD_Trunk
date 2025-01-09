Public Class CalidadOrdenDeControlItem
   Inherits Entidad

#Region "Constantes"
   Public Const NombreTabla As String = "CalidadOrdenDeControlItems"
#End Region

#Region "Columnas"
   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdListaControl
      IdListaControlItem
      NivelInspeccion
      ValorAQL
      IdMRPAQLA
      CodigoNivel
      TamanoMuestreo
      CantidadAceptacion
      CantidadRechazo
   End Enum
#End Region

#Region "Propiedades"
   Public Property IdSucursal As Integer
   Public Property IdTipoComprobante As String
   Public Property Letra As String
   Public Property CentroEmisor As Integer
   Public Property NumeroComprobante As Long
   Public Property IdListaControl As Integer
   Public Property IdListaControlItem As Integer
   Public Property NivelInspeccion As NivelInspeccionMRP
   Public Property ValorAQL As Decimal
   Public Property IdMRPAQLA As Integer
   Public Property CodigoNivel As String
   Public Property TamanoMuestreo As Integer
   Public Property CantidadAceptacion As Integer
   Public Property CantidadRechazo As Integer

   Public Property Observacion As String
#End Region

#Region "Propiedades no Pertenecientes a la entidad"
   Public Property NombreListaControl As String
   Public Property NombreListaControlItem As String
#End Region

End Class

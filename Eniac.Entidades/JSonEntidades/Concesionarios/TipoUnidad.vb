﻿Namespace JSonEntidades.Concesionarios.Alcorta
   Public Class TipoUnidad
      Public Class ConcesionarioTipoUnidad

         Public Enum columnas
            IdTipoUnidad
            Nombre
            Descripcion
            SolicitaDistribucionEje
            MuestraEnCerokm
            MuestraEnUsado
         End Enum

#Region "Propiedades"
         Public Property IdTipoUnidad As Integer
         Public Property Nombre As String
         Public Property Descripcion As String
         Public Property SolicitaDistribucionEje As Boolean
         Public Property MuestraEnCerokm As Boolean
         Public Property MuestraEnUsado As Boolean
#End Region
      End Class

      Public Class TipoUnidadResponse
         Public Enum Campos
            sync
         End Enum
         Public Property sync As Boolean
      End Class
   End Class
End Namespace
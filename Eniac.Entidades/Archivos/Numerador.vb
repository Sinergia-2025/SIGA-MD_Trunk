Imports System.ComponentModel

Public Class Numerador
   Inherits Eniac.Entidades.Entidad
   Public Const NombreTabla As String = "Numeradores"
   Public Enum Columnas
      IdNumerador
      Numero
      Descripcion
   End Enum

   Public Property IdNumerador As String
   Public Property Numero As Long
   Public Property Descripcion As String

   Public Enum TiposNumeradores
      PRODUCTOS
      SIRPLUS
   End Enum

End Class
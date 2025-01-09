Public Class AFIPReferenciaTransferencia
   Inherits Entidad
   Public Const NombreTabla As String = "AFIPReferenciasTransferencias"
   Public Enum Columnas
      IdAFIPReferenciaTransferencia
      NombreReferenciaTransferencia
      DescripcionReferenciaTransferencia

   End Enum

   Public Property IdAFIPReferenciaTransferencia As String
   Public Property NombreReferenciaTransferencia As String
   Public Property DescripcionReferenciaTransferencia As String

End Class
Public Class ProduccionModeloFormaVariable
    Inherits Entidad

    Public Const NombreTabla As String = "ProduccionModelosFormasVariables"

    Public Enum Columnas
        IdProduccionModeloForma
        CodigoVariable
        ValorDecimalVariable

    End Enum

    Public Property IdProduccionModeloForma As Integer
    Public Property CodigoVariable As String
    Public Property ValorDecimalVariable As Decimal
End Class
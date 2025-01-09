Public Class ModeloMotor
   Inherits Eniac.Entidades.Entidad

   Public Const NombreTabla As String = "ModelosMotores"

   Public Enum Columnas
      IdModeloMotor
      NombreModeloMotor
      IdMarcaMotor

   End Enum

#Region "Propiedades"

   Public Property IdModeloMotor As Integer
   Public Property NombreModeloMotor As String
   Public Property IdMarcaMotor As Integer

#End Region

End Class
Public Class FuncionVinculada
   Inherits Entidad

   Public Const NombreTabla As String = "FuncionesVinculadas"

   Public Enum Columnas
      IdFuncion
      IdFuncionVinculada

   End Enum

   Public Sub New()
      Funcion = New Funcion()
      FuncionVinculada = New Funcion()
   End Sub

   Public Property Funcion As Funcion
   Public Property FuncionVinculada As Funcion

#Region "Propiedades ReadOnly"

   Public ReadOnly Property IdFuncion As String
      Get
         Return Funcion.Id
      End Get
   End Property
   Public ReadOnly Property IdFuncionVinculada As String
      Get
         Return FuncionVinculada.Id
      End Get
   End Property
   Public ReadOnly Property NombreFuncion As String
      Get
         Return Funcion.Nombre
      End Get
   End Property
   Public ReadOnly Property NombreFuncionVinculada As String
      Get
         Return FuncionVinculada.Nombre
      End Get
   End Property

#End Region

End Class
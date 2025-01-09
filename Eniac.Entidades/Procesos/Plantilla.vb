<Serializable()>
Public Class Plantilla
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdPlantilla
      NombrePlantilla
      FilaInicial
      Sistema
   End Enum

#Region "Campos"

   Private _IdPlantilla As Integer
   Private _NombrePlantilla As String
   Private _Proveedor As Entidades.Proveedor
   Private _FilaInicial As Integer
   Private _Sistema As Boolean
   Private _Campos As DataTable

#End Region

#Region "Propiedades"

   Public Property IdPlantilla() As Integer
      Get
         Return _IdPlantilla
      End Get
      Set(ByVal value As Integer)
         _IdPlantilla = value
      End Set
   End Property

   Public Property NombrePlantilla() As String
      Get
         Return _NombrePlantilla
      End Get
      Set(ByVal value As String)
         _NombrePlantilla = value
      End Set
   End Property

   Public Property Proveedor() As Entidades.Proveedor
      Get
         If Me._Proveedor Is Nothing Then
            Me._Proveedor = New Entidades.Proveedor()
         End If
         Return _Proveedor
      End Get
      Set(ByVal value As Entidades.Proveedor)
         _Proveedor = value
      End Set
   End Property

   Public Property FilaInicial() As Integer
      Get
         Return _FilaInicial
      End Get
      Set(ByVal value As Integer)
         _FilaInicial = value
      End Set
   End Property

   Public Property Sistema() As Boolean
      Get
         Return _Sistema
      End Get
      Set(ByVal value As Boolean)
         _Sistema = value
      End Set
   End Property

   Public Property Campos() As DataTable
      Get
         Return Me._Campos
      End Get
      Set(ByVal value As DataTable)
         Me._Campos = value
      End Set
   End Property

#End Region

End Class
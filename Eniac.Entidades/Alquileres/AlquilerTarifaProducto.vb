<Serializable()> _
<System.ComponentModel.Description("AlquilerTarifaProducto")> _
Public Class AlquilerTarifaProducto
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdProducto
      dtdetalles
      NombreProducto
      Chasis
      Modelo
      NumeroSerie
   End Enum

   Private _IdProducto As String
   Private _dtdetalles As DataTable
   Private _NombreProducto As String

   Public Property IdProducto() As String
      Get
         Return Me._IdProducto
      End Get
      Set(ByVal value As String)
         Me._IdProducto = value
      End Set
   End Property

   Public Property NombreProducto() As String
      Get
         Return Me._NombreProducto
      End Get
      Set(ByVal value As String)
         Me._NombreProducto = value
      End Set
   End Property

   Public Property dtdetalles() As DataTable
      Get
         Return Me._dtdetalles
      End Get
      Set(ByVal value As DataTable)
         Me._dtdetalles = value
      End Set
   End Property

End Class

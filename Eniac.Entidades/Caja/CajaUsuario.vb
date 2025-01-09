<Serializable()> _
Public Class CajaUsuario
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdSucursal
      IdCaja
      NombreCaja
   End Enum

#Region "Propiedades"

   'Private _idSucursal As Integer
   'Public Property IdSucursal() As Integer
   '   Get
   '      Return Me._idSucursal
   '   End Get
   '   Set(ByVal value As Integer)
   '      Me._idSucursal = value
   '   End Set
   'End Property

   Private _idCaja As Integer
   Public Property IdCaja() As Integer
      Get
         Return Me._idCaja
      End Get
      Set(ByVal value As Integer)
         Me._idCaja = value
      End Set
   End Property

   Private _nombreMarca As String
   Public Property NombreCaja() As String
      Get
         Return Me._nombreMarca
      End Get
      Set(ByVal value As String)
         Me._nombreMarca = value
      End Set
   End Property



#End Region

End Class
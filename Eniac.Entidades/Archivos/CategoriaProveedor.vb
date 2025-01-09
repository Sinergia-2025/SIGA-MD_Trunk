<Serializable()> _
Public Class CategoriaProveedor
   Inherits Eniac.Entidades.Entidad

   Public Enum Columnas
      IdCategoria
      NombreCategoria
      IdCuentaContable
   End Enum

#Region "Propiedades"

   Private _idCategoria As Integer
   Public Property IdCategoria() As Integer
      Get
         Return Me._idCategoria
      End Get
      Set(ByVal value As Integer)
         Me._idCategoria = value
      End Set
   End Property

   Private _nombreCategoria As String
   Public Property NombreCategoria() As String
      Get
         Return Me._nombreCategoria
      End Get
      Set(ByVal value As String)
         Me._nombreCategoria = value
      End Set
   End Property

   Private _cuentaContable As ContabilidadCuenta
   Public Property CuentaContable() As ContabilidadCuenta
      Get
         Return _cuentaContable
      End Get
      Set(ByVal value As ContabilidadCuenta)
         _cuentaContable = value
      End Set
   End Property

#End Region

   Public Function GetCopia() As Entidades.CategoriaProveedor
      Dim copia As Entidades.CategoriaProveedor = New Entidades.CategoriaProveedor()
      With copia
         .IdCategoria = Me._idCategoria
         .IdSucursal = Me.IdSucursal
         .NombreCategoria = Me._nombreCategoria
         .CuentaContable = Me._cuentaContable
         .Password = Me.Password
         .Usuario = Me.Usuario
      End With
      Return copia
   End Function


End Class
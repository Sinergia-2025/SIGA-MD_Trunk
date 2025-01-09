<Serializable()>
Public Class MovimientoNumero
   Inherits Eniac.Entidades.Entidad

#Region "Campos"

   Private _numero As Long
   Private _tipoMovimiento As Entidades.TipoMovimiento
   Private _sucursal As Entidades.Sucursal

#End Region

#Region "Propiedades"

   Public Property Numero() As Long
      Get
         Return _numero
      End Get
      Set(ByVal value As Long)
         _numero = value
      End Set
   End Property

   Public Property TipoMovimiento() As Entidades.TipoMovimiento
      Get
         If Me._tipoMovimiento Is Nothing Then
            Me._tipoMovimiento = New Entidades.TipoMovimiento()
         End If
         Return _tipoMovimiento
      End Get
      Set(ByVal value As Entidades.TipoMovimiento)
         _tipoMovimiento = value
      End Set
   End Property

   Public Property Sucursal() As Entidades.Sucursal
      Get
         If _sucursal Is Nothing Then
            Me._sucursal = New Entidades.Sucursal()
         End If
         Return _sucursal
      End Get
      Set(ByVal value As Entidades.Sucursal)
         _sucursal = value
      End Set
   End Property

#End Region

End Class
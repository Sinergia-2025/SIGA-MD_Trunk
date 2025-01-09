Public Class SeleccionMultipleProducto
   Public Property Producto As ProductoLivianoParaImportarProducto
   Public Property Cantidad As Decimal
   Public Property Ubicaciones As List(Of SeleccionMultipleUbicaciones)

   Public Property ListObject As Object

   Public Sub New()
      Ubicaciones = New List(Of SeleccionMultipleUbicaciones)()
      LoteSeleccionado = "(seleccionar)"
      NroSerieSeleccionado = "(seleccionar)"
   End Sub

   Public ReadOnly Property IdProducto As String
      Get
         Return If(Producto IsNot Nothing, Producto.IdProducto, String.Empty)
      End Get
   End Property
   Public ReadOnly Property NombreProducto As String
      Get
         Return If(Producto IsNot Nothing, Producto.NombreProducto, String.Empty)
      End Get
   End Property
   Public ReadOnly Property NombreDepositoUbicacion As String
      Get
         If Ubicaciones.Count = 0 Then
            Return String.Format("{0}/{1}", Producto.NombreDepositoDefecto, Producto.NombreUbicacionDefecto)
         ElseIf Ubicaciones.Count = 1 Then
            Dim u = Ubicaciones.First()
            Return String.Format("{0}/{1}", u.NombreDeposito, u.NombreUbicacion)
         Else
            Return "(multiples)"
         End If
      End Get
   End Property
   Public ReadOnly Property LoteSeleccionado As String
   Public ReadOnly Property NroSerieSeleccionado As String


End Class


Public Class SeleccionMultipleUbicaciones
   Public Property Producto As ProductoLivianoParaImportarProducto
   Public Property Ubicacion As SucursalUbicacion
   Public Property Cantidad As Decimal
   Public Property Stock As Decimal

   Public Property Lotes As List(Of SeleccionMultipleLotes)
   Public Property NrosSerie As List(Of SeleccionMultipleNrosSerie)

   Public Sub New()
      Lotes = New List(Of SeleccionMultipleLotes)()
      NrosSerie = New List(Of SeleccionMultipleNrosSerie)()
   End Sub

#Region "ReadOnly Properties"
   Public ReadOnly Property IdProducto As String
      Get
         Return If(Producto Is Nothing, String.Empty, Producto.IdProducto)
      End Get
   End Property
   Public ReadOnly Property NombreProducto As String
      Get
         Return If(Producto Is Nothing, String.Empty, Producto.NombreProducto)
      End Get
   End Property

   Public ReadOnly Property IdSucursal As Integer
      Get
         Return If(Ubicacion Is Nothing, 0, Ubicacion.IdSucursal)
      End Get
   End Property
   Public ReadOnly Property NombreSucursal As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.NombreSucursal)
      End Get
   End Property

   Public ReadOnly Property IdDeposito As Integer
      Get
         Return If(Ubicacion Is Nothing, 0, Ubicacion.IdDeposito)
      End Get
   End Property
   Public ReadOnly Property CodigoDeposito As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.CodigoDeposito)
      End Get
   End Property
   Public ReadOnly Property NombreDeposito As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.NombreDeposito)
      End Get
   End Property

   Public ReadOnly Property IdUbicacion As Integer
      Get
         Return If(Ubicacion Is Nothing, 0, Ubicacion.IdUbicacion)
      End Get
   End Property
   Public ReadOnly Property CodigoUbicacion As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.CodigoUbicacion)
      End Get
   End Property
   Public ReadOnly Property NombreUbicacion As String
      Get
         Return If(Ubicacion Is Nothing, String.Empty, Ubicacion.NombreUbicacion)
      End Get
   End Property


   Public ReadOnly Property DisplayMember As String
      Get
         Return String.Format("Dep: {0} - Ubic: {1}", NombreDeposito, NombreUbicacion)
      End Get
   End Property
   Public ReadOnly Property DisplayMemberCompleto As String
      Get
         Return String.Format("Sub: {0} - Dep: {1} - Ubic: {2}", NombreSucursal, NombreDeposito, NombreUbicacion)
      End Get
   End Property

   Public ReadOnly Property IdUnico As String
      Get
         Return String.Format("{0}-{1}-{2}", IdSucursal, IdDeposito, IdUbicacion)
      End Get
   End Property

#End Region

End Class
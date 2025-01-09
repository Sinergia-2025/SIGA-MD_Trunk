<DebuggerDisplay("{DebuggerDisplayForClass,nq}")>
Public Class VentaInvocado
   Inherits Entidad
   Public Const NombreTabla As String = "VentasInvocados"

   Public Enum Columnas
      IdSucursal
      IdTipoComprobante
      Letra
      CentroEmisor
      NumeroComprobante
      IdSucursalInvocado
      IdTipoComprobanteInvocado
      LetraInvocado
      CentroEmisorInvocado
      NumeroComprobanteInvocado

   End Enum


   Public Property Invocador As IVentaInvocada
   Public Property Invocado As IVentaInvocada


   'Public Property IdSucursal As Integer
   Public Overrides Property IdSucursal As Integer
      Get
         Return If(Invocador IsNot Nothing, Invocador.IdSucursal, 0)
      End Get
      Set(value As Integer)
         'MyBase.IdSucursal = value
      End Set
   End Property
   Public ReadOnly Property IdTipoComprobante As String
      Get
         Return If(Invocador IsNot Nothing, Invocador.IdTipoComprobante, String.Empty)
      End Get
   End Property
   Public ReadOnly Property Letra As String
      Get
         Return If(Invocador IsNot Nothing, Invocador.Letra, String.Empty)
      End Get
   End Property
   Public ReadOnly Property CentroEmisor As Integer
      Get
         Return If(Invocador IsNot Nothing, Invocador.CentroEmisor, 0I)
      End Get
   End Property
   Public ReadOnly Property NumeroComprobante As Long
      Get
         Return If(Invocador IsNot Nothing, Invocador.NumeroComprobante, 0L)
      End Get
   End Property



   Public ReadOnly Property IdSucursalInvocado As Integer
      Get
         Return If(Invocado IsNot Nothing, Invocado.IdSucursal, 0)
      End Get
   End Property
   Public ReadOnly Property IdTipoComprobanteInvocado As String
      Get
         Return If(Invocado IsNot Nothing, Invocado.IdTipoComprobante, String.Empty)
      End Get
   End Property
   Public ReadOnly Property LetraInvocado As String
      Get
         Return If(Invocado IsNot Nothing, Invocado.Letra, String.Empty)
      End Get
   End Property
   Public ReadOnly Property CentroEmisorInvocado As Integer
      Get
         Return If(Invocado IsNot Nothing, Invocado.CentroEmisor, 0)
      End Get
   End Property
   Public ReadOnly Property NumeroComprobanteInvocado As Long
      Get
         Return If(Invocado IsNot Nothing, Invocado.NumeroComprobante, 0)
      End Get
   End Property


   <DebuggerBrowsable(DebuggerBrowsableState.Never)>
   Private ReadOnly Property DebuggerDisplayForClass() As String
      Get
         Return String.Format("{0} / {1}-{2} {3:0000}-{4:00000000}",
                              Me.IdSucursalInvocado,
                              Me.IdTipoComprobanteInvocado,
                              Me.LetraInvocado,
                              Me.CentroEmisorInvocado,
                              Me.NumeroComprobanteInvocado,
                              Me.IdSucursal,
                              Me.IdTipoComprobante,
                              Me.Letra,
                              Me.CentroEmisor,
                              Me.NumeroComprobante)
      End Get
   End Property
End Class
Public Class VentasInvocadasCollection
   Inherits BindingList(Of VentaInvocado)
   Private _VentaInvocadora As IVentaInvocada

   Public Sub New()
   End Sub

   Public Sub New(ventaInvocadora As IVentaInvocada)
      Me.New()
      Me.VentaInvocadora = ventaInvocadora
   End Sub

   Public Property VentaInvocadora() As IVentaInvocada
      Get
         Return _VentaInvocadora
      End Get
      Set(value As IVentaInvocada)
         _VentaInvocadora = value
         All(Function(i)
                i.Invocador = _VentaInvocadora
                Return True
             End Function)
      End Set
   End Property

   Public Overloads Function Add(item As IVentaInvocada) As Boolean
      Add(New VentaInvocado() With
                {
                  .Invocador = _VentaInvocadora,
                  .Invocado = item
                })
      Return True
   End Function
   Public Overloads Sub Add(lst As IEnumerable(Of IVentaInvocada))
      If lst IsNot Nothing Then
         lst.All(Function(i) Add(i))
      End If
   End Sub

   Protected Overrides Sub OnAddingNew(e As AddingNewEventArgs)
      MyBase.OnAddingNew(e)

      If VentaInvocadora IsNot Nothing Then
         DirectCast(e.NewObject, VentaInvocado).Invocador = VentaInvocadora
      ElseIf DirectCast(e.NewObject, VentaInvocado).Invocador IsNot Nothing Then
         VentaInvocadora = DirectCast(e.NewObject, VentaInvocado).Invocador
      End If

   End Sub

End Class

Public Interface IVentaInvocada
   Inherits IPKComprobante
   'ReadOnly Property IdSucursal As Integer
   'ReadOnly Property IdTipoComprobante As String
   'ReadOnly Property Letra As String
   'ReadOnly Property CentroEmisor As Integer
   'ReadOnly Property NumeroComprobante As Long
   ReadOnly Property IdCliente As Long
   ReadOnly Property Cuit As String
   ReadOnly Property Fecha As Date
   ReadOnly Property TipoTipoComprobante As String
   ReadOnly Property CoeficienteStock As Integer
   ReadOnly Property IdProveedor As Long?
   ReadOnly Property IdTipoComprobanteContraMovInvocar As String
   ReadOnly Property DescripcionTipoComprobante As String

End Interface
<DebuggerDisplay("{DebuggerDisplayForClass,nq}")>
Public Class VentaInvocada
   Inherits Entidad
   Implements IVentaInvocada

   'Public Property IdSucursal As Integer
   Public Property IdTipoComprobante As String Implements IVentaInvocada.IdTipoComprobante
   Public Property Letra As String Implements IVentaInvocada.Letra
   Public Property CentroEmisor As Integer Implements IVentaInvocada.CentroEmisor
   Public Property NumeroComprobante As Long Implements IVentaInvocada.NumeroComprobante
   Public Property IdCliente As Long Implements IVentaInvocada.IdCliente
   Public Property Cuit As String Implements IVentaInvocada.Cuit
   Public Property Fecha As Date Implements IVentaInvocada.Fecha
   Public Property TipoTipoComprobante As String Implements IVentaInvocada.TipoTipoComprobante
   Public Property CoeficienteStock As Integer Implements IVentaInvocada.CoeficienteStock
   Public Property IdProveedor As Long? Implements IVentaInvocada.IdProveedor
   Public Property IdTipoComprobanteContraMovInvocar As String Implements IVentaInvocada.IdTipoComprobanteContraMovInvocar
   Public Property DescripcionTipoComprobante As String Implements IVentaInvocada.DescripcionTipoComprobante

   Private Property IVentaInvocada_IdSucursal As Integer Implements IVentaInvocada.IdSucursal
      Get
         Return Me.IdSucursal
      End Get
      Set(value As Integer)
         Me.IdSucursal = value
      End Set
   End Property

   <DebuggerBrowsable(DebuggerBrowsableState.Never)>
   Private ReadOnly Property DebuggerDisplayForClass() As String
      Get
         Return String.Format("{0} / {1}-{2} {3:0000}-{4:00000000}",
                              Me.IdSucursal,
                              Me.IdTipoComprobante,
                              Me.Letra,
                              Me.CentroEmisor,
                              Me.NumeroComprobante)
      End Get
   End Property
End Class
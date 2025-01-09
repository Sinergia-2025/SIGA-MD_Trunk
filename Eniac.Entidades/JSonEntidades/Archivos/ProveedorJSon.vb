Namespace JSonEntidades.Archivos
   Public Class ProveedorJSon
      Implements IValidable, INotifyPropertyChanged

      Public Property CuitEmpresa As String
      Public Property IdProveedor As Long

      Private _NombreProveedor As String
      Public Property NombreProveedor() As String
         Get
            Return _NombreProveedor.Replace("""", "´")
         End Get
         Set(value As String)
            _NombreProveedor = value
         End Set
      End Property

      Public Property CBUProveedor As String
      Public Property CBUAliasProveedor As String
      Public Property CBUCuit As String
      Public Property DireccionProveedor As String
      Public Property IdLocalidadProveedor As Integer
      Public Property CuitProveedor As String
      Public Property TelefonoProveedor As String
      Public Property FaxProveedor As String
      Public Property IdCategoriaFiscal As Int16
      Public Property Observacion As String
      Public Property IngresosBrutos As String
      Public Property CorreoElectronico As String
      Public Property Activo As Boolean
      Public Property IdCategoria As Integer
      Public Property IdRubroCompra As Integer
      Public Property IdCuentaCaja As Integer
      Public Property EsPasibleRetencion As Boolean
      Public Property IdRegimen As Integer
      Public Property IdTipoComprobante As String
      Public Property DescuentoRecargoPorc As Decimal
      Public Property IdFormasPago As Integer
      Public Property PorCtaOrden As Boolean
      Public Property CodigoProveedor As Long
      Public Property CodigoProveedorLetras As String
      Public Property TipoDocProveedor As String
      Public Property NroDocProveedor As Long
      Public Property FechaHigSeg As String
      Public Property FechaRes559 As String
      Public Property FechaIndiceInc As String
      Public Property EsPasibleRetencionIVA As Boolean
      Public Property IdRegimenIVA As Integer
      Public Property EsPasibleRetencionIIBB As Boolean
      Public Property IdRegimenIIBB As Integer
      Public Property IdRegimenIIBBComplem As Integer
      Public Property IdRegimenGan As Integer
      Public Property IdCuentaContable As Long?
      Public Property NombreDeFantasia As String
      Public Property IdCuentaBanco As Integer
      Public Property NivelAutorizacion As Short
      Public Property FechaIndemnidad As String
      Public Property EsProveedorGenerico As Boolean
      Public Property CorreoAdministrativo As String
      Public Property IdConceptoCM05 As Integer?
      Public Property IdTransportista As Integer
      Public Property IdClienteVinculado As Long?

      Private _ConErrores As Boolean
      Public Property ConErrores As Boolean Implements IValidable.ConErrores
         Get
            Return _ConErrores
         End Get
         Set(value As Boolean)
            _ConErrores = value
            OnPropertyChanged("ConErrores")
         End Set
      End Property
      Private _Estado As String
      Public Property ___Estado As String Implements IValidable.___Estado
         Get
            Return _Estado
         End Get
         Set(value As String)
            _Estado = value
            OnPropertyChanged("___Estado")
         End Set
      End Property
      Private _MensajeError As String
      Public Property ___MensajeError As String Implements IValidable.___MensajeError
         Get
            Return _MensajeError
         End Get
         Set(value As String)
            _MensajeError = value
            OnPropertyChanged("___MensajeError")
         End Set
      End Property

      Public Property drOrigen As DataRow Implements IValidable.drOrigen

      Public Sub New()
         ConErrores = False
         ___Estado = ""
         ___MensajeError = ""
      End Sub

      Protected Overridable Sub OnPropertyChanged(name As String)
         RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(name))
      End Sub

      Public Event PropertyChanged(sender As Object, e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged
   End Class

   Public Class ProveedorJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdProveedor As Long
      Public Property DatosProveedor As String

      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, IdProveedor As Long, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdProveedor = IdProveedor
         Me.FechaActualizacion = fechaActualizacion
      End Sub
   End Class

End Namespace
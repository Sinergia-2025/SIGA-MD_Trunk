Option Strict On
Option Explicit On
Imports actual = Eniac.Entidades.Usuario.Actual
Public Class OrdenesCompraDetalle
   Private _publicos As Publicos

   Public ReadOnly Property OrdenCompra As Entidades.OrdenCompra
      Get
         Return DirectCast(_entidad, Entidades.OrdenCompra)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Eniac.Entidades.OrdenCompra)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         Me._publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtUsuario.Text = actual.Nombre.ToString()
            dtpFechaPedidos.Value = Today
         Else
            bscCodigoProveedor.Text = OrdenCompra.CodigoProveedor.ToString()
            bscCodigoProveedor.PresionarBoton()
         End If

      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.OrdenesCompra()
   End Function

   Protected Overrides Sub Aceptar()

      If IsNumeric(bscCodigoProveedor.Tag) Then
         OrdenCompra.IdProveedor = Long.Parse(bscCodigoProveedor.Tag.ToString())
      End If

      OrdenCompra.IdSucursal = actual.Sucursal.IdSucursal

      MyBase.Aceptar()

      If Not Me.HayError And Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.Close()
      End If
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      If Not IsNumeric(txtNumeroOrdenCompra.Text) Then txtNumeroOrdenCompra.Text = "0"
      If Long.Parse(txtNumeroOrdenCompra.Text) = 0 Then
         txtNumeroOrdenCompra.Focus()
         Return "Debe ingresar un número de Orden de Compra."
      End If

      'If cmbFormaPago.SelectedIndex < 0 Then
      '   cmbFormaPago.Focus()
      '   Return "Debe seleccionar una Forma de Pago."
      'End If

      If Not bscCodigoProveedor.Selecciono OrElse Not IsNumeric(bscCodigoProveedor.Tag) Then
         bscCodigoProveedor.Focus()
         Return "Debe seleccionar un Proveedor."
      End If
      Return MyBase.ValidarDetalle()
   End Function

#End Region

   Private Sub bscCodigoProveedor_BuscadorClick() Handles bscCodigoProveedor.BuscadorClick
      Dim codigoProveedor As Long = -1
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscCodigoProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         If IsNumeric(Me.bscCodigoProveedor.Text) Then
            codigoProveedor = Long.Parse(Me.bscCodigoProveedor.Text.Trim())
         End If
         Me.bscCodigoProveedor.Datos = rProveedores.GetFiltradoPorCodigo(codigoProveedor, True)
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub bscCodigoProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorClick() Handles bscProveedor.BuscadorClick
      Try
         Me._publicos.PreparaGrillaProveedores(Me.bscProveedor)
         Dim rProveedores As Reglas.Proveedores = New Reglas.Proveedores()
         Me.bscProveedor.Datos = rProveedores.GetFiltradoPorNombre(Me.bscProveedor.Text.Trim())
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub bscProveedor_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProveedor.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosProveedor(e.FilaDevuelta)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub CargarDatosProveedor(ByVal dr As DataGridViewRow)
      Me.bscProveedor.Text = dr.Cells(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).Value.ToString()
      Me.bscCodigoProveedor.Text = dr.Cells(Entidades.Proveedor.Columnas.CodigoProveedor.ToString()).Value.ToString()
      Me.bscCodigoProveedor.Tag = dr.Cells(Entidades.Proveedor.Columnas.IdProveedor.ToString()).Value.ToString()
   End Sub

End Class
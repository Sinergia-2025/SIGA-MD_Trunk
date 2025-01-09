Option Strict Off
Public Class ProductosSucursalesDetalle

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(ByVal entidad As Entidades.ProductoSucursal)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Campos"

   Private _publicos As Publicos
   Private _MostrarCosto As Boolean

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()
      Me._publicos.CargaComboSucursales(Me.cmbSucursal)

      Me._liSources.Add("Sucursal", DirectCast(Me._entidad, Entidades.ProductoSucursal).Sucursal)
      Me._liSources.Add("Producto", DirectCast(Me._entidad, Entidades.ProductoSucursal).Producto)
      'Me._liSources.Add("Precios", DirectCast(Me._entidad, Entidades.ProductoSucursal).Precios)

      Me.BindearControles(Me._entidad, Me._liSources)

      Dim prodSuc As Entidades.ProductoSucursal = DirectCast(Me._entidad, Entidades.ProductoSucursal)

      If Me.cmbSucursal.Items.Count = 1 Then
         Me.lblIdSucursal.Visible = False
         Me.cmbSucursal.Visible = False
      End If

      Me.txtMarcaNombre.Text = New Reglas.Marcas().GetPorCodigo(Integer.Parse(Me.txtMarcaCodigo.Text)).Rows(0)("NombreMarca")
      Me.txtRubroNombre.Text = New Reglas.Rubros().GetPorCodigo(Integer.Parse(Me.txtRubroCodigo.Text)).Rows(0)("NombreRubro")
      Me.txtPrecioVenta.Text = New Reglas.ProductosSucursales().GetPrecioVentaPredeterminado(prodSuc.IdSucursal, prodSuc.Producto.IdProducto)

      'Seguridad del campo Precio de Costo
      Dim oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()
      Me._MostrarCosto = oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ConsultarPrecios-PrecioCosto")
      Me.lblPrecioCosto.Visible = Me._MostrarCosto
      Me.txtPrecioCosto.Visible = Me._MostrarCosto

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ProductosSucursales
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Decimal.Parse(Me.txtPrecioCosto.Text) < 0 Then
         Me.txtPrecioCosto.Focus()
         Return "El Precio de Costo NO Puede Ser Negativo."
      End If

      If Decimal.Parse(Me.txtPrecioVenta.Text) < 0 Then
         Me.txtPrecioVenta.Focus()
         Return "El Precio de Venta NO Puede Ser Negativo."
      End If

      If Decimal.Parse(Me.txtPuntoDePedido.Text) < 0 Then
         Me.txtPuntoDePedido.Focus()
         Return "El Punto de Pedido NO Puede Ser Negativo."
      End If

      If Decimal.Parse(Me.txtStockMinimo.Text) < 0 Then
         Me.txtStockMinimo.Focus()
         Return "El Stock Minimo NO Puede Ser Negativo."
      End If

      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      'Me.cmbProducto.Focus()
   End Sub

#End Region

End Class

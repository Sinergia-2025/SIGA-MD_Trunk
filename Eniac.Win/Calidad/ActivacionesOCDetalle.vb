Option Strict Off
Imports Infragistics.Win.UltraWinGrid
Public Class ActivacionesOCDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _OC As Entidades.PedidoProveedor
   Private _Producto As String = String.Empty
   Private _Orden As Integer
   Private _oUsuario As Eniac.Reglas.Usuarios = New Eniac.Reglas.Usuarios()

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ActivacionOC, OC As Entidades.PedidoProveedor, IdProducto As String, Orden As Integer)
      Me.InitializeComponent()
      Me._entidad = entidad
      Me._Producto = IdProducto
      Me._Orden = Orden
      Me._OC = OC
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      _publicos.CargaComboObservacionesCalidad(Me.cmbObservaciones, "COMPRA")
      Dim ProductosEstados As DataTable

      Me.txtComprobante.Text = _OC.TipoComprobante.IdTipoComprobante
      Me.txtNumero.Text = _OC.NumeroPedido
      Me.cmbCriticidad.SelectedIndex = 0
      Me.txtProveedor.Text = _OC.Proveedor.NombreProveedor

      Me.BindearControles(Me._entidad)

      Dim oPedidos As Reglas.PedidosProveedores = New Reglas.PedidosProveedores
      ProductosEstados = oPedidos.GetOCDetalladoXEstadosTodos(actual.Sucursal.Id,
                                                "TODOS",
                                                Nothing, Nothing,
                                                _OC.NumeroPedido,
                                                _Producto,
                                                0,
                                                0,
                                                "",
                                                _OC.Proveedor.IdProveedor,
                                                "",
                                                0,
                                                0,
                                                0,
                                                "PEDIDOSPROV",
                                               {_OC.TipoComprobante},
                                                Nothing, Nothing,
                                                0,
                                                0, Nothing, Nothing)



      If _Orden = 0 Then
         Me.txtItem.Visible = False
         Me.txtProducto.Visible = False
         Me.lblItem.Visible = False
         Me.chbCantidades.Visible = True
         Me.chbFechaE.Visible = True
         Me.grpCabecera.Visible = True
         Me.ugDetalle.Visible = True

         Me.ugDetalle.DataSource = ProductosEstados

         Me.FormateaGrillaProductos(ugDetalle)
         Me.ugDetalle.AgregarFiltroEnLinea({"Estado"})
      Else
         Me.chbFechaReprogEntrega.Visible = False
         Me.dtpFechaReprogEntrega.Visible = False

         Me.ugbArticulo.Visible = True

         Me.txtItem.Text = _Producto
         Me.txtProducto.Text = New Reglas.Productos().GetUno(_Producto).NombreProducto
         Me.txtTelefono.ReadOnly = True
         Me.txtCorreoElectronico.ReadOnly = True
         Me.txtEstado.Text = ProductosEstados.Rows(0).Item("IdEstado").ToString()
         Me.txtCantidadPedida.Text = Decimal.Parse(ProductosEstados.Rows(0).Item("Cantidad").ToString()).ToString("N2")
         Me.txtCantidadPendiente.Text = Decimal.Parse(ProductosEstados.Rows(0).Item("CantPendiente").ToString()).ToString("N2")
         Me.txtCosto.Text = Decimal.Parse(ProductosEstados.Rows(0).Item("Costo").ToString()).ToString("C2")
         Me.txtFechaEntregado.Text = date.Parse(ProductosEstados.Rows(0).Item("FechaEntrega").ToString()).ToString("dd/MM/yyyy")
         Me.txtFechaEstado.Text = Date.Parse(ProductosEstados.Rows(0).Item("FechaEstado").ToString()).ToString("dd/MM/yyyy")

         Me.Height = 520
         Me.Width = 545
      End If

      Dim Prov As Entidades.Proveedor = New Reglas.Proveedores().GetUno(_OC.Proveedor.IdProveedor)
      Me.txtTelefono.Text = Prov.TelefonoProveedor
      Me.txtCorreoElectronico.Text = Prov.CorreoElectronico

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         DirectCast(Me._entidad, Entidades.ActivacionOC).IdSucursal = _OC.IdSucursal
         DirectCast(Me._entidad, Entidades.ActivacionOC).TipoComprobante = _OC.TipoComprobante
         DirectCast(Me._entidad, Entidades.ActivacionOC).Letra = _OC.LetraComprobante
         DirectCast(Me._entidad, Entidades.ActivacionOC).CentroEmisor = _OC.CentroEmisor
         DirectCast(Me._entidad, Entidades.ActivacionOC).NumeroPedido = _OC.NumeroPedido
         If Not String.IsNullOrEmpty(_Producto) Then
            DirectCast(Me._entidad, Entidades.ActivacionOC).Producto = New Reglas.Productos().GetUno(_Producto)
         End If
         DirectCast(Me._entidad, Entidades.ActivacionOC).Orden = _Orden
         DirectCast(Me._entidad, Entidades.ActivacionOC).OrdenActivacion = New Reglas.ActivacionesOC().GetCodigoMaximo(_OC, _Producto, _Orden).ToString() + 1
         DirectCast(Me._entidad, Entidades.ActivacionOC).IdUsuario = actual.Nombre
         DirectCast(Me._entidad, Entidades.ActivacionOC).FechaActivacion = Date.Now
         Me.txtContacto.Focus()

         Dim Activaciones As DataTable = New Reglas.ActivacionesOC().GetUltimaActivacion(_OC.IdSucursal, _OC.TipoComprobante.IdTipoComprobante,
                                                            _OC.LetraComprobante, _OC.CentroEmisor, _OC.NumeroPedido, 0)

         If Activaciones.Rows.Count > 0 Then
            Me.chbCantidades.Checked = Boolean.Parse(Activaciones.Rows(0).Item("Cantidades").ToString())
            Me.chbItems.Checked = Boolean.Parse(Activaciones.Rows(0).Item("Items").ToString())
            Me.chbPrecioU.Checked = Boolean.Parse(Activaciones.Rows(0).Item("Precio").ToString())
            Me.chbFechaE.Checked = Boolean.Parse(Activaciones.Rows(0).Item("FechaE").ToString())

            If IsDate(Activaciones.Rows(0).Item("FechaReprogEntrega").ToString()) Then
               Me.chbFechaReprogEntrega.Checked = True
               Me.dtpFechaReprogEntrega.Value = DateTime.Parse(Activaciones.Rows(0).Item("FechaReprogEntrega").ToString())
            End If
            Me.cmbCriticidad.Text = Activaciones.Rows(0).Item("Criticidad").ToString()
         End If
      Else

            If _oUsuario.TienePermisos(Eniac.Ayudantes.Common.usuario, Eniac.Entidades.Usuario.Actual.Sucursal.Id, "ActivacionesOC_SoloConsulta") Or
                     DirectCast(Me._entidad, Entidades.ActivacionOC).IdUsuario <> Eniac.Ayudantes.Common.usuario Then
            Me.gpbCabecera.Enabled = False
            Me.grbObservaciones.Enabled = False
            Me.ugbArticulo.Enabled = False
            Me.grpCabecera.Enabled = False
            Me.txtObservacion.Enabled = False
         End If

         If DirectCast(Me._entidad, Entidades.ActivacionOC).Criticidad <> "" Then
            Me.cmbCriticidad.Text = DirectCast(Me._entidad, Entidades.ActivacionOC).Criticidad.ToString()
         End If

         If DirectCast(Me._entidad, Entidades.ActivacionOC).IdObservacion > 0 Then
            '    Me.bscObservacionDetalle.Text = New Reglas.Observaciones().GetUno(DirectCast(Me._entidad, Entidades.ActivacionOC).IdObservacion).DetalleObservacion
            '   Me.bscObservacionDetalle.PresionarBoton()
            Me.cmbObservaciones.SelectedValue = New Reglas.Observaciones().GetUno(DirectCast(Me._entidad, Entidades.ActivacionOC).IdObservacion).IdObservacion
         End If
         If DirectCast(Me._entidad, Entidades.ActivacionOC).FechaReprogEntrega <> Nothing Then
               Me.chbFechaReprogEntrega.Checked = True
               Me.dtpFechaReprogEntrega.Value = DirectCast(Me._entidad, Entidades.ActivacionOC).FechaReprogEntrega
            End If
         End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ActivacionesOC()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      '   DirectCast(Me._entidad, Entidades.ActivacionOC).IdObservacion = Me.bscObservacionDetalle.Tag
      If cmbObservaciones.SelectedIndex <> -1 Then
         DirectCast(Me._entidad, Entidades.ActivacionOC).IdObservacion = Integer.Parse(cmbObservaciones.SelectedValue.ToString())
      End If

      If DirectCast(Me._entidad, Entidades.ActivacionOC).Orden = 0 Then
         DirectCast(Me._entidad, Entidades.ActivacionOC).Criticidad = Me.cmbCriticidad.Text
      End If

      If Me.chbFechaReprogEntrega.Checked Then
         DirectCast(Me._entidad, Entidades.ActivacionOC).FechaReprogEntrega = Me.dtpFechaReprogEntrega.Value
      End If

      Dim oProveedores As Reglas.Proveedores = New Reglas.Proveedores()
      oProveedores.ActualizarTelefonoMails(_OC.Proveedor.IdProveedor, Me.txtTelefono.Text, Me.txtCorreoElectronico.Text)

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   'Private Sub CargarProximoNumero()
   '   Me.txtIdProductoTipoServicio.Text = New Reglas.ActivacionesOC().GetCodigoMaximo().ToString()
   'End Sub

#End Region


   Private Sub chbFechaReprogEntrega_CheckedChanged(sender As Object, e As EventArgs) Handles chbFechaReprogEntrega.CheckedChanged
      Try
         Me.dtpFechaReprogEntrega.Enabled = Me.chbFechaReprogEntrega.Checked
         If Not Me.chbFechaReprogEntrega.Checked Then
            Me.dtpFechaReprogEntrega.Value = Date.Today
            DirectCast(Me._entidad, Entidades.ActivacionOC).FechaReprogEntrega = Nothing
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


   Private Sub FormateaGrillaProductos(grilla As UltraGrid)
      Dim col As Integer = 0
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdProducto"), "Cod. Artículo", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Nombreproducto"), "Descripción Artículo", col, 200)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Cantidad"), "Cant. Pedida", col, 75, HAlign.Right, , "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("Costo"), "Costo", col, 80, HAlign.Right, , "C2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdEstado"), "Estado", col, 80)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FechaEstado"), "Fecha Estado", col, 80, HAlign.Center)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("CantPendiente"), "Cant. Pendiente", col, 92, HAlign.Right,, "N2")
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("FechaEntrega"), "Fecha Entrega", col, 85, HAlign.Center)

      End With

   End Sub

   Private Sub btnRefreshObservaciones_Click(sender As Object, e As EventArgs) Handles btnRefreshObservaciones.Click
      Try
         Me.cmbObservaciones.SelectedIndex = -1
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub


End Class
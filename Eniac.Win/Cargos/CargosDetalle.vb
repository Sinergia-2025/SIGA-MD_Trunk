Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual

Public Class CargosDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Cargo)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         Me._publicos.CargaComboTiposLiquidacion(cmbTiposLiquidacion)

         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then

            Me.chbActivo.Checked = True

            Me.CargarProximoNumero()
            DirectCast(Me._entidad, Entidades.Cargo).IdSucursal = actual.Sucursal.Id
            DirectCast(Me._entidad, Entidades.Cargo).Usuario = actual.Nombre

            If Me.cmbTiposLiquidacion.Items.Count = 1 Then
               Me.cmbTiposLiquidacion.SelectedIndex = 0
            End If

         Else

            Me.chbCuotas.Checked = DirectCast(Me._entidad, Entidades.Cargo).CantidadCuotas.HasValue

            Me.chbCargoTemporal.Checked = DirectCast(Me._entidad, Entidades.Cargo).CargoTemporal

            If Not String.IsNullOrWhiteSpace(DirectCast(Me._entidad, Entidades.Cargo).IdProducto) Then
               bscCodigoProducto2.Text = DirectCast(Me._entidad, Entidades.Cargo).IdProducto
               bscCodigoProducto2.PresionarBoton()
            End If

         End If

         'Me.txtNombre.Focus()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Cargos()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Not Me.bscCodigoProducto2.Selecciono And Not Me.bscProducto2.Selecciono Then
         Return "Debe Seleccionar un Producto."
      End If

      If Me.chbCuotas.Checked AndAlso Integer.Parse(Me.txtCantidadCuotas.Text) = 0 Then
         Return "Activo las Cuotas. Debe Informar la Cantidad."
      End If

      'If Decimal.Parse(Me.txtMonto.Text) = 0 Then
      '   Return "El Monto del Adicional No Puede ser Cero."
      'End If

      'If Me.chbImprimeVoucher.Checked AndAlso Integer.Parse(Me.txtCantidadMeses.Text) = 0 Then
      '   Return "Activo el Voucher. Debe Informar la Cantidad de Meses de Validez."
      'End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      If Not chbImprimeVoucher.Checked Then
         DirectCast(_entidad, Entidades.Cargo).CantidadMeses = Nothing
      End If

      If Not chbCuotas.Checked Then
         DirectCast(_entidad, Entidades.Cargo).CantidadCuotas = Nothing
         DirectCast(_entidad, Entidades.Cargo).CuotaActual = Nothing
      End If

      If DirectCast(_entidad, Entidades.Cargo).Producto Is Nothing Then
         DirectCast(_entidad, Entidades.Cargo).Producto = New Eniac.Entidades.Producto()
      End If
      DirectCast(_entidad, Entidades.Cargo).Producto.IdProducto = bscCodigoProducto2.Text

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub chbImprimeVoucher_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbImprimeVoucher.CheckedChanged
      Me.txtCantidadMeses.ReadOnly = Not Me.chbImprimeVoucher.Checked
      If Not Me.txtCantidadMeses.ReadOnly Then
         Me.txtCantidadMeses.Focus()
      Else
         Me.txtCantidadMeses.Text = Nothing
      End If
   End Sub

   Private Sub chbCuotas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbCuotas.CheckedChanged
      Me.txtCantidadCuotas.ReadOnly = Not Me.chbCuotas.Checked
      If Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         Me.txtCuotaActual.ReadOnly = Not Me.chbCuotas.Checked
      End If
      If Not Me.txtCantidadCuotas.ReadOnly Then
         Me.txtCantidadCuotas.Focus()
      Else
         Me.txtCantidadCuotas.Text = "0"
         Me.txtCuotaActual.Text = "0"
      End If
   End Sub

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtNombre.Focus()
   End Sub

   Private Sub bscCodigoProducto2_BuscadorClick() Handles bscCodigoProducto2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscCodigoProducto2)
         Me.bscCodigoProducto2.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorClick() Handles bscProducto2.BuscadorClick
      Try
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         Me._publicos.PreparaGrillaProductos2(Me.bscProducto2)
         Me.bscProducto2.Datos = oProductos.GetPorNombre(Me.bscProducto2.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "TODOS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto2_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto2.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarProducto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      Me.txtId.Text = (DirectCast(Me.GetReglas(), Reglas.Cargos).GetCodigoMaximo() + 1).ToString()
   End Sub

   Private Sub CargarProducto(ByVal dr As DataGridViewRow)
      Me.bscProducto2.Text = dr.Cells("NombreProducto").Value.ToString()
      Me.bscCodigoProducto2.Text = dr.Cells("IdProducto").Value.ToString.Trim()
   End Sub

#End Region


   Private Sub btnRefrescar_Click(sender As Object, e As EventArgs) Handles btnRefrescar.Click
      Try

         Me.cmbTiposLiquidacion.SelectedIndex = -1
         DirectCast(Me._entidad, Entidades.Cargo).IdTipoLiquidacion = Nothing

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
End Class
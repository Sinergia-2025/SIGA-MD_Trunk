Option Explicit On
Option Strict On

'Imports Eniac
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class NotaRecepcion

#Region "Campos"

   Private _nota As Eniac.Entidades.RecepcionNota
   Private _CantidadOriginal As Integer
   Private _publicos As Eniac.Win.Publicos

#End Region

#Region "Constructores"

   Public Sub New(ByVal notaRecepcion As Eniac.Entidades.RecepcionNota)

      InitializeComponent()

      Me._nota = notaRecepcion
      Me._CantidadOriginal = Decimal.ToInt32(Me._nota.CantidadProductos)

      Me._publicos = New Eniac.Win.Publicos()

   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         'Tengo que Bindear a mano, el producto puede venir vacio para una Nota sin Comprobante.
         'Me.BindearControles(Me._nota)

         Me.CargaDatosNota()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Overrides Sub Aceptar()
      Try
         Dim res As String
         res = Me.ValidarControles().Trim()
         If Me.ValidarDetalle() <> "" Then
            If res = "" Then
               res = Me.ValidarDetalle()
            Else
               res += Convert.ToChar(Keys.Enter) & Me.ValidarDetalle()
            End If
         End If
         If res = "" Then
            Dim oWS As Eniac.Reglas.RecepcionNotas = New Eniac.Reglas.RecepcionNotas()

            Me.SetearNota()

            'Inserto un registro
            If Me.StateForm = Eniac.Win.StateForm.Insertar Then

               Me._nota.EstaPrestado = False

               oWS.Insertar(Me._nota)

               MessageBox.Show("La Nota de Recepción Nro. " + Me._nota.NroNota.ToString() _
                        + Convert.ToChar(Keys.Enter) + _
                        " de " + Me._nota.Cliente.NombreCliente + Convert.ToChar(Keys.Enter) + " fue grabada con éxito.", _
                      Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

               If MessageBox.Show("¿Quiere imprimir la Nota de Recepcion del Producto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
                  Me.ImprimirNotaRecepcion(Me._nota)
               End If

               Me.Close()
            Else
               'Modifico un registro
               oWS.Actualizar(Me._nota)
               MessageBox.Show("Se actualizo el registro.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.DialogResult = Windows.Forms.DialogResult.OK
               Me.Close()
            End If
         Else
            MessageBox.Show(res, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch exSql As System.Data.SqlClient.SqlException
         If exSql.Message.Contains("Cannot insert duplicate key in object") Then
            MessageBox.Show("El código ingresado ya existe.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         ElseIf exSql.Message.Contains("Expire time") Then
            MessageBox.Show("Expiro el tiempo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(exSql.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message)
      End Try
   End Sub

   Protected Overrides Function ValidarDetalle() As String

      Dim vacio As String = ""

      If Me.bscCodigoProducto.Enabled And Not Me.bscCodigoProducto.Selecciono And Not Me.bscProducto.Selecciono Then
         Me.bscCodigoProducto.Focus()
         Return "Debe elegir un Producto."
      End If

      If Decimal.Parse(Me.txtCantidadProductos.Text) <= 0 Then
         Me.txtCantidadProductos.Focus()
         Return "Debe ingresar una cantidad Positiva"
      End If

      If Me._nota.Venta.TipoComprobante IsNot Nothing And Decimal.Parse(Me.txtCantidadProductos.Text) > Me._CantidadOriginal Then
         Me.txtCantidadProductos.Focus()
         Return "No puede recibir mas productos que los vendidos (" & Me._CantidadOriginal.ToString() & ")"
      End If

      If Decimal.Parse(Me.txtCostoReparacion.Text) < 0 Then
         Me.txtCostoReparacion.Focus()
         Return "El Costo de la Reparacion no debe ser Negativo"
      End If

      If Me.dtpFechaCompra.Visible And Me.dtpFechaCompra.Value.Date > Me.dtpFechaRecepcion.Value.Date Then
         Me.dtpFechaCompra.Focus()
         Return "La fecha de Compra NO puede ser mayor a la de Recepcion"
      End If

      Return vacio

   End Function


#End Region

#Region "Eventos"

   Private Sub bscCodigoProducto_BuscadorClick() Handles bscCodigoProducto.BuscadorClick
      Try
         Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos
         pub.PreparaGrillaProductos2(Me.bscCodigoProducto)
         Me.bscCodigoProducto.Datos = oProductos.GetPorCodigo(Me.bscCodigoProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscProducto.Text = e.FilaDevuelta.Cells("NombreProducto").Value.ToString()
            Me.bscCodigoProducto.Text = e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim()
            Me._nota.Producto = New Eniac.Reglas.Productos().GetUno(e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim())
            'DirectCast(Me._entidad, Eniac.Service.Entidades.RecepcionNotaV).Producto = New Eniac.Reglas.Productos().GetUno(e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim())
            Me.txtCantidadProductos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorClick() Handles bscProducto.BuscadorClick
      Try
         Dim pub As Eniac.Win.Publicos = New Eniac.Win.Publicos()
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()
         pub.PreparaGrillaProductos2(Me.bscProducto)
         Me.bscProducto.Datos = oProductos.GetPorNombre(Me.bscProducto.Text.Trim(), actual.Sucursal.Id, Publicos.ListaPreciosPredeterminada, "VENTAS")
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscProducto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscProducto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.bscProducto.Text = e.FilaDevuelta.Cells("NombreProducto").Value.ToString()
            Me.bscCodigoProducto.Text = e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim()
            Me._nota.Producto = New Eniac.Reglas.Productos().GetUno(e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim())
            'DirectCast(Me._entidad, Eniac.Service.Entidades.RecepcionNotaV).Producto = New Eniac.Reglas.Productos().GetUno(e.FilaDevuelta.Cells("IdProducto").Value.ToString.Trim())
            Me.txtCantidadProductos.Focus()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaDatosNota()

      Me.dtpFechaRecepcion.Value = Me._nota.FechaNota

      If Me._nota.Venta.TipoComprobante IsNot Nothing Then
         Me.dtpFechaCompra.Value = Me._nota.Venta.Fecha
      Else
         Me.lblFechaCompra.Visible = False
         Me.dtpFechaCompra.Visible = False
      End If

      If Me._nota.Producto IsNot Nothing Then
         Me.bscCodigoProducto.Text = Me._nota.Producto.IdProducto
         Me.bscProducto.Text = Me._nota.Producto.NombreProducto
      Else
         Me.bscCodigoProducto.Enabled = True
         Me.bscProducto.Enabled = True
      End If

      Me.txtDefectoProducto.Text = Me._nota.DefectoProducto
      Me.txtObservacion.Text = Me._nota.Observacion
      Me.txtCantidadProductos.Text = Me._nota.CantidadProductos.ToString()
      Me.txtCostoReparacion.Text = Me._nota.CostoReparacion.ToString()

   End Sub

   Private Sub SetearNota()

      Me._nota.FechaNota = Me.dtpFechaRecepcion.Value
      Me._nota.Venta.Fecha = Me.dtpFechaCompra.Value
      Me._nota.Producto.IdProducto = Me.bscCodigoProducto.Text
      Me._nota.Producto.NombreProducto = Me.bscProducto.Text
      Me._nota.DefectoProducto = Me.txtDefectoProducto.Text
      Me._nota.Observacion = Me.txtObservacion.Text
      Me._nota.CantidadProductos = Decimal.Parse(Me.txtCantidadProductos.Text)
      Me._nota.CostoReparacion = Decimal.Parse(txtCostoReparacion.Text)
      Me._nota.Usuario = actual.Nombre

   End Sub

   Private Sub ImprimirNotaRecepcion(ByVal Nota As Eniac.Entidades.RecepcionNota)

      Me.Cursor = Cursors.WaitCursor

      Try
         Dim oImprimir As ImpresionNota = New ImpresionNota(Nota)
         oImprimir.ImprimirNotaRecepcion()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

End Class
Option Explicit On
Option Strict On

'Imports Eniac
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class NotaRecepcionF

#Region "Campos"

   Private _nota As Eniac.Entidades.RecepcionNotaF
   Private _CantidadOriginal As Integer
   Private _publicos As Eniac.Win.Publicos
#End Region

#Region "Constructores"

   Public Sub New(ByVal notaRecepcion As Eniac.Entidades.RecepcionNotaF)
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
         Me.BindearControles(Me._nota)

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
            Dim oWS As Eniac.Reglas.RecepcionNotasF = New Eniac.Reglas.RecepcionNotasF()

            'Inserto un registro
            If Me.StateForm = Eniac.Win.StateForm.Insertar Then

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

      'If Me.bscCodigoProducto.Enabled And Not Me.bscCodigoProducto.Selecciono And Not Me.bscProducto.Selecciono Then
      '   Me.bscCodigoProducto.Focus()
      '   Return "Debe elegir un Producto."
      'End If

      If Decimal.Parse(Me.txtCantidadProductos.Text) <= 0 Then
         Me.txtCantidadProductos.Focus()
         Return "Debe ingresar una cantidad Positiva"
      End If

      'If Me._nota.Venta.TipoComprobante IsNot Nothing And Decimal.Parse(Me.txtCantidadProductos.Text) > Me._CantidadOriginal Then
      '   Me.txtCantidadProductos.Focus()
      '   Return "No puede recibir mas productos que los vendidos (" & Me._CantidadOriginal.ToString() & ")"
      'End If

      If Decimal.Parse(Me.txtCantidadProductos.Text) > Me._CantidadOriginal Then
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

#Region "Metodos"

   Private Sub ImprimirNotaRecepcion(ByVal nota As Eniac.Entidades.RecepcionNotaF)

      Me.Cursor = Cursors.WaitCursor

      Try
         Dim oImprimir As ImpresionNotaF = New ImpresionNotaF(nota)
         oImprimir.ImprimirNotaRecepcion()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub


#End Region

End Class
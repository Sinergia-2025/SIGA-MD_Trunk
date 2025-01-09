Option Strict On
Option Explicit On
Public Class ImpresionTicketFiscalConfirmar

   Private Property Venta As Entidades.Venta
   Public Property NuevoNumeroComprobante As Long
   Public Property NumeroEnPapel As Long

   Public Sub New()
      InitializeComponent()
   End Sub
   Public Sub New(venta As Entidades.Venta, numeroEnPapel As Long)
      Me.New()
      Me.Venta = venta
      Me.NumeroEnPapel = numeroEnPapel
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         txtTipoComprobante.Text = Venta.TipoComprobante.Descripcion
         txtLetra.Text = Venta.LetraComprobante
         txtEmisor.Text = Venta.CentroEmisor.ToString("0000")
         txtNumero.Text = Venta.NumeroComprobante.ToString("00000000")

         txtNumeroEnPapel.Text = NumeroEnPapel.ToString()
         txtNumeroEnPapel.ReadOnly = NumeroEnPapel > 0

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      Try
         Dim nuevoNumero As Long = If(IsNumeric(txtNumeroEnPapel.Text), Long.Parse(txtNumeroEnPapel.Text), 0)
         If nuevoNumero = 0 Then
            ShowMessage("El número en Papel no puede ser 0")
            Exit Sub
         End If
         Dim rVenta As Reglas.Ventas = New Reglas.Ventas()
         If rVenta.Existe(Venta.IdSucursal, Venta.TipoComprobante.IdTipoComprobanteSecundario, Venta.LetraComprobante, Venta.CentroEmisor, nuevoNumero) Then
            ShowMessage(String.Format("Ya existe el comprobante {0} {1} {2:0000}-{3:00000000}", Venta.TipoComprobante.IdTipoComprobanteSecundario, Venta.LetraComprobante, Venta.CentroEmisor, nuevoNumero))
            Exit Sub
         End If

         If NumeroEnPapel = 0 Then
            Dim puedeCargarNumero As Boolean
            puedeCargarNumero = BaseSeguridad.ControloPermisos(actual.Sucursal.Id, Eniac.Ayudantes.Common.usuario, "ImpresionTicketFiscal-IngPapel", "")

            If Not puedeCargarNumero Then
               ShowMessage("No tiene permitido cambiar el número de comprobante impreso en papel")
               Exit Sub
            End If
         End If

         NuevoNumeroComprobante = nuevoNumero

         DialogResult = Windows.Forms.DialogResult.OK
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
      Try
         DialogResult = Windows.Forms.DialogResult.Cancel
         Close()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub txtNumeroEnPapel_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNumeroEnPapel.KeyDown
      If e.KeyCode = Keys.Enter Then
         btnAceptar.PerformClick()
      End If
   End Sub
End Class
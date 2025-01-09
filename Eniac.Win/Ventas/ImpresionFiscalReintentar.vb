Imports Eniac.Entidades.Entidad
Public Class ImpresionFiscalReintentar
   Private _ComprobanteImprimir As Entidades.Venta
   Private _ComprobanteAnterior As Entidades.Venta
   Private _EsFical As Boolean
   Private _CantidadReintentos As Integer = 0

   Public Sub New(ByVal ComprobanteAnterior As Entidades.Venta, ComprobanteImprimir As Entidades.Venta, ByVal EsFiscal As Boolean)

      MyBase.New()

      Me.InitializeComponent()

      Try
         _ComprobanteImprimir = ComprobanteImprimir
         _ComprobanteAnterior = ComprobanteAnterior
         _EsFical = EsFiscal

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try


   End Sub

#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me.tsbReintentarImpresion.PerformClick()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

#End Region


   Private Sub tsbReintentarImpresion_Click(sender As Object, e As EventArgs) Handles tsbReintentarImpresion.Click

      Dim oventas As Reglas.Ventas = New Reglas.Ventas()

      Try
         _CantidadReintentos += 1
         Dim _fc As FacturacionComunes = New FacturacionComunes()

         If _fc.ImprimirComprobante(_ComprobanteImprimir, _EsFical) Then
            Try

               'Guardo numero de comprobante por si falla la grabacion del TICKET
               oventas.ActualizaNumeroComprobanteFiscal(_ComprobanteAnterior.IdSucursal, _ComprobanteAnterior.TipoComprobante.IdTipoComprobante, _
                                                   _ComprobanteAnterior.LetraComprobante, _ComprobanteAnterior.Impresora.CentroEmisor, _
                                                   _ComprobanteAnterior.NumeroComprobante, _ComprobanteImprimir.NumeroComprobante)


               oventas.GrabarComprobanteFiscal(_ComprobanteAnterior, _ComprobanteImprimir, MetodoGrabacion.Manual, Me.IdFuncion)

            Catch ex As Reglas.Ventas.ActualizaCAEException
               Throw

            End Try
         End If
      Catch ex As Exception
         If _CantidadReintentos < 4 Then
            Me.Label1.Text = "Cantidad de intentos: " & _CantidadReintentos
            Dim stbError As New StringBuilder(ex.Message)
            If ex.InnerException IsNot Nothing Then
               stbError.AppendLine()
               stbError.Append(ex.InnerException.Message)
            End If
            Me.txtMensaje.Text = stbError.ToString()

            oventas.ActualizaCantidadReintentos(_ComprobanteAnterior.IdSucursal, _ComprobanteAnterior.IdTipoComprobante, _ComprobanteAnterior.LetraComprobante,
                                                    _ComprobanteAnterior.CentroEmisor, _ComprobanteAnterior.NumeroComprobante, _CantidadReintentos)

            oventas.ActualizarCodigoErrorAFIP(_ComprobanteAnterior.IdSucursal, _ComprobanteAnterior.IdTipoComprobante, _ComprobanteAnterior.LetraComprobante,
                                                    _ComprobanteAnterior.CentroEmisor, _ComprobanteAnterior.NumeroComprobante, ex.Message.ToString())
         Else
            MessageBox.Show("Error en la impresión fiscal, por favor imprimir desde pantalla Impresión Tickets Fiscales.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
         End If
      End Try
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

End Class
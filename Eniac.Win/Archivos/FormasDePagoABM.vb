Public Class FormasDePagoABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New FormasDePagoDetalle(DirectCast(GetEntidad(), Entidades.VentaFormaPago))
      End If
      Return New FormasDePagoDetalle(New Entidades.VentaFormaPago())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.VentasFormasPago()
   End Function

   'Protected Overrides Sub Imprimir()
   '   MyBase.Imprimir()
   '   Try
   '      Me.Cursor = Cursors.WaitCursor
   '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Sucursales.rdlc", "SistemaDataSet_Sucursales", Me.dtDatos, True)
   '      frmImprime.Text = "Sucursales"
   '      frmImprime.Show()
   '      Me.Cursor = Cursors.Default
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.FilaSeleccionada(Of DataRow)()
         Return New Reglas.VentasFormasPago().GetUna(.ValorNumericoPorDefecto("IdFormasPago", 0I))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim col = 0I

         .Columns("IdFormasPago").FormatearColumna("Código", col, 50, HAlign.Right)
         .Columns("DescripcionFormasPago").FormatearColumna("Nombre", col, 200)
         .Columns("Dias").FormatearColumna("Dias", col, 50, HAlign.Right)
         .Columns("EsTarjeta").FormatearColumna("Es Tarjeta", col, 60, HAlign.Right, True)

         .Columns("OrdenVentas").FormatearColumna("Orden Ventas", col, 60, HAlign.Right)
         .Columns("OrdenCompras").FormatearColumna("Orden Compras", col, 60, HAlign.Right)
         .Columns("OrdenFichas").FormatearColumna("Orden Fichas", col, 60, HAlign.Right, Not Reglas.Publicos.TieneModuloFichas)

         .Columns("CantidadCuotas").FormatearColumna("Cantidad Cuotas", col, 60, HAlign.Right)
         .Columns("DiasPrimerCuota").FormatearColumna("Dias primer Cuota", col, 60, HAlign.Right)

         .Columns(Entidades.VentaFormaPago.Columnas.FechaBaseProximaCuota.ToString()).FormatearColumna("Próxima Cuota", col, 70)

         .Columns(Entidades.VentaFormaPago.Columnas.IdListaPrecios.ToString()).FormatearColumna("Código Lista de Precios", col, 80, HAlign.Right, False)    '-.PE-33091.-
         .Columns(Entidades.ListaDePrecios.Columnas.NombreListaPrecios.ToString()).FormatearColumna("Lista de Precios", col, 120)

         .Columns(Entidades.VentaFormaPago.Columnas.IdTipoComprobantes.ToString()).Hidden = True
         .Columns(Entidades.VentaFormaPago.Columnas.IdTipoComprobantesFR.ToString()).Hidden = True

         .Columns(Entidades.VentaFormaPago.Columnas.ExcluyeSabados.ToString()).FormatearColumna("Excluye Sábados", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.ExcluyeDomingos.ToString()).FormatearColumna("Excluye Domingos", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.ExcluyeFeriados.ToString()).FormatearColumna("Excluye Feriados", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.ExcluyeFeriados.ToString()).FormatearColumna("Excluye Feriados", col, 60, HAlign.Center)

         .Columns(Entidades.VentaFormaPago.Columnas.Porcentaje.ToString()).FormatearColumna("D/R Gral", col, 50, HAlign.Right)

         .Columns(Entidades.VentaFormaPago.Columnas.IdCuentaBancariaEfectivo.ToString()).OcultoPosicion(True, col)
         .Columns(Entidades.CuentaBancaria.Columnas.CodigoBancario.ToString()).OcultoPosicion(True, col)
         .Columns(Entidades.CuentaBancaria.Columnas.NombreCuenta.ToString()).FormatearColumna("Cuenta Bancaria para cobro contado", col, 120)

         .Columns(Entidades.VentaFormaPago.Columnas.RequierePesos.ToString()).FormatearColumna("Requiere Pesos", col, 60, HAlign.Center)
         '.Columns(Entidades.VentaFormaPago.Columnas.RequiereDolares.ToString()).FormatearColumna("Requiere Dólares", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.RequiereTickets.ToString()).FormatearColumna("Requiere Tickets", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.RequiereTransferencia.ToString()).FormatearColumna("Requiere Transferencia", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.RequiereCheques.ToString()).FormatearColumna("Requiere Cheques", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.RequiereTarjetaDebito.ToString()).FormatearColumna("Requiere Tarjeta Débito", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.RequiereTarjetaCredito.ToString()).FormatearColumna("Requiere Tarjeta Crédito", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.RequiereTarjetaCredito1Pago.ToString()).FormatearColumna("Requiere Tarjeta Crédito 1 Pago", col, 60, HAlign.Center)

         '-- REQ-35955.- ------------------------------------------------------------------------------
         .Columns(Entidades.VentaFormaPago.Columnas.ArchivoComplementario.ToString()).FormatearColumna("Arch. Complementario", col, 200)
         .Columns(Entidades.VentaFormaPago.Columnas.ArchivoComplementario.ToString()).Hidden = True
         .Columns(Entidades.VentaFormaPago.Columnas.ArchivoAImprimirEmbebido.ToString()).FormatearColumna("Embebido", col, 60, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.ArchivoAImprimirEmbebido.ToString()).Hidden = True
         '---------------------------------------------------------------------------------------------
         .Columns(Entidades.VentaFormaPago.Columnas.Descripcion.ToString()).FormatearColumna("Desc. Extendida", col, 150, HAlign.Center)
         .Columns(Entidades.VentaFormaPago.Columnas.Descripcion.ToString()).Hidden = True

      End With
      dgvDatos.AgregarFiltroEnLinea({"DescripcionFormasPago"})

   End Sub

#End Region

End Class
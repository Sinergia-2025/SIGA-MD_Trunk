Public Class TiposComprobantesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
      dgvDatos.AgregarFiltroEnLinea({Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString(),
                                     Entidades.TipoComprobante.Columnas.Descripcion.ToString(),
                                     Entidades.TipoComprobante.Columnas.DescripcionAbrev.ToString(),
                                     Entidades.TipoComprobante.Columnas.ComprobantesAsociados.ToString()})
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposComprobantesDetalle(DirectCast(GetEntidad(), Entidades.TipoComprobante))
      End If
      Return New TiposComprobantesDetalle(New Entidades.TipoComprobante())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.TiposComprobantes()
   End Function

   'Protected Overrides Sub Imprimir()
   '   MyBase.Imprimir()
   '   Try
   '      Me.Cursor = Cursors.WaitCursor
   '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Categorias.rdlc", "SistemaDataSet_Categorias", Me.dtDatos, True)
   '      frmImprime.Text = "Categorias"
   '      frmImprime.Show()
   '      Me.Cursor = Cursors.Default
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim tipoComp As Entidades.TipoComprobante = New Entidades.TipoComprobante
      With Me.dgvDatos.ActiveCell.Row
         tipoComp.IdTipoComprobante = .Cells(Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()).Value.ToString()
         tipoComp = New Reglas.TiposComprobantes().GetUno(tipoComp.IdTipoComprobante)
      End With
      Return tipoComp
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I

         .Columns(Entidades.TipoComprobante.Columnas.IdTipoComprobante.ToString()).FormatearColumna("Comprobante", pos, 100)
         .Columns(Entidades.TipoComprobante.Columnas.EsFiscal.ToString()).FormatearColumna("Es Fiscal", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.Descripcion.ToString()).FormatearColumna("Descripción", pos, 200)
         .Columns(Entidades.TipoComprobante.Columnas.Tipo.ToString()).FormatearColumna("Tipo", pos, 80)
         .Columns(Entidades.TipoComprobante.Columnas.Orden.ToString()).FormatearColumna("Orden", pos, 50, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.Color.ToString()).FormatearColumna("Color", pos, 80, HAlign.Right)

         .Columns(Entidades.TipoComprobante.Columnas.CoeficienteStock.ToString()).FormatearColumna("Coef. Stock", pos, 60, HAlign.Right)
         .Columns(Entidades.TipoComprobante.Columnas.CoeficienteValores.ToString()).FormatearColumna("Coef. Valores", pos, 60, HAlign.Right)

         .Columns(Entidades.TipoComprobante.Columnas.GrabaLibro.ToString()).FormatearColumna("Graba Libro", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.InformaLibroIVA.ToString()).FormatearColumna("Informa Libro IVA", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsComercial.ToString()).FormatearColumna("Es Comercial", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.LetrasHabilitadas.ToString()).FormatearColumna("Letras Habilitadas", pos, 80)

         .Columns(Entidades.TipoComprobante.Columnas.Imprime.ToString()).FormatearColumna("Imprime", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.CantidadMaximaItems.ToString()).FormatearColumna("Cant. Max. Items", pos, 60, HAlign.Right)
         .Columns(Entidades.TipoComprobante.Columnas.CantidadMaximaItemsObserv.ToString()).FormatearColumna("Cant. Max. Items Observ", pos, 60, HAlign.Right)
         .Columns(Entidades.TipoComprobante.Columnas.CantidadCopias.ToString()).FormatearColumna("Cantidad Copias", pos, 60, HAlign.Right)

         .Columns(Entidades.TipoComprobante.Columnas.EsFacturable.ToString()).FormatearColumna("Es Facturable", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsFacturador.ToString()).FormatearColumna("Es Facturador", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.ModificaAlFacturar.ToString()).FormatearColumna("Mod. al Facturar", pos, 100)

         .Columns(Entidades.TipoComprobante.Columnas.AfectaCaja.ToString()).FormatearColumna("Afecta Caja", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.ActualizaCtaCte.ToString()).FormatearColumna("Actualiza Cta Cte", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.UtilizaImpuestos.ToString()).FormatearColumna("Utiliza Impuestos", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.PermiteSeleccionarAlicuotaIVA.ToString()).FormatearColumna("Permite Seleccionar IVA", pos, 70, HAlign.Center)

         .Columns(Entidades.TipoComprobante.Columnas.CargaPrecioActual.ToString()).FormatearColumna("Carga Precio Actual", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.CargaDescRecActual.ToString()).FormatearColumna("Carga D/R Actual", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.CargaDescRecGralActual.ToString()).FormatearColumna("Carga D/R Gral. Actual", pos, 70, HAlign.Center)

         .Columns(Entidades.TipoComprobante.Columnas.DescripcionAbrev.ToString()).FormatearColumna("Descripcion Abrev", pos, 100)
         .Columns(Entidades.TipoComprobante.Columnas.DescripcionImpresion.ToString()).FormatearColumna("Descr. Impresión", pos, 200)
         .Columns("Grupo").FormatearColumna("Grupo", pos, 80)
         .Columns(Entidades.TipoComprobante.Columnas.ClaseComprobante.ToString()).FormatearColumna("Clase", pos, 80)

         .Columns(Entidades.TipoComprobante.Columnas.PuedeSerBorrado.ToString()).FormatearColumna("Puede ser Borrado", pos, 70, HAlign.Center)

         .Columns(Entidades.TipoComprobante.Columnas.ComprobantesAsociados.ToString()).FormatearColumna("Comprobantes Asociados", pos, 200)
         .Columns(Entidades.TipoComprobante.Columnas.IdTipoComprobanteSecundario.ToString()).FormatearColumna("Comprobante Secundario", pos, 150)

         .Columns(Entidades.TipoComprobante.Columnas.ImporteMinimo.ToString()).FormatearColumna("Importe Mínimo", pos, 80, HAlign.Right)
         .Columns(Entidades.TipoComprobante.Columnas.ImporteTope.ToString()).FormatearColumna("Importe Tope", pos, 80, HAlign.Right)

         .Columns("UsaFacturacion").FormatearColumna("Usa Facturación", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.UsaFacturacionRapida.ToString()).FormatearColumna("Usa Facturación Rápida", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.NumeracionAutomatica.ToString()).FormatearColumna("Numeración Automática", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsElectronico.ToString()).FormatearColumna("Es Electrónico", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsPreElectronico.ToString()).FormatearColumna("Es PreElectrónico", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsAnticipo.ToString()).FormatearColumna("Es Anticipo", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsRecibo.ToString()).FormatearColumna("Es Recibo", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsRemitoTransportista.ToString()).FormatearColumna("Es Remito Transportista", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsDespachoImportacion.ToString()).FormatearColumna("Es Despacho Importación", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.EsReciboClienteVinculado.ToString()).FormatearColumna("Es Recibo C. Vinculado", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.SolicitaFechaDevolucion.ToString()).FormatearColumna("Solicita Fecha de Devolución", pos, 70, HAlign.Center)


         .Columns(Entidades.TipoComprobante.Columnas.IdTipoComprobanteEpson.ToString()).FormatearColumna("Comprobante Epson", pos, 120, HAlign.Center)


         .Columns(Entidades.TipoComprobante.Columnas.GeneraObservConInvocados.ToString()).FormatearColumna("Genera Observ Con Invocados", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.ImportaObservDeInvocados.ToString()).FormatearColumna("Importa Observ De Invocados", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.ImportaObservGrales.ToString()).FormatearColumna("Importa Observ Generales", pos, 70, HAlign.Center)


         .Columns(Entidades.TipoComprobante.Columnas.IdTipoComprobanteNCred.ToString()).FormatearColumna("Comprobante N.Crédito", pos, 100)
         .Columns(Entidades.TipoComprobante.Columnas.IdTipoComprobanteNDeb.ToString()).FormatearColumna("Comprobante N.Débito", pos, 100)
         .Columns(Entidades.TipoComprobante.Columnas.IdProductoNCred.ToString()).FormatearColumna("Producto N.Crédito", pos, 100)
         .Columns(Entidades.TipoComprobante.Columnas.IdProductoNDeb.ToString()).FormatearColumna("Producto N.Débito", pos, 100)


         .Columns(Entidades.TipoComprobante.Columnas.ConsumePedidos.ToString()).FormatearColumna("Consume Pedidos", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AlInvocarPedidoAfectaFactura.ToString()).FormatearColumna("Pedido Afecta Factura", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AlInvocarPedidoAfectaRemito.ToString()).FormatearColumna("Pedido Afecta Remito", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.InvocarPedidosConEstadoEspecifico.ToString()).FormatearColumna("Pedido Estadi Específico", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.InvocaCompras.ToString()).FormatearColumna("Invoca Compras", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.MarcaInvocado.ToString()).FormatearColumna("Marca Invocado", pos, 70, HAlign.Center)


         .Columns(Entidades.TipoComprobante.Columnas.IncluirEnExpensas.ToString()).FormatearColumna("Incluir En Expensas", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.IdTipoComprobanteContraMovInvocar.ToString()).FormatearColumna("Contramovimiento al ser Invocado", pos, 100)

         .Columns(Entidades.TipoComprobante.Columnas.LargoMaximoNumero.ToString()).FormatearColumna("Largo Máximo Número", pos, 60, HAlign.Right)
         .Columns(Entidades.TipoComprobante.Columnas.RequiereReferenciaCtaCte.ToString()).FormatearColumna("Req. Referencia CtaCte", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.ControlaTopeConsumidorFinal.ToString()).FormatearColumna("Controla Tope Consumidor Final", pos, 70, HAlign.Center)


         .Columns(Entidades.TipoComprobante.Columnas.NivelAutorizacion.ToString()).FormatearColumna("Nivel de Autorización", pos, 60, HAlign.Right)

         .Columns(Entidades.TipoComprobante.Columnas.CodigoComprobanteSifere.ToString()).FormatearColumna("Código Sifere", pos, 80)

         .Columns(Entidades.TipoComprobante.Columnas.AFIPWSIncluyeFechaVencimiento.ToString()).FormatearColumna("AFIP Fecha Vencimiento", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AFIPWSEsFEC.ToString()).FormatearColumna("AFIP Es FEC MyPyme", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AFIPWSRequiereReferenciaComercial.ToString()).FormatearColumna("AFIP Ref. Comercial", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AFIPWSRequiereComprobanteAsociado.ToString()).FormatearColumna("AFIP Comprobante Asociado", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AFIPWSRequiereCBU.ToString()).FormatearColumna("AFIP Req. CBU", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AFIPWSCodigoAnulacion.ToString()).FormatearColumna("AFIP Código Anulación", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.AFIPWSRequiereReferenciaTransferencia.ToString()).FormatearColumna("AFIP Ref. Transferencia", pos, 70, HAlign.Center)


         .Columns(Entidades.TipoComprobante.Columnas.IdPlanCuenta.ToString()).FormatearColumna("Plan Cuenta", pos, 60, HAlign.Right)
         .Columns(Entidades.TipoComprobante.Columnas.GeneraContabilidad.ToString()).FormatearColumna("Genera Contabilidad", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.UtilizaCtaSecundariaProd.ToString()).FormatearColumna("Utiliza Cta Cble Sec. Prod", pos, 70, HAlign.Center)
         .Columns(Entidades.TipoComprobante.Columnas.UtilizaCtaSecundariaCateg.ToString()).FormatearColumna("Utiliza Cta Cble Sec. Categ", pos, 70, HAlign.Center)

         .Columns(Entidades.TipoComprobante.Columnas.EsPreFiscal.ToString()).OcultoPosicion(True, pos)

         If Not Reglas.Publicos.TieneModuloContabilidad Then
            .Columns(Entidades.TipoComprobante.Columnas.UtilizaCtaSecundariaProd.ToString()).Hidden = True
            .Columns(Entidades.TipoComprobante.Columnas.UtilizaCtaSecundariaCateg.ToString()).Hidden = True
         Else
            If Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaProducto Then
               .Columns(Entidades.TipoComprobante.Columnas.UtilizaCtaSecundariaProd.ToString()).Hidden = True
            End If
            If Not Reglas.ContabilidadPublicos.ContabilidadCuentaSecundariaCategoria Then
               .Columns(Entidades.TipoComprobante.Columnas.UtilizaCtaSecundariaCateg.ToString()).Hidden = True
            End If
         End If
         .Columns(Entidades.TipoComprobante.Columnas.SimulaPercepciones.ToString()).FormatearColumna("Simula Percepciones", pos, 70, HAlign.Center)

      End With
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      TryCatched(
         Sub()
            Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
            Dim colorColumnKey = Entidades.EstadoPedido.Columnas.Color.ToString()
            If dr IsNot Nothing Then
               Dim iColor = dr.Field(Of Integer?)(colorColumnKey)
               e.Row.Cells(colorColumnKey).Color(Nothing, If(iColor.HasValue, Color.FromArgb(iColor.Value), Nothing))
            End If
         End Sub)
   End Sub
#End Region

End Class
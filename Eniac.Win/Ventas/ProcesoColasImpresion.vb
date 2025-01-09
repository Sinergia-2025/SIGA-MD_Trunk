Public Class ProcesoColasImpresion
   Public Sub IniciarEjecucionCola(idColaImpresion As Integer)

      Dim rColaImprComp As Reglas.VentasColasImpresionComprobantes = New Reglas.VentasColasImpresionComprobantes()
      Dim colColaImprComp As List(Of Entidades.VentaColaImpresionComprobante) = rColaImprComp.GetTodos(idColaImpresion)
      Dim _fc As FacturacionComunes = New FacturacionComunes()

      For Each colaImprComp As Entidades.VentaColaImpresionComprobante In colColaImprComp
         Dim oVenta As Entidades.Venta = New Reglas.Ventas().GetUna(colaImprComp.IdSucursal,
                                                                    colaImprComp.IdTipoComprobante,
                                                                    colaImprComp.Letra,
                                                                    Convert.ToInt16(colaImprComp.CentroEmisor),
                                                                    colaImprComp.NumeroComprobante)
         Dim oTpCompSecundario As Entidades.TipoComprobante = New Reglas.TiposComprobantes().GetUno(oVenta.TipoComprobante.IdTipoComprobanteSecundario)
         If oVenta.TipoComprobante.EsPreFiscal AndAlso oTpCompSecundario.EsFiscal AndAlso oTpCompSecundario.GrabaLibro Then

            If _fc.ImprimirComprobante(oVenta, oTpCompSecundario.EsComercial) Then
               Try
                  Dim oFacturacion As Reglas.Ventas = New Reglas.Ventas()
                  oFacturacion.Insertar(oVenta, Entidades.Entidad.MetodoGrabacion.Automatico, "FacturacionV2")
               Catch ex As Exception
                  Throw ex
               End Try
            Else
               Throw New Exception("Error en la impresión Fiscal")
            End If
         End If
      Next

   End Sub
End Class

Public Class FacturacionComunes
   Inherits Reglas.FacturacionComunes
#Region "Campos"

   Private _ImpresionFiscal As ImpresionFiscal

#End Region

   Public Property ImpresionFiscal() As ImpresionFiscal
      Get
         Return Me._ImpresionFiscal
      End Get
      Set(ByVal value As ImpresionFiscal)
         Me._ImpresionFiscal = value
      End Set
   End Property

   'Por ahora se imprimirá Solo Fiscal
   Public Function ImprimirComprobante(ByVal Comprobante As Entidades.Venta, ByVal esFiscal As Boolean) As Boolean

      If esFiscal Then

         Dim oImpresion As Impresion
         Dim oEstadoImpresion As EstadoImpresion

         If Comprobante.Impresora.Metodo.Value <> Entidades.Impresora.MetodosFiscal.BATCH Then

            'Metodo nuevo de impresion
            If Comprobante.TipoComprobante.GrabaLibro Then
               If Comprobante.Impresora.ImprimirLineaALinea Then
                  Me._ImpresionFiscal.ImprimirFiscalPie(Comprobante)
               Else
                  If Comprobante.Impresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2 Then
                     Dim impf As ImpresionFiscalV2 = New ImpresionFiscalV2(Comprobante.Impresora)
                     impf.ImprimirFiscal(Comprobante)
                  Else
                     Dim impf As ImpresionFiscal = New ImpresionFiscal(Comprobante.Impresora.Modelo, Comprobante.Impresora.Puerto)
                     impf.ImprimirFiscal(Comprobante)
                  End If
               End If

               'Imprime Ticket no Fiscal si forma de pago es Cta Cte segun parametro
               If Reglas.Publicos.Facturacion.Impresion.FacturacionImprimeTicketNoFiscalCtaCte Then
                  'Valida si es Cta Cta
                  If Comprobante.FormaPago.Dias > 0 Then
                     Me.TicketNoFiscalResumenParaFirmar(Comprobante)
                  End If
               End If

            Else
               If Comprobante.Impresora.Metodo.Value = Entidades.Impresora.MetodosFiscal.DLLsV2 Then
                  Dim impf As ImpresionFiscalV2 = New ImpresionFiscalV2(Comprobante.Impresora)
                  impf.ImprimirNoFiscal(Comprobante)
               Else
                  Dim impf As ImpresionFiscal = New ImpresionFiscal(Comprobante.Impresora.Modelo, Comprobante.Impresora.Puerto)
                  impf.ImprimirNoFiscal(Comprobante)
               End If
            End If

            'Esto no deberia pasar, solo por las dudas.
            If Comprobante.NumeroComprobante = 0 Then
               MessageBox.Show("ATENCION: El Comprobante se generaria con Numeracion en Cero debido a Problemas de Comunicacion con la Fiscal, Por favor revise que no este bloqueada.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return False
            End If

         Else  'BATCH

            'Habilitado solo para DLLs
            If Not Comprobante.TipoComprobante.GrabaLibro Then
               MessageBox.Show("ATENCION: El Comprobante no puede ser emitido con esta configuracion, debe ser configurado Metodo DLLs, Por favor contáctese con sistemas.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return False
            End If

            If Comprobante.Impresora.Marca = "HASAR" Then

               'metodo nuevo de impresion
               'Dim impf As ImpresionFiscal = New ImpresionFiscal(LibreriaFiscal.ControladorFiscal.ModelosFiscales.HASAR_441, ventas.Impresora.Puerto)
               'impf.ImprimirFiscal(ventas)

               If Not My.Computer.FileSystem.FileExists(Entidades.Publicos.CarpetaEniac + "SPOOLER.EXE") Then
                  MsgBox("ATENCION: NO se encuentra el archivo " + Entidades.Publicos.CarpetaEniac + "SPOOLER.EXE" & Chr(13) & Chr(13) & "NO podrá imprimir con la FISCAL, por favor comuniquese con SISTEMAS.", MsgBoxStyle.Exclamation)
                  Return False
               End If

               oImpresion = New Impresion(Comprobante)
               oEstadoImpresion = oImpresion.Imprimir_HASAR()

            Else  'EPSON

               If Not My.Computer.FileSystem.FileExists(Entidades.Publicos.CarpetaEniac + "PFBATCH.EXE") Then
                  MsgBox("ATENCION: NO se encuentra el archivo " + Entidades.Publicos.CarpetaEniac + "PFBATCH.EXE" & Chr(13) & Chr(13) & "NO podrá imprimir con la FISCAL, por favor comuniquese con SISTEMAS.", MsgBoxStyle.Exclamation)
                  Return False
               End If

               oImpresion = New Impresion(Comprobante)
               oEstadoImpresion = oImpresion.Imprimir_EPSON()

            End If

            Comprobante.NumeroComprobante = oEstadoImpresion.NumeroComprobante

            'Diego: vuelvo esto hasta que modifiques los lanzamiento del error.
            'Compatibilidad del sistema viejo.
            If oEstadoImpresion.OK Then
               'Esto no deberia darse, pero hay un error dando vueltas y hay que acotarlo!
               If oEstadoImpresion.NumeroComprobante = 0 Then
                  MessageBox.Show("ATENCION: OK y Comprobante Cero." & Chr(13) & "--------------------------------" & Chr(13) & oEstadoImpresion.MensajeError, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Return False
               Else
                  Return True
               End If
            Else
               MessageBox.Show(oEstadoImpresion.MensajeError, "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return False
            End If

         End If

      Else 'si no es Fiscal

         Dim Facturacion As Reglas.Ventas = New Reglas.Ventas()
         Dim oComprobante As Entidades.Venta

         'Al imprimir tiene que tener las cantidadas ajustadas segun el Tipo de comprobante, luego se da vuelta.
         oComprobante = Facturacion.GetUna(Comprobante.IdSucursal, Comprobante.TipoComprobante.IdTipoComprobante,
                                          Comprobante.LetraComprobante,
                                          Comprobante.CentroEmisor,
                                          Comprobante.NumeroComprobante)
         '-- REQ-31325.- Se comenta por solicitad del requerimiento.- -------------------------------------------------------------------------------------------
         'CAE - agregado por Fact. Electronica
         'If Comprobante.TipoComprobante.EsElectronico Then
         '   If String.IsNullOrEmpty(oComprobante.AFIPCAE.CAE) Then
         '      MessageBox.Show("Este comprobante no se puede imprimir porque le falta el CAE.", "Impresión", MessageBoxButtons.OK, MessageBoxIcon.Information)
         '      Return False
         '   End If
         'End If
         '-------------------------------------------------------------------------------------------------------------------------------------------------------
         Dim oImpr As Impresion = New Impresion(oComprobante)
         oImpr.ImprimirComprobanteNoFiscal(Publicos.VisualizaComprobantesDeVenta)

         'If Publicos.RetieneIIBB And DirectCast(Comprobante.TipoComprobante, Entidades.TipoComprobante).EsComercial Then
         '   If oComprobante.Cliente.InscriptoIBStaFe Then
         'If oComprobante.Percepciones IsNot Nothing Then
         '   For Each perc As Entidades.PercepcionVenta In oComprobante.Percepciones
         '      If perc.ImporteTotal <> 0 Then
         '         Dim ret As PercepcionImprimir = New PercepcionImprimir()
         '         ret.ImprimirPercepcion(oComprobante, perc)
         '      End If
         '   Next
         'End If
         '   End If
         'End If

      End If

      Return True

   End Function

   Private Sub TicketNoFiscalResumenParaFirmar(Comprobante As Entidades.Venta)

      _ImpresionFiscal.AbrirComprobanteNoFiscal()

      _ImpresionFiscal.ImprimirTextoNoFiscal(Reglas.Publicos.NombreFantasia)
      _ImpresionFiscal.ImprimirTextoNoFiscal("C.U.I.T. Nro: " & Reglas.Publicos.CuitEmpresa)
      _ImpresionFiscal.ImprimirTextoNoFiscal("INGRESOS BRUTOS: " & Reglas.Publicos.IngresosBrutos)
      _ImpresionFiscal.ImprimirTextoNoFiscal(Reglas.Publicos.DireccionEmpresa)
      _ImpresionFiscal.ImprimirTextoNoFiscal(Reglas.Publicos.CategoriaFiscalEmpresaNombre)
      _ImpresionFiscal.ImprimirTextoNoFiscal("")
      _ImpresionFiscal.ImprimirTextoNoFiscal("Fecha: " & Comprobante.Fecha.ToString("dd/MM/yyyy"))
      _ImpresionFiscal.ImprimirTextoNoFiscal("Forma de Pago: " & Comprobante.FormaPago.DescripcionFormasPago)
      _ImpresionFiscal.ImprimirTextoNoFiscal("Nro. Comprobante: " & Comprobante.TipoComprobante.Descripcion.Trim() & "- '" & Comprobante.LetraComprobante & "' -" &
                                             Comprobante.CentroEmisor.ToString("0000") & "-" & Comprobante.NumeroComprobante.ToString("00000000"))
      _ImpresionFiscal.ImprimirTextoNoFiscal("Importe Total: " & Comprobante.ImporteTotal.ToString("##,##0.00"))
      _ImpresionFiscal.ImprimirTextoNoFiscal("")
      _ImpresionFiscal.ImprimirTextoNoFiscal("Cliente: " & Comprobante.Cliente.NombreCliente)
      _ImpresionFiscal.ImprimirTextoNoFiscal("C.U.I.T. Nro: " & Comprobante.Cliente.Cuit)
      _ImpresionFiscal.ImprimirTextoNoFiscal(Comprobante.Cliente.CategoriaFiscal.NombreCategoriaFiscal)
      _ImpresionFiscal.ImprimirTextoNoFiscal("")
      _ImpresionFiscal.ImprimirTextoNoFiscal("Firma: ____________________________________")
      _ImpresionFiscal.ImprimirTextoNoFiscal("")
      _ImpresionFiscal.ImprimirTextoNoFiscal("Aclaración: _______________________________")

      _ImpresionFiscal.CerrarComprobanteNoFiscal()

   End Sub

End Class

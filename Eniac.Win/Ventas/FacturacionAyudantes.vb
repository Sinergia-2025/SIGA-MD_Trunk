Public Class FacturacionAyudantes
   ''' <summary>
   ''' Determinar la letra fiscal para el comprobante según <see cref="Entidades.TipoComprobante">Tipo de Comprobante</see> y <see cref="Entidades.CategoriaFiscal">Categoría Fiscal</see> del cliente.
   ''' </summary>
   ''' <param name="tipoComprobante">Entidad del <see cref="Entidades.TipoComprobante">Tipo de Comprobante</see> que se va a emitir.</param>
   ''' <param name="categoriaFiscal">Entidad de la <see cref="Entidades.CategoriaFiscal">Categoría Fiscal</see> del Cliente.</param>
   ''' <returns>Letra para el comprobante a emitir.</returns>
   ''' <remarks>
   ''' Si hay solo una letra entre las letras habilitadas tomo esa. Por ejemplo: "X" en remitos y cotizaciones o "R" en remito de transporte.
   ''' Si la letra de la categoría fiscal está entre las letras del tipo de comprobante se toma la letra de la Categoría Fiscal.
   ''' En cualquier otro caso se devuelve String.Empty como valor por defecto indicando que no se pudo determinar un valor válido.
   ''' </remarks>
   Public Shared Function GetLetraParaComprobante(tipoComprobante As Entidades.TipoComprobante, categoriaFiscal As Entidades.CategoriaFiscal) As String
      Dim letra = String.Empty

      'Verifico que se haya pasado un tipo de comprobante. En caso de no haberlo pasado se pasa la letra en blanco.
      If tipoComprobante IsNot Nothing Then
         'Separo las letras habilitadas del tipo de comprobante por la coma (,) para poder trabajar más como con ellas.
         Dim letrasHabilitadas = tipoComprobante.LetrasHabilitadas.Split(","c)
         'Si hay solo una letra entre las letras habilitadas tomo esa. Por ejemplo: "X" en remitos y cotizaciones o "R" en remito de transporte.
         'En caso de que letras habilitadas esté en blanco "", el split devuelve un array con un solo elemento y el mismo está en blanco por lo que le pone "" como es por defecto.
         If letrasHabilitadas.Length = 1 Then
            letra = letrasHabilitadas(0)

            'Si suministré un categoría fiscal, y la letra de dicha categoría fiscal está entre las letras del tipo de comprobante se toma la letra de la Categoría Fiscal.
            'En caso no se suministre categoría o que la categoría tenga una letra que no está entre las habilitadas para el tipo de comprobante, se deja el valor por defecto ("").
         ElseIf categoriaFiscal IsNot Nothing AndAlso letrasHabilitadas.Contains(categoriaFiscal.LetraFiscal) Then
            letra = categoriaFiscal.LetraFiscal
         End If
      End If

      Return letra
   End Function

   ''' <summary>
   ''' Setea la letra del comprobante en el textbox de letra aplicando la lógica de colores si hay un error.
   ''' </summary>
   ''' <param name="txtLetra">Textbox donde se va a poner la letra.</param>
   ''' <param name="cmbTiposComprobantes">ComboBox de donde se va a tomar el Tipo de Comprobante seleccionado.</param>
   ''' <param name="cmbCategoriaFiscal">ComboBox de donde se va a tomar la Categoría Fiscal seleccionada.</param>
   ''' <remarks>
   ''' <para>1. Toma el Tipo de Comprobante y la Categoría Fiscal de los combos suministrados.</para>
   ''' <para>2. Utiliza la función <seealso cref="GetLetraParaComprobante"/> para determinar que letra corresponde.</para>
   ''' <para>3. Asigna dicha letra al TextBox de letra.</para>
   ''' <para>4. Si la letra está en blanco, entonces se resalta el textbox en rojo para hacer visible esta situación al usuario.</para>
   ''' </remarks>
   Public Shared Sub SetLetraParaComprobante(txtLetra As TextBox, cmbTiposComprobantes As ComboBox, cmbCategoriaFiscal As ComboBox)
      'Seteo la letra que corresponde usando la función GetLetraParaComprobante.
      txtLetra.Text = GetLetraParaComprobante(cmbTiposComprobantes.ItemSeleccionado(Of Entidades.TipoComprobante), cmbCategoriaFiscal.ItemSeleccionado(Of Entidades.CategoriaFiscal))
      'Si GetLetraParaComprobante me retorna la letra en blanco entonces resalto el control con color ya que habría un error.
      txtLetra.BackColor = If(String.IsNullOrWhiteSpace(txtLetra.Text), Color.Red, Nothing)
   End Sub


   Public Shared Function GetPrecio(precioVentaSinIVA As Decimal, precioVentaConIVA As Decimal,
                                    producto As Entidades.Producto, cliente As Entidades.Cliente, fechaComprobante As Date, ByRef _nroOferta As Integer,
                                    categoriaFiscalEmpresa As Entidades.CategoriaFiscal, codigoBarrasCompleto As String,
                                    cotizacionDolar As Decimal, modalidad As Entidades.Producto.Modalidades, valorRedondeo As Integer,
                                    FormaDePago As Entidades.VentaFormaPago) As Decimal
      Return GetPrecio(precioVentaSinIVA, precioVentaConIVA, producto, cliente, fechaComprobante, _nroOferta,
                       categoriaFiscalEmpresa, codigoBarrasCompleto, cotizacionDolar, modalidad, valorRedondeo,
                       obtienePrecioConIVA:=Nothing, FormaDePago)
   End Function
   Public Shared Function GetPrecio(precioVentaSinIVA As Decimal, precioVentaConIVA As Decimal,
                                    producto As Entidades.Producto, cliente As Entidades.Cliente, fechaComprobante As Date, ByRef _nroOferta As Integer,
                                    categoriaFiscalEmpresa As Entidades.CategoriaFiscal, codigoBarrasCompleto As String,
                                    cotizacionDolar As Decimal, modalidad As Entidades.Producto.Modalidades, valorRedondeo As Integer,
                                    obtienePrecioConIVA As Boolean?, FormaDePago As Entidades.VentaFormaPago) As Decimal
      '----------------------------------------------------------------------------------------------------------------------------------
      If FormaDePago IsNot Nothing AndAlso FormaDePago.AplicanOfertas Then


         Dim oferta = New Reglas.ProductosOfertas().GetOfertaVigente(fechaComprobante, producto.IdProducto, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)

         If oferta IsNot Nothing Then
            _nroOferta = oferta.IdOferta
            If Reglas.Publicos.PreciosConIVA Then
               precioVentaConIVA = oferta.PrecioOferta
               precioVentaSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(oferta.PrecioOferta, producto)
            Else
               precioVentaSinIVA = oferta.PrecioOferta
               precioVentaConIVA = Reglas.CalculosImpositivos.ObtenerPrecioConImpuestos(oferta.PrecioOferta, producto)
            End If
         End If
      End If
      '----------------------------------------------------------------------------------------------------------------------------------


      If producto.PrecioPorEmbalaje Then
         precioVentaSinIVA = precioVentaSinIVA / producto.Embalaje
         precioVentaConIVA = precioVentaConIVA / producto.Embalaje
      End If

      'Si el producto pertenece a una Marca que tiene lista de Precios especifica.. vuelvo a tomar los precios.

      Dim dt = New Reglas.ClientesMarcasListasDePrecios().GetUno(cliente.IdCliente, producto.IdMarca)
      If dt.Rows.Count = 1 Then
         Dim idListaDePrecio = dt.Rows(0).Field(Of Integer)("IdListaPrecios")

         dt = New Reglas.Productos().GetPorCodigo(producto.IdProducto, actual.Sucursal.Id, idListaDePrecio, "VENTAS")

         precioVentaSinIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaSinIVA").ToString())
         precioVentaConIVA = Decimal.Parse(dt.Rows(0)("PrecioVentaConIVA").ToString())

      End If
      '----------------------------------------------------------------------------------------------------------------------------------

      If producto.Moneda.IdMoneda = Entidades.Moneda.Dolar Then
         precioVentaSinIVA = Decimal.Round(precioVentaSinIVA * cotizacionDolar, valorRedondeo)
         precioVentaConIVA = Decimal.Round(precioVentaConIVA * cotizacionDolar, valorRedondeo)
      End If

      'Si leyo el Precio de la Etiqueta lo asigno.
      If modalidad = Entidades.Producto.Modalidades.PRECIO And (precioVentaConIVA = 0 Or Publicos.ProductoCodigoBarraPrecioRespetaEtiqueta) Then
         precioVentaConIVA = GetPrecioModalidadPrecio(codigoBarrasCompleto)
         precioVentaSinIVA = Reglas.CalculosImpositivos.ObtenerPrecioSinImpuestos(precioVentaConIVA, producto)
         'PrecioVentaSinIVA = Decimal.Round(PrecioVentaConIVA / (1 + Decimal.Parse(Me.cmbPorcentajeIva.Text) / 100), Me._valorRedondeo)
      End If

      If obtienePrecioConIVA.HasValue Then
         Return If(obtienePrecioConIVA.Value, precioVentaConIVA, precioVentaSinIVA)
      Else
         If (cliente.CategoriaFiscal.IvaDiscriminado And categoriaFiscalEmpresa.IvaDiscriminado) Or
             Not cliente.CategoriaFiscal.UtilizaImpuestos Or Not categoriaFiscalEmpresa.UtilizaImpuestos Then
            Return precioVentaSinIVA
         Else
            'comprobante sin discrimir y precio con IVA o comprobante discriminado con precio sin IVA
            Return precioVentaConIVA
         End If
      End If

   End Function

   Private Shared Function GetPrecioModalidadPrecio(codigoBarrasCompleto As String) As Decimal
      If codigoBarrasCompleto.Length = 13 Then
         Return codigoBarrasCompleto.Substring(Reglas.Publicos.CaracteresProductoCBPesoCantidad,
                                               12 - Reglas.Publicos.CaracteresProductoCBPesoCantidad).
                                     Insert(12 - Reglas.Publicos.CaracteresProductoCBPesoCantidad - 2, ".").ValorNumericoPorDefecto(0D)
         'Return codigoBarrasCompleto.Substring(7, 5).Insert(3, ".").ValorNumericoPorDefecto(0D)
      Else
         Return 0
      End If
   End Function

End Class
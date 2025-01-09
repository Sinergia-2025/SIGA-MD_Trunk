Partial Class Ventas
   Public Class CalculoPrecioCostoResult
      Public Property PrecioCosto As Decimal
      Public Property PrecioCostoSinIVA As Decimal
      Public Property PrecioCostoConIVA As Decimal

      Public Sub New(precioCosto As Decimal, precioCostoSinIVA As Decimal, precioCostoConIVA As Decimal)
         Me.PrecioCosto = precioCosto
         Me.PrecioCostoSinIVA = precioCostoSinIVA
         Me.PrecioCostoConIVA = precioCostoConIVA
      End Sub
   End Class
   Public Function CalculoPrecioCosto(idSucursal As Integer, producto As Entidades.Producto, lote As String,
                                      idDeposito As Integer, idUbicacion As Integer,
                                      cliente As Entidades.Cliente, tipoComprobante As Entidades.TipoComprobante,
                                      cotizacionDolar As Decimal,
                                      decimalesRedondeoEnPrecio As Integer) As CalculoPrecioCostoResult
      If producto.Lote AndAlso Publicos.UtilizaPrecioCostoPorLote Then
         Dim prodLote = New ProductosLotes(da)._GetUno(producto.IdProducto, lote, idSucursal, idDeposito, idUbicacion)
         If prodLote IsNot Nothing AndAlso prodLote.PrecioCosto <> 0 Then
            Dim precioCostoParaCalculo = prodLote.PrecioCosto
            Return CalculoPrecioCosto(producto, cliente,
                                      tipoComprobante, precioCostoParaCalculo,
                                      cotizacionDolar, decimalesRedondeoEnPrecio)
         End If
      End If
      Return Nothing
   End Function
   Public Function CalculoPrecioCosto(producto As Entidades.Producto,
                                      cliente As Entidades.Cliente, tipoComprobante As Entidades.TipoComprobante,
                                      precioCostoParaCalculo As Decimal,
                                      cotizacionDolar As Decimal,
                                      decimalesRedondeoEnPrecio As Integer) As CalculoPrecioCostoResult
      Dim precioCostoSinIVA = 0D
      Dim precioCostoConIVA = 0D

      My.Application.Log.WriteEntry(String.Format("1- Reglas.Ventas.CalculoPrecioCosto {0:dd/MM/yyyy HH:mm:ss.fff}", Date.Now), TraceEventType.Verbose)

      If Publicos.PreciosConIVA Then
         precioCostoConIVA = precioCostoParaCalculo
         precioCostoSinIVA = CalculosImpositivos.ObtenerPrecioSinImpuestos(precioCostoParaCalculo, producto)
      Else
         precioCostoConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(precioCostoParaCalculo, producto)
         precioCostoSinIVA = precioCostoParaCalculo
      End If

      '----------------------------------------------------------------------------------------------------------------------------------

      If producto.PrecioPorEmbalaje Then
         If producto.Embalaje = 0 Then
            Throw New Exception(String.Format("El producto {0} - {1} está configurado como Precio Por Embalaje, pero el Embalaje está configurado en cero.",
                                              producto.IdProducto, producto.NombreProducto))
         End If
         precioCostoSinIVA = precioCostoSinIVA / producto.Embalaje
         precioCostoConIVA = precioCostoConIVA / producto.Embalaje
      End If

      '------------------------------------------

      If Publicos.Facturacion.VentasPrecioCosto <> "ACTUAL" Then
         Dim splVentasCalculoCosto = Publicos.Facturacion.VentasPrecioCosto.Split(";"c)
         Dim otroPrecioCosto = 0D
         Select Case splVentasCalculoCosto(0).ToString()
            Case "PROMPOND"
               otroPrecioCosto = New ComprasProductos().GetCostoPromedioPonderado(
                                             actual.Sucursal.Id, producto.IdProducto,
                                             Date.Today.AddMonths(splVentasCalculoCosto(1).ValorNumericoPorDefecto(0I) * (-1)),
                                             Date.Today.UltimoSegundoDelDia(),
                                             decimalesRedondeoEnPrecio)
            Case Else
               Throw New Exception(String.Format("ATENCION: el sistema tiene configurado el Tipo de COSTO '{0}' (incorrecto), verifíquelo en Parametros.",
                                                 splVentasCalculoCosto(0)))
         End Select
         If otroPrecioCosto <> 0 Then
            precioCostoSinIVA = otroPrecioCosto
            precioCostoConIVA = CalculosImpositivos.ObtenerPrecioConImpuestos(otroPrecioCosto, producto)
         End If
      End If


      If producto.Moneda.IdMoneda = Entidades.Moneda.Dolar Then
         precioCostoSinIVA = Math.Round(precioCostoSinIVA * cotizacionDolar, decimalesRedondeoEnPrecio)
         precioCostoConIVA = Math.Round(precioCostoConIVA * cotizacionDolar, decimalesRedondeoEnPrecio)
      End If

      Dim precioCosto = 0D
      If (cliente.CategoriaFiscal.IvaDiscriminado And _categoriaFiscalEmpresa.IvaDiscriminado) Or
         Not cliente.CategoriaFiscal.UtilizaImpuestos Or Not _categoriaFiscalEmpresa.UtilizaImpuestos Or
         Not tipoComprobante.UtilizaImpuestos Then
         precioCosto = precioCostoSinIVA
      Else
         precioCosto = precioCostoConIVA
      End If

      My.Application.Log.WriteEntry(String.Format("1.1- Reglas.Ventas.CalculoPrecioCosto {0:dd/MM/yyyy HH:mm:ss.fff} - PrecioCosto: {1} - precioCostoSinIVA: {2} - precioCostoConIVA: {3}",
                                                  Date.Now, precioCosto, precioCostoSinIVA, precioCostoConIVA), TraceEventType.Verbose)

      Return New CalculoPrecioCostoResult(precioCosto, precioCostoSinIVA, precioCostoConIVA)

   End Function
End Class
#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports System.Text
#End Region
Public Class CalculosDescuentosRecargos
   Private Property Cache As BusquedasCacheadas
   Private Property ClienteDRporGrabaLibro As Boolean
   Private Property CalculaDescuentoRecargo2 As Boolean
   Public Sub New()
      Me.New(New BusquedasCacheadas())
   End Sub
   Public Sub New(cache As BusquedasCacheadas)
      Me.Cache = cache
      Me.ClienteDRporGrabaLibro = Publicos.ClienteDRporGrabaLibro
      Me.CalculaDescuentoRecargo2 = Not Reglas.Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual
   End Sub

   Public Function DescuentoRecargo(cliente As Entidades.Cliente, grabaLibro As Boolean, esPreElectronico As Boolean, formaPago As Entidades.VentaFormaPago,
                                    cantidadLineasVenta As Integer) As Decimal
      Dim descRec As Decimal = 0
      Dim cat As Entidades.Categoria = Cache.BuscaCategoria(cliente.IdCategoria)
      If cat IsNot Nothing Then
         descRec = cat.DescuentoRecargo
      End If

      If ClienteDRporGrabaLibro Then
         descRec = 0
         If grabaLibro Or esPreElectronico Then
            If cliente.DescuentoRecargoPorc <> 0 Then
               descRec = cliente.DescuentoRecargoPorc
            End If
         Else
            If cliente.DescuentoRecargoPorc2 <> 0 Then
               descRec = cliente.DescuentoRecargoPorc2
            End If
         End If
      Else
         If cliente.DescuentoRecargoPorc <> 0 Then
            descRec = cliente.DescuentoRecargoPorc
         End If
      End If

      If formaPago IsNot Nothing AndAlso formaPago.Porcentaje <> 0 Then
         descRec = CombinaDosDescuentos(descRec, formaPago.Porcentaje, 2)
      End If

      '#########################################################################
      '
      'Si el comprobante NO GRABA LIBRO
      If Not grabaLibro Then
         If Reglas.Publicos.CantidadLineasDeProductosAEvaluarParaDescRecarg > 0 Then
            If cantidadLineasVenta >= Reglas.Publicos.CantidadLineasDeProductosAEvaluarParaDescRecarg Then
               descRec = Reglas.Publicos.PorcentajeDeDescRecargPorLineaDeProducto
            End If
         End If
      End If
      '
      '#########################################################################

      Return descRec
   End Function

   Private Class DescuentoRecargoPorCantidadResult
      Public Property DescuentoRecargo As Decimal
      Public Property Origen As OrigenEnum
      Public Property Orden As Integer
      Public Sub New(descuentoRecargo As Decimal, origen As OrigenEnum, orden As Integer)
         Me.DescuentoRecargo = descuentoRecargo
         Me.Origen = origen
         Me.Orden = orden
      End Sub
      Public Enum OrigenEnum
         Producto
         Rubro
         SubRubro
      End Enum
   End Class
   Private Function DescuentoRecargoPorCantidad(cliente As Entidades.Cliente, drProducto As DataRow, cantidad As Decimal, rub As Entidades.Rubro, subRub As Entidades.SubRubro) As DescuentoRecargoPorCantidadResult
      '********************************************************************************
      'Si tiene al menos una cantidad en el Hasta1, entonces tomo el del producto.
      '********************************************************************************
      If drProducto.ValorNumericoPorDefecto("UnidHasta1", 0D) <> 0 Then
         Dim unidHasta5 As Decimal = drProducto.ValorNumericoPorDefecto("UnidHasta5", 0D)
         Dim unidHasta4 As Decimal = drProducto.ValorNumericoPorDefecto("UnidHasta4", 0D)
         Dim unidHasta3 As Decimal = drProducto.ValorNumericoPorDefecto("UnidHasta3", 0D)
         Dim unidHasta2 As Decimal = drProducto.ValorNumericoPorDefecto("UnidHasta2", 0D)
         Dim unidHasta1 As Decimal = drProducto.ValorNumericoPorDefecto("UnidHasta1", 0D)
         Dim UHPorc5 As Decimal = drProducto.ValorNumericoPorDefecto("UHPorc5", 0D)
         Dim UHPorc4 As Decimal = drProducto.ValorNumericoPorDefecto("UHPorc4", 0D)
         Dim UHPorc3 As Decimal = drProducto.ValorNumericoPorDefecto("UHPorc3", 0D)
         Dim UHPorc2 As Decimal = drProducto.ValorNumericoPorDefecto("UHPorc2", 0D)
         Dim UHPorc1 As Decimal = drProducto.ValorNumericoPorDefecto("UHPorc1", 0D)
         If unidHasta5 > 0 AndAlso cantidad >= unidHasta5 Then
            Return New DescuentoRecargoPorCantidadResult(UHPorc5, DescuentoRecargoPorCantidadResult.OrigenEnum.Producto, 5)
         ElseIf unidHasta4 > 0 AndAlso cantidad >= unidHasta4 Then
            Return New DescuentoRecargoPorCantidadResult(UHPorc4, DescuentoRecargoPorCantidadResult.OrigenEnum.Producto, 4)
         ElseIf unidHasta3 > 0 AndAlso cantidad >= unidHasta3 Then
            Return New DescuentoRecargoPorCantidadResult(UHPorc3, DescuentoRecargoPorCantidadResult.OrigenEnum.Producto, 3)
         ElseIf unidHasta2 > 0 AndAlso cantidad >= unidHasta2 Then
            Return New DescuentoRecargoPorCantidadResult(UHPorc2, DescuentoRecargoPorCantidadResult.OrigenEnum.Producto, 2)
         ElseIf cantidad >= unidHasta1 Then
            Return New DescuentoRecargoPorCantidadResult(UHPorc1, DescuentoRecargoPorCantidadResult.OrigenEnum.Producto, 1)
         End If         ' ElseIf cantidad >= producto.UnidHasta1 Then
      Else              ' If producto.UnidHasta1 <> 0 Then
         If subRub IsNot Nothing AndAlso subRub.UnidHasta1 <> 0 Then
            'Caso contrario tomo el del rubro. Si la cantidad 1 del Rubro es 0, no hay descuento.
            If subRub.UnidHasta5 <> 0 And cantidad >= subRub.UnidHasta5 Then
               Return New DescuentoRecargoPorCantidadResult(subRub.UHPorc5, DescuentoRecargoPorCantidadResult.OrigenEnum.SubRubro, 5)
            ElseIf subRub.UnidHasta4 <> 0 And cantidad >= subRub.UnidHasta4 Then
               Return New DescuentoRecargoPorCantidadResult(subRub.UHPorc4, DescuentoRecargoPorCantidadResult.OrigenEnum.SubRubro, 4)
            ElseIf subRub.UnidHasta3 <> 0 And cantidad >= subRub.UnidHasta3 Then
               Return New DescuentoRecargoPorCantidadResult(subRub.UHPorc3, DescuentoRecargoPorCantidadResult.OrigenEnum.SubRubro, 3)
            ElseIf subRub.UnidHasta2 <> 0 And cantidad >= subRub.UnidHasta2 Then
               Return New DescuentoRecargoPorCantidadResult(subRub.UHPorc2, DescuentoRecargoPorCantidadResult.OrigenEnum.SubRubro, 2)
            ElseIf cantidad >= subRub.UnidHasta1 Then
               Return New DescuentoRecargoPorCantidadResult(subRub.UHPorc1, DescuentoRecargoPorCantidadResult.OrigenEnum.SubRubro, 1)
            End If   ' ElseIf cantidad >= subRub.UnidHasta1 Then
         Else
            'Dim Rub As Entidades.Rubro = Cache.BuscaRubro(drProducto.ValorNumericoPorDefecto("IdRubro", 0I)) ' New Reglas.Rubros(da).GetUno(producto.IdRubro)
            If rub IsNot Nothing Then
               'Caso contrario tomo el del rubro. Si la cantidad 1 del Rubro es 0, no hay descuento.
               If rub.UnidHasta1 <> 0 Then
                  If rub.UnidHasta5 <> 0 And cantidad >= rub.UnidHasta5 Then
                     Return New DescuentoRecargoPorCantidadResult(rub.UHPorc5, DescuentoRecargoPorCantidadResult.OrigenEnum.Rubro, 5)
                  ElseIf rub.UnidHasta4 <> 0 And cantidad >= rub.UnidHasta4 Then
                     Return New DescuentoRecargoPorCantidadResult(rub.UHPorc4, DescuentoRecargoPorCantidadResult.OrigenEnum.Rubro, 4)
                  ElseIf rub.UnidHasta3 <> 0 And cantidad >= rub.UnidHasta3 Then
                     Return New DescuentoRecargoPorCantidadResult(rub.UHPorc3, DescuentoRecargoPorCantidadResult.OrigenEnum.Rubro, 3)
                  ElseIf rub.UnidHasta2 <> 0 And cantidad >= rub.UnidHasta2 Then
                     Return New DescuentoRecargoPorCantidadResult(rub.UHPorc2, DescuentoRecargoPorCantidadResult.OrigenEnum.Rubro, 2)
                  ElseIf cantidad >= rub.UnidHasta1 Then
                     Return New DescuentoRecargoPorCantidadResult(rub.UHPorc1, DescuentoRecargoPorCantidadResult.OrigenEnum.Rubro, 1)
                  End If   ' ElseIf cantidad >= Rub.UnidHasta1 Then
               End If      ' If Rub.UnidHasta1 <> 0 Then
            End If         ' If Rub IsNot Nothing Then
         End If            ' If subRub.UnidHasta1 <> 0 Then
      End If               ' If producto.UnidHasta1 <> 0 Then
      Return New DescuentoRecargoPorCantidadResult(0, DescuentoRecargoPorCantidadResult.OrigenEnum.Producto, 0)
   End Function

   Public Function DescuentoRecargo(cliente As Entidades.Cliente, drProducto As DataRow, cantidad As Decimal, decimalesRedondeoEnPrecio As Integer) As DescuentoRecargoProducto
      My.Application.Log.WriteEntry("Inicia DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Dim descRecr As DescuentoRecargoProducto = New DescuentoRecargoProducto()
      If drProducto Is Nothing Then Return descRecr

      Dim siTieneDescRecPorCantidadIgnoraOtros As Boolean = Reglas.Publicos.SiTieneDescRecPorCantidadIgnoraOtros

      My.Application.Log.WriteEntry("0.1. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Dim subRub As Entidades.SubRubro = Cache.BuscaSubRubroEntidad(drProducto.ValorNumericoPorDefecto("IdSubRubro", 0I))

      My.Application.Log.WriteEntry("0.2. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Dim rub As Entidades.Rubro = Cache.BuscaRubro(drProducto.ValorNumericoPorDefecto("IdRubro", 0I)) ' New Reglas.Rubros(da).GetUno(producto.IdRubro)

      My.Application.Log.WriteEntry("0.3. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Dim descRecPorCantidad As DescuentoRecargoPorCantidadResult = DescuentoRecargoPorCantidad(cliente, drProducto, cantidad, rub, subRub)

      My.Application.Log.WriteEntry("1. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      If Not siTieneDescRecPorCantidadIgnoraOtros Or descRecPorCantidad.DescuentoRecargo = 0 Then
         '*****************************************************************************************
         'Si el producto tiene descuento/recargo (DescRecProducto) lo cargo en el primer descuento.
         '*****************************************************************************************
         If drProducto.ValorNumericoPorDefecto("DescRecProducto", 0D) <> 0 Then
            descRecr.DescuentoRecargo1 = drProducto.ValorNumericoPorDefecto("DescRecProducto", 0D)
         End If

         My.Application.Log.WriteEntry("2. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '********************************************************************************
         'Cargo el Descuento/Recargo cargado en el subrubro
         '********************************************************************************
         If drProducto.ValorNumericoPorDefecto("IdSubRubro", 0I) > 0 Then
            'Dim SubRub As Entidades.SubRubro = Cache.BuscaSubRubroEntidad(drProducto.ValorNumericoPorDefecto("IdSubRubro", 0I)) ' New Reglas.SubRubros(da).GetUno(producto.IdSubRubro)
            If subRub IsNot Nothing Then
               If subRub.DescuentoRecargoPorc1 <> 0 Then
                  If descRecr.DescuentoRecargo1 = 0 Then
                     descRecr.DescuentoRecargo1 = subRub.DescuentoRecargoPorc1
                  ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                     descRecr.DescuentoRecargo2 = subRub.DescuentoRecargoPorc1
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el Sub Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                       subRub.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, subRub.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
                  End If
               End If
               If subRub.DescuentoRecargoPorc2 <> 0 Then
                  If CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                     descRecr.DescuentoRecargo2 = subRub.DescuentoRecargoPorc2
                  Else
                     If CalculaDescuentoRecargo2 Then
                        descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para el Sub Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 2.",
                                                          subRub.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                        descRecr.DescuentoRecargo2 = CombinaDosDescuentos(descRecr.DescuentoRecargo2, subRub.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                     Else
                        descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para el Sub Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                  subRub.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                        descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, subRub.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                     End If
                  End If
               End If
            End If
            '********************************************************************************
            'Cargo el Descuento/Recargo cargado en el subrubro especifico para el Cliente
            '********************************************************************************
            Dim SubR2 As Entidades.ClienteDescuentoSubRubro = Cache.BuscaClientesDescuentosSubRubros(cliente.IdCliente, drProducto.ValorNumericoPorDefecto("IdSubRubro", 0I)) ' New Reglas.ClientesDescuentosSubRubros(da).GetUno(cliente.IdCliente, producto.IdSubRubro)
            If SubR2 IsNot Nothing Then
               If CalculaDescuentoRecargo2 Then
                  descRecr.DescuentoRecargo2 = SubR2.DescuentoRecargo
               Else
                  If descRecr.DescuentoRecargo1 = 0 Then
                     descRecr.DescuentoRecargo1 = SubR2.DescuentoRecargo
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el Sub Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                       SubR2.DescuentoRecargo, descRecr.DescuentoRecargo1))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, SubR2.DescuentoRecargo, decimalesRedondeoEnPrecio)
                  End If
               End If
            End If
         End If

         My.Application.Log.WriteEntry("3. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         Dim rubro As Entidades.Rubro = Cache.BuscaRubro(drProducto.ValorNumericoPorDefecto("IdRubro", 0I))
         If drProducto.ValorNumericoPorDefecto("IdRubro", 0I) <> 0 AndAlso rubro IsNot Nothing Then
            If rubro.DescuentoRecargoPorc1 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = rubro.DescuentoRecargoPorc1
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = rubro.DescuentoRecargoPorc1
               Else
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    rubro.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, rubro.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
               End If
            End If
            If rubro.DescuentoRecargoPorc2 <> 0 Then
               If CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = rubro.DescuentoRecargoPorc2
               Else
                  If CalculaDescuentoRecargo2 Then
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para el Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 2.",
                                                       rubro.DescuentoRecargoPorc1, descRecr.DescuentoRecargo2))
                     descRecr.DescuentoRecargo2 = CombinaDosDescuentos(descRecr.DescuentoRecargo2, rubro.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para el Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                               rubro.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, rubro.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  End If
               End If
            End If

         End If
         My.Application.Log.WriteEntry("4. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '********************************************************************************
         'Cargo el Descuento/Recargo 1 cargado en el rubro para del cliente
         '********************************************************************************
         Dim rubClte As Entidades.ClienteDescuentoRubro = Cache.BuscaClientesDescuentosRubros(cliente.IdCliente, drProducto.ValorNumericoPorDefecto("IdRubro", 0I)) ' New Reglas.ClientesDescuentosRubros(da).GetUno(cliente.IdCliente, producto.IdRubro, False)
         If rubClte IsNot Nothing Then   'Si es Nothing no encontró el la combinación
            If rubClte.DescuentoRecargoPorc1 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = rubClte.DescuentoRecargoPorc1
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = rubClte.DescuentoRecargoPorc1
               Else
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    rubClte.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, rubClte.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
               End If
            End If
            If rubClte.DescuentoRecargoPorc2 <> 0 Then
               If Not CalculaDescuentoRecargo2 Then
                  If descRecr.DescuentoRecargo2 = 0 Then
                     descRecr.DescuentoRecargo2 = rubClte.DescuentoRecargoPorc2
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para el Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                       rubClte.DescuentoRecargoPorc2, descRecr.DescuentoRecargo2))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo2, rubClte.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  End If
               Else
                  If descRecr.DescuentoRecargo1 = 0 Then
                     descRecr.DescuentoRecargo1 = rubClte.DescuentoRecargoPorc2
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                       rubClte.DescuentoRecargoPorc2, descRecr.DescuentoRecargo2))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo2, rubClte.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  End If
               End If
            End If
         End If
         My.Application.Log.WriteEntry("4. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '********************************************************************************
         'Cargo el Descuento/Recargo 1 cargado en la marca para del cliente
         '********************************************************************************
         Dim marcClte As Entidades.ClienteDescuentoMarca = Cache.BuscaClientesDescuentosMarcas(cliente.IdCliente, drProducto.ValorNumericoPorDefecto("IdMarca", 0I)) ' New Reglas.ClientesDescuentosMarcas(da).GetUno(cliente.IdCliente, producto.IdMarca)
         If marcClte IsNot Nothing Then
            If marcClte.DescuentoRecargoPorc1 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = marcClte.DescuentoRecargoPorc1
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = marcClte.DescuentoRecargoPorc1
               Else
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para la Marca de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    marcClte.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, marcClte.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
               End If
            End If
            '********************************************************************************
            'Cargo el Descuento/Recargo 2 cargado en la marca para el cliente
            '********************************************************************************
            If marcClte.DescuentoRecargoPorc2 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = marcClte.DescuentoRecargoPorc2
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = marcClte.DescuentoRecargoPorc2
               Else
                  If CalculaDescuentoRecargo2 Then
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para la Marca de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 2.",
                                                       marcClte.DescuentoRecargoPorc2, descRecr.DescuentoRecargo2))
                     descRecr.DescuentoRecargo2 = CombinaDosDescuentos(descRecr.DescuentoRecargo2, marcClte.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para la Marca de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                       marcClte.DescuentoRecargoPorc2, descRecr.DescuentoRecargo1))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, marcClte.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  End If
               End If
            End If
         End If
         My.Application.Log.WriteEntry("5. Marcas.DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '********************************************************************************
         'Cargo el Descuento/Recargo 1 cargado en la marca
         '********************************************************************************
         Dim marc = Cache.BuscaMarca(drProducto.ValorNumericoPorDefecto("IdMarca", 0I))
         If marc IsNot Nothing Then
            If marc.DescuentoRecargoPorc1 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = marc.DescuentoRecargoPorc1
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = marc.DescuentoRecargoPorc1
               Else
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para la Marca de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    marc.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, marc.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
               End If
            End If
            '********************************************************************************
            'Cargo el Descuento/Recargo 2 cargado en la marca
            '********************************************************************************
            If marc.DescuentoRecargoPorc2 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = marc.DescuentoRecargoPorc2
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = marc.DescuentoRecargoPorc2
               Else
                  If CalculaDescuentoRecargo2 Then
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para la Marca de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 2.",
                                                       marc.DescuentoRecargoPorc2, descRecr.DescuentoRecargo2))
                     descRecr.DescuentoRecargo2 = CombinaDosDescuentos(descRecr.DescuentoRecargo2, marc.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para la Marca de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                       marc.DescuentoRecargoPorc2, descRecr.DescuentoRecargo1))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, marc.DescuentoRecargoPorc2, decimalesRedondeoEnPrecio)
                  End If
               End If
            End If
         End If
         My.Application.Log.WriteEntry("6. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '***********************************************************************************************************************
         Dim drDescRecProdCol As DataRow() = Cache.BuscaClientesDescuentosProductos(cliente.IdCliente, drProducto("IdProducto").ToString().Trim()) ' New Reglas.ClientesDescuentosProductos(da).GetUno(cliente.IdCliente, producto.IdProducto)
         If drDescRecProdCol.Length > 0 Then
            If Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc1").ToString()) <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc1").ToString())
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc1").ToString())
               Else
                  'Unifico los porcentajes 
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para la Producto de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc1").ToString()), descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc1").ToString()), decimalesRedondeoEnPrecio)
               End If
            End If

            If Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc2").ToString()) <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc2").ToString())
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc2").ToString())
               Else
                  'Unifico los porcentajes 
                  If CalculaDescuentoRecargo2 Then
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para la Producto de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 2.",
                                                       Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc1").ToString()), descRecr.DescuentoRecargo2))
                     descRecr.DescuentoRecargo2 = CombinaDosDescuentos(descRecr.DescuentoRecargo2, Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc2").ToString()), decimalesRedondeoEnPrecio)
                  Else
                     descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Cliente para la Producto de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                       Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc1").ToString()), descRecr.DescuentoRecargo1))
                     descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, Decimal.Parse(drDescRecProdCol(0)("DescuentoRecargoPorc2").ToString()), decimalesRedondeoEnPrecio)
                  End If
               End If
            End If
         End If
         My.Application.Log.WriteEntry("7. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '***********************************************************************************
         'Cargo el Descuento/Recargo cargado en CategoriasDescuentos "Rubros" para el Cliente
         '***********************************************************************************
         Dim rubCat As Entidades.CategoriasDescuentosRubros = Cache.BuscaCategoriasDescuentosRubros(cliente.IdCategoria, drProducto.ValorNumericoPorDefecto("IdRubro", 0I))
         If rubCat IsNot Nothing Then   'Si es Nothing no encontró el la combinación
            If rubCat.DescuentoRecargoPorc1 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = rubCat.DescuentoRecargoPorc1
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = rubCat.DescuentoRecargoPorc1
               Else
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el Rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    rubCat.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, rubCat.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
               End If
            End If
         End If
         My.Application.Log.WriteEntry("8. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '***************************************************************************************
         'Cargo el Descuento/Recargo cargado en CategoriasDescuentos "SubRubros" para el Cliente
         '***************************************************************************************
         Dim subRubCat As Entidades.CategoriasDescuentosSubRubros = Cache.BuscaCategoriasDescuentosSubRubros(cliente.IdCategoria, drProducto.ValorNumericoPorDefecto("IdRubro", 0I), drProducto.ValorNumericoPorDefecto("IdSubRubro", 0I))
         If subRubCat IsNot Nothing Then
            If subRubCat.DescuentoRecargoPorc1 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = subRubCat.DescuentoRecargoPorc1
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = subRubCat.DescuentoRecargoPorc1
               Else
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el SubRubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    subRubCat.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, subRubCat.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
               End If
            End If
         End If
         My.Application.Log.WriteEntry("9. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         '***************************************************************************************
         'Cargo el Descuento/Recargo cargado en CategoriasDescuentos "SubSubRubros" para el Cliente
         '***************************************************************************************
         Dim subSubRubCat As Entidades.CategoriasDescuentosSubSubRubros = Cache.BuscaCategoriasDescuentosSubSubRubros(cliente.IdCategoria, drProducto.ValorNumericoPorDefecto("IdRubro", 0I), drProducto.ValorNumericoPorDefecto("IdSubRubro", 0I), drProducto.ValorNumericoPorDefecto("IdSubSubRubro", 0I))
         If subSubRubCat IsNot Nothing Then
            If subSubRubCat.DescuentoRecargoPorc1 <> 0 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = subSubRubCat.DescuentoRecargoPorc1
               ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = subSubRubCat.DescuentoRecargoPorc1
               Else
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Cliente para el SubSubRubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    subSubRubCat.DescuentoRecargoPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, subSubRubCat.DescuentoRecargoPorc1, decimalesRedondeoEnPrecio)
               End If
            End If
         End If
      End If

      If drProducto("TipoBonificacion").ToString() <> Entidades.Producto.TiposBonificacionesProductos.LISTAPRECIO.ToString() Then

         My.Application.Log.WriteEntry("10. DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)
         If descRecPorCantidad.DescuentoRecargo <> 0 Then
            If descRecr.DescuentoRecargo1 = 0 Then
               descRecr.DescuentoRecargo1 = descRecPorCantidad.DescuentoRecargo
            ElseIf CalculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
               descRecr.DescuentoRecargo2 = descRecPorCantidad.DescuentoRecargo
            Else
               'Unifico los porcentajes 
               descRecr.AppendLine(String.Format("ATENCION: El Descuento {2} del {3} para la cantidad de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                              descRecPorCantidad.DescuentoRecargo, descRecr.DescuentoRecargo1, descRecPorCantidad.Origen, descRecPorCantidad.Origen.ToString()))
               descRecr.DescuentoRecargo1 = CombinaDosDescuentos(descRecr.DescuentoRecargo1, descRecPorCantidad.DescuentoRecargo, decimalesRedondeoEnPrecio)
            End If
         End If

      End If

      My.Application.Log.WriteEntry("Finaliza DescuentoRecargo " + Now.ToString("dd/MM/yyyy HH:mm:ss.fff"), TraceEventType.Verbose)

      Return descRecr
   End Function

   Public Function DescuentoRecargo(idCliente As Long, idProducto As String, cantidad As Decimal, decimalesRedondeoEnPrecio As Integer) As DescuentoRecargoProducto
      Return DescuentoRecargo(Cache.BuscaClientePorIdEntidad(idCliente), idProducto, cantidad, decimalesRedondeoEnPrecio)
   End Function

   Public Function DescuentoRecargo(cliente As Entidades.Cliente, idProducto As String, cantidad As Decimal, decimalesRedondeoEnPrecio As Integer) As DescuentoRecargoProducto
      Return DescuentoRecargo(cliente, Cache.BuscaProductoPorId(idProducto), cantidad, decimalesRedondeoEnPrecio)
   End Function


   Public Shared Function CombinaDosDescuentos(descuento1 As Decimal, descuento2 As Decimal, decimalesRedondeoEnPrecio As Integer) As Decimal
      Dim desc1 As Decimal = (100 + descuento1) / 100
      Dim desc2 As Decimal = (100 + descuento2) / 100
      Return Decimal.Round(((desc1 * desc2) - 1) * 100, decimalesRedondeoEnPrecio)
   End Function


   Public Function GetPreciosConDescuentos(precio As Decimal, descuentoGeneral As Decimal, descuento1 As Decimal, descuento2 As Decimal, factorConversion As Decimal) As Decimal
      precio = precio + (precio * descuentoGeneral / 100)
      precio = precio + (precio * descuento1 / 100)
      precio = precio + (precio * descuento2 / 100)

      Return Decimal.Round(precio * factorConversion, 2)
   End Function

End Class
Public Class DescuentoRecargoProducto
   Private _descuentoRecargo1 As Decimal
   Public Property DescuentoRecargo1() As Decimal
      Get
         Return _descuentoRecargo1
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargo1 = value
      End Set
   End Property
   Private _descuentoRecargo2 As Decimal
   Public Property DescuentoRecargo2() As Decimal
      Get
         Return _descuentoRecargo2
      End Get
      Set(ByVal value As Decimal)
         _descuentoRecargo2 = value
      End Set
   End Property
   Private _mensaje As StringBuilder
   Public ReadOnly Property Mensaje() As String
      Get
         If _mensaje Is Nothing Then Return ""
         Return _mensaje.ToString()
      End Get
   End Property
   Public Sub AppendLine(value As String)
      If _mensaje Is Nothing Then _mensaje = New StringBuilder()
      _mensaje.AppendLine(value)
   End Sub
End Class
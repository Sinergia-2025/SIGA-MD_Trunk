#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports Eniac.Entidades
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
#End Region
Partial Class Ventas

   '' DESCUENTOS Y RECARGOS

   Public Function ReciboPorcentajeDescuentoRecargo(tipoRecibo As Entidades.TipoComprobante, idCategoria As Integer, fechaComprobante As DateTime, fechaVencimiento As DateTime, fechaRecibo As DateTime, importeTotal As Decimal, saldo As Decimal) As Decimal
      Dim porcInteres As Decimal = 0
      Dim blnConexionAbierta As Boolean = da.Connection Is Nothing OrElse da.Connection.State = ConnectionState.Open
      Try
         If Not blnConexionAbierta Then
            Me.da.OpenConection()
         End If

         Dim categoria As Categoria = _cache.BuscaCategoria(idCategoria) ' New Categorias(da).GetUno(idCategoria)

         Dim reglaIntereses As Reglas.Intereses = New Reglas.Intereses(da)
         Dim intereses As Interes
         If categoria.IdInteres > 0 Then
            intereses = reglaIntereses.GetUno(categoria.IdInteres)
         Else
            intereses = New Interes()
         End If

         If intereses.InteresesDias.Count > 0 AndAlso
            tipoRecibo.ImporteTope > 0 AndAlso saldo > 0 AndAlso
            (Not fechaComprobante.Date.Equals(fechaRecibo.Date) Or intereses.InteresesDias(0).Interes < 0) AndAlso
            (Not Reglas.Publicos.CtaCte.InteresesCalculoCompletoPrimerPago Or importeTotal = saldo) Then

            Dim interesesMetodoParaDeterminarRango As String = intereses.MetodoParaDeterminarRango ' Publicos.InteresesMetodoParaDeterminarRango

            Select Case interesesMetodoParaDeterminarRango
               Case Entidades.InteresesMetodoParaDeterminarRangoEnum.DIAMES.ToString()
                  porcInteres = ReciboPorcentajeDescuentoRecargoPorDiaMes(fechaComprobante, fechaRecibo, intereses)

               Case Entidades.InteresesMetodoParaDeterminarRangoEnum.DIAMESVENCIMIENTO.ToString()
                  porcInteres = ReciboPorcentajeDescuentoRecargoPorDiaMes(fechaVencimiento, fechaRecibo, intereses)

               Case Entidades.InteresesMetodoParaDeterminarRangoEnum.DIASCORRIDOSEMISION.ToString()
                  porcInteres = ReciboPorcentajeDescuentoRecargoPorDiasCorridos(fechaComprobante, fechaRecibo, intereses)

               Case Entidades.InteresesMetodoParaDeterminarRangoEnum.DIASCORRIDOSVENCIMIENTO.ToString()
                  porcInteres = ReciboPorcentajeDescuentoRecargoPorDiasCorridos(fechaVencimiento, fechaRecibo, intereses)

               Case Else
                  Throw New ArgumentOutOfRangeException("InteresesMetodoParaDeterminarRango",
                                                        interesesMetodoParaDeterminarRango,
                                                        "El valor de 'Intereses toma desde/hasta como' no es válido o no se encuentra implementado.")
            End Select
         End If
      Finally
         If Not blnConexionAbierta Then
            Me.da.CloseConection()
         End If
      End Try

      Return porcInteres
   End Function

   Private Function ReciboPorcentajeDescuentoRecargoPorDiaMes(fechaComprobante As DateTime, fechaRecibo As DateTime, intereses As Interes) As Decimal
      Dim porcInteres As Decimal = 0

      If Not intereses.UtilizaVigencia OrElse (fechaComprobante >= intereses.FechaVigenciaDesde.Value.Date AndAlso fechaComprobante <= intereses.FechaVigenciaHasta.Value.UltimoSegundoDelDia()) Then '-.PE-32072.-


         Dim porcAdicional As Decimal = intereses.AdicionalProporcinalDias
         Dim ultimoInteres As InteresDias
         Dim diaUltimoInteres As DateTime = fechaComprobante

         If intereses.InteresesDias.Count > 0 Then
            ultimoInteres = intereses.InteresesDias.Last()
            diaUltimoInteres = New Date(fechaComprobante.Year, fechaComprobante.Month, Math.Min(ultimoInteres.DiasHasta, fechaComprobante.UltimoDiaMes.Day))
         Else
            ultimoInteres = New InteresDias()
         End If

         If diaUltimoInteres < fechaRecibo Then
            Dim diasTranscurridos As Integer = Convert.ToInt32(Math.Truncate((fechaRecibo - diaUltimoInteres).TotalDays))
            porcInteres = ultimoInteres.Interes + (porcAdicional * diasTranscurridos / 30)
         Else
            For Each interes As InteresDias In intereses.InteresesDias

               If interes.DiasDesde <= fechaRecibo.Day And interes.DiasHasta >= fechaRecibo.Day Then
                  porcInteres = interes.Interes
               End If
            Next
         End If
      End If

      Return porcInteres
   End Function

   Private Function ReciboPorcentajeDescuentoRecargoPorDiasCorridos(fechaComprobante As DateTime, fechaRecibo As DateTime, intereses As Interes) As Decimal
      Dim porcInteres As Decimal = 0
      Dim porcAdicional As Decimal = intereses.AdicionalProporcinalDias

      Dim alguno As Boolean = False
      For Each interes As InteresDias In intereses.InteresesDias
         If fechaComprobante.Date.AddDays(interes.DiasDesde) <= fechaRecibo.Date And fechaComprobante.Date.AddDays(interes.DiasHasta) >= fechaRecibo.Date Then
            porcInteres = interes.Interes
            alguno = True
         End If
      Next

      If Not alguno Then
         If fechaComprobante.Date < fechaRecibo.Date Then
            Dim ultimoInteres As InteresDias
            Dim diaUltimoInteres As DateTime = fechaComprobante

            If intereses.InteresesDias.Count > 0 Then
               ultimoInteres = intereses.InteresesDias.Last()
               diaUltimoInteres = fechaComprobante.Date.AddDays(ultimoInteres.DiasHasta)
            Else
               ultimoInteres = New InteresDias()
            End If
            Dim diasTranscurridos As Integer = Convert.ToInt32(Math.Truncate((fechaRecibo - diaUltimoInteres).TotalDays))

            If fechaComprobante.Date <= fechaRecibo.Date Then
               porcInteres = ultimoInteres.Interes + (porcAdicional * diasTranscurridos / 30)
            Else
               porcInteres = 0
            End If
         End If

      End If
      Return porcInteres
   End Function

#Region "Descuentos y Recargos"

   <Obsolete("Usar New CalculosDescuentosRecargos().DescuentoRecargo")>
   Public Function DescuentoRecargo(cliente As Cliente, tipoComprobante As TipoComprobante, formaPago As Entidades.VentaFormaPago,
                                    cantidadLineasVenta As Integer) As Decimal
      If cliente Is Nothing Or tipoComprobante Is Nothing Then Return 0

      Return New CalculosDescuentosRecargos().DescuentoRecargo(cliente, tipoComprobante.GrabaLibro, tipoComprobante.EsPreElectronico, formaPago,
                                                               cantidadLineasVenta)
   End Function

   <Obsolete("Usar CalculosDescuentosRecargos().DescuentoRecargo")>
   Public Function DescuentoRecargo(cliente As Cliente, producto As Producto, cantidad As Decimal, Optional decimalesRedondeoEnPrecio As Integer = 2) As DescuentoRecargoProducto
      Return DirectCast(New CalculosDescuentosRecargos().DescuentoRecargo(cliente, producto.IdProducto, cantidad, decimalesRedondeoEnPrecio), DescuentoRecargoProducto)
   End Function

   Public Function DescuentoRecargoSoloCantidadAgrupadaRubro(cliente As Cliente, producto As Producto, cantidad As Decimal, Optional decimalesRedondeoEnPrecio As Integer = 2) As DescuentoRecargoProducto
      Dim descRecr As DescuentoRecargoProducto = New DescuentoRecargoProducto()
      If producto Is Nothing Then Return descRecr

      Dim calculaDescuentoRecargo2 As Boolean = Not Publicos.Facturacion.FacturacionDescuentoRecargo2CargaManual

      Dim blnAbreConexcion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         If blnAbreConexcion Then da.OpenConection()

         Dim Rub As Entidades.Rubro = New Reglas.Rubros(da).GetUno(producto.IdRubro)

         'Caso contrario tomo el del rubro. Si la cantidad 1 del Rubro es 0, no hay descuento.
         If Rub.UnidHasta1 <> 0 Then

            If Rub.UnidHasta5 <> 0 And cantidad >= Rub.UnidHasta5 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = Rub.UHPorc5
               ElseIf calculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = Rub.UHPorc5
               Else
                  'Unifico los porcentajes 
                  Dim desc1 As Decimal = (100 + descRecr.DescuentoRecargo1) / 100
                  Dim desc2 As Decimal = (100 + Rub.UHPorc5) / 100
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 5 del Rubro para la cantidad segun rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    Rub.UHPorc5, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = Decimal.Round(((desc1 * desc2) - 1) * 100, decimalesRedondeoEnPrecio)
               End If
            ElseIf Rub.UnidHasta4 <> 0 And cantidad >= Rub.UnidHasta4 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = Rub.UHPorc4
               ElseIf calculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = Rub.UHPorc4
               Else
                  'Unifico los porcentajes 
                  Dim desc1 As Decimal = (100 + descRecr.DescuentoRecargo1) / 100
                  Dim desc2 As Decimal = (100 + Rub.UHPorc4) / 100
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 4 del Rubro para la cantidad segun rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    Rub.UHPorc4, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = Decimal.Round(((desc1 * desc2) - 1) * 100, decimalesRedondeoEnPrecio)
               End If
            ElseIf Rub.UnidHasta3 <> 0 And cantidad >= Rub.UnidHasta3 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = Rub.UHPorc3
               ElseIf calculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = Rub.UHPorc3
               Else
                  'Unifico los porcentajes 
                  Dim desc1 As Decimal = (100 + descRecr.DescuentoRecargo1) / 100
                  Dim desc2 As Decimal = (100 + Rub.UHPorc3) / 100
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 3 del Rubro para la cantidad segun rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    Rub.UHPorc3, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = Decimal.Round(((desc1 * desc2) - 1) * 100, decimalesRedondeoEnPrecio)
               End If
            ElseIf Rub.UnidHasta2 <> 0 And cantidad >= Rub.UnidHasta2 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = Rub.UHPorc2
               ElseIf calculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = Rub.UHPorc2
               Else
                  'Unifico los porcentajes 
                  Dim desc1 As Decimal = (100 + descRecr.DescuentoRecargo1) / 100
                  Dim desc2 As Decimal = (100 + Rub.UHPorc2) / 100
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 2 del Rubro para la cantidad segun rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    Rub.UHPorc2, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = Decimal.Round(((desc1 * desc2) - 1) * 100, decimalesRedondeoEnPrecio)
               End If
            ElseIf cantidad >= Rub.UnidHasta1 Then
               If descRecr.DescuentoRecargo1 = 0 Then
                  descRecr.DescuentoRecargo1 = Rub.UHPorc1
               ElseIf calculaDescuentoRecargo2 And descRecr.DescuentoRecargo2 = 0 Then
                  descRecr.DescuentoRecargo2 = Rub.UHPorc1
               Else
                  'Unifico los porcentajes 
                  Dim desc1 As Decimal = (100 + descRecr.DescuentoRecargo1) / 100
                  Dim desc2 As Decimal = (100 + Rub.UHPorc1) / 100
                  descRecr.AppendLine(String.Format("ATENCION: El Descuento 1 del Rubro para la cantidad segun rubro de {0:N2}%, fue sumado al descuento {1:N2}% en la Posicion 1.",
                                                    Rub.UHPorc1, descRecr.DescuentoRecargo1))
                  descRecr.DescuentoRecargo1 = Decimal.Round(((desc1 * desc2) - 1) * 100, decimalesRedondeoEnPrecio)
               End If
            End If      ' ElseIf cantidad >= Rub.UnidHasta1 Then
         End If         ' If Rub.UnidHasta1 <> 0 Then

         Return descRecr
      Finally
         If blnAbreConexcion Then da.CloseConection()
      End Try
   End Function

   'Public Class DescuentoRecargoProducto
   '   Inherits Reglas.DescuentoRecargoProducto
   '   'Private _descuentoRecargo1 As Decimal
   '   'Public Property DescuentoRecargo1() As Decimal
   '   '   Get
   '   '      Return _descuentoRecargo1
   '   '   End Get
   '   '   Set(ByVal value As Decimal)
   '   '      _descuentoRecargo1 = value
   '   '   End Set
   '   'End Property
   '   'Private _descuentoRecargo2 As Decimal
   '   'Public Property DescuentoRecargo2() As Decimal
   '   '   Get
   '   '      Return _descuentoRecargo2
   '   '   End Get
   '   '   Set(ByVal value As Decimal)
   '   '      _descuentoRecargo2 = value
   '   '   End Set
   '   'End Property
   '   'Private _mensaje As StringBuilder
   '   'Public ReadOnly Property Mensaje() As String
   '   '   Get
   '   '      If _mensaje Is Nothing Then Return ""
   '   '      Return _mensaje.ToString()
   '   '   End Get
   '   'End Property
   '   'Public Sub AppendLine(value As String)
   '   '   If _mensaje Is Nothing Then _mensaje = New StringBuilder()
   '   '   _mensaje.AppendLine(value)
   '   'End Sub
   'End Class

   Public Function GetDescuentoCantidad(idProducto As String) As DescuentoRecargoPorCantidad
      Dim producto As Producto
      Try
         producto = New Productos().GetUno(idProducto, False, False)
      Catch ex As Exception
         producto = Nothing
      End Try
      Return GetDescuentoCantidad(producto)
   End Function

   Public Function GetDescuentoCantidad(producto As Producto) As DescuentoRecargoPorCantidad

      If producto Is Nothing Then Return Nothing

      If Not Publicos.Facturacion.FacturacionDescuentosAgrupaCantidadesPorRubro AndAlso producto.UnidHasta1 <> 0 Then

         Return New DescuentoRecargoPorCantidad(producto.UnidHasta1, producto.UHPorc1,
                                                producto.UnidHasta2, producto.UHPorc2,
                                                producto.UnidHasta3, producto.UHPorc3,
                                                producto.UnidHasta4, producto.UHPorc4,
                                                producto.UnidHasta5, producto.UHPorc5)
      Else

         If producto.IdSubRubro > 0 Then

            Dim SubRubro As Entidades.SubRubro = New Reglas.SubRubros().GetUno(producto.IdSubRubro)

            If SubRubro.UnidHasta1 <> 0 Then

               Return New DescuentoRecargoPorCantidad(SubRubro.UnidHasta1, SubRubro.UHPorc1,
                                       SubRubro.UnidHasta2, SubRubro.UHPorc2,
                                       SubRubro.UnidHasta3, SubRubro.UHPorc3,
                                       SubRubro.UnidHasta4, SubRubro.UHPorc4,
                                       SubRubro.UnidHasta5, SubRubro.UHPorc5)

               Exit Function

            End If

         End If

         Dim rubro As Entidades.Rubro = New Reglas.Rubros().GetUno(producto.IdRubro)
         Return New DescuentoRecargoPorCantidad(rubro.UnidHasta1, rubro.UHPorc1,
                                                rubro.UnidHasta2, rubro.UHPorc2,
                                                rubro.UnidHasta3, rubro.UHPorc3,
                                                rubro.UnidHasta4, rubro.UHPorc4,
                                                rubro.UnidHasta5, rubro.UHPorc5)
      End If
   End Function

   Public Class DescuentoRecargoPorCantidad
      Public Property UnidHasta1 As Decimal
      Public Property UHPorc1 As Decimal
      Public Property UnidHasta2 As Decimal
      Public Property UHPorc2 As Decimal
      Public Property UnidHasta3 As Decimal
      Public Property UHPorc3 As Decimal
      Public Property UnidHasta4 As Decimal
      Public Property UHPorc4 As Decimal
      Public Property UnidHasta5 As Decimal
      Public Property UHPorc5 As Decimal

      Public Sub New()
      End Sub
      Public Sub New(unidHasta1 As Decimal, uhPorc1 As Decimal, unidHasta2 As Decimal, uhPorc2 As Decimal, unidHasta3 As Decimal, uhPorc3 As Decimal,
                     unidHasta4 As Decimal, uhPorc4 As Decimal, unidHasta5 As Decimal, uhPorc5 As Decimal)
         Me.New()

         Me.UnidHasta1 = unidHasta1
         Me.UHPorc1 = uhPorc1
         Me.UnidHasta2 = unidHasta2
         Me.UHPorc2 = uhPorc2
         Me.UnidHasta3 = unidHasta3
         Me.UHPorc3 = uhPorc3
         Me.UnidHasta4 = unidHasta4
         Me.UHPorc4 = uhPorc4
         Me.UnidHasta5 = unidHasta5
         Me.UHPorc5 = uhPorc5
      End Sub
   End Class

#End Region

End Class
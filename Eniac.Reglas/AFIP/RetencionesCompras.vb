Public Class RetencionesCompras
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "RetencionesCompras"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.RetencionesCompras = New SqlServer.RetencionesCompras(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RetencionesCompras(Me.da).RetencionesCompras_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Friend Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Dim en As Entidades.RetencionCompra = DirectCast(entidad, Entidades.RetencionCompra)

      Dim sql As SqlServer.RetencionesCompras = New SqlServer.RetencionesCompras(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.RetencionesCompras_I(en.IdSucursal,
                              en.TipoImpuesto.IdTipoImpuesto.ToString(),
                              en.EmisorRetencion,
                              en.NumeroRetencion,
                              en.Proveedor.IdProveedor,
                              en.FechaEmision,
                              en.BaseImponible, en.Alicuota, en.ImporteTotal,
                              en.Caja.IdCaja, en.NroPlanillaEgreso, en.NroMovimientoEgreso,
                              en.IdEstado,
                              en.Regimen.IdRegimen,
                              en.AjusteManual, en.BaseImponibleCalculada, en.ImporteTotalCalculado)

         Case TipoSP._U
            sql.RetencionesCompras_U(en.IdSucursal,
                              en.TipoImpuesto.IdTipoImpuesto.ToString(),
                              en.EmisorRetencion,
                              en.NumeroRetencion,
                              en.Proveedor.IdProveedor,
                              en.FechaEmision,
                              en.BaseImponible, en.Alicuota, en.ImporteTotal,
                              en.Caja.IdCaja, en.NroPlanillaEgreso, en.NroMovimientoEgreso,
                              en.IdEstado,
                              en.Regimen.IdRegimen,
                              en.AjusteManual, en.BaseImponibleCalculada, en.ImporteTotalCalculado)

         Case TipoSP._D
            sql.RetencionesCompras_D(en.IdSucursal, en.TipoImpuesto.IdTipoImpuesto.ToString(),
                                     en.EmisorRetencion, en.NumeroRetencion,
                                     en.Proveedor.IdProveedor)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.RetencionCompra, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())

         .TipoImpuesto = New Reglas.TiposImpuestos(da)._GetUno(DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), dr("IdTipoImpuesto").ToString()), Entidades.TipoImpuesto.Tipos))
         .EmisorRetencion = Integer.Parse(dr("EmisorRetencion").ToString())
         .NumeroRetencion = Long.Parse(dr("NumeroRetencion").ToString())
         .FechaEmision = Date.Parse(dr("FechaEmision").ToString())

         .BaseImponible = Decimal.Parse(dr("BaseImponible").ToString())
         .Alicuota = Decimal.Parse(dr("Alicuota").ToString())
         .ImporteTotal = Decimal.Parse(dr("ImporteTotal").ToString())

         If Not String.IsNullOrEmpty(dr("NroPlanillaEgreso").ToString()) Then
            .NroPlanillaEgreso = Integer.Parse(dr("NroPlanillaEgreso").ToString())
            .NroMovimientoEgreso = Integer.Parse(dr("NroMovimientoEgreso").ToString())
         Else
            .NroPlanillaEgreso = 0
            .NroMovimientoEgreso = 0
         End If

         If Not String.IsNullOrEmpty(dr("IdProveedor").ToString()) Then
            .Proveedor = New Reglas.Proveedores(Me.da)._GetUno(Long.Parse(dr("IdProveedor").ToString()))
         End If

         .IdEstado = DirectCast([Enum].Parse(GetType(Entidades.Retencion.Estados), dr("IdEstado").ToString()), Entidades.Retencion.Estados)

         If Not String.IsNullOrEmpty(dr("IdRegimen").ToString()) Then
            .Regimen = New Reglas.Regimenes(Me.da)._GetUno(Int32.Parse(dr("IdRegimen").ToString()))
         End If

         .AjusteManual = dr.Field(Of Boolean)("AjusteManual")
         .BaseImponibleCalculada = dr.Field(Of Decimal)("BaseImponibleCalculada")
         .ImporteTotalCalculado = dr.Field(Of Decimal)("ImporteTotalCalculado")

      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.RetencionCompra)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim dt As DataTable = Me.GetAll()
         Dim o As Entidades.RetencionCompra
         Dim oLis As List(Of Entidades.RetencionCompra) = New List(Of Entidades.RetencionCompra)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.RetencionCompra()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Me.da.CommitTransaction()
         Return oLis

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(IdSucursal As Integer,
                                     IdTipoImpuesto As String,
                                     EmisorRetencion As Integer,
                                     NumeroRetencion As Long,
                                     IdProveedor As Long) As Entidades.RetencionCompra
      Try
         Me.da.OpenConection()

         Return Me._GetUno(IdSucursal, IdTipoImpuesto, EmisorRetencion, NumeroRetencion, IdProveedor)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(IdSucursal As Integer,
                                     IdTipoImpuesto As String,
                                     EmisorRetencion As Integer,
                                     NumeroRetencion As Long,
                                     IdProveedor As Long) As Entidades.RetencionCompra

      Dim sql As SqlServer.RetencionesCompras = New SqlServer.RetencionesCompras(Me.da)

      Dim dt As DataTable = sql.RetencionesCompras_G1(IdSucursal, IdTipoImpuesto, EmisorRetencion, NumeroRetencion, IdProveedor)

      Dim o As Entidades.RetencionCompra = New Entidades.RetencionCompra()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la RetencionCompra.")
      End If

      Return o

   End Function

   Public Function GetPorCuentaCorriente(idSucursal As Integer,
                                          idTipoComprobante As String,
                                          letra As String,
                                          centroEmisor As Integer,
                                          numeroComprobante As Long,
                                          IdProveedor As Long) As List(Of Entidades.RetencionCompra)

      Dim sql As SqlServer.RetencionesCompras = New SqlServer.RetencionesCompras(Me.da)

      Dim dt As DataTable

      dt = sql.GetPorCuentaCorrienteProv(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, IdProveedor)

      Dim o As Entidades.RetencionCompra

      Dim oLis As List(Of Entidades.RetencionCompra) = New List(Of Entidades.RetencionCompra)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.RetencionCompra()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis

   End Function

   Public Function GetRetencionesCalculadas(ctacteProv As Entidades.CuentaCorrienteProv,
                                            importeAnticipo As Decimal,
                                            regimenGan As Entidades.Regimen,
                                            regimenIVA As Entidades.Regimen,
                                            regimenIIBB As Entidades.Regimen,
                                            regimenIIBBC As Entidades.Regimen) As List(Of Entidades.RetencionCompra)
      Return EjecutaConConexion(Function() _GetRetencionesCalculadas(ctacteProv, importeAnticipo, regimenGan, regimenIVA, regimenIIBB, regimenIIBBC))
   End Function

   Private Function _GetRetencionesCalculadas(ctacteProv As Entidades.CuentaCorrienteProv,
                                              importeAnticipo As Decimal,
                                              regimenGan As Entidades.Regimen,
                                              regimenIVA As Entidades.Regimen,
                                              regimenIIBB As Entidades.Regimen,
                                              regimenIIBBC As Entidades.Regimen) As List(Of Entidades.RetencionCompra)
      Dim rt = New List(Of Entidades.RetencionCompra)()
      If ctacteProv.Proveedor.EsPasibleRetencion Then

         GetRetencionesGANACalculadas(ctacteProv, importeAnticipo, rt, regimenGan)
         'If Not Publicos.CtaCteProv.RetencionesGananciasCalculoRecursivo Then
         '   GetRetencionesGANACalculadas(ctacteProv, importeAnticipo, rt, regimenGan)
         'Else
         '   Dim rGana As Entidades.RetencionCompra = Nothing
         '   Dim anticipoRecursivo = importeAnticipo
         '   For i = 1 To Publicos.CtaCteProv.RetencionesGananciasCalculoRecursivoCantidadRepeticiones
         '      rGana = GetRetencionesGANACalculadas(ctacteProv, anticipoRecursivo, rt, regimenGan)
         '      If rGana IsNot Nothing Then
         '         rt.Remove(rGana)
         '         anticipoRecursivo = importeAnticipo - rGana.ImporteTotal
         '      End If
         '   Next
         '   If rGana IsNot Nothing Then
         '      rt.Add(rGana)
         '   End If
         'End If
      End If
      If ctacteProv.Proveedor.EsPasibleRetencionIVA Then
         GetRetencionesIVACalculadas(ctacteProv, rt, regimenIVA)
      End If
      If ctacteProv.Proveedor.EsPasibleRetencionIIBB Then
         GetRetencionesIIBBCalculadas(ctacteProv, rt, regimenIIBB)
      End If
      If ctacteProv.Proveedor.RegimenIIBBComplem.IdRegimen > 0 Then
         GetRetencionesIIBCCalculadas(ctacteProv, rt, regimenIIBBC)
      End If

      Return rt
   End Function

   Private Function GetRetencionesGANACalculadas(ctacteProv As Entidades.CuentaCorrienteProv, importeAnticipo As Decimal, rt As List(Of Entidades.RetencionCompra), regimen As Entidades.Regimen) As Entidades.RetencionCompra
      Dim fechaOrigen = ctacteProv.Fecha.PrimerDiaMes()
      Dim fechaFin = ctacteProv.Fecha.UltimoDiaMes(ultimoSegundo:=True)

      'obtengo los pagos hechos al proveedor
      Dim dtPagos As DataTable
      Dim sqlCtaCtePagos As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(Me.da)

      dtPagos = sqlCtaCtePagos.GetPagos(ctacteProv.Proveedor.IdProveedor, fechaOrigen, fechaFin)

      Dim pagoTotal As Decimal = 0
      Dim porcentajeIVA As Decimal = 0
      Dim pIVA As Decimal = 1
      Dim compro As Entidades.Compra
      Dim regComp As Reglas.Compras = New Reglas.Compras(Me.da)

      Dim ndebcheqrechcom As String() = Publicos.IdNotaDebitoChequeRechazadoCompra.Split(","c)

      'sumo los pagos que se van a realizar actualmente + los anteriores
      For Each dr As DataRow In dtPagos.Rows
         If Not ndebcheqrechcom.Contains(dr("IdTipoComprobante2").ToString()) Then
            If Not String.IsNullOrEmpty(dr("PorcentajeIVA").ToString()) Then
               'pIVA = (Decimal.Parse(dr("PorcentajeIVA").ToString()) / 100) + 1
               pIVA = dr.Field(Of Decimal?)("ImporteTotal").IfNull() / dr.Field(Of Decimal?)("TotalNeto").IfNull()
            Else
               pIVA = (Publicos.ProductoIVA / 100) + 1
            End If
            pagoTotal += Decimal.Round(Decimal.Parse(dr("ImporteCuota").ToString()) / pIVA, 2) * -1
         End If
      Next

      Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()

      For Each ct As Entidades.CuentaCorrienteProvPago In ctacteProv.Pagos
         If Not ndebcheqrechcom.Contains(ct.IdTipoComprobante) Then

            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(ct.IdTipoComprobante)

            'Si Aplico un ANTICIPO o un Comprobante Directo en CtaCte no encuentra y lanza un Throw, cortando el proceso.
            If regComp.Existe(ct.IdSucursal, ctacteProv.Proveedor.IdProveedor,
                              ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante) Then


               compro = regComp.GetUna(ct.IdSucursal, ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante, ctacteProv.Proveedor.IdProveedor)

               'Solo contemplo los comprobantes en Blanco.
               If compro.TipoComprobante.GrabaLibro Then
                  Dim totalNeto As Decimal = compro.TotalNeto

                  If totalNeto <> 0 Then
                     pIVA = (compro.ImporteTotal) / (totalNeto) ''(compro.PorcentajeIVA / 100) + 1
                  End If
                  pagoTotal += Decimal.Round(ct.Paga / pIVA, 2)
               End If
            ElseIf oTipoComprobante.EsAnticipo Then

               '   ElseIf ct.IdTipoComprobante = "ANTICIPO" Then

               ''Deberia Analizar el Recibo que lo genero, pero es un quilombo!!!
               'pIVA = (Publicos.ProductoIVA / 100) + 1
               'pagoTotal += Decimal.Round(ct.Paga / pIVA, 2)

            ElseIf ct.TipoComprobante.GrabaLibro Then

               pIVA = (Publicos.ProductoIVA / 100) + 1
               pagoTotal += Decimal.Round(ct.Paga / pIVA, 2)

            End If

            'Lo unico que queda afuera son los comprobantes en Negro.
         End If

      Next

      If importeAnticipo <> 0 Then
         pIVA = (Publicos.ProductoIVA / 100) + 1
         pagoTotal += Decimal.Round(importeAnticipo / pIVA, 2)
      End If

      'recupero todas las retenciones que se le hizo al proveedor durante ese mes
      Dim retencionesBaseImponible As Decimal = 0
      Dim retencionesAplicadas As Decimal = 0
      Dim retapl As DataTable = New SqlServer.CuentasCorrientesProvRetenciones(Me.da).GetRetencionesPorFechaProveedor(fechaOrigen, fechaFin, ctacteProv.Proveedor.IdProveedor)

      For Each dr As DataRow In retapl.Select("IdTipoImpuesto = 'RGANA'")
         retencionesBaseImponible += Decimal.Parse(dr("BaseImponible").ToString())
         'Quedo sin uso
         retencionesAplicadas += Decimal.Parse(dr("ImporteTotal").ToString())
         '---------------------
      Next

      If regimen Is Nothing Then regimen = ctacteProv.Proveedor.Regimen

      'Controlo si retiene por escalas o no
      If regimen.RetienePorEscala Then

         'realizo los calculos y creo la retencion
         Dim rete As Entidades.RetencionCompra

         'si creo la retencion de ganancias
         rete = New Entidades.RetencionCompra()

         With rete
            'cargo una retencion de ganancias
            .IdSucursal = ctacteProv.IdSucursal
            .EmisorRetencion = ctacteProv.CentroEmisor
            .TipoImpuesto = regimen.TipoImpuesto   '' New Reglas.TiposImpuestos(Me.da).GetUno(Entidades.TipoImpuesto.Tipos.RGANA)
            .Regimen = regimen
            .Proveedor = ctacteProv.Proveedor
            'La numeracion es unica para todos
            '.NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion, .Proveedor.IdProveedor)
            .NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion)
            .FechaEmision = ctacteProv.Fecha

            Dim oescalas As Reglas.EscalasRetGanancias = New Reglas.EscalasRetGanancias()
            Dim escalas As DataTable = oescalas.GetAll()
            pagoTotal = pagoTotal - regimen.MontoAExceder - retencionesBaseImponible

            For Each dr As DataRow In escalas.Rows
               If pagoTotal >= Decimal.Parse(dr("MontoMasDe").ToString()) And pagoTotal <= Decimal.Parse(dr("MontoA").ToString()) Then
                  .BaseImponible = pagoTotal '- Decimal.Parse(dr("SobreExcedente").ToString())
                  .Alicuota = Decimal.Parse(dr("MasPorcentaje").ToString())
                  .ImporteTotal = Decimal.Round((.BaseImponible - dr.ValorNumericoPorDefecto("SobreExcedente", 0D)) * .Alicuota / 100, 2) + Decimal.Parse(dr("Importe").ToString())

                  '# Guardo lo calculado por el sistema
                  .BaseImponibleCalculada = .BaseImponible
                  .ImporteTotalCalculado = .ImporteTotal
                  Exit For
               End If
            Next

            .Proveedor = ctacteProv.Proveedor
            .IdEstado = Entidades.Retencion.Estados.APLICADO
         End With
         rt.Add(rete)
         Return rete

      Else

         'controlo el Regimen del proveedor para realizar los calculos
         If pagoTotal > regimen.MontoAExceder Then

            'realizo los calculos y creo la retencion
            Dim rete As Entidades.RetencionCompra

            'si creo la retencion de ganancias
            rete = New Entidades.RetencionCompra()

            With rete
               'cargo una retencion de ganancias
               .IdSucursal = ctacteProv.IdSucursal
               .EmisorRetencion = ctacteProv.CentroEmisor
               .TipoImpuesto = regimen.TipoImpuesto   '' New Reglas.TiposImpuestos(Me.da).GetUno(Entidades.TipoImpuesto.Tipos.RGANA)
               .Regimen = regimen
               .Proveedor = ctacteProv.Proveedor
               'La numeracion es unica para todos
               '.NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion, .Proveedor.IdProveedor)
               .NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion)
               .FechaEmision = ctacteProv.Fecha
               .BaseImponible = pagoTotal - regimen.MinimoNoImponible - retencionesBaseImponible
               .Alicuota = regimen.ARetenerInscripto
               .ImporteTotal = Decimal.Round(.BaseImponible * .Alicuota / 100, 2)
               .Proveedor = ctacteProv.Proveedor
               .IdEstado = Entidades.Retencion.Estados.APLICADO

               '# Guardo lo calculado por el sistema
               .BaseImponibleCalculada = .BaseImponible
               .ImporteTotalCalculado = .ImporteTotal
            End With

            'en primera instancia cargo la tetencion
            Dim cargaRT As Boolean = True

            'si la categoria dle proveedor esta inscripto valido una cosa sino otra
            If rete.Proveedor.CategoriaFiscal.IvaDiscriminado Then
               If regimen.ImporteMinimoInscripto > rete.ImporteTotal Then
                  cargaRT = False
               End If
            Else 'no esta inscripto en este caso
               If regimen.ImporteMinimoNoInscripto > rete.ImporteTotal Then
                  cargaRT = False
               End If
            End If

            '
            If cargaRT Then
               rt.Add(rete)
               Return rete
            End If

         End If
      End If

      Return Nothing

   End Function

   Private Sub GetRetencionesIVACalculadas(ctacteProv As Entidades.CuentaCorrienteProv, ByRef rt As List(Of Entidades.RetencionCompra), regimen As Entidades.Regimen)
      'As List(Of Entidades.RetencionCompra)
      ' ''Try
      ' ''   Me.da.OpenConection()

      ' ''   Dim rt As List(Of Entidades.RetencionCompra) = New List(Of Entidades.RetencionCompra)()
      'Dim fechaOrigen As DateTime = New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1, 0, 0, 0)
      'Dim fechaFin As DateTime = New DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month), 23, 59, 59)

      '' ''Dim fechaOrigen As DateTime = New DateTime(ctacteProv.Fecha.Year, ctacteProv.Fecha.Month, 1, 0, 0, 0)
      '' ''Dim fechaFin As DateTime = New DateTime(ctacteProv.Fecha.Year, ctacteProv.Fecha.Month, DateTime.DaysInMonth(ctacteProv.Fecha.Year, ctacteProv.Fecha.Month), 23, 59, 59)

      'obtengo los pagos hechos al proveedor
      '' ''Dim dtPagos As DataTable
      Dim sqlCtaCtePagos As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(Me.da)

      '' ''dtPagos = sqlCtaCtePagos.GetPagos(ctacteProv.Proveedor.IdProveedor, fechaOrigen, fechaFin)

      Dim pagoTotal As Decimal = 0
      Dim porcentajeIVA As Decimal = 0
      Dim pIVA As Decimal = 1
      Dim compro As Entidades.Compra
      Dim regComp As Reglas.Compras = New Reglas.Compras(Me.da)

      'sumo los pagos que se van a realizar actualmente + los anteriores
      '' ''For Each dr As DataRow In dtPagos.Rows
      '' ''   If Not String.IsNullOrEmpty(dr("PorcentajeIVA").ToString()) Then
      '' ''      pIVA = (Decimal.Parse(dr("PorcentajeIVA").ToString()) / 100) + 1
      '' ''   End If
      '' ''   pagoTotal += Decimal.Round(Decimal.Parse(dr("ImporteCuota").ToString()) / pIVA, 2) * -1
      '' ''Next

      Dim ndebcheqrechcom As String() = Publicos.IdNotaDebitoChequeRechazadoCompra.Split(","c)
      Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()

      For Each ct As Entidades.CuentaCorrienteProvPago In ctacteProv.Pagos
         If Not ndebcheqrechcom.Contains(ct.IdTipoComprobante) Then

            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(ct.IdTipoComprobante)

            'Si Aplico un ANTICIPO o un Comprobante Directo en CtaCte no encuentra y lanza un Throw, cortando el proceso.
            If regComp.Existe(ct.IdSucursal, ctacteProv.Proveedor.IdProveedor,
                              ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante) Then


               compro = regComp.GetUna(ct.IdSucursal, ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante, ctacteProv.Proveedor.IdProveedor)

               'Solo contemplo los comprobantes en Blanco.
               If compro.TipoComprobante.GrabaLibro Then
                  pIVA = (compro.ImporteTotal) / (compro.TotalNeto) ''(compro.PorcentajeIVA / 100) + 1
                  pagoTotal += Decimal.Round(ct.Paga / pIVA, 2)
               End If
            ElseIf oTipoComprobante.EsAnticipo Then
               '    ElseIf ct.IdTipoComprobante = "ANTICIPO" Then

               'Deberia Analizar el Recibo que lo genero, pero es un quilombo!!!
               pIVA = (Publicos.ProductoIVA / 100) + 1
               pagoTotal += Decimal.Round(ct.Paga / pIVA, 2)

            ElseIf ct.TipoComprobante.GrabaLibro Then

               pIVA = (Publicos.ProductoIVA / 100) + 1
               pagoTotal += Decimal.Round(ct.Paga / pIVA, 2)

            End If

            'Lo unico que queda afuera son los comprobantes en Negro.
         End If
      Next

      'recupero todas las retenciones que se le hizo al proveedor durante ese mes
      Dim retencionesBaseImponible As Decimal = 0
      Dim retencionesAplicadas As Decimal = 0
      '' ''Dim retapl As DataTable = New SqlServer.CuentasCorrientesProvRetenciones(Me.da).GetRetencionesPorFechaProveedor(fechaOrigen, fechaFin, ctacteProv.Proveedor.IdProveedor)

      '' ''For Each dr As DataRow In retapl.Rows
      '' ''   retencionesBaseImponible += Decimal.Parse(dr("BaseImponible").ToString())
      '' ''   'Quedo sin uso
      '' ''   retencionesAplicadas += Decimal.Parse(dr("ImporteTotal").ToString())
      '' ''   '---------------------
      '' ''Next

      If regimen Is Nothing Then regimen = ctacteProv.Proveedor.RegimenIVA

      'Controlo si retiene por escalas o no
      If regimen.RetienePorEscala Then

         'realizo los calculos y creo la retencion
         Dim rete As Entidades.RetencionCompra

         'si creo la retencion de ganancias
         rete = New Entidades.RetencionCompra()

         With rete
            'cargo una retencion de ganancias
            .IdSucursal = ctacteProv.IdSucursal
            .EmisorRetencion = ctacteProv.CentroEmisor
            .TipoImpuesto = regimen.TipoImpuesto   '' New Reglas.TiposImpuestos(Me.da).GetUno(Entidades.TipoImpuesto.Tipos.RGANA)
            .Regimen = regimen
            .Proveedor = ctacteProv.Proveedor
            'La numeracion es unica para todos
            '.NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion, .Proveedor.IdProveedor)
            .NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion)
            .FechaEmision = ctacteProv.Fecha

            '' ''Dim oescalas As Reglas.EscalasRetGanancias = New Reglas.EscalasRetGanancias()
            '' ''Dim escalas As DataTable = oescalas.GetAll()
            pagoTotal = pagoTotal - regimen.MontoAExceder - retencionesBaseImponible

            '' ''For Each dr As DataRow In escalas.Rows
            '' ''   If pagoTotal >= Decimal.Parse(dr("MontoMasDe").ToString()) And pagoTotal <= Decimal.Parse(dr("MontoA").ToString()) Then
            '' ''      .BaseImponible = pagoTotal - Decimal.Parse(dr("SobreExcedente").ToString())
            '' ''      .Alicuota = Decimal.Parse(dr("MasPorcentaje").ToString())
            '' ''      .ImporteTotal = Decimal.Round(.BaseImponible * .Alicuota / 100, 2) + Decimal.Parse(dr("Importe").ToString())

            '' ''      Exit For
            '' ''   End If
            '' ''Next

            .Proveedor = ctacteProv.Proveedor
            .IdEstado = Entidades.Retencion.Estados.APLICADO
         End With
         rt.Add(rete)

      Else

         'controlo el Regimen del proveedor para realizar los calculos
         If pagoTotal > regimen.MontoAExceder Then

            'realizo los calculos y creo la retencion
            Dim rete As Entidades.RetencionCompra

            'si creo la retencion de ganancias
            rete = New Entidades.RetencionCompra()

            With rete
               'cargo una retencion de ganancias
               .IdSucursal = ctacteProv.IdSucursal
               .EmisorRetencion = ctacteProv.CentroEmisor
               .TipoImpuesto = regimen.TipoImpuesto  '' New Reglas.TiposImpuestos(Me.da).GetUno(Entidades.TipoImpuesto.Tipos.RGANA)
               .Regimen = regimen
               .Proveedor = ctacteProv.Proveedor
               'La numeracion es unica para todos
               '.NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion, .Proveedor.IdProveedor)
               .NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion)
               .FechaEmision = ctacteProv.Fecha
               .BaseImponible = pagoTotal - regimen.MontoAExceder - retencionesBaseImponible
               .Alicuota = regimen.ARetenerInscripto
               .ImporteTotal = Decimal.Round(.BaseImponible * .Alicuota / 100, 2)
               .Proveedor = ctacteProv.Proveedor
               .IdEstado = Entidades.Retencion.Estados.APLICADO

               '# Guardo lo calculado por el sistema
               .BaseImponibleCalculada = .BaseImponible
               .ImporteTotalCalculado = .ImporteTotal
            End With
            rt.Add(rete)

         End If
      End If


      ' ''Return rt

      ' ''Catch ex As Exception
      ' ''   Throw
      ' ''Finally
      ' ''   Me.da.CloseConection()
      ' ''End Try

   End Sub

   Private Sub GetRetencionesIIBBCalculadas(ctacteProv As Entidades.CuentaCorrienteProv, ByRef rt As List(Of Entidades.RetencionCompra), regimen As Entidades.Regimen)
      'obtengo los pagos hechos al proveedor
      'Dim dtPagos As DataTable
      Dim sqlCtaCtePagos As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(Me.da)

      Dim pagoTotal As Decimal = 0
      Dim porcentajeIIBB As Decimal = 0
      Dim porcIVA As Decimal = 1
      Dim compro As Entidades.Compra
      Dim regComp As Reglas.Compras = New Reglas.Compras(Me.da)

      If regimen Is Nothing Then regimen = ctacteProv.Proveedor.RegimenIIBB

      Dim ndebcheqrechcom As String() = Publicos.IdNotaDebitoChequeRechazadoCompra.Split(","c)
      Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()

      For Each ct As Entidades.CuentaCorrienteProvPago In ctacteProv.Pagos

         If Not ndebcheqrechcom.Contains(ct.IdTipoComprobante) Then

            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(ct.IdTipoComprobante)

            'Si Aplico un ANTICIPO o un Comprobante Directo en CtaCte no encuentra y lanza un Throw, cortando el proceso.
            If regComp.Existe(ct.IdSucursal, ctacteProv.Proveedor.IdProveedor,
                              ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante) Then


               compro = regComp.GetUna(ct.IdSucursal, ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante, ctacteProv.Proveedor.IdProveedor)

               'Solo contemplo los comprobantes en Blanco.
               If compro.TipoComprobante.GrabaLibro Then
                  porcIVA = (compro.ImporteTotal) / (compro.TotalNeto)
                  If regimen.OrigenBaseImponible = Entidades.Regimen.OrigenBaseImponibleEnum.NETO Then
                     pagoTotal += Decimal.Round(ct.Paga / porcIVA, 2)
                  Else
                     pagoTotal += ct.Paga
                  End If
               End If

            ElseIf oTipoComprobante.EsAnticipo Then
               ' ElseIf ct.IdTipoComprobante = "ANTICIPO" Then

               'Deberia Analizar el Recibo que lo genero, pero es un quilombo!!!
               porcIVA = (Publicos.ProductoIVA / 100) + 1
               If regimen.OrigenBaseImponible = Entidades.Regimen.OrigenBaseImponibleEnum.NETO Then
                  pagoTotal += Decimal.Round(ct.Paga / porcIVA, 2)
               Else
                  pagoTotal += ct.Paga
               End If

            ElseIf ct.TipoComprobante.GrabaLibro Then

               porcIVA = (Publicos.ProductoIVA / 100) + 1
               If regimen.OrigenBaseImponible = Entidades.Regimen.OrigenBaseImponibleEnum.NETO Then
                  pagoTotal += Decimal.Round(ct.Paga / porcIVA, 2)
               Else
                  pagoTotal += ct.Paga
               End If

            End If

            'Lo unico que queda afuera son los comprobantes en Negro.
         End If
      Next

      'recupero todas las retenciones que se le hizo al proveedor durante ese mes
      Dim retencionesBaseImponible As Decimal = 0
      Dim retencionesAplicadas As Decimal = 0

      ''Controlo si retiene por escalas o no
      'IIBB NO EXISTE REGIMEN QUE RETENGA POR ESCALA.
      'If regimen.RetienePorEscala Then

      '   'realizo los calculos y creo la retencion
      '   Dim rete As Entidades.RetencionCompra

      '   'si creo la retencion de ganancias
      '   rete = New Entidades.RetencionCompra()

      '   With rete
      '      'cargo una retencion de ganancias
      '      .IdSucursal = ctacteProv.IdSucursal
      '      .EmisorRetencion = ctacteProv.CentroEmisor
      '      .TipoImpuesto = regimen.TipoImpuesto
      '      .Regimen = regimen
      '      .Proveedor = ctacteProv.Proveedor
      '      'La numeracion es unica para todos
      '      .NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion)
      '      .FechaEmision = ctacteProv.Fecha

      '      pagoTotal = pagoTotal - regimen.MinimoNoImponible - retencionesBaseImponible

      '      .Proveedor = ctacteProv.Proveedor
      '      .IdEstado = Entidades.Retencion.Estados.APLICADO
      '   End With
      '   rt.Add(rete)

      'Else

      'controlo el Regimen del proveedor para realizar los calculos
      If pagoTotal > regimen.MontoAExceder Then

         'realizo los calculos y creo la retencion
         Dim rete As Entidades.RetencionCompra

         'si creo la retencion de ganancias
         rete = New Entidades.RetencionCompra()

         With rete
            'cargo una retencion de ganancias
            .IdSucursal = ctacteProv.IdSucursal
            .EmisorRetencion = ctacteProv.CentroEmisor
            .TipoImpuesto = regimen.TipoImpuesto
            .Regimen = regimen
            .Proveedor = ctacteProv.Proveedor
            'La numeracion es unica para todos
            .NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion)
            .FechaEmision = ctacteProv.Fecha
            .BaseImponible = pagoTotal - regimen.MinimoNoImponible - retencionesBaseImponible
            .Alicuota = regimen.ARetenerInscripto
            .ImporteTotal = Decimal.Round(.BaseImponible * .Alicuota / 100, 2)
            .Proveedor = ctacteProv.Proveedor
            .IdEstado = Entidades.Retencion.Estados.APLICADO

            '# Guardo lo calculado por el sistema
            .BaseImponibleCalculada = .BaseImponible
            .ImporteTotalCalculado = .ImporteTotal
         End With
         rt.Add(rete)

      End If
      'End If

   End Sub

   Private Sub GetRetencionesIIBCCalculadas(ctacteProv As Entidades.CuentaCorrienteProv, ByRef rt As List(Of Entidades.RetencionCompra), regimen As Entidades.Regimen)
      'obtengo los pagos hechos al proveedor
      'Dim dtPagos As DataTable
      Dim sqlCtaCtePagos As SqlServer.CuentasCorrientesProvPagos = New SqlServer.CuentasCorrientesProvPagos(Me.da)

      Dim pagoTotal As Decimal = 0

      Dim importeTotal As Decimal = 0
      Dim secuenciaRete As Integer = 1

      Dim porcentajeIIBB As Decimal = 0
      Dim porcIVA As Decimal = 1
      Dim compro As Entidades.Compra
      Dim regComp As Reglas.Compras = New Reglas.Compras(Me.da)
      Dim rCtaCtePP = New Reglas.CuentasCorrientesProvPagos(Me.da)

      If regimen Is Nothing Then regimen = ctacteProv.Proveedor.RegimenIIBB

      Dim ndebcheqrechcom As String() = Publicos.IdNotaDebitoChequeRechazadoCompra.Split(","c)
      Dim oTipoComprobante As Entidades.TipoComprobante = New Entidades.TipoComprobante()

      For Each ct As Entidades.CuentaCorrienteProvPago In ctacteProv.Pagos
         importeTotal = ct.ImporteCuota
         secuenciaRete = rCtaCtePP.GetCuentacorrienteProvPagosSecuenciaRetencion(ct) + 1

         If Not ndebcheqrechcom.Contains(ct.IdTipoComprobante) Then

            oTipoComprobante = New Reglas.TiposComprobantes().GetUno(ct.IdTipoComprobante)

            'Si Aplico un ANTICIPO o un Comprobante Directo en CtaCte no encuentra y lanza un Throw, cortando el proceso.
            If regComp.Existe(ct.IdSucursal, ctacteProv.Proveedor.IdProveedor,
                              ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante) Then


               compro = regComp.GetUna(ct.IdSucursal, ct.IdTipoComprobante, ct.Letra, ct.CentroEmisor, ct.NumeroComprobante, ctacteProv.Proveedor.IdProveedor)

               'Solo contemplo los comprobantes en Blanco.
               If compro.TipoComprobante.GrabaLibro Then
                  porcIVA = (compro.ImporteTotal) / (compro.TotalNeto)
                  If regimen.OrigenBaseImponible = Entidades.Regimen.OrigenBaseImponibleEnum.NETO Then
                     pagoTotal += Decimal.Round(ct.Paga / porcIVA, 2)
                  Else
                     pagoTotal += ct.Paga
                  End If
               End If

            ElseIf oTipoComprobante.EsAnticipo Then
               ' ElseIf ct.IdTipoComprobante = "ANTICIPO" Then

               'Deberia Analizar el Recibo que lo genero, pero es un quilombo!!!
               porcIVA = (Publicos.ProductoIVA / 100) + 1
               If regimen.OrigenBaseImponible = Entidades.Regimen.OrigenBaseImponibleEnum.NETO Then
                  pagoTotal += Decimal.Round(ct.Paga / porcIVA, 2)
               Else
                  pagoTotal += ct.Paga
               End If

            ElseIf ct.TipoComprobante.GrabaLibro Then

               porcIVA = (Publicos.ProductoIVA / 100) + 1
               If regimen.OrigenBaseImponible = Entidades.Regimen.OrigenBaseImponibleEnum.NETO Then
                  pagoTotal += Decimal.Round(ct.Paga / porcIVA, 2)
               Else
                  pagoTotal += ct.Paga
               End If
            End If
         End If
      Next

      Dim retencionesBaseImponible As Decimal = 0
      Dim retencionesAplicadas As Decimal = 0

      If importeTotal > regimen.MontoAExceder Then

         'realizo los calculos y creo la retencion
         Dim rete As Entidades.RetencionCompra

         'si creo la retencion de ganancias
         rete = New Entidades.RetencionCompra()

         With rete
            'cargo una retencion de ganancias
            .IdSucursal = ctacteProv.IdSucursal
            .EmisorRetencion = ctacteProv.CentroEmisor
            .TipoImpuesto = regimen.TipoImpuesto
            .Regimen = regimen
            .Proveedor = ctacteProv.Proveedor
            'La numeracion es unica para todos
            .NumeroRetencion = Me.GetProximoNumero(.IdSucursal, .TipoImpuesto.IdTipoImpuesto, .EmisorRetencion)
            .FechaEmision = ctacteProv.Fecha
            .BaseImponible = pagoTotal - regimen.MinimoNoImponible - retencionesBaseImponible
            .Alicuota = regimen.ARetenerInscripto
            .ImporteTotal = Decimal.Round(.BaseImponible * .Alicuota / 100, 2)
            .Proveedor = ctacteProv.Proveedor
            .IdEstado = Entidades.Retencion.Estados.APLICADO
            .SecuenciaRetencion = secuenciaRete
            '# Guardo lo calculado por el sistema
            .BaseImponibleCalculada = .BaseImponible
            .ImporteTotalCalculado = .ImporteTotal
         End With
         rt.Add(rete)

      End If
      'End If

   End Sub

   Public Function GetProximoNumero(idSucursal As Integer,
                                      IdTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                      EmisorRetencion As Integer) As Integer

      'La numeracion es unica para todos
      ' IdProveedor As Long) As Integer

      Dim sql As SqlServer.RetencionesCompras = New SqlServer.RetencionesCompras(Me.da)
      Return sql.GetProximoNumero(idSucursal, IdTipoImpuesto, EmisorRetencion)

   End Function


   Public Function GetTodos(sucursales As Entidades.Sucursal(),
                            FechaDesde As Date,
                            FechaHasta As Date,
                            IdTipoRetencion As String,
                            IdTipoImpuesto As String,
                             AplicativoAfip As String) As DataTable

      Dim sql As SqlServer.RetencionesCompras
      Dim dt As DataTable

      Try
         Me.da.OpenConection()

         sql = New SqlServer.RetencionesCompras(Me.da)

         dt = sql.GetTodos(sucursales,
                           FechaDesde, FechaHasta,
                           IdTipoImpuesto, AplicativoAfip)

         Return dt

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

#End Region

End Class
Public Class FacturacionComunes

#Region "Campos"

   Private _impuestosVarios As List(Of Entidades.VentaImpuesto)

#End Region

   Public Property ImpuestosVarios() As List(Of Entidades.VentaImpuesto)
      Get
         Return _impuestosVarios
      End Get
      Set(value As List(Of Entidades.VentaImpuesto))
         _impuestosVarios = value
      End Set
   End Property

   Public Sub CargarRetenciones(retencionesIVA As Entidades.PercepcionVentaCalculo,
                                retencionesIIBB As Entidades.PercepcionVentaCalculo,
                                retencionesGanancias As Decimal,
                                retencionesVarias As Decimal)
      CargarRetenciones({retencionesIVA}.ToList(), {retencionesIIBB}.ToList(), retencionesGanancias, retencionesVarias)
   End Sub

   Public Sub CargarRetenciones(retencionesIVA As List(Of Entidades.PercepcionVentaCalculo),
                                retencionesIIBB As List(Of Entidades.PercepcionVentaCalculo),
                                retencionesGanancias As Decimal,
                                retencionesVarias As Decimal)

      _impuestosVarios = Nothing
      _impuestosVarios = New List(Of Entidades.VentaImpuesto)

      'Percepcion de IVA
      'Me.BorrarImpuesto("PIVA")
      For Each ent In retencionesIVA.Where(Function(r) r IsNot Nothing)
         If ent.Monto > 0 Then
            Dim oLineaPercepciones = New Entidades.VentaImpuesto()
            With oLineaPercepciones
               .TipoImpuesto = New TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.PIVA)
               .Alicuota = ent.Alicuota
               .Bruto = ent.BaseImponible
               .Neto = ent.BaseImponible
               .Importe = ent.Monto
               .IdRegimenPercepcion = ent.IdRegimenPercepcion
               .Total = 0
            End With
            _impuestosVarios.Add(oLineaPercepciones)
         End If
      Next
      'If retencionesIVA > 0 Then
      '   Dim oLineaPercepciones = New Entidades.VentaImpuesto()
      '   With oLineaPercepciones
      '      .TipoImpuesto = New TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.PIVA)
      '      .Alicuota = 0
      '      .Bruto = 0
      '      .Neto = 0
      '      .Importe = retencionesIVA
      '      .Total = 0
      '   End With
      '   _impuestosVarios.Add(oLineaPercepciones)
      'End If

      'Percepcion de Ingresos Brutos
      'Me.BorrarImpuesto("PIIBB")
      For Each ent As Entidades.PercepcionVentaCalculo In retencionesIIBB
         If ent.Monto > 0 Then
            Dim oLineaPercepciones = New Entidades.VentaImpuesto
            With oLineaPercepciones
               .TipoImpuesto = New TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.PIIBB)
               .Alicuota = ent.Alicuota
               .Bruto = ent.BaseImponible
               .Neto = ent.BaseImponible
               .Importe = ent.Monto
               .IdProvincia = ent.IdProvincia
               .IdActividad = ent.IdActividad
               .Total = 0
            End With
            _impuestosVarios.Add(oLineaPercepciones)
         End If
      Next

      'Percepcion de Ganancias
      'Me.BorrarImpuesto("PGANA")
      If retencionesGanancias > 0 Then
         Dim oLineaPercepciones = New Entidades.VentaImpuesto
         With oLineaPercepciones
            .TipoImpuesto = New TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.PGANA)
            .Alicuota = 0
            .Bruto = 0
            .Neto = 0
            .Importe = retencionesGanancias
            .Total = 0
         End With
         _impuestosVarios.Add(oLineaPercepciones)
      End If

      'Percepcion Varias
      'Me.BorrarImpuesto("PVAR")
      If retencionesVarias > 0 Then
         Dim oLineaPercepciones = New Entidades.VentaImpuesto
         With oLineaPercepciones
            .TipoImpuesto = New TiposImpuestos().GetUno(Entidades.TipoImpuesto.Tipos.PVAR)
            .Alicuota = 0
            .Bruto = 0
            .Neto = 0
            .Importe = retencionesVarias
            .Total = 0
         End With
         _impuestosVarios.Add(oLineaPercepciones)
      End If

   End Sub

   Public Sub BorrarImpuesto(idTipoImpuesto As Entidades.TipoImpuesto.Tipos)
      _impuestosVarios.RemoveAll(Function(vi) vi.IdTipoImpuesto = idTipoImpuesto)
   End Sub


   Public Function CalculaPercepcionesIVA(cliente As Entidades.Cliente, tipoComp As Entidades.TipoComprobante,
                                          catFiscalEmpresa As Entidades.CategoriaFiscal,
                                          ventasProductos As List(Of Entidades.VentaProducto),
                                          invocados As IList(Of Entidades.VentaInvocado)) As List(Of Entidades.PercepcionVentaCalculo)
      Return CalculaPercepcionesIVA(cliente, tipoComp, catFiscalEmpresa, ventasProductos, If(invocados Is Nothing, Nothing, invocados.ToList().ConvertAll(Function(i) i.Invocado)))
   End Function
   Public Function CalculaPercepcionesIVA(cliente As Entidades.Cliente, tipoComp As Entidades.TipoComprobante,
                                          catFiscalEmpresa As Entidades.CategoriaFiscal,
                                          ventasProductos As List(Of Entidades.VentaProducto),
                                          invocados As List(Of Entidades.Venta)) As List(Of Entidades.PercepcionVentaCalculo)
      Return CalculaPercepcionesIVA(cliente, tipoComp, catFiscalEmpresa, ventasProductos, If(invocados Is Nothing, Nothing, invocados.ConvertAll(Function(i) DirectCast(i, Entidades.IVentaInvocada))))
   End Function
   Public Function CalculaPercepcionesIVA(cliente As Entidades.Cliente, tipoComp As Entidades.TipoComprobante,
                                          catFiscalEmpresa As Entidades.CategoriaFiscal,
                                          ventasProductos As List(Of Entidades.VentaProducto),
                                          invocados As IList(Of Entidades.IVentaInvocada)) As List(Of Entidades.PercepcionVentaCalculo)
      If invocados Is Nothing Then invocados = New List(Of Entidades.IVentaInvocada)()
      Dim cache = New BusquedasCacheadas()
      Dim entPercIVA = New List(Of Entidades.PercepcionVentaCalculo)()

      If tipoComp IsNot Nothing AndAlso tipoComp.ClaseComprobante = Entidades.TipoComprobante.ClasesComprobante.NOTADEB Then
         Return entPercIVA
      End If

      If cliente IsNot Nothing AndAlso Not cliente.EsExentoPercIVARes53292023 AndAlso
            ((tipoComp.GrabaLibro And tipoComp.EsComercial) Or tipoComp.EsPreElectronico Or ((Not tipoComp.GrabaLibro And Not tipoComp.EsComercial) And tipoComp.SimulaPercepciones)) AndAlso
            catFiscalEmpresa.IvaDiscriminado AndAlso cliente.CategoriaFiscal.IvaDiscriminado Then

         If tipoComp.CoeficienteValores < 0 Then
            Dim rVI = New VentasImpuestos()
            'Dim alguno = False
            'For Each inv In invocados
            '   If rVI.GetTodos(inv.IdSucursal, inv.IdTipoComprobante, inv.Letra, inv.CentroEmisor, inv.NumeroComprobante, Entidades.TipoImpuesto.Tipos.PIVA).Any() Then
            '      alguno = True
            '   End If
            'Next
            Dim alguno = rVI.GetTodos(invocados, Entidades.TipoImpuesto.Tipos.PIVA).Any()
            If Not alguno Then
               Return entPercIVA
            End If
         End If

         Dim regPerc = New RegimenesPercepciones().GetTodos().FirstOrDefault()
         If regPerc IsNot Nothing Then
            Dim tpImpPIVA = cache.BuscaTiposImpuestos(Entidades.TipoImpuesto.Tipos.PIVA)
            For Each vp In ventasProductos.Where(Function(x) x.Producto.EsPerceptibleIVARes53292023)
               Dim impuesto = cache.BuscaImpuesto(vp.TipoImpuesto.IdTipoImpuesto.ToString(), vp.AlicuotaImpuesto)

               Dim pv = entPercIVA.FirstOrDefault(Function(x) x.Alicuota = impuesto.AlicuotaPIVA.IfNull())
               If pv Is Nothing Then
                  pv = New Entidades.PercepcionVentaCalculo()
                  pv.Alicuota = impuesto.AlicuotaPIVA.IfNull()
                  pv.IdRegimenPercepcion = regPerc.IdRegimenPercepcion
                  pv.NombreRegimenPercepcion = regPerc.NombreRegimenPercepcion
                  entPercIVA.Add(pv)
               End If

               pv.BaseImponible += vp.PrecioNeto * vp.Cantidad '   vp.ImporteTotalNeto
               pv.Monto = pv.BaseImponible * pv.Alicuota / 100

            Next
            If tipoComp.CoeficienteValores >= 0 AndAlso entPercIVA.Sum(Function(x) x.Monto) < regPerc.ImpuestoMinimo Then
               entPercIVA.Clear()
            End If
         End If
      End If

      Return entPercIVA
   End Function

End Class
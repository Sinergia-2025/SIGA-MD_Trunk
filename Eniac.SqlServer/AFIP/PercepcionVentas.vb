Public Class PercepcionVentas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub PercepcionVentas_I(idSucursal As Integer,
                                 idTipoImpuesto As String,
                                 emisorPercepcion As Integer,
                                 numeroPercepcion As Long,
                                 fechaEmision As Date,
                                 baseImponible As Decimal,
                                 alicuota As Decimal,
                                 importeTotal As Decimal,
                                 idCajaIngreso As Integer,
                                 nroPlanillaIngreso As Integer,
                                 nroMovimientoIngreso As Integer,
                                 idEstado As Entidades.Retencion.Estados,
                                 idActividad As Integer,
                                 idProvincia As String,
                                 idCliente As Long,
                                 idRegimenPercepcion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO PercepcionVentas (")
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdTipoImpuesto")
         .AppendFormatLine("   , EmisorPercepcion")
         .AppendFormatLine("   , NumeroPercepcion")
         .AppendFormatLine("   , FechaEmision")
         .AppendFormatLine("   , BaseImponible")
         .AppendFormatLine("   , Alicuota")
         .AppendFormatLine("   , ImporteTotal")
         .AppendFormatLine("   , IdCajaIngreso")
         .AppendFormatLine("   , NroPlanillaIngreso")
         .AppendFormatLine("   , NroMovimientoIngreso")
         .AppendFormatLine("   , IdEstado")
         .AppendFormatLine("   , IdActividad")
         .AppendFormatLine("   , IdProvincia")
         .AppendFormatLine("   , IdCliente")
         .AppendFormatLine("   , IdRegimenPercepcion")
         .AppendFormatLine("   ) VALUES (")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoImpuesto)
         .AppendFormatLine("   ,  {0} ", emisorPercepcion)
         .AppendFormatLine("   ,  {0} ", numeroPercepcion)
         .AppendFormatLine("   , '{0}'", ObtenerFecha(fechaEmision, True))
         .AppendFormatLine("   ,  {0} ", baseImponible)
         .AppendFormatLine("   ,  {0} ", alicuota)
         .AppendFormatLine("   ,  {0} ", importeTotal)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idCajaIngreso))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(nroPlanillaIngreso))
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(nroMovimientoIngreso))

         .AppendFormatLine("   , '{0}'", idEstado.ToString())
         .AppendFormatLine("   ,  {0} ", idActividad)
         .AppendFormatLine("   , '{0}'", idProvincia)
         .AppendFormatLine("   ,  {0} ", idCliente)
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idRegimenPercepcion))
         .AppendFormatLine("   )")
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "PercepcionVentas")
   End Sub

   Public Sub PercepcionVentas_U(idSucursal As Integer,
                                 idTipoImpuesto As String,
                                 emisorPercepcion As Integer,
                                 numeroPercepcion As Long,
                                 fechaEmision As Date,
                                 baseImponible As Decimal,
                                 alicuota As Decimal,
                                 importeTotal As Decimal,
                                 idCajaIngreso As Integer,
                                 nroPlanillaIngreso As Integer,
                                 nroMovimientoIngreso As Integer,
                                 idEstado As Entidades.Retencion.Estados,
                                 idRegimen As Integer,
                                 idCliente As Long,
                                 idRegimenPercepcion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE  PercepcionVentas SET ")
         .AppendFormatLine("     IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   , IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("   , EmisorPercepcion = {0}", emisorPercepcion)
         .AppendFormatLine("   , NumeroPercepcion = {0}", numeroPercepcion)
         .AppendFormatLine("   , FechaEmision = '{0}'", ObtenerFecha(fechaEmision, True))
         .AppendFormatLine("   , BaseImponible = {0}", baseImponible)
         .AppendFormatLine("   , Alicuota = {0}", alicuota)
         .AppendFormatLine("   , ImporteTotal = {0}", importeTotal)
         .AppendFormatLine("   , IdCajaEgreso = {0}", GetStringFromNumber(idCajaIngreso))
         .AppendFormatLine("   , NroPlanillaEgreso = {0}", GetStringFromNumber(nroPlanillaIngreso))
         .AppendFormatLine("   , NroMovimientoEgreso = {0}", GetStringFromNumber(nroMovimientoIngreso))
         .AppendFormatLine("   , IdEstado = '{0}'", idEstado.ToString())
         .AppendFormatLine("   , IdRegimen = {0}", GetStringFromNumber(idRegimen))
         .AppendFormatLine("   , IdCliente = {0}", idCliente)
         .AppendFormatLine("   , IdRegimenPercepcion = {0}", GetStringFromNumber(idRegimenPercepcion))
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("   AND EmisorPercepcion = {0}", emisorPercepcion)
         .AppendFormatLine("   AND NumeroPercepcion = {0}", numeroPercepcion)
         .AppendFormatLine("   AND IdCliente = {0}", idCliente)
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), " PercepcionVentas")
   End Sub

   Public Sub PercepcionVentas_D(idSucursal As Integer, idTipoImpuesto As String, emisorPercepcion As Integer, numeroPercepcion As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM PercepcionVentas")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine(" AND IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine(" AND EmisorPercepcion = {0}", emisorPercepcion)
         .AppendFormatLine(" AND NumeroPercepcion = {0}", numeroPercepcion)
      End With
      Execute(stb)
      Sincroniza_I(stb.ToString(), "PercepcionVentas")
   End Sub

   'Private Sub SelectTexto(stb As StringBuilder)
   '   With stb
   '      .Append("SELECT PV.*")
   '      .Append("  FROM PercepcionVentas PV")
   '   End With
   'End Sub

   Public Function PercepcionVentas_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function PercepcionVentas_G1(idSucursal As Integer, idTipoImpuesto As String, emisorPercepcion As Integer, numeroPercepcion As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE PV.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND PV.IdTipoImpuesto = '{0}'", idTipoImpuesto)
         .AppendFormatLine("   AND PV.EmisorPercepcion = {0}", emisorPercepcion)
         .AppendFormatLine("   AND PV.NumeroPercepcion = {0}", numeroPercepcion)
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "PV.")
   End Function

   Public Function GetPorVentasPercepciones(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE VP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND VP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VP.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND VP.NumeroComprobante = {0}", numeroComprobante)
      End With
      Return GetDataTable(stb)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PV.*")
         .AppendFormatLine("     , TI.NombreTipoImpuesto")
         .AppendFormatLine("     , C.NombreCliente")
         .AppendFormatLine("     , C.IdCliente")
         .AppendFormatLine("     , C.CodigoCliente")
         .AppendFormatLine("     , VP.IdTipoComprobante")
         .AppendFormatLine("     , VP.Letra")
         .AppendFormatLine("     , VP.CentroEmisor")
         .AppendFormatLine("     , VP.NumeroComprobante")
         .AppendFormatLine("     , V.Cuit")
         .AppendFormatLine("     , V.TipoDocCliente")
         .AppendFormatLine("     , V.NroDocCliente")
         .AppendFormatLine("     , C.InscriptoIBStaFe")
         .AppendFormatLine("     , C.IngresosBrutos")
         .AppendFormatLine("     , V.IdCategoriaFiscal")
         .AppendFormatLine("     , CF.SolicitaCUIT")
         .AppendFormatLine("     , V.ImporteTotal ImporteComprobante ")
         .AppendFormatLine("     , V.SubTotal ImporteSubTotalComprobante")
         .AppendFormatLine("     , C.IdTipoDeExension, C.AnioExension")
         .AppendFormatLine("     , C.NroCertExension, C.NroCertPropio")
         .AppendFormatLine("     , TC.CodigoComprobanteSifere, TC.CodigoComprobanteSicore , CA.IdActividad AS Act")
         .AppendFormatLine("     , 'P: ' + CONVERT(VARCHAR(MAX), PV.NroPlanillaIngreso) + ' - M: ' + CONVERT(VARCHAR(MAX), PV.NroMovimientoIngreso) Ingreso")
         .AppendFormatLine("     , ATCTC.IdAFIPTipoComprobante")
         .AppendFormatLine("     , RP.CodigoAFIP")
         .AppendFormatLine("     , ATD.IdAFIPTipoDocumento")
         .AppendFormatLine("     , ATDCUIT.IdAFIPTipoDocumento IdAFIPTipoDocumentoCuit")
         .AppendFormatLine("  FROM PercepcionVentas PV")
         .AppendFormatLine("  LEFT JOIN TiposImpuestos TI ON PV.IdTipoImpuesto=  TI.IdTipoImpuesto")
         .AppendFormatLine("  LEFT JOIN Clientes C ON PV.IdCliente = C.IdCliente")
         .AppendFormatLine("  LEFT JOIN VentasPercepciones VP ON VP.IdSucursal = PV.IdSucursal AND VP.IdTipoImpuesto = PV.IdTipoImpuesto")
         .AppendFormatLine("        AND VP.EmisorPercepcion = PV.EmisorPercepcion AND VP.NumeroPercepcion = PV.NumeroPercepcion")
         .AppendFormatLine("  LEFT JOIN Ventas V ON V.IdSucursal = VP.IdSucursal")
         .AppendFormatLine("       	AND V.IdTipoComprobante = VP.IdTipoComprobante AND	V.Letra = VP.Letra")
         .AppendFormatLine("       	AND V.CentroEmisor = VP.CentroEmisor AND V.NumeroComprobante = VP.NumeroComprobante")
         .AppendFormatLine("  LEFT JOIN CategoriasFiscales CF ON CF.IdCategoriaFiscal = V.IdCategoriaFiscal")
         .AppendFormatLine("  LEFT JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante ")
         .AppendFormatLine("  LEFT JOIN ClientesActividades CA ON CA.IdCliente = PV.IdCliente")
         .AppendFormatLine("        AND CA.IdProvincia = PV.IdProvincia  AND CA.IdActividad = PV.IdActividad ")
         .AppendFormatLine("  LEFT JOIN AFIPTiposComprobantesTiposCbtes ATCTC ON ATCTC.IdTipoComprobante = V.IdTIpoComprobante")
         .AppendFormatLine("                                                 AND ATCTC.Letra = V.Letra")
         .AppendFormatLine("  LEFT JOIN AFIPTiposDocumentos ATD ON ATD.TipoDocumento = V.TipoDocCliente")
         .AppendFormatLine("  LEFT JOIN AFIPTiposDocumentos ATDCuit ON ATDCuit.TipoDocumento = 'CUIT'")
         .AppendFormatLine("  LEFT JOIN RegimenesPercepciones RP ON RP.IdRegimenPercepcion = PV.IdRegimenPercepcion")
      End With
   End Sub

   Public Function GetTodos(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                            idTipoImpuesto As String, idCliente As Long, idProvincia As String) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE PV.IdSucursal = {0}", idSucursal)

         .AppendFormatLine("   AND PV.FechaEmision  >= '{0}'", ObtenerFecha(fechaDesde, False))
         .AppendFormatLine("   AND PV.FechaEmision  <= '{0}'", ObtenerFecha(fechaHasta.UltimoSegundoDelDia(), True))

         If idCliente <> 0 Then
            .AppendFormatLine("   AND C.IdCliente = {0}", idCliente)
         End If

         If Not String.IsNullOrEmpty(idTipoImpuesto) Then
            .AppendFormatLine("   AND PV.IdTipoImpuesto = '{0}'", idTipoImpuesto)
         End If

         If Not String.IsNullOrWhiteSpace(idProvincia) Then
            .AppendFormatLine("   AND PV.IdProvincia = '{0}'", idProvincia)
         End If
         .AppendFormatLine(" ORDER BY PV.FechaEmision")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As DataTable
      Dim stb = New StringBuilder()
      SelectTexto(stb)
      With stb
         .AppendFormatLine("   WHERE VP.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("     AND VP.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("     AND VP.Letra = '{0}'", letra)
         .AppendFormatLine("     AND VP.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("     AND VP.NumeroComprobante = {0}", numeroComprobante)
         '.AppendFormatLine("   ORDER BY PV.FechaEmision")
      End With
      Return GetDataTable(stb)
   End Function

   Public Overloads Function GetCodigoMaximo(idSucursal As Integer, idTipoImpuesto As Entidades.TipoImpuesto.Tipos, emisorPercepcion As Integer) As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine(" IdSucursal = {0}", idSucursal)
         .AppendFormatLine("  AND IdTipoImpuesto = '{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine("  AND EmisorPercepcion = {0}", emisorPercepcion)
      End With
      Return GetCodigoMaximo("NumeroPercepcion", "PercepcionVentas", stb.ToString()).ToInteger()
   End Function

End Class
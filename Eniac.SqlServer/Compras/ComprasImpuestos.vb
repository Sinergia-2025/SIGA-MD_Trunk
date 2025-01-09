Option Explicit On
Option Strict On
Public Class ComprasImpuestos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasImpuestos_I(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long,
                                 idProveedor As Long,
                                 idTipoImpuesto As String,
                                 orden As Integer,
                                 idProvincia As String,
                                 emisor As Integer,
                                 numero As Long,
                                 bruto As Decimal,
                                 baseImponible As Decimal,
                                 alicuota As Decimal,
                                 importe As Decimal,
                                 esDespacho As Boolean)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO ComprasImpuestos (")
         .AppendLine("            IdSucursal")
         .AppendLine("           ,IdTipoComprobante")
         .AppendLine("           ,Letra")
         .AppendLine("           ,CentroEmisor")
         .AppendLine("           ,NumeroComprobante")
         .AppendLine("           ,IdProveedor")
         .AppendLine("           ,IdTipoImpuesto")
         .AppendLine("           ,Orden")
         .AppendLine("           ,IdProvincia")
         .AppendLine("           ,Emisor")
         .AppendLine("           ,Numero")
         .AppendLine("           ,Bruto")
         .AppendLine("           ,BaseImponible")
         .AppendLine("           ,Alicuota")
         .AppendLine("           ,Importe")
         .AppendLine("           ,EsDespacho")
         .AppendLine(") VALUES (")
         .AppendFormat("            {0},", idSucursal).AppendLine()
         .AppendFormat("           '{0}',", idTipoComprobante).AppendLine()
         .AppendFormat("           '{0}',", letra).AppendLine()
         .AppendFormat("            {0},", centroEmisor).AppendLine()
         .AppendFormat("            {0},", numeroComprobante).AppendLine()
         .AppendFormat("            {0},", idProveedor).AppendLine()
         .AppendFormat("           '{0}',", idTipoImpuesto).AppendLine()
         .AppendFormat("            {0},", orden).AppendLine()
         If Not String.IsNullOrWhiteSpace(idProvincia) Then
            .AppendFormat("           '{0}',", idProvincia).AppendLine()
         Else
            .AppendFormat("           NULL,").AppendLine()
         End If
         If emisor > 0 Then
            .AppendFormat("            {0},", emisor).AppendLine()
         Else
            .AppendFormat("            NULL,").AppendLine()
         End If
         If numero > 0 Then
            .AppendFormat("            {0},", numero).AppendLine()
         Else
            .AppendFormat("            NULL,").AppendLine()
         End If
         .AppendFormat("            {0},", bruto).ToString()
         .AppendFormat("            {0},", baseImponible).AppendLine()
         .AppendFormat("            {0},", alicuota).AppendLine()
         .AppendFormat("            {0},", importe).AppendLine()
         .AppendFormat("            {0}", GetStringFromBoolean(esDespacho)).AppendLine()
         .AppendLine(") ")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ComprasImpuestos_D(idSucursal As Integer,
                                 idTipoComprobante As String,
                                 letra As String,
                                 centroEmisor As Integer,
                                 numeroComprobante As Long,
                                 idProveedor As Long,
                                 orden As Integer,
                                 idTipoImpuesto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .AppendLine("DELETE FROM ComprasImpuestos ")
         .AppendFormat(" WHERE IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND NumeroComprobante = {0}", numeroComprobante).AppendLine()
         .AppendFormat("   AND IdProveedor = {0}", idProveedor).AppendLine()
         If Not String.IsNullOrWhiteSpace(idTipoImpuesto) Then
            .AppendFormat("   AND IdTipoImpuesto = '{0}'", idTipoImpuesto).AppendLine()
         End If
         If orden > 0 Then
            .AppendFormat("   AND Orden = {0}", orden).AppendLine()
         End If
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectFiltrado(ByRef stb As StringBuilder, Optional joinCompras As Boolean = False)
      With stb
         .AppendLine("SELECT CI.*")
         .AppendLine("     , P.NombreProvincia")
         .AppendLine("     , P.Jurisdiccion")
         .AppendLine("     , PR.CodigoProveedor")
         '   .AppendLine("     ,CASE WHEN PR.EsProveedorGenerico = 'True' THEN C.NombreProveedor ELSE PR.NombreProveedor END AS NombreProveedor")
         .AppendLine("     , PR.NombreProveedor")
         '   .AppendLine("     ,CASE WHEN  PR.EsProveedorGenerico = 'True' THEN C.CuitProveedor ELSE PR.CuitProveedor END AS CuitProveedor")
         .AppendLine("     , PR.CuitProveedor")
         .AppendLine("     , TI.NombreTipoImpuesto")
         .AppendLine("     , TI.Tipo AS TipoTipoImpuesto")
         .AppendLine("     ,PR.IdRegimenIIBB")
         If joinCompras Then
            .AppendLine("     , C.Fecha")
            .AppendLine("     , TC.CodigoComprobanteSifere")
         End If
         .AppendLine("  FROM ComprasImpuestos CI ")
         .AppendLine("  LEFT JOIN Provincias P ON P.IdProvincia = CI.IdProvincia")
         .AppendLine(" INNER JOIN Proveedores PR ON PR.IdProveedor = CI.IdProveedor")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = CI.IdTipoImpuesto")
         If joinCompras Then
            .AppendLine(" INNER JOIN Compras C ON CI.IdSucursal = C.IdSucursal")
            .AppendLine("                     AND CI.IdTipoComprobante = C.IdTipoComprobante")
            .AppendLine("                     AND CI.Letra = C.Letra")
            .AppendLine("                     AND CI.CentroEmisor = C.CentroEmisor")
            .AppendLine("                     AND CI.NumeroComprobante = C.NumeroComprobante")
            .AppendLine("                     AND CI.IdProveedor = C.IdProveedor")
            .AppendLine(" INNER JOIN TiposComprobantes AS TC ON TC.IdTipoComprobante = C.IdTipoComprobante")
         End If
      End With
   End Sub

   Public Function ComprasImpuestos_GA_TotasLasProvincias() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT NULL AS IdSucursal")
         .AppendLine("     , NULL AS IdTipoComprobante")
         .AppendLine("     , NULL AS Letra")
         .AppendLine("     , NULL AS CentroEmisor")
         .AppendLine("     , NULL AS NumeroComprobante")
         .AppendLine("     , NULL AS IdProveedor")
         .AppendLine("     , NULL AS IdTipoImpuesto")
         .AppendLine("     , NULL AS Orden")
         .AppendLine("     , P.IdProvincia")
         .AppendLine("     , P.NombreProvincia")
         .AppendLine("     , 0 AS Emisor")
         .AppendLine("     , 0 AS Numero")
         .AppendLine("     , 0 AS Bruto")
         .AppendLine("     , 0 AS BaseImponible")
         .AppendLine("     , 0 AS Alicuota")
         .AppendLine("     , 0 AS Importe")
         .AppendLine("     , 1 AS EsDespacho")
         .AppendLine("  FROM Provincias P")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ComprasImpuestos_GA() As DataTable
      Return ComprasImpuestos_G(0, String.Empty, String.Empty, 0, 0, 0, 0, String.Empty, Nothing, Nothing, Nothing, String.Empty, 0)
   End Function
   Public Function ComprasImpuestos_GA(idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Integer,
                                       numeroComprobante As Long,
                                       idProveedor As Long) As DataTable
      Return ComprasImpuestos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, 0, String.Empty, Nothing, Nothing, Nothing, String.Empty, 0)
   End Function
   Public Function ComprasImpuestos_G(idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Integer,
                                       numeroComprobante As Long,
                                       idProveedor As Long,
                                       orden As Integer,
                                       idTipoImpuesto As String,
                                       fechaDesde As DateTime?,
                                       fechaHasta As DateTime?,
                                       tipoTipoImpuesto As String,
                                       aplicativoAFIP As String,
                                       periodoFiscal As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectFiltrado(myQuery, fechaDesde.HasValue Or fechaHasta.HasValue)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal > 0 Then
            .AppendFormat("   AND CI.IdSucursal = {0}", idSucursal).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND CI.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND CI.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND CI.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroComprobante > 0 Then
            .AppendFormat("   AND CI.NumeroComprobante = {0}", numeroComprobante).AppendLine()
         End If
         If idProveedor > 0 Then
            .AppendFormat("   AND CI.IdProveedor = {0}", idProveedor).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoImpuesto) Then
            .AppendFormat("   AND CI.IdTipoImpuesto = '{0}'", idTipoImpuesto).AppendLine()
         End If
         If orden > 0 Then
            .AppendFormat("   AND CI.Orden = {0}", orden).AppendLine()
         End If

         If periodoFiscal > 0 Then
            .AppendLine("	  AND C.PeriodoFiscal = " & periodoFiscal.ToString())
         End If

         If fechaDesde.HasValue AndAlso fechaDesde.Value <> Nothing Then
            .AppendFormat("   AND C.Fecha >= '{0}'", ObtenerFecha(fechaDesde.Value, True)).AppendLine()
         End If
         If fechaHasta.HasValue AndAlso fechaHasta.Value <> Nothing Then
            .AppendFormat("   AND C.Fecha <= '{0}'", ObtenerFecha(fechaHasta.Value, True)).AppendLine()
         End If

         If Not String.IsNullOrWhiteSpace(tipoTipoImpuesto) Then
            .AppendFormat("   AND TI.Tipo = '{0}'", tipoTipoImpuesto).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(aplicativoAFIP) Then
            .AppendFormat("   AND TI.AplicativoAfip = '{0}'", aplicativoAFIP).AppendLine()
         End If
         .AppendLine(" ORDER BY CI.IdSucursal, CI.idTipoComprobante, CI.letra, CI.centroEmisor, CI.numeroComprobante, CI.idProveedor, CI.orden, CI.idTipoImpuesto")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ComprasImpuestos_G_Informe(sucursales As Entidades.Sucursal(),
                                              FechaDesde As Date,
                                              FechaHasta As Date,
                                              IdTipoImpuesto As String,
                                              IdProveedor As Long,
                                              tipoTipoImpuesto As String,
                                              aplicativoAFIP As String,
                                              periodoFiscal As Integer) As DataTable
      Return ComprasImpuestos_G_InformeMultSucursal(sucursales, String.Empty, String.Empty, 0, 0, IdProveedor, 0,
                                IdTipoImpuesto, FechaDesde, FechaHasta, tipoTipoImpuesto, aplicativoAFIP, periodoFiscal)
   End Function
   Public Function ComprasImpuestos_G_InformeMultSucursal(sucursales As Entidades.Sucursal(),
                                     idTipoComprobante As String,
                                     letra As String,
                                     centroEmisor As Integer,
                                     numeroComprobante As Long,
                                     idProveedor As Long,
                                     orden As Integer,
                                     idTipoImpuesto As String,
                                     fechaDesde As DateTime?,
                                     fechaHasta As DateTime?,
                                     tipoTipoImpuesto As String,
                                     aplicativoAFIP As String,
                                     periodoFiscal As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectFiltrado(myQuery, fechaDesde.HasValue Or fechaHasta.HasValue)
         .AppendLine(" WHERE 1 = 1")

         GetListaSucursalesMultiples(myQuery, sucursales, "CI")

         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormat("   AND CI.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormat("   AND CI.Letra = '{0}'", letra).AppendLine()
         End If
         If centroEmisor > 0 Then
            .AppendFormat("   AND CI.CentroEmisor = {0}", centroEmisor).AppendLine()
         End If
         If numeroComprobante > 0 Then
            .AppendFormat("   AND CI.NumeroComprobante = {0}", numeroComprobante).AppendLine()
         End If
         If idProveedor > 0 Then
            .AppendFormat("   AND CI.IdProveedor = {0}", idProveedor).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(idTipoImpuesto) Then
            .AppendFormat("   AND CI.IdTipoImpuesto = '{0}'", idTipoImpuesto).AppendLine()
         End If
         If orden > 0 Then
            .AppendFormat("   AND CI.Orden = {0}", orden).AppendLine()
         End If

         If periodoFiscal > 0 Then
            .AppendLine("	  AND C.PeriodoFiscal = " & periodoFiscal.ToString())
         End If

         If fechaDesde.HasValue AndAlso fechaDesde.Value <> Nothing Then
            .AppendFormat("   AND C.Fecha >= '{0}'", ObtenerFecha(fechaDesde.Value, True)).AppendLine()
         End If
         If fechaHasta.HasValue AndAlso fechaHasta.Value <> Nothing Then
            .AppendFormat("   AND C.Fecha <= '{0}'", ObtenerFecha(fechaHasta.Value, True)).AppendLine()
         End If

         If Not String.IsNullOrWhiteSpace(tipoTipoImpuesto) Then
            .AppendFormat("   AND TI.Tipo = '{0}'", tipoTipoImpuesto).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(aplicativoAFIP) Then
            .AppendFormat("   AND TI.AplicativoAfip = '{0}'", aplicativoAFIP).AppendLine()
         End If
         .AppendLine(" ORDER BY CI.IdSucursal, CI.idTipoComprobante, CI.letra, CI.centroEmisor, CI.numeroComprobante, CI.idProveedor, CI.orden, CI.idTipoImpuesto")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ComprasImpuestos_G1(idSucursal As Integer,
                                       idTipoComprobante As String,
                                       letra As String,
                                       centroEmisor As Integer,
                                       numeroComprobante As Long,
                                       idProveedor As Long,
                                       orden As Integer) As DataTable
      Return ComprasImpuestos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor,
                                 orden, String.Empty, Nothing, Nothing, Nothing, String.Empty, 0)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      Select Case columna
         Case Else
            columna = "CI." + columna
      End Select

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectFiltrado(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
         .AppendLine(" ORDER BY CI.IdSucursal, CI.idTipoComprobante, CI.letra, CI.centroEmisor, CI.numeroComprobante, CI.idProveedor, CI.orden, CI.idTipoImpuesto")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetOrdenMaximo(idSucursal As Integer,
                                  idTipoComprobante As String,
                                  letra As String,
                                  centroEmisor As Integer,
                                  numeroComprobante As Long,
                                  idProveedor As Long) As Long
      Dim result As Long = 0
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT MAX(orden) AS {0} FROM ComprasImpuestos CI", ColumnAlias)
         .AppendLine(" WHERE 1 = 1")
         .AppendFormat("   AND CI.IdSucursal = {0}", idSucursal).AppendLine()
         .AppendFormat("   AND CI.IdTipoComprobante = '{0}'", idTipoComprobante).AppendLine()
         .AppendFormat("   AND CI.Letra = '{0}'", letra).AppendLine()
         .AppendFormat("   AND CI.CentroEmisor = {0}", centroEmisor).AppendLine()
         .AppendFormat("   AND CI.NumeroComprobante = {0}", numeroComprobante).AppendLine()
         .AppendFormat("   AND CI.IdProveedor = {0}", idProveedor).AppendLine()
      End With
      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 AndAlso dt.Columns.Contains(ColumnAlias) Then
         If Not IsDBNull(dt.Rows(0)(ColumnAlias)) AndAlso Not String.IsNullOrWhiteSpace(dt.Rows(0)(ColumnAlias).ToString()) Then
            If Not Long.TryParse(dt.Rows(0)(ColumnAlias).ToString(), result) Then
               result = 0
            End If
         End If
      End If
      Return result
   End Function
End Class
Public Class Listados
    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

   Public Function GetParaImpresionMasiva(ByVal idSucursal As Integer, _
                                             ByVal fechaDesde As Date, _
                                             ByVal fechaHasta As Date, _
                                             ByVal impreso As Entidades.General.Impreso, _
                                             ByVal TipoDocCliente As String, ByVal NroDocCliente As String, _
                                             ByVal idTipoComprobante As String, _
                                             ByVal letra As String, _
                                             ByVal centroEmisor As Short, _
                                             ByVal nroDesde As Long, _
                                             ByVal nroHasta As Long, _
                                             ByVal IdEstadoComprobante As String, _
                                             ByVal discIVA As Boolean, _
                                             ByVal GrabaLibro As String, _
                                             ByVal AfectaCaja As String, _
                                             ByVal IdVendedor As Integer, _
                                             ByVal IdFormasPago As Integer, _
                                             ByVal IdUsuario As String, _
                                             ByVal NumeroReparto As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT V.Fecha ")
         .AppendLine("	,V.IdTipoComprobante")
         .AppendLine("	,TC.DescripcionAbrev ")
         .AppendLine("	,V.Letra ")
         .AppendLine("	,V.CentroEmisor ")
         .AppendLine("	,V.NumeroComprobante ")
         .AppendLine("	,V.IdVendedor ")
         .AppendLine("  ,E.NombreEmpleado as NombreVendedor")
         .AppendLine("	,C.NombreCliente ")
         .AppendLine("	,V.TipoDocCliente ")
         .AppendLine("	,V.NroDocCliente ")
         .AppendLine("	,V.ImporteBruto ")
         .AppendLine("	,V.DescuentoRecargoPorc ")
         .AppendLine("	,V.DescuentoRecargo ")

         'RI
         If discIVA Then
            .AppendLine("	,V.SubTotal ")
            .AppendLine("	,V.TotalImpuestos ")
         Else
            'Monotributo
            .AppendLine("	,ImporteTotal AS SubTotal ")
            .AppendLine("	,0 AS TotalImpuestos ")
         End If

         .AppendLine("	,V.ImporteTotal ")
         .AppendLine("	,CF.NombreCategoriaFiscalAbrev AS NombreCategoriaFiscal ")
         .AppendLine("   ,I.IdImpresora")
         .AppendLine("   ,I.TipoImpresora")
         .AppendLine("   ,V.IdEstadoComprobante")
         .AppendLine("   ,V.Kilos")
         .AppendLine("   ,C.Cuit")
         .AppendLine("   ,VFP.DescripcionFormasPago as FormaDePago")
         .AppendLine("   ,V.IdFormasPago")
         .AppendLine("   ,V.ImportePesos")
         .AppendLine("   ,V.ImporteTickets")
         .AppendLine("   ,V.ImporteTarjetas")
         .AppendLine("   ,V.ImporteCheques")
         .AppendLine("   ,V.CantidadInvocados")
         .AppendLine("   ,V.CantidadLotes")
         .AppendLine("   ,V.Usuario")
         .AppendLine("   ,V.FechaAlta")
         .AppendLine("   ,V.CAE")
         .AppendLine("   ,V.CAEVencimiento")
         .AppendLine("   ,V.Observacion")

         .AppendLine("   ,V.SubTotal-V.Utilidad AS Costo")
         .AppendLine("   ,V.Utilidad")
         .AppendLine("   ,V.FechaTransmisionAFIP")

         .AppendLine("   ,TC.EsElectronico")
         .AppendLine("   ,V.FechaImpresion")

         .AppendLine("   ,V.NumeroReparto")

         .AppendLine("	FROM Ventas V")

         .AppendLine("	 LEFT JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal=CF.IdCategoriaFiscal ")
         .AppendLine("	 LEFT JOIN Impresoras I ON V.CentroEmisor = I.CentroEmisor ")
         .AppendLine("	 LEFT JOIN TiposComprobantes TC ON  V.IdTipoComprobante=TC.IdTipoComprobante ")
         .AppendLine("	 LEFT JOIN VentasFormasPago VFP ON V.IdFormasPago = VFP.IdFormasPago ")
         .AppendLine("	 LEFT JOIN Clientes C ON V.TipoDocCliente=C.TipoDocCliente AND V.NroDocCliente=C.NroDocCliente ")
         .AppendLine("  INNER JOIN Empleados E ON V.IdVendedor = E.IdEmpleado  ")

         .AppendLine("  WHERE V.IdSucursal= " & idSucursal.ToString())

         .AppendLine(" AND V.Fecha BETWEEN '" & fechaDesde.ToString("yyyyMMdd HH:mm:ss") & "' AND '" & fechaHasta.ToString("yyyyMMdd HH:mm:ss") & "'")

         Select Case impreso
            Case Entidades.General.Impreso.SI
               .AppendLine("	AND V.FechaImpresion IS NOT NULL")
            Case Entidades.General.Impreso.NO
               .AppendLine("	AND V.FechaImpresion IS NULL")
            Case Else
         End Select

         If Not String.IsNullOrEmpty(TipoDocCliente) Then
            .AppendLine("	 AND V.TipoDocCliente = '" & TipoDocCliente & "'")
            .AppendLine("	 AND V.NroDocCliente = '" & NroDocCliente & "'")
         End If

         If Not String.IsNullOrEmpty(IdEstadoComprobante) Then
            'Si lo grabariamos de entrada cuando se genera el remito, sacamos el if y dejamos el filtro.
            If IdEstadoComprobante = "PENDIENTE" Then
               .AppendLine("   AND (V.IdEstadoComprobante IS NULL OR V.IdEstadoComprobante = 'INVOCO')")
            ElseIf IdEstadoComprobante = "NO ANULADO" Then
               .AppendLine("   AND (IdEstadoComprobante IS NULL OR IdEstadoComprobante <> 'ANULADO') ")
            Else
               .AppendLine("   AND V.IdEstadoComprobante = '" & IdEstadoComprobante & "'")
            End If

         End If

         If Not String.IsNullOrEmpty(idTipoComprobante) Then
            .AppendLine("	AND V.IdTipoComprobante = '" & idTipoComprobante & "'")
         End If

         If Not String.IsNullOrEmpty(letra) Then
            .AppendLine("  AND V.Letra = '" & letra & "'")
         End If

         If centroEmisor <> 0 Then
            .AppendLine("  AND V.CentroEmisor = " & centroEmisor.ToString())
         End If

         If nroDesde <> 0 Then
            .AppendLine("	  AND V.NumeroComprobante >= " & nroDesde.ToString())
         End If

         If nroHasta <> 0 Then
            .AppendLine("	  AND V.NumeroComprobante <= " & nroHasta.ToString())
         End If

         If GrabaLibro <> "TODOS" Then
            .AppendLine("      AND TC.GrabaLibro = " & IIf(GrabaLibro = "SI", "1", "0").ToString())
         End If

         If AfectaCaja <> "TODOS" Then
            .AppendLine("      AND TC.AfectaCaja = " & IIf(AfectaCaja = "SI", "1", "0").ToString())
         End If

         If IdVendedor > 0 Then
            .AppendLine("	 AND V.IdVendedor = " & IdVendedor)
         End If

         If IdFormasPago > 0 Then
            .AppendLine("	 AND V.IdFormasPago = " & IdFormasPago.ToString())
         End If

         If Not String.IsNullOrEmpty(IdUsuario) Then
            .AppendLine("	 AND V.Usuario = '" & IdUsuario & "'")
         End If

         If NumeroReparto > 0 Then
            .AppendLine("   AND V.NumeroReparto = " & NumeroReparto.ToString())
         End If

         'Le quito la hora, por aquellos comprobantes que puedo hacer con fecha atrasada, los ordenaria distinto
         '.AppendLine("	ORDER BY CONVERT(varchar(11), V.fecha, 120)")
         '.AppendLine("	,V.IdTipoComprobante")
         '.AppendLine("	,V.Letra")
         '.AppendLine("	,V.CentroEmisor")
         '.AppendLine("	,V.NumeroComprobante")
         .AppendLine("	ORDER BY V.fecha")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function
End Class

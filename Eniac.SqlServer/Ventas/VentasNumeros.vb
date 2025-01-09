Public Class VentasNumeros
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasNumeros_U(idSucursal As Integer,
                              idEmpresa As Integer,
                              idTipoComprobante As String,
                              letraFiscal As String,
                              centroEmisor As Short,
                              numero As Long,
                              fecha As Date,
                              comparteNumeracionEntreSucursales As Boolean)
      Dim myQuery = New StringBuilder()

      With myQuery
         .AppendLine("IF NOT EXISTS ( ")
         .AppendLine("    SELECT Numero ")
         .AppendLine("     FROM VentasNumeros")
         .AppendLine("     WHERE 1 = 1")
         If Not comparteNumeracionEntreSucursales Then
            .AppendLine("       AND IdSucursal = " & idSucursal.ToString)
         End If
         .AppendLine("       AND IdTipoComprobante = '" & idTipoComprobante & "'")
         .AppendLine("       AND LetraFiscal = '" & letraFiscal & "'")
         .AppendLine("       AND CentroEmisor = " & centroEmisor.ToString())
         .AppendLine("      ) ")
         .AppendLine("BEGIN")
         .AppendLine("    INSERT INTO VentasNumeros")
         .AppendLine("        (IdSucursal")
         .AppendLine("        ,IdEmpresa")
         .AppendLine("        ,IdTipoComprobante")
         .AppendLine("        ,LetraFiscal")
         .AppendLine("        ,CentroEmisor")
         .AppendLine("        ,Numero")
         .AppendLine("        ,Fecha")
         .AppendLine("        )")

         .AppendFormatLine("    SELECT IdSucursal, IdEmpresa, '{0}', '{1}', {2}, {3}, '{4}'",
                           idTipoComprobante, letraFiscal, centroEmisor, numero, ObtenerFecha(fecha, True))
         .AppendFormatLine("      FROM Sucursales")
         .AppendFormatLine("     WHERE IdSucursal = {0}", idSucursal)
         .AppendLine("END")
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasNumeros")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE VentasNumeros  ")
         .AppendLine("  SET Numero = " & numero & ", Fecha = '" & Me.ObtenerFecha(fecha, True) & "' ")

         If idSucursal >= 0 Then
            .AppendLine("     ,IdSucursal = " & idSucursal.ToString())
         End If

         .AppendLine(" WHERE 1 = 1 ")
         If Not comparteNumeracionEntreSucursales Then
            .AppendLine("   AND IdSucursal = " & idSucursal.ToString)
         End If
         .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
         'modificado para que inserte al comprobante relacionado
         '.AppendLine("   AND ( IdTipoComprobante = '" & idTipoComprobante & "' or IdTipoComprobanteRelacionado LIKE '%" & idTipoComprobante & "%' )")
         .AppendFormatLine("   AND ( IdTipoComprobante = '{0}' OR IdTipoComprobanteRelacionado LIKE '%,{0},%' OR IdTipoComprobanteRelacionado LIKE '%,{0}%' OR IdTipoComprobanteRelacionado LIKE '%{0},%' OR IdTipoComprobanteRelacionado = '{0}' )",
                           idTipoComprobante)
         .AppendLine("   AND LetraFiscal = '" & letraFiscal & "'")
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString)
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasNumeros")

   End Sub

   Public Sub VentasNumeros_D(idSucursal As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("DELETE VentasNumeros ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasNumeros")

   End Sub

   Public Sub VentasNumeros_DxEmisor(idSucursal As Integer, centroEmisor As Short)
      Dim myQuery = New StringBuilder()
      'Si bien el Emisor no se comparte por Sucursal, podria ser un error o algun manejo necesario.
      With myQuery
         .AppendLine("DELETE VentasNumeros ")
         .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
         .AppendLine("   AND CentroEmisor = " & centroEmisor.ToString())
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasNumeros")
   End Sub

   Public Sub VentasNumeros_GenerarNumeracion(idSucursal As Integer, idEmpresa As Integer, centroEmisor As Short)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO VentasNumeros")
         .AppendLine("   (IdSucursal ")
         .AppendLine("   ,IdEmpresa ")
         .AppendLine("   ,IdTipoComprobante ")
         .AppendLine("   ,LetraFiscal ")
         .AppendLine("   ,CentroEmisor ")
         .AppendLine("   ,Numero ")
         .AppendLine("   ,IdTipoComprobanteRelacionado")
         .AppendLine("   ,Fecha) ")
         .AppendLine("SELECT " & idSucursal.ToString() & " AS SucursalNueva")
         .AppendFormatLine("    ,{0}", idEmpresa)
         .AppendLine("    ,IdTipoComprobante")
         .AppendLine("    ,LetraFiscal")
         .AppendLine("    ," & centroEmisor.ToString() & " AS CentroEmisorNuevo ") 'Habria que dar la posibilidad de asignar el Emisor.
         .AppendLine("    ,0 AS NumeroNuevo")
         .AppendLine("    ,IdTipoComprobanteRelacionado")
         .AppendLine("    ,'1900-01-01' AS FechaNueva")
         .AppendLine("  FROM VentasNumeros")
         .AppendLine(" WHERE IdSucursal = 1")  'Casa Central
         .AppendLine("   AND CentroEmisor = 1")  'En general es el NORMAL, hacerlo mejor
      End With

      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "VentasNumeros")

   End Sub

   Public Function VentasNumeros_G1(idSucursal As Integer,
                                    idEmpresa As Integer,
                                    idTipoComprobante As String,
                                    letraFiscal As String,
                                    emisor As Short,
                                    comparteNumeracion As Boolean) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery
         .AppendFormatLine("SELECT *") 'Numero")
         .AppendFormatLine("  FROM VentasNumeros")
         .AppendFormatLine(" WHERE IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND LetraFiscal = '{0}'", letraFiscal)
         .AppendFormatLine("   AND CentroEmisor = {0}", emisor)
         .AppendFormatLine("   AND IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("   AND (IdSucursal = {0}", idSucursal)
         If comparteNumeracion Then
            .AppendFormatLine("    OR IdSucursal = 0")
         End If
         .AppendLine(")")
      End With
      Return GetDataTable(stbQuery)

      'Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      'Dim val As Long = 1

      'If dt.Rows.Count > 0 Then
      '   If Not String.IsNullOrEmpty(dt.Rows(0)("Numero").ToString()) Then
      '      val = Integer.Parse(dt.Rows(0)("Numero").ToString()) + 1
      '   End If
      'End If

      'Return val

   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT VN.* FROM VentasNumeros AS VN").AppendLine()
      End With
   End Sub

   Public Function VentasNumeros_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" ORDER BY VN.IdEmpresa, VN.IdTipoComprobante")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function VentasNumeros_GA_LetrasFiscales(idEmpresa As Integer, tipo As Entidades.TipoComprobante.Tipos?) As DataTable
      Return VentasNumeros_GA_Distinct(Entidades.VentaNumero.Columnas.LetraFiscal, idEmpresa, tipo)
   End Function
   Public Function VentasNumeros_GA_CentroEmisor(idEmpresa As Integer, tipo As Entidades.TipoComprobante.Tipos?) As DataTable
      Return VentasNumeros_GA_Distinct(Entidades.VentaNumero.Columnas.CentroEmisor, idEmpresa, tipo)
   End Function
   Public Function VentasNumeros_GA_Distinct(campo As Entidades.VentaNumero.Columnas, idEmpresa As Integer, tipo As Entidades.TipoComprobante.Tipos?) As DataTable
      Dim stbQuery = New StringBuilder()
      With stbQuery  'LetraFiscal
         .AppendFormatLine("SELECT DISTINCT VN.{0}", campo)
         .AppendFormatLine("  FROM VentasNumeros VN")
         If tipo.HasValue Then
            .AppendFormatLine(" INNER JOIN TiposComprobantes TC ON TC.IdTipoComprobante = VN.IdTipoComprobante")
         End If
         .AppendFormatLine(" WHERE VN.IdEmpresa = {0}", idEmpresa)
         If tipo.HasValue Then
            .AppendFormatLine("   AND TC.Tipo = '{0}'", tipo.ToString())
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function VentasNumeros_G1(idEmpresa As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormat(" WHERE VN.IdEmpresa = {0}", idEmpresa)
         .AppendFormat("   AND VN.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND VN.LetraFiscal = '{0}'", letra)
         .AppendFormat("   AND VN.CentroEmisor = {0}", centroEmisor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function VentasNumeros_G1_PorRelacionado(idEmpresa As Integer, idTipoComprobanteRelacionado As String) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE VN.IdTipoComprobanteRelacionado = '{0}' OR VN.IdTipoComprobanteRelacionado LIKE '{0},%' OR VN.IdTipoComprobanteRelacionado LIKE '%,{0}' OR VN.IdTipoComprobanteRelacionado LIKE '%,{0},%'",
                           idTipoComprobanteRelacionado)
         .AppendFormatLine("   AND VN.IdEmpresa = {0}", idEmpresa)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function PeriodosFiscalesParaControlSaltoNumeracion(idEmpresa As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT TOP 3 *")
         .AppendFormatLine("  FROM PeriodosFiscales")
         .AppendFormatLine(" WHERE 1 = 1")
         .AppendFormatLine("   AND PeriodoFiscal <= (SELECT TOP 1 PeriodoFiscal")
         .AppendFormatLine("                           FROM PeriodosFiscales")
         .AppendFormatLine("                           WHERE VentasHabilitadas = 'True'")
         .AppendFormatLine("                             AND IdEmpresa = {0}", idEmpresa)
         .AppendFormatLine("                           ORDER BY PeriodoFiscal DESC)")
         .AppendFormatLine(" ORDER BY PeriodoFiscal DESC")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetParaControlSaltoNumeracion(idEmpresa As Integer, periodos As List(Of Integer)) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT S.IdEmpresa, V.IdSucursal, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante")
         .AppendFormatLine("  FROM Ventas V")
         .AppendFormatLine(" INNER JOIN TiposComprobantes TP ON TP.IdTipoComprobante = V.IdTipoComprobante")
         .AppendFormatLine(" INNER JOIN Sucursales S ON S.IdSucursal = V.IdSucursal")
         .AppendFormatLine(" INNER JOIN (SELECT PeriodoFiscal")
         .AppendFormatLine("                  , CONVERT(DATETIME, CONVERT(VARCHAR(MAX), PeriodoFiscal) + '01') FechaInicio")
         .AppendFormatLine("                  , DATEADD(SECOND, -1, DATEADD(MONTH, 1, CONVERT(DATETIME, CONVERT(VARCHAR(MAX), PeriodoFiscal) + '01'))) FechaFin")
         .AppendFormatLine("                  , IdEmpresa")
         .AppendFormatLine("               FROM (SELECT *")
         .AppendFormatLine("                       FROM PeriodosFiscales")
         .AppendFormatLine("                      WHERE PeriodoFiscal IN ({0})", String.Join(",", periodos))
         .AppendFormatLine("                        AND IdEmpresa = {0}) PeriodosFiscales", idEmpresa)
         .AppendFormatLine("              WHERE VentasHabilitadas = 'True') PF")
         .AppendFormatLine("         ON V.Fecha BETWEEN PF.FechaInicio AND PF.FechaFin")
         .AppendFormatLine("        AND S.IdEmpresa = PF.IdEmpresa")
         .AppendFormatLine(" WHERE TP.InformaLibroIVA = 'True'")
         .AppendFormatLine(" ORDER BY S.IdEmpresa, V.IdSucursal, V.IdTipoComprobante, V.Letra, V.CentroEmisor, V.NumeroComprobante")
      End With
      Return GetDataTable(stb)
   End Function

End Class
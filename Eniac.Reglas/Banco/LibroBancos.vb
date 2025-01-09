Public Class LibroBancos
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "LibroBancos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Enumeraciones"

   Public Enum TipoOperacion
      Nuevo
      Modificacion
   End Enum

#End Region

#Region "Metodos"

   Public Function BuscarV2(entidad As Entidades.Buscar, idSucursal As Integer, idCuentaBancaria As Integer, FechaDesde As Date, FechaHasta As Date, concilidado As Entidades.Publicos.SiNoTodos) As DataTable

      Dim stbQuery = New StringBuilder()

      entidad.Columna = "Lb." & entidad.Columna

      Select Case entidad.Columna

         Case "Lb.DescCuentaBancaria"
            entidad.Columna = "Cbs.CodigoBancario + ' - ' + B2.NombreBanco + ' (' + L2.NombreLocalidad + ')'"

         Case "Lb.NombreCuentaBanco"
            entidad.Columna = "Cb." + entidad.Columna.Replace("Lb.", "")

         Case "Lb.IdBanco"
            entidad.Columna = "Cbs." + entidad.Columna.Replace("Lb.", "")

         Case "Lb.DescCheque"
            entidad.Columna = "Convert(varchar,Lb.NumeroCheque) + ' - ' + B.NombreBanco + ' (' + L.NombreLocalidad + ' )'"

      End Select

      Me.SelectFiltrado(stbQuery)

      With stbQuery
         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE Lb.IdSucursal = " & idSucursal.ToString())
            .AppendLine("     AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         Else
            .AppendLine(" WHERE Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If
         .AppendLine("     AND Lb.FechaAplicado Between '" & FechaDesde.ToString("yyyyMMdd") & "  00:00:00' And '" & FechaHasta.ToString("yyyyMMdd") & " 23:59:59' ")
         .AppendLine("     AND " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")

         If concilidado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendLine("  AND Lb.Conciliado= " & IIf(concilidado = Entidades.Publicos.SiNoTodos.SI, "1", "0").ToString())
         End If

         .AppendLine(" ORDER BY CONVERT(varchar(11), Lb.FechaAplicado, 120), CONVERT(varchar(11), Lb.FechaMovimiento, 120), Lb.NumeroMovimiento")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetTodos(idSucursal As Integer, idCuentaBancaria As Integer, FechaDesde As DateTime, FechaHasta As DateTime, esModificable As Boolean?, concilidado As Entidades.Publicos.SiNoTodos) As DataTable

      Dim stbQuery = New StringBuilder()

      Me.SelectFiltrado(stbQuery)

      With stbQuery
         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE Lb.IdSucursal = " & idSucursal.ToString())
            .AppendLine("     AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         Else
            .AppendLine(" WHERE Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If
         .AppendLine("     AND Lb.FechaAplicado Between '" & FechaDesde.ToString("yyyyMMdd") & "  00:00:00' And '" & FechaHasta.ToString("yyyyMMdd") & " 23:59:59' ")
         If esModificable.HasValue Then
            .AppendFormat(" AND lb.EsModificable = {0}", IIf(esModificable.Value, 1, 0))
         End If

         If concilidado <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendLine("  AND Lb.Conciliado= " & IIf(concilidado = Entidades.Publicos.SiNoTodos.SI, "1", "0").ToString())
         End If

         .AppendLine(" ORDER BY CONVERT(varchar(11), Lb.FechaAplicado, 120), CONVERT(varchar(11), Lb.FechaMovimiento, 120), Lb.NumeroMovimiento")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetMovimientos(idSucursal As Integer,
                                  idMoneda As Integer, idCuentaBancaria As Integer,
                                  fechaDesde As Date, fechaHasta As Date,
                                  tipoFecha As Entidades.LibroBanco.TiposFechasLibrosBancos,
                                  concilidado As Entidades.Publicos.SiNoTodos,
                                  posdatado As String, idCuentaBanco As Integer, idGrupoCuenta As String) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim sql = New SqlServer.LibroBancos(da)
            Return sql.GetMovimientos(idSucursal, idMoneda, idCuentaBancaria,
                                      fechaDesde, fechaHasta,
                                      tipoFecha, concilidado,
                                      posdatado, idCuentaBanco, Publicos.UnificaLibrosDeBanco, idGrupoCuenta)

         End Function)
   End Function

   Public Function GetPosdatados(idSucursal As Integer, idCuentaBancaria As Integer,
                                 fechaDesde As Date, fechaHasta As Date,
                                 fechaAplicadoDesde As Date, fechaAplicadoHasta As Date,
                                 confirmado As String, posdatado As String,
                                 unificaLibroBancos As Boolean) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .AppendLine("SELECT Lb.IdSucursal, ")
         .AppendLine("   	Cbs.IdCuentaBancaria, ")
         .AppendLine("   	Lb.NumeroMovimiento, ")
         .AppendLine("   	Lb.FechaMovimiento, ")
         .AppendLine("   	Cb.IdCuentaBanco, ")
         .AppendLine("   	Cb.NombreCuentaBanco, ")
         .AppendLine("   	Abs(Lb.Importe) Importe, ")
         .AppendLine("   	Lb.IdTipoMovimiento, ")
         .AppendLine("   	Convert(varchar,C.NumeroCheque) + ' - ' + B.NombreBanco  + ' - ' + Convert(varchar,C.IdBancoSucursal) + ' (' + L.NombreLocalidad + ' )'  DescCheque, ")
         .AppendLine("   	Lb.FechaAplicado, ")
         .AppendLine("   	Case Lb.Conciliado ")
         .AppendLine("   		When 1 Then 'Si' ")
         .AppendLine("   		When 0 Then 'No' ")
         .AppendLine("   	End Conciliado, ")
         .AppendLine("   	Observacion ")
         .AppendLine("   	,Lb.EsModificable ")
         .AppendLine("     ,Lb.IdEjercicio")
         .AppendLine("   	,Lb.IdPlanCuenta")
         .AppendLine("   	,Lb.IdAsiento")
         .AppendLine("   	,Lb.IdCentroCosto ")
         .AppendLine("   	,CCC.NombreCentroCosto ")
         .AppendLine("     ,Lb.GeneraContabilidad")
         .AppendLine("   FROM LibrosBancos Lb Inner Join CuentasBancarias Cbs On Lb.IdCuentaBancaria = Cbs.IdCuentaBancaria ")
         .AppendLine("   	Inner Join Localidades L2 On Cbs.IdLocalidad = L2.IdLocalidad ")
         .AppendLine("   	Inner Join Provincias P2 on L2.IdProvincia = P2.IdProvincia ")
         .AppendLine("   	Inner Join CuentasBancos Cb On Lb.IdCuentaBanco = Cb.IdCuentaBanco ")
         .AppendLine("   	Left Outer Join Bancos B On Lb.IdBancoCheque = B.IdBanco ")
         .AppendLine("   	Left Outer Join Cheques C On Lb.IdCheque = C.IdCheque")
         .AppendLine("   	Left Outer Join Localidades L On C.IdLocalidad = L.IdLocalidad ")
         .AppendLine("   	Left Outer Join Provincias P on L.IdProvincia = P.IdProvincia ")
         .AppendLine("   LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = Lb.IdCentroCosto")

         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE Lb.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         Else
            .AppendLine(" WHERE Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If

         '.AppendLine("     AND Lb.FechaAplicado > Lb.FechaMovimiento ")
         If confirmado = "SI" Then
            .AppendLine("   And Lb.Conciliado = 'True' ")
         ElseIf confirmado = "NO" Then
            .AppendLine("   And Lb.Conciliado = 'False' ")
         End If
         If posdatado = "SI" Then
            .AppendLine("   And Lb.FechaMovimiento <> Lb.FechaAplicado ")
         ElseIf posdatado = "NO" Then
            .AppendLine("   And Lb.FechaMovimiento = Lb.FechaAplicado ")
         End If
         .AppendLine("   And Lb.FechaMovimiento Between '" & fechaDesde.ToString("yyyyMMdd") & " 00:00:00' And '" & fechaHasta.ToString("yyyyMMdd") & " 23:59:59' ")
         .AppendLine("   And Lb.FechaAplicado Between '" & fechaAplicadoDesde.ToString("yyyyMMdd") & " 00:00:00' And '" & fechaAplicadoHasta.ToString("yyyyMMdd") & " 23:59:59' ")
      End With

      Return da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function ResumenDeBanco(idSucursal As Integer, idCuentaBancaria As Integer, fechaDesde As Date, fechaHasta As Date, esFechaMovimiento As Boolean) As DataTable
      Return New SqlServer.LibroBancos(da).ResumenDeBanco(idSucursal, idCuentaBancaria, fechaDesde, fechaHasta, esFechaMovimiento)
   End Function

   Public Function ResumenAnual(idSucursal As Integer,
                                Anio As Integer,
                                idMoneda As Integer,
                                idCuentaBancaria As Integer) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT ")
         .AppendLine("    IdCuentaBanco, NombreCuentaBanco,")
         .AppendLine("    SUM(Enero) AS Enero, SUM(Febrero) AS Febrero, SUM(Marzo) AS Marzo,")
         .AppendLine("    SUM(Abril) AS Abril, SUM(Mayo) AS Mayo, SUM(Junio) AS Junio, SUM(Julio) AS Julio,")
         .AppendLine("    SUM(Agosto) AS Agosto, SUM(Septiembre) AS Septiembre, SUM(Octubre) AS Octubre,")
         .AppendLine("    SUM(Noviembre) AS Noviembre, SUM(Diciembre) AS Diciembre,")
         .AppendLine("    SUM(Enero+Febrero+Marzo+Abril+Mayo+Junio+Julio+Agosto+Septiembre+Octubre+Noviembre+Diciembre) AS Total")
         .AppendLine("  FROM")
         .AppendLine("( ")
         .AppendLine("SELECT Cb.IdCuentaBanco, Cb.NombreCuentaBanco,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 1 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Enero,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 2 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Febrero,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 3 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Marzo,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 4 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Abril,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 5 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Mayo,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 6 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Junio,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 7 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Julio,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 8 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Agosto,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 9 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Septiembre,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 10 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Octubre,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 11 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Noviembre,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 12 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Diciembre")
         .AppendLine(" FROM LibrosBancos LB")

         .AppendLine(" INNER JOIN CuentasBancos Cb ON LB.IdCuentaBanco = Cb.IdCuentaBanco")
         .AppendLine(" INNER JOIN CuentasBancarias CBA ON LB.IdCuentaBancaria = CBA.IdCuentaBancaria")

         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE Lb.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND CBA.IdMoneda = " & idMoneda.ToString())
         Else
            .AppendLine(" WHERE CBA.IdMoneda = " & idMoneda.ToString())
         End If

         If idCuentaBancaria > 0 Then
            .AppendLine("   AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If

         .AppendLine("   AND YEAR(LB.FechaAplicado) = " & Anio.ToString())

         .AppendLine(" GROUP BY Cb.IdCuentaBanco, Cb.NombreCuentaBanco, LB.FechaAplicado")
         .AppendLine(") Detalle")
         .AppendLine("GROUP BY IdCuentaBanco, NombreCuentaBanco")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function ResumenAnualPorMoneda(idSucursal As Integer,
                                         idMoneda As Integer,
                                         Anio As Integer) As DataTable

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT ")
         .AppendLine("    IdCuentaBanco, NombreCuentaBanco,")
         .AppendLine("    SUM(Enero) AS Enero, SUM(Febrero) AS Febrero, SUM(Marzo) AS Marzo,")
         .AppendLine("    SUM(Abril) AS Abril, SUM(Mayo) AS Mayo, SUM(Junio) AS Junio, SUM(Julio) AS Julio,")
         .AppendLine("    SUM(Agosto) AS Agosto, SUM(Septiembre) AS Septiembre, SUM(Octubre) AS Octubre,")
         .AppendLine("    SUM(Noviembre) AS Noviembre, SUM(Diciembre) AS Diciembre,")
         .AppendLine("    SUM(Enero+Febrero+Marzo+Abril+Mayo+Junio+Julio+Agosto+Septiembre+Octubre+Noviembre+Diciembre) AS Total")
         .AppendLine("  FROM")
         .AppendLine("( ")
         .AppendLine("SELECT Cb.IdCuentaBanco, Cb.NombreCuentaBanco,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 1 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Enero,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 2 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Febrero,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 3 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Marzo,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 4 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Abril,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 5 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Mayo,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 6 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Junio,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 7 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Julio,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 8 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Agosto,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 9 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Septiembre,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 10 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Octubre,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 11 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Noviembre,")
         .AppendLine(" CASE MONTH(LB.FechaAplicado)")
         .AppendLine("      WHEN 12 Then SUM(Importe)")
         .AppendLine("      ELSE 0 ")
         .AppendLine(" END Diciembre")
         .AppendLine(" FROM LibrosBancos LB")

         .AppendLine(" INNER JOIN CuentasBancos Cb ON LB.IdCuentaBanco = Cb.IdCuentaBanco")
         .AppendLine(" INNER JOIN CuentasBancarias CBA ON LB.IdCuentaBancaria = CBA.IdCuentaBancaria")

         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE Lb.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND CBA.IdMoneda =" & idMoneda.ToString())
         Else
            .AppendLine(" WHERE CBA.IdMoneda =" & idMoneda.ToString())
         End If

         .AppendLine("   AND YEAR(LB.FechaAplicado) = " & Anio.ToString())

         .AppendLine(" GROUP BY Cb.IdCuentaBanco, Cb.NombreCuentaBanco, LB.FechaAplicado")
         .AppendLine(") Detalle")
         .AppendLine("GROUP BY IdCuentaBanco, NombreCuentaBanco")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Function GetUno(idSucursal As Integer, idCuentaBancaria As Integer, NumeroMovimiento As Integer) As Entidades.LibroBanco

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Length = 0
         .AppendLine("SELECT ")
         .AppendLine("    Lb.IdCuentaBancaria, ")
         .AppendLine("    Cbs.NombreCuenta , ")
         .AppendLine("    Lb.NumeroMovimiento, ")
         .AppendLine("    Lb.IdCuentaBanco, ")
         .AppendLine("    Cb.NombreCuentaBanco, ")
         .AppendLine("    Lb.IdTipoMovimiento, ")
         .AppendLine("    Abs(Lb.Importe) Importe, ")
         .AppendLine("    Lb.FechaMovimiento, ")
         .AppendLine("    Convert(varchar,C.NumeroCheque) + ' - ' + B.NombreBanco  + ' - ' + Convert(varchar,C.IdLocalidad) + ' (' + L.NombreLocalidad + ' )'  DescCheque, ")
         .AppendLine("    Lb.FechaAplicado, ")
         .AppendLine("    Lb.Observacion, ")
         .AppendLine("    Lb.Conciliado ")
         .AppendLine("   	,Lb.EsModificable ")
         .AppendLine("     ,Lb.IdEjercicio")
         .AppendLine("   	,Lb.IdPlanCuenta ")
         .AppendLine("   	,Lb.IdAsiento ")
         .AppendLine("   	,Lb.IdCentroCosto ")
         .AppendLine("   	,CCC.NombreCentroCosto ")
         .AppendLine("     ,Lb.GeneraContabilidad")
         .AppendLine("     ,Lb.IdCheque")
         .AppendFormatLine("      ,{0}", Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("      ,{0}", Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())
         .AppendFormatLine("      ,Lb.{0}", Entidades.LibroBanco.Columnas.FechaActualizacionAsiento.ToString())
         .AppendFormatLine("   	, Lb.IdConceptoCM05")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")
         .AppendLine("  FROM")
         .AppendLine("    LibrosBancos Lb Inner Join CuentasBancarias Cbs On Lb.IdCuentaBancaria = Cbs.IdCuentaBancaria ")
         .AppendLine("    INNER JOIN CuentasBancariasClase Ccb On Cbs.IdCuentaBancariaClase = Ccb.IdCuentaBancariaClase ")
         .AppendLine("    INNER JOIN CuentasBancos Cb On Lb.IdCuentaBanco = Cb.IdCuentaBanco ")
         .AppendLine("    LEFT OUTER JOIN Cheques C On Lb.IdCheque = C.IdCheque")
         .AppendLine("    LEFT OUTER JOIN Localidades L On C.IdLocalidad = L.IdLocalidad ")
         .AppendLine("    LEFT OUTER JOIN Bancos B On C.IdBanco = B.IdBanco ")
         .AppendLine("   LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = Lb.IdCentroCosto")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = Lb.IdConceptoCM05")

         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE Lb.IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         Else
            .AppendLine(" WHERE Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If

         .AppendLine("    AND NumeroMovimiento = " & NumeroMovimiento.ToString())
      End With

      Dim drLibroBanco As DataRow = Me.da.GetDataTable(stbQuery.ToString()).Rows(0)

      Dim eLibroBanco As Entidades.LibroBanco = New Entidades.LibroBanco(actual.Sucursal.Id, actual.Nombre, actual.Pwd) With {
         .IdCuentaBancaria = Integer.Parse(drLibroBanco("IdCuentaBancaria").ToString()),
         .NumeroMovimiento = Integer.Parse(drLibroBanco("NumeroMovimiento").ToString()),
         .IdCuentaBanco = Integer.Parse(drLibroBanco("IdCuentaBanco").ToString()),
         .IdTipoMovimiento = drLibroBanco("IdTipoMovimiento").ToString(),
         .Importe = Decimal.Parse(drLibroBanco("Importe").ToString()),
         .FechaMovimiento = Convert.ToDateTime(drLibroBanco("FechaMovimiento"))
      }

      If drLibroBanco("IdCheque") IsNot DBNull.Value Then
         eLibroBanco.IdCheque = drLibroBanco.Field(Of Long?)(Entidades.LibroBanco.Columnas.IdCheque.ToString())
         eLibroBanco.DescCheque = drLibroBanco("DescCheque").ToString()
      End If

      eLibroBanco.FechaAplicado = Convert.ToDateTime(drLibroBanco("FechaAplicado"))
      eLibroBanco.Observacion = drLibroBanco("Observacion").ToString()

      eLibroBanco.Conciliado = Convert.ToBoolean(drLibroBanco("Conciliado"))
      eLibroBanco.DescCuentaBancaria = drLibroBanco("NombreCuenta").ToString()

      eLibroBanco.NombreCuentaBanco = drLibroBanco("NombreCuentaBanco").ToString()

      eLibroBanco.EsModificable = CBool(drLibroBanco("EsModificable"))
      eLibroBanco.GeneraContabilidad = CBool(drLibroBanco("GeneraContabilidad"))

      If Not IsDBNull(drLibroBanco("IdEjercicio")) Then
         eLibroBanco.IdEjercicio = Convert.ToInt32(drLibroBanco("IdEjercicio"))
      End If
      If Not IsDBNull(drLibroBanco("IdPlanCuenta")) Then
         eLibroBanco.IdPlanCuenta = Convert.ToInt32(drLibroBanco("IdPlanCuenta"))
      End If
      If Not IsDBNull(drLibroBanco("IdAsiento")) Then
         eLibroBanco.IdAsiento = Convert.ToInt32(drLibroBanco("IdAsiento"))
      End If

      If Not String.IsNullOrWhiteSpace(drLibroBanco(Entidades.LibroBanco.Columnas.IdCentroCosto.ToString()).ToString()) Then
         eLibroBanco.CentroCosto = New ContabilidadCentrosCostos(da)._GetUna(Convert.ToInt32(drLibroBanco(Entidades.LibroBanco.Columnas.IdCentroCosto.ToString())))
      End If

      '# Tipo de COmprobante y Nro de Depósito
      If Not IsDBNull(drLibroBanco(Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())) Then
         eLibroBanco.IdTipoComprobante = drLibroBanco.Field(Of String)(Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())
      End If
      If Not IsDBNull(drLibroBanco(Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())) Then
         eLibroBanco.NumeroDeposito = drLibroBanco.Field(Of Long?)(Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())
      End If

      eLibroBanco.FechaActualizacionAsiento = drLibroBanco.Field(Of Date)(Entidades.LibroBanco.Columnas.FechaActualizacionAsiento.ToString())

      eLibroBanco.IdConceptoCM05 = drLibroBanco.Field(Of Integer?)(Entidades.LibroBanco.Columnas.IdConceptoCM05.ToString())

      Return eLibroBanco

   End Function

   Public Function GetProximoNumeroDeMovimiento(idSucursal As Integer, idCuentaBancaria As Integer) As Integer

      Dim ProximoNumeroMovimiento As Integer = 1

      Dim stbQuery = New StringBuilder()

      With stbQuery
         .Append("SELECT ")
         .Append(" Max(NumeroMovimiento) + 1 ")
         .Append(" FROM LibrosBancos ")
         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE IdSucursal = " & idSucursal.ToString())
            .AppendLine("   AND IdCuentaBancaria = " & idCuentaBancaria.ToString())
         Else
            .AppendLine(" WHERE IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())

      If dt.Rows(0)(0) IsNot DBNull.Value Then
         ProximoNumeroMovimiento = CInt(dt.Rows(0)(0))
      End If

      Return ProximoNumeroMovimiento

   End Function

   Public Sub InsertarMovimiento(eLibroBanco As Entidades.LibroBanco)

      Try

         Me.da.OpenConection()
         Me.da.BeginTransaction()

         If eLibroBanco.GeneraContabilidad Then
            If Publicos.TieneModuloContabilidad And ContabilidadPublicos.UtilizaCentroCostos(da) Then
               If eLibroBanco.CentroCosto Is Nothing Then
                  Dim cuenta = New CuentasBancos().GetUna(eLibroBanco.IdCuentaBanco)
                  eLibroBanco.CentroCosto = cuenta.CentroCosto
                  If eLibroBanco.CentroCosto Is Nothing Then
                     Throw New Exception(String.Format("La cuenta de banco {0} - {1} no tiene asignado un centro de costos. Por favor verifique la configuración y reintente.",
                                                       cuenta.IdCuentaBanco, cuenta.NombreCuentaBanco))
                  End If
               End If
            End If
         End If

         eLibroBanco.NumeroMovimiento = Me.GetProximoNumeroDeMovimiento(eLibroBanco.IdSucursal, eLibroBanco.IdCuentaBancaria)

         Dim sql As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)

         sql.LibroBancos_I(eLibroBanco.IdSucursal, eLibroBanco.IdCuentaBancaria, eLibroBanco.NumeroMovimiento, eLibroBanco.IdCuentaBanco,
                           eLibroBanco.IdTipoMovimiento, eLibroBanco.Importe, eLibroBanco.FechaMovimiento, eLibroBanco.IdCheque,
                           eLibroBanco.FechaAplicado, eLibroBanco.Observacion, eLibroBanco.Conciliado, eLibroBanco.EsModificable,
                           eLibroBanco.IdEjercicio, eLibroBanco.IdPlanCuenta, eLibroBanco.IdAsiento,
                           eLibroBanco.IdCentroCosto, eLibroBanco.GeneraContabilidad, eLibroBanco.IdTipoComprobante, eLibroBanco.NumeroDeposito,
                           eLibroBanco.IdConceptoCM05)

         If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea And eLibroBanco.GeneraContabilidad Then
            Dim ctbl As Contabilidad = New Contabilidad(da)
            ctbl.RegistraContabilidad(eLibroBanco)
         End If

         ' '' ''ars 07/05/2014  Contabilidad
         '' ''If Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.CONTABILIDADEJECUTARENLINEA)) Then
         '' ''   Me.CargarContabilidad(ent)
         '' ''End If
         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Public Sub AgregaMovimiento(ent As Entidades.LibroBanco)
      Dim sql = New SqlServer.LibroBancos(da)
      If ent.FechaActualizacionAsiento = New DateTime() Then
         ent.FechaActualizacionAsiento = Date.Now
      End If
      sql.LibroBancos_I(ent.IdSucursal, ent.IdCuentaBancaria, ent.NumeroMovimiento, ent.IdCuentaBanco,
                        ent.IdTipoMovimiento, ent.Importe, ent.FechaMovimiento, ent.IdCheque,
                        ent.FechaAplicado, ent.Observacion, ent.Conciliado, ent.EsModificable,
                        ent.IdEjercicio, ent.IdPlanCuenta, ent.IdAsiento, ent.IdCentroCosto, ent.GeneraContabilidad,
                        ent.IdTipoComprobante, ent.NumeroDeposito, ent.IdConceptoCM05)
   End Sub

   Public Sub ActualizarMovimiento(eLibroBanco As Entidades.LibroBanco)

      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)

         '' ''If Boolean.Parse(New Reglas.Parametros(da)._GetValor(Parametro.Parametros.CONTABILIDADEJECUTARENLINEA)) Then
         '' ''   Me.EditarContabilidad(eLibroBanco)
         '' ''End If

         If eLibroBanco.GeneraContabilidad Then
            If Publicos.TieneModuloContabilidad And ContabilidadPublicos.UtilizaCentroCostos(da) Then
               If eLibroBanco.CentroCosto Is Nothing Then
                  Dim cuenta = New CuentasBancos().GetUna(eLibroBanco.IdCuentaBanco)
                  eLibroBanco.CentroCosto = cuenta.CentroCosto
                  If eLibroBanco.CentroCosto Is Nothing Then
                     Throw New Exception(String.Format("La cuenta de banco {0} - {1} no tiene asignado un centro de costos. Por favor verifique la configuración y reintente.",
                                                       cuenta.IdCuentaBanco, cuenta.NombreCuentaBanco))
                  End If
               End If
            End If
         End If

         sql.LibroBancos_U(eLibroBanco.IdSucursal, eLibroBanco.IdCuentaBancaria, eLibroBanco.NumeroMovimiento, eLibroBanco.IdCuentaBanco,
                           eLibroBanco.IdTipoMovimiento, eLibroBanco.Importe, eLibroBanco.FechaMovimiento, eLibroBanco.IdCheque,
                           eLibroBanco.FechaAplicado, eLibroBanco.Observacion, eLibroBanco.Conciliado, eLibroBanco.EsModificable,
                           eLibroBanco.IdEjercicio, eLibroBanco.IdPlanCuenta, eLibroBanco.IdAsiento, eLibroBanco.IdCentroCosto, eLibroBanco.GeneraContabilidad,
                           eLibroBanco.IdTipoComprobante, eLibroBanco.NumeroDeposito, eLibroBanco.IdConceptoCM05)


         If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea And eLibroBanco.GeneraContabilidad And
            eLibroBanco.IdEjercicio.HasValue And eLibroBanco.IdAsiento.HasValue And eLibroBanco.IdPlanCuenta.HasValue Then
            Dim ctbl As Contabilidad = New Contabilidad(da)
            If ctbl.AsientoProcesadoComoDefinitivo(eLibroBanco.IdEjercicio, eLibroBanco.IdPlanCuenta, eLibroBanco.IdAsiento) Then
               Throw New Exception("No es posible Modificar el movimiento de banco porque el asiento contable asociado ya fue procesado como DEFINITIVO.")
            End If
            ctbl.RegenerarDetalleContabilidad(eLibroBanco)
            ''Me.EditarContabilidad(eCajaDetalle)
         End If

         da.CommitTransaction()

      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Sub EliminarMovimiento(eLibroBanco As Entidades.LibroBanco) ''IdSucursal As Integer, IdCuentaBancaria As Integer, NumeroMovimiento As Integer)

      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)

         ' '' ''Si tiene Contablilidad elimino el asiento temporal, si tenia asiento definitivo, no llogo hasta aca
         '' ''If Boolean.Parse(New Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.CONTABILIDADEJECUTARENLINEA)) Then
         '' ''   Dim eLibroBanco As Entidades.LibroBanco
         '' ''   eLibroBanco = Me.GetUno(IdSucursal, IdCuentaBancaria, NumeroMovimiento)
         '' ''   Dim dtAsientoTmp As DataTable
         '' ''   Dim oContabilidad As Reglas.ContabilidadProcesos = New Reglas.ContabilidadProcesos


         '' ''   Dim tipoproceso As String = "MOVBANCO"
         '' ''   Dim DescAsiento As String = Me.ObtenerDescAsiento(eLibroBanco)
         '' ''   dtAsientoTmp = oContabilidad.GetAsientoTmp(tipoproceso, DescAsiento)
         '' ''   If dtAsientoTmp.Rows.Count > 0 Then
         '' ''      Dim sqlAsientoTmp As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
         '' ''      sqlAsientoTmp.Asiento_D_Detalle_Tmp(CInt(dtAsientoTmp.Rows(0)("IdPlanCuenta").ToString()), CInt(dtAsientoTmp.Rows(0)("IdAsiento").ToString()))
         '' ''      sqlAsientoTmp.Asiento_D_Tmp(CInt(dtAsientoTmp.Rows(0)("IdPlanCuenta").ToString()), CInt(dtAsientoTmp.Rows(0)("IdAsiento").ToString()))
         '' ''   End If

         '' ''End If

         'Si tiene Contablilidad elimino el asiento temporal, si tenia asiento definitivo, no llogo hasta aca
         'If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea And eLibroBanco.IdPlanCuenta.HasValue And eLibroBanco.IdAsiento.HasValue Then
         If Publicos.TieneModuloContabilidad And eLibroBanco.IdEjercicio.HasValue And eLibroBanco.IdPlanCuenta.HasValue And eLibroBanco.IdAsiento.HasValue Then
            Dim ctbl As Contabilidad = New Contabilidad(da)
            If ctbl.AsientoProcesadoComoDefinitivo(eLibroBanco.IdEjercicio, eLibroBanco.IdPlanCuenta, eLibroBanco.IdAsiento) Then
               Throw New Exception("No es posible Eliminar el movimiento de caja porque el asiento contable asociado ya fue procesado como DEFINITIVO.")
            End If
            ctbl.EliminarAsientoContabilidad(eLibroBanco)
         End If

         sql.LibroBancos_D(eLibroBanco.IdSucursal, eLibroBanco.IdCuentaBancaria, eLibroBanco.NumeroMovimiento)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function ConciliarMovimiento(IdSucursal As Integer, IdCuentaBancaria As Integer, NumeroMovimiento As Integer, Conciliado As Boolean) As Boolean

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)
         If Not sql.LibroBancos_Existe(IdSucursal, IdCuentaBancaria, NumeroMovimiento) Then
            Throw New Exception("El movimiento indicado no existe.")
         End If
         sql.LibroBancos_Conciliar(IdSucursal, IdCuentaBancaria, NumeroMovimiento, Conciliado)
         da.CommitTransaction()

         Dim dt As DataTable = sql.LibroBancos_G1(IdSucursal, IdCuentaBancaria, NumeroMovimiento)
         Return Convert.ToBoolean(dt.Rows(0)(Entidades.LibroBanco.Columnas.Conciliado.ToString()))


      Catch ex As Exception
         da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         da.CloseConection()
      End Try

   End Function

   Public Function GetSaldo(IdSucursal As Integer, idCuentaBancaria As Integer, FechaTope As Date, TipoSaldo As String) As Decimal

      Dim ReturnValue As Decimal = 0D

      Dim myQuery = New StringBuilder()

      With myQuery
         .Length = 0
         .AppendLine("SELECT Sum(Importe) AS Saldo FROM LibrosBancos Lb")

         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE Lb.IdSucursal = " & IdSucursal.ToString())
            .AppendLine("   AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         Else
            .AppendLine(" WHERE Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
         End If

         .AppendLine("   AND CONVERT(varchar(10), Lb.FechaAplicado, 120) <= '" & FechaTope.ToString("yyyy-MM-dd") & "'")

         If TipoSaldo = "CONCILIADO" Then
            .AppendLine("   AND Lb.Conciliado = 'True'")
         End If

      End With

      Dim drSaldo As DataRow = da.GetDataTable(myQuery.ToString()).Rows(0)

      If drSaldo("Saldo") IsNot DBNull.Value Then
         ReturnValue = drSaldo.Field(Of Decimal?)(0).IfNull()
      End If

      Return ReturnValue

   End Function

   ''''Public Function GetSaldoConciliado(IdSucursal As Integer, idCuentaBancaria As Integer) As Decimal

   ''''   Dim ReturnValue As Decimal = CDec(0.0)

   ''''   Dim myQuery = New StringBuilder()

   ''''   With myQuery
   ''''      .Length = 0
   ''''      .AppendLine("SELECT Sum(Importe) AS SaldoConciliado FROM LibrosBancos Lb")

   ''''      If Not Publicos.UnificaLibrosDeBanco Then
   ''''         .AppendLine(" WHERE Lb.IdSucursal = " & IdSucursal.ToString())
   ''''         .AppendLine("   AND Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
   ''''      Else
   ''''         .AppendLine(" WHERE Lb.IdCuentaBancaria = " & idCuentaBancaria.ToString())
   ''''      End If

   ''''      .AppendLine("   AND CONVERT(varchar(10), Lb.FechaAplicado, 120) <= '" & Now.Date.ToString("yyyy-MM-dd") & "'")
   ''''      .AppendLine("   AND Lb.Conciliado = 'True'")
   ''''   End With

   ''''   Dim drSaldo As DataRow = Me.DataServer().GetDataTable(myQuery.ToString()).Rows(0)

   ''''   If drSaldo("SaldoConciliado") IsNot DBNull.Value Then
   ''''      ReturnValue = Convert.ToDecimal(drSaldo("SaldoConciliado"))
   ''''   End If

   ''''   Return ReturnValue

   ''''End Function

   Public Sub IntercambiarMovimiento(IdSucursal As Integer, IdCuentaBancaria As Integer, NuevoIdCuentaBancaria As Integer, NumeroMovimiento As Integer)

      Try

         da.OpenConection()
         da.BeginTransaction()

         Dim NNMov As Integer = Me.GetProximoNumeroDeMovimiento(IdSucursal, NuevoIdCuentaBancaria)

         Dim sql As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)
         sql.LibroBancos_Intercambiar(IdSucursal, IdCuentaBancaria, NuevoIdCuentaBancaria, NumeroMovimiento, NNMov)

         Dim eLibroBanco = New Reglas.LibroBancos(da).GetUno(IdSucursal, NuevoIdCuentaBancaria, NNMov)

         If Publicos.TieneModuloContabilidad And Publicos.ContabilidadEjecutarEnLinea And eLibroBanco.GeneraContabilidad And
            eLibroBanco.IdEjercicio.HasValue And eLibroBanco.IdAsiento.HasValue And eLibroBanco.IdPlanCuenta.HasValue Then
            Dim ctbl As Contabilidad = New Contabilidad(da)
            If ctbl.AsientoProcesadoComoDefinitivo(eLibroBanco.IdEjercicio, eLibroBanco.IdPlanCuenta, eLibroBanco.IdAsiento) Then
               Throw New Exception("No es posible Modificar el movimiento de banco porque el asiento contable asociado ya fue procesado como DEFINITIVO.")
            End If
            ctbl.RegenerarDetalleContabilidad(eLibroBanco)
            ''Me.EditarContabilidad(eCajaDetalle)
         End If

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Function GetAniosDeLibro(idSucursal As Integer) As DataTable

      Dim myQuery = New StringBuilder()

      With myQuery
         .Append("SELECT DISTINCT YEAR(FechaAplicado) Anio FROM LibrosBancos")

         If Not Publicos.UnificaLibrosDeBanco Then
            .AppendLine(" WHERE IdSucursal = " & idSucursal)
         End If

         .Append(" ORDER BY 1 DESC")

      End With

      Return da.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetSaldosCuentasBancarias(idSucursal As Integer, idMoneda As Integer, fechaSaldo As Date,
                                             activas As Entidades.Publicos.SiNoTodos, conSaldo As Entidades.Publicos.SiNoTodos,
                                             idClase As Integer) As DataTable
      Return New SqlServer.LibroBancos(da).
                  GetSaldosCuentasBancarias(idSucursal, idMoneda, fechaSaldo, activas, conSaldo,
                                            Publicos.UnificaLibrosDeBanco, idClase)
   End Function

   Public Sub EliminarMovimientoPorCheque(idCheque As Long)

      Dim sql As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)

      sql.LibroBancos_DPorCheque(idCheque)

   End Sub

   Public Sub EliminarDepositosCuentasBancos(idSucursal As Integer, numeroDeposito As Long, idTipoComprobante As String)
      Dim sql As SqlServer.LibroBancos = New SqlServer.LibroBancos(da)
      Dim rDepositosCuentasBancos As Reglas.DepositosCuentasBancos = New Reglas.DepositosCuentasBancos(da)

      '# Elimino todas las Cuentas Bancos asociadas al depósito
      rDepositosCuentasBancos.BorrarTodas(idSucursal, numeroDeposito, idTipoComprobante)

   End Sub

#End Region

#Region "Contabilidad"
   'ARS 18/04/2014 

   '' ''Private Sub CargarContabilidad(ByRef eLibroBanco As Entidades.LibroBanco)

   '' ''   Dim sql As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
   '' ''   Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
   '' ''   Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios
   '' ''   Try

   '' ''      Dim codEjeVigente As Integer
   '' ''      Dim idPeriodoActual As String
   '' ''      'obtengo el ejercicio vigente

   '' ''      codEjeVigente = oEjercicio.GetEjercicioVigente(eLibroBanco.FechaMovimiento)
   '' ''      idPeriodoActual = oEjercicio.GetPeriodoActual(codEjeVigente, eLibroBanco.FechaMovimiento)

   '' ''      If Not (oEjercicio.EstaPeriodoCerrado(codEjeVigente, idPeriodoActual)) Then
   '' ''         Dim idUltimoAsiento As Integer = 0

   '' ''         Dim idPlan As Integer = sql.GetPlanCtaXCtaBan(eLibroBanco.IdCuentaBancaria)
   '' ''         Dim tipoproceso As String = Entidades.ContabilidadProceso.Procesos.MOVBANCO.ToString()

   '' ''         Dim dtCuentaContableCtaBan As DataTable = sql.GetCuentaContableCtaBan(eLibroBanco.IdCuentaBancaria)
   '' ''         If String.IsNullOrEmpty(dtCuentaContableCtaBan.Rows(0)("idCuentaContable").ToString) Or (Int32.Parse(dtCuentaContableCtaBan.Rows(0)("idCuentaContable").ToString()) = 0) Then
   '' ''            Throw New Exception("La Cuenta Bancaria no tiene Asignada Cuenta Contable.")
   '' ''         End If
   '' ''         Dim dtCuentaContableCuentasdeBanco As DataTable = sql.GetCuentaContableCuentadeCaja(eLibroBanco.IdCuentaBanco)
   '' ''         If String.IsNullOrEmpty(dtCuentaContableCuentasdeBanco.Rows(0)("idCuentaContable").ToString) Or (Int32.Parse(dtCuentaContableCuentasdeBanco.Rows(0)("idCuentaContable").ToString()) = 0) Then
   '' ''            Throw New Exception("La cuenta de banco no tiene Asignada Cuenta Contable.")
   '' ''         End If

   '' ''         Dim TablaClave As DataTable = sql.ObtenerDatosLibroBanco


   '' ''         'obtengo el ultimo id del los asientos
   '' ''         idUltimoAsiento = sqlAsientos.Asiento_GetIdMaximo_Tmp(idPlan) + 1

   '' ''         sqlAsientos.Asiento_I_TMP(idUltimoAsiento, _
   '' ''                                    eLibroBanco.FechaMovimiento, _
   '' ''                                    ObtenerDescAsiento(eLibroBanco), _
   '' ''                                    0, _
   '' ''                                    codEjeVigente, _
   '' ''                                    idPlan, _
   '' ''                                    eLibroBanco.IdSucursal, _
   '' ''                                    tipoproceso,
   '' ''                                    0, _
   '' ''                                    0)


   '' ''         sqlAsientos.Asiento_I_Detalle_TMP(idPlan, _
   '' ''                                             idUltimoAsiento, _
   '' ''                                             ArmarDetalle(eLibroBanco, idUltimoAsiento, tipoproceso, eLibroBanco.IdTipoMovimiento, dtCuentaContableCtaBan, dtCuentaContableCuentasdeBanco))


   '' ''         sql.MarcarRegistroProcesado(filaClave(TablaClave, eLibroBanco) _
   '' ''                                       , tipoproceso _
   '' ''                                       , idPlan,
   '' ''                                       idUltimoAsiento)
   '' ''      Else
   '' ''         Throw New Exception("No se puede ingresar el asiento, el periodo contable se encuentra cerrado")
   '' ''      End If
   '' ''   Catch ex As Exception

   '' ''      Throw ex

   '' ''   End Try

   '' ''End Sub

   'ARS 18/04/2014 
   '' ''Private Sub EditarContabilidad(ByRef eLibroBanco As Entidades.LibroBanco)
   '' ''   Dim sqlProceso As SqlServer.ContabilidadProcesos = New SqlServer.ContabilidadProcesos(da)
   '' ''   Dim sqlAsientos As SqlServer.ContabilidadAsientosTmp = New SqlServer.ContabilidadAsientosTmp(da)
   '' ''   Dim oEjercicio As Reglas.ContabilidadEjercicios = New Reglas.ContabilidadEjercicios
   '' ''   Try
   '' ''      Dim codEjeVigente As Integer
   '' ''      Dim idPeriodoActual As String

   '' ''      codEjeVigente = oEjercicio.GetEjercicioVigente(eLibroBanco.FechaMovimiento)  'obtengo el ejercicio vigente
   '' ''      idPeriodoActual = oEjercicio.GetPeriodoActual(codEjeVigente, eLibroBanco.FechaMovimiento)

   '' ''      If Not (oEjercicio.EstaPeriodoCerrado(codEjeVigente, idPeriodoActual)) Then 'valido que el periodo no este cerrado
   '' ''         Dim dtAsientoDefinitivo As DataTable
   '' ''         Dim tipoproceso As String = "MOVBANCO"
   '' ''         Dim DescAsiento As String = ObtenerDescAsiento(eLibroBanco)
   '' ''         dtAsientoDefinitivo = sqlProceso.GetAsientoDefinitivo(tipoproceso, DescAsiento)
   '' ''         If dtAsientoDefinitivo.Rows.Count = 0 Then
   '' ''            Dim IdAsientoModif As Integer = sqlProceso.getIdAsientoModif(tipoproceso, DescAsiento)
   '' ''            If IdAsientoModif <> 0 Then
   '' ''               Dim idPlan As Integer = sqlProceso.GetPlanCtaXCtaBan(eLibroBanco.IdCuentaBancaria)

   '' ''               Dim dtCuentaContableCtaBan As DataTable = sqlProceso.GetCuentaContableCtaBan(eLibroBanco.IdCuentaBancaria)
   '' ''               If String.IsNullOrEmpty(dtCuentaContableCtaBan.Rows(0)("idCuentaContable").ToString) Or (CInt(dtCuentaContableCtaBan.Rows(0)("idCuentaContable")) = 0) Then
   '' ''                  Throw New Exception("La Cuenta Bancaria no tiene asignada Cuenta Contable.")
   '' ''               End If
   '' ''               Dim dtCuentaContableCuentasdeBanco As DataTable = sqlProceso.GetCuentaContableCuentadeCaja(eLibroBanco.IdCuentaBanco)
   '' ''               If String.IsNullOrEmpty(dtCuentaContableCuentasdeBanco.Rows(0)("idCuentaContable").ToString) Or (CInt(dtCuentaContableCuentasdeBanco.Rows(0)("idCuentaContable")) = 0) Then
   '' ''                  Throw New Exception("La Cuenta de Banco no tiene asignada Cuenta Contable.")
   '' ''               End If

   '' ''               sqlAsientos.Asiento_U_Tmp(IdAsientoModif, _
   '' ''                                       eLibroBanco.FechaMovimiento, _
   '' ''                                       ObtenerDescAsiento(eLibroBanco), _
   '' ''                                       0, _
   '' ''                                       codEjeVigente, _
   '' ''                                       idPlan, _
   '' ''                                       eLibroBanco.IdSucursal,
   '' ''                                       tipoproceso, _
   '' ''                                       0, _
   '' ''                                       0)


   '' ''               sqlAsientos.Asiento_U_Detalle_Tmp(idPlan, _
   '' ''                                             IdAsientoModif, _
   '' ''                                             ArmarDetalle(eLibroBanco, IdAsientoModif, tipoproceso, eLibroBanco.IdTipoMovimiento, dtCuentaContableCtaBan, dtCuentaContableCuentasdeBanco))

   '' ''            Else
   '' ''               CargarContabilidad(eLibroBanco)

   '' ''            End If
   '' ''         Else
   '' ''            Throw New Exception("No se puede editar el movimientos ya se encuentra contabilizado, con el plan de cuenta: " & _
   '' ''                                 dtAsientoDefinitivo.Rows(0)("IdPlanCuenta").ToString() & ", Asiento: " & dtAsientoDefinitivo.Rows(0)("IdAsiento").ToString())
   '' ''         End If

   '' ''      Else
   '' ''         Throw New Exception("No se puede editar el periodo contable se encuentra cerrado")
   '' ''      End If
   '' ''   Catch ex As Exception

   '' ''      Throw ex

   '' ''   End Try

   '' ''End Sub

   '' ''Private Function filaClave(TablaClave As DataTable, eLibroBanco As Entidades.LibroBanco) As DataRow
   '' ''   Dim filaC As DataRow = TablaClave.NewRow

   '' ''   filaC("IdSucursal") = eLibroBanco.IdSucursal
   '' ''   filaC("IdCuentaBancaria") = eLibroBanco.IdCuentaBancaria
   '' ''   filaC("NumeroMovimiento") = eLibroBanco.NumeroMovimiento

   '' ''   TablaClave.Rows.Add(filaC)

   '' ''   Return TablaClave.Rows(0)

   '' ''End Function

   '' ''Public Function ObtenerDescAsiento(ByRef eLibroBanco As Entidades.LibroBanco) As String

   '' ''   Return CStr("Suc:" & eLibroBanco.IdSucursal.ToString & "-CtaBancaria:" & eLibroBanco.IdCuentaBancaria.ToString & "-Mov:" & eLibroBanco.NumeroMovimiento.ToString & _
   '' ''               "-Fec:" & eLibroBanco.FechaMovimiento.Year.ToString("0000") & "/" & eLibroBanco.FechaMovimiento.Month.ToString("00") & "/" & eLibroBanco.FechaMovimiento.Day.ToString("00") & _
   '' ''               "-MOVBANCO#" & eLibroBanco.IdSucursal.ToString & "-" & eLibroBanco.IdCuentaBancaria.ToString & "-" & eLibroBanco.NumeroMovimiento.ToString)
   '' ''End Function


   '' ''Private Function crearTablaDetalle() As DataTable
   '' ''   Dim datosDetalle As New DataTable

   '' ''   datosDetalle.Columns.Add("Cuenta", System.Type.GetType("System.String")) 'Cuentas.CodCuenta
   '' ''   datosDetalle.Columns.Add("debe", System.Type.GetType("System.Decimal"))
   '' ''   datosDetalle.Columns.Add("haber", System.Type.GetType("System.Decimal"))
   '' ''   datosDetalle.Columns.Add("idAsiento", System.Type.GetType("System.Int32"))
   '' ''   datosDetalle.Columns.Add("idRenglon", System.Type.GetType("System.Int32"))
   '' ''   datosDetalle.Columns.Add("IdCuenta", System.Type.GetType("System.Int32"))

   '' ''   Return datosDetalle

   '' ''End Function

   '' ''Private Sub AgregarFila(ByRef dtDet As DataTable, _
   '' ''                     dscCuenta As String, _
   '' ''                     debe As Decimal, _
   '' ''                     haber As Decimal, _
   '' ''                     idAsiento As Integer, _
   '' ''                     idCuenta As Integer)

   '' ''   Dim fila As DataRow

   '' ''   fila = dtDet.NewRow
   '' ''   fila("Cuenta") = dscCuenta
   '' ''   fila("debe") = debe
   '' ''   fila("haber") = haber
   '' ''   fila("idAsiento") = idAsiento
   '' ''   fila("idRenglon") = 0
   '' ''   fila("IdCuenta") = idCuenta

   '' ''   dtDet.Rows.Add(fila)

   '' ''End Sub

   '' ''Private Function ObtenerDescCuenta(filaCuenta As DataRow) As String

   '' ''   Return String.Empty 'filaCuenta("idCuenta").ToString & "-" & filaCuenta("nombreCuenta").ToString

   '' ''End Function

   '' ''Private Function ArmarDetalle(eLibroBanco As Entidades.LibroBanco _
   '' ''                           , idUltimoAsiento As Integer _
   '' ''                           , tipoproceso As String _
   '' ''                           , tipomovimiento As String _
   '' ''                           , dtCuentaContableCtaBan As DataTable _
   '' ''                           , dtCuentaContableCuentadeBanco As DataTable) As DataTable

   '' ''   Dim dtDetalle As DataTable = crearTablaDetalle()

   '' ''   If tipomovimiento = "I" Then
   '' ''      'Banco al debe
   '' ''      AgregarFila(dtDetalle, ObtenerDescCuenta(dtCuentaContableCtaBan.Rows(0)), System.Math.Abs(eLibroBanco.Importe), 0, idUltimoAsiento, CInt(dtCuentaContableCtaBan.Rows(0)!idCuentaContable))
   '' ''      AgregarFila(dtDetalle, ObtenerDescCuenta(dtCuentaContableCuentadeBanco.Rows(0)), 0, System.Math.Abs(eLibroBanco.Importe), idUltimoAsiento, CInt(dtCuentaContableCuentadeBanco.Rows(0)!idCuentaContable))

   '' ''   Else
   '' ''      'Banco al haber

   '' ''      AgregarFila(dtDetalle, ObtenerDescCuenta(dtCuentaContableCuentadeBanco.Rows(0)), System.Math.Abs(eLibroBanco.Importe), 0, idUltimoAsiento, CInt(dtCuentaContableCuentadeBanco.Rows(0)!idCuentaContable))
   '' ''      AgregarFila(dtDetalle, ObtenerDescCuenta(dtCuentaContableCtaBan.Rows(0)), 0, System.Math.Abs(eLibroBanco.Importe), idUltimoAsiento, CInt(dtCuentaContableCtaBan.Rows(0)!idCuentaContable))

   '' ''   End If

   '' ''   Return dtDetalle

   '' ''End Function
#End Region

#Region "Metodos Privados"

   Private Sub SelectFiltrado(ByRef stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT Lb.IdSucursal")
         .AppendLine("      ,Lb.IdCuentaBancaria")
         .AppendLine("      ,Cbs.CodigoBancario + ' - ' + B2.NombreBanco + ' (' + L2.NombreLocalidad + ')' DescCuentaBancaria")
         .AppendLine("      ,Lb.NumeroMovimiento")
         .AppendLine("      ,Lb.IdCuentaBanco")
         .AppendLine("      ,Cb.NombreCuentaBanco")
         .AppendLine("      ,Lb.IdTipoMovimiento")
         .AppendLine("      ,Lb.Importe")
         .AppendLine("      ,Lb.FechaMovimiento")
         .AppendLine("      ,Lb.FechaAplicado")
         .AppendLine("      ,CASE Lb.Conciliado")
         .AppendLine("   	    WHEN 1 Then 'Si'")
         .AppendLine("   	    WHEN  0 Then 'No'")
         .AppendLine("       END Conciliado ")
         .AppendLine("      ,C.NumeroCheque")
         .AppendLine("      ,Cbs.IdBanco")
         .AppendLine("      ,Convert(varchar,C.NumeroCheque) + ' - ' + B.NombreBanco + ' (' + L.NombreLocalidad + ' )'  DescCheque")
         .AppendLine("      ,C.FechaCobro")
         .AppendLine("   	 ,Lb.EsModificable ")
         .AppendLine("      ,Lb.Observacion")
         .AppendLine("      ,Lb.IdEjercicio")
         .AppendLine("      ,Lb.IdPlanCuenta ")
         .AppendLine("      ,Lb.IdAsiento ")
         .AppendLine("      ,Lb.IdCheque")
         .AppendLine("   	 ,Lb.IdCentroCosto ")
         .AppendLine("   	 ,CCC.NombreCentroCosto ")
         .AppendLine("      ,Lb.GeneraContabilidad")
         .AppendFormatLine(" ,{0}", Entidades.LibroBanco.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine(" ,{0}", Entidades.LibroBanco.Columnas.NumeroDeposito.ToString())
         .AppendLine("      ,Lb.FechaActualizacionAsiento")
         .AppendFormatLine("   	, Lb.IdConceptoCM05")
         .AppendFormatLine("     , CM05.DescripcionConceptoCM05")
         .AppendFormatLine("     , CM05.TipoConceptoCM05")
         .AppendLine("  FROM ")
         .AppendLine("   	LibrosBancos Lb INNER JOIN CuentasBancarias Cbs ON Lb.IdCuentaBancaria = Cbs.IdCuentaBancaria ")
         .AppendLine("   	INNER JOIN Bancos B2 ON Cbs.IdBanco = B2.IdBanco ")
         .AppendLine("   	INNER JOIN CuentasBancariasClase Ccb ON Cbs.IdCuentaBancariaClase = Ccb.IdCuentaBancariaClase ")
         .AppendLine("   	INNER JOIN Localidades L2 ON Cbs.IdLocalidad = L2.IdLocalidad ")
         .AppendLine("   	INNER JOIN CuentasBancos Cb ON Lb.IdCuentaBanco = Cb.IdCuentaBanco ")
         .AppendLine("   	LEFT JOIN Cheques C ON Lb.IdCheque = c.IdCheque")
         .AppendLine("   	LEFT JOIN Bancos B ON C.IdBanco = B.IdBanco ")
         .AppendLine("   	LEFT JOIN Localidades L ON C.IdLocalidad = L.IdLocalidad ")
         .AppendLine("   LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = Lb.IdCentroCosto")
         .AppendFormatLine("  LEFT JOIN AFIPConceptosCM05 CM05 ON CM05.IdConceptoCM05 = Lb.IdConceptoCM05")
      End With
   End Sub

#End Region

End Class
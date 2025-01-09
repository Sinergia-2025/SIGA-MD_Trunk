Public Class VentasImpuestos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub VentasImpuestos_I(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                idTipoImpuesto As Entidades.TipoImpuesto.Tipos, alicuota As Decimal,
                                bruto As Decimal,
                                neto As Decimal,
                                importe As Decimal,
                                total As Decimal,
                                idProvincia As String,
                                idRegimenPercepcion As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO VentasImpuestos (")
         .AppendFormatLine("     IdSucursal")
         .AppendFormatLine("   , IdTipoComprobante")
         .AppendFormatLine("   , Letra")
         .AppendFormatLine("   , CentroEmisor")
         .AppendFormatLine("   , NumeroComprobante")
         .AppendFormatLine("   , IdTipoImpuesto")
         .AppendFormatLine("   , Alicuota")
         .AppendFormatLine("   , Bruto")
         .AppendFormatLine("   , Neto")
         .AppendFormatLine("   , Importe")
         .AppendFormatLine("   , Total")
         .AppendFormatLine("   , IdProvincia")
         .AppendFormatLine("   , IdRegimenPercepcion")
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", idSucursal)
         .AppendFormatLine("   , '{0}'", idTipoComprobante)
         .AppendFormatLine("   , '{0}'", letra)
         .AppendFormatLine("   ,  {0} ", centroEmisor)
         .AppendFormatLine("   ,  {0} ", numeroComprobante)
         .AppendFormatLine("   , '{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine("   ,  {0} ", alicuota)
         .AppendFormatLine("   ,  {0} ", bruto)
         .AppendFormatLine("   ,  {0} ", neto)
         .AppendFormatLine("   ,  {0} ", importe)
         .AppendFormatLine("   ,  {0} ", total)
         If Not String.IsNullOrWhiteSpace(idProvincia) Then
            .AppendFormatLine("   , '{0}'", idProvincia)
         Else
            .AppendFormatLine("   , NULL")
         End If
         .AppendFormatLine("   ,  {0} ", GetStringFromNumber(idRegimenPercepcion))
         .AppendFormatLine(")")
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "VentasImpuestos")
   End Sub

   Public Sub VentasImpuestos_D(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                idTipoImpuesto As Entidades.TipoImpuesto.Tipos,
                                alicuota As Decimal)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM VentasImpuestos ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
         'Pensado para borrar toda la tabla de una vez.
         If idTipoImpuesto <> Entidades.TipoImpuesto.Tipos.Ninguno Then
            .AppendFormatLine("   AND IdTipoImpuesto = '{0}'", idTipoImpuesto)
            .AppendFormatLine("   AND Alicuota = {0}", alicuota)
         End If
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "VentasImpuestos")
   End Sub

   Public Sub VentasImpuestos_D2(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM VentasImpuestos ")
         .AppendFormatLine(" WHERE IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND Letra = '{0}'", letra)
         .AppendFormatLine("   AND CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND NumeroComprobante = {0}", numeroComprobante)
      End With

      Execute(stb)
      Sincroniza_I(stb.ToString(), "VentasImpuestos")
   End Sub


   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT VI.*")
         .AppendFormatLine("  FROM VentasImpuestos VI ")
      End With
   End Sub

   Public Function VentasImpuestos_GA() As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
      End With

      Return GetDataTable(stb)
   End Function
   Public Function VentasImpuestos_GA(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      idTipoImpuesto As Entidades.TipoImpuesto.Tipos?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE VI.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND VI.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VI.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VI.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND VI.NumeroComprobante = {0}", numeroComprobante)
         If idTipoImpuesto.HasValue Then
            .AppendFormatLine("   AND VI.IdTipoImpuesto = '{0}'", idTipoImpuesto.Value.ToString())
         End If
         .AppendFormatLine(" ORDER BY VI.IdTipoImpuesto, VI.Alicuota")
      End With

      Return GetDataTable(stb)
   End Function
   Public Function VentasImpuestos_GA(comprobantes As IEnumerable(Of Entidades.IPKComprobante), idTipoImpuesto As Entidades.TipoImpuesto.Tipos?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If comprobantes.AnySecure() Then
            .AppendFormatLine("   AND ({0})", String.Join(" OR ", comprobantes.ToList().
                                                   ConvertAll(Function(c) String.Format("VI.IdSucursal = {0} AND VI.IdTipoComprobante = '{1}' AND VI.Letra = '{2}' AND VI.CentroEmisor = {3} AND VI.NumeroComprobante = {4}",
                                                                                        c.IdSucursal, c.IdTipoComprobante, c.Letra, c.CentroEmisor, c.NumeroComprobante))))

         Else
            .AppendFormatLine("   AND 1 = 2")
         End If
         '.AppendFormatLine("   AND VI.IdSucursal = {0}", idSucursal)
         '.AppendFormatLine("   AND VI.IdTipoComprobante = '{0}'", idTipoComprobante)
         '.AppendFormatLine("   AND VI.Letra = '{0}'", letra)
         '.AppendFormatLine("   AND VI.CentroEmisor = {0}", centroEmisor)
         '.AppendFormatLine("   AND VI.NumeroComprobante = {0}", numeroComprobante)
         If idTipoImpuesto.HasValue Then
            .AppendFormatLine("   AND VI.IdTipoImpuesto = '{0}'", idTipoImpuesto.Value.ToString())
         End If
         .AppendFormatLine(" ORDER BY VI.IdTipoImpuesto, VI.Alicuota")
      End With

      Return GetDataTable(stb)
   End Function
   Public Function VentasImpuestos_G1(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                      idTipoImpuesto As Entidades.TipoImpuesto.Tipos, alicuota As Decimal) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(" WHERE VI.IdSucursal = {0}", idSucursal)
         .AppendFormatLine("   AND VI.IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormatLine("   AND VI.Letra = '{0}'", letra)
         .AppendFormatLine("   AND VI.CentroEmisor = {0}", centroEmisor)
         .AppendFormatLine("   AND VI.NumeroComprobante = {0}", numeroComprobante)
         .AppendFormatLine("   AND VI.IdTipoImpuesto = '{0}'", idTipoImpuesto.ToString())
         .AppendFormatLine("   AND VI.Alicuota = {0}", alicuota)
      End With

      Return GetDataTable(stb)
   End Function

   Public Function GetResumenDeVenta(empresas As Entidades.Empresa(),
                                     fechaDesde As Date?,
                                     fechaHasta As Date?,
                                     periodoDesde As Date?,
                                     periodoHasta As Date?,
                                     grabaLibro As Entidades.Publicos.SiNoTodos,
                                     esComercial As Entidades.Publicos.SiNoTodos,
                                     informaLibroIva As Entidades.Publicos.SiNoTodos,
                                     agrupadoPor As Entidades.ResumenDeVenta_AgrupadoPor,
                                     separarNetos As Boolean) As DataTable

      Dim nombreCampo As String = "'____' + CASE WHEN I.IdTipoImpuesto = 'IVA' THEN I.IdTipoImpuesto + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), I.Alicuota), '.', '#') ELSE I.IdTipoImpuesto + '_' + TI.NombreTipoImpuesto END"
      Dim nombreCampoNetoGravado As String = "'____IVA_NetoGravado_' + REPLACE(CONVERT(VARCHAR(MAX), I.Alicuota), '.', '#')"

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT QUOTENAME({0}) campo", nombreCampo)
         .AppendLine("  FROM Impuestos I")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = I.IdTipoImpuesto")
         .AppendLine(" WHERE (I.IdTipoImpuesto <> 'IVA' OR I.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")
         .AppendLine(" ORDER BY CASE WHEN I.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, I.IdTipoImpuesto, Alicuota")
      End With
      Dim dtCampos As DataTable = GetDataTable(stb.ToString())

      '# Campos de Neto Gravado separados
      stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT QUOTENAME({0}) campo", nombreCampoNetoGravado)
         .AppendLine("  FROM Impuestos I")
         .AppendLine(" INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = I.IdTipoImpuesto")
         .AppendLine(" WHERE (I.IdTipoImpuesto <> 'IVA' OR I.Alicuota <> 0)")
         .AppendLine("   AND TI.Tipo IN ('IVA')")
         .AppendLine(" ORDER BY CASE WHEN I.IdTipoImpuesto = 'IVA' THEN 0 ELSE 1 END, I.IdTipoImpuesto, Alicuota")
      End With
      Dim dtCamposNetoGravadosSeparados As DataTable = GetDataTable(stb.ToString())

      Dim campo_pivot = New StringBuilder()
      Dim campo_pivot_netoGravado = New StringBuilder()
      Dim campos_sum = New StringBuilder()
      Dim campos_total = New StringBuilder()

      Dim camposExistentes = New List(Of String)()

      For Each drCampos As DataRow In dtCampos.Rows
         If Not camposExistentes.Contains(drCampos("campo").ToString()) Then
            campo_pivot.AppendFormat("{0},", drCampos("campo"))
            If (agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Or
                agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto Or
                agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal) And drCampos("campo").ToString().StartsWith("[____IMINT") Then
               campos_sum.AppendFormatLine(", SUM(ISNULL(VIP.ImporteImpuestoInterno, 0)) AS {0}", drCampos("campo"))
               campos_total.AppendFormat(" + ISNULL(VIP.ImporteImpuestoInterno, 0)", drCampos("campo"))
            Else
               campos_sum.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", drCampos("campo"))
               campos_total.AppendFormat(" + ISNULL({0}, 0)", drCampos("campo"))
            End If
            camposExistentes.Add(drCampos("campo").ToString())
         End If
      Next

      '# Campos de Neto Gravado
      If separarNetos Then
         For Each gravCampos As DataRow In dtCamposNetoGravadosSeparados.Rows
            If Not camposExistentes.Contains(gravCampos("campo").ToString()) Then
               campo_pivot_netoGravado.AppendFormat("{0},", gravCampos("campo"))
               campos_sum.AppendFormatLine(", SUM(ISNULL({0}, 0)) AS {0}", gravCampos("campo"))
               campos_total.AppendFormat(" + ISNULL({0}, 0)", gravCampos("campo"))
               camposExistentes.Add(gravCampos("campo").ToString())
            End If
         Next
      End If

      stb = New StringBuilder()

      With stb
         .AppendLine("SELECT VIP.NombreSucursal")
         .AppendLine("      ,VIP.NombreEmpresa")
         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra
               .AppendLine("      ,VIP.Descripcion,VIP.Letra")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine("      ,VIP.NombreCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaCliente
               .AppendLine("      ,VIP.NombreCategoria")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine("      ,VIP.NombreRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto
               .AppendLine("      ,VIP.NombreRubro,VIP.NombreSubRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal
               .AppendLine("      ,VIP.NombreRubro")
               .AppendLine("      ,VIP.NombreCategoriaFiscal")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select

         .AppendLine("      ,SUM(VIP.NetoNoGravado) NetoNoGravado")
         .AppendLine("      ,SUM(VIP.NetoGravado) Neto")

         'If agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Then
         '   .AppendLine("      ,SUM(VIP.ImporteTotalNeto) Neto")
         'Else
         '   .AppendLine("      ,SUM(VIP.Neto) Neto")
         'End If
         .AppendLine(campos_sum.ToString())
         If agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Or
            agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto Or
            agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal Then
            If separarNetos Then
               .AppendFormatLine("      ,SUM( {0}) Total", campos_total)
            Else
               .AppendFormatLine("      ,SUM(VIP.ImporteTotalNeto {0}) Total", campos_total)
            End If

         Else
            If separarNetos Then
               .AppendFormatLine("      ,SUM( {0}) Total", campos_total)
            Else
               .AppendFormatLine("      ,SUM(VIP.NetoGravado + VIP.NetoNoGravado {0}) Total", campos_total)
            End If

         End If

         If agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto Or
            agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto Or
            agrupadoPor = Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal Then

            nombreCampo = "'____' + 'IVA' + '_' + 'IVA' + '_' + REPLACE(CONVERT(VARCHAR(MAX), VI.AlicuotaImpuesto), '.', '#')"
            nombreCampoNetoGravado = "'____IVA_NetoGravado_' + REPLACE(CONVERT(VARCHAR(MAX), VI.AlicuotaImpuesto), '.', '#')"
         End If


         .AppendFormatLine("  FROM (SELECT {0} AS Impuesto_Importe", nombreCampo)
         If separarNetos Then .AppendFormatLine("              ,{0} AS NetoGravadoSeparado", nombreCampoNetoGravado)
         .AppendLine("              ,VI.*")
         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto And
            agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto And
            agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal Then
            .AppendLine("              ,CASE WHEN VI.Alicuota =  0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.Neto ELSE 0 END NetoNoGravado")
            .AppendLine("              ,CASE WHEN VI.Alicuota <> 0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.Neto ELSE 0 END NetoGravado")
            If separarNetos Then .AppendLine("              ,CASE WHEN VI.Alicuota <> 0 AND VI.IdTipoImpuesto = 'IVA' THEN VI.Neto ELSE 0 END NetoGravado1")
         Else
            .AppendLine("              ,CASE WHEN VI.AlicuotaImpuesto =  0 THEN VI.ImporteTotalNeto ELSE 0 END NetoNoGravado")
            .AppendLine("              ,CASE WHEN VI.AlicuotaImpuesto <> 0 THEN VI.ImporteTotalNeto ELSE 0 END NetoGravado")
            If separarNetos Then .AppendLine("              ,CASE WHEN VI.AlicuotaImpuesto <> 0 THEN VI.ImporteTotalNeto ELSE 0 END NetoGravado1")
         End If
         '.AppendLine("              ,S.Nombre NombreSucursal")
         .AppendLine("              ,'' NombreSucursal")
         .AppendLine("              ,EM.NombreEmpresa")

         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra
               .AppendLine("              ,TC.Descripcion")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine("              ,CF.NombreCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaCliente
               .AppendLine("              ,CAT.NombreCategoria")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine("              ,R.NombreRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto
               .AppendLine("              ,R.NombreRubro,SR.NombreSubRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal
               .AppendLine("              ,R.NombreRubro")
               .AppendLine("              ,CF.NombreCategoriaFiscal")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select

         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto And agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto And agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal Then
            .AppendLine("          FROM VentasImpuestos VI")
         Else
            .AppendLine("          FROM VentasProductos VI")
         End If
         .AppendLine("         INNER JOIN Ventas V ON VI.IdSucursal = V.IdSucursal")
         .AppendLine("                            AND VI.IdTipoComprobante = V.IdTipoComprobante")
         .AppendLine("                            AND VI.Letra = V.Letra")
         .AppendLine("                            AND VI.CentroEmisor = V.CentroEmisor")
         .AppendLine("                            AND VI.NumeroComprobante = V.NumeroComprobante")
         .AppendLine("         INNER JOIN TiposComprobantes TC ON V.IdTipoComprobante = TC.IdTipoComprobante")
         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto And agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto And agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal Then
            .AppendLine("         INNER JOIN TiposImpuestos TI ON TI.IdTipoImpuesto = VI.IdTipoImpuesto")
            .AppendLine("         INNER JOIN Impuestos I ON I.IdTipoImpuesto = VI.IdTipoImpuesto AND I.Alicuota = VI.Alicuota")
         End If
         .AppendLine("         INNER JOIN Sucursales S ON VI.IdSucursal = S.IdSucursal")
         .AppendLine("         INNER JOIN Empresas EM ON EM.IdEmpresa = S.IdEmpresa")
         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra

            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine("         INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaCliente
               .AppendLine("         INNER JOIN Clientes CL ON CL.IdCLiente = V.IdCliente ")
               .AppendLine("         INNER JOIN Categorias CAT ON CL.IdCategoria = CAT.IdCategoria")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine("         INNER JOIN Productos P ON P.IdProducto = VI.IdProducto")
               .AppendLine("         INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto
               .AppendLine("         INNER JOIN Productos P ON P.IdProducto = VI.IdProducto")
               .AppendLine("         INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
               .AppendLine("         INNER JOIN SubRubros SR ON SR.IdSubRubro = P.IdSubRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal
               .AppendLine("         INNER JOIN Productos P ON P.IdProducto = VI.IdProducto")
               .AppendLine("         INNER JOIN Rubros R ON R.IdRubro = P.IdRubro")
               .AppendLine("         INNER JOIN CategoriasFiscales CF ON V.IdCategoriaFiscal = CF.IdCategoriaFiscal")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select
         .AppendLine("         WHERE 1 = 1")

         '  Se quita porque se dio el caso en Aimaro que el usuario destildo afecta caja en el tipo de comprobante
         'y no se encontró un motivo para que esté este filtro. Si surge la necesidad contemplar en Citi Ventas y Libro IVA
         '.AppendLine("         WHERE TC.AfectaCaja = 'True'") 

         'GetListaSucursalesMultiples(stb, sucursales, "VI").AppendLine()

         '# Graba Libro
         If grabaLibro <> Entidades.Publicos.SiNoTodos.TODOS Then
            If grabaLibro = Entidades.Publicos.SiNoTodos.SI Then
               .AppendLine("          AND TC.GrabaLibro = 'True'")
            Else
               .AppendLine("          AND TC.GrabaLibro = 'False'")
            End If
         End If

         '# Es Comercial
         If esComercial <> Entidades.Publicos.SiNoTodos.TODOS Then
            If esComercial = Entidades.Publicos.SiNoTodos.SI Then
               .AppendLine("          AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
            Else
               .AppendLine("          AND TC.EsComercial = 'False' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
            End If
         End If

         'ElseIf grabaLibro = Entidades.Publicos.SiNoTodos.NO Then
         '.AppendLine("          AND TC.GrabaLibro = 'False'")
         '.AppendLine("          AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
         'Else
         '.AppendLine("          AND TC.EsComercial = 'True' ") 'Con esta sola pregunta deberia alcanzar (Ventas Sin NDEB Cheque Rechazados)
         'End If

         GetListaEmpresasMultiples(stb, empresas, "EM")

         If informaLibroIva <> Entidades.Publicos.SiNoTodos.TODOS Then
            .AppendFormatLine("          AND TC.InformaLibroIVA = {0}", IIf(informaLibroIva = Entidades.Publicos.SiNoTodos.SI, "1", "0"))
         End If

         '.AppendLine("          AND VI.IdTipoImpuesto IN ('IVA', 'PIIBB', 'IMINT')")
         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto And
            agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto And
            agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal Then
            .AppendLine("          AND TI.Tipo IN ('IVA', 'PERCEPCION', 'INTERNO')")

         End If

         If fechaDesde.HasValue Then
            .AppendFormatLine("          AND V.fecha >= '{0}'", ObtenerFecha(fechaDesde.Value, False))
            .AppendFormatLine("          AND V.fecha <= '{0}'", ObtenerFecha(fechaHasta.Value.UltimoSegundoDelDia(), True))
         End If

         If periodoDesde.HasValue Then
            .AppendFormatLine("          AND V.fecha >= '{0}'", ObtenerFecha(periodoDesde.Value, False))
            .AppendFormatLine("          AND V.fecha <= '{0}'", ObtenerFecha(periodoHasta.Value.UltimoSegundoDelDia(), True))
         End If

         .AppendFormatLine(") AS VI")

         '# Separo los Neto Gravado por alícuotas
         If separarNetos Then
            .AppendFormatLine("PIVOT (SUM(NetoGravado1) FOR NetoGravadoSeparado IN ({0}))", campo_pivot_netoGravado.ToString().Trim(","c))
            .AppendLine("AS NGS")
         End If

         If agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto And
            agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto And
            agrupadoPor <> Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal Then
            .AppendFormatLine("PIVOT (SUM(Importe) FOR Impuesto_Importe IN ({0}))", campo_pivot.ToString().Trim(","c))
         Else
            .AppendFormatLine("PIVOT (SUM(ImporteImpuesto) FOR Impuesto_Importe IN ({0}))", campo_pivot.ToString().Trim(","c))
         End If
         .AppendLine("AS VIP")

         Select Case agrupadoPor
            Case Entidades.ResumenDeVenta_AgrupadoPor.TipoComprobante_Letra
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.Descripcion, VIP.Letra")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.Descripcion, VIP.Letra")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaFiscal
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreCategoriaFiscal")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreCategoriaFiscal")
            Case Entidades.ResumenDeVenta_AgrupadoPor.CategoriaCliente
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreCategoria")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreCategoria")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreRubro")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_SubRubroProducto
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreRubro, VIP.NombreSubRubro")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreRubro, VIP.NombreSubRubro")
            Case Entidades.ResumenDeVenta_AgrupadoPor.RubroProducto_CategoriaFiscal
               .AppendLine(" GROUP BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreRubro, VIP.NombreCategoriaFiscal")
               .AppendLine(" ORDER BY VIP.NombreSucursal, VIP.NombreEmpresa, VIP.NombreRubro, VIP.NombreCategoriaFiscal")
            Case Else
               Throw New ArgumentOutOfRangeException(String.Format("Método de agrupado {0} no definido.", agrupadoPor))
         End Select

      End With

      Return GetDataTable(stb)
   End Function

End Class
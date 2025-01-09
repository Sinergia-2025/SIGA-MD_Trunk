Public Class CategoriasFiscales
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasFiscales_I(idCategoriaFiscal As Short,
                                   nombreCategoriaFiscal As String,
                                   nombreCategoriaFiscalAbrev As String,
                                   utilizaImpuestos As Boolean,
                                   condicionIvaImpresoraFiscalEpson As String,
                                   condicionIvaImpresoraFiscalHasar As String,
                                   activo As Boolean,
                                   solicitaCUIT As Boolean,
                                   esPasiblePercIIBB As Boolean,
                                   utilizaAlicuota2Producto As Boolean,
                                   codigoExportacion As String,
                                   leyendaCategoriaFiscal As String,
                                   ivaCeroCategoriaFiscal As String)

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO CategoriasFiscales")
         .AppendLine("   (IdCategoriaFiscal")
         .AppendLine("   ,NombreCategoriaFiscal")
         .AppendLine("   ,NombreCategoriaFiscalAbrev")
         .AppendLine("   ,UtilizaImpuestos")
         .AppendLine("   ,CondicionIvaImpresoraFiscalEpson")
         .AppendLine("   ,CondicionIvaImpresoraFiscalHasar")
         .AppendLine("   ,Activo")
         .AppendLine("   ,SolicitaCUIT")
         .AppendLine("   ,EsPasiblePercIIBB")
         .AppendLine("   ,UtilizaAlicuota2Producto")
         .AppendLine("   ,CodigoExportacion")
         .AppendLine("   ,LeyendaCategoriaFiscal") '-.PE-34189.-
         '-- REG-34587.- -------------------------
         .AppendLine("   ,IvaCeroCategoriaFiscal")
         '----------------------------------------
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & idCategoriaFiscal.ToString())
         .AppendLine("   ,'" & nombreCategoriaFiscal & "'")
         .AppendLine("   ,'" & nombreCategoriaFiscalAbrev & "'")
         .AppendLine("   ,'" & utilizaImpuestos.ToString() & "'")
         .AppendLine("   ,'" & condicionIvaImpresoraFiscalEpson & "'")
         .AppendLine("   ,'" & condicionIvaImpresoraFiscalHasar & "'")
         .AppendLine("   ,'" & activo.ToString() & "'")
         .AppendFormatLine("   ,'{0}'", solicitaCUIT)
         .AppendFormatLine("   ,'{0}'", esPasiblePercIIBB)
         .AppendFormatLine("   ,{0}", GetStringFromBoolean(utilizaAlicuota2Producto))
         .AppendFormatLine("   ,'{0}'", codigoExportacion)
         .AppendFormatLine("   ,'{0}'", leyendaCategoriaFiscal) '-.PE-34189.-
         '-- REG-34587.- --------------------------------------
         .AppendFormatLine("   ,'{0}'", ivaCeroCategoriaFiscal)
         '-----------------------------------------------------
         .AppendLine(")")
      End With

      Execute(stb.ToString())
   End Sub

   Public Sub CategoriasFiscales_U(idCategoriaFiscal As Short,
                                   nombreCategoriaFiscal As String,
                                   nombreCategoriaFiscalAbrev As String,
                                   utilizaImpuestos As Boolean,
                                   condicionIvaImpresoraFiscalEpson As String,
                                   condicionIvaImpresoraFiscalHasar As String,
                                   activo As Boolean,
                                   solicitaCUIT As Boolean,
                                   esPasiblePercIIBB As Boolean,
                                   utilizaAlicuota2Producto As Boolean,
                                   codigoExportacion As String,
                                   leyendaCategoriaFiscal As String,
                                   ivaCeroCategoriaFiscal As String)

      Dim stb = New StringBuilder()
      With stb
         .AppendLine("UPDATE CategoriasFiscales SET ")
         .AppendLine("   NombreCategoriaFiscal = '" & nombreCategoriaFiscal & "'")
         .AppendLine("   ,NombreCategoriaFiscalAbrev = '" & nombreCategoriaFiscalAbrev & "'")
         .AppendLine("   ,UtilizaImpuestos = '" & utilizaImpuestos.ToString() & "'")
         .AppendLine("   ,Activo = '" & activo.ToString() & "'")
         .AppendLine("   ,CondicionIvaImpresoraFiscalEpson = '" & condicionIvaImpresoraFiscalEpson & "'")
         .AppendLine("   ,CondicionIvaImpresoraFiscalHasar = '" & condicionIvaImpresoraFiscalHasar & "'")
         .AppendFormatLine("   ,SolicitaCUIT = '{0}'", solicitaCUIT)
         .AppendFormatLine("   ,EsPasiblePercIIBB  = '{0}'", esPasiblePercIIBB)
         .AppendFormatLine("   ,UtilizaAlicuota2Producto = {0}", GetStringFromBoolean(utilizaAlicuota2Producto))
         .AppendFormatLine("   ,CodigoExportacion = '{0}'", codigoExportacion)
         .AppendFormatLine("   ,LeyendaCategoriaFiscal = '{0}'", leyendaCategoriaFiscal) '-.PE-34189.-
         '-- REG-34587.- ----------------------------------------------------------------
         .AppendFormatLine("   ,IvaCeroCategoriaFiscal = '{0}'", ivaCeroCategoriaFiscal.ToString())
         '-------------------------------------------------------------------------------
         .AppendLine(" WHERE IdCategoriaFiscal = " & idCategoriaFiscal.ToString())
      End With

      Execute(stb.ToString())
      Sincroniza_I(stb.ToString(), "CategoriasFiscales")
   End Sub

   Public Sub CategoriasFiscales_D(idCategoriaFiscal As Short)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM CategoriasFiscales")
         .AppendLine(" WHERE IdCategoriaFiscal = " & idCategoriaFiscal.ToString())
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "CategoriasFiscales")
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, idEmpresa As Integer)
      With stb
         .AppendFormatLine("SELECT CF.IdCategoriaFiscal")
         .AppendFormatLine("      ,CF.NombreCategoriaFiscal")
         .AppendFormatLine("      ,CF.NombreCategoriaFiscalAbrev")
         .AppendFormatLine("      ,CFC.LetraFiscal")
         .AppendFormatLine("      ,CFC.LetraFiscalCompra")
         .AppendFormatLine("      ,ISNULL(CFC.IvaDiscriminado, 0) IvaDiscriminado")
         .AppendFormatLine("      ,CF.UtilizaImpuestos")
         .AppendFormatLine("      ,CF.CondicionIvaImpresoraFiscalEpson")
         .AppendFormatLine("      ,CF.CondicionIvaImpresoraFiscalHasar")
         .AppendFormatLine("      ,CF.Activo")
         .AppendFormatLine("      ,CF.SolicitaCUIT")
         .AppendFormatLine("      ,CF.EsPasiblePercIIBB")
         .AppendFormatLine("      ,CF.UtilizaAlicuota2Producto")
         .AppendFormatLine("      ,CF.CodigoExportacion")
         .AppendFormatLine("      ,CF.LeyendaCategoriaFiscal") '-- PE -34189.-
         .AppendFormatLine("      ,CF.IvaCeroCategoriaFiscal") '-- REQ-34587.-
         .AppendFormatLine("  FROM CategoriasFiscales CF")
         .AppendFormatLine(" CROSS JOIN (SELECT * FROM Parametros WHERE IdParametro = 'CATEGORIAFISCALEMPRESA' AND IdEmpresa = {0}) P", idEmpresa)
         .AppendFormatLine("  LEFT JOIN CategoriasFiscalesConfiguraciones CFC ON CFC.IdCategoriaFiscalCliente = CF.IdCategoriaFiscal AND CFC.IdCategoriaFiscalEmpresa = ISNULL(P.ValorParametro, 0)")

      End With
   End Sub

   Public Function CategoriasFiscales_GA(idEmpresa As Integer) As DataTable

      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb, idEmpresa)
         .AppendLine(" ORDER BY CF.NombreCategoriaFiscal")
      End With

      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function CategoriasFiscales_GA(SoloActivos As Boolean, idEmpresa As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         Me.SelectTexto(stb, idEmpresa)
         .AppendFormatLine("  WHERE Activo = '{0}'", SoloActivos)
         .AppendLine(" ORDER BY CF.NombreCategoriaFiscal")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function CategoriasFiscales_G1(idCategoriaFiscal As Short, idEmpresa As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, idEmpresa)
         .AppendFormatLine(" WHERE CF.IdCategoriaFiscal = {0}", idCategoriaFiscal)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Categorias_G1(idCategoriaFiscal As Integer, ceroTodos As Boolean, idEmpresa As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         Me.SelectTexto(stb, idEmpresa)
         If idCategoriaFiscal <> 0 And Not ceroTodos Then
            .AppendFormatLine(" WHERE CF.IdCategoriaFiscal = {0}", idCategoriaFiscal)
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Categorias_G_PorNombre(nombre As String, exacto As Boolean, idEmpresa As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery, idEmpresa)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(nombre) Then
            If exacto Then
               .AppendFormatLine("   AND CF.IdCategoriaFiscal = '{0}'", nombre)
            Else
               .AppendFormatLine("   AND CF.IdCategoriaFiscal LIKE '%{0}%'", nombre)
            End If
         End If
         .AppendLine(" ORDER BY CF.NombreCategoriaFiscal")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CategoriasFiscales_GetCodigoMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(IdCategoriaFiscal) AS maximo ")
         .AppendLine(" FROM CategoriasFiscales")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String, idEmpresa As Integer) As DataTable
      If columna = "LetraFiscal" Or columna = "LetraFiscalCompra" Or columna = "IvaDiscriminado" Then
         columna = "CFC." + columna
      Else
         columna = "CF." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb, idEmpresa)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
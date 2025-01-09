Public Class Embarcaciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetParaMovil() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT E.IdEmbarcacion")
         .AppendFormatLine("     , E.CodigoEmbarcacion")
         .AppendFormatLine("     , E.NombreEmbarcacion")
         .AppendFormatLine("     , E.Matricula")
         .AppendFormatLine("     , E.Activo")
         .AppendFormatLine("     , E.EnMantenimiento")

         .AppendFormatLine("     , E.Estado")
         .AppendFormatLine("     , E.Situacion")

         .AppendFormatLine("     , E.BotadoRestringidoPrefectura")

         .AppendFormatLine("     , E.IdCama")
         .AppendFormatLine("     , C.CodigoCama")
         .AppendFormatLine("     , C.IdNave")
         .AppendFormatLine("     , N.NombreNave")

         .AppendFormatLine("     , E.IdCategoriaEmbarcacion")
         .AppendFormatLine("     , CE.NombreCategoriaEmbarcacion")
         .AppendFormatLine("     , E.IdMarcaEmbarcacion")
         .AppendFormatLine("     , ME.NombreMarcaEmbarcacion")
         .AppendFormatLine("     , E.IdModeloEmbarcacion")
         .AppendFormatLine("     , MO.NombreModeloEmbarcacion")

         .AppendFormatLine("     , E.TieneObservacionesTurno")
         .AppendFormatLine("     , E.ObservacionesTurno")
         .AppendFormatLine("     , E.BloqueaTurno")

         .AppendFormatLine("  FROM Embarcaciones E")
         .AppendFormatLine(" INNER JOIN Camas C ON C.IdCama = E.IdCama")
         .AppendFormatLine(" INNER JOIN Naves N ON N.IdNave = C.IdNave")
         .AppendFormatLine(" INNER JOIN CategoriasEmbarcaciones CE ON CE.IdCategoriaEmbarcacion = E.IdCategoriaEmbarcacion")
         .AppendFormatLine(" INNER JOIN MarcasEmbarcaciones ME ON ME.IdMarcaEmbarcacion = E.IdMarcaEmbarcacion")
         .AppendFormatLine(" INNER JOIN ModelosEmbarcaciones MO ON MO.IdMarcaEmbarcacion = E.IdMarcaEmbarcacion AND MO.IdModeloEmbarcacion = E.IdModeloEmbarcacion")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetClientesParaMovil() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT EC.IdEmbarcacion, EC.IdCliente")
         .AppendFormatLine("  FROM EmbarcacionesClientes EC")

      End With
      Return GetDataTable(stb)
   End Function

   Public Function GetPorCodigoCliente(codigoCliente As Long, situacion As String, activo As Boolean?) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT E.IdEmbarcacion")
         .AppendFormatLine("      ,E.CodigoEmbarcacion")
         .AppendFormatLine("      ,C.IdCliente")
         .AppendFormatLine("      ,E.NombreEmbarcacion")
         .AppendFormatLine("      ,E.Matricula")
         .AppendFormatLine("      ,(CASE WHEN EC.Tipo = 'T' THEN 'TITULAR' ELSE 'AUTORIZADO' END) AS NombreTipo")
         .AppendFormatLine("      ,E.Estado")
         .AppendFormatLine("      ,E.Situacion")
         .AppendFormatLine("      ,EC.ResponsableCargos")
         .AppendFormatLine("      ,E.BotadoRestringidoPrefectura")
         .AppendFormatLine("  FROM EmbarcacionesClientes EC")
         .AppendFormatLine("	LEFT JOIN Embarcaciones E ON E.IdEmbarcacion = EC.IdEmbarcacion")
         .AppendFormatLine("	LEFT JOIN Clientes C ON C.IdCliente = EC.IdCliente")
         .AppendFormatLine("	WHERE C.CodigoCliente = {0}", codigoCliente)
         If Not String.IsNullOrEmpty(situacion) Then
            .AppendFormatLine("	AND E.Situacion = '{0}'", situacion)
         End If
         If activo.HasValue Then
            .AppendFormatLine("	AND E.Activo = {0}", GetStringFromBoolean(activo.Value))
         End If
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Embarcaciones_G1_Liviano(idEmbarcacion As Long) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT E.IdEmbarcacion")
         .AppendFormatLine("      ,E.CodigoEmbarcacion")
         .AppendFormatLine("      ,E.NombreEmbarcacion")
         .AppendFormatLine("  FROM Embarcaciones E")
         .AppendFormatLine(" where E.IdEmbarcacion = {0}", idEmbarcacion)
      End With
      Return GetDataTable(stb)
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT E.CodigoEmbarcacion")
         .AppendLine("      ,E.IdEmbarcacion")
         .AppendLine("      ,E.NombreEmbarcacion")
         .AppendLine("      ,E.IdCategoriaEmbarcacion")
         .AppendLine("      ,CE.NombreCategoriaEmbarcacion")
         .AppendLine("      ,E.Matricula")
         .AppendLine("      ,E.IdCama")
         .AppendLine("      ,Ca.CodigoCama")
         .AppendLine("      ,N.NombreNave")
         .AppendLine("      ,E.IdMarcaEmbarcacion")
         .AppendLine("      ,MaE.NombreMarcaEmbarcacion")
         .AppendLine("      ,E.IdModeloEmbarcacion")
         .AppendLine("      ,MoE.NombreModeloEmbarcacion")
         .AppendLine("      ,E.Color")
         .AppendLine("      ,E.Anio")
         .AppendLine("      ,E.Eslora")
         .AppendLine("      ,E.Manga")
         .AppendLine("      ,E.Puntal")
         .AppendLine("      ,E.AlturaTotal")
         .AppendLine("      ,ImporteAdicionalEslora")
         .AppendLine("      ,ImporteAdicionalAlturaTotal")
         .AppendLine("      ,E.PorcDescExpensas")
         .AppendLine("      ,E.PeriodoDesdeDescExpensas")
         .AppendLine("      ,E.PeriodoHastaDescExpensas")
         .AppendLine("      ,E.PorcDescAlquiler")
         .AppendLine("      ,E.PeriodoDesdeDescAlquiler")
         .AppendLine("      ,E.PeriodoHastaDescAlquiler")
         .AppendLine("      ,E.ImporteAlquiler")
         .AppendLine("      ,E.PeriodoDesdeImpAlquiler")
         .AppendLine("      ,E.PeriodoHastaImpAlquiler")
         .AppendLine("      ,E.PorcDescExtra")
         .AppendLine("      ,E.PeriodoDesdeDescExtra")
         .AppendLine("      ,E.PeriodoHastaDescExtra")
         .AppendLine("      ,E.NumeroSerieCasco")
         'Solo la busco en el GET1 porque ahi puedo necesitarlo, en todo lo demas NO.
         'Lentifica terriblemente la consulta.
         'If Imagen Then
         '   '.AppendLine("      ,E.Foto")
         'End If
         .AppendLine("      ,E.Observacion")
         .AppendLine("      ,E.EnMantenimiento")
         .AppendLine("      ,E.UtilizaCamaDeCortesia")
         .AppendLine("      ,E.KilosEnSeco")
         .AppendLine("      ,E.Situacion")
         .AppendLine("      ,E.FechaRecepcion")
         .AppendLine("      ,E.FechaRetiro")
         .AppendLine("      ,E.Estado")
         .AppendLine("      ,E.FechaAlta")
         .AppendLine("         ,E.Activo")
         .AppendLine("           ,E.FechaVtoMatricTramite")
         .AppendLine("           ,E.DatosSeguro")
         .AppendLine("           ,E.FechaVtoElemSeguridad")
         .AppendLine("           ,MM.NombreMarcaMotor")
         .AppendLine("           ,EM.PotenciaMotor")
         .AppendLine("           ,EM.NumeroSerieMotor")
         .AppendLine("           ,C.IdCliente")
         .AppendLine("           ,C.CodigoCliente")
         .AppendLine("           ,C.NombreCliente")
         .AppendLine("           ,C.Telefono")
         .AppendLine("           ,C.Celular")
         .AppendLine("           ,C.CorreoElectronico")
         .AppendLine("           ,CAT.NombreCategoria")
         .AppendLine("        ,E.BotadoRestringidoPrefectura")
         .AppendLine("        ,E.FechaVtoPoliza")
         .AppendLine("        ,E.ImporteAsegurado")
         .AppendLine("        ,E.IdMonedaImporteAsegurado")
         .AppendLine("        ,M.NombreMoneda")
         .AppendLine("        ,E.ValorTotalEnDolares")
         .AppendLine("        ,E.PeriodoContrato")
         .AppendLine("        ,E.PeriodoContratoDesde")
         .AppendLine("        ,E.PeriodoContratoHasta")
         .AppendLine("  FROM Embarcaciones E")
         .AppendLine("  INNER JOIN CategoriasEmbarcaciones CE ON CE.IdCategoriaEmbarcacion = E.IdCategoriaEmbarcacion")
         .AppendLine("	INNER JOIN MarcasEmbarcaciones MaE ON E.IdMarcaEmbarcacion = MaE.IdMarcaEmbarcacion")
         .AppendLine("	INNER JOIN ModelosEmbarcaciones MoE ON E.IdModeloEmbarcacion = MoE.IdModeloEmbarcacion")
         .AppendLine("	INNER JOIN Monedas M ON E.IdMonedaImporteAsegurado = M.IdMoneda")
         .AppendLine("	LEFT OUTER JOIN Camas Ca ON E.IdCama = Ca.IdCama")
         .AppendLine("	LEFT OUTER JOIN Naves N ON Ca.IdNave = N.IdNave")
         .AppendLine("  LEFT OUTER JOIN EmbarcacionesMotores EM ON E.IdEmbarcacion = EM.IdEmbarcacion AND EM.Principal = 'True' ")
         .AppendLine("  LEFT OUTER JOIN MarcasMotores MM ON MM.IdMarcaMotor = EM.IdMarcaMotor")
         .AppendLine(" 	LEFT OUTER JOIN EmbarcacionesClientes EC ON EC.IdEmbarcacion = E.IdEmbarcacion AND EC.ResponsableCargos = 'True'")
         .AppendLine("  LEFT OUTER JOIN Clientes C ON C.IdCliente = EC.IdCliente")
         .AppendLine("  LEFT OUTER JOIN Categorias CAT ON CAT.IdCategoria = C.IdCategoria")
      End With
   End Sub
   Public Function GetFiltradoPorNombre(nombre As String) As DataTable
      Dim stbQuery = New StringBuilder()
      Dim consultaFoto = True
      SelectTexto(stbQuery)
      With stbQuery
         If nombre <> "" Then
            .AppendFormat(" WHERE E.NombreEmbarcacion LIKE '%{0}%' ", nombre)
            .AppendLine(" ORDER BY E.NombreEmbarcacion ")
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function

   Public Function GetFiltradoPorEmbarcacion(Embarcacion As Long) As DataTable
      Dim stbQuery = New StringBuilder()
      Dim consultaFoto = True
      SelectTexto(stbQuery)
      With stbQuery
         If Embarcacion > 0 Then
            .AppendFormat(" WHERE E.CodigoEmbarcacion = {0} ", Embarcacion)
         End If
      End With
      Return GetDataTable(stbQuery)
   End Function
End Class
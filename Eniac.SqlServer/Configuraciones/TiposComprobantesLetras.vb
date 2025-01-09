Public Class TiposComprobantesLetras
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposComprobantesLetras_I(idTipoComprobante As String,
                                        letra As String,
                                        archivoAImprimir As String,
                                        archivoAImprimirEmbebido As Boolean,
                                        nombreImpresora As String,
                                        CantidadItemsProductos As Integer,
                                        CantidadItemsObservaciones As Integer,
                                        imprime As Boolean,
                                        cantidadCopias As Integer,
                                        archivoAImprimir2 As String,
                                        archivoAImprimirEmbebido2 As Boolean,
                                        ArchivoAImprimirComplementario As String,
                                        ArchivoAImprimirComplementarioEmbebido As Boolean,
                                        ArchivoAExportar As String,
                                        ArchivoAExportarEmbebido As Boolean,
                                        IdTipoImpresionFiscalArchivoAImprimir As Integer,
                                        IdTipoImpresionFiscalArchivoAImprimir2 As Integer,
                                        IdTipoImpresionFiscalArchivoAImprimirComplementario As Integer,
                                        IdTipoImpresionFiscalArchivoAExportar As Integer,
                                        desplazamientoXArchivoAImprimir As Integer,
                                        desplazamientoYArchivoAImprimir As Integer,
                                        desplazamientoXArchivoAImprimir2 As Integer,
                                        desplazamientoYArchivoAImprimir2 As Integer,
                                        desplazamientoXArchivoAImprimirComplementario As Integer,
                                        desplazamientoYArchivoAImprimirComplementario As Integer,
                                        desplazamientoXArchivoAExportar As Integer,
                                        desplazamientoYArchivoAExportar As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Append("INSERT INTO TiposComprobantesLetras")
         .Append("           (IdTipoComprobante")
         .Append("           ,Letra")
         .Append("           ,ArchivoAImprimir")
         .Append("           ,ArchivoAImprimirEmbebido")
         .Append("           ,NombreImpresora")
         .Append("           ,CantidadItemsProductos")
         .Append("           ,CantidadItemsObservaciones")
         .Append("           ,Imprime")
         .Append("           ,CantidadCopias")
         .Append("           ,ArchivoAImprimir2")
         .Append("           ,ArchivoAImprimirEmbebido2")
         .Append("           ,ArchivoAImprimirComplementario")
         .Append("           ,ArchivoAImprimirComplementarioEmbebido")
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportar.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportarEmbebido.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir2.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimirComplementario.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAExportar.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir2.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir2.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimirComplementario.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimirComplementario.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAExportar.ToString())
         .AppendFormat("           ,{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAExportar.ToString())

         .Append(" ) VALUES (")
         .AppendFormat("           '{0}'", idTipoComprobante)
         .AppendFormat("           ,'{0}'", letra)
         .AppendFormat("           ,'{0}'", archivoAImprimir)
         .AppendFormat("           ,{0}", Me.GetStringFromBoolean(archivoAImprimirEmbebido))
         .AppendFormat("           ,'{0}'", nombreImpresora)
         .AppendFormat("           ,{0}", CantidadItemsProductos)
         .AppendFormat("           ,{0}", CantidadItemsObservaciones)
         .AppendFormat("           ,'{0}'", imprime)
         .AppendFormat("           ,'{0}'", cantidadCopias)
         .AppendFormat("           ,'{0}'", archivoAImprimir2)
         .AppendFormat("           ,{0}", GetStringFromBoolean(archivoAImprimirEmbebido2))
         .AppendFormat("           ,'{0}'", ArchivoAImprimirComplementario)
         .AppendFormat("           ,{0}", GetStringFromBoolean(ArchivoAImprimirComplementarioEmbebido))
         .AppendFormat("           ,'{0}'", ArchivoAExportar)
         .AppendFormat("           ,{0}", GetStringFromBoolean(ArchivoAExportarEmbebido))
         .AppendFormat("           ,{0}", IdTipoImpresionFiscalArchivoAImprimir)
         .AppendFormat("           ,{0}", IdTipoImpresionFiscalArchivoAImprimir2)
         .AppendFormat("           ,{0}", IdTipoImpresionFiscalArchivoAImprimirComplementario)
         .AppendFormat("           ,{0}", IdTipoImpresionFiscalArchivoAExportar)
         .AppendFormat("           ,{0}", desplazamientoXArchivoAImprimir)
         .AppendFormat("           ,{0}", desplazamientoYArchivoAImprimir)
         .AppendFormat("           ,{0}", desplazamientoXArchivoAImprimir2)
         .AppendFormat("           ,{0}", desplazamientoYArchivoAImprimir2)
         .AppendFormat("           ,{0}", desplazamientoXArchivoAImprimirComplementario)
         .AppendFormat("           ,{0}", desplazamientoYArchivoAImprimirComplementario)
         .AppendFormat("           ,{0}", desplazamientoXArchivoAExportar)
         .AppendFormat("           ,{0}", desplazamientoYArchivoAExportar)
         .Append(")")
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposComprobantesLetras_U(idTipoComprobante As String,
                                        letra As String,
                                        archivoAImprimir As String,
                                        archivoAImprimirEmbebido As Boolean,
                                        nombreImpresora As String,
                                        CantidadItemsProductos As Integer,
                                        CantidadItemsObservaciones As Integer,
                                        imprime As Boolean,
                                        cantidadCopias As Integer,
                                        archivoAImprimir2 As String,
                                        archivoAImprimirEmbebido2 As Boolean,
                                        ArchivoAImprimirComplementario As String,
                                        ArchivoAImprimirComplementarioEmbebido As Boolean,
                                        ArchivoAExportar As String,
                                        ArchivoAExportarEmbebido As Boolean,
                                        IdTipoImpresionFiscalArchivoAImprimir As Integer,
                                        IdTipoImpresionFiscalArchivoAImprimir2 As Integer,
                                        IdTipoImpresionFiscalArchivoAImprimirComplementario As Integer,
                                        IdTipoImpresionFiscalArchivoAExportar As Integer,
                                        desplazamientoXArchivoAImprimir As Integer,
                                        desplazamientoYArchivoAImprimir As Integer,
                                        desplazamientoXArchivoAImprimir2 As Integer,
                                        desplazamientoYArchivoAImprimir2 As Integer,
                                        desplazamientoXArchivoAImprimirComplementario As Integer,
                                        desplazamientoYArchivoAImprimirComplementario As Integer,
                                        desplazamientoXArchivoAExportar As Integer,
                                        desplazamientoYArchivoAExportar As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .Append("UPDATE TiposComprobantesLetras")
         .Append("   SET ")
         .AppendFormat("      ArchivoAImprimir = '{0}'", archivoAImprimir)
         .AppendFormat("      ,ArchivoAImprimirEmbebido = {0}", Me.GetStringFromBoolean(archivoAImprimirEmbebido))
         .AppendFormat("      ,NombreImpresora = '{0}'", nombreImpresora)
         .AppendFormat("      ,CantidadItemsProductos = {0}", CantidadItemsProductos)
         .AppendFormat("      ,CantidadItemsObservaciones = {0}", CantidadItemsObservaciones)
         .AppendFormat("      ,Imprime = '{0}'", imprime)
         .AppendFormat("      ,CantidadCopias = '{0}'", cantidadCopias)
         .AppendFormat("      ,ArchivoAImprimir2 = '{0}'", archivoAImprimir2)
         .AppendFormat("      ,ArchivoAImprimirEmbebido2 = {0}", GetStringFromBoolean(archivoAImprimirEmbebido2))
         .AppendFormat("      ,ArchivoAImprimirComplementario= '{0}'", ArchivoAImprimirComplementario)
         .AppendFormat("      ,ArchivoAImprimirComplementarioEmbebido = {0}", GetStringFromBoolean(ArchivoAImprimirComplementarioEmbebido))
         .AppendFormat("      ,{0} = '{1}'", Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportar.ToString(), ArchivoAExportar)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportarEmbebido.ToString(), GetStringFromBoolean(ArchivoAExportarEmbebido))
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir.ToString(), IdTipoImpresionFiscalArchivoAImprimir)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir2.ToString(), IdTipoImpresionFiscalArchivoAImprimir2)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimirComplementario.ToString(), IdTipoImpresionFiscalArchivoAImprimirComplementario)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAExportar.ToString(), IdTipoImpresionFiscalArchivoAExportar)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir.ToString(), desplazamientoXArchivoAImprimir)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir.ToString(), desplazamientoYArchivoAImprimir)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir2.ToString(), desplazamientoXArchivoAImprimir2)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir2.ToString(), desplazamientoYArchivoAImprimir2)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimirComplementario.ToString(), desplazamientoXArchivoAImprimirComplementario)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimirComplementario.ToString(), desplazamientoYArchivoAImprimirComplementario)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAExportar.ToString(), desplazamientoXArchivoAExportar)
         .AppendFormat("      ,{0} = {1}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAExportar.ToString(), desplazamientoYArchivoAExportar)
         .AppendFormat(" WHERE IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}'", letra)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub TiposComprobantesLetras_D(ByVal idTipoComprobante As String, _
                                        ByVal letra As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM TiposComprobantesLetras  ")
         .AppendFormat(" WHERE IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("      AND Letra = '{0}'", letra)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Function TiposComprobantesLetras_GA() As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" ORDER BY TCL.IdTipoComprobante")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function GetUno(ByVal idTipoComprobante As String, ByVal letra As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IdTipoComprobante = '{0}'", idTipoComprobante)
         .AppendFormat("   AND Letra = '{0}' ", letra)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = "NombreTipoImpresionFiscalArchivoAImprimir" Then
         columna = String.Format("TIF1.{0}", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
      End If
      If columna = "NombreTipoImpresionFiscalArchivoAImprimir2" Then
         columna = String.Format("TIF2.{0}", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
      End If
      If columna = "NombreTipoImpresionFiscalArchivoAImprimirComplementario" Then
         columna = String.Format("TIF3.{0}", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
      End If
      If columna = "NombreTipoImpresionFiscalArchivoAExportar" Then
         columna = String.Format("TIF4.{0}", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
      End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE 1=1 ")
         For Each palabra As String In valor.ToString().Split(" "c)
            .AppendFormat("   AND {0} LIKE '%{1}%'", columna, palabra)
         Next
         .AppendLine()
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT ")
         .AppendLine("	   TCL.IdTipoComprobante,")
         .AppendLine("	   TCL.Letra,")
         .AppendLine("	   TCL.ArchivoAImprimir,")
         .AppendLine("	   TCL.ArchivoAImprimirEmbebido,")
         .AppendLine("	   TCL.NombreImpresora,")
         .AppendLine("	   TCL.CantidadItemsProductos,")
         .AppendLine("	   TCL.CantidadItemsObservaciones,")
         .AppendLine("	   TCL.Imprime,")
         .AppendLine("	   TCL.CantidadCopias,")
         .AppendLine("	   TCL.ArchivoAImprimir2,")
         .AppendLine("	   TCL.ArchivoAImprimirEmbebido2,")
         .AppendLine("	   TCL.ArchivoAImprimirComplementario,")
         .AppendLine("	   TCL.ArchivoAImprimirComplementarioEmbebido")
         .AppendFormatLine("	   ,TCL.{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir.ToString())
         .AppendFormatLine("	   ,TCL.{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir.ToString())
         .AppendFormatLine("	   ,TCL.{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimir2.ToString())
         .AppendFormatLine("	   ,TCL.{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimir2.ToString())
         .AppendFormatLine("	   ,TCL.{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAImprimirComplementario.ToString())
         .AppendFormatLine("	   ,TCL.{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAImprimirComplementario.ToString())
         .AppendFormatLine("	   ,TCL.{0}", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoXArchivoAExportar.ToString())
         .AppendFormatLine("	   ,TCL.{0},", Entidades.TipoComprobanteLetra.Columnas.DesplazamientoYArchivoAExportar.ToString())
         .AppendFormatLine("	   TCL.{0},", Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportar.ToString())
         .AppendFormatLine("	   TCL.{0},", Entidades.TipoComprobanteLetra.Columnas.ArchivoAExportarEmbebido.ToString())
         .AppendFormatLine("	   TCL.{0},", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir.ToString())
         .AppendFormatLine("	   TCL.{0},", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir2.ToString())
         .AppendFormatLine("	   TCL.{0},", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimirComplementario.ToString())
         .AppendFormatLine("	   TCL.{0},", Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAExportar.ToString())
         .AppendFormatLine("	   TIF1.{0} as NombreTipoImpresionFiscalArchivoAImprimir,", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
         .AppendFormatLine("	   TIF2.{0} as NombreTipoImpresionFiscalArchivoAImprimir2,", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
         .AppendFormatLine("	   TIF3.{0} as NombreTipoImpresionFiscalArchivoAImprimirComplementario,", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
         .AppendFormatLine("	   TIF4.{0} as NombreTipoImpresionFiscalArchivoAExportar", Entidades.TipoImpresionFiscal.Columnas.NombreTipoImpresionFiscal.ToString())
         .AppendLine("FROM TiposComprobantesLetras TCL       ")

         .AppendFormatLine("LEFT JOIN {0} TIF1 ON TCL.{1} = TIF1.{2}",
                           Entidades.TipoImpresionFiscal.NombreTabla,
                           Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir.ToString(),
                           Entidades.TipoImpresionFiscal.Columnas.IdTipoImpresionFiscal.ToString())
         .AppendFormatLine("LEFT JOIN {0} TIF2 ON TCL.{1} = TIF2.{2}",
                           Entidades.TipoImpresionFiscal.NombreTabla,
                           Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimir2.ToString(),
                           Entidades.TipoImpresionFiscal.Columnas.IdTipoImpresionFiscal.ToString())
         .AppendFormatLine("LEFT JOIN {0} TIF3 ON TCL.{1} = TIF3.{2}",
                           Entidades.TipoImpresionFiscal.NombreTabla,
                           Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAImprimirComplementario.ToString(),
                           Entidades.TipoImpresionFiscal.Columnas.IdTipoImpresionFiscal.ToString())
         .AppendFormatLine("LEFT JOIN {0} TIF4 ON TCL.{1} = TIF4.{2}",
                           Entidades.TipoImpresionFiscal.NombreTabla,
                           Entidades.TipoComprobanteLetra.Columnas.IdTipoImpresionFiscalArchivoAExportar.ToString(),
                           Entidades.TipoImpresionFiscal.Columnas.IdTipoImpresionFiscal.ToString())
      End With
   End Sub

End Class
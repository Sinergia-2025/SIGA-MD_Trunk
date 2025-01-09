Imports Eniac.Entidades
Public Class MRPProcesosProductivos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProcesosProductivos_I(idProcesoProductivo As Long,
                                    idProductoProceso As String,
                                    codigoProcesoProductivo As String,
                                    descripcionProceso As String,
                                    costoManoObraInterna As Decimal,
                                    costoManoObraExterna As Decimal,
                                    costoMateriaPrima As Decimal,
                                    costoTotalProceso As Decimal,
                                    fechaAltaProceso As DateTime,
                                    fechaModificaProceso As DateTime,
                                    fechaActualizaCostos As DateTime,
                                    tiempoTotalProceso As Decimal,
                                    archivoAdjunto As Integer?,
                                    respetaOrden As Boolean,
                                    activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15})",
                       MRPProcesoProductivo.NombreTabla,
                       MRPProcesoProductivo.Columnas.IdProcesoProductivo.ToString(),
                       MRPProcesoProductivo.Columnas.IdProductoProceso.ToString(),
                       MRPProcesoProductivo.Columnas.CodigoProcesoProductivo.ToString(),
                       MRPProcesoProductivo.Columnas.DescripcionProceso.ToString(),
                       MRPProcesoProductivo.Columnas.CostoManoObraInterna.ToString(),
                       MRPProcesoProductivo.Columnas.CostoManoObraExterna.ToString(),
                       MRPProcesoProductivo.Columnas.CostoMateriaPrima.ToString(),
                       MRPProcesoProductivo.Columnas.CostoTotalProceso.ToString(),
                       MRPProcesoProductivo.Columnas.FechaAltaProceso.ToString(),
                       MRPProcesoProductivo.Columnas.FechaModificaProceso.ToString(),
                       MRPProcesoProductivo.Columnas.FechaActualizaCostos.ToString(),
                       MRPProcesoProductivo.Columnas.TiempoTotalProceso.ToString(),
                       MRPProcesoProductivo.Columnas.IdArchivoAdjunto.ToString(),
                       MRPProcesoProductivo.Columnas.RespetaOrden.ToString(),
                       MRPProcesoProductivo.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}', '{2}', '{3}', {4}, {5}, {6}, {7}, '{8}', '{9}', '{10}', {11}, {12}, {13}, {14}",
                        idProcesoProductivo,
                        idProductoProceso,
                        codigoProcesoProductivo,
                        descripcionProceso,
                        costoManoObraInterna,
                        costoManoObraExterna,
                        costoMateriaPrima,
                        costoTotalProceso,
                        ObtenerFecha(fechaAltaProceso, True),
                        ObtenerFecha(fechaModificaProceso, True),
                        ObtenerFecha(fechaActualizaCostos, True),
                        tiempoTotalProceso,
                        IIf(archivoAdjunto.HasValue, archivoAdjunto, "NULL"),
                        GetStringFromBoolean(respetaOrden),
                        GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProcesosProductivos_U(idProcesoProductivo As Long,
                                    idProductoProceso As String,
                                    codigoProcesoProductivo As String,
                                    descripcionProceso As String,
                                    costoManoObraInterna As Decimal,
                                    costoManoObraExterna As Decimal,
                                    costoMateriaPrima As Decimal,
                                    costoTotalProceso As Decimal,
                                    fechaAltaProceso As Date,
                                    fechaModificaProceso As Date,
                                    fechaActualizaCostos As Date,
                                    tiempoTotalProceso As Decimal,
                                    archivoAdjunto As Integer?,
                                    respetaOrden As Boolean,
                                    activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPProcesoProductivo.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", MRPProcesoProductivo.Columnas.CodigoProcesoProductivo.ToString(), codigoProcesoProductivo).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivo.Columnas.DescripcionProceso.ToString(), descripcionProceso).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.CostoManoObraInterna.ToString(), costoManoObraInterna).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.CostoManoObraExterna.ToString(), costoManoObraExterna).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.CostoMateriaPrima.ToString(), costoMateriaPrima).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.CostoTotalProceso.ToString(), costoTotalProceso).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivo.Columnas.FechaAltaProceso.ToString(), ObtenerFecha(fechaAltaProceso, True)).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivo.Columnas.FechaModificaProceso.ToString(), ObtenerFecha(fechaModificaProceso, True)).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPProcesoProductivo.Columnas.FechaActualizaCostos.ToString(), ObtenerFecha(fechaActualizaCostos, True)).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.TiempoTotalProceso.ToString(), tiempoTotalProceso).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.IdArchivoAdjunto.ToString(), IIf(archivoAdjunto.HasValue, archivoAdjunto, "NULL")).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.RespetaOrden.ToString(), GetStringFromBoolean(respetaOrden)).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPProcesoProductivo.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", MRPProcesoProductivo.Columnas.IdProcesoProductivo.ToString(), idProcesoProductivo).AppendLine()

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProcesosProductivos_D(idProcesoProductivo As Double,
                                    idProductoProceso As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {3} AND {2} = '{4}'",
                       MRPProcesoProductivo.NombreTabla,
                       MRPProcesoProductivo.Columnas.IdProcesoProductivo.ToString(),
                       MRPProcesoProductivo.Columnas.IdProductoProceso.ToString(),
                       idProcesoProductivo, idProductoProceso)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT PP.*, P.NombreProducto, M.NombreMoneda FROM {0} AS PP ", Entidades.MRPProcesoProductivo.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS P ON PP.IdProductoProceso = P.IdProducto ", Producto.NombreTabla).AppendLine()
         .AppendFormat("   INNER JOIN {0} AS M ON M.IdMoneda = P.IdMoneda ", Moneda.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function ProcesosProductivos_G(idProcesoProductivo As Long, idProductoProceso As String,
                                          codigoProcesoProductivo As String, codigoProcesoProductivoExacto As Boolean,
                                          descripcionProcesoProductivo As String, descripcionProcesoProductivoExacto As Boolean,
                                          activosSiNo As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idProcesoProductivo > 0 Then
            .AppendFormatLine("   AND PP.IdProcesoProductivo = {0}", idProcesoProductivo)
         End If
         If Not String.IsNullOrWhiteSpace(idProductoProceso) Then
            .AppendFormatLine("   AND PP.IdProductoProceso = '{0}'", idProductoProceso)
         End If
         If Not String.IsNullOrWhiteSpace(codigoProcesoProductivo) Then
            If codigoProcesoProductivoExacto Then
               .AppendFormatLine("   AND PP.CodigoProcesoProductivo = '{0}'", codigoProcesoProductivo)
            Else
               .AppendFormatLine("   AND PP.CodigoProcesoProductivo LIKE '%{0}%'", codigoProcesoProductivo)
            End If
         End If
         If Not String.IsNullOrWhiteSpace(descripcionProcesoProductivo) Then
            If descripcionProcesoProductivoExacto Then
               .AppendFormatLine("   AND PP.DescripcionProceso = '{0}'", descripcionProcesoProductivo)
            Else
               .AppendFormatLine("   AND PP.DescripcionProceso LIKE '%{0}%'", descripcionProcesoProductivo)
            End If
         End If
         Select Case activosSiNo
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormatLine(" AND PP.Activo = {0}", GetStringFromBoolean(True))
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormatLine(" AND PP.Activo = {0}", GetStringFromBoolean(False))
         End Select
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function ProcesosProductivos_G1(idProcesoProductivo As Long, idProductoProceso As String) As DataTable

      Return ProcesosProductivos_G(idProcesoProductivo, idProductoProceso, codigoProcesoProductivo:=String.Empty, codigoProcesoProductivoExacto:=True,
                                   descripcionProcesoProductivo:=String.Empty, descripcionProcesoProductivoExacto:=True, Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function ProcesosProductivos_GAC(codigoProcesoProductivo As String, codigoProcesoProductivoExacto As Boolean) As DataTable
      Return ProcesosProductivos_G(idProcesoProductivo:=0, idProductoProceso:=String.Empty, codigoProcesoProductivo, codigoProcesoProductivoExacto,
                                   descripcionProcesoProductivo:=String.Empty, descripcionProcesoProductivoExacto:=True, Entidades.Publicos.SiNoTodos.TODOS)
   End Function
   Public Function ProcesosProductivos_GA_PorDescripcionBusqueda(descripcionProcesoProductivo As String, descripcionProcesoProductivoExacto As Boolean) As DataTable
      Return ProcesosProductivos_G(idProcesoProductivo:=0, idProductoProceso:=String.Empty, codigoProcesoProductivo:=String.Empty, codigoProcesoProductivoExacto:=True,
                                   descripcionProcesoProductivo, descripcionProcesoProductivoExacto, Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Function ProcesosProductivos_GA(idProductoProceso As String, activosSiNo As Entidades.Publicos.SiNoTodos) As DataTable
      Return ProcesosProductivos_G(idProcesoProductivo:=0, idProductoProceso:=idProductoProceso, codigoProcesoProductivo:=String.Empty, codigoProcesoProductivoExacto:=True,
                                   descripcionProcesoProductivo:=String.Empty, descripcionProcesoProductivoExacto:=True, activosSiNo)
   End Function

   Public Function ProcesosProductivos_GA() As DataTable
      Return ProcesosProductivos_G(idProcesoProductivo:=0, idProductoProceso:=String.Empty, codigoProcesoProductivo:=String.Empty, codigoProcesoProductivoExacto:=True,
                                   descripcionProcesoProductivo:=String.Empty, descripcionProcesoProductivoExacto:=True, Entidades.Publicos.SiNoTodos.TODOS)
   End Function

   Public Overloads Function GetCodigoMaximo() As Long
      Return Convert.ToInt64(GetCodigoMaximo(MRPProcesoProductivo.Columnas.IdProcesoProductivo.ToString(), MRPProcesoProductivo.NombreTabla))
   End Function

   Public Function ExisteAdjunto(idProductoProceso As String, idItemAdjunto As Integer) As Boolean
      Dim stb = New StringBuilder("")
      With stb
         .AppendFormat("SELECT * FROM {0} AS PP", MRPProcesoProductivo.NombreTabla)
         .AppendFormat("   WHERE PP.{0} = '{2}' AND PP.{1} = {3}",
                           MRPProcesoProductivo.Columnas.IdProductoProceso.ToString(),
                           MRPProcesoProductivo.Columnas.IdArchivoAdjunto.ToString(), idProductoProceso, idItemAdjunto)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function

   Public Function GetProcesosProductivosCostos(idProducto As String, marcas As Entidades.Marca(), rubros As Entidades.Rubro(),
                                                subrubros As Entidades.SubRubro(), subSubRubros As Entidades.SubSubRubro()) As DataTable
      Dim stb = New StringBuilder("")
      With stb
         .AppendFormatLine("SELECT 'FALSE' as Masivo, P.IdProducto, P.NombreProducto, ")
         .AppendFormatLine("       PP.IdProcesoProductivo, PP.DescripcionProceso,  ")
         '------------------------------------------------------------------------------
         .AppendFormatLine("       MO.IdMoneda, MO.NombreMoneda,  ")
         '------------------------------------------------------------------------------
         .AppendFormatLine("       M.IdMarca, M.NombreMarca,  ")
         .AppendFormatLine("       R.IdRubro, R.NombreRubro, ")
         .AppendFormatLine("       SR.IdSubRubro, SR.NombreSubRubro,")
         .AppendFormatLine("       PP.CostoMateriaPrima, PP.CostoManoObraInterna, ")
         .AppendFormatLine("       PP.CostoManoObraExterna, PP.CostoTotalProceso, PP.FechaActualizaCostos,")
         .AppendFormatLine("       PP.FechaAltaProceso, PP.FechaModificaProceso")

         .AppendFormat("      FROM {0} AS P ", Producto.NombreTabla)

         .AppendFormat("      INNER JOIN Monedas AS MO ON MO.IdMoneda = P.IdMoneda ", Marca.NombreTabla)

         .AppendFormat("      LEFT JOIN {0} AS M ON P.IdMarca = M.IdMarca ", Marca.NombreTabla)
         .AppendFormat("      LEFT JOIN {0} AS R ON P.idRubro = r.IdRubro ", Rubro.NombreTabla)
         .AppendFormat("      LEFT JOIN {0} AS SR ON P.IdRubro = SR.IdRubro ANd P.IdSubRubro = SR.IdSubRubro ", SubRubro.NombreTabla)
         .AppendFormat("      LEFT JOIN {0} AS PP ON P.IdProcesoProductivoDefecto = PP.IdProcesoProductivo ", MRPProcesoProductivo.NombreTabla)

         .AppendFormat("   WHERE P.{0} IS NOT NULL", Producto.Columnas.IdProcesoProductivoDefecto.ToString())

         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("                  AND P.IdProducto = '{0}'", idProducto)
         End If
         GetListaMarcasMultiples(stb, marcas, "P")
         GetListaRubrosMultiples(stb, rubros, "P")
         GetListaSubRubrosMultiples(stb, subrubros, "P")
         GetListaSubSubRubrosMultiples(stb, subSubRubros, "P")

      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

End Class

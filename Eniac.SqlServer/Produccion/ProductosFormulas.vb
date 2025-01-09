Public Class ProductosFormulas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosFormulas_I(idProducto As String, idFormula As Integer,
                                  nombreFormula As String, PorcentajeGanancia As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO ProductosFormulas (")
         .AppendFormatLine("    IdProducto")
         .AppendFormatLine("  , IdFormula")
         .AppendFormatLine("  , NombreFormula ")
         .AppendFormatLine("  ,PorcentajeGanancia")
         .AppendFormatLine("  ) VALUES ( ")
         .AppendFormatLine("    '{0}'", idProducto)
         .AppendFormatLine("  ,  {0} ", idFormula)
         .AppendFormatLine("  , '{0}'", nombreFormula)
         .AppendFormatLine("  ,  {0} ", PorcentajeGanancia)

         .AppendFormatLine("   )")
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosFormulas")
   End Sub
   Public Sub ProductosFormulas_U(idProducto As String, idFormula As Integer,
                                  nombreFormula As String, PorcentajeGanancia As Decimal)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE ProductosFormulas")
         .AppendFormatLine("   SET NombreFormula = '{0}'", nombreFormula)
         .AppendFormatLine("   ,PorcentajeGanancia = {0}", PorcentajeGanancia)
         .AppendFormatLine(" WHERE IdProducto    = '{0}'", idProducto)
         .AppendFormatLine("   AND IdFormula     =  {0} ", idFormula)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosFormulas")
   End Sub
   Public Sub ProductosFormulas_D(idProducto As String, idFormula As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM ProductosFormulas ")
         .AppendFormatLine(" WHERE IdProducto   = '{0}'", idProducto)
         .AppendFormatLine("   AND IdFormula    =  {0} ", idFormula)
      End With
      Execute(myQuery)
      Sincroniza_I(myQuery.ToString(), "ProductosFormulas")
   End Sub
   Public Sub ProductosFormulas_M(en As Entidades.ProductoFormula)
      Dim query = New StringBuilder()
      With query
         .AppendFormatLine("MERGE INTO ProductosFormulas AS DEST ")
         .AppendFormatLine("        USING (SELECT '{1}' AS {0}", Entidades.ProductoFormula.Columnas.IdProducto.ToString(), en.IdProducto)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoFormula.Columnas.IdFormula.ToString(), en.IdFormula)
         .AppendFormatLine("                    , '{1}' AS {0}", Entidades.ProductoFormula.Columnas.NombreFormula.ToString(), en.NombreFormula)
         .AppendFormatLine("                    ,  {1}  AS {0}", Entidades.ProductoFormula.Columnas.PorcentajeGanancia.ToString(), en.PorcentajeGanancia)
         .AppendFormatLine("              ) AS ORIG ON ORIG.{0} = DEST.{0} AND ORIG.{1} = DEST.{1}",
                              Entidades.ProductoFormula.Columnas.IdProducto.ToString(),
                              Entidades.ProductoFormula.Columnas.IdFormula.ToString())
         .AppendFormatLine("    WHEN MATCHED THEN")
         .AppendFormatLine("        UPDATE SET DEST.{0} = ORIG.{0}",
                           Entidades.ProductoFormula.Columnas.NombreFormula.ToString())
         .AppendFormatLine("        ,DEST.{0} = ORIG.{0}",
                           Entidades.ProductoFormula.Columnas.PorcentajeGanancia.ToString())
         .AppendFormatLine("    WHEN NOT MATCHED THEN ")
         .AppendFormatLine("        INSERT ({0}, {1}, {2}) VALUES (ORIG.{0}, ORIG.{1}, ORIG.{2}, ORIG.{3})",
                           Entidades.ProductoFormula.Columnas.IdProducto.ToString(),
                           Entidades.ProductoFormula.Columnas.IdFormula.ToString(),
                           Entidades.ProductoFormula.Columnas.NombreFormula.ToString(),
                           Entidades.ProductoFormula.Columnas.PorcentajeGanancia.ToString())
         .AppendFormatLine(";")
      End With
      Execute(query)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT PF.*")
         .AppendLine(" FROM ProductosFormulas PF")

         ' JOINS
         .AppendLine("INNER JOIN Productos P ON PF.IdProducto = P.IdProducto")
      End With
   End Sub

   Private Function ProductosFormulas_G(idProducto As String, idFormula As Integer, idFormulaDistinto As Boolean, fechaActualizacionDesde As Date?,
                                        publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND PF.IdProducto = '{0}'", idProducto)
         End If
         If idFormula <> 0 Then
            .AppendFormatLine(" AND PF.IdFormula {1} {0}", idFormula, If(idFormulaDistinto, "<>", "="))
         End If
         If fechaActualizacionDesde.HasValue Then
            .AppendFormatLine(" AND P.{0} > '{1}'",
                              Entidades.Producto.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True, True))
         End If
         ProductoPublicarEn(myQuery, publicarEn, "P")
         'If publicarEn <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormat("   AND P.{0} = {1}",
         '                   Entidades.Producto.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEn = Entidades.Publicos.SiNoTodos.SI)).AppendLine()
         'End If
      End With
      Return GetDataTable(myQuery.ToString())
   End Function

   Public Function ProductosFormulas_GA() As DataTable
      Return ProductosFormulas_G(idProducto:="", idFormula:=0, idFormulaDistinto:=True, fechaActualizacionDesde:=Nothing, publicarEn:=New Entidades.Filtros.ProductosPublicarEnFiltros())
   End Function

   Public Function ProductosFormulas_GA(idProducto As String) As DataTable
      Return ProductosFormulas_G(idProducto, idFormula:=0, idFormulaDistinto:=True, fechaActualizacionDesde:=Nothing, publicarEn:=New Entidades.Filtros.ProductosPublicarEnFiltros())
   End Function
   Public Function ProductosFormulas_GA(idProducto As String, idFormulaDistinto As Integer) As DataTable
      Return ProductosFormulas_G(idProducto, idFormulaDistinto, idFormulaDistinto:=True, fechaActualizacionDesde:=Nothing, publicarEn:=New Entidades.Filtros.ProductosPublicarEnFiltros())
   End Function

   Public Function ProductosFormulas_GA(fechaActualizacionDesde As Date?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Return ProductosFormulas_G(idProducto:="", idFormula:=0, idFormulaDistinto:=True, fechaActualizacionDesde:=fechaActualizacionDesde, publicarEn:=publicarEn)
   End Function

   Public Function ProductosFormulas_G1(idProducto As String, idFormula As Integer) As DataTable
      Return ProductosFormulas_G(idProducto, idFormula, idFormulaDistinto:=False, fechaActualizacionDesde:=Nothing, publicarEn:=New Entidades.Filtros.ProductosPublicarEnFiltros())
   End Function

   Public Function GetFormulas(IdSucursal As Integer, IdProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PF.IdProducto")
         .AppendFormatLine("      ,PF.IdFormula")
         .AppendFormatLine("      ,PF.NombreFormula")
         .AppendFormatLine("      ,PF.PorcentajeGanancia")
         .AppendFormatLine(" FROM ProductosFormulas PF ")
         .AppendFormatLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = PF.IdProducto")
         .AppendFormatLine(" WHERE PS.IdSucursal =  {0} ", IdSucursal)
         .AppendFormatLine("   AND PF.IdProducto = '{0}'", IdProducto)
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Overloads Function GetCodigoMaximo(idProducto As String) As Integer
      Return GetCodigoMaximo("IdFormula", "ProductosFormulas", String.Format("IdProducto = '{0}'", idProducto)).ToInteger()
   End Function

   Public Function GetPorNombreExacto(IdProducto As String, Nombre As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("SELECT PF.IdProducto")
         .AppendFormatLine("      ,PF.IdFormula")
         .AppendFormatLine("      ,PF.NombreFormula")
         .AppendFormatLine("      ,PF.PorcentajeGanancia")
         .AppendFormatLine(" FROM ProductosFormulas PF")
         .AppendFormatLine(" WHERE PF.IdProducto    = '{0}'", IdProducto)
         .AppendFormatLine("   AND PF.NombreFormula = '{0}'", Nombre)
      End With
      Return GetDataTable(myQuery)
   End Function

End Class
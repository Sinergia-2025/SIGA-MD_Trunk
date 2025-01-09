Public Class ProveedoresProductosComparar
   Inherits Comunes

#Region "Constructores"

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

#End Region

   Public Sub ProveedoresProductosComparar_I(idProducto As String,
                                             linea As Integer,
                                             idProveedor As Long,
                                             codigoProductoProveedor As String,
                                             precioCompraAnterior As Decimal?,
                                             porcVarCompra As Decimal?,
                                             precioCompra As Decimal?,
                                             descRec1 As Decimal?,
                                             descRec2 As Decimal?,
                                             descRec3 As Decimal?,
                                             descRec4 As Decimal?,
                                             precioCostoAnterior As Decimal?,
                                             porcVarCosto As Decimal?,
                                             precioCosto As Decimal?)

      Dim query As StringBuilder = New StringBuilder()
      With query
         .AppendFormatLine("INSERT INTO ProveedoresProductosComparar (")
         .AppendFormatLine("   IdProducto")
         .AppendFormatLine("   ,Linea")
         .AppendFormatLine("   ,IdProveedor")
         .AppendFormatLine("   ,CodigoProductoProveedor")
         .AppendFormatLine("   ,PrecioCompraAnterior")
         .AppendFormatLine("   ,PorcVarCompra")
         .AppendFormatLine("   ,PrecioCompra")
         .AppendFormatLine("   ,DescRec1")
         .AppendFormatLine("   ,DescRec2")
         .AppendFormatLine("   ,DescRec3")
         .AppendFormatLine("   ,DescRec4")
         .AppendFormatLine("   ,PrecioCostoAnterior")
         .AppendFormatLine("   ,PorcVarCosto")
         .AppendFormatLine("   ,PrecioCosto")
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("    '{0}'", idProducto)
         .AppendFormatLine("    ,{0}", linea)
         .AppendFormatLine("    ,{0}", idProveedor)
         .AppendFormatLine("    ,'{0}'", codigoProductoProveedor)

         If precioCompraAnterior.HasValue Then
            .AppendFormatLine("    ,{0}", precioCompraAnterior.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If porcVarCompra.HasValue Then
            .AppendFormatLine("    ,{0}", porcVarCompra.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If precioCompra.HasValue Then
            .AppendFormatLine("    ,{0}", precioCompra.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If descRec1.HasValue Then
            .AppendFormatLine("    ,{0}", descRec1.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If descRec2.HasValue Then
            .AppendFormatLine("    ,{0}", descRec2.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If descRec3.HasValue Then
            .AppendFormatLine("    ,{0}", descRec3.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If descRec4.HasValue Then
            .AppendFormatLine("    ,{0}", descRec4.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If precioCostoAnterior.HasValue Then
            .AppendFormatLine("    ,{0}", precioCostoAnterior.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If porcVarCosto.HasValue Then
            .AppendFormatLine("    ,{0}", porcVarCosto.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         If precioCosto.HasValue Then
            .AppendFormatLine("    ,{0}", precioCosto.Value)
         Else
            .AppendLine("    ,NULL")
         End If

         .AppendLine(")")
      End With

      Me.Execute(query.ToString())
   End Sub

   '# No se va a utilizar por ahora
   Public Sub ProveedoresProductosComparar_U(idProducto As String,
                                             linea As Integer,
                                             idProveedor As Long,
                                             codigoProductoProveedor As String,
                                             precioCompraAnterior As Decimal?,
                                             porcVarCompra As Decimal?,
                                             precioCompra As Decimal?,
                                             descRec1 As Decimal?,
                                             descRec2 As Decimal?,
                                             descRec3 As Decimal?,
                                             descRec4 As Decimal?,
                                             precioCostoAnterior As Decimal?,
                                             porcVarCosto As Decimal?,
                                             precioCosto As Decimal?)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("UPDATE ProveedoresProductosComparar SET ")
         .AppendFormatLine("  {0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.CodigoProductoProveedor.ToString(), codigoProductoProveedor)

         If precioCompraAnterior.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.PrecioCompraAnterior.ToString(), precioCompraAnterior.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.PrecioCompraAnterior.ToString())
         End If

         If porcVarCompra.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.PorcVarCompra.ToString(), porcVarCompra.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.PorcVarCompra.ToString())
         End If

         If precioCompra.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.PrecioCompra.ToString(), precioCompra.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.PrecioCompra.ToString())
         End If

         If descRec1.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.DescRec1.ToString(), descRec1.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.DescRec1.ToString())
         End If

         If descRec2.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.DescRec2.ToString(), descRec2.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.DescRec2.ToString())
         End If

         If descRec3.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.DescRec3.ToString(), descRec3.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.DescRec3.ToString())
         End If

         If descRec4.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.DescRec4.ToString(), descRec4.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.DescRec4.ToString())
         End If

         If precioCostoAnterior.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.PrecioCostoAnterior.ToString(), precioCostoAnterior.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.PrecioCostoAnterior.ToString())
         End If

         If porcVarCosto.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.PorcVarCosto.ToString(), porcVarCosto.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.PorcVarCosto.ToString())
         End If

         If precioCosto.HasValue Then
            .AppendFormatLine("  ,{0} = '{1}'", Entidades.ProveedorProductoComparar.Columnas.PrecioCosto.ToString(), precioCosto.Value)
         Else
            .AppendFormatLine("  ,{0} = NULL", Entidades.ProveedorProductoComparar.Columnas.PrecioCosto.ToString())
         End If

         .AppendLine("  WHERE 1=1")
         .AppendFormatLine("     AND IdProducto = '{0}'", idProducto)
         .AppendFormatLine("     AND Linea = {0}", linea)

      End With

      Me.Execute(query.ToString())
   End Sub

   Public Sub ProveedoresProductosComparar_D(idProveedor As Long)

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("DELETE ProveedoresProductosComparar")
         .AppendFormatLine("     WHERE IdProveedor = {0}", idProveedor)
      End With

      Me.Execute(query.ToString())
   End Sub

   Public Function ProveedoresProductosComparar_GA() As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function ProveedoresProductosComparar_G1(idProducto As String, linea As Integer) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         SelectTexto(query)
         .AppendLine("  WHERE 1=1")
         .AppendFormatLine("     AND IdProducto = '{0}'", idProducto)
         .AppendFormatLine("     AND Linea = {0}", linea)
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function CompararProductosEntreProveedores(proveedores As List(Of Entidades.Proveedor),
                                                     idSucursal As Integer,
                                                     idProducto As String,
                                                     marcas As Entidades.Marca(),
                                                     rubros As Entidades.Rubro(),
                                                     subrubros As Entidades.SubRubro(),
                                                     subsubrubros As Entidades.SubSubRubro()) As DataTable

      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT IdProducto")
         .AppendFormatLine("        ,NombreProducto")
         .AppendFormatLine("		   ,Actual")

         '# Costos de los Proveedores seleccionados
         For Each prov As Entidades.Proveedor In proveedores
            .AppendFormatLine("		   ,SUM([{0}]) AS 'Pr. Costo Prov. {1}'", prov.IdProveedor, prov.NombreProveedor)
         Next

         .AppendFormatLine("FROM (SELECT PR.IdProveedor")
         .AppendFormatLine("		,PR.NombreProveedor AS PROV")
         .AppendFormatLine("		,PS.IdProducto")
         .AppendFormatLine("		,PS.PrecioCosto AS Actual")
         .AppendFormatLine("		,P.NombreProducto")
         .AppendFormatLine("		,PPC.PrecioCosto FROM ProveedoresProductosComparar PPC")
         .AppendFormatLine("		INNER JOIN Proveedores PR ON PPC.IdProveedor = PR.IdProveedor")
         .AppendFormatLine("		INNER JOIN Productos P ON PPC.IdProducto = P.IdProducto")
         .AppendFormatLine("		INNER JOIN ProductosSucursales PS ON PPC.IdProducto = PS.IdProducto")
         .AppendFormatLine("			WHERE PS.IdSucursal = {0}", idSucursal)

         '# ################ Inicio Filtros

         If Not String.IsNullOrEmpty(idProducto) Then
            .AppendFormatLine("			AND P.IdProducto = '{0}'", idProducto)
         End If

         GetListaMarcasMultiples(query, marcas, "P")
         GetListaRubrosMultiples(query, rubros, "P")
         GetListaSubRubrosMultiples(query, subrubros, "P")
         GetListaSubSubRubrosMultiples(query, subsubrubros, "P")

         '# ################ Fin Filtros

         .AppendFormatLine(") SRC")
         .AppendFormatLine("PIVOT")
         .AppendFormatLine("(")
         .AppendFormatLine("	SUM(PrecioCosto) FOR IdProveedor IN ([0]")

         '# Id de los Proveeedores seleccionados
         For Each prov As Entidades.Proveedor In proveedores
            .AppendFormatLine(",[{0}]", prov.IdProveedor)
         Next

         .AppendFormatLine(")")
         .AppendFormatLine(") PVT")
         .AppendFormatLine("GROUP BY IdProducto")
         .AppendFormatLine("		,NombreProducto")
         .AppendFormatLine("		,Actual")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(MyBase.GetCodigoMaximo("Linea", "ProveedoresProductosComparar"))
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Dim query As StringBuilder = New StringBuilder()
      With query
         Me.SelectTexto(query)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(query.ToString())
   End Function

   Public Sub SelectTexto(query As StringBuilder)
      With query
         .AppendFormatLine("SELECT PPC.* FROM ProveedoresProductosComparar PPC")
      End With
   End Sub

End Class

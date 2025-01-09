Option Strict On
Option Explicit On
Public Class ProductosClientes
   Inherits Comunes
   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
   Public Sub ProductosPorCliente_I(idProducto As String, idCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0}", Entidades.ProductosClientes.NombreTabla).AppendLine()
         .AppendFormat("           ({0}, {1})",
                       Entidades.ProductosClientes.Columnas.IdProducto.ToString(),
                       Entidades.ProductosClientes.Columnas.IdCliente.ToString()).AppendLine()
         .AppendFormat("    VALUES ('{0}', {1})", idProducto, idCliente)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub ProductosPorCliente_D(idCliente As Long)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", Entidades.ProductosClientes.NombreTabla)
         .AppendFormat(" WHERE 1 = 1")

         .AppendFormat("   AND {0} = {1}", Entidades.ProductosClientes.Columnas.IdCliente.ToString(), idCliente)

      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProductosPorCliente_DxProducto(idProducto As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} ", Entidades.ProductosClientes.NombreTabla)
         .AppendFormat(" WHERE 1 = 1")

         .AppendFormat("   AND {0} = '{1}'", Entidades.ProductosClientes.Columnas.IdProducto.ToString(), idProducto)

      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Function ProductosClientes_G1(idProducto As String, idCliente As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormat("SELECT * FROM ProductosClientes PC")
         .AppendFormatLine(" WHERE PC.idProducto = '{0}'", idProducto)
         .AppendFormatLine("   AND PC.IdCliente = {0}", idCliente)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function GetProductosCliente(idCliente As Long,
                                    marcas As Entidades.Marca(),
                                    rubros As Entidades.Rubro(),
                                    subRubros As Entidades.SubRubro()) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("SELECT   P.IdProducto").AppendLine()
         .AppendFormat("        ,P.NombreProducto").AppendLine()
         .AppendFormat("        ,P.IdMarca").AppendLine()
         .AppendFormat("        ,M.NombreMarca").AppendLine()
         .AppendFormat("        ,P.IdRubro").AppendLine()
         .AppendFormat("        ,R.NombreRubro").AppendLine()
         .AppendFormat("        ,P.IdSubRubro").AppendLine()
         .AppendFormat("        ,SR.NombreSubRubro").AppendLine()
         .AppendFormat("    FROM Productos P").AppendLine()
         If idCliente > 0 Then
            .AppendFormat("        INNER JOIN ProductosClientes PC ON PC.IdProducto = P.IdProducto AND PC.IdCliente = {0}", idCliente)
         End If
         .AppendFormat("	     LEFT JOIN Marcas M ON M.IdMarca = P.IdMarca").AppendLine()
         .AppendFormat("	     LEFT JOIN Rubros R ON R.IdRubro = P.IdRubro").AppendLine()
         .AppendFormat("        LEFT OUTER JOIN SubRubros SR ON P.IdRubro = SR.IdRubro AND P.IdSubRubro = SR.IdSubRubro").AppendLine()

         .AppendFormat("         WHERE 1=1").AppendLine()

         If Not idCliente > 0 Then
            GetListaRubrosMultiples(stb, rubros, "P")
            GetListaSubRubrosMultiples(stb, subRubros, "P")
            GetListaMarcasMultiples(stb, marcas, "P")
         End If

      End With

      Return GetDataTable(stb.ToString())
   End Function

   Public Function GetParaSincronizacionMovil(idSucursal As Integer,
                                              incluirClientes As String,
                                              incluidoEnRuta As Boolean,
                                              idCategoria As Integer,
                                              modulo As String,
                                              publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros,
                                              soloProductosConStock As Boolean) As DataTable
      Dim query As StringBuilder = New StringBuilder
      With query
         .AppendFormatLine("SELECT ")
         .AppendFormatLine("	 PC.IdCliente")
         .AppendFormatLine("	,PC.IdProducto")
         .AppendFormatLine("FROM ProductosClientes PC")
         .AppendFormatLine("	INNER JOIN Clientes C ON PC.IdCliente = C.IdCliente")
         .AppendFormatLine("	INNER JOIN Productos P ON PC.IdProducto = P.IdProducto")
         .AppendFormatLine("WHERE 1=1")

         '# Filtros
         .AppendFormatLine("	AND C.Activo = 1")

         If incluirClientes = "SoloClientesConDeuda" Then
            .AppendLine("	AND EXISTS (SELECT CC.IdSucursal")
            .AppendLine("                  FROM CuentasCorrientes CC")
            .AppendLine("         WHERE CC.IdCliente = C.IdCliente")
            .AppendLine("                   AND CC.Saldo > 0)")
         End If

         If incluidoEnRuta Then
            .AppendLine("    AND EXISTS (SELECT MRC.IdCliente")
            .AppendLine("                  FROM MovilRutasClientes MRC")
            .AppendLine("                 INNER JOIN MovilRutas MR ON MR.IdRuta = MRC.IdRuta")
            .AppendLine("         WHERE MRC.IdCliente = C.IdCliente")
            .AppendLine("                   AND MR.Activa = 1)")
         End If

         If idCategoria <> 0 Then
            .AppendFormatLine("   AND C.IdCategoria = {0}", idCategoria)
         End If

         If modulo <> "TODOS" Then
            .AppendFormatLine("   AND P.EsDe{0} = 'True'", modulo)
         End If

         If soloProductosConStock Then
            .AppendFormatLine("   AND PS.Stock > 0")
         End If

         ProductoPublicarEn(query, publicarEn, "P")
      End With

      Return Me.GetDataTable(query.ToString())
   End Function

   Public Function GetClientexProducto(idProducto As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .AppendFormat("SELECT TOP 1  PC.IdCliente FROM ProductosClientes PC WHERE PC.IdProducto = '{0}' ", idProducto).AppendLine()
      End With

      Return GetDataTable(stb.ToString())
   End Function

End Class

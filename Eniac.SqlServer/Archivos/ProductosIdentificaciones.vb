Option Strict On
Option Explicit On
Public Class ProductosIdentificaciones
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosIdentificaciones_I(idProducto As String, identificacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0}", Entidades.ProductoIdentificacion.NombreTabla)
         .AppendFormatLine("           ({0}, {1})",
                           Entidades.ProductoIdentificacion.Columnas.IdProducto.ToString(),
                           Entidades.ProductoIdentificacion.Columnas.Identificacion.ToString())
         .AppendFormatLine("    VALUES ('{0}', '{1}')",
                           idProducto, identificacion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProductosIdentificaciones_U(idProducto As String, identificacion As String)
      'Actualmente la tabla tiene solo PK por lo que no tiene sentido hacer UPDATES
      'Dim myQuery As StringBuilder = New StringBuilder()
      'With myQuery
      '   .AppendFormatLine("UPDATE {0} ", Entidades.ProductoIdentificacion.NombreTabla)
      '   '.AppendFormatLine("   SET {0} = '{1}'", Entidades.ProductoIdentificacion.Columnas.NombreRuta.ToString(), nombreProductoIdentificacion)
      '   .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.ProductoIdentificacion.Columnas.IdProducto.ToString(), idProducto)
      '   .AppendFormatLine("   AND {0} = '{1}'", Entidades.ProductoIdentificacion.Columnas.Identificacion.ToString(), identificacion)
      'End With
      'Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ProductosIdentificaciones_D(idProducto As String, identificacion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE 1 = 1", Entidades.ProductoIdentificacion.NombreTabla)
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormat("   AND {0} = '{1}'", Entidades.ProductoIdentificacion.Columnas.IdProducto.ToString(), idProducto)
         End If
         If Not String.IsNullOrWhiteSpace(identificacion) Then
            .AppendFormat("   AND {0} = '{1}'", Entidades.ProductoIdentificacion.Columnas.Identificacion.ToString(), identificacion)
         End If
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT PI.*")
         .AppendFormatLine("  FROM {0} AS PI", Entidades.ProductoIdentificacion.NombreTabla)

         ' JOINS
         .AppendLine("INNER JOIN Productos P ON PI.IdProducto = P.IdProducto ")
      End With
   End Sub

   Public Function ProductosIdentificaciones_GA() As DataTable
      Return ProductosIdentificaciones_G(idProducto:=String.Empty, identificacion:=String.Empty, idProductoExacto:=True, identificacionExacta:=True, fechaActualizacionDesde:=Nothing, publicarEn:=Nothing)
   End Function
   Public Function ProductosIdentificaciones_GA(idProducto As String) As DataTable
      Return ProductosIdentificaciones_G(idProducto, identificacion:=String.Empty, idProductoExacto:=True, identificacionExacta:=True, fechaActualizacionDesde:=Nothing, publicarEn:=Nothing)
   End Function
   Public Function ProductosIdentificaciones_GA(fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Return ProductosIdentificaciones_G(idProducto:=Nothing, fechaActualizacionDesde:=fechaActualizacionDesde, publicarEn:=publicarEn, identificacion:=String.Empty, idProductoExacto:=True, identificacionExacta:=True)
   End Function

   Private Function ProductosIdentificaciones_G(idProducto As String, identificacion As String, idProductoExacto As Boolean, identificacionExacta As Boolean?, fechaActualizacionDesde As DateTime?, publicarEn As Entidades.Filtros.ProductosPublicarEnFiltros) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      Const exactoFormat As String = "   AND PI.{0} = '{1}'"
      Const likeFormat As String = "   AND PI.{0} LIKE '%{1}%'"

      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine(If(idProductoExacto, exactoFormat, likeFormat), Entidades.ProductoIdentificacion.Columnas.IdProducto.ToString(), idProducto)
         End If
         If Not String.IsNullOrWhiteSpace(identificacion) Then
            .AppendFormatLine(If(identificacionExacta, exactoFormat, likeFormat), Entidades.ProductoIdentificacion.Columnas.Identificacion.ToString(), identificacion)
         End If

         If fechaActualizacionDesde.HasValue Then
            .AppendFormat("   AND P.{0} > '{1}'",
                            Entidades.Producto.Columnas.FechaActualizacionWeb.ToString(), ObtenerFecha(fechaActualizacionDesde.Value, True)).AppendLine()
         End If
         ProductoPublicarEn(myQuery, publicarEn, "P")
         'If publicarEnWeb <> Entidades.Publicos.SiNoTodos.TODOS Then
         '   .AppendFormat("   AND P.{0} = {1}",
         '                   Entidades.Producto.Columnas.PublicarEnWeb.ToString(), GetStringFromBoolean(publicarEnWeb = Entidades.Publicos.SiNoTodos.SI)).AppendLine()
         'End If

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ProductosIdentificaciones_G1(idProducto As String, identificacion As String) As DataTable
      Return ProductosIdentificaciones_G(idProducto, identificacion, idProductoExacto:=True, identificacionExacta:=True, fechaActualizacionDesde:=Nothing, publicarEn:=New Entidades.Filtros.ProductosPublicarEnFiltros())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "NombreVendedor" Then
      '   columna = "E.NombreEmpleado"
      'Else
      columna = "PI." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE {0} LIKE '%{1}%'", columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
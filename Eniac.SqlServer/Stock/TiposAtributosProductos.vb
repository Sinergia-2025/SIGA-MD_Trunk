Public Class TiposAtributosProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub TiposAtributosProductos_I(idTipoAtributoProducto As Short,
                                        descripcion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2})",
                       Entidades.TipoAtributoProducto.NombreTabla,
                       Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString(),
                       Entidades.TipoAtributoProducto.Columnas.Descripcion.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, '{1}'", idTipoAtributoProducto, descripcion)
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TiposAtributosProductos_U(idTipoAtributoProducto As Short,
                                        descripcion As String)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.TipoAtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.TipoAtributoProducto.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString(), idTipoAtributoProducto).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub TiposAtributosProductos_D(idTipoAtributoProducto As Short)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.TipoAtributoProducto.NombreTabla, Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString(), idTipoAtributoProducto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT TAP.* FROM {0} AS TAP", Entidades.TipoAtributoProducto.NombreTabla).AppendLine()
      End With
   End Sub
   Public Function TiposAtributosProductos_G1(idTipoAtributoProducto As Short) As DataTable
      Return TiposAtributosProductos_G(idTipoAtributoProducto:=idTipoAtributoProducto, descripcion:=String.Empty)
   End Function
   Private Function TiposAtributosProductos_G(idTipoAtributoProducto As Short, descripcion As String) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendFormat("   WHERE 1 = 1").AppendLine()
         If idTipoAtributoProducto <> 0 Then
            .AppendFormat("   AND TAP.IdTipoAtributoProducto = {0}", idTipoAtributoProducto).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat("   AND TAP.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "TAP." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Function TiposAtributosProductos_GA() As DataTable
      Return TiposAtributosProductos_G(idTipoAtributoProducto:=0, descripcion:=String.Empty)
   End Function
   Public Overloads Function GetCodigoMaximo() As Short
      Return Convert.ToInt16(GetCodigoMaximo(Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString(), "TiposAtributosProductos"))
   End Function
   Public Function GetFiltradoPorCodigo(codigo As Short) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         SelectTexto(stbQuery)
         If codigo > 0 Then
            .AppendFormat(" WHERE TAP.IdTipoAtributoProducto = {0}", codigo)
         End If
         .AppendLine(" ORDER BY TAP.IdTipoAtributoProducto")
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String) As DataTable
      Dim stbQuery = New StringBuilder()

      With stbQuery
         SelectTexto(stbQuery)
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat(" WHERE TAP.Descripcion LIKE '%{0}%' ", descripcion)
         End If
         .AppendLine(" ORDER BY TAP.IdTipoAtributoProducto")
      End With
      Dim dt As DataTable = Me.GetDataTable(stbQuery.ToString())
      Return dt
   End Function

End Class

Public Class GruposTiposAtributosProductos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub GruposTiposAtributosProductos_I(idGrupoTipoAtributoProducto As Integer,
                                              idTipoAtributoProducto As Short,
                                              descripcion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3})",
                       Entidades.GrupoTipoAtributoProducto.NombreTabla,
                       Entidades.GrupoTipoAtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString(),
                       Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString(),
                       Entidades.GrupoTipoAtributoProducto.Columnas.Descripcion.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, {1}, '{2}')", idGrupoTipoAtributoProducto, idTipoAtributoProducto, descripcion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub GruposTiposAtributosProductos_U(idGrupoTipoAtributoProducto As Integer,
                                              idTipoAtributoProducto As Short,
                                              descripcion As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}        ", Entidades.GrupoTipoAtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}'", Entidades.GrupoTipoAtributoProducto.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.GrupoTipoAtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString(), idGrupoTipoAtributoProducto).AppendLine()
         .AppendFormat("   AND {0} =  {1} ", Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString(), idTipoAtributoProducto).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub GruposTiposAtributosProductos_D(idGrupoTipoAtributoProducto As Integer, idTipoAtributoProducto As Short)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2} AND {3} = {4}",
                                 Entidades.GrupoTipoAtributoProducto.NombreTabla,
                                 Entidades.GrupoTipoAtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString(), idGrupoTipoAtributoProducto,
                                 Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto.ToString(), idTipoAtributoProducto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT GTA.IdGrupoTipoAtributoProducto, GTA.Descripcion, TAP.IdTipoAtributoProducto, TAP.Descripcion AS DescripcionTipo")
         .AppendFormat("       FROM {0} AS GTA", Entidades.GrupoTipoAtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("       INNER JOIN {0} AS TAP", Entidades.TipoAtributoProducto.NombreTabla).AppendLine()
         .AppendFormat("            ON TAP.{0} = GTA.{1}",
                                          Entidades.TipoAtributoProducto.Columnas.IdTipoAtributoProducto,
                                          Entidades.GrupoTipoAtributoProducto.Columnas.IdTipoAtributoProducto).AppendLine()
      End With
   End Sub
   Public Function GruposTiposAtributosProductos_GA() As DataTable
      Return GruposTiposAtributosProductos_G(idGrupoTipoAtributoProducto:=0, idTipoAtributoProducto:=0, descripcion:=String.Empty)
   End Function
   Private Function GruposTiposAtributosProductos_G(idGrupoTipoAtributoProducto As Integer, idTipoAtributoProducto As Short, descripcion As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idGrupoTipoAtributoProducto > 0 Then
            .AppendFormat("   AND GTA.IdGrupoTipoAtributoProducto = {0}", idGrupoTipoAtributoProducto).AppendLine()
         End If
         If idTipoAtributoProducto > 0 Then
            .AppendFormat("   AND TAP.idTipoAtributoProducto = {0}", idTipoAtributoProducto).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            .AppendFormat("   AND GTA.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Function GruposTiposAtributosProductos_G1(idGrupoTipoAtributoProducto As Integer, idTipoAtributoProducto As Short) As DataTable
      Return GruposTiposAtributosProductos_G(idGrupoTipoAtributoProducto:=idGrupoTipoAtributoProducto, idTipoAtributoProducto:=idTipoAtributoProducto, descripcion:=String.Empty)
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "GTA." + columna
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function
   Public Overloads Function GetCodigoMaximo(tipoAtributoProducto As Short) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.GrupoTipoAtributoProducto.Columnas.IdGrupoTipoAtributoProducto.ToString(),
                                             "GruposTiposAtributosProductos",
                                             String.Format("IdTipoAtributoProducto = {0}", tipoAtributoProducto)))
   End Function
   Public Function GetFiltradoPorCodigo(codigoGrupo As Integer, codigoTipo As Short) As DataTable
      Return GruposTiposAtributosProductos_G(idGrupoTipoAtributoProducto:=codigoGrupo, idTipoAtributoProducto:=codigoTipo, descripcion:=String.Empty)
   End Function
   Public Function GetFiltradoPorDescripcion(descripcion As String, codigoTipo As Short) As DataTable
      Return GruposTiposAtributosProductos_G(idGrupoTipoAtributoProducto:=0, idTipoAtributoProducto:=codigoTipo, descripcion:=descripcion)
   End Function

End Class

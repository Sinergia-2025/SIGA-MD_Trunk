Public Class ListasControlItemsLinks
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ListasControlItemLinks_I(idListaControl As Integer,
                                    item As Integer,
                                    ItemLink As Integer,
                                    Descripcion As String,
                                    Link As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendFormat("INSERT INTO CalidadListasControlConfigLinks ({0}, {1}, {2},{3},{4})",
                       Entidades.ListaControlItemLinks.Columnas.IdListaControl.ToString(),
                       Entidades.ListaControlItemLinks.Columnas.Item.ToString(),
                       Entidades.ListaControlItemLinks.Columnas.ItemLink.ToString(),
                       Entidades.ListaControlItemLinks.Columnas.Descripcion.ToString(),
                       Entidades.ListaControlItemLinks.Columnas.Link.ToString()).AppendLine()
         .AppendFormat("     VALUES ({0}, {1}, {2}, '{3}','{4}')",
                       idListaControl, item, ItemLink, Descripcion, Link)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlItemLinks_U(idListaControl As Integer,
                                    item As Integer,
                                    ItemLink As Integer,
                                    Descripcion As String,
                                    Link As String)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("UPDATE CalidadListasControlConfigLinks ")
         .AppendFormat("   SET {0} = {1}", Entidades.ListaControlItemLinks.Columnas.Descripcion.ToString(), Descripcion).AppendLine()
         .AppendFormat("      ,{0} = {1}", Entidades.ListaControlItemLinks.Columnas.Link.ToString(), Link).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlItemLinks.Columnas.IdListaControl.ToString(), idListaControl)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlItemLinks.Columnas.Item.ToString(), item)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlItemLinks.Columnas.ItemLink.ToString(), ItemLink)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub ListasControlItemLinks_D(idListaControl As Integer, item As Integer,
                                    ItemLink As Integer)

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         .AppendLine("DELETE FROM CalidadListasControlConfigLinks ")
         .AppendFormat(" WHERE {0} = '{1}'", Entidades.ListaControlItemLinks.Columnas.IdListaControl.ToString(), idListaControl)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlItemLinks.Columnas.Item.ToString(), item)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlItemLinks.Columnas.ItemLink.ToString(), ItemLink)

      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT IL.*, LCI.NombreListaControlItem FROM CalidadListasControlConfigLinks AS IL").AppendLine()
         .AppendFormat("  LEFT JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = IL.Item")
      End With
   End Sub

   Public Function ListasControlItemLinks_GA(IdListaControl As Integer, item As Integer) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)

         .AppendFormat(" WHERE {0} = {1}", Entidades.ListaControlItemLinks.Columnas.IdListaControl.ToString(), IdListaControl)
         .AppendFormat(" AND {0} = {1}", Entidades.ListaControlItemLinks.Columnas.Item.ToString(), item)

         .AppendFormat(" ORDER BY IL.ItemLink")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function ListasControlItemLinks_G1(idListaControl As Integer, item As Integer, itemLink As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IL.{0} = {1}", Entidades.ListaControlItemLinks.Columnas.IdListaControl.ToString(), idListaControl)
         .AppendFormat("   AND IL.{0} = {1}", Entidades.ListaControlItemLinks.Columnas.Item.ToString(), item)
         .AppendFormat("   AND IL.{0} = {1}", Entidades.ListaControlItemLinks.Columnas.ItemLink.ToString(), itemLink)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable

      If columna = "NombreModulo" Then
         columna = "AM." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(ByVal IdListaControl As Integer, ByVal Item As Integer) As Integer
      Return Convert.ToInt32(GetCodigoMaximo("ItemLink", "CalidadListasControlConfigLinks", " IdListaControl = " & IdListaControl & " AND Item = " & Item))
   End Function

End Class
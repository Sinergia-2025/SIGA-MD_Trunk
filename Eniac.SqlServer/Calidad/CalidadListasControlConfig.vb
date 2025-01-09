Public Class CalidadListasControlConfig
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CalidadListasControlConfig_I(idListaControl As Integer, idListaControlItem As Integer, orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadListaControlConfig.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadListaControlConfig.Columnas.IdListaControl.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlConfig.Columnas.IdListaControlItem.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlConfig.Columnas.Orden.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idListaControl)
         .AppendFormatLine("	 ,  {0} ", idListaControlItem)
         .AppendFormatLine("	 ,  {0} ", orden)
         .AppendFormatLine(")")
      End With

      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControlConfig_U(idListaControl As Integer, idListaControlItem As Integer, orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadListaControlConfig.NombreTabla)
         .AppendFormatLine("   SET {0} = {1}", Entidades.CalidadListaControlConfig.Columnas.Orden.ToString(), orden)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.CalidadListaControlConfig.Columnas.IdListaControl.ToString(), idListaControl)
         .AppendFormatLine("   AND {0} = {1}", Entidades.CalidadListaControlConfig.Columnas.IdListaControlItem.ToString(), idListaControlItem)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CalidadListasControlConfig_D(idListaControl As Integer, idListaControlItem As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CalidadListaControlConfig.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.CalidadListaControlConfig.Columnas.IdListaControl.ToString(), idListaControl)
         If idListaControlItem <> 0 Then
            .AppendFormatLine("   AND {0} = {1}", Entidades.CalidadListaControlConfig.Columnas.IdListaControlItem.ToString(), idListaControlItem)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT LCC.*, LCI.NombreListaControlItem")
         .AppendFormatLine("  FROM CalidadListasControlConfig AS LCC")
         .AppendFormatLine("  INNER JOIN CalidadListasControlItems AS LCI ON LCI.IdListaControlItem = LCC.IdListaControlItem")
      End With
   End Sub

   Public Function CalidadListasControlConfig_GA() As DataTable
      Return CalidadListasControlConfig_G(idListaControl:=0, idListaControlItem:=0)
   End Function
   Public Function CalidadListasControlConfig_GA(idListaControl As Integer) As DataTable
      Return CalidadListasControlConfig_G(idListaControl, idListaControlItem:=0)
   End Function
   Public Function CalidadListasControlConfig_G1(idListaControl As Integer, idListaControlItem As Integer) As DataTable
      Return CalidadListasControlConfig_G(idListaControl, idListaControlItem)
   End Function
   Public Function CalidadListasControlConfig_G(idListaControl As Integer, idListaControlItem As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idListaControl <> 0 Then
            .AppendFormatLine("   AND LCC.{0} = '{1}'", Entidades.CalidadListaControlConfig.Columnas.IdListaControl.ToString(), idListaControl)
         End If
         If idListaControlItem <> 0 Then
            .AppendFormatLine("   AND LCC.{0} = '{1}'", Entidades.CalidadListaControlConfig.Columnas.IdListaControlItem.ToString(), idListaControlItem)
         End If

         .AppendFormat(" ORDER BY LCC.Orden")
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb1) SelectTexto(stb1), "LCC.")
   End Function

   Public Function GetOrdenMaximo(idListaControl As Integer) As Integer
      Return GetCodigoMaximo(Entidades.CalidadListaControlConfig.Columnas.Orden.ToString(), Entidades.CalidadListaControlConfig.NombreTabla,
                             String.Format("LCC.{0} = {1}", Entidades.CalidadListaControlConfig.Columnas.IdListaControl.ToString(), idListaControl)).ToInteger()
   End Function

End Class
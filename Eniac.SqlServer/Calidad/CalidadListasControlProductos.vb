
Public Class CalidadListasControlProductos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

#Region "Metodos Publicos"
   Public Sub CalidadListasControlProductos_I(IdProducto As String,
                                              IdListaControl As Integer,
                                              fecha As DateTime,
                                              IdUsuario As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CalidadListaControlProducto.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CalidadListaControlProducto.Columnas.IdProducto.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlProducto.Columnas.IdListaControl.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlProducto.Columnas.FechaActualizacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.CalidadListaControlProducto.Columnas.IdUsuario.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	   '{0}'", IdProducto)
         .AppendFormatLine("	 ,  {0} ", IdListaControl)
         .AppendFormatLine("	 , '{0}'", ObtenerFecha(fecha, True))
         .AppendFormatLine("	 , '{0}'", IdUsuario)
         .AppendFormatLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CalidadListasControlProductos_U(IdProducto As String,
                                              IdListaControl As Integer,
                                              fecha As DateTime,
                                              IdUsuario As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CalidadListaControlProducto.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CalidadListaControlProducto.Columnas.IdUsuario.ToString(), IdUsuario)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CalidadListaControlProducto.Columnas.FechaActualizacion.ToString(), ObtenerFecha(fecha, True))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CalidadListaControlProducto.Columnas.IdListaControl.ToString(), IdListaControl)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CalidadListaControlProducto.Columnas.IdProducto.ToString(), IdProducto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CalidadListasControlProductos_D(idProducto As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CalidadListaControlProducto.NombreTabla)
         .AppendFormatLine(" WHERE {0} = '{1}'", Entidades.CalidadListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Sub CalidadListasControlProductos_D(idProducto As String, idListaControl As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CalidadListaControlProducto.NombreTabla)
         .AppendFormatLine("  WHERE {0} = '{1}'", Entidades.CalidadListaControlProducto.Columnas.IdProducto.ToString(), idProducto)
         .AppendFormatLine("    AND {0} =  {1} ", Entidades.CalidadListaControlProducto.Columnas.IdListaControl.ToString(), idListaControl)

      End With
      Me.Execute(myQuery.ToString())
   End Sub
   Public Function CalidadListasControlProductos_GA() As DataTable
      Return CalidadEstadosOrdenesCalidad_G(idProducto:=Nothing, idListaControl:=0)
   End Function
   Public Function CalidadListasControlProductos_G1(idProducto As String, idListaControl As Integer) As DataTable
      Return CalidadEstadosOrdenesCalidad_G(idProducto:=idProducto, idListaControl:=idListaControl)
   End Function

   Public Function CalidadOrdenListaControlProductos_G(idProducto As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendLine("SELECT CLCP.IdProducto, CLCP.IdListaControl, CLC.NombreListaControl,CLCI.IdListaControlItem, CLCI.NombreListaControlItem,")
         .AppendLine("	   CLCI.NivelInspeccion, CLCI.ValorAQL")
         .AppendLine("	FROM CalidadListasControlProductos  CLCP")
         .AppendLine("  INNER JOIN CalidadListasControl CLC ON CLC.IdListaControl = CLCP.IdListaControl")
         .AppendLine("  INNER JOIN CalidadListasControlConfig CLCG ON CLCG.IdListaControl = CLCP.IdListaControl")
         .AppendLine("  INNER JOIN CalidadListasControlItems CLCI ON CLCI.IdListaControlItem = CLCG.IdListaControlItem")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   WHERE CLCP.IdProducto = '{0}'", idProducto)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CLCP.*")
         .AppendFormatLine("	   , CLC.NombreListaControl")
         .AppendFormatLine("  FROM {0} AS CLCP", Entidades.CalidadListaControlProducto.NombreTabla)
         .AppendFormatLine(" INNER JOIN {0} AS CLC  ON CLC.IdListaControl = CLCP.IdListaControl ", Entidades.CalidadListaControl.NombreTabla)
      End With
   End Sub
   Private Function CalidadEstadosOrdenesCalidad_G(idProducto As String, idListaControl As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If Not String.IsNullOrWhiteSpace(idProducto) Then
            .AppendFormatLine("   AND CLCP.IdProducto = '{0}'", idProducto)
         End If
         If idListaControl > 0 Then
            .AppendFormatLine("   AND CLCP.IdListaControl = {0} ", idListaControl)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
#End Region
End Class

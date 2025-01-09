Imports Eniac.Entidades

Public Class MRPNormasFabricacion
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub NormasFabricacion_I(idNormaFab As Integer,
                                   codigoNormaFab As String,
                                   descripcion As String,
                                   detalleDispositivo As String,
                                   detalleMetodo As String,
                                   detalleSeguridad As String,
                                   detalleControlCalidad As String,
                                   activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})",
                       MRPNormaFabricacion.NombreTabla,
                       MRPNormaFabricacion.Columnas.IdNormaFab.ToString(),
                       MRPNormaFabricacion.Columnas.CodigoNormaFab.ToString(),
                       MRPNormaFabricacion.Columnas.Descripcion.ToString(),
                       MRPNormaFabricacion.Columnas.DetalleDispositivos.ToString(),
                       MRPNormaFabricacion.Columnas.DetalleMetodos.ToString(),
                       MRPNormaFabricacion.Columnas.DetalleSeguridad.ToString(),
                       MRPNormaFabricacion.Columnas.DetalleControlCalidad.ToString(),
                       MRPNormaFabricacion.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', {7}",
                       idNormaFab,
                       codigoNormaFab,
                       descripcion,
                       detalleDispositivo,
                       detalleMetodo,
                       detalleSeguridad,
                       detalleControlCalidad,
                       GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub NormasFabricacion_U(idNormaFab As Integer,
                                   codigoNormaFab As String,
                                   descripcion As String,
                                   detalleDispositivo As String,
                                   detalleMetodo As String,
                                   detalleSeguridad As String,
                                   detalleControlCalidad As String,
                                   activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.MRPNormaFabricacion.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", Entidades.MRPNormaFabricacion.Columnas.CodigoNormaFab.ToString(), codigoNormaFab).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPNormaFabricacion.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPNormaFabricacion.Columnas.DetalleDispositivos.ToString(), detalleDispositivo).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPNormaFabricacion.Columnas.DetalleMetodos.ToString(), detalleMetodo).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPNormaFabricacion.Columnas.DetalleSeguridad.ToString(), detalleSeguridad).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPNormaFabricacion.Columnas.DetalleControlCalidad.ToString(), detalleControlCalidad).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", Entidades.MRPNormaFabricacion.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", Entidades.MRPNormaFabricacion.Columnas.IdNormaFab.ToString(), idNormaFab).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub NormasFabricacion_D(idNormaFab As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.MRPNormaFabricacion.NombreTabla, Entidades.MRPNormaFabricacion.Columnas.IdNormaFab.ToString(), idNormaFab)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormat("SELECT NF.* FROM {0} AS NF", Entidades.MRPNormaFabricacion.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function NormasFabricacion_G(idNormaFab As Integer, codigoNormaFab As String, descripcion As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idNormaFab > 0 Then
            .AppendFormat("   AND NF.IdNormaFab = {0}", idNormaFab).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(codigoNormaFab) Then
            .AppendFormat("   AND NF.CodigoNormaFab LIKE '%{0}%'", codigoNormaFab).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            If nombreExacto Then
               .AppendFormat("   AND NF.Descripcion = '{0}'", descripcion).AppendLine()
            Else
               .AppendFormat("   AND NF.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
            End If
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function


   Public Function NormasFabricacion_G1(idNormaFab As Integer) As DataTable
      Return NormasFabricacion_G(idNormaFab:=idNormaFab, codigoNormaFab:=String.Empty, descripcion:=String.Empty, nombreExacto:=False)
   End Function

   Public Function NormasFabricacion_GA() As DataTable
      Return NormasFabricacion_G(idNormaFab:=0, codigoNormaFab:=String.Empty, descripcion:=String.Empty, nombreExacto:=False)
   End Function

   Public Function NormasFabricacion_Nombre(descripcion As String) As DataTable
      Return NormasFabricacion_G(idNormaFab:=0, codigoNormaFab:=String.Empty, descripcion:=descripcion, nombreExacto:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "NF.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MRPNormaFabricacion.Columnas.IdNormaFab.ToString(), "MRPNormasFabricacion"))
   End Function

   Public Function Existe(codigoNormaFab As String) As Boolean
      Dim stb = New StringBuilder("")
      With stb
         .AppendFormat("SELECT * FROM {0} AS NF", MRPNormaFabricacion.NombreTabla)
         .AppendFormat("   WHERE NF.{0} = '{1}'", MRPNormaFabricacion.Columnas.CodigoNormaFab.ToString(), codigoNormaFab)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function

End Class

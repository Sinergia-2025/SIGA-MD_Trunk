Imports Eniac.Entidades
Imports Eniac.Entidades.JSonEntidades

Public Class MRPTareas
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Tareas_I(idTarea As Integer,
                       codigoTarea As String,
                       descripcion As String,
                       idCentroProductor As Integer,
                       activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5})",
                       MRPTarea.NombreTabla,
                       MRPTarea.Columnas.IdTarea.ToString(),
                       MRPTarea.Columnas.CodigoTarea.ToString(),
                       MRPTarea.Columnas.Descripcion.ToString(),
                       MRPTarea.Columnas.IdCentroProductor.ToString(),
                       MRPTarea.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}', '{2}', {3}, {4}", idTarea, codigoTarea.ToUpper(), descripcion, IIf(idCentroProductor > 0, idCentroProductor, "NULL"), GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Tareas_U(idTarea As Integer,
                       codigoTarea As String,
                       descripcion As String,
                       idCentroProductor As Integer,
                       activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", MRPTarea.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", MRPTarea.Columnas.CodigoTarea.ToString(), codigoTarea.ToUpper()).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", MRPTarea.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         .AppendFormat("      ,{0} =  {1} ", MRPTarea.Columnas.IdCentroProductor.ToString(), IIf(idCentroProductor > 0, idCentroProductor, "NULL")).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", MRPTarea.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", MRPTarea.Columnas.IdTarea.ToString(), idTarea).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Tareas_D(idTarea As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.MRPTarea.NombreTabla, Entidades.MRPTarea.Columnas.IdTarea.ToString(), idTarea)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT TP.*, CP.Descripcion AS NombreCentroProductor FROM {0} AS TP", Entidades.MRPTarea.NombreTabla)
         .AppendFormat("   LEFT JOIN {0} AS CP ON CP.IdCentroProductor = TP.IdCentroProductor ", Entidades.MRPCentroProductor.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function Tareas_G(idTarea As Integer, codigoTarea As String, descripcion As String, valorExacto As Boolean, activas As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idTarea > 0 Then
            .AppendFormat("   AND TP.IdTarea = {0}", idTarea).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(codigoTarea) Then
            If valorExacto Then
               .AppendFormat("   AND TP.CodigoTarea = '{0}'", codigoTarea).AppendLine()
            Else
               .AppendFormat("   AND TP.CodigoTarea LIKE '%{0}%'", codigoTarea).AppendLine()
            End If
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            If valorExacto Then
               .AppendFormat("   AND TP.Descripcion = '{0}'", descripcion).AppendLine()
            Else
               .AppendFormat("   AND TP.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
            End If
         End If
         Select Case activas
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormat(" AND TP.Activo = {0}", GetStringFromBoolean(True))
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormat(" AND TP.Activo = {0}", GetStringFromBoolean(False))
         End Select
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Tareas_G1(idTarea As Integer) As DataTable
      Return Tareas_G(idTarea:=idTarea, codigoTarea:=String.Empty, descripcion:=String.Empty, valorExacto:=False, activas:=Publicos.SiNoTodos.TODOS)
   End Function
   Public Function Tareas_G1_Codigo(codigoTarea As String, codigoExacto As Boolean) As DataTable
      Return Tareas_G(idTarea:=0, codigoTarea:=codigoTarea, descripcion:=String.Empty, valorExacto:=codigoExacto, activas:=Publicos.SiNoTodos.TODOS)
   End Function

   Public Function Tareas_GA_Nombre(nombreTarea As String, nombreExacto As Boolean, activas As Entidades.Publicos.SiNoTodos) As DataTable

      Return Tareas_G(idTarea:=0, codigoTarea:=String.Empty, descripcion:=nombreTarea, valorExacto:=nombreExacto, activas)
   End Function

   Public Function Tareas_GA() As DataTable
      Return Tareas_G(idTarea:=0, codigoTarea:=String.Empty, descripcion:=String.Empty, valorExacto:=False, activas:=Publicos.SiNoTodos.TODOS)
   End Function


   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "TP.",
                    New Dictionary(Of String, String) From {{"NombreCentroProductor", "CP.Descripcion"}})
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MRPTarea.Columnas.IdTarea.ToString(), "MRPTareas"))
   End Function

   Public Function Existe(codigoTareas As String) As Boolean
      Dim stb = New StringBuilder("")
      With stb
         .AppendFormat("SELECT * FROM {0} AS TP", MRPTarea.NombreTabla)
         .AppendFormat("   WHERE  TP.{0} = '{1}'", MRPTarea.Columnas.CodigoTarea.ToString(), codigoTareas)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function
End Class

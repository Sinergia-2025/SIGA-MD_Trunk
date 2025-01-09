Imports Eniac.Entidades

Public Class MRPSecciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Secciones_I(idSeccion As Integer,
                          codigoSeccion As String,
                          descripcion As String,
                          claseSeccion As String,
                          activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5})",
                       Entidades.MRPSeccion.NombreTabla,
                       Entidades.MRPSeccion.Columnas.IdSeccion.ToString(),
                       Entidades.MRPSeccion.Columnas.CodigoSeccion.ToString(),
                       Entidades.MRPSeccion.Columnas.Descripcion.ToString(),
                       Entidades.MRPSeccion.Columnas.ClaseSeccion.ToString(),
                       Entidades.MRPSeccion.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}', '{2}', '{3}', {4}", idSeccion, codigoSeccion.ToUpper(), descripcion.ToUpper(), claseSeccion, GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Secciones_U(idSeccion As Integer,
                          codigoSeccion As String,
                          descripcion As String,
                          claseSeccion As String,
                          activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.MRPSeccion.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", Entidades.MRPSeccion.Columnas.CodigoSeccion.ToString(), codigoSeccion.ToUpper()).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPSeccion.Columnas.Descripcion.ToString(), descripcion.ToUpper()).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPSeccion.Columnas.ClaseSeccion.ToString(), claseSeccion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", Entidades.MRPSeccion.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", Entidades.MRPSeccion.Columnas.IdSeccion.ToString(), idSeccion).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Secciones_D(idSeccion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.MRPSeccion.NombreTabla, Entidades.MRPSeccion.Columnas.IdSeccion.ToString(), idSeccion)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT SC.* FROM {0} AS SC ", Entidades.MRPSeccion.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function Secciones_G(idSeccion As Integer, codigoSeccion As String, descripcion As String, nombreExacto As Boolean) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSeccion > 0 Then
            .AppendFormat("   AND SC.IdSeccion = {0}", idSeccion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(codigoSeccion) Then
            .AppendFormat("   AND SC.CodigoSeccion LIKE '%{0}%'", codigoSeccion).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            If nombreExacto Then
               .AppendFormat("   AND SC.Descripcion = '{0}'", descripcion).AppendLine()
            Else
               .AppendFormat("   AND SC.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
            End If
         End If
         .AppendLine(" ORDER BY SC.CodigoSeccion")

      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Secciones_G1(idSeccion As Integer) As DataTable
      Return Secciones_G(idSeccion:=idSeccion, codigoSeccion:=String.Empty, descripcion:=String.Empty, nombreExacto:=False)
   End Function

   Public Function Secciones_GA() As DataTable
      Return Secciones_G(idSeccion:=0, codigoSeccion:=String.Empty, descripcion:=String.Empty, nombreExacto:=False)
   End Function
   Public Function Secciones_GA(activas As Entidades.Publicos.SiNoTodos) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         Me.SelectTexto(myQuery)
         Select Case activas
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormat(" WHERE SC.Activo = {0}", GetStringFromBoolean(True))
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormat(" WHERE SC.Activo = {0}", GetStringFromBoolean(False))
         End Select
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function
   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "SC.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MRPSeccion.Columnas.IdSeccion.ToString(), "MRPSecciones"))
   End Function

   Public Function Existe(codigoSecciones As String) As Boolean
      Dim stb = New StringBuilder("")
      With stb
         .AppendFormat("SELECT * FROM {0} AS SC", MRPSeccion.NombreTabla)
         .AppendFormat("   WHERE  SC.{0} = '{1}'", MRPSeccion.Columnas.CodigoSeccion.ToString(), codigoSecciones)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function
End Class

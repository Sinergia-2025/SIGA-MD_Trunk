Imports Eniac.Entidades
Imports Eniac.Entidades.JSonEntidades

Public Class MRPCategoriasEmpleados
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CategoriasEmpleados_I(idCategoria As Integer,
                                    codigoCategoria As String,
                                    descripcion As String,
                                    valorHoraProduccion As Decimal,
                                    activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5})",
                       Entidades.MRPCategoriaEmpleado.NombreTabla,
                       Entidades.MRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(),
                       Entidades.MRPCategoriaEmpleado.Columnas.CodigoCategoriaEmpleado.ToString(),
                       Entidades.MRPCategoriaEmpleado.Columnas.Descripcion.ToString(),
                       Entidades.MRPCategoriaEmpleado.Columnas.ValorHoraProduccion.ToString(),
                       Entidades.MRPCategoriaEmpleado.Columnas.Activo.ToString()).AppendLine()
         .AppendFormat("  VALUES ({0}, '{1}', '{2}', {3}, {4}", idCategoria, codigoCategoria, descripcion, valorHoraProduccion, GetStringFromBoolean(activo))
         .AppendLine(")")
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasEmpleados_U(idCategoria As Integer,
                                    codigoCategoria As String,
                                    descripcion As String,
                                    valorHoraProduccion As Decimal,
                                    activo As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("UPDATE {0}", Entidades.MRPCategoriaEmpleado.NombreTabla).AppendLine()
         .AppendFormat("   SET {0} = '{1}' ", Entidades.MRPCategoriaEmpleado.Columnas.CodigoCategoriaEmpleado.ToString(), codigoCategoria).AppendLine()
         .AppendFormat("      ,{0} = '{1}' ", Entidades.MRPCategoriaEmpleado.Columnas.Descripcion.ToString(), descripcion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", Entidades.MRPCategoriaEmpleado.Columnas.ValorHoraProduccion.ToString(), valorHoraProduccion).AppendLine()
         .AppendFormat("      ,{0} =  {1}  ", Entidades.MRPCategoriaEmpleado.Columnas.Activo.ToString(), GetStringFromBoolean(activo)).AppendLine()
         .AppendFormat(" WHERE {0} =  {1}  ", Entidades.MRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoria).AppendLine()
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub CategoriasEmpleados_D(idCategoria As Integer)
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.MRPCategoriaEmpleado.NombreTabla, Entidades.MRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), idCategoria)
      End With
      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendFormat("SELECT CE.* FROM {0} AS CE", Entidades.MRPCategoriaEmpleado.NombreTabla).AppendLine()
      End With
   End Sub

   Private Function CategoriasEmpleados_G(idCategoria As Integer, codigoCategoria As String, descripcion As String, valorExacto As Boolean, activos As Entidades.Publicos.SiNoTodos) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         Me.SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idCategoria > 0 Then
            .AppendFormat("   AND CE.IdCategoriaEmpleado = {0}", idCategoria).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(codigoCategoria) Then
            If valorExacto Then
               .AppendFormat("   AND CE.CodigoCategoriaEmpleado = '{0}'", codigoCategoria).AppendLine()
            Else
               .AppendFormat("   AND CE.CodigoCategoriaEmpleado LIKE '%{0}%'", codigoCategoria).AppendLine()
            End If
         End If
         If Not String.IsNullOrWhiteSpace(descripcion) Then
            If valorExacto Then
               .AppendFormat("   AND CE.Descripcion = '{0}'", descripcion).AppendLine()
            Else
               .AppendFormat("   AND CE.Descripcion LIKE '%{0}%'", descripcion).AppendLine()
            End If
         End If
      End With
      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function CategoriasEmpleados_G1(idCategoria As Integer) As DataTable
      Return CategoriasEmpleados_G(idCategoria:=idCategoria, codigoCategoria:=String.Empty, descripcion:=String.Empty, valorExacto:=False, activos:=Publicos.SiNoTodos.TODOS)
   End Function
   Public Function CategoriasEmpleados_G1_Codigo(codigoCategoriaEmp As String, codigoExacto As Boolean) As DataTable
      Return CategoriasEmpleados_G(idCategoria:=0, codigoCategoria:=codigoCategoriaEmp, descripcion:=String.Empty, valorExacto:=codigoExacto, activos:=Publicos.SiNoTodos.TODOS)
   End Function
   Public Function CategoriaEmpleados_G1_Nombre(nombreCategoriaEmp As String, codigoExacto As Boolean, activos As Publicos.SiNoTodos) As DataTable
      Return CategoriasEmpleados_G(idCategoria:=0, codigoCategoria:=String.Empty, descripcion:=nombreCategoriaEmp, valorExacto:=codigoExacto, activos)
   End Function

   Public Function CategoriasEmpleados_GA() As DataTable
      Return CategoriasEmpleados_G(idCategoria:=0, codigoCategoria:=String.Empty, descripcion:=String.Empty, valorExacto:=False, activos:=Publicos.SiNoTodos.TODOS)
   End Function

   Public Function CategoriasEmpleados_GA(activas As Entidades.Publicos.SiNoTodos) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder()

      With myQuery
         Me.SelectTexto(myQuery)
         Select Case activas
            Case Entidades.Publicos.SiNoTodos.SI
               .AppendFormat(" WHERE CE.Activo = {0}", GetStringFromBoolean(True))
            Case Entidades.Publicos.SiNoTodos.NO
               .AppendFormat(" WHERE CE.Activo = {0}", GetStringFromBoolean(False))
         End Select
         .AppendLine(" ORDER BY CE.Descripcion")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "CE." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MRPCategoriaEmpleado.Columnas.IdCategoriaEmpleado.ToString(), MRPCategoriaEmpleado.NombreTabla))
   End Function

   Public Function Existe(codigoCategoria As String) As Boolean
      Dim stb = New StringBuilder("")
      With stb
         .AppendFormat("SELECT TOP 1 * FROM {0} AS CE", MRPCategoriaEmpleado.NombreTabla)
         If Not String.IsNullOrWhiteSpace(codigoCategoria) Then
            .AppendFormat("   WHERE  CE.{0} = '{1}'", MRPCategoriaEmpleado.Columnas.CodigoCategoriaEmpleado.ToString(), codigoCategoria)
         End If
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      Return dt.Rows.Count > 0
   End Function
End Class

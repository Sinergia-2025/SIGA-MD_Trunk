Public Class ProductosConceptos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ProductosConceptos_I(ByVal idProducto As String, _
                                     ByVal idConcepto As Integer)
      'ByVal descuentaAlFacturar As Boolean)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO ProductosConceptos")
         .AppendLine("   (IdProducto")
         .AppendLine("   ,IdConcepto")
         .AppendLine("   ) ")
         .AppendLine("   VALUES(")
         .AppendLine("   '" & idProducto & "'")
         .AppendLine("   ," & idConcepto)
         .AppendLine("   )")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosConceptos")

   End Sub

   Public Sub ProductosConceptos_D(ByVal idProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM ProductosConceptos ")
         .Append(" WHERE IdProducto = '" & idProducto & "'")

      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "ProductosConceptos")

   End Sub

   Public Function GetConceptos(ByVal IdProducto As String) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT PC.IdProducto")
         .AppendLine("      ,PC.IdConcepto")
         .AppendLine("      ,C.NombreConcepto")
         .AppendLine(" FROM ProductosConceptos PC ")
         .AppendLine(" INNER JOIN Conceptos C ON C.IdConcepto = PC.IdConcepto")
         .AppendLine("   AND PC.IdProducto = '" & IdProducto & "'")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function


   Public Function GetPorProductoComponente(ByVal IdSucursal As Integer, ByVal IdProducto As String, ByVal idListaDePrecios As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT PC.IdProducto")
         .AppendLine("      ,PC.IdProductoComponente")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,P.IdUnidadDeMedida")
         .AppendLine("      ,PC.Cantidad")
         .AppendLine("      ,P.IdMoneda")
         .AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,PSP.PrecioVenta")
         .AppendLine(" FROM ProductosConceptos PC ")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = PC.IdProductoComponente")
         .AppendLine(" LEFT JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         .AppendLine(" LEFT JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal AND PSP.IdListaPrecios = " & idListaDePrecios.ToString())
         '.AppendLine(" WHERE P.Activo = 1 ")
         '.AppendLine(" AND P.EsServicio <> 1 ")
         '.AppendLine(" AND P.AfectaStock = 1 ")
         .AppendLine(" WHERE PS.IdSucursal = " & IdSucursal)
         .AppendLine("   AND PC.IdProductoComponente = '" & IdProducto & "'")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetInforme(ByVal IdSucursal As Integer, ByVal IdProducto As String, ByVal idFormula As Integer, ByVal idListaDePrecios As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT PC.IdProducto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine("      ,PC.IdFormula")
         .AppendLine("      ,PF.NombreFormula")
         .AppendLine("      ,PC.IdProductoComponente")
         .AppendLine("      ,P2.NombreProducto AS NombreComponente")
         '.AppendLine("      ,P.IdUnidadDeMedida")
         '.AppendLine("      ,PS.PrecioCosto")
         .AppendLine("      ,PC.Cantidad")
         '.AppendLine("      ,P.IdMoneda")
         '.AppendLine("      ,PSP.PrecioVenta")
         .AppendLine(" FROM ProductosConceptos PC ")
         .AppendLine(" INNER JOIN ProductosFormulas PF ON PF.IdProducto = PC.IdProducto AND PF.IdFormula = PC.IdFormula")
         .AppendLine(" INNER JOIN Productos P ON P.IdProducto = PC.IdProducto")
         .AppendLine(" INNER JOIN Productos P2 ON P2.IdProducto = PC.IdProductoComponente")
         '.AppendLine(" INNER JOIN ProductosSucursales PS ON PS.IdProducto = P.IdProducto")
         '.AppendLine(" INNER JOIN ProductosSucursalesPrecios PSP ON PSP.IdProducto = PS.IdProducto AND PSP.IdSucursal = PS.IdSucursal AND PSP.IdListaPrecios = " & idListaDePrecios.ToString())
         '.AppendLine(" WHERE PS.IdSucursal = " & IdSucursal.ToString())
         If Not String.IsNullOrEmpty(IdProducto) Then
            .AppendLine("   AND PC.IdProducto = '" & IdProducto & "'")
         End If
         If idFormula > 0 Then
            .AppendLine("   AND PC.IdFormula = " & idFormula.ToString())
         End If
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

End Class

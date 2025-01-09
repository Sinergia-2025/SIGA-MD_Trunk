Public Class Conceptos
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Conceptos_I(idConcepto As Integer,
                          nombreConcepto As String,
                          idRubroConcepto As Integer,
                          grupoGastos As String,
                          esNoGravado As Boolean,
                          activo As Boolean,
                          imprimeProveedor As Boolean,
                          imprimeDetalleComprobante As Boolean,
                          idProducto As String)

      Dim myQuery As StringBuilder = New StringBuilder()
      With myQuery
         .AppendLine("INSERT INTO Conceptos (")
         .AppendLine("  IdConcepto, ")
         .AppendLine("  NombreConcepto, ")
         .AppendLine("  IdRubroConcepto, ")
         .AppendLine("  grupoGastos, ")
         .AppendLine("  EsNoGravado, ")
         .AppendLine("  Activo, ")
         .AppendLine("  ImprimeProveedor ")
         .AppendLine(" ,ImprimeDetalleComprobante")
         .AppendLine(" ,IdProducto")
         .AppendLine(") VALUES (")
         .AppendLine(idConcepto.ToString() & ", ")
         .AppendLine("'" & nombreConcepto & "', ")
         .AppendLine(idRubroConcepto.ToString() & ", ")
         .AppendLine("'" & grupoGastos & "', ")
         .AppendLine("'" & esNoGravado.ToString() & "', ")
         .AppendLine("'" & activo.ToString() & "', ")
         .AppendLine("'" & imprimeProveedor.ToString() & "' ")
         .AppendFormatLine(", {0}", GetStringFromBoolean(imprimeDetalleComprobante))
         .AppendFormatLine(", {0}", GetStringParaQueryConComillas(idProducto))
         .AppendLine(") ")
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Conceptos")

   End Sub

   Public Sub Conceptos_U(idConcepto As Integer,
                          nombreConcepto As String,
                          idRubroConcepto As Integer,
                          grupoGastos As String,
                          esNoGravado As Boolean,
                          activo As Boolean,
                          imprimeProveedor As Boolean,
                          imprimeDetalleComprobante As Boolean,
                          idProducto As String)


      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Conceptos SET ")
         .AppendLine("NombreConcepto = '" & nombreConcepto & "', ")
         .AppendLine("IdRubroConcepto = " & idRubroConcepto.ToString() & ", ")
         .AppendLine("grupoGastos = '" & grupoGastos & "', ")
         .AppendLine("EsNoGravado = '" & esNoGravado.ToString() & "', ")
         .AppendLine("Activo = '" & activo.ToString() & "', ")
         .AppendLine("ImprimeProveedor = '" & imprimeProveedor.ToString() & "' ")
         .AppendFormatLine("  ,ImprimeDetalleComprobante = {0}", GetStringFromBoolean(imprimeDetalleComprobante))
         .AppendFormatLine("  ,IdProducto = {0}", GetStringParaQueryConComillas(idProducto))
         .AppendLine(" WHERE IdConcepto = " & idConcepto.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Conceptos")

   End Sub

   Public Sub Conceptos_D(ByVal idConcepto As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM Conceptos ")
         .Append(" WHERE IdConcepto = " & idConcepto.ToString())
      End With

      Me.Execute(myQuery.ToString())
      Me.Sincroniza_I(myQuery.ToString(), "Conceptos")

   End Sub


   Private Sub SelectFiltrado(ByRef stb As StringBuilder)
      With stb
         .AppendLine("SELECT C.*")
         .AppendLine("      ,R.NombreRubroConcepto")
         .AppendLine("      ,P.NombreProducto")
         .AppendLine(" FROM Conceptos C")
         .AppendLine(" LEFT JOIN RubrosConceptos R ON C.IdRubroConcepto = R.IdRubroConcepto")
         .AppendLine(" LEFT JOIN Productos P ON P.IdProducto = C.IdProducto")
      End With
   End Sub

   Public Function Conceptos_GA() As DataTable
      Return Conceptos_GA(0, String.Empty, Nothing)
   End Function
   Public Function Conceptos_GA(idConcepto As Integer, nombre As String, activos As Boolean?) As DataTable
      Dim myQuery As StringBuilder = New StringBuilder("")
      With myQuery
         SelectFiltrado(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idConcepto > 0 Then
            .AppendFormat("   AND C.IdConcepto = {0}", idConcepto).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(nombre) Then
            .AppendFormat("   AND C.NombreConcepto LIKE '%{0}%'", nombre).AppendLine()
         End If
         If activos.HasValue Then
            .AppendFormat("   AND C.Activo = {0}", GetStringFromBoolean(activos.Value)).AppendLine()
         End If
         .AppendLine(" ORDER BY C.NombreConcepto  ")
      End With

      Return Me.GetDataTable(myQuery.ToString())
   End Function

   Public Function Conceptos_G1(idConcepto As Integer) As DataTable
      Return Conceptos_GA(idConcepto, String.Empty, Nothing)
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      Select Case columna
         Case "NombreRubroConcepto"
            columna = "R." + columna
         Case "NombreProducto"
            columna = "P." + columna
         Case Else
            columna = "C." + columna
      End Select

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectFiltrado(stb)
         .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
         .AppendLine(" ORDER BY C.NombreConcepto")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
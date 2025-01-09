Public Class FiltrosValores
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub FiltrosValores_I(ByVal idTipoFiltro As String, _
                               ByVal idNombreFiltro As String, _
                               ByVal idColumna As String, _
                               ByVal idRegistro As Integer, _
                               ByVal valor As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("INSERT INTO FiltrosValores")
         .Append("           (IdTipoFiltro")
         .Append("           ,IdNombreFiltro")
         .Append("           ,IdColumna")
         .Append("           ,IdRegistro")
         .Append("           ,Valor)")
         .Append("     VALUES")
         .AppendFormat("           ('{0}'", idTipoFiltro)
         .AppendFormat("           ,'{0}'", idNombreFiltro)
         .AppendFormat("           ,'{0}'", idColumna)
         .AppendFormat("           ,{0}", idRegistro)
         .AppendFormat("           ,'{0}')", valor)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "FiltrosValores")
   End Sub

   Public Sub FiltrosValores_U(ByVal idTipoFiltro As String, _
                               ByVal idNombreFiltro As String, _
                               ByVal idColumna As String, _
                               ByVal idRegistro As Integer, _
                               ByVal valor As String)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("UPDATE FiltrosValores")
         .AppendFormat("   SET Valor = '{0}'", valor)
         .AppendFormat(" WHERE IdTipoFiltro = '{0}'", idTipoFiltro)
         .AppendFormat("      AND IdNombreFiltro = '{0}'", idNombreFiltro)
         .AppendFormat("      AND IdColumna = '{0}'", idColumna)
         .AppendFormat("      AND IdRegistro = {0}", idRegistro)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "FiltrosValores")
   End Sub

   Public Sub FiltrosValores_D(ByVal idTipoFiltro As String, _
                               ByVal idNombreFiltro As String, _
                               ByVal idColumna As String, _
                               ByVal idRegistro As Integer)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM FiltrosValores")
         .AppendFormat(" WHERE IdTipoFiltro = '{0}'", idTipoFiltro)
         .AppendFormat("      AND IdNombreFiltro = '{0}'", idNombreFiltro)
         .AppendFormat("      AND IdColumna = '{0}'", idColumna)
         .AppendFormat("      AND IdRegistro = {0}", idRegistro)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "FiltrosValores")
   End Sub

   Public Sub BorrarFiltros(ByVal idTipoFiltro As String, _
                            ByVal idNombreFiltro As String)
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("DELETE FROM FiltrosValores")
         .AppendFormat(" WHERE IdTipoFiltro = '{0}'", idTipoFiltro)
         .AppendFormat("      AND IdNombreFiltro = '{0}'", idNombreFiltro)
      End With

      Me.Execute(stb.ToString())
      Me.Sincroniza_I(stb.ToString(), "FiltrosValores")
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Append("SELECT IdTipoFiltro")
         .Append("      ,IdNombreFiltro")
         .Append("      ,IdColumna")
         .Append("      ,IdRegistro")
         .Append("      ,Valor")
         .Append("  FROM FiltrosValores ")
      End With
   End Sub

   Public Function FiltrosValores_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorTipoNombre(ByVal idTipoFiltro As String, ByVal idNombreFiltro As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IdTipoFiltro = '{0}'", idTipoFiltro)
         .AppendFormat(" AND IdNombreFiltro = '{0}'", idNombreFiltro)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetNombresFiltros(ByVal idTipoFiltro As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT IdTipoFiltro")
         .Append("      ,IdNombreFiltro")
         .Append("  FROM FiltrosValores ")
         .AppendFormat(" WHERE IdTipoFiltro = '{0}'", idTipoFiltro)
         .AppendFormat(" GROUP BY IdTipoFiltro, IdNombreFiltro ")
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function FiltrosValores_G1(ByVal idTipoFiltro As String, _
                               ByVal idNombreFiltro As String, _
                               ByVal idColumna As String, _
                               ByVal idRegistro As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" WHERE IdTipoFiltro = '{0}'", idTipoFiltro)
         .AppendFormat("      AND IdNombreFiltro = '{0}'", idNombreFiltro)
         .AppendFormat("      AND IdColumna = '{0}'", idColumna)
         .AppendFormat("      AND IdRegistro = {0}", idRegistro)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      columna = "R." + columna
      'If columna = "R.NombreVendedor" Then columna = "V.NombreEmpleado"
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine("  WHERE ")
         .Append(columna)
         .Append(" LIKE '%")
         .Append(valor)
         .Append("%'")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


End Class

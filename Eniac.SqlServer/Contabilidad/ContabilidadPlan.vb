Public Class ContabilidadPlan
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Planes_I(idPlanCuenta As Integer,
                       nombrePlanCuenta As String)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadPlanes")
         .AppendLine("   (IdPlanCuenta")
         .AppendLine("   ,NombrePlanCuenta")
         .AppendLine(" ) VALUES ( ")
         .AppendLine("   " & idPlanCuenta.ToString())
         .AppendLine("   ,'" & nombrePlanCuenta & "'")
         .AppendLine(")")
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Planes_U(idPlanCuenta As Integer,
                       nombrePlanCuenta As String)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("UPDATE ContabilidadPlanes SET ")
         .AppendLine("   NombrePlanCuenta = '" & nombrePlanCuenta & "'")
         .AppendLine(" WHERE IdPlanCuenta = " & idPlanCuenta.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub Planes_D(idPlanCuenta As Integer)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ContabilidadPlanes")
         .AppendLine(" WHERE IdPlanCuenta = " & idPlanCuenta.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .AppendLine("SELECT P.* ")
         .AppendLine(" FROM ContabilidadPlanes P")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "P." + columna
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Planes_GA(todos As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)

         If todos Then
            .Append(" union select '-1' as  idplancuenta,'(Todos)' as nombreplancuenta ")
         End If
         .Append("  ORDER BY P.NombrePlanCuenta")

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Planes_G1(idPlanCuenta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE IdPlanCuenta = " & idPlanCuenta.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre(nombrePlanCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE p.NombrePlanCuenta LIKE '%" & nombrePlanCuenta & "%'")
         .AppendLine(" ORDER BY P.NombrePlanCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function TieneCuentasAsociadas(idPLanCuenta As Integer) As Boolean
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT IdCuenta ")
         .AppendLine(" FROM ContabilidadPlanesCuentas")
         .AppendLine(" WHERE ContabilidadCuentas.IdPlanCuenta= " & idPLanCuenta.ToString)

      End With

      Return Me.GetDataTable(stb.ToString()).Rows.Count > 0

   End Function

   Public Function GetIdMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo("IdPlanCuenta", "ContabilidadPlanes"))
   End Function

End Class
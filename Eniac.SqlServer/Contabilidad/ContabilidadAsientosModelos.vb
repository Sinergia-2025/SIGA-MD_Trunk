Public Class ContabilidadAsientosModelos
    Inherits Comunes

    Public Sub New(ByVal da As Eniac.Datos.DataAccess)
        MyBase.New(da)
    End Sub

    Public Function Asiento_GetDetalle(ByVal IdPlanCuenta As Integer, ByVal idAsiento As Integer) As DataTable

        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            .Length = 0
            .AppendLine("SELECT IdAsiento ")
            .AppendLine(" ,(SELECT str(c.IdCuenta) + ' - ' + C.NombreCuenta FROM ContabilidadCuentas C WHERE C.IdCuenta = AC.IdCuenta) as Cuenta ")
            .AppendLine(" ,idCuenta ")
            .AppendLine(" ,idPlanCuenta ")
            .AppendLine(" ,nombreAsiento ")

            .AppendLine("  FROM ContabilidadAsientosModelo AC ")
            .AppendLine(" WHERE IdPlanCuenta = " & IdPlanCuenta.ToString)
            .AppendLine("   AND IdAsiento = " & idAsiento.ToString)

        End With

        Return Me.GetDataTable(stb.ToString())

    End Function

    Public Function Asiento_GetIdMaximo(ByVal IdPlanCuenta As Integer) As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            .Length = 0
            .AppendLine("SELECT MAX(IdAsiento) AS maximo ")
            .AppendLine(" FROM ContabilidadAsientosModelo")
            .AppendLine(" WHERE IdPlanCuenta = " & IdPlanCuenta.ToString)
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendLine("SELECT A.IdPlanCuenta")
         .AppendLine("      ,Pl.NombrePlanCuenta")
         .AppendLine("      ,A.IdAsiento")
         .AppendLine("      ,A.NombreAsiento")
         .AppendLine("      ,A.Idcuenta")
         .AppendLine("      ,C.nombreCuenta")

         .AppendLine(" FROM ContabilidadAsientosModelo A ")
         .AppendLine(" INNER JOIN ContabilidadPlanes Pl on Pl.IdPlanCuenta = A.IdPlanCuenta")
         .AppendLine(" INNER JOIN contabilidadCuentas C on C.Idcuenta = A.Idcuenta")
      End With
   End Sub

    Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
        columna = "A." + columna
        If columna = "A.NombrePlanCuenta" Then columna = columna.Replace("A.", "Pl.")
        ' If columna = "A.NombreSucursal" Then columna = "S.Nombre"
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendLine(" WHERE " & columna & " LIKE '%" & valor & "%'")
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

   Public Function Asientos_GAD() As DataTable
      Return Asientos_GAD(Nothing, String.Empty, False)
   End Function
   Public Function Asientos_GAD(ByVal idPlanCuenta As Integer?, ByVal modelo As String) As DataTable
      Return Asientos_GAD(idPlanCuenta, modelo, False)
   End Function
   Public Function Asientos_GAD(ByVal idPlanCuenta As Integer?, ByVal modelo As String, ByVal BusquedaParcial As Boolean) As DataTable
      Dim dtResult As DataTable = Asientos_GAD_interno(idPlanCuenta, modelo, False)
      If dtResult.Rows.Count = 0 And BusquedaParcial Then
         dtResult = Asientos_GAD_interno(idPlanCuenta, modelo, True)
      End If
      Return dtResult
   End Function

   Private Function Asientos_GAD_interno(ByVal idPlanCuenta As Integer?, ByVal modelo As String, ByVal BusquedaParcial As Boolean) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Length = 0
         .AppendLine("SELECT A.IdPlanCuenta")
         .AppendLine("      ,Pl.NombrePlanCuenta")
         .AppendLine("      ,A.IdAsiento")
         .AppendLine("      ,A.NombreAsiento")

         .AppendLine(" FROM ContabilidadAsientosModelo A ")
         .AppendLine(" INNER JOIN ContabilidadPlanes Pl on Pl.IdPlanCuenta = A.IdPlanCuenta")

         .AppendLine(" WHERE 1 = 1")
         If idPlanCuenta.HasValue Then
            .AppendFormat("   AND A.idPlanCuenta = {0}", idPlanCuenta.Value).AppendLine()
         End If
         If Not String.IsNullOrWhiteSpace(modelo) Then
            If BusquedaParcial Then
               .AppendFormat("   AND A.nombreAsiento LIKE '%{0}%'", modelo).AppendLine()
            Else
               .AppendFormat("   AND A.nombreAsiento = '{0}'", modelo).AppendLine()
            End If
         End If

         .Append("  GROUP BY A.IdPlanCuenta,Pl.NombrePlanCuenta,A.IdAsiento,A.NombreAsiento ORDER BY A.NombreAsiento")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Asientos_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY A.NombreAsiento")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Asientos_G1(ByVal idPlanCuenta As Integer, ByVal idAsiento As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE A.IdPlanCuenta = " & idPlanCuenta.ToString())
         .AppendLine("   AND A.IdAsiento = " & idAsiento.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

    Public Function GetPorNombre(ByVal NombreAsiento As String) As DataTable
        Dim stb As StringBuilder = New StringBuilder("")
        With stb
            Me.SelectTexto(stb)
            .AppendLine(" WHERE A.NombreAsiento LIKE '%" & NombreAsiento & "%'")
            .AppendLine(" ORDER BY A.NombreAsiento")
        End With
        Return Me.GetDataTable(stb.ToString())
    End Function

    Public Sub Asiento_I(ByVal idAsiento As Integer, _
                         ByVal NombreAsiento As String, _
                        ByVal IdPlanCuenta As Integer, _
                        ByVal idCuenta As Integer)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("INSERT INTO ContabilidadAsientosModelo")
            .AppendLine("   (IdAsiento")
            .AppendLine("   ,NombreAsiento")
            .AppendLine("   ,IdPlanCuenta")
            .AppendLine("   ,idCuenta")

            .AppendLine(" ) VALUES ( ")
            .AppendLine("   " & idAsiento.ToString())
            .AppendLine("   ,'" & NombreAsiento.ToString() & "'")
            .AppendLine("   ," & IdPlanCuenta.ToString)
            .AppendLine("   ," & idCuenta.ToString)
            .AppendLine(")")

        End With

        Me.Execute(stb.ToString())

    End Sub


    Public Sub Asiento_U(ByVal idAsiento As Integer, _
                         ByVal NombreAsiento As String, _
                         ByVal IdPlanCuenta As Integer, _
                        ByVal idCuenta As Integer)

        Dim stb As StringBuilder = New StringBuilder("")

        With stb
            .Length = 0
            .AppendLine("UPDATE ContabilidadAsientosModelo SET ")
            .AppendLine("   NombreAsiento = '" & NombreAsiento & "'")
            .AppendLine("   ,IdPlanCuenta = " & IdPlanCuenta.ToString)
            .AppendLine("   ,idCuenta =" & idCuenta.ToString)
            .AppendLine(" WHERE  idAsiento = " & idAsiento.ToString())
        End With

        Me.Execute(stb.ToString())

    End Sub

   Public Sub Asiento_D(ByVal IdPlanCuenta As Integer, ByVal idAsiento As Integer)

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("DELETE FROM ContabilidadAsientosModelo")
         .AppendLine(" WHERE IdPlanCuenta = " & IdPlanCuenta.ToString())
         .AppendLine("   AND idAsiento = " & idAsiento.ToString())
      End With

      Me.Execute(stb.ToString())

   End Sub

End Class

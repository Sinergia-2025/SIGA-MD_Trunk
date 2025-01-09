Public Class ContabilidadPlanesCuentas
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function plan_GetDetalle(ByVal idPlanCuenta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine(" SELECT ") 'IdPlanCuenta, ")
         .AppendLine(" C.IdCuenta ")
         .AppendLine(",C.NombreCuenta ")
         .AppendLine(" FROM ContabilidadCuentas C,ContabilidadPlanesCuentas PC")
         .AppendLine(" WHERE C.IdCuenta= PC.idCuenta ")
         .AppendLine(" and PC.idplancuenta = " & idPlanCuenta.ToString)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function


   Public Sub PlanCuenta_M(idPlanCuenta As Integer?, idCuenta As Long?)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         'EL MERGE PERMITE ANALIZAR SI EL REGISTRO SE ENCUENTRA EN LA BD E INMEDIATAMENTE
         '(EN LA MISMA INSTRUCCION) DECIDIR SI SE DESEA INSERTAR O ACTUALIZAR EL REGISTRO
         'EN ESTE CASO SOLO EVALUO SI NO ESTAN (NOT MATCHED) PARA INSERTAR LOS REGISTROS.
         'SI YA SE ENCUENTRAN, NO HAGO NADA.
         .AppendFormat("MERGE INTO ContabilidadPlanesCuentas AS D").AppendLine()
         .AppendFormat("     USING (SELECT IdPlanCuenta, IdCuenta").AppendLine()
         .AppendFormat("              FROM ContabilidadPlanes CROSS JOIN ContabilidadCuentas").AppendLine()
         .AppendFormat("             WHERE 1 = 1").AppendLine()
         If idCuenta.HasValue Then
            .AppendFormat("            AND IdCuenta = {0}", idCuenta).AppendLine()
         End If
         If idPlanCuenta.HasValue Then
            .AppendFormat("            AND idPlanCuenta = {0}", idPlanCuenta).AppendLine()
         End If
         .AppendFormat(") AS O")
         .AppendFormat("        ON D.IdPlanCuenta = O.IdPlanCuenta AND D.IdCuenta = O.IdCuenta").AppendLine()
         .AppendFormat(" WHEN NOT MATCHED THEN").AppendLine()
         .AppendFormat("         INSERT(IdPlanCuenta, IdCuenta)").AppendLine()
         .AppendFormat("    VALUES (O.IdPlanCuenta, O.IdCuenta);").AppendLine()
      End With
      Me.Execute(stb.ToString())
   End Sub

   Public Sub PlanCuenta_I(idPlanCuenta As Integer,
                           grillaCuentas As DataTable)

      PlanCuenta_D(idPlanCuenta)

      For Each filaCuenta As DataRow In grillaCuentas.Rows
         If Not CBool(filaCuenta("Importa")) Then Continue For
         Dim stb As StringBuilder = New StringBuilder()
         With stb
            .AppendLine("INSERT INTO ContabilidadPlanesCuentas")
            .AppendLine("   (idPlanCuenta")
            .AppendLine("   ,IdCuenta")
            .AppendLine(" ) VALUES ( ")
            .AppendLine("   " & idPlanCuenta.ToString())
            .AppendLine("   ," & filaCuenta("IdCuenta").ToString)
            .AppendLine(")")
         End With
         Me.Execute(stb.ToString())
      Next
   End Sub

   Public Sub PlanCuenta_U(idPlanCuenta As Integer,
                           grillaCuentas As DataTable)

      'Dim stb As StringBuilder = New StringBuilder("")

      'With stb
      '    .Length = 0
      '    .AppendLine("UPDATE ContabilidadPlanesCuentas SET ")
      '    .AppendLine("    IdCuenta= " & IdCuenta.ToString)
      '    .AppendLine("   ,IdCentroCosto = " & IdCentroCosto.ToString)
      '    .AppendLine("   ,NombrePlanCuenta = '" & NombrePlanCuenta.ToString() & "'")
      '    .AppendLine(" WHERE idPlanCuenta = " & idPlanCuenta.ToString())

      'End With

      'Me.Execute(stb.ToString())

   End Sub

   Public Sub PlanCuenta_D(idPlanCuenta As Integer)
      PlanCuenta_D(idPlanCuenta, Nothing)
   End Sub

   Public Sub PlanCuenta_D(idPlanCuenta As Integer?, idCuenta As Long?)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ContabilidadPlanesCuentas")
         .AppendLine(" WHERE 1 = 1")
         If idPlanCuenta.HasValue Then
            .AppendLine("   AND idPlanCuenta = " & idPlanCuenta.Value.ToString())
         End If
         If idCuenta.HasValue Then
            .AppendLine("   AND idCuenta = " & idCuenta.Value.ToString())
         End If
      End With

      Me.Execute(stb.ToString())
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT PC.* ")
         .AppendLine(" FROM ContabilidadPlanesCuentas PC")
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      columna = "PC." + columna
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PlanCuenta_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .Append("  ORDER BY PC.NombrePlanCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PlanCuenta_G1(idPlanCuenta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE PC.idPlanCuenta = " & idPlanCuenta.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre(nombrePlanCuenta As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto(stb)
         .AppendFormatLine(" WHERE PC.NombrePlanCuenta LIKE '%{0}%'", nombrePlanCuenta)
         .AppendLine(" ORDER BY PC.NombrePlanCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function PlanCuenta_GetIdMaximo() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(idPlanCuenta) AS maximo ")
         .AppendLine(" FROM ContabilidadPlanesCuentas")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetDatosCuenta(idCuenta As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT c.NombreCuenta as cuenta ")
         .AppendLine(", c.IdCuenta as codigo ")
         '.AppendLine(", TC.NombreTipoCuenta as TipoCuenta ")
         '.AppendLine(", c.IdCuentaPadre as Jerarquia ")

         '.AppendLine(" FROM ContabilidadCuentas C,ContabilidadTiposCuentas TC")
         .AppendLine(" FROM ContabilidadCuentas C")

         .AppendLine(" WHERE  c.IdCuenta=" & idCuenta)
         '.AppendLine(" and  c.codTipoCuenta=TC.codTipoCuenta")
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function seleccionarTodasLasCuentas() As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT c.NombreCuenta  ")
         .AppendLine(", c.IdCuenta  ")
         .AppendLine(" FROM ContabilidadCuentas C")

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   'Public Function seleccionarTodasLasCuentasNivel1() As DataTable
   '   Dim stb As StringBuilder = New StringBuilder()
   '   With stb
   '      .AppendLine("SELECT IdCuenta  ")
   '      .AppendLine(", NombreCuenta  ")
   '      .AppendLine(", IdCuentaPadre  ")
   '      .AppendLine(" FROM ContabilidadCuentas")
   '      .AppendLine(" Where Nivel = 1")

   '   End With
   '   Return Me.GetDataTable(stb.ToString())
   'End Function

End Class
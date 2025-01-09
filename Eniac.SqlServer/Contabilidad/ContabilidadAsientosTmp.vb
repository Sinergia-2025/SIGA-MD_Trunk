Public Class ContabilidadAsientosTmp
   Inherits Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub
#Region "ABM"

   Public Sub MarcarContabilidadDefinitiva(idEjercicio As Integer,
                                           idPlanCuenta As Integer,
                                           idAsiento As Integer,
                                           idEjercicioDefinitivo As Integer?,
                                           idPlanCuentaDefinitivo As Integer?,
                                           idAsientoDefinitivo As Integer?)
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormatLine("UPDATE ContabilidadAsientosTmp")
         .AppendFormatLine("   SET IdEjercicioDefinitivo  = {0}", idEjercicioDefinitivo)
         .AppendFormatLine("     , IdPlanCuentaDefinitivo = {0}", idPlanCuentaDefinitivo)
         .AppendFormatLine("     , IdAsientoDefinitivo    = {0}", idAsientoDefinitivo)
         .AppendFormatLine(" WHERE IdEjercicio  = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND idAsiento    = {0}", idAsiento)
      End With
      Me.Execute(stb.ToString())
   End Sub

   Public Sub Asiento_I_TMP(idEjercicio As Integer,
                            idPlanCuenta As Integer,
                            idAsiento As Integer,
                            fechaAsiento As Date,
                            nombreAsiento As String,
                            idTipoDoc As Integer,
                            idSucursal As Integer,
                            subsiAsiento As String,
                            idEjercicioDefinitivo As Integer?,
                            idPlanCuentaDefinitivo As Integer?,
                            idAsientoDefinitivo As Integer?)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadAsientosTmp")
         .AppendLine("   (IdEjercicio")
         .AppendLine("   ,IdPlanCuenta")
         .AppendLine("   ,IdAsiento")
         .AppendLine("   ,FechaAsiento")
         .AppendLine("   ,NombreAsiento")
         .AppendLine("   ,IdTipoDoc")
         .AppendLine("   ,idSucursal")
         .AppendLine("   ,SubsiAsiento")
         .AppendLine("   ,IdEjercicioDefinitivo")
         .AppendLine("   ,IdPlanCuentaDefinitivo")
         .AppendLine("   ,IdAsientoDefinitivo")
         .AppendLine(" ) VALUES ( ")
         .AppendFormatLine("     {0} ", idEjercicio)
         .AppendFormatLine("   , {0} ", idPlanCuenta)
         .AppendFormatLine("   , {0} ", idAsiento)
         .AppendFormatLine("   ,'{0}'", Me.ObtenerFecha(fechaAsiento, False))
         .AppendFormatLine("   ,'{0}'", nombreAsiento)
         .AppendFormatLine("   , {0} ", idTipoDoc)
         .AppendFormatLine("   , {0} ", idSucursal)
         .AppendFormatLine("   ,'{0}'", subsiAsiento)
         .AppendFormatLine("   , {0} ", GetStringFromNumber(idEjercicioDefinitivo))
         .AppendFormatLine("   , {0} ", GetStringFromNumber(idPlanCuentaDefinitivo))
         .AppendFormatLine("   , {0} ", GetStringFromNumber(idAsientoDefinitivo))
         .AppendLine(")")
      End With
      Me.Execute(stb.ToString())
   End Sub

   Public Sub Asiento_I_Detalle_TMP(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer, dtDetalle As DataTable)
      Dim renglon As Integer = 1
      For Each fila As DataRow In dtDetalle.Rows
         Dim stb As StringBuilder = New StringBuilder()
         With stb
            .AppendLine("INSERT INTO ContabilidadAsientosCuentasTmp")
            .AppendLine("    (IdEjercicio")
            .AppendLine("    ,IdPlanCuenta")
            .AppendLine("    ,idAsiento")
            .AppendLine("    ,IdCuenta")
            .AppendLine("    ,idRenglon")
            .AppendLine("    ,Debe")
            .AppendLine("    ,Haber")
            .AppendLine("    ,IdTipoReferencia")
            .AppendLine("    ,Referencia")
            .AppendLine("    ,IdCentroCosto")

            .AppendLine(" ) VALUES ( ")
            .AppendFormatLine("     {0}", idEjercicio)
            .AppendFormatLine("    ,{0}", idPlanCuenta)
            .AppendFormatLine("    ,{0}", idAsiento)
            .AppendFormatLine("    ,{0}", fila("IdCuenta"))
            .AppendFormatLine("    ,{0}", renglon)

            .AppendFormatLine("    ,{0}", If(IsDBNull(fila("Debe")), 0, fila("Debe")))
            .AppendFormatLine("    ,{0}", If(IsDBNull(fila("Haber")), 0, fila("Haber")))


            If Not String.IsNullOrWhiteSpace(fila("IdTipoReferencia").ToString()) Then
               .AppendFormatLine("    ,'{0}'", fila("IdTipoReferencia"))
            Else
               .AppendFormatLine("    ,NULL")
            End If
            If Not String.IsNullOrWhiteSpace(fila("Referencia").ToString()) Then
               .AppendFormatLine("    ,'{0}'", fila("Referencia"))
            Else
               .AppendFormatLine("    ,NULL")
            End If
            If IsNumeric(fila("IdCentroCosto")) AndAlso Integer.Parse(fila("IdCentroCosto").ToString()) > 0 Then
               .AppendFormatLine("    ,{0}", fila("IdCentroCosto"))
            Else
               .AppendLine(" ,NULL")
            End If
            .AppendLine(")")

         End With

         Me.Execute(stb.ToString())

         renglon += 1
      Next

   End Sub

   Public Sub Asiento_U_Tmp(idEjercicio As Integer,
                            idPlanCuenta As Integer,
                            idAsiento As Integer,
                            fechaAsiento As Date,
                            nombreAsiento As String,
                            idTipoDoc As Integer,
                            idSucursal As Integer,
                            subsiAsiento As String,
                            idEjercicioDefinitivo As Integer?,
                            idPlanCuentaDefinitivo As Integer?,
                            idAsientoDefinitivo As Integer?)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ContabilidadAsientosTmp")
         .AppendFormatLine("   SET NombreAsiento = '{0}'", nombreAsiento)
         .AppendFormatLine("     , FechaAsiento = '{0}'", Me.ObtenerFecha(fechaAsiento, False))
         .AppendFormatLine("     , SubsiAsiento = '{0}'", subsiAsiento)
         .AppendFormatLine("     , IdSucursal = {0}", idSucursal)
         .AppendFormatLine("     , IdEjercicioDefinitivo = {0}", GetStringFromNumber(idEjercicioDefinitivo))
         .AppendFormatLine("     , IdPlanCuentaDefinitivo = {0}", GetStringFromNumber(idPlanCuentaDefinitivo))
         .AppendFormatLine("     , IdAsientoDefinitivo {0} = ", GetStringFromNumber(idAsientoDefinitivo))
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND idAsiento = {0}", idAsiento)

      End With
      Me.Execute(stb.ToString())
   End Sub

   Public Sub Asiento_U_Detalle_Tmp(idEjercicio As Integer,
                                    idPlanCuenta As Integer,
                                    idAsiento As Integer,
                                    dtDetalle As DataTable)
      ' primero borro todo, luego inserto.
      Asiento_D_Detalle_Tmp(idEjercicio, idPlanCuenta, idAsiento)
      Asiento_I_Detalle_TMP(idEjercicio, idPlanCuenta, idAsiento, dtDetalle)

   End Sub

   Public Sub Asiento_D_Detalle_Tmp(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ContabilidadAsientosCuentasTmp")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND IdAsiento = {0}", idAsiento)
      End With

      Me.Execute(stb.ToString())
   End Sub

   Public Sub Asiento_D_Tmp(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer)
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ContabilidadAsientosTmp")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND IdAsiento = {0}", idAsiento)
      End With

      Me.Execute(stb.ToString())
   End Sub


#End Region

   Private Sub SelectTexto_Tmp(stb As StringBuilder)
      With stb
         .AppendLine("SELECT A.IdEjercicio")
         .AppendLine("      ,A.IdPlanCuenta")
         .AppendLine("      ,A.IdAsiento")
         .AppendLine("      ,A.NombreAsiento")
         .AppendLine("      ,A.FechaAsiento")
         .AppendLine("      ,A.IdTipoDoc")
         .AppendLine("      ,A.IdEjercicio")
         .AppendLine("      ,A.IdSucursal")
         .AppendLine("      ,A.SubsiAsiento ")
         .AppendLine("      ,A.IdEjercicioDefinitivo")
         .AppendLine("      ,A.IdPlanCuentaDefinitivo")
         .AppendLine("      ,A.IdAsientoDefinitivo")
         .AppendLine(" FROM ContabilidadAsientosTmp A ")
      End With
   End Sub

   Public Overloads Function Buscar_tmp(ByVal columna As String, ByVal valor As String) As DataTable
      'If columna = "NombrePlanCuenta" Then
      '   columna = "PL." + columna
      'ElseIf columna = "NombreSucursal" Then
      '   columna = "S.Nombre"
      'Else
      columna = "A." + columna
      'End If
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto_Tmp(stb)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Asiento_GetIdMaximo_Tmp(idEjercicio As Integer, idPlanCuenta As Integer) As Integer
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT * ")
         .AppendLine(" FROM vw_ContabilidadAsientosIDMaximo")
         .AppendFormatLine(" WHERE IdEjercicio = {0} ", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0} ", idPlanCuenta)
      End With

      Dim dt As DataTable = Me.GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return dt.Rows(0).ValorNumericoPorDefecto("maximo", 0I)
      End If

      Return 0
   End Function

   Public Function Asientos_G1_Tmp(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto_Tmp(stb)
         .AppendFormatLine(" WHERE A.IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND A.IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND A.IdAsiento = {0}", idAsiento)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Asientos_GA(idEjercicio As Integer?, idPlanCuenta As Integer?, idAsiento As Integer?) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         Me.SelectTexto_Tmp(stb)
         .AppendFormatLine(" WHERE 1 = 1")
         If idEjercicio.HasValue Then
            .AppendFormatLine("   AND A.IdEjercicio = {0}", idEjercicio.Value)
         End If
         If idPlanCuenta.HasValue Then
            .AppendFormatLine("   AND A.IdPlanCuenta = {0}", idPlanCuenta.Value)
         End If
         If idAsiento.HasValue Then
            .AppendFormatLine("   AND A.IdAsiento = {0}", idAsiento.Value)
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Asiento_GetDetalle_Tmp(idEjercicio As Integer, idPlanCuenta As Integer, idAsiento As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("SELECT AC.IdEjercicio")
         .AppendLine("     , AC.IdPlanCuenta")
         .AppendLine("     , AC.IdAsiento ")
         .AppendLine("     , AC.IdCuenta")
         .AppendLine("     , STR(AC.IdCuenta) + ' - ' + C.NombreCuenta as Cuenta")
         .AppendLine("     , AC.IdRenglon")
         .AppendLine("     , CASE WHEN AC.Debe  = 0 THEN NULL ELSE AC.Debe  END Debe")
         .AppendLine("     , CASE WHEN AC.Haber = 0 THEN NULL ELSE AC.Haber END Haber")
         .AppendLine("     , AC.IdTipoReferencia")
         .AppendLine("     , AC.Referencia")
         .AppendLine("     , AC.IdCentroCosto")
         .AppendLine("     , CCC.NombreCentroCosto")
         .AppendLine("  FROM ContabilidadAsientosCuentasTmp AC ")
         .AppendLine(" INNER JOIN ContabilidadCuentas C ON C.IdCuenta = AC.IdCuenta")
         .AppendLine("  LEFT JOIN ContabilidadCentrosCostos CCC ON CCC.IdCentroCosto = AC.IdCentroCosto")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPlanCuenta = {0}", idPlanCuenta)
         .AppendFormatLine("   AND IdAsiento = {0}", idAsiento)
      End With

      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function GetPorNombre_Tmp(nombreAsiento As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto_Tmp(stb)
         .AppendFormatLine(" WHERE A.NombreAsiento LIKE '%{0}%'", nombreAsiento)
         .AppendLine(" ORDER BY A.NombreAsiento")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function ComprobarExistenciaAsientos_Tmp(ByVal FechaInicial As DateTime, ByVal FechaFinal As DateTime) As DataTable
      Dim stb As StringBuilder = New StringBuilder()
      With stb
         .AppendLine("IF EXISTS (SELECT * FROM ContabilidadAsientosTmp WHERE (IdAsientoDefinitivo IS NULL OR IdAsientoDefinitivo = 0)")
         .AppendLine("           AND FechaAsiento BETWEEN '" & ObtenerFecha(FechaInicial, False) & "' AND '" & ObtenerFecha(FechaFinal, True) & "')")
         .AppendLine("     SELECT 1 as ExisteUno")
         .AppendLine("ELSE")
         .AppendLine("     Select 0 as ExisteUno")
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class
Public Class ContabilidadEjercicios
   Inherits Comunes
   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Function GetPeriodoActual(idEjercicio As Integer, fechaAsiento As Date) As String
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(PE.IdPeriodo) IdPeriodo")  'Uso MAX porque así siempre tengo un registro, incluso si no lo encuentro (trae NULL)
         .AppendLine("  FROM ContabilidadEjercicios E")
         .AppendLine(" INNER JOIN ContabilidadPeriodosEjercicios PE ON PE.IdEjercicio = E.IdEjercicio")
         .AppendLine(" WHERE E.Cerrado = 'False'")
         .AppendLine("   AND PE.cerrado = 'False'")
         .AppendFormatLine("   AND PE.IdPeriodo = '{0:MM/yyyy}'", fechaAsiento)
      End With
      Using dt = GetDataTable(stb)
         Return dt.Rows(0).Field(Of String)("IdPeriodo").IfNull()
      End Using
   End Function

   Public Function EstaPeriodoCerrado(idEjercicio As Integer, idPeriodo As String) As Boolean 'Devuelve el estado del periodo

      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("SELECT ISNULL(MIN(CONVERT(INT,PE.Cerrado)), 0) Cerrado")   'Uso MIN porque así siempre tengo un registro, incluso si no lo encuentro (trae NULL), luego si NULL lo convierto en False
         .AppendFormatLine("  FROM ContabilidadPeriodosEjercicios PE ")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
         .AppendFormatLine("   AND IdPeriodo = '{0}'", idPeriodo)
      End With
      Using dt = GetDataTable(stb)
         Return dt.Rows(0).Field(Of Integer)("Cerrado") <> 0   'El valor devuelto es entero. Si es 0 entonces False, si es 1 es True
      End Using
   End Function

   Public Function GetEjercicioVigente(fechaAsiento As Date, soloAbierto As Boolean) As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(E.IdEjercicio) IdEjercicio")  'Uso MAX porque así siempre tengo un registro, incluso si no lo encuentro (trae NULL)
         .AppendLine("  FROM ContabilidadEjercicios E")
         .AppendLine(" INNER JOIN ContabilidadPeriodosEjercicios PE ON PE.IdEjercicio = E.IdEjercicio")

         .AppendFormatLine(" WHERE PE.IdPeriodo =  '{0:MM/yyyy}'", fechaAsiento)
         If soloAbierto Then
            .AppendLine("   AND E.Cerrado = 'False'")
            .AppendLine("   AND PE.cerrado = 'False'")
         End If
      End With
      Using dt = GetDataTable(stb)
         Return dt.Rows(0).Field(Of Integer?)("IdEjercicio").IfNull()
      End Using
   End Function

   Public Function GetEjerciciosReportes(fechaAsiento As Date) As Integer
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(PE.IdPeriodo) IdPeriodo")  'Uso MAX porque así siempre tengo un registro, incluso si no lo encuentro (trae NULL)
         .AppendLine("  FROM ContabilidadEjercicios E")
         .AppendLine(" INNER JOIN ContabilidadPeriodosEjercicios PE ON PE.IdEjercicio = E.IdEjercicio")
         .AppendFormatLine(" WHERE PE.IdPeriodo =  '{0:MM/yyyy}'", fechaAsiento)
      End With
      Using dt = GetDataTable(stb)
         Return dt.Rows(0).Field(Of Integer?)("IdEjercicio").IfNull()
      End Using
   End Function

   Public Function GetEjerciciosAbiertos() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT [IdEjercicio],[FechaDesde],[FechaHasta],[Cerrado]")
         .AppendLine("  FROM ContabilidadEjercicios ")
         .AppendFormatLine(" WHERE Cerrado = 'False'")
      End With
      Return GetDataTable(stb)
   End Function


   'Public Function GetPrimerMesPeriodo(fecha As Date) As String
   '   Dim stb = New StringBuilder()
   '   With stb
   '      .AppendLine("SELECT SUBSTRING(IdPeriodo, 0, 3) AS mes")
   '      .AppendLine(" from  ContabilidadPeriodosEjercicios PE ")
   '      .AppendLine(" where IdEjercicio = " & GetEjerciciosReportes(fecha).ToString)
   '      .AppendLine(" and orden = 1")
   '   End With

   '   Dim dt As DataTable
   '   dt = GetDataTable(stb)

   '   If dt.Rows.Count = 0 Then
   '      Return "0101"
   '   Else
   '      Return dt.Rows(0)("mes").ToString() & "01"
   '   End If

   'End Function

   'Public Function GetUltimoMesPeriodoAnterior(fecha As Date) As String

   '   Dim stb = New StringBuilder()
   '   With stb
   '      .AppendLine(" Select SUBSTRING(IdPeriodo, 0, 3) as mes")
   '      .AppendLine(" from  ContabilidadPeriodosEjercicios PE ")
   '      .AppendLine(" where IdEjercicio = " & GetEjerciciosReportes(fecha.AddYears(-1)).ToString)
   '      .AppendLine(" and orden = 12")
   '   End With

   '   Dim dt As DataTable
   '   dt = GetDataTable(stb)

   '   If dt.Rows.Count = 0 Then
   '      Return "1231"
   '   Else
   '      Return dt.Rows(0)("mes").ToString() & Date.DaysInMonth(fecha.AddYears(-1).Year, CInt(dt.Rows(0)("mes"))).ToString()
   '   End If

   'End Function

   Public Function Ejercicio_GetDetalle(idEjercicio As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT PE.*")
         .AppendLine("  FROM ContabilidadPeriodosEjercicios PE")
         .AppendFormatLine(" WHERE PE.IdEjercicio = {0}", idEjercicio)
         .AppendLine(" ORDER BY Orden")
      End With
      Return GetDataTable(stb)
   End Function

   Public Sub Ejercicios_I(idEjercicio As Integer, fechaDesde As Date, fechaHasta As Date, cerrado As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("INSERT INTO ContabilidadEjercicios")
         .AppendLine("   (IdEjercicio")
         .AppendLine("   ,FechaDesde")
         .AppendLine("   ,FechaHasta")
         .AppendLine("   ,cerrado")
         .AppendLine(" ) VALUES ( ")
         .AppendFormatLine("     {0} ", idEjercicio)
         .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaDesde, False))
         .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaHasta, False))
         .AppendFormatLine("   , {0} ", GetStringFromBoolean(cerrado))
         .AppendLine(")")
      End With
      Execute(stb)
   End Sub

   Public Sub Ejercicios_I_Detalle(idEjercicio As Integer, dtDetalle As DataTable)
      For Each fila As DataRow In dtDetalle.Rows
         Dim stb = New StringBuilder()
         With stb
            .AppendLine("INSERT INTO ContabilidadPeriodosEjercicios")
            .AppendLine("   (IdEjercicio")
            .AppendLine("   ,IdPeriodo")
            .AppendLine("   ,cerrado")
            .AppendLine("   ,orden")
            .AppendFormatLine("   ,CoeficienteAjustePorInflacion")
            .AppendLine(" ) VALUES ( ")
            .AppendFormatLine("     {0} ", idEjercicio)
            .AppendFormatLine("   ,'{0}'", fila.Field(Of String)("IdPeriodo").PadLeft(7, "0"c))
            .AppendFormatLine("   ,'{0}'", fila.Field(Of Boolean)("Cerrado"))
            .AppendFormatLine("   , {0} ", fila.Field(Of Integer)("Orden"))
            .AppendFormatLine("   , {0} ", GetStringFromDecimal(fila.Field(Of Decimal?)("CoeficienteAjustePorInflacion")))
            .AppendLine(")")
         End With
         Execute(stb)
      Next
   End Sub

   'Public Sub Ejercicios_U_Detalle(idEjercicio As Integer, dtDetalle As DataTable)
   '   For Each fila As DataRow In dtDetalle.Rows
   '      Dim stb = New StringBuilder()
   '      With stb
   '         .AppendLine("UPDATE ContabilidadPeriodosEjercicios SET ")
   '         .AppendFormatLine("    Cerrado = '{0}'", fila("cerrado"))
   '         .AppendFormatLine("  , IdPeriodo = '{0}'", fila("IdPeriodo"))
   '         .AppendFormatLine("  , Orden = {0}", fila("orden"))
   '         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
   '      End With
   '      Execute(stb)
   '   Next
   'End Sub

   Public Sub Ejercicios_U(IdEjercicio As Integer, FechaDesde As Date, fechaHasta As Date, cerrado As Boolean)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("UPDATE ContabilidadEjercicios SET ")
         .AppendFormatLine("    FechaDesde = '{0}'", ObtenerFecha(FechaDesde, False))
         .AppendFormatLine("  , FechaHasta = '{0}'", ObtenerFecha(fechaHasta, False))
         .AppendFormatLine("  , cerrado    = '{0}'", cerrado)
         .AppendFormatLine(" WHERE IdEjercicio = {0}", IdEjercicio)
      End With
      Execute(stb)
   End Sub

   Public Sub Ejercicios_D_Detalle(idEjercicio As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ContabilidadPeriodosEjercicios")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
      End With
      Execute(stb)
   End Sub

   Public Sub Ejercicios_D(idEjercicio As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("DELETE FROM ContabilidadEjercicios")
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
      End With
      Execute(stb)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder, cantidadPeriodosPivot As Integer)
      With stb
         .AppendLine("SELECT E.* ")
         .AppendLine("     , (SELECT COUNT(1) FROM ContabilidadPeriodosEjercicios PE WHERE PE.IdEjercicio = E.IdEjercicio) CantPeriodos")
         If cantidadPeriodosPivot > 0 Then
            .AppendLine("     , PE.*")
         End If
         .AppendLine(" FROM ContabilidadEjercicios E")
         If cantidadPeriodosPivot > 0 Then
            Dim periodos = New Tuple(Of Long, Long)(1, cantidadPeriodosPivot).TupleRangeToList().ConvertAll(Function(l) l.ToString("00"))
            Dim maxP = String.Join(", ", periodos.ConvertAll(Function(s) String.Format("MAX(P{0}) P___{0}", s)))
            Dim maxE = String.Join(", ", periodos.ConvertAll(Function(s) String.Format("MAX(E{0}) E___{0}", s)))

            Dim pivP = String.Join(", ", periodos.ConvertAll(Function(s) String.Format("P{0}", s)))
            Dim pivE = String.Join(", ", periodos.ConvertAll(Function(s) String.Format("E{0}", s)))


            .AppendFormatLine("INNER JOIN (")
            .AppendFormatLine("            SELECT PE.IdEjercicio")
            .AppendFormatLine("                 , {0}", maxP)
            .AppendFormatLine("                 , {0}", maxE)
            .AppendFormatLine("              FROM (")
            .AppendFormatLine("                    SELECT PE.IdEjercicio")
            .AppendFormatLine("                         , PE.IdPeriodo")
            .AppendFormatLine("                         , CONVERT(INT, PE.Cerrado) Periodo_Cerrado")
            .AppendFormatLine("                         , 'P' + RIGHT( '0' + CONVERT(VARCHAR(MAX), Orden), 2) Orden_Periodo")
            .AppendFormatLine("                         , 'E' + RIGHT( '0' + CONVERT(VARCHAR(MAX), Orden), 2) Orden_Estado")
            .AppendFormatLine("                      FROM ContabilidadEjercicios E")
            .AppendFormatLine("                     INNER JOIN ContabilidadPeriodosEjercicios PE ON PE.IdEjercicio = E.IdEjercicio")
            .AppendFormatLine("                   ) PV")
            .AppendFormatLine("             PIVOT (MAX(IdPeriodo) FOR Orden_Periodo IN ({0})) P", pivP)
            .AppendFormatLine("             PIVOT (MAX(Periodo_Cerrado) FOR Orden_Estado IN ({0})) PE", pivE)
            .AppendFormatLine("             GROUP BY PE.IdEjercicio")
            .AppendFormatLine("            ) PE ON PE.IdEjercicio = E.IdEjercicio")
         End If
      End With
   End Sub

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      If columna = "CantPeriodos" Then
         columna = "(SELECT COUNT(1) FROM ContabilidadPeriodosEjercicios PE WHERE PE.IdEjercicio = E.IdEjercicio)"
      Else
         columna = "E." + columna
      End If
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, 0)
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Ejercicios_GA(cantidadPeriodosPivot As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, cantidadPeriodosPivot)
         .Append("  ORDER BY E.FechaDesde")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function Ejercicios_G1(idEjercicio As Integer) As DataTable
      Dim stb = New StringBuilder()
      With stb
         SelectTexto(stb, 0)
         .AppendFormatLine(" WHERE IdEjercicio = {0}", idEjercicio)
      End With
      Return GetDataTable(stb)
   End Function

   'Public Function Ejercicio_GetIdMaximo() As DataTable
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Length = 0
   '      .AppendLine("SELECT MAX(IdEjercicio) AS maximo ")
   '      .AppendLine(" FROM ContabilidadEjercicios")
   '   End With
   '   Return GetDataTable(stb)
   'End Function

   Public Function Ejercicio_GetFechaMaxima() As DataTable
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT MAX(FechaHasta) AS maxima")
         .AppendLine("  FROM ContabilidadEjercicios")
      End With
      Return GetDataTable(stb)
   End Function

   Public Function TieneAsientosAsociados(idEjercicio As Integer) As Boolean
      Dim stb = New StringBuilder()
      With stb
         .AppendLine("SELECT idAsiento ")
         .AppendLine(" FROM ContabilidadAsientos ")
         .AppendLine(" Where IdEjercicio= " & idEjercicio.ToString)
      End With
      Return GetDataTable(stb).Rows.Count > 0
   End Function

   Public Function GetIdMaximo() As Integer
      Return GetCodigoMaximo("IdEjercicio", "ContabilidadEjercicios").ToInteger()
   End Function

   ''' <summary>
   ''' Recupera el máximo Orden de todos los periodos con el fin de saber cuantas columnas mostrar en el ABM de Ejercicios
   ''' </summary>
   ''' <returns></returns>
   Public Function GetMaximoOrdenPeriodo() As Integer
      Return GetCodigoMaximo("Orden", "ContabilidadPeriodosEjercicios").ToInteger()
   End Function

End Class
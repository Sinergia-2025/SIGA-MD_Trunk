Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual

Public Class Cargos
   Inherits Eniac.SqlServer.Comunes

   Public Sub New(ByVal da As Eniac.Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Cargos_I(en As Entidades.Cargo)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("INSERT INTO Cargos")
         .AppendFormat(" ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}) ",
                          Entidades.Cargo.Columnas.IdCargo.ToString(),
                          Entidades.Cargo.Columnas.NombreCargo.ToString(),
                          Entidades.Cargo.Columnas.Monto.ToString(),
                          Entidades.Cargo.Columnas.Activo.ToString(),
                          Entidades.Cargo.Columnas.ImprimeVoucher.ToString(),
                          Entidades.Cargo.Columnas.CantidadMeses.ToString(),
                          Entidades.Cargo.Columnas.ModificaImporte.ToString(),
                          Entidades.Cargo.Columnas.CantidadCuotas.ToString(),
                          Entidades.Cargo.Columnas.CuotaActual.ToString(),
                          Entidades.Cargo.Columnas.ModificaCantidad.ToString(),
                          Entidades.Cargo.Columnas.IdProducto.ToString(),
                          Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString(),
                          Entidades.Cargo.Columnas.CargoTemporal.ToString()).AppendLine()

         .AppendLine(" VALUES ")
         .AppendFormat(" ({0}, '{1}', {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10},{11}, {12})",
                       en.IdCargo,
                       en.NombreCargo,
                       en.Monto,
                       GetStringFromBoolean(en.Activo),
                       GetStringFromBoolean(en.ImprimeVoucher),
                       IIf(en.CantidadMeses.HasValue, "0", "NULL").ToString(),
                       GetStringFromBoolean(en.ModificaImporte),
                       IIf(en.CantidadCuotas.HasValue, "0", "NULL").ToString(),
                       IIf(en.CantidadCuotas.HasValue, "0", "NULL").ToString(),
                       GetStringFromBoolean(en.ModificaCantidad),
                       IIf(String.IsNullOrWhiteSpace(en.IdProducto), "NULL", "'" + en.IdProducto + "'"),
                       en.IdTipoLiquidacion,
                        GetStringFromBoolean(en.CargoTemporal)).AppendLine()
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Cargos_U(en As Entidades.Cargo)
      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Cargos SET ")
         .AppendFormat("   {0} = '{1}',", Entidades.Cargo.Columnas.NombreCargo.ToString(), en.NombreCargo).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.Monto.ToString(), en.Monto).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.Activo.ToString(), GetStringFromBoolean(en.Activo)).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.ImprimeVoucher.ToString(), GetStringFromBoolean(en.ImprimeVoucher)).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.CantidadMeses.ToString(), IIf(en.CantidadMeses.HasValue, en.CantidadMeses, "NULL").ToString()).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.ModificaImporte.ToString(), GetStringFromBoolean(en.ModificaImporte)).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.CantidadCuotas.ToString(), IIf(en.CantidadCuotas.HasValue, en.CantidadCuotas, "NULL").ToString()).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.CuotaActual.ToString(), IIf(en.CantidadCuotas.HasValue, en.CuotaActual, "NULL").ToString()).AppendLine()
         .AppendFormat("   {0} =  {1},", Entidades.Cargo.Columnas.ModificaCantidad.ToString(), GetStringFromBoolean(en.ModificaCantidad)).AppendLine()
         .AppendFormat("   {0} =  {1}, ", Entidades.Cargo.Columnas.IdProducto.ToString(), IIf(String.IsNullOrWhiteSpace(en.IdProducto), "NULL", "'" + en.IdProducto + "'")).AppendLine()
         .AppendFormat("   {0} =  {1}, ", Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString(), en.IdTipoLiquidacion).AppendLine()
         .AppendFormat("   {0} =  {1} ", Entidades.Cargo.Columnas.CargoTemporal.ToString(), GetStringFromBoolean(en.CargoTemporal)).AppendLine()

         .AppendFormat(" WHERE {0} = {1}", Entidades.Cargo.Columnas.IdCargo.ToString(), en.IdCargo)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Cargos_U(ByVal idCargo As Integer, ByVal cuotaActual As Integer)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("UPDATE Cargos SET ")
         .AppendFormat("   {0} =  {1}", Entidades.Cargo.Columnas.CuotaActual.ToString(), cuotaActual).AppendLine()
         .AppendFormat(" WHERE {0} = {1}", Entidades.Cargo.Columnas.IdCargo.ToString(), idCargo)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Public Sub Cargos_D(en As Entidades.Cargo)

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Append("DELETE FROM Cargos")
         .AppendFormat(" WHERE {0} = {1}", Entidades.Cargo.Columnas.IdCargo.ToString(), en.IdCargo)
      End With

      Me.Execute(myQuery.ToString())
   End Sub

   Private Sub SelectTexto(ByVal stb As StringBuilder)
      With stb
         .Length = 0
         .AppendFormat("SELECT {0}.{1}, {0}.{2}, {0}.{3}, {0}.{4}, {0}.{5}, {0}.{6}, {0}.{7}, {0}.{8}, {0}.{9}, {0}.{10}, {0}.{11}, P.{12},{0}.{13},TL.{14},{15}  ", "AL",
                       Entidades.Cargo.Columnas.IdCargo.ToString(),
                       Entidades.Cargo.Columnas.NombreCargo.ToString(),
                       Entidades.Cargo.Columnas.Monto.ToString(),
                       Entidades.Cargo.Columnas.Activo.ToString(),
                       Entidades.Cargo.Columnas.ImprimeVoucher.ToString(),
                       Entidades.Cargo.Columnas.CantidadMeses.ToString(),
                       Entidades.Cargo.Columnas.ModificaImporte.ToString(),
                       Entidades.Cargo.Columnas.CantidadCuotas.ToString(),
                       Entidades.Cargo.Columnas.CuotaActual.ToString(),
                       Entidades.Cargo.Columnas.ModificaCantidad.ToString(),
                       Entidades.Cargo.Columnas.IdProducto.ToString(),
                       Eniac.Entidades.Producto.Columnas.NombreProducto.ToString(),
                       Entidades.Cargo.Columnas.IdTipoLiquidacion.ToString(),
                      "NombreTipoLiquidacion",
                       Entidades.Cargo.Columnas.CargoTemporal.ToString()).AppendLine()
         .AppendFormat(" FROM Cargos AS {0}", "AL").AppendLine()
         .AppendFormat(" LEFT JOIN Productos AS P ON P.IdProducto = AL.IdProducto").AppendLine()
         .AppendFormat(" LEFT JOIN TiposLiquidaciones AS TL  ON TL.IdTipoLiquidacion = AL.IdTipoLiquidacion").AppendLine()

      End With
   End Sub

   Public Function Cargos_GA() As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(" ORDER BY {0}.{1} ", "AL", Entidades.Cargo.Columnas.NombreCargo.ToString())

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cargos_GxTipoLiquidacion(ByVal IdTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE (AL.IdTipoLiquidacion = " & IdTipoLiquidacion.ToString() & "OR AL.IdTipoLiquidacion = '')")
         .AppendLine(" AND AL.Activo = 'True'")
         .AppendFormat(" ORDER BY {0}.{1} ", "AL", Entidades.Cargo.Columnas.NombreCargo.ToString())

      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cargos_G(idCargo As Integer?, nombreCargo As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)

         'Agrego el WHERE sin condicion real.
         .AppendLine(" WHERE AL.IdCargo > 0 ")

         If idCargo.HasValue Then
            .AppendLine("   AND AL.IdCargo = " & idCargo.ToString())
         End If
         If Not String.IsNullOrEmpty(nombreCargo) Then
            .AppendLine("   AND AL.NombreCargo LIKE '%" & nombreCargo & "%'")
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Function Cargos_G1(ByVal idCargo As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE AL.IdCargo = " & idCargo.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function Buscar(ByVal columna As String, ByVal valor As String) As DataTable
      If columna = Eniac.Entidades.Producto.Columnas.NombreProducto.ToString() Then
         columna = "P." + columna
      Else
         columna = "AL." + columna
      End If

      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendFormat(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())

   End Function

   Public Function CargosModificaImporte(idCargo As Integer, nombreCargo As String, idTipoLiquidacion As Integer) As DataTable
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         Me.SelectTexto(stb)
         .AppendLine(" WHERE AL.IdCargo > 0 ")
         .AppendLine(" AND (AL.IdTipoLiquidacion = " & idTipoLiquidacion & " OR AL.IdTipoLiquidacion = '')")
         .AppendLine("   AND (AL.ModificaImporte = 'True' OR AL.ModificaCantidad = 'True')")
         .AppendLine(" AND AL.Activo = 'True'")
         If idCargo > 0 Then
            .AppendLine("   AND AL.IdCargo = " & idCargo.ToString())
         End If
         If Not String.IsNullOrWhiteSpace(nombreCargo) Then
            .AppendLine("   AND AL.NombreCargo LIKE '%" & nombreCargo & "%'")
         End If
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer

      Dim maximo As String = "maximo"

      Dim dt As DataTable = GetDataTable(String.Format("SELECT MAX({1}) as {0} FROM Cargos ", maximo, Entidades.Cargo.Columnas.IdCargo.ToString()))

      Dim val As Integer = 0
      If dt.Rows.Count > 0 Then
         If Not IsDBNull(dt.Rows(0)(maximo)) AndAlso Not String.IsNullOrEmpty(dt.Rows(0)(maximo).ToString()) AndAlso
            IsNumeric(dt.Rows(0)(maximo).ToString()) Then
            val = Integer.Parse(dt.Rows(0)(maximo).ToString())
         End If
      End If

      Return val

   End Function

   Public Function GetCargosPorPeriodo(ByVal Periodo As Integer, ByVal IdSucursal As Integer, ByVal IdTipoLiquidacion As Integer) As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT * FROM LiquidacionesCargos")
         .AppendLine(" WHERE PeriodoLiquidacion = " & Periodo.ToString())
         .AppendLine(" AND IdSucursal = " & IdSucursal.ToString())
         .AppendLine(" AND IdTipoLiquidacion = " & IdTipoLiquidacion.ToString())

      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetTiposLiquidacion() As DataTable

      Dim myQuery As StringBuilder = New StringBuilder("")

      With myQuery
         .Length = 0
         .AppendLine("SELECT * FROM TiposLiquidaciones")
      End With

      Return Me.GetDataTable(myQuery.ToString())

   End Function

   Public Function GetFiltradoPorCodigo(IdCargo As Integer?, nombreCargo As String) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      Me.SelectTexto(stb)
      With stb
         .AppendLine(" WHERE AL.IdCargo > 0 ")
         If IdCargo.HasValue AndAlso IdCargo.Value > -1 Then
            .AppendFormat(" AND AL.{0} LIKE = {1}", Entidades.Cargo.Columnas.IdCargo.ToString(), IdCargo)
         End If
         If Not String.IsNullOrWhiteSpace(nombreCargo) Then
            .AppendFormat("   AND AL.{0} LIKE '%{1}%'", Entidades.Cargo.Columnas.NombreCargo.ToString(), nombreCargo)
         End If

         .AppendFormat(" ORDER BY AL.{0} ", Entidades.Cargo.Columnas.NombreCargo.ToString())
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

End Class

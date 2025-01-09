Public Class CuentasCorrientesAntiguedadesSaldosRangos
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesAntiguedadesSaldosRangos_I(idAntiguedadSaldoConfig As Integer,
                                                          diasDesde As Integer, diasHasta As Integer,
                                                          etiquetaColumna As String, orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CuentaCorrienteAntiguedadSaldoRangos.NombreTabla)
         .AppendFormatLine("        {0} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.IdAntiguedadSaldoConfig.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.DiasDesde.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.DiasHasta.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.EtiquetaColumna.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.Orden.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("        {0} ", idAntiguedadSaldoConfig)
         .AppendFormatLine("     ,  {0} ", diasDesde)
         .AppendFormatLine("     ,  {0} ", diasHasta)
         .AppendFormatLine("     , '{0}'", etiquetaColumna)
         .AppendFormatLine("     ,  {0} ", orden)
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CuentasCorrientesAntiguedadesSaldosRangos_U(idAntiguedadSaldoConfig As Integer,
                                                          diasDesde As Integer, diasHasta As Integer,
                                                          etiquetaColumna As String, orden As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CuentaCorrienteAntiguedadSaldoRangos.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.DiasHasta.ToString(), diasHasta)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.EtiquetaColumna.ToString(), etiquetaColumna)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.Orden.ToString(), orden)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.IdAntiguedadSaldoConfig.ToString(), idAntiguedadSaldoConfig)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.DiasDesde.ToString(), diasDesde)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CuentasCorrientesAntiguedadesSaldosRangos_D(idAntiguedadSaldoConfig As Integer, diasDesde As Integer?)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CuentaCorrienteAntiguedadSaldoRangos.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.IdAntiguedadSaldoConfig.ToString(), idAntiguedadSaldoConfig)
         If diasDesde.HasValue Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.DiasDesde.ToString(), diasDesde)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT ASR.*")
         .AppendFormatLine("  FROM {0} AS ASR", Entidades.CuentaCorrienteAntiguedadSaldoRangos.NombreTabla)
      End With
   End Sub

   Public Function CuentasCorrientesAntiguedadesSaldosRangos_G(idAntiguedadSaldoConfig As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idAntiguedadSaldoConfig <> 0 Then
            .AppendFormatLine("   AND ASR.{0} = {1} ", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.IdAntiguedadSaldoConfig.ToString(), idAntiguedadSaldoConfig)
         End If
         .AppendFormatLine(" ORDER BY ASR.{0}", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.Orden.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CuentasCorrientesAntiguedadesSaldosRangos_GA() As DataTable
      Return CuentasCorrientesAntiguedadesSaldosRangos_G(idAntiguedadSaldoConfig:=0)
   End Function

   Public Function CuentasCorrientesAntiguedadesSaldosRangos_GA(idAntiguedadSaldoConfig As Integer) As DataTable
      Return CuentasCorrientesAntiguedadesSaldosRangos_G(idAntiguedadSaldoConfig)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "ASR.")
   End Function

   Public Overloads Function GetOrdenMaximo(idAntiguedadSaldoConfig As Integer) As Integer
      Return GetCodigoMaximo(Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.Orden.ToString(), Entidades.CuentaCorrienteAntiguedadSaldoRangos.NombreTabla,
                             String.Format("{0} = {1}", Entidades.CuentaCorrienteAntiguedadSaldoRangos.Columnas.IdAntiguedadSaldoConfig.ToString(), idAntiguedadSaldoConfig)).ToInteger()
   End Function

End Class
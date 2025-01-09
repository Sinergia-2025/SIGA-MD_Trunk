Public Class CuentasCorrientesAntiguedadesSaldosConfig
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub CuentasCorrientesAntiguedadesSaldosConfig_I(idAntiguedadSaldoConfig As Integer, nombreAntiguedadSaldoConfig As String,
                                                          tipoAntiguedadSaldoConfig As Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo, porDefecto As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CuentaCorrienteAntiguedadSaldoConfig.NombreTabla)
         .AppendFormatLine("        {0} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.NombreAntiguedadSaldoConfig.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.TipoAntiguedadSaldoConfig.ToString())
         .AppendFormatLine("     ,  {0} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.PorDefecto.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("        {0} ", idAntiguedadSaldoConfig)
         .AppendFormatLine("     , '{0}'", nombreAntiguedadSaldoConfig)
         .AppendFormatLine("     , '{0}'", tipoAntiguedadSaldoConfig.ToString())
         .AppendFormatLine("     ,  {0} ", GetStringFromBoolean(porDefecto))
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub CuentasCorrientesAntiguedadesSaldosConfig_U(idAntiguedadSaldoConfig As Integer, nombreAntiguedadSaldoConfig As String,
                                                          tipoAntiguedadSaldoConfig As Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo, porDefecto As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.CuentaCorrienteAntiguedadSaldoConfig.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.NombreAntiguedadSaldoConfig.ToString(), nombreAntiguedadSaldoConfig)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.TipoAntiguedadSaldoConfig.ToString(), tipoAntiguedadSaldoConfig.ToString())
         .AppendFormatLine("     , {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto))
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString(), idAntiguedadSaldoConfig)
      End With
      Execute(myQuery)
   End Sub

   Public Sub CuentasCorrientesAntiguedadesSaldosConfig_D(idAntiguedadSaldoConfig As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CuentaCorrienteAntiguedadSaldoConfig.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString(), idAntiguedadSaldoConfig)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CCASC.*")
         .AppendFormatLine("  FROM {0} AS CCASC", Entidades.CuentaCorrienteAntiguedadSaldoConfig.NombreTabla)
      End With
   End Sub

   Public Function CuentasCorrientesAntiguedadesSaldosConfig_G(idAntiguedadSaldoConfig As Integer, idAntiguedadSaldoConfigCeroTodos As Boolean,
                                                               tipoAntiguedadSaldoConfig As Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo?,
                                                               porDefecto As Boolean?) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idAntiguedadSaldoConfig <> 0 OrElse Not idAntiguedadSaldoConfigCeroTodos Then
            .AppendFormatLine("   AND CCASC.{0} = {1} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString(), idAntiguedadSaldoConfig)
         End If
         If tipoAntiguedadSaldoConfig.HasValue Then
            .AppendFormatLine("   AND CCASC.{0} = '{1}'", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.TipoAntiguedadSaldoConfig.ToString(), tipoAntiguedadSaldoConfig.Value.ToString())
         End If
         If porDefecto.HasValue Then
            .AppendFormatLine("   AND CCASC.{0} = {1} ", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.PorDefecto.ToString(), GetStringFromBoolean(porDefecto.Value))
         End If
         .AppendFormatLine(" ORDER BY CCASC.{0}", Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.NombreAntiguedadSaldoConfig.ToString())
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function CuentasCorrientesAntiguedadesSaldosConfig_GA() As DataTable
      Return CuentasCorrientesAntiguedadesSaldosConfig_G(idAntiguedadSaldoConfig:=0, idAntiguedadSaldoConfigCeroTodos:=True, tipoAntiguedadSaldoConfig:=Nothing, porDefecto:=Nothing)
   End Function

   Public Function CuentasCorrientesAntiguedadesSaldosConfig_G1(idAntiguedadSaldoConfig As Integer) As DataTable
      Return CuentasCorrientesAntiguedadesSaldosConfig_G(idAntiguedadSaldoConfig, idAntiguedadSaldoConfigCeroTodos:=False, tipoAntiguedadSaldoConfig:=Nothing, porDefecto:=Nothing)
   End Function
   Public Function CuentasCorrientesAntiguedadesSaldosConfig_GA_TipoConceptoCM05(tipoAntiguedadSaldoConfig As Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo?) As DataTable
      Return CuentasCorrientesAntiguedadesSaldosConfig_G(idAntiguedadSaldoConfig:=0, idAntiguedadSaldoConfigCeroTodos:=True, tipoAntiguedadSaldoConfig, porDefecto:=Nothing)
   End Function
   Public Function CuentasCorrientesAntiguedadesSaldosConfig_GA_PorDefecto(tipoAntiguedadSaldoConfig As Entidades.CuentaCorrienteAntiguedadSaldoConfig.TipoAntiguedadSaldo?,
                                                                           porDefecto As Boolean) As DataTable
      Return CuentasCorrientesAntiguedadesSaldosConfig_G(idAntiguedadSaldoConfig:=0, idAntiguedadSaldoConfigCeroTodos:=True, tipoAntiguedadSaldoConfig, porDefecto)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "CCASC.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return GetCodigoMaximo(Entidades.CuentaCorrienteAntiguedadSaldoConfig.Columnas.IdAntiguedadSaldoConfig.ToString(), Entidades.CuentaCorrienteAntiguedadSaldoConfig.NombreTabla).ToInteger()
   End Function

End Class
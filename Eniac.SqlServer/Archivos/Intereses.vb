Public Class Intereses
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub Intereses_I(idInteres As Integer, nombreInteres As String,
                          adicionalProporcinalDias As Decimal, metodoParaDeterminarRango As String,
                          utilizaVigencia As Boolean, fechaVigenciaDesde As Date?, fechaVigenciaHasta As Date?,
                          vencimientoExcluyeSabado As Boolean, vencimientoExcluyeDomingo As Boolean, vencimientoExcluyeFeriados As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO Intereses (", Entidades.Interes.NombreTabla)
         .AppendFormatLine("         {0}", Entidades.Interes.Columnas.IdInteres.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.NombreInteres.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.AdicionalProporcinalDias.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.MetodoParaDeterminarRango.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.UtilizaVigencia.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.FechaVigenciaDesde.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.FechaVigenciaHasta.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.VencimientoExcluyeSabado.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.VencimientoExcluyeDomingo.ToString())
         .AppendFormatLine("      ,  {0}", Entidades.Interes.Columnas.VencimientoExcluyeFeriados.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("         {0} ", idInteres)
         .AppendFormatLine("      , '{0}'", nombreInteres)
         .AppendFormatLine("      ,  {0} ", adicionalProporcinalDias)
         .AppendFormatLine("      , '{0}'", metodoParaDeterminarRango)
         .AppendFormatLine("      , '{0}'", utilizaVigencia)
         .AppendFormatLine("      ,  {0} ", If(utilizaVigencia, ObtenerFecha(fechaVigenciaDesde, True), "NULL"))
         .AppendFormatLine("      ,  {0} ", If(utilizaVigencia, ObtenerFecha(fechaVigenciaHasta, True), "NULL"))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(vencimientoExcluyeSabado))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(vencimientoExcluyeDomingo))
         .AppendFormatLine("      ,  {0} ", GetStringFromBoolean(vencimientoExcluyeFeriados))
         .AppendFormatLine(" )")
      End With
      Execute(myQuery)
   End Sub

   Public Sub Intereses_U(idInteres As Integer, nombreInteres As String,
                          adicionalProporcinalDias As Decimal, metodoParaDeterminarRango As String,
                          utilizaVigencia As Boolean, fechaVigenciaDesde As Date?, fechaVigenciaHasta As Date?,
                          vencimientoExcluyeSabado As Boolean, vencimientoExcluyeDomingo As Boolean, vencimientoExcluyeFeriados As Boolean)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.Interes.NombreTabla)
         .AppendFormatLine("   SET {0} = '{1}'", Entidades.Interes.Columnas.NombreInteres.ToString(), nombreInteres)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Interes.Columnas.AdicionalProporcinalDias.ToString(), adicionalProporcinalDias)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Interes.Columnas.MetodoParaDeterminarRango.ToString(), metodoParaDeterminarRango)
         .AppendFormatLine("     , {0} = '{1}'", Entidades.Interes.Columnas.UtilizaVigencia.ToString(), utilizaVigencia)
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Interes.Columnas.FechaVigenciaDesde.ToString(), If(utilizaVigencia, ObtenerFecha(fechaVigenciaDesde, True), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Interes.Columnas.FechaVigenciaHasta.ToString(), If(utilizaVigencia, ObtenerFecha(fechaVigenciaHasta, True), "NULL"))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Interes.Columnas.VencimientoExcluyeSabado.ToString(), GetStringFromBoolean(vencimientoExcluyeSabado))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Interes.Columnas.VencimientoExcluyeDomingo.ToString(), GetStringFromBoolean(vencimientoExcluyeDomingo))
         .AppendFormatLine("     , {0} =  {1} ", Entidades.Interes.Columnas.VencimientoExcluyeFeriados.ToString(), GetStringFromBoolean(vencimientoExcluyeFeriados))
         .AppendFormatLine(" WHERE {0} =  {1}", Entidades.Interes.Columnas.IdInteres.ToString(), idInteres)
      End With
      Execute(myQuery)
   End Sub

   Public Sub Intereses_D(idInteres As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.Interes.NombreTabla)
         .AppendFormatLine(" WHERE {0} = {1}", Entidades.Interes.Columnas.IdInteres.ToString(), idInteres)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT I.*")
         .AppendFormatLine("  FROM {0} AS I", Entidades.Interes.NombreTabla)
      End With
   End Sub

   Public Function Intereses_G(idInteres As Integer, idInteresCeroTodos As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idInteres > 0 OrElse (idInteres = 0 And Not idInteresCeroTodos) Then
            .AppendFormatLine("   AND I.{0} = {1}", Entidades.Interes.Columnas.IdInteres.ToString(), idInteres)
         End If
         .AppendFormatLine(" ORDER BY I.NombreInteres")
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function Intereses_GA() As DataTable
      Return Intereses_G(idInteres:=0, idInteresCeroTodos:=True)
   End Function

   Public Function Intereses_G1(idInteres As Integer) As DataTable
      Return Intereses_G(idInteres, idInteresCeroTodos:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "I.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.Interes.Columnas.IdInteres.ToString(), Entidades.Interes.NombreTabla, String.Format("{0} <> 999", Entidades.Interes.Columnas.IdInteres.ToString())))
   End Function
End Class
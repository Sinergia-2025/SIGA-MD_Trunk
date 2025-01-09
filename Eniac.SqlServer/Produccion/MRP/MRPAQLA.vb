Imports Eniac.Entidades

Public Class MRPAQLA
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MRPAQLA_I(idMRPAQLA As Integer,
                        tamanoLoteDesde As Integer, tamanoLoteHasta As Integer,
                        nivelGeneral1 As String, nivelGeneral2 As String, nivelGeneral3 As String,
                        nivelEspecialS1 As String, nivelEspecialS2 As String, nivelEspecialS3 As String, nivelEspecialS4 As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.MRPAQLA.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.MRPAQLA.Columnas.IdMRPAQLA.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.TamanoLoteDesde.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.TamanoLoteHasta.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.NivelGeneral1.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.NivelGeneral2.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.NivelGeneral3.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.NivelEspecialS1.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.NivelEspecialS2.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.NivelEspecialS3.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLA.Columnas.NivelEspecialS4.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", idMRPAQLA)
         .AppendFormatLine("   ,  {0} ", tamanoLoteDesde)
         .AppendFormatLine("   ,  {0} ", tamanoLoteHasta)
         .AppendFormatLine("   , '{0}'", nivelGeneral1.ToUpper())
         .AppendFormatLine("   , '{0}'", nivelGeneral2.ToUpper())
         .AppendFormatLine("   , '{0}'", nivelGeneral3.ToUpper())
         .AppendFormatLine("   , '{0}'", nivelEspecialS1.ToUpper())
         .AppendFormatLine("   , '{0}'", nivelEspecialS2.ToUpper())
         .AppendFormatLine("   , '{0}'", nivelEspecialS3.ToUpper())
         .AppendFormatLine("   , '{0}'", nivelEspecialS4.ToUpper())
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub MRPAQLA_U(idMRPAQLA As Integer,
                        tamanoLoteDesde As Integer, tamanoLoteHasta As Integer,
                        nivelGeneral1 As String, nivelGeneral2 As String, nivelGeneral3 As String,
                        nivelEspecialS1 As String, nivelEspecialS2 As String, nivelEspecialS3 As String, nivelEspecialS4 As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.MRPAQLA.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.MRPAQLA.Columnas.TamanoLoteDesde.ToString(), tamanoLoteDesde)
         .AppendFormatLine("      ,{0} =  {1} ", Entidades.MRPAQLA.Columnas.TamanoLoteHasta.ToString(), tamanoLoteHasta)
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.MRPAQLA.Columnas.NivelGeneral1.ToString(), nivelGeneral1.ToUpper())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.MRPAQLA.Columnas.NivelGeneral2.ToString(), nivelGeneral2.ToUpper())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.MRPAQLA.Columnas.NivelGeneral3.ToString(), nivelGeneral3.ToUpper())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.MRPAQLA.Columnas.NivelEspecialS1.ToString(), nivelEspecialS1.ToUpper())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.MRPAQLA.Columnas.NivelEspecialS2.ToString(), nivelEspecialS2.ToUpper())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.MRPAQLA.Columnas.NivelEspecialS3.ToString(), nivelEspecialS3.ToUpper())
         .AppendFormatLine("      ,{0} = '{1}'", Entidades.MRPAQLA.Columnas.NivelEspecialS4.ToString(), nivelEspecialS4.ToUpper())
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.MRPAQLA.Columnas.IdMRPAQLA.ToString(), idMRPAQLA)
      End With
      Execute(myQuery)
   End Sub

   Public Sub MRPAQLA_D(idMRPAQLA As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0} WHERE {1} = {2}", Entidades.MRPAQLA.NombreTabla, Entidades.MRPAQLA.Columnas.IdMRPAQLA.ToString(), idMRPAQLA)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT AQLA.*")
         .AppendFormatLine("  FROM {0} AS AQLA", Entidades.MRPAQLA.NombreTabla)
      End With
   End Sub

   Private Function MRPAQLA_G(idMRPAQLA As Integer, idCeroTodos As Boolean) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If idMRPAQLA <> 0 Or idCeroTodos Then
            .AppendFormatLine("   AND AQLA.IdMRPAQLA = {0}", idMRPAQLA)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function MRPAQLA_G1(idMRPAQLA As Integer) As DataTable
      Return MRPAQLA_G(idMRPAQLA, idCeroTodos:=True)
   End Function
   Public Function MRPAQLA_GA() As DataTable
      Return MRPAQLA_G(idMRPAQLA:=0, idCeroTodos:=False)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "AQLA.")
   End Function

   Public Overloads Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.MRPAQLA.Columnas.IdMRPAQLA.ToString(), "MRPAQLA"))
   End Function

   Public Overloads Function ValidarRango(desde As Integer, hasta As Integer, idActual As Integer) As DataTable
      Return ValidarRango(desde, hasta,
                          Entidades.MRPAQLA.NombreTabla,
                          Entidades.MRPAQLA.Columnas.TamanoLoteDesde.ToString(), Entidades.MRPAQLA.Columnas.TamanoLoteHasta.ToString(),
                          String.Format("{0} <> {1}", Entidades.MRPAQLA.Columnas.IdMRPAQLA.ToString(), idActual))
   End Function

   Public Overloads Function GetCalidadOrdenCantidad(cantidad As Decimal) As DataTable

      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE TamanoLoteDesde <= {0} and TamanoLoteHasta >= {0}", cantidad)
      End With
      Return GetDataTable(myQuery)
   End Function

End Class
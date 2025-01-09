Public Class MRPAQLB
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub MRPAQLB_I(limiteCalidadAceptable As Decimal, codigoNivel As String,
                        tamanoMuestreo As Integer, cantidadAceptacion As Integer, cantidadRechazo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.MRPAQLB.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.MRPAQLB.Columnas.LimiteCalidadAceptable.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLB.Columnas.CodigoNivel.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLB.Columnas.TamanoMuestreo.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLB.Columnas.CantidadAceptacion.ToString())
         .AppendFormatLine("   , {0}", Entidades.MRPAQLB.Columnas.CantidadRechazo.ToString())
         .AppendFormatLine(" ) VALUES ( ")
         .AppendFormatLine("      {0} ", limiteCalidadAceptable)
         .AppendFormatLine("   , '{0}'", codigoNivel)
         .AppendFormatLine("   ,  {0} ", tamanoMuestreo)
         .AppendFormatLine("   ,  {0} ", cantidadAceptacion)
         .AppendFormatLine("   ,  {0} ", cantidadRechazo)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub MRPAQLB_U(limiteCalidadAceptable As Decimal, codigoNivel As String,
                        tamanoMuestreo As Integer, cantidadAceptacion As Integer, cantidadRechazo As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("UPDATE {0}", Entidades.MRPAQLB.NombreTabla)
         .AppendFormatLine("   SET {0} =  {1} ", Entidades.MRPAQLB.Columnas.TamanoMuestreo.ToString(), tamanoMuestreo)
         .AppendFormatLine("      ,{0} =  {1} ", Entidades.MRPAQLB.Columnas.CantidadAceptacion.ToString(), cantidadAceptacion)
         .AppendFormatLine("      ,{0} =  {1} ", Entidades.MRPAQLB.Columnas.CantidadRechazo.ToString(), cantidadRechazo)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.MRPAQLB.Columnas.LimiteCalidadAceptable.ToString(), limiteCalidadAceptable)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.MRPAQLB.Columnas.CodigoNivel.ToString(), codigoNivel)
      End With
      Execute(myQuery)
   End Sub

   Public Sub MRPAQLB_D(limiteCalidadAceptable As Decimal, codigoNivel As String)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormat("DELETE FROM {0}", Entidades.MRPAQLB.NombreTabla)
         .AppendFormat(" WHERE {0} =  {1} ", Entidades.MRPAQLB.Columnas.LimiteCalidadAceptable.ToString(), limiteCalidadAceptable)
         .AppendFormat("   AND {0} = '{1}'", Entidades.MRPAQLB.Columnas.CodigoNivel.ToString(), codigoNivel)
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT AQLB.*")
         .AppendFormatLine("  FROM {0} AS AQLB", Entidades.MRPAQLB.NombreTabla)
      End With
   End Sub

   Private Function MRPAQLB_G(limiteCalidadAceptable As Decimal, codigoNivel As String) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendFormatLine(" WHERE 1 = 1")
         If limiteCalidadAceptable <> 0 Then
            .AppendFormatLine("   AND AQLB.{0} = {1}", Entidades.MRPAQLB.Columnas.LimiteCalidadAceptable.ToString(), limiteCalidadAceptable)
         End If
         If Not String.IsNullOrWhiteSpace(codigoNivel) Then
            .AppendFormatLine("   AND AQLB.{0} = '{1}'", Entidades.MRPAQLB.Columnas.CodigoNivel.ToString(), codigoNivel)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function

   Public Function MRPAQLB_G1(limiteCalidadAceptable As Decimal, codigoNivel As String) As DataTable
      Return MRPAQLB_G(limiteCalidadAceptable, codigoNivel)
   End Function
   Public Function MRPAQLB_GA() As DataTable
      Return MRPAQLB_G(limiteCalidadAceptable:=0, codigoNivel:=String.Empty)
   End Function

   Public Overloads Function Buscar(columna As String, valor As String) As DataTable
      Return Buscar(columna, valor, Sub(stb) SelectTexto(stb), "AQLB.")
   End Function

End Class
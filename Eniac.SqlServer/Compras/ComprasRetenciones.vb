Public Class ComprasRetenciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ComprasRetenciones_I(idSucursal As Integer,
                                   idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                   idRetencion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("INSERT INTO {0} (", Entidades.CompraRetencion.NombreTabla)
         .AppendFormatLine("     {0}", Entidades.CompraRetencion.Columnas.IdSucursal.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraRetencion.Columnas.IdTipoComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraRetencion.Columnas.Letra.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraRetencion.Columnas.CentroEmisor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraRetencion.Columnas.NumeroComprobante.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraRetencion.Columnas.IdProveedor.ToString())
         .AppendFormatLine("   , {0}", Entidades.CompraRetencion.Columnas.IdRetencion.ToString())
         .AppendFormatLine(") VALUES (")
         .AppendFormatLine("	    {0} ", idSucursal)
         .AppendFormatLine("	 , '{0}'", idTipoComprobante)
         .AppendFormatLine("	 , '{0}'", letra)
         .AppendFormatLine("	 ,  {0} ", centroEmisor)
         .AppendFormatLine("	 ,  {0} ", numeroComprobante)
         .AppendFormatLine("	 ,  {0} ", idProveedor)
         .AppendFormatLine("	 ,  {0} ", idRetencion)
         .AppendFormatLine(")")
      End With
      Execute(myQuery)
   End Sub

   Public Sub ComprasRetenciones_U(idSucursal As Integer,
                                   idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                   idRetencion As Integer)
      Throw New NotImplementedException()
      'Dim myQuery = New StringBuilder()
      'With myQuery
      '   .AppendFormatLine("UPDATE {0}", Entidades.CompraRetencion.NombreTabla)
      '   .AppendFormatLine("   SET {0} = '{1}'", Entidades.CompraRetencion.Columnas.IdProveedor.ToString(), idProveedor)
      '   .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdSucursal.ToString(), idSucursal)
      '   .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraRetencion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
      '   .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraRetencion.Columnas.Letra.ToString(), letra)
      '   .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.CentroEmisor.ToString(), centroEmisor)
      '   .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.NumeroComprobante.ToString(), numeroComprobante)
      '   .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdProveedor.ToString(), idProveedor)
      '   .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdRetencion.ToString(), idRetencion)
      'End With
      'Execute(myQuery)
   End Sub

   Public Sub ComprasRetenciones_D(idSucursal As Integer,
                                   idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                   idRetencion As Integer)
      Dim myQuery = New StringBuilder()
      With myQuery
         .AppendFormatLine("DELETE FROM {0}", Entidades.CompraRetencion.NombreTabla)
         .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdSucursal.ToString(), idSucursal)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraRetencion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraRetencion.Columnas.Letra.ToString(), letra)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.CentroEmisor.ToString(), centroEmisor)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdProveedor.ToString(), idProveedor)
         If idRetencion <> 0 Then
            .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdRetencion.ToString(), idRetencion)
         End If
      End With
      Execute(myQuery)
   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendFormatLine("SELECT CR.*")
         .AppendFormatLine("  FROM ComprasRetenciones AS CR")
      End With
   End Sub

   Private Function ComprasRetenciones_G(idSucursal As Integer,
                                         idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                         idRetencion As Integer) As DataTable
      Dim myQuery = New StringBuilder()
      With myQuery
         SelectTexto(myQuery)
         .AppendLine(" WHERE 1 = 1")
         If idSucursal <> 0 Then
            .AppendFormatLine("   AND CR.{0} =  {1} ", Entidades.CompraRetencion.Columnas.IdSucursal.ToString(), idSucursal)
         End If
         If Not String.IsNullOrWhiteSpace(idTipoComprobante) Then
            .AppendFormatLine("   AND CR.{0} = '{1}'", Entidades.CompraRetencion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
         End If
         If Not String.IsNullOrWhiteSpace(letra) Then
            .AppendFormatLine("   AND CR.{0} = '{1}'", Entidades.CompraRetencion.Columnas.Letra.ToString(), letra)
         End If
         If centroEmisor <> 0 Then
            .AppendFormatLine("   AND CR.{0} =  {1} ", Entidades.CompraRetencion.Columnas.CentroEmisor.ToString(), centroEmisor)
         End If
         If numeroComprobante <> 0 Then
            .AppendFormatLine("   AND CR.{0} =  {1} ", Entidades.CompraRetencion.Columnas.NumeroComprobante.ToString(), numeroComprobante)
         End If
         If idProveedor <> 0 Then
            .AppendFormatLine("   AND CR.{0} =  {1} ", Entidades.CompraRetencion.Columnas.IdProveedor.ToString(), idProveedor)
         End If
         If idRetencion <> 0 Then
            .AppendFormatLine("   AND CR.{0} =  {1} ", Entidades.CompraRetencion.Columnas.IdRetencion.ToString(), idRetencion)
         End If
      End With
      Return GetDataTable(myQuery)
   End Function
   Public Function ComprasRetenciones_GA() As DataTable
      Return ComprasRetenciones_G(idSucursal:=0,
                                  idTipoComprobante:=String.Empty, letra:=String.Empty, centroEmisor:=0, numeroComprobante:=0, idProveedor:=0,
                                  idRetencion:=0)
   End Function
   Public Function ComprasRetenciones_GA(idSucursal As Integer,
                                         idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long,
                                         idProveedor As Long) As DataTable
      Return ComprasRetenciones_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor,
                                  idRetencion:=0)
   End Function
   Public Function ComprasRetenciones_G1(idSucursal As Integer,
                                         idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
                                         idRetencion As Integer) As DataTable
      Return ComprasRetenciones_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante, idProveedor, idRetencion)
   End Function

   'Public Overloads Function GetOrdenMaximo(idSucursal As Integer,
   '                                         idTipoComprobante As String, letra As String, centroEmisor As Integer, numeroComprobante As Long, idProveedor As Long,
   '                                         idRetencion As Integer) As Integer
   '   Dim myQuery = New StringBuilder()
   '   With myQuery
   '      .AppendFormatLine(" WHERE {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdSucursal.ToString(), idSucursal)
   '      .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraRetencion.Columnas.IdTipoComprobante.ToString(), idTipoComprobante)
   '      .AppendFormatLine("   AND {0} = '{1}'", Entidades.CompraRetencion.Columnas.Letra.ToString(), letra)
   '      .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.CentroEmisor.ToString(), centroEmisor)
   '      .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.NumeroComprobante.ToString(), numeroComprobante)
   '      .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdProveedor.ToString(), idProveedor)
   '      .AppendFormatLine("   AND {0} =  {1} ", Entidades.CompraRetencion.Columnas.IdRetencion.ToString(), idRetencion)
   '   End With
   '   Return GetCodigoMaximo(Entidades.CompraRetencion.Columnas.Orden.ToString(), Entidades.CompraRetencion.NombreTabla, myQuery.ToString()).ToInteger()
   'End Function

End Class
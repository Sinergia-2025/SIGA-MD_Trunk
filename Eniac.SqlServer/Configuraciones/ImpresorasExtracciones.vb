Public Class ImpresorasExtracciones
   Inherits Comunes

   Public Sub New(da As Datos.DataAccess)
      MyBase.New(da)
   End Sub

   Public Sub ImpresorasExtracciones_I(idSucursal As Integer,
                                       idImpresora As String,
                                       secuencia As Integer,
                                       zetaDesde As Long,
                                       zetaHasta As Long,
                                       fechaExtraccionDesde As Date,
                                       fechaExtraccionHasta As Date,
                                       fechaExtraccion As Date,
                                       idUsuarioExtraccion As String,
                                       nombreArchivo As String,
                                       md5Archivo As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("INSERT INTO ImpresorasExtracciones (")
         .AppendFormatLine("    IdSucursal")
         .AppendFormatLine("   ,IdImpresora")
         .AppendFormatLine("   ,Secuencia")
         .AppendFormatLine("   ,ZetaDesde")
         .AppendFormatLine("   ,ZetaHasta")
         .AppendFormatLine("   ,FechaExtraccionDesde")
         .AppendFormatLine("   ,FechaExtraccionHasta")
         .AppendFormatLine("   ,FechaExtraccion")
         .AppendFormatLine("   ,IdUsuarioExtraccion")
         .AppendFormatLine("   ,NombreArchivo")
         .AppendFormatLine("   ,MD5Archivo")

         .AppendFormatLine(" ) VALUES (")

         .AppendFormatLine("     {0} ", idSucursal)
         .AppendFormatLine("   ,'{0}'", idImpresora)
         .AppendFormatLine("   , {0} ", secuencia)

         .AppendFormatLine("   , {0} ", zetaDesde)
         .AppendFormatLine("   , {0} ", zetaHasta)
         .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaExtraccionDesde, False))
         .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaExtraccionHasta, False))

         .AppendFormatLine("   ,'{0}'", ObtenerFecha(fechaExtraccion, False))
         .AppendFormatLine("   ,'{0}'", idUsuarioExtraccion)

         .AppendFormatLine("   ,'{0}'", nombreArchivo)
         .AppendFormatLine("   ,'{0}'", md5Archivo)

         .Append(" )")
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub ImpresorasExtracciones_U(idSucursal As Integer,
                                       idImpresora As String,
                                       secuencia As Integer,
                                       zetaDesde As Long,
                                       zetaHasta As Long,
                                       fechaExtraccionDesde As Date,
                                       fechaExtraccionHasta As Date,
                                       fechaExtraccion As Date,
                                       idUsuarioExtraccion As String,
                                       nombreArchivo As String,
                                       md5Archivo As String)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("UPDATE ImpresorasExtracciones")
         .AppendFormatLine("   SET ZetaDesde = {0}", zetaDesde)
         .AppendFormatLine("      ,ZetaHasta = {0}", zetaHasta)
         .AppendFormatLine("      ,FechaExtraccionDesde = '{0}'", ObtenerFecha(fechaExtraccionDesde, False))
         .AppendFormatLine("      ,FechaExtraccionHasta = '{0}'", ObtenerFecha(fechaExtraccionHasta, False))

         .AppendFormatLine("      ,FechaExtraccion     = '{0}'", ObtenerFecha(fechaExtraccion, False))
         .AppendFormatLine("      ,IdUsuarioExtraccion = '{0}'", idUsuarioExtraccion)
         .AppendFormatLine("      ,NombreArchivo       = '{0}'", nombreArchivo)
         .AppendFormatLine("      ,MD5Archivo          = '{0}'", md5Archivo)

         .AppendFormatLine(" WHERE IdSucursal  =  {0} ", idSucursal)
         .AppendFormatLine("   AND IdImpresora = '{0}'", idImpresora)
         .AppendFormatLine("   AND Secuencia   =  {0} ", secuencia)
      End With

      Me.Execute(stb.ToString())

   End Sub

   Public Sub ImpresorasExtracciones_D(idSucursal As Integer, idImpresora As String, secuencia As Integer)
      Dim stb = New StringBuilder()
      With stb
         .AppendFormatLine("DELETE FROM ImpresorasExtracciones")
         .AppendFormatLine("  WHERE IdSucursal = {0}", idSucursal)
         If Not String.IsNullOrWhiteSpace(idImpresora) Then
            .AppendFormatLine("    AND IdImpresora = '{0}'", idImpresora)
         End If
         If secuencia > 0 Then
            .AppendFormatLine("    AND Secuencia = {0}", secuencia)
         End If
      End With

      Me.Execute(stb.ToString())

   End Sub

   Private Sub SelectTexto(stb As StringBuilder)
      With stb
         .AppendLine("SELECT IE.*")
         .AppendLine("  FROM ImpresorasExtracciones IE")
      End With
   End Sub

   Public Function ImpresorasExtracciones_GA(idSucursal As Integer) As DataTable
      Return ImpresorasExtracciones_GA(idSucursal, idImpresora:=Nothing, secuencia:=0)
   End Function
   Public Function ImpresorasExtracciones_GA(idSucursal As Integer, idImpresora As String) As DataTable
      Return ImpresorasExtracciones_GA(idSucursal, idImpresora, secuencia:=0)
   End Function

   Private Function ImpresorasExtracciones_GA(idSucursal As Integer, idImpresora As String, secuencia As Integer) As DataTable
      Dim stb = New StringBuilder()
      Me.SelectTexto(stb)
      With stb
         .AppendFormatLine(" WHERE IE.IdSucursal = {0}", idSucursal)
         If Not String.IsNullOrWhiteSpace(idImpresora) Then
            .AppendFormatLine("   AND IE.IdImpresora = '{0}'", idImpresora)
         End If
         If secuencia <> 0 Then
            .AppendFormatLine("   AND IE.Secuencia = {0}", secuencia)
         End If
         .AppendFormatLine(" ORDER BY IE.IdSucursal, IE.IdImpresora, IE.ZetaDesde")
      End With
      Return Me.GetDataTable(stb)
   End Function

   Public Function ImpresorasExtracciones_G1(idSucursal As Integer, idImpresora As String, secuencia As Integer) As DataTable
      Return ImpresorasExtracciones_GA(idSucursal, idImpresora, secuencia)
   End Function

   Public Function Buscar(columna As String, valor As String) As DataTable
      'If columna = "NombreLocalidadCentroEmisor" Then
      '   columna = "L.NombreLocalidad"
      'Else
      columna = "IE." + columna
      'End If
      Dim stb = New StringBuilder()
      Me.SelectTexto(stb)
      With stb
         .AppendFormatLine(FormatoBuscar, columna, valor)
      End With
      Return Me.GetDataTable(stb.ToString())
   End Function

   Public Overloads Function GetCodigoMaximo(idSucursal As Integer, idImpresora As String) As Integer
      Return Convert.ToInt32(GetCodigoMaximo(Entidades.ImpresoraExtraccion.Columnas.Secuencia.ToString(), Entidades.ImpresoraExtraccion.NombreTabla,
                                             String.Format("{0} = {1} AND {2} = '{3}'",
                                                           Entidades.ImpresoraExtraccion.Columnas.IdSucursal.ToString(), idSucursal,
                                                           Entidades.ImpresoraExtraccion.Columnas.IdImpresora.ToString(), idImpresora)))
   End Function

End Class
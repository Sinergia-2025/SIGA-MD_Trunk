Imports Eniac.Entidades
Imports Eniac.Entidades.JSonEntidades

Partial Class Productos

   Public Function GetOrdenProductos(activos As Boolean?) As DataTable
      Return New SqlServer.Productos(da).GetOrdenProductos(activos)
   End Function

   Public Function GetPorNombre(nombreProducto As String) As DataTable
      Return New SqlServer.Productos(da).Productos_G_PorNombre(nombreProducto)
   End Function

   Public Function GetPorCodigoBarra(CodigoBarra As String) As DataTable
      Return New SqlServer.Productos(da).Productos_G_PorCodigoBarra(CodigoBarra)
   End Function

   Public Sub ExportarImagenes(idProductos As List(Of String))
      Try
         da.OpenConection()
         Dim sql As SqlServer.Productos = New SqlServer.Productos(da)
         Dim registrosPorPagina As Integer = 50

         Dim carpetaImagenes As String = IO.Path.Combine(Entidades.Publicos.CarpetaEniac, "ImagenesWeb")
         If Not IO.Directory.Exists(carpetaImagenes) Then
            IO.Directory.CreateDirectory(carpetaImagenes)
         End If
         Dim posicion As Integer = 0
         While posicion < idProductos.Count
            Dim pagina(Math.Min(idProductos.Count - posicion, registrosPorPagina)) As String
            idProductos.CopyTo(posicion, pagina, 0, Math.Min(idProductos.Count - posicion, registrosPorPagina))

            For Each dr As DataRow In sql.GetFotos(pagina).Rows
               If Not String.IsNullOrWhiteSpace(dr("Foto").ToString()) Then
                  GrabarImagen(dr("IdProducto").ToString(), DirectCast(dr("Foto"), Byte()), 1, carpetaImagenes)
               End If
               If Not String.IsNullOrWhiteSpace(dr("Foto2").ToString()) Then
                  GrabarImagen(dr("IdProducto").ToString(), DirectCast(dr("Foto2"), Byte()), 2, carpetaImagenes)
               End If
               If Not String.IsNullOrWhiteSpace(dr("Foto3").ToString()) Then
                  GrabarImagen(dr("IdProducto").ToString(), DirectCast(dr("Foto3"), Byte()), 3, carpetaImagenes)
               End If
            Next

            posicion += registrosPorPagina
         End While

      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub GrabarImagen(idProducto As String, imagen As Byte(), orden As Integer, carpetaImagenes As String)
      Using ms As New IO.MemoryStream(imagen)
         Dim returnImage As Drawing.Image = Drawing.Image.FromStream(ms)
         Dim mime As String = returnImage.MimeType()
         Dim extension As String
         Select Case mime
            Case "image/jpeg"
               extension = "jpg"
            Case "image/png"
               extension = "png"
            Case Else
               extension = "jpg"
         End Select
         Dim nombreArchivo As String = IO.Path.Combine(carpetaImagenes, String.Format("{0}{2}.{1}",
                                                                                      Publicos.NormalizarNombreArchivo(idProducto),
                                                                                      extension,
                                                                                      If(orden < 2, "", If(orden = 2, "_2", "_3"))))
         IO.File.WriteAllBytes(nombreArchivo, imagen)
      End Using
   End Sub


   Private Function PaginarDatos(Of T)(datos As List(Of T), registrosPorPagina As Integer) As List(Of T())
      Dim result As List(Of T()) = New List(Of T())
      Dim posicion As Integer = 0
      While posicion < datos.Count
         Dim pagina(Math.Min(datos.Count - posicion, registrosPorPagina) - 1) As T
         datos.CopyTo(posicion, pagina, 0, Math.Min(datos.Count - posicion, registrosPorPagina))
         result.Add(pagina)
         posicion += registrosPorPagina
      End While
      Return result
   End Function

   Public Class CodigoBarras
      Public Shared Function GetValorSegunModalidad(codigoBarrasCompleto As String, modalidad As Entidades.Producto.Modalidades) As Decimal
         Select Case modalidad
            Case Producto.Modalidades.PESO
               Return GetValorPesoPrecio(codigoBarrasCompleto, 3)
            Case Producto.Modalidades.PRECIO
               Return GetValorPesoPrecio(codigoBarrasCompleto, 2)
            Case Else
               Return 0
         End Select
      End Function

      Public Shared Function GetValorPesoPrecio(codigoBarrasCompleto As String, cantidadDecimales As Integer) As Decimal
         Const posicionInicialPrecioPeso As Integer = 7
         Const tamanioPrecioPeso As Integer = 5

         Dim posicionParaPunto As Integer = tamanioPrecioPeso - cantidadDecimales

         If codigoBarrasCompleto.Length = 13 Then
            Return Decimal.Parse(codigoBarrasCompleto.Substring(posicionInicialPrecioPeso, tamanioPrecioPeso).Insert(posicionParaPunto, "."c))
         Else
            Return 0
         End If
      End Function
   End Class
End Class
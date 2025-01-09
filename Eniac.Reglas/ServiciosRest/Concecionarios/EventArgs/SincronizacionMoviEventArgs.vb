Namespace ServiciosRest.Concesionarios
   Public Class SincronizacionMovilEventArgs
      Inherits EventArgs
      Public Sub New(tienda As Entidades.TiendasWeb, mensaje As String)
         Me.Mensaje = mensaje
         Me.Tienda = tienda
      End Sub
      Public Sub New(tienda As Entidades.TiendasWeb, mensaje As String, metodo As String, url As Uri)
         Me.New(tienda, mensaje)
         Me.Metodo = metodo
         Me.Url = url
      End Sub
      Public Sub New(tienda As Entidades.TiendasWeb, mensaje As String, metodo As String, url As Uri, tabla As SincroMovilMetodos, totalRegistrosSubidos As Long)
         Me.New(tienda, mensaje, metodo, url, tabla, totalRegistrosSubidos, nombre:=String.Empty)
      End Sub
      Public Sub New(tienda As Entidades.TiendasWeb, mensaje As String, metodo As String, url As Uri, tabla As SincroMovilMetodos, totalRegistrosSubidos As Long, nombre As String)
         Me.New(tienda, mensaje, metodo, url)
         Me.Tabla = tabla
         Me.TotalRegistrosSubidos = totalRegistrosSubidos
         Me.Nombre = nombre
      End Sub

      Public Property Tienda As Entidades.TiendasWeb
      Public Property Mensaje As String
      Public Property Metodo As String
      Public Property Url As Uri
      Public Property Tabla As SincroMovilMetodos
      Public Property TotalRegistrosSubidos As Long
      Public Property Nombre As String

   End Class
   Public Enum SincroMovilMetodos
      [GET]
      POST
      PUT
      PATCH
   End Enum

End Namespace
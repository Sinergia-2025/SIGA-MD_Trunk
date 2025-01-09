Option Strict On
Option Explicit On
Public Interface IReglaAdjuntos
   Function GetOClonar(entidadOriginal As Entidades.IAdjunto) As Entidades.IAdjunto
   Function GetUno(entidadOriginal As Entidades.IAdjunto, incluirAdjunto As Boolean) As Entidades.IAdjunto
End Interface
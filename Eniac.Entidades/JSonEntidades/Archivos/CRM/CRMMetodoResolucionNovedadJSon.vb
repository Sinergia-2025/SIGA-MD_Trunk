﻿Imports System.ComponentModel

Namespace JSonEntidades.Archivos.CRM
   Public Class CRMMetodoResolucionNovedadJSon
      Inherits Entidades.CRMMetodoResolucionNovedad
      Implements IValidable

      Public Property ConErrores As Boolean Implements IValidable.ConErrores
      Public Property ___Estado As String Implements IValidable.___Estado
      Public Property ___MensajeError As String Implements IValidable.___MensajeError

      Public Property drOrigen As DataRow Implements IValidable.drOrigen
   End Class

   Public Class CRMMetodoResolucionNovedadJSonTransporte
      Public Property CuitEmpresa As String
      Public Property IdMetodoResolucionNovedad As Integer
      Public Property Datos As String
      Public Property FechaActualizacion As String

      Public Sub New()
      End Sub

      Public Sub New(cuitEmpresa As String, idMetodoResolucionNovedad As Integer, fechaActualizacion As String)
         Me.CuitEmpresa = cuitEmpresa
         Me.IdMetodoResolucionNovedad = idMetodoResolucionNovedad
         Me.FechaActualizacion = fechaActualizacion
      End Sub

   End Class

End Namespace
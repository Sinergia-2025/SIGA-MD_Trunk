﻿Namespace ServiciosRest.Concesionarios
   Public Class SincronizacionMovilEstadoEventArgs
      Inherits EventArgs
      Public Sub New(concesionario As Entidades.ConcesionarioMovil, estado As SincroMovilEstados, metodo As SincroMovilMetodos, totalRegistros As Long, totalRegistrosSubidos As Long)
         Me.New(concesionario, estado, metodo, totalRegistros, totalRegistrosSubidos, nombre:=String.Empty, 0, 0)
      End Sub
      Public Sub New(concesionario As Entidades.ConcesionarioMovil, estado As SincroMovilEstados, metodo As SincroMovilMetodos, totalRegistros As Long, totalRegistrosSubidos As Long, nombre As String,
                     countExitoso As Integer, countError As Integer)
         Me.Concesionario = concesionario
         Me.Estado = estado
         Me.Metodo = metodo
         Me.TotalRegistros = totalRegistros
         Me.TotalRegistrosSubidos = totalRegistrosSubidos
         Me.Nombre = nombre
         TotalRegistrosExitosos = countExitoso
         TotalRegistrosError = countError
      End Sub
      Public Property Concesionario As Entidades.ConcesionarioMovil
      Public Property Estado As SincroMovilEstados
      Public Property Metodo As SincroMovilMetodos
      Public Property Nombre As String
      Public Property TotalRegistros As Long
      Public Property TotalRegistrosSubidos As Long
      Public Property TotalRegistrosExitosos As Long
      Public Property TotalRegistrosError As Long

   End Class
   Public Enum SincroMovilEstados
      Iniciando
      Importando
      Subiendo
      Bajando
      Finalizado
      [Error]
   End Enum
End Namespace
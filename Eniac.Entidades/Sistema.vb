<Serializable()>
Public Class Sistema
   Inherits Entidad

   ''' <summary>Nombre de la empresa encriptado en la Licencia. Entrada 1 de la licencia</summary>
   Public Property NombreEmpresa As String = String.Empty
   ''' <summary>Fecha de vencimiento de la Licencia. Entrada 0 de la licencia</summary>
   Public Property FechaVencimiento As Date
   ''' <summary>Indica si la Licencia está habilitada (no está vencida)</summary>
   Public Property Habilitado As Boolean
   ''' <summary>Indica si se debe avisar al usuario que la licencia está por vencer</summary>
   Public Property AvisarAlCliente As Boolean
   ''' <summary>La clave de Licencia encriptada</summary>
   Public Property ClaveActual As String
   ''' <summary>Cantidad de empresas contratadas para esta Licencia. Entrada 2 de la licencia</summary>
   Public Property CantidadEmpresasContratadas As Integer

   Public Property CantidadDepositosTipoOperativo As Integer = 1
   Public Property CantidadDepositosTipoReserva As Integer = 1
   Public Property CantidadDepositosTipoEnTransito As Integer = 0
   Public Property CantidadDepositosTipoDefectuoso As Integer = 0

   ''' <summary>Cantidad de usuarios contratados para esta Licencia. Entrada 4 de la licencia</summary>
   Public Property CantidadUsuariosContratados As Integer


   Public Sub ControlaValidezDeFecha(fecha As DateTime)
      If DateDiff(DateInterval.Day, fecha, FechaVencimiento) < 0 Then
         Throw New Exception(String.Format("La fecha es mayor a la validez del sistema, el {0:dd/MM/yyyy}", FechaVencimiento))
      End If
   End Sub


   'Public Sub ControlaValidezDeFecha(fecha As Date)
   '   If DateDiff(DateInterval.Day, fecha, FechaVencimiento) < 0 Then
   '      Throw New Exception(String.Format("La fecha es mayor a la validez del sistema, el {0:dd/MM/yyyy}", FechaVencimiento))
   '   End If
   'End Sub

End Class
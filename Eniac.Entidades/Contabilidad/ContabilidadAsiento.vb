<Serializable()>
<Description("ContabilidadAsiento")>
Public Class ContabilidadAsiento
   Inherits Entidad

   Public Enum Columnas
      IdPlanCuenta
      NombrePlanCuenta
      IdAsiento
      NombreAsiento
      FechaAsiento
      IdTipoDoc
      IdEjercicio
      DetallesAsiento
      idSucursal
      NombreSucursal
      SubsiAsiento
      EsManual
      FechaExportacion
      IdEstadoAsiento
      TipoAsiento
   End Enum

   Public Enum TiposAsiento
      NORMAL
      AJUSTEPORINFLACION
      REFUNDICIONDERESULTADOS
      CIERREDEPATRIMONIO
      APERTURADEEJERCICIO
   End Enum

   Public Sub New()
      SubsiAsiento = String.Empty
   End Sub
   Public Sub New(esManual As Boolean, subsistema As ContabilidadProceso.Procesos)
      Me.New()
      _EsManual = esManual
      _SubsiAsiento = subsistema.ToString()
   End Sub

   'Public Overloads Property idSucursal As Integer
   Public Property IdPlanCuenta As Integer
   Public Property IdAsiento As Integer
   Public Property NombreAsiento As String
   Public Property FechaAsiento As Date
   Public Property IdTipoDoc As Integer
   Public Property IdEjercicio As Integer
   Public Property IdEjercicioNuevo As Integer     'Nuevo IdEjercicio si se cambia en pantalla.
   Public Property SubsiAsiento As String
   Public Property EsManual As Boolean
   Public Property FechaExportacion As Date
   Public Property IdEstadoAsiento As Integer
   Public Property DetallesAsiento As DataTable
   Public Property TipoAsiento As String

End Class
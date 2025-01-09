#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class SucursalesUbicacionesEstadosABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SucursalesUbicacionesEstadosDetalle(DirectCast(Me.GetEntidad(), Entidades.SucursalUbicacionEstado))
      End If
      Return New SucursalesUbicacionesEstadosDetalle(New Entidades.SucursalUbicacionEstado)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.SucursalesUbicacionesEstados()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim estadoUbicacion = New Entidades.SucursalUbicacionEstado
      With Me.dgvDatos.ActiveRow
         estadoUbicacion = New Reglas.SucursalesUbicacionesEstados().GetUno(Integer.Parse(.Cells("IdEstado").Value.ToString()))
      End With
      Return estadoUbicacion
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.SucursalUbicacionEstado.Columnas.IdEstado.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.SucursalUbicacionEstado.Columnas.NombreEstado.ToString()).FormatearColumna("Nombre Estado", col, 200)
         .Columns(Entidades.SucursalUbicacionEstado.Columnas.OrdenEstado.ToString()).FormatearColumna("Orden", col, 80, HAlign.Right)
         .Columns(Entidades.SucursalUbicacionEstado.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 80)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.SucursalUbicacionEstado.Columnas.NombreEstado.ToString()})
   End Sub

#End Region
End Class
#Region "Option"
Option Strict On
Option Explicit On
#End Region

Public Class MRPNormasFabricacionABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPNormasFabricacionDetalle(DirectCast(Me.GetEntidad(), Entidades.MRPNormaFabricacion))
      End If
      Return New MRPNormasFabricacionDetalle(New Entidades.MRPNormaFabricacion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPNormasFabricacion()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim eSeccion = New Entidades.MRPNormaFabricacion
      With Me.dgvDatos.ActiveRow
         eSeccion = New Reglas.MRPNormasFabricacion().GetUno(Integer.Parse(.Cells("IdNormaFab").Value.ToString()))
      End With
      Return eSeccion
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.MRPNormaFabricacion.Columnas.IdNormaFab.ToString()).FormatearColumna("idCódigo", col, 80,, True)
         .Columns(Entidades.MRPNormaFabricacion.Columnas.CodigoNormaFab.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.MRPNormaFabricacion.Columnas.Descripcion.ToString()).FormatearColumna("Descripcion", col, 400)
         .Columns(Entidades.MRPNormaFabricacion.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 60)
         .Columns(Entidades.MRPNormaFabricacion.Columnas.DetalleDispositivos.ToString()).FormatearColumna("Dispositivos", col, 400)
         .Columns(Entidades.MRPNormaFabricacion.Columnas.DetalleMetodos.ToString()).FormatearColumna("Metodos", col, 400)
         .Columns(Entidades.MRPNormaFabricacion.Columnas.DetalleSeguridad.ToString()).FormatearColumna("Seguridad", col, 400)
         .Columns(Entidades.MRPNormaFabricacion.Columnas.DetalleControlCalidad.ToString()).FormatearColumna("ControlCalidad", col, 400)
      End With
      '-- Agrega Filtros.- ---
      dgvDatos.AgregarFiltroEnLinea({"CodigoNormaFab", "Descripcion", "DetalleDispositivos", "DetalleMetodos", "DetalleSeguridad", "DetalleControlCalidad"})
   End Sub
#End Region
End Class
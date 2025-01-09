Public Class MRPConceptosNoProductivosABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MRPConceptosNoProductivosDetalle(DirectCast(GetEntidad(), Entidades.MRPConceptoNoProductivo))
      End If
      Return New MRPConceptosNoProductivosDetalle(New Entidades.MRPConceptoNoProductivo())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MRPConceptosNoProductivos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.MRPConceptosNoProductivos().GetUno(dr.Field(Of Integer)(Entidades.MRPConceptoNoProductivo.Columnas.IdConceptoNoProductivo.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         Dim col = 0I
         .Columns(Entidades.MRPConceptoNoProductivo.Columnas.IdConceptoNoProductivo.ToString()).FormatearColumna("Id", col, 80, HAlign.Right, True)
         .Columns(Entidades.MRPConceptoNoProductivo.Columnas.CodigoConceptoNoProductivo.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.MRPConceptoNoProductivo.Columnas.NombreConceptoNoProductivo.ToString()).FormatearColumna("Descripción", col, 200)
         .Columns(Entidades.MRPConceptoNoProductivo.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 60)
      End With
      '-- Agrega Filtros.- ---
      dgvDatos.AgregarFiltroEnLinea({Entidades.MRPConceptoNoProductivo.Columnas.NombreConceptoNoProductivo.ToString()})
   End Sub
#End Region
End Class
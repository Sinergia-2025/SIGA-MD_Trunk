Public Class MarcasEmbarcacionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MarcasEmbarcacionesDetalle(DirectCast(GetEntidad(), Entidades.MarcaEmbarcacion))
      End If
      Return New MarcasEmbarcacionesDetalle(New Entidades.MarcaEmbarcacion())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.MarcasEmbarcaciones()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.MarcasEmbarcaciones().GetUno(dr.Field(Of Integer)(Entidades.MarcaEmbarcacion.Columnas.IdMarcaEmbarcacion.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.MarcaEmbarcacion.Columnas.IdMarcaEmbarcacion.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.MarcaEmbarcacion.Columnas.NombreMarcaEmbarcacion.ToString()).FormatearColumna("Nombre", pos, 250)
      End With
   End Sub

#End Region

End Class
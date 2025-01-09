Public Class ModelosEmbarcacionesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ModelosEmbarcacionesDetalle(DirectCast(GetEntidad(), Entidades.ModeloEmbarcacion))
      End If
      Return New ModelosEmbarcacionesDetalle(New Entidades.ModeloEmbarcacion)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ModelosEmbarcaciones()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)
      Return New Reglas.ModelosEmbarcaciones().GetUno(dr.Field(Of Integer)(Entidades.ModeloEmbarcacion.Columnas.IdModeloEmbarcacion.ToString()))
   End Function

   Protected Overrides Sub FormatearGrilla()
      Dim pos = 0I
      With dgvDatos.DisplayLayout.Bands(0)
         .Columns(Entidades.ModeloEmbarcacion.Columnas.IdModeloEmbarcacion.ToString()).FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns(Entidades.ModeloEmbarcacion.Columnas.NombreModeloEmbarcacion.ToString()).FormatearColumna("Nombre", pos, 250)
         .Columns(Entidades.ModeloEmbarcacion.Columnas.IdMarcaEmbarcacion.ToString()).OcultoPosicion(hidden:=True, pos)
         .Columns(Entidades.ModeloEmbarcacion.Columnas.NombreMarcaEmbarcacion.ToString()).FormatearColumna("Marca", pos, 250)
      End With
   End Sub

#End Region

End Class
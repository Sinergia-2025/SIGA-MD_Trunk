Public Class AFIPConceptosCM05ABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AFIPConceptosCM05Detalle(DirectCast(GetEntidad(), Entidades.AFIPConceptoCM05))
      End If
      Return New AFIPConceptosCM05Detalle(New Entidades.AFIPConceptoCM05())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AFIPConceptosCM05()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.AFIPConceptosCM05().GetUno(Integer.Parse(.Cells(Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         For Each col As UltraGridColumn In .Columns
            col.CellActivation = Activation.ActivateOnly
         Next
         Dim pos = 0I
         .Columns(Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString()).FormatearColumna("Código", pos, 80, HAlign.Right)
         .Columns(Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString()).FormatearColumna("Nombre", pos, 300)
         .Columns(Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString()).FormatearColumna("Tipo Concepto", pos, 100, HAlign.Center)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString()})
   End Sub

#End Region

End Class
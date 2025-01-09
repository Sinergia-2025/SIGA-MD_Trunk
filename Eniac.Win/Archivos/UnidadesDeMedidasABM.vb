Public Class UnidadesDeMedidasABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New UnidadesDeMedidasDetalle(DirectCast(Me.GetEntidad(), Entidades.UnidadDeMedida))
      End If
      Return New UnidadesDeMedidasDetalle(New Entidades.UnidadDeMedida())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.UnidadesDeMedidas()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
      Sub()
         Dim frmImprime = New VisorReportes("Eniac.Win.UnidadesDeMedidas.rdlc", "SistemaDataSet_UnidadesDeMedidas", dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = Text
         frmImprime.Show()
      End Sub)
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      Return New Reglas.UnidadesDeMedidas().GetUno(dr.Field(Of String)("IdUnidadDeMedida"))
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns("IdUnidadDeMedida").FormatearColumna("Código", pos, 120)
         .Columns("NombreUnidadDeMedida").FormatearColumna("Nombre", pos, 180)
         .Columns("ConversionAKilos").FormatearColumna("Conv. a Kilos", pos, 90, HAlign.Right, , "N3")
         .Columns("IdAFIP").FormatearColumna("Cod. AFIP", pos, 60, HAlign.Right)
      End With
      dgvDatos.AgregarFiltroEnLinea({"NombreUnidadDeMedida"})
   End Sub

#End Region

End Class
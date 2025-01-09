Public Class AFIPIncotermsABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      MyBase.OnLoad(e)
      Me.dgvDatos.AgregarFiltroEnLinea({"NombreIncoterm"})
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AFIPIncotermsDetalle(DirectCast(Me.GetEntidad(), Entidades.AFIPIncoterm))
      End If
      Return New AFIPIncotermsDetalle(New Entidades.AFIPIncoterm)
   End Function
   'GET REGLLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.AFIPIncoterms()
   End Function
   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim afipIncoterm As Entidades.AFIPIncoterm = New Entidades.AFIPIncoterm()
      Dim r As Reglas.AFIPIncoterms = New Reglas.AFIPIncoterms()

      With Me.dgvDatos.ActiveCell.Row
         afipIncoterm.IdIncoterm = .Cells("IdIncoterm").Value.ToString()
         afipIncoterm = r.GetUno(afipIncoterm.IdIncoterm)
      End With
      Return afipIncoterm
   End Function
   'IMPRIMIR
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub
   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Eniac.Entidades.AFIPIncoterm.Columnas.IdIncoterm.ToString()).FormatearColumna("Código", col, 80)
         .Columns(Eniac.Entidades.AFIPIncoterm.Columnas.NombreIncoterm.ToString()).FormatearColumna("Nombre", col, 150)
      End With
   End Sub
#End Region
End Class
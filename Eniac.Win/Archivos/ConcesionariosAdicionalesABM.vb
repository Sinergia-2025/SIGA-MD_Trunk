Public Class ConcesionariosAdicionalesABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      'Me.tsbImprimir.Visible = False
   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ConcesionariosAdicionalesDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.ConcesionariosAdicionales))
      End If
      Return New ConcesionariosAdicionalesDetalle(New Eniac.Entidades.ConcesionariosAdicionales)

   End Function

   'GET REGLAS
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ConcesionariosAdicionales()
   End Function

   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim ConcesionariosAdicionales As Eniac.Entidades.ConcesionariosAdicionales = New Eniac.Entidades.ConcesionariosAdicionales
      With Me.dgvDatos.ActiveRow
         ConcesionariosAdicionales = New Eniac.Reglas.ConcesionariosAdicionales().GetUno(Integer.Parse(.Cells("IdAdicional").Value.ToString()))
      End With
      Return ConcesionariosAdicionales
   End Function
   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Eniac.Entidades.ConcesionariosAdicionales.Columnas.IdAdicional.ToString()).FormatearColumna("Código", col, 80)
         .Columns(Eniac.Entidades.ConcesionariosAdicionales.Columnas.NombreAdicional.ToString()).FormatearColumna("Nombre", col, 150)
         .Columns(Eniac.Entidades.ConcesionariosAdicionales.Columnas.DescripcionAdicional.ToString()).FormatearColumna("Descripción", col, 200)
         .Columns(Eniac.Entidades.ConcesionariosAdicionales.Columnas.SolicitaDetalle.ToString()).FormatearColumna("Solicita Detalle", col, 80, HAlign.Center)
      End With
   End Sub
#End Region

End Class
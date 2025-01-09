Imports Eniac.Win

Public Class TiposAntecedentesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TiposAntecedentesDetalle(DirectCast(Me.GetEntidad(), Entidades.TipoAntecedente))
      End If
      Return New TiposAntecedentesDetalle(New Entidades.TipoAntecedente)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposAntecedentes()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim o As Entidades.TipoAntecedente = New Entidades.TipoAntecedente()
      With Me.dgvDatos.ActiveRow
         'IdTipoAntecedente
         o.IdTipoAntecedente = Int32.Parse(.Cells(Entidades.TipoAntecedente.Columnas.IdTipoAntecedente.ToString()).Value.ToString())
         'NombreTipoAntecedente
         If Not String.IsNullOrEmpty(.Cells(Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()).Value.ToString()) Then
            o.NombreTipoAntecedente = .Cells(Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()).Value.ToString()
         End If
      End With
      Return o
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      'Try
      '   Me.Cursor = Cursors.WaitCursor
      '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Personal.Win.Datos.rdlc", "Dominios_Datos", Me.dtDatos)
      '   frmImprime.Text = ""
      '   frmImprime.Show()
      '   Me.Cursor = Cursors.Default
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoAntecedente.Columnas.IdTipoAntecedente.ToString()),
                                        "Codigo", col, 50, HAlign.Right)
      
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()),
                                     "Nombre", col, 200, HAlign.Left)

      End With
   End Sub

#End Region

End Class
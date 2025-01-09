Imports Eniac.Win

Public Class AntecedentesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AntecedentesDetalle(DirectCast(Me.GetEntidad(), Entidades.Antecedente))
      End If
      Return New AntecedentesDetalle(New Entidades.Antecedente)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Antecedentes()
   End Function

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim o As Entidades.Antecedente = New Entidades.Antecedente()
      With Me.dgvDatos.ActiveRow
         o = New Reglas.Antecedentes().GetUno(Int32.Parse(.Cells(Entidades.Antecedente.Columnas.IdAntecedente.ToString()).Value.ToString()))
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
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Antecedente.Columnas.IdAntecedente.ToString()),
                                        "Codigo", col, 50, HAlign.Right)
        
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.Antecedente.Columnas.NombreAntecedente.ToString()),
                                    "Antecedente", col, 200, HAlign.Left)

         'IdTipoAntecedente
         .Columns(Entidades.Antecedente.Columnas.IdTipoAntecedente.ToString()).Hidden = True

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.TipoAntecedente.Columnas.NombreTipoAntecedente.ToString()),
                                  "Tipo", col, 200, HAlign.Left)

      End With
   End Sub

#End Region

End Class
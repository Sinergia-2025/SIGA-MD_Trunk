Imports Eniac.Entidades
Imports Eniac.Reglas
Public Class NacionalidadesABM
#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.BotonImprimir.Visible = False
      Me.dgvDatos.AgregarFiltroEnLinea({"NombreNacionalidad"})
   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New NacionalidadesDetalle(DirectCast(Me.GetEntidad(), Entidades.Nacionalidad))
      End If
      Return New NacionalidadesDetalle(New Entidades.Nacionalidad)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Nacionalidades()
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      '   Try
      '      Me.Cursor = Cursors.WaitCursor
      '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiSeN.Win.Nacionalidades.rdlc", "SistemaDataSet_Nacionalidades", Me.dtDatos, True)
      '      frmImprime.Text = "Nacionalidades"
      '      frmImprime.Show()
      '      Me.Cursor = Cursors.Default
      '   Catch ex As Exception
      '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   End Try
   End Sub

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim nacion As Entidades.Nacionalidad = New Entidades.Nacionalidad
      With Me.dgvDatos.ActiveCell.Row
         nacion.IdNacionalidad = Integer.Parse(.Cells(Entidades.Nacionalidad.Columnas.IdNacionalidad.ToString()).Value.ToString())
         nacion = New Reglas.Nacionalidades().GetUno(nacion.IdNacionalidad)
      End With
      Return nacion
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.Nacionalidad.Columnas.IdNacionalidad.ToString()).FormatearColumna("Código", col, 80, HAlign.Right)
         .Columns(Entidades.Nacionalidad.Columnas.NombreNacionalidad.ToString()).FormatearColumna("Nombre", col, 250)
      End With
   End Sub
#End Region
End Class
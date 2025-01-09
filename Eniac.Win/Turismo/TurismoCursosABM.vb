#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports Eniac.Win
#End Region
Public Class TurismoCursosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New TurismoCursosDetalle(DirectCast(Me.GetEntidad(), Entidades.TurismoCurso))
      End If
      Return New TurismoCursosDetalle(New Eniac.Entidades.TurismoCurso())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TurismoCursos()
   End Function

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveCell Is Nothing Then
            If Me.dgvDatos.ActiveRow IsNot Nothing Then
               Me.dgvDatos.ActiveCell = Me.dgvDatos.ActiveRow.Cells(0)
            End If
         End If
         If Me.dgvDatos.ActiveCell IsNot Nothing Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.Base = GetReglas()
               Me._entidad = Me.GetEntidad()
               cl.Borrar(Me._entidad)
               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("El registro NO se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.TurismoCursos().GetUno(Integer.Parse(.Cells(Entidades.TurismoCurso.Columnas.IdCurso.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         Dim col As Integer = 0

         .Columns(Entidades.TurismoCurso.Columnas.IdCurso.ToString()).FormatearColumna("Código", col, 60, HAlign.Right)
         .Columns(Entidades.TurismoCurso.Columnas.NombreCurso.ToString()).FormatearColumna("Curso", col, 180)

      End With

      ' Agrego el Filtro en Linea x Descripción del Turno
      AgregarFiltroEnLinea(dgvDatos, {Entidades.TurismoCurso.Columnas.NombreCurso.ToString()})
   End Sub

#End Region

#Region "Eventos"

   '#

#End Region

End Class
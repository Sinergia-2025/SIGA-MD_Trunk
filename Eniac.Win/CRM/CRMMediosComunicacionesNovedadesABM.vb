#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class CRMMediosComunicacionesNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMMediosComunicacionesNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMMedioComunicacionNovedad))
      End If
      Return New CRMMediosComunicacionesNovedadesDetalle(New Eniac.Entidades.CRMMedioComunicacionNovedad())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.CRMMediosComunicacionesNovedades()
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
         Return New Reglas.CRMMediosComunicacionesNovedades().GetUno(Integer.Parse(.Cells(Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", pos, 100)
         .Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()).FormatearColumna("Descripción", pos, 180)
         .Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.Posicion.ToString()).FormatearColumna("Posición", pos, 70, HAlign.Right)
         .Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.Color.ToString()).FormatearColumna("Color", pos, 80, HAlign.Right)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString()).OcultoPosicion(True, pos)
         .Columns(Entidades.CRMMedioComunicacionNovedad.Columnas.PorDefecto.ToString()).FormatearColumna("Pred.", pos, 50, HAlign.Center)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()})
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         Dim row As DataRow = dgvDatos.FilaSeleccionada(Of DataRow)(e.Row)
         If row IsNot Nothing Then
            Dim colorColumnKey As String = Entidades.CRMMedioComunicacionNovedad.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
               e.Row.Cells(colorColumnKey).Appearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).Appearance.ForeColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.ForeColor = colorEstado
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class
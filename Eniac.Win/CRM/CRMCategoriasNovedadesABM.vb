#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Eniac.Win
#End Region
Public Class CRMCategoriasNovedadesABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CRMCategoriasNovedadesDetalle(DirectCast(Me.GetEntidad(), Entidades.CRMCategoriaNovedad))
      End If
      Return New CRMCategoriasNovedadesDetalle(New Eniac.Entidades.CRMCategoriaNovedad())
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Eniac.Reglas.CRMCategoriasNovedades()
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
         Return New Reglas.CRMCategoriasNovedades().GetUno(Integer.Parse(.Cells(Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString()).Value.ToString()))
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         .Columns(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).FormatearColumna("Tipo", pos, 100)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).FormatearColumna("Descripción", pos, 180)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.Posicion.ToString()).FormatearColumna("Posición", pos, 70, HAlign.Right)
         .Columns(Entidades.CRMEstadoNovedad.Columnas.Color.ToString()).FormatearColumna("Color", pos, 80, HAlign.Right)

         .Columns(Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString()).Hidden = True
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.PorDefecto.ToString()).FormatearColumna("Pred.", pos, 50, HAlign.Center)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.Reporta.ToString()).FormatearColumna("Reporta", pos, 60, , Not Reglas.Publicos.CRMMuestraReportaCategoriasNovedades)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.PublicarEnWeb.ToString()).FormatearColumna("Publica en Web", pos, 60, HAlign.Center)
         .Columns(Entidades.CRMCategoriaNovedad.Columnas.IdTipoCategoriaNovedad.ToString()).FormatearColumna("IdTipoCategoriaNovedad", pos, 40, HAlign.Right, True)
         .Columns("NombreTipoCategoriaNovedad").FormatearColumna("Tipo Categoria", pos, 120, HAlign.Left)

      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()})
   End Sub

#End Region

End Class
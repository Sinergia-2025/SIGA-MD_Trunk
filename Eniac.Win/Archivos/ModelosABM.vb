#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ModelosABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      'Me.BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ModelosDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Modelo))
      End If
      Return New ModelosDetalle(New Entidades.Modelo)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Modelos()
   End Function
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()

      Try
         Me.Cursor = Cursors.WaitCursor

         Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresaImpresion))
         parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreSucursal", actual.Sucursal.Nombre))

         Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Modelos.rdlc", "SistemaDataSet_Modelos", Me.dtDatos, parm, True, 1) '# 1 = Cantidad Copias

         frmImprime.Text = "Modelos"
         frmImprime.Show()

         Me.Cursor = Cursors.Default

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Modelos().GetUno(Integer.Parse(.Cells(Entidades.Modelo.Columnas.IdModelo.ToString()).Value.ToString()), Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns("IdModelo").FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns("NombreModelo").FormatearColumna("Nombre", pos, 220)
         .Columns("IdMarca").FormatearColumna("Marca", pos, 70, HAlign.Right)
         .Columns("NombreMarca").FormatearColumna("Nombre Marca", pos, 270)
         .Columns("Orden").FormatearColumna("Orden", pos, 70)
      End With
   End Sub

#End Region

End Class
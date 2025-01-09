#Region "Option/Imports"
Option Strict On
Option Explicit On
Imports Eniac.Win
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region

Public Class MonedasABM
#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New Publicos()

         Me.tsbBorrar.Enabled = False
         Me.tsbBorrar.Visible = False
         Me.tsbImprimir.Visible = False
         Me.tsbImprimir.Enabled = False

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New MonedasDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Moneda))
      End If
      Return New MonedasDetalle(New Entidades.Moneda)
   End Function
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Monedas()
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
         Return New Reglas.Monedas().GetUna(Integer.Parse(.Cells(Entidades.Moneda.Columnas.IdMoneda.ToString()).Value.ToString()), Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         .Columns("IdMoneda").FormatearColumna("Código", pos, 70, HAlign.Right)
         .Columns("NombreMoneda").FormatearColumna("Nombre", pos, 220)
         .Columns("Simbolo").FormatearColumna("Simbolo", pos, 120, HAlign.Center)
         .Columns("FactorConversion").FormatearColumna("Factor", pos, 70, HAlign.Right)
         .Columns("Predeterminada").FormatearColumna("Predeterminada", pos, 120)
         .Columns("IdBanco").Hidden = True
         .Columns("IdTipoMoneda").Hidden = True
         .Columns("OperadorConversion").Hidden = True
      End With
   End Sub

#End Region
End Class
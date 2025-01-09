Option Explicit On
Option Strict On

'Imports Eniac.SiPrueba.Win
Imports Eniac.Win

Public Class ContabilidadTiposCuentasABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbNuevo.Visible = False
      Me.tsbEditar.Visible = False
      Me.tsbBorrar.Visible = False
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ContabilidadTiposCuentasABMDetalle(DirectCast(Me.GetEntidad(), Entidades.ContabilidadTipoCuenta))
      End If
      Return New ContabilidadTiposCuentasABMDetalle(New Entidades.ContabilidadTipoCuenta)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadTiposCuentas()
   End Function

   'Protected Overrides Sub Imprimir()
   '    MyBase.Imprimir()
   '    Try
   '        Me.Cursor = Cursors.WaitCursor
   '        Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '        parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.Win.Publicos.NombreEmpresa))

   '        Dim frmImprime As VisorReportes = New VisorReportes("Eniac.SiPrueba.Win.MarcasVehiculos.rdlc", "SistemaDataSet_MarcasVehiculos", Me.dtDatos, parm, True)
   '        frmImprime.Text = Me.Text
   '        frmImprime.Show()
   '        Me.Cursor = Cursors.Default
   '    Catch ex As Exception
   '        MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '    End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad

      Dim TipoCuenta As Entidades.ContabilidadTipoCuenta = New Entidades.ContabilidadTipoCuenta
      Dim TiposCuentas As Reglas.ContabilidadTiposCuentas = New Reglas.ContabilidadTiposCuentas

      With Me.dgvDatos.SelectedCells(0).OwningRow
         TipoCuenta = TiposCuentas.GetUna(Integer.Parse(.Cells(Entidades.ContabilidadTipoCuenta.Columnas.IdTipoCuenta.ToString()).Value.ToString()))
      End With

      Return TipoCuenta

   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns(Entidades.ContabilidadTipoCuenta.Columnas.IdTipoCuenta.ToString()).HeaderText = "Cód. Tipo Cta."
         .Columns(Entidades.ContabilidadTipoCuenta.Columnas.IdTipoCuenta.ToString()).Width = 105
         .Columns(Entidades.ContabilidadTipoCuenta.Columnas.IdTipoCuenta.ToString()).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
         .Columns(Entidades.ContabilidadTipoCuenta.Columnas.NombreTipoCuenta.ToString()).HeaderText = "Descripción Tipos de Cuenta"
         .Columns(Entidades.ContabilidadTipoCuenta.Columnas.NombreTipoCuenta.ToString()).Width = 250
         .Columns(Entidades.ContabilidadTipoCuenta.Columnas.NombreTipoCuenta).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
      End With
   End Sub

#End Region

End Class
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Win

Public Class ArchivosAImprimirABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ArchivosAImprimirDetalle(DirectCast(Me.GetEntidad(), Entidades.ArchivoAImprimir))
      End If
      Return New ArchivosAImprimirDetalle(New Entidades.ArchivoAImprimir())
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ArchivosAImprimir()
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
      MyBase.GetEntidad()
      Dim en As Entidades.ArchivoAImprimir = New Entidades.ArchivoAImprimir()

      With Me.dgvDatos.ActiveCell.Row
         en = New Reglas.ArchivosAImprimir().GetUno(actual.Sucursal.IdSucursal, .Cells(Entidades.ArchivoAImprimir.Columnas.NombreReporteOriginal.ToString()).Value.ToString())
      End With

      Return en

   End Function

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)

         .Columns(Entidades.ArchivoAImprimir.Columnas.IdSucursal.ToString()).Header.Caption = "Sucursal"
         .Columns(Entidades.ArchivoAImprimir.Columnas.IdSucursal.ToString()).Width = 40

         .Columns(Entidades.ArchivoAImprimir.Columnas.NombreReporteOriginal.ToString()).Header.Caption = "Reporte Original"
         .Columns(Entidades.ArchivoAImprimir.Columnas.NombreReporteOriginal.ToString()).Width = 200

         .Columns(Entidades.ArchivoAImprimir.Columnas.ReporteSecundario.ToString()).Hidden = True

      End With

   End Sub

#End Region

End Class
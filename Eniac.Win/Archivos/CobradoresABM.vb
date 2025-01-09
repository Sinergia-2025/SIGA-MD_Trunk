Option Strict On
Option Explicit On
Public Class CobradoresABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CobradoresDetalle(DirectCast(Me.GetEntidad(), Eniac.Entidades.Cobrador))
      End If
      Return New CobradoresDetalle(New Eniac.Entidades.Cobrador)
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Cobradores()
   End Function

   'Protected Overrides Sub Imprimir()
   '   MyBase.Imprimir()
   '   Try
   '      Me.Cursor = Cursors.WaitCursor
   '      Dim parm As System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter) = New System.Collections.Generic.List(Of Microsoft.Reporting.WinForms.ReportParameter)

   '      parm.Add(New Microsoft.Reporting.WinForms.ReportParameter("NombreEmpresa", Eniac.SiSeN.Win.Publicos.NombreEmpresa))

   '      Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Gimnasio.Win.Cobradores.rdlc", "SistemaDataSet_Cobradores", Me.dtDatos, parm, True)
   '      frmImprime.Text = Me.Text
   '      frmImprime.Show()
   '      Me.Cursor = Cursors.Default
   '   Catch ex As Exception
   '      MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '   End Try
   'End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      Dim Cobrador As Eniac.Entidades.Cobrador = New Eniac.Entidades.Cobrador
      With Me.dgvDatos.ActiveCell.Row
         Cobrador = New Eniac.Reglas.Cobradores().GetUno(Integer.Parse(.Cells("IdCobrador").Value.ToString()))
      End With
      Return Cobrador
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         .Columns(Eniac.Entidades.Cobrador.Columnas.IdCobrador.ToString()).FormatearColumna("Codigo", col, 80, HAlign.Right)
         .Columns(Eniac.Entidades.Cobrador.Columnas.NombreCobrador.ToString()).FormatearColumna("Nombre", col, 120)
         .Columns(Eniac.Entidades.Cobrador.Columnas.DebitoDirecto.ToString()).FormatearColumna("Débito Directo", col, 70)
         .Columns(Eniac.Entidades.Cobrador.Columnas.IdBanco.ToString()).FormatearColumna("Id Banco", col, 70, HAlign.Right, True)
         .Columns("NombreBanco").FormatearColumna("Banco", col, 200)
         .Columns(Eniac.Entidades.Cobrador.Columnas.IdDispositivo.ToString()).FormatearColumna("ID Dispositivo", col, 180)

         .Columns(Eniac.Entidades.CobradorSucursal.Columnas.IdCaja.ToString()).FormatearColumna("Id Caja", col, 70, HAlign.Right)
         .Columns(Eniac.Entidades.CajaNombre.Columnas.NombreCaja.ToString()).FormatearColumna("Caja", col, 120)
         .Columns(Eniac.Entidades.CobradorSucursal.Columnas.Observacion.ToString()).FormatearColumna("Observación", col, 200)

      End With
   End Sub

#End Region

End Class
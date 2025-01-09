Public Class AlertasSistemaABM

#Region "Overrides"

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New AlertasSistemaDetalle(DirectCast(GetEntidad(), Entidades.SistemaE.AlertaSistema))
      End If
      Return New AlertasSistemaDetalle(New Entidades.SistemaE.AlertaSistema())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Sistema.AlertasSistema()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With dgvDatos.ActiveRow
         Return New Reglas.Sistema.AlertasSistema().GetUno(.FilaSeleccionada(Of DataRow).Field(Of Integer)(Entidades.SistemaE.AlertaSistema.Columnas.IdAlertaSistema.ToString()))
      End With
   End Function

   Protected Overrides Sub FormatearGrilla()
      With dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0I
         .Columns(Entidades.SistemaE.AlertaSistema.Columnas.IdAlertaSistema.ToString()).FormatearColumna("Código", pos, 60, HAlign.Right)
         .Columns(Entidades.SistemaE.AlertaSistema.Columnas.TituloAlerta.ToString()).FormatearColumna("Nombre", pos, 220)
         With .Columns(Entidades.SistemaE.AlertaSistema.Columnas.ConsultaAlerta.ToString()).FormatearColumna("Consulta", pos, 120)
            .Style = UltraWinGrid.ColumnStyle.Button
            .ButtonDisplayStyle = UltraWinGrid.ButtonDisplayStyle.Always
         End With
         .Columns(Entidades.SistemaE.AlertaSistema.Columnas.UtilizaConsultaGenerica.ToString()).FormatearColumna("Consulta Genérica", pos, 80, HAlign.Center)
         .Columns(Entidades.SistemaE.AlertaSistema.Columnas.IdFuncionClick.ToString()).FormatearColumna("Código Función", pos, 80)
         .Columns("NombreFuncionClick").FormatearColumna("Función", pos, 150)
         .Columns(Entidades.SistemaE.AlertaSistema.Columnas.ParametrosPantalla.ToString()).FormatearColumna("Parámetros Función", pos, 150)
         .Columns(Entidades.SistemaE.AlertaSistema.Columnas.PermisosCondicion.ToString()).FormatearColumna("Codición de Permisos", pos, 80)
      End With

      dgvDatos.AgregarFiltroEnLinea({Entidades.SistemaE.AlertaSistema.Columnas.TituloAlerta.ToString(),
                                     Entidades.SistemaE.AlertaSistema.Columnas.ConsultaAlerta.ToString(),
                                     Entidades.SistemaE.AlertaSistema.Columnas.IdFuncionClick.ToString(),
                                     Entidades.SistemaE.AlertaSistema.Columnas.ParametrosPantalla.ToString(),
                                     "NombreFuncionClick"})
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_ClickCellButton(sender As Object, e As CellEventArgs) Handles dgvDatos.ClickCellButton
      TryCatched(Sub() ClickCellButton(e))
   End Sub

#End Region

#Region "Métodos privados"
   Private Sub ClickCellButton(e As CellEventArgs)
      Dim dr = e.Cell.Row.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         If e.Cell.Column.Key = Entidades.SistemaE.AlertaSistema.Columnas.ConsultaAlerta.ToString() Then
            Using frm = New VisorTexto()
               frm.ShowDialog(Me, String.Format("Consulta del Alerta {0} - {1}",
                                                dr.Field(Of Integer)(Entidades.SistemaE.AlertaSistema.Columnas.IdAlertaSistema.ToString()),
                                                dr.Field(Of String)(Entidades.SistemaE.AlertaSistema.Columnas.TituloAlerta.ToString())),
                              dr.Field(Of String)(Entidades.SistemaE.AlertaSistema.Columnas.ConsultaAlerta.ToString()))
            End Using
         End If
      End If
   End Sub
#End Region

End Class
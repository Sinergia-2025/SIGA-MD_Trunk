Public Class GrillaActualizadorAlerta
   Inherits GrillaController
   Private WithEvents _contextMenu As ContextMenuStrip
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)

      _contextMenu = New ContextMenuStrip()
      _contextMenu.Name = "_contextMenu"

      Dim label As ToolStripLabel = New ToolStripLabel("A C C I O N E S")
      label.Font = New Font(label.Font, FontStyle.Bold)
      _contextMenu.Items.Add(label)
      _contextMenu.Items.Add(New ToolStripSeparator())

      _contextMenu.Items.Add("Marcar como revisado", My.Resources.delete_32,
                             Sub(sender, e)
                                Try
                                   MarcarRevisado(grilla.ActiveRow)
                                Catch ex As Exception
                                   MessageBox.Show(ex.Message, _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Try
                             End Sub)

      _contextMenu.Items.Add("Ver Detalle", My.Resources.form_yellow,
                             Sub(sender, e)
                                Try
                                   VerDetalle(grilla.ActiveRow)
                                Catch ex As Exception
                                   MessageBox.Show(ex.Message, _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Try
                             End Sub)

      grilla.ContextMenuStrip = _contextMenu

   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("Color").FormatearColumna("", pos, 26).AnchoMinimoMaximo(26, 26).Style = UltraWinGrid.ColumnStyle.Color
         ''.Columns("Estado").FormatearColumna("Estado", pos, 70)

         .Columns("FechaInicioActualizacion").FormatearColumna("F. Inicio", pos, 70, HAlign.Center, , "dd/MM HH:mm")
         .Columns("NombreCliente").FormatearColumna("Nombre Cliente", pos, 200)
         .Columns("NombreDeFantasia").FormatearColumna("Nombre Fantasia", pos, 200)


         .Columns("NombreCliente").Hidden = Filtros.VerNombreCliente <> Entidades.TablerosDeComando.VerNombreCliente.NombreCliente
         .Columns("NombreDeFantasia").Hidden = Filtros.VerNombreCliente <> Entidades.TablerosDeComando.VerNombreCliente.NombreDeFantasia
      End With
   End Sub
   Protected Overrides Sub FormatearGrillasPre(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub FormatearGrillasPos(ByRef pos As Integer)
   End Sub
   Protected Overrides Sub AgregarFiltrosEnLinea()
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetActualizadorAutomaticoAlerta(filtros)
   End Function

   Public Sub _grilla_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles _grilla.ClickCell
      Try
         If e.Cell.Column.Key = "Color" Then
            MarcarRevisado(e.Cell.Row)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Function MarcarRevisado(ultraRow As UltraGridRow) As DialogResult
      Dim dr As DataRow = _grilla.FilaSeleccionada(Of DataRow)(ultraRow)
      If dr IsNot Nothing Then
         Dim estado As String = dr.Field(Of String)("Estado")
         Dim activo As Boolean? = dr.Field(Of Boolean?)("Activo")
         If Not activo.HasValue Then activo = True

         If estado = Entidades.ClienteActualizacion.EstadoActualizacion.ConError.ToString() AndAlso activo Then
            If MessageBox.Show("¿Desea marcar la ejecución seleccionada como revisada?",
                               _grilla.FindForm().Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
               Dim rCA As Reglas.ClientesActualizaciones = New Reglas.ClientesActualizaciones()
               rCA.ActualizarActivo(dr.Field(Of Long)("IdCliente"),
                                    dr.Field(Of String)("NombreServidor"),
                                    dr.Field(Of String)("BaseDatos"),
                                    dr.Field(Of DateTime)("FechaEjecucion"),
                                    activo:=False)
               PerformSolicitaRefrescarGrilla(Me, Nothing)
               Return DialogResult.OK
            End If
         End If
      End If
      Return DialogResult.Cancel
   End Function

   Private Sub VerDetalle(ultraRow As UltraGridRow)
      Dim dr As DataRow = _grilla.FilaSeleccionada(Of DataRow)(ultraRow)
      If dr IsNot Nothing Then
         Using frm As ClientesActualizacionesDetalle = New ClientesActualizacionesDetalle()
            If frm.ShowDialog(_grilla.FindForm(),
                              dr.Field(Of Long)("IdCliente"),
                              dr.Field(Of String)("NombreServidor"),
                              dr.Field(Of String)("BaseDatos"),
                              dr.Field(Of DateTime)("FechaEjecucion"),
                              Function()
                                 Return MarcarRevisado(Grilla.ActiveRow)
                              End Function) = DialogResult.OK Then
               PerformSolicitaRefrescarGrilla(Me, Nothing)
            End If
         End Using
      End If
   End Sub

End Class
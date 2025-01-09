Imports Infragistics.Win.UltraWinGrid
Imports System.ComponentModel
Public Class GrillaBackup
   Inherits GrillaController

   ' Privada para el MenuStrip
   Private WithEvents _contextMenu As ContextMenuStrip
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      MyBase.New(grilla, panel)

      _contextMenu = New ContextMenuStrip()
      _contextMenu.Name = "_contextMenu"

      Dim label As ToolStripLabel = New ToolStripLabel("A C C I O N E S")

      label.Font = New Font(label.Font, FontStyle.Bold)
      _contextMenu.Items.Add(label)
      _contextMenu.Items.Add(New ToolStripSeparator())

      _contextMenu.Items.Add("Eliminar Backups Duplicados", My.Resources.delete_32,
                             Sub(sender, e)
                                Try
                                   EliminarBackupsDuplicados(grilla.ActiveRow)
                                Catch ex As Exception
                                   MessageBox.Show(ex.Message, _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Try
                             End Sub)

      grilla.ContextMenuStrip = _contextMenu

   End Sub
   Protected Overrides Sub FormatearGrillaCamposPropios(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("DiasBackup").FormatearColumna("Dias Backup", pos, 50, HAlign.Center)
         .Columns("FechaInicioBackup").FormatearColumna("Fecha Inicio", pos, 70, HAlign.Center, , "dd/MM HH:mm")
         .Columns("FechaFinBackup").FormatearColumna("Fecha Fin", pos, 70, HAlign.Center, , "dd/MM HH:mm")
         .Columns("TiempoBackup").FormatearColumna("Tiempo", pos, 40)
         .Columns("FechaInicioBackupUltimo").FormatearColumna("Fecha Última Ejecución", pos, 70, HAlign.Center, , "dd/MM HH:mm")
         .Columns("NombreServidor").FormatearColumna("Nombre Servidor", pos, 100)
         .Columns("BaseDatos").FormatearColumna("Base Datos", pos, 70)
      End With
   End Sub
   Public Overrides Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable
      Return rTablero.GetClientesBackups(filtros)
   End Function
   Private Sub _grilla_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles _grilla.InitializeRow
      Try
         Dim fechaInicioBackup As DateTime? = Nothing
         Dim fechaInicioBackupUltimo As DateTime? = Nothing
         If IsDate(e.Row.Cells("FechaInicioBackup").Value) Then
            fechaInicioBackup = DateTime.Parse(e.Row.Cells("FechaInicioBackup").Value.ToString())
         End If
         If IsDate(e.Row.Cells("FechaInicioBackupUltimo").Value) Then
            fechaInicioBackupUltimo = DateTime.Parse(e.Row.Cells("FechaInicioBackupUltimo").Value.ToString())
         End If
         If fechaInicioBackup <> fechaInicioBackupUltimo Then
            e.Row.Cells("FechaInicioBackupUltimo").Appearance.BackColor = Color.Cyan
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub EliminarBackupsDuplicados(r As UltraGridRow)

      If Not r Is Nothing Then
         Dim nombreFantasia As String = r.Cells("NombreDeFantasia").Value.ToString()
         Dim nombreServidor As String = r.Cells("NombreServidor").Value.ToString()
         Dim baseDatos As String = r.Cells("BaseDatos").Value.ToString()
         Dim idCliente As Long = Long.Parse(r.Cells("IdCliente").Value.ToString())

         Dim mensaje As String = String.Format("¿Esta seguro que desea eliminar éste backup del Cliente: {0} - Servidor: {1} - Base Datos: {2}?", nombreFantasia, nombreServidor, baseDatos)

         If MessageBox.Show(mensaje, _grilla.FindForm().Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = vbOK Then
            Dim regla As Reglas.TableroDeComando = New Reglas.TableroDeComando

            If String.IsNullOrEmpty(nombreServidor) Then
               Throw New Exception("El Nombre del Servidor está vacio.")
            End If

            If String.IsNullOrEmpty(baseDatos) Then
               Throw New Exception("El Nombre de Base de Datos está vacio.")
            End If

            regla.EliminarClientesBackups(idCliente,
                                          nombreServidor,
                                          baseDatos)
            MessageBox.Show("Backup eliminado correctamente!!", _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            PerformSolicitaRefrescarGrilla(Me, Nothing)
         End If
      End If

   End Sub

End Class
Public Class FiltroTableros_CategoriaActualiza
   Implements IFiltroTableros

   Private _publicos As Publicos

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         cmbCategoriasClientes.Inicializar(False)
         _publicos.CargaComboDesdeEnum(Me.cmbActualizaAplicacion, GetType(Entidades.Publicos.SiNoTodos))
         cmbActualizaAplicacion.SelectedValue = Entidades.Publicos.SiNoTodos.TODOS
         _publicos.CargaComboDesdeEnum(cmbNombreCliente, GetType(Entidades.TablerosDeComando.VerNombreCliente))
         cmbNombreCliente.SelectedValue = Entidades.TablerosDeComando.VerNombreCliente.NombreDeFantasia

      Catch ex As Exception
         FindForm().ShowError(ex)
      End Try
   End Sub

   Public Function GetFiltros() As Entidades.TablerosDeComando.FiltroTableros Implements IFiltroTableros.GetFiltros
      Return New Entidades.TablerosDeComando.FiltroTableros(cmbCategoriasClientes.GetCategorias(todosVacio:=True),
                                                            cmbActualizaAplicacion.ValorSeleccionado(Of Entidades.Publicos.SiNoTodos),
                                                            cmbNombreCliente.ValorSeleccionado(Of Entidades.TablerosDeComando.VerNombreCliente))
   End Function

   Public Sub RefrescarGrilla() Implements IFiltroTableros.RefrescarGrilla
      Me.cmbCategoriasClientes.Refrescar()
      chbActualizaAplicacion.Checked = False

   End Sub


   Private Sub chbActualizaAplicacion_CheckedChanged(sender As Object, e As EventArgs) Handles chbActualizaAplicacion.CheckedChanged
      'If _initializing Then Return
      Try
         Me.cmbActualizaAplicacion.Enabled = Me.chbActualizaAplicacion.Checked
         If Not Me.chbActualizaAplicacion.Checked Then
            Me.cmbActualizaAplicacion.SelectedIndex = -1
         Else
            If Me.cmbActualizaAplicacion.Items.Count > 0 Then
               Me.cmbActualizaAplicacion.SelectedIndex = 0
            End If
            Me.cmbActualizaAplicacion.Focus()
         End If
      Catch ex As Exception
         FindForm().ShowError(ex)
      End Try
   End Sub

   Private Sub cmbNombreCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNombreCliente.SelectedIndexChanged
      If cmbNombreCliente.SelectedIndex > -1 Then
         'btnConsultar.PerformClick()
      End If
   End Sub

End Class
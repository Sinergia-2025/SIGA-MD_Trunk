Option Strict Off
Imports Eniac.Win

Public Class CajasNombresABM

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
      'Me.dgvDatos.Columns("Nombre").Visible = (New Reglas.Sucursales().GetAll.Rows.Count() > 1)
   End Sub

   Protected Overrides Function GetDetalle(ByVal estado As StateForm) As Eniac.Win.BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New CajasNombresDetalle(DirectCast(Me.GetEntidad(), Entidades.CajaNombre))
      End If
      Return New CajasNombresDetalle(New Entidades.CajaNombre)
   End Function

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.CajasNombres()
   End Function

   Protected Overrides Sub Imprimir()
      'MyBase.Imprimir()
      'Try
      '   Me.Cursor = Cursors.WaitCursor
      '   Dim frmImprime As VisorReportes = New VisorReportes("Eniac.Win.Marcas.rdlc", "SistemaDataSet_Marcas", Me.dtDatos, True)
      '   frmImprime.Text = "Marcas"
      '   frmImprime.Show()
      '   Me.Cursor = Cursors.Default
      'Catch ex As Exception
      '   MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      'End Try
   End Sub

   Protected Overrides Function GetEntidad() As Eniac.Entidades.Entidad
      With Me.dgvDatos.ActiveRow
         Return New Reglas.CajasNombres().GetUna(Integer.Parse(.Cells(Entidades.CajaNombre.Columnas.IdSucursal.ToString()).Value.ToString()),
                                                 Integer.Parse(.Cells(Entidades.CajaNombre.Columnas.IdCaja.ToString()).Value.ToString()))
      End With
   End Function

   Protected Overrides Function GetAll(rg As Reglas.Base) As DataTable
      Return DirectCast(rg, Reglas.CajasNombres).GetAll(Entidades.Usuario.Actual.Sucursal.Id)
   End Function

   Protected Overrides Function Buscar(rg As Reglas.Base, bus As Entidades.Buscar) As DataTable
      Return DirectCast(rg, Reglas.CajasNombres).Buscar(bus, Entidades.Usuario.Actual.Sucursal.Id)
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0

         Ayudante.Grilla.FormatearColumna(.Columns("IdSucursal"), "Sucursal", col, 30, , True)
         Ayudante.Grilla.FormatearColumna(.Columns("Nombre"), "Sucursal", col, 70, , True)

         Ayudante.Grilla.FormatearColumna(.Columns("IdCaja"), "Caja", col, 30, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns("NombreCaja"), "Nombre Caja", col, 100)

         Ayudante.Grilla.FormatearColumna(.Columns("NombrePC"), "PC", col, 100)
         Ayudante.Grilla.FormatearColumna(.Columns("IdUsuario"), "Usuario", col, 100)

         Ayudante.Grilla.FormatearColumna(.Columns("TopeAviso"), "Tope Aviso", col, 70, HAlign.Right)
         Ayudante.Grilla.FormatearColumna(.Columns("TopeBloqueo"), "Tope Bloqueo", col, 70, HAlign.Right)

         Ayudante.Grilla.FormatearColumna(.Columns("IdPlanCuenta"), "Plan Cuenta", col, 70, HAlign.Right, True)

         Ayudante.Grilla.FormatearColumna(.Columns("IdTipoComprobanteF3"), "Tipo Comprobante Tecla F3", col, 150)
         Ayudante.Grilla.FormatearColumna(.Columns("IdTipoComprobanteF4"), "Tipo Comprobante Tecla F4", col, 150)

         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CajaNombre.Columnas.IdTipoComprobanteF10Origen.ToString()), "Tipo Comprobante Tecla F10 Origen", col, 150)
         Ayudante.Grilla.FormatearColumna(.Columns(Entidades.CajaNombre.Columnas.IdTipoComprobanteF10Destino.ToString()), "Tipo Comprobante Tecla F10 Destino", col, 150)

         Dim tieneModuloContabilidad As Boolean = Publicos.TieneModuloContabilidad
         Ayudante.Grilla.FormatearColumna(.Columns("nombrePlanCuenta"), "Plan Cuenta", col, 70, , Not tieneModuloContabilidad)
         Ayudante.Grilla.FormatearColumna(.Columns("idCuentaContable"), "Cuenta Contable", col, 100, , Not tieneModuloContabilidad)
         Ayudante.Grilla.FormatearColumna(.Columns("nombreCuenta"), "Nombre Cuenta Contable", col, 180, , Not tieneModuloContabilidad)
      End With
   End Sub

   Protected Overrides Sub Borrar()
      Try
         If Me.dgvDatos.ActiveRow IsNot Nothing Then
            If MessageBox.Show("¿Está seguro de eliminar el registro seleccionado?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
               Dim cl As Reglas.CajasNombres = Me.GetReglas()
               Me._entidad = Me.GetEntidad()
               cl.BorrarUna(Me._entidad, Nothing)
               Me.RefreshGrid()
            End If
         End If
      Catch ex As Exception
         If ex.Message.Contains("The DELETE statement conflicted with the REFERENCE constraint") Then
            MessageBox.Show("No se puede eliminar porque esta siendo utilizado.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      End Try
   End Sub

#End Region

#Region "Eventos"
   Private Sub dgvDatos_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles dgvDatos.InitializeRow
      Try
         If e.Row IsNot Nothing AndAlso
            e.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Row.ListObject, DataRowView).Row IsNot Nothing Then
            Dim row As DataRow = DirectCast(e.Row.ListObject, DataRowView).Row
            Dim colorColumnKey As String = Entidades.CajaNombre.Columnas.Color.ToString()
            If row.Table.Columns.Contains(colorColumnKey) AndAlso IsNumeric(e.Row.Cells(colorColumnKey).Value) Then
               Dim colorEstado As Color = Color.FromArgb(Integer.Parse(e.Row.Cells(colorColumnKey).Value.ToString()))
               e.Row.Cells(colorColumnKey).Appearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).Appearance.ForeColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.BackColor = colorEstado
               e.Row.Cells(colorColumnKey).ActiveAppearance.ForeColor = colorEstado
            End If
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

End Class
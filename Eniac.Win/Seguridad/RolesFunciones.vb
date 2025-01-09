Imports Infragistics.Win.UltraWinGrid
Public Class RolesFunciones

#Region "Campos"

   Dim _rolesFunciones As DataTable
   Dim _funciones As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.CargaPantalla()

   End Sub

#End Region

#Region "Metodos"

   Private Sub CargaPantalla()
      Dim oUsu As Reglas.Funciones = New Reglas.Funciones()
      With Me.ugFunciones
         _funciones = oUsu.GetAll()
         .DataSource = _funciones
      End With
      Me.FormatearGrillaFunciones()

      Dim oRol As Reglas.Roles = New Reglas.Roles()
      With Me.cmbRoles
         .DataSource = oRol.GetAll("CadenaSegura")
      End With
      Me.FormatearComboRoles()

      Me.CargarRolesFunciones()
   End Sub
   Private Sub CargarRolesFunciones()

      Dim oRol As Reglas.RolesFunciones = New Reglas.RolesFunciones()
      Me._rolesFunciones = New DataTable()
      Me._rolesFunciones = oRol.GetFuncionesPorRol(Me.cmbRoles.Text)

      If _rolesFunciones.Rows.Count > 0 Then
         Dim resultados() As DataRow
         Dim selecttexto As String
         For Each dr As DataRow In Me._rolesFunciones.Rows
            selecttexto = "Id='" & dr("IdRol").ToString() & "'"
            resultados = _funciones.Select(selecttexto)
         Next
      End If

      With Me.ugRolesFunciones
         .DataSource = Me._rolesFunciones
      End With

      Me.FormatearGrillaRolesFunciones()

   End Sub

   Private Sub FormatearComboRoles()
      With Me.cmbRoles
         .DisplayMember = "Id"
         .ValueMember = "Id"
      End With
   End Sub

   Protected Sub FormatearGrillaFunciones()

      With Me.ugFunciones.DisplayLayout.Bands(0)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Id.ToString()), "Id", 1, 80, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Nombre.ToString()), "Función", 2, 250).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.IdPadre.ToString()), "Padre", 3, 125).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
         'FormatearColumna(.Columns("NombrePadre"), "Padre", 4, 110, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Posicion.ToString()), "Pos.", 4, 50, HAlign.Right)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Descripcion.ToString()), "Descripción", 5, 250, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.EsMenu.ToString()), "EsMenu", 6, 40, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.EsBoton.ToString()), "EsBoton", 7, 40, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Enabled.ToString()), "Enabled", 8, 40, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Visible.ToString()), "Visible", 9, 40, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Archivo.ToString()), "Archivo", 10, 80, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Pantalla.ToString()), "Pantalla", 11, 80, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Icono.ToString()), "Icono", 12, 50, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Parametros.ToString()), "Parametros", 13, 150, , True)
      End With

   End Sub

   Protected Sub FormatearGrillaRolesFunciones()
      With Me.ugRolesFunciones.DisplayLayout.Bands(0)
         FormatearColumna(.Columns(Entidades.RolFuncion.Columnas.IdRol.ToString()), "IdRol", 1, 80, , True)
         FormatearColumna(.Columns(Entidades.RolFuncion.Columnas.IdFuncion.ToString()), "Id", 2, 80, , True)
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Nombre.ToString()), "Función", 3, 250).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.IdPadre.ToString()), "Padre", 4, 125).FilterOperatorDefaultValue = FilterOperatorDefaultValue.Contains
         FormatearColumna(.Columns(Entidades.Funcion.Columnas.Posicion.ToString()), "Pos.", 5, 50, HAlign.Right)
      End With
   End Sub

   Protected Function FormatearColumna(col As UltraGridColumn, caption As String, posicion As Integer, ancho As Integer,
                                  Optional alineacion As HAlign = HAlign.Default, Optional hidden As Boolean = False) As UltraGridColumn
      col.Hidden = hidden
      col.Header.Caption = caption
      col.Header.VisiblePosition = posicion
      col.Width = ancho
      col.CellAppearance.TextHAlign = alineacion
      Return col
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click

      Try

         'If Me.ugFunciones.ActiveCell Is Nothing Then
         '   If Me.ugFunciones.ActiveRow IsNot Nothing Then
         '      Me.ugFunciones.ActiveCell = Me.ugFunciones.ActiveRow.Cells(0)
         '   End If
         'End If

         For Each ugr As UltraGridRow In Me.ugFunciones.Selected.Rows
            If Me._rolesFunciones.Select("IdFuncion = '" & ugr.Cells("Id").Value.ToString() & "'").Length = 0 Then
               Dim dr As DataRow = Me._rolesFunciones.NewRow()
               dr(0) = Me.cmbRoles.Text
               dr(1) = ugr.Cells("Id").Value
               dr(2) = ugr.Cells("Nombre").Value
               dr(3) = ugr.Cells("Posicion").Value
               dr(4) = ugr.Cells("IdPadre").Value
               Me._rolesFunciones.Rows.Add(dr)
            End If
         Next

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub cmbRoles_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRoles.SelectedIndexChanged
      Try
         Me.CargarRolesFunciones()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub btnQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuitar.Click

      Try
         'If Me.dgvRolesFunciones.SelectedCells.Count > 0 Then
         '   Me.dgvRolesFunciones.Rows.Remove(Me.dgvRolesFunciones.SelectedRows(0))
         'End If
         If Me.ugRolesFunciones.Selected.Rows.Count > 0 Then
            For Each ugr As UltraGridRow In ugRolesFunciones.Selected.Rows
               Me.ugRolesFunciones.PerformAction(UltraGridAction.DeleteRows)
            Next
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub
   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Me.CargaPantalla()
   End Sub
   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub
   Private Sub tsbGrabar_Click(sender As Object, e As EventArgs) Handles tsbGrabar.Click
      Try
         Dim oUsuRol As Reglas.RolesFunciones = New Reglas.RolesFunciones()
         Dim oUR As Entidades.RolFuncion

         For Each dr As DataRow In Me._rolesFunciones.Rows
            If dr.RowState = DataRowState.Added Then
               oUR = New Entidades.RolFuncion()
               oUR.IdFuncion = dr("IdFuncion").ToString()
               oUR.IdRol = Me.cmbRoles.Text
               oUsuRol.Insertar(oUR)
            End If
            If dr.RowState = DataRowState.Deleted Then
               oUR = New Entidades.RolFuncion()
               oUR.IdFuncion = dr("IdFuncion", DataRowVersion.Original).ToString()
               oUR.IdRol = Me.cmbRoles.Text
               oUsuRol.Borrar(oUR)
            End If
         Next


         Me._rolesFunciones.AcceptChanges()
         MessageBox.Show("Los roles han sido modificados con exito!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.CargarRolesFunciones()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub Facturacion_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      Select Case e.KeyCode
         Case Keys.F4
            If Me.tsbGrabar.Enabled Then
               Me.tsbGrabar.PerformClick()
            End If
         Case Else
      End Select
   End Sub
#End Region
End Class
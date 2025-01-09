Public Class BaseMultiplesFiltros2

   Protected _permiteSinSeleccion As Boolean

   Protected _publicos As Publicos
   Protected _columnasAMostrar As List(Of String)
   Protected _tipoFiltro As String = String.Empty
   Protected _nombreFiltro As String = String.Empty

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.
   End Sub
   Public Sub New(permiteSinSeleccion As Boolean)
      Me.New()
      _permiteSinSeleccion = permiteSinSeleccion
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me._publicos = New Publicos()
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnCerrar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function


   Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
      If ValidaSeleccion() Then
         DialogResult = DialogResult.Cancel
         Close()
      End If
   End Sub

   Private Sub lnkRecuperarUltimo_LinkClicked(sender As Object, e As EventArgs) Handles lnkRecuperarUltimo.Click
      TryCatched(Sub() RecuperarUltimo())
   End Sub

   Protected Overridable Sub RecuperarUltimo()
      Dim fila As BaseFiltrosAdmin = New BaseFiltrosAdmin(Me._tipoFiltro, BaseFiltrosAdmin.Estados.Recuperar)
      fila.ShowDialog()
      Me._nombreFiltro = fila.txtNombreArchivo.Text
      If Not String.IsNullOrEmpty(Me._nombreFiltro) Then
         Me.CargarClase()
         Me.RefrescoDatosGrilla()
      End If
   End Sub

   Public Sub CargarClase(nombreFiltro As String)
      _nombreFiltro = nombreFiltro
      CargarClase()
   End Sub
   Protected Overridable Sub CargarClase()
      Throw New Exception("Sobreescribir CargarClase()")
   End Sub


   Protected Overridable Sub RefrescoDatosGrilla()
      For Each cl As UltraWinGrid.UltraGridColumn In Me.dgvDatos.DisplayLayout.Bands(0).Columns
         If Not Me._columnasAMostrar.Contains(cl.Key) Then
            cl.Hidden = True
         End If
      Next
   End Sub

   Private Sub lnkGrabarFiltro_LinkClicked(sender As Object, e As EventArgs) Handles lnkGrabarFiltro.Click
      TryCatched(
         Sub()
            Dim fila As BaseFiltrosAdmin = New BaseFiltrosAdmin(Me._tipoFiltro, BaseFiltrosAdmin.Estados.Grabar)
            fila.ShowDialog()
            _nombreFiltro = fila.txtNombreArchivo.Text
            If Not String.IsNullOrEmpty(Me._nombreFiltro) Then
               Dim reg As Reglas.FiltrosValores = New Reglas.FiltrosValores()
               reg.GrabarFiltros(Me._tipoFiltro, Me._nombreFiltro, Me.GetValoresColumnasFiltros())

               MessageBox.Show("Filtro guardado satisfactoriamente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         End Sub)
   End Sub

   Private Function GetValoresColumnasFiltros() As List(Of Entidades.FiltroValor)
      Dim fv As Entidades.FiltroValor
      Dim fvs As List(Of Entidades.FiltroValor) = New List(Of Entidades.FiltroValor)()
      Dim i As Integer = 0

      For Each fil As UltraWinGrid.UltraGridRow In Me.dgvDatos.Rows
         For Each ce As UltraWinGrid.UltraGridCell In fil.Cells
            fv = New Entidades.FiltroValor()
            fv.IdTipoFiltro = Me._tipoFiltro
            fv.IdNombreFiltro = Me._nombreFiltro
            fv.IdColumna = ce.Column.Key
            If ce.Value IsNot Nothing Then
               fv.Valor = ce.Value.ToString()
            Else
               fv.Valor = String.Empty
            End If
            fv.IdRegistro = i
            fvs.Add(fv)
         Next
         i += 1
      Next

      Return fvs

   End Function

   Private Sub lnkAgregarTodos_LinkClicked(sender As Object, e As EventArgs) Handles lnkAgregarTodos.Click
      TryCatched(Sub() AgregarTodos())
   End Sub

   Protected Overridable Sub AgregarTodos()
      Throw New Exception("Sobreescribir AgregarTodos()")
   End Sub

   Private Sub lnkLimpiarFiltros_LinkClicked(sender As Object, e As EventArgs) Handles lnkLimpiarFiltros.Click
      TryCatched(Sub() LimpiarFiltros())
   End Sub

   Protected Overridable Sub LimpiarFiltros()
      Throw New Exception("Sobreescribir AgregarTodos()")
   End Sub

   Protected Overridable Function ValidaSeleccion() As Boolean
      If Not _permiteSinSeleccion AndAlso dgvDatos.Count = 0 Then
         ShowMessage(String.Format("Debe seleccionar al menos un/a {0}.", Text))
         Return False
      End If
      Return True
   End Function

   'Protected Overrides Function ValidaSeleccion() As Boolean
   '   Dim result As Boolean = MyBase.ValidaSeleccion()
   '   If Not _permiteSinSeleccion AndAlso _filtros.Count = 0 Then
   '      MessageBox.Show("Debe seleccionar al menos una Categoria.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
   '      Return False
   '   End If
   '   Return result
   'End Function

End Class
Option Strict Off

Imports Infragistics.Win.UltraWinGrid

Public Class PlantillasCalidadDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _dtListasControl As DataTable
   Private _dtProductosListasControl As DataTable
   Private _cargandoPantalla As Boolean


#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.PlantillaListaControl)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._cargandoPantalla = True

      Me._publicos = New Publicos()

      Me._cargandoPantalla = False

      Me.CierraAutomaticamente = True

      Me.CargarListasControl(True)



      Me.tssProductosListaControl.Text = ugProductoListasControl.Rows.Count.ToString() & " Registros"
      Me.tssListasControlAsignar.Text = ugListasControl.Rows.Count.ToString() & " Registros"

      spcDatos.Enabled = True

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         Me.CargarProximoNumero()

         '   Me._dtProductosListasControl.Clear()
         Me.ChequeaEstructuraPlantillasListasControl()
      Else
         Me.CargarPlantillasListasControl(True)
         ' Me.ugProductoListasControl.DataSource = DirectCast(Me._entidad, Entidades.PlantillaListaControl).ListasControl
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.PlantillasListasControl()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()

      DirectCast(Me._entidad, Entidades.PlantillaListaControl).ListasControl = _dtProductosListasControl

      MyBase.Aceptar()


   End Sub

#End Region

#Region "Eventos"
   Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
      Try
         AgregarListaAProducto()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub btnSacar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSacar.Click
      Try
         Me.SacarListaDeProducto()
      Catch ex As Exception
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub ugUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugListasControl.AfterRowFilterChanged
      Me.tssProductosListaControl.Text = Me.ugListasControl.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

   Private Sub ugListasControlUsuarios_AfterRowFilterChanged(sender As Object, e As AfterRowFilterChangedEventArgs) Handles ugProductoListasControl.AfterRowFilterChanged
      Me.tssListasControlAsignar.Text = Me.ugProductoListasControl.Rows.FilteredInRowCount.ToString() & " Registros"
   End Sub

#End Region

#Region "Metodos"
   Private Sub ChequeaEstructuraPlantillasListasControl()
      If Me._dtProductosListasControl Is Nothing Then
         Me._dtProductosListasControl = New DataTable()
         Me._dtProductosListasControl.Columns.Add("IdPlantillaCalidad", System.Type.GetType("System.Int32"))
         Me._dtProductosListasControl.Columns.Add("IdListaControl", System.Type.GetType("System.Int32"))
         Me._dtProductosListasControl.Columns.Add("NombreListaControl", System.Type.GetType("System.String"))

         bdsProductosListasControl.Filter = String.Empty
         bdsProductosListasControl.DataSource = _dtProductosListasControl

         Me.FormateaGrillaPlantillasListasControl()
      End If
   End Sub
   Private Sub CargarProximoNumero()
      Dim pla As Reglas.PlantillasListasControl = New Reglas.PlantillasListasControl()
      Me.txtIdPlanilla.Text = pla.GetProximoId().ToString()
   End Sub

   Private Sub CargarListasControl(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then
         _dtListasControl = New Reglas.ListasControl()._GetTodos()
         bdsListasControl.DataSource = _dtListasControl
         Me.FormateaGrillaListasControl()
      End If
   End Sub

   Private Sub CargarPlantillasListasControl(tablaVacia As Boolean)
      If Not Me._cargandoPantalla Then

         _dtProductosListasControl = DirectCast(Me._entidad, Entidades.PlantillaListaControl).ListasControl

         bdsProductosListasControl.Filter = String.Empty
         bdsProductosListasControl.DataSource = _dtProductosListasControl

         Me.FormateaGrillaPlantillasListasControl()
      End If
   End Sub

   Private Sub FormateaGrillaListasControl()
      FormateaGrillaListasControl(Me.ugListasControl)
   End Sub

   Private Sub FormateaGrillaPlantillasListasControl()
      FormateaGrillaListasControl(Me.ugProductoListasControl)
   End Sub

   Private Sub FormateaGrillaListasControl(grilla As UltraGrid)
      Dim col As Integer = 0
      Eniac.Win.Ayudante.Grilla.AgregarFiltroEnLinea(grilla, {"Nombre"})
      With grilla.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
         Next

         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("IdListaControl"), "Código", col, 70)
         Eniac.Win.Ayudante.Grilla.FormatearColumna(.Columns("NombreListaControl"), "Nombre", col, 250)

      End With
   End Sub

   Private Sub AgregarListaAProducto()
      Me.Cursor = Cursors.WaitCursor

      If ugListasControl.Selected.Rows.Count = 0 And ugListasControl.ActiveRow IsNot Nothing Then
         ugListasControl.ActiveRow.Selected = True
      End If

      Try
         Dim drListaCol As List(Of DataRow) = New List(Of DataRow)()
         For Each dgLista As UltraGridRow In ugListasControl.Selected.Rows
            If dgLista.ListObject IsNot Nothing AndAlso
               TypeOf (dgLista.ListObject) Is DataRowView AndAlso
               DirectCast(dgLista.ListObject, DataRowView).Row IsNot Nothing Then

               For Each item As DataRow In _dtProductosListasControl.Rows
                  If item("IdListaControl") = Integer.Parse(dgLista.Cells("IdListaControl").Value.ToString()) Then
                     Throw New Exception("Ya existe la lista de control: " & dgLista.Cells("NombreListaControl").Value.ToString())
                  End If
               Next

               drListaCol.Add(DirectCast(dgLista.ListObject, DataRowView).Row)


            End If
         Next
         For Each drLista As DataRow In drListaCol
            Dim drProductoListasControl As DataRow = _dtProductosListasControl.NewRow()

            For Each dc As DataColumn In _dtListasControl.Columns
               If drProductoListasControl.Table.Columns.Contains(dc.ColumnName) Then
                  drProductoListasControl(dc.ColumnName) = drLista(dc.ColumnName)
                  drProductoListasControl("IdListaControl") = drLista("IdListaControl")
               End If
            Next
            drProductoListasControl("IdPlantillaCalidad") = Integer.Parse(Me.txtIdPlanilla.Text.ToString())

            _dtProductosListasControl.Rows.Add(drProductoListasControl)
            _dtProductosListasControl.AcceptChanges()
            _dtListasControl.AcceptChanges()

         Next

      Catch
         _dtProductosListasControl.RejectChanges()
         _dtListasControl.RejectChanges()
         Throw
      End Try

   End Sub

   Private Sub SacarListaDeProducto()
      If ugProductoListasControl.Selected.Rows.Count = 0 And ugProductoListasControl.ActiveRow IsNot Nothing Then
         ugProductoListasControl.ActiveRow.Selected = True
      End If

      Try
         Dim drProductoListaControl As List(Of DataRow) = New List(Of DataRow)()
         For Each dgRow As UltraGridRow In ugProductoListasControl.Selected.Rows
            If dgRow.ListObject IsNot Nothing AndAlso
               TypeOf (dgRow.ListObject) Is DataRowView AndAlso
               DirectCast(dgRow.ListObject, DataRowView).Row IsNot Nothing Then
               drProductoListaControl.Add(DirectCast(dgRow.ListObject, DataRowView).Row)
            End If
         Next

         For Each drLista As DataRow In drProductoListaControl
            drLista.Delete()
         Next

         _dtProductosListasControl.AcceptChanges()
         _dtListasControl.AcceptChanges()

      Catch
         _dtProductosListasControl.RejectChanges()
         _dtListasControl.RejectChanges()
         Throw
      End Try
   End Sub

   Private Function ValidaLinea() As Boolean
      If Me._dtProductosListasControl IsNot Nothing Then
         For Each item As DataRow In _dtProductosListasControl.Rows
            If item("IdListaControl") = Integer.Parse(ugListasControl.ActiveRow.Cells("IdListaControl").Value.ToString()) Then
               Throw New Exception("Ya existe la lista de control.")
            End If
         Next
      End If
      Return True
   End Function


#End Region


End Class
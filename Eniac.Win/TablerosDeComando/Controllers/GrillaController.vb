Public MustInherit Class GrillaController
   Implements IDisposable

   Public Event SolicitaRefrescarGrilla(sender As Object, e As EventArgs)

   Protected WithEvents _grilla As UltraGrid
   Protected _panel As Entidades.TableroControlPanel
   Protected _parametros As String
   Protected ReadOnly Property Grilla As UltraGrid
      Get
         Return _grilla
      End Get
   End Property

   Protected rTablero As Reglas.TableroDeComando
   Public Filtros As Entidades.TablerosDeComando.FiltroTableros
   Public Sub New(grilla As UltraGrid, panel As Entidades.TableroControlPanel)
      _grilla = grilla
      _panel = panel

      If panel.BackColor1.HasValue Then
         grilla.DisplayLayout.Override.RowAppearance.BackColor = Color.FromArgb(panel.BackColor1.Value)
      Else
         grilla.DisplayLayout.Override.RowAppearance.BackColor = Nothing
      End If
      If panel.ForeColor1.HasValue Then
         grilla.DisplayLayout.Override.RowAppearance.ForeColor = Color.FromArgb(panel.ForeColor1.Value)
      Else
         grilla.DisplayLayout.Override.RowAppearance.ForeColor = Nothing
      End If

      If panel.BackColor2.HasValue Then
         grilla.DisplayLayout.Override.RowAlternateAppearance.BackColor = Color.FromArgb(panel.BackColor2.Value)
      Else
         grilla.DisplayLayout.Override.RowAlternateAppearance.BackColor = Nothing
      End If
      If panel.ForeColor2.HasValue Then
         grilla.DisplayLayout.Override.RowAlternateAppearance.ForeColor = Color.FromArgb(panel.ForeColor2.Value)
      Else
         grilla.DisplayLayout.Override.RowAlternateAppearance.ForeColor = Nothing
      End If

   End Sub

   Private Sub _grilla_DoubleClickRow(sender As Object, e As Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs) Handles _grilla.DoubleClickRow
      Try
         Dim dr As DataRow = _grilla.FilaSeleccionada(Of DataRow)(e.Row)
         If dr IsNot Nothing AndAlso dr.Table.Columns.Contains("IdCliente") AndAlso IsNumeric(dr("IdCliente")) Then
            Dim idCliente As Long = Long.Parse(dr("IdCliente").ToString())
            Dim cliente As Entidades.Cliente = New Reglas.Clientes().GetUno(idCliente)
            cliente.Usuario = actual.Nombre

            Using frmCliente As ClientesDetalle = New ClientesDetalle(cliente)
               frmCliente.CierraAutomaticamente = True
               frmCliente.StateForm = Eniac.Win.StateForm.Actualizar
               If frmCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
                  PerformSolicitaRefrescarGrilla(Me, Nothing)
               End If
            End Using

         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, _grilla.FindForm().Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Protected Sub PerformSolicitaRefrescarGrilla(sender As Object, e As EventArgs)
      RaiseEvent SolicitaRefrescarGrilla(sender, e)
   End Sub

   Public Function SetReglaTablero(regla As Reglas.TableroDeComando) As GrillaController
      rTablero = regla
      Return Me
   End Function

   Public Sub SetDataSource(datasource As Object)
      Dim _dtTemp As DataTable = Nothing
      If TypeOf (Grilla.DataSource) Is DataTable Then _dtTemp = DirectCast(Grilla.DataSource, DataTable)
      Grilla.DataSource = datasource
      FormatearGrilla()

      Grilla.ActiveRow = Nothing

      If _dtTemp IsNot Nothing Then
         _dtTemp.Dispose()
      End If
   End Sub

   Public MustOverride Function GetDatos(filtros As Entidades.TablerosDeComando.FiltroTableros) As DataTable ' categorias As Entidades.Categoria(), actualizarAplicacion As Entidades.Publicos.SiNoTodos) As DataTable

   Private Sub FormatearGrilla()
      'Grilla.Text = Publicos.GetEnumString(_tipo)
      Grilla.Text = If(_panel IsNot Nothing, _panel.NombrePanel, String.Empty)
      Grilla.DisplayLayout.AutoFitStyle = AutoFitStyle.ExtendLastColumn
      Grilla.SetGroupByVisible(False)
      With Grilla.DisplayLayout.Bands(0)
         Dim pos As Integer = 0

         For Each col As UltraGridColumn In Grilla.DisplayLayout.Bands(0).Columns
            col.Hidden = True
            col.CellActivation = Activation.NoEdit
         Next

         FormatearGrillasPre(pos)

         FormatearGrillaCamposPropios(pos)

         FormatearGrillasPos(pos)

         AgregarFiltrosEnLinea()
         AgregarTotales()
      End With

   End Sub
   Protected MustOverride Sub FormatearGrillaCamposPropios(ByRef pos As Integer)

   Protected Overridable Sub FormatearGrillasPre(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("Color").FormatearColumna("", pos, 26).AnchoMinimoMaximo(26, 26).Style = UltraWinGrid.ColumnStyle.Color
         .Columns("CodigoCliente").FormatearColumna("Código", pos, 80, HAlign.Right, True).AnchoMinimoMaximo(80, 80)
         .Columns("NombreCliente").FormatearColumna("Nombre Cliente", pos, 200)
         .Columns("NombreDeFantasia").FormatearColumna("Nombre Fantasia", pos, 200)

         .Columns("NombreCliente").Hidden = Filtros.VerNombreCliente <> Entidades.TablerosDeComando.VerNombreCliente.NombreCliente
         .Columns("NombreDeFantasia").Hidden = Filtros.VerNombreCliente <> Entidades.TablerosDeComando.VerNombreCliente.NombreDeFantasia

      End With
   End Sub
   Protected Overridable Sub FormatearGrillasPos(ByRef pos As Integer)
      With Grilla.DisplayLayout.Bands(0)
         .Columns("NombreCategoria").FormatearColumna("Categoría", pos, 90)
         .Columns("IdAplicacion").FormatearColumna("Aplicación", pos, 80)
         .Columns("Edicion").FormatearColumna("Edición", pos, 80)
         .Columns("ActualizarAplicacion_SN").FormatearColumna("Actualizar", pos, 70, HAlign.Center)
         .Columns("ActualizarAplicacion").OcultoPosicion(True, pos)
      End With
   End Sub

   Protected Overridable Sub AgregarFiltrosEnLinea()
      Grilla.AgregarFiltroEnLinea({"NombreCliente", "NombreDeFantasia"})
   End Sub
   Protected Overridable Sub AgregarTotales()
   End Sub

#Region "IDisposable Support"
   Private disposedValue As Boolean ' To detect redundant calls

   ' IDisposable
   Protected Overridable Sub Dispose(disposing As Boolean)
      If Not Me.disposedValue Then
         If disposing Then
            If TypeOf (Grilla.DataSource) Is IDisposable Then DirectCast(Grilla.DataSource, IDisposable).Dispose()
            _grilla.ClearFilas()
            _grilla = Nothing
         End If
      End If
      Me.disposedValue = True
   End Sub

   Public Sub Dispose() Implements IDisposable.Dispose
      Dispose(True)
      GC.SuppressFinalize(Me)
   End Sub
#End Region

End Class
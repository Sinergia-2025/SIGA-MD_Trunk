Option Strict On
Option Explicit On
Option Infer On
Imports Eniac.Entidades.Filtros
Imports Sync = Eniac.Reglas.ServiciosRest.Sincronizacion
Imports Infragistics.Win.UltraWinGrid

Public Class SincronizacionSubidaV2

   Private _resumenDataSource As List(Of Resumen)

   Private Sub btnSincronizar_Click(sender As Object, e As EventArgs) Handles btnSincronizar.Click
      Try

         btnSincronizar.Enabled = False

         txtLogInformation.Clear()
         txtLogVerbose.Clear()

         _resumenDataSource = New List(Of Resumen)()
         ugResumen.DataSource = _resumenDataSource

         Using syncs = New Reglas.ServiciosRest.Sincronizacion.SyncBaseCollection()

            AddHandler syncs.NotificarEstadoInformation, Sub(sender1, e1) MostrarEstadoInformation(String.Format("{0} - {1}", e1.Tipo.Name, e1.Estado))
            AddHandler syncs.NotificarEstadoVerbose, Sub(sender1, e1) MostrarEstadoVerbose(String.Format("{0} - {1}", e1.Tipo.Name, e1.Estado))
            AddHandler syncs.LuegoObtenerCantidadRegistros, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Cantidad, e1.CantidadRegistros, Nothing, Nothing, Nothing)
            AddHandler syncs.RecibiendoDatos, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Recibiendo, Nothing, e1.RegistrosRecibidos, e1.PaginaActual, Nothing)
            AddHandler syncs.RecibiendoDatosFinalizado, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Recibido, Nothing, e1.RegistrosRecibidos, e1.PaginaActual, Nothing)
            AddHandler syncs.DespuesRecibiendoDatos, Sub(sender1, e1) AddResumen(e1.Tipo, Estado.Recibido, Nothing, Nothing, Nothing, e1.TotalPaginas)

            syncs.Add(New Sync.SyncLocalidades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.SyncRubrosCompras().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.SyncMarcas().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.SyncRubros().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.SyncSubRubros().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.SyncSubSubRubros().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))

            syncs.Add(New Sync.SyncClientes().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.SyncProveedores().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))

            syncs.Add(New Sync.SyncProductos().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked, New ProductosPublicarEnFiltros() With {.SincronizacionSucursal = Entidades.Publicos.SiNoTodos.SI}))
            syncs.Add(New Sync.SyncProductosSucursales().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked, New ProductosPublicarEnFiltros() With {.SincronizacionSucursal = Entidades.Publicos.SiNoTodos.SI}))
            syncs.Add(New Sync.SyncProductosSucursalesPrecios().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked, New ProductosPublicarEnFiltros() With {.SincronizacionSucursal = Entidades.Publicos.SiNoTodos.SI}))

            syncs.Add(New Sync.CRM.SyncCRMCategoriasNovedades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.CRM.SyncCRMEstadosNovedades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.CRM.SyncCRMMediosComunicacionesNovedades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.CRM.SyncCRMMetodosResolucionesNovedades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.CRM.SyncCRMPrioridadesNovedades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.CRM.SyncCRMTiposComentariosNovedades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))

            syncs.Add(New Sync.CRM.SyncCRMNovedades().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))
            syncs.Add(New Sync.CRM.SyncCRMNovedadesSeguimiento().InicializaDatos(chbReenviarTodos.Checked, chbRecibirTodo.Checked))

            syncs.SincronizarAutomaticamente(grabaArchivoLocal:=True)

            'syncs.ImportarAutomaticamente(syncs)
            'syncs.EnviarAutomaticamente(grabaArchivoLocal:=True)


            'syncs.DescargarDatos()
            'syncs.ValidarDatos()
            'syncs.ImportarDatos()

            'syncs.CargarDatos()
            'syncs.EnviarDatos(grabaArchivoLocal:=True)
         End Using

         MostrarEstadoInformation(String.Empty)
         MostrarEstadoInformation("¡¡ Sincronización Finalizada Exitosamente !!")

      Catch ex As Exception
         ShowError(ex)
      Finally
         btnSincronizar.Enabled = True
      End Try
   End Sub

   Private Sub AddResumen(tipo As Type, estado As Estado?, cantidadRegistros As Long?, registrosRecibidos As Integer?, paginaActual As Integer?, totalPaginas As Integer?)
      Dim resumen = _resumenDataSource.FirstOrDefault(Function(x) x.Tipo = tipo.Name)
      If resumen Is Nothing Then
         resumen = New Resumen() With {.Tipo = tipo.Name}
         _resumenDataSource.Add(resumen)
      End If

      If estado.HasValue Then
         resumen.Estado = estado.Value
      End If

      If cantidadRegistros.HasValue Then resumen.TotalRegistros = cantidadRegistros.Value
      If registrosRecibidos.HasValue Then resumen.RegistrosRecibidos = registrosRecibidos.Value
      If paginaActual.HasValue Then resumen.PaginaActual = paginaActual.Value
      If totalPaginas.HasValue Then resumen.TotalPaginas = totalPaginas.Value

      ugResumen.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
      ugResumen.Rows.Refresh(UltraWinGrid.RefreshRow.RefreshDisplay)

   End Sub

   Private Sub MostrarEstadoVerbose(mensaje As String)
      MostrarEstado(mensaje, txtLogVerbose)
   End Sub
   Private Sub MostrarEstadoInformation(mensaje As String)
      MostrarEstado(mensaje, txtLogInformation)
   End Sub

   Private Sub MostrarEstado(mensaje As String, txt As TextBox)
      tssInfo.Text = mensaje
      txt.AppendText(mensaje)
      txt.AppendText(Environment.NewLine)
      txt.SelectionStart = txt.SelectionLength
      Application.DoEvents()
   End Sub


   Public Class Resumen
      Public Property Tipo As String
      Public Property Estado As Estado = SincronizacionSubidaV2.Estado.Pendiente
      Public Property RegistrosRecibidos As Integer
      Public Property TotalRegistros As Long
      Public Property PaginaActual As Integer
      Public Property TotalPaginas As Integer
   End Class
   Public Enum Estado
      Pendiente
      Cantidad
      Recibiendo
      Recibido

   End Enum

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      Close()
   End Sub

   ''Private Sub ugResumen_InitializeRow(sender As Object, e As UltraWinGrid.InitializeRowEventArgs) Handles ugResumen.InitializeRow
   ''   Try
   ''      Dim dr = ugResumen.FilaSeleccionada(Of Resumen)(e.Row)
   ''      If dr IsNot Nothing Then
   ''         Dim cell As UltraGridCell = e.Row.Cells("Estado")
   ''         Select Case dr.Estado
   ''            Case Estado.Pendiente
   ''               SetColorCell(cell, Nothing, Nothing)
   ''            Case Estado.Cantidad
   ''               SetColorCell(cell, Color.Blue, Color.White)
   ''            Case Estado.Recibiendo
   ''               SetColorCell(cell, Color.Yellow, Color.White)
   ''            Case Estado.Recibido
   ''               SetColorCell(cell, Color.Green, Color.White)

   ''         End Select

   ''      End If
   ''   Catch ex As Exception
   ''      ShowError(ex)
   ''   End Try
   ''End Sub
   ''Private Sub SetColorCell(cell As UltraGridCell, backColor As Color, foreColor As Color)
   ''   cell.Appearance.BackColor = backColor
   ''   cell.Appearance.ForeColor = foreColor

   ''   cell.ActiveAppearance.BackColor = backColor
   ''   cell.ActiveAppearance.ForeColor = foreColor
   ''End Sub
End Class
Imports System.Globalization

Public Class ImportarCRM

   Private Class ColumnasExcel
      Public Const LetraIndex As Integer = 0
      Public Const EmisorIndex As Integer = 1
      Public Const NumeroIndex As Integer = 2
      Public Const FechaIndex As Integer = 3
      Public Const NombreClienteIndex As Integer = 4
      Public Const InterlocutorIndex As Integer = 5
      Public Const DescripcionIndex As Integer = 6
      Public Const ComentariosIndex As Integer = 7
      Public Const EstadoIndex As Integer = 8
      'Public Const FinalizadoIndex As Integer = 9
      'Public Const TiempoResoluconIndex As Integer = 2
      Public Const UsuarioAsignadoIndex As Integer = 9
      Public Const PrioridadIndex As Integer = 10
      Public Const CategoriaIndex As Integer = 11
      Public Const ProximoContactoIndex As Integer = 12
      Public Const MedioIndex As Integer = 13
      Public Const AvanceIndex As Integer = 14
      Public Const FechaEstadoIndex As Integer = 15
      'Public Const UsuarioEstadoIndex As Integer = 17
      Public Const UsuarioAltaIndex As Integer = 16
      Public Const ResolucionIndex As Integer = 17
      Public Const SistemaIndex As Integer = 18
      Public Const CodigoFuncionIndex As Integer = 19
      Public Const NombreFuncionIndex As Integer = 20
      Public Const CodigoProyectoIndex As Integer = 21
      Public Const VersionIndex As Integer = 22
      Public Const VersionFechaIndex As Integer = 23
      Public Const PatenteVehiculo As Integer = 24

   End Class

   Public ReadOnly Property TipoNovedad As Entidades.CRMTipoNovedad
      Get
         If cmbTipoNovedad.SelectedIndex < 0 Then
            Return Nothing
         Else
            Return DirectCast(cmbTipoNovedad.SelectedItem, Entidades.CRMTipoNovedad)
         End If
      End Get
   End Property

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   'Private ConexionExcel As Data.OleDb.OleDbConnection

   '  Private ColumnaNombreFantasia As Integer = 0
   '  Private ColumnaCantidad As Integer = 4

   'Private ColumnaNombreProducto As Integer = 0
   'Private ColumnaCodigoProveedor As Integer = 1   'Predeterminado 1 Columna
   'Private ColumnaNombreProducto2 As Integer = 2
   'Private ColumnaPrecioVenta As Integer = 3
   Private ProductosConError As Integer
   Private _estaCargando As Boolean = True
   Private _OrdenCompra As Long = 0

   Private _rangoCeldasColumnaDesdeDefault As String
   Private _rangoCeldasColumnaHastaDefault As String
   Private _rangoCeldasFilaDesdeDefault As String
   Private _rangoCeldasFilaHastaDefault As String

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _rangoCeldasColumnaDesdeDefault = txtRangoCeldasColumnaDesde.Text
         _rangoCeldasColumnaHastaDefault = txtRangoCeldasColumnaHasta.Text
         _rangoCeldasFilaDesdeDefault = txtRangoCeldasFilaDesde.Text
         _rangoCeldasFilaHastaDefault = txtRangoCeldasFilaHasta.Text

         _publicos = New Publicos()

         cboAccion.Items.Insert(0, "Todas")
         cboAccion.Items.Insert(1, "Altas")
         cboAccion.Items.Insert(2, "Modificar")

         cboEstado.Items.Insert(0, "Todos")
         cboEstado.Items.Insert(1, "Validos")
         cboEstado.Items.Insert(2, "Invalidos")

         _publicos.CargaComboCRMTiposNovedades(cmbTipoNovedad)

         CargarValoresIniciales()
         '_publicos.CargaComboFormasDePago(Me.cmbFormaPago, "VENTAS")

         _estaCargando = False
      End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnMostrar.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbImportar.PerformClick()
      End If
      Return MyBase.ProcessCmdKey(msg, keyData)
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargarValoresIniciales())
   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(
      Sub()
         'Por si logra repetir la accion.
         If Not tsbImportar.Enabled Then Exit Sub

         tsbImportar.Enabled = False

         If ugDetalle.Rows.Count = 0 Then Exit Sub

         If ProductosConError > 0 AndAlso ShowPregunta("ATENCION: Existen Pedidos que NO se Importarán. ¿ Confirma el Proceso ?") <> DialogResult.Yes Then
            tsbImportar.Enabled = True
            Exit Sub
         End If

         ugDetalle.DisplayLayout.Bands(0).Columns("EstadoImporta").Hidden = False
         tspImportando.Visible = True

         ImportarDatos()

         ShowMessage("¡El proceso de importación ha finalizado!")
         tspImportando.Value = 0
      End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
         If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
            'Si bien aca lo pude abrir, solo es para obtener el path.
            txtRangoCeldasFilaHasta.Focus()
         End If
      End Sub)
   End Sub

   Private Sub cboEstado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboEstado.SelectedIndexChanged
      TryCatched(
      Sub()
         If Not _estaCargando Then
            tsbImportar.Enabled = (cboEstado.Text <> "Invalidos")
         End If
      End Sub)
   End Sub

   Private Sub btnMostrar_Click(sender As Object, e As EventArgs) Handles btnMostrar.Click
      TryCatched(
      Sub()
         tspImportando.Value = 0

         If String.IsNullOrWhiteSpace(txtArchivoOrigen.Text) Then
            Exit Sub
         End If

         If Not IO.File.Exists(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: El archivo a Importar NO Existe")
            Exit Sub
         End If

         If String.IsNullOrWhiteSpace(txtRangoCeldasColumnaDesde.Text) Or
            String.IsNullOrWhiteSpace(txtRangoCeldasColumnaHasta.Text) Or
            Not IsNumeric(txtRangoCeldasFilaDesde.Text) Or
            Not IsNumeric(txtRangoCeldasFilaHasta.Text) Then
            ShowMessage("Debe indicar el rango de celdas a leer del archivo Excel")
            txtRangoCeldasFilaHasta.Focus()
            Exit Sub
         End If

         Dim rangoExcel = String.Format("[{0}{1}:{2}{3}]",
                                        txtRangoCeldasColumnaDesde.Text.Trim(),
                                        txtRangoCeldasFilaDesde.Text.Trim(),
                                        txtRangoCeldasColumnaHasta.Text.Trim(),
                                        txtRangoCeldasFilaHasta.Text.Trim())


         If cmbTipoNovedad.SelectedIndex < 0 Then
            ShowMessage("ATENCION: El Tipo de Novedad es requerido")
            Exit Sub
         End If

         'If Not bscCodigoProveedor.Selecciono And Not bscProveedor.Selecciono Then
         '   MessageBox.Show("ATENCION: Debe seleccionar el Proveedor", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '   Exit Sub
         'End If

         'If Me.txtOrdenCompra.Text = "" Then
         '   MessageBox.Show("ATENCION: Debe ingresar el numero de Orden de Compra", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '   Exit Sub
         'End If

         'If Me.cmbFormaPago.SelectedIndex = -1 Then
         '   MessageBox.Show("ATENCION: Debe seleccionar la Forma de Pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         '   Exit Sub
         'End If

         'Dim OC As DataTable = New Reglas.OrdenesCompra().Get1(actual.Sucursal.IdSucursal, Long.Parse(Me.txtOrdenCompra.Text.ToString()))

         'If OC.Rows.Count <> 0 Then
         '   MessageBox.Show("Orden de compra existente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         '   Me._OrdenCompra = Long.Parse(OC.Rows(0).Item("NumeroOrdenCompra").ToString())
         'Else
         '   Me._OrdenCompra = 0
         'End If

         tsbImportar.Enabled = True

         LeerExcel(rangoExcel)
         ugDetalle.DisplayLayout.Bands(0).Columns("EstadoImporta").Hidden = True
      End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      txtArchivoOrigen.Clear()

      txtRangoCeldasColumnaDesde.Text = _rangoCeldasColumnaDesdeDefault
      txtRangoCeldasColumnaHasta.Text = _rangoCeldasColumnaHastaDefault
      txtRangoCeldasFilaDesde.Text = _rangoCeldasFilaDesdeDefault
      txtRangoCeldasFilaHasta.Text = _rangoCeldasFilaHastaDefault

      cboAccion.SelectedIndex = 0
      cboEstado.SelectedIndex = 0

      'Me.bscProveedor.Text = ""
      'Me.bscCodigoProveedor.Text = ""
      'Me.txtOrdenCompra.Text = ""

      ugDetalle.ClearFilas()

      tspImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable
      Dim dt = New Reglas.CRMNovedades().GetEmpty()
      dt.Columns.Add("Importa", GetType(Boolean))
      dt.Columns.Add("EstadoImporta", GetType(String))

      dt.Columns.Add("Accion", GetType(String))
      'FALTAN EN GRILLA
      dt.Columns.Add(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString(), GetType(String))
      dt.Columns.Add(Entidades.Funcion.Columnas.Nombre.ToString(), GetType(String))

      dt.Columns.Add("Mensaje", GetType(String))
      Return dt
   End Function

   Private Function AbrirExcel(ArchivoXLS As String) As OleDb.OleDbConnection
      Dim m_sConn1 As String
      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If

      Dim ConexionExcel = New OleDb.OleDbConnection(m_sConn1)
      Return ConexionExcel
   End Function

   Private Sub ColumnasGrilla()
      If _estaCargando Then Exit Sub

      ugDetalle.DisplayLayout.Bands(0).Columns("NombreProducto").Width = 200
   End Sub

   'TODO: BusquedasCacheadas es obsoleto. Para cambiarlo/quitarlo es necesario revisar todo el comportamiento
#Disable Warning BC40008 ' Type or member is obsolete
   Private Sub LeerExcel(rangoExcel As String)
      Try
         'Dim tipoNovedad As Entidades.CRMTipoNovedad = DirectCast(cmbTipoNovedad.SelectedItem, Entidades.CRMTipoNovedad)
         Dim idTipoNovedad As String = TipoNovedad.IdTipoNovedad
         Dim formatoFechas As String = txtFormatoFechas.Text

         BusquedasCacheadas.Reset()

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Reglas.Publicos = New Reglas.Publicos
         'Dim oPedido As Reglas.Pedidos = New Reglas.Pedidos
         'Dim rOrdenesCompraPedido As Reglas.OrdenesCompraPedidos = New Reglas.OrdenesCompraPedidos

         'Dim AnchoIdProducto As Integer
         'AnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto")

         'Dim AnchoNombreProducto As Integer
         'AnchoNombreProducto = oPublicos.GetAnchoCampo("Productos", "NombreProducto")

         'Dim AnchoNombreMarca As Integer
         'AnchoNombreMarca = oPublicos.GetAnchoCampo("Marcas", "NombreMarca")

         'Dim AnchoNombreRubro As Integer
         'AnchoNombreRubro = oPublicos.GetAnchoCampo("Rubros", "NombreRubro")

         'Dim AnchoCodigoDeBarras As Integer
         'AnchoCodigoDeBarras = oPublicos.GetAnchoCampo("Productos", "CodigoDeBarras")

         'tsbImportar.Enabled = False
         'tsbSalir.Enabled = False

         ProductosConError = 0


         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         'Dim Cliente As Integer = 4
         'Dim dr As DataRow

         Dim PrimeraFila As Boolean = True

         Dim rNovedades As Reglas.CRMNovedades = New Reglas.CRMNovedades()
         Dim rClientes As Reglas.Clientes = New Reglas.Clientes()


         Using ConexionExcel = AbrirExcel(txtArchivoOrigen.Text)
            ConexionExcel.Open()
            Using DA = New OleDb.OleDbDataAdapter("Select * From " + rangoExcel, ConexionExcel)
               Using ds = New DataSet()
                  DA.Fill(ds)


                  'DA1 = New System.Data.OleDb.OleDbDataAdapter("Select * From A2:BA3", Me.ConexionExcel)
                  'DA1.Fill(ds1)
                  Dim lineaProcesada As Long = 0
                  Dim drTemp As DataRow


                  Try
                     For Each dr In ds.Tables(0).AsEnumerable()
                        lineaProcesada += 1

                        Dim Accion = "A"
                        Dim Importa = True
                        Dim Mensaje = New StringBuilder()

                        'System.Windows.Forms.Application.DoEvents()

                        drCl = dt.NewRow()

                        drCl(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()) = TipoNovedad.IdTipoNovedad

                        Dim letra = String.Empty
                        Dim centroEmisor = 1S
                        Dim idNovedad = 0L

                        If IsNumeric(dr(ColumnasExcel.NumeroIndex)) Then
                           letra = dr(ColumnasExcel.LetraIndex).ToString()
                           centroEmisor = Convert.ToInt16(dr(ColumnasExcel.EmisorIndex))

                           idNovedad = Convert.ToInt32(dr(ColumnasExcel.NumeroIndex))
                           If idNovedad > 0 Then
                              If rNovedades.Existe(idTipoNovedad, letra, centroEmisor, idNovedad) Then
                                 Accion = "M"
                              End If
                           End If
                           drCl(Entidades.CRMNovedad.Columnas.Letra.ToString()) = letra
                           drCl(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()) = centroEmisor
                           drCl(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()) = idNovedad
                        ElseIf Not String.IsNullOrWhiteSpace(GetValorString(dr, ColumnasExcel.NumeroIndex)) Then
                           Accion = "X"
                           Mensaje.AppendFormat("El Número no es numérico - ")
                        End If

                        If String.IsNullOrWhiteSpace(drCl(Entidades.CRMNovedad.Columnas.Letra.ToString()).ToString()) Then
                           letra = TipoNovedad.LetrasHabilitadas
                           drCl(Entidades.CRMNovedad.Columnas.Letra.ToString()) = letra
                        End If
                        If IsDBNull(drCl(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString())) Then
                           centroEmisor = 1
                           drCl(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString()) = centroEmisor
                        End If
                        If IsDBNull(drCl(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())) Then
                           centroEmisor = 1
                           drCl(Entidades.CRMNovedad.Columnas.IdNovedad.ToString()) = 0
                        End If

                        Dim fecha As DateTime = Nothing
                        If Not IsDBNull(dr(ColumnasExcel.FechaIndex)) AndAlso
                           DateTime.TryParseExact(dr(ColumnasExcel.FechaIndex).ToString(), formatoFechas,
                                                  Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, fecha) Then
                           drCl(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString()) = fecha
                           drCl(Entidades.CRMNovedad.Columnas.FechaAlta.ToString()) = fecha
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("La fecha tiene un formato incorrecto - ")
                        End If

                        Dim nombreCliente As String = GetValorString(dr, ColumnasExcel.NombreClienteIndex)
                        drCl(Entidades.Cliente.Columnas.NombreCliente.ToString()) = nombreCliente

                        If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES) Then
                           drTemp = BusquedasCacheadas.Instancia.BuscaClientePorFantasia(nombreCliente)
                           'If drTemp Is Nothing Then
                           '   drTemp = BusquedasCacheadas.Instancia.BuscaClientePorFantasia(nombreCliente)
                           'End If
                           If drTemp IsNot Nothing Then
                              drCl(Entidades.CRMNovedad.Columnas.IdCliente.ToString()) = drTemp(Entidades.Cliente.Columnas.IdCliente.ToString())
                              drCl(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = drTemp(Entidades.Cliente.Columnas.CodigoCliente.ToString())
                           Else
                              If TipoNovedad.DinamicoRequerido(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES) Then
                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe el Cliente - ")
                              End If
                           End If
                        ElseIf TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS) Then
                           drTemp = BusquedasCacheadas.Instancia.BuscaProspectoPorFantasia(nombreCliente)
                           'If drTemp Is Nothing Then
                           '   drTemp = BusquedasCacheadas.Instancia.BuscaClientePorFantasia(nombreCliente)
                           'End If
                           If drTemp IsNot Nothing Then
                              drCl(Entidades.CRMNovedad.Columnas.IdProspecto.ToString()) = drTemp("IdProspecto")
                              drCl(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = drTemp("CodigoProspecto")
                           Else
                              If TipoNovedad.DinamicoRequerido(Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS) Then
                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe el Cliente - ")
                              End If
                           End If
                        ElseIf TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES) Then
                           drTemp = BusquedasCacheadas.Instancia.BuscaProveedores(nombreCliente)
                           'If drTemp Is Nothing Then
                           '   drTemp = BusquedasCacheadas.Instancia.BuscaClientePorFantasia(nombreCliente)
                           'End If
                           If drTemp IsNot Nothing Then
                              drCl(Entidades.CRMNovedad.Columnas.IdProveedor.ToString()) = drTemp(Entidades.Proveedor.Columnas.IdProveedor.ToString())
                              drCl(Entidades.Cliente.Columnas.CodigoCliente.ToString()) = drTemp(Entidades.Proveedor.Columnas.CodigoProveedor.ToString())
                           Else
                              If TipoNovedad.DinamicoRequerido(Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES) Then
                                 Accion = "X"
                                 Mensaje.AppendFormat("No existe el Cliente - ")
                              End If
                           End If
                        End If


                        drCl(Entidades.CRMNovedad.Columnas.Interlocutor.ToString()) = GetValorString(dr, ColumnasExcel.InterlocutorIndex)
                        drCl(Entidades.CRMNovedad.Columnas.IdSistema.ToString()) = dr(ColumnasExcel.SistemaIndex)
                        Dim descripcion As String = GetValorString(dr, ColumnasExcel.DescripcionIndex)
                        drCl(Entidades.CRMNovedad.Columnas.Descripcion.ToString()) = descripcion
                        If String.IsNullOrWhiteSpace(descripcion) Then
                           Accion = "X"
                           Mensaje.AppendFormat("La Descripción es requerida - ")
                        End If

                        Dim comentario As String = GetValorString(dr, ColumnasExcel.ComentariosIndex)
                        drCl(Entidades.CRMNovedadSeguimiento.Columnas.Comentario.ToString()) = comentario

                        Dim nombreEstadoNovedad As String = GetValorString(dr, ColumnasExcel.EstadoIndex)
                        drCl(Entidades.CRMEstadoNovedad.Columnas.NombreEstadoNovedad.ToString()) = nombreEstadoNovedad
                        drTemp = BusquedasCacheadas.Instancia.BuscaCRMEstadoNovedad(idTipoNovedad, nombreEstadoNovedad)
                        If drTemp IsNot Nothing Then
                           drCl(Entidades.CRMNovedad.Columnas.IdEstadoNovedad.ToString()) = drTemp(Entidades.CRMEstadoNovedad.Columnas.IdEstadoNovedad.ToString())
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("No existe el Estado de Novedad - ")
                        End If

                        Dim nombreUsuario As String = GetValorString(dr, ColumnasExcel.UsuarioAsignadoIndex)
                        If Not BusquedasCacheadas.Instancia.ExisteUsuarios(nombreUsuario) Then
                           Accion = "X"
                           Mensaje.AppendFormat("No existe el Usuario Asignado - ")
                        End If
                        drCl(Entidades.CRMNovedad.Columnas.IdUsuarioAsignado.ToString()) = nombreUsuario
                        drCl(Entidades.CRMNovedad.Columnas.IdUsuarioResponsable.ToString()) = nombreUsuario

                        Dim nombrePrioridadNovedad As String = GetValorString(dr, ColumnasExcel.PrioridadIndex)
                        drCl(Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString()) = nombrePrioridadNovedad
                        drTemp = BusquedasCacheadas.Instancia.BuscaCRMPrioridadesNovedades(idTipoNovedad, nombrePrioridadNovedad)
                        If drTemp IsNot Nothing Then
                           drCl(Entidades.CRMNovedad.Columnas.IdPrioridadNovedad.ToString()) = drTemp(Entidades.CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString())
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("No existe el Prioridad de Novedad - ")
                        End If

                        Dim nombreCategoriaNovedad As String = GetValorString(dr, ColumnasExcel.CategoriaIndex)
                        drCl(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()) = nombreCategoriaNovedad
                        drTemp = BusquedasCacheadas.Instancia.BuscaCRMCategoriasNovedades(idTipoNovedad, nombreCategoriaNovedad)
                        If drTemp IsNot Nothing Then
                           drCl(Entidades.CRMNovedad.Columnas.IdCategoriaNovedad.ToString()) = drTemp(Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString())
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("No existe el Categoria de Novedad - ")
                        End If

                        Dim nombreMetodoResolucionNovedad As String = GetValorString(dr, ColumnasExcel.ResolucionIndex)
                        drCl(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()) = nombreMetodoResolucionNovedad
                        drTemp = BusquedasCacheadas.Instancia.BuscaCRMMetodosResolucionesNovedades(idTipoNovedad, nombreMetodoResolucionNovedad)
                        If drTemp IsNot Nothing Then
                           drCl(Entidades.CRMNovedad.Columnas.IdMetodoResolucionNovedad.ToString()) = drTemp(Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString())
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("No existe el Metodo Resolucion de Novedad - ")
                        End If

                        fecha = Nothing
                        If Not IsDBNull(dr(ColumnasExcel.FechaIndex)) AndAlso
                           DateTime.TryParseExact(dr(ColumnasExcel.ProximoContactoIndex).ToString(), formatoFechas,
                                                  Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, fecha) Then
                           drCl(Entidades.CRMNovedad.Columnas.FechaProximoContacto.ToString()) = fecha
                        End If

                        Dim nombreMedio As String = GetValorString(dr, ColumnasExcel.MedioIndex)
                        drCl(Entidades.CRMMedioComunicacionNovedad.Columnas.NombreMedioComunicacionNovedad.ToString()) = nombreMedio
                        drTemp = BusquedasCacheadas.Instancia.BuscaCRMMediosComunicacionesNovedades(idTipoNovedad, nombreMedio)
                        If drTemp IsNot Nothing Then
                           drCl(Entidades.CRMNovedad.Columnas.IdMedioComunicacionNovedad.ToString()) = drTemp(Entidades.CRMMedioComunicacionNovedad.Columnas.IdMedioComunicacionNovedad.ToString())
                        Else
                           Accion = "X"
                           Mensaje.AppendFormat("No existe el Medio de Comunicacion de Novedad - ")
                        End If

                        If IsNumeric(dr(ColumnasExcel.AvanceIndex)) Then
                           drCl(Entidades.CRMNovedad.Columnas.Avance.ToString()) = Convert.ToDecimal(dr(ColumnasExcel.AvanceIndex))
                        ElseIf Not String.IsNullOrWhiteSpace(GetValorString(dr, ColumnasExcel.AvanceIndex)) Then
                           Accion = "X"
                           Mensaje.AppendFormat("El Avance no es numérico - ")
                        End If

                        fecha = Nothing
                        If Not IsDBNull(dr(ColumnasExcel.FechaIndex)) AndAlso
                           DateTime.TryParseExact(dr(ColumnasExcel.FechaEstadoIndex).ToString(), formatoFechas,
                                                  Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, fecha) Then
                           drCl(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()) = fecha
                        Else
                           drCl(Entidades.CRMNovedad.Columnas.FechaEstadoNovedad.ToString()) = drCl(Entidades.CRMNovedad.Columnas.FechaNovedad.ToString())
                        End If

                        'nombreUsuario = GetValorString(dr, ColumnasExcel.UsuarioEstadoIndex)
                        'If Not BusquedasCacheadas.Instancia.ExisteUsuarios(nombreUsuario) Then
                        '   Accion = "X"
                        '   Mensaje.AppendFormat("No existe el Usuario Estado - ")
                        'End If
                        'drCl(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString()) = nombreUsuario

                        nombreUsuario = GetValorString(dr, ColumnasExcel.UsuarioAltaIndex)
                        If Not BusquedasCacheadas.Instancia.ExisteUsuarios(nombreUsuario) Then
                           Accion = "X"
                           Mensaje.AppendFormat("No existe el Usuario Alta - ")
                        End If
                        drCl(Entidades.CRMNovedad.Columnas.IdUsuarioAlta.ToString()) = nombreUsuario
                        drCl(Entidades.CRMNovedad.Columnas.IdUsuarioEstadoNovedad.ToString()) = nombreUsuario

                        Dim codigoFuncion As String = GetValorString(dr, ColumnasExcel.CodigoFuncionIndex)
                        drCl(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()) = codigoFuncion
                        Dim nombreFuncion As String = GetValorString(dr, ColumnasExcel.NombreFuncionIndex)
                        drCl(Entidades.Funcion.Columnas.Nombre.ToString()) = nombreFuncion

                        If Not String.IsNullOrWhiteSpace(codigoFuncion) Then
                           If Not BusquedasCacheadas.Instancia.ExisteFuncion(codigoFuncion) Then
                              Accion = "X"
                              Mensaje.AppendFormat("No existe la Función del Sistema - ")
                           End If
                        Else
                           If Not BusquedasCacheadas.Instancia.ExisteFuncionPorNombre(nombreFuncion) Then
                              Accion = "X"
                              Mensaje.AppendFormat("No existe la Función del Sistema - ")
                           Else
                              Dim drFunc As DataRow = BusquedasCacheadas.Instancia.BuscaFuncionPorNombre(nombreFuncion)
                              drCl(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()) = drFunc(Entidades.Funcion.Columnas.Id.ToString())
                           End If
                        End If

                        If Ayudante.ImportarExcel.IsNumeric(dr, ColumnasExcel.CodigoProyectoIndex) Then
                           Dim idProyecto As Integer = Convert.ToInt32(Ayudante.ImportarExcel.GetValorDecimal(dr, ColumnasExcel.CodigoProyectoIndex))
                           drCl(Entidades.CRMNovedad.Columnas.IdProyecto.ToString()) = idProyecto
                           If Not BusquedasCacheadas.Instancia.ExisteProyecto(idProyecto) Then
                              Accion = "X"
                              Mensaje.AppendFormat("No existe el Proyecto - ")
                           End If
                        End If

                        drCl(Entidades.CRMNovedad.Columnas.Version.ToString()) = dr(ColumnasExcel.VersionIndex)

                        fecha = Nothing
                        If Not IsDBNull(dr(ColumnasExcel.VersionFechaIndex)) AndAlso
                           DateTime.TryParseExact(dr(ColumnasExcel.VersionFechaIndex).ToString(), formatoFechas,
                                                  Threading.Thread.CurrentThread.CurrentCulture, DateTimeStyles.None, fecha) Then
                           drCl(Entidades.CRMNovedad.Columnas.VersionFecha.ToString()) = fecha

                        End If
                        drCl(Entidades.CRMNovedad.Columnas.RevisionAdministrativa.ToString()) = False
                        drCl(Entidades.CRMNovedad.Columnas.Priorizado.ToString()) = False

                        drCl(Entidades.CRMNovedad.Columnas.IdSucursalService.ToString()) = 0
                        drCl(Entidades.CRMNovedad.Columnas.CentroEmisorService.ToString()) = 0
                        drCl(Entidades.CRMNovedad.Columnas.NumeroComprobanteService.ToString()) = 0
                        drCl(Entidades.CRMNovedad.Columnas.ProductoPrestadoDevuelto.ToString()) = False

                        Dim patenteVehiculo = dr(ColumnasExcel.PatenteVehiculo).ToString()
                        If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO) AndAlso String.IsNullOrWhiteSpace(patenteVehiculo) Then
                           Accion = "X"
                           Mensaje.AppendFormat("La patente es requerida - ")
                        Else
                           drCl(Entidades.CRMNovedad.Columnas.PatenteVehiculo.ToString()) = patenteVehiculo
                        End If

                        Importa = True
                        drCl("Accion") = Accion
                        If Accion = "X" Then
                           Importa = False
                           drCl("Mensaje") = Mensaje.ToString()
                        End If
                        drCl("Importa") = Importa

                        If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importa) Or (Me.cboEstado.Text = "Invalidos" And Not Importa)) And
                           (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
                           If Not String.IsNullOrEmpty(descripcion) Or idNovedad > 0 Then
                              dt.Rows.Add(drCl)
                           End If
                        End If
                     Next
                  Catch ex As Exception
                     Throw New Exception(String.Format("Error procesando línea {0}: {1}", lineaProcesada, ex.Message), ex)
                  End Try
               End Using
            End Using

            ConexionExcel.Close()
         End Using

         ugDetalle.DataSource = dt

         FormatearGrilla()

         'tssRegistros.Text = dt.Rows.Count.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Then
            ProductosConError = 0
         End If


      Catch ex As Exception
         Cursor = Cursors.Default
         'Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            ShowMessage("Rango de Celdas Invalidos.")
            txtRangoCeldasFilaHasta.Focus()
         Else
            ShowError(ex)
         End If
      Finally
         Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try

   End Sub
#Enable Warning BC40008 ' Type or member is obsolete

   Public Function RemoveDiacritics(stIn As String) As String
      Dim stFormD As String = stIn.Normalize(NormalizationForm.FormD)
      Dim sb As New StringBuilder()

      For ich As Integer = 0 To stFormD.Length - 1
         Dim uc As UnicodeCategory = CharUnicodeInfo.GetUnicodeCategory(stFormD(ich))
         If uc <> UnicodeCategory.NonSpacingMark Then
            sb.Append(stFormD(ich))
         End If
      Next

      Return (sb.ToString().Normalize(NormalizationForm.FormC))
   End Function

   Private Sub FormatearGrilla()
      ugDetalle.DisplayLayout.Bands(0).Columns("Mensaje").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)
   End Sub

   Private Sub ImportarDatos()
      Dim rCrm = New Reglas.CRMNovedades()
      rCrm.Importar(ugDetalle.DataSource(Of DataTable), tspImportando)
   End Sub

#End Region

   Private Function GetValorString(dr As DataRow, indiceColumna As Integer) As String
      Return ImportarExcel.GetValorString(dr, indiceColumna)
   End Function

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      If e.Row.Cells("Accion").Value.ToString() = "X" Then
         e.Row.Cells("Importa").Appearance.BackColor = Color.Yellow
         e.Row.Cells("Importa").ActiveAppearance.BackColor = Color.Yellow
      ElseIf e.Row.Cells("Accion").Value.ToString() = "E" Then
         e.Row.Cells("Importa").Appearance.BackColor = Color.LightCoral
         e.Row.Cells("Importa").ActiveAppearance.BackColor = Color.LightCoral
      Else
         e.Row.Cells("Importa").Appearance.BackColor = Color.LimeGreen
         e.Row.Cells("Importa").ActiveAppearance.BackColor = Color.LimeGreen
      End If

      If e.Row.Cells("EstadoImporta").Value.Equals("OK") Then
         e.Row.Cells("EstadoImporta").Appearance.BackColor = Color.LimeGreen
         e.Row.Cells("EstadoImporta").ActiveAppearance.BackColor = Color.LimeGreen
      ElseIf e.Row.Cells("EstadoImporta").Value.Equals("ERROR") Then
         e.Row.Cells("EstadoImporta").Appearance.BackColor = Color.LightCoral
         e.Row.Cells("EstadoImporta").ActiveAppearance.BackColor = Color.LightCoral
      End If

   End Sub

   Private Sub cmbTipoNovedad_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoNovedad.SelectedIndexChanged
      Try
         If TipoNovedad IsNot Nothing Then
            With ugDetalle.DisplayLayout.Bands(0)
               If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES) Or
                  TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS) Or
                  TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES) Then
                  .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Hidden = False
                  .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Hidden = False
                  If TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.CLIENTES) Then
                     .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.Caption = "Cliente"
                  ElseIf TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROSPECTOS) Then
                     .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.Caption = "Prospecto"
                  ElseIf TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.PROVEEDORES) Then
                     .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Header.Caption = "Proveedor"
                  End If
               Else
                  .Columns(Entidades.Cliente.Columnas.CodigoCliente.ToString()).Hidden = True
                  .Columns(Entidades.Cliente.Columnas.NombreCliente.ToString()).Hidden = True
               End If

               .Columns(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()).Hidden = Not TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.FUNCIONES)
               .Columns(Entidades.Funcion.Columnas.Nombre.ToString()).Hidden = .Columns(Entidades.CRMNovedad.Columnas.IdFuncion.ToString()).Hidden
               .Columns(Entidades.CRMNovedad.Columnas.IdSistema.ToString()).Hidden = Not TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.SISTEMAS)
               .Columns(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).Hidden = Not TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.METODORESOLUCION)
               .Columns(Entidades.CRMNovedad.Columnas.PatenteVehiculo.ToString()).Hidden = Not TipoNovedad.TieneDinamico(Entidades.CRMTipoNovedad.TipoDinamico.VEHICULO)
            End With
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub Controles_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRangoCeldasFilaHasta.KeyDown, txtRangoCeldasFilaDesde.KeyDown, txtRangoCeldasColumnaHasta.KeyDown, txtRangoCeldasColumnaDesde.KeyDown, cmbTipoNovedad.KeyDown, cboEstado.KeyDown, cboAccion.KeyDown
      PresionarTab(e)
   End Sub
End Class
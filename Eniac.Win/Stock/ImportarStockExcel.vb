Imports ImportarExcel = Eniac.Entidades.Ayudante.ImportarExcel
Public Class ImportarStockExcel

#Region "Campos"
   Private ConexionExcel As OleDb.OleDbConnection
   Private _publicos As Publicos

   Private _idSucursal As Integer
   Private _idDeposito As Integer

   Private Const ColumnaIdProducto As Integer = 0        ' A
   Private Const ColumnaNombreProducto As Integer = 1    ' B
   Private Const ColumnaStock As Integer = 2             ' C
   Private Const ColumnaDeposito As Integer = 3          ' D
   Private Const ColumnaUbicacion As Integer = 4         ' E

   Public ReadOnly Property dtDetalle As DataTable
      Get
         Return ugDetalle.DataSource(Of DataTable)()
      End Get
   End Property
#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      TryCatched(Sub() _publicos = New Publicos())
      TryCatched(Sub() CargarValoresIniciales())
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnLeerExel.PerformClick()
      ElseIf keyData = Keys.F4 Then
         tsbImportar.PerformClick()
      ElseIf keyData = Keys.Escape Then
         tsbSalir.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
   Public Shadows Function ShowDialog(owner As IWin32Window, idSucursal As Integer, idDeposito As Integer) As DialogResult
      _idSucursal = idSucursal
      _idDeposito = idDeposito
      Return MyBase.ShowDialog(owner)
   End Function

#End Region

#Region "Eventos"

#Region "Eventos Toolbar"
   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargarValoresIniciales())
   End Sub
   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(Sub() Importar())
      'Resultado = True
   End Sub
   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close(DialogResult.Cancel))
      'Resultado = False
   End Sub
#End Region

   Private Sub btnLeerExel_Click(sender As Object, e As EventArgs) Handles btnLeerExel.Click
      TryCatched(
      Sub()
         Enabled = False

         If String.IsNullOrWhiteSpace(txtArchivoOrigen.Text) Then
            Exit Sub
         End If

         If Not IO.File.Exists(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: El archivo a Importar NO Existe")
            Exit Sub
         End If

         If txtRangoCeldasFilaHasta.ValorNumericoPorDefecto(0I) = 0 Then
            ShowMessage("Debe indicar el rango de celdas a leer del archivo Excel")
            txtRangoCeldasFilaHasta.Focus()
            Exit Sub
         End If

         Dim rangoExcel = ImportarExcel.Rango(txtRangoCeldasColumnaDesde.Text, txtRangoCeldasFilaDesde.Text,
                                              txtRangoCeldasColumnaHasta.Text, txtRangoCeldasFilaHasta.Text)
         Mostrar(rangoExcel)
      End Sub)

      MostrarInfo(String.Empty)
      Enabled = True
   End Sub
   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         Dim DialogoAbrirArchivo = New OpenFileDialog With {
            .InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop,
            .Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*",
            .FilterIndex = 1,
            .RestoreDirectory = True,
            .CheckFileExists = True
         }

         If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
            txtRangoCeldasFilaHasta.Focus()
         End If
      End Sub)
   End Sub

   Private Sub ugDetalle_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles ugDetalle.InitializeRow
      TryCatched(
      Sub()
         Dim dr = e.Row.FilaSeleccionada(Of DataRow)
         If dr IsNot Nothing Then
            If dr.Field(Of String)("Accion") = "M" Then
               e.Row.Cells("Importa").Color(Nothing, Color.LimeGreen)
            Else
               e.Row.Cells("Importa").Color(Nothing, Color.Tomato)
            End If
         End If
      End Sub)
   End Sub
   Private Sub txtRangoCeldasFilaHasta_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRangoCeldasFilaHasta.KeyDown, txtRangoCeldasFilaDesde.KeyDown, txtRangoCeldasColumnaDesde.KeyDown, txtArchivoOrigen.KeyDown
      PresionarTab(e)
   End Sub

#End Region

#Region "Metodos"

   Private Sub Importar()
      ugDetalle.UpdateData()

      If dtDetalle Is Nothing Then
         Throw New Exception("Debe importar un Excel")
      Else
         Close(DialogResult.OK)
      End If
   End Sub

   Private Sub CargarValoresIniciales()

      txtArchivoOrigen.Text = ""
      txtRangoCeldasColumnaDesde.Text = "A"
      txtRangoCeldasFilaDesde.Text = "4"
      txtRangoCeldasColumnaHasta.Text = ":E"
      txtRangoCeldasFilaHasta.Text = ""

      ugDetalle.ClearFilas()

      txtArchivoOrigen.Focus()

      tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar
   End Sub

   Sub AbrirExcel(ArchivoXLS As String)

      Dim m_sConn1 As String

      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If

      ConexionExcel = New OleDb.OleDbConnection(m_sConn1)
      ConexionExcel.Open()
   End Sub

   Private Sub Mostrar(rangoExcel As String)

      Dim ds = New DataSet()
      Dim DA = New OleDb.OleDbDataAdapter
      Dim rProd = New Reglas.Productos()
      Dim rDeposit = New Reglas.SucursalesDepositos()
      Dim rUbicaci = New Reglas.SucursalesUbicaciones()

      Try
         Dim dt = CrearDT()
         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         AbrirExcel(txtArchivoOrigen.Text)
         DA = New OleDb.OleDbDataAdapter("Select * From " & rangoExcel, ConexionExcel)

         DA.Fill(ds)

         'Dim Stock As Decimal
         'Dim Ubicacion As String
         '  Dim Linea As ListViewItem

         'Dim DepImportar = 0I
         'Dim DepDescarta = 0I

         Dim lineaProcesada = 0L

         For Each dr In ds.Tables(0).AsEnumerable()
            lineaProcesada += 1

            If lineaProcesada = 1 Or lineaProcesada Mod 100 = 0 Then
               MostrarInfo(String.Format("Procesando linea {0}", lineaProcesada))
            End If

            Dim Accion As String = "A"
            Dim Importa As Boolean = True
            Dim stbMensaje = New StringBuilder()

            Dim drCl = dt.NewRow()

            Dim CodigoProducto = dr(ColumnaIdProducto).ToString.Trim()
            drCl("Codigo") = CodigoProducto
            If rProd.Existe(CodigoProducto.ToString()) Then
               Accion = "M"
            Else
               Accion = "X"
               stbMensaje.AppendFormat("El Producto no existe - ")
            End If

            drCl("Descripcion") = dr(ColumnaNombreProducto).ToString()

            If ImportarExcel.IsNumeric(dr, ColumnaStock) Then
               drCl("Stock") = Decimal.Parse(dr(ColumnaStock).ToString())
            Else
               Accion = "X"
               stbMensaje.AppendFormat("El Stock no es numérico - ")
            End If
            '--
            Dim nombreDepo = dr(ColumnaDeposito).ToString.Trim()
            Dim idDeposito = 0I

            drCl("NombreDeposito") = nombreDepo
            Dim eDeposito = rDeposit.GetDepositoNombre(_idSucursal, nombreDepo.ToString(), Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            If eDeposito IsNot Nothing Then
               idDeposito = eDeposito.IdDeposito
               drCl("IdDeposito") = idDeposito
               'Accion = "M"
               'DepImportar += 1

               If idDeposito <> _idDeposito Then
                  Accion = "X"
                  stbMensaje.AppendFormat("El Deposito no coincide con el Deposito que se está procesando - ")
               End If

            Else
               Accion = "X"
               stbMensaje.AppendFormat("El Deposito no existe - ")
            End If

            Dim nombreUbic = dr(ColumnaUbicacion).ToString()
            drCl("NombreUbicacion") = nombreUbic

            Dim eUbicacion = rUbicaci.GetUbicacionNombres(_idSucursal, nombreDepo, nombreUbic, Reglas.Base.AccionesSiNoExisteRegistro.Nulo)
            Dim idUbicacion = 0I
            If eUbicacion IsNot Nothing Then
               idUbicacion = eUbicacion.IdUbicacion
               drCl("IdUbicacion") = idUbicacion
               '   Accion = "M"
            Else
               Accion = "X"
               stbMensaje.AppendFormat("No existe Ubicacion para el Deposito seleccionado - Agregar Ubicacion")
            End If

            Importa = True

            dt.Rows.Add(drCl)

            drCl("Accion") = Accion
            If Accion = "X" Then
               Importa = False
               drCl("Mensaje") = stbMensaje.ToString()

            End If
            drCl("Importa") = Importa
         Next

         ConexionExcel.Close()
         ugDetalle.DataSource = dt
         'FormatearGrilla()
         ugDetalle.DisplayLayout.Bands(0).Columns("Mensaje").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

         tssRegistros.Text = ugDetalle.CantidadRegistrosParaStatusbar

      Catch ex As Exception
         Cursor = Cursors.Default
         tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("no pudo encontrar") Then
            ShowMessage("Rango de Celdas Invalidos.")
            txtRangoCeldasFilaHasta.Focus()
         Else
            ShowError(ex)
         End If
      Finally

         DA.Dispose()
         ConexionExcel.Dispose()

         Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try
      MostrarTotales()
   End Sub

   Private Sub MostrarTotales()
      Dim dt = ugDetalle.DataSource(Of DataTable)
      Dim countImportar = dt.Count(Function(dr) dr.Field(Of Boolean)("Importa"))
      Dim countConError = dt.Count(Function(dr) Not dr.Field(Of Boolean)("Importa"))
      tssAImportar.Text = String.Format("A importar: {0}", countImportar)
      tssConError.Text = String.Format("A importar: {0}", countConError)

      tssAImportar.Visible = countImportar <> 0
      tssConError.Visible = countConError <> 0
   End Sub

   'Private Sub FormatearGrilla()

   '   ugDetalle.DisplayLayout.Bands(0).Columns("Mensaje").PerformAutoResize(PerformAutoSizeType.AllRowsInBand, AutoResizeColumnWidthOptions.All)

   '   For Each dr As UltraGridRow In Me.ugDetalle.Rows

   '      If dr.Cells("Accion").Value.ToString() = "M" Then
   '         dr.Cells("Importa").Appearance.BackColor = Color.LimeGreen
   '      End If

   '   Next
   'End Sub
   Private Function CrearDT() As DataTable

      Dim dtTemp = New DataTable()

      With dtTemp
         .Columns.Add("Importa", GetType(Boolean))
         .Columns.Add("EstadoImporta", GetType(String))
         .Columns.Add("Accion", GetType(String))
         .Columns.Add("Codigo", GetType(String))
         .Columns.Add("Descripcion", GetType(String))
         .Columns.Add("Stock", GetType(Decimal))

         .Columns.Add("IdDeposito", GetType(Integer))
         .Columns.Add("NombreDeposito", GetType(String))
         .Columns.Add("IdUbicacion", GetType(Integer))
         .Columns.Add("NombreUbicacion", GetType(String))
         .Columns.Add("Mensaje", GetType(String))
      End With

      Return dtTemp

   End Function

   Private Sub MostrarInfo(mensaje As String)
      tssInfo.Text = mensaje
      Application.DoEvents()
   End Sub

#End Region

End Class
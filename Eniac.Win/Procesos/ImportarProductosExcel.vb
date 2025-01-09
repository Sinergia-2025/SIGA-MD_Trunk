Public Class ImportarProductosExcel

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As OleDb.OleDbConnection
   Private ColumnaIdProducto As Integer = 0
   Private ColumnaIdProductoNumerico As Integer = 1
   Private ColumnaNombreProducto As Integer = 2
   Private ColumnaNombreProducto2 As Integer = 2   'Predeterminado 1 Columna
   Private ColumnaNombreMarca As Integer = 3
   Private ColumnaNombreRubro As Integer = 4
   Private ColumnaNombreSubRubro As Integer = 5
   Private ColumnaNombreSubSubRubro As Integer = 6
   Private ColumnaIVA As Integer = 7
   Private ColumnaPrecioCosto As Integer = 8
   Private ColumnaPrecioVenta As Integer = 9
   Private ColumnaMoneda As Integer = 10
   Private ColumnaCodigoDeBarras As Integer = 11
   Private ColumnaPorcentaje As Integer = 12

   Private ColumnaNombreProveedorHabitual As Integer = 13

   Private ColumnaCodigoProductoProveedorHabitual As Integer = 14

   Private ColumnaNombreDeposito As Integer = 15
   Private ColumnaNombreUbicacion As Integer = 16


   Private ProductosConError As Integer
   Private _estaCargando As Boolean = True

   '-- REQ-32571.- ---------------------------------------------------------
   Private _decimalesEnPrecio As Integer
   Private _formatoEnPrecio As String
   Private _ceroFormateado As String
   '------------------------------------------------------------------------


#End Region

#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
         Sub()
            _publicos = New Publicos()

            'Me._publicos.CargaComboMarcas(Me.cmbMarca)
            '-- REQ-32571.- ---------------------------------------------------------
            _decimalesEnPrecio = Reglas.Publicos.PreciosDecimalesEnVenta
            _formatoEnPrecio = String.Concat("N", _decimalesEnPrecio)
            _ceroFormateado = 0.ToString(_formatoEnPrecio)
            '------------------------------------------------------------------------
            With dgvDetalle
               .Columns("PrecioCosto").DefaultCellStyle.Format = _formatoEnPrecio
               .Columns("PrecioVenta").DefaultCellStyle.Format = _formatoEnPrecio
            End With
            '------------------------------------------------------------------------

            cboDescripcion.Items.Insert(0, "Una Columna")
            cboDescripcion.Items.Insert(1, "Dos Columnas")

            cboAccion.Items.Insert(0, "Todas")
            cboAccion.Items.Insert(1, "Altas")
            cboAccion.Items.Insert(2, "Modificar")

            cboEstado.Items.Insert(0, "Todos")
            cboEstado.Items.Insert(1, "Validos")
            cboEstado.Items.Insert(2, "Invalidos")

            cmbDescripcionCorte.Items.Insert(0, "No Cortar")
            cmbDescripcionCorte.Items.Insert(1, "Cortar")
            cmbDescripcionCorte.Items.Insert(2, "Avisar y Cortar")

            _publicos.CargaComboListaDePrecios(cmbListaPrecios)

            CargarValoresIniciales()

            _estaCargando = False
         End Sub)
   End Sub
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F5 Then
         tsbRefrescar.PerformClick()
      ElseIf keyData = Keys.F3 Then
         btnMostrar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   Private Sub tsbRefrescar_Click(sender As Object, e As EventArgs) Handles tsbRefrescar.Click
      TryCatched(Sub() CargarValoresIniciales())
   End Sub

   Private Sub tsbImportar_Click(sender As Object, e As EventArgs) Handles tsbImportar.Click
      TryCatched(
         Sub()
            If dgvDetalle.RowCount = 0 Then Exit Sub

            If ProductosConError > 0 AndAlso ShowPregunta("ATENCION: Existen {0} Productos que NO se Importarán. ¿ Confirma el proceso ?", ProductosConError) <> DialogResult.Yes Then
               Exit Sub
            End If

            ImportarDatos()

            ShowMessage(String.Format("Se importaron {0}  Productos EXITOSAMENTE !!!", dgvDetalle.RowCount - ProductosConError))

            prbImportando.Value = 0
         End Sub)
   End Sub

   Private Sub tsbSalir_Click(sender As Object, e As EventArgs) Handles tsbSalir.Click
      TryCatched(Sub() Close())
   End Sub

   Private Sub btnExaminar_Click(sender As Object, e As EventArgs) Handles btnExaminar.Click
      TryCatched(
      Sub()
         Using dlg = New OpenFileDialog()
            dlg.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
            dlg.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*"
            dlg.FilterIndex = 1
            dlg.RestoreDirectory = True

            If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
               txtArchivoOrigen.Text = dlg.FileName
               'Si bien aca lo pude abrir, solo es para obtener el path.
               txtRangoCeldasFilaHasta.Focus()
            End If
         End Using
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
         If txtArchivoOrigen.Text.Trim() = "" Then
            Exit Sub
         End If

         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            ShowMessage("ATENCION: El archivo a Importar NO Existe")
            Exit Sub
         End If

         Dim rangoExcel = String.Format("[{0}{1}{2}{3}]",
                                        txtRangoCeldasColumnaDesde.Text.Trim.Replace(" ", ""), txtRangoCeldasFilaDesde.Text.Trim.Replace(" ", ""),
                                        txtRangoCeldasColumnaHasta.Text.Trim.Replace(" ", ""), txtRangoCeldasFilaHasta.Text.Trim.Replace(" ", ""))


         'RangoExcel = "[" & txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"

         If rangoExcel = "" Or rangoExcel = "[An:Nn]" Then
            MsgBox("Debe indicar el rango de celdas a leer del archivo Excel")
            txtRangoCeldasFilaHasta.Focus()
            Exit Sub
         End If

         Mostrar(rangoExcel)
      End Sub)
   End Sub

   Private Sub cboDescripcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDescripcion.SelectedIndexChanged
      TryCatched(Sub() ColumnasGrilla())
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      txtArchivoOrigen.Text = ""

      txtRangoCeldasFilaHasta.Text = String.Empty

      cboDescripcion.SelectedIndex = 0

      cboAccion.SelectedIndex = 0
      cboEstado.SelectedIndex = 0
      cmbDescripcionCorte.SelectedIndex = 0

      txtPrefijo.Text = ""

      chkCreaUbicaciones.Checked = False

      If TypeOf (dgvDetalle.DataSource) Is DataTable Then
         DirectCast(dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      prbImportando.Value = 0

      tssRegistros.Text = dgvDetalle.Rows.Count.ToString() & " Registros"

   End Sub

   Private Function CrearDT() As DataTable
      Dim dtTemp = New DataTable()
      With dtTemp
         .Columns.Add("Importa", GetType(Boolean))
         '.Columns.Add("LineaExcel", GetType("System.Int64"))
         .Columns.Add("Accion", GetType(String))
         .Columns.Add("CodigoProducto", GetType(String))
         .Columns.Add("IdProductoNumerico", GetType(Long))
         .Columns.Add("NombreProducto", GetType(String))
         .Columns.Add("NombreProducto2", GetType(String))
         .Columns.Add("NombreMarca", GetType(String))
         .Columns.Add("NombreRubro", GetType(String))
         .Columns.Add("NombreSubRubro", GetType(String))
         .Columns.Add("NombreSubSubRubro", GetType(String))
         .Columns.Add("IVA", GetType(Decimal))
         .Columns.Add("PrecioCosto", GetType(Decimal))
         .Columns.Add("PrecioVenta", GetType(Decimal))
         .Columns.Add("Moneda", GetType(String))
         .Columns.Add("CodigoDeBarras", GetType(String))
         .Columns.Add("Porcentaje", GetType(String))
         .Columns.Add("NombreProveedorHabitual", GetType(String))
         .Columns.Add("CodigoProductoProveedorHabitual", GetType(String))
         .Columns.Add("NombreDeposito", GetType(String))
         .Columns.Add("NombreUbicacion", GetType(String))
         .Columns.Add("Mensaje", GetType(String))
      End With
      Return dtTemp
   End Function

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

   Private Sub ColumnasGrilla()

      If _estaCargando Then Exit Sub

      If cboDescripcion.SelectedIndex = 1 Then  'Dos columnas
         txtRangoCeldasColumnaHasta.Text = ":R"
         dgvDetalle.Columns("NombreProducto").Width = 200
         dgvDetalle.Columns("NombreProducto2").Visible = True

         ColumnaIdProducto = 0
         ColumnaIdProductoNumerico = 1
         ColumnaNombreProducto = 2
         ColumnaNombreProducto2 = 3
         ColumnaNombreMarca = 4
         ColumnaNombreRubro = 5
         ColumnaNombreSubRubro = 6
         ColumnaNombreSubSubRubro = 7
         ColumnaIVA = 8
         ColumnaPrecioCosto = 9
         ColumnaPrecioVenta = 10
         ColumnaMoneda = 11
         ColumnaCodigoDeBarras = 12
         ColumnaPorcentaje = 13
         ColumnaNombreProveedorHabitual = 14
         ColumnaCodigoProductoProveedorHabitual = 15

      Else
         txtRangoCeldasColumnaHasta.Text = ":Q"
         dgvDetalle.Columns("NombreProducto").Width = 300
         dgvDetalle.Columns("NombreProducto2").Visible = False

         ColumnaIdProducto = 0
         ColumnaIdProductoNumerico = 1
         ColumnaNombreProducto = 2
         ColumnaNombreMarca = 3
         ColumnaNombreRubro = 4
         ColumnaNombreSubRubro = 5
         ColumnaNombreSubSubRubro = 6
         ColumnaIVA = 7
         ColumnaPrecioCosto = 8
         ColumnaPrecioVenta = 9
         ColumnaMoneda = 10
         ColumnaCodigoDeBarras = 11
         ColumnaPorcentaje = 12
         ColumnaNombreProveedorHabitual = 13
         ColumnaCodigoProductoProveedorHabitual = 14
      End If

   End Sub

   Private Sub Mostrar(rangoExcel As String)
      Try
         Dim oPublicos = New Reglas.Publicos()
         Dim oProductos = New Reglas.Productos()
         Dim oProveedores = New Reglas.Proveedores()

         Dim anchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto")
         Dim anchoNombreProducto = oPublicos.GetAnchoCampo("Productos", "NombreProducto")
         Dim anchoNombreMarca = oPublicos.GetAnchoCampo("Marcas", "NombreMarca")
         Dim anchoNombreRubro = oPublicos.GetAnchoCampo("Rubros", "NombreRubro")
         Dim anchoNombreSubRubro = oPublicos.GetAnchoCampo("SubRubros", "NombreSubRubro")
         Dim anchoNombreSubSubRubro = oPublicos.GetAnchoCampo("SubSubRubros", "NombreSubSubRubro")
         Dim anchoCodigoDeBarras = oPublicos.GetAnchoCampo("Productos", "CodigoDeBarras")
         Dim anchoCodigoProductoProveedorHabitual = oPublicos.GetAnchoCampo("ProductosProveedores", "CodigoProductoProveedor")


         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         ProductosConError = 0

         'Leo el archivo y lo subo a la grilla. 

         Dim dt = CrearDT()

         AbrirExcel(txtArchivoOrigen.Text)

         Dim DA = New OleDb.OleDbDataAdapter("Select * From " & rangoExcel, Me.ConexionExcel)
         Dim ds = New DataSet()
         DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String

         Dim rDeposito = New Reglas.SucursalesDepositos()
         Dim rUbicacion = New Reglas.SucursalesUbicaciones()

         For Each dr In ds.Tables(0).Rows

            Accion = "A"

            Application.DoEvents()

            Dim drCl = dt.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaIdProducto).ToString.Trim() = "" Or dr(ColumnaNombreMarca).ToString.Trim() = "" Or dr(ColumnaNombreRubro).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
            End If

            'drCl("LineaExcel") = ""

            drCl("CodigoProducto") = Me.txtPrefijo.Text.Trim() & dr(ColumnaIdProducto).ToString.Trim.Replace("'", "´")

            '# Cód. Prod. Numérico
            If Not String.IsNullOrEmpty(dr(ColumnaIdProductoNumerico).ToString()) Then
               If Not IsNumeric(dr(ColumnaIdProductoNumerico)) Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El Cód. Producto Numérico tiene caracteres inválidos."
               Else
                  drCl("IdProductoNumerico") = Convert.ToInt64(dr(ColumnaIdProductoNumerico).ToString())
               End If
            End If

            'If drCl("CodigoProducto").ToString.Trim.Length > AnchoIdProducto Then
            '   Importar = False
            '   If Mensaje.Length > 0 Then Mensaje += " - "
            '   Mensaje += "Digitos del Codigo del Producto es Mayor a " & AnchoIdProducto.ToString()
            'Else
            '   Accion = IIf(oProductos.Existe(drCl("CodigoProducto")), "M", "A")
            'End If

            If drCl("CodigoProducto").ToString.Trim.Length > anchoIdProducto Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Codigo del Producto es Mayor a " & anchoIdProducto.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("CodigoProducto") = drCl("CodigoProducto").ToString.Remove(anchoIdProducto)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Codigo del Producto es Mayor a " & anchoIdProducto.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     'drCl("CodigoProducto") = dr(ColumnaIdProducto).ToString.Trim.Replace("'", "´").Remove(AnchoIdProducto)
                     drCl("CodigoProducto") = drCl("CodigoProducto").ToString.Remove(anchoIdProducto)
                  End If
               End If
            End If
            Accion = If(oProductos.Existe(drCl.Field(Of String)("CodigoProducto")), "M", "A")


            If Me.cboDescripcion.SelectedIndex = 1 Then  'Dos Columnas
               drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´")
               drCl("NombreProducto2") = dr(ColumnaNombreProducto2).ToString.Trim.Replace("'", "´")

               If dr(ColumnaNombreProducto).ToString.Trim.Length + 1 + dr(ColumnaNombreProducto2).ToString.Trim.Length > anchoNombreProducto Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & anchoNombreProducto.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & anchoNombreProducto.ToString()
                     End If
                  End If

               End If

            Else
               drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´")
               drCl("NombreProducto2") = ""

               If dr(ColumnaNombreProducto).ToString.Trim.Length > anchoNombreProducto Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & anchoNombreProducto.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(anchoNombreProducto)
                        drCl("NombreProducto2") = ""
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & anchoNombreProducto.ToString()
                     End If
                     If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(anchoNombreProducto)
                        drCl("NombreProducto2") = ""
                     End If
                  End If

               End If

            End If


            drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´")
            If dr(ColumnaNombreMarca).ToString.Trim.Length > anchoNombreMarca Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Marca es Mayor a " & anchoNombreMarca.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´").Remove(anchoNombreMarca)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Nombre de Marca es Mayor a " & anchoNombreMarca.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´").Remove(anchoNombreMarca)
                  End If
               End If

            End If


            drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´")
            If dr(ColumnaNombreRubro).ToString.Trim.Length > anchoNombreRubro Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Rubro es Mayor a " & anchoNombreRubro.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´").Remove(anchoNombreRubro)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Nombre de Rubro es Mayor a " & anchoNombreRubro.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´").Remove(anchoNombreRubro)
                  End If
               End If

            End If

            If Not String.IsNullOrWhiteSpace(dr(ColumnaNombreProveedorHabitual).ToString.Trim.Replace("'", "´")) Then

               drCl("NombreProveedorHabitual") = dr(ColumnaNombreProveedorHabitual).ToString.Trim.Replace("'", "´")
               drCl("CodigoProductoProveedorHabitual") = dr(ColumnaCodigoProductoProveedorHabitual).ToString.Trim.Replace("'", "´")

               If Not oProveedores.ExisteProveedorPorCodigoNombre(0, dr(ColumnaNombreProveedorHabitual).ToString.Trim.Replace("'", "´")) Then
                  Importar = False
                  Mensaje += " El Proveedor Habitual para el producto  No Existe."
               Else
                  Dim ProvHabitual As Entidades.Proveedor = oProveedores.GetUnoPorNombre(dr(ColumnaNombreProveedorHabitual).ToString(), False)
                  If ProvHabitual IsNot Nothing And ProvHabitual.Activo = False Then
                     Importar = False
                     Mensaje += " Proveedor Habitual esta Inactivo, este producto no se importara."
                  End If
               End If
               If String.IsNullOrWhiteSpace(dr(ColumnaCodigoProductoProveedorHabitual).ToString()) Then
                  Importar = False
                  Mensaje += " El campo Codigo Producto del Proveedor Habitual No puede estar vacio."
               End If
               If dr(ColumnaCodigoProductoProveedorHabitual).ToString.Trim.Length > anchoCodigoProductoProveedorHabitual Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del campo de Codigo Producto Proveedor Habitual es Mayor a " & anchoCodigoProductoProveedorHabitual.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        drCl("CodigoProductoProveedorHabitual") = dr(ColumnaCodigoProductoProveedorHabitual).ToString.Trim.Replace("'", "´").Remove(anchoCodigoProductoProveedorHabitual)
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos del Nombre de Codigo Producto Proveedor Habitual es Mayor a " & anchoCodigoProductoProveedorHabitual.ToString()
                     End If
                     If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                        drCl("CodigoProductoProveedorHabitual") = dr(ColumnaCodigoProductoProveedorHabitual).ToString.Trim.Replace("'", "´").Remove(anchoCodigoProductoProveedorHabitual)
                     End If
                  End If
               End If
            Else
               If Not String.IsNullOrWhiteSpace(dr(ColumnaCodigoProductoProveedorHabitual).ToString()) Then
                  drCl("CodigoProductoProveedorHabitual") = dr(ColumnaCodigoProductoProveedorHabitual).ToString.Trim.Replace("'", "´")
                  Importar = False
                  Mensaje += " El Nombre del campo Proveedor Habitual se encuentra vacio y posee Código de Proveedor Habitual."
               End If
            End If
            drCl("NombreSubRubro") = dr(ColumnaNombreSubRubro).ToString.Trim.Replace("'", "´")
            If dr(ColumnaNombreSubRubro).ToString.Trim.Length > anchoNombreSubRubro Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de SubRubro es Mayor a " & anchoNombreRubro.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("NombreSubRubro") = dr(ColumnaNombreSubRubro).ToString.Trim.Replace("'", "´").Remove(anchoNombreSubRubro)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Nombre de SubRubro es Mayor a " & anchoNombreSubRubro.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("NombreSubRubro") = dr(ColumnaNombreSubRubro).ToString.Trim.Replace("'", "´").Remove(anchoNombreSubRubro)
                  End If
               End If

            End If

            drCl("NombreSubSubRubro") = dr(ColumnaNombreSubSubRubro).ToString.Trim.Replace("'", "´")
            If dr(ColumnaNombreSubSubRubro).ToString.Trim.Length > anchoNombreSubSubRubro Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de SubSubRubro es Mayor a " & anchoNombreSubSubRubro.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("NombreSubSubRubro") = dr(ColumnaNombreSubSubRubro).ToString.Trim.Replace("'", "´").Remove(anchoNombreSubSubRubro)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Nombre de SubSubRubro es Mayor a " & anchoNombreSubSubRubro.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("NombreSubSubRubro") = dr(ColumnaNombreSubSubRubro).ToString.Trim.Replace("'", "´").Remove(anchoNombreSubSubRubro)
                  End If
               End If

            End If

            If IsNumeric(dr(ColumnaIVA).ToString()) Then
               Dim oImp As Reglas.Impuestos = New Reglas.Impuestos
               drCl("IVA") = Decimal.Round(Decimal.Parse(dr(ColumnaIVA).ToString()), 2)
               If Not oImp.Existe("IVA", Decimal.Round(Decimal.Parse(dr(ColumnaIVA).ToString()), 2)) Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El IVA no existe: " & dr(ColumnaIVA).ToString()
               End If
            Else
               drCl("IVA") = Publicos.ProductoIVA
            End If

            If IsNumeric(dr(ColumnaPrecioCosto).ToString()) Then
               drCl("PrecioCosto") = Decimal.Round(Decimal.Parse(dr(ColumnaPrecioCosto).ToString()), _decimalesEnPrecio)
            Else
               drCl("PrecioCosto") = 0
            End If

            If IsNumeric(dr(ColumnaPrecioVenta).ToString()) Then
               drCl("PrecioVenta") = Decimal.Round(Decimal.Parse(dr(ColumnaPrecioVenta).ToString()), _decimalesEnPrecio)
            Else
               drCl("PrecioVenta") = 0
            End If

            drCl("Moneda") = IIf(dr(ColumnaMoneda).ToString.Trim() = "D", "Dolar", "Pesos").ToString()


            drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´")
            'If dr(ColumnaCodigoDeBarras).ToString.Trim.Length > AnchoCodigoDeBarras Then
            '   Importar = False
            '   If Mensaje.Length > 0 Then Mensaje += " - "
            '   Mensaje += "Digitos del Codigo de Barras es Mayor a " & AnchoCodigoDeBarras.ToString()
            'End If
            If dr(ColumnaCodigoDeBarras).ToString.Trim.Length > anchoCodigoDeBarras Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Codigo de Barras es Mayor a " & anchoCodigoDeBarras.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´").Remove(anchoCodigoDeBarras)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Codigo de Barras es Mayor a " & anchoCodigoDeBarras.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´").Remove(anchoNombreRubro)
                  End If
               End If
            End If

            Dim codProd = drCl.Field(Of String)("CodigoProducto")
            If dt.Select(String.Format("CodigoProducto = '{0}'", codProd)).Count > 0 Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += String.Format("El código de producto {0} ya se encuentra en el mismo excel.", codProd)
            End If


            Dim nombreDeposito = dr(ColumnaNombreDeposito).ToString.Trim.Replace("'", "´")
            drCl("NombreDeposito") = nombreDeposito
            If Not String.IsNullOrWhiteSpace(nombreDeposito) Then
               If Not rDeposito.ExistePorNombre(actual.Sucursal.IdSucursal, nombreDeposito) Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += String.Format("El depósito '{0}' no existe.", nombreDeposito)
               End If
            End If

            Dim nombreUbicacion = dr(ColumnaNombreUbicacion).ToString.Trim.Replace("'", "´")
            drCl("NombreUbicacion") = nombreUbicacion
            If Not String.IsNullOrWhiteSpace(nombreUbicacion) Then
               If Not rUbicacion.ExistePorNombre(actual.Sucursal.IdSucursal, nombreDeposito, nombreUbicacion) Then
                  If Not chkCreaUbicaciones.Checked Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += String.Format("La ubicación '{0}' no existe en el depósito '{1}'.", nombreUbicacion, nombreDeposito)
                  Else
                     Dim rUbica = New Reglas.SucursalesUbicaciones()
                     rUbica._InsertarDesdeExportacion(actual.Sucursal.IdSucursal, nombreDeposito, nombreUbicacion)
                  End If
               End If
            End If

            drCl("Importa") = Importar

            If Not Importar Then
               ProductosConError += 1
               drCl("Mensaje") = Mensaje
               Accion = "X"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drCl("Mensaje") = Mensaje
               Else
                  drCl("Mensaje") = ""
               End If

            End If

            drCl("Accion") = Accion

            'If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And
            '   (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
            dt.Rows.Add(drCl)
            'End If

         Next

         If cboEstado.Text <> "Todos" Then
            dt.RemoveRowRange(dt.Select(String.Format("{0} Importa", If(cboEstado.Text = "Validos", "NOT", ""))))
         End If
         If cboAccion.Text <> "Todas" Then
            dt.RemoveRowRange(dt.Select(String.Format("Accion = '{0}'", If(cboAccion.Text = "Altas", "M", "A"))))
         End If
         dt.AcceptChanges()



         ConexionExcel.Close()

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ProductosConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldasFilaHasta.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try

   End Sub

   Private Sub ImportarDatos()
      Dim dtDatos = DirectCast(dgvDetalle.DataSource, DataTable)

      Dim reg = New Reglas.Productos()

      reg.ImportarProductos(actual.Sucursal.Id, dtDatos, actual.Nombre, Integer.Parse(cmbListaPrecios.SelectedValue.ToString()), prbImportando,
                            IdFuncion)
   End Sub

#End Region

End Class
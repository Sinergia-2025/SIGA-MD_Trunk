Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO
Imports Infragistics.Win.UltraWinGrid

#End Region

Public Class ImportarProductosExcelListasMultiples

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String
   Private ColumnaIdProducto As Integer = 0
   Private ColumnaIdProductoNumerico As Integer = 1
   Private ColumnaNombreProducto As Integer = 2
   Private ColumnaNombreProducto2 As Integer = 2   'Predeterminado 1 Columna
   Private ColumnaNombreMarca As Integer = 3
   Private ColumnaNombreRubro As Integer = 4
   Private ColumnaIVA As Integer = 5
   Private ColumnaPrecioCosto As Integer = 6
   'Private ColumnaPrecioVenta As Integer = 6
   Private ColumnaMoneda As Integer = 7
   Private ColumnaCodigoDeBarras As Integer = 8
   Private ProductosConError As Integer
   Private _estaCargando As Boolean = True

#End Region
   Private dtListaPrecios As DataTable

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Me._publicos.CargaComboMarcas(Me.cmbMarca)

      Me.cboDescripcion.Items.Insert(0, "Una Columna")
      Me.cboDescripcion.Items.Insert(1, "Dos Columnas")

      Me.cboAccion.Items.Insert(0, "Todas")
      Me.cboAccion.Items.Insert(1, "Altas")
      Me.cboAccion.Items.Insert(2, "Modificar")

      Me.cboEstado.Items.Insert(0, "Todos")
      Me.cboEstado.Items.Insert(1, "Validos")
      Me.cboEstado.Items.Insert(2, "Invalidos")

      Me.cmbDescripcionCorte.Items.Insert(0, "No Cortar")
      Me.cmbDescripcionCorte.Items.Insert(1, "Cortar")
      Me.cmbDescripcionCorte.Items.Insert(2, "Avisar y Cortar")

      Me.CargarValoresIniciales()

      CreaDTPrecios()
      CargaDTPrecios()
      dgvListasPrecios.DataSource = dtListaPrecios
      FormateaGrillaPrecios()

      Me._estaCargando = False

      tsbImportar.Enabled = TabControl1.SelectedTab.Equals(tpPrecios)

      tslRegistroActual.Text = ""
      tslTiempoActual.Text = ""
   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarProductosExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tslTotalRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         If ProductosConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ProductosConError.ToString() & " Productos que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.dgvDetalle.RowCount - ProductosConError).ToString() & " Productos EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.prbImportando.Value = 0
         'Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click

      Dim ArchivoStream As Stream = Nothing
      Dim DialogoAbrirArchivo As New OpenFileDialog()

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoAbrirArchivo.Filter = "Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*"
      DialogoAbrirArchivo.FilterIndex = 1
      DialogoAbrirArchivo.RestoreDirectory = True

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = DialogoAbrirArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               Me.txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
               'Si bien aca lo pude abrir, solo es para obtener el path.
               Me.txtRangoCeldas.Focus()
            End If
         Catch Ex As Exception
            MessageBox.Show("ATENCION: No se puede leer el archivo. Error: " & Ex.Message)
         Finally
            If (ArchivoStream IsNot Nothing) Then
               ArchivoStream.Close()
            End If
         End Try
      End If

   End Sub

   Private Sub cboEstado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEstado.SelectedIndexChanged

      If Not Me._estaCargando Then
         Me.tsbImportar.Enabled = (Me.cboEstado.Text <> "Invalidos")
      End If

   End Sub

   Private Sub btnMostrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click

      Try

         If Me.txtArchivoOrigen.Text.Trim() = "" Then
            Exit Sub
         End If

         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         RangoExcel = "[" & Me.txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"
         If RangoExcel = "" Or RangoExcel = "[An:In]" Then
            MsgBox("Debe indicar el rango de celdas a leer del archivo Excel")
            Me.txtRangoCeldas.Focus()
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.Mostrar()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub cboDescripcion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDescripcion.SelectedIndexChanged
      Me.ColumnasGrilla()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""

      Me.txtRangoCeldas.Text = "An : In"

      Me.cboDescripcion.SelectedIndex = 0

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0

      Me.txtPrefijo.Text = ""

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      'If Not Me._dt Is Nothing Then
      '   Me._dt.Rows.Clear()
      'End If

      Me.prbImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("Importa", System.Type.GetType("System.Boolean"))
         '.Columns.Add("LineaExcel", System.Type.GetType("System.Int64"))
         .Columns.Add("Accion", System.Type.GetType("System.String"))
         .Columns.Add("IdProductoNumerico", GetType(Long))
         .Columns.Add("CodigoProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto2", System.Type.GetType("System.String"))
         .Columns.Add("NombreMarca", System.Type.GetType("System.String"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("IVA", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrecioCosto", System.Type.GetType("System.Decimal"))
         .Columns.Add("PrecioVenta", System.Type.GetType("System.Decimal"))
         .Columns.Add("Moneda", System.Type.GetType("System.String"))
         .Columns.Add("CodigoDeBarras", System.Type.GetType("System.String"))
         .Columns.Add("Mensaje", System.Type.GetType("System.String"))
      End With

      Return dtTemp

   End Function

   Sub AbrirExcel(ByVal ArchivoXLS As String)

      Dim m_sConn1 As String

      If ArchivoXLS.ToUpper.EndsWith(".XLSX") Then
         m_sConn1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"
      Else
         m_sConn1 = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & ArchivoXLS & ";Extended Properties=""Excel 8.0;HDR=Yes;IMEX=1"";"
      End If


      ConexionExcel = New System.Data.OleDb.OleDbConnection(m_sConn1)
      ConexionExcel.Open()

   End Sub

   Private Sub ColumnasGrilla()

      If Me._estaCargando Then Exit Sub

      If Me.cboDescripcion.SelectedIndex = 1 Then  'Dos columnas

         Me.dgvDetalle.Columns("NombreProducto").Width = 200
         Me.dgvDetalle.Columns("NombreProducto2").Visible = True

         ColumnaIdProducto = 0
         ColumnaNombreProducto = 1
         ColumnaNombreProducto2 = 2
         ColumnaNombreMarca = 3
         ColumnaNombreRubro = 4
         ColumnaIVA = 5
         ColumnaPrecioCosto = 6
         'ColumnaPrecioVenta = 7
         ColumnaMoneda = 7
         ColumnaCodigoDeBarras = 8

      Else

         Me.dgvDetalle.Columns("NombreProducto").Width = 300
         Me.dgvDetalle.Columns("NombreProducto2").Visible = False

         ColumnaIdProducto = 0
         ColumnaNombreProducto = 1
         ColumnaNombreMarca = 2
         ColumnaNombreRubro = 3
         ColumnaIVA = 4
         ColumnaPrecioCosto = 5
         'ColumnaPrecioVenta = 6
         ColumnaMoneda = 6
         ColumnaCodigoDeBarras = 7

      End If

   End Sub

   Private Sub Mostrar()

      Try

         Dim dt As DataTable
         Dim drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos

         Dim AnchoIdProducto As Integer
         AnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto")

         Dim AnchoNombreProducto As Integer
         AnchoNombreProducto = oPublicos.GetAnchoCampo("Productos", "NombreProducto")

         Dim AnchoNombreMarca As Integer
         AnchoNombreMarca = oPublicos.GetAnchoCampo("Marcas", "NombreMarca")

         Dim AnchoNombreRubro As Integer
         AnchoNombreRubro = oPublicos.GetAnchoCampo("Rubros", "NombreRubro")

         Dim AnchoCodigoDeBarras As Integer
         AnchoCodigoDeBarras = oPublicos.GetAnchoCampo("Productos", "CodigoDeBarras")

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         ProductosConError = 0


         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Dim ds As DataSet = New DataSet()
         Dim DA As New System.Data.OleDb.OleDbDataAdapter

         Me.AbrirExcel(txtArchivoOrigen.Text)

         DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         DA.Fill(ds)

         Dim dr As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String

         For Each dr In ds.Tables(0).Rows

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaIdProducto).ToString.Trim() = "" Or dr(ColumnaNombreMarca).ToString.Trim() = "" Or dr(ColumnaNombreRubro).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
            End If

            'drCl("LineaExcel") = ""

            drCl("CodigoProducto") = Me.txtPrefijo.Text.Trim() & dr(ColumnaIdProducto).ToString.Trim.Replace("'", "´")

            '# Cód. Producto Numérico
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

            If drCl("CodigoProducto").ToString.Trim.Length > AnchoIdProducto Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Codigo del Producto es Mayor a " & AnchoIdProducto.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("CodigoProducto") = drCl("CodigoProducto").ToString.Remove(AnchoIdProducto)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Codigo del Producto es Mayor a " & AnchoIdProducto.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     'drCl("CodigoProducto") = dr(ColumnaIdProducto).ToString.Trim.Replace("'", "´").Remove(AnchoIdProducto)
                     drCl("CodigoProducto") = drCl("CodigoProducto").ToString.Remove(AnchoIdProducto)
                  End If
               End If
            End If
            Accion = IIf(oProductos.Existe(drCl("CodigoProducto")), "M", "A")


            If Me.cboDescripcion.SelectedIndex = 1 Then  'Dos Columnas
               drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´")
               drCl("NombreProducto2") = dr(ColumnaNombreProducto2).ToString.Trim.Replace("'", "´")

               If dr(ColumnaNombreProducto).ToString.Trim.Length + 1 + dr(ColumnaNombreProducto2).ToString.Trim.Length > AnchoNombreProducto Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                     End If
                  End If

               End If

            Else
               drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´")
               drCl("NombreProducto2") = ""

               If dr(ColumnaNombreProducto).ToString.Trim.Length > AnchoNombreProducto Then
                  If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                  Else
                     If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(AnchoNombreProducto)
                        drCl("NombreProducto2") = ""
                        If Mensaje.Length > 0 Then Mensaje += " - "
                        Mensaje += "Digitos de la Descripcion del Producto es Mayor a " & AnchoNombreProducto.ToString()
                     End If
                     If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                        drCl("NombreProducto") = dr(ColumnaNombreProducto).ToString.Trim.Replace("'", "´").Remove(AnchoNombreProducto)
                        drCl("NombreProducto2") = ""
                     End If
                  End If

               End If

            End If


            drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´")
            If dr(ColumnaNombreMarca).ToString.Trim.Length > AnchoNombreMarca Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Marca es Mayor a " & AnchoNombreMarca.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´").Remove(AnchoNombreMarca)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Nombre de Marca es Mayor a " & AnchoNombreMarca.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("NombreMarca") = dr(ColumnaNombreMarca).ToString.Trim.Replace("'", "´").Remove(AnchoNombreMarca)
                  End If
               End If

            End If


            drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´")
            If dr(ColumnaNombreRubro).ToString.Trim.Length > AnchoNombreRubro Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Nombre de Rubro es Mayor a " & AnchoNombreRubro.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´").Remove(AnchoNombreRubro)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Nombre de Rubro es Mayor a " & AnchoNombreRubro.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("NombreRubro") = dr(ColumnaNombreRubro).ToString.Trim.Replace("'", "´").Remove(AnchoNombreRubro)
                  End If
               End If

            End If

            If IsNumeric(dr(ColumnaIVA).ToString()) Then
               drCl("IVA") = Decimal.Round(Decimal.Parse(dr(ColumnaIVA).ToString()), 2)
            Else
               drCl("IVA") = Publicos.ProductoIVA
            End If

            If IsNumeric(dr(ColumnaPrecioCosto).ToString()) Then
               drCl("PrecioCosto") = Decimal.Round(Decimal.Parse(dr(ColumnaPrecioCosto).ToString()), 2)
            Else
               drCl("PrecioCosto") = 0
            End If

            'If IsNumeric(dr(ColumnaPrecioVenta).ToString()) Then
            '   drCl("PrecioVenta") = Decimal.Round(Decimal.Parse(dr(ColumnaPrecioVenta).ToString()), 2)
            'Else
            drCl("PrecioVenta") = 0
            'End If

            drCl("Moneda") = IIf(dr(ColumnaMoneda).ToString.Trim() = "D", "Dolar", "Pesos").ToString()


            drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´")
            'If dr(ColumnaCodigoDeBarras).ToString.Trim.Length > AnchoCodigoDeBarras Then
            '   Importar = False
            '   If Mensaje.Length > 0 Then Mensaje += " - "
            '   Mensaje += "Digitos del Codigo de Barras es Mayor a " & AnchoCodigoDeBarras.ToString()
            'End If
            If dr(ColumnaCodigoDeBarras).ToString.Trim.Length > AnchoCodigoDeBarras Then
               If Me.cmbDescripcionCorte.SelectedIndex = 0 Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "Digitos del Codigo de Barras es Mayor a " & AnchoCodigoDeBarras.ToString()
               Else
                  If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                     drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´").Remove(AnchoCodigoDeBarras)
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "Digitos del Codigo de Barras es Mayor a " & AnchoCodigoDeBarras.ToString()
                  End If
                  If Me.cmbDescripcionCorte.SelectedIndex = 1 Then
                     drCl("CodigoDeBarras") = dr(ColumnaCodigoDeBarras).ToString.Trim.Replace("'", "´").Remove(AnchoNombreRubro)
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

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And _
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               dt.Rows.Add(drCl)
            End If

         Next

         ConexionExcel.Close()

         Me.dgvDetalle.DataSource = dt

         Me.tslTotalRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            ProductosConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tslTotalRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = TabControl1.SelectedTab.Equals(tpPrecios)
         tsbSalir.Enabled = True
      End Try

   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      'Dim dt As DataTable = New DataTable()
      'Dim drCl As DataRow

      'For Each dr As DataRow In dtDatos.Rows
      '   If Boolean.Parse(dr("Importa").ToString()) Then
      '      drCl = dt.NewRow
      '      drCl = dr.
      '      dt.Rows.Add(drCl)
      '   End If
      'Next

      Dim reg As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()

      'SPC: Cambiar método. El 0 es la lista de precios.
      reg.ImportarProductos(actual.Sucursal.Id, dtDatos, actual.Nombre, dtListaPrecios,
                            CInt(txtRedondeoPrecioVenta.Text), chbAjusteA.Checked, CInt(txtAjusteA.Text), Me.prbImportando, tslTiempoActual, tslRegistroActual,
                            idProveedor:=0, idFuncion:=IdFuncion, fuerzaActualizacionPrecio:=False)

   End Sub

#End Region


   Private Sub CreaDTPrecios()
      dtListaPrecios = New DataTable()

      dtListaPrecios.Columns.Add(ListaPreciosColumns.IdListaPrecios.ToString(), GetType(Int32))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.NombreListaPrecios.ToString(), GetType(String))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioVenta.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioVentaBase.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeBase.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PrecioCosto.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeCosto.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcentajeCalculado.ToString(), GetType(Decimal))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.PorcActual.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.SobreVenta.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.SobreCosto.ToString(), GetType(Boolean))
      dtListaPrecios.Columns.Add(ListaPreciosColumns.DesdeFormula.ToString(), GetType(Boolean))
   End Sub

   Private Sub CargaDTPrecios()

      For Each drPrecios As DataRow In New Reglas.ListasDePrecios().GetAll().Rows
         If dtListaPrecios.Select(String.Format("{0} = {1}", ListaPreciosColumns.IdListaPrecios.ToString(), drPrecios("IdListaPrecios"))).Length = 0 Then
            Dim dr As DataRow
            dr = dtListaPrecios.NewRow()
            dr(ListaPreciosColumns.IdListaPrecios.ToString()) = drPrecios("IdListaPrecios")
            dr(ListaPreciosColumns.NombreListaPrecios.ToString()) = drPrecios("NombreListaPrecios")
            'dr(ListaPreciosColumns.PrecioVenta.ToString()) = 0
            'dr(ListaPreciosColumns.PrecioVentaBase.ToString()) = 0
            'dr(ListaPreciosColumns.PorcentajeBase.ToString()) = 0
            'dr(ListaPreciosColumns.PrecioCosto.ToString()) = 0
            'dr(ListaPreciosColumns.PorcentajeCosto.ToString()) = 0
            dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = 0
            dr(ListaPreciosColumns.PorcActual.ToString()) = True
            dr(ListaPreciosColumns.SobreVenta.ToString()) = False
            dr(ListaPreciosColumns.SobreCosto.ToString()) = False
            dr(ListaPreciosColumns.DesdeFormula.ToString()) = False
            dtListaPrecios.Rows.Add(dr)
         End If
      Next

   End Sub

   Private Enum ListaPreciosColumns
      IdListaPrecios
      NombreListaPrecios
      PrecioVenta
      PrecioVentaBase
      PorcentajeBase
      PrecioCosto
      PorcentajeCosto
      PorcActual
      SobreVenta
      SobreCosto
      DesdeFormula
      PorcentajeCalculado
   End Enum

   Private Sub FormateaGrillaPrecios()
      With dgvListasPrecios.DisplayLayout.Bands(0)
         .Override.WrapHeaderText = DefaultableBoolean.True
         For Each columna As UltraGridColumn In .Columns
            columna.Hidden = True
            columna.CellActivation = Activation.NoEdit
         Next

         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Header.Caption = "Nombre"
         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Width = 170
         .Columns(ListaPreciosColumns.NombreListaPrecios.ToString()).Hidden = False

         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Header.Caption = "%"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Width = 50
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Format = "N2"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).MaskInput = "{double:-4.2}"
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).Hidden = False
         .Columns(ListaPreciosColumns.PorcentajeCalculado.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(ListaPreciosColumns.PorcActual.ToString()).Header.Caption = "Porc. Actual"
         .Columns(ListaPreciosColumns.PorcActual.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.PorcActual.ToString()).Width = 50
         .Columns(ListaPreciosColumns.PorcActual.ToString()).Hidden = False

         .Columns(ListaPreciosColumns.SobreVenta.ToString()).Header.Caption = "Sobre Venta"
         .Columns(ListaPreciosColumns.SobreVenta.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.SobreVenta.ToString()).Width = 50
         .Columns(ListaPreciosColumns.SobreVenta.ToString()).Hidden = False

         .Columns(ListaPreciosColumns.SobreCosto.ToString()).Header.Caption = "Sobre Costo"
         .Columns(ListaPreciosColumns.SobreCosto.ToString()).CellActivation = Activation.AllowEdit
         .Columns(ListaPreciosColumns.SobreCosto.ToString()).Width = 50
         .Columns(ListaPreciosColumns.SobreCosto.ToString()).Hidden = False

         If Reglas.Publicos.TieneModuloProduccion Then
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Header.Caption = "Desde Formula"
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).CellActivation = Activation.AllowEdit
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Width = 50
            .Columns(ListaPreciosColumns.DesdeFormula.ToString()).Hidden = False
         End If

         dgvListasPrecios.DisplayLayout.Override.HeaderClickAction = HeaderClickAction.Select
         dgvListasPrecios.DisplayLayout.GroupByBox.Hidden = True
         dgvListasPrecios.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
      End With
   End Sub

   Private Sub dgvListasPrecios_CellChange(sender As Object, e As CellEventArgs) Handles dgvListasPrecios.CellChange
      Try
         If e.Cell.Column.DataType.Equals(GetType(Boolean)) AndAlso
            e.Cell.Row.ListObject IsNot Nothing AndAlso
            TypeOf (e.Cell.Row.ListObject) Is DataRowView AndAlso
            DirectCast(e.Cell.Row.ListObject, DataRowView).Row IsNot Nothing Then

            Dim dr As DataRow = DirectCast(e.Cell.Row.ListObject, DataRowView).Row

            If e.Cell.Column.Key <> ListaPreciosColumns.PorcActual.ToString() Then
               dr(ListaPreciosColumns.PorcActual.ToString()) = False
            End If

            If e.Cell.Column.Key <> ListaPreciosColumns.SobreVenta.ToString() Then
               dr(ListaPreciosColumns.SobreVenta.ToString()) = False
            End If

            If e.Cell.Column.Key <> ListaPreciosColumns.SobreCosto.ToString() Then
               dr(ListaPreciosColumns.SobreCosto.ToString()) = False
            End If

            If e.Cell.Column.Key <> ListaPreciosColumns.DesdeFormula.ToString() Then
               dr(ListaPreciosColumns.DesdeFormula.ToString()) = False
            End If

            'If e.Cell.Column.Key = ListaPreciosColumns.PorcActual.ToString() Then
            '   dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = dr(ListaPreciosColumns.PorcentajeCosto.ToString())
            'Else
            '   dr(ListaPreciosColumns.PorcentajeCalculado.ToString()) = dr(ListaPreciosColumns.PorcentajeBase.ToString())
            'End If


            dgvListasPrecios.PerformAction(UltraGridAction.ExitEditMode)
            dgvListasPrecios.UpdateData()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub dgvListasPrecios_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles dgvListasPrecios.InitializeRow
      If CBool(e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Activation = Activation.NoEdit
         e.Row.Cells(ListaPreciosColumns.PorcentajeCalculado.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.PorcActual.ToString()).Activation = Activation.AllowEdit
         e.Row.Cells(ListaPreciosColumns.PorcentajeCalculado.ToString()).Activation = Activation.AllowEdit
      End If
      If CBool(e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.SobreVenta.ToString()).Activation = Activation.AllowEdit
      End If
      If CBool(e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.SobreCosto.ToString()).Activation = Activation.AllowEdit
      End If
      If CBool(e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Value) Then
         e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Activation = Activation.NoEdit
      Else
         e.Row.Cells(ListaPreciosColumns.DesdeFormula.ToString()).Activation = Activation.AllowEdit
      End If
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
      tsbImportar.Enabled = TabControl1.SelectedTab.Equals(tpPrecios)
   End Sub
End Class
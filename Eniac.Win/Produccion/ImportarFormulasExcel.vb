Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO

#End Region

Public Class ImportarFormulasExcel

#Region "Campos"

   Private _publicos As Publicos
   'Private _dt As DataTable
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String
   Private ColumnaIdProducto As Integer = 0
   Private ColumnaNombreProducto As Integer = 1
   Private ColumnaNombreFormula As Integer = 2
   Private ColumnaIdProducto2 As Integer = 3
   Private ColumnaNombreProducto2 As Integer = 4
   Private ColumnaNombreFormulaProducto2 As Integer = 5
   Private ColumnaCantidad As Integer = 6
   Private ProductosConError As Integer
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      'Me._publicos.CargaComboMarcas(Me.cmbMarca)

      Me.cboEstado.Items.Insert(0, "Todos")
      Me.cboEstado.Items.Insert(1, "Validos")
      Me.cboEstado.Items.Insert(2, "Invalidos")

      Me.CargarValoresIniciales()

      Me._estaCargando = False

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
         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
      Try

         If Me.dgvDetalle.RowCount = 0 Then Exit Sub

         '# Valido que el valor de la columna Principal sea único para toda la fórmula
         If Not ValidarColumnaPrincipal() Then Exit Sub

         If ProductosConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & ProductosConError.ToString() & " Componentes que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         ShowMessage(String.Format("Se importaron {0} Componentes EXITOSAMENTE !!!", (Me.dgvDetalle.RowCount - ProductosConError).ToString()))

         Me.prbImportando.Value = 0
      Catch ex As Exception
         ShowError(ex)
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
         ShowError(ex)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

#End Region

#Region "Metodos"

   Private Function ValidarColumnaPrincipal() As Boolean

      '# Valido que todos las fórmulas que se van a importar tengan el mismo valor en la columna "Principal"
      '# Para esta validación, los datos en la grilla deben estar ordenados por NombreFormula
      Dim tempProducto As String = String.Empty
      Dim tempNombre As String = String.Empty
      Dim tempValorPrincipal As String = String.Empty
      Dim dt As DataTable = DirectCast(Me.dgvDetalle.DataSource, DataTable)
      For Each formula As DataRow In dt.Rows

         '# En el primer bucle me guardo el nombre y el valor de la columna Principal, de la primera Fórmula
         If String.IsNullOrEmpty(tempProducto) Then
            tempProducto = formula.Field(Of String)("IdProducto")
            tempNombre = formula.Field(Of String)("NombreFormula")
            tempValorPrincipal = formula.Field(Of String)("Principal")
         End If

         '# Luego voy comparando los valores de la columna Principal hasta que cambie el nombre de la fórmula.
         '# Mientras tanto, el valor de Principal debe ser siempre igual al temporal. Caso contrario, se dará aviso al usuario y no podrá importarse.
         If tempProducto = formula.Field(Of String)("IdProducto") AndAlso
            tempNombre = formula.Field(Of String)("NombreFormula") Then
            If Not tempValorPrincipal = formula.Field(Of String)("Principal") Then
               ShowMessage(String.Format("ATENCIÓN: La Fórmula {0} para el Producto {1}, debe tener un único valor para la columna Principal. Debe corregirla para poder continuar con la importación.",
                                         formula.Field(Of String)("NombreFormula"),
                                         formula.Field(Of String)("NombreProducto")))
               Return False
            End If
         Else
            tempProducto = formula.Field(Of String)("IdProducto")
            tempNombre = formula.Field(Of String)("NombreFormula")
            tempValorPrincipal = formula.Field(Of String)("Principal")
         End If
      Next

      Return True
   End Function


   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""

      Me.txtRangoCeldas.Text = "An : Hn"

      Me.cboEstado.SelectedIndex = 0

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
         .Columns.Add("IdProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreFormula", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("IdProductoComponente", System.Type.GetType("System.String"))
         .Columns.Add("NombreProductoComponente", System.Type.GetType("System.String"))
         .Columns.Add("NombreFormulaComponente", System.Type.GetType("System.String"))
         .Columns.Add("Cantidad", System.Type.GetType("System.Decimal"))
         .Columns.Add("Principal", GetType(String))
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

   Private Sub Mostrar()

      Try

         Dim dt As DataTable, drCl As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos
         Dim oProductos As Eniac.Reglas.Productos = New Eniac.Reglas.Productos

         Dim AnchoIdProducto As Integer
         AnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto")

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

         For Each dr In ds.Tables(0).Rows

            System.Windows.Forms.Application.DoEvents()

            drCl = dt.NewRow()

            Importar = True
            Mensaje = ""

            If dr(ColumnaIdProducto).ToString.Trim() = "" Or dr(ColumnaIdProducto2).ToString.Trim() = "" Or dr(ColumnaCantidad).ToString.Trim() = "" Then
               Importar = False
               Mensaje = "Hay Campo(s) sin completar"
            End If

            drCl("IdProducto") = dr(ColumnaIdProducto).ToString.Trim()
            If dr(ColumnaIdProducto).ToString.Trim.Length > AnchoIdProducto Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Digitos del Codigo del Producto es Mayor a " & AnchoIdProducto.ToString()
            End If

            If Not oProductos.Existe(drCl("IdProducto").ToString.Trim()) Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "El Producto NO Existe"
               drCl("NombreProducto") = "NO Existe"
            Else
               drCl("NombreProducto") = oProductos.GetUno(dr(ColumnaIdProducto).ToString.Trim()).NombreProducto
               '---
               If String.IsNullOrEmpty(dr(ColumnaNombreFormula).ToString.Trim()) Then
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El Producto NO Posee Formula"
                  drCl("NombreFormula") = "NO Existe la Formula"

               Else
                  drCl("NombreFormula") = dr(ColumnaNombreFormula).ToString.Trim()
               End If
               '--
            End If

            drCl("IdProductoComponente") = dr(ColumnaIdProducto2).ToString.Trim()
            If dr(ColumnaIdProducto2).ToString.Trim.Length > AnchoIdProducto Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Digitos del Codigo del Producto Componente es Mayor a " & AnchoIdProducto.ToString()
            End If

            If Not oProductos.Existe(drCl("IdProductoComponente").ToString.Trim()) Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "El Producto Componente NO Existe"
               drCl("NombreProductoComponente") = "NO Existe"
            Else
               drCl("NombreProductoComponente") = oProductos.GetUno(dr(ColumnaIdProducto2).ToString.Trim()).NombreProducto
               '---
               If Not String.IsNullOrEmpty(dr(ColumnaNombreFormulaProducto2).ToString.Trim()) Then
                  Dim dtFormulas As DataTable = New DataTable
                  Dim oFormulas As Eniac.Reglas.ProductosFormulas = New Eniac.Reglas.ProductosFormulas()
                  dtFormulas = oFormulas.GetPorNombreExacto(dr(ColumnaIdProducto2).ToString.Trim(), dr(ColumnaNombreFormulaProducto2).ToString().Trim())
                  If dtFormulas.Rows.Count = 0 Then
                     Importar = False
                     If Mensaje.Length > 0 Then Mensaje += " - "
                     Mensaje += "El Producto Componente Posee Formula Inexistente"
                     drCl("NombreFormulaComponente") = "NO Existe la Formula"
                  Else
                     drCl("NombreFormulaComponente") = dr(ColumnaNombreFormulaProducto2).ToString.Trim()
                  End If
               End If
               '--
            End If


            If Not IsNumeric(dr(ColumnaCantidad).ToString()) Then
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "Cantidad es invalida."
               drCl("Cantidad") = 0
            Else
               drCl("Cantidad") = Decimal.Round(Decimal.Parse(dr(ColumnaCantidad).ToString()), 4)
            End If

            If Not IsNumeric(dr.Field(Of String)("Principal")) Then
               If dr("Principal").ToString() = "S" Or dr("Principal").ToString() = "N" Or String.IsNullOrEmpty(dr("Principal").ToString()) Then
                  If Not String.IsNullOrEmpty(dr("Principal").ToString()) Then
                     drCl("Principal") = dr("Principal").ToString().Trim()
                  End If
               Else
                  Importar = False
                  If Mensaje.Length > 0 Then Mensaje += " - "
                  Mensaje += "El campo Principal debe completarse con S(SI) / N(NO)."
               End If
            Else
               Importar = False
               If Mensaje.Length > 0 Then Mensaje += " - "
               Mensaje += "El campo Principal debe completarse con S(SI) / N(NO)."
            End If

            drCl("Importa") = Importar

            If Not Importar Then
               ProductosConError += 1
               drCl("Mensaje") = Mensaje
            Else
               drCl("Mensaje") = ""
            End If

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) Then
               dt.Rows.Add(drCl)
            End If

         Next

         ConexionExcel.Close()

         '# Ordeno la tabla por Fórmula
         dt.DefaultView.Sort = "NombreProducto, NombreFormula"
         Me.dgvDetalle.DataSource = dt.DefaultView.ToTable()

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Then
            ProductosConError = 0
         End If


      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            ShowError(ex)
         End If
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try

   End Sub

   Private Sub ImportarDatos()

      Dim reg As Eniac.Reglas.ProductosComponentes = New Eniac.Reglas.ProductosComponentes()
      Dim dtDatos As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      reg.ImportarFormulas(actual.Sucursal.Id, dtDatos, actual.Nombre, Me.prbImportando)

   End Sub

#End Region

End Class
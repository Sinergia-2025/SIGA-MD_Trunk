Option Strict Off

#Region "Imports"

'Imports actual = Eniac.Entidades.Usuario.Actual

Imports System.Data
Imports System.IO
Imports Infragistics.Win.UltraWinGrid

#End Region

Public Class ImportarProductosProveedor

#Region "Campos"

   ''Public Resultado As Boolean
   Public NombreListaDePrecios As String
   Public NumeroListaDePrecios As Integer
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String
   'Private _estaCargando As Boolean = True
   Private _publicos As Publicos

   Private _dtImport As DataTable
   Public Property DtImport() As DataTable
      Get
         Return _dtImport
      End Get
      Set(ByVal value As DataTable)
         _dtImport = value
      End Set
   End Property


   Public Enum ColumnasExcel As Integer
      Codigo = 0
      Descripcion = 1
      CodProveedor = 2
      Compra = 3
      D_R_1 = 4
      D_R_2 = 5
      D_R_3 = 6
      D_R_4 = 7
   End Enum

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.CargarValoresIniciales()
      SetDataSource(CreateDT())

      chbLeeCompra.Visible = Publicos.UtilizaPrecioDeCompra
      chbLeeDescuentos.Visible = Publicos.UtilizaPrecioDeCompra

      Me._publicos = New Publicos()
   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarProductosProveedor_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbImportar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbImportar.Click
      Me.DialogResult = Windows.Forms.DialogResult.OK
      Me.Close()
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.DialogResult = Windows.Forms.DialogResult.Cancel
      Me.Close()
   End Sub

   Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click

      Dim ArchivoStream As Stream = Nothing
      Dim DialogoAbrirArchivo As New OpenFileDialog()

      DialogoAbrirArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      DialogoAbrirArchivo.Filter = "Todos los Libros de Excel|*.xls;*.xlsx|Libro de Excel 97-2003 (*.xls)|*.xls|Libro de Excel 2007-2010 (*.xlsx)|*.xlsx|Todos los Archivos (*.*)|*.*"
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

   Private Sub btnLeerExel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeerExel.Click

      Try

         If Me.txtArchivoOrigen.Text.Trim() = "" Then
            Exit Sub
         End If

         If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
            MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         'RangoExcel = Me.txtRangoCeldas.Text.Trim.Replace(" ", "")
         RangoExcel = "[" & Me.txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"
         If RangoExcel = "" Or RangoExcel = "[An:Dn]" Then
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


#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      Me.txtArchivoOrigen.Text = ""
      Me.txtRangoCeldas.Text = "An : In"
      Me.chbLeeCodigoProveedor.Checked = True
      Me.chbLeeCompra.Checked = True
      Me.chbLeeDescuentos.Checked = True

      Me.txtArchivoOrigen.Focus()

   End Sub

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

      Dim ds As DataSet = New DataSet()
      Dim DA As New System.Data.OleDb.OleDbDataAdapter

      Try

         Dim dtImportTemp As DataTable = CreateDT()

         tsbImportar.Enabled = False
         tsbSalir.Enabled = False

         Me.AbrirExcel(txtArchivoOrigen.Text)
         DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)

         DA.Fill(ds)

         Dim reglaProductos As Reglas.Productos = New Reglas.Productos()

         Dim dr As DataRow, Codigo As String, drImport As DataRow

         For Each dr In ds.Tables(0).Rows

            If Not String.IsNullOrEmpty(dr(ColumnasExcel.Codigo).ToString.Trim()) Then

               drImport = dtImportTemp.NewRow()
               dtImportTemp.Rows.Add(drImport)

               Codigo = dr(ColumnasExcel.Codigo).ToString.Trim()

               If Not reglaProductos.Existe(Codigo) Then
                  drImport.SetColumnError(ColumnasExcel.Codigo.ToString(), "El código de producto no existe en el sistema.")
               End If

               drImport(ColumnasExcel.Codigo.ToString()) = dr(ColumnasExcel.Codigo).ToString.Trim()
               drImport(ColumnasExcel.Descripcion.ToString()) = dr(ColumnasExcel.Descripcion).ToString.Trim()

               If Me.chbLeeCodigoProveedor.Checked Then
                  drImport(ColumnasExcel.CodProveedor.ToString()) = dr(ColumnasExcel.CodProveedor).ToString.Trim()
               End If

               If chbLeeCompra.Checked And dr.Table.Columns.Count > ColumnasExcel.Compra AndAlso IsNumeric(dr(ColumnasExcel.Compra)) Then drImport(ColumnasExcel.Compra.ToString()) = CDec(dr(ColumnasExcel.Compra).ToString.Trim())
               If chbLeeDescuentos.Checked And dr.Table.Columns.Count > ColumnasExcel.D_R_1 AndAlso IsNumeric(dr(ColumnasExcel.D_R_1)) Then drImport(ColumnasExcel.D_R_1.ToString()) = CDec(dr(ColumnasExcel.D_R_1).ToString.Trim())
               If chbLeeDescuentos.Checked And dr.Table.Columns.Count > ColumnasExcel.D_R_2 AndAlso IsNumeric(dr(ColumnasExcel.D_R_2)) Then drImport(ColumnasExcel.D_R_2.ToString()) = CDec(dr(ColumnasExcel.D_R_2).ToString.Trim())
               If chbLeeDescuentos.Checked And dr.Table.Columns.Count > ColumnasExcel.D_R_3 AndAlso IsNumeric(dr(ColumnasExcel.D_R_3)) Then drImport(ColumnasExcel.D_R_3.ToString()) = CDec(dr(ColumnasExcel.D_R_3).ToString.Trim())
               If chbLeeDescuentos.Checked And dr.Table.Columns.Count > ColumnasExcel.D_R_4 AndAlso IsNumeric(dr(ColumnasExcel.D_R_4)) Then drImport(ColumnasExcel.D_R_4.ToString()) = CDec(dr(ColumnasExcel.D_R_4).ToString.Trim())
            End If
         Next

         Me.ConexionExcel.Close()

         DtImport = dtImportTemp
         SetDataSource(DtImport)

         Me.tssRegistros.Text = ugDetalle.Rows.Count.ToString() & " Registros"

         If DtImport.HasErrors Then
            MessageBox.Show("Existen algunas filas con errores. No podrá importar el archivo.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("no pudo encontrar") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
         Else
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally

         DA.Dispose()
         Me.ConexionExcel.Dispose()

         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = Not DtImport.HasErrors
         tsbSalir.Enabled = True
      End Try

   End Sub

   Private Sub SetDataSource(dt As DataTable)
      ugDetalle.DataSource = dt

      With ugDetalle.DisplayLayout.Bands(0)
         For Each column As UltraGridColumn In .Columns
            column.Hidden = True
            column.CellActivation = Activation.NoEdit
         Next

         .Columns(ColumnasExcel.Codigo.ToString()).Hidden = False
         .Columns(ColumnasExcel.Codigo.ToString()).Header.Caption = "Código"
         .Columns(ColumnasExcel.Codigo.ToString()).Header.VisiblePosition = 0
         .Columns(ColumnasExcel.Codigo.ToString()).CellAppearance.TextHAlign = HAlign.Right

         .Columns(ColumnasExcel.Codigo.ToString()).MinWidth = 120
         .Columns(ColumnasExcel.Codigo.ToString()).Width = 120
         .Columns(ColumnasExcel.Codigo.ToString()).MaxWidth = 120

         .Columns(ColumnasExcel.Descripcion.ToString()).Hidden = False
         .Columns(ColumnasExcel.Descripcion.ToString()).Header.Caption = "Descripción"
         .Columns(ColumnasExcel.Descripcion.ToString()).Header.VisiblePosition = 1

         .Columns(ColumnasExcel.CodProveedor.ToString()).Hidden = False
         .Columns(ColumnasExcel.CodProveedor.ToString()).Header.Caption = "Codigo del Proveedor"
         .Columns(ColumnasExcel.CodProveedor.ToString()).Header.VisiblePosition = 2

         .Columns(ColumnasExcel.CodProveedor.ToString()).MinWidth = 120
         .Columns(ColumnasExcel.CodProveedor.ToString()).Width = 120
         .Columns(ColumnasExcel.CodProveedor.ToString()).MaxWidth = 120

         If Publicos.UtilizaPrecioDeCompra Then
            .Columns(ColumnasExcel.Compra.ToString()).Hidden = False
            .Columns(ColumnasExcel.Compra.ToString()).Header.VisiblePosition = 4
            .Columns(ColumnasExcel.Compra.ToString()).CellAppearance.TextHAlign = HAlign.Right

            .Columns(ColumnasExcel.Compra.ToString()).MinWidth = 80
            .Columns(ColumnasExcel.Compra.ToString()).Width = 80
            .Columns(ColumnasExcel.Compra.ToString()).MaxWidth = 80

            .Columns(ColumnasExcel.D_R_1.ToString()).Hidden = False
            .Columns(ColumnasExcel.D_R_1.ToString()).Header.Caption = "D/R 1"
            .Columns(ColumnasExcel.D_R_1.ToString()).Header.VisiblePosition = 5
            .Columns(ColumnasExcel.D_R_1.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(ColumnasExcel.D_R_1.ToString()).Format = "N2"

            .Columns(ColumnasExcel.D_R_1.ToString()).Width = 50
            .Columns(ColumnasExcel.D_R_1.ToString()).MaxWidth = 50
            .Columns(ColumnasExcel.D_R_1.ToString()).MinWidth = 50

            .Columns(ColumnasExcel.D_R_2.ToString()).Hidden = False
            .Columns(ColumnasExcel.D_R_2.ToString()).Header.Caption = "D/R 2"
            .Columns(ColumnasExcel.D_R_2.ToString()).Header.VisiblePosition = 6
            .Columns(ColumnasExcel.D_R_2.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(ColumnasExcel.D_R_2.ToString()).Format = "N2"

            .Columns(ColumnasExcel.D_R_2.ToString()).Width = 50
            .Columns(ColumnasExcel.D_R_2.ToString()).MaxWidth = 50
            .Columns(ColumnasExcel.D_R_2.ToString()).MinWidth = 50

            .Columns(ColumnasExcel.D_R_3.ToString()).Hidden = False
            .Columns(ColumnasExcel.D_R_3.ToString()).Header.Caption = "D/R 3"
            .Columns(ColumnasExcel.D_R_3.ToString()).Header.VisiblePosition = 7
            .Columns(ColumnasExcel.D_R_3.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(ColumnasExcel.D_R_3.ToString()).Format = "N2"

            .Columns(ColumnasExcel.D_R_3.ToString()).Width = 50
            .Columns(ColumnasExcel.D_R_3.ToString()).MaxWidth = 50
            .Columns(ColumnasExcel.D_R_3.ToString()).MinWidth = 50

            .Columns(ColumnasExcel.D_R_4.ToString()).Hidden = False
            .Columns(ColumnasExcel.D_R_4.ToString()).Header.Caption = "D/R 4"
            .Columns(ColumnasExcel.D_R_4.ToString()).Header.VisiblePosition = 8
            .Columns(ColumnasExcel.D_R_4.ToString()).CellAppearance.TextHAlign = HAlign.Right
            .Columns(ColumnasExcel.D_R_4.ToString()).Format = "N2"

            .Columns(ColumnasExcel.D_R_4.ToString()).Width = 50
            .Columns(ColumnasExcel.D_R_4.ToString()).MaxWidth = 50
            .Columns(ColumnasExcel.D_R_4.ToString()).MinWidth = 50
         End If

      End With
      ugDetalle.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns
   End Sub

   Private Function CreateDT() As DataTable
      Dim dt As DataTable = New DataTable()

      dt.Columns.Add(ColumnasExcel.Codigo.ToString(), GetType(String))
      dt.Columns.Add(ColumnasExcel.Descripcion.ToString(), GetType(String))
      dt.Columns.Add(ColumnasExcel.CodProveedor.ToString(), GetType(String))
      dt.Columns.Add(ColumnasExcel.Compra.ToString(), GetType(Decimal))
      dt.Columns.Add(ColumnasExcel.D_R_1.ToString(), GetType(Decimal))
      dt.Columns.Add(ColumnasExcel.D_R_2.ToString(), GetType(Decimal))
      dt.Columns.Add(ColumnasExcel.D_R_3.ToString(), GetType(Decimal))
      dt.Columns.Add(ColumnasExcel.D_R_4.ToString(), GetType(Decimal))

      Return dt
   End Function
#End Region


End Class
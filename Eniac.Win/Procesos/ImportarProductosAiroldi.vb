Option Strict Off

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas

Imports System.Data
Imports System.IO

#End Region

Public Class ImportarProductosAiroldi

#Region "Campos"

   Private _publicos As Publicos
   Private _dt As DataTable

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me._publicos.CargaComboMarcas(Me.cmbMarca)

      Me.CargarValoresIniciales()

   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarDatosAiroldi_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Importacion de Productos realizada EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Me.Close()


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
      If Me.optCSV.Checked Then
         DialogoAbrirArchivo.Filter = "Archivos de Texto (*.csv)|*.csv| Todos los Archivos (*.*)|*.*"
      Else
         DialogoAbrirArchivo.Filter = "Archivos de Texto (*.txt)|*.txt| Todos los Archivos (*.*)|*.*"
      End If
      DialogoAbrirArchivo.FilterIndex = 1
      DialogoAbrirArchivo.RestoreDirectory = True

      If DialogoAbrirArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = DialogoAbrirArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               Me.txtArchivoOrigen.Text = DialogoAbrirArchivo.FileName
               'Si bien aca lo pude abrir, solo es para obtener el path.
               Me.txtCotizacionDolar.Focus()
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

   Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMostrar.Click
      Try

         If Me.cmbMarca.SelectedIndex = -1 Then
            MessageBox.Show("ATENCION: debe seleccionar una MARCA", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbMarca.Focus()
            Exit Sub
         End If

         'If Decimal.Parse(Me.txtCotizacionDolar.Text) <= 0 Then
         '   MessageBox.Show("ATENCION: debe cargar un valor correcto del DOLAR", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         '   Me.txtCotizacionDolar.Focus()
         '   Exit Sub
         'End If

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
      Me.txtCotizacionDolar.Text = "0.00"
      Me.cmbMarca.SelectedIndex = -1

      If Not Me.dgvDetalle.DataSource Is Nothing Then
         DirectCast(Me.dgvDetalle.DataSource, DataTable).Rows.Clear()
      End If

      If Not Me._dt Is Nothing Then
         Me._dt.Rows.Clear()
      End If

      Me.prbImportando.Value = 0

   End Sub

   Private Function CrearDT() As DataTable

      Dim dtTemp As DataTable = New DataTable()

      With dtTemp
         .Columns.Add("CodigoProducto", System.Type.GetType("System.String"))
         .Columns.Add("NombreProducto", System.Type.GetType("System.String"))
         .Columns.Add("Precio", System.Type.GetType("System.Decimal"))
         .Columns.Add("Moneda", System.Type.GetType("System.String"))
         .Columns.Add("MonedaConvertida", System.Type.GetType("System.String"))
         .Columns.Add("IVA", System.Type.GetType("System.Decimal"))
         .Columns.Add("NombreRubro", System.Type.GetType("System.String"))
         .Columns.Add("CostoFinal", System.Type.GetType("System.Decimal"))
      End With

      Return dtTemp

   End Function

   Private Sub Mostrar()

      Dim dt As DataTable, drCl As DataRow
      Dim Linea As String
      Dim vecDatos As Array
      Dim Costo As Decimal

      Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos

      Dim AnchoIdProducto As Integer

      AnchoIdProducto = oPublicos.GetAnchoCampo("Productos", "IdProducto")

      If Me.txtArchivoOrigen.Text.Trim() = "" Then
         Exit Sub
      End If

      If Not My.Computer.FileSystem.FileExists(txtArchivoOrigen.Text) Then
         MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Exit Sub
      End If

      tsbImportar.Enabled = False
      tsbSalir.Enabled = False

      Try

         Dim intColRubro As Integer = 0

         If Me.optCSV.Checked Then
            '0-Código,1-Descripción,2-Precio,3-Tipo (Moneda),4-IVA,5-BUE,6-ROS,7-MZA,8-CBA,9-LUG,10-Grupo,11-Rubro
            intColRubro = 11
         Else
            intColRubro = 5
         End If

         Me.Cursor = Cursors.WaitCursor

         'Leo el archivo y lo subo a la grilla. 

         dt = Me.CrearDT()

         Using sr As StreamReader = New StreamReader(txtArchivoOrigen.Text)

            Linea = sr.ReadLine

            While Not Linea Is Nothing

               System.Windows.Forms.Application.DoEvents()

               'Tuve que poner el Option Strict Off, no se como tomar la matrix.


               If Me.optCSV.Checked Then
                  '0-Código,1-Descripción,2-Precio,3-Tipo (Moneda),4-IVA,5-BUE,6-ROS,7-MZA,8-CBA,9-LUG,10-Grupo,11-Rubro
                  '"17628,SERVER LENOVO X3650M4 E5-2620 8GB SAS/SATA 3,5,3817.05480000,A,10.5,N,N,N,N,S,250,001-0300"
                  Linea = Linea.Replace(Chr(34), "")
                  vecDatos = Linea.Split(Chr(Asc(";")))
               Else
                  '0-Código|1-Descripción|2-Precio|3-Moneda|4-IVA|5-Rubro|6-ROS|7-BUE|8-CBA|9-MZA|10-ROS|11-BUE|12-CBA|13-MZA
                  vecDatos = Linea.Split(Chr(Asc("|")))
               End If

               'La primer linea es texto
               If IsNumeric(vecDatos(2).ToString()) And vecDatos(1).ToString.Trim() <> "" Then

                  drCl = dt.NewRow()

                  drCl("CodigoProducto") = Strings.Right(Strings.Space(AnchoIdProducto) & vecDatos(0), AnchoIdProducto)
                  drCl("NombreProducto") = vecDatos(1).ToString.Trim()

                  drCl("Precio") = Decimal.Parse(vecDatos(2).ToString())

                  If Me.optCSV.Checked Then
                     drCl("Moneda") = "Dolares"
                     If Decimal.Parse(txtCotizacionDolar.Text) > 0 Then
                        drCl("MonedaConvertida") = "Pesos"
                     Else
                        drCl("MonedaConvertida") = "Dolares"
                     End If
                  Else

                     drCl("Moneda") = vecDatos(3).ToString()
                     If vecDatos(3).ToString() = "Pesos" Or (vecDatos(3).ToString() <> "Pesos" And Decimal.Parse(txtCotizacionDolar.Text) > 0) Then
                        drCl("MonedaConvertida") = "Pesos"
                     Else
                        drCl("MonedaConvertida") = "Dolares"
                     End If
                  End If


                  drCl("IVA") = Decimal.Parse(vecDatos(4).ToString())
                  drCl("NombreRubro") = vecDatos(intColRubro).ToString.Trim()

                  If Me.optCSV.Checked Then
                     If Decimal.Parse(txtCotizacionDolar.Text) = 0 Then
                        Costo = Decimal.Round(Decimal.Parse(vecDatos(2).ToString()) * (1 + Decimal.Parse(vecDatos(4).ToString()) / 100), 2)
                     Else
                        Costo = Decimal.Round(Decimal.Parse(vecDatos(2).ToString()) * (1 + Decimal.Parse(vecDatos(4).ToString()) / 100) * Decimal.Parse(txtCotizacionDolar.Text), 2)
                     End If
                  Else
                     If vecDatos(3).ToString() = "Pesos" Or (vecDatos(3).ToString() <> "Pesos" And Decimal.Parse(txtCotizacionDolar.Text) = 0) Then
                        Costo = Decimal.Round(Decimal.Parse(vecDatos(2).ToString()) * (1 + Decimal.Parse(vecDatos(4).ToString()) / 100), 2)
                     Else
                        Costo = Decimal.Round(Decimal.Parse(vecDatos(2).ToString()) * (1 + Decimal.Parse(vecDatos(4).ToString()) / 100) * Decimal.Parse(txtCotizacionDolar.Text), 2)
                     End If
                  End If

                  drCl("CostoFinal") = Costo

                  'If Not String.IsNullOrEmpty(dr("CentroEmisor").ToString) Then
                  '    drCl("NumeroComprobante") = Strings.Format(dr("CentroEmisor"), "0000") & "-" & Strings.Format(dr("NumeroComprobante"), "00000000")
                  'Else
                  '    drCl("NumeroComprobante") = ""
                  'End If

                  dt.Rows.Add(drCl)

                  'While Not strLinea Is Nothing
                  '    strLinea = sr.ReadLine
                  'End While

               End If

                  Linea = sr.ReadLine
            End While

         End Using

         Me.dgvDetalle.DataSource = dt

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.tssRegistros.Text = "0 Registros"
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try

   End Sub

   Private Sub ImportarDatos()

      Dim reg As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()

      Dim dtDatos As DataTable
      Dim Marca As Integer

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      Marca = Me.cmbMarca.SelectedValue

      reg.ImportarProductosAiroldi(actual.Sucursal.Id, dtDatos, Marca, actual.Nombre, Me.prbImportando, IdFuncion)

   End Sub


   'Private Function NombreDia(ByVal dia As DayOfWeek) As String
   '   Select Case dia
   '      Case DayOfWeek.Sunday
   '         Return "Domingo"
   '      Case DayOfWeek.Monday
   '         Return "Lunes"
   '      Case DayOfWeek.Tuesday
   '         Return "Martes"
   '      Case DayOfWeek.Wednesday
   '         Return "Miercoles"
   '      Case DayOfWeek.Thursday
   '         Return "Jueves"
   '      Case DayOfWeek.Friday
   '         Return "Viernes"
   '      Case DayOfWeek.Saturday
   '         Return "Sabado"
   '      Case Else
   '         Return ""
   '   End Select
   'End Function

#End Region

End Class
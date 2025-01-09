Option Strict On
Option Explicit On

#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

Imports System.Data
Imports System.IO
Imports Eniac.Entidades

#End Region

Public Class ImportarContribuyentesARBA

   'Private Const RangoCeldasDefault As String = "An : En"

#Region "Campos"

   Private _publicos As Publicos
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String

   Private ColumnaIdCuenta As Integer = 0
   Private ColumnaNombreCuenta As Integer = 1
   Private ColumnaNivel As Integer = 2
   Private ColumnaCentroCosto As Integer = 3
   Private ColumnaEsImputable As Integer = 4
   Private EmbarcacionesConError As Integer
   Private _estaCargando As Boolean = True

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

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

      Me.dtpPeriodo.Value = Today.PrimerDiaMes()

      Me._estaCargando = False

   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarEmbarcacionesExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
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

         If Me.dgvDetalle.Rows.Count = 0 Then Exit Sub

         If EmbarcacionesConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & EmbarcacionesConError.ToString() & " Embarcaciones que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.dgvDetalle.Rows.Count - EmbarcacionesConError).ToString() & " Embarcaciones EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.prbImportando.Value = 0
         'Me.Close()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Try
         Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnExaminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExaminar.Click

      Dim ArchivoStream As Stream = Nothing
      Dim ofdArchivo As New OpenFileDialog()

      ofdArchivo.Multiselect = True
      ofdArchivo.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.Desktop
      ofdArchivo.Filter = "Archivo de texto (*.txt)|*.txt|Todos los Archivos (*.*)|*.*"
      ofdArchivo.FilterIndex = 1
      ofdArchivo.RestoreDirectory = True
      Dim str As System.Text.StringBuilder = New System.Text.StringBuilder()
      Me.Archivos.Clear()
      Me.btnMostrar.Enabled = True
      Me.tsbImportar.Enabled = True

      If ofdArchivo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
         Try
            ArchivoStream = ofdArchivo.OpenFile()
            If (ArchivoStream IsNot Nothing) Then
               For Each ar As String In ofdArchivo.FileNames
                  Me.Archivos.Add(ar)
                  str.Append(ar).AppendLine()
               Next

               Me.txtArchivoOrigen.Text = str.ToString()
               'Si bien aca lo pude abrir, solo es para obtener el path.
            End If

            'no permito mostrar la info en grilla si selecciona mas de un archivo
            If Me.Archivos.Count > 1 Then
               Me.btnMostrar.Enabled = False
               Me.tsbImportar.Enabled = False
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

         Dim existe As Boolean = True

         For Each ar As String In Me.Archivos
            If Not My.Computer.FileSystem.FileExists(ar) Then
               existe = False
            End If
         Next

         If Not existe Then
            MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         'RangoExcel = "[" & Me.txtRangoCeldas.Text.Trim.Replace(" ", "") & "]"
         'If RangoExcel = "" Or RangoExcel = RangoCeldasDefault Then
         '   MsgBox("Debe indicar el rango de celdas a leer del archivo Excel")
         '   Me.txtRangoCeldas.Focus()
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

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0

      Me.txtCantidadDePadronesARBA.Text = Publicos.CantidadBasesARBAaGuardar.ToString()

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
         .Columns.Add("Importa", GetType(Boolean))
         .Columns.Add("Accion", GetType(String))

         .Columns.Add(Entidades.PadronARBA.Columnas.IdPadronARBA.ToString(), GetType(Long))
         .Columns.Add(Entidades.PadronARBA.Columnas.PeriodoInformado.ToString(), GetType(Integer))

         .Columns.Add(Entidades.PadronARBA.Columnas.TipoRegimen.ToString(), GetType(String))
         .Columns.Add(Entidades.PadronARBA.Columnas.FechaPublicacion.ToString(), GetType(DateTime))
         .Columns.Add(Entidades.PadronARBA.Columnas.FechaVigenciaDesde.ToString(), GetType(DateTime))
         .Columns.Add(Entidades.PadronARBA.Columnas.FechaVigenciaHasta.ToString(), GetType(DateTime))
         .Columns.Add(Entidades.PadronARBA.Columnas.CUIT.ToString(), GetType(Long))
         .Columns.Add(Entidades.PadronARBA.Columnas.TipoContribuyente.ToString(), GetType(String))
         .Columns.Add(Entidades.PadronARBA.Columnas.AccionARBA.ToString(), GetType(String))
         .Columns.Add(Entidades.PadronARBA.Columnas.CambioAlicuota.ToString(), GetType(Boolean))
         .Columns.Add(Entidades.PadronARBA.Columnas.Alicuota.ToString(), GetType(Decimal))
         .Columns.Add(Entidades.PadronARBA.Columnas.Grupo.ToString(), GetType(Integer))

         .Columns.Add("Mensaje", GetType(String))

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

   Private Function ValorExcel(drXls As DataRow, columna As Integer) As String
      Return drXls(columna).ToString().Trim.Replace("'", "´")
   End Function

   Private Sub StringToDate(valor As String, drEmb As DataRow, columna As String)
      Dim iAnio As Integer = -1
      Dim iMes As Integer = -1
      Dim idia As Integer = -1

      iAnio = -1
      iMes = -1
      idia = -1
      Integer.TryParse(valor.Substring(4, 4), iAnio)
      Integer.TryParse(valor.Substring(2, 2), iMes)
      Integer.TryParse(valor.Substring(0, 2), idia)
      If iAnio < 0 Or iMes < 1 Or iMes > 12 Or idia < 1 Or idia > 31 Then
         drEmb.SetColumnError(columna, "La " + columna + " es incorrecta.")
      Else
         Try
            drEmb(columna) = New DateTime(iAnio, iMes, idia)
         Catch ex As Exception
            drEmb.SetColumnError(columna, "La " + columna + " es incorrecta.")
         End Try
      End If
   End Sub

   Private Sub Mostrar()
      Dim intCont As Integer = 0
      Try

         If TypeOf (Me.dgvDetalle.DataSource) Is IDisposable Then
            Dim o As IDisposable = DirectCast(Me.dgvDetalle.DataSource, IDisposable)
            Me.dgvDetalle.DataSource = Me.CrearDT()
            o.Dispose()
            o = Nothing
            GC.Collect()
         End If

         Dim dtEmb As DataTable = Me.CrearDT()
         Dim drEmb As DataRow
         Dim lDummy As Long = 0
         Dim dDummy As Decimal = 0

         Using strArchivo As StreamReader = New StreamReader(txtArchivoOrigen.Text.Trim)
            Dim linea As String
            While strArchivo.Peek >= 0
               linea = strArchivo.ReadLine()
               intCont += 1

               Dim columnas As String() = linea.Split(";"c)

               drEmb = dtEmb.NewRow()
               dtEmb.Rows.Add(drEmb)

               If columnas.Length < 11 Then
                  drEmb("Mensaje") = "El formato del registro es incorrecto."
                  drEmb("Accion") = "X"
                  drEmb("Importa") = False
               Else
                  If String.IsNullOrWhiteSpace(columnas(0)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.TipoRegimen.ToString(), "El Régimen es requerido.")
                  Else
                     drEmb(Entidades.PadronARBA.Columnas.TipoRegimen.ToString()) = columnas(0).Trim()
                  End If

                  If String.IsNullOrWhiteSpace(columnas(1)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.FechaPublicacion.ToString(), "La fecha de publicación es requerida.")
                  Else
                     StringToDate(columnas(1), drEmb, Entidades.PadronARBA.Columnas.FechaPublicacion.ToString())
                  End If

                  If String.IsNullOrWhiteSpace(columnas(2)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.FechaVigenciaDesde.ToString(), "La fecha de vigencia desde es requerida.")
                  Else
                     StringToDate(columnas(2), drEmb, Entidades.PadronARBA.Columnas.FechaVigenciaDesde.ToString())
                  End If

                  If String.IsNullOrWhiteSpace(columnas(3)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.FechaVigenciaHasta.ToString(), "La fecha de vigencia hasta es requerida.")
                  Else
                     StringToDate(columnas(3), drEmb, Entidades.PadronARBA.Columnas.FechaVigenciaHasta.ToString())
                  End If

                  If String.IsNullOrWhiteSpace(columnas(4)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.CUIT.ToString(), "El C.U.I.T. es requerido.")
                  Else
                     If Long.TryParse(columnas(4), lDummy) Then
                        drEmb(Entidades.PadronARBA.Columnas.CUIT.ToString()) = lDummy
                     Else
                        drEmb.SetColumnError(Entidades.PadronARBA.Columnas.CUIT.ToString(), "El C.U.I.T. no es válido.")
                     End If
                  End If

                  If String.IsNullOrWhiteSpace(columnas(5)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.TipoContribuyente.ToString(), "El Tipo de Contribuyente es requerido.")
                  Else
                     drEmb(Entidades.PadronARBA.Columnas.TipoContribuyente.ToString()) = columnas(5).Trim()
                  End If

                  If String.IsNullOrWhiteSpace(columnas(6)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.AccionARBA.ToString(), "El Alta/Baja es requerido.")
                  Else
                     drEmb(Entidades.PadronARBA.Columnas.AccionARBA.ToString()) = columnas(6).Trim()
                  End If

                  If String.IsNullOrWhiteSpace(columnas(7)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.CambioAlicuota.ToString(), "Cambia Alicuota es requerido.")
                  Else
                     drEmb(Entidades.PadronARBA.Columnas.CambioAlicuota.ToString()) = columnas(7).Trim() = "S"
                  End If

                  If String.IsNullOrWhiteSpace(columnas(8)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.Alicuota.ToString(), "El Alicuota es requerido.")
                  Else
                     If Decimal.TryParse(columnas(8).Replace(","c, "."c), dDummy) Then
                        drEmb(Entidades.PadronARBA.Columnas.Alicuota.ToString()) = dDummy
                     Else
                        drEmb.SetColumnError(Entidades.PadronARBA.Columnas.Alicuota.ToString(), "El Alicuota no es válido.")
                     End If
                  End If

                  If String.IsNullOrWhiteSpace(columnas(9)) Then
                     drEmb.SetColumnError(Entidades.PadronARBA.Columnas.Grupo.ToString(), "El Grupo es requerido.")
                  Else
                     If Long.TryParse(columnas(9), lDummy) Then
                        drEmb(Entidades.PadronARBA.Columnas.Grupo.ToString()) = lDummy
                     Else
                        drEmb.SetColumnError(Entidades.PadronARBA.Columnas.Grupo.ToString(), "El Grupo no es válido.")
                     End If
                  End If

                  If drEmb.HasErrors Then
                     drEmb("Accion") = "X"
                     drEmb("Importa") = False
                  Else
                     drEmb("Accion") = "A"
                     drEmb("Importa") = True
                  End If

               End If

               Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"

               'Application.DoEvents()

            End While
         End Using

         Me.dgvDetalle.DataSource = dtEmb

         Me.tssRegistros.Text = Me.dgvDetalle.Rows.Count.ToString() & " Registros"







         '' ''Dim dDummy As Decimal = 0
         '' ''Dim iDummy As Integer = 0
         '' ''Dim lDummy As Boolean = False
         '' ''Dim sDummy As String = ""

         '' ''Try

         '' ''   'Dim dtEmb As DataTable
         '' ''   Dim drEmb As DataRow

         '' ''   Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos

         '' ''   tsbImportar.Enabled = False
         '' ''   tsbSalir.Enabled = False

         '' ''   EmbarcacionesConError = 0

         '' ''   'Leo el archivo y lo subo a la grilla. 

         '' ''   dtEmb = Me.CrearDT()

         '' ''   Dim dsXls As DataSet = New DataSet()
         '' ''   Dim DA As System.Data.OleDb.OleDbDataAdapter = Nothing

         '' ''   Me.AbrirExcel(txtArchivoOrigen.Text)

         '' ''   Try
         '' ''      DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
         '' ''      DA.Fill(dsXls)
         '' ''   Finally
         '' ''      If DA IsNot Nothing Then DA.Dispose()
         '' ''      If ConexionExcel IsNot Nothing Then ConexionExcel.Dispose()

         '' ''   End Try

         '' ''   Dim drXls As DataRow
         '' ''   Dim Importar As Boolean
         '' ''   Dim Mensaje As String
         '' ''   Dim Accion As String

         '' ''   Me.prbImportando.Maximum = dsXls.Tables(0).Rows.Count
         '' ''   Me.prbImportando.Minimum = 0
         '' ''   Me.prbImportando.Value = 0

         '' ''   For Each drXls In dsXls.Tables(0).Rows

         '' ''      Dim mensajes As List(Of String) = New List(Of String)()

         '' ''      'Para identificar la linea en el error.
         '' ''      intCont += 1
         '' ''      Me.prbImportando.Value = intCont

         '' ''      Accion = "A"

         '' ''      System.Windows.Forms.Application.DoEvents()

         '' ''      drEmb = dtEmb.NewRow()

         '' ''      Importar = True
         '' ''      Mensaje = ""

         '' ''      If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaIdCuenta)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Falta el Id de cuenta.")
         '' ''      ElseIf Not IsNumeric(ValorExcel(drXls, ColumnaIdCuenta)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Id de cuenta debe ser numérico.")
         '' ''      Else
         '' ''         drEmb(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()) = Integer.Parse(ValorExcel(drXls, ColumnaIdCuenta))
         '' ''         Dim existe As Boolean = False
         '' ''         'If Not chkEliminaCuentasAnteriores.Checked Then
         '' ''         '   existe = (New Reglas.ContabilidadCuentas().Get1(Integer.Parse(drEmb(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).ToString()))).Rows.Count > 0
         '' ''         'End If

         '' ''         Accion = IIf(existe, "M", "A").ToString()
         '' ''      End If

         '' ''      If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaNombreCuenta)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Falta el mombre de la cuenta.")
         '' ''      Else
         '' ''         drEmb(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()) = ValorExcel(drXls, ColumnaNombreCuenta)
         '' ''      End If

         '' ''      If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaNivel)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Falta el Nivel.")
         '' ''      ElseIf Not IsNumeric(ValorExcel(drXls, ColumnaNivel)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Nivel debe ser numérico.")
         '' ''      Else
         '' ''         iDummy = Integer.Parse(ValorExcel(drXls, ColumnaNivel))
         '' ''         drEmb(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()) = iDummy
         '' ''         If iDummy <= 1 Then
         '' ''            Importar = False
         '' ''            mensajes.Add("Nivel debe ser mayor a 1. Los niveles de primer nivel estan predefinidos.")
         '' ''         End If
         '' ''      End If

         '' ''      If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaCentroCosto)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Falta el Centro de Costos.")
         '' ''      ElseIf Not IsNumeric(ValorExcel(drXls, ColumnaCentroCosto)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Centro de Costos debe ser numérico.")
         '' ''      Else
         '' ''         iDummy = Integer.Parse(ValorExcel(drXls, ColumnaCentroCosto))
         '' ''         drEmb(Entidades.ContabilidadCuenta.Columnas.IdCentroCosto.ToString()) = iDummy
         '' ''         If (New Reglas.ContabilidadCentrosCostos().Get1(iDummy)).Rows.Count = 0 Then
         '' ''            Importar = False
         '' ''            mensajes.Add("No existe Centro de Costos. Debe dar de alta primero el centro de costos.")
         '' ''         End If
         '' ''      End If

         '' ''      If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaEsImputable)) Then
         '' ''         Importar = False
         '' ''         mensajes.Add("Falta determinar si Es Imputable.")
         '' ''      Else
         '' ''         sDummy = ValorExcel(drXls, ColumnaEsImputable)
         '' ''         If sDummy = "1" Or sDummy = Boolean.TrueString Or sDummy = "S" Or sDummy = "Si" Then
         '' ''            lDummy = True
         '' ''         ElseIf sDummy = "0" Or sDummy = Boolean.FalseString Or sDummy = "N" Or sDummy = "No" Then
         '' ''            lDummy = False
         '' ''         Else
         '' ''            Importar = False
         '' ''            mensajes.Add("El valor de Es Imputable no es valido.")
         '' ''         End If
         '' ''         drEmb(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString()) = lDummy
         '' ''      End If

         '' ''      drEmb("Importa") = Importar

         '' ''      Mensaje = ""
         '' ''      For Each msg As String In mensajes
         '' ''         Mensaje += msg + " - "
         '' ''      Next

         '' ''      If Not Importar Then
         '' ''         EmbarcacionesConError += 1
         '' ''         drEmb("Mensaje") = Mensaje.Trim().Trim("-"c).Trim()
         '' ''         Accion = "X"
         '' ''      Else
         '' ''         If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
         '' ''            drEmb("Mensaje") = Mensaje.Trim().Trim("-"c).Trim()
         '' ''         Else
         '' ''            drEmb("Mensaje") = ""
         '' ''         End If

         '' ''      End If

         '' ''      drEmb("Accion") = Accion

         '' ''      If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And _
         '' ''         (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
         '' ''         dtEmb.Rows.Add(drEmb)
         '' ''      End If

         '' ''   Next

         '' ''   ConexionExcel.Close()

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            EmbarcacionesConError = 0
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.prbImportando.Value = 0
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show("Linea: " & intCont & " - " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If
      Finally
         Me.Cursor = Cursors.Default
         tsbImportar.Enabled = True
         tsbSalir.Enabled = True
      End Try
   End Sub

   Private Sub ImportarDatos()

      Dim dtDatos As DataTable

      dtDatos = DirectCast(Me.dgvDetalle.DataSource, DataTable)

      Dim reg As Reglas.PadronesARBA = New Reglas.PadronesARBA(Publicos.NombreBaseARBA)

      prbImportando.Maximum = dtDatos.Rows.Count
      prbImportando.Value = 0
      reg.ImportarARBA(Int32.Parse(dtpPeriodo.Value.ToString("yyyyMM")), dtDatos, prbImportando)
      prbImportando.Value = prbImportando.Maximum
      '' '' ''reg.ImportarCuentas(dtDatos, chkEliminaCuentasAnteriores.Checked, CInt(cmbContabilidadPlan.SelectedValue))

   End Sub

   Private _archivos As List(Of String)
   Private Property Archivos As List(Of String)
      Get
         If Me._archivos Is Nothing Then
            Me._archivos = New List(Of String)()
         End If
         Return Me._archivos
      End Get
      Set(value As List(Of String))
         Me._archivos = value
      End Set
   End Property

   Private Sub ImportarDatosDirecto()
      If cmbPadron.SelectedItem IsNot Nothing Then
         If cmbPadron.SelectedItem.ToString() = "ARBA" Then
            Dim reg As Reglas.PadronesARBA = New Reglas.PadronesARBA(Publicos.NombreBaseARBA)
            reg.ImportarARBADirecto(Ayudantes.Conexiones.Base, Me.Archivos, Int32.Parse(dtpPeriodo.Value.ToString("yyyyMM")))
         ElseIf cmbPadron.SelectedItem.ToString() = "AGIP" Then
            Dim reg As Reglas.PadronesAGIP = New Reglas.PadronesAGIP(Publicos.NombreBaseARBA)
            reg.ImportarAGIPDirecto(Ayudantes.Conexiones.Base, Me.Archivos, Int32.Parse(dtpPeriodo.Value.ToString("yyyyMM")))
         End If
      End If

   End Sub

#End Region

   Private Sub tsbImportarDirecto_Click(sender As Object, e As EventArgs) Handles tsbImportarDirecto.Click
      Try
         If String.IsNullOrEmpty(Me.txtArchivoOrigen.Text) Then Exit Sub

         Dim existe As Boolean = True

         For Each ar As String In Me.Archivos
            If Not My.Computer.FileSystem.FileExists(ar) Then
               existe = False
            End If
         Next

         If Not existe Then
            MessageBox.Show("ATENCION: El archivo a Importar NO Existe", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatosDirecto()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.dgvDetalle.Rows.Count - EmbarcacionesConError).ToString() & " Contribuyentes EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.prbImportando.Value = 0
         'Me.Close()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try
   End Sub

   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      dtpPeriodo.Value = dtpPeriodo.Value.PrimerDiaMes()
   End Sub
End Class
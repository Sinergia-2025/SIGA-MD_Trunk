#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports System.Data
Imports System.IO
#End Region

Public Class ImportarContabilidadCuentasExcel

   Private Const RangoCeldasDefault As String = "An : Gn"

#Region "Campos"

   Private _publicos As Publicos
   Private ConexionExcel As System.Data.OleDb.OleDbConnection
   Private RangoExcel As String

   Private ColumnaIdCuenta As Integer = 0
   Private ColumnaNombreCuenta As Integer = 1
   Private ColumnaNivel As Integer = 2
   Private ColumnaEsImputable As Integer = 3
   Private ColumnaIdCuentaPadre As Integer = 4
   Private ColumnaTipoDeCuenta As Integer = 5
   Private ColumnaAjusteXInflacion As Integer = 6
   Private _cuentasConError As Integer
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

      _publicos.CargaComboContabilidadPlan(cmbContabilidadPlan)

      Me.CargarValoresIniciales()

      Me._estaCargando = False

   End Sub

#End Region

#Region "Eventos"

   Private Sub ImportarContabilidadCuentasExcel_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar.PerformClick()
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

         If _cuentasConError > 0 AndAlso MessageBox.Show("ATENCION: Existen " & _cuentasConError.ToString() & " Cuentas Contables que NO se Importarán. ¿ Confirma el proceso ?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Me.ImportarDatos()

         Me.Cursor = Cursors.Default

         MessageBox.Show("Se importaron " & (Me.dgvDetalle.RowCount - _cuentasConError).ToString() & " Cuentas Contables EXITOSAMENTE !!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Me.prbImportando.Value = 0
         'Me.Close()

      Catch ex As Exception
         Dim mensaje As String = ""
         mensaje = ex.Message
         If ex.InnerException IsNot Nothing Then
            mensaje += Chr(13) + ex.InnerException.Message
            If ex.InnerException.InnerException IsNot Nothing Then
               mensaje += Chr(13) + ex.InnerException.InnerException.Message
            End If
         End If
         MessageBox.Show(mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
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
         If RangoExcel = "" Or RangoExcel = RangoCeldasDefault Then
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

      Me.txtRangoCeldas.Text = RangoCeldasDefault

      Me.cboAccion.SelectedIndex = 0
      Me.cboEstado.SelectedIndex = 0
      Me.cmbDescripcionCorte.SelectedIndex = 0


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
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString(), GetType(Long))
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString(), GetType(String))
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString(), GetType(Integer))
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString(), GetType(String))
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.Activa.ToString(), GetType(Boolean))
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString(), GetType(Long))
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString(), GetType(String))
         .Columns.Add(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString(), GetType(String)).DefaultValue = String.Empty
         .Columns.Add("Mensaje", GetType(String))

         .Columns(Entidades.ContabilidadCuenta.Columnas.Activa.ToString()).DefaultValue = True
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

   Private Sub Mostrar()

      Dim intCont As Integer = 0

      Dim dDummy As Decimal = 0
      Dim iDummy As Integer = 0
      Dim lDummy As Boolean = False
      Dim sDummy As String = ""

      Try

         Dim dtEmb As DataTable
         Dim drEmb As DataRow

         Dim oPublicos As Eniac.Reglas.Publicos = New Eniac.Reglas.Publicos()

         Me.tsbImportar.Enabled = False
         Me.tsbSalir.Enabled = False

         _cuentasConError = 0

         If New Reglas.ContabilidadAsientos().GetAll().Rows.Count > 0 Then ''Or
            ''New Reglas.ContabilidadAsientosTmp().GetTodos_Tmp().Count > 0 Then
            If chkEliminaCuentasAnteriores.Checked Then
               Throw New Exception("Existen asientos contables en el sistema. No es posible eliminar las cuentas existentes.")
            Else
               If MessageBox.Show("Existen asientos contables en el sistema." + Environment.NewLine + Environment.NewLine +
                                  "¿Está seguro que desea actualizar las cuentas del sistema?",
                                  "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No Then
                  Throw New Exception("Cancelado por el usuario.")
               End If
            End If
         End If

         If chkEliminaCuentasAnteriores.Checked AndAlso
            New Reglas.MediosdePago().GetAll().Select(String.Format("{0} <> 0", Entidades.MedioDePago.Columnas.IdCuenta.ToString())).Length > 0 Then
            Throw New Exception("Existen medios de pago con cuentas contables configuradas." + Environment.NewLine + Environment.NewLine +
                                "No es posible eliminar las cuentas existentes." + Environment.NewLine + Environment.NewLine +
                                "Debe modificar los medios de pago indicando que no posee cuenta contable.")
         End If

         'Leo el archivo y lo subo a la grilla. 

         dtEmb = Me.CrearDT()

         Dim dsXls As DataSet = New DataSet()
         Dim DA As System.Data.OleDb.OleDbDataAdapter = Nothing

         Me.AbrirExcel(txtArchivoOrigen.Text)

         Try
            DA = New System.Data.OleDb.OleDbDataAdapter("Select * From " & RangoExcel, Me.ConexionExcel)
            DA.Fill(dsXls)
         Finally
            If DA IsNot Nothing Then DA.Dispose()
            If ConexionExcel IsNot Nothing Then ConexionExcel.Dispose()
         End Try

         Dim drXls As DataRow
         Dim Importar As Boolean
         Dim Mensaje As String
         Dim Accion As String


         Me.prbImportando.Maximum = dsXls.Tables(0).Rows.Count
         Me.prbImportando.Minimum = 0
         Me.prbImportando.Value = 0

         For Each drXls In dsXls.Tables(0).Rows

            Dim mensajes As List(Of String) = New List(Of String)()

            'Para identificar la linea en el error.
            intCont += 1
            Me.prbImportando.Value = intCont

            Accion = "A"

            System.Windows.Forms.Application.DoEvents()

            drEmb = dtEmb.NewRow()

            Importar = True
            Mensaje = ""

            If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaIdCuenta)) Then
               Importar = False
               mensajes.Add("Falta el Id de cuenta.")
            ElseIf Not IsNumeric(ValorExcel(drXls, ColumnaIdCuenta)) Then
               Importar = False
               mensajes.Add("Id de cuenta debe ser numérico.")
            Else
               drEmb(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()) = Long.Parse(FormatNumber(ValorExcel(drXls, ColumnaIdCuenta), 0).Trim.Replace(",", ""))

               Dim blnExiste As Boolean = False
               If Not chkEliminaCuentasAnteriores.Checked Then
                  blnExiste = (New Reglas.ContabilidadCuentas().Get1(Long.Parse(FormatNumber(drEmb(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).ToString(), 0).Trim.Replace(",", "")))).Rows.Count > 0
               End If

               Accion = IIf(blnExiste, "M", "A").ToString()
            End If

            If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaNombreCuenta)) Then
               Importar = False
               mensajes.Add("Falta el nombre de la cuenta.")
            Else
               drEmb(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()) = ValorExcel(drXls, ColumnaNombreCuenta)
            End If

            If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaNivel)) Then
               Importar = False
               mensajes.Add("Falta el Nivel.")
            ElseIf Not IsNumeric(ValorExcel(drXls, ColumnaNivel)) Then
               Importar = False
               mensajes.Add("Nivel debe ser numérico.")
            Else
               iDummy = Integer.Parse(ValorExcel(drXls, ColumnaNivel))
               drEmb(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()) = iDummy
               If iDummy < 1 Then
                  Importar = False
                  'mensajes.Add("Nivel debe ser mayor a 1. Los niveles de primer nivel estan predefinidos.")
                  mensajes.Add("Nivel debe ser al menos 1.")
               End If
            End If

            If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaEsImputable)) Then
               Importar = False
               mensajes.Add("Falta determinar si Es Imputable.")
            Else

               sDummy = ValorExcel(drXls, ColumnaEsImputable)

               If sDummy = "1" Or sDummy = Boolean.TrueString Or sDummy = "S" Or sDummy.ToUpper() = "SI" Then
                  lDummy = True
               ElseIf sDummy = "0" Or sDummy = Boolean.FalseString Or sDummy = "N" Or sDummy.ToUpper() = "NO" Then
                  lDummy = False
               Else
                  Importar = False
                  mensajes.Add("El valor de Es Imputable no es valido. Completar con SI / NO.")
               End If
               Dim valor As String = String.Empty
               If lDummy Then
                  valor = "SI"
               Else
                  valor = "NO"
               End If
               drEmb(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString()) = valor
            End If

            If Integer.Parse("0" & drEmb(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()).ToString) > 1 Then

               If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaIdCuentaPadre)) Then
                  Importar = False
                  mensajes.Add("Falta determinar la cuenta padre.")
               ElseIf Not IsNumeric(ValorExcel(drXls, ColumnaIdCuentaPadre)) Then
                  Importar = False
                  mensajes.Add("Id de cuenta madre debe ser numérico.")
               Else
                  drEmb(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()) = Long.Parse(FormatNumber(ValorExcel(drXls, ColumnaIdCuentaPadre), 0).Trim.Replace(",", ""))
                  Dim existe As Boolean = False
                  If Not chkEliminaCuentasAnteriores.Checked Then
                     existe = (New Reglas.ContabilidadCuentas().Get1(Long.Parse(FormatNumber(drEmb(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).ToString(), 0).Trim.Replace(",", "")))).Rows.Count > 0
                  End If
               End If
            End If

            '#####################################################
            '# Nuevas Columnas agregadas a partir del 27/12/2019 #
            '#####################################################

            '###############################################################################################################################
            '# También se agregó validaciones dentro de la plantilla excel pero aún así se deja el mismo código de validación en el source #
            '###############################################################################################################################

            ' Tipo de Cuenta
            If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaTipoDeCuenta)) Then
               Importar = False
               mensajes.Add("Falta determinar el tipo de cuenta.")
            ElseIf ValorExcel(drXls, ColumnaTipoDeCuenta).ToUpper = "SIN DEFINIR" Then
               drEmb(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()) = ValorExcel(drXls, ColumnaTipoDeCuenta).ToUpper
            ElseIf ValorExcel(drXls, ColumnaTipoDeCuenta).ToUpper = "PATRIMONIO" Then
               drEmb(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()) = ValorExcel(drXls, ColumnaTipoDeCuenta).ToUpper
            ElseIf ValorExcel(drXls, ColumnaTipoDeCuenta).ToUpper = "RESULTADO" Then
               drEmb(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()) = ValorExcel(drXls, ColumnaTipoDeCuenta).ToUpper
            Else ' is numeric o mal escrito
               Importar = False
               mensajes.Add("Tipo de Cuenta debe ser: Sin Definir, Patrimonio o Resultado.")
            End If

            ' Ajusta X Inflación
            If String.IsNullOrWhiteSpace(ValorExcel(drXls, ColumnaAjusteXInflacion)) Then
               Importar = False
               mensajes.Add("Falta determinar si Ajusta por Inflación.")
            Else
               sDummy = ValorExcel(drXls, ColumnaAjusteXInflacion)
               If sDummy = "1" Or sDummy = Boolean.TrueString Or sDummy = "S" Or sDummy.ToUpper() = "SI" Then
                  lDummy = True
               ElseIf sDummy = "0" Or sDummy = Boolean.FalseString Or sDummy = "N" Or sDummy.ToUpper() = "NO" Then
                  lDummy = False
               Else
                  Importar = False
                  mensajes.Add("El valor de Ajusta por Inflación no es válido. Completar con SI / NO.")
               End If
               Dim valor As String = String.Empty
               If lDummy Then
                  valor = "SI" 'Boolean.TrueString '"True"
                  drEmb(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString()) = valor
               Else
                  valor = "NO" 'Boolean.FalseString '"False"
                  drEmb(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString()) = valor
               End If
            End If

            drEmb("Importa") = Importar

            Mensaje = ""
            For Each msg As String In mensajes
               Mensaje += msg + " - "
            Next

            If Not Importar Then
               _cuentasConError += 1
               drEmb("Mensaje") = Mensaje.Trim().Trim("-"c).Trim()
               Accion = "X"
            Else
               If Me.cmbDescripcionCorte.SelectedIndex = 2 Then
                  drEmb("Mensaje") = Mensaje.Trim().Trim("-"c).Trim()
               Else
                  drEmb("Mensaje") = ""
               End If

            End If

            drEmb("Accion") = Accion

            If (Me.cboEstado.Text = "Todos" Or (Me.cboEstado.Text = "Validos" And Importar) Or (Me.cboEstado.Text = "Invalidos" And Not Importar)) And _
               (Me.cboAccion.Text = "Todas" Or (Me.cboAccion.Text = "Altas" And Accion = "A") Or (Me.cboAccion.Text = "Modificar" And Accion = "M")) Then
               dtEmb.Rows.Add(drEmb)
            End If

         Next

         ConexionExcel.Close()

         Me.dgvDetalle.DataSource = dtEmb

         Me.tssRegistros.Text = Me.dgvDetalle.RowCount.ToString() & " Registros"

         'Igual pudo encontrar invalidos porque no se filtran inicialmente del excel.

         If Me.cboEstado.Text = "Validos" Or Me.cboAccion.Text <> "Todas" Then
            _cuentasConError = 0
         End If

      Catch ex As Exception
         Me.Cursor = Cursors.Default
         Me.prbImportando.Value = 0
         Me.tssRegistros.Text = "0 Registros"
         If ex.Message.Contains("FROM") Then
            MessageBox.Show("Rango de Celdas Invalidos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.txtRangoCeldas.Focus()
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

      Dim reg As Reglas.ContabilidadCuentas = New Reglas.ContabilidadCuentas()

      reg.ImportarCuentas(dtDatos, chkEliminaCuentasAnteriores.Checked, Int32.Parse(cmbContabilidadPlan.SelectedValue.ToString()))

   End Sub

#End Region
End Class
Option Strict Off
#Region "Imports"

Imports actual = Eniac.Entidades.Usuario.Actual

'Imports Eniac.Win
'Imports Eniac.Entidades
'Imports Eniac.Reglas
Imports Infragistics.Win.UltraWinGrid

Imports System.Data
Imports System.IO

#End Region

Public Class SueldosModificaImporteConcepto

#Region "Campos"

   Private TabGrillaConceptosSueldo As New DataSetSueldos.ConceptosPersonalDataTable, Linea As DataSetSueldos.ConceptosPersonalRow
   Private _publicos As Publicos
   Private _cargoConcepto As Boolean = False

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      Me.CargarValoresIniciales()

   End Sub

#End Region

#Region "Eventos"

   Private Sub tsbEliminarConceptosMasivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         Dim scme As SueldosConceptosMasivoEliminar = New SueldosConceptosMasivoEliminar()
         scme.ShowDialog()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbPersonalSeleccionarTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbPersonalSeleccionarTodos.CheckedChanged
      Try
         For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugvPersonal.Rows
            dr.Cells("Check").Value = Me.chbPersonalSeleccionarTodos.Checked
         Next
         Me.CargaGrillasConceptos()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbEstadoCivil_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbEstadoCivil.CheckedChanged
      Try
         Me.cmbEstadoCivil.Enabled = Me.chbEstadoCivil.Checked
         If Not Me.cmbEstadoCivil.Enabled Then
            Me.cmbEstadoCivil.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbLugarActividad_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbLugarActividad.SelectedIndexChanged
      Try
         Me.CargarGrillaPersonal()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub chbLugarActividad_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLugarActividad.CheckedChanged
      Try
         Me.cmbLugarActividad.Enabled = Me.chbLugarActividad.Checked
         If Not Me.cmbLugarActividad.Enabled Then
            Me.cmbLugarActividad.SelectedIndex = -1
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub cmbFiltrarPor_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEstadoCivil.SelectedIndexChanged
      Try
         Me.CargarGrillaPersonal()
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub ugvPersonal_CellChange(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles ugvPersonal.CellChange
      Try
         Me.ugvPersonal.UpdateData()
         If Me._cargoConcepto Then
            If MessageBox.Show("Si continua va a perder los conceptos agregados, debe grabarlos con anticipación, ¿desea continuar?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
               e.Cell.Value = Not e.Cell.Value
               Exit Sub
            End If
         End If
         If e.Cell.Row.Index >= 0 AndAlso e.Cell.Column.Key = "Check" Then
            Me.CargaGrillasConceptos()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub SueldosConceptosPersonal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
      If e.KeyCode = Keys.F5 Then
         Me.tsbRefrescar_Click(Me.tsbRefrescar, New EventArgs())
      End If
   End Sub

   Private Sub tsbRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefrescar.Click
      Try
         Me.CargarValoresIniciales()
         Me.tssRegistros.Text = "" 'Me.dgvDetalle.Rows.Count.ToString() & " Registros"
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub tsbGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbGrabar.Click

      Try

         If Me.dgvConceptosSueldo.Rows.Count = 0 Then
            MessageBox.Show("No hay Conceptos de Sueldos para procesar.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.bscCodigoConcepto.Focus()
            Exit Sub
         End If

         If MessageBox.Show("Confirma la actualización de los datos ingresados?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Exit Sub
         End If

         Me.Cursor = Cursors.WaitCursor

         Dim oMovimientos As Reglas.SueldosPersonalCodigos = New Reglas.SueldosPersonalCodigos()

         Dim ListaDatos As New List(Of Entidades.SueldosPersonaConcepto)

         Dim ObjConcepto As Entidades.SueldosPersonaConcepto

         For Each Linea As DataSetSueldos.ConceptosPersonalRow In Me.TabGrillaConceptosSueldo.Rows

            ObjConcepto = New Entidades.SueldosPersonaConcepto()

            With ObjConcepto
               .idLegajo = Linea.idLegajo
               .idConcepto = Linea.idConcepto
               .idTipoConcepto = Linea.idTipoConcepto
               .Valor = Linea.Valor
               .Periodos = Linea.Periodos
               .TipoRecibo.IdTipoRecibo = Linea.IdTipoRecibo
               .Aguinaldo = "N"
               If Linea.EsAguinaldo Then
                  .Aguinaldo = "S"
               End If

            End With

            ListaDatos.Add(ObjConcepto)

         Next

         oMovimientos.InsertarConceptoModificado(ListaDatos)

         MessageBox.Show("Los conceptos fueron grabados exitosamente!!", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

         Me.CargarValoresIniciales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      Finally
         Me.Cursor = Cursors.Default
      End Try

   End Sub

   Private Sub tsbSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalir.Click
      Me.Close()
   End Sub

   Private Sub btnAsgnarConcepto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarConcepto.Click

      Try
         If Not Me.bscCodigoConcepto.Selecciono And Not Me.bscNombreConcepto.Selecciono Then
            MessageBox.Show("Debe ingresar el Concepto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.bscCodigoConcepto.Focus()
            Exit Sub
         End If

         If Me.txtValorConcepto.Enabled = True Then
            If Decimal.Parse(Me.txtValorConcepto.Text) = 0 Then
               MessageBox.Show("Debe ingresar el valor del Concepto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.txtValorConcepto.Focus()
               Exit Sub
            End If
         End If

         If Decimal.Parse(Me.txtValorConcepto.Text) < 0 Then
            MessageBox.Show("El valor ingresado no puede ser negativo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.txtValorConcepto.Focus()
            Exit Sub
         End If

         If Me.cmbTipoRecibo.SelectedIndex = -1 Then
            MessageBox.Show("Debe seleccionar un Tipo de Recibo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.cmbTipoRecibo.Focus()
            Exit Sub
         End If

         If MessageBox.Show("Confirma el Concepto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) <> Windows.Forms.DialogResult.Yes Then
            Me.LimpiarDatosConcepto()
            Exit Sub
         End If

         Dim Linea As DataSetSueldos.ConceptosPersonalRow

         For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugvPersonal.Rows
            If dr.Cells("Check").Value.ToString() = "True" Then
               Linea = TabGrillaConceptosSueldo.NewRow()
               Linea.idConcepto = Me.bscCodigoConcepto.Text
               Linea.idLegajo = Int32.Parse(dr.Cells("IdLegajo").Value.ToString())
               Linea.idQuePide = Me.lblModalidad.Tag
               Linea.NombreConcepto = Me.bscNombreConcepto.Text
               Linea.NombreTipoConcepto = Me.lblTipoConcepto.Text
               Linea.Valor = Me.txtValorConcepto.Text
               Linea.NombreQuePide = Me.lblModalidad.Text
               Linea.idTipoConcepto = Me.lblTipoConcepto.Tag
               Linea.Periodos = Short.Parse(Me.txtPeriodosLiquidar.Text)
               Linea.IdTipoRecibo = Int32.Parse(Me.cmbTipoRecibo.SelectedValue.ToString())
               Linea.NombreTipoRecibo = Me.cmbTipoRecibo.Text
               Linea.EsAguinaldo = Me.RadioModoAguinaldo.Checked

               TabGrillaConceptosSueldo.Rows.Add(Linea)
               dgvConceptosSueldo.DataSource = TabGrillaConceptosSueldo
               Me.btnBorrarConceptoSueldo.Enabled = True
            End If
         Next

         Me._cargoConcepto = True
         Me.chbPersonalSeleccionarTodos.Enabled = False

         Me.LimpiarDatosConcepto()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnBorrarConceptoSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrarConceptoSueldo.Click

      If Me.dgvConceptosSueldo.Rows.Count = 0 Then
         MessageBox.Show("No hay conceptos para eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      If Me.dgvConceptosSueldo.ActiveRow Is Nothing Then
         MessageBox.Show("No hay conceptos seleccionados para eliminar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      Dim Eliminar As Integer
      Eliminar = Me.dgvConceptosSueldo.ActiveRow.ListIndex
      Me.TabGrillaConceptosSueldo.Rows(Eliminar).Delete()

      dgvConceptosSueldo.DataSource = TabGrillaConceptosSueldo

      If Me.TabGrillaConceptosSueldo.Rows.Count = 0 Then
         Me.btnBorrarConceptoSueldo.Enabled = False
      End If

   End Sub

   Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
      Me.LimpiarDatosConcepto()
   End Sub

   Private Sub bscCodigoConcepto_BuscadorClick() Handles bscCodigoConcepto.BuscadorClick

      Dim NroDoc As Integer = -1

      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscCodigoConcepto)
         Dim oConceptos As Reglas.SueldosConceptos = New Reglas.SueldosConceptos
         If Me.bscCodigoConcepto.Text.Trim.Length > 0 Then
            NroDoc = Long.Parse(Me.bscCodigoConcepto.Text.Trim())
         End If
         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)

         Dim Aguinaldo As Boolean = False
         If Me.RadioModoAguinaldo.Checked = True Then
            Aguinaldo = True
         End If

         Me.bscCodigoConcepto.Datos = oConceptos.GetPorCodigo(NroDoc, Aguinaldo)

         ' Me.bscNroDoc.Datos = oSocios.GetUno(NroDoc)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscCodigoConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscCodigoConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
            'Me.CargaGrillasConceptos()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorClick() Handles bscNombreConcepto.BuscadorClick
      Try
         Me._publicos.PreparaGrillaSueldosConceptos(Me.bscNombreConcepto)
         Dim oClientes As Reglas.SueldosConceptos = New Reglas.SueldosConceptos

         Dim Aguinaldo As Boolean = False
         If Me.RadioModoAguinaldo.Checked = True Then
            Aguinaldo = True
         End If

         Me.bscNombreConcepto.Datos = oClientes.GetPorNombre(Me.bscNombreConcepto.Text.Trim(), Aguinaldo)

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub bscNombreConcepto_BuscadorSeleccion(ByVal sender As Object, ByVal e As Controles.BuscadorEventArgs) Handles bscNombreConcepto.BuscadorSeleccion
      Try
         If Not e.FilaDevuelta Is Nothing Then
            Me.CargarDatosConcepto(e.FilaDevuelta)
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub


#End Region

#Region "Metodos"

   Private Sub CargarGrillaPersonal()
      Dim lis As List(Of Entidades.SueldosPersonal) = New Reglas.SueldosPersonal().GetTodosActivos()

      Dim dt As DataSetSueldos.PersonalDataTable = New DataSetSueldos.PersonalDataTable()
      Dim dr As DataSetSueldos.PersonalRow
      Dim idEstadoCivil As Integer = 0
      Dim idLugarActividad As Integer = 0

      If Me.chbEstadoCivil.Checked Then
         idEstadoCivil = Int32.Parse(Me.cmbEstadoCivil.SelectedValue.ToString())
      End If

      If Me.chbLugarActividad.Checked Then
         idLugarActividad = Int32.Parse(Me.cmbLugarActividad.SelectedValue.ToString())
      End If

      Dim personas As IEnumerable(Of Entidades.SueldosPersonal)

      If idEstadoCivil <> 0 Then
         If idLugarActividad <> 0 Then
            personas = From l As Entidades.SueldosPersonal In lis _
                           Where l.IdEstadoCivil = idEstadoCivil _
                           And l.LugarActividad.IdLugarActividad = idLugarActividad _
                           Select l
         Else
            personas = From l As Entidades.SueldosPersonal In lis _
                           Where l.IdEstadoCivil = idEstadoCivil _
                         Select l
         End If
      Else
         If idLugarActividad <> 0 Then
            personas = From l As Entidades.SueldosPersonal In lis _
                       Where l.LugarActividad.IdLugarActividad = idLugarActividad _
                        Select l
         Else
            personas = From l As Entidades.SueldosPersonal In lis _
            Select l
         End If
      End If

      For Each p As Entidades.SueldosPersonal In personas
         dr = dt.NewPersonalRow()
         dr.IdLegajo = p.idLegajo
         dr.NombrePersonal = p.NombrePersonal
         dr.Domicilio = p.Domicilio
         dr.TipoDocPersonal = p.TipoDocPersonal
         dr.NroDocPersonal = p.NroDocPersonal
         dt.AddPersonalRow(dr)
      Next

      Me.TabGrillaConceptosSueldo.Rows.Clear()

      Me.ugvPersonal.DataSource = dt
      Me.chbPersonalSeleccionarTodos.Checked = False

   End Sub

   Private Sub CargarValoresIniciales()

      Me._publicos.CargaComboSueldosTiposRecibos(Me.cmbTipoRecibo)
      Me._publicos.CargaComboSueldosEstadoCivil(Me.cmbEstadoCivil)
      Me._publicos.CargaComboSueldosLugaresActividad(Me.cmbLugarActividad)

      Me.chbEstadoCivil.Checked = False
      Me.chbLugarActividad.Checked = False

      Me.chbPersonalSeleccionarTodos.Enabled = True
      Me._cargoConcepto = False

      Me.cmbEstadoCivil.SelectedIndex = -1

      Me.CargarGrillaPersonal()

      Me.LimpiarDatosConcepto()

   End Sub

   Private Sub CargarDatosConcepto(ByVal dr As DataGridViewRow)

      Me.bscNombreConcepto.Text = dr.Cells("NombreConcepto").Value.ToString()
      Me.bscNombreConcepto.Enabled = False
      Me.bscCodigoConcepto.Text = dr.Cells("idConcepto").Value.ToString()
      Me.bscCodigoConcepto.Enabled = False

      Me.lblTipoConcepto.Text = dr.Cells("NombreTipoConcepto").Value.ToString
      Me.lblTipoConcepto.Tag = dr.Cells("idTipoConcepto").Value.ToString

      Me.lblModalidad.Text = dr.Cells("NombreQuePide").Value.ToString
      Me.lblModalidad.Tag = dr.Cells("idQuePide").Value.ToString
      If lblModalidad.Tag > "0" Then
         Me.txtValorConcepto.Enabled = True
      Else
         Me.txtValorConcepto.Enabled = False
      End If

      If dr.Cells("TIPO").Value.ToString = "U" Then
         Me.txtPeriodosLiquidar.Enabled = True
         Me.txtPeriodosLiquidar.Text = "1"
      Else
         Me.txtPeriodosLiquidar.Enabled = False
         Me.txtPeriodosLiquidar.Text = "0"

      End If


      Me.lblNormal_o_Aguianaldo.Tag = dr.Cells("Aguinaldo").Value.ToString
      If Me.lblNormal_o_Aguianaldo.Tag = "N" Then
         Me.lblNormal_o_Aguianaldo.Text = "NORMAL"
      Else
         Me.lblNormal_o_Aguianaldo.Text = "AGUINALDO"
      End If

      If Me.txtValorConcepto.Enabled Then
         Me.txtValorConcepto.Focus()
         Me.txtValorConcepto.SelectAll()
      Else
         Me.btnAsignarConcepto.Focus()
      End If

   End Sub

   Private Sub CargaGrillasConceptos()
      Dim idLegajos As List(Of Integer) = New List(Of Integer)()
      For Each dr As Infragistics.Win.UltraWinGrid.UltraGridRow In Me.ugvPersonal.Rows
         If dr.Cells("Check").Value.ToString() = "True" Then
            idLegajos.Add(Int32.Parse(dr.Cells("IdLegajo").Value.ToString()))
         End If
      Next

      Me.grpConceptos.Enabled = (idLegajos.Count > 0)

      Dim oSueldosConceptos As Reglas.SueldosConceptos = New Reglas.SueldosConceptos()

      Dim Tabla As DataTable

      Me.TabGrillaConceptosSueldo.Rows.Clear()

      Tabla = oSueldosConceptos.GetConceptosPersonas(idLegajos)

      For Each Dato As DataRow In Tabla.Rows
         'Linea = TabGrillaConceptosSueldo.NewConceptosPersonalRow

         'Linea.idLegajo = Dato.Item("idLegajo")
         'Linea.idConcepto = Dato.Item("idConcepto")
         'Linea.NombreConcepto = Dato.Item("NombreConcepto")
         'Linea.NombreTipoConcepto = Dato.Item("NombreTipoConcepto")
         'Linea.idTipoConcepto = Dato.Item("IdTipoConcepto")
         'Linea.idQuePide = Dato.Item("idQuePide")
         'Linea.NombreQuePide = Dato.Item("NombreQuePide")
         'Linea.Valor = Dato.Item("Valor")
         'Linea.Periodos = Integer.Parse(Dato.Item("Periodos").ToString())
         'Linea.EsAguinaldo = (Dato("Aguinaldo").ToString() = "S")
         'Linea.IdTipoRecibo = Integer.Parse(Dato("IdTipoRecibo").ToString())
         'Linea.NombreTipoRecibo = Dato("NombreTipoRecibo").ToString()
         'TabGrillaConceptosSueldo.AddConceptosPersonalRow(Linea)
      Next

      Me.dgvConceptosSueldo.DataSource = TabGrillaConceptosSueldo

      Me.btnBorrarConceptoSueldo.Enabled = (Me.TabGrillaConceptosSueldo.Rows.Count > 0)

      Me.txtValorConcepto.Focus()
      Me.txtValorConcepto.SelectAll()

      Me.LimpiarDatosConcepto()

   End Sub

   Private Sub Filtrar(ByVal campo As String, ByVal valor As String)

      Dim lis As List(Of Entidades.SueldosPersonal) = New Reglas.SueldosPersonal().GetTodosActivos()

      Dim dt As DataSetSueldos.PersonalDataTable = New DataSetSueldos.PersonalDataTable()
      Dim dr As DataSetSueldos.PersonalRow

      For Each p As Entidades.SueldosPersonal In lis
         dr = dt.NewPersonalRow()
         dr.IdLegajo = p.idLegajo
         dr.NombrePersonal = p.NombrePersonal
         dt.AddPersonalRow(dr)
      Next

      Me.ugvPersonal.DataSource = dt

   End Sub

   Private Sub LimpiarDatosConcepto()
      Me.bscCodigoConcepto.Text = ""
      Me.bscCodigoConcepto.Enabled = True
      Me.bscNombreConcepto.Text = ""
      Me.bscNombreConcepto.Tag = ""
      Me.bscNombreConcepto.Enabled = True
      Me.lblTipoConcepto.Text = ""
      Me.lblModalidad.Text = ""
      Me.txtPeriodosLiquidar.Text = ""
      Me.txtValorConcepto.Text = "0.00"
      Me.lblNormal_o_Aguianaldo.Text = ""
      Me.txtValorConcepto.Enabled = True
      Me.btnAsignarConcepto.Enabled = True
      Me.bscCodigoConcepto.Focus()
   End Sub

#End Region


End Class
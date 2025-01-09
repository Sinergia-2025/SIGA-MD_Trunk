Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.SueldosTipoConcepto

Public Class SueldosConceptosDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _EstaCargando As Boolean = True

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.SueldosConcepto)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)
      Try
         Me._publicos = New Publicos()

         Me.CargaComboTiposConceptos(Me.cmbTipoConcepto)
         Me.CargaComboQuePide(Me.cmbQuePide)

         'With Me.cmbQuePide
         '   .Items.Clear()
         '   .Items.Add(Entidades.SueldosConcepto.QuePide.Nada.ToString)
         '   .Items.Add(Entidades.SueldosConcepto.QuePide.Cantidad.ToString)
         '   .Items.Add(Entidades.SueldosConcepto.QuePide.Importe.ToString)
         '   .Items.Add(Entidades.SueldosConcepto.QuePide.Porcentaje.ToString)
         'End With


         Me.BindearControles(Me._entidad)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            'Me.chbActivo.Checked = True
            'Me.cmbQuePide.SelectedIndex = 1

            Me.CargarProximoNumero()

            DirectCast(Me._entidad, Entidades.SueldosConcepto).Aguinaldo = "N"
            Me.RadioModoNormal.Checked = True

            DirectCast(Me._entidad, Entidades.SueldosConcepto).Tipo = "P"
            Me.RadioTipoPermanente.Checked = True

            DirectCast(Me._entidad, Entidades.SueldosConcepto).LiquidacionAnual = True
            Me.chbLiquidacionAnual.Checked = True

            DirectCast(Me._entidad, Entidades.SueldosConcepto).MostrarEnRecibo = True
            Me.chbMostrarEnRecibo.Checked = True

            DirectCast(Me._entidad, Entidades.SueldosConcepto).EsContempladoAguinaldo = False
            Me.chbEsContempladoAguinaldo.Checked = False

         Else

            'Dim QuePide As Integer
            'QuePide = DirectCast(Me._entidad, Entidades.SueldosConcepto).idQuepide
            'Me.cmbQuePide.SelectedValue = QuePide

            If DirectCast(Me._entidad, Entidades.SueldosConcepto).Aguinaldo = "S" Then
               Me.RadioModoAguinaldo.Checked = True
            Else
               Me.RadioModoNormal.Checked = True
            End If
            If DirectCast(Me._entidad, Entidades.SueldosConcepto).Tipo = "U" Then
               Me.radioTipoUnitaria.Checked = True
            Else
               Me.RadioTipoPermanente.Checked = True
            End If

            Me.txtLiquidacionMeses.Visible = True
            Me.txtLiquidacionMeses.Visible = False

            If DirectCast(Me._entidad, Entidades.SueldosConcepto).EsContempladoAguinaldo = True Then
               Me.chbEsContempladoAguinaldo.Checked = True
            Else
               Me.chbEsContempladoAguinaldo.Checked = False
            End If

            'recorro el txt y lo cargo en el cbl
            Dim i As Integer = 0
            If Not String.IsNullOrEmpty(Me.txtLiquidacionMeses.Text) Then
               For i = 0 To clbLiquidacionMeses.Items.Count - 1
                  If Me.txtLiquidacionMeses.Text.Length <= i Then
                     Exit For
                  End If
                  If Me.txtLiquidacionMeses.Text.ToString().Substring(i, 1) = "X" Then
                     clbLiquidacionMeses.SetItemChecked(i, True)
                  Else
                     clbLiquidacionMeses.SetItemChecked(i, False)
                  End If

               Next
            End If

            Me.clbLiquidacionMeses.Visible = Not Me.chbLiquidacionAnual.Checked

            'Navego los tabs para activar los controles combobox y que luego se validen, sino, no sucede.
            Me.tbcDetalle.SelectedTab = Me.tbpFormula
            Me.tbcDetalle.SelectedTab = Me.tbpDatos
            'Me.tbcDetalle.Focus()
            Me.txtNombre.Focus()

         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

      Me._EstaCargando = False

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SueldosConceptos
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If Integer.Parse(Me.txtCodigoConcepto.Text) <= 0 Then
         Return "El Codigo del Concepto No puede ser 0 (Cero) o Negativo."
      End If

      'GAR - 30/08/2016: Esta bien, pero repensarlo. lo hice modificar muy restrictivo.
      'If Me.txtFormula.Text.Contains("CODVALOR") And (Me.cmbQuePide.SelectedIndex = 0 Or Decimal.Parse("0" & Me.txtValor.Text) = 0) Then
      '   Return "La formula contiene CODVALOR pero esta seleccionado que no Pide o el valor es 0."
      'Else
      '   If Not Me.txtFormula.Text.Contains("CODVALOR") And (Me.cmbQuePide.SelectedIndex <> 0 Or Decimal.Parse("0" & Me.txtValor.Text) <> 0) Then
      '      Return "La formula no contiene CODVALOR pero esta seleccionado que Pide o el valor distinto de 0."
      '   End If
      'End If

      If Me.txtFormula.Text.Contains("CODVALOR") And Decimal.Parse("0" & Me.txtValor.Text) = 0 Then
         Return "La formula contiene CODVALOR pero esta seleccionado que el valor es 0."
      Else
         If Not Me.txtFormula.Text.Contains("CODVALOR") And Decimal.Parse("0" & Me.txtValor.Text) <> 0 Then
            Return "La formula no contiene CODVALOR pero el valor es distinto de 0."
         End If
      End If

      If Not Me.txtFormula.Text.Contains("CODVALOR") And Not Me.txtFormula.Text.Contains("LIQVALOR") And (Me.cmbQuePide.SelectedIndex > 0 Or Decimal.Parse("0" & Me.txtValor.Text) <> 0) Then
         Return "La formula contiene no contiene CODVALOR ni LIQVALOR pero esta seleccionado que Pide y el valor es 0."
      End If

      Dim concepto As DataTable = New Reglas.SueldosConceptos().GetUnoPorCodigo(Integer.Parse(Me.txtCodigoConcepto.Text.ToString()), DirectCast(Me._entidad, Entidades.SueldosConcepto).idConcepto)
      If concepto.Rows.Count <> 0 Then
         Return "El código de concepto ya existe."
      End If

      Return MyBase.ValidarDetalle()

   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      Me.txtCodigoConcepto.Focus()
   End Sub

   Private Sub radioTipoUnitaria_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radioTipoUnitaria.CheckedChanged
      If Me._EstaCargando Then Exit Sub
      If Me.radioTipoUnitaria.Checked Then
         DirectCast(Me._entidad, Entidades.SueldosConcepto).Tipo = "U"
      End If
   End Sub

   Private Sub RadioTipoPermanente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioTipoPermanente.CheckedChanged
      If Me._EstaCargando Then Exit Sub
      If Me.RadioTipoPermanente.Checked Then
         DirectCast(Me._entidad, Entidades.SueldosConcepto).Tipo = "P"
      End If
   End Sub

   Private Sub RadioModoNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioModoNormal.CheckedChanged
      If Me._EstaCargando Then Exit Sub
      If Me.RadioModoNormal.Checked Then
         DirectCast(Me._entidad, Entidades.SueldosConcepto).Aguinaldo = "N"
      End If
   End Sub

   Private Sub RadioModoAguinaldo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioModoAguinaldo.CheckedChanged
      If Me._EstaCargando Then Exit Sub
      If Me.RadioModoAguinaldo.Checked Then
         DirectCast(Me._entidad, Entidades.SueldosConcepto).Aguinaldo = "S"
      End If
   End Sub

   Private Sub cmbQuePide_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQuePide.SelectedIndexChanged

      If Me._EstaCargando Then Exit Sub

      'Dim Valor As Integer, vQ As Eniac.Entidades.SueldosConcepto.QuePide
      'Valor = Integer.Parse(Me.cmbQuePide.SelectedIndex.ToString)

      'Select Case Valor
      '   Case -1, 0
      '      vQ = Entidades.SueldosConcepto.QuePide.Nada
      '   Case 1
      '      vQ = Entidades.SueldosConcepto.QuePide.Cantidad
      '   Case 2
      '      vQ = Entidades.SueldosConcepto.QuePide.Importe
      '   Case Else
      '      vQ = Entidades.SueldosConcepto.QuePide.Porcentaje
      'End Select

      'DirectCast(Me._entidad, Entidades.SueldosConcepto).idQuepide = vQ
      If Me.cmbQuePide.SelectedValue IsNot Nothing Then
         DirectCast(Me._entidad, Entidades.SueldosConcepto).idQuepide = Integer.Parse(Me.cmbQuePide.SelectedValue.ToString())
      End If

   End Sub

   Private Sub chbLiquidacionAnual_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbLiquidacionAnual.CheckedChanged

      If Me._EstaCargando Then Exit Sub


      Me.clbLiquidacionMeses.Visible = Not Me.chbLiquidacionAnual.Checked

      Me.txtLiquidacionMeses.Visible = True
      Me.txtLiquidacionMeses.Visible = False

      If Not Me.clbLiquidacionMeses.Visible Then
         Me.txtLiquidacionMeses.Text = ""
      Else
         Dim i As Integer
         For i = 0 To clbLiquidacionMeses.Items.Count - 1
            clbLiquidacionMeses.SetItemChecked(i, False)
         Next
      End If


      'Me.txtLiquidacionMeses.IsRequired = True
      'If Not Me.txtLiquidacionMeses.Visible Then
      '   Me.txtLiquidacionMeses.Text = ""
      '   Me.txtLiquidacionMeses.IsRequired = False
      'End If

   End Sub

   Private Sub clbLiquidacionMeses_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles clbLiquidacionMeses.SelectedIndexChanged
      Dim cadena As String = ""
      Dim i As Integer
      For i = 0 To clbLiquidacionMeses.Items.Count - 1
         If clbLiquidacionMeses.GetItemChecked(i) = True Then
            cadena = cadena + "X"
         Else
            cadena = cadena + " "

         End If
      Next
      Me.txtLiquidacionMeses.Text = cadena
   End Sub

#End Region

#Region "Metodos"

   Public Sub CargaComboTiposConceptos(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreTipoConcepto"
         .ValueMember = "IdTipoConcepto"
         .DataSource = New Reglas.SueldosTiposConceptos().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Public Sub CargaComboQuePide(ByVal combo As Eniac.Controles.ComboBox)
      With combo
         .DisplayMember = "NombreQuePide"
         .ValueMember = "IdQuePide"
         .DataSource = New Reglas.SueldosQuePideConcepto().GetAll()
         .SelectedIndex = -1
      End With
   End Sub

   Private Sub CargarProximoNumero()
      Dim oSC As Reglas.SueldosConceptos = New Reglas.SueldosConceptos()
      DirectCast(Me._entidad, Entidades.SueldosConcepto).idConcepto = (oSC.GetCodigoMaximo() + 1)
   End Sub

   Private Sub CargarTipoConcepto(ByVal dr As DataGridViewRow)
      DirectCast(Me._entidad, Entidades.SueldosConcepto).idTipoConcepto = Int32.Parse(dr.Cells("IdTipoConcepto").Value.ToString())
      Me.cmbTipoConcepto.SelectedValue = dr.Cells("IdTipoConcepto").Value.ToString()
   End Sub

#End Region

End Class

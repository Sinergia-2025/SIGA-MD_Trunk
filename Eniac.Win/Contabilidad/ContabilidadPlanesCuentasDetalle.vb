Option Explicit On
Option Strict On

Public Class ContabilidadPlanesCuentasDetalle

#Region "Campos"

   Private _publicos As ContabilidadPublicos
   Private dtGrilla As DataTable
   Dim cantInicial As Integer = 0

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.ContabilidadPlanCuenta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      MyBase.OnLoad(e)

      Try
         Me._publicos = New ContabilidadPublicos()
         Me._entidad = New Entidades.ContabilidadPlanCuenta

         Me._publicos.CargaComboCuentas(Me.cmbCuenta)
         Me._publicos.CargaComboPlanes(cmbPlan, False)

         Me.BindearControles(Me._entidad)

         Me.CargarValoresIniciales()

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.ContabilidadPlanesCuentas()
   End Function

   Protected Overrides Sub Aceptar()

      If Validar() Then

         DirectCast(Me._entidad, Entidades.ContabilidadPlanCuenta).grillaCuentas = DirectCast(Me.grdPlanCuentas.DataSource, DataTable)

         MyBase.Aceptar()

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.Close()
         End If

      End If
   End Sub
#End Region

#Region "Eventos"



   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
      If Not Me.HayError Then Me.Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarValoresIniciales()
      'End If
      ' Me.txtcodigoPlan.Focus()
   End Sub

   Private Sub cmdAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAgregar.Click

      If validacionesCuentasOK() Then
         BuscarDatosComplementariosCuenta(Integer.Parse(Me.cmbCuenta.SelectedValue.ToString())) ' busca y agrega la fila
      End If

   End Sub

   Private Sub cmbQuitar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQuitar.Click
      If Me.grdPlanCuentas.SelectedRows.Count = 0 Then
         MessageBox.Show("Seleccione la cuenta a quitar", "Planes de cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
      Else
         DirectCast(Me.grdPlanCuentas.DataSource, DataTable).Rows.RemoveAt(Me.grdPlanCuentas.SelectedCells.Item(1).RowIndex)
         ' Me.grdPlanCuentas.DataSource = dtGrilla

      End If
   End Sub


   Private Sub trvPlan_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles trvPlan.DoubleClick

      If Me.trvPlan.SelectedNode.Level = 3 Then
         If Not Me.grdPlanCuentas.DataSource Is Nothing Then


            For Each filaVal As DataRow In DirectCast(Me.grdPlanCuentas.DataSource, DataTable).Rows
               If Int64.Parse(filaVal("idCuenta").ToString) = Int64.Parse(DirectCast(trvPlan, System.Windows.Forms.TreeView).SelectedNode.Name) Then
                  MessageBox.Show("La cuenta ya existe en el plan", "Plan de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
                  Exit Sub
               End If
            Next
         End If

         Dim fila As DataRow
         fila = dtGrilla.NewRow
         fila("IdCuenta") = Int64.Parse(DirectCast(trvPlan, System.Windows.Forms.TreeView).SelectedNode.Name).ToString
         fila("NombreCuenta") = Split(DirectCast(trvPlan, System.Windows.Forms.TreeView).SelectedNode.Text, " - ")(1)
         dtGrilla.Rows.Add(fila)

         If (Not Me.grdPlanCuentas.DataSource Is Nothing) AndAlso DirectCast(Me.grdPlanCuentas.DataSource, DataTable).Rows.Count > 0 Then
            dtGrilla.Merge(DirectCast(Me.grdPlanCuentas.DataSource, DataTable))
         End If

         Me.grdPlanCuentas.DataSource = dtGrilla

      End If
   End Sub

   Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
      If grdPlanCuentas.Rows.Count > 0 Then
         DirectCast(grdPlanCuentas.DataSource, DataTable).Rows.Clear()
      End If
      If Me.chkTodas.Checked Then
         Dim oplanCuenta As Reglas.ContabilidadPlanesCuentas = New Reglas.ContabilidadPlanesCuentas()
         Me.grdPlanCuentas.DataSource = oplanCuenta.seleccionarTodasLasCuentas()
      End If

   End Sub

   Private Sub cmdVer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVer.Click
      Using frm As New ContabilidadPlanesCuentasPreView()
         frm.IdPlanCuenta = CInt(Me.cmbPlan.SelectedValue)
         frm.ShowDialog()
      End Using
   End Sub

   Private Sub cmbPlan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlan.SelectedIndexChanged

      llenarGrillaPlan(CInt(Me.cmbPlan.SelectedValue))

   End Sub


#End Region

#Region "Metodos"


   Private Function Validar() As Boolean

      If Me.cmbPlan.SelectedIndex = -1 Then
         MessageBox.Show("Seleccione una Plan de Cuenta", "Plan de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbPlan.Focus()
         Return False
      End If

      'If CInt(Me.cmbPlan.SelectedValue) = 1 Then
      '   MessageBox.Show("El plan de cuenta seleccionado no se puede modificar", "Plan de Cuenta Principal", MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Me.cmbPlan.Focus()
      '   Return False
      'End If

      If cantInicial = 0 And Me.grdPlanCuentas.Rows.Count = 0 Then
         MessageBox.Show("No hay cuentas seleccionadas para agregar al plan", "Plan de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmdAgregar.Focus()
         Return False
      End If


      Return True
   End Function

   Private Function validacionesCuentasOK() As Boolean

      If Me.cmbCuenta.SelectedIndex = -1 Then ' si seleccionó algo...
         MessageBox.Show("Seleccione una cuenta", "Plan de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.cmbCuenta.Focus()
         Return False
      End If
      ' si esta repetida
      If Me.grdPlanCuentas.Rows.Count > 0 Then
         For Each dr As DataRow In DirectCast(Me.grdPlanCuentas.DataSource, DataTable).Rows
            If Int64.Parse(dr("IdCuenta").ToString()) = Int64.Parse(Me.cmbCuenta.SelectedValue.ToString()) Then
               MessageBox.Show("La cuenta ya existe en el plan", "Plan de Cuenta", MessageBoxButtons.OK, MessageBoxIcon.Information)
               Me.cmbCuenta.Focus()
               Return False
            End If
         Next
      End If

      Return True
   End Function

   Private Sub CargarValoresIniciales()

      Me.cmbPlan.SelectedValue = 1

      Me.lblEmpresa.Text = Publicos.NombreEmpresaImpresion

      Me._publicos.ConfigurarArbol(Me.trvPlan)

   End Sub

   Private Sub llenarGrillaPlan(ByVal idPlan As Integer)
      Dim oplanCuenta As Reglas.ContabilidadPlanesCuentas = New Reglas.ContabilidadPlanesCuentas()
      Dim dtaux As DataTable
      cantInicial = 0
      dtaux = DirectCast(oplanCuenta.GetUna(idPlan), Entidades.ContabilidadPlanCuenta).grillaCuentas
      dtGrilla = crearTablaGrilla()
      Me.grdPlanCuentas.DataSource = dtaux 'DirectCast(Me._entidad, Entidades.PlanCuenta).grillaCuentas
      If Not dtaux Is Nothing Then
         Me.grdPlanCuentas.Columns("NombreCuenta").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
         cantInicial = dtaux.Rows.Count
      End If


   End Sub

   Private Function AplicarJerarquia(ByVal codigo As String) As String

      Return codigo.Substring(0, 1) & "." _
                      & codigo.Substring(1, 2) & "." _
                      & codigo.Substring(3, 2) & "." _
                      & codigo.Substring(5, 3)
   End Function

   Private Sub BuscarDatosComplementariosCuenta(ByVal idCuenta As Integer)
      Dim oplanCuenta As Reglas.ContabilidadPlanesCuentas = New Reglas.ContabilidadPlanesCuentas()

      Dim dtDetalle As DataTable
      Dim fila As DataRow

      dtDetalle = oplanCuenta.GetDatosCuenta(idCuenta)

      fila = dtGrilla.NewRow
      fila("NombreCuenta") = dtDetalle.Rows(0)("Cuenta")
      fila("IdCuenta") = dtDetalle.Rows(0)("codigo")
      'fila("tipoCuenta") = dtDetalle.Rows(0)("tipoCuenta")
      'fila("jerarquia") = dtDetalle.Rows(0)("jerarquia")

      dtGrilla.Rows.Add(fila)

      Me.grdPlanCuentas.DataSource = dtGrilla
      Me.grdPlanCuentas.Columns("NombreCuenta").AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

   End Sub

   Private Function crearTablaGrilla() As DataTable
      Dim datosGrillas As New DataTable

      datosGrillas.Columns.Add("NombreCuenta", System.Type.GetType("System.String")) 'Cuentas.NombreCuenta
      datosGrillas.Columns.Add("IdCuenta", System.Type.GetType("System.Int64")) 'Cuentas.IdCuenta
      'datosGrillas.Columns.Add("TipoCuenta", System.Type.GetType("System.String")) ' TiposCuentas.NombreTipoCuenta
      'datosGrillas.Columns.Add("Jerarquia", System.Type.GetType("System.String")) ' cuentas.idCuentaPadre

      Return datosGrillas

   End Function


#End Region

End Class
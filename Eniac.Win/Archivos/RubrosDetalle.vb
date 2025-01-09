#Region "Option/Imports"
Option Explicit On
Option Strict On

Imports actual = Eniac.Entidades.Usuario.Actual
#End Region

Imports Infragistics.Win.UltraWinGrid
Public Class RubrosDetalle

#Region "Campos"

   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
   Private _idActividad As Integer = 0
   Private _decimalesEnDescRec As Integer
   Private _titRubroComisDesRec As Dictionary(Of String, String)
   Private _EntRubroComisDesRec As List(Of Entidades.RubroComisionPorDescuento)
#End Region

#Region "Propiedades"

   Private _idRubro As String
   Public Property IdRubro() As String
      Get
         Return _idRubro
      End Get
      Set(ByVal value As String)
         _idRubro = value
      End Set
   End Property

#End Region

#Region "Constructores"

   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.Rubro)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      _decimalesEnDescRec = Reglas.Publicos.Facturacion.Redondeo.FacturacionDecimalesEnDescRec

      txtUHPorc1.Formato = "N" + _decimalesEnDescRec.ToString()
      txtUHPorc2.Formato = "N" + _decimalesEnDescRec.ToString()
      txtUHPorc3.Formato = "N" + _decimalesEnDescRec.ToString()
      txtUHPorc4.Formato = "N" + _decimalesEnDescRec.ToString()
      txtUHPorc5.Formato = "N" + _decimalesEnDescRec.ToString()


      Me.cmbProvincia.DisplayMember = "NombreProvincia"
      Me.cmbProvincia.ValueMember = "IdProvincia"
      Me.cmbProvincia.DataSource = New Reglas.Provincias().GetAll()
      Me.cmbProvincia.SelectedIndex = -1

      Me._idActividad = DirectCast(Me._entidad, Entidades.Rubro).Actividad.IdActividad

      Me._liSources.Add("Actividad", DirectCast(Me._entidad, Entidades.Rubro).Actividad)

      Me.BindearControles(Me._entidad, Me._liSources)

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
         DirectCast(Me._entidad, Entidades.Rubro).Usuario = actual.Nombre
      Else
         If DirectCast(Me._entidad, Entidades.Rubro).Actividad.IdActividad > 0 Then
            Me.chbAsociaActividad.Checked = True
         End If
      End If
      '-- REQ-30521.- --------------------------------------------
      Me._publicos.CargaComboCategoriasMercadoLibre(Me.cmbCategoriasMercadoLibre)
      Me.cmbCategoriasMercadoLibre.Enabled = False
      '-----------------------------------------------------------

      Me._estaCargando = False
      tbcDetalle.SelectedTab = tbpComisionPorDesCuento
      _titRubroComisDesRec = GetColumnasVisiblesGrilla(ugDetalle)
      tbcDetalle.SelectedTab = tbpDatos

      Me._EntRubroComisDesRec = DirectCast(Me._entidad, Entidades.Rubro).RubroComisionPorDescuento
      Me.ugDetalle.DataSource = Me._EntRubroComisDesRec

      FormateaGrilla()

      '-- REQ-30521.- --
      If DirectCast(_entidad, Entidades.Rubro).IdRubroMercadoLibre IsNot Nothing Then
         Me.cmbCategoriasMercadoLibre.SelectedValue = DirectCast(_entidad, Entidades.Rubro).IdRubroMercadoLibre
         Me.chbCategoriasMercadoLibre.Checked = True
      End If

   End Sub
   Private Sub FormateaGrilla()
      AjustarColumnasGrilla(ugDetalle, _titRubroComisDesRec)
   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.Rubros()
   End Function

   Protected Overrides Sub Aceptar()
      Me.IdRubro = Me.txtIdRubro.Text
      '-- REQ-30521.- ---------------------------------------------------------------
      If cmbCategoriasMercadoLibre.SelectedIndex <> -1 Then
         DirectCast(Me._entidad, Entidades.Rubro).idCategoriaMercadoLibre = cmbCategoriasMercadoLibre.SelectedValue.ToString()
         Me.chbCategoriasMercadoLibre.Checked = True
      Else
         DirectCast(Me._entidad, Entidades.Rubro).idCategoriaMercadoLibre = Nothing
         Me.chbCategoriasMercadoLibre.Checked = False
      End If
      '------------------------------------------------------------------------------
      MyBase.Aceptar()
   End Sub
   Protected Overrides Function ValidarDetalle() As String

      If Me.chbAsociaActividad.Checked Then
         If Me.cmbProvincia.SelectedIndex = -1 Then
            Me.cmbProvincia.Focus()
            Return "No selecciono la Provincia."
         End If
         If Me.cmbActividad.SelectedIndex = -1 Then
            Me.cmbActividad.Focus()
            Return "No selecciono la Actividad."
         End If
      End If
      If Decimal.Parse(Me.txtUnidHasta1.Text) <> 0 And Decimal.Parse(Me.txtUHPorc1.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta2.Text) <> 0 And Decimal.Parse(Me.txtUHPorc2.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta3.Text) <> 0 And Decimal.Parse(Me.txtUHPorc3.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta4.Text) <> 0 And Decimal.Parse(Me.txtUHPorc4.Text) = 0 Or
         Decimal.Parse(Me.txtUnidHasta5.Text) <> 0 And Decimal.Parse(Me.txtUHPorc5.Text) = 0 Then
         Return "El porcentaje no puede ser 0 si ingreso la cantidad"
      End If
      If Decimal.Parse(Me.txtUHPorc1.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc2.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc3.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc4.Text) > 0 Or
         Decimal.Parse(Me.txtUHPorc5.Text) > 0 Then
         If Decimal.Parse(Me.txtUHPorc1.Text) > 0 Then
            Me.txtUHPorc1.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc2.Text) > 0 Then
            Me.txtUHPorc2.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc3.Text) > 0 Then
            Me.txtUHPorc3.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc4.Text) > 0 Then
            Me.txtUHPorc4.Focus()
         End If
         If Decimal.Parse(Me.txtUHPorc5.Text) > 0 Then
            Me.txtUHPorc5.Focus()
         End If
         Return "El porcentaje debe ser negativo"
      End If
      If Decimal.Parse(Me.txtUnidHasta2.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta2.Text) <= Decimal.Parse(Me.txtUnidHasta1.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If
      If Decimal.Parse(Me.txtUnidHasta3.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta3.Text) <= Decimal.Parse(Me.txtUnidHasta2.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If
      If Decimal.Parse(Me.txtUnidHasta4.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta4.Text) <= Decimal.Parse(Me.txtUnidHasta3.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If
      If Decimal.Parse(Me.txtUnidHasta5.Text) <> 0 Then
         If Decimal.Parse(Me.txtUnidHasta5.Text) <= Decimal.Parse(Me.txtUnidHasta4.Text) Then
            Return "Las cantidades de bonificaciones por volumen deben ir en orden."
         End If
      End If
      If Decimal.Parse(Me.txtDescuentoRecargo1.Text) <= -100 Or Decimal.Parse(Me.txtDescuentoRecargo1.Text) >= 100 Then
         txtDescuentoRecargo1.Focus()
         Return "El Descuento/Recargo 1 NO es Válido."
      End If
      If Decimal.Parse(Me.txtDescuentoRecargo2.Text) <= -100 Or Decimal.Parse(Me.txtDescuentoRecargo2.Text) >= 100 Then
         txtDescuentoRecargo2.Focus()
         Return "El Descuento/Recargo 2 NO es Válido."
      End If
      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

      If Not Me.HayError Then Me.Close()
      Me.txtIdRubro.Focus()
   End Sub

   Private Sub chbAsociaActividad_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chbAsociaActividad.CheckedChanged
      Me.cmbProvincia.Enabled = Me.chbAsociaActividad.Checked
      Me.cmbActividad.Enabled = Me.chbAsociaActividad.Checked

      If Not Me._estaCargando Then
         If Me.chbAsociaActividad.Checked Then
            Me.cmbProvincia.SelectedValue = New Reglas.Localidades().GetUna(Publicos.LocalidadEmpresa).IdProvincia
            Me.cmbActividad.Focus()
         Else
            Me.cmbProvincia.SelectedIndex = -1
            Me.cmbActividad.SelectedIndex = -1

            DirectCast(Me._entidad, Entidades.Rubro).Actividad.IdProvincia = String.Empty
            DirectCast(Me._entidad, Entidades.Rubro).Actividad.IdActividad = 0

         End If
      End If
   End Sub

   Private Sub cmbProvincia_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbProvincia.SelectedIndexChanged

      Try

         If Me.cmbProvincia.SelectedIndex >= 0 Then
            Dim act As Reglas.Actividades = New Reglas.Actividades()

            Me.cmbActividad.DisplayMember = "NombreActividad"
            Me.cmbActividad.ValueMember = "IdActividad"
            Me.cmbActividad.DataSource = act.GetPorProvincia(Me.cmbProvincia.SelectedValue.ToString())
         End If

         If Not Me._estaCargando Or Me.cmbProvincia.SelectedIndex = -1 Then
            Me.cmbActividad.SelectedIndex = -1
         ElseIf Me._estaCargando And Me.cmbProvincia.SelectedIndex > -1 Then
            'Se pierde la posicion al cargarse la pantalla
            Me.cmbActividad.SelectedValue = Me._idActividad 'DirectCast(Me._entidad, Entidades.Rubro).Actividad.IdActividad
         End If

      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try

   End Sub

   Private Sub btnRefrescarDescRec_Click(sender As Object, e As EventArgs) Handles btnRefrescarDescRec.Click
      Try
         RefrescaDescRec()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub btnInsertarRubroComsion_Click(sender As Object, e As EventArgs) Handles btnInsertarRubroComsion.Click
      Try
         If Me.ValidarDescRec() Then
            Me.InsertarDescRec()
            RefrescaDescRec()
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub
   Private Sub btnEliminarRubroComsion_Click(sender As Object, e As EventArgs) Handles btnEliminarRubroComsion.Click
      Try
         Dim entRubroComisDesRec As Entidades.RubroComisionPorDescuento = GetRubroComicDescRec()
         If entRubroComisDesRec IsNot Nothing Then
            _EntRubroComisDesRec.Remove(entRubroComisDesRec)
            Me.ugDetalle.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
         End If
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
   Private Sub ugDetalle_DoubleClickRow(sender As Object, e As DoubleClickRowEventArgs) Handles ugDetalle.DoubleClickRow
      Try
         Dim row As Entidades.RubroComisionPorDescuento = GetRubroComicDescRec()
         If row IsNot Nothing Then
            If Not String.IsNullOrWhiteSpace(row.IdRubro.ToString()) Then
               Me.txtDesRecHasta.Text = row.DescuentoRecargoHasta.ToString()
               Me.txtComisionDescRec.Text = row.Comision.ToString()
               _EntRubroComisDesRec.Remove(row)
               Me.ugDetalle.Rows.Refresh(UltraWinGrid.RefreshRow.ReloadData)
               txtDesRecHasta.Focus()
            End If
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

   Private Sub txtDesRecHasta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDesRecHasta.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub txtComisonDescRec_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtComisionDescRec.KeyPress
      PresionarTab(e)
   End Sub

   Private Sub btnInsertarRubroComsion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles btnInsertarRubroComsion.KeyPress
      PresionarTab(e)
   End Sub
#End Region

#Region "Metodos"
   Private Sub CargarProximoNumero()
      Dim oRubro As Reglas.Rubros = New Reglas.Rubros()
      Me.txtIdRubro.Text = (oRubro.GetCodigoMaximo() + 1).ToString()
      Me.txtOrden.Text = (oRubro.GetOrdenMaximo() + 1).ToString()
   End Sub

   Private Sub RefrescaDescRec()
      Me.txtComisionDescRec.Text = "0.00"
      Me.txtDesRecHasta.Text = "0.00"
      Me.txtDesRecHasta.Focus()
   End Sub


   Private Function ValidarDescRec() As Boolean
      If Decimal.Parse(Me.txtDesRecHasta.Text) >= 0 Then
         MessageBox.Show("Debe ingresar un valor Negativo para el porcentaje de Descuento", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDesRecHasta.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtDesRecHasta.Text) <= -100 Then
         MessageBox.Show("El valor del  Descuento no puede superar a -100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtDesRecHasta.Focus()
         Return False
      End If
      If Decimal.Parse(Me.txtComisionDescRec.Text) <= 0 Then
         MessageBox.Show("La Comisión debe ser mayor a 0", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtComisionDescRec.Focus()
         Return False
      End If

      If Decimal.Parse(Me.txtComisionDescRec.Text) >= 100 Then
         MessageBox.Show("El valor de la Comisión no debe ser mayor a 100", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Me.txtComisionDescRec.Focus()
         Return False
      End If
      For Each ent As Entidades.RubroComisionPorDescuento In _EntRubroComisDesRec
         If (ent.DescuentoRecargoHasta = Decimal.Parse(Me.txtDesRecHasta.Text)) Then
            MessageBox.Show("Existe un Descuento Hasta  con el mismo valor a ingresar", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
         End If
      Next
      Return True
   End Function
   Private Sub InsertarDescRec()

      Dim entRubroComisDesRec As Entidades.RubroComisionPorDescuento = New Entidades.RubroComisionPorDescuento()
      With entRubroComisDesRec
         .IdRubro = Integer.Parse(Me.txtIdRubro.Text)
         .DescuentoRecargoHasta = Decimal.Parse(Me.txtDesRecHasta.Text)
         .Comision = Decimal.Parse(Me.txtComisionDescRec.Text)
      End With
      Me._EntRubroComisDesRec.Add(entRubroComisDesRec)
      Me.ugDetalle.Rows.Refresh(RefreshRow.ReloadData)

   End Sub


   Private Function GetRubroComicDescRec() As Entidades.RubroComisionPorDescuento
      Return ugDetalle.FilaSeleccionada(Of Entidades.RubroComisionPorDescuento)()
   End Function

   Private Sub chbCategoriasMercadoLibre_CheckedChanged(sender As Object, e As EventArgs) Handles chbCategoriasMercadoLibre.CheckedChanged
      cmbCategoriasMercadoLibre.Enabled = chbCategoriasMercadoLibre.Checked
   End Sub

#End Region

End Class
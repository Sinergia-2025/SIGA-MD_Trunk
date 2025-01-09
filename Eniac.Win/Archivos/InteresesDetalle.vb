Public Class InteresesDetalle

   Private _publicos As Publicos

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Eniac.Entidades.Interes)
      InitializeComponent()
      _entidad = entidad
   End Sub
#End Region

   Private _tit As Dictionary(Of String, String)

   Public ReadOnly Property Interes() As Entidades.Interes
      Get
         Return DirectCast(_entidad, Entidades.Interes)
      End Get
   End Property


#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbInteresesMetodoParaDeterminarRango, GetType(Entidades.InteresesMetodoParaDeterminarRangoEnum), True, True)

         BindearControles(_entidad, _liSources)

         _tit = GetColumnasVisiblesGrilla(ugDias)

         ugDias.DataSource = Interes.InteresesDias
         AjustarColumnasGrilla(ugDias, _tit)

         Dim eInt = New Entidades.Interes()
         If StateForm = Win.StateForm.Insertar Then
            CargarProximoNumero()
            dtpFechaVigenciaDesde.Value = Date.Today
            dtpFechaVigenciaHasta.Value = Date.Today
         End If
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Intereses()
   End Function

   Protected Overrides Function ValidarDetalle() As String

      MyBase.ValidarDetalle()

      If txtIdInteres.Text.Trim() = "0" Then
         txtIdInteres.Focus()
         Return "No puede poner el codigo 0."
      End If

      If Interes.InteresesDias.Count = 0 Then
         If ShowPregunta("¿Desea grabar la tabla de intereses sin días?") = DialogResult.No Then
            txtDiasDesde.Focus()
            Return "Debe ingresar días. Por favor reintente."
         End If
      End If

      If dtpFechaVigenciaDesde.Value.Date > dtpFechaVigenciaHasta.Value.Date Then
         dtpFechaVigenciaDesde.Focus()
         Return "La Fecha Vigencia Desde no puede ser mayor a la Fecha Vigencia Hasta"
      End If

      Return String.Empty
   End Function
   Protected Overrides Function ProcessCmdKey(ByRef msg As Message, keyData As Keys) As Boolean
      If keyData = Keys.F4 Then
         btnAceptar.PerformClick()
      Else
         Return MyBase.ProcessCmdKey(msg, keyData)
      End If
      Return True
   End Function
#End Region

#Region "Eventos"

   'Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
   '   If Not Me.HayError Then Me.Close()
   '   Me.txtNombreInteres.Focus()
   'End Sub
   Private Sub btnInsertar_Click(sender As Object, e As EventArgs) Handles btnInsertar.Click
      TryCatched(Sub() AgregarLinea())
   End Sub
   Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
      TryCatched(Sub() EliminarLinea())
   End Sub
   Private Sub txtIdInteres_KeyDown(sender As Object, e As KeyEventArgs) Handles txtIdInteres.KeyDown, txtNombreInteres.KeyDown, txtInteresAdicional.KeyDown, txtDiasDesde.KeyDown, txtDiasHasta.KeyDown
      PresionarTab(e)
   End Sub

   Private Sub txtInteres_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInteres.KeyDown
      TryCatched(
      Sub()
         If e.KeyCode = Keys.Enter Then
            AgregarLinea()
         End If
      End Sub)
   End Sub

   Private Sub chbUtilizaVigencia_CheckedChanged_1(sender As Object, e As EventArgs) Handles chbUtilizaVigencia.CheckedChanged, chbVencimientoExcluyeFeriados.CheckedChanged, chbVencimientoExcluyeDomingo.CheckedChanged, chbVencimientoExcluyeSabado.CheckedChanged
      TryCatched(
      Sub()
         If chbUtilizaVigencia.Checked Then
            dtpFechaVigenciaDesde.Enabled = True
            dtpFechaVigenciaHasta.Enabled = True
            Interes.FechaVigenciaDesde = dtpFechaVigenciaDesde.Value
            Interes.FechaVigenciaHasta = dtpFechaVigenciaHasta.Value
         Else
            dtpFechaVigenciaDesde.Enabled = False
            dtpFechaVigenciaHasta.Enabled = False
         End If
      End Sub)
   End Sub

   Private Sub dtpFechaVigenciaDesde_Leave(sender As Object, e As EventArgs) Handles dtpFechaVigenciaDesde.Leave, dtpFechaVigenciaHasta.Leave
      TryCatched(
      Sub()
         Interes.FechaVigenciaDesde = dtpFechaVigenciaDesde.Value
         Interes.FechaVigenciaHasta = dtpFechaVigenciaHasta.Value
      End Sub)
   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub AgregarLinea()
      If ValidaLinea() Then
         Dim intDias = New Entidades.InteresDias With {
            .IdInteres = txtIdInteres.ValorNumericoPorDefecto(0I),
            .DiasDesde = txtDiasDesde.ValorNumericoPorDefecto(0I),
            .DiasHasta = txtDiasHasta.ValorNumericoPorDefecto(0I),
            .Interes = txtInteres.ValorNumericoPorDefecto(0D)
         }

         Interes.InteresesDias.Add(intDias)
         LimpiaLinea()

         ugDias.DataBind()
         txtDiasDesde.Focus()
      End If
   End Sub

   Private Sub LimpiaLinea()
      txtDiasDesde.Text = "0"
      txtDiasHasta.Text = "0"
      txtInteres.Text = "0.00"
   End Sub

   Private Function ValidaLinea() As Boolean
      If txtDiasDesde.ValorNumericoPorDefecto(0I) = 0 Then
         txtDiasDesde.Focus()
         Throw New Exception("Desde no puede ser igual a cero (0).")
      End If

      If txtDiasHasta.ValorNumericoPorDefecto(0I) = 0 Then
         txtDiasHasta.Focus()
         Throw New Exception("Hasta no puede ser igual a cero (0).")
      End If

      If txtDiasDesde.ValorNumericoPorDefecto(0I) > txtDiasHasta.ValorNumericoPorDefecto(0I) Then
         txtDiasHasta.Focus()
         Throw New Exception("Días Desde no puede ser mayor a Días Hasta.")
      End If

      For Each intDias In Interes.InteresesDias
         If intDias.DiasDesde = txtDiasDesde.ValorNumericoPorDefecto(0I) And intDias.DiasHasta = txtDiasHasta.ValorNumericoPorDefecto(0I) Then
            txtDiasHasta.Focus()
            Throw New Exception("Ya existe una combinación con los mismos días Desde y Hasta.")
         End If
      Next
      Return True
   End Function
   Private Sub EliminarLinea()
      Dim dr = ugDias.FilaSeleccionada(Of Entidades.InteresDias)()
      If dr IsNot Nothing Then
         If ShowPregunta("¿Desea eliminar los intereses para el rango de días seleccionado?") = DialogResult.Yes Then
            Interes.InteresesDias.Remove(dr)
            ugDias.DataBind()
         End If
      End If
   End Sub
   Private Sub CargarProximoNumero()
      txtIdInteres.Text = (New Reglas.Intereses().GetCodigoMaximo() + 1).ToString("####0")
   End Sub
#End Region

End Class
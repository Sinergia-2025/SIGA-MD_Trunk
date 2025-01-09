Public Class ImpuestosDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private ReadOnly Property Impuesto As Entidades.Impuesto
      Get
         Return DirectCast(_entidad, Entidades.Impuesto)
      End Get
   End Property
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.Impuesto)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      _publicos = New Publicos()
      _publicos.CargaComboTiposImpuestos(cmbTipoImpuesto, "TODOS")
      _publicos.CargaComboTiposImpuestos(cmbTipoImpuestoPIVA, Entidades.TipoImpuesto.Tipos.PIVA)

      BindearControles(_entidad)

      If StateForm = Win.StateForm.Insertar Then
         chbEstado.Checked = True
         If Reglas.Publicos.TieneModuloContabilidad Then
            UcCuentasCompras.Cuenta = Nothing
            UcCuentasVentas.Cuenta = Nothing
         Else
            UcCuentasCompras.Visible = False
            UcCuentasVentas.Visible = False
         End If
      Else
         If Reglas.Publicos.TieneModuloContabilidad Then
            UcCuentasCompras.Cuenta = Impuesto.CuentaCompras
            UcCuentasVentas.Cuenta = Impuesto.CuentaVentas
         Else
            UcCuentasCompras.Visible = False
            UcCuentasVentas.Visible = False
         End If
      End If

      grpPIVA.Enabled = cmbTipoImpuesto.ValorSeleccionado(Of String) = Entidades.TipoImpuesto.Tipos.IVA.ToString()
      chbPIVA.Checked = Not String.IsNullOrWhiteSpace(Impuesto.IdTipoImpuestoPIVA) AndAlso Impuesto.AlicuotaPIVA.HasValue

   End Sub
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Impuestos
   End Function

   Protected Overrides Sub Aceptar()
      If Reglas.Publicos.TieneModuloContabilidad Then
         Impuesto.CuentaCompras = UcCuentasCompras.Cuenta
         Impuesto.CuentaVentas = UcCuentasVentas.Cuenta
      Else
         Impuesto.CuentaCompras = Nothing
         Impuesto.CuentaVentas = Nothing
      End If

      Impuesto.PIVAAgregarSiNoExiste = False
      If grpPIVA.Enabled And chbPIVA.Checked Then
         If cmbTipoImpuestoPIVA.SelectedIndex < 0 Then
            Throw New Exception("No ha seleccionado Tipo de Impuesto para Percepción de IVA")
         End If
         If Not New Reglas.Impuestos().Existe(cmbTipoImpuestoPIVA.ValorSeleccionado(Of String),
                                              txtDescripcionPIVA.ValorNumericoPorDefecto(0D)) Then
            If ShowPregunta(String.Format("El impuesto tipo {1} con alicuota de {2} no existe.{0}{0}¿Desea crearlo?", Environment.NewLine,
                                          cmbTipoImpuestoPIVA.ValorSeleccionado(Of String),
                                          txtDescripcionPIVA.ValorNumericoPorDefecto(0D))) = DialogResult.No Then
               HayError = True
               Exit Sub
            End If
            Impuesto.PIVAAgregarSiNoExiste = True
         End If
      Else
         Impuesto.IdTipoImpuestoPIVA = String.Empty
         Impuesto.AlicuotaPIVA = Nothing
      End If

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      cmbTipoImpuesto.Focus()
   End Sub

   Private Sub chbPIVA_CheckedChanged(sender As Object, e As EventArgs) Handles chbPIVA.CheckedChanged
      TryCatched(
      Sub()
         cmbTipoImpuestoPIVA.Enabled = chbPIVA.Checked
         txtDescripcionPIVA.Enabled = chbPIVA.Checked
      End Sub)
   End Sub

#End Region

End Class
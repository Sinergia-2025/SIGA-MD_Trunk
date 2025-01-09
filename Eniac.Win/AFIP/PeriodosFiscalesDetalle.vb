Public Class PeriodosFiscalesDetalle

#Region "Campos"
   Private _estaCargando As Boolean = True
#End Region

   Private ReadOnly Property Periodo As Entidades.PeriodoFiscal
      Get
         Return DirectCast(_entidad, Entidades.PeriodoFiscal)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.PeriodoFiscal)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         BindearControles(_entidad)

         _estaCargando = False

         If StateForm = Eniac.Win.StateForm.Insertar Then
            CargarProximoPeriodo()

         Else
            dtpPeriodo.Value = Periodo.PeriodoFiscal.FromPeriodo()
            If Not String.IsNullOrEmpty(Periodo.UsuarioCierre) Then
               chbCierre.Checked = True
            End If

         End If
      End Sub)
   End Sub
   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.PeriodosFiscales()
   End Function
   Protected Overrides Sub Aceptar()
      Periodo.PeriodoFiscal = dtpPeriodo.Value.ToPeriodo()

      If chbCierre.Checked Then
         Periodo.FechaCierre = dtpFechaCierre.Value
      End If

      MyBase.Aceptar()
   End Sub

#End Region

#Region "Eventos"

   Private Sub dtpPeriodo_ValueChanged(sender As Object, e As EventArgs) Handles dtpPeriodo.ValueChanged
      TryCatched(Sub() dtpPeriodo.Value = dtpPeriodo.Value.PrimerDiaMes())
   End Sub
   Private Sub chbCierre_CheckedChanged(sender As Object, e As EventArgs) Handles chbCierre.CheckedChanged
      If _estaCargando Then Exit Sub

      If chbCierre.Checked Then
         txtUsuarioCierre.Text = actual.Nombre

      Else
         dtpFechaCierre.Value = Date.Now
         txtUsuarioCierre.Text = String.Empty
         Periodo.FechaCierre = Nothing
         Periodo.UsuarioCierre = Nothing
      End If

      dtpFechaCierre.Enabled = chbCierre.Checked
   End Sub
   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      dtpPeriodo.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoPeriodo()
      Dim oPF = New Reglas.PeriodosFiscales()
      Dim PF = oPF.GetPeriodoMaximo(actual.Sucursal.IdEmpresa)
      If PF = 0 Then
         dtpPeriodo.Value = Date.Today.PrimerDiaMes()
      Else
         dtpPeriodo.Value = PF.FromPeriodo().AddMonths(1)
      End If
   End Sub

#End Region

End Class
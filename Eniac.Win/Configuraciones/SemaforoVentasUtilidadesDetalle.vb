Public Class SemaforoVentasUtilidadesDetalle

#Region "Campos"

   Private _publicos As Publicos

#End Region

   Public Enum TiposColores
      FORECOLOR
      BACKCOLOR
   End Enum

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.SemaforoVentaUtilidad)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      '# Combos
      Me._publicos.CargaComboDesdeEnum(Me.cmbTipoSemaforo, GetType(Entidades.SemaforoVentaUtilidad.TiposSemaforos))

      Me.BindearControles(Me._entidad)

      DirectCast(Me._entidad, Entidades.SemaforoVentaUtilidad).Usuario = actual.Nombre

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         Me.CargarProximoNumero()
      Else
         Me.txtColorSemadoro.BackColor = Color.FromArgb(DirectCast(Me._entidad, Entidades.SemaforoVentaUtilidad).ColorSemaforo)
         Me.txtColorSemaforoLetra.BackColor = Color.FromArgb(DirectCast(Me._entidad, Entidades.SemaforoVentaUtilidad).ColorLetra)
      End If

      Me.SetearEjemplo()

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.SemaforoVentasUtilidades
   End Function

   Protected Overrides Function ValidarDetalle() As String

      'Dim vacio As String = ""

      If Decimal.Parse(Me.txtPorcentajeHasta.Text) = 0 Then
         Me.txtPorcentajeHasta.Focus()
         Return "El Campo Hasta es Requerido."
      End If


      If Me.txtColorSemadoro.Key = "0" Then
         Me.txtColorSemadoro.Focus()
         Return "El Campo Color es Requerido."
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As System.Object, e As System.EventArgs) Handles btnAceptar.Click
      If Me.StateForm = Eniac.Win.StateForm.Insertar And Not Me.HayError Then
         Me.Close()
      End If
      Me.txtIdSemaforo.Focus()
   End Sub

   Private Sub btnColorSemadoro_Click(sender As System.Object, e As System.EventArgs) Handles btnColorSemadoro.Click
      Try
         Me.CargarPaleta(TiposColores.BACKCOLOR)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub btnPaletaColorLetra_Click(sender As Object, e As EventArgs) Handles btnPaletaColorLetra.Click
      Try
         Me.CargarPaleta(TiposColores.FORECOLOR)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
#End Region

#Region "Metodos"

   Private Sub SetearEjemplo()

      Me.txtEjemplo.BackColor = Me.txtColorSemadoro.BackColor
      Me.txtEjemplo.ForeColor = Me.txtColorSemaforoLetra.BackColor
      If Me.chbNegrita.Checked Then
         Me.txtEjemplo.Font = New Font(txtEjemplo.Font, FontStyle.Bold)
      Else
         Me.txtEjemplo.Font = New Font(txtEjemplo.Font, FontStyle.Regular)
      End If

   End Sub

   Private Sub CargarProximoNumero()
      Dim oSemaforos As Reglas.SemaforoVentasUtilidades = New Reglas.SemaforoVentasUtilidades()
      Me.txtIdSemaforo.Text = (oSemaforos.GetCodigoMaximo() + 1).ToString()
   End Sub

   Private Sub CargarPaleta(tipoColor As TiposColores)

      If tipoColor = TiposColores.BACKCOLOR Then
         Me.ColorDialog1.Color = Me.txtColorSemadoro.BackColor
         If Me.ColorDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColorSemadoro.Key = Me.ColorDialog1.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.SemaforoVentaUtilidad).ColorSemaforo = Me.ColorDialog1.Color.ToArgb()
            Me.txtColorSemadoro.BackColor = Me.ColorDialog1.Color
         End If
      Else '# FORECOLOR
         Me.ColorDialog2.Color = Me.txtColorSemaforoLetra.BackColor
         If Me.ColorDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.txtColorSemaforoLetra.Key = Me.ColorDialog2.Color.ToArgb().ToString()
            DirectCast(Me._entidad, Entidades.SemaforoVentaUtilidad).ColorLetra = Me.ColorDialog2.Color.ToArgb()
            Me.txtColorSemaforoLetra.BackColor = Me.ColorDialog2.Color
         End If
      End If

      Me.SetearEjemplo()

   End Sub
#End Region

   Private Sub chbNegrita_CheckedChanged(sender As Object, e As EventArgs) Handles chbNegrita.CheckedChanged
      Try
         Me.SetearEjemplo()
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub
End Class

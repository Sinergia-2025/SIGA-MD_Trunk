Public Class CategoriasFiscalesDetalle

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CategoriaFiscal)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      TryCatched(
      Sub()
         _publicos = New Publicos()

         '-- REQ-34587.- -----------------------------------------
         _publicos.CargaComboDesdeEnum(cmbIvaCero, GetType(Entidades.Publicos.FormatoIvaCero),, True)
         '--------------------------------------------------------

         BindearControles(_entidad)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            chbActivo.Checked = True
            '-- REQ-34587.- -----------------------------------------
            cmbIvaCero.SelectedIndex = 0
            '--------------------------------------------------------
            CargarProximoNumero()
            txtIdCategoriaFiscal.Focus()
         End If

         chbUtilizaAlicuota2Producto.Enabled = Reglas.Publicos.ProductoUtilizaAlicuota2
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.CategoriasFiscales
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      If Not HayError Then Close()
      'If Me.StateForm = Eniac.Win.StateForm.Insertar Then
      '   Me.CargarValoresIniciales()
      'End If
      txtIdCategoriaFiscal.Focus()
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarProximoNumero()
      Dim rCF = New Reglas.CategoriasFiscales()
      txtIdCategoriaFiscal.Text = (rCF.GetCodigoMaximo() + 1).ToString("####0")
   End Sub

#End Region

End Class
Option Explicit On
Option Strict On
Public Class AFIPTiposComprobantesDetalle

#Region "Campos"
   Private _publicos As Publicos
   Private _estaCargando As Boolean = True
#End Region

   Private ReadOnly Property AFIPTipoComprobante() As Entidades.AFIPTipoComprobante
      Get
         Return DirectCast(_entidad, Entidades.AFIPTipoComprobante)
      End Get
   End Property

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Entidades.AFIPTipoComprobante)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      Me._publicos = New Publicos()

      _publicos.CargaComboDesdeEnum(cmbIncluyeFechaVencimiento, GetType(Entidades.Publicos.SiNoDefault))
      _publicos.CargaComboAFIPTipoDocumento(cmbTipoDocumento)

      Me.BindearControles(Me._entidad)

      Me._estaCargando = False

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then
         'Me.txtAFIPTiposComprobantes.Focus()
      End If

      If AFIPTipoComprobante.IncluyeFechaVencimiento.HasValue Then
         If AFIPTipoComprobante.IncluyeFechaVencimiento.Value Then
            cmbIncluyeFechaVencimiento.SelectedValue = Entidades.Publicos.SiNoDefault.SI
         Else
            cmbIncluyeFechaVencimiento.SelectedValue = Entidades.Publicos.SiNoDefault.NO
         End If
      Else
         cmbIncluyeFechaVencimiento.SelectedValue = Entidades.Publicos.SiNoDefault.DEFAULT
      End If

      chbTipoDocumento.Checked = AFIPTipoComprobante.IdAFIPTipoDocumento.HasValue
      If AFIPTipoComprobante.IdAFIPTipoDocumento.HasValue Then
         cmbTipoDocumento.SelectedValue = AFIPTipoComprobante.IdAFIPTipoDocumento.Value
      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.AFIPTiposComprobantes()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      If chbTipoDocumento.Checked AndAlso cmbTipoDocumento.SelectedIndex = -1 Then
         cmbTipoDocumento.Focus()
         Return "Debe seleccionar un Tipo de Documento."
      End If
      Return MyBase.ValidarDetalle()
   End Function

   Protected Overrides Sub Aceptar()
      If cmbTipoDocumento.SelectedIndex > -1 Then
         AFIPTipoComprobante.IdAFIPTipoDocumento = Integer.Parse(cmbTipoDocumento.SelectedValue.ToString())
      Else
         AFIPTipoComprobante.IdAFIPTipoDocumento = Nothing
      End If

      If DirectCast(cmbIncluyeFechaVencimiento.SelectedValue, Entidades.Publicos.SiNoDefault) = Entidades.Publicos.SiNoDefault.DEFAULT Then
         AFIPTipoComprobante.IncluyeFechaVencimiento = Nothing
      Else
         AFIPTipoComprobante.IncluyeFechaVencimiento = DirectCast(cmbIncluyeFechaVencimiento.SelectedValue, Entidades.Publicos.SiNoDefault) = Entidades.Publicos.SiNoDefault.SI
      End If

      MyBase.Aceptar()
   End Sub

#End Region

   Private Sub chbTipoDocumento_CheckedChanged(sender As Object, e As EventArgs) Handles chbTipoDocumento.CheckedChanged
      cmbTipoDocumento.Enabled = chbTipoDocumento.Checked
      If Not chbTipoDocumento.Checked Then
         cmbTipoDocumento.SelectedIndex = -1
      End If
   End Sub
End Class
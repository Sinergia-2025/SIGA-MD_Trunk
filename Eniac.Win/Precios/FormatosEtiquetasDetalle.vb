Option Strict On
Option Explicit On
Imports System.Drawing.Printing
Public Class FormatosEtiquetasDetalle
   Private _publicos As Publicos

   Public ReadOnly Property FormatoEtiqueta As Entidades.FormatoEtiqueta
      Get
         Return DirectCast(_entidad, Entidades.FormatoEtiqueta)
      End Get
   End Property

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(ByVal entidad As Eniac.Entidades.FormatoEtiqueta)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub
#End Region


   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      Try
         _publicos = New Publicos()

         _publicos.CargaComboDesdeEnum(cmbTipo, GetType(Entidades.FormatoEtiqueta.Tipos))

         CargarImpresorasInstaladas()

         Me.BindearControles(Me._entidad, Me._liSources)

         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            txtIdFormatoEtiqueta.Text = (DirectCast(GetReglas(), Reglas.FormatosEtiquetas).GetCodigoMaximo() + 1).ToString()
            chbActivo.Checked = True
         Else

         End If

      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.FormatosEtiquetas()
   End Function

   Protected Overrides Function ValidarDetalle() As String
      Return MyBase.ValidarDetalle()
   End Function

   Private Sub CargarImpresorasInstaladas()
      'agrego una impresora vacia
      Me.cmbNombreImpresora.Items.Add("")

      For i As Integer = 0 To PrinterSettings.InstalledPrinters.Count - 1
         Me.cmbNombreImpresora.Items.Add(PrinterSettings.InstalledPrinters.Item(i))
      Next

   End Sub


End Class
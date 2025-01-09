#Region "Option"
Option Strict Off
Option Explicit On

Imports System.Drawing.Printing

#End Region
Public Class ImpresorasAComprobantesDetalle

#Region "Campos"
   Private _publicos As Publicos
#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
      Me._entidad = New Entidades.TipoComprobanteLetra
   End Sub

   Public Sub New(ByVal entidad As Entidades.TipoComprobanteLetra)
      Me.InitializeComponent()
      Me._entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)

      MyBase.OnLoad(e)

      '# Carga inicial de la antigua pantalla
      Me._publicos = New Publicos
      _publicos.CargaComboTiposComprobantes(Me.cmbComprobante, False, "TODOS", "")

      ' # Cargo los combos de Tipos de Impresión Fiscal
      CargarCombosTipoImpresionFiscal()

      Me.BindearControles(Me._entidad)
      Me.CargarImpresorasInstaladas()
      'Me.txtServidor.Text = My.Computer.Name

      '-----------------'-----------------'-----------------

      'Me.cmbImpresora.SelectedValue = DirectCast(_entidad, Entidades.TipoComprobanteLetra).NombreImpresora


      Dim nombreImpresora As String = DirectCast(_entidad, Entidades.TipoComprobanteLetra).NombreImpresora
      If Not String.IsNullOrEmpty(nombreImpresora) Then
         If nombreImpresora.Contains("\\") Then
            Dim Partes As String() = nombreImpresora.Split("\\")
            Me.txtServidor.Text = Partes(2)
            Me.cmbImpresora.SelectedItem = Partes(3)
         Else
            Me.txtServidor.Text = String.Empty
            Me.cmbImpresora.SelectedItem = nombreImpresora
         End If
      Else
         If Me.StateForm = Eniac.Win.StateForm.Insertar Then
            Me.txtServidor.Text = My.Computer.Name
         Else
            Me.txtServidor.Text = String.Empty
         End If
         Me.cmbImpresora.SelectedIndex = Me.cmbImpresora.Items.Count - 1
      End If
      Me.cmbImpresora.Refresh()


      ' # Por defecto los combos inician con el valor seleccionado del parámetro de Tipo Impresión Fiscal de Fact. Electrónica.
      If Me.StateForm = Me.StateForm.Insertar Then

         If Me.cmbTipoImpresionFiscalArchivoAExportar.SelectedIndex = -1 Then
            Me.cmbTipoImpresionFiscalArchivoAExportar.SelectedValue = Reglas.Publicos.TipoImpresionFiscal
         End If
         If Me.cmbTipoImpresionFiscalArchivoAImprimir.SelectedIndex = -1 Then
            Me.cmbTipoImpresionFiscalArchivoAImprimir.SelectedValue = Reglas.Publicos.TipoImpresionFiscal
         End If
         If Me.cmbTipoImpresionFiscalArchivoAImprimirComplementario.SelectedIndex = -1 Then
            Me.cmbTipoImpresionFiscalArchivoAImprimirComplementario.SelectedValue = Reglas.Publicos.TipoImpresionFiscal
         End If
         If Me.cmbTipoImpresionFiscalArchivoAImprimirDolares.SelectedIndex = -1 Then
            Me.cmbTipoImpresionFiscalArchivoAImprimirDolares.SelectedValue = Reglas.Publicos.TipoImpresionFiscal
         End If

      End If

   End Sub

   Protected Overrides Function GetReglas() As Eniac.Reglas.Base
      Return New Reglas.TiposComprobantesLetras()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
      'Reglas.ParametrosCache.Instancia.LimpiarCache(txtParametro.Text)
   End Sub

#End Region

#Region "Métodos"

   Private Sub CargarCombosTipoImpresionFiscal()

      ' # Cargo los combos con los valores
      Me._publicos.CargaComboTiposImpresionesFiscales(Me.cmbTipoImpresionFiscalArchivoAExportar)
      Me._publicos.CargaComboTiposImpresionesFiscales(Me.cmbTipoImpresionFiscalArchivoAImprimir)
      Me._publicos.CargaComboTiposImpresionesFiscales(Me.cmbTipoImpresionFiscalArchivoAImprimirComplementario)
      Me._publicos.CargaComboTiposImpresionesFiscales(Me.cmbTipoImpresionFiscalArchivoAImprimirDolares)

   End Sub

   Private Sub CargarImpresorasInstaladas()
      Dim i As Integer
      Dim pkInstalledPrinters As String

      Dim instance As PrinterSettings = New PrinterSettings()

      For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
         pkInstalledPrinters = PrinterSettings.InstalledPrinters.Item(i)

         Me.cmbImpresora.Items.Add(pkInstalledPrinters)
      Next

      'agrego una impresora vacia
      Me.cmbImpresora.Items.Add("")

   End Sub

#End Region

End Class
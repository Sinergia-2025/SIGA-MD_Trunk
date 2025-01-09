#Region "Option/Imports"
Option Explicit On
Option Strict On
#End Region

Public Class FormatoNombreArchivoExportacion

#Region "Campos"
	Public FormatoNombreArchivo As String = String.Empty
#End Region

#Region "Overrides"
	Protected Overrides Sub OnLoad(e As EventArgs)
		Try
			MyBase.OnLoad(e)
			'-------------------------------------------------------------------------
			txtFormatoArchivoExportacion.Text = FormatoNombreArchivo
			txtFormatoArchivoExportacion.SelectionStart = FormatoNombreArchivo.Length
			'-------------------------------------------------------------------------
		Catch ex As Exception

		End Try
	End Sub
#End Region

#Region "Eventos"
	Private Sub lblArrovaNumero_DoubleClick(sender As Object, e As EventArgs) Handles lblArrovaTipo.DoubleClick,
																												 lblArrovaNumero.DoubleClick,
																												 lblArrovaLetra.DoubleClick,
																												 lblArrovaComprobante.DoubleClick,
																												 lblArrovaCentroEmisor.DoubleClick,
																												 lblArrovaNroReparto.DoubleClick,
																												 lblArrovaNombreEmpresa.DoubleClick, lblArrovaFantasiaEmpresa.DoubleClick, lblArrovaCuitEmpresa.DoubleClick,
																												 lblArrovaNombreCliente.DoubleClick, lblArrovaFantasiaCliente.DoubleClick, lblArrovaCuitCliente.DoubleClick
		CargaTextoFormatoArchivo(DirectCast(sender, Label).Text)
	End Sub
	Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
		FormatoNombreArchivo = txtFormatoArchivoExportacion.Text
		DialogResult = Windows.Forms.DialogResult.OK
		Close()
	End Sub
	Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
		Close()
	End Sub

#End Region

#Region "Metodo"
	''' <summary>
	''' Carga los valores de Formato.- 
	''' </summary>
	Private Sub CargaTextoFormatoArchivo(oVariable As String)
		Dim SelectionStart = txtFormatoArchivoExportacion.SelectionStart
		txtFormatoArchivoExportacion.Text = txtFormatoArchivoExportacion.Text.Insert(SelectionStart, oVariable)
		txtFormatoArchivoExportacion.SelectionStart = SelectionStart + oVariable.Length
	End Sub


#End Region
End Class
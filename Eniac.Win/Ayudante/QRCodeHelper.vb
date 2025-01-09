#Region "Option/Imports"
Option Strict On
Option Explicit On

Imports QRCoder
#End Region
Namespace Ayudante
   Public Class QRCodeHelper
      Public Shared Function GenerarQR(valor As String) As Image
         Return GenerarQR(valor, QRCodeGenerator.ECCLevel.Q, 12, "#000000", "#ffffff")
      End Function
      Private Shared Function GenerarQR(valor As String, eccLevel As QRCodeGenerator.ECCLevel, pixelsPerModule As Integer, darkColorHtmlHex As String, lightColorHtmlHex As String) As Image
         Using qrGenerator As QRCodeGenerator = New QRCodeGenerator()
            Using QRCodeData As QRCodeData = qrGenerator.CreateQrCode(valor, eccLevel)
               Using qrCode As QRCode = New QRCode(QRCodeData)
                  Return qrCode.GetGraphic(pixelsPerModule, darkColorHtmlHex, lightColorHtmlHex)
               End Using
            End Using
         End Using
      End Function
   End Class
End Namespace
#Region "Imports"
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Globalization
#End Region
Namespace Extensiones
   Public Module ImageExtensions

      <Extension()>
      Public Function MimeType(image As Image) As String
         If image Is Nothing Then Return String.Empty
         'Dim codec As ImageCodecInfo = ImageCodecInfo.GetImageDecoders().First(Function(c) c.FormatID = image.RawFormat.Guid)
         Return MimeType(image.RawFormat)
      End Function
      <Extension()>
      Public Function MimeType(format As ImageFormat) As String
         If format Is Nothing Then Return String.Empty
         Dim codec As ImageCodecInfo = ImageCodecInfo.GetImageDecoders().First(Function(c) c.FormatID = format.Guid)
         Return codec.MimeType
      End Function
      <Extension()>
      Public Function ConvertImageToBase64(image As Image) As String
         If image Is Nothing Then Return String.Empty
         Return ConvertImageToBase64(image, image.RawFormat)
      End Function

      <Extension()>
      Public Function ConvertImageToBase64(image As Image, format As ImageFormat) As String
         If image Is Nothing Then Return String.Empty
         Using imageStream As New System.IO.MemoryStream()
            image.Save(imageStream, format)
            Return ConvertImageToBase64(imageStream.ToArray())
         End Using
      End Function

      <Extension()>
      Public Function ConvertImageToBase64(fileBytes As Byte()) As String
         Return Convert.ToBase64String(fileBytes)
      End Function

   End Module
End Namespace
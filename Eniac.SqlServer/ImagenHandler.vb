Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.IO

Public Class ImagenHandler

   Public Class Size
      Public width As Integer
      Public height As Integer

      Sub New(ByVal image As Object)
         width = CType(image, System.Drawing.Image).Width
         height = CType(image, System.Drawing.Image).Height
      End Sub

      Sub New(ByVal w As Integer, ByVal h As Integer)
         width = w
         height = h
      End Sub
   End Class

   Private Function GetEncoder(ByVal format As ImageFormat) As ImageCodecInfo
      Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageDecoders()

      Dim codec As ImageCodecInfo
      For Each codec In codecs
         If codec.FormatID = format.Guid Then
            Return codec
         End If
      Next codec
      Return Nothing
   End Function

   Private Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
      Dim original, resized As Size

      If preserveAspectRatio Then
         original = New Size(image)

         Dim percWidth As Single = CSng(size.width) / CSng(original.width)
         Dim percHeight As Single = CSng(size.height) / CSng(original.height)
         Dim perc As Single = If(percHeight < percWidth, percHeight, percWidth)

         resized = New Size(CInt(original.width * perc), CInt(original.height * perc))
      Else
         resized = New Size(size)
      End If

      Dim newImage As Image = New Bitmap(resized.width, resized.height)

      Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
         graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
         graphicsHandle.DrawImage(image, 0, 0, resized.width, resized.height)
      End Using

      Return newImage
   End Function

   Public Function Guardar(ByVal original As Image, ByVal size As Size, ByVal calidad As Integer) As Byte()
      Using resized As Image = ResizeImage(original, size)
         Dim jpgEncoder As ImageCodecInfo = GetEncoder(ImageFormat.Jpeg)
         Dim myEncoder As System.Drawing.Imaging.Encoder = System.Drawing.Imaging.Encoder.Quality
         Dim myEncoderParameters As New EncoderParameters(1)
         Dim myEncoderParameter As New EncoderParameter(myEncoder, calidad)
         myEncoderParameters.Param(0) = myEncoderParameter

         Using ms As MemoryStream = New MemoryStream()
            Try
               resized.Save(ms, jpgEncoder, myEncoderParameters)
            Catch ex As Exception
               Throw New Exception("Error al guardar la imagen a disco")
            End Try
            Return ms.ToArray()
         End Using
      End Using
   End Function
End Class

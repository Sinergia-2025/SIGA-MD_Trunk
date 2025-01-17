Public Class RTFtoHTML

#Region "Private Members"

   ' A RichTextBox control to use to help with parsing.
   Private _rtfSource As New System.Windows.Forms.RichTextBox

#End Region

#Region "Read/Write Properties"

   ''' <summary>
   ''' Returns/Sets The RTF formatted text to parse
   ''' </summary>
   Public Property rtf() As String
      Get
         Return _rtfSource.Rtf
      End Get
      Set(ByVal value As String)
         _rtfSource.Rtf = value
      End Set
   End Property

#End Region

#Region "ReadOnly Properties"

   ''' <summary>
   ''' Returns the HTML code for the provided RTF
   ''' </summary>
   Public ReadOnly Property html() As String
      Get
         Return GetHtml()
      End Get
   End Property

#End Region

#Region "Private Functions"

   ''' <summary>
   ''' Returns an HTML Formated Color string for the style from a system.drawing.color
   ''' </summary>
   ''' <param name="clr">The color you wish to convert</param>
   Private Function HtmlColorFromColor(ByRef clr As System.Drawing.Color) As String
      Dim strReturn As String = ""
      If clr.IsNamedColor Then
         strReturn = clr.Name.ToLower
      Else
         strReturn = clr.Name
         If strReturn.Length > 6 Then
            strReturn = strReturn.Substring(strReturn.Length - 6, 6)
         End If
         strReturn = "#" & strReturn
      End If
      Return strReturn
   End Function

   ''' <summary>
   ''' Provides the font style per given font
   ''' </summary>
   ''' <param name="fnt">The font you wish to convert</param>
   Private Function HtmlFontStyleFromFont(ByRef fnt As System.Drawing.Font) As String
      Dim strReturn As String = ""
      'style
      If fnt.Italic Then
         strReturn &= "italic "
      Else
         strReturn &= "normal "
      End If
      'variant
      strReturn &= "normal "
      'weight
      If fnt.Bold Then
         strReturn &= "bold "
      Else
         strReturn &= "normal "
      End If
      'size
      strReturn &= fnt.SizeInPoints & "pt/normal "
      'family
      strReturn &= fnt.FontFamily.Name
      Return strReturn
   End Function

   ''' <summary>
   ''' Parses the given rich text and returns the html.
   ''' </summary>
   Private Function GetHtml() As String
      Dim strReturn As String = "<div>"
      Dim clrForeColor As System.Drawing.Color = Color.Black
      Dim clrBackColor As System.Drawing.Color = Color.Black
      Dim fntCurrentFont As System.Drawing.Font = _rtfSource.Font
      Dim altCurrent As System.Windows.Forms.HorizontalAlignment = HorizontalAlignment.Left
      Dim intPos As Integer = 0
      For intPos = 0 To _rtfSource.Text.Length - 1
         _rtfSource.Select(intPos, 1)
         'Forecolor
         If intPos = 0 Then
            strReturn &= "<span style=""color:" & HtmlColorFromColor(_rtfSource.SelectionColor) & """>"
            clrForeColor = _rtfSource.SelectionColor
         Else
            If _rtfSource.SelectionColor <> clrForeColor Then
               strReturn &= "</span>"
               strReturn &= "<span style=""color:" & HtmlColorFromColor(_rtfSource.SelectionColor) & """>"
               clrForeColor = _rtfSource.SelectionColor
            End If
         End If
         'Background color
         If intPos = 0 Then
            strReturn &= "<span style=""background-color:" & HtmlColorFromColor(_rtfSource.SelectionBackColor) & """>"
            clrBackColor = _rtfSource.SelectionBackColor
         Else
            If _rtfSource.SelectionBackColor <> clrBackColor Then
               strReturn &= "</span>"
               strReturn &= "<span style=""background-color:" & HtmlColorFromColor(_rtfSource.SelectionBackColor) & """>"
               clrBackColor = _rtfSource.SelectionBackColor
            End If
         End If
         'Font
         If intPos = 0 Then
            strReturn &= "<span style=""font:" & HtmlFontStyleFromFont(_rtfSource.SelectionFont) & """>"
            fntCurrentFont = _rtfSource.SelectionFont
         Else
            If _rtfSource.SelectionFont.GetHashCode <> fntCurrentFont.GetHashCode Then
               strReturn &= "</span>"
               strReturn &= "<span style=""font:" & HtmlFontStyleFromFont(_rtfSource.SelectionFont) & """>"
               fntCurrentFont = _rtfSource.SelectionFont
            End If
         End If
         'Alignment
         If intPos = 0 Then
            strReturn &= "<p style=""text-align:" & _rtfSource.SelectionAlignment.ToString & """>"
            altCurrent = _rtfSource.SelectionAlignment
         Else
            If _rtfSource.SelectionAlignment <> altCurrent Then
               strReturn &= "</p>"
               strReturn &= "<p style=""text-align:" & _rtfSource.SelectionAlignment.ToString & """>"
               altCurrent = _rtfSource.SelectionAlignment
            End If
         End If
         strReturn &= _rtfSource.Text.Substring(intPos, 1)
      Next
      'close all the spans
      strReturn &= "</span>"
      strReturn &= "</span>"
      strReturn &= "</span>"
      strReturn &= "</p>"
      strReturn &= "</div>"
      strReturn = strReturn.Replace(Convert.ToChar(10), "<br />")
      Return strReturn
   End Function


   Public Function Convertir(ByVal sRTF As String) As String
      Dim MyWord As Microsoft.Office.Interop.Word.Application
      Dim oDoNotSaveChanges As Object = _
           Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges
      Dim sReturnString As String = ""
      Dim sConvertedString As String = ""
      Try
         MyWord = CType(CreateObject("Word.application"), Microsoft.Office.Interop.Word.Application)
         MyWord.Visible = False
         MyWord.Documents.Add()
         Dim doRTF As New System.Windows.Forms.DataObject
         doRTF.SetData("Rich Text Format", sRTF)
         Clipboard.SetDataObject(doRTF)
         MyWord.Windows(1).Selection.Paste()
         MyWord.Windows(1).Selection.WholeStory()
         MyWord.Windows(1).Selection.Copy()
         sConvertedString = _
              CStr(Clipboard.GetData(System.Windows.Forms.DataFormats.Html))
         sConvertedString = _
              sConvertedString.Substring(sConvertedString.IndexOf("<html"))
         sConvertedString = sConvertedString.Replace("Â", "")
         sReturnString = sConvertedString
         If Not MyWord Is Nothing Then
            MyWord.Quit(oDoNotSaveChanges)
            MyWord = Nothing
         End If
      Catch ex As Exception
         If Not MyWord Is Nothing Then
            MyWord.Quit(oDoNotSaveChanges)
            MyWord = Nothing
         End If
         MsgBox("Error converting Rich Text to HTML")
      End Try
      Return sReturnString
   End Function
#End Region

End Class

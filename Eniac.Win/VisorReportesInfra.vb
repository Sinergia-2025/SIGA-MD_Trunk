Public Class VisorReportesInfra

   Private _documento As System.Drawing.Printing.PrintDocument
   Public Property Documento() As System.Drawing.Printing.PrintDocument
      Get
         Return _documento
      End Get
      Set(ByVal value As System.Drawing.Printing.PrintDocument)
         _documento = value
      End Set
   End Property


   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      Me.upcDocumento.Document = Me.Documento

   End Sub

End Class
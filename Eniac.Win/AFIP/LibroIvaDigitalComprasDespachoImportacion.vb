Imports System.Text
Imports System.IO

Public Class LibroIvaDigitalComprasDespachoImportacion

#Region "Propiedades"

   Private _lineas As List(Of LibroIvaDigitalComprasDespachoImportacionLinea)
   Public ReadOnly Property Lineas() As List(Of LibroIvaDigitalComprasDespachoImportacionLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of LibroIvaDigitalComprasDespachoImportacionLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As LibroIvaDigitalComprasDespachoImportacionLinea In Me.Lineas
            If li.Procesar Then
               cant += 1
            End If
         Next
         Return cant
      End Get
   End Property

#End Region

#Region "Metodos Publicos"

   Public Sub GrabarArchivo(ByVal destino As String)
      Dim stb As StringBuilder
      Try
         stb = New StringBuilder()

         For Each linea As LibroIvaDigitalComprasDespachoImportacionLinea In Lineas
            If linea.Procesar Then
               stb.Append(linea.GetLinea()).AppendLine()
            End If
         Next

         My.Computer.FileSystem.WriteAllText(destino, stb.ToString(), False, System.Text.Encoding.ASCII)

      Catch ex As Exception
         Throw
      End Try
   End Sub
#End Region

End Class

Public Class LibroIvaDigitalComprasDespachoImportacionLinea

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      Me._stb = New StringBuilder()
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetLinea() As String
      With Me._stb
         .Length = 0

         '01 - desde 001 hasta 016 / AlfaNúmerico / Tam = 16 / Observaciones =  
         .AppendFormat(Me.DespachoImportacion.ToString().PadLeft(16, "0"c))
         '02 - desde 017 hasta 031 / Númerico / Tam = 15 / Observaciones =  13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImporteNetoGravado.ToStringAFIP(15, 0))
         '03 - desde 032 hasta 035 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         .AppendFormat(Me.AlicuotaDeIVA.ToString(New String("0"c, 4)))
         '04 - desde 036 hasta 050 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImpuestoLiquidado.ToStringAFIP(15, 0))

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"
   Public Property Procesar As Boolean
   Public Property Linea As Integer
   Public Property DespachoImportacion As String

   Private _importeNetoGravado As Decimal
   Public Property ImporteNetoGravado() As Decimal
      Private Get
         Return _importeNetoGravado * 100 'System.Math.Abs(_importeNetoGravado * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeNetoGravado = value
      End Set
   End Property
   Public Property AlicuotaDeIVA As Integer

   Private _impuestoLiquidado As Decimal
   Public Property ImpuestoLiquidado() As Decimal
      Private Get
         Return _impuestoLiquidado * 100 'System.Math.Abs(_impuestoLiquidado * 100)
      End Get
      Set(ByVal value As Decimal)
         _impuestoLiquidado = value
      End Set
   End Property



#End Region

End Class

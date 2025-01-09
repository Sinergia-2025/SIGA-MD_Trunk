Imports System.Text
Imports System.IO

Public Class CitiComprasDespachoImportacion

#Region "Propiedades"

   Private _lineas As List(Of CitiComprasDespachoImportacionLinea)
   Public ReadOnly Property Lineas() As List(Of CitiComprasDespachoImportacionLinea)
      Get
         If Me._lineas Is Nothing Then
            Me._lineas = New List(Of CitiComprasDespachoImportacionLinea)()
         End If
         Return _lineas
      End Get
   End Property

   Public ReadOnly Property CantidadDeLineasaProcesar() As Integer
      Get
         Dim cant As Integer = 0
         For Each li As CitiComprasDespachoImportacionLinea In Me.Lineas
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

         For Each linea As CitiComprasDespachoImportacionLinea In Lineas
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

Public Class CitiComprasDespachoImportacionLinea

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
         .AppendFormat(Me.ImporteNetoGravado.ToString(New String("0"c, 15)))
         '03 - desde 032 hasta 035 / Númerico / Tam = 4 / Observaciones =  Según tabla Alícuotas
         .AppendFormat(Me.AlicuotaDeIVA.ToString(New String("0"c, 4)))
         '04 - desde 036 hasta 050 / Númerico / Tam = 15 / Observaciones = 13 enteros 2 decimales sin punto decimal
         .AppendFormat(Me.ImpuestoLiquidado.ToString(New String("0"c, 15)))

      End With
      Return Me._stb.ToString()
   End Function

#End Region

#Region "Propiedades"

   Private _procesar As Boolean = False
   Public Property Procesar() As Boolean
      Get
         Return _procesar
      End Get
      Set(ByVal value As Boolean)
         _procesar = value
      End Set
   End Property

   Private _linea As Integer = 0
   Public Property Linea() As Integer
      Get
         Return _linea
      End Get
      Set(ByVal value As Integer)
         _linea = value
      End Set
   End Property


   Private _despachoImportacion As String
   Public Property DespachoImportacion() As String
      Private Get
         Return _despachoImportacion
      End Get
      Set(ByVal value As String)
         _despachoImportacion = value
      End Set
   End Property


   Private _importeNetoGravado As Decimal
   Public Property ImporteNetoGravado() As Decimal
      Private Get
         Return System.Math.Abs(_importeNetoGravado * 100)
      End Get
      Set(ByVal value As Decimal)
         _importeNetoGravado = value
      End Set
   End Property

   Private _AlicuotaDeIVA As Integer
   Public Property AlicuotaDeIVA() As Integer
      Private Get
         Return _AlicuotaDeIVA
      End Get
      Set(ByVal value As Integer)
         _AlicuotaDeIVA = value
      End Set
   End Property

   Private _impuestoLiquidado As Decimal
   Public Property ImpuestoLiquidado() As Decimal
      Private Get
         Return System.Math.Abs(_impuestoLiquidado * 100)
      End Get
      Set(ByVal value As Decimal)
         _impuestoLiquidado = value
      End Set
   End Property



#End Region


End Class


Public Class ArchivoPDA
#Region "Propiedades"

   Private _datos As List(Of ArchivoPDADatos)
   Public Property Datos() As List(Of ArchivoPDADatos)
      Get
         If _datos Is Nothing Then
            _datos = New List(Of ArchivoPDADatos)()
         End If
         Return _datos
      End Get
      Set(value As List(Of ArchivoPDADatos))
         _datos = value
      End Set
   End Property

#End Region

#Region "Metodos Publicos"
   Public Function GetInfo(archivoFisico As IO.StreamReader) As ArchivoPDA

      Dim linea As String
      Dim arDa As ArchivoPDADatos = New ArchivoPDADatos()

      linea = archivoFisico.ReadLine()
      Do While linea IsNot Nothing
         Datos.Add(New ArchivoPDADatos().GetDato(linea))
         linea = archivoFisico.ReadLine()
      Loop

      Return Me
   End Function

#End Region

End Class
Public Class ArchivoPDADatos

#Region "Campos"

   Private _stb As StringBuilder

#End Region

#Region "Constructores"

   Public Sub New()
      _stb = New StringBuilder()
      Observacion = String.Empty
      TelefonoCliente = String.Empty
      FormaPago = String.Empty
   End Sub

#End Region

#Region "Propiedades"

   Public Property NroPedido As String
   Public Property Fecha As Date
   Public Property CodigoCliente As String
   Public Property CodigoProducto As String
   Public Property Cantidad As Decimal
   Public Property CantidadSinCargo As Decimal
   Public Property CantidadFaltante As Decimal
   Public Property Precio As Decimal
   Public Property Porcentaje As Decimal
   Public Property Observacion As String
   Public Property TelefonoCliente As String
   Public Property FormaPago As String
   Public Property CodigoVendedor As String
   Public Property UnidadBulto As Integer
   Public Property Tipo As Integer
   Public Property Deposito As Integer
   Public Property Transporte As Integer
   Public Property FechaEntrega As Date
   Public Property CantidadDevolucion As Decimal
   Public Property CodigoRuta As Integer
   '-- REQ-31246.- --
   Public Property PorcentajeDescuento2 As Decimal
   Public Property PorcentajeRetornable As Decimal

#End Region

#Region "Metodos Publicos"

   Public Function GetDato(linea As String) As ArchivoPDADatos
      Dim dato As ArchivoPDADatos = New ArchivoPDADatos()
      With dato
         dato.NroPedido = linea.Substring(0, 13)
         Dim fec = linea.Substring(13, 10).Replace("/", "")
         Dim dia = Integer.Parse(fec.Substring(0, 2))
         Dim mes = Integer.Parse(fec.Substring(2, 2))
         Dim año = Integer.Parse(fec.Substring(4, 4))
         dato.Fecha = New Date(año, mes, dia)
         dato.CodigoCliente = linea.Substring(23, 10)
         dato.CodigoProducto = linea.Substring(33, 20)
         dato.Cantidad = Decimal.Parse(linea.Substring(53, 12))
         dato.CantidadSinCargo = Decimal.Parse(linea.Substring(65, 12))
         dato.CantidadFaltante = Decimal.Parse(linea.Substring(77, 12))
         dato.Precio = Decimal.Parse(linea.Substring(89, 12))
         dato.Porcentaje = Decimal.Parse(linea.Substring(101, 6))
         dato.Observacion = linea.Substring(107, 100)
         dato.TelefonoCliente = linea.Substring(207, 15)
         dato.FormaPago = linea.Substring(222, 2)
         dato.CodigoVendedor = linea.Substring(224, 10)
         dato.UnidadBulto = Integer.Parse(linea.Substring(234, 1))
         dato.Tipo = Integer.Parse(linea.Substring(235, 1))
         dato.Deposito = Integer.Parse(linea.Substring(236, 2))
         dato.Transporte = Integer.Parse(linea.Substring(238, 1))
         Dim fec2 = linea.Substring(239, 10).Replace("/", "")
         Dim dia2 = Integer.Parse(fec2.Substring(0, 2))
         Dim mes2 = Integer.Parse(fec2.Substring(2, 2))
         Dim año2 = Integer.Parse(fec2.Substring(4, 4))
         dato.FechaEntrega = New Date(año2, mes2, dia2)
         dato.CantidadDevolucion = Decimal.Parse(linea.Substring(249, 12))
         dato.CodigoRuta = Integer.Parse(linea.Substring(261, 3))
         '-- REQ-31246.- --
         If linea.Length > 264 Then
            If Trim(linea.Substring(264, 6)) <> "" Then
               dato.PorcentajeDescuento2 = Decimal.Parse(linea.Substring(264, 6))
            Else
               dato.PorcentajeDescuento2 = 0
            End If
         Else
            dato.PorcentajeDescuento2 = 0
         End If
         If linea.Length > 270 Then
            If Trim(linea.Substring(270, 6)) <> "" Then
               dato.PorcentajeRetornable = Decimal.Parse(linea.Substring(270, 6))
            Else
               dato.PorcentajeRetornable = 0
            End If
         Else
            dato.PorcentajeRetornable = 0
         End If
      End With

      Return dato
   End Function

#End Region

End Class
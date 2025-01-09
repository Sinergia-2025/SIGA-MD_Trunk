Imports System.IO
Imports System.Net
Imports System.Web.Script.Serialization

Public Class VentasPirelli
   Inherits Base
#Region "Enum"
   Public Enum Metodo
      [GET]
      POST
      PUT
      PATCH
   End Enum

   Public Enum Controls
      categories
      products
      orders
   End Enum

#End Region

#Region "Propiedades"

   Public serializer As New JavaScriptSerializer()
   Public rFechaDesde As Date
   Public rFechaHasta As Date

   Private Property VentasPirelliURLBase As Uri
   Private Property RestResponse As String
   Public Property EstadoProceso As Boolean
   Public Property MensajProceso As String
   Public Property MensajErrores As New StringBuilder()


#End Region

#Region "Constructors"
   Private Sub New(accesoDatos As Datos.DataAccess)
      da = accesoDatos
   End Sub
   Public Sub New()
      Me.New(New Datos.DataAccess())
      If Not String.IsNullOrEmpty(Reglas.Publicos.InformeVentas.VentasPirelli.VentasPirelliURLBase) Then
         VentasPirelliURLBase = New Uri(Reglas.Publicos.InformeVentas.VentasPirelli.VentasPirelliURLBase)
      Else
         Throw New Exception("ATENCIÓN: La URL Base para Ventas Pirelli no se encuentra configurada.")
      End If
   End Sub

#End Region

#Region "Methods"

   Public Sub InformaVentasPirelli()
      '--------------------------
      Dim serializer = New JavaScriptSerializer()
      '-- Obtiene la ventas a informar.- --   
      Dim dt As DataTable = GetVentasPirelli()
      Dim data As String
      Dim nContVtas As Integer = 0           '-- Contador de Ventas Informadas.- --
      Dim Atributos = New List(Of Entidades.JSonEntidades.Exportaciones.Pirelli.Ventas)


      For Each dr As DataRow In dt.Rows
         nContVtas += 1
         '-- Carga Atributos de Marca y Modelo N/A.- --
         '-- REQ-32666.- ------------------------------
         Dim item As New Entidades.JSonEntidades.Exportaciones.Pirelli.Ventas
         Dim FechaVta As DateTime? = dr.Field(Of Date)("FechaVenta")
         With item
            .SucursalId = CInt(dr.Field(Of String)("Sucursal").ToString())
            .ProductoId = CInt(dr.Field(Of String)("ProductoID").ToString())
            .Fecha = FechaVta.Value.ToString("yyyy-MM-ddTHH:mm:ss-03:00")
            .Cantidad = CInt(dr.Field(Of Decimal)("Cantidad").ToString())
         End With
         Atributos.Add(item)
      Next
      Dim Producto = New Entidades.JSonEntidades.Exportaciones.Pirelli.Request
      With Producto
         .JerarquiaId = 9790040
         .Clave = "API_Pilla#1986"
         .Lineas = Atributos
      End With

      '-- Armo el JSON y Lo convierto a String
      data = serializer.Serialize(Producto)
      '-- Informa nueva Ventas Pirelli.- --
      CrgVentasPirelli(data, nContVtas)

   End Sub

   Private Function GetVentasPirelli() As DataTable
      Return New SqlServer.VentasPirelli(da).GetVentasPirelli(rFechaDesde, rFechaHasta)
   End Function

   Private Sub CrgVentasPirelli(data As String, CantidadReg As Integer)
      Dim rCabecera As New Dictionary(Of String, String)

      '-- Envio Informe de Ventas Pirelli.- --
      Dim response = Enviar(Of Entidades.JSonEntidades.Exportaciones.Pirelli.Response)(data, Metodo.POST, rCabecera, "api/upload")
      EstadoProceso = response.Ok
      Select Case response.Ok
         Case True
            '-- Informo Exito del Proceso.- --
            MensajProceso = response.mensaje
         Case False
            '-- Informo Errores del Proceso.- --
            With MensajErrores
               .AppendFormatLine("Listado de Erroles Informados en el Proceso")
               .AppendFormatLine("")
            End With
            For Each errPRL As Entidades.JSonEntidades.Exportaciones.Pirelli.UploadError In response.Errores
               With MensajErrores
                  .AppendFormatLine(errPRL.error)
               End With
            Next
      End Select
   End Sub

   Private Function Enviar(Of T)(data As String, method As Metodo, headers As Dictionary(Of String, String), relativeUri As String) As T
      Dim uri = New Uri(VentasPirelliURLBase, relativeUri)
      '--------------------------------------------------------------------------------------
      GetPOSTResponse(uri, method.ToString(), data, headers, Sub(x)
                                                                RestResponse = x
                                                             End Sub)
      Return DirectCast(New JavaScriptSerializer().Deserialize(RestResponse, GetType(T)), T)
      '--------------------------------------------------------------------------------------
   End Function

   Private Sub GetPOSTResponse(uri As Uri, metodo As String, data As String, headers As Dictionary(Of String, String), callback As Action(Of String))

      Dim request As HttpWebRequest = DirectCast(HttpWebRequest.Create(uri), HttpWebRequest)
      request.Method = metodo
      request.ContentType = "application/json"

      '# Add headers
      If headers IsNot Nothing Then
         For Each header As KeyValuePair(Of String, String) In headers
            If Not String.IsNullOrWhiteSpace(header.Key) Then
               request.Headers.Add(header.Key, header.Value)
            End If
         Next
      End If


      Try

         Dim encoding As New System.Text.UTF8Encoding()
         Dim bytes As Byte() = encoding.GetBytes(data)
         request.ContentLength = bytes.Length
         Using requestStream As Stream = request.GetRequestStream()
            ' Send the data.
            requestStream.Write(bytes, 0, bytes.Length)
         End Using

         request.BeginGetResponse(
          Function(x)
             Using response As HttpWebResponse = DirectCast(request.EndGetResponse(x), HttpWebResponse)
                If callback IsNot Nothing Then
                   Using stream As Stream = response.GetResponseStream()
                      Dim reader As StreamReader = New StreamReader(stream, encoding)
                      Dim responseString As String = reader.ReadToEnd()
                      callback(responseString)
                   End Using
                End If
             End Using
             Return 0
          End Function, Nothing)
      Catch ex As WebException

      End Try
   End Sub
#End Region


End Class
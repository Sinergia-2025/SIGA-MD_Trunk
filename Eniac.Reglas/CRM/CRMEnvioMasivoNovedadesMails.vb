Option Strict On
Option Explicit On
Public Class CRMEnvioMasivoNovedadesMails
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      da = accesoDatos
   End Sub

#End Region

   Public Function GetEnvioMasivoNovedadesMail(idAplicacion As String,
                                               categorias As Entidades.Categoria(),
                                               idZonaGeografica As String,
                                               idCliente As Long,
                                               desdeNombreCliente As String,
                                               configMail As String,
                                               IdCobrador As Integer) As DataTable
      Return New SqlServer.CRMEnvioMasivoNovedadesMails(Me.da).GetEnvioMasivoNovedadesMail(idAplicacion,
                                                                                           categorias, idZonaGeografica,
                                                                                           idCliente, desdeNombreCliente,
                                                                                           configMail, IdCobrador)
   End Function

   Public Function ArmaClientesEnvio(dtEnvioMail As DataTable,
                                     ByRef cantidadCorreos As Integer,
                                     bcc As String) As List(Of ClienteEnvioMail)
      Dim result As List(Of ClienteEnvioMail) = New List(Of ClienteEnvioMail)()
      dtEnvioMail.DefaultView.Sort = "IdCliente"
      Dim idClienteAnterior As Long = -1
      Dim clienteEnvio As ClienteEnvioMail = Nothing
      Dim codigoCliente As Long
      Dim nombreCliente As String
      Dim correElectronico As String

      Dim idCliente As Long

      For Each drvEnvioMail As DataRowView In dtEnvioMail.DefaultView
         Dim drEnvioMail As DataRow = drvEnvioMail.Row
         If Not CBool(drEnvioMail("Envio")) Then Continue For
         idCliente = Long.Parse(drEnvioMail(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())

         If Not idCliente.Equals(idClienteAnterior) Then
            codigoCliente = Long.Parse(drEnvioMail(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
            nombreCliente = drEnvioMail(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()
            correElectronico = drEnvioMail(Entidades.Cliente.Columnas.CorreoElectronico.ToString()).ToString()

            'le cargo una sucursal por defecto en el ultimo parametro
            clienteEnvio = New ClienteEnvioMail(idCliente, codigoCliente, nombreCliente, correElectronico)
            result.Add(clienteEnvio)

            idClienteAnterior = idCliente
            cantidadCorreos += clienteEnvio.CorreElectronico.Split(";"c).Length
            If Not String.IsNullOrWhiteSpace(bcc) Then cantidadCorreos += bcc.Split(";"c).Length
         End If

      Next

      If result.Count = 0 Then
         Throw New Exception("ATENCION: No seleccionó ningún Cliente.")
      End If

      Return result
   End Function

#Region "Clases para ArmaClientesEnvio"
   Public Class ClienteEnvioMail
      Public Sub New()
         Comprobantes = New List(Of ComprobanteEnvioMail)()
      End Sub
      Public Sub New(idCliente As Long,
                     codigoCliente As Long,
                     nombreCliente As String,
                     correoElectronico As String)
         Me.New()
         Me.IdCliente = idCliente
         Me.CodigoCliente = codigoCliente
         Me.NombreCliente = nombreCliente
         Me.CorreElectronico = correoElectronico
         Me.IdSucursalDefecto = IdSucursalDefecto
      End Sub
      Public Property IdCliente As Long
      Public Property CodigoCliente As Long
      Public Property NombreCliente As String
      Public Property CorreElectronico As String
      Public Property Comprobantes As List(Of ComprobanteEnvioMail)
      Public Property IdSucursalDefecto As Integer
   End Class
   Public Class ComprobanteEnvioMail
      Public Sub New()
      End Sub
      Public Sub New(IdSucursal As Integer, IdTipoComprobante As String, LetraComprobante As String, CentroEmisor As Short, NumeroComprobante As Long)
         Me.New()
         Me.IdSucursal = IdSucursal
         Me.IdTipoComprobante = IdTipoComprobante
         Me.LetraComprobante = LetraComprobante
         Me.CentroEmisor = CentroEmisor
         Me.NumeroComprobante = NumeroComprobante
      End Sub
      Public Property IdSucursal() As Integer
      Public Property IdTipoComprobante() As String
      Public Property LetraComprobante() As String
      Public Property CentroEmisor() As Short
      Public Property NumeroComprobante() As Long
      Public Property NombreArchivoDestino As String
   End Class
#End Region

End Class
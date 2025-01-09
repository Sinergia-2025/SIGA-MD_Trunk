Option Strict On
Option Explicit On
Imports System.Runtime.Remoting.Messaging
Imports System.Text
Imports System.Windows.Forms
Imports Eniac.Entidades

Public Class VentasEnvioMasivoMails
   Inherits Eniac.Reglas.Base

   Private ComprobanteAnt As Entidades.Venta
   Private _categoriaFiscalEmpresa As Eniac.Entidades.CategoriaFiscal

#Region "Constructores"

   Public Sub New()
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      da = accesoDatos
   End Sub

#End Region

   Public Function GetEnvioMasivoMail(sucursales As Entidades.Sucursal(),
                                      fechaDesde As DateTime?, fechaHasta As DateTime?, modoFechas As String,
                                      idCategoria As Integer?, idZonaGeografica As String,
                                      idCliente As Long?, desdeNombreCliente As String,
                                      configMail As String, idcobrador As Integer,
                                      correoEnviado As Entidades.Publicos.SiNoTodos,
                                      listaComprobantes As Entidades.TipoComprobante(),
                                      operador As Entidades.Publicos.OperadoresRelacionales?,
                                      saldo As Decimal?, vinculado As Entidades.Cliente.ClienteVinculado) As DataTable


      Return New SqlServer.VentasEnvioMasivoMails(Me.da).GetEnvioMasivoMail(sucursales,
                                                                                  fechaDesde, fechaHasta, modoFechas,
                                                                                  idCategoria, idZonaGeografica,
                                                                                  idCliente, desdeNombreCliente,
                                                                                  configMail, idcobrador,
                                                                                  correoEnviado,
                                                                                  listaComprobantes,
                                                                                  operador,
                                                                                  saldo, vinculado)
   End Function

   Public Function ArmaClientesEnvio(dtEnvioMail As DataTable,
                                     ByRef cantidadCorreos As Integer,
                                     bcc As String, vinculado As Entidades.Cliente.ClienteVinculado) As List(Of ClienteEnvioMail)
      Dim result As List(Of ClienteEnvioMail) = New List(Of ClienteEnvioMail)()
      dtEnvioMail.DefaultView.Sort = "IdCliente"
      Dim idClienteAnterior As Long = -1
      Dim clienteEnvio As ClienteEnvioMail = Nothing
      Dim codigoCliente As Long
      Dim nombreCliente As String
      Dim nombreFantasia As String
      Dim siMovilUsuario As String
      Dim siMovilClave As String
      Dim correElectronico As String
      Dim IdSucursal As Integer
      Dim IdTipoComprobante As String
      Dim LetraComprobante As String
      Dim CentroEmisor As Short
      Dim NumeroComprobante As Long
      Dim compMail As ComprobanteEnvioMail
      Dim idCliente As Long

      For Each drvEnvioMail As DataRowView In dtEnvioMail.DefaultView
         Dim drEnvioMail As DataRow = drvEnvioMail.Row
         If Not CBool(drEnvioMail("Envio")) Then Continue For

         '# Actualizo el estado del correo a "Pendiente"
         If drEnvioMail.Table.Columns.Contains("Estado") Then
            drEnvioMail("Estado") = "Pendiente"
            Application.DoEvents()
         End If

         idCliente = Long.Parse(drEnvioMail(Entidades.Cliente.Columnas.IdCliente.ToString()).ToString())
         If vinculado = Entidades.Cliente.ClienteVinculado.Vinculado Then
            idCliente = Long.Parse(drEnvioMail("IdClienteVinculado").ToString())
         End If
         If dtEnvioMail.Columns.Contains(Entidades.Venta.Columnas.IdSucursal.ToString()) Then
            IdSucursal = Short.Parse(drEnvioMail(Entidades.Venta.Columnas.IdSucursal.ToString()).ToString())
         Else
            IdSucursal = Entidades.Usuario.Actual.Sucursal.Id
         End If

         If Not idCliente.Equals(idClienteAnterior) Then
            codigoCliente = Long.Parse(drEnvioMail(Entidades.Cliente.Columnas.CodigoCliente.ToString()).ToString())
            nombreCliente = drEnvioMail(Entidades.Cliente.Columnas.NombreCliente.ToString()).ToString()
            nombreFantasia = drEnvioMail(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).ToString()
            siMovilUsuario = drEnvioMail(Entidades.Cliente.Columnas.SiMovilIdUsuario.ToString()).ToString()
            siMovilClave = drEnvioMail(Entidades.Cliente.Columnas.SiMovilClave.ToString()).ToString()

            correElectronico = drEnvioMail(Entidades.Cliente.Columnas.CorreoElectronico.ToString()).ToString()
            If vinculado = Entidades.Cliente.ClienteVinculado.Vinculado Then
               correElectronico = drEnvioMail("CorreoClienteVinculado").ToString()
            End If

            'le cargo una sucursal por defecto en el ultimo parametro
            clienteEnvio = New ClienteEnvioMail(idCliente, codigoCliente, nombreCliente, correElectronico, IdSucursal, nombreFantasia, siMovilUsuario, siMovilClave, drEnvioMail)
            result.Add(clienteEnvio)

            idClienteAnterior = idCliente
            cantidadCorreos += clienteEnvio.CorreElectronico.Split(";"c).Length
            If Not String.IsNullOrWhiteSpace(bcc) Then cantidadCorreos += bcc.Split(";"c).Length
         End If
         If dtEnvioMail.Columns.Contains(Entidades.Venta.Columnas.IdTipoComprobante.ToString()) And
            dtEnvioMail.Columns.Contains(Entidades.Venta.Columnas.Letra.ToString()) And
            dtEnvioMail.Columns.Contains(Entidades.Venta.Columnas.CentroEmisor.ToString()) And
            dtEnvioMail.Columns.Contains(Entidades.Venta.Columnas.NumeroComprobante.ToString()) Then
            IdTipoComprobante = drEnvioMail(Entidades.Venta.Columnas.IdTipoComprobante.ToString()).ToString()
            LetraComprobante = drEnvioMail(Entidades.Venta.Columnas.Letra.ToString()).ToString()
            CentroEmisor = Short.Parse(drEnvioMail(Entidades.Venta.Columnas.CentroEmisor.ToString()).ToString())
            NumeroComprobante = Long.Parse(drEnvioMail(Entidades.Venta.Columnas.NumeroComprobante.ToString()).ToString())
            compMail = New ComprobanteEnvioMail(IdSucursal, IdTipoComprobante, LetraComprobante, CentroEmisor, NumeroComprobante)

            clienteEnvio.Comprobantes.Add(compMail)
         End If
      Next

      If result.Count = 0 Then
         Throw New Exception("ATENCION: No seleccionó ningún Comprobante/Cliente.")
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
                     correoElectronico As String,
                     idSucursalDefecto As Integer,
                     nombreDeFantasia As String,
                     siMovilUsuario As String,
                     siMovilClave As String,
                     drEnvioMail As DataRow)
         Me.New()
         Me.IdCliente = idCliente
         Me.CodigoCliente = codigoCliente
         Me.NombreCliente = nombreCliente
         Me.CorreElectronico = correoElectronico
         Me.IdSucursalDefecto = idSucursalDefecto
         Me.NombreDeFantasia = nombreDeFantasia
         Me.SiMovilUsuario = siMovilUsuario
         Me.SiMovilClave = siMovilClave
         Me.RowOrigen = drEnvioMail
      End Sub
      Public Property IdCliente As Long
      Public Property CodigoCliente As Long
      Public Property NombreCliente As String
      Public Property NombreDeFantasia As String
      Public Property SiMovilUsuario As String
      Public Property SiMovilClave As String
      Public Property CorreElectronico As String
      Public Property Comprobantes As List(Of ComprobanteEnvioMail)
      Public Property IdSucursalDefecto As Integer
      Public Property RowOrigen As DataRow
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

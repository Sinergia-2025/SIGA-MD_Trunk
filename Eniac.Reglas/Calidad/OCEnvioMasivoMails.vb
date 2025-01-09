Option Strict On
Option Explicit On
Imports System.Text
Imports System.Windows.Forms

Public Class OCEnvioMasivoMails
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
                                      saldo As Decimal?) As DataTable
      Return New SqlServer.VentasEnvioMasivoMails(Me.da).GetEnvioMasivoMail(sucursales,
                                                                            fechaDesde, fechaHasta, modoFechas,
                                                                            idCategoria, idZonaGeografica,
                                                                            idCliente, desdeNombreCliente,
                                                                            configMail, idcobrador,
                                                                            correoEnviado,
                                                                            listaComprobantes,
                                                                            operador,
                                                                            saldo)
   End Function

   Public Function ArmaProveedoresEnvio(dtEnvioMail As DataTable,
                                     ByRef cantidadCorreos As Integer,
                                     bcc As String) As List(Of OCEnvioMail)
      Dim result As List(Of OCEnvioMail) = New List(Of OCEnvioMail)()
      dtEnvioMail.DefaultView.Sort = "IdProveedor"
      Dim idProveedorAnterior As Long = -1
      Dim OCEnvio As OCEnvioMail = Nothing
      Dim codigoProveedor As Long
      Dim nombreProveedor As String
      Dim nombreFantasia As String
      Dim siMovilUsuario As String
      Dim siMovilClave As String
      Dim correElectronico As String
      Dim IdSucursal As Integer
      Dim IdTipoComprobante As String
      Dim LetraComprobante As String
      Dim CentroEmisor As Short
      Dim NumeroPedido As Long
      Dim compMail As ComprobanteEnvioMail
      Dim idProveedor As Long

      For Each drvEnvioMail As DataRowView In dtEnvioMail.DefaultView
         Dim drEnvioMail As DataRow = drvEnvioMail.Row
         If Not CBool(drEnvioMail("Envio")) Then Continue For

         '# Actualizo el estado del correo a "Pendiente"
         If drEnvioMail.Table.Columns.Contains("Estado") Then
            drEnvioMail("Estado") = "Pendiente"
            Application.DoEvents()
         End If

         idProveedor = Long.Parse(drEnvioMail(Entidades.Proveedor.Columnas.IdProveedor.ToString()).ToString())

         If dtEnvioMail.Columns.Contains(Entidades.Venta.Columnas.IdSucursal.ToString()) Then
            IdSucursal = Short.Parse(drEnvioMail(Entidades.Venta.Columnas.IdSucursal.ToString()).ToString())
         Else
            IdSucursal = Entidades.Usuario.Actual.Sucursal.Id
         End If

         If Not idProveedor.Equals(idProveedorAnterior) Then
            ' codigoProveedor = Long.Parse(drEnvioMail(Entidades.Proveedor.Columnas.Codigopriente.ToString()).ToString())
            nombreProveedor = drEnvioMail(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).ToString()
            'nombreFantasia = drEnvioMail(Entidades.Cliente.Columnas.NombreDeFantasia.ToString()).ToString()
            'siMovilUsuario = drEnvioMail(Entidades.Cliente.Columnas.SiMovilIdUsuario.ToString()).ToString()
            'siMovilClave = drEnvioMail(Entidades.Cliente.Columnas.SiMovilClave.ToString()).ToString()

            correElectronico = drEnvioMail(Entidades.Cliente.Columnas.CorreoElectronico.ToString()).ToString()

            'le cargo una sucursal por defecto en el ultimo parametro
            OCEnvio = New OCEnvioMail(idProveedor, codigoProveedor, nombreProveedor, correElectronico, IdSucursal, nombreFantasia, siMovilUsuario, siMovilClave, drEnvioMail)
            result.Add(OCEnvio)

            idProveedorAnterior = idProveedor
            cantidadCorreos += OCEnvio.CorreElectronico.Split(";"c).Length
            If Not String.IsNullOrWhiteSpace(bcc) Then cantidadCorreos += bcc.Split(";"c).Length
         End If
         If dtEnvioMail.Columns.Contains(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()) And
            dtEnvioMail.Columns.Contains(Entidades.PedidoProveedor.Columnas.Letra.ToString()) And
            dtEnvioMail.Columns.Contains(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()) And
            dtEnvioMail.Columns.Contains(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()) Then
            IdTipoComprobante = drEnvioMail(Entidades.PedidoProveedor.Columnas.IdTipoComprobante.ToString()).ToString()
            LetraComprobante = drEnvioMail(Entidades.PedidoProveedor.Columnas.Letra.ToString()).ToString()
            CentroEmisor = Short.Parse(drEnvioMail(Entidades.PedidoProveedor.Columnas.CentroEmisor.ToString()).ToString())
            NumeroPedido = Long.Parse(drEnvioMail(Entidades.PedidoProveedor.Columnas.NumeroPedido.ToString()).ToString())
            compMail = New ComprobanteEnvioMail(IdSucursal, IdTipoComprobante, LetraComprobante, CentroEmisor, NumeroPedido)

            OCEnvio.Comprobantes.Add(compMail)
         End If
      Next

      If result.Count = 0 Then
         Throw New Exception("ATENCION: No seleccionó ningún Comprobante/Cliente.")
      End If

      Return result
   End Function

#Region "Clases para ArmaClientesEnvio"
   Public Class OCEnvioMail
      Public Sub New()
         Comprobantes = New List(Of ComprobanteEnvioMail)()
      End Sub
      Public Sub New(idProveedor As Long,
                     codigoProveedor As Long,
                     nombreProveedor As String,
                     correoElectronico As String,
                     idSucursalDefecto As Integer,
                     nombreDeFantasia As String,
                     siMovilUsuario As String,
                     siMovilClave As String,
                     drEnvioMail As DataRow)
         Me.New()
         Me.IdProveedor = idProveedor
         Me.CodigoProveedor = codigoProveedor
         Me.NombreProveedor = nombreProveedor
         Me.CorreElectronico = correoElectronico
         Me.IdSucursalDefecto = idSucursalDefecto
         Me.NombreDeFantasia = nombreDeFantasia
         Me.SiMovilUsuario = siMovilUsuario
         Me.SiMovilClave = siMovilClave
         Me.RowOrigen = drEnvioMail
      End Sub
      Public Property IdProveedor As Long
      Public Property CodigoProveedor As Long
      Public Property NombreProveedor As String
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

Option Explicit On
Option Strict On
Public Class VentasClientesContactos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "VentasClientesContactos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "VentasClientesContactos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Borra(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Actualiza(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.VentasClientesContactos(Me.da).VentasClientesContactos_GA()
   End Function

   Public Overloads Function GetAll(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Short,
                                    numeroComprobante As Long) As System.Data.DataTable
      Return New SqlServer.VentasClientesContactos(Me.da).VentasClientesContactos_G(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.VentaClienteContacto = DirectCast(entidad, Entidades.VentaClienteContacto)

      Dim sqlC As SqlServer.VentasClientesContactos = New SqlServer.VentasClientesContactos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasClientesContactos_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.numeroComprobante, en.IdCliente, en.IdContacto)
         Case TipoSP._U
            sqlC.VentasClientesContactos_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.numeroComprobante, en.IdCliente, en.IdContacto)
         Case TipoSP._D
            sqlC.VentasClientesContactos_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.numeroComprobante, en.IdCliente, en.IdContacto)
      End Select
   End Sub

   Public Sub InsertaContactosDesdeVenta(ByVal oVentas As Entidades.Venta)

      Dim orden As Integer = 0
      For Each contacto As Entidades.VentaClienteContacto In oVentas.VentasContactos
         contacto.IdSucursal = oVentas.IdSucursal
         contacto.IdTipoComprobante = oVentas.IdTipoComprobante
         contacto.Letra = oVentas.LetraComprobante
         contacto.CentroEmisor = oVentas.CentroEmisor
         contacto.NumeroComprobante = oVentas.NumeroComprobante
         Inserta(contacto)
      Next
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.VentaClienteContacto, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.VentaClienteContacto.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.VentaClienteContacto.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.VentaClienteContacto.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.VentaClienteContacto.Columnas.CentroEmisor.ToString()).ToString())
         .numeroComprobante = Long.Parse(dr(Entidades.VentaClienteContacto.Columnas.numeroComprobante.ToString()).ToString())
         If IsNumeric(dr(Entidades.VentaClienteContacto.Columnas.IdCliente.ToString())) And
            IsNumeric(dr(Entidades.VentaClienteContacto.Columnas.IdContacto.ToString())) Then
            .Contacto = New Reglas.ClientesContactos(da).GetUno(Long.Parse(dr(Entidades.VentaClienteContacto.Columnas.IdCliente.ToString()).ToString()),
                                                                Integer.Parse(dr(Entidades.VentaClienteContacto.Columnas.IdContacto.ToString()).ToString()))
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Short,
                          numeroComprobante As Long,
                          idCliente As Long,
                          idContacto As Integer) As Entidades.VentaClienteContacto
      Dim dt As DataTable = New SqlServer.VentasClientesContactos(Me.da).VentasClientesContactos_G1(idSucursal,
                                                                                                      idTipoComprobante,
                                                                                                      letra,
                                                                                                      centroEmisor,
                                                                                                      numeroComprobante,
                                                                                                      idCliente,
                                                                                                      idContacto)
      Dim o As Entidades.VentaClienteContacto = New Entidades.VentaClienteContacto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Short,
                            numeroComprobante As Long) As List(Of Entidades.VentaClienteContacto)
      Dim dt As DataTable = Me.GetAll(idSucursal,
                                      idTipoComprobante,
                                      letra,
                                      centroEmisor,
                                      numeroComprobante)
      Dim o As Entidades.VentaClienteContacto
      Dim oLis As List(Of Entidades.VentaClienteContacto) = New List(Of Entidades.VentaClienteContacto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.VentaClienteContacto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetContactosCliente(idSucursal As Integer,
                           idTipoComprobante As String,
                           letra As String,
                           centroEmisor As Short,
                           numeroComprobante As Long) As DataTable
      Return New SqlServer.VentasClientesContactos(Me.da).VentasClientesContactos_GetParaInforme(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function

#End Region
End Class
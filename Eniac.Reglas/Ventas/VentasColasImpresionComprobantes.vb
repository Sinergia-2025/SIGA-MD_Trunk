Option Strict On
Option Explicit On
Imports Eniac.Entidades
Imports System.Text
Public Class VentasColasImpresionComprobantes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "VentasColasImpresionComprobantes"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "VentasColasImpresionComprobantes"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.VentasColasImpresionComprobantes = New SqlServer.VentasColasImpresionComprobantes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(0)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open
      Try
         Dim en As Entidades.VentaColaImpresionComprobante = DirectCast(entidad, Entidades.VentaColaImpresionComprobante)

         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sqlC As SqlServer.VentasColasImpresionComprobantes = New SqlServer.VentasColasImpresionComprobantes(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.VentasColasImpresionComprobantes_I(en.IdVentaColaImpresion, en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                    en.IdCliente, en.CodigoCliente, en.NombreCliente,
                                    en.IdVendedor, en.NombreVendedor, en.Fecha,
                                    en.IdFormasPago, en.DescripcionFormasPago, en.ImporteTotal, en.DescuentoRecargoPorc,
                                    en.IdCategoria, en.IdCategoriaFiscal, en.NombreCategoriaFiscal)
            Case TipoSP._U
               sqlC.VentasColasImpresionComprobantes_U(en.IdVentaColaImpresion, en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante,
                                    en.IdCliente, en.CodigoCliente, en.NombreCliente,
                                    en.IdVendedor, en.NombreVendedor, en.Fecha,
                                    en.IdFormasPago, en.DescripcionFormasPago, en.ImporteTotal, en.DescuentoRecargoPorc,
                                    en.IdCategoria, en.IdCategoriaFiscal, en.NombreCategoriaFiscal)
            Case TipoSP._D
               sqlC.VentasColasImpresionComprobantes_D(en.IdVentaColaImpresion, en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante)
         End Select

         If blnAbreConexion Then da.CommitTransaction()
      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.VentaColaImpresionComprobante, ByVal dr As DataRow)
      With o
         .IdVentaColaImpresion = Integer.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.IdVentaColaImpresion.ToString()).ToString())
         .IdSucursal = Integer.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.VentaColaImpresionComprobante.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.VentaColaImpresionComprobante.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Integer.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroComprobante = Long.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.NumeroComprobante.ToString()).ToString())
         .IdCliente = Long.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.IdCliente.ToString()).ToString())
         .CodigoCliente = Long.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.CodigoCliente.ToString()).ToString())
         .NombreCliente = dr(Entidades.VentaColaImpresionComprobante.Columnas.NombreCliente.ToString()).ToString()
         .IdVendedor = Integer.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.IdVendedor.ToString()).ToString())
         .NombreVendedor = dr(Entidades.VentaColaImpresionComprobante.Columnas.NombreVendedor.ToString()).ToString()
         .Fecha = DateTime.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.Fecha.ToString()).ToString())
         .IdFormasPago = Integer.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.IdFormasPago.ToString()).ToString())
         .DescripcionFormasPago = dr(Entidades.VentaColaImpresionComprobante.Columnas.DescripcionFormasPago.ToString()).ToString()
         .ImporteTotal = Decimal.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.ImporteTotal.ToString()).ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.DescuentoRecargoPorc.ToString()).ToString())
         .IdCategoria = Integer.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.IdCategoria.ToString()).ToString())
         .IdCategoriaFiscal = Short.Parse(dr(Entidades.VentaColaImpresionComprobante.Columnas.IdCategoriaFiscal.ToString()).ToString())
         .NombreCategoriaFiscal = dr(Entidades.VentaColaImpresionComprobante.Columnas.NombreCategoriaFiscal.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(IdVentaColaImpresion As Integer,
                          IdSucursal As Integer,
                          IdTipoComprobante As String,
                          Letra As String,
                          CentroEmisor As Integer,
                          NumeroComprobante As Long) As Entidades.VentaColaImpresionComprobante
      Dim dt As DataTable = New SqlServer.VentasColasImpresionComprobantes(Me.da).VentasColasImpresionComprobantes_G1(IdVentaColaImpresion, IdSucursal, IdTipoComprobante, Letra, CentroEmisor, NumeroComprobante)
      Dim o As Entidades.VentaColaImpresionComprobante = New Entidades.VentaColaImpresionComprobante()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Overloads Function GetAll(idColaImpresion As Integer) As System.Data.DataTable
      Return New SqlServer.VentasColasImpresionComprobantes(Me.da).VentasColasImpresionComprobantes_GA(idColaImpresion)
   End Function

   Public Function GetTodos() As List(Of Entidades.VentaColaImpresionComprobante)
      Return GetTodos(0)
   End Function

   Public Function GetTodos(idColaImpresion As Integer) As List(Of Entidades.VentaColaImpresionComprobante)
      Dim dt As DataTable = Me.GetAll(idColaImpresion)
      Dim o As Entidades.VentaColaImpresionComprobante
      Dim oLis As List(Of Entidades.VentaColaImpresionComprobante) = New List(Of Entidades.VentaColaImpresionComprobante)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.VentaColaImpresionComprobante()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class

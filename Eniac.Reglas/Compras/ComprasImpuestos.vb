#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class ComprasImpuestos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ComprasImpuestos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim ent As Entidades.CompraImpuesto = DirectCast(entidad, Entidades.CompraImpuesto)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.Inserta(ent)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Inserta(ByVal conce As Eniac.Entidades.CompraImpuesto)
      'Inserto el Registro en la tabla Maestra
      Me.EjecutaSP(conce, TipoSP._I)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim ent As Entidades.CompraImpuesto = DirectCast(entidad, Entidades.CompraImpuesto)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Me.EjecutaSP(ent, TipoSP._D)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Borra(ByVal conce As Eniac.Entidades.CompraImpuesto)
      Me.EjecutaSP(conce, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ComprasImpuestos = New SqlServer.ComprasImpuestos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ComprasImpuestos(Me.da).ComprasImpuestos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal ent As Entidades.CompraImpuesto, ByVal tipo As TipoSP)
      Dim sql As SqlServer.ComprasImpuestos = New SqlServer.ComprasImpuestos(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.ComprasImpuestos_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                                   ent.NumeroComprobante, ent.IdProveedor, ent.IdTipoImpuesto, ent.Orden,
                                   ent.IdProvincia, ent.Emisor, ent.Numero, ent.Bruto, ent.BaseImponible, ent.Alicuota, ent.Importe,
                                   ent.EsDespacho)
         Case TipoSP._U

         Case TipoSP._D
            sql.ComprasImpuestos_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor,
                                   ent.NumeroComprobante, ent.IdProveedor, ent.Orden, ent.IdTipoImpuesto)
      End Select
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetCodigoMaximo(idSucursal As Integer,
                                   idTipoComprobante As String,
                                   letra As String,
                                   centroEmisor As Integer,
                                   numeroComprobante As Long,
                                   idProveedor As Long) As Long
      Return New SqlServer.ComprasImpuestos(da).GetOrdenMaximo(idSucursal, idTipoComprobante, letra, centroEmisor,
                                                               numeroComprobante, idProveedor)
   End Function

   Private Sub CargaUno(o As Entidades.CompraImpuesto, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.CompraImpuesto.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.CompraImpuesto.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.CompraImpuesto.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Integer.Parse(dr(Entidades.CompraImpuesto.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroComprobante = Long.Parse(dr(Entidades.CompraImpuesto.Columnas.NumeroComprobante.ToString()).ToString())
         .IdProveedor = Long.Parse(dr(Entidades.CompraImpuesto.Columnas.IdProveedor.ToString()).ToString())
         .IdTipoImpuesto = dr(Entidades.CompraImpuesto.Columnas.IdTipoImpuesto.ToString()).ToString()
         .Orden = Integer.Parse(dr(Entidades.CompraImpuesto.Columnas.Orden.ToString()).ToString())
         .IdProvincia = dr(Entidades.CompraImpuesto.Columnas.IdProvincia.ToString()).ToString()
         .NombreProvincia = dr(Entidades.Provincia.Columnas.NombreProvincia.ToString()).ToString()

         If Not String.IsNullOrWhiteSpace(dr(Entidades.CompraImpuesto.Columnas.Emisor.ToString()).ToString()) Then
            .Emisor = Integer.Parse(dr(Entidades.CompraImpuesto.Columnas.Emisor.ToString()).ToString())
         End If
         If Not String.IsNullOrWhiteSpace(dr(Entidades.CompraImpuesto.Columnas.Numero.ToString()).ToString()) Then
            .Numero = Long.Parse(dr(Entidades.CompraImpuesto.Columnas.Numero.ToString()).ToString())
         End If

         .Bruto = Decimal.Parse(dr(Entidades.CompraImpuesto.Columnas.Bruto.ToString()).ToString())
         .BaseImponible = Decimal.Parse(dr(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString()).ToString())
         .Alicuota = Decimal.Parse(dr(Entidades.CompraImpuesto.Columnas.Alicuota.ToString()).ToString())
         .Importe = Decimal.Parse(dr(Entidades.CompraImpuesto.Columnas.Importe.ToString()).ToString())

         .EsDespacho = Boolean.Parse(dr(Entidades.CompraImpuesto.Columnas.EsDespacho.ToString()).ToString())

         .NombreProveedor = dr(Entidades.Proveedor.Columnas.NombreProveedor.ToString()).ToString()
         .NombreTipoImpuesto = dr(Entidades.TipoImpuesto.Columnas.NombreTipoImpuesto.ToString()).ToString()
         .TipoTipoImpuesto = dr("TipoTipoImpuesto").ToString()
      End With
   End Sub

   Public Function GetUno(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          numeroComprobante As Long,
                          idProveedor As Long,
                          orden As Integer) As Entidades.CompraImpuesto
      Dim dt As DataTable = New SqlServer.ComprasImpuestos(da).ComprasImpuestos_G1(idSucursal, idTipoComprobante, letra, centroEmisor,
                                                                                   numeroComprobante, idProveedor, orden)

      Dim oCon As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
      If dt.Rows.Count > 0 Then
         CargaUno(oCon, dt.Rows(0))
      End If
      Return oCon
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            numeroComprobante As Long,
                            idProveedor As Long) As List(Of Entidades.CompraImpuesto)
      Dim result As List(Of Entidades.CompraImpuesto) = New List(Of Entidades.CompraImpuesto)()
      For Each dr As DataRow In New SqlServer.ComprasImpuestos(da).ComprasImpuestos_GA(idSucursal, idTipoComprobante, letra, centroEmisor,
                                                                                       numeroComprobante, idProveedor).Rows
         Dim o As Entidades.CompraImpuesto = New Entidades.CompraImpuesto()
         CargaUno(o, dr)
         result.Add(o)
      Next
      Return result
   End Function

   Public Function GetTodasLasProvincias() As DataTable
      Return TiparDataTable(New SqlServer.ComprasImpuestos(da).ComprasImpuestos_GA_TotasLasProvincias())
   End Function

   Private Function TiparDataTable(dtOrigen As DataTable) As DataTable
      Dim dtResult As DataTable = New DataTable()

      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.IdSucursal.ToString(), GetType(Integer))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.IdTipoComprobante.ToString(), GetType(String))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.Letra.ToString(), GetType(String))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.CentroEmisor.ToString(), GetType(Integer))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.NumeroComprobante.ToString(), GetType(Long))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.IdProveedor.ToString(), GetType(Long))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.IdTipoImpuesto.ToString(), GetType(String))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.Orden.ToString(), GetType(Integer))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.IdProvincia.ToString(), GetType(String))
      dtResult.Columns.Add(Entidades.Provincia.Columnas.NombreProvincia.ToString(), GetType(String))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.Emisor.ToString(), GetType(Integer))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.Numero.ToString(), GetType(Long))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.Bruto.ToString(), GetType(Decimal))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.BaseImponible.ToString(), GetType(Decimal))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.Alicuota.ToString(), GetType(Decimal))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.Importe.ToString(), GetType(Decimal))
      dtResult.Columns.Add(Entidades.CompraImpuesto.Columnas.EsDespacho.ToString(), GetType(Boolean))

      For Each drOrigen As DataRow In dtOrigen.Rows
         Dim drResult As DataRow = dtResult.NewRow
         For Each dcResult As DataColumn In dtResult.Columns
            drResult(dcResult.ColumnName) = drOrigen(dcResult.ColumnName)
         Next
         dtResult.Rows.Add(drResult)
      Next

      Return dtResult
   End Function
   Public Function GetPercepcionesParaInforme(sucursales As Entidades.Sucursal(),
                                              FechaDesde As Date,
                                              FechaHasta As Date,
                                              IdTipoImpuesto As String,
                                              IdProveedor As Long,
                                              aplicativoAFIP As String,
                                              periodoFiscal As Integer) As DataTable
      Return New SqlServer.ComprasImpuestos(Me.da).ComprasImpuestos_G_Informe(sucursales, FechaDesde, FechaHasta, IdTipoImpuesto, IdProveedor, "PERCEPCION", aplicativoAFIP, periodoFiscal)
   End Function

#End Region

End Class

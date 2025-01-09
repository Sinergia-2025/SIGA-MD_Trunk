Option Explicit On
Option Strict On
Public Class CategoriasFiscales
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CategoriasFiscales"
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
      Dim sql As SqlServer.CategoriasFiscales = New SqlServer.CategoriasFiscales(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString(), actual.Sucursal.IdEmpresa)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CategoriasFiscales(Me.da).CategoriasFiscales_GA(actual.Sucursal.IdEmpresa)
   End Function

   Private Function GetAll2(SoloActivos As Boolean) As System.Data.DataTable
      Return New SqlServer.CategoriasFiscales(Me.da).CategoriasFiscales_GA(SoloActivos, actual.Sucursal.IdEmpresa)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.CategoriaFiscal = DirectCast(entidad, Entidades.CategoriaFiscal)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.CategoriasFiscales = New SqlServer.CategoriasFiscales(Me.da)
         Dim rCFC As Reglas.CategoriasFiscalesConfiguraciones = New CategoriasFiscalesConfiguraciones(da)

         Select Case tipo

            Case TipoSP._I
               sql.CategoriasFiscales_I(en.IdCategoriaFiscal, en.NombreCategoriaFiscal, en.NombreCategoriaFiscalAbrev, en.UtilizaImpuestos,
                                        en.CondicionIvaImpresoraFiscalEpson, en.CondicionIvaImpresoraFiscalHasar,
                                        en.Activo, en.SolicitaCUIT, en.EsPasiblePercIIBB, en.UtilizaAlicuota2Producto, en.CodigoExportacion,
                                        en.LeyendaCategoriaFiscal, en.IvaCeroCategoriaFiscal)
               rCFC._Merge(en)

            Case TipoSP._U
               sql.CategoriasFiscales_U(en.IdCategoriaFiscal, en.NombreCategoriaFiscal, en.NombreCategoriaFiscalAbrev, en.UtilizaImpuestos,
                                        en.CondicionIvaImpresoraFiscalEpson, en.CondicionIvaImpresoraFiscalHasar,
                                        en.Activo, en.SolicitaCUIT, en.EsPasiblePercIIBB, en.UtilizaAlicuota2Producto, en.CodigoExportacion,
                                        en.LeyendaCategoriaFiscal, en.IvaCeroCategoriaFiscal)
               rCFC._Merge(en)

            Case TipoSP._D
               rCFC._Borrar(New Entidades.CategoriaFiscalConfiguracion() With {.IdCategoriaFiscalCliente = en.IdCategoriaFiscal})
               sql.CategoriasFiscales_D(en.IdCategoriaFiscal)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex

      Finally
         da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CategoriaFiscal, ByVal dr As DataRow)

      With o
         .IdCategoriaFiscal = Short.Parse(dr(Entidades.CategoriaFiscal.Columnas.IdCategoriaFiscal.ToString()).ToString())
         .NombreCategoriaFiscal = dr(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscal.ToString()).ToString()
         .NombreCategoriaFiscalAbrev = dr(Entidades.CategoriaFiscal.Columnas.NombreCategoriaFiscalAbrev.ToString()).ToString()
         .LetraFiscal = dr(Entidades.CategoriaFiscal.Columnas.LetraFiscal.ToString()).ToString()
         .LetraFiscalCompra = dr(Entidades.CategoriaFiscal.Columnas.LetraFiscalCompra.ToString()).ToString()
         .IvaDiscriminado = Boolean.Parse(dr(Entidades.CategoriaFiscal.Columnas.IvaDiscriminado.ToString()).ToString())
         .UtilizaImpuestos = Boolean.Parse(dr(Entidades.CategoriaFiscal.Columnas.UtilizaImpuestos.ToString()).ToString())
         .CondicionIvaImpresoraFiscalEpson = dr(Entidades.CategoriaFiscal.Columnas.CondicionIvaImpresoraFiscalEpson.ToString()).ToString()
         .CondicionIvaImpresoraFiscalHasar = dr(Entidades.CategoriaFiscal.Columnas.CondicionIvaImpresoraFiscalHasar.ToString()).ToString()
         .Activo = Boolean.Parse(dr(Entidades.CategoriaFiscal.Columnas.Activo.ToString()).ToString())
         .SolicitaCUIT = Boolean.Parse(dr(Entidades.CategoriaFiscal.Columnas.SolicitaCUIT.ToString()).ToString())
         .EsPasiblePercIIBB = Boolean.Parse(dr(Entidades.CategoriaFiscal.Columnas.EsPasiblePercIIBB.ToString()).ToString())
         .UtilizaAlicuota2Producto = Boolean.Parse(dr(Entidades.CategoriaFiscal.Columnas.UtilizaAlicuota2Producto.ToString()).ToString())
         .CodigoExportacion = dr.Field(Of String)(Entidades.CategoriaFiscal.Columnas.CodigoExportacion.ToString())
         .LeyendaCategoriaFiscal = dr.Field(Of String)(Entidades.CategoriaFiscal.Columnas.LeyendaCategoriaFiscal.ToString())
         .IvaCeroCategoriaFiscal = dr.Field(Of String)(Entidades.CategoriaFiscal.Columnas.IvaCeroCategoriaFiscal.ToString())
      End With

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.CategoriaFiscal)
      Dim dt As DataTable = Me.GetAll2(True)
      Dim o As Entidades.CategoriaFiscal
      Dim oLis As List(Of Entidades.CategoriaFiscal) = New List(Of Entidades.CategoriaFiscal)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CategoriaFiscal()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal IdCategoriaFiscal As Short) As Entidades.CategoriaFiscal
      Return Me._GetUno(IdCategoriaFiscal)
   End Function

   Public Function _GetUno(IdCategoriaFiscal As Short) As Entidades.CategoriaFiscal
      Dim sql As SqlServer.CategoriasFiscales = New SqlServer.CategoriasFiscales(Me.da)
      Dim dt As DataTable = sql.CategoriasFiscales_G1(IdCategoriaFiscal, actual.Sucursal.IdEmpresa)
      Dim o As Entidades.CategoriaFiscal = New Entidades.CategoriaFiscal()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe la Categoria Fiscal.")
      End If
      Return o
   End Function

   Public Function Get1(idCategoriaFiscal As Short) As DataTable
      Dim sql As SqlServer.CategoriasFiscales = New SqlServer.CategoriasFiscales(Me.da)
      Return sql.CategoriasFiscales_G1(IdCategoriaFiscal, actual.Sucursal.IdEmpresa)
   End Function

   Public Function GetCodigoMaximo() As Short

      Dim sql As SqlServer.CategoriasFiscales = New SqlServer.CategoriasFiscales(Me.da)
      Dim dt As DataTable = sql.CategoriasFiscales_GetCodigoMaximo()
      Dim val As Short = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Short.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function
   Public Function GetPorId(idCategoria As Integer) As DataTable
      Return New SqlServer.CategoriasFiscales(da).Categorias_G1(idCategoria, ceroTodos:=True, actual.Sucursal.IdEmpresa)
   End Function

   Public Function GetPorNombreLike(nombre As String) As DataTable
      Return New SqlServer.CategoriasFiscales(da).Categorias_G_PorNombre(nombre, False, actual.Sucursal.IdEmpresa)
   End Function

   Public Function GetPorNombreExacto(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT IdCategoriaFiscal,")
         .AppendLine("       NombreCategoriaFiscal,")
         .AppendLine("       SolicitaCUIT")
         .AppendLine("  FROM CategoriasFiscales")
         .AppendLine(" WHERE NombreCategoriaFiscal = '" & nombre & "' ")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function
#End Region

End Class
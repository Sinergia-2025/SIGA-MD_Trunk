Option Explicit On
Option Strict On

Imports System.Text
Imports actual = Eniac.Entidades.Usuario.Actual
Imports Eniac.Reglas
Imports Eniac.Entidades

Public Class FichasProductos
    Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      MyBase.New()
      Me.NombreEntidad = "FichasProductos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos"

   Friend Function GetUna(ByVal idSucursal As Int32, _
                        ByVal nroOperacion As Integer, _
                        ByVal IdCliente As Long) _
                        As System.Collections.Generic.List(Of Eniac.Entidades.FichaProducto)
      Dim stbQuery As StringBuilder = New StringBuilder("")
      Dim fps As System.Collections.Generic.List(Of Eniac.Entidades.FichaProducto) = New System.Collections.Generic.List(Of Eniac.Entidades.FichaProducto)
      Dim fp As Eniac.Entidades.FichaProducto
      With stbQuery
         .Append(" SELECT * ")
         .Append(" FROM FichasProductos FP ")
         .Append(" WHERE FP.IdCliente = " & IdCliente.ToString())
         .Append(" AND FP.NroOperacion = " & nroOperacion.ToString())
         .Append(" AND FP.IdSucursal = " & idSucursal.ToString())
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())
      For Each dr As DataRow In dt.Rows
         fp = New Eniac.Entidades.FichaProducto(actual.Sucursal.Id, actual.Nombre, actual.Pwd)
         fp.IdProducto = dr("IdProducto").ToString().Trim().Trim()
         fp.IdSucursal = Int32.Parse(dr("IdSucursal").ToString())
         fp.NroOperacion = Int32.Parse(dr("NroOperacion").ToString())
         fp.IdCliente = Long.Parse(dr("IdCliente").ToString())
         fp.Cantidad = Int32.Parse(dr("Cantidad").ToString())
         fp.Precio = Decimal.Parse(dr("Precio").ToString())
         fp.FechaEntrega = DateTime.Parse(dr("FechaEntrega").ToString())
         fp.Garantia = Int32.Parse(dr("Garantia").ToString())
         If Not String.IsNullOrEmpty(dr("IdProveedor").ToString()) Then
            fp.Proveedor = New Proveedores(Me.da)._GetUno(Long.Parse(dr("IdProveedor").ToString()))
         End If
         fps.Add(fp)
      Next
      Return fps
   End Function
   Friend Sub GrabaFichaProductos(ByVal ent As Eniac.Entidades.FichaProducto)

      If ent.FechaEntrega = Nothing Then
         ent.FechaEntrega = New DateTime(1899, 1, 1)
      End If

      Dim sql As SqlServer.FichasProductos = New SqlServer.FichasProductos(Me.da)
      sql.FichasProductos_I(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, ent.IdProducto.Trim(), ent.Cantidad, _
         ent.Precio, ent.FechaEntrega, ent.Garantia, ent.Proveedor.IdProveedor)
   End Sub

   Friend Sub BorraFichaProductos(ByVal ent As Eniac.Entidades.FichaProducto)
      Dim sql As SqlServer.FichasProductos = New SqlServer.FichasProductos(Me.da)
      sql.FichasProductos_D(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, ent.IdProducto.Trim())
   End Sub

   Public Sub ActualizarFechaEntrega(ByVal ent As Eniac.Entidades.FichaProducto)
      Try
         da.OpenConection()
         da.BeginTransaction()

         If ent.FechaEntrega = Nothing Then
            ent.FechaEntrega = New DateTime(1899, 1, 1)
         End If

         Dim sql As SqlServer.FichasProductos = New SqlServer.FichasProductos(Me.da)
         sql.FichasProductos_UFechaEntrega(ent.IdSucursal, ent.NroOperacion, ent.IdCliente, ent.IdProducto.Trim(), ent.FechaEntrega)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim ent As Eniac.Entidades.FichaProducto = DirectCast(entidad, Eniac.Entidades.FichaProducto)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.GrabaFichaProductos(ent)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim fp As Eniac.Entidades.FichaProducto = DirectCast(entidad, Eniac.Entidades.FichaProducto)
      Dim da As Datos.DataAccess = New Datos.DataAccess()
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.BorraFichaProductos(fp)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Publicos"

   Public Function GetProductosFichas(ByVal idSucursal As Int32, ByVal nroOperacion As Integer, ByVal IdCliente As Long) _
                        As System.Collections.Generic.List(Of Eniac.Entidades.Producto)

      Dim oProd As System.Collections.Generic.List(Of Eniac.Entidades.Producto) = New System.Collections.Generic.List(Of Eniac.Entidades.Producto)
      Dim prod As Eniac.Entidades.Producto
      Dim produc As Eniac.Reglas.Productos = New Eniac.Reglas.Productos()
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append(" select p.idproducto from fichasproductos fp ")
         .Append(" inner join productos p on fp.idproducto = p.idproducto")
         .AppendFormat(" where fp.NroOperacion = {0}", nroOperacion)
         .AppendFormat(" and fp.IdCliente = {0}", IdCliente)
         .AppendFormat("and fp.idsucursal = {0}", idSucursal)
      End With
      Dim dt As DataTable = da.GetDataTable(stb.ToString())
      For Each dr As DataRow In dt.Rows
         prod = produc.GetUno(dr("idproducto").ToString())
         oProd.Add(prod)
      Next
      Return oProd


   End Function



#End Region

End Class

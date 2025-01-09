Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Datos
Imports actual = Eniac.Entidades.Usuario.Actual

#End Region

Public Class RecepcionNotasF
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "RecepcionNotasF"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim nota As Entidades.RecepcionNotaF = DirectCast(entidad, Entidades.RecepcionNotaF)
         nota.NroNota = Me.GetUltimoNroNotaRecepcion(actual.Sucursal.IdSucursal) + 1

         Me.EjecutaSP(nota, TipoSP._I)

         Dim est As Entidades.RecepcionNotaEstadoF = New Entidades.RecepcionNotaEstadoF()
         With est
            .IdSucursal = nota.IdSucursal
            .Nota.NroNota = nota.NroNota
            .Estado = nota.Estado
            .FechaEstado = nota.FechaNota
            .Observacion = nota.Observacion
            .Usuario = nota.Usuario
         End With

         Dim estado As Reglas.RecepcionNotasEstadosF = New Reglas.RecepcionNotasEstadosF(da)
         estado.EjecutaSP(est, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         'Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim nota As Entidades.RecepcionNotaF = DirectCast(entidad, Entidades.RecepcionNotaF)
         Select Case nota.Modo
            Case Entidades.Modos.DevolverProducto
               Me.GrabaDevolucion(nota)
            Case Entidades.Modos.PrestarProducto
               Me.GrabaPrestamo(nota)
            Case Entidades.Modos.Ninguno
               Me.EjecutaSP(nota, TipoSP._U)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   'Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataSet
   '   Dim stbQuery As StringBuilder = New StringBuilder("")
   '   With stbQuery
   '      .Append(" SELECT ")
   '      .Append(" IdSector ")
   '      .Append(", NombreSector ")
   '      .Append(", LetraSector ")
   '      .Append("FROM  ")
   '      .Append("Sectores ")
   '      .Append("  WHERE ")
   '      .Append(entidad.Columna)
   '      .Append(" LIKE '%")
   '      .Append(entidad.Valor.ToString())
   '      .Append("%'")
   '   End With
   '   Return Me.DataServer().GetDataSet(stbQuery.ToString())
   'End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal nota As Entidades.RecepcionNotaF, ByVal tipo As TipoSP)

      Dim sql As SqlServer.RecepcionNotasF = New SqlServer.RecepcionNotasF(Me.da)

      Select Case tipo

         Case TipoSP._I
            sql.RecepcionNotasF_I(nota.IdSucursal, nota.NroNota, nota.Cliente.IdCliente, _
                                 nota.Ficha.NroOperacion, nota.Producto.IdProducto, nota.FechaNota, nota.CantidadProductos, _
                                 nota.CostoReparacion, nota.DefectoProducto, nota.Observacion, nota.EstaPrestado, nota.Usuario)


         Case TipoSP._U
            sql.RecepcionNotasF_U(nota.IdSucursal, nota.NroNota, nota.Cliente.IdCliente, _
                                 nota.Ficha.NroOperacion, nota.Producto.IdProducto, nota.FechaNota, nota.CantidadProductos, _
                                 nota.CostoReparacion, nota.DefectoProducto, nota.Observacion, nota.EstaPrestado, nota.Usuario)

         Case TipoSP._D

      End Select

   End Sub

   Private Sub GrabaPrestamo(ByVal nota As Entidades.RecepcionNotaF)

      Dim sql As SqlServer.RecepcionNotasF = New SqlServer.RecepcionNotasF(Me.da)
      sql.RecepcionNotasF_UPrestamo(nota.IdSucursal, nota.NroNota, nota.ProductoPrestado.IdProducto, nota.CantidadPrestada, nota.ObservacionPrestamo, True, nota.Usuario)

   End Sub

   Private Sub GrabaDevolucion(ByVal nota As Entidades.RecepcionNotaF)

      Dim sql As SqlServer.RecepcionNotasF = New SqlServer.RecepcionNotasF(Me.da)
      sql.RecepcionNotasF_UDevolucion(nota.IdSucursal, nota.NroNota, nota.ObservacionPrestamo, False, nota.Usuario)

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.RecepcionNotaF, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr("IdSucursal").ToString())
         .NroNota = Integer.Parse(dr("NroNota").ToString())
         .FechaNota = Date.Parse(dr("FechaNota").ToString())
         .Producto = New Eniac.Reglas.Productos(da).GetUno(dr("IdProducto").ToString())
         .CantidadProductos = Decimal.Parse(dr("CantidadProductos").ToString())
         .CostoReparacion = Decimal.Parse(dr("CostoReparacion").ToString())
         .DefectoProducto = dr("DefectoProducto").ToString()
         .Observacion = dr("Observacion").ToString()
         .Cliente = New Eniac.Reglas.Clientes(da).GetUno(Long.Parse(dr("IdCliente").ToString()))
         .Ficha = New Eniac.Reglas.Fichas(da).GetUna(Long.Parse(dr("IdCliente").ToString()), Integer.Parse(dr("NroOperacion").ToString()), Integer.Parse(dr("IdSucursal").ToString()))
         If Not String.IsNullOrEmpty(dr("IdProductoPrestado").ToString()) Then
            .ProductoPrestado = New Eniac.Reglas.Productos().GetUno(dr("IdProductoPrestado").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("CantidadPrestada").ToString()) Then
            .CantidadPrestada = Decimal.Parse(dr("CantidadPrestada").ToString())
         End If
         .ObservacionPrestamo = dr("ObservacionPrestamo").ToString()
         If Not String.IsNullOrEmpty(dr("EstaPrestado").ToString()) Then
            .EstaPrestado = Boolean.Parse(dr("EstaPrestado").ToString())
         End If
         .Usuario = dr("Usuario").ToString()
      End With
   End Sub

   Private Function GetUltimoNroNotaRecepcion(ByVal IdSucursal As Integer) As Integer
      Dim stb As StringBuilder = New StringBuilder("")
      With stb
         .Append("SELECT max(NroNota) as Nro")
         .Append(" FROM RecepcionNotasF")
         .Append(" WHERE IdSucursal = " & IdSucursal.ToString())
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Nro").ToString()) Then
            Return Integer.Parse(dt.Rows(0)("Nro").ToString())
         End If
      End If
      Return 0
   End Function

#End Region

#Region "Metodos Publicos"

   Public Function ExisteLaNota(ByVal idSucursal As Integer, _
                                ByVal IdCliente As Long, _
                                ByVal nroOperacion As Integer, _
                                ByVal idProducto As String) As Boolean

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append(" SELECT NroNota")
         .Append(" FROM RecepcionNotasF")
         .AppendFormat(" WHERE NroOperacion = {0}", nroOperacion)
         .AppendFormat(" AND IdCliente = {0}", IdCliente)
         .AppendFormat(" AND IdSucursal = {0}", idSucursal)
         .AppendFormat(" AND IdProducto = '{0}'", idProducto)
      End With
      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      If dt.Rows.Count > 0 Then
         Return True
      End If
      Return False
   End Function

   Public Function GetTodos() As List(Of Entidades.RecepcionNotaF)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.RecepcionNotaF
      Dim oLis As List(Of Entidades.RecepcionNotaF) = New List(Of Entidades.RecepcionNotaF)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.RecepcionNotaF()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal idSucursal As Integer, ByVal nroNota As Integer) As Entidades.RecepcionNotaF

      Dim stb As StringBuilder = New StringBuilder("")
      Dim dt As DataTable = New DataTable()

      With stb
         .Append("SELECT IdSucursal")
         .Append("      ,NroNota")
         .Append("      ,NroOperacion")
         .Append("      ,IdCliente")
         .Append("      ,IdProducto")
         .Append("      ,FechaNota")
         .Append("      ,CantidadProductos")
         .Append("      ,CostoReparacion")
         .Append("      ,DefectoProducto")
         .Append("      ,Observacion")
         .Append("      ,IdProductoPrestado")
         .Append("      ,CantidadPrestada")
         .Append("      ,ObservacionPrestamo")
         .Append("      ,EstaPrestado")
         .Append("      ,Usuario")
         .Append("  FROM RecepcionNotasF")
         .AppendFormat("  WHERE idSucursal = {0}", idSucursal)
         .AppendFormat("    AND NroNota = {0}", nroNota)
      End With

      dt = Me.da.GetDataTable(stb.ToString())

      Dim o As Entidades.RecepcionNotaF = New Entidades.RecepcionNotaF()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el estado.")
      End If
      Return o
   End Function

#End Region

End Class

Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Datos

#End Region

Public Class RecepcionNotasProveedores
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "RecepcionNotasProveedoresV"
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
         Dim nota As Entidades.RecepcionNotaProveedor

         da.OpenConection()
         da.BeginTransaction()

         'Inserto el proveedor en la tabla RecepcionNotaProveedor
         nota = DirectCast(entidad, Entidades.RecepcionNotaProveedor)
         Me.EjecutaSP(nota, TipoSP._I)

         'preparo e inserto el estado de la nota de recepcion
         Dim re As Entidades.RecepcionNotaEstado = New Entidades.RecepcionNotaEstado()
         With re
            .Nota = nota.Nota
            'pongo a la nota en estado 2 que es "En Service"
            .Estado = New Reglas.RecepcionEstados(da).GetUno(20)
            .IdSucursal = nota.IdSucursal
            .Observacion = nota.Observacion
            .FechaEstado = nota.FechaEntrega
            .Usuario = nota.Usuario
         End With
         Dim est As Reglas.RecepcionNotasEstados = New Reglas.RecepcionNotasEstados(da)
         est.EjecutaSP(re, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append(" SELECT ")
         .Append(" IdSector ")
         .Append(", NombreSector ")
         .Append(", LetraSector ")
         .Append("FROM  ")
         .Append("Sectores ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

#End Region

#Region "Metodos Privados"

   Friend Sub EjecutaSP(ByVal nota As Entidades.RecepcionNotaProveedor, ByVal tipo As TipoSP)
      Dim sql As SqlServer.RecepcionNotasProveedores = New SqlServer.RecepcionNotasProveedores(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.RecepcionNotasProveedores_I(nota.IdSucursal, nota.Nota.NroNota, nota.Proveedor.IdProveedor, nota.FechaEntrega, nota.Observacion, nota.Usuario)
         Case TipoSP._U
         Case TipoSP._D

      End Select

   End Sub

   'Private Sub CargarUno(ByVal o As Entidades.RecepcionNotaProveedorV, ByVal dr As DataRow)
   '   With o
   '      .Nota = New Reglas.RecepcionNotasV(da).GetUno(Integer.Parse(dr("NroNota").ToString()))
   '      .FechaEntrega = Date.Parse(dr("FechaEntrega").ToString())
   '   End With
   'End Sub

#End Region

#Region "Metodos Publicos"

   'Public Function GetTodos() As List(Of Entidades.RecepcionNotaProveedorV)
   '   Dim dt As DataTable = Me.GetAll()
   '   Dim o As Entidades.RecepcionNotaProveedorV
   '   Dim oLis As List(Of Entidades.RecepcionNotaProveedorV) = New List(Of Entidades.RecepcionNotaProveedorV)
   '   For Each dr As DataRow In dt.Rows
   '      o = New Entidades.RecepcionNotaProveedorV()
   '      Me.CargarUno(o, dr)
   '      oLis.Add(o)
   '   Next
   '   Return oLis
   'End Function

   'Public Function GetUno(ByVal idEstado As String) As Entidades.RecepcionNotaProveedorV
   '   Dim stb As StringBuilder = New StringBuilder("")
   '   With stb
   '      .Append("SELECT IdEstado")
   '      .Append("      ,NombreEstado")
   '      .Append("  FROM RecepcionEstadosF")
   '      .Append("  WHERE IdEstado = '")
   '      .Append(idEstado)
   '      .Append("'")
   '   End With
   '   Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())

   '   Dim o As Entidades.RecepcionNotaProveedorV = New Entidades.RecepcionNotaProveedorV()
   '   If dt.Rows.Count > 0 Then
   '      Me.CargarUno(o, dt.Rows(0))
   '   Else
   '      Throw New Exception("No existe la nota de proveedor.")
   '   End If
   '   Return o
   'End Function

#End Region

End Class

Option Explicit On
Option Strict On
Imports System.Text
Public Class OrdenesProduccionObservaciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "OrdenesProduccionObservaciones"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Inserta(DirectCast(entidad, Entidades.OrdenProduccionObservacion))
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()
         Borra(DirectCast(entidad, Entidades.OrdenProduccionObservacion))
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub
   <Obsolete("Usar GetAll(Integer, String, String, Integer, Long", True)>
   Public Overrides Function GetAll() As DataTable
      Return MyBase.GetAll()
   End Function
   Public Overloads Function GetAll(idSucursal As Integer,
                                    idTipoComprobante As String,
                                    letra As String,
                                    centroEmisor As Integer,
                                    NumeroOrdenProduccion As Long) As DataTable
      Return New SqlServer.OrdenesProduccionObservaciones(da).OrdenesProduccionObservaciones_GA(idSucursal,
                                                                            idTipoComprobante,
                                                                            letra,
                                                                            centroEmisor,
                                                                            NumeroOrdenProduccion)
   End Function
#End Region

#Region "Metodos"

   Public Sub Inserta(ByVal entidad As Eniac.Entidades.OrdenProduccionObservacion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub Borra(ByVal entidad As Eniac.Entidades.OrdenProduccionObservacion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub Borra(ByVal OrdenProduccion As Eniac.Entidades.OrdenProduccion)
      Dim sql As SqlServer.OrdenesProduccionObservaciones = New SqlServer.OrdenesProduccionObservaciones(Me.da)
      sql.OrdenesProduccionObservaciones_D(OrdenProduccion.IdSucursal, OrdenProduccion.IdTipoComprobante, OrdenProduccion.LetraComprobante, OrdenProduccion.CentroEmisor, OrdenProduccion.NumeroOrdenProduccion, 0)
   End Sub

   Public Sub InsertaObservacionesDesdeOrdenProduccion(ByVal oOrdenProduccions As Entidades.OrdenProduccion)

      Dim orden As Integer = 0
      For Each observacion As Entidades.OrdenProduccionObservacion In oOrdenProduccions.OrdenesProduccionObservaciones
         orden += 1
         observacion.IdSucursal = oOrdenProduccions.IdSucursal
         observacion.IdTipoComprobante = oOrdenProduccions.IdTipoComprobante
         observacion.Letra = oOrdenProduccions.LetraComprobante
         observacion.CentroEmisor = oOrdenProduccions.CentroEmisor
         observacion.NumeroOrdenProduccion = oOrdenProduccions.NumeroOrdenProduccion
         observacion.Linea = orden
         Inserta(observacion)
      Next
   End Sub

   Friend Sub EjecutaSP(ByVal ent As Entidades.OrdenProduccionObservacion, ByVal tipo As TipoSP)
      Dim sql As SqlServer.OrdenesProduccionObservaciones = New SqlServer.OrdenesProduccionObservaciones(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.OrdenesProduccionObservaciones_I(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroOrdenProduccion, ent.Linea, ent.Observacion)

            'Case TipoSP._U

         Case TipoSP._D
            sql.OrdenesProduccionObservaciones_D(ent.IdSucursal, ent.IdTipoComprobante, ent.Letra, ent.CentroEmisor, ent.NumeroOrdenProduccion, 0)
      End Select
   End Sub

   Private Sub CargarUna(ByVal o As Entidades.OrdenProduccionObservacion, ByVal dr As DataRow)
      With o
         .IdSucursal = Int32.Parse(dr(Entidades.OrdenProduccionObservacion.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.OrdenProduccionObservacion.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.OrdenProduccionObservacion.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.OrdenProduccionObservacion.Columnas.Linea.ToString()).ToString())
         .NumeroOrdenProduccion = Long.Parse(dr(Entidades.OrdenProduccionObservacion.Columnas.NumeroOrdenProduccion.ToString()).ToString())
         .Linea = Integer.Parse(dr(Entidades.OrdenProduccionObservacion.Columnas.Linea.ToString()).ToString())
         .Observacion = dr(Entidades.OrdenProduccionObservacion.Columnas.Observacion.ToString()).ToString()
      End With
   End Sub

   Public Function GetUna(idSucursal As Integer,
                          idTipoComprobante As String,
                          letra As String,
                          centroEmisor As Integer,
                          NumeroOrdenProduccion As Long,
                          linea As Integer) As Entidades.OrdenProduccionObservacion
      Dim sql As SqlServer.OrdenesProduccionObservaciones = New SqlServer.OrdenesProduccionObservaciones(da)

      Dim dt As DataTable = sql.OrdenesProduccionObservaciones_G1(idSucursal,
                                                        idTipoComprobante,
                                                        letra,
                                                        centroEmisor,
                                                        NumeroOrdenProduccion,
                                                        linea)
      If dt.Rows.Count > 0 Then
         Dim o As Entidades.OrdenProduccionObservacion = New Entidades.OrdenProduccionObservacion()
         CargarUna(o, dt.Rows(0))
         Return o
      Else
         Throw New Exception("No existe la Observación del OrdenProduccion.")
      End If
   End Function

   Public Function GetTodos(idSucursal As Integer,
                            idTipoComprobante As String,
                            letra As String,
                            centroEmisor As Integer,
                            NumeroOrdenProduccion As Long) As List(Of Entidades.OrdenProduccionObservacion)
      Dim lst As List(Of Entidades.OrdenProduccionObservacion) = New List(Of Entidades.OrdenProduccionObservacion)()

      Dim dt As DataTable = GetAll(idSucursal,
                                   idTipoComprobante,
                                   letra,
                                   centroEmisor,
                                   NumeroOrdenProduccion)
      For Each dr As DataRow In dt.Rows
         Dim o As Entidades.OrdenProduccionObservacion = New Entidades.OrdenProduccionObservacion()
         CargarUna(o, dr)
         lst.Add(o)
      Next
      Return lst
   End Function
#End Region

End Class
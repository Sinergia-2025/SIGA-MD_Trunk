Option Strict On
Option Explicit On
Public Class VentasAdjuntos
   Inherits Eniac.Reglas.Base
   Implements IReglaAdjuntos

   Private Property NombreBaseAdjuntos As String

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "VentasAdjuntos"
      da = accesoDatos
      NombreBaseAdjuntos = Reglas.Publicos.NombreBaseAdjuntos(da)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Inserta(entidad)

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

         Borra(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.VentasAdjuntos = New SqlServer.VentasAdjuntos(Me.da, NombreBaseAdjuntos)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString(), incluirAdjunto:=False) 'Buscar siempre se ejecuta desde las grillas ABM, por lo que es sin el Byte()
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.VentasAdjuntos(Me.da, NombreBaseAdjuntos).VentasAdjuntos_GA(incluirAdjunto:=False)   'Generalmente se ejecuta desde las grillas ABM, por lo que es sin el Byte()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.VentaAdjunto = DirectCast(entidad, Entidades.VentaAdjunto)

      Dim sqlC As SqlServer.VentasAdjuntos = New SqlServer.VentasAdjuntos(da, NombreBaseAdjuntos)
      Select Case tipo
         Case TipoSP._I
            sqlC.VentasAdjuntos_I(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdVentaAdjunto, en.IdProducto, en.Orden, en.IdTipoAdjunto, en.NombreAdjunto, en.Adjunto, en.Observaciones, en.NivelAutorizacion)
         Case TipoSP._U
            sqlC.VentasAdjuntos_U(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdVentaAdjunto, en.IdTipoAdjunto, en.NombreAdjunto, en.Observaciones, en.NivelAutorizacion)
         Case TipoSP._D
            sqlC.VentasAdjuntos_D(en.IdSucursal, en.IdTipoComprobante, en.Letra, en.CentroEmisor, en.NumeroComprobante, en.IdVentaAdjunto)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.VentaAdjunto, ByVal dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Entidades.VentaAdjunto.Columnas.IdSucursal.ToString()).ToString())
         .IdTipoComprobante = dr(Entidades.VentaAdjunto.Columnas.IdTipoComprobante.ToString()).ToString()
         .Letra = dr(Entidades.VentaAdjunto.Columnas.Letra.ToString()).ToString()
         .CentroEmisor = Short.Parse(dr(Entidades.VentaAdjunto.Columnas.CentroEmisor.ToString()).ToString())
         .NumeroComprobante = Long.Parse(dr(Entidades.VentaAdjunto.Columnas.NumeroComprobante.ToString()).ToString())
         .IdVentaAdjunto = Long.Parse(dr(Entidades.VentaAdjunto.Columnas.IdVentaAdjunto.ToString()).ToString())

         .IdProducto = dr(Entidades.VentaAdjunto.Columnas.IdProducto.ToString()).ToString()
         If IsNumeric(dr(Entidades.VentaAdjunto.Columnas.Orden.ToString())) Then
            .Orden = Integer.Parse(dr(Entidades.VentaAdjunto.Columnas.Orden.ToString()).ToString())
         End If

         .IdTipoAdjunto = Integer.Parse(dr(Entidades.VentaAdjunto.Columnas.IdTipoAdjunto.ToString()).ToString())
         .NombreTipoAdjunto = dr(Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()).ToString()
         .NombreAdjunto = dr(Entidades.VentaAdjunto.Columnas.NombreAdjunto.ToString()).ToString()
         .Observaciones = dr(Entidades.VentaAdjunto.Columnas.Observaciones.ToString()).ToString()
         If Not IsDBNull(dr(Entidades.VentaAdjunto.Columnas.Adjunto.ToString())) Then
            .Adjunto = CType(dr(Entidades.VentaAdjunto.Columnas.Adjunto.ToString()), Byte())
         End If
         .NivelAutorizacion = Short.Parse(dr(Entidades.VentaAdjunto.Columnas.NivelAutorizacion.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Overloads Sub Inserta(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overloads Sub Actualiza(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overloads Sub Borra(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub ActualizaDesdeVentas(venta As Entidades.Venta)
      Try
         da.OpenConection()
         da.BeginTransaction()
         _ActualizaDesdeVentas(venta)
         da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw New Exception(ex.Message, ex)
      Finally
         da.CloseConection()
      End Try
   End Sub
   Friend Sub _ActualizaDesdeVentas(venta As Entidades.Venta)
      For Each adjunto As Entidades.VentaAdjunto In venta.VentasAdjuntos
         If adjunto.IdVentaAdjunto > 0 Then
            Actualiza(adjunto)
         Else
            adjunto.IdSucursal = venta.IdSucursal
            adjunto.IdTipoComprobante = venta.IdTipoComprobante
            adjunto.Letra = venta.LetraComprobante
            adjunto.CentroEmisor = venta.CentroEmisor
            adjunto.NumeroComprobante = venta.NumeroComprobante
            adjunto.IdVentaAdjunto = GetCodigoMaximo(venta.IdSucursal, venta.IdTipoComprobante, venta.LetraComprobante, venta.CentroEmisor, venta.NumeroComprobante) + 1

            Dim fi As IO.FileInfo = New IO.FileInfo(adjunto.NombreAdjuntoCompleto)
            If Not String.IsNullOrWhiteSpace(adjunto.NombreAdjuntoCompleto) AndAlso fi.Exists Then
               adjunto.Adjunto = IO.File.ReadAllBytes(adjunto.NombreAdjuntoCompleto)
            End If
            adjunto.NombreAdjunto = fi.Name
            Try
               Inserta(adjunto)
            Catch
               adjunto.IdVentaAdjunto = 0
               Throw
            End Try
         End If
      Next
      For Each adjunto As Entidades.VentaAdjunto In venta.VentasAdjuntos.Borrados
         If adjunto.IdVentaAdjunto > 0 Then
            Borra(adjunto)
         End If
      Next
   End Sub

   Public Function GetUno(idSucursal As Integer?, idTipoComprobante As String, letra As String, centroEmisor As Short?, numeroComprobante As Long?,
                          idVentaAdjunto As Long?, incluirAdjunto As Boolean) As Entidades.VentaAdjunto
      Dim dt As DataTable = New SqlServer.VentasAdjuntos(Me.da, NombreBaseAdjuntos).VentasAdjuntos_G1(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                                                                      idVentaAdjunto, incluirAdjunto, actual.NivelAutorizacion)
      Dim o As Entidades.VentaAdjunto = New Entidades.VentaAdjunto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idSucursal As Integer, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long,
                            incluirAdjunto As Boolean) As List(Of Entidades.VentaAdjunto)
      Dim dt As DataTable = New SqlServer.VentasAdjuntos(Me.da, NombreBaseAdjuntos).VentasAdjuntos_GA(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante,
                                                                                                      incluirAdjunto, actual.NivelAutorizacion)
      Dim o As Entidades.VentaAdjunto
      Dim oLis As List(Of Entidades.VentaAdjunto) = New List(Of Entidades.VentaAdjunto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.VentaAdjunto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Overloads Function GetCodigoMaximo(idSucursal As Long, idTipoComprobante As String, letra As String, centroEmisor As Short, numeroComprobante As Long) As Long
      Return New SqlServer.VentasAdjuntos(da, NombreBaseAdjuntos).GetCodigoMaximo(idSucursal, idTipoComprobante, letra, centroEmisor, numeroComprobante)
   End Function


#End Region


   Public Function GetOClonar(entidadOriginal As Entidades.IAdjunto) As Entidades.IAdjunto Implements IReglaAdjuntos.GetOClonar
      Dim va As Entidades.VentaAdjunto = DirectCast(entidadOriginal, Entidades.VentaAdjunto)
      Dim copia As Entidades.VentaAdjunto
      If va.IdVentaAdjunto > 0 Then
         copia = DirectCast(GetUno(entidadOriginal, True), Entidades.VentaAdjunto)
      Else
         copia = va.Clonar(va)
      End If
      Return copia
   End Function

   Public Function GetUno(entidadOriginal As Entidades.IAdjunto, incluirAdjunto As Boolean) As Entidades.IAdjunto Implements IReglaAdjuntos.GetUno
      Dim va As Entidades.VentaAdjunto = DirectCast(entidadOriginal, Entidades.VentaAdjunto)
      Return GetUno(va.IdSucursal, va.IdTipoComprobante, va.Letra, va.CentroEmisor, va.NumeroComprobante, va.IdVentaAdjunto, incluirAdjunto)
   End Function
End Class
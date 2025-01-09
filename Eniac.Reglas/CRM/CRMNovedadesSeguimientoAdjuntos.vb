#Region "Option"
Option Strict On
Option Explicit On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

Imports System.IO
#End Region
Public Class CRMNovedadesSeguimientoAdjuntos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess(), "")
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess, dataBase As String)
      Me.NombreEntidad = "CRMNovedadesSeguimientoAdjuntos"
      da = accesoDatos
      Me._base = Publicos.NombreBaseAdjuntosCRM
   End Sub

   Private _base As String = String.Empty

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(entidad))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(entidad))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMNovedadesSeguimientoAdjuntos = New SqlServer.CRMNovedadesSeguimientoAdjuntos(Me.da, Me._base)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMNovedadesSeguimientoAdjuntos(Me.da, Me._base).CRMNovedadesSeguimientoAdjuntos_GA(False)
   End Function

   Public Overloads Function GetAll(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As System.Data.DataTable
      Return New SqlServer.CRMNovedadesSeguimientoAdjuntos(Me.da, Me._base).CRMNovedadesSeguimientoAdjuntos_GA(idTipoNovedad, letra, centroEmisor, idNovedad, False)
   End Function
#End Region

   Public Sub _Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Overloads Sub Borrar(idTipoNovedad As String, letra As String, centroEmisor As Short, IdNovedad As Long)
      Dim sqlC As SqlServer.CRMNovedadesSeguimientoAdjuntos = New SqlServer.CRMNovedadesSeguimientoAdjuntos(da, Me._base)
      sqlC.CRMNovedadesSeguimientoAdjuntos_D(idTipoNovedad, letra, centroEmisor, IdNovedad)
   End Sub
   Public Overloads Sub Borrar(idTipoNovedad As String, letra As String, centroEmisor As Short, IdNovedad As Long, idSeguimiento As Integer, idUnico As String)
      Dim sqlC As SqlServer.CRMNovedadesSeguimientoAdjuntos = New SqlServer.CRMNovedadesSeguimientoAdjuntos(da, Me._base)
      sqlC.CRMNovedadesSeguimientoAdjuntos_D(idTipoNovedad, letra, centroEmisor, IdNovedad, idSeguimiento, idUnico)
   End Sub

   Public Sub BorrarTodosDeUnaNovedad(entidades As List(Of Entidades.CRMNovedadSeguimientoAdjunto))
      For Each en As Entidades.CRMNovedadSeguimientoAdjunto In entidades
         Me.EjecutaSP(en, TipoSP._D)
      Next
   End Sub
   Public Overloads Sub Insertar(entidades As List(Of Entidades.CRMNovedadSeguimientoAdjunto))
      For Each en As Entidades.CRMNovedadSeguimientoAdjunto In entidades
         Me.EjecutaSP(en, TipoSP._I)
      Next
   End Sub

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)
      Dim en As Entidades.CRMNovedadSeguimientoAdjunto = DirectCast(entidad, Entidades.CRMNovedadSeguimientoAdjunto)

      If en.IdSeguimiento = 0 Then
         en.IdSeguimiento = GetCodigoMaximo(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad) + 1
      End If

      Dim sqlC As SqlServer.CRMNovedadesSeguimientoAdjuntos = New SqlServer.CRMNovedadesSeguimientoAdjuntos(da, Me._base)
      Select Case tipo
         Case TipoSP._I
            'en.FechaSeguimiento = Now
            If Not String.IsNullOrWhiteSpace(en.NombreAdjunto) Then
               If en.Adjunto Is Nothing OrElse en.Adjunto.Length = 0 Then
                  Dim fi As FileInfo = New FileInfo(en.NombreAdjunto)
                  If Not fi.Exists Then
                     Throw New Exception(String.Format("El archivo '{0}' no existe el archivo a adjuntar.", en.NombreAdjunto))
                  End If
                  en.Adjunto = File.ReadAllBytes(fi.FullName)
                  en.NombreAdjunto = fi.Name
               End If

               sqlC.CRMNovedadesSeguimientoAdjuntos_I(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico, en.NombreAdjunto, en.Adjunto)
            End If
         Case TipoSP._U
            sqlC.CRMNovedadesSeguimientoAdjuntos_U(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico, en.NombreAdjunto)
         Case TipoSP._D
            sqlC.CRMNovedadesSeguimientoAdjuntos_D(en.IdTipoNovedad, en.Letra, en.CentroEmisor, en.IdNovedad, en.IdSeguimiento, en.IdUnico)
      End Select

   End Sub

   Private Sub CargarUno(o As Entidades.CRMNovedadSeguimientoAdjunto, dr As DataRow)
      With o
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr.Field(Of String)(Entidades.CRMNovedad.Columnas.IdTipoNovedad.ToString()))
         .Letra = dr.Field(Of String)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Letra.ToString())
         .CentroEmisor = dr.Field(Of Short)(Entidades.CRMNovedad.Columnas.CentroEmisor.ToString())
         .IdNovedad = dr.Field(Of Long)(Entidades.CRMNovedad.Columnas.IdNovedad.ToString())
         .IdSeguimiento = dr.Field(Of Integer)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdSeguimiento.ToString())
         .IdUnico = dr.Field(Of String)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdUnico.ToString())
         .NombreAdjunto = dr.Field(Of String)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.NombreAdjunto.ToString())
         If Not IsDBNull(dr(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Adjunto.ToString())) Then
            .Adjunto = CType(dr(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Adjunto.ToString()), Byte())
         End If
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Function Get1(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String, incluirFoto As Boolean) As DataTable
      Return New SqlServer.CRMNovedadesSeguimientoAdjuntos(Me.da, Me._base).CRMNovedadesSeguimientoAdjuntos_G1(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico, incluirFoto)
   End Function

   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String, incluirFoto As Boolean) As Entidades.CRMNovedadSeguimientoAdjunto
      Return GetUno(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico, incluirFoto, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long, idSeguimiento As Integer, idUnico As String, incluirFoto As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.CRMNovedadSeguimientoAdjunto
      'nullSiNoExiste As Boolean
      Dim dt As DataTable = Get1(idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico, incluirFoto)
      Dim o As Entidades.CRMNovedadSeguimientoAdjunto = New Entidades.CRMNovedadSeguimientoAdjunto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      Else
         If accion = AccionesSiNoExisteRegistro.Excepcion Then
            Throw New Exception(String.Format("No existe un Adjunto de Novedad para {0} {1} {2:0000}-{3:00000000} seg.: {4} GUID: {5}", idTipoNovedad, letra, centroEmisor, idNovedad, idSeguimiento, idUnico))
         ElseIf accion = AccionesSiNoExisteRegistro.Nulo Then
            Return Nothing
         End If
      End If
      Return o
   End Function

   Public Function GetTodos(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As List(Of Entidades.CRMNovedadSeguimientoAdjunto)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad, letra, centroEmisor, idNovedad)
      Return CargaLista(dt, Sub(o, dr) CargarUno(DirectCast(o, Entidades.CRMNovedadSeguimientoAdjunto), dr), Function() New Entidades.CRMNovedadSeguimientoAdjunto())
   End Function

   Public Function GetCodigoMaximo(idTipoNovedad As String, letra As String, centroEmisor As Short, idNovedad As Long) As Integer
      Return New SqlServer.CRMNovedadesSeguimientoAdjuntos(Me.da, Me._base).GetCodigoMaximo(idTipoNovedad, letra, centroEmisor, idNovedad)
   End Function

   Public Function GetAdjuntosParaArchivar() As DataTable
      Dim meses = Publicos.MesesArchivarCRMFinalizados
      Return New SqlServer.CRMNovedadesSeguimientoAdjuntos(da, _base).CRMNovedadesSeguimientoAdjuntos_GA_ParaArchivar(fechaDesde:=Nothing, fechaHasta:=DateTime.Today.AddMonths(meses * -1))
   End Function

   Public Function ArchivarAdjuntos(dtAdjuntos As DataTable, rootPath As String,
                                    avance As Action(Of String, Integer, Integer),
                                    checkForCancelation As Func(Of Boolean)) As Boolean
      Return EjecutaConConexion( _
         Function()
            Dim col = dtAdjuntos.Select("Selec")
            Dim i As Integer
            col.All(Function(dr)
                       dr("EstadoProceso") = "Comenzando"
                       i += 1
                       Try
                          Dim adj = GetUno(dr.Field(Of String)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdTipoNovedad.ToString()),
                                           dr.Field(Of String)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.Letra.ToString()),
                                           dr.Field(Of Short)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.CentroEmisor.ToString()),
                                           dr.Field(Of Long)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdNovedad.ToString()),
                                           dr.Field(Of Integer)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdSeguimiento.ToString()),
                                           dr.Field(Of String)(Entidades.CRMNovedadSeguimientoAdjunto.Columnas.IdUnico.ToString()),
                                           incluirFoto:=True, accion:=AccionesSiNoExisteRegistro.Nulo)
                          If adj IsNot Nothing Then
                             Dim nombreArchivo = String.Concat(IO.Path.Combine(rootPath,
                                                                               String.Format("{0}_{1}_{2:0000}-{3:00000000}",
                                                                                             adj.IdTipoNovedad, adj.Letra, adj.CentroEmisor, adj.IdNovedad, checkForCancelation()),
                                                                               adj.NombreAdjunto),
                                                               ".gz")
                             Dim fi = New FileInfo(nombreArchivo)
                             If Not fi.Directory.Exists Then
                                fi.Directory.Create()
                             End If

                             avance(String.Format("Exportando ({1}/{2}) {0}", nombreArchivo, i, col.Length), i, col.Length)
                             Using memStream = New MemoryStream(adj.Adjunto)
                                CompresionArchivos.Comprimir(memStream, fi.FullName)
                             End Using
                             _EliminaContenidoAdjunto_SoloConTransaccion(adj)
                          End If
                          dr("EstadoProceso") = "Exitoso"
                          dr("Selec") = False
                       Catch ex As Exception
                          dr("EstadoProceso") = "Error"
                          dr("MensajeProceso") = ex.Message
                       End Try
                       Return Not checkForCancelation()
                    End Function)
            Return True
         End Function)
   End Function

   Public Sub EliminaContenidoAdjunto(adj As Entidades.CRMNovedadSeguimientoAdjunto)
      EjecutaConConexion(Sub()
                            _EliminaContenidoAdjunto_SoloConTransaccion(adj)
                         End Sub)
   End Sub

   Private Sub _EliminaContenidoAdjunto_SoloConTransaccion(adj As Entidades.CRMNovedadSeguimientoAdjunto)
      EjecutaSoloConTransaccion(Function()
                                   _EliminaContenidoAdjunto(adj)
                                   Return True
                                End Function)
   End Sub
   Private Sub _EliminaContenidoAdjunto(adj As Entidades.CRMNovedadSeguimientoAdjunto)
      Dim sql = New SqlServer.CRMNovedadesSeguimientoAdjuntos(da, _base)
      sql.CRMNovedadesSeguimientoAdjuntos_U_EliminarContenido(adj.IdTipoNovedad, adj.Letra, adj.CentroEmisor, adj.IdNovedad, adj.IdSeguimiento, adj.IdUnico)
   End Sub
#End Region
End Class
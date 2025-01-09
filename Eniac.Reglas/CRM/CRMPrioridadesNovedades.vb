Option Strict On
Option Explicit On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

Public Class CRMPrioridadesNovedades
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMPrioridadNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMPrioridadNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMPrioridadNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMPrioridadNovedadJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CRMPrioridadesNovedades"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMPrioridadesNovedades"
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
      Dim sql As SqlServer.CRMPrioridadesNovedades = New SqlServer.CRMPrioridadesNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMPrioridadesNovedades(Me.da).CRMPrioridadesNovedades_GA()
   End Function

   Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad, Optional ordenarPosicion As Boolean = False) As System.Data.DataTable
      If TipoNovedad Is Nothing Then
         Return GetAll()
      Else
         Return GetAll(TipoNovedad.IdTipoNovedad, ordenarPosicion)
      End If
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.CRMPrioridadesNovedades(Me.da).CRMPrioridadesNovedades_GA(idTipoNovedad, ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.CRMPrioridadNovedad = DirectCast(entidad, Entidades.CRMPrioridadNovedad)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CRMPrioridadesNovedades = New SqlServer.CRMPrioridadesNovedades(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.CRMPrioridadesNovedades_I(en)
            Case TipoSP._U
               sqlC.CRMPrioridadesNovedades_U(en)
            Case TipoSP._D
               sqlC.CRMPrioridadesNovedades_D(en.IdPrioridadNovedad)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CRMPrioridadNovedad, ByVal dr As DataRow)
      With o
         .IdPrioridadNovedad = Integer.Parse(dr(Entidades.CRMPrioridadNovedad.Columnas.IdPrioridadNovedad.ToString()).ToString())
         .NombrePrioridadNovedad = dr(Entidades.CRMPrioridadNovedad.Columnas.NombrePrioridadNovedad.ToString()).ToString()
         .Posicion = Integer.Parse(dr(Entidades.CRMPrioridadNovedad.Columnas.Posicion.ToString()).ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMPrioridadNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .PorDefecto = CBool(dr(Entidades.CRMPrioridadNovedad.Columnas.PorDefecto.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idPrioridadNovedad As Integer) As Entidades.CRMPrioridadNovedad
      Dim dt As DataTable = New SqlServer.CRMPrioridadesNovedades(Me.da).CRMPrioridadesNovedades_G1(idPrioridadNovedad)
      Dim o As Entidades.CRMPrioridadNovedad = New Entidades.CRMPrioridadNovedad()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMPrioridadNovedad)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad, ordenarPosicion)
      Dim o As Entidades.CRMPrioridadNovedad
      Dim oLis As List(Of Entidades.CRMPrioridadNovedad) = New List(Of Entidades.CRMPrioridadNovedad)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CRMPrioridadNovedad()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMPrioridadesNovedades(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.CRMPrioridadesNovedades(Me.da).
                                       GetCodigoMaximo(Entidades.CRMPrioridadNovedad.Columnas.Posicion.ToString(),
                                                       "CRMPrioridadesNovedades",
                                                       String.Format("{0} = '{1}'", Entidades.CRMPrioridadNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function

#End Region

End Class

Option Strict On
Option Explicit On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

Public Class CRMMetodosResolucionesNovedades
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMMetodoResolucionNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMetodoResolucionNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMMetodoResolucionNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMMetodoResolucionNovedadJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CRMMetodosResolucionesNovedades"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMMetodosResolucionesNovedades"
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
      Dim sql As SqlServer.CRMMetodosResolucionesNovedades = New SqlServer.CRMMetodosResolucionesNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMMetodosResolucionesNovedades(Me.da).CRMMetodosResolucionesNovedades_GA()
   End Function

   Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad, Optional ordenarPosicion As Boolean = False) As System.Data.DataTable
      If TipoNovedad Is Nothing Then
         Return GetAll()
      Else
         Return GetAll(TipoNovedad.IdTipoNovedad, ordenarPosicion)
      End If
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.CRMMetodosResolucionesNovedades(Me.da).CRMMetodosResolucionesNovedades_GA(idTipoNovedad, ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.CRMMetodoResolucionNovedad = DirectCast(entidad, Entidades.CRMMetodoResolucionNovedad)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CRMMetodosResolucionesNovedades = New SqlServer.CRMMetodosResolucionesNovedades(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.CRMMetodosResolucionesNovedades_I(en)
            Case TipoSP._U
               sqlC.CRMMetodosResolucionesNovedades_U(en)
            Case TipoSP._D
               sqlC.CRMMetodosResolucionesNovedades_D(en.IdMetodoResolucionNovedad)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CRMMetodoResolucionNovedad, ByVal dr As DataRow)
      With o
         .IdMetodoResolucionNovedad = Integer.Parse(dr(Entidades.CRMMetodoResolucionNovedad.Columnas.IdMetodoResolucionNovedad.ToString()).ToString())
         .NombreMetodoResolucionNovedad = dr(Entidades.CRMMetodoResolucionNovedad.Columnas.NombreMetodoResolucionNovedad.ToString()).ToString()
         .Posicion = Integer.Parse(dr(Entidades.CRMMetodoResolucionNovedad.Columnas.Posicion.ToString()).ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .PorDefecto = CBool(dr(Entidades.CRMMetodoResolucionNovedad.Columnas.PorDefecto.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idMetodoResolucionNovedad As Integer) As Entidades.CRMMetodoResolucionNovedad
      Dim dt As DataTable = New SqlServer.CRMMetodosResolucionesNovedades(Me.da).CRMMetodosResolucionesNovedades_G1(idMetodoResolucionNovedad)
      Dim o As Entidades.CRMMetodoResolucionNovedad = New Entidades.CRMMetodoResolucionNovedad()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMMetodoResolucionNovedad)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad, ordenarPosicion)
      Dim o As Entidades.CRMMetodoResolucionNovedad
      Dim oLis As List(Of Entidades.CRMMetodoResolucionNovedad) = New List(Of Entidades.CRMMetodoResolucionNovedad)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CRMMetodoResolucionNovedad()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMMetodosResolucionesNovedades(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.CRMMetodosResolucionesNovedades(Me.da).
                                       GetCodigoMaximo(Entidades.CRMMetodoResolucionNovedad.Columnas.Posicion.ToString(),
                                                       "CRMMetodosResolucionesNovedades",
                                                       String.Format("{0} = '{1}'", Entidades.CRMMetodoResolucionNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function
   Public Function GetPorCodigo(codigo As Integer, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMMetodosResolucionesNovedades(da).CRMMetodoResolucionesNovedades_GxCodigo(codigo, idTipoNovedad)
   End Function

   Public Function GetPorNombre(nombre As String, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMMetodosResolucionesNovedades(da).CRMMetodoResolucionesNovedades_PorNombre(nombre, nombreExacto:=False, idTipoNovedad)
   End Function
#End Region

End Class

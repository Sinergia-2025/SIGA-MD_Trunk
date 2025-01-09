Option Strict On
Option Explicit On
Public Class CRMTiposNovedadesDinamicos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CRMTiposNovedadesDinamicos"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMTiposNovedadesDinamicos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)
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

         Me.EjecutaSP(entidad, TipoSP._U)
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

         Me.EjecutaSP(entidad, TipoSP._D)
         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMTiposNovedadesDinamicos = New SqlServer.CRMTiposNovedadesDinamicos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMTiposNovedadesDinamicos(Me.da).CRMTiposNovedadesDinamicos_GA()
   End Function

   Public Overrides Function GetAll(IdTipoNovedad As String) As System.Data.DataTable
      Return New SqlServer.CRMTiposNovedadesDinamicos(Me.da).CRMTiposNovedadesDinamicos_GA(IdTipoNovedad)
   End Function

#End Region

#Region "Metodos Privados"

   Public Overloads Sub Insertar(ByVal entidades As List(Of Entidades.CRMTipoNovedadDinamico))
      For Each entidad As Entidades.CRMTipoNovedadDinamico In entidades
         EjecutaSP(entidad, TipoSP._I)
      Next
   End Sub

   Public Overloads Sub Borrar(IdTipoNovedad As String)
      Dim sqlC As SqlServer.CRMTiposNovedadesDinamicos = New SqlServer.CRMTiposNovedadesDinamicos(da)
      sqlC.CRMTiposNovedadesDinamicos_D(IdTipoNovedad)
   End Sub


   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.CRMTipoNovedadDinamico = DirectCast(entidad, Entidades.CRMTipoNovedadDinamico)

      Dim sqlC As SqlServer.CRMTiposNovedadesDinamicos = New SqlServer.CRMTiposNovedadesDinamicos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.CRMTiposNovedadesDinamicos_I(en.IdTipoNovedad, en.IdNombreDinamico, en.EsRequerido, en.Orden)
         Case TipoSP._U
            sqlC.CRMTiposNovedadesDinamicos_U(en.IdTipoNovedad, en.IdNombreDinamico, en.EsRequerido, en.Orden)
         Case TipoSP._D
            sqlC.CRMTiposNovedadesDinamicos_D(en.IdTipoNovedad)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CRMTipoNovedadDinamico, ByVal dr As DataRow)
      With o
         .IdTipoNovedad = dr(Entidades.CRMTipoNovedadDinamico.Columnas.IdTipoNovedad.ToString()).ToString()
         .IdNombreDinamico = dr(Entidades.CRMTipoNovedadDinamico.Columnas.IdNombreDinamico.ToString()).ToString()
         .EsRequerido = CBool(dr(Entidades.CRMTipoNovedadDinamico.Columnas.EsRequerido.ToString()))
         .Orden = Integer.Parse(dr(Entidades.CRMTipoNovedadDinamico.Columnas.Orden.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(IdTipoNovedad As String, IdNombreDinamico As String) As Entidades.CRMTipoNovedadDinamico
      Dim dt As DataTable = New SqlServer.CRMTiposNovedadesDinamicos(Me.da).CRMTiposNovedadesDinamicos_G1(IdTipoNovedad, IdNombreDinamico)
      Dim o As Entidades.CRMTipoNovedadDinamico = New Entidades.CRMTipoNovedadDinamico()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos() As List(Of Entidades.CRMTipoNovedadDinamico)
      Return GetTodos(String.Empty)
   End Function
   Public Function GetTodos(IdTipoNovedad As String) As List(Of Entidades.CRMTipoNovedadDinamico)
      Dim dt As DataTable = Me.GetAll(IdTipoNovedad)
      Dim o As Entidades.CRMTipoNovedadDinamico
      Dim oLis As List(Of Entidades.CRMTipoNovedadDinamico) = New List(Of Entidades.CRMTipoNovedadDinamico)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CRMTipoNovedadDinamico()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

#End Region
End Class

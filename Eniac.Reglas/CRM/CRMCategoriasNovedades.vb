#Region "Option"
Option Strict On
Option Explicit On

Imports Eniac.Reglas.ServiciosRest.Sincronizacion

#End Region
Public Class CRMCategoriasNovedades
   Inherits Eniac.Reglas.BaseSync(Of Entidades.JSonEntidades.Archivos.CRM.CRMCategoriaNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMCategoriaNovedadJSon)
   Implements ISyncRegla(Of Entidades.JSonEntidades.Archivos.CRM.CRMCategoriaNovedadJSonTransporte, Entidades.JSonEntidades.Archivos.CRM.CRMCategoriaNovedadJSon)

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CRMCategoriasNovedades"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMCategoriasNovedades"
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
      Dim sql As SqlServer.CRMCategoriasNovedades = New SqlServer.CRMCategoriasNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.CRMCategoriasNovedades(Me.da).CRMCategoriasNovedades_GA()
   End Function

   Public Overloads Function GetAll(TipoNovedad As Entidades.CRMTipoNovedad) As System.Data.DataTable
      If TipoNovedad Is Nothing Then
         Return GetAll()
      Else
         Return GetAll(TipoNovedad.IdTipoNovedad, False)
      End If
   End Function
   Public Overloads Function GetAll(idTipoNovedad As String, ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.CRMCategoriasNovedades(Me.da).CRMCategoriasNovedades_GA(idTipoNovedad, ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.CRMCategoriaNovedad = DirectCast(entidad, Entidades.CRMCategoriaNovedad)

         da.OpenConection()
         da.BeginTransaction()

         Dim sqlC As SqlServer.CRMCategoriasNovedades = New SqlServer.CRMCategoriasNovedades(da)
         Select Case tipo
            Case TipoSP._I
               sqlC.CRMCategoriasNovedades_I(en.IdCategoriaNovedad, en.NombreCategoriaNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto, en.Reporta, en.Color, en.PublicarEnWeb, en.IdTipoCategoriaNovedad)
            Case TipoSP._U
               sqlC.CRMCategoriasNovedades_U(en.IdCategoriaNovedad, en.NombreCategoriaNovedad, en.Posicion, en.IdTipoNovedad, en.PorDefecto, en.Reporta, en.Color, en.PublicarEnWeb, en.IdTipoCategoriaNovedad)
            Case TipoSP._D
               sqlC.CRMCategoriasNovedades_D(en.IdCategoriaNovedad)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CRMCategoriaNovedad, ByVal dr As DataRow)
      With o
         .IdCategoriaNovedad = Integer.Parse(dr(Entidades.CRMCategoriaNovedad.Columnas.IdCategoriaNovedad.ToString()).ToString())
         .NombreCategoriaNovedad = dr(Entidades.CRMCategoriaNovedad.Columnas.NombreCategoriaNovedad.ToString()).ToString()
         .Posicion = Integer.Parse(dr(Entidades.CRMCategoriaNovedad.Columnas.Posicion.ToString()).ToString())
         .TipoNovedad = Cache.CRMCacheHandler.Instancia.Tipos.Buscar(dr(Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString()).ToString())
         .PorDefecto = CBool(dr(Entidades.CRMCategoriaNovedad.Columnas.PorDefecto.ToString()).ToString())
         .Reporta = dr(Entidades.CRMCategoriaNovedad.Columnas.Reporta.ToString()).ToString()
         If IsNumeric(dr(Entidades.CRMCategoriaNovedad.Columnas.Color.ToString())) Then
            .Color = Integer.Parse(dr(Entidades.CRMCategoriaNovedad.Columnas.Color.ToString()).ToString())
         Else
            .Color = Nothing
         End If
         .PublicarEnWeb = Boolean.Parse(dr(Entidades.CRMCategoriaNovedad.Columnas.PublicarEnWeb.ToString()).ToString())
         .IdTipoCategoriaNovedad = dr.Field(Of Integer)(Entidades.CRMCategoriaNovedad.Columnas.IdTipoCategoriaNovedad.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idCategoriaNovedad As Integer) As Entidades.CRMCategoriaNovedad
      Dim dt As DataTable = New SqlServer.CRMCategoriasNovedades(Me.da).CRMCategoriasNovedades_G1(idCategoriaNovedad)
      Dim o As Entidades.CRMCategoriaNovedad = New Entidades.CRMCategoriaNovedad()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idTipoNovedad As String, Optional ordenarPosicion As Boolean = False) As List(Of Entidades.CRMCategoriaNovedad)
      Return CargaLista(Me.GetAll(idTipoNovedad, ordenarPosicion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMCategoriaNovedad())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.CRMCategoriasNovedades(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetPosicionMaxima(idTipoNovedad As String) As Integer
      Return Convert.ToInt32(New SqlServer.CRMCategoriasNovedades(Me.da).
                                       GetCodigoMaximo(Entidades.CRMCategoriaNovedad.Columnas.Posicion.ToString(),
                                                       "CRMCategoriasNovedades",
                                                       String.Format("{0} = '{1}'", Entidades.CRMCategoriaNovedad.Columnas.IdTipoNovedad.ToString(), idTipoNovedad)))
   End Function

   Public Function GetPorCodigo(codigo As Integer, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMCategoriasNovedades(da).CRMCategoriasNovedades_GxCodigo(codigo, idTipoNovedad)
   End Function

   Public Function GetPorNombre(nombre As String, idTipoNovedad As String) As DataTable
      Return New SqlServer.CRMCategoriasNovedades(da).CRMCategoriasNovedades_PorNombre(nombre, nombreExacto:=False, idTipoNovedad)
   End Function

#End Region

End Class

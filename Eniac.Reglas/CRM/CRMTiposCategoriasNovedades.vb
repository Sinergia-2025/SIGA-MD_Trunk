Option Explicit On
Option Strict On
Public Class CRMTiposCategoriasNovedades
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.CRMTipoCategoriaNovedad.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.CRMTipoCategoriaNovedad.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Sub _Inserta(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoCategoriaNovedad), TipoSP._I)
   End Sub
   Public Sub _Actualiza(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoCategoriaNovedad), TipoSP._U)
   End Sub
   Public Sub _Borra(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoCategoriaNovedad), TipoSP._D)
   End Sub

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoCategoriaNovedad), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoCategoriaNovedad), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.CRMTipoCategoriaNovedad), TipoSP._D))
   End Sub

   'Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable

   'End Function

   Public Overrides Function GetAll(idTipoNovedad As String) As System.Data.DataTable
      Dim sCRMTiposCategoriasNovedades As SqlServer.CRMTiposCategoriasNovedades = New SqlServer.CRMTiposCategoriasNovedades(da)
      Return sCRMTiposCategoriasNovedades.CRMTiposCategoriasNovedades_GA(idTipoNovedad)
   End Function

#End Region

#Region "Métodos Públicos"

   Public Function GetUno(idTipoCategoriaNovedad As Integer) As Entidades.CRMTipoCategoriaNovedad
      Dim sCRMTiposCategoriasNovedades As SqlServer.CRMTiposCategoriasNovedades = New SqlServer.CRMTiposCategoriasNovedades(da)
      Return CargaEntidad(sCRMTiposCategoriasNovedades.CRMTiposCategoriasNovedades_G1(idTipoCategoriaNovedad),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoCategoriaNovedad(),
                    AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el tipo de categoria con número: {0}", idTipoCategoriaNovedad))
   End Function

   Public Function GetTodos() As List(Of Entidades.CRMTipoCategoriaNovedad)
      Return Me.GetTodos(idTipoNovedad:=Nothing)
   End Function

   '# Get Todos x IdTipoNovedad
   Public Function GetTodos(idTipoNovedad As String) As List(Of Entidades.CRMTipoCategoriaNovedad)
      Dim dt As DataTable = Me.GetAll(idTipoNovedad)
      Dim eCRMTipoCategoriaNovedad As Entidades.CRMTipoCategoriaNovedad
      Dim lista As List(Of Entidades.CRMTipoCategoriaNovedad) = New List(Of Entidades.CRMTipoCategoriaNovedad)
      For Each dr As DataRow In dt.Rows
         eCRMTipoCategoriaNovedad = New Entidades.CRMTipoCategoriaNovedad()
         Me.CargarUno(eCRMTipoCategoriaNovedad, dr)
         lista.Add(eCRMTipoCategoriaNovedad)
      Next
      Return lista
   End Function

#End Region

#Region "Métodos Privados"

   Private Sub EjecutaSP(en As Entidades.CRMTipoCategoriaNovedad, tipo As TipoSP)
      Dim sCRMTiposCategoriasNovedades As SqlServer.CRMTiposCategoriasNovedades = New SqlServer.CRMTiposCategoriasNovedades(da)
      Select Case tipo
         Case TipoSP._I
            sCRMTiposCategoriasNovedades.CRMTiposCategoriasNovedades_I(en.IdTipoCategoriaNovedad, en.NombreTipoCategoriaNovedad, en.Posicion, en.IdTipoNovedad)
         Case TipoSP._U
            sCRMTiposCategoriasNovedades.CRMTiposCategoriasNovedades_U(en.IdTipoCategoriaNovedad, en.NombreTipoCategoriaNovedad, en.Posicion, en.IdTipoNovedad)
         Case TipoSP._D
            sCRMTiposCategoriasNovedades.CRMTiposCategoriasNovedades_D(en.IdTipoCategoriaNovedad)
      End Select
   End Sub

   Private Sub CargarUno(eCRMTipoCategoriaNovedad As Entidades.CRMTipoCategoriaNovedad, dr As DataRow)
      With eCRMTipoCategoriaNovedad
         .IdTipoCategoriaNovedad = dr.Field(Of Integer)(Entidades.CRMTipoCategoriaNovedad.Columnas.IdTipoCategoriaNovedad.ToString())
         .NombreTipoCategoriaNovedad = dr.Field(Of String)(Entidades.CRMTipoCategoriaNovedad.Columnas.NombreTipoCategoriaNovedad.ToString())
         .Posicion = dr.Field(Of Integer)(Entidades.CRMTipoCategoriaNovedad.Columnas.Posicion.ToString())
         .IdTipoNovedad = dr.Field(Of String)(Entidades.CRMTipoCategoriaNovedad.Columnas.IdTipoNovedad.ToString())
      End With
   End Sub

#End Region

End Class

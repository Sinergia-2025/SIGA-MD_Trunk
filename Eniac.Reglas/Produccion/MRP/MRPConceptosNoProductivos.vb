Public Class MRPConceptosNoProductivos
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.MRPConceptoNoProductivo.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.MRPConceptoNoProductivo)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.MRPConceptoNoProductivo)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.MRPConceptoNoProductivo)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql = New SqlServer.MRPConceptosNoProductivos(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.MRPConceptosNoProductivos(da).MRPConceptosNoProductivos_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPConceptoNoProductivo, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPConceptosNoProductivos(da)
      Select Case tipo
         Case TipoSP._I
            If en.IdConceptoNoProductivo = 0 Then
               en.IdConceptoNoProductivo = GetCodigoMaximo() + 1
            End If
            sqlC.MRPConceptosNoProductivos_I(en.IdConceptoNoProductivo, en.CodigoConceptoNoProductivo, en.NombreConceptoNoProductivo, en.Activo)
         Case TipoSP._U
            sqlC.MRPConceptosNoProductivos_U(en.IdConceptoNoProductivo, en.CodigoConceptoNoProductivo, en.NombreConceptoNoProductivo, en.Activo)
         Case TipoSP._D
            sqlC.MRPConceptosNoProductivos_D(en.IdConceptoNoProductivo)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPConceptoNoProductivo, dr As DataRow)
      With o
         .IdConceptoNoProductivo = dr.Field(Of Integer)(Entidades.MRPConceptoNoProductivo.Columnas.IdConceptoNoProductivo.ToString())
         .CodigoConceptoNoProductivo = dr.Field(Of String)(Entidades.MRPConceptoNoProductivo.Columnas.CodigoConceptoNoProductivo.ToString())
         .NombreConceptoNoProductivo = dr.Field(Of String)(Entidades.MRPConceptoNoProductivo.Columnas.NombreConceptoNoProductivo.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.MRPConceptoNoProductivo.Columnas.Activo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.MRPConceptoNoProductivo)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.MRPConceptoNoProductivo)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.MRPConceptoNoProductivo)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetFiltradoPorCodigo(codigoTarea As String, busquedaParcial As Boolean) As DataTable
      Dim sql = New SqlServer.MRPConceptosNoProductivos(da)
      Dim dt = sql.MRPConceptosNoProductivos_G1_Codigo(codigoTarea, codigoExacto:=True)
      If dt.Empty() And busquedaParcial Then
         dt = sql.MRPConceptosNoProductivos_G1_Codigo(codigoTarea, codigoExacto:=False)
      End If
      Return dt
   End Function

   Public Function GetFiltradoPorNombre(nombreTarea As String, activos As Entidades.Publicos.SiNoTodos) As DataTable
      Return New SqlServer.MRPConceptosNoProductivos(da).MRPConceptosNoProductivos_GA_Nombre(nombreTarea, nombreExacto:=False, activos)
   End Function

   Public Function Get1(idTarea As Integer) As DataTable
      Return New SqlServer.MRPConceptosNoProductivos(da).MRPConceptosNoProductivos_G1(idTarea)
   End Function

   Public Function GetUno(idTarea As Integer) As Entidades.MRPConceptoNoProductivo
      Return GetUno(idTarea, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idTarea As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MRPConceptoNoProductivo
      Return CargaEntidad(Get1(idTarea),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MRPConceptoNoProductivo(),
                          accion, Function() String.Format("No existe Tarea con Id: {0}", idTarea))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPConceptoNoProductivo)
      Return CargaLista(New SqlServer.MRPConceptosNoProductivos(da).MRPConceptosNoProductivos_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MRPConceptoNoProductivo())
   End Function
   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MRPConceptosNoProductivos(da).GetCodigoMaximo()
   End Function
   Public Function Existe(codigoTarea As String) As Boolean
      Return New SqlServer.MRPConceptosNoProductivos(da).MRPConceptosNoProductivos_G1_Codigo(codigoTarea, codigoExacto:=True).Any()
   End Function

#End Region

End Class
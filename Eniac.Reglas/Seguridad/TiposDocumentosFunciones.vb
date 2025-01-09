#Region "Option"
Option Strict On
Option Explicit On
#End Region
Public Class TiposDocumentosFunciones
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.TipoDocumentoFuncion.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.TipoDocumentoFuncion)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.TipoDocumentoFuncion)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.TipoDocumentoFuncion)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.TiposDocumentosFunciones = New SqlServer.TiposDocumentosFunciones(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposDocumentosFunciones(Me.da).TiposDocumentosFunciones_GA()
   End Function

   Public Overloads Function GetAll(ordenarPosicion As Boolean) As System.Data.DataTable
      Return New SqlServer.TiposDocumentosFunciones(Me.da).TiposDocumentosFunciones_GA(ordenarPosicion)
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TipoDocumentoFuncion, tipo As TipoSP)
      Dim sqlC As SqlServer.TiposDocumentosFunciones = New SqlServer.TiposDocumentosFunciones(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.TiposDocumentosFunciones_I(en.IdTipoLink, en.Descripcion, en.DescripcionAbreviada, en.Orden)
         Case TipoSP._U
            sqlC.TiposDocumentosFunciones_U(en.IdTipoLink, en.Descripcion, en.DescripcionAbreviada, en.Orden)
         Case TipoSP._D
            sqlC.TiposDocumentosFunciones_D(en.IdTipoLink)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TipoDocumentoFuncion, dr As DataRow)
      With o
         .IdTipoLink = dr.Field(Of String)(Entidades.TipoDocumentoFuncion.Columnas.IdTipoLink.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.TipoDocumentoFuncion.Columnas.Descripcion.ToString())
         .DescripcionAbreviada = dr.Field(Of String)(Entidades.TipoDocumentoFuncion.Columnas.DescripcionAbreviada.ToString())
         .Orden = dr.Field(Of Integer)(Entidades.TipoDocumentoFuncion.Columnas.Orden.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.TipoDocumentoFuncion)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.TipoDocumentoFuncion)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.TipoDocumentoFuncion)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetUno(idTipoLink As String) As Entidades.TipoDocumentoFuncion
      Return GetUno(idTipoLink, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoLink As String, accion As AccionesSiNoExisteRegistro) As Entidades.TipoDocumentoFuncion
      Return CargaEntidad(New SqlServer.TiposDocumentosFunciones(Me.da).TiposDocumentosFunciones_G1(idTipoLink),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoDocumentoFuncion(),
                          accion, Function() String.Format("No existe Tipo de Documento de Función con Id: {0}", idTipoLink))
   End Function

   Public Function GetTodos(Optional ordenarPosicion As Boolean = False) As List(Of Entidades.TipoDocumentoFuncion)
      Return CargaLista(Me.GetAll(ordenarPosicion),
                        Sub(o, dr) CargarUno(DirectCast(o, Entidades.TipoDocumentoFuncion), dr),
                        Function() New Entidades.TipoDocumentoFuncion())
   End Function

#End Region
End Class
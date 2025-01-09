Option Strict On
Option Explicit On
Public Class FuncionesDocumentos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.FuncionesDocumentos.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.FuncionesDocumentos)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.FuncionesDocumentos)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.FuncionesDocumentos)))
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.FuncionesDocumentos = New SqlServer.FuncionesDocumentos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.FuncionesDocumentos(Me.da).FuncionesDocumentos_GA()
   End Function

   Public Overrides Function GetAll(idFuncion As String) As System.Data.DataTable
      Return New SqlServer.FuncionesDocumentos(Me.da).FuncionesDocumentos_GA(idFuncion)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(doc As Entidades.FuncionesDocumentos, tipo As TipoSP)

      Dim sqlC As SqlServer.FuncionesDocumentos = New SqlServer.FuncionesDocumentos(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.FuncionesDocumentos_I(doc.IdFuncion, doc.IdTipoLink, doc.Orden, doc.Link, doc.Descripcion)
         Case TipoSP._U
            sqlC.FuncionesDocumentos_U(doc.IdFuncion, doc.IdTipoLink, doc.Orden, doc.Link, doc.Descripcion)
         Case TipoSP._D
            sqlC.FuncionesDocumentos_D(doc.IdFuncion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.FuncionesDocumentos, dr As DataRow)
      With o
         .IdFuncion = dr(Entidades.FuncionesDocumentos.Columnas.IdFuncion.ToString()).ToString()
         .TipoDocumentoFuncion = New Reglas.TiposDocumentosFunciones(da).GetUno(dr.Field(Of String)(Entidades.FuncionesDocumentos.Columnas.IdTipoLink.ToString()))
         '.IdTipoLink = dr(Entidades.FuncionesDocumentos.Columnas.IdTipoLink.ToString()).ToString().StringToEnum(Entidades.FuncionesDocumentos.TiposLinks.Manual)
         .Orden = dr.ValorNumericoPorDefecto(Entidades.FuncionesDocumentos.Columnas.Orden.ToString(), 0I)
         .Link = dr(Entidades.FuncionesDocumentos.Columnas.Link.ToString()).ToString()
         .Descripcion = dr(Entidades.FuncionesDocumentos.Columnas.Descripcion.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Sub _Insertar(entidad As Entidades.FuncionesDocumentos)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.FuncionesDocumentos)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.FuncionesDocumentos)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub


   Public Overloads Sub Insertar(funcion As Entidades.Funcion)
      Dim orden As Integer = 0
      For Each documento As Entidades.FuncionesDocumentos In funcion.Documentos
         orden += 1
         documento.IdFuncion = funcion.Id
         documento.Orden = orden
         _Insertar(documento)
      Next
   End Sub

   Public Overloads Sub Borrar(idFuncion As String)
      _Borrar(New Entidades.FuncionesDocumentos() With {.IdFuncion = idFuncion})
   End Sub

   Public Function GetUno(IdFuncion As String, orden As Integer) As Entidades.FuncionesDocumentos
      Return GetUno(IdFuncion, orden, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUno(idFuncion As String, orden As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.FuncionesDocumentos
      Return CargaEntidad(New SqlServer.FuncionesDocumentos(Me.da).FuncionesDocumentos_G1(idFuncion, orden),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.FuncionesDocumentos(),
                          accion, Function() String.Format("No se encontró documento con Id '{0}' y orden {1}",
                                                           idFuncion, orden))
   End Function

   Public Function GetTodos() As List(Of Entidades.FuncionesDocumentos)
      Return GetTodos(String.Empty)
   End Function
   Public Function GetTodos(idFuncion As String) As List(Of Entidades.FuncionesDocumentos)
      Return CargaLista(Me.GetAll(idFuncion),
                        Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.FuncionesDocumentos())
   End Function

#End Region
End Class
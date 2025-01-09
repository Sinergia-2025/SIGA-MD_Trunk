Public Class TiposClientes
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "TipoCliente"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TipoCliente), TipoSP._I))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TipoCliente), TipoSP._D))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.TipoCliente), TipoSP._U))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.TiposClientes(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposClientes(da).TiposClientes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.TipoCliente, tipo As TipoSP)
      Dim sql = New SqlServer.TiposClientes(da)
      Select Case tipo
         Case TipoSP._I
            sql.TiposClientes_I(en.IdTipoCliente, en.NombreTipoCliente)
         Case TipoSP._U
            sql.TiposClientes_U(en.IdTipoCliente, en.NombreTipoCliente)
         Case TipoSP._D
            sql.TiposClientes_D(en.IdTipoCliente)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.TipoCliente, dr As DataRow)
      With o
         .IdTipoCliente = dr.Field(Of Integer)("IdTipoCliente")
         .NombreTipoCliente = dr.Field(Of String)("NombreTipoCliente").IfNull()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.TipoCliente)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoCliente())
   End Function

   Public Function GetUno(idTipoCliente As Integer) As Entidades.TipoCliente
      Return EjecutaConConexion(Function() _GetUno(idTipoCliente))
   End Function

   Public Function _GetUno(idTipoCliente As Integer) As Entidades.TipoCliente
      Return _GetUno(idTipoCliente, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function _GetUno(idTipoCliente As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.TipoCliente
      Return CargaEntidad(New SqlServer.TiposClientes(da).TiposClientes_G1(idTipoCliente),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoCliente(),
                          accion, Function() String.Format("No existe el Tipo de Cliente con Código {0}.", idTipoCliente))
   End Function

   Public Function GetUnoXNombre(TipoCliente As String) As Entidades.TipoCliente
      Return GetUnoXNombre(TipoCliente, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUnoXNombre(TipoCliente As String, accion As AccionesSiNoExisteRegistro) As Entidades.TipoCliente
      Return CargaEntidad(GetAllPorNombre(TipoCliente, nombreExacto:=True),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TipoCliente(),
                          accion, Function() String.Format("No existe el Tipo de Cliente con nombre '{0}'.", TipoCliente))
   End Function

   '# Este retorna un DT
   Public Function GetAllPorNombre(nombre As String) As DataTable
      Return GetAllPorNombre(nombre, nombreExacto:=False)
   End Function
   Public Function GetAllPorNombre(nombre As String, nombreExacto As Boolean) As DataTable
      Return New SqlServer.TiposClientes(da).GetPorNombre(nombre, nombreExacto)
   End Function

   Public Function GetAllPorCodigo(codigo As Integer) As DataTable
      Return New SqlServer.TiposClientes(da).GetPorCodigo(codigo)
   End Function

   Public Function GetProximoId() As Integer
      Return New SqlServer.TiposClientes(da).GetProximoId()
   End Function

   Public Function GetIdTop1() As Integer
      Dim result As Integer = 0
      Dim dt As DataTable = New SqlServer.TiposClientes(da).GetTop1()
      If dt.Rows.Count > 0 Then result = dt.Rows(0).Field(Of Integer)(Entidades.TipoCliente.Columnas.IdTipoCliente.ToString())
      Return result
   End Function
#End Region

End Class

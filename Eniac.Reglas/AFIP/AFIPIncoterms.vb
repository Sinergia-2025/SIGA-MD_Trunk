Public Class AFIPIncoterms
   Inherits Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = Entidades.AFIPIncoterm.NombreTabla
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.AFIPIncoterm.NombreTabla
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.AFIPIncoterm), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.AFIPIncoterm), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.AFIPIncoterm), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.AFIPIncoterms = New SqlServer.AFIPIncoterms(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.AFIPIncoterms(Me.da).AFIPIncoterms_GA()
   End Function
#End Region

#Region "Métodos Privados"
   Private Sub EjecutaSP(en As Entidades.AFIPIncoterm, tipo As TipoSP)
      Dim sAfipIncoterm As SqlServer.AFIPIncoterms = New SqlServer.AFIPIncoterms(da)
      Select Case tipo
         Case TipoSP._I
            sAfipIncoterm.AFIPIncoterms_I(en.IdIncoterm, en.NombreIncoterm)
         Case TipoSP._U
            sAfipIncoterm.AFIPIncoterms_U(en.IdIncoterm, en.NombreIncoterm)
         Case TipoSP._D
            sAfipIncoterm.AFIPIncoterms_D(en.IdIncoterm)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.AFIPIncoterm, dr As DataRow)
      With o
         .IdIncoterm = dr.Field(Of String)(Entidades.AFIPIncoterm.Columnas.IdIncoterm.ToString())
         .NombreIncoterm = dr.Field(Of String)(Entidades.AFIPIncoterm.Columnas.NombreIncoterm.ToString())
      End With
   End Sub
#End Region

#Region "Métodos Públicos"
   'GET UNO
   Public Function GetUno(idIncoterm As String) As Entidades.AFIPIncoterm
      Return GetUno(idIncoterm, AccionesSiNoExisteRegistro.Vacio)
   End Function

   Public Function GetUno(idIncoterm As String, accion As AccionesSiNoExisteRegistro) As Entidades.AFIPIncoterm
      Return CargaEntidad(New SqlServer.AFIPIncoterms(Me.da).AFIPIncoterms_G1(idIncoterm),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.AFIPIncoterm(),
         accion, Function() String.Format("No existe AFIPIncoterm con Id: {0}", idIncoterm))
   End Function
   'GET TODOS
   Public Function GetTodos() As List(Of Entidades.AFIPIncoterm)
      Return CargaLista(New SqlServer.AFIPIncoterms(Me.da).AFIPIncoterms_GA(),
         Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.AFIPIncoterm())
   End Function
#End Region
End Class

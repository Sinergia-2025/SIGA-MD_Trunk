Public Class MediosdePago
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.MedioDePago.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.MedioDePago)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.MedioDePago)))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.MedioDePago)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.MediosdePago(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.MediosdePago(da).MediosDePago_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MedioDePago, tipo As TipoSP)
      Dim sql = New SqlServer.MediosdePago(da)
      Select Case tipo
         Case TipoSP._I
            sql.MediosDePago_I(en.IdMedioDePago, en.NombreMedioDePago, en.IdCuenta)

         Case TipoSP._U
            sql.MediosDePago_U(en.IdMedioDePago, en.NombreMedioDePago, en.IdCuenta)

         Case TipoSP._D
            sql.MediosDePago_D(en.IdMedioDePago)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.MedioDePago, dr As DataRow)
      With o
         .IdMedioDePago = dr.Field(Of Integer)(Entidades.MedioDePago.Columnas.IdMedioDePago.ToString())
         .NombreMedioDePago = dr.Field(Of String)(Entidades.MedioDePago.Columnas.NombreMedioDePago.ToString())

         'CuentaContable
         .IdCuenta = dr.Field(Of Long?)(Entidades.MedioDePago.Columnas.IdCuenta.ToString()).IfNull()
         .CuentaContable = New ContabilidadCuentas(da)._GetUna(.IdCuenta, AccionesSiNoExisteRegistro.Nulo)
      End With
   End Sub
#End Region

#Region "Metodos Publicos"

   Public Sub _Insertar(entidad As Entidades.MedioDePago)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.MedioDePago)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.MedioDePago)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function Get1(idMedioDePago As Integer) As DataTable
      Return New SqlServer.MediosdePago(da).Buscar("IdMedioDePago", idMedioDePago.ToString())
   End Function

   Public Function GetTodas() As List(Of Entidades.MedioDePago)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.MedioDePago())
   End Function

   Public Function GetUna(idMedioDePago As Integer) As Entidades.MedioDePago
      Return GetUna(idMedioDePago, AccionesSiNoExisteRegistro.Excepcion)
   End Function

   Public Function GetUna(idMedioDePago As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.MedioDePago
      Return CargaEntidad(Get1(idMedioDePago), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.MedioDePago(),
                          accion, Function() String.Format("No existe el medio de pago {0}.", idMedioDePago))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.MediosdePago(da).GetCodigoMaximo()
   End Function
#End Region

End Class
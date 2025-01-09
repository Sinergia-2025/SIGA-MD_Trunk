Public Class RepartosCobranzas
   Inherits Eniac.Reglas.Base

   Friend Const IdCobranzaBorrador As Integer = -1

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.RepartoCobranza.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RepartoCobranza)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RepartoCobranza)))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RepartoCobranza)))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.RepartosCobranzas(Me.da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.RepartosCobranzas(Me.da).RepartosCobranzas_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.RepartoCobranza, tipo As TipoSP)
      Dim sqlC As SqlServer.RepartosCobranzas = New SqlServer.RepartosCobranzas(da)

      Dim rComprobante = New RepartosCobranzasComprobantes(da)

      Select Case tipo
         Case TipoSP._I
            sqlC.RepartosCobranzas_I(en.IdSucursal, en.IdReparto, en.IdCobranza, en.FechaRendicion, en.IdCaja, en.FechaAlta, en.IdUsuarioAlta)
            rComprobante._Insertar(en)
         Case TipoSP._U
            sqlC.RepartosCobranzas_U(en.IdSucursal, en.IdReparto, en.IdCobranza, en.FechaRendicion, en.IdCaja, en.FechaAlta, en.IdUsuarioAlta)
            rComprobante._Borrar(en)
            rComprobante._Insertar(en)
         Case TipoSP._D
            rComprobante._Borrar(en)
            sqlC.RepartosCobranzas_D(en.IdSucursal, en.IdReparto, en.IdCobranza)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RepartoCobranza, dr As DataRow)
      With o
         .IdSucursal = dr.Field(Of Integer)(Entidades.RepartoCobranza.Columnas.IdSucursal.ToString())
         .IdReparto = dr.Field(Of Integer)(Entidades.RepartoCobranza.Columnas.IdReparto.ToString())
         .IdCobranza = dr.Field(Of Integer)(Entidades.RepartoCobranza.Columnas.IdCobranza.ToString())
         .FechaRendicion = dr.Field(Of DateTime)(Entidades.RepartoCobranza.Columnas.FechaRendicion.ToString())

         .IdCaja = dr.Field(Of Integer)(Entidades.RepartoCobranza.Columnas.IdCaja.ToString())
         .FechaAlta = dr.Field(Of DateTime)(Entidades.RepartoCobranza.Columnas.FechaAlta.ToString())
         .IdUsuarioAlta = dr.Field(Of String)(Entidades.RepartoCobranza.Columnas.IdUsuarioAlta.ToString())

         .Comprobantes = New RepartosCobranzasComprobantes(da).GetTodos(.IdSucursal, .IdReparto, .IdCobranza)

      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Sub _Insertar(entidad As Entidades.RepartoCobranza)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Sub _Actualizar(entidad As Entidades.RepartoCobranza)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Sub _Borrar(entidad As Entidades.RepartoCobranza)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub
   Public Sub _Borrar(idSucursal As Integer, idReparto As Integer, idCobranza As Integer)
      _Borrar(New Entidades.RepartoCobranza() With {.IdSucursal = idSucursal, .IdReparto = idReparto, .IdCobranza = idCobranza})
   End Sub

   Public Function GetBorrador(idSucursal As Integer, idReparto As Integer) As Entidades.RepartoCobranza
      Return GetUno(idSucursal, idReparto, idCobranza:=-1, accion:=AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetBorrador(idSucursal As Integer, idReparto As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.RepartoCobranza
      Return GetUno(idSucursal, idReparto, idCobranza:=-1, accion:=accion)
   End Function
   Public Function GetUno(idSucursal As Integer, idReparto As Integer, idCobranza As Integer) As Entidades.RepartoCobranza
      Return GetUno(idSucursal, idReparto, idCobranza, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idSucursal As Integer, idReparto As Integer, idCobranza As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.RepartoCobranza
      Return CargaEntidad(New SqlServer.RepartosCobranzas(Me.da).RepartosCobranzas_G1(idSucursal, idReparto, idCobranza),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranza(),
                          accion, Function() String.Format("No existe Cobranza de Reparto con IdSucursal: {0}, IdReparto: {1} y IdCobranza: {2}", idSucursal, idReparto, idCobranza))
   End Function

   Public Function GetTodos() As List(Of Entidades.RepartoCobranza)
      Return CargaLista(Me.GetAll(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RepartoCobranza())
   End Function

   Public Function Existe(idSucursal As Integer, idReparto As Integer, idCobranza As Integer) As Boolean
      Return GetUno(idSucursal, idReparto, idCobranza, AccionesSiNoExisteRegistro.Nulo) IsNot Nothing
   End Function

   Public Function GetMaximoIdCobranza(idSucursal As Integer, idReparto As Integer) As Integer
      Return New SqlServer.RepartosCobranzas(da).GetMaximoIdCobranza(idSucursal, idReparto)
   End Function

#End Region

End Class
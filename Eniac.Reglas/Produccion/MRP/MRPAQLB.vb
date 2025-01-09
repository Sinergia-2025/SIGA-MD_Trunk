Public Class MRPAQLB
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.MRPAQLB.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MRPAQLB), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MRPAQLB), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.MRPAQLB), TipoSP._D))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.MRPAQLB(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.MRPAQLB(da).MRPAQLB_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.MRPAQLB, tipo As TipoSP)
      Dim sqlC = New SqlServer.MRPAQLB(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.MRPAQLB_I(en.LimiteCalidadAceptable, en.CodigoNivel,
                           en.TamanoMuestreo, en.CantidadAceptacion, en.CantidadRechazo)
         Case TipoSP._U
            sqlC.MRPAQLB_U(en.LimiteCalidadAceptable, en.CodigoNivel,
                           en.TamanoMuestreo, en.CantidadAceptacion, en.CantidadRechazo)
         Case TipoSP._D
            sqlC.MRPAQLB_D(en.LimiteCalidadAceptable, en.CodigoNivel)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.MRPAQLB, dr As DataRow)
      With o
         .LimiteCalidadAceptable = dr.Field(Of Decimal)(Entidades.MRPAQLB.Columnas.LimiteCalidadAceptable.ToString())
         .CodigoNivel = dr.Field(Of String)(Entidades.MRPAQLB.Columnas.CodigoNivel.ToString())
         .TamanoMuestreo = dr.Field(Of Integer)(Entidades.MRPAQLB.Columnas.TamanoMuestreo.ToString())
         .CantidadAceptacion = dr.Field(Of Integer)(Entidades.MRPAQLB.Columnas.CantidadAceptacion.ToString())
         .CantidadRechazo = dr.Field(Of Integer)(Entidades.MRPAQLB.Columnas.CantidadRechazo.ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Function Get1(limiteCalidadAceptable As Decimal, codigoNivel As String) As DataTable
      Return New SqlServer.MRPAQLB(da).MRPAQLB_G1(limiteCalidadAceptable, codigoNivel)
   End Function
   Public Function GetUno(limiteCalidadAceptable As Decimal, codigoNivel As String) As Entidades.MRPAQLB
      Return GetUno(limiteCalidadAceptable, codigoNivel, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(limiteCalidadAceptable As Decimal, codigoNivel As String, accion As AccionesSiNoExisteRegistro) As Entidades.MRPAQLB
      Return CargaEntidad(Get1(limiteCalidadAceptable, codigoNivel), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.MRPAQLB(),
                          accion, Function() String.Format("No existe AQL B con Limite: {0} y código: {1}", limiteCalidadAceptable, codigoNivel))
   End Function
   Public Function GetTodos() As List(Of Entidades.MRPAQLB)
      Return CargaLista(GetAll(), Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.MRPAQLB())
   End Function
#End Region

End Class
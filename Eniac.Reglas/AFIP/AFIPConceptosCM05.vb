Public Class AFIPConceptosCM05
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = Entidades.AFIPConceptoCM05.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.AFIPConceptoCM05), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.AFIPConceptoCM05), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.AFIPConceptoCM05), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.AFIPConceptosCM05(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function
   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.AFIPConceptosCM05(da).AFIPConceptosCM05_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.AFIPConceptoCM05, tipo As TipoSP)
      Dim sqlC = New SqlServer.AFIPConceptosCM05(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.AFIPConceptosCM05_I(en.IdConceptoCM05, en.DescripcionConceptoCM05, en.TipoConceptoCM05)
         Case TipoSP._U
            sqlC.AFIPConceptosCM05_U(en.IdConceptoCM05, en.DescripcionConceptoCM05, en.TipoConceptoCM05)
         Case TipoSP._D
            sqlC.AFIPConceptosCM05_D(en.IdConceptoCM05)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.AFIPConceptoCM05, dr As DataRow)
      With o
         .IdConceptoCM05 = dr.Field(Of Integer)(Entidades.AFIPConceptoCM05.Columnas.IdConceptoCM05.ToString())
         .DescripcionConceptoCM05 = dr.Field(Of String)(Entidades.AFIPConceptoCM05.Columnas.DescripcionConceptoCM05.ToString())
         .TipoConceptoCM05 = dr.Field(Of String)(Entidades.AFIPConceptoCM05.Columnas.TipoConceptoCM05.ToString()).StringToEnum(Entidades.AFIPConceptoCM05.TiposConceptosCM05.INGRESOS)
      End With
   End Sub

#End Region

#Region "Metodos publicos"

   Public Function GetUno(IdConceptoCM05 As Integer) As Entidades.AFIPConceptoCM05
      Return GetUno(IdConceptoCM05, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(idConceptoCM05 As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.AFIPConceptoCM05
      Return CargaEntidad(Get1(idConceptoCM05), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.AFIPConceptoCM05(),
                          accion, Function() String.Format("No existe Concepto CM05 con código {0}", idConceptoCM05))
   End Function
   Public Function GetTodos() As List(Of Entidades.AFIPConceptoCM05)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.AFIPConceptoCM05())
   End Function

   Public Function GetTodos(tipoConceptoCM05 As Entidades.AFIPConceptoCM05.TiposConceptosCM05?) As List(Of Entidades.AFIPConceptoCM05)
      Return CargaLista(New SqlServer.AFIPConceptosCM05(da).AFIPConceptosCM05_GA_TipoConceptoCM05(tipoConceptoCM05),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.AFIPConceptoCM05())
   End Function

   Public Function Get1(idConceptoCM05 As Integer) As DataTable
      Return New SqlServer.AFIPConceptosCM05(da).AFIPConceptosCM05_G1(idConceptoCM05)
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.AFIPConceptosCM05(da).GetCodigoMaximo()
   End Function

#End Region

End Class
Public Class RegimenesPercepciones
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.RegimenPercepcion.NombreTabla, accesoDatos)
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RegimenPercepcion)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RegimenPercepcion)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RegimenPercepcion)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.RegimenesPercepciones(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.RegimenesPercepciones(da).RegimenesPercepciones_GA()
   End Function
   Public Overloads Function GetAll(idTipoImpuesto As String) As DataTable
      Return New SqlServer.RegimenesPercepciones(da).RegimenesPercepciones_GA(idTipoImpuesto)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.RegimenPercepcion, tipo As TipoSP)
      Dim sql = New SqlServer.RegimenesPercepciones(da)
      Dim rAlicuotas = New RegimenesPercepcionesAlicuotas(da)
      Select Case tipo
         Case TipoSP._I
            sql.RegimenesPercepciones_I(en.IdTipoImpuesto, en.IdRegimenPercepcion, en.NombreRegimenPercepcion, en.CodigoAFIP, en.ImporteNetoMinimo, en.ImpuestoMinimo)
            rAlicuotas._Insertar(en)
         Case TipoSP._U
            sql.RegimenesPercepciones_U(en.IdTipoImpuesto, en.IdRegimenPercepcion, en.NombreRegimenPercepcion, en.CodigoAFIP, en.ImporteNetoMinimo, en.ImpuestoMinimo)
            rAlicuotas._Actualizar(en)
         Case TipoSP._D
            rAlicuotas._Borrar(en)
            sql.RegimenesPercepciones_D(en.IdTipoImpuesto, en.IdRegimenPercepcion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RegimenPercepcion, dr As DataRow)
      With o
         .IdTipoImpuesto = dr.Field(Of String)(Entidades.RegimenPercepcion.Columnas.IdTipoImpuesto.ToString())
         .IdRegimenPercepcion = dr.Field(Of Integer)(Entidades.RegimenPercepcion.Columnas.IdRegimenPercepcion.ToString())

         .NombreRegimenPercepcion = dr.Field(Of String)(Entidades.RegimenPercepcion.Columnas.NombreRegimenPercepcion.ToString())
         .CodigoAFIP = dr.Field(Of Integer)(Entidades.RegimenPercepcion.Columnas.CodigoAFIP.ToString())

         .ImporteNetoMinimo = Math.Round(dr.Field(Of Decimal)(Entidades.RegimenPercepcion.Columnas.ImporteNetoMinimo.ToString()), 2)
         .ImpuestoMinimo = dr.Field(Of Decimal)(Entidades.RegimenPercepcion.Columnas.ImpuestoMinimo.ToString())

         .Alicuotas = New RegimenesPercepcionesAlicuotas(da).GetTodos(.IdTipoImpuesto, .IdRegimenPercepcion)
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.RegimenPercepcion)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RegimenPercepcion)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RegimenPercepcion)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Function GetTodos() As List(Of Entidades.RegimenPercepcion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RegimenPercepcion())
   End Function
   Public Function GetTodos(idTipoImpuesto As String) As List(Of Entidades.RegimenPercepcion)
      Return CargaLista(GetAll(idTipoImpuesto), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RegimenPercepcion())
   End Function

   Public Function Get1(idTipoImpuesto As String, idRegimenPercepcion As Integer) As DataTable
      Return New SqlServer.RegimenesPercepciones(da).RegimenesPercepciones_G1(idTipoImpuesto, idRegimenPercepcion)
   End Function
   Public Function GetUno(idTipoImpuesto As Entidades.TipoImpuesto.Tipos, idRegimenPercepcion As Integer) As Entidades.RegimenPercepcion
      Return GetUno(idTipoImpuesto.ToString(), idRegimenPercepcion)
   End Function
   Public Function GetUno(idTipoImpuesto As String, idRegimenPercepcion As Integer) As Entidades.RegimenPercepcion
      Return GetUno(idTipoImpuesto, idRegimenPercepcion, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoImpuesto As String, idRegimenPercepcion As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.RegimenPercepcion
      Return CargaEntidad(Get1(idTipoImpuesto, idRegimenPercepcion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RegimenPercepcion(),
                          accion, Function() String.Format("No existe el Regimen de Percepcion con tipo {0} e id {1}", idTipoImpuesto, idRegimenPercepcion))
   End Function

   Public Function Existe(idTipoImpuesto As String, idRegimenPercepcion As Integer) As Boolean
      Return EjecutaConConexion(Function() _Existe(idTipoImpuesto, idRegimenPercepcion))
   End Function
   Public Function _Existe(idTipoImpuesto As String, idRegimenPercepcion As Integer) As Boolean
      Return Get1(idTipoImpuesto, idRegimenPercepcion).Any()
   End Function

#End Region

End Class
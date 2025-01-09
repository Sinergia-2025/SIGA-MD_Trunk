Public Class RegimenesPercepcionesAlicuotas
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.RegimenPercepcionAlicuota.NombreTabla, accesoDatos)
   End Sub

#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.RegimenPercepcionAlicuota)))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.RegimenPercepcionAlicuota)))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.RegimenPercepcionAlicuota)))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.RegimenesPercepcionesAlicuotas(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.RegimenesPercepcionesAlicuotas(da).RegimenesPercepcionesAlicuotas_GA()
   End Function
   Public Overloads Function GetAll(idTipoImpuesto As String) As DataTable
      Return New SqlServer.RegimenesPercepcionesAlicuotas(da).RegimenesPercepcionesAlicuotas_GA(idTipoImpuesto)
   End Function
   Public Overloads Function GetAll(idTipoImpuesto As String, idRegimenPercepcion As Integer) As DataTable
      Return New SqlServer.RegimenesPercepcionesAlicuotas(da).RegimenesPercepcionesAlicuotas_GA(idTipoImpuesto, idRegimenPercepcion)
   End Function

#End Region

#Region "Metodos Privados"
   Private Sub EjecutaSP(en As Entidades.RegimenPercepcionAlicuota, tipo As TipoSP)
      Dim sql As SqlServer.RegimenesPercepcionesAlicuotas = New SqlServer.RegimenesPercepcionesAlicuotas(da)
      Select Case tipo
         Case TipoSP._I
            sql.RegimenesPercepcionesAlicuotas_I(en.IdTipoImpuesto, en.IdRegimenPercepcion, en.AlicuotaPercepcion)
         Case TipoSP._U
            sql.RegimenesPercepcionesAlicuotas_U(en.IdTipoImpuesto, en.IdRegimenPercepcion, en.AlicuotaPercepcion)
         Case TipoSP._D
            sql.RegimenesPercepcionesAlicuotas_D(en.IdTipoImpuesto, en.IdRegimenPercepcion, en.AlicuotaPercepcion)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.RegimenPercepcionAlicuota, dr As DataRow)
      With o
         .IdTipoImpuesto = dr.Field(Of String)(Entidades.RegimenPercepcionAlicuota.Columnas.IdTipoImpuesto.ToString())
         .IdRegimenPercepcion = dr.Field(Of Integer)(Entidades.RegimenPercepcionAlicuota.Columnas.IdRegimenPercepcion.ToString())

         .AlicuotaPercepcion = dr.Field(Of Decimal)(Entidades.RegimenPercepcionAlicuota.Columnas.AlicuotaPercepcion.ToString())
      End With
   End Sub
#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.RegimenPercepcionAlicuota)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RegimenPercepcionAlicuota)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RegimenPercepcionAlicuota)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.RegimenPercepcion)
      entidad.Alicuotas.ForEach(
         Sub(a)
            a.IdTipoImpuesto = entidad.IdTipoImpuesto
            a.IdRegimenPercepcion = entidad.IdRegimenPercepcion
            EjecutaSP(a, TipoSP._I)
         End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.RegimenPercepcion)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.RegimenPercepcion)
      _Borrar(New Entidades.RegimenPercepcionAlicuota() With
                  {
                     .IdTipoImpuesto = entidad.IdTipoImpuesto,
                     .IdRegimenPercepcion = entidad.IdRegimenPercepcion
                  })
   End Sub


   Public Function GetTodos() As List(Of Entidades.RegimenPercepcionAlicuota)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RegimenPercepcionAlicuota())
   End Function
   Public Function GetTodos(idTipoImpuesto As String) As List(Of Entidades.RegimenPercepcionAlicuota)
      Return CargaLista(GetAll(idTipoImpuesto), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RegimenPercepcionAlicuota())
   End Function
   Public Function GetTodos(idTipoImpuesto As String, idRegimenPercepcion As Integer) As List(Of Entidades.RegimenPercepcionAlicuota)
      Return CargaLista(GetAll(idTipoImpuesto, idRegimenPercepcion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RegimenPercepcionAlicuota())
   End Function

   Public Function Get1(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal) As DataTable
      Return New SqlServer.RegimenesPercepcionesAlicuotas(da).RegimenesPercepcionesAlicuotas_G1(idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion)
   End Function
   Public Function GetUno(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal) As Entidades.RegimenPercepcionAlicuota
      Return GetUno(idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUno(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal, accion As AccionesSiNoExisteRegistro) As Entidades.RegimenPercepcionAlicuota
      Return CargaEntidad(Get1(idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.RegimenPercepcionAlicuota(),
                          accion, Function() String.Format("No existe el Regimen de Percepcion con tipo {0}, id {1} y alicuota {2}", idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion))
   End Function

   Public Function Existe(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal) As Boolean
      Return EjecutaConConexion(Function() _Existe(idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion))
   End Function
   Public Function _Existe(idTipoImpuesto As String, idRegimenPercepcion As Integer, alicuotaPercepcion As Decimal) As Boolean
      Return Get1(idTipoImpuesto, idRegimenPercepcion, alicuotaPercepcion).Any()
   End Function

#End Region

End Class
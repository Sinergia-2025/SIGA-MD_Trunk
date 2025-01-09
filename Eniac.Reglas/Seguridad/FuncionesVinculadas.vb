Public Class FuncionesVinculadas
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New(Entidades.FuncionVinculada.NombreTabla, accesoDatos)
   End Sub
#End Region

#Region "Overrides"
   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, Entidades.FuncionVinculada)))
   End Sub
   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, Entidades.FuncionVinculada)))
   End Sub
   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, Entidades.FuncionVinculada)))
   End Sub
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return GetSQL().Buscar(entidad.Columna, entidad.Valor.ToString(), False)
   End Function
   Public Overrides Function GetAll() As DataTable
      Return GetSQL().FuncionesVinculadas_GA()
   End Function
#End Region

#Region "Metodos Privados"
   Private Function GetSQL() As SqlServer.FuncionesVinculadas
      Return New SqlServer.FuncionesVinculadas(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.FuncionVinculada, tipo As TipoSP)
      Dim sql = GetSQL()
      Select Case tipo
         Case TipoSP._I
            sql.FuncionesVinculadas_I(en.IdFuncion, en.IdFuncionVinculada)
         Case TipoSP._U
            Throw New NotImplementedException("El tipo TipoSP._U de Reglas.FuncionesVinculadas.EjecutaSP no se implementa por falta de campos para actualizar")
            'sql.FuncionesVinculadas_U(en.IdFuncion, en.IdFuncionVinculada)
         Case TipoSP._D
            sql.FuncionesVinculadas_D(en.IdFuncion, en.IdFuncionVinculada)
      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.FuncionVinculada, dr As DataRow)
      With o
         Dim rFunc = New Funciones(da)
         o.Funcion = rFunc.GetUna(dr.Field(Of String)(Entidades.FuncionVinculada.Columnas.IdFuncion.ToString()), cargaDocumentos:=False, cargaVinculadas:=False)
         o.FuncionVinculada = rFunc.GetUna(dr.Field(Of String)(Entidades.FuncionVinculada.Columnas.IdFuncionVinculada.ToString()), cargaDocumentos:=False, cargaVinculadas:=False)
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Sub _Insertar(entidad As Entidades.FuncionVinculada)
      EjecutaSP(entidad, TipoSP._I)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.FuncionVinculada)
      EjecutaSP(entidad, TipoSP._U)
   End Sub
   Public Sub _Borrar(entidad As Entidades.FuncionVinculada)
      EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub _Insertar(entidad As Entidades.Funcion)
      entidad.FuncionesVinculadas.ForEachSecure(
      Sub(en)
         en.Funcion = entidad
         _Insertar(en)
      End Sub)
   End Sub
   Public Sub _Actualizar(entidad As Entidades.Funcion)
      _Borrar(entidad)
      _Insertar(entidad)
   End Sub
   Public Sub _Borrar(entidad As Entidades.Funcion)
      _Borrar(New Entidades.FuncionVinculada() With {.Funcion = entidad})
   End Sub

   Public Overloads Function GetAll(idFuncion As String) As DataTable
      Return GetSQL().FuncionesVinculadas_GA(idFuncion)
   End Function
   Public Overloads Function Get1(idFuncion As String, idFuncionVinculada As String) As DataTable
      Return GetSQL().FuncionesVinculadas_G1(idFuncion, idFuncionVinculada)
   End Function
   Public Function GetUna(idFuncion As String, idFuncionVinculada As String) As Entidades.FuncionVinculada
      Return GetUna(idFuncion, idFuncionVinculada, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idFuncion As String, idFuncionVinculada As String, accion As AccionesSiNoExisteRegistro) As Entidades.FuncionVinculada
      Return CargaEntidad(Get1(idFuncion, idFuncionVinculada), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.FuncionVinculada(),
                          accion, Function() String.Format("No existe Función Vinculada con Id: {1} para la función {0}", idFuncion, idFuncionVinculada))
   End Function
   Public Function GetTodos(idFuncion As String) As List(Of Entidades.FuncionVinculada)
      Return CargaLista(GetAll(idFuncion), Sub(o, dr) CargarUna(o, dr), Function() New Entidades.FuncionVinculada())
   End Function
#End Region

End Class
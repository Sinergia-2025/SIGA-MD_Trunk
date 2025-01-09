Public Class Funciones
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Funciones", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Funcion), TipoSP._I))
   End Sub
   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Funcion), TipoSP._U))
   End Sub
   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Funcion), TipoSP._U))
   End Sub
   Public Overloads Function Buscar(entidad As Entidades.Buscar, igual As Boolean) As DataTable
      Return GetSql().Buscar(entidad.Columna, entidad.Valor.ToString(), igual)
   End Function
   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Funciones = GetSql()
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString(), False)
   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetSql().Funciones_GA()
   End Function

#End Region

   Public Function GetFiltradoPorCodigoNombre(CodigoFuncion As String, NombreFuncion As String) As DataTable
      Return EjecutaConConexion(
         Function()
            Dim dt = GetSql().Funciones_GA(CodigoFuncion, NombreFuncion, True)
            If Not dt.Any() Then
               dt = GetSql().Funciones_GA(CodigoFuncion, NombreFuncion, False)
            End If
            Return dt
         End Function)
   End Function

   Public Sub GrabarImagen(imagen() As Byte, funcion As String)
      If imagen IsNot Nothing AndAlso imagen.Length > 0 Then
         Dim stbQuery = New StringBuilder()
         With stbQuery
            .AppendFormat(" UPDATE Funciones SET Icono = @Imagen WHERE Id = '{0}'", funcion)
         End With
         Dim oDatos = New Datos.DataAccess("CadenaSegura")
         oDatos.Command.CommandText = stbQuery.ToString()
         oDatos.Command.CommandType = CommandType.Text
         Dim oParameter = oDatos.Command.CreateParameter()
         oParameter.ParameterName = "@Imagen"
         oParameter.DbType = DbType.Binary
         oParameter.Size = imagen.Length
         oParameter.Value = imagen
         oDatos.Command.Parameters.Add(oParameter)
         oDatos.OpenConection()
         oDatos.Command.Connection = oDatos.Connection
         oDatos.ExecuteNonQuery(oDatos.Command)
         oDatos.CloseConection()
      End If
   End Sub

   Public Function GetTodas() As List(Of Entidades.Funcion)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUna(o, dr, cargaDocumentos:=False, cargaVinculadas:=False), Function() New Entidades.Funcion())
   End Function
   Public Function Get1(idFuncion As String) As DataTable
      Return GetSql().Funciones_G1(idFuncion)
   End Function
   Public Function GetUna(idFuncion As String, cargaDocumentos As Boolean, cargaVinculadas As Boolean) As Entidades.Funcion
      Return GetUna(idFuncion, cargaDocumentos, cargaVinculadas, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function GetUna(idFuncion As String, cargaDocumentos As Boolean, cargaVinculadas As Boolean, accion As AccionesSiNoExisteRegistro) As Entidades.Funcion
      Return CargaEntidad(Get1(idFuncion), Sub(o, dr) CargarUna(o, dr, cargaDocumentos, cargaVinculadas), Function() New Entidades.Funcion(),
                          accion, Function() String.Format("La función '{0}' no existe. Por favor verifique.", idFuncion))
   End Function

   Private Function GetSql() As SqlServer.Funciones
      Return New SqlServer.Funciones(da)
   End Function
   Private Sub EjecutaSP(en As Entidades.Funcion, tipo As TipoSP)
      Dim reFuncionesDocumentos = New FuncionesDocumentos(da)
      Dim rFuncVinc = New FuncionesVinculadas(da)
      Dim sql = GetSql()

      Select Case tipo
         Case TipoSP._I
            sql.Funciones_I(en.Id, en.Nombre, en.Descripcion,
                            en.EsMenu, en.EsBoton, en.Enabled, en.Visible,
                            en.IdPadre, en.Posicion, en.Archivo, en.Pantalla, en.Parametros,
                            en.PermiteMultiplesInstancias, en.Plus, en.Express, en.Basica, en.PV,
                            en.IdModulo, en.EsMDIChild)

            ' Inserto los links
            reFuncionesDocumentos.Insertar(en)
            rFuncVinc._Insertar(en)

            GrabarImagen(en.Icono, en.Id)
         Case TipoSP._U
            ' Primero elimino los Documentos de la función
            reFuncionesDocumentos.Borrar(en.Id)

            sql.Funciones_U(en.Id, en.Nombre, en.Descripcion,
                            en.EsMenu, en.EsBoton, en.Enabled, en.Visible,
                            en.IdPadre, en.Posicion, en.Archivo, en.Pantalla, en.Parametros,
                            en.PermiteMultiplesInstancias, en.Plus, en.Express, en.Basica, en.PV,
                            en.IdModulo, en.EsMDIChild)

            ' Inserto nuevamente los links
            reFuncionesDocumentos.Insertar(en)
            rFuncVinc._Actualizar(en)

            GrabarImagen(en.Icono, en.Id)
         Case TipoSP._D

            reFuncionesDocumentos.Borrar(en.Id)
            rFuncVinc._Borrar(en)
            sql.Funciones_D(en.Id)

      End Select
   End Sub
   Private Sub CargarUna(o As Entidades.Funcion, dr As DataRow, cargaDocumentos As Boolean, cargaVinculadas As Boolean)
      With o
         o.Id = dr(Entidades.Funcion.Columnas.Id.ToString()).ToString()
         o.Nombre = dr(Entidades.Funcion.Columnas.Nombre.ToString()).ToString()
         o.Descripcion = dr(Entidades.Funcion.Columnas.Descripcion.ToString()).ToString()
         o.EsMenu = Boolean.Parse(dr(Entidades.Funcion.Columnas.EsMenu.ToString()).ToString())
         o.EsBoton = Boolean.Parse(dr(Entidades.Funcion.Columnas.EsBoton.ToString()).ToString())
         o.Enabled = Boolean.Parse(dr(Entidades.Funcion.Columnas.Enabled.ToString()).ToString())
         o.Visible = Boolean.Parse(dr(Entidades.Funcion.Columnas.Visible.ToString()).ToString())
         o.IdPadre = dr(Entidades.Funcion.Columnas.IdPadre.ToString()).ToString()
         o.Posicion = Integer.Parse(dr(Entidades.Funcion.Columnas.Posicion.ToString()).ToString())
         o.Archivo = dr(Entidades.Funcion.Columnas.Archivo.ToString()).ToString()
         o.Pantalla = dr(Entidades.Funcion.Columnas.Pantalla.ToString()).ToString()
         o.Parametros = dr(Entidades.Funcion.Columnas.Parametros.ToString()).ToString()
         o.PermiteMultiplesInstancias = Boolean.Parse(dr(Entidades.Funcion.Columnas.PermiteMultiplesInstancias.ToString()).ToString())
         o.Plus = dr(Entidades.Funcion.Columnas.Plus.ToString()).ToString()
         o.Express = dr(Entidades.Funcion.Columnas.Express.ToString()).ToString()
         o.Basica = dr(Entidades.Funcion.Columnas.Basica.ToString()).ToString()
         o.PV = dr(Entidades.Funcion.Columnas.PV.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.Funcion.Columnas.IdModulo.ToString()).ToString()) Then
            o.IdModulo = Integer.Parse(dr(Entidades.Funcion.Columnas.IdModulo.ToString()).ToString())
         End If
         o.EsMDIChild = Boolean.Parse(dr(Entidades.Funcion.Columnas.EsMDIChild.ToString()).ToString())

         If cargaDocumentos Then
            .Documentos = New FuncionesDocumentos(da).GetTodos(.Id)
         End If
         If cargaVinculadas Then
            .FuncionesVinculadas = New FuncionesVinculadas(da).GetTodos(.Id)
         End If
      End With
   End Sub

   Public Function ExisteFuncion(idFuncion As String) As Boolean
      Return GetSql().ExisteFuncion(idFuncion)
   End Function
   Public Function ExisteFuncionPorPantalla(pantalla As String) As Boolean
      Return GetSql().ExisteFuncionPorPantalla(pantalla)
   End Function
   Public Function FuncionHabilitada(idFuncion As String) As Boolean
      Return GetSql().FuncionHabilitada(idFuncion)
   End Function
End Class
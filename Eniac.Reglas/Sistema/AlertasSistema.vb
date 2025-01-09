Imports Eniac.Entidades
Imports Eniac.Entidades.SistemaE
Namespace Sistema
   Public Class AlertasSistema
      Inherits Base

#Region "Constructores"

      Public Sub New()
         Me.New(New Datos.DataAccess())
      End Sub

      Public Sub New(accesoDatos As Datos.DataAccess)
         MyBase.New(AlertaSistema.NombreTabla, accesoDatos)
      End Sub

#End Region

#Region "Overrides"

      Public Overrides Sub Insertar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Insertar(DirectCast(entidad, AlertaSistema)))
      End Sub
      Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Actualizar(DirectCast(entidad, AlertaSistema)))
      End Sub
      Public Overrides Sub Borrar(entidad As Entidades.Entidad)
         EjecutaConTransaccion(Sub() _Borrar(DirectCast(entidad, AlertaSistema)))
      End Sub

      Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
         Return New SqlServer.Sistema.AlertasSistema(da).Buscar(entidad.Columna, entidad.Valor.ToString())
      End Function

      Public Overrides Function GetAll() As DataTable
         Return New SqlServer.Sistema.AlertasSistema(da).AlertasSistema_GA()
      End Function
#End Region

#Region "Metodos Privados"

      Private Sub EjecutaSP(en As AlertaSistema, tipo As TipoSP)
         Dim sqlC = New SqlServer.Sistema.AlertasSistema(da)
         Dim rCondiciones = New AlertasSistemaCondiciones(da)
         Dim rPermisos = New AlertasSistemaPermisos(da)
         Dim rRoles = New AlertasSistemaRoles(da)
         Dim rUsuarios = New AlertasSistemaUsuarios(da)
         Select Case tipo
            Case TipoSP._I
               If en.IdAlertaSistema = 0 Then en.IdAlertaSistema = GetCodigoMaximo() + 1
               sqlC.AlertasSistema_I(en.IdAlertaSistema, en.TituloAlerta, en.ConsultaAlerta,
                                     en.PermisosCondicion, en.IdFuncionClick, en.ParametrosPantalla,
                                     en.UtilizaConsultaGenerica)
               rCondiciones._Insertar(en)
               rPermisos._Insertar(en)
               rRoles._Insertar(en)
               rUsuarios._Insertar(en)
            Case TipoSP._U
               sqlC.AlertasSistema_U(en.IdAlertaSistema, en.TituloAlerta, en.ConsultaAlerta,
                                     en.PermisosCondicion, en.IdFuncionClick, en.ParametrosPantalla,
                                     en.UtilizaConsultaGenerica)
               rCondiciones._Actualizar(en)
               rPermisos._Actualizar(en)
               rRoles._Actualizar(en)
               rUsuarios._Actualizar(en)
            Case TipoSP._D
               rCondiciones._Borrar(en)
               rPermisos._Borrar(en)
               rRoles._Borrar(en)
               rUsuarios._Borrar(en)
               sqlC.AlertasSistema_D(en.IdAlertaSistema)
         End Select
      End Sub

      Private Sub CargarUno(o As AlertaSistema, dr As DataRow)
         With o
            .IdAlertaSistema = dr.Field(Of Integer)(AlertaSistema.Columnas.IdAlertaSistema.ToString())
            .TituloAlerta = dr.Field(Of String)(AlertaSistema.Columnas.TituloAlerta.ToString())

            .ConsultaAlerta = dr.Field(Of String)(AlertaSistema.Columnas.ConsultaAlerta.ToString())

            .PermisosCondicion = dr.Field(Of String)(AlertaSistema.Columnas.PermisosCondicion.ToString()).StringToEnum(CondicionesPermisoAlerta.AND)

            .IdFuncionClick = dr.Field(Of String)(AlertaSistema.Columnas.IdFuncionClick.ToString())
            .ParametrosPantalla = dr.Field(Of String)(AlertaSistema.Columnas.ParametrosPantalla.ToString())

            .UtilizaConsultaGenerica = dr.Field(Of Boolean)(AlertaSistema.Columnas.UtilizaConsultaGenerica.ToString())

            .Condiciones = New AlertasSistemaCondiciones(da).GetTodos(.IdAlertaSistema)
            .Permisos = New AlertasSistemaPermisos(da).GetTodos(.IdAlertaSistema)
            .Roles = New AlertasSistemaRoles(da).GetTodos(.IdAlertaSistema)
            .Usuarios = New AlertasSistemaUsuarios(da).GetTodos(.IdAlertaSistema)

         End With
      End Sub
#End Region

#Region "Metodos publicos"
      Public Sub _Insertar(entidad As AlertaSistema)
         EjecutaSP(entidad, TipoSP._I)
      End Sub
      Public Sub _Actualizar(entidad As AlertaSistema)
         EjecutaSP(entidad, TipoSP._U)
      End Sub
      Public Sub _Borrar(entidad As AlertaSistema)
         EjecutaSP(entidad, TipoSP._D)
      End Sub

      Public Function GetUno(idAlertaSistema As Integer) As AlertaSistema
         Return GetUno(idAlertaSistema, AccionesSiNoExisteRegistro.Excepcion)
      End Function
      Public Function GetUno(idAlertaSistema As Integer, accion As AccionesSiNoExisteRegistro) As AlertaSistema
         Return CargaEntidad(New SqlServer.Sistema.AlertasSistema(da).AlertasSistema_G1(idAlertaSistema),
                             Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistema(),
                             accion, Function() String.Format("No existe Alerta con Id: {0}", idAlertaSistema))
      End Function
      Public Function GetTodos() As List(Of AlertaSistema)
         Return CargaLista(GetAll(),
                           Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistema())
      End Function
      Public Function GetTodos(idUsuario As String) As List(Of AlertaSistema)
         Return CargaLista(New SqlServer.Sistema.AlertasSistema(da).AlertasSistema_GA(idUsuario),
                           Sub(o, dr) CargarUno(o, dr), Function() New AlertaSistema())
      End Function

      Public Function GetCodigoMaximo() As Integer
         Return New SqlServer.Sistema.AlertasSistema(da).GetCodigoMaximo()
      End Function

      Public Function EjecutaConsulta(alerta As AlertaSistema) As DataTable
         Return EjecutaConsulta(alerta.ConsultaAlerta, New VariablesAlerta().Inicializar(DestinoListaVariables.Consulta))
      End Function
      Public Function EjecutaConsulta(sql As String, variables As VariablesAlerta) As DataTable
         Dim consulta = If(variables IsNot Nothing AndAlso sql.Contains("@@"), sql.Replace2(variables.ToReplaceTuple()), sql)
         Return EjecutaConsulta(consulta)
      End Function
      Private Function EjecutaConsulta(sql As String) As DataTable
         Return da.GetDataTable(sql)
      End Function

      Public Function ConvertirVariablesAReplaceTuple(variables As List(Of Tuple(Of String, String, String))) As List(Of ReplaceTuple)
         Return variables.ConvertAll(Function(v) New ReplaceTuple(v.Item1, Function() v.Item3))
      End Function
      Public Class VariablesAlerta
         Inherits List(Of VariableAlerta)
         Public Function ToReplaceTuple() As List(Of ReplaceTuple)
            Return ConvertAll(Function(v) New ReplaceTuple(v.Variable, Function() v.ValorEjecucionPrueba))
         End Function
         Public Function Inicializar(para As DestinoListaVariables) As VariablesAlerta
            If para <> DestinoListaVariables.Consulta Then
               Add("@@COUNT@@", "Cantidad de registros en la consulta ejecutada")
            End If
            Add(New VariableAlerta("@@IDUSUARIO@@", "Usuario que ingresó a la aplicación", actual.Nombre))
            Add(New VariableAlerta("@@IDSUCURSAL@@", "Id Sucursal seleccionada al ingresar a la aplicación", actual.Sucursal.Id.ToString()))
            Add(New VariableAlerta("@@NOMBRESUCURSAL@@", "Nombre Sucursal seleccionada al ingresar a la aplicación", actual.Sucursal.Nombre.ToString()))
            Add(New VariableAlerta("@@IDEMPRESA@@", "Id Empresa de la Sucursal seleccionada al ingresar a la aplicación", actual.Sucursal.IdEmpresa.ToString()))
            Add(New VariableAlerta("@@NOMBREEMPRESA@@", "Nombre Empresa de la Sucursal seleccionada al ingresar a la aplicación", actual.Sucursal.NombreEmpresa.ToString()))
            Return Me
         End Function
         Public Overloads Function Add(variable As String, descripcion As String) As VariablesAlerta
            Return Add(variable, descripcion, String.Empty)
         End Function
         Public Overloads Function Add(variable As String, descripcion As String, valorEjecucionPrueba As String) As VariablesAlerta
            If Not Exists(Function(x) x.Variable = variable) Then
               Add(New VariableAlerta(variable, descripcion, valorEjecucionPrueba))
            Else
               Update(variable, valorEjecucionPrueba)
            End If
            Return Me
         End Function
         Public Function Update(variable As String, valorEjecucionPrueba As String) As VariablesAlerta
            Dim actual = FirstOrDefault(Function(x) x.Variable = variable)
            If actual IsNot Nothing Then
               actual.ValorEjecucionPrueba = valorEjecucionPrueba
            End If
            Return Me
         End Function
      End Class
      Public Class VariableAlerta
         Public Property Variable As String
         Public Property Descripcion As String
         Public Property ValorEjecucionPrueba As String
         Public Sub New(variable As String, descripcion As String, valorEjecucionPrueba As String)
            Me.Variable = variable
            Me.Descripcion = descripcion
            Me.ValorEjecucionPrueba = valorEjecucionPrueba
         End Sub
      End Class
      Public Enum DestinoListaVariables
         Consulta
         Mensaje
      End Enum

#End Region

   End Class
End Namespace
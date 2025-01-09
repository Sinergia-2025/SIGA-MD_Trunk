Public Class Chequeras
   Inherits Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = Entidades.Chequera.NombreTabla
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = Entidades.Chequera.NombreTabla
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Chequera), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Chequera), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.Chequera), TipoSP._D))
   End Sub

   Public Sub _Inserta(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.Chequera), TipoSP._I)
   End Sub

   Public Sub _Actualiza(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.Chequera), TipoSP._U)
   End Sub

   Public Sub _Borra(entidad As Entidades.Entidad)
      Me.EjecutaSP(DirectCast(entidad, Entidades.Chequera), TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Chequeras = New SqlServer.Chequeras(da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(idCuentaBancaria:=0)
   End Function
   Public Overloads Function GetAll(idCuentaBancaria As Integer) As System.Data.DataTable
      Dim sChequeras As SqlServer.Chequeras = New SqlServer.Chequeras(da)
      Return sChequeras.Chequeras_GA(idCuentaBancaria)
   End Function

#End Region

#Region "Métodos Públicos"

   '# Obtener el siguiente Número de Cheque disponible en mi chequera
   Public Function GetSiguienteChequeDisponible(idCuentaBancaria As Integer, idChequera As Integer) As Integer
      Dim sql As SqlServer.Chequeras = New SqlServer.Chequeras(da)
      Dim dt As DataTable = sql.GetSiguienteChequeDisponible(idCuentaBancaria, idChequera)

      Dim result As Integer = 0
      If dt.Rows.Count > 0 Then
         '# Todo el valor máximo entre el Actual y el Desde
         result = If(dt.Rows(0).Field(Of Integer)(Entidades.Chequera.Columnas.NumeroActual) >= dt.Rows(0).Field(Of Integer)(Entidades.Chequera.Columnas.NumeroDesde),
            dt.Rows(0).Field(Of Integer)(Entidades.Chequera.Columnas.NumeroActual) + 1,
            dt.Rows(0).Field(Of Integer)(Entidades.Chequera.Columnas.NumeroDesde))
      End If

      Return result
   End Function

   '# Actualizar el numerador de último cheque registrado
   Public Sub ActualizarNumeroActual(idChequera As Integer, nroChequeRegistrado As Integer)
      Dim sql As SqlServer.Chequeras = New SqlServer.Chequeras(da)
      sql.ActualizarNumeroActual(idChequera, nroChequeRegistrado)

      '# También verifico que aún queden cheques a emitir en la chequera. Caso contrario inactivo la chequera.
      Dim eChequera As Entidades.Chequera = GetUno(idChequera)
      If eChequera.NumeroHasta = eChequera.NumeroActual Then
         sql.Chequeras_U(eChequera.IdChequera, eChequera.IdCuentaBancaria, eChequera.NumeroDesde, eChequera.NumeroHasta, eChequera.NombreChequera, activo:=False, descripcion:=eChequera.Descripcion)
      End If
   End Sub

   '# CuentaBancaria AND NumeroDesde (Alternative Key)
   Public Function GetUno(idCuentaBancaria As Integer, numeroDesde As Integer) As Entidades.Chequera
      Dim sChequeras As SqlServer.Chequeras = New SqlServer.Chequeras(da)
      Return CargaEntidad(sChequeras.Chequeras_G1(idCuentaBancaria, numeroDesde),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Chequera(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe la chequera {0} {1}", idCuentaBancaria, numeroDesde))
   End Function

   '# IdChequera
   Public Function GetUno(idChequera As Integer) As Entidades.Chequera
      Dim sChequeras As SqlServer.Chequeras = New SqlServer.Chequeras(da)
      Return CargaEntidad(sChequeras.Chequeras_G1(idChequera),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Chequera(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe la chequera {0}", idChequera))
   End Function

   Public Function GetTodos() As List(Of Entidades.Chequera)
      Return GetTodos(idCuentaBancaria:=0)
   End Function

   '# Get Todos by IdCuentaBancaria
   Public Function GetTodos(idCuentaBancaria As Integer) As List(Of Entidades.Chequera)
      Return CargaLista(Me.GetAll(idCuentaBancaria),
                     Sub(o, dr) Me.CargarUno(o, dr),
                     Function() New Entidades.Chequera)
   End Function

#End Region

#Region "Métodos Privados"
   Private Sub ValidarRangosChequeras(en As Entidades.Chequera, sql As SqlServer.Chequeras)

      '# Valido el rango de la chequera
      If sql.ValidarRango(en.NumeroDesde, en.NumeroHasta, en.IdCuentaBancaria, en.IdChequera).Rows.Count > 0 Then
         Throw New Exception("ATENCIÓN: El rango de la Chequera se solapa con el rango de otra ya creada.")
      End If

   End Sub

   Private Sub EjecutaSP(en As Entidades.Chequera, tipo As TipoSP)
      Dim sChequeras As SqlServer.Chequeras = New SqlServer.Chequeras(da)
      Select Case tipo
         Case TipoSP._I

            '# Valido que no existe la chequera cargada en el sistema
            If New Reglas.Chequeras().GetUno(en.IdCuentaBancaria, en.NumeroDesde) IsNot Nothing Then
               Throw New Exception("ATENCIÓN: Esta Chequera ya se encuentra registrada en el sistema.")
            End If

            '# Id Chequera
            en.IdChequera = CInt(sChequeras.GetCodigoMaximo(Entidades.Chequera.Columnas.IdChequera.ToString(), Entidades.Chequera.NombreTabla)) + 1

            '# Valido rangos de chequeras
            Me.ValidarRangosChequeras(en, sChequeras)
            '
            sChequeras.Chequeras_I(en.IdChequera, en.IdCuentaBancaria, en.NumeroDesde, en.NumeroHasta, en.NombreChequera, en.NumeroActual, en.Activo, en.Descripcion)
         Case TipoSP._U

            '# Valido rangos de chequeras
            Me.ValidarRangosChequeras(en, sChequeras)

            sChequeras.Chequeras_U(en.IdChequera, en.IdCuentaBancaria, en.NumeroDesde, en.NumeroHasta, en.NombreChequera, en.Activo, en.Descripcion)
         Case TipoSP._D
            sChequeras.Chequeras_D(en.IdChequera)
      End Select
   End Sub

   Private Sub CargarUno(eChequera As Entidades.Chequera, dr As DataRow)
      With eChequera
         .IdChequera = dr.Field(Of Integer)(Entidades.Chequera.Columnas.IdChequera.ToString())
         .IdCuentaBancaria = dr.Field(Of Integer)(Entidades.Chequera.Columnas.IdCuentaBancaria.ToString())
         .NumeroDesde = dr.Field(Of Integer)(Entidades.Chequera.Columnas.NumeroDesde.ToString())
         .NumeroHasta = dr.Field(Of Integer)(Entidades.Chequera.Columnas.NumeroHasta.ToString())
         .NombreChequera = dr.Field(Of String)(Entidades.Chequera.Columnas.NombreChequera.ToString())
         .NumeroActual = dr.Field(Of Integer)(Entidades.Chequera.Columnas.NumeroActual.ToString())
         .Activo = dr.Field(Of Boolean)(Entidades.Chequera.Columnas.Activo.ToString())
         .Descripcion = dr.Field(Of String)(Entidades.Chequera.Columnas.Descripcion.ToString())
      End With
   End Sub

#End Region

End Class

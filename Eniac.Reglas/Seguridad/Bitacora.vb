Public Class Bitacora
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "Bitacora"
      da = accesoDatos
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Bitacora = New SqlServer.Bitacora(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Bitacora(Me.da).Bitacora_GA()
   End Function

   Public Overloads Function GetAll(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                                    idUsuario As String, idFuncion As String, descripcion As String,
                                    nombrePC As String, tipoBitacora As Entidades.Bitacora.TipoBitacora?) As System.Data.DataTable
      Return New SqlServer.Bitacora(Me.da).Bitacora_GA(idSucursal, fechaDesde, fechaHasta, idUsuario, idFuncion, descripcion, nombrePC, tipoBitacora)
   End Function

#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim en As Entidades.Bitacora = DirectCast(entidad, Entidades.Bitacora)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.Bitacora = New SqlServer.Bitacora(Me.da)

         Select Case tipo

            Case TipoSP._I

               Dim IdBitacora As Integer = GetCodigoMaximo() + 1

               sql.Bitacora_I(en.IdSucursal, IdBitacora, en.FechaBitacora, en.IdFuncion, en.IdUsuario,
                              en.NombrePC, en.Tipo, en.Descripcion)

               'Case TipoSP._U
               '   sql.CategoriasFiscales_U(en.IdCategoriaFiscal, en.NombreCategoriaFiscal, en.NombreCategoriaFiscalAbrev, en.LetraFiscal, _
               '                            en.LetraFiscalCompra, en.IvaDiscriminado, en.UtilizaImpuestos, _
               '                            en.CondicionIvaImpresoraFiscalEpson, en.CondicionIvaImpresoraFiscalHasar, en.Activo)

               'Case TipoSP._D
               '   sql.CategoriasFiscales_D(en.IdCategoriaFiscal)

         End Select

         If blnAbreConexion Then da.CommitTransaction()

      Catch
         If blnAbreConexion Then da.RollbakTransaction()
         Throw
      Finally
         If blnAbreConexion Then da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUno(o As Entidades.Bitacora, dr As DataRow)
      With o
         .IdSucursal = Integer.Parse(dr(Eniac.Entidades.Bitacora.Columnas.IdSucursal.ToString()).ToString())
         .IdBitacora = Integer.Parse(dr(Eniac.Entidades.Bitacora.Columnas.IdBitacora.ToString()).ToString())
         .FechaBitacora = DateTime.Parse(dr(Eniac.Entidades.Bitacora.Columnas.FechaBitacora.ToString()).ToString())
         .IdFuncion = dr(Eniac.Entidades.Bitacora.Columnas.IdFuncion.ToString()).ToString()
         .IdUsuario = dr(Eniac.Entidades.Bitacora.Columnas.IdUsuario.ToString()).ToString()
         .NombrePC = dr(Eniac.Entidades.Bitacora.Columnas.NombrePC.ToString()).ToString()
         .Tipo = dr(Eniac.Entidades.Bitacora.Columnas.Tipo.ToString()).ToString()
         .Descripcion = dr(Eniac.Entidades.Bitacora.Columnas.Descripcion.ToString()).ToString()
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub BorraPorFechaTipo(fechaBitacoraDesde As DateTime?, fechaBitacoraHasta As DateTime?, tipoBitacora As String)
      EjecutaConTransaccion(Sub() _BorraPorFechaTipo(fechaBitacoraDesde, fechaBitacoraHasta, tipoBitacora))
   End Sub
   Public Sub BorraErroresAntiguos()
      EjecutaConTransaccion(Sub() _BorraPorFechaTipo(fechaBitacoraDesde:=Nothing, fechaBitacoraHasta:=DateTime.Now.AddMonths(Publicos.LoginMesesPreservarBitacoraError * -1), tipoBitacora:=Entidades.Bitacora.TipoBitacora.SucedioError.ToString()))
   End Sub
   Public Sub _BorraPorFechaTipo(fechaBitacoraDesde As DateTime?, fechaBitacoraHasta As DateTime?, tipoBitacora As String)
      Dim sql = New SqlServer.Bitacora(da)
      sql.Bitacora_D_PorFechaTipo(fechaBitacoraDesde, fechaBitacoraHasta, tipoBitacora)
   End Sub

   Public Overloads Sub Insertar(tipo As Entidades.Bitacora.TipoBitacora, idFuncion As String, descripcion As String, fechaHora As DateTime)
      Dim eBitacora As Entidades.Bitacora = New Entidades.Bitacora()
      eBitacora.IdSucursal = Entidades.Usuario.Actual.Sucursal.IdSucursal
      eBitacora.FechaBitacora = fechaHora
      eBitacora.IdFuncion = idFuncion
      eBitacora.IdUsuario = Entidades.Usuario.Actual.Nombre
      eBitacora.NombrePC = My.Computer.Name
      eBitacora.Tipo = tipo.ToString()
      eBitacora.Descripcion = descripcion
      Insertar(eBitacora)
   End Sub

   Public Sub InsertarError(idFuncion As String, mensaje As String)
      Insertar(Entidades.Bitacora.TipoBitacora.SucedioError, idFuncion, mensaje, Now)
   End Sub

   Public Sub InsertarBorrado(idFuncion As String, clavePrimaria As String)
      Insertar(Entidades.Bitacora.TipoBitacora.Borrado, idFuncion, String.Format("{0} --- ", clavePrimaria), Now)
   End Sub

   Public Sub InsertarNuevoRegistro(idFuncion As String, clavePrimaria As String)
      Insertar(Entidades.Bitacora.TipoBitacora.NuevoRegistro, idFuncion, String.Format("{0} --- ", clavePrimaria), Now)
   End Sub

   Public Sub InsertarActualizacion(idFuncion As String, clavePrimaria As String, descripcion As String)
      Dim textoDividido As String() = {String.Format("{0} --- {1}", clavePrimaria, descripcion).Replace("'"c, "´")} '.DivideEnPartes(1000)
      Dim fechaBitacora As DateTime = Now

      For i As Integer = 0 To textoDividido.Length - 1
         Insertar(Entidades.Bitacora.TipoBitacora.Actualizacion, idFuncion, textoDividido(i), fechaBitacora)
      Next
   End Sub

   Public Sub InsertarActualizacion(idFuncion As String, clavePrimaria As String, drAnterior As DataRow, drNuevo As DataRow)
      Dim algunoCambio As Boolean = False
      Dim stb As StringBuilder = New StringBuilder()
      For Each dc As DataColumn In drAnterior.Table.Columns
         If Not drAnterior(dc.ColumnName).Equals(drNuevo(dc.ColumnName)) Then
            Dim strAnterior As String = "(NULL)"
            Dim strNuevo As String = "(NULL)"
            If Not IsDBNull(drAnterior(dc.ColumnName)) Then strAnterior = drAnterior(dc.ColumnName).ToString()
            If Not IsDBNull(drNuevo(dc.ColumnName)) Then strNuevo = drNuevo(dc.ColumnName).ToString()

            If strAnterior.Equals(Boolean.TrueString) Then strAnterior = "SI"
            If strAnterior.Equals(Boolean.FalseString) Then strAnterior = "NO"

            If strNuevo.Equals(Boolean.TrueString) Then strNuevo = "SI"
            If strNuevo.Equals(Boolean.FalseString) Then strNuevo = "NO"

            stb.AppendFormat("{0}: {1} -> {2} || ", dc.ColumnName, strAnterior, strNuevo)
            algunoCambio = True
         End If
      Next

      If algunoCambio Then
         Dim rBitacora As Bitacora = New Bitacora(da)
         rBitacora.InsertarActualizacion(idFuncion, clavePrimaria, stb.ToString())
      End If

   End Sub

   Public Function GetTodos() As List(Of Entidades.Bitacora)
      Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Bitacora())
   End Function

   Public Function GetTodos(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
                            idUsuario As String, idFuncion As String, descripcion As String,
                            nombrePC As String, tipoBitacora As Entidades.Bitacora.TipoBitacora) As List(Of Entidades.Bitacora)
      Return CargaLista(Me.GetAll(idSucursal, fechaDesde, fechaHasta, idUsuario, idFuncion, descripcion, nombrePC, tipoBitacora),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Bitacora())
   End Function


   Public Function GetUno(idSucursal As Integer, idBitacora As Integer) As Entidades.Bitacora
      Return CargaEntidad(Get1(idSucursal, idBitacora),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Bitacora(),
                          AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe Bitacora con Sucursal {0} e Id {1}", idSucursal, idBitacora))
   End Function

   Public Function Get1(idSucursal As Integer, idBitacora As Integer) As DataTable
      Dim sql As SqlServer.Bitacora = New SqlServer.Bitacora(Me.da)
      Return sql.Bitacora_G1(idSucursal, idBitacora)
   End Function

   Public Function GetPorRangoFechas(idSucursal As Integer,
                                     fechaDesde As Date,
                                     fechaHasta As Date,
                                     idBitacora As String) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.Bitacora = New SqlServer.Bitacora(Me.da)
         'Return sql.GetPorRangoFechas(idSucursal, fechaDesde, fechaHasta, idBitacora)
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return Convert.ToInt32(New SqlServer.Bitacora(da).GetCodigoMaximo("IdBitacora", "Bitacora",
                                                                        "IdSucursal = " + Eniac.Entidades.Usuario.Actual.Sucursal.IdSucursal.ToString()))
   End Function
#End Region

End Class
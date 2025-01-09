Option Explicit On
Option Strict On
Public Class ArchivosImportados
   Inherits Eniac.Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ArchivosImportados"
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
      Dim sql As SqlServer.ArchivosImportados = New SqlServer.ArchivosImportados(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ArchivosImportados(Me.da).ArchivosImportados_GA()
   End Function

#End Region

#Region "Metodos Privados"


   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim en As Entidades.ArchivoImportado = DirectCast(entidad, Entidades.ArchivoImportado)
      Dim blnAbreConexion As Boolean = da.Connection Is Nothing OrElse da.Connection.State <> ConnectionState.Open

      Try
         If blnAbreConexion Then da.OpenConection()
         If blnAbreConexion Then da.BeginTransaction()

         Dim sql As SqlServer.ArchivosImportados = New SqlServer.ArchivosImportados(Me.da)

         Select Case tipo

            Case TipoSP._I

               sql.ArchivosImportados_I(en.IdFuncion, en.IdSubFuncion, en.NombreArchivo, en.FechaLectura, en.IdUsuario, en.NombrePC, en.IdSucursal)

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

   Private Sub CargarUno(o As Entidades.ArchivoImportado, dr As DataRow)
      With o
         .IdFuncion = dr(Eniac.Entidades.ArchivoImportado.Columnas.IdFuncion.ToString()).ToString()
         .IdSubFuncion = dr(Eniac.Entidades.ArchivoImportado.Columnas.IdSubFuncion.ToString()).ToString()
         .NombreArchivo = dr(Eniac.Entidades.ArchivoImportado.Columnas.NombreArchivo.ToString()).ToString()
         .FechaLectura = DateTime.Parse(dr(Eniac.Entidades.ArchivoImportado.Columnas.FechaLectura.ToString()).ToString())
         .IdUsuario = dr(Eniac.Entidades.ArchivoImportado.Columnas.IdUsuario.ToString()).ToString()
         .NombrePC = dr(Eniac.Entidades.ArchivoImportado.Columnas.NombrePC.ToString()).ToString()
         .IdSucursal = Integer.Parse(dr(Eniac.Entidades.ArchivoImportado.Columnas.IdSucursal.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   'Public Overloads Sub Insertar(tipo As Entidades.ArchivosImportados.TipoArchivosImportados, idFuncion As String, descripcion As String, fechaHora As DateTime)
   '   Dim eArchivosImportados As Entidades.ArchivosImportados = New Entidades.ArchivosImportados()
   '   eArchivosImportados.IdSucursal = Entidades.Usuario.Actual.Sucursal.IdSucursal
   '   eArchivosImportados.FechaArchivosImportados = fechaHora
   '   eArchivosImportados.IdFuncion = idFuncion
   '   eArchivosImportados.IdUsuario = Entidades.Usuario.Actual.Nombre
   '   eArchivosImportados.NombrePC = My.Computer.Name
   '   eArchivosImportados.Tipo = tipo.ToString()
   '   eArchivosImportados.Descripcion = descripcion
   '   Insertar(eArchivosImportados)
   'End Sub

   'Public Sub InsertarError(idFuncion As String, mensaje As String)
   '   Insertar(Entidades.ArchivosImportados.TipoArchivosImportados.SucedioError, idFuncion, mensaje, Now)
   'End Sub

   'Public Sub InsertarBorrado(idFuncion As String, clavePrimaria As String)
   '   Insertar(Entidades.ArchivosImportados.TipoArchivosImportados.Borrado, idFuncion, String.Format("{0} --- ", clavePrimaria), Now)
   'End Sub

   'Public Sub InsertarNuevoRegistro(idFuncion As String, clavePrimaria As String)
   '   Insertar(Entidades.ArchivosImportados.TipoArchivosImportados.NuevoRegistro, idFuncion, String.Format("{0} --- ", clavePrimaria), Now)
   'End Sub

   'Public Sub InsertarActualizacion(idFuncion As String, clavePrimaria As String, descripcion As String)
   '   Dim textoDividido As String() = {String.Format("{0} --- {1}", clavePrimaria, descripcion).Replace("'"c, "´")} '.DivideEnPartes(1000)
   '   Dim fechaArchivosImportados As DateTime = Now

   '   For i As Integer = 0 To textoDividido.Length - 1
   '      Insertar(Entidades.ArchivosImportados.TipoArchivosImportados.Actualizacion, idFuncion, textoDividido(i), fechaArchivosImportados)
   '   Next
   'End Sub

   'Public Sub InsertarActualizacion(idFuncion As String, clavePrimaria As String, drAnterior As DataRow, drNuevo As DataRow)
   '   Dim algunoCambio As Boolean = False
   '   Dim stb As StringBuilder = New StringBuilder()
   '   For Each dc As DataColumn In drAnterior.Table.Columns
   '      If Not drAnterior(dc.ColumnName).Equals(drNuevo(dc.ColumnName)) Then
   '         Dim strAnterior As String = "(NULL)"
   '         Dim strNuevo As String = "(NULL)"
   '         If Not IsDBNull(drAnterior(dc.ColumnName)) Then strAnterior = drAnterior(dc.ColumnName).ToString()
   '         If Not IsDBNull(drNuevo(dc.ColumnName)) Then strNuevo = drNuevo(dc.ColumnName).ToString()

   '         If strAnterior.Equals(Boolean.TrueString) Then strAnterior = "SI"
   '         If strAnterior.Equals(Boolean.FalseString) Then strAnterior = "NO"

   '         If strNuevo.Equals(Boolean.TrueString) Then strNuevo = "SI"
   '         If strNuevo.Equals(Boolean.FalseString) Then strNuevo = "NO"

   '         stb.AppendFormat("{0}: {1} -> {2} || ", dc.ColumnName, strAnterior, strNuevo)
   '         algunoCambio = True
   '      End If
   '   Next

   '   If algunoCambio Then
   '      Dim rArchivosImportados As ArchivosImportados = New ArchivosImportados(da)
   '      rArchivosImportados.InsertarActualizacion(idFuncion, clavePrimaria, stb.ToString())
   '   End If

   'End Sub

   'Public Function GetTodos() As List(Of Entidades.ArchivoImportado)
   '   Return CargaLista(Me.GetAll(), Sub(o, dr) CargarUno(o, dr))
   'End Function

   'Public Function GetTodos(idSucursal As Integer, fechaDesde As Date, fechaHasta As Date,
   '                         idUsuario As String, idFuncion As String, descripcion As String,
   '                         nombrePC As String)
   '   Return CargaLista(Me.GetAll(idSucursal, fechaDesde, fechaHasta, idUsuario, idFuncion, descripcion, nombrePC, tipoArchivosImportados),
   '                     Sub(o, dr) CargarUno(o, dr))
   'End Function


   Public Function GetUno(idFuncion As String, idSubfuncion As String, NombreArchivo As String, idSucursal As Integer) As Entidades.ArchivoImportado
      Return CargaEntidad(Get1(idFuncion, idSubfuncion, NombreArchivo, idSucursal),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ArchivoImportado(),
                          AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No existe ArchivosImportados con Funcion  {0} e NombreArchivo {1}", idFuncion, NombreArchivo))
   End Function

   Public Function Get1(idFuncion As String, idSubfuncion As String, NombreArchivo As String, IdSucursal As Integer) As DataTable
      Dim sql As SqlServer.ArchivosImportados = New SqlServer.ArchivosImportados(Me.da)
      Return sql.ArchivosImportados_G1(idFuncion, idSubfuncion, NombreArchivo, IdSucursal)
   End Function


#End Region

End Class
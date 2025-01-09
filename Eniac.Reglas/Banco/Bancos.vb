Option Explicit On
Option Strict On
Public Class Bancos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Bancos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As DataTable
      Return New SqlServer.Bancos(da).Bancos_GA()
   End Function

   Public Function GetTodosE() As List(Of Entidades.Banco)
      Return CargaLista(GetTodos(), Sub(o, dr) CargarUno(dr, o), Function() New Entidades.Banco())
   End Function
   Public Function GetFiltradoPorNombre(ByVal nombreBanco As String) As DataTable
      Return New SqlServer.Bancos(da).Bancos_G_PorNombre(nombreBanco, False)
   End Function

   Public Function GetFiltradoPorCodigo(codigoBanco As String) As DataTable

      Dim dt As DataTable = GetFiltradoPorCodigo(codigoBanco, True) ' búsqueda por código exacto

      ' Solo va a ingresar al condicional si el código ingresado no fue exacto
      If dt.Rows.Count = 0 Then
         dt = GetFiltradoPorCodigo(codigoBanco, False)
      End If

      Return dt
   End Function
   Public Function GetFiltradoPorCodigo(codigoBanco As String, codigoExacto As Boolean) As DataTable
      Return New SqlServer.Bancos(da).Bancos_G_PorCodigo(If(IsNumeric(codigoBanco), Integer.Parse(codigoBanco), 0), codigoExacto)
   End Function
   Public Function GetUno(idBanco As Integer) As Entidades.Banco
      If idBanco = 0 Then idBanco = -1
      Return CargaEntidad(New SqlServer.Bancos(da).Bancos_G1(idBanco),
                          Sub(o, dr) CargarUno(dr, o), Function() New Entidades.Banco(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No existe el Banco con Código {0}", idBanco))
   End Function

   Public Function Get1(ByVal IdBanco As Integer) As DataTable
      Return New SqlServer.Bancos(Me.da).Bancos_G1(IdBanco)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim banco As Entidades.Banco = DirectCast(entidad, Entidades.Banco)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sqlBancos As SqlServer.Bancos = New SqlServer.Bancos(da)

         Select Case tipo
            Case TipoSP._I
               sqlBancos.Bancos_I(banco.IdBanco, banco.NombreBanco, banco.DebitoDirecto, banco.Empresa, banco.Convenio, banco.Servicio)
            Case TipoSP._U
               sqlBancos.Bancos_U(banco.IdBanco, banco.NombreBanco, banco.DebitoDirecto, banco.Empresa, banco.Convenio, banco.Servicio)
            Case TipoSP._D
               sqlBancos.Bancos_D(banco.IdBanco)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.Banco)
      With o
         .IdBanco = Integer.Parse(dr("IdBanco").ToString())
         .NombreBanco = dr("NombreBanco").ToString()
         .DebitoDirecto = Boolean.Parse(dr("DebitoDirecto").ToString())
         If .DebitoDirecto Then
            .Empresa = If(IsNumeric(dr("Empresa")), Integer.Parse(dr("Empresa").ToString()), 0)
            .Convenio = If(IsNumeric(dr("Convenio")), Integer.Parse(dr("Convenio").ToString()), 0)
            .Servicio = dr("Servicio").ToString()
         End If
      End With
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
      Return New SqlServer.Bancos(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Bancos(Me.da).Bancos_GA()
   End Function

#End Region

End Class
Public Class ClientesAntecedentes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ClientesAntecedentes"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._I)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(entidad, TipoSP._U)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try

   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ClientesAntecedentes = New SqlServer.ClientesAntecedentes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ClientesAntecedentes(Me.da).ClientesAntecedentes_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.ClienteAntecedente = DirectCast(entidad, Entidades.ClienteAntecedente)

      Dim sql As SqlServer.ClientesAntecedentes = New SqlServer.ClientesAntecedentes(Me.da)
      en.FechaActualizacion = DateTime.Now
      If Me.GetUno(en.Antecedente.IdAntecedente, en.Cliente.IdCLiente) Is Nothing Then
         tipo = TipoSP._I
      Else
         tipo = TipoSP._U
      End If
      Select Case tipo
         Case TipoSP._I
            sql.ClientesAntecedentes_I(en.Antecedente.IdAntecedente, en.Cliente.IdCliente, en.Valor, en.FechaActualizacion)
         Case TipoSP._U
            sql.ClientesAntecedentes_U(en.Antecedente.IdAntecedente, en.Cliente.IdCliente, en.Valor, en.FechaActualizacion)
         Case TipoSP._D
            sql.ClientesAntecedentes_D(en.Antecedente.IdAntecedente, en.Cliente.IdCliente)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ClienteAntecedente, ByVal dr As DataRow)
      With o
         .Antecedente = New Reglas.Antecedentes(Me.da).GetUno(Int32.Parse(dr(Entidades.ClienteAntecedente.Columnas.IdAntecedente.ToString()).ToString()))
         .Cliente = New Reglas.Clientes(Me.da).GetUno(Int64.Parse(dr(Entidades.ClienteAntecedente.Columnas.IdCliente.ToString()).ToString()))
         If Not String.IsNullOrEmpty(dr(Entidades.ClienteAntecedente.Columnas.Valor.ToString()).ToString()) Then
            .Valor = dr(Entidades.ClienteAntecedente.Columnas.Valor.ToString()).ToString()
         End If
         .FechaActualizacion = DateTime.Parse(dr(Entidades.ClienteAntecedente.Columnas.FechaActualizacion.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ClienteAntecedente)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ClienteAntecedente
      Dim oLis As List(Of Entidades.ClienteAntecedente) = New List(Of Entidades.ClienteAntecedente)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ClienteAntecedente()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUno(ByVal idAntecedente As Integer, _
                          ByVal IdCLiente As Long) As Entidades.ClienteAntecedente
      Dim sql As SqlServer.ClientesAntecedentes = New SqlServer.ClientesAntecedentes(Me.da)

      Dim dt As DataTable = sql.ClientesAntecedentes_G1(idAntecedente, IdCLiente)

      Dim o As Entidades.ClienteAntecedente = New Entidades.ClienteAntecedente()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Return Nothing
      End If
      Return o
   End Function

   Public Function GetPorTipoAntecedenteYCliente(ByVal idTipoAntecedente As Integer, ByVal IdCLiente As Long) As DataTable
      Dim sql As SqlServer.ClientesAntecedentes = New SqlServer.ClientesAntecedentes(Me.da)
      Return sql.GetPorTipoAntecedenteYCliente(idTipoAntecedente, IdCLiente)
   End Function

   Public Function GetAntecedentesDeCliente(ByVal IdCLiente As Long) As DataTable
      Dim sql As SqlServer.ClientesAntecedentes = New SqlServer.ClientesAntecedentes(Me.da)
      Return sql.GetAntecedentesDeCliente(IdCLiente)
   End Function

#End Region

End Class

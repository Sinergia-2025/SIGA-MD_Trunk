Option Strict On
Option Explicit On
Public Class ClientesAdjuntos
   Inherits Eniac.Reglas.Base
   Implements IReglaAdjuntos

   Private Property NombreBaseAdjuntos As String

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ClientesAdjuntos"
      da = accesoDatos
      NombreBaseAdjuntos = Reglas.Publicos.NombreBaseAdjuntos(da)
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Inserta(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Try

         da.OpenConection()
         da.BeginTransaction()

         Borra(entidad)

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ClientesAdjuntos = New SqlServer.ClientesAdjuntos(Me.da, NombreBaseAdjuntos)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString(), incluirAdjunto:=False) 'Buscar siempre se ejecuta desde las grillas ABM, por lo que es sin el Byte()
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ClientesAdjuntos(Me.da, NombreBaseAdjuntos).ClientesAdjuntos_GA(incluirAdjunto:=False)   'Generalmente se ejecuta desde las grillas ABM, por lo que es sin el Byte()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.ClienteAdjunto = DirectCast(entidad, Entidades.ClienteAdjunto)

      Dim sqlC As SqlServer.ClientesAdjuntos = New SqlServer.ClientesAdjuntos(da, NombreBaseAdjuntos)
      Select Case tipo
         Case TipoSP._I
            sqlC.ClientesAdjuntos_I(en.IdCliente, en.IdClienteAdjunto, en.IdTipoAdjunto, en.NombreAdjunto, en.Adjunto, en.Observaciones, en.NivelAutorizacion)
         Case TipoSP._U
            sqlC.ClientesAdjuntos_U(en.IdCliente, en.IdClienteAdjunto, en.IdTipoAdjunto, en.NombreAdjunto, en.Observaciones, en.NivelAutorizacion)
         Case TipoSP._D
            sqlC.ClientesAdjuntos_D(en.IdCliente, en.IdClienteAdjunto)
      End Select
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.ClienteAdjunto, ByVal dr As DataRow)
      With o
         .IdCliente = Long.Parse(dr(Entidades.ClienteAdjunto.Columnas.IdCliente.ToString()).ToString())
         .IdClienteAdjunto = Long.Parse(dr(Entidades.ClienteAdjunto.Columnas.IdClienteAdjunto.ToString()).ToString())
         .IdTipoAdjunto = Integer.Parse(dr(Entidades.ClienteAdjunto.Columnas.IdTipoAdjunto.ToString()).ToString())
         .NombreTipoAdjunto = dr(Entidades.TipoAdjunto.Columnas.NombreTipoAdjunto.ToString()).ToString()
         .NombreAdjunto = dr(Entidades.ClienteAdjunto.Columnas.NombreAdjunto.ToString()).ToString()
         .Observaciones = dr(Entidades.ClienteAdjunto.Columnas.Observaciones.ToString()).ToString()
         If Not IsDBNull(dr(Entidades.ClienteAdjunto.Columnas.Adjunto.ToString())) Then
            .Adjunto = CType(dr(Entidades.ClienteAdjunto.Columnas.Adjunto.ToString()), Byte())
         End If
         .NivelAutorizacion = Short.Parse(dr(Entidades.Cliente.Columnas.NivelAutorizacion.ToString()).ToString())
      End With
   End Sub
#End Region

#Region "Metodos publicos"
   Public Overloads Sub Inserta(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overloads Sub Actualiza(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overloads Sub Borra(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub ActualizaDesdeCliente(cliente As Entidades.Cliente)
      If cliente.Adjuntos IsNot Nothing Then
         For Each adjunto As Entidades.ClienteAdjunto In cliente.Adjuntos
            If adjunto.IdClienteAdjunto > 0 Then
               Actualiza(adjunto)
            Else
               adjunto.IdCliente = cliente.IdCliente
               adjunto.IdClienteAdjunto = GetCodigoMaximo(cliente.IdCliente) + 1
               Dim fi As IO.FileInfo = New IO.FileInfo(adjunto.NombreAdjuntoCompleto)
               If Not String.IsNullOrWhiteSpace(adjunto.NombreAdjuntoCompleto) AndAlso fi.Exists Then
                  adjunto.Adjunto = IO.File.ReadAllBytes(adjunto.NombreAdjuntoCompleto)
               End If
               adjunto.NombreAdjunto = fi.Name
               Inserta(adjunto)
            End If
         Next
         For Each adjunto As Entidades.ClienteAdjunto In cliente.Adjuntos.Borrados
            If adjunto.IdClienteAdjunto > 0 Then
               Borra(adjunto)
            End If
         Next
      End If
   End Sub

   Public Function GetUno(idCliente As Long?, idClienteAdjunto As Long?, incluirAdjunto As Boolean) As Entidades.ClienteAdjunto
      Dim dt As DataTable = New SqlServer.ClientesAdjuntos(Me.da, NombreBaseAdjuntos).ClientesAdjuntos_G1(idCliente, idClienteAdjunto, incluirAdjunto, Nothing)
      Dim o As Entidades.ClienteAdjunto = New Entidades.ClienteAdjunto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   Public Function GetTodos(idCliente As Long, incluirAdjunto As Boolean) As List(Of Entidades.ClienteAdjunto)
      Dim dt As DataTable = New SqlServer.ClientesAdjuntos(Me.da, NombreBaseAdjuntos).ClientesAdjuntos_GA(idCliente, incluirAdjunto, actual.NivelAutorizacion)
      Dim o As Entidades.ClienteAdjunto
      Dim oLis As List(Of Entidades.ClienteAdjunto) = New List(Of Entidades.ClienteAdjunto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ClienteAdjunto()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Overloads Function GetCodigoMaximo(idCliente As Long) As Integer
      Return New SqlServer.ClientesAdjuntos(da, NombreBaseAdjuntos).GetCodigoMaximo(idCliente)
   End Function


#End Region

   Public Function GetOClonar(entidadOriginal As Entidades.IAdjunto) As Entidades.IAdjunto Implements IReglaAdjuntos.GetOClonar
      Dim va As Entidades.ClienteAdjunto = DirectCast(entidadOriginal, Entidades.ClienteAdjunto)
      Dim copia As Entidades.ClienteAdjunto
      If va.IdClienteAdjunto > 0 Then
         copia = DirectCast(GetUno(entidadOriginal, True), Entidades.ClienteAdjunto)
      Else
         copia = va.Clonar(va)
      End If
      Return copia
   End Function

   Public Function GetUno(entidadOriginal As Entidades.IAdjunto, incluirAdjunto As Boolean) As Entidades.IAdjunto Implements IReglaAdjuntos.GetUno
      Dim va As Entidades.ClienteAdjunto = DirectCast(entidadOriginal, Entidades.ClienteAdjunto)
      Return GetUno(va.IdCliente, va.IdClienteAdjunto, incluirAdjunto)
   End Function

End Class
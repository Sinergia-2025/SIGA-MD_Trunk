Public Class Destinos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Eniac.Datos.DataAccess())
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "Destinos"
      da = accesoDatos
   End Sub

#End Region

   Public Function GetParaMovil() As DataTable
      If Not New Reglas.Generales().ExisteTabla("Destinos") Then
         Return Nothing
      End If

      Return New SqlServer.Destinos(da).GetParaMovil()
   End Function

   Public Function GetTodas() As List(Of Entidades.Destino)
      If Not New Reglas.Generales().ExisteTabla("Destinos") Then
         Return Nothing
      End If

      Return CargaLista(New SqlServer.Destinos(da).Destinos_GA(),
                        Sub(o, dr)
                           o.IdDestino = dr.Field(Of Short)(Entidades.Destino.Columnas.IdDestino.ToString())
                           o.NombreDestino = dr.Field(Of String)(Entidades.Destino.Columnas.NombreDestino.ToString())
                           o.EsLibre = dr.Field(Of Boolean)(Entidades.Destino.Columnas.EsLibre.ToString())
                        End Sub,
                        Function() New Entidades.Destino())
   End Function
   Public Function GetUno(ByVal idDestino As Integer) As Eniac.Entidades.Destino
      Dim dt As DataTable = New SqlServer.Destinos(Me.da).Destinos_G1(idDestino)
      Dim o As Eniac.Entidades.Destino = New Eniac.Entidades.Destino()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function
   Private Sub CargarUno(ByVal o As Entidades.Destino, ByVal dr As DataRow)
      With o
         .IdDestino = Short.Parse(dr(Entidades.Destino.Columnas.IdDestino.ToString()).ToString())
         .NombreDestino = dr(Entidades.Destino.Columnas.NombreDestino.ToString()).ToString()
         .EsLibre = Boolean.Parse(dr(Entidades.Destino.Columnas.EsLibre.ToString()).ToString())
      End With
   End Sub

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


   Public Function GetCodigoMaximo(ByVal Campo As String) As Integer

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT MAX(" & Campo & ") AS Maximo")
         .Append(" FROM Destinos")
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("Maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("Maximo").ToString())
         End If
      End If

      Return val

   End Function
   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(False)
   End Function

   Public Overloads Function GetAll(activas As Boolean) As System.Data.DataTable
      Return New SqlServer.Destinos(Me.da).Destinos_GA()
   End Function

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.Destino = DirectCast(entidad, Entidades.Destino)

      Dim sql As SqlServer.Destinos = New SqlServer.Destinos(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.Destinos_I(en)
         Case TipoSP._U
            sql.Destinos_U(en)
         Case TipoSP._D
            sql.Destinos_D(en.IdDestino)
      End Select

   End Sub


End Class
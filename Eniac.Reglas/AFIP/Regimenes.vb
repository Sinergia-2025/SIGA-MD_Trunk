Public Class Regimenes
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Regimenes"
      da = New Eniac.Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Eniac.Datos.DataAccess)
      Me.NombreEntidad = "Regimenes"
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
      Dim sql As SqlServer.Regimenes = New SqlServer.Regimenes(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overloads Function GetAll(idTipoImpuesto As String) As System.Data.DataTable
      Return New SqlServer.Regimenes(Me.da).Regimenes_GA(idTipoImpuesto)
   End Function

   <Obsolete("Utilizar el método con GetAll(idTipoImpuesto as String)", True)> _
   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(String.Empty)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Dim en As Entidades.Regimen = DirectCast(entidad, Entidades.Regimen)

      Dim sql As SqlServer.Regimenes = New SqlServer.Regimenes(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.Regimenes_I(en.IdRegimen, en.ConceptoRegimen, en.ARetenerInscripto, en.ARetenerNoInscripto, _
                            en.MontoAExceder, en.ImporteMinimoInscripto, en.ImporteMinimoNoInscripto, en.TipoImpuesto.IdTipoImpuesto, _
                            en.RetienePorEscala, en.MinimoNoImponible, en.OrigenBaseImponible, en.CodigoAfip)
         Case TipoSP._U
            sql.Regimenes_U(en.IdRegimen, en.ConceptoRegimen, en.ARetenerInscripto, en.ARetenerNoInscripto, _
                            en.MontoAExceder, en.ImporteMinimoInscripto, en.ImporteMinimoNoInscripto, en.TipoImpuesto.IdTipoImpuesto, _
                            en.RetienePorEscala, en.MinimoNoImponible, en.OrigenBaseImponible, en.CodigoAfip)
         Case TipoSP._D
            sql.Regimenes_D(en.IdRegimen)
      End Select

   End Sub

   Private Sub CargarUno(ByVal o As Entidades.Regimen, ByVal dr As DataRow)
      With o
         .IdRegimen = Int32.Parse(dr(Entidades.Regimen.Columnas.IdRegimen.ToString()).ToString())
         .ConceptoRegimen = dr(Entidades.Regimen.Columnas.ConceptoRegimen.ToString()).ToString()
         .ARetenerInscripto = Decimal.Parse(dr(Entidades.Regimen.Columnas.ARetenerInscripto.ToString()).ToString())
         .ARetenerNoInscripto = Decimal.Parse(dr(Entidades.Regimen.Columnas.ARetenerNoInscripto.ToString()).ToString())
         .MontoAExceder = Decimal.Parse(dr(Entidades.Regimen.Columnas.MontoAExceder.ToString()).ToString())
         .ImporteMinimoInscripto = Decimal.Parse(dr(Entidades.Regimen.Columnas.ImporteMinimoInscripto.ToString()).ToString())
         .ImporteMinimoNoInscripto = Decimal.Parse(dr(Entidades.Regimen.Columnas.ImporteMinimoNoInscripto.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.Regimen.Columnas.IdTipoImpuesto.ToString()).ToString()) Then
            .TipoImpuesto = New Reglas.TiposImpuestos(Me.da)._GetUno(DirectCast([Enum].Parse(GetType(Eniac.Entidades.TipoImpuesto.Tipos), dr(Entidades.Regimen.Columnas.IdTipoImpuesto.ToString()).ToString()), Entidades.TipoImpuesto.Tipos))
         End If
         .RetienePorEscala = Boolean.Parse(dr(Entidades.Regimen.Columnas.RetienePorEscala.ToString()).ToString())
         If Not IsDBNull(dr(Entidades.Regimen.Columnas.MinimoNoImponible.ToString())) Then
            .MinimoNoImponible = Decimal.Parse(dr(Entidades.Regimen.Columnas.MinimoNoImponible.ToString()).ToString())
         End If

         .OrigenBaseImponible = DirectCast([Enum].Parse(GetType(Entidades.Regimen.OrigenBaseImponibleEnum),
                                                        dr(Eniac.Entidades.Regimen.Columnas.OrigenBaseImponible.ToString()).ToString()), 
                                           Entidades.Regimen.OrigenBaseImponibleEnum)



         .CodigoAfip = Int32.Parse(dr(Entidades.Regimen.Columnas.CodigoAfip.ToString()).ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodos(idTipoImpuesto As String) As List(Of Entidades.Regimen)
      Try
         Me.da.OpenConection()

         Dim dt As DataTable = Me.GetAll(idTipoImpuesto)
         Dim o As Entidades.Regimen
         Dim oLis As List(Of Entidades.Regimen) = New List(Of Entidades.Regimen)
         For Each dr As DataRow In dt.Rows
            o = New Entidades.Regimen()
            Me.CargarUno(o, dr)
            oLis.Add(o)
         Next

         Return oLis

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetUno(ByVal idRegimen As Integer) As Entidades.Regimen
      Try
         Me.da.OpenConection()

         Return Me._GetUno(idRegimen)

      Catch ex As Exception
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Friend Function _GetUno(ByVal idRegimen As Integer) As Entidades.Regimen

      Dim sql As SqlServer.Regimenes = New SqlServer.Regimenes(Me.da)

      Dim dt As DataTable = sql.Regimenes_G1(idRegimen)

      Dim o As Entidades.Regimen = New Entidades.Regimen()
      If dt.Rows.Count > 0 Then
         Me.CargarUno(o, dt.Rows(0))
      Else
         Throw New Exception("No existe el Régimen.")
      End If

      Return o

   End Function

#End Region

End Class

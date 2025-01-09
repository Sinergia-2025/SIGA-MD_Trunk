Option Infer On
Public Class SueldosPersonalCodigos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosPersonalCodigos"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "SueldosPersonalCodigos"
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

      Dim stbQuery As StringBuilder = New StringBuilder("")
      With stbQuery
         .Append("SELECT")
         .Append(" idTipoConcepto ")
         .Append(", NombreConcepto ")
         .Append(" FROM  ")
         .Append("SueldosConceptos ")
         .Append("  WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")
      End With
      Return Me.da.GetDataTable(stbQuery.ToString())


   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosPersonalCodigos(Me.da).SueldosPersonalCodigos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim oConcepto As Entidades.SueldosPersonaConcepto = DirectCast(entidad, Entidades.SueldosPersonaConcepto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosPersonalCodigos_I(oConcepto.idLegajo, oConcepto.idTipoConcepto, oConcepto.idConcepto, _
                                      oConcepto.Valor, _
                                      oConcepto.Periodos, _
                                      oConcepto.Aguinaldo, oConcepto.TipoRecibo.IdTipoRecibo)

            Case TipoSP._U
               sql.SueldosPersonalCodigos_U(oConcepto.idLegajo, oConcepto.idTipoConcepto, oConcepto.idConcepto, _
                                      oConcepto.Valor, _
                                      oConcepto.Periodos, _
                                      oConcepto.Aguinaldo)
            Case TipoSP._D
               sql.SueldosPersonalCodigos_D(oConcepto.idLegajo, oConcepto.idTipoConcepto, oConcepto.idConcepto)
         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosPersonaConcepto)
      With o
         .idTipoConcepto = dr.Field(Of Integer)("idTipoConcepto")
         .idConcepto = dr.Field(Of Integer)("idConcepto")
         .Periodos = Integer.Parse(dr("Periodos").ToString())
         .Valor = Decimal.Parse(dr("Valor").ToString())

         If Not String.IsNullOrEmpty(dr("Aguinaldo").ToString()) Then
            .Aguinaldo = dr("Aguinaldo").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub ActualizarConceptosPersonal(ByVal idLegajo As Integer, _
                                               ByVal ListaDatos As List(Of Entidades.SueldosPersonaConcepto), _
                                               ByVal idTipoRecibo As Integer)

      'agre transaccion

      Dim oConcepto As Entidades.SueldosPersonaConcepto

      Me.da.OpenConection()

      Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)

      Try
         Me.da.BeginTransaction()

         sql.SueldosPersonalCodigos_DPorTipoRecibo(idLegajo, idTipoRecibo)

         For Each oConcepto In ListaDatos



            sql.SueldosPersonalCodigos_I(oConcepto.idLegajo, oConcepto.idTipoConcepto, oConcepto.idConcepto, _
                                           oConcepto.Valor, _
                                           oConcepto.Periodos, _
                                           oConcepto.Aguinaldo, _
                                           oConcepto.TipoRecibo.IdTipoRecibo)


         Next
         da.CommitTransaction()

      Catch ex As Exception

         da.RollbakTransaction()

         Throw ex

      End Try


      'borra los onceptos del peronal

      'agrega

      'cierra transa


   End Sub

   Public Sub ActualizarConceptosDelPersonal(ByVal ListaDatos As List(Of Entidades.SueldosPersonaConcepto))

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)

         Me.da.BeginTransaction()

         Dim legajos = From l In ListaDatos _
                       Select l.idLegajo Distinct

         Dim nroLega As Integer = 0

         For Each lega As Integer In legajos
            nroLega = lega
            Dim conceptos = From c In ListaDatos _
                            Where c.idLegajo = nroLega _
                            Select c

            sql.SueldosPersonalCodigos_DPorTipoRecibo(lega, 0)

            For Each conc As Entidades.SueldosPersonaConcepto In conceptos
               If sql.SueldosPersonalCodigos_G1(conc.idLegajo, conc.idTipoConcepto, conc.idConcepto, conc.TipoRecibo.IdTipoRecibo).Rows.Count = 0 Then
                  sql.SueldosPersonalCodigos_I(conc.idLegajo, _
                                               conc.idTipoConcepto, _
                                               conc.idConcepto, _
                                               conc.Valor, _
                                               conc.Periodos, _
                                               conc.Aguinaldo, _
                                               conc.TipoRecibo.IdTipoRecibo)
               End If
            Next
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub InsertarConceptoModificado(ByVal ListaDatos As List(Of Entidades.SueldosPersonaConcepto))

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)

         Me.da.BeginTransaction()

         Dim legajos = From l In ListaDatos _
                       Select l.idLegajo Distinct

         Dim nroLega As Integer = 0

         For Each lega As Integer In legajos
            nroLega = lega
            Dim conceptos = From c In ListaDatos _
                            Where c.idLegajo = nroLega _
                            Select c

            'sql.SueldosPersonalCodigos_DPorTipoRecibo(lega, 0)

            For Each conc As Entidades.SueldosPersonaConcepto In conceptos
               If sql.SueldosPersonalCodigos_G1(conc.idLegajo, conc.idTipoConcepto, conc.idConcepto, conc.TipoRecibo.IdTipoRecibo).Rows.Count = 0 Then
                  sql.SueldosPersonalCodigos_I(conc.idLegajo, _
                                               conc.idTipoConcepto, _
                                               conc.idConcepto, _
                                               conc.Valor, _
                                               conc.Periodos, _
                                               conc.Aguinaldo, _
                                               conc.TipoRecibo.IdTipoRecibo)
               End If
            Next
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Sub EliminarConceptosDelPersonal(ByVal ListaDatos As List(Of Entidades.SueldosPersonaConcepto))

      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)

         Me.da.BeginTransaction()

         For Each conc As Entidades.SueldosPersonaConcepto In ListaDatos
            sql.SueldosPersonalCodigos_D(conc.idLegajo, _
                                               conc.idTipoConcepto, _
                                               conc.idConcepto)
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex
      Finally
         Me.da.CloseConection()
      End Try


   End Sub

   Public Function GetTodas() As List(Of Entidades.SueldosPersonaConcepto)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosPersonaConcepto
      Dim oLis As List(Of Entidades.SueldosPersonaConcepto) = New List(Of Entidades.SueldosPersonaConcepto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosPersonaConcepto()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idTipoConcepto,")
         .Append("       NombreTipoConcepto")
         .Append("  FROM SueldosConceptos")
         If Integer.Parse(codigo) > 0 Then
            .Append(" WHERE idTipoConcepto = " & codigo.ToString())
         End If
         .Append("	ORDER BY NombreTipoConcepto")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Append("SELECT idTipoConcepto,")
         .Append("       NombreTipoConcepto")
         .Append("  FROM SueldosConceptos")
         .Append("	WHERE NombreTipoConcepto LIKE '%")
         .Append(nombre)
         .Append("%' ")
         .Append("	ORDER BY NombreTipoConcepto")
      End With

      Return Me.DataServer.GetDataTable(stb.ToString())

   End Function



   'daniel piguin  152023312  - Country Aldea Tenis

   Public Function GetCodigoMaximo() As Long

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT ")
         .Append(" max(idConcepto) as maximo ")
         .Append(" from SueldosConceptos ")
      End With

      Dim dt As DataTable = Me.DataServer().GetDataTable(stb.ToString())
      Dim val As Long = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Long.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function


   Public Function GetUno(ByVal idTipoConcepto As Integer, ByVal idConcepto As Integer, ByVal EsAguinaldo As Boolean) As Entidades.SueldosConcepto
      Dim qry As SqlServer.SueldosConceptos = New SqlServer.SueldosConceptos(Me.da)

      Dim dt As DataTable = qry.SueldosConceptos_G1(idConcepto, EsAguinaldo, False, "")
      Dim o As Entidades.SueldosConcepto = New Entidades.SueldosConcepto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idTipoConcepto = dr.Field(Of Integer)("idTipoConcepto")
            .idConcepto = dr.Field(Of Integer)("idConcepto")
            .NombreConcepto = dr("NombreConcepto").ToString()
            .Tipo = dr("Tipo").ToString()
            .Aguinaldo = dr("Aguinaldo").ToString()
            '  .Calculo1 = dr("Calculo1").ToString()
            .Formula = dr("Formula").ToString()
            .idQuepide = dr.Field(Of Integer)("idQuepide")
            .LiquidacionAnual = dr.Field(Of Boolean)("LiquidacionAnual")
            .LiquidacionMeses = dr("LiquidacionMeses").ToString()
            .Valor = dr.Field(Of Decimal)("Valor")
         End With
      End If
      Return o
   End Function

#End Region

End Class
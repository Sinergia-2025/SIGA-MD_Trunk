Option Strict Off
#Region "Imports"

Imports Eniac.Entidades
Imports System.Text

#End Region

Public Class SueldosConceptos

   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosConceptos"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "SueldosConceptos"
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

      entidad.Columna = "C." & entidad.Columna

      Select Case entidad.Columna
         Case "C.NombreTipoConcepto"
            entidad.Columna = entidad.Columna.Replace("C.", "TC.")

         Case "C.NombreQuePide"
            entidad.Columna = entidad.Columna.Replace("C.", "Q.")
      End Select

      Me.SelectTexto(stbQuery)

      With stbQuery
         .AppendLine("  WHERE " & entidad.Columna & " LIKE '%" & entidad.Valor.ToString() & "%'")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosConceptos(Me.da).SueldosConceptos_GA()
   End Function

   Private Sub SelectTexto(ByVal stb As StringBuilder)

      With stb
         .Length = 0
         .AppendLine("SELECT C.CodigoConcepto")
         .AppendLine("      ,C.NombreConcepto ")
         .AppendLine("      ,C.idTipoConcepto")
         .AppendLine("      ,TC.NombreTipoConcepto ")
         .AppendLine("      ,C.IdQuepide")
         .AppendLine("      ,Q.NombreQuePide ")
         .AppendLine("      ,C.Valor ")
         .AppendLine("      ,C.Tipo ")
         .AppendLine("      ,C.Aguinaldo ")
         .AppendLine("      ,C.LiquidacionAnual ")
         .AppendLine("      ,C.LiquidacionMeses ")
         .AppendLine("      ,C.Formula ")
         'GAR: 13/09/2016 - 'Dejar aca hasta cambiar la ayuda a la que se usa por base, necesita los lugares exactos.
         .AppendLine("      ,C.IdConcepto ")
         .AppendLine("      ,C.MostrarEnRecibo")
         .AppendLine("      ,C.EsContempladoAguinaldo")
         .AppendLine("  FROM SueldosConceptos C ")
         .AppendLine("  LEFT JOIN SueldosTiposConceptos TC ON TC.IdTipoCOncepto = C.IdTipoConcepto ")
         .AppendLine("  LEFT JOIN SueldosQuePideConcepto Q ON Q.idQuePide = C.idQuepide ")
      End With

   End Sub

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim oConcepto As Entidades.SueldosConcepto = DirectCast(entidad, Entidades.SueldosConcepto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosConceptos = New SqlServer.SueldosConceptos(Me.da)
         Dim sql1 As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosConceptos_I(oConcepto.idConcepto, _
                                      oConcepto.NombreConcepto, _
                                      oConcepto.idTipoConcepto, _
                                      oConcepto.Valor, _
                                      oConcepto.Tipo, _
                                      oConcepto.idQuepide, _
                                      oConcepto.Formula, _
                                      oConcepto.EsContempladoAguinaldo, _
                                      oConcepto.Aguinaldo, _
                                      oConcepto.LiquidacionAnual, _
                                      oConcepto.LiquidacionMeses,
                                      oConcepto.CodigoConcepto,
                                      oConcepto.MostrarEnRecibo)

               If oConcepto.Formula.Contains("CODVALOR") And Not oConcepto.Formula.Contains("LIQVALOR") Then
                  sql1.SueldosPersonalCodigos_UValor(oConcepto.idConcepto, oConcepto.idTipoConcepto, oConcepto.Valor)
               End If

            Case TipoSP._U
               sql.SueldosConceptos_U(oConcepto.idConcepto, _
                                      oConcepto.NombreConcepto, _
                                      oConcepto.idTipoConcepto, _
                                      oConcepto.Valor, _
                                      oConcepto.Tipo, _
                                      oConcepto.idQuepide, _
                                      oConcepto.Formula, _
                                      oConcepto.EsContempladoAguinaldo, _
                                      oConcepto.Aguinaldo, _
                                      oConcepto.LiquidacionAnual, _
                                      oConcepto.LiquidacionMeses,
                                      oConcepto.CodigoConcepto,
                                      oConcepto.MostrarEnRecibo)

               If oConcepto.Formula.Contains("CODVALOR") And Not oConcepto.Formula.Contains("LIQVALOR") Then
                  sql1.SueldosPersonalCodigos_UValor(oConcepto.idConcepto, oConcepto.idTipoConcepto, oConcepto.Valor)
               End If

            Case TipoSP._D
               sql.SueldosConceptos_D(oConcepto.idConcepto)

         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal dr As DataRow, ByVal o As Entidades.SueldosConcepto)
      With o
         .idTipoConcepto = dr("idTipoConcepto").ToString()
         .idConcepto = dr("idConcepto").ToString()

         If Not String.IsNullOrEmpty(dr("NombreConcepto").ToString()) Then
            .NombreConcepto = dr("NombreConcepto").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetTodas() As List(Of Entidades.SueldosConcepto)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.SueldosConcepto
      Dim oLis As List(Of Entidades.SueldosConcepto) = New List(Of Entidades.SueldosConcepto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosConcepto()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(ByVal codigo As String, ByVal EsAguinaldo As Boolean) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      Dim oConceptos As New SqlServer.SueldosConceptos(Me.da)

      Dim Datos As DataTable
      Datos = oConceptos.SueldosConceptos_G1(codigo, EsAguinaldo, False, "")

      'With stb
      '    .Append("SELECT idTipoConcepto,")
      '    .Append("       NombreTipoConcepto")
      '    .Append("  FROM SueldosConceptos")
      '    If codigo > 0 Then
      '        .Append(" WHERE idTipoConcepto = " & codigo.ToString())
      '    End If
      '    .Append("	ORDER BY NombreTipoConcepto")
      'End With

      Return Datos ' Me.DataServer.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(ByVal nombre As String, ByVal EsAguinaldo As Boolean) As DataTable

      Dim sql As New SqlServer.SueldosConceptos(Me.da)
      Return sql.SueldosConceptos_G1(0, EsAguinaldo, True, nombre)

   End Function

   Public Function GetConceptosPersona(ByVal idLegajo As Long, ByVal idTipoRecibo As Integer) As DataTable
      Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)
      Return sql.GetConceptosPersona(idLegajo, idTipoRecibo)
   End Function

   Public Function GetConceptosPersonas(ByVal idLegajos As List(Of Integer)) As DataTable
      Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)
      Return sql.GetConceptosPersonas(idLegajos)
   End Function

   Public Function GetMejorSueldo(IdLegajo As Integer, ByVal anoperiodo As Integer, ByVal mesperiodo As Integer) As Decimal
      Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(Me.da)
      Dim Resultado As DataTable
      Dim periodoinicial As Integer
      Dim periodofinal As Integer

      periodoinicial = Integer.Parse(anoperiodo.ToString() + (mesperiodo - 5).ToString("00"))
      periodofinal = Integer.Parse(anoperiodo.ToString() + (mesperiodo).ToString("00"))

      Resultado = sql.GetMejorSueldo(IdLegajo, periodoinicial, periodofinal)
      Return Resultado.Rows(0).Item("MejorSueldo").ToString()
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SueldosConceptos(Me.da).GetCodigoMaximo()
   End Function

   Public Function GetUno(ByVal idConcepto As Integer) As Entidades.SueldosConcepto
      Dim qry As SqlServer.SueldosConceptos = New SqlServer.SueldosConceptos(Me.da)

      Dim dt As DataTable = qry.SueldosConceptos_G1(idConcepto)
      Dim o As Entidades.SueldosConcepto = New Entidades.SueldosConcepto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idTipoConcepto = Integer.Parse(dr("idTipoConcepto").ToString())
            .idConcepto = Integer.Parse(dr("idConcepto").ToString())
            .NombreConcepto = dr("NombreConcepto").ToString()
            .Tipo = dr("Tipo").ToString()
            .Aguinaldo = dr("Aguinaldo").ToString()
            .Formula = dr("Formula").ToString()
            .idQuepide = Integer.Parse(dr("idQuepide").ToString())
            .LiquidacionAnual = Boolean.Parse(dr("LiquidacionAnual").ToString())
            .LiquidacionMeses = dr("LiquidacionMeses").ToString()
            .Valor = Decimal.Parse(dr("Valor").ToString())
            .CodigoConcepto = Integer.Parse(dr("CodigoConcepto").ToString())
            .MostrarEnRecibo = Boolean.Parse(dr("MostrarEnRecibo").ToString())
            .EsContempladoAguinaldo = Boolean.Parse(dr("EsContempladoAguinaldo"))
         End With
      End If

      Return o

   End Function

   Public Function GetUnoPorCodigo(ByVal CodigoConcepto As Integer, ByVal idConcepto As Integer) As DataTable
      Dim qry As SqlServer.SueldosConceptos = New SqlServer.SueldosConceptos(Me.da)

      Dim dt As DataTable = qry.SueldosConceptos_G1xCodigo(CodigoConcepto, idConcepto)
      Return dt

   End Function

   Public Function GetUno(ByVal idConcepto As Integer, ByVal EsAguinaldo As Boolean) As Entidades.SueldosConcepto
      Dim qry As SqlServer.SueldosConceptos = New SqlServer.SueldosConceptos(Me.da)

      Dim dt As DataTable = qry.SueldosConceptos_G1(idConcepto, EsAguinaldo, False, "")
      Dim o As Entidades.SueldosConcepto = New Entidades.SueldosConcepto()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idTipoConcepto = Integer.Parse(dr("idTipoConcepto").ToString())
            .idConcepto = Integer.Parse(dr("idConcepto").ToString())
            .NombreConcepto = dr("NombreConcepto").ToString()
            .Tipo = dr("Tipo").ToString()
            .Aguinaldo = dr("Aguinaldo").ToString()
            .Formula = dr("Formula").ToString()
            .idQuepide = Integer.Parse(dr("idQuepide").ToString())
            .LiquidacionAnual = Boolean.Parse(dr("LiquidacionAnual").ToString())
            .LiquidacionMeses = dr("LiquidacionMeses").ToString()
            .Valor = Decimal.Parse(dr("Valor").ToString())
            .CodigoConcepto = Integer.Parse(dr("CodigoConcepto").ToString())
            .MostrarEnRecibo = Boolean.Parse(dr("MostrarEnRecibo").ToString())
            .EsContempladoAguinaldo = Boolean.Parse(dr("EsContempladoAguinaldo"))
         End With
      End If

      Return o

   End Function

#End Region

End Class

Public Class SueldosLiquidacion
   Inherits Base

#Region "Constructores"

   Public Enum SueldosTiposConceptos
      Haberes = 1
      Retencion = 2
      Aportes = 3
      HaberesAguinaldo = 4
      Descuento = 5
      SalarioFAmiliar = 6
      Indemnizaion = 7
      NoRemunerativo = 8
      RetencionAguinaldo = 9
      AporteSobreAguinaldo = 10

   End Enum


   Public Sub New()
      Me.New(New Datos.DataAccess())

   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      NombreEntidad = "SueldosPersonalCodigos"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable

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

   Public Function GetAll(IdtipoRecibo As Integer) As System.Data.DataTable
      Return New SqlServer.SueldosLiquidacion(da).SueldosLiquidacionActual_GA(IdtipoRecibo)
   End Function



#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim oConcepto As Entidades.SueldosPersonaConcepto = DirectCast(entidad, Entidades.SueldosPersonaConcepto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosPersonalCodigos_I(oConcepto.idLegajo, oConcepto.idTipoConcepto, oConcepto.idConcepto,
                                      oConcepto.Valor,
                                      oConcepto.Periodos,
                                      oConcepto.Aguinaldo, oConcepto.TipoRecibo.IdTipoRecibo)

            Case TipoSP._U
               sql.SueldosPersonalCodigos_U(oConcepto.idLegajo, oConcepto.idTipoConcepto, oConcepto.idConcepto,
                                      oConcepto.Valor,
                                      oConcepto.Periodos,
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

   Private Sub CargarUno(dr As DataRow, o As Entidades.SueldosPersonaConcepto)
      With o
         .idTipoConcepto = dr.Field(Of Integer?)("idTipoConcepto").IfNull()
         .idConcepto = dr.Field(Of Integer?)("idConcepto").IfNull()
         .Periodos = Integer.Parse(dr("Periodos").ToString())
         .Valor = Decimal.Parse(dr("Valor").ToString())

         If Not String.IsNullOrEmpty(dr("Aguinaldo").ToString()) Then
            .Aguinaldo = dr("Aguinaldo").ToString()
         End If
      End With
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Sub ActualizarConceptosPersonal(idLegajo As Integer,
                                          listaDatos As List(Of Entidades.SueldosPersonaConcepto),
                                          idTipoRecibo As Integer)

      'agre transaccion

      Dim oConcepto As Entidades.SueldosPersonaConcepto

      da.OpenConection()

      Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(da)

      Try
         da.BeginTransaction()

         sql.SueldosPersonalCodigos_DPorTipoRecibo(idLegajo, idTipoRecibo)

         For Each oConcepto In listaDatos



            sql.SueldosPersonalCodigos_I(oConcepto.idLegajo, oConcepto.idTipoConcepto, oConcepto.idConcepto,
                                           oConcepto.Valor,
                                           oConcepto.Periodos,
                                           oConcepto.Aguinaldo, oConcepto.TipoRecibo.IdTipoRecibo)


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

   Public Function GetTodas(idTipoRecibo As Integer) As List(Of Entidades.SueldosPersonaConcepto)
      Dim dt As DataTable = Me.GetAll(idTipoRecibo)
      Dim o As Entidades.SueldosPersonaConcepto
      Dim oLis As List(Of Entidades.SueldosPersonaConcepto) = New List(Of Entidades.SueldosPersonaConcepto)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosPersonaConcepto()
         Me.CargarUno(dr, o)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetPorCodigo(codigo As String) As DataTable

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

      Return da.GetDataTable(stb.ToString())

   End Function

   Public Function GetPorNombre(nombre As String) As DataTable

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

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetDetalleRecibo(idLegajo As Integer,
                                    nroLiquidacion As Integer?,
                                    idTipoRecibo As Integer?,
                                    PeriodoLiquidacion As Integer) As DataTable
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

         Return sql.GetDetalleRecibo(idLegajo, nroLiquidacion, idTipoRecibo, PeriodoLiquidacion)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetDetalleReciboxPeriodos(idLegajo As Integer,
                                       nroLiquidacion As Integer?,
                                       idTipoRecibo As Integer?,
                                       PeriodoLiquidacionDesde As Integer,
                                       PeriodoLiquidacionHasta As Integer) As DataTable
      Try
         Me.da.OpenConection()

         Dim sql As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

         Return sql.GetDetalleReciboxPeriodos(idLegajo, nroLiquidacion, idTipoRecibo, PeriodoLiquidacionDesde, PeriodoLiquidacionHasta)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Function

   Public Function GetInformeControl(LegajoSeleccionado As String, tiporecibo As Integer, esAguinaldo As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT p.IdLegajo")
         .AppendLine("       ,p.NombrePersonal")
         .AppendLine("       ,l.IdConcepto")
         .AppendLine("	     ,c.NombreConcepto")
         .AppendLine("       ,c.IdTipoConcepto")
         .AppendLine("       ,l.IdTipoRecibo")
         .AppendLine("       ,CASE c.MostrarEnRecibo WHEN 'True' THEN  l.Valor ELSE 0 END as Valor")
         .AppendLine("       ,CASE c.MostrarEnRecibo WHEN 'True' THEN  l.Importe ELSE 0 END as Importe")
         '.AppendLine("       ,l.Valor")
         '.AppendLine("       ,CASE c.MostrarEnRecibo WHEN 'True' THEN  l.Importe THEN 0 END")
         .AppendLine("       ,c.CodigoConcepto")
         .AppendLine("       ,l.Aguinaldo")
         .AppendLine("       FROM SueldosPersonal p,")
         .AppendLine("            SueldosLiquidacionActual l,")
         .AppendLine("            SueldosTiposConceptos t,")
         .AppendLine("            SueldosConceptos c")
         .AppendLine("       WHERE p.IdLegajo = l.IdLegajo")
         .AppendLine("         AND l.IdConcepto = c.IdConcepto")
         .AppendLine("         AND t.IdTipoConcepto = c.IdTipoConcepto")
         If LegajoSeleccionado.Trim <> "" Then
            .AppendLine("       AND p.IdLegajo = " & LegajoSeleccionado)
         End If
         .AppendLine("         AND l.IdTipoRecibo = " & tiporecibo)

         If Not String.IsNullOrWhiteSpace(esAguinaldo) Then
            .AppendFormat("  AND l.Aguinaldo = '{0}'", esAguinaldo)
         End If

         .AppendLine(" ORDER BY p.IdLegajo, t.Orden, c.IdTipoConcepto, c.CodigoConcepto")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetInformeLiquidacionesDetalladas(LegajoSeleccionado As String,
                                                     tiporecibo As Integer,
                                                     PeriodoLiquidacionDesde As Integer,
                                                     PeriodoLiquidacionHasta As Integer,
                                                     Concepto As String) As DataTable

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .AppendLine("SELECT p.IdLegajo")
         .AppendLine("       ,p.NombrePersonal")
         .AppendLine("       ,l.IdConcepto")
         .AppendLine("	     ,c.NombreConcepto")
         .AppendLine("       ,c.IdTipoConcepto")
         .AppendLine("       ,l.IdTipoRecibo")
         .AppendLine("       ,l.Valor")
         .AppendLine("       ,CASE WHEN t.Tipo = 'H' THEN l.Importe ELSE 0 END as Haberes")
         .AppendLine("		  ,CASE WHEN t.Tipo = 'D' THEN l.Importe ELSE 0 END as Deducciones")
         .AppendLine("       ,c.CodigoConcepto")
         .AppendLine("       ,l.PeriodoLiquidacion")
         .AppendLine("       ,l.NroLiquidacion")
         .AppendLine("       ,(CASE WHEN t.Tipo = 'H' THEN l.Importe ELSE 0 END) - CASE WHEN t.Tipo = 'D' THEN l.Importe ELSE 0 END as Saldo")
         .AppendLine("      FROM SueldosPersonal p ")
         .AppendLine("      INNER JOIN SueldosCierreLiquidacion l ON   p.IdLegajo = l.IdLegajo")
         .AppendLine("      INNER JOIN SueldosConceptos c ON l.IdConcepto = c.IdConcepto")
         .AppendLine("      INNER JOIN SueldosTiposConceptos t ON t.IdTipoConcepto = c.IdTipoConcepto")
         .AppendLine("       WHERE  l.IdTipoRecibo = " & tiporecibo)
         .AppendFormat("     AND l.PeriodoLiquidacion >= {0}", PeriodoLiquidacionDesde).AppendLine()
         .AppendFormat("     AND l.PeriodoLiquidacion <= {0}", PeriodoLiquidacionHasta).AppendLine()
         If LegajoSeleccionado.Trim <> "" Then
            .AppendLine("    AND p.IdLegajo = " & LegajoSeleccionado)
         End If
         If Concepto.Trim <> "" Then
            .AppendLine("    AND l.IdConcepto = " & Concepto)
         End If

         .AppendLine(" ORDER BY l.PeriodoLiquidacion, l.NroLiquidacion, p.IdLegajo, t.Orden, c.IdTipoConcepto, c.CodigoConcepto")
      End With

      Return Me.da.GetDataTable(stb.ToString())

   End Function

   Public Function GetTodosLosPeriodosLiquidacion() As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

         Return sql.GetTodosLosPeriodosLiquidacion()

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function
   Public Function GetTodosNroLiquidacion(IdTipoRecibo? As Integer, PeriodoLiquidacion As Integer) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

         Return sql.GetTodosNroLiquidacion(IdTipoRecibo, PeriodoLiquidacion)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetLugarDePagoyFecha(IdTipoRecibo? As Integer, PeriodoLiquidacion As Integer, nroLiquidacion As Integer) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

         Return sql.GetLugarDePagoyFecha(IdTipoRecibo, PeriodoLiquidacion, nroLiquidacion)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCantidadPersonalLiquidados(idTipoRecibo As Integer) As Long

      Dim stb As StringBuilder = New StringBuilder("")

      With stb
         .Length = 0
         .Append("SELECT ")
         .Append(" count(*) valor ")
         .Append(" from SueldosLiquidacionActual ")
         .AppendFormat(" where IdTipoRecibo = {0} ", idTipoRecibo)
      End With

      Dim dt As DataTable = Me.da.GetDataTable(stb.ToString())
      Dim val As Long = 0

      val = Long.Parse(dt.Rows(0)("valor").ToString())


      Return val

   End Function

   Public Function GetUno(idTipoConcepto As Integer, idConcepto As Integer, EsAguinaldo As Boolean) As Entidades.SueldosConcepto

      Dim qry As SqlServer.SueldosConceptos = New SqlServer.SueldosConceptos(da)

      Dim dt As DataTable = qry.SueldosConceptos_G1(idConcepto, EsAguinaldo, False, "")

      Dim o As Entidades.SueldosConcepto = New Entidades.SueldosConcepto()

      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idTipoConcepto = Integer.Parse(dr("idTipoConcepto").ToString())
            .idConcepto = Integer.Parse(dr("idConcepto").ToString())
            .CodigoConcepto = Integer.Parse(dr("CodigoConcepto").ToString())
            .NombreConcepto = dr("NombreConcepto").ToString()
            .Tipo = dr("Tipo").ToString()
            .Aguinaldo = dr("Aguinaldo").ToString()
            '   .Calculo1 = dr("Calculo1").ToString()
            .Formula = dr("Formula").ToString()
            .idQuepide = Integer.Parse(dr("idQuepide").ToString())
            .LiquidacionAnual = Boolean.Parse(dr("LiquidacionAnual").ToString())
            .LiquidacionMeses = dr("LiquidacionMeses").ToString()
            .Valor = Decimal.Parse(dr("Valor").ToString())
         End With
      End If
      Return o
   End Function

   Public Sub GeneraLiquidacionSueldos(Periodo As String,
                                            NumeroLiquidacion As Integer,
                                            idLugarActividad As Integer,
                                            idTipoRecibo As Integer)

      Me.da.OpenConection()

      Dim oEmpleados As Reglas.SueldosPersonal = New Reglas.SueldosPersonal(da)
      Dim oSueldosConceptos As Reglas.SueldosConceptos = New Reglas.SueldosConceptos(da)

      Dim TablaEmpleados As DataTable = New DataTable()
      Dim TablaCOnceptosEmpleado As DataTable
      Dim idLegajo As Integer

      'TODO,  leer puntero y determinar si es un mes de aguinaldo
      Dim MesPeriodo As Integer
      Dim AnoPeriodo As Integer
      Dim AnoIngreso As Integer
      Dim MesIngreso As Integer
      Dim EsMesAguinaldo As Boolean

      MesPeriodo = Integer.Parse(Right(Periodo, 2))
      AnoPeriodo = Integer.Parse(Left(Periodo, 4))

      If MesPeriodo = 6 Or MesPeriodo = 12 Then
         EsMesAguinaldo = True
      Else
         EsMesAguinaldo = False
      End If

      'establece la fecha de liquidacion
      Dim DiaFinMes As Integer
      DiaFinMes = Date.DaysInMonth(AnoPeriodo, MesPeriodo)

      Dim FechaLiquidacion As New Date(AnoPeriodo, MesPeriodo, DiaFinMes)

      Dim sql As SqlServer.SueldosPersonalCodigos = New SqlServer.SueldosPersonalCodigos(da)
      Dim objLiq As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)


      Dim Haberes As Decimal
      Dim Retencion As Decimal
      Dim Aportes As Decimal
      Dim Descuento As Decimal
      Dim SalarioFamiliar As Decimal
      Dim Indemniza As Decimal
      Dim MejorSueldo As Decimal
      Dim NoRemunerativo As Decimal
      Dim HaberAguinaldo As Decimal
      Dim RetencionAguinaldo As Decimal
      Dim Total As Decimal
      Dim Familiar As Decimal
      Dim idConcepto As Integer
      Dim idTipoConcepto As Integer
      Dim Valor As Decimal
      Dim ImporteLiquidado As Decimal
      Dim Antiguedad As Integer
      Dim HaberesContempladosAguinaldo As Decimal
      Dim MejorSueldoGuardado As Decimal
      'Dim CoeficienteQuePasa As Integer

      'Recupera Concepto Aguinaldo
      Dim idConceptoAguinaldo As Integer = Reglas.Publicos.SueldosConceptoAguinaldo ' Integer.Parse(New Eniac.Reglas.Parametros().GetValor(Entidades.Parametro.Parametros.SUELDOS_CONCEPTO_AGUINALDO))

      Try
         Me.da.BeginTransaction()

         'borrar los datos de la tabla Liquidacion
         objLiq.LimpiaSueldosLiquidacionActual(idTipoRecibo)

         'seleccionar los empleados activos
         If idLugarActividad = 0 Then
            TablaEmpleados = oEmpleados._GetPersonalActivo()
         Else
            TablaEmpleados = oEmpleados._GetPersonalActivoPorLugarActividad(idLugarActividad)
         End If

         '    sql.SueldosPersonalCodigos_D(idLegajo)

         For Each Empleado As DataRow In TablaEmpleados.Rows
            'traer los conceptos de liquidacion, si no tiene pasar al que sigue

            idLegajo = Empleado.Field(Of Integer?)("idLegajo").IfNull()

            TablaCOnceptosEmpleado = oSueldosConceptos.GetConceptosPersona(idLegajo, idTipoRecibo)

            If TablaCOnceptosEmpleado.Rows.Count = 0 Then
               Continue For
            End If

            'calcular la antiguedad del empleado
            AnoIngreso = Year(Empleado.Field(Of DateTime?)("fechaingreso").IfNull())
            MesIngreso = Month(Empleado.Field(Of DateTime?)("fechaingreso").IfNull())

            Antiguedad = AnoPeriodo - AnoIngreso
            If MesPeriodo < MesIngreso And Antiguedad > 0 Then
               Antiguedad = Antiguedad - 1
            End If


            Haberes = 0
            Retencion = 0
            Aportes = 0
            Descuento = 0
            SalarioFamiliar = 0
            Indemniza = 0
            MejorSueldo = 0
            NoRemunerativo = 0
            HaberAguinaldo = 0
            RetencionAguinaldo = 0
            Total = 0
            Familiar = 0
            idConcepto = 0
            idTipoConcepto = 0
            Valor = 0
            ImporteLiquidado = 0
            HaberesContempladosAguinaldo = 0
            MejorSueldoGuardado = 0

            For Each ConceptoEmpleado As DataRow In TablaCOnceptosEmpleado.Rows

               '                    Determina si es un codigo de liquidacion anual, y si no corresponde al mes que se tiene que liquidar lo saltea y sigue con otro (esto se configura en el abm de codigos de liquidacion) 
               If MesPeriodo = 6 Or MesPeriodo = 12 Then
               Else
                  If ConceptoEmpleado.Item("Aguinaldo").ToString() = "S" Then
                     Continue For
                  End If
               End If

               idConcepto = ConceptoEmpleado.Field(Of Integer)("idconcepto")
               idTipoConcepto = Integer.Parse(ConceptoEmpleado.Item("idTipoConcepto").ToString)

               'GAR : 30/08 - Asigno liqvalor si corresponde, no utiliza
               'Si funciona borrar todo el codigo.
               'If ConceptoEmpleado.Item("Formula").ToString().Contains("CODVALOR") And Not ConceptoEmpleado.Item("Formula").ToString().Contains("LIQVALOR") Then
               ' Valor = Decimal.Parse(ConceptoEmpleado.Item("ConceptoValor").ToString)
               'Else
               Valor = Decimal.Parse(ConceptoEmpleado.Item("Valor").ToString)
               'End If


               'Si el codigo es el de aguinaldo (Originalmente el 241) calcula el mejor sueldo y los dias trabajados 
               ' entre la fecha de ingreso y la de liquidacion por si es un empleado nuevo 
               If idConcepto = idConceptoAguinaldo Then

                  MejorSueldo = HaberesContempladosAguinaldo - Indemniza
                  MejorSueldoGuardado = oSueldosConceptos.GetMejorSueldo(idLegajo, AnoPeriodo, MesPeriodo)

                  If MejorSueldo < MejorSueldoGuardado Then
                     MejorSueldo = MejorSueldoGuardado
                  End If

                  Dim Dias As Long
                  Dias = DateDiff(DateInterval.Day, Empleado.Field(Of DateTime?)("FechaIngreso").IfNull(), FechaLiquidacion) + 1
                  If Dias >= 180 Then
                     ImporteLiquidado = Math.Round(MejorSueldo * 180 / 360, 2)
                  Else
                     ImporteLiquidado = Math.Round(MejorSueldo * Dias / 360, 2)
                  End If

               Else

                  'Si no es aguinaldo, toma el campo "formula" y lo ejecuta como una macro, obteniendo un importe. 

                  'HAY QUE VER COMO SE LIQUIDA ESTO QUE EN FOX SOLO EJECUTA UNA MACRO
                  ImporteLiquidado = 0
                  Dim FormulaCalculo As String

                  If String.IsNullOrEmpty(ConceptoEmpleado.Item("Formula").ToString()) Then
                     Throw New Exception("El Concepto " & ConceptoEmpleado.Item("NombreConcepto").ToString() & " no tiene formula para el legajo nro: " _
                                         & ConceptoEmpleado.Item("IdLegajo").ToString())
                  End If

                  FormulaCalculo = ConceptoEmpleado.Item("Formula").ToString

                  'FormulaCalculo = ConvierteCadena(FormulaCalculo, "LIQVALOR", Valor)
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "LIQVALOR", Decimal.Parse(ConceptoEmpleado.Item("Valor").ToString))
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "BASICO", Decimal.Parse(Empleado.Item("SueldoBasico").ToString))
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "CODVALOR", Decimal.Parse(ConceptoEmpleado.Item("ConceptoValor").ToString))
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "MEJORSUE", MejorSueldo)

                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "HABEAGUIN", HaberAguinaldo)
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "ANTIGUEDAD", Antiguedad)
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "HABERES", Haberes)
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "RETENCION", Retencion)
                  'FormulaCalculo = ConvierteCadena(FormulaCalculo, "ANTICIPO", anti)
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "BFAMILIAR", SalarioFamiliar)
                  FormulaCalculo = ConvierteCadena(FormulaCalculo, "RETEAGUIN", RetencionAguinaldo)


                  'GAR: 13/09/2016 -- Agregado y quitado. Pensarlo bien.
                  'CoeficienteQuePasa = 1
                  'If ConceptoEmpleado.Item("idQuepide").ToString() = 3 Then 'PORCENTAJE. 
                  '   CoeficienteQuePasa = 100
                  'End If

                  'Ejecuta calculo
                  Dim oSC As New MSScriptControl.ScriptControl
                  oSC.Language = "VBScript"
                  ImporteLiquidado = Decimal.Round(Decimal.Parse(oSC.Eval(FormulaCalculo).ToString()), 2)

                  'ImporteLiquidado = Decimal.Round(Decimal.Parse(oSC.Eval(FormulaCalculo).ToString()) / CoeficienteQuePasa, 2)

               End If

               'Acumula el importe en variables acumuladores fijas, que corresponden al campo rubro de la tabla concepto. Esta compilado: 1.haberes, 2.retencion, 3.aportes, .aguinaldo, etc 
               Select Case idTipoConcepto
                  Case SueldosLiquidacion.SueldosTiposConceptos.Haberes
                     Haberes += ImporteLiquidado
                  Case SueldosLiquidacion.SueldosTiposConceptos.Retencion
                     Retencion += ImporteLiquidado
                  Case SueldosLiquidacion.SueldosTiposConceptos.Aportes
                     Aportes += ImporteLiquidado
                  Case SueldosLiquidacion.SueldosTiposConceptos.HaberesAguinaldo
                     HaberAguinaldo += ImporteLiquidado
                  Case SueldosLiquidacion.SueldosTiposConceptos.Descuento
                     Descuento += ImporteLiquidado
                  Case SueldosLiquidacion.SueldosTiposConceptos.SalarioFAmiliar
                     SalarioFamiliar += ImporteLiquidado
                  Case SueldosLiquidacion.SueldosTiposConceptos.Indemnizaion
                     Indemniza += ImporteLiquidado
                  Case SueldosLiquidacion.SueldosTiposConceptos.RetencionAguinaldo
                     RetencionAguinaldo += ImporteLiquidado
               End Select

               If ConceptoEmpleado.Field(Of Boolean)("EsContempladoAguinaldo") Then
                  HaberesContempladosAguinaldo += ImporteLiquidado
               End If

               If EsMesAguinaldo = False Then
                  If idTipoConcepto = SueldosLiquidacion.SueldosTiposConceptos.Haberes Then
                     Total = Total + ImporteLiquidado
                  ElseIf idTipoConcepto = SueldosLiquidacion.SueldosTiposConceptos.SalarioFAmiliar Then
                     Familiar = Familiar + ImporteLiquidado
                  End If
               End If


               'Agrega un registro a la tabla liquida con el concepto y el importe calculado.  Acumula el importe al total del empleado. Lee el siguiente concepto de liquidacion del empleado.

               objLiq.SueldosLiquidacionActual_I(idLegajo,
                                                 idTipoConcepto,
                                                 idConcepto,
                                                 Valor,
                                                 ImporteLiquidado,
                                                 NumeroLiquidacion,
                                                 ConceptoEmpleado.Field(Of String)("aguinaldo"),
                                                 idTipoRecibo,
                                                 ConceptoEmpleado.Field(Of Integer)("Periodos"))

               'cuando calculó todos los conceptos almacena en la tabla personal el sueldo del empleado y el total del rubro 6 correspondiente a salario familiar. 


            Next

            Try
               objLiq.GrabaSueldoActual(idLegajo, Total, Familiar)
            Catch ex As Exception
               Throw New Exception(String.Format("Error actalizando sueldo actual del legajo: {0} - {1}. Error: {2}", idLegajo, Empleado("NombrePersonal").ToString(), ex.Message), ex)
            End Try

         Next
         Me.da.CommitTransaction()

      Catch ex As Exception

         da.RollbakTransaction()

         Throw

      End Try


      'borra los onceptos del peronal

      'agrega

      'cierra transa


   End Sub

   Public Function MostrarResumenLiquidacion(idTipoRecibo As Integer) As DataTable

      Dim Tabla As DataTable

      Dim objLiq As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

      Tabla = objLiq.GetResumenLiquidacion(idTipoRecibo)

      Return Tabla

   End Function

   Public Sub Cierre_de_Liquidacion(Período As String,
                                         numeroLiquidacion As Integer,
                                         mesLiquidacion As Integer,
                                         anoLiquidacion As Integer,
                                         idTipoRecibo As Integer,
                                         fechaPago As Date,
                                         lugarPago As String,
                                         domicilioempresa As String,
                                         cantidadLiquidacionPeriodo As Integer)

      Dim oEmpleados As Reglas.SueldosPersonal
      Dim oSueldosConceptos As Reglas.SueldosConceptos
      Dim PeriodoActual As Integer '
      Dim sql As SqlServer.SueldosPersonalCodigos
      Dim objLiq As SqlServer.SueldosLiquidacion
      Dim objEmpleAcu As SqlServer.SueldosPersonal
      Dim TablaLiquidacionActual As DataTable
      Dim TablaLiquidacionPersonal As DataTable
      Dim TablaTotales As DataTable
      Dim Empleado As DataTable
      Dim Legajo As Integer
      Dim TipoConcepto As Integer
      Dim AcumuladoAnul As Decimal
      Dim AcumuladoSalarioFamiliar As Decimal
      'Dim MejorSueldo As Decimal
      Dim Importe As Decimal
      Dim oParam As Eniac.Reglas.Parametros
      Dim Periodo As Integer
      Dim Cadena As String
      Dim TotalesHaberesParaAguinaldo As Dictionary(Of Integer, Decimal)


      Try
         Me.da.OpenConection()

         Me.da.BeginTransaction()

         oEmpleados = New Reglas.SueldosPersonal(da)
         oSueldosConceptos = New Reglas.SueldosConceptos(da)
         sql = New SqlServer.SueldosPersonalCodigos(da)
         objLiq = New SqlServer.SueldosLiquidacion(da)
         objEmpleAcu = New SqlServer.SueldosPersonal(da)

         PeriodoActual = anoLiquidacion * 100 + mesLiquidacion

         cantidadLiquidacionPeriodo += 1

         'ACTUALIZA SUELDOS CIERRE LIQUIDACION DESDE SUELDOS LIQUIDACION ACTUAL

         TablaLiquidacionActual = objLiq.SueldosLiquidacionActual_GA(idTipoRecibo)
         TablaLiquidacionPersonal = objLiq.SueldosLiquidacionActPersonal(idTipoRecibo)

         TotalesHaberesParaAguinaldo = New Dictionary(Of Integer, Decimal)()
         For Each Linea As DataRow In TablaLiquidacionActual.Rows

            If Linea.Field(Of Boolean)("EsContempladoAguinaldo") Then
               If Not TotalesHaberesParaAguinaldo.ContainsKey(Linea.Field(Of Integer)("IdLegajo")) Then
                  TotalesHaberesParaAguinaldo.Add(Linea.Field(Of Integer)("IdLegajo"), 0)
               End If
               TotalesHaberesParaAguinaldo(Linea.Field(Of Integer)("IdLegajo")) += Decimal.Parse(Linea.Item("importe").ToString())
            End If

            objLiq.SueldosCierreLiquidacion_I(Integer.Parse(Linea.Item("IdLegajo").ToString()),
                                                Integer.Parse(Linea.Item("IdTipoConcepto").ToString()),
                                                Integer.Parse(Linea.Item("IdConcepto").ToString()),
                                                Decimal.Parse(Linea.Item("valor").ToString()),
                                                Decimal.Parse(Linea.Item("importe").ToString()),
                                                PeriodoActual,
                                                Linea.Item("aguinaldo").ToString(),
                                                Int32.Parse(Linea.Item("IdTipoRecibo").ToString()),
                                                numeroLiquidacion,
                                                Int32.Parse(Linea.Item("Periodos").ToString()))
         Next


         'Actualizo Datos generales liquidacion
         Dim idCtaBancaria As Integer
         Dim IdCuentasBancariasClaseCtaBancaria As Integer
         Dim NumeroCuentaBancaria As String
         Dim CBU As Decimal
         Dim SueldoBasico As Decimal
         Dim idCategoria As Integer
         Dim HaberesParaAguinaldo As Decimal = 0

         For Each linea1 As DataRow In TablaLiquidacionPersonal.Rows
            If Not String.IsNullOrEmpty(linea1.Item("IdBancoCtaBancaria").ToString()) Then
               idCtaBancaria = Integer.Parse(linea1.Item("IdBancoCtaBancaria").ToString())
            Else
               idCtaBancaria = 0
            End If
            If Not String.IsNullOrEmpty(linea1.Item("IdCuentasBancariasClaseCtaBancaria").ToString()) Then
               IdCuentasBancariasClaseCtaBancaria = Integer.Parse(linea1.Item("IdCuentasBancariasClaseCtaBancaria").ToString())
            Else
               IdCuentasBancariasClaseCtaBancaria = 0
            End If
            If Not String.IsNullOrEmpty(linea1.Item("NumeroCuentaBancaria").ToString()) Then
               NumeroCuentaBancaria = linea1.Item("NumeroCuentaBancaria").ToString()
            Else
               NumeroCuentaBancaria = "0"
            End If
            If Not String.IsNullOrEmpty(linea1.Item("CBU").ToString()) Then
               CBU = Decimal.Parse(linea1.Item("CBU").ToString())
            Else
               CBU = 0
            End If
            SueldoBasico = Decimal.Parse(linea1("SueldoBasico").ToString())
            idCategoria = Int32.Parse(linea1("IdCategoria").ToString())
            TotalesHaberesParaAguinaldo.TryGetValue(linea1.Field(Of Integer)("IdLegajo"), HaberesParaAguinaldo)
            'Si no existe en la lista debe ser 0
            objLiq.SueldosCierreLiqDatos_I(Integer.Parse(linea1.Item("IdLegajo").ToString()),
                                           Int32.Parse(linea1.Item("IdTipoRecibo").ToString()),
                                           PeriodoActual,
                                           fechaPago,
                                           lugarPago,
                                          domicilioempresa,
                                          idCtaBancaria,
                                          IdCuentasBancariasClaseCtaBancaria,
                                          NumeroCuentaBancaria,
                                          CBU,
                                          numeroLiquidacion,
                                          SueldoBasico,
                                          idCategoria,
                                          HaberesParaAguinaldo)
            'TotalesHaberesParaAguinaldo(Integer.Parse(linea1.Item("IdLegajo"))))

         Next


         'ACTUALIZA ACUMULADORES DE PERSONAL

         'calcula el mejor sueldo
         TablaTotales = objLiq.SueldosLiquidacionActualTotales()
         Legajo = Integer.Parse(TablaLiquidacionActual.Rows(0).Item("idLegajo").ToString())


         For Each Linea As DataRow In TablaTotales.Rows
            TipoConcepto = Integer.Parse(Linea.Item("IdTipoConcepto").ToString())

            If TipoConcepto <> 1 And TipoConcepto <> 6 Then
               Continue For
            End If

            Legajo = Integer.Parse(Linea.Item("IdLegajo").ToString())
            Importe = Decimal.Parse(Linea.Item("total").ToString())
            Empleado = oEmpleados.GetFiltradoPorLegajo(Legajo)

            If TipoConcepto = 1 Then
               AcumuladoAnul = Decimal.Parse(Empleado.Rows(0).Item("AcumuladoAnual").ToString())
               'actualiza acumulado anual
               objEmpleAcu.SueldosPersonal_U_AcumAnual(Legajo, AcumuladoAnul)


            Else
               'salario familiar
               AcumuladoSalarioFamiliar = Decimal.Parse(Empleado.Rows(0).Item("AcumuladoSalarioFamiliar").ToString()) * Importe
               objEmpleAcu.SueldosPersonal_U_AcumuladoSalarioFAmiliar(Legajo, AcumuladoSalarioFamiliar)
            End If
         Next

         If mesLiquidacion = 12 Then
            'borra los acumuladores en diciembre
            objLiq.InicializaAcumuladores()
         End If


         'ACTUALIZA LOS CONCEPTOS QUE SE LIQUIDAN POR UNICA VEZ

         objLiq.SueldosLiquidacionEliminaConceptosLiquidacioPorUnicaVez(idTipoRecibo)

         'ACTUALIZA SUELDOSPUNTERO
         objLiq.SueldosCierrePuntero_I(numeroLiquidacion, mesLiquidacion, anoLiquidacion)

         oParam = New Eniac.Reglas.Parametros(da)


         Dim recibo As Entidades.SueldosTipoRecibo = New Reglas.SueldosTiposRecibos(da)._GetUno(idTipoRecibo)
         Dim sqlSueldosTipoRecibo As SqlServer.SueldosTiposRecibos = New SqlServer.SueldosTiposRecibos(da)

         If recibo.CantidadLiquid = 1 Or recibo.CantidadLiquid = cantidadLiquidacionPeriodo Then
            numeroLiquidacion += 1

            mesLiquidacion += 1
            If mesLiquidacion = 13 Then
               mesLiquidacion = 1
               anoLiquidacion += 1
            End If

            Periodo = anoLiquidacion * 100 + mesLiquidacion
            Cadena = Periodo.ToString
            Cadena = Mid(Cadena, 1, 4) & "-" & Mid(Cadena, 5, 2)

            sqlSueldosTipoRecibo.SueldosTiposRecibos_U_PeriodoYNumeroLiquidacion(idTipoRecibo,
                                                                                 Periodo,
                                                                                 numeroLiquidacion,
                                                                                 0,
                                                                                 fechaPago)

         Else
            Periodo = anoLiquidacion * 100 + mesLiquidacion
            numeroLiquidacion += 1
            sqlSueldosTipoRecibo.SueldosTiposRecibos_U_PeriodoYNumeroLiquidacion(idTipoRecibo,
                                                                                 Periodo,
                                                                                 numeroLiquidacion,
                                                                                 cantidadLiquidacionPeriodo,
                                                                                 fechaPago)

         End If




         'borrar los datos de la tabla Liquidacion
         objLiq.LimpiaSueldosLiquidacionActual(idTipoRecibo)


         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw ex

      Finally
         Me.da.CloseConection()
      End Try

      'borra los onceptos del peronal

      'agrega

      'cierra transa


   End Sub

   Public Sub ReAbrirLiquidacion(mesLiquidacion As Integer, anoLiquidacion As Integer,
                                 idTipoRecibo As Integer, nroLiquidacion As Integer)
      EjecutaConTransaccion(
         Sub()
            Dim recibo As Entidades.SueldosTipoRecibo = New Reglas.SueldosTiposRecibos(da)._GetUno(idTipoRecibo)

            Dim cantidadLiquidaciones = recibo.CantidadLiquidPeriodo
            cantidadLiquidaciones += 1

            'identificar el ultimo periodo a volver atras
            If recibo.CantidadLiquidPeriodo = 0 Or cantidadLiquidaciones = 1 Then
               mesLiquidacion -= 1
               If mesLiquidacion = 0 Then
                  anoLiquidacion -= 1
                  mesLiquidacion = 12
               End If
               cantidadLiquidaciones = recibo.CantidadLiquid
            Else
               If recibo.CantidadLiquid > 1 And recibo.CantidadLiquid = cantidadLiquidaciones Then
                  cantidadLiquidaciones -= 1
               Else
                  mesLiquidacion -= 1
                  If mesLiquidacion = 0 Then
                     anoLiquidacion -= 1
                     mesLiquidacion = 12
                  End If
                  cantidadLiquidaciones = recibo.CantidadLiquid
               End If
            End If

            'vuelvo atras el nro. de liquidación
            nroLiquidacion -= 1

            Dim periodo = anoLiquidacion * 100 + mesLiquidacion

            Dim sqlSueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)
            'Al reabrir se decidió que se deben dejar los conceptos del empleado igual a como estaban antes de liquidar
            'no importa si el usuario los cambió, ya que debe poder volver a generar la liquidación tal como estaba o
            'cambiarle a la misma lo que haga falta.
            'Por ello copio los registros de la tabla de SueldosCierreLiquidacion a SueldosPersonalCodigos
            sqlSueldosLiquidacion.CopiarCierreLiquidacionAPersonalCodigos(idTipoRecibo, periodo, nroLiquidacion)

            'eliminar todos los registros de la tabla actual (despues voy a copiar todos los que estaban en la definitiva)
            sqlSueldosLiquidacion.LimpiaSueldosLiquidacionActual(idTipoRecibo)

            'eliminar todos los registros del detalle y tabla de datos
            sqlSueldosLiquidacion.EliminaSueldosCierreLiqDatos(idTipoRecibo, periodo, nroLiquidacion)
            sqlSueldosLiquidacion.EliminaSueldosCierreLiquidacion(idTipoRecibo, periodo, nroLiquidacion)

            'ACTUALIZA ACUMULADORES DE PERSONAL

            'calcula el mejor sueldo
            Using TablaTotales = sqlSueldosLiquidacion.SueldosCierreLiquidacionTotales()

               For Each Linea In TablaTotales.Rows.OfType(Of DataRow)()
                  Dim TipoConcepto = Integer.Parse(Linea.Item("IdTipoConcepto").ToString())

                  If TipoConcepto <> 1 And TipoConcepto <> 6 Then
                     Continue For
                  End If

                  Dim Legajo = Integer.Parse(Linea.Item("IdLegajo").ToString())
                  Dim Importe = Decimal.Parse(Linea.Item("total").ToString())
                  Dim rEmpleados = New Reglas.SueldosPersonal(da)
                  Dim sqlEmpleAcu = New SqlServer.SueldosPersonal(da)
                  Using Empleado = rEmpleados.GetFiltradoPorLegajo(Legajo)
                     If TipoConcepto = 1 Then
                        Dim AcumuladoAnul = sqlSueldosLiquidacion.GetAcumuladoAnual(Legajo, anoLiquidacion)
                        'actualiza mejor sueldo y acumulado anual

                        'Lautaro dice: cambiado por la función nueva que no usa MejorSueldo del empleado
                        'objEmpleAcu.SueldosPersonal_U_MejorSueldo_AcumAnual(Legajo, MejorSueldo, AcumuladoAnul)
                        sqlEmpleAcu.SueldosPersonal_U_AcumAnual(Legajo, AcumuladoAnul)
                     Else
                        'salario familiar
                        Dim AcumuladoSalarioFamiliar = Decimal.Parse(Empleado.Rows(0).Item("AcumuladoSalarioFamiliar").ToString()) * Importe
                        sqlEmpleAcu.SueldosPersonal_U_AcumuladoSalarioFAmiliar(Legajo, AcumuladoSalarioFamiliar)
                     End If
                  End Using
               Next
            End Using

            If mesLiquidacion = 1 Then
               'borra los acumuladores en diciembre
               sqlSueldosLiquidacion.InicializaAcumuladores()
            End If

            Dim sqlSueldosTipoRecibo As SqlServer.SueldosTiposRecibos = New SqlServer.SueldosTiposRecibos(da)

            cantidadLiquidaciones -= 1

            Dim dtUltimoPeriodo = sqlSueldosLiquidacion.UltimoPeriodoLuegoReabrir(idTipoRecibo)
            Dim drUltimoPeriodo = dtUltimoPeriodo.FirstOrDefault()

            If drUltimoPeriodo IsNot Nothing Then
               Dim prox = CalculaProximoPeriodoLiquidacion(recibo, cantidadLiquidaciones,
                                                           drUltimoPeriodo.Field(Of Integer)("NroLiquidacion"),
                                                           drUltimoPeriodo.Field(Of Integer)("PeriodoLiquidacion"))
               sqlSueldosTipoRecibo.SueldosTiposRecibos_U_PeriodoYNumeroLiquidacion(
                                                idTipoRecibo, prox.Item1,
                                                drUltimoPeriodo.Field(Of Integer)("NroLiquidacion") + 1,
                                                prox.Item3, Date.Now)
            End If
         End Sub)
   End Sub

   Function ConvierteCadena(Cadena As String, Constante As String, Valor As Decimal) As String

      If InStr(Cadena, Constante, CompareMethod.Text) > 0 Then

         Cadena = Replace(Cadena, Constante, Valor.ToString)

      End If

      Return Cadena

   End Function

   Public Function GetUnaLiqDatos(idPersonal As Integer,
                                  idTipoRecibo As Integer?,
                                  PeriodoLiquidacion As Integer,
                                 NroLiquidacion As Integer?) As Entidades.SueldosCierreLiqDatos
      Dim qry As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

      Dim dt As DataTable = qry.SueldosCierreLiqDatos_G1(idPersonal, idTipoRecibo, NroLiquidacion, PeriodoLiquidacion)
      Dim o As Entidades.SueldosCierreLiqDatos = New Entidades.SueldosCierreLiqDatos()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         With o
            .idLegajo = dr.Field(Of Integer)("IdLegajo")
            .idTipoRecibo = dr.Field(Of Integer)("IdTipoRecibo")
            .NroLiquidacion = dr.Field(Of Integer)("NroLiquidacion")
            .FechaPago = dr.Field(Of DateTime)("FechaPago")
            .LugarPago = dr("LugarPago").ToString()
            .DomicilioEmpresa = dr("DomicilioEmpresa").ToString()
            If Not String.IsNullOrEmpty(dr("IdBancoCtaBancaria").ToString()) Then
               .IdBancoCtaBancaria = dr.Field(Of Integer)("IdBancoCtaBancaria")
            Else
               .IdBancoCtaBancaria = 0
            End If
            .NombreBanco = dr("NombreBanco").ToString()
            If Not String.IsNullOrEmpty(dr("IdCuentasBancariasClaseCtaBancaria").ToString()) Then
               .IdCuentasBancariasClaseCtaBancaria = dr.Field(Of Integer)("IdCuentasBancariasClaseCtaBancaria")
            Else
               .IdCuentasBancariasClaseCtaBancaria = 0
            End If
            .NombreCuentaBancariaClase = dr("NombreCuentaBancariaClase").ToString()
            .NumeroCuentaBancaria = dr("NumeroCuentaBancaria").ToString()
            .CBU = dr.Field(Of Decimal)("CBU")
            .SueldoBasico = Decimal.Parse(dr("SueldoBasico").ToString())
            .SueldoCategoria = New Reglas.SueldosCategorias(da)._GetUno(Int32.Parse(dr("IdCategoria").ToString()))
         End With
      End If
      Return o
   End Function

   Public Sub ActualizarLugarDePagoyFecha(LugarPago As String,
                                          FechaPago As Date,
                                          IdTipoRecibo? As Integer,
                                          PeriodoLiquidacion As Integer,
                                          nroLiquidacion As Integer,
                                          idLegajo As Integer)
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.SueldosLiquidacion = New SqlServer.SueldosLiquidacion(da)

         sql.ActualizarLugarDePagoyFecha(LugarPago, FechaPago, IdTipoRecibo.IfNull(), PeriodoLiquidacion, nroLiquidacion, idLegajo)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Function CalculaProximoPeriodoLiquidacion(idTipoRecibo As Integer,
                                                    cantidadLiquidacionPeriodo As Integer, numeroLiquidacion As Integer, periodoLiquidacion As Integer) As Tuple(Of Integer, Integer, Integer)
      Return CalculaProximoPeriodoLiquidacion(New SueldosTiposRecibos(da)._GetUno(idTipoRecibo),
                                              cantidadLiquidacionPeriodo, numeroLiquidacion, periodoLiquidacion)
   End Function
   Public Function CalculaProximoPeriodoLiquidacion(recibo As Entidades.SueldosTipoRecibo,
                                                    cantidadLiquidacionPeriodo As Integer, numeroLiquidacion As Integer, periodoLiquidacion As Integer) As Tuple(Of Integer, Integer, Integer)
      Dim mesLiquidacion = periodoLiquidacion.FromPeriodo().Month
      Dim anoLiquidacion = periodoLiquidacion.FromPeriodo().Year

      If recibo.CantidadLiquid = 1 Or recibo.CantidadLiquid = cantidadLiquidacionPeriodo Then
         numeroLiquidacion += 1

         mesLiquidacion += 1
         If mesLiquidacion = 13 Then
            mesLiquidacion = 1
            anoLiquidacion += 1
         End If
         cantidadLiquidacionPeriodo = 0
      Else
         numeroLiquidacion += 1
      End If
      Return New Tuple(Of Integer, Integer, Integer)(anoLiquidacion * 100 + mesLiquidacion, numeroLiquidacion, cantidadLiquidacionPeriodo)
   End Function

#End Region

End Class
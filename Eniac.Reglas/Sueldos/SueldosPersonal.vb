Option Explicit On
Option Strict On

#Region "Imports"

Imports System.Text
Imports Eniac.Datos

#End Region

Public Class SueldosPersonal
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "SueldosPersonal"
      da = New Datos.DataAccess()
   End Sub

   Friend Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "SueldosPersonal"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._I)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)
      Me.EjecutaSP(entidad, TipoSP._D)
   End Sub

   Public Sub Insertar2(ByVal en As Entidades.SueldosPersonal)
      'Dim en As Entidades.SueldosPersonal = DirectCast(entidad, Entidades.SueldosPersonal)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim dtf As DataTable = en.Familiares

         Dim sql As SqlServer.SueldosPersonal = New SqlServer.SueldosPersonal(da)
         Dim sqlAudit As Eniac.SqlServer.Auditorias = New Eniac.SqlServer.Auditorias(da)

         sql.SueldosPersonal_I(en.idLegajo, en.NombrePersonal, en.Domicilio, en.idLocalidad, _
                              en.TipoDocPersonal, en.NroDocPersonal, en.idNacionalidad, en.Sexo, en.IdEstadoCivil, _
                              en.Cuil, en.LegajoMinTrabajo, en.idObraSocial, en.CodObraSocial, _
                              en.FechaNacimiento, en.FechaIngreso, en.FechaBaja, en.idCategoria, _
                              en.CentroCosto, en.SueldoBasico, en.MejorSueldo, en.AcumuladoAnual, _
                              en.AcumuladoSalarioFamiliar, en.SueldoActual, en.SalarioFamiliarActual, en.AFJP, en.AnteriorAcumuladoAnual, _
                              en.AnteriorMejorSueldo, en.AnteriorSalarioFamiliar, en.MotivoBaja.IdMotivoBaja, _
                              en.LugarActividad.IdLugarActividad, en.DatosFamiliares, en.Banco.IdBanco, _
                              en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CBU)
         'Familiares
         Dim sql2 As SqlServer.SueldosPersonalFamiliares = New SqlServer.SueldosPersonalFamiliares(da)
         If dtf.GetChanges(DataRowState.Deleted) IsNot Nothing Then
            For Each dr As DataRow In dtf.GetChanges(DataRowState.Deleted).Rows
               If dr.RowState = DataRowState.Deleted Then
                  sql2.SueldosPersonalFamiliares_D(Integer.Parse(dr("IdLegajo", DataRowVersion.Original).ToString()), _
                                              Long.Parse(dr("CuilFamiliar", DataRowVersion.Original).ToString()))
               End If
            Next
         End If
         For Each dr As DataRow In dtf.Rows
            If dr.RowState = DataRowState.Added Then
               sql2.SueldosPersonalFamiliares_I(Integer.Parse(dr("IdLegajo", DataRowVersion.Current).ToString()), _
                                          Long.Parse(dr("CuilFamiliar", DataRowVersion.Current).ToString()), _
                                         dr("NombreFamiliar", DataRowVersion.Current).ToString(), _
                                         Date.Parse(dr("FechaNacimientoFamiliar", DataRowVersion.Current).ToString()), _
                                         dr("IdTipoVinculoFamiliar", DataRowVersion.Current).ToString(), _
                                         dr("SexoFamiliar", DataRowVersion.Current).ToString())
            End If

         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Actualizar2(ByVal en As Entidades.SueldosPersonal)
      'Dim en As Entidades.SueldosPersonal = DirectCast(entidad, Entidades.SueldosPersonal)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = en.Familiares

         Dim sql As SqlServer.SueldosPersonal = New SqlServer.SueldosPersonal(da)
         Dim sqlAudit As Eniac.SqlServer.Auditorias = New Eniac.SqlServer.Auditorias(da)

         sql.SueldosPersonal_U(en.idLegajo, en.NombrePersonal, en.Domicilio, en.idLocalidad, _
                        en.TipoDocPersonal, en.NroDocPersonal, en.idNacionalidad, en.Sexo, en.IdEstadoCivil, _
                        en.Cuil, en.LegajoMinTrabajo, en.idObraSocial, en.CodObraSocial, _
                        en.FechaNacimiento, en.FechaIngreso, en.FechaBaja, en.idCategoria, _
                        en.CentroCosto, en.SueldoBasico, en.MejorSueldo, en.AcumuladoAnual, _
                        en.AcumuladoSalarioFamiliar, en.SueldoActual, en.SalarioFamiliarActual, en.AFJP, _
                        en.AnteriorAcumuladoAnual, _
                        en.AnteriorMejorSueldo, en.AnteriorSalarioFamiliar, en.MotivoBaja.IdMotivoBaja, _
                        en.LugarActividad.IdLugarActividad, en.DatosFamiliares, en.Banco.IdBanco, _
                        en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CBU)

         Dim sql2 As SqlServer.SueldosPersonalFamiliares = New SqlServer.SueldosPersonalFamiliares(da)


         If dt.GetChanges(DataRowState.Deleted) IsNot Nothing Then
            For Each dr As DataRow In dt.GetChanges(DataRowState.Deleted).Rows
               If dr.RowState = DataRowState.Deleted Then
                  sql2.SueldosPersonalFamiliares_D(Integer.Parse(dr("IdLegajo", DataRowVersion.Original).ToString()), _
                                              Long.Parse(dr("CuilFamiliar", DataRowVersion.Original).ToString()))
               End If
            Next
         End If
         For Each dr As DataRow In dt.Rows
            If dr.RowState = DataRowState.Added Then

               sql2.SueldosPersonalFamiliares_I(Integer.Parse(dr("IdLegajo", DataRowVersion.Current).ToString()), _
                           Long.Parse(dr("CuilFamiliar", DataRowVersion.Current).ToString()), _
                          dr("NombreFamiliar", DataRowVersion.Current).ToString(), _
                          Date.Parse(dr("FechaNacimientoFamiliar", DataRowVersion.Current).ToString()), _
                          dr("IdTipoVinculoFamiliar", DataRowVersion.Current).ToString(), _
                          dr("SexoFamiliar", DataRowVersion.Current).ToString())
            End If

         Next

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      entidad.Columna = "C." & entidad.Columna

      Select Case entidad.Columna

         Case "C.NombreLocalidad"
            entidad.Columna = "L." + entidad.Columna.Replace("C.", "")

         Case "C.NombreEstadoCivil"
            entidad.Columna = "E." + entidad.Columna.Replace("C.", "")


         Case "C.NombreZonaGeografica"
            entidad.Columna = "Z." + entidad.Columna.Replace("C.", "")

         Case "C.NombreLocalidadTrabajo"
            entidad.Columna = "L1.NombreLocalidad"

         Case "C.NombreGarante"
            entidad.Columna = "C1.NombreCliente"

         Case "C.NombreCategoria"
            entidad.Columna = "Ca." + entidad.Columna.Replace("C.", "")

         Case "C.NombreCategoriaFiscal"
            entidad.Columna = "Cf." + entidad.Columna.Replace("C.", "")

         Case "C.NombreVendedor"
            entidad.Columna = "E.NombreEmpleado"

      End Select

      With stbQuery
         .Length = 0
         .Append("SELECT ")
         .Append("           C.idLegajo")
         .Append("           ,C.NombrePersonal")
         .Append("           ,C.Domicilio")
         .Append("           ,C.IdLocalidad")
         .Append("           ,C.TipoDocPersonal")
         .Append("           ,C.NroDocPersonal")
         .Append("           ,C.idNacionalidad")
         .Append("           ,N.NombreNacionalidad")
         .Append("           ,C.Sexo")
         .Append("           ,C.IdEstadoCivil")
         .Append("           ,C.Cuil")
         .Append("           ,C.LegajoMinTrabajo")
         .Append("           ,C.idObraSocial")
         .Append("           ,C.CodObraSocial")
         .Append("           ,C.FechaNacimiento")
         .Append("           ,C.FechaIngreso")
         .Append("           ,C.FechaBaja")
         .Append("           ,C.idCategoria")
         .Append("           ,C.CentroCosto")
         .Append("           ,C.SueldoBasico")
         .Append("           ,C.MejorSueldo")
         .Append("           ,C.AcumuladoAnual")
         .Append("           ,C.AcumuladoSalarioFamiliar")
         .Append("           ,C.SueldoActual")
         .Append("           ,C.SalarioFamiliarActual")
         .Append("           ,C.AFJP")
         .Append("           ,C.AnteriorAcumuladoAnual")
         .Append("           ,C.AnteriorMejorSueldo")
         .Append("           ,C.AnteriorSalarioFamiliar")
         .Append("           ,C.IdMotivoBaja")
         .Append("            , A.NombreCategoria")
         .Append("            , E.NombreEstadoCivil")
         .Append("            , C.IdLugarActividad")
         .Append("            , C.DatosFamiliares")
         .Append("            , C.IdBancoCtaBancaria")
         .Append("            , C.IdCuentasBancariasClaseCtaBancaria")
         .Append("            , C.NumeroCuentaBancaria")
         .Append("            , C.CBU")

         .AppendLine("    FROM SueldosPersonal C")
         .AppendLine("    LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine("    LEFT JOIN SueldosEstadoCivil E ON E.idEstadoCivil = C.IdEstadoCivil ")
         .AppendLine("    LEFT JOIN SueldosCategorias A ON A.idCategoria = C.idCategoria")
         .AppendLine("    LEFT JOIN SueldosObraSocial O ON O.idObraSocial = C.idObraSocial")
         .AppendLine("    LEFT JOIN Nacionalidades N ON C.IdNacionalidad = N.IdNacionalidad")
         .AppendLine(" WHERE ")
         .Append(entidad.Columna)
         .Append(" LIKE '%")
         .Append(entidad.Valor.ToString())
         .Append("%'")

      End With

      Return Me.da.GetDataTable(stbQuery.ToString())

   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SueldosPersonal(Me.da).SueldosPersonal_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub SelectFiltrado(ByRef stb As StringBuilder)
      With stb
         .Length = 0

         .Append("SELECT C.idLegajo")
         .Append("           ,C.NombrePersonal")
         .Append("           ,C.Domicilio")
         .Append("           ,C.IdLocalidad")
         .Append("           ,C.TipoDocPersonal")
         .Append("           ,C.NroDocPersonal")
         .Append("           ,C.idNacionalidad")
         .Append("           ,N.NombreNacionalidad")
         .Append("           ,C.Sexo")
         .Append("           ,C.IdEstadoCivil")
         .Append("           ,C.Cuil")
         .Append("           ,C.LegajoMinTrabajo")
         .Append("           ,C.idObraSocial")
         .Append("           ,C.CodObraSocial")
         .Append("           ,C.FechaNacimiento")
         .Append("           ,C.FechaIngreso")
         .Append("           ,C.FechaBaja")
         .Append("           ,C.idCategoria")
         .Append("           ,C.CentroCosto")
         .Append("           ,C.SueldoBasico")
         .Append("           ,C.MejorSueldo")
         .Append("           ,C.AcumuladoAnual")
         .Append("           ,C.AcumuladoSalarioFamiliar")
         .Append("           ,C.SueldoActual")
         .Append("           ,C.SalarioFamiliarActual")
         .Append("           ,C.AFJP")
         .Append("           ,C.AnteriorAcumuladoAnual")
         .Append("           ,C.AnteriorMejorSueldo")
         .Append("           ,C.AnteriorSalarioFamiliar")
            .Append("           ,C.IdMotivoBaja")
            .Append("            , A.NombreCategoria")
         .Append("            , E.NombreEstadoCivil")
         .Append("            , C.IdLugarActividad")
         .Append("            , C.DatosFamiliares")
         .Append("            , C.IdBancoCtaBancaria")
         .Append("            , C.IdCuentasBancariasClaseCtaBancaria")
         .Append("            , C.NumeroCuentaBancaria")
         .Append("            , C.CBU")

         .AppendLine("    FROM SueldosPersonal C")
         .AppendLine("    LEFT JOIN Localidades L ON L.IdLocalidad = C.IdLocalidad ")
         .AppendLine("    LEFT JOIN SueldosEstadoCivil E ON E.idEstadoCivil = C.IdEstadoCivil ")
         .AppendLine("    LEFT JOIN SueldosCategorias A ON A.idCategoria = C.idCategoria")
         .AppendLine("    LEFT JOIN SueldosObraSocial O ON O.idObraSocial = C.idObraSocial")
         .AppendLine("    LEFT JOIN Nacionalidades N ON C.IdNacionalidad = N.IdNacionalidad")

      End With
   End Sub

   Public Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.SueldosPersonal = DirectCast(entidad, Entidades.SueldosPersonal)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Dim dt As DataTable = en.Familiares

         Dim sql As SqlServer.SueldosPersonal = New SqlServer.SueldosPersonal(da)
         Dim sqlAudit As Eniac.SqlServer.Auditorias = New Eniac.SqlServer.Auditorias(da)

         Select Case tipo
            Case TipoSP._I
               sql.SueldosPersonal_I(en.idLegajo, en.NombrePersonal, en.Domicilio, en.idLocalidad, _
                              en.TipoDocPersonal, en.NroDocPersonal, en.idNacionalidad, en.Sexo, en.IdEstadoCivil, _
                              en.Cuil, en.LegajoMinTrabajo, en.idObraSocial, en.CodObraSocial, _
                              en.FechaNacimiento, en.FechaIngreso, en.FechaBaja, en.idCategoria, _
                              en.CentroCosto, en.SueldoBasico, en.MejorSueldo, en.AcumuladoAnual, _
                              en.AcumuladoSalarioFamiliar, en.SueldoActual, en.SalarioFamiliarActual, en.AFJP, en.AnteriorAcumuladoAnual, _
                              en.AnteriorMejorSueldo, en.AnteriorSalarioFamiliar, en.MotivoBaja.IdMotivoBaja, _
                              en.LugarActividad.IdLugarActividad, en.DatosFamiliares, en.Banco.IdBanco, _
                              en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CBU)

               Dim sql2 As SqlServer.SueldosPersonalFamiliares = New SqlServer.SueldosPersonalFamiliares(da)


               For Each dr As DataRow In dt.GetChanges(DataRowState.Deleted).Rows
                  If dr.RowState = DataRowState.Deleted Then
                     sql2.SueldosPersonalFamiliares_D(Integer.Parse(dr("IdLegajo", DataRowVersion.Original).ToString()), _
                                                 Long.Parse(dr("CuilHijo", DataRowVersion.Original).ToString()))
                  End If
               Next
               For Each dr As DataRow In dt.Rows
                  If dr.RowState = DataRowState.Added Then
                     sql2.SueldosPersonalFamiliares_I(Integer.Parse(dr("IdLegajo", DataRowVersion.Current).ToString()), _
                                 Long.Parse(dr("CuilFamiliar", DataRowVersion.Current).ToString()), _
                                dr("NombreFamiliar", DataRowVersion.Current).ToString(), _
                                Date.Parse(dr("FechaNacimientoFamiliar", DataRowVersion.Current).ToString()), _
                                dr("IdTipoVinculoFamiliar", DataRowVersion.Current).ToString(), _
                                dr("SexoFamiliar", DataRowVersion.Current).ToString())
                  End If

               Next


               'sqlAudit.Auditorias_I("Clientes", SqlServer.Auditorias.Operaciones.Alta, en.Usuario, "TipoDocumento = '" & en.TipoDocumento & "' AND NroDocumento = '" & en.NroDocumento.Trim() & "'")

            Case TipoSP._U
               sql.SueldosPersonal_U(en.idLegajo, en.NombrePersonal, en.Domicilio, en.idLocalidad, _
                              en.TipoDocPersonal, en.NroDocPersonal, en.idNacionalidad, en.Sexo, en.IdEstadoCivil, _
                              en.Cuil, en.LegajoMinTrabajo, en.idObraSocial, en.CodObraSocial, _
                              en.FechaNacimiento, en.FechaIngreso, en.FechaBaja, en.idCategoria, _
                              en.CentroCosto, en.SueldoBasico, en.MejorSueldo, en.AcumuladoAnual, _
                              en.AcumuladoSalarioFamiliar, en.SueldoActual, en.SalarioFamiliarActual, en.AFJP, _
                              en.AnteriorAcumuladoAnual, _
                              en.AnteriorMejorSueldo, en.AnteriorSalarioFamiliar, en.MotivoBaja.IdMotivoBaja, _
                              en.LugarActividad.IdLugarActividad, en.DatosFamiliares, en.Banco.IdBanco, _
                              en.CuentaBancariaClase.IdCuentaBancariaClase, en.NumeroCuentaBancaria, en.CBU)

               Dim sql2 As SqlServer.SueldosPersonalFamiliares = New SqlServer.SueldosPersonalFamiliares(da)


               For Each dr As DataRow In dt.GetChanges(DataRowState.Deleted).Rows
                  If dr.RowState = DataRowState.Deleted Then
                     sql2.SueldosPersonalFamiliares_D(Integer.Parse(dr("IdLegajo", DataRowVersion.Original).ToString()), _
                                                 Long.Parse(dr("CuilHijo", DataRowVersion.Original).ToString()))
                  End If
               Next
               For Each dr As DataRow In dt.Rows
                  If dr.RowState = DataRowState.Added Then
                     sql2.SueldosPersonalFamiliares_I(Integer.Parse(dr("IdLegajo", DataRowVersion.Current).ToString()), _
                                 Long.Parse(dr("CuilFamiliar", DataRowVersion.Current).ToString()), _
                                dr("NombreFamiliar", DataRowVersion.Current).ToString(), _
                                Date.Parse(dr("FechaNacimientoFamiliar", DataRowVersion.Current).ToString()), _
                                dr("IdTipoVinculoFamiliar", DataRowVersion.Current).ToString(), _
                                dr("SexoFamiliar", DataRowVersion.Current).ToString())
                  End If

               Next


               'dtAudit = sqlAudit.Auditorias_G1("Clientes", "TipoDocumento = '" & en.TipoDocumento & "' AND NroDocumento = '" & en.NroDocumento.Trim() & "'")

               'Select Case True
               '    Case Not en.Activo And Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
               '        'Lo inactivo
               '        OperacAudit = SqlServer.Auditorias.Operaciones.Inactivar
               '    Case en.Activo And Not Boolean.Parse(dtAudit.Rows(0)("Activo").ToString())
               '        'Lo activo
               '        OperacAudit = SqlServer.Auditorias.Operaciones.Alta
               '    Case Else
               '        OperacAudit = SqlServer.Auditorias.Operaciones.Modificacion
               'End Select

               '      sqlAudit.Auditorias_I("Clientes", OperacAudit, en.Usuario, "TipoDocumento = '" & en.TipoDocumento & "' AND NroDocumento = '" & en.NroDocumento.Trim() & "'")

            Case TipoSP._D

               '            sqlAudit.Auditorias_I("Clientes", SqlServer.Auditorias.Operaciones.Baja, en.Usuario, "TipoDocumento = '" & en.TipoDocumento & "' AND NroDocumento = '" & en.NroDocumento.Trim() & "'")

               sql.SueldosPersonal_D(en.idLegajo)


         End Select

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetPersonalActivo() As DataTable
      Try
         Me.da.OpenConection()

         Return Me._GetPersonalActivo()

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetPersonalActivo() As DataTable
      Dim sql As SqlServer.SueldosPersonal = New SqlServer.SueldosPersonal(Me.da)
      Return sql.GetPersonalActivo()
   End Function

   Public Function _GetPersonalActivoPorLugarActividad(ByVal idLugarActividad As Integer) As DataTable
      Dim sql As SqlServer.SueldosPersonal = New SqlServer.SueldosPersonal(Me.da)
      Return sql.GetPersonalActivoPorLugarActividad(idLugarActividad)
   End Function

   Public Function GetPersonalActivoPorLugarActividad(ByVal idLugarActividad As Integer) As DataTable
      Try
         Me.da.OpenConection()

         Return Me._GetPersonalActivoPorLugarActividad(idLugarActividad)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetFiltradoPorLegajo(ByVal NroLegajo As Integer, Optional ByVal BusquedaParcial As Boolean = True, Optional ByVal OrdenLegajo As Boolean = False) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")
      Me.SelectFiltrado(stbQuery)
      With stbQuery
         If NroLegajo > 0 Then
            .AppendLine("   WHERE C.idLegajo = " & NroLegajo.ToString())
         End If
         If OrdenLegajo Then
            .AppendLine(" ORDER BY C.IdLegajo ")
         Else
            .AppendLine(" ORDER BY C.NombrePersonal ")
         End If

      End With
      Dim dt As DataTable = Me.da.GetDataTable(stbQuery.ToString())
      If dt.Rows.Count = 0 And BusquedaParcial Then
         stbQuery.Length = 0
         Me.SelectFiltrado(stbQuery)
         With stbQuery
            '.AppendLine(" WHERE C.Activo = 'True' ")
            .AppendLine("   WHERE idLegajo LIKE '%" & NroLegajo.ToString() & "%' ")
            If OrdenLegajo Then
               .AppendLine(" ORDER BY IdLegajo ")
            Else
               .AppendLine(" ORDER BY NombrePersonal ")
            End If

         End With
         dt = Me.da.GetDataTable(stbQuery.ToString())
      End If
      Return dt
   End Function

   Private Sub CargarUno(ByVal o As Entidades.SueldosPersonal, ByVal dr As DataRow)
      With o
         .TipoDocPersonal = dr(Entidades.SueldosPersonal.Columnas.TipoDocPersonal.ToString()).ToString()
         .NroDocPersonal = Long.Parse(dr(Entidades.SueldosPersonal.Columnas.NroDocPersonal.ToString()).ToString())
         .NombrePersonal = dr(Entidades.SueldosPersonal.Columnas.NombrePersonal.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr("FechaIngreso").ToString()) Then
            .FechaIngreso = DateTime.Parse(dr("FechaIngreso").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaBaja").ToString()) Then
            .FechaBaja = DateTime.Parse(dr("FechaBaja").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("FechaNacimiento").ToString()) Then
            .FechaNacimiento = DateTime.Parse(dr("FechaNacimiento").ToString())
         End If
         .Sexo = dr(Entidades.SueldosPersonal.Columnas.Sexo.ToString()).ToString()
         .AcumuladoAnual = Decimal.Parse(dr("AcumuladoAnual").ToString())
         .AcumuladoSalarioFamiliar = Decimal.Parse(dr("AcumuladoSalarioFamiliar").ToString())
         .AnteriorAcumuladoAnual = Decimal.Parse(dr("AnteriorAcumuladoAnual").ToString())
         .AnteriorMejorSueldo = Decimal.Parse(dr("AnteriorMejorSueldo").ToString())
         .AnteriorSalarioFamiliar = Decimal.Parse(dr("AnteriorSalarioFamiliar").ToString())
         .CentroCosto = Integer.Parse(dr("CentroCosto").ToString())
         .CodObraSocial = Integer.Parse(dr("CodObraSocial").ToString())
         .Cuil = Long.Parse(dr("Cuil").ToString())
         .Domicilio = dr("Domicilio").ToString()

         .idCategoria = Integer.Parse(dr("idCategoria").ToString())
         .IdEstadoCivil = Integer.Parse(dr("IdEstadoCivil").ToString())
         .idLegajo = Integer.Parse(dr("idLegajo").ToString())
         .idLocalidad = Integer.Parse(dr("idLocalidad").ToString())
         .idNacionalidad = Integer.Parse(dr("idNacionalidad").ToString())
         '.IdSucursal= Integer.Parse(dr("idCategoria").ToString())
         .idObraSocial = Int32.Parse(dr(Entidades.SueldosPersonal.Columnas.idObraSocial.ToString()).ToString())

         .LegajoMinTrabajo = Long.Parse(dr("LegajoMinTrabajo").ToString())
         .MejorSueldo = Decimal.Parse(dr("MejorSueldo").ToString())
         .SueldoBasico = Decimal.Parse(dr(Entidades.SueldosPersonal.Columnas.SueldoBasico.ToString()).ToString())
         .SueldoActual = Decimal.Parse(dr(Entidades.SueldosPersonal.Columnas.SueldoActual.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.SueldosPersonal.Columnas.IdMotivoBaja.ToString()).ToString()) Then
            .MotivoBaja = New Reglas.SueldosMotivosBaja(Me.da)._GetUno(Int32.Parse(dr(Entidades.SueldosPersonal.Columnas.IdMotivoBaja.ToString()).ToString()))
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.SueldosPersonal.Columnas.IdLugarActividad.ToString()).ToString()) Then
            .LugarActividad = New Reglas.SueldosLugaresActividad(Me.da)._GetUno(Int32.Parse(dr(Entidades.SueldosPersonal.Columnas.IdLugarActividad.ToString()).ToString()))
         End If
         .DatosFamiliares = dr(Entidades.SueldosPersonal.Columnas.DatosFamiliares.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.SueldosPersonal.Columnas.IdBancoCtaBancaria.ToString()).ToString()) Then
            .Banco = New Eniac.Reglas.Bancos(Me.da).GetUno(Int32.Parse(dr(Entidades.SueldosPersonal.Columnas.IdBancoCtaBancaria.ToString()).ToString()))
         End If
         If Not String.IsNullOrEmpty(dr(Entidades.SueldosPersonal.Columnas.IdCuentasBancariasClaseCtaBancaria.ToString()).ToString()) Then
            .CuentaBancariaClase = New Eniac.Reglas.CuentasBancariasClase(Me.da).GetUna(Int32.Parse(dr(Entidades.SueldosPersonal.Columnas.IdCuentasBancariasClaseCtaBancaria.ToString()).ToString()))
         End If
         .NumeroCuentaBancaria = dr(Entidades.SueldosPersonal.Columnas.NumeroCuentaBancaria.ToString()).ToString()
         If Not String.IsNullOrEmpty(dr(Entidades.SueldosPersonal.Columnas.CBU.ToString()).ToString()) Then
            .CBU = dr(Entidades.SueldosPersonal.Columnas.CBU.ToString()).ToString()
         End If
      End With
   End Sub

    Public Function GetUno(ByVal idLegajo As Integer, Optional ByVal tipoDocumento As String = "", Optional ByVal nroDocumento As String = "") As Entidades.SueldosPersonal
        Dim dt As DataTable = Me.GetFiltradoPorLegajo(idLegajo)
        Dim oPersonal As Entidades.SueldosPersonal = New Entidades.SueldosPersonal()
        If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(oPersonal, dr)
      End If
      Return oPersonal
   End Function

   Public Function GetTodosActivos() As List(Of Entidades.SueldosPersonal)
      Try
         Me.da.OpenConection()
         Return Me._GetTodosActivos()
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetTodosActivos() As List(Of Entidades.SueldosPersonal)
      Dim dt As DataTable = New SqlServer.SueldosPersonal(Me.da).GetPersonalActivo()
      Dim lis As List(Of Entidades.SueldosPersonal) = New List(Of Entidades.SueldosPersonal)()
      Dim o As Entidades.SueldosPersonal = New Entidades.SueldosPersonal()
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosPersonal()
         Me.CargarUno(o, dr)
         lis.Add(o)
      Next
      Return lis
   End Function

   Public Function GetTodosActivosPorConcepto(ByVal idTipoConcepto As Integer, ByVal idConcepto As Integer) As List(Of Entidades.SueldosPersonal)
      Try
         Me.da.OpenConection()
         Return Me._GetTodosActivosPorConcepto(idTipoConcepto, idConcepto)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetTodosActivosPorConcepto(ByVal idTipoConcepto As Integer, ByVal idConcepto As Integer) As List(Of Entidades.SueldosPersonal)
      Dim dt As DataTable = New SqlServer.SueldosPersonal(Me.da).GetPersonalActivoPorConcepto(idTipoConcepto, idConcepto)
      Dim lis As List(Of Entidades.SueldosPersonal) = New List(Of Entidades.SueldosPersonal)()
      Dim o As Entidades.SueldosPersonal = New Entidades.SueldosPersonal()
      For Each dr As DataRow In dt.Rows
         o = New Entidades.SueldosPersonal()
         Me.CargarUno(o, dr)
         lis.Add(o)
      Next
      Return lis
   End Function


   Public Function GetFiltradoPorNombre(ByVal nombre As String) As DataTable

      Dim stbQuery As StringBuilder = New StringBuilder("")

      Me.SelectFiltrado(stbQuery)

      With stbQuery
         .AppendLine("   WHERE NombrePersonal LIKE '%" & nombre & "%' ")
         .AppendFormat(" AND FechaBaja IS null ")
         .AppendLine(" ORDER BY NombrePersonal ")
      End With

      Dim dt As DataTable = Me.DataServer().GetDataTable(stbQuery.ToString())

      Return dt

   End Function

   Public Function GetGaranteFiltradoPorTipoYNroDocumento(ByVal tipoDocumento As String, ByVal nroDocumento As String) As DataTable
      Dim stbQuery As StringBuilder = New StringBuilder("")

      With stbQuery
         .Length = 0
         .AppendLine(" SELECT A.TipoDocumento, A.NroDocumento, A.NombreCliente, A.Direccion")
         .AppendLine("   FROM CLIENTES A, ")
         .AppendLine(" (SELECT C.TipoDocumentoGarante, C.NroDocumentoGarante ")
         .AppendLine("   FROM Clientes C ")
         .AppendLine(" WHERE C.Activo = 'True' ")
         .AppendFormat("    AND C.TipoDocumento = '{0}'", tipoDocumento)
         .AppendFormat("    AND C.NroDocumento = '{0}') B", nroDocumento)
         .AppendLine("   WHERE A.TipoDocumento = B.TipoDocumentoGarante")
         .AppendLine("     AND A.NroDocumento = B.NroDocumentoGarante ")
      End With

      Return Me.da.GetDataTable(stbQuery.ToString())
   End Function

   Public Function GetCodigoMaximo() As Long

      Dim sql As SqlServer.SueldosPersonal = New SqlServer.SueldosPersonal(da)
      Dim Nro As Long

      Nro = sql.GetCodigoMaximo

      sql = Nothing

      Return Nro

   End Function

#End Region

End Class

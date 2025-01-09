
Option Explicit On
Option Strict On

Imports System.Text
Public Class ContabilidadCuentas
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "ContabilidadCuentas"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ContabilidadCuentas"
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As System.Data.DataTable
      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.ContabilidadCuentas(Me.da).Cuentas_GA()
   End Function

   Public Function GetAll_PorCodigo() As System.Data.DataTable
      Return New SqlServer.ContabilidadCuentas(Me.da).Cuentas_GA_PorCodigo()
   End Function

#End Region


#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)

      Dim en As Entidades.ContabilidadCuenta = DirectCast(entidad, Entidades.ContabilidadCuenta)

      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Dim sqlPC As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(da)

         Select Case tipo

            Case TipoSP._I
               sql.Cuentas_I(en.IdCuenta,
                             en.NombreCuenta,
                             en.Nivel,
                             en.EsImputable,
                             en.Activa,
                             en.IdCuentaPadre,
                             en.AjustaPorInflacion,
                             en.TipoCuenta)


            Case TipoSP._U
               sql.Cuentas_U(en.IdCuenta,
                             en.NombreCuenta,
                             en.Nivel,
                             en.EsImputable,
                             en.Activa,
                             en.IdCuentaPadre,
                             en.AjustaPorInflacion,
                             en.TipoCuenta)

            Case TipoSP._D
               sqlPC.PlanCuenta_D(Nothing, en.IdCuenta)
               sql.Cuentas_D(en.IdCuenta)

         End Select

         'USO EL MERGE EN LUGAR DEL INSERT YA QUE SI NO ESTÁ LO INSERTA Y SI ESTÁ LO IGNORA
         sqlPC.PlanCuenta_M(Nothing, en.IdCuenta)

         Me.da.CommitTransaction()

      Catch
         Me.da.RollbakTransaction()
         Throw
      Finally
         Me.da.CloseConection()
      End Try

   End Sub

   Private Sub CargarUna(ByVal o As Entidades.ContabilidadCuenta, ByVal dr As DataRow)
      With o
         .IdCuenta = Long.Parse(dr(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).ToString())
         .NombreCuenta = dr(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).ToString()
         .EsImputable = Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString()).ToString())
         .Activa = Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Activa.ToString()).ToString())
         .Nivel = Integer.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).ToString()) AndAlso
             Long.Parse(dr(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).ToString()) <> .IdCuenta Then
            .Padre = New Reglas.ContabilidadCuentas(Me.da)._GetUna(Long.Parse(dr(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).ToString()))
         End If
         .AjustaPorInflacion = Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()).ToString()) Then
            .TipoCuenta = DirectCast([Enum].Parse(GetType(Entidades.ContabilidadCuenta.TipoCuentaContable), dr(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()).ToString()), Entidades.ContabilidadCuenta.TipoCuentaContable)
         End If
      End With
   End Sub

   Private Sub CargarUnaSoloUnPadre(ByVal o As Entidades.ContabilidadCuenta, ByVal dr As DataRow, ByVal traePadre As Boolean)
      With o
         .IdCuenta = Long.Parse(dr(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).ToString())
         .NombreCuenta = dr(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).ToString()
         .EsImputable = Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString()).ToString())
         .Activa = Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Activa.ToString()).ToString())
         .Nivel = Integer.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()).ToString())
         If Not String.IsNullOrEmpty(dr(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).ToString()) And traePadre Then
            .Padre = Me._GetUnaPadre(Long.Parse(dr(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).ToString()))
         End If
         .AjustaPorInflacion = Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString()).ToString())
         If Not String.IsNullOrWhiteSpace(dr(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()).ToString()) Then
            .TipoCuenta = DirectCast([Enum].Parse(GetType(Entidades.ContabilidadCuenta.TipoCuentaContable), dr(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()).ToString()), Entidades.ContabilidadCuenta.TipoCuentaContable)
         End If
      End With
   End Sub


#End Region



#Region "Metodos Publicos"

   Public Function GetTodos() As List(Of Entidades.ContabilidadCuenta)
      Dim dt As DataTable = Me.GetAll()
      Dim o As Entidades.ContabilidadCuenta
      Dim oLis As List(Of Entidades.ContabilidadCuenta) = New List(Of Entidades.ContabilidadCuenta)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.ContabilidadCuenta()
         Me.CargarUnaSoloUnPadre(o, dr, True)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetUna(ByVal IdCuenta As Long) As Entidades.ContabilidadCuenta
      Try
         Me.da.OpenConection()
         Return Me._GetUna(IdCuenta)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function _GetUna(idCuenta As Long) As Entidades.ContabilidadCuenta
      Return _GetUna(idCuenta, AccionesSiNoExisteRegistro.Excepcion)
   End Function
   Public Function _GetUna(idCuenta As Long, accion As AccionesSiNoExisteRegistro) As Entidades.ContabilidadCuenta
      Return CargaEntidad(New SqlServer.ContabilidadCuentas(da).Cuentas_G1(idCuenta),
                          Sub(o, dr) CargarUna(o, dr), Function() New Entidades.ContabilidadCuenta(),
                          accion, String.Format("No existe la Cuenta {0}", idCuenta))
   End Function

   Friend Function _GetUnaPadre(ByVal IdCuenta As Long) As Entidades.ContabilidadCuenta
      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
      Dim dt As DataTable = sql.Cuentas_G1(IdCuenta)
      Dim o As Entidades.ContabilidadCuenta = New Entidades.ContabilidadCuenta()
      If dt.Rows.Count > 0 Then
         Me.CargarUnaSoloUnPadre(o, dt.Rows(0), False)
      Else
         Throw New Exception("No existe la Cuenta.")
      End If
      Return o
   End Function

   Public Function Get1(ByVal IdCuenta As Long) As DataTable
      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
      Return sql.Cuentas_G1(IdCuenta)
   End Function

   Public Function GetPorCodigo(ByVal IdCuenta As Long) As DataTable
      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
      Return sql.GetPorCodigoNombre(IdCuenta, String.Empty)
   End Function

   Public Function GetPorNombre(ByVal dscCuenta As String) As DataTable
      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
      Return sql.GetPorCodigoNombre(0, dscCuenta)
   End Function

   Public Function GetIdMaximo(nivel As Integer) As Integer

      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
      Dim dt As DataTable = sql.Cuenta_GetIdMaximo(nivel)
      Dim val As Integer = 0

      If dt.Rows.Count > 0 Then
         If Not String.IsNullOrEmpty(dt.Rows(0)("maximo").ToString()) Then
            val = Integer.Parse(dt.Rows(0)("maximo").ToString())
         End If
      End If

      Return val

   End Function

   ' para las de nivel 3
   Public Function TieneHijosLaCuenta(ByVal IdCuenta As Long) As Boolean
      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)

      Return sql.TieneHijosLaCuenta(IdCuenta)

   End Function
   ' para las de nivel 4
   Public Function TieneAsientosLaCuenta(ByVal IdCuenta As Long) As Boolean
      Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)

      Return sql.TieneAsientosLaCuenta(IdCuenta)

   End Function

   Public Function GetCuentasImputables() As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Return sql.GetCuentasImputables()

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCuentasImputablesXCodigo(idCuenta As Long) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Return sql.GetCuentasImputablesXCodigo(idCuenta)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCuentasImputablesXNombre(nombreCuenta As String) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Return sql.GetCuentasImputablesXNombre(nombreCuenta)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCuentasImputablesXTipo(tipoCuenta As Entidades.ContabilidadCuenta.TipoCuentaContable, nombreCuenta As String) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Return sql.GetCuentasImputablesXTipo(tipoCuenta, nombreCuenta)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCuentasImputablesXTipo(tipoCuenta As Entidades.ContabilidadCuenta.TipoCuentaContable, idCuenta As Long) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Return sql.GetCuentasImputablesXTipo(tipoCuenta, idCuenta)

      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCuentasXNivel(ByVal nivel As Integer) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Return sql.GetCuentasXNivel(nivel)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Function GetCuentasXNivelDescripcion(ByVal nivel As Integer, nombreCuenta As String) As DataTable
      Try
         Me.da.OpenConection()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Return sql.GetCuentasXNivelDescripcion(nivel, nombreCuenta)
      Catch ex As Exception
         Throw
      Finally
         Me.da.CloseConection()
      End Try
   End Function

   Public Sub GuardarCuentaNivel(idCuenta As Long,
                                 dscCuenta As String,
                                 nivel As Integer,
                                 activa As Boolean,
                                 esImputable As Boolean,
                                 idCuentaPadre As Long,
                                 ajustaPorInflacion As Boolean,
                                 tipoCuenta As Entidades.ContabilidadCuenta.TipoCuentaContable)
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()
         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         sql.Cuentas_I(idCuenta,
                       dscCuenta,
                       nivel,
                       esImputable,
                       activa,
                       idCuentaPadre,
                       ajustaPorInflacion,
                       tipoCuenta)
         Me.da.CommitTransaction()
      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub ImportarCuentas(dtDatos As DataTable, eliminaCuentasAnteriores As Boolean, idPlanCuenta As Integer)

      Dim linea As Integer
      Try
         Me.da.OpenConection()
         Me.da.BeginTransaction()

         Dim sql As SqlServer.ContabilidadCuentas = New SqlServer.ContabilidadCuentas(Me.da)
         Dim sqlP As SqlServer.ContabilidadPlan = New SqlServer.ContabilidadPlan(Me.da)
         Dim sqlPC As SqlServer.ContabilidadPlanesCuentas = New SqlServer.ContabilidadPlanesCuentas(Me.da)

         Dim dtPlan As DataTable = sqlP.Planes_GA(False)
         Dim drPlanCol As DataRow()

         drPlanCol = dtPlan.Select()
         'If eliminaCuentasAnteriores Then
         '   drPlanCol = dtPlan.Select()
         'Else
         '   drPlanCol = dtPlan.Select(String.Format("{0} = {1}", Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString(), idPlanCuenta))
         'End If

         If eliminaCuentasAnteriores Then
            For Each dr As DataRow In drPlanCol
               sqlPC.PlanCuenta_D(CInt(dr(Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString())))
            Next

            sql.Cuentas_D()
         End If

         linea = 0

         For Each dr As DataRow In dtDatos.Rows
            If Boolean.Parse(dr("Importa").ToString()) Then
               Dim tipo As Entidades.ContabilidadCuenta.TipoCuentaContable = Entidades.ContabilidadCuenta.TipoCuentaContable.NULL

               ' Si el valor de Tipo de Cuenta es SIN DEFINIR, le asigno el valor del Enum de TipoCuentaContable > NULL
               If dr(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()).ToString() = "SIN DEFINIR" Then
                  dr(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()) = Entidades.ContabilidadCuenta.TipoCuentaContable.NULL
               End If

               tipo = DirectCast([Enum].Parse(GetType(Entidades.ContabilidadCuenta.TipoCuentaContable), dr(Entidades.ContabilidadCuenta.Columnas.TipoCuenta.ToString()).ToString()), Entidades.ContabilidadCuenta.TipoCuentaContable)

               If dr("Accion").ToString() = "A" Then
                  sql.Cuentas_I(Long.Parse(dr(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).ToString()),
                                dr(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).ToString(),
                                Integer.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()).ToString()),
                                Boolean.Parse(IIf(dr(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString()).ToString() = "SI", True, False).ToString()),
                                Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Activa.ToString()).ToString()),
                                Long.Parse("0" & dr(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).ToString()),
                                Boolean.Parse(IIf(dr(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString()).ToString() = "SI", True, False).ToString()),
                                tipo)
               Else
                  sql.Cuentas_U(Long.Parse(dr(Entidades.ContabilidadCuenta.Columnas.IdCuenta.ToString()).ToString()),
                                dr(Entidades.ContabilidadCuenta.Columnas.NombreCuenta.ToString()).ToString(),
                                Integer.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Nivel.ToString()).ToString()),
                                Boolean.Parse(IIf(dr(Entidades.ContabilidadCuenta.Columnas.EsImputable.ToString()).ToString() = "SI", True, False).ToString()),
                                Boolean.Parse(dr(Entidades.ContabilidadCuenta.Columnas.Activa.ToString()).ToString()),
                                Long.Parse("0" & dr(Entidades.ContabilidadCuenta.Columnas.IdCuentaPadre.ToString()).ToString()),
                                Boolean.Parse(IIf(dr(Entidades.ContabilidadCuenta.Columnas.AjustaPorInflacion.ToString()).ToString() = "SI", True, False).ToString()),
                                tipo)
               End If
            End If
            linea += 1
         Next
         'inserto las cuentas contables para todos los planes
         drPlanCol = dtPlan.Select(String.Format("{0} = {1}", Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString(), idPlanCuenta))
         For Each dr As DataRow In drPlanCol
            sqlPC.PlanCuenta_I(CInt(dr(Entidades.ContabilidadPlan.Columnas.IdPlanCuenta.ToString())), dtDatos)
         Next

         Me.da.CommitTransaction()

      Catch ex As Exception
         Me.da.RollbakTransaction()
         Throw New Exception(String.Format("Error al importar en la linea {0}", linea.ToString()), ex)

      Finally
         Me.da.CloseConection()
      End Try
   End Sub

   Public Function GetArbol(idCuenta As Long) As DataTable
      Dim stb As StringBuilder = New StringBuilder()

      With stb
         .AppendFormat("WITH tree (IdCuenta, IdCuentaPadre, level, NombreCuenta, rn) as ").AppendLine()
         .AppendFormat("(").AppendLine()
         .AppendFormat("   SELECT IdCuenta, IdCuentaPadre, 0 as level, NombreCuenta,").AppendLine()
         .AppendFormat("       convert(varchar(max),right(row_number() over (order by IdCuenta),10)) rn").AppendLine()
         .AppendFormat("   FROM ContabilidadCuentas").AppendLine()
         If idCuenta > 0 Then
            .AppendFormat("   WHERE IdCuenta = {0}", idCuenta).AppendLine()
         Else
            .AppendFormat("   WHERE IdCuenta IN (SELECT IdCuenta FROM ContabilidadCuentas WHERE IdCuentaPadre IS NULL)").AppendLine()
         End If
         .AppendFormat("   UNION ALL").AppendLine()
         .AppendFormat("   SELECT c2.IdCuenta, c2.IdCuentaPadre, tree.level + 1, c2.NombreCuenta,").AppendLine()
         .AppendFormat("       rn + '/' + convert(varchar(max),right(row_number() over (order by tree.IdCuenta),10))").AppendLine()
         .AppendFormat("   FROM ContabilidadCuentas c2 ").AppendLine()
         .AppendFormat("     INNER JOIN tree ON tree.IdCuenta = c2.IdCuentaPadre").AppendLine()
         .AppendFormat(")").AppendLine()
         .AppendFormat("SELECT * FROM tree ORDER BY RN").AppendLine()

         Return da.GetDataTable(stb.ToString())
      End With
   End Function

   Public Function GetAll_Ids() As DataTable
      Return New SqlServer.ContabilidadCuentas(da).Cuentas_GA_Ids()
   End Function

#End Region


End Class

Public Class Feriados
   Inherits Base

#Region "Constructores"
   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub
   Public Sub New(accesoDatos As Datos.DataAccess)
      MyBase.New("Feriados", accesoDatos)
   End Sub
#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Feriado), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Feriado), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() EjecutaSP(DirectCast(entidad, Entidades.Feriado), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Entidades.Buscar) As DataTable
      Return New SqlServer.Feriados(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return New SqlServer.Feriados(da).Feriados_GA()
   End Function
#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.Feriado, tipo As TipoSP)
      Dim sqlC = New SqlServer.Feriados(da)
      Select Case tipo
         Case TipoSP._I
            sqlC.Feriados_I(en.FechaFeriado, en.NombreFeriado)
         Case TipoSP._U
            sqlC.Feriados_U(en.FechaFeriado, en.NombreFeriado)
         Case TipoSP._D
            sqlC.Feriados_D(en.FechaFeriado)
      End Select
   End Sub

   Private Sub CargarUno(o As Entidades.Feriado, dr As DataRow)
      With o
         .FechaFeriado = Date.Parse(dr(Entidades.Feriado.Columnas.FechaFeriado.ToString()).ToString())
         .NombreFeriado = dr(Entidades.Feriado.Columnas.NombreFeriado.ToString()).ToString()
      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(fechaFeriado As Date) As Entidades.Feriado
      Return GetUno(fechaFeriado, AccionesSiNoExisteRegistro.Vacio)
   End Function
   Public Function GetUno(fechaFeriado As Date, accion As AccionesSiNoExisteRegistro) As Entidades.Feriado
      Return CargaEntidad(New SqlServer.Feriados(da).Feriados_G1(fechaFeriado),
                          Sub(o, dr) Me.CargarUno(o, dr), Function() New Entidades.Feriado(),
                          accion, Function() String.Format("No existe feriado con la fecha {0:dd/MM/yyyy}", fechaFeriado))
   End Function
   Public Function GetTodos() As List(Of Entidades.Feriado)
      Return CargaLista(New SqlServer.Feriados(da).Feriados_GA(),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Feriado())
   End Function
   Public Function GetTodos(fechaFeriadoDesde As Date?, fechaFeriadoHasta As Date?) As List(Of Entidades.Feriado)
      Return CargaLista(New SqlServer.Feriados(da).Feriados_GA(fechaFeriadoDesde, fechaFeriadoHasta),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.Feriado())
   End Function

   Public Sub CopiarFeriados(anoDesde As Integer, anoHasta As Integer)
      EjecutaConTransaccion(
      Sub()
         Dim sql = New SqlServer.Feriados(da)
         sql.Feriados_Copiar(anoDesde, anoHasta)
      End Sub)
   End Sub

   Public Function GetDiasHabilesAFecha(fechaHasta As Date) As Entidades.DiasHabiles
      Return GetDiasHabiles(fechaHasta.PrimerDiaMes(), fechaHasta)
   End Function
   Public Function GetDiasHabiles(periodo As Integer) As Entidades.DiasHabiles
      Dim fecha = periodo.FromPeriodo()
      Return GetDiasHabiles(fecha, fecha.UltimoDiaMes())
   End Function
   Public Function GetDiasHabiles(fechaDesde As Date, fechaHasta As Date) As Entidades.DiasHabiles
      Return GetDiasHabiles(New SqlServer.Feriados(da).GetDiasHabiles(fechaDesde, fechaHasta))
   End Function
   Public Function GetDiasHabiles(dt As DataTable) As Entidades.DiasHabiles
      Dim result = New Entidades.DiasHabiles()
      If dt.Rows.Count > 0 Then
         Dim dr = dt.Rows(0)
         With result
            .Lunes = dr.Field(Of Integer)("Lun")
            .Martes = dr.Field(Of Integer)("Mar")
            .Miercoles = dr.Field(Of Integer)("Mie")
            .Jueves = dr.Field(Of Integer)("Jue")
            .Viernes = dr.Field(Of Integer)("Vie")
            .Sabados = dr.Field(Of Integer)("Sab")
            .Domingos = dr.Field(Of Integer)("Dom")
            .Feriados = dr.Field(Of Integer)("Fer")
         End With
      End If
      Return result
   End Function

   Public Function BuscaSiguienteDiaHabil(fecha As Date, fp As Entidades.VentaFormaPago) As Date
      Return BuscaSiguienteDiaHabil(fecha, fp.ExcluyeSabados, fp.ExcluyeDomingos, fp.ExcluyeFeriados)
   End Function
   Public Function BuscaSiguienteDiaHabil(fecha As Date?, interes As Entidades.Interes) As Date?
      If fecha.HasValue Then
         Return BuscaSiguienteDiaHabil(fecha.Value, interes.VencimientoExcluyeSabado, interes.VencimientoExcluyeDomingo, interes.VencimientoExcluyeFeriados)
      Else
         Return fecha
      End If
   End Function
   Public Function BuscaSiguienteDiaHabil(fecha As Date, interes As Entidades.Interes) As Date
      Return BuscaSiguienteDiaHabil(fecha, interes.VencimientoExcluyeSabado, interes.VencimientoExcluyeDomingo, interes.VencimientoExcluyeFeriados)
   End Function
   Public Function BuscaSiguienteDiaHabil(fecha As Date, excluyeSabados As Boolean, excluyeDomingos As Boolean, excluyeFeriados As Boolean) As Date
      'Solo entro a procesar si y solo si al menos uno de los excluye es true, esto para evitar procesamiento y cachear feriados sin sentido
      If excluyeSabados OrElse excluyeDomingos OrElse excluyeFeriados Then
         Return BuscaSiguienteDiaHabil(fecha, excluyeSabados, excluyeDomingos, excluyeFeriados, New BusquedasCacheadas())
      End If
   End Function
   Public Function BuscaSiguienteDiaHabil(fecha As Date, excluyeSabados As Boolean, excluyeDomingos As Boolean, excluyeFeriados As Boolean, cache As BusquedasCacheadas) As Date
      'Solo entro a procesar si y solo si al menos uno de los excluye es true, esto para evitar procesamiento y cachear feriados sin sentido
      If excluyeSabados OrElse excluyeDomingos OrElse excluyeFeriados Then
         While Not EsDiaValido(fecha, excluyeSabados, excluyeDomingos, excluyeFeriados, cache)
            fecha = fecha.AddDays(1)
         End While
      End If
      Return fecha
   End Function
   Private Function EsDiaValido(dia As Date, excluyeSabados As Boolean, excluyeDomingos As Boolean, excluyeFeriados As Boolean, cache As BusquedasCacheadas) As Boolean
      If dia.DayOfWeek = DayOfWeek.Saturday And excluyeSabados Then
         'Si el día es Sábado y Excluye Sábados es un día INVALIDO
         Return False
      ElseIf dia.DayOfWeek = DayOfWeek.Sunday And excluyeDomingos Then
         'Si el día es Domingo y Excluye Domingos es un día INVALIDO
         Return False
      ElseIf excluyeFeriados AndAlso cache.EsFeriado(dia) Then
         'Si Excluye Feriados y el día es un Feriado es un día INVALIDO
         Return False
      Else
         Return True
      End If
   End Function

#End Region

End Class
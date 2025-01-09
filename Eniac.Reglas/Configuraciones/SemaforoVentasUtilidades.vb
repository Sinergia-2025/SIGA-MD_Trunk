Public Class SemaforoVentasUtilidades
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Public Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "SemaforoVentasUtilidades"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SemaforoVentaUtilidad), TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SemaforoVentaUtilidad), TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.SemaforoVentaUtilidad), TipoSP._D))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Return New SqlServer.SemaforoVentasUtilidades(da).Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.SemaforoVentasUtilidades(Me.da).SemaforoVentasUtilidades_GA()
   End Function

#End Region

#Region "Metodos"

   Public Function GetUno(id As Integer) As Eniac.Entidades.SemaforoVentaUtilidad
      Return CargaEntidad(New SqlServer.SemaforoVentasUtilidades(da).SemaforoVentasUtilidades_G1(id),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.SemaforoVentaUtilidad(),
                          AccionesSiNoExisteRegistro.Excepcion, Function() String.Format("No se encontró un semáforo con ID: {0}", id.ToString()))
   End Function

   Public Function GetTodos(tipo As Entidades.SemaforoVentaUtilidad.TiposSemaforos) As List(Of Entidades.SemaforoVentaUtilidad)
      Return CargaLista(New SqlServer.SemaforoVentasUtilidades(da).SemaforoVentasUtilidades_GA(tipo),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.SemaforoVentaUtilidad())
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.SemaforoVentasUtilidades(da).GetCodigoMaximo()
   End Function

   Public Function ColorSemaforo(Porcentaje As Decimal,
                                 idTipoSemaforo As Entidades.SemaforoVentaUtilidad.TiposSemaforos) As Entidades.SemaforoVentaUtilidad
      Return CargaEntidad(New SqlServer.SemaforoVentasUtilidades(da).SemaforoVentasUtilidades_ColorSemaforo(Porcentaje, idTipoSemaforo),
                    Sub(o, dr) CargarUno(o, dr), Function() New Entidades.SemaforoVentaUtilidad(),
                    AccionesSiNoExisteRegistro.Nulo, Function() String.Format("No se encontró un semáforo configurado para el porcentaje: {0}", Porcentaje.ToString()))
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub CargarUno(eSemaforoVentaUtilidad As Entidades.SemaforoVentaUtilidad, dr As DataRow)
      With eSemaforoVentaUtilidad
         .IdSemaforo = dr.Field(Of Integer)(Entidades.SemaforoVentaUtilidad.Columnas.IdSemaforo.ToString())
         .IdTipoSemaforoVentaUtilidad = DirectCast([Enum].Parse(GetType(Entidades.SemaforoVentaUtilidad.TiposSemaforos), dr(Entidades.SemaforoVentaUtilidad.Columnas.IdTipoSemaforoVentaUtilidad.ToString()).ToString()), Entidades.SemaforoVentaUtilidad.TiposSemaforos)
         .NombreColor = dr.Field(Of String)(Entidades.SemaforoVentaUtilidad.Columnas.NombreColor.ToString())
         .ColorSemaforo = dr.Field(Of Integer)(Entidades.SemaforoVentaUtilidad.Columnas.ColorSemaforo.ToString())
         .ColorLetra = dr.Field(Of Integer)(Entidades.SemaforoVentaUtilidad.Columnas.ColorLetra.ToString())
         .Negrita = dr.Field(Of Boolean)(Entidades.SemaforoVentaUtilidad.Columnas.Negrita.ToString())
         .PorcentajeHasta = dr.Field(Of Decimal)(Entidades.SemaforoVentaUtilidad.Columnas.PorcentajeHasta.ToString())
      End With
   End Sub

   Private Sub EjecutaSP(en As Entidades.SemaforoVentaUtilidad, tipo As TipoSP)
      Dim sql = New SqlServer.SemaforoVentasUtilidades(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.SemaforoVentasUtilidades_I(en.IdSemaforo, en.PorcentajeHasta, en.ColorSemaforo, en.ColorLetra, en.NombreColor, en.IdTipoSemaforoVentaUtilidad, en.Negrita)

         Case TipoSP._U
            sql.SemaforoVentasUtilidades_U(en.IdSemaforo, en.PorcentajeHasta, en.ColorSemaforo, en.ColorLetra, en.NombreColor, en.IdTipoSemaforoVentaUtilidad, en.Negrita)

         Case TipoSP._D
            sql.SemaforoVentasUtilidades_D(en.IdSemaforo)

      End Select
   End Sub

#End Region

End Class
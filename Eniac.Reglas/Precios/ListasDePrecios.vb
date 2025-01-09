Public Class ListasDePrecios
   Inherits Base

#Region "Constructores"

   Public Sub New()
      Me.New(New Datos.DataAccess())
   End Sub

   Friend Sub New(accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "ListasDePrecios"
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(entidad As Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ListaDePrecios), TipoSP._I))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ListaDePrecios), TipoSP._D))
      'Try
      '   da.OpenConection()
      '   da.BeginTransaction()

      '   Me.EjecutaSP(DirectCast(entidad, Entidades.ListaDePrecios), TipoSP._D)

      '   da.CommitTransaction()

      'Catch ex As Exception
      '   da.RollbakTransaction()
      '   Dim men As String
      '   Dim peda As String
      '   Dim comi As Integer
      '   If ex.InnerException IsNot Nothing Then
      '      men = "No se puede borrar porque esta siendo utilizado en "
      '      If ex.InnerException.Message.Contains("FK_") Then
      '         comi = ex.InnerException.Message.IndexOf("dbo.") + 4
      '         peda = ex.InnerException.Message.Substring(comi, ex.InnerException.Message.Length - comi)
      '         peda = peda.Substring(0, peda.IndexOf(",") - 1)
      '         men += peda
      '      End If
      '   Else
      '      men = ex.Message
      '   End If

      '   Throw New Exception(men, ex)
      'Finally
      '   da.CloseConection()
      'End Try
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(DirectCast(entidad, Entidades.ListaDePrecios), TipoSP._U))
   End Sub

   Public Overrides Function Buscar(entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.ListasDePrecios = New SqlServer.ListasDePrecios(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overloads Function GetAll(activa As Boolean?, OrderBy As Entidades.ListaDePrecios.Columnas) As System.Data.DataTable
      Return New SqlServer.ListasDePrecios(Me.da).ListasDePrecios_GA(activa, OrderBy)
   End Function

   Public Function GetClientesAsociados(idLista As Integer) As System.Data.DataTable
      Return New SqlServer.ListasDePrecios(Me.da).GetClientesAsociados(idLista)
   End Function

   Public Function GetProspectosAsociados(idLista As Integer) As System.Data.DataTable
      Return New SqlServer.ListasDePrecios(Me.da).GetProspectosAsociados(idLista)
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return GetAll(Nothing, Entidades.ListaDePrecios.Columnas.NombreListaPrecios)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(en As Entidades.ListaDePrecios, tipo As TipoSP)

      'Dim en As Entidades.ListaDePrecios = DirectCast(entidad, Entidades.ListaDePrecios)

      Dim sql = New SqlServer.ListasDePrecios(Me.da)

      Select Case tipo
         Case TipoSP._I
            sql.ListasDePrecios_I(en.IdListaPrecios, en.NombreListaPrecios, en.FechaVigencia,
                                 en.Usuario, en.IdListaPreciosCopiar, en.DescuentoRecargoPorc,
                                 en.Orden, en.Activa, en.NombreCortoListaPrecios, en.IdFormasPago,
                                 en.PublicarEnWeb, en.PermiteUtilidadEnCero)

         Case TipoSP._U
            sql.ListasDePrecios_U(en.IdListaPrecios, en.NombreListaPrecios, en.FechaVigencia,
                                  en.DescuentoRecargoPorc, en.Orden, en.Activa, en.NombreCortoListaPrecios,
                                  en.IdFormasPago, en.PublicarEnWeb, en.PermiteUtilidadEnCero)

         Case TipoSP._D

            'si es la lista de precios predeterminada no la puedo eliminar
            If en.IdListaPrecios = Integer.Parse(New Reglas.Parametros(Me.da).GetValorPD(Entidades.Parametro.Parametros.LISTAPRECIOSPREDETERMINADA, "0")) Then
               Throw New Exception("No se puede eliminar la lista de precios predeterminada.")
            End If

            Dim dt As DataTable
            'tengo que avisar que no se puede eliminar la lista ya que hay varios clientes que la tienen asociada
            dt = Me.GetClientesAsociados(en.IdListaPrecios)

            If dt.Rows.Count > 0 Then
               Throw New Exception(String.Format("La lista de precios tiene {0} clientes asociados, para eliminarla tiene que asociar estos clientes a otra lista de precios.", dt.Rows.Count))
            End If

            'tengo que avisar que no se puede eliminar la lista ya que hay varios prospectos que la tienen asociada
            dt = Me.GetProspectosAsociados(en.IdListaPrecios)

            If dt.Rows.Count > 0 Then
               Throw New Exception(String.Format("La lista de precios tiene {0} prospectos asociados, para eliminarla tiene que asociar estos prospectos a otra lista de precios.", dt.Rows.Count))
            End If

            'Borro el Historial que se Genero, cada corrida Genera muchos registros
            Dim sql2 As SqlServer.HistorialPrecios = New SqlServer.HistorialPrecios(Me.da)
            sql2.HistorialPrecios_DPorLista(en.IdListaPrecios)

            sql.ListasDePrecios_D(en.IdListaPrecios)

      End Select

   End Sub

   Public Sub Inserta(entidad As Entidades.Entidad)
      Dim en = DirectCast(entidad, Entidades.ListaDePrecios)
      Dim sql = New SqlServer.ListasDePrecios(Me.da)
      sql.ListasDePrecios_I(en.IdListaPrecios, en.NombreListaPrecios, en.FechaVigencia, en.Usuario,
                            en.IdListaPreciosCopiar, en.DescuentoRecargoPorc, en.Orden, en.Activa,
                            en.NombreCortoListaPrecios, en.IdFormasPago, en.PublicarEnWeb, en.PermiteUtilidadEnCero)
   End Sub

   Private Sub CargarUno(o As Entidades.ListaDePrecios, dr As DataRow)
      With o
         .IdListaPrecios = Integer.Parse(dr("IdListaPrecios").ToString())
         .NombreListaPrecios = dr("NombreListaPrecios").ToString()
         .FechaVigencia = Date.Parse(dr("FechaVigencia").ToString())
         .DescuentoRecargoPorc = Decimal.Parse(dr("DescuentoRecargoPorc").ToString())
         If Not String.IsNullOrEmpty(dr("Orden").ToString()) Then
            .Orden = Integer.Parse(dr("Orden").ToString())
         End If
         .Activa = Boolean.Parse(dr("Activa").ToString())
         .NombreCortoListaPrecios = dr(Entidades.ListaDePrecios.Columnas.NombreCortoListaPrecios.ToString()).ToString()
         If IsNumeric(dr(Entidades.ListaDePrecios.Columnas.IdFormasPago.ToString())) Then
            .FormaPago = New Reglas.VentasFormasPago(da).GetUna(Integer.Parse(dr(Entidades.ListaDePrecios.Columnas.IdFormasPago.ToString()).ToString()))
         End If
         .PublicarEnWeb = Boolean.Parse(dr("PublicarenWeb").ToString())
         .PermiteUtilidadEnCero = Boolean.Parse(dr("PermiteUtilidadEnCero").ToString())
      End With
   End Sub

#End Region

#Region "Metodos Publicos"
   Public Function GetTodos() As List(Of Entidades.ListaDePrecios)
      Return GetTodos(activa:=Nothing, orderBy:=Entidades.ListaDePrecios.Columnas.Orden)
   End Function
   Public Function GetTodos(activa As Boolean?) As List(Of Entidades.ListaDePrecios)
      Return GetTodos(activa, Entidades.ListaDePrecios.Columnas.Orden)
   End Function

   Public Function GetTodos(activa As Boolean?, orderBy As Entidades.ListaDePrecios.Columnas) As List(Of Entidades.ListaDePrecios)
      Return CargaLista(Me.GetAll(activa, orderBy), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ListaDePrecios())
   End Function

   Public Function GetUno(idListaPrecios As Integer) As Entidades.ListaDePrecios
      Return GetUno(idListaPrecios, AccionesSiNoExisteRegistro.Nulo)
   End Function
   Public Function GetUno(idListaPrecios As Integer, accion As AccionesSiNoExisteRegistro) As Entidades.ListaDePrecios
      Return CargaEntidad(New SqlServer.ListasDePrecios(Me.da).ListasDePrecios_G1(idListaPrecios),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.ListaDePrecios(),
                          accion, Function() String.Format("No existe lista de precios con Id {0}", idListaPrecios))
   End Function

   Public Function GetCodigoMaximo() As Integer
      Return New SqlServer.ListasDePrecios(da).GetCodigoMaximo()
   End Function

   Public Function GetPorNombre(nombre As String) As DataTable
      Return New SqlServer.ListasDePrecios(da).ListasDePrecios_GA(nombre, False)
   End Function
   Public Function GetPorNombreExacto(nombre As String) As DataTable
      Return New SqlServer.ListasDePrecios(da).ListasDePrecios_GA(nombre, True)
   End Function

   Public Function GetPorCodigo(cod As Integer, codExacto As Boolean) As DataTable
      Return New SqlServer.ListasDePrecios(da).ListasDePrecios_GetPorCodigo(cod, codExacto)
   End Function

   Public Sub VerificaPuedeBorrarListaDePrecios(idListaPrecios As Integer)
      EjecutaConConexion(Sub() _VerificaPuedeBorrarListaDePrecios(idListaPrecios))
   End Sub

   Private Sub _VerificaPuedeBorrarListaDePrecios(idListaPrecios As Integer)
      Dim listasDefault = New Parametros(da).GetPorCodigoEntidades(idEmpresa:=0, Entidades.Parametro.Parametros.LISTAPRECIOSPREDETERMINADA)
      Dim lp = GetUno(idListaPrecios)
      Dim rEmpresas = New Empresas(da)
      Dim permitido = True
      Dim stb As StringBuilder = Nothing
      For Each lpDef In listasDefault.OrderBy(Function(l) l.IdEmpresa)
         Dim idLP = lpDef.ValorParametro.ValorNumericoPorDefecto(-1I)
         If idLP = idListaPrecios Then
            If permitido Then
               stb = New StringBuilder()
               stb.AppendFormatLine("No puede eliminar la lista de precios predeterminada.").AppendLine()
               stb.AppendFormatLine("La lista de precios {0} - {1} es la lista predeterminada en la/s empresa/s:", lp.IdListaPrecios, lp.NombreListaPrecios).AppendLine()
            End If
            Dim emp = rEmpresas.GetUno(lpDef.IdEmpresa)
            stb.AppendFormatLine("    {0} - {1}", emp.IdEmpresa, emp.NombreEmpresa)
            permitido = False
         End If
      Next

      If Not permitido Then
         Throw New Exception(stb.ToString())
      End If
   End Sub

   Public Function GetPedidosPorListaDePrecios(idListaDePrecio As Integer) As DataTable
      Return New SqlServer.ListasDePrecios(da).ListasDePrecios_GetPedidosPorListaDePrecios(idListaDePrecio)
   End Function
#End Region

End Class
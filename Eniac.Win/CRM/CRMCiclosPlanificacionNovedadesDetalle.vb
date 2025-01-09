Public Class CRMCiclosPlanificacionNovedadesDetalle

   Private _publicos As Publicos

#Region "Constructores"
   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub
   Public Sub New(entidad As Entidades.CRMCicloPlanificacionNovedad)
      Me.New()
      _entidad = entidad
   End Sub
#End Region

   Public ReadOnly Property CRMCicloPlanificacionNovedad As Entidades.CRMCicloPlanificacionNovedad
      Get
         Return DirectCast(_entidad, Entidades.CRMCicloPlanificacionNovedad)
      End Get
   End Property

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As System.EventArgs)
      MyBase.OnLoad(e)

      TryCatched(
      Sub()
         _publicos = New Publicos()
         _publicos.CargaComboDesdeEnum(cmbTipoPlanificacion, Entidades.CRMCicloPlanificacionNovedad.TiposPlanificacion.CERRADA)
         _publicos.CargaComboCRMTiposNovedades(cmbIdTipoNovedad, idTipoNovedad:="PENDIENTE")

         BindearControles(_entidad)

         If StateForm = Eniac.Win.StateForm.Insertar Then
            pnlUsuarios.Visible = False
         Else
            bscIdCicloPlanificacion.Text = CRMCicloPlanificacionNovedad.IdCicloPlanificacion.ToString()
            bscIdCicloPlanificacion.PresionarBoton()
            bscIdNovedad.Text = CRMCicloPlanificacionNovedad.IdNovedad.ToString()
            bscIdNovedad.PresionarBoton()

            bscIdCicloPlanificacion.Permitido = False
            bscNombreCicloPlanificacion.Permitido = False
            cmbIdTipoNovedad.Enabled = False
            txtLetra.ReadOnly = True
            txtCentroEmisor.ReadOnly = True
            bscIdNovedad.Permitido = False

         End If

         MostrarEstadosNovedadSegunEstado()
      End Sub)
   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return GetRegla()
   End Function
   Protected Function GetRegla() As Reglas.CRMCiclosPlanificacionNovedades
      Return New Reglas.CRMCiclosPlanificacionNovedades()
   End Function

   Protected Overrides Sub Aceptar()
      MyBase.Aceptar()
   End Sub
   Protected Overrides Function ValidarDetalle() As String
      If Not bscIdCicloPlanificacion.Selecciono AndAlso Not bscNombreCicloPlanificacion.Selecciono Then
         bscIdCicloPlanificacion.Focus()
         Return "No seleccionó un ciclo de planificación"
      End If
      If Not bscIdNovedad.Selecciono Then
         bscIdNovedad.Focus()
         Return "No seleccionó una Novedad"
      End If
      If txtOrden.ValorNumericoPorDefecto(0I) <= 0I Then
         txtOrden.Focus()
         Return "El orden debe ser mayor a cero"
      End If

      If cmbTipoPlanificacion.SelectedIndex = -1 Then
         cmbTipoPlanificacion.Focus()
         Return "No seleccionó un tipo de planificación"
      End If

      Return MyBase.ValidarDetalle()
   End Function

#End Region

#Region "Eventos"
#Region "Eventos Buscador Ciclo Planificacion"
   Private Sub bscIdCicloPlanificacion_BuscadorClick() Handles bscIdCicloPlanificacion.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCRMCiclosPlanificacion(bscIdCicloPlanificacion)
         bscIdCicloPlanificacion.Datos = New Reglas.CRMCiclosPlanificacion().GetPorCodigo(bscIdCicloPlanificacion.Text.ValorNumericoPorDefecto(0I))
      End Sub)
   End Sub
   Private Sub bscNombreCicloPlanificacion_BuscadorClick() Handles bscNombreCicloPlanificacion.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCRMCiclosPlanificacion(bscNombreCicloPlanificacion)
         bscNombreCicloPlanificacion.Datos = New Reglas.CRMCiclosPlanificacion().GetPorNombre(bscNombreCicloPlanificacion.Text)
      End Sub)
   End Sub
   Private Sub bscIdCicloPlanificacion_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscNombreCicloPlanificacion.BuscadorSeleccion, bscIdCicloPlanificacion.BuscadorSeleccion
      TryCatched(Sub() CargaCicloPlanificacion(e.FilaDevuelta))
   End Sub
#End Region

#Region "Eventos Buscador Novedad"
   Private Sub bscIdNovedad_BuscadorClick() Handles bscIdNovedad.BuscadorClick
      TryCatched(
      Sub()
         _publicos.PreparaGrillaCRMNovedades(bscIdNovedad, cmbIdTipoNovedad.ValorSeleccionado(String.Empty))
         bscIdNovedad.Datos = New Reglas.CRMNovedades().GetNovedadXTipo(cmbIdTipoNovedad.ValorSeleccionado(String.Empty), String.Empty, 0S, bscIdNovedad.Text.ValorNumericoPorDefecto(0L))
      End Sub)
   End Sub

   Private Sub bscIdNovedad_BuscadorSeleccion(sender As Object, e As Controles.BuscadorEventArgs) Handles bscIdNovedad.BuscadorSeleccion
      TryCatched(Sub() CargaNovedad(e.FilaDevuelta))
   End Sub
#End Region
#End Region

#Region "Métodos"
   Private Sub CargaCicloPlanificacion(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         CRMCicloPlanificacionNovedad.IdCicloPlanificacion = dr.Cells(Entidades.CRMCicloPlanificacion.Columnas.IdCicloPlanificacion.ToString()).Value.ToString().ValorNumericoPorDefecto(0I)
         bscIdCicloPlanificacion.Text = CRMCicloPlanificacionNovedad.IdCicloPlanificacion.ToString()
         bscNombreCicloPlanificacion.Text = dr.Cells(Entidades.CRMCicloPlanificacion.Columnas.NombreCicloPlanificacion.ToString()).Value.ToString()
         txtEstadoCicloPlanificacion.Text = dr.Cells(Entidades.CRMCicloPlanificacion.Columnas.IdEstadoCicloPlanificacion.ToString()).Value.ToString()

         dtpFechaInicio.Value = Date.Parse(dr.Cells(Entidades.CRMCicloPlanificacion.Columnas.FechaInicio.ToString()).Value.ToString())
         dtpFechaCierre.Value = Date.Parse(dr.Cells(Entidades.CRMCicloPlanificacion.Columnas.FechaCierre.ToString()).Value.ToString())
         dtpFechaFinalizacion.Value = Date.Parse(dr.Cells(Entidades.CRMCicloPlanificacion.Columnas.FechaFinalizacion.ToString()).Value.ToString())

         Dim estado = New Reglas.CRMEstadosCiclosPlanificacion().GetUno(txtEstadoCicloPlanificacion.Text)
         txtEstadoCicloPlanificacion.ForeColor = estado.ForeColor.ToArgbColor()
         txtEstadoCicloPlanificacion.BackColor = estado.BackColor.ToArgbColor()

         If StateForm = StateForm.Insertar Then
            txtOrden.SetValor(GetRegla().GetProximoOrden(CRMCicloPlanificacionNovedad.IdCicloPlanificacion))
         End If

         cmbIdTipoNovedad.Focus()
      End If
   End Sub
   Private Sub CargaNovedad(dr As DataGridViewRow)
      If dr IsNot Nothing Then
         Dim novedad = New Reglas.CRMNovedades().GetUno(dr.Cells("IdTipoNovedad").Value.ToString(),
                                                        dr.Cells("Letra").Value.ToString(),
                                                        Short.Parse(dr.Cells("CentroEmisor").Value.ToString()),
                                                        Long.Parse(dr.Cells("IdNovedad").Value.ToString()),
                                                        Reglas.Base.AccionesSiNoExisteRegistro.Excepcion)

         txtLetra.Text = novedad.Letra
         txtCentroEmisor.Text = novedad.CentroEmisor.ToString()
         bscIdNovedad.Text = novedad.IdNovedad.ToString()

         CRMCicloPlanificacionNovedad.IdNovedad = novedad.IdNovedad

         txtOrden.Focus()
      End If
   End Sub

   Private Sub MostrarEstadosNovedadSegunEstado()
      Dim cache = New Reglas.BusquedasCacheadas()
      MostrarEstadosNovedadSegunEstadoIndividual(txtEstadoInicio, CRMCicloPlanificacionNovedad.IdEstadoNovedadInicio, cache)
      MostrarEstadosNovedadSegunEstadoIndividual(txtEstadoCierre, CRMCicloPlanificacionNovedad.IdEstadoNovedadCierre, cache)
      MostrarEstadosNovedadSegunEstadoIndividual(txtEstadoFin, CRMCicloPlanificacionNovedad.IdEstadoNovedadFinal, cache)
   End Sub
   Private Sub MostrarEstadosNovedadSegunEstadoIndividual(txt As TextBox, id As Integer?, cache As Reglas.BusquedasCacheadas)
      Dim e = cache.CRMEstadoNovedad.Buscar(id)
      If e IsNot Nothing Then
         txt.Text = e.NombreEstadoNovedad
      Else
         txt.Clear()
      End If
   End Sub

#End Region

End Class
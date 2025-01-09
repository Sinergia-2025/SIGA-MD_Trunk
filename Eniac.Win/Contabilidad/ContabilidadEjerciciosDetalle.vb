Public Class ContabilidadEjerciciosDetalle

#Region "Campos"

   Private ReadOnly Property Ejercicio As Entidades.ContabilidadEjercicio
      Get
         Return DirectCast(Me._entidad, Entidades.ContabilidadEjercicio)
      End Get
   End Property

   Private _publicos As ContabilidadPublicos
   Private dtGrilla As DataTable
   Private _cargandoForm As Boolean = True

#End Region

#Region "Constructores"

   Public Sub New()
      ' This call is required by the Windows Form Designer.
      InitializeComponent()
   End Sub

   Public Sub New(entidad As Entidades.ContabilidadEjercicio)
      InitializeComponent()
      _entidad = entidad
   End Sub

#End Region

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)

      MyBase.OnLoad(e)

      TryCatched(
         Sub()
            _publicos = New ContabilidadPublicos()

            BindearControles(_entidad)

            CargarValoresIniciales()
         End Sub)

   End Sub

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.ContabilidadEjercicios()
   End Function

#End Region

#Region "Eventos"

   Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
      TryCatched(
         Sub()
            DirectCast(_entidad, Entidades.ContabilidadEjercicio).DetallesPeriodos = DirectCast(grdPeriodos.DataSource, DataTable)
            If Not HayError Then Close()
            txtcodigoEjercicio.Focus()
         End Sub)
   End Sub

   Private Sub grdPeriodos_MouseClick(sender As Object, e As MouseEventArgs) Handles grdPeriodos.MouseClick
      TryCatched(
         Sub()
            If grdPeriodos IsNot Nothing Then
               Dim point1 = grdPeriodos.CurrentCellAddress
               If grdPeriodos.EditMode = DataGridViewEditMode.EditProgrammatically Then
                  grdPeriodos.BeginEdit(True)
               End If
            End If
         End Sub)
   End Sub

   Private Sub dtpDesde_ValueChanged(sender As Object, e As EventArgs) Handles dtpDesde.ValueChanged
      TryCatched(
         Sub()
            If Not _cargandoForm Then
               dtpDesde.Value = dtpDesde.Value.PrimerDiaMes()
               _cargandoForm = True
               dtpHasta.Value = CalculaFechaHasta(dtpDesde.Value)
               _cargandoForm = False
               CargarGrillaConEjercicio(dtpDesde.Value)
            End If
         End Sub)
   End Sub

   Private Sub chkCerrado_CheckedChanged(sender As Object, e As EventArgs) Handles chkCerrado.CheckedChanged
      TryCatched(
         Sub()
            If _cargandoForm Then Return
            dtGrilla.AsEnumerable().ToList().ForEach(Sub(fila) fila("Cerrado") = chkCerrado.Checked)
         End Sub)
   End Sub

#End Region

#Region "Metodos"

   Private Sub CargarValoresIniciales()

      If Me.StateForm = Eniac.Win.StateForm.Insertar Then

         CargarProximoNumero()

         dtpDesde.Value = New Reglas.ContabilidadEjercicios().GetFechaMaxima()
         dtpDesde.Value = dtpDesde.Value.Date.PrimerDiaMes().AddMonths(1)
         dtpHasta.Value = CalculaFechaHasta(dtpDesde.Value)

         'Solo permito poner la fecha de inicio del ejercicio si es el primer ejercicio que se cargó
         dtpDesde.Enabled = txtcodigoEjercicio.Text = "1"

         dtGrilla = CrearTablaGrilla()

         _cargandoForm = False
         CargarGrillaConEjercicio(dtpDesde.Value)

         'Me.txtcodigoEjercicio.Focus()

      ElseIf Me.StateForm = Eniac.Win.StateForm.Actualizar Then
         dtpDesde.Value = Ejercicio.FechaDesde.PrimerDiaMes()
         dtpHasta.Value = Ejercicio.FechaHasta.PrimerDiaMes()
         dtGrilla = Ejercicio.DetallesPeriodos
         _cargandoForm = False
      End If

      grdPeriodos.DataSource = dtGrilla

      grdPeriodos.EditMode = DataGridViewEditMode.EditProgrammatically

      grdPeriodos.Columns("IdPeriodo").ReadOnly = True
      grdPeriodos.Columns("IdEjercicio").ReadOnly = True
      grdPeriodos.Columns("cerrado").ReadOnly = False
      grdPeriodos.Columns("CoeficienteAjustePorInflacion").ReadOnly = False
      grdPeriodos.Columns("orden").Visible = False


      ' grdPeriodos.BeginEdit(False)

   End Sub

   Protected Overrides Sub Aceptar()
      Ejercicio.FechaDesde = dtpDesde.Value.PrimerDiaMes()
      Ejercicio.FechaHasta = dtpHasta.Value.UltimoDiaMes()
      Ejercicio.Fuerza_VerificaAsientosPendientes = Reglas.ContabilidadPublicos.CerrarPeriodoConAsientoPermitir = Entidades.Publicos.PermitirNoPermitir.PERMITIR

      MyBase.Aceptar()
   End Sub

   Protected Overrides Function EjecutaActualizar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      Try
         Return MyBase.EjecutaActualizar(rg, en)
      Catch ex As Reglas.ContabilidadEjercicios.VerificaAsientosPendientesException
         If Reglas.ContabilidadPublicos.CerrarPeriodoConAsientoPermitir = Entidades.Publicos.PermitirNoPermitir.NOPERMITIR Then
            Throw
         Else 'par = "AVISA" 
            If ShowPregunta(String.Format("{1}{0}{0}¿Desea continuar igualmente?", Environment.NewLine, ex.Message)) = DialogResult.Yes Then
               Ejercicio.Fuerza_VerificaAsientosPendientes = True
               Return EjecutaActualizar(rg, en)
            Else
               Throw New Exception(String.Format("Grabación cancelada por el usuario.{0}{0}{1}", Environment.NewLine, ex.Message))
            End If
         End If
      End Try
   End Function
   Protected Overrides Function EjecutaInsertar(rg As Reglas.Base, en As Entidades.Entidad) As Entidades.Entidad
      Try
         Return MyBase.EjecutaInsertar(rg, en)
      Catch ex As Reglas.ContabilidadEjercicios.VerificaAsientosPendientesException
         If Reglas.ContabilidadPublicos.CerrarPeriodoConAsientoPermitir = Entidades.Publicos.PermitirNoPermitir.NOPERMITIR Then
            Throw
         Else 'par = "AVISA" 
            If ShowPregunta(String.Format("{1}{0}{0}¿Desea continuar igualmente?", Environment.NewLine, ex.Message)) = DialogResult.Yes Then
               Ejercicio.Fuerza_VerificaAsientosPendientes = True
               Return EjecutaInsertar(rg, en)
            Else
               Throw New Exception(String.Format("Grabación cancelada por el usuario.{0}{0}{1}", Environment.NewLine, ex.Message))
            End If
         End If
      End Try
   End Function

   Private Sub CargarProximoNumero()
      Dim ProximoID = New Reglas.ContabilidadEjercicios().GetIdMaximo() + 1
      txtcodigoEjercicio.Text = ProximoID.ToString()
   End Sub

   Private Sub CargarGrillaConEjercicio(fDesde As Date)

      Dim meses = DateDiff(DateInterval.Month, dtpDesde.Value, dtpHasta.Value) + 1

      If grdPeriodos.Rows.Count > 0 Then
         DirectCast(grdPeriodos.DataSource, DataTable).Rows.Clear()
      End If

      For i = 1 To meses
         Dim fila = dtGrilla.NewRow
         fila(Entidades.ContabilidadEjercicio.Columnas.IdEjercicio.ToString()) = txtcodigoEjercicio.Text
         fila("IdPeriodo") = fDesde.ToString("MM/yyyy")
         fila("orden") = i
         fDesde = fDesde.AddMonths(1)
         fila("cerrado") = False
         fila("CoeficienteAjustePorInflacion") = DBNull.Value
         dtGrilla.Rows.Add(fila)
      Next

      Ejercicio.DetallesPeriodos = dtGrilla

   End Sub

   Private Function CrearTablaGrilla() As DataTable
      Dim datosGrillas = New DataTable()
      datosGrillas.Columns.Add("IdEjercicio", GetType(Integer))
      datosGrillas.Columns.Add("IdPeriodo", GetType(String))
      datosGrillas.Columns.Add("cerrado", GetType(Boolean))
      datosGrillas.Columns.Add("orden", GetType(Integer))
      datosGrillas.Columns.Add("CoeficienteAjustePorInflacion", GetType(Decimal))
      Return datosGrillas
   End Function

   Protected Overrides Function ValidarDetalle() As String

      If StateForm = Win.StateForm.Insertar Then
         If Not EjercicioTiene12Meses(dtpDesde.Value, dtpHasta.Value) Then
            dtpDesde.Focus()
            Return "El Ejercicio no posee 12 meses."
         End If
      End If

      'Return vacio
      Return MyBase.ValidarDetalle()

   End Function

   Private Function EjercicioTiene12Meses(Fdesde As Date, Fhasta As Date) As Boolean
      Dim Meses = DateDiff(DateInterval.Month, dtpDesde.Value, dtpHasta.Value) + 1
      Return (Meses = 12)
   End Function

   Private Function CalculaFechaHasta(fechaDesde As Date) As Date
      Return fechaDesde.Date.AddMonths(11)
   End Function

#End Region

End Class
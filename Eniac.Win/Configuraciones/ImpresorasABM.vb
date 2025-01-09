Public Class ImpresorasABM

   Public ConsultarAutomaticamente As Boolean = False

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      Me.tsbImprimir.Visible = False
   End Sub

   Protected Overrides Sub OnShown(e As EventArgs)
      MyBase.OnShown(e)

      Try
         CargarMenuContextualGrilla()
      Catch ex As Exception
         ShowError(ex)
      End Try

   End Sub

   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New ImpresorasDetalle(DirectCast(GetEntidad(), Entidades.Impresora))
      End If
      Return New ImpresorasDetalle(New Entidades.Impresora())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Impresoras()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      MyBase.GetEntidad()
      Dim o = New Entidades.Impresora
      With dgvDatos.ActiveRow
         o = New Reglas.Impresoras().GetUna(actual.Sucursal.Id, .Cells("IdImpresora").Value.ToString())
      End With
      Return o
   End Function

   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
      TryCatched(
      Sub()
         Dim frmImprime = New VisorReportes("Eniac.Personal.Win.Impresoras.rdlc", "ControlPersonal_Impresoras", Me.dtDatos, True, 1) '# 1 = Cantidad Copias
         frmImprime.Text = ""
         frmImprime.Show()
      End Sub)
   End Sub

   Protected Overrides Sub FormatearGrilla()

      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos = 0
         ''.SelectionMode = DataGridViewSelectionMode.FullRowSelect
         .Columns("IdSucursal").OcultoPosicion(True, pos)

         .Columns("IdImpresora").FormatearColumna("Id", pos, 120)

         .Columns("TipoImpresora").FormatearColumna("Tipo", pos, 60)

         .Columns("CentroEmisor").FormatearColumna("Centro Emisor", pos, 50, HAlign.Right)

         .Columns("PorCtaOrden").FormatearColumna("Cta y Orden", pos, 70, HAlign.Center)

         .Columns("UtilizaBonosFiscalesElectronicos").FormatearColumna("Utiliza Bono Fiscal", pos, 70, HAlign.Center)

         .Columns("ComprobantesHabilitados").FormatearColumna("Comprobantes Habilitados", pos, 200)

         .Columns("Puerto").FormatearColumna("Puerto", pos, 45, HAlign.Right)

         .Columns("Velocidad").FormatearColumna("Velocidad", pos, 60, HAlign.Right)
         .Columns("MaximoCaracteresItem").FormatearColumna("Máximo Caracteres Item", pos, 60, HAlign.Right)

         .Columns("EsProtocoloExtendido").FormatearColumna("Prot. Ext.", pos, 60, HAlign.Center)

         .Columns("Marca").FormatearColumna("Marca", pos, 60)
         .Columns("Modelo").FormatearColumna("Modelo", pos, 80)

         .Columns("OrigenPapel").FormatearColumna("Origen Papel", pos, 40, HAlign.Center)

         .Columns("CantidadCopias").FormatearColumna("Cant. Copias", pos, 40, HAlign.Right)

         .Columns("TipoFormulario").FormatearColumna("Tipo Form.", pos, 40, HAlign.Center)

         .Columns("TamanioLetra").FormatearColumna("Tamaño Letra", pos, 50, HAlign.Right)

         .Columns("Metodo").FormatearColumna("Metodo", pos, 60)

         .Columns("AbrirCajonDinero").FormatearColumna("Abrir Caja", pos, 50, HAlign.Center)
         .Columns("GrabarLOGs").FormatearColumna("Grabar LOGs", pos, 50, HAlign.Center)
         .Columns("CierreFiscalEstandar").FormatearColumna("Cierre Fis. Est.", pos, 50, HAlign.Center)
         .Columns("ImprimirLineaALinea").FormatearColumna("Imprimir x Linea", pos, 50, HAlign.Center)

         .Columns("DireccionCentroEmisor").FormatearColumna("Dirección Centro Emisor", pos, 130)
         .Columns("IdLocalidadCentroEmisor").OcultoPosicion(True, pos)
         .Columns("NombreLocalidadCentroEmisor").FormatearColumna("Localidad Centro Emisor", pos, 100)

         .Columns("FiscalUltimaFechaExtraidaAuditoria").FormatearColumna("Última fecha extraida auditoria", pos, 80)
         .Columns("FiscalUltimoZetaExtraidoAuditoria").FormatearColumna("Último zeta extraido auditoria", pos, 80)
         .Columns("FiscalUltimaFechaExtraidaInforme").FormatearColumna("Última fecha extraida informe", pos, 80)

         dgvDatos.AgregarFiltroEnLinea({"IdImpresora", "ComprobantesHabilitados", "NombreLocalidadCentroEmisor"})

      End With

   End Sub

   Protected Overrides Sub RefreshGrid()
      Try

         Dim rg = DirectCast(Me.GetReglas(), Reglas.Impresoras)
         If Not tstBuscar.Tag Is Nothing And Me.tstBuscar.Text <> "" Then
            Dim bus As Entidades.Buscar = New Entidades.Buscar
            bus.IdSucursal = Entidades.Usuario.Actual.Sucursal.Id
            bus.Columna = Me.tstBuscar.Tag.ToString()
            bus.Valor = Me.tstBuscar.Text.Trim()
            Me.dtDatos = rg.Buscar(bus)
         Else
            Me.dtDatos = rg.GetAll(Entidades.Usuario.Actual.Sucursal.Id)
         End If
         Me.dgvDatos.DataSource = Me.dtDatos
         If Not Me.dtDatos Is Nothing Then
            Me.FormatearGrilla()
         End If
         If Me.dgvDatos.Rows.Count > 1 Then
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registros"
         Else
            Me.tssRegistros.Text = Me.dgvDatos.Rows.Count & " Registro"
         End If
      Catch ex As Exception
         MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
      End Try
   End Sub

#End Region

#Region "Metodo"
   Private Sub CargarMenuContextualGrilla()
      GridContextMenuManager1.CargarMenuContextualGrilla()

      Dim item = gridContextMenuStrip.Items.AddMenuItem("Agregar PC Actual")
      AddHandler item.Click, Sub(sender, e) TryCatched(Sub() AgregarPC())
   End Sub

   Private Sub AgregarPC()
      Dim impresora = DirectCast(GetEntidad(), Entidades.Impresora)
      If Not String.IsNullOrWhiteSpace(impresora.IdImpresora) Then
         Dim pc = Environment.MachineName
         If Not impresora.PCs.Contains(pc) Then
            If ShowPregunta("¿Desea agregar esta PC a la impresora seleccionada?") = Windows.Forms.DialogResult.Yes Then
               Dim pcs = impresora.PCs.ToList()
               pcs.Add(pc)
               impresora.PCs = pcs.ToArray()
               GetReglas().Actualizar(impresora)
               ShowMessage("Impresora actualizada exitosamente.")
            End If
         Else
            ShowMessage("La impresora selecciona ya tiene asignada esta PC")
         End If
      End If
   End Sub
#End Region

End Class
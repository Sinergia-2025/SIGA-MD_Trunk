Public Class SucursalesABM
   Private WithEvents tsbVincular As ToolStripButton

   Public Sub New()
      ' This call is required by the designer.
      InitializeComponent()
      ' Add any initialization after the InitializeComponent() call.

      tsbVincular = New ToolStripButton()
      With tsbVincular
         .Image = My.Resources.exchange
         .Name = "tsbVincular"
         .Size = New Size(65, 26)
         .Text = "Vincular"
         .ToolTipText = "Vincula - Desvincula una sucursal con otra."
      End With
      tstBarra.Items.Insert(tstBarra.Items.IndexOf(tsbBorrar) + 1, tsbVincular)

   End Sub

#Region "Overrides"

   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      BotonImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SucursalesDetalle(DirectCast(Me.GetEntidad(), Entidades.Sucursal))
      End If
      Return New SucursalesDetalle(New Entidades.Sucursal)
   End Function
   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.Sucursales()
   End Function
   Protected Overrides Function GetEntidad() As Entidades.Entidad
      With Me.dgvDatos.ActiveRow
         Return New Reglas.Sucursales().GetUna(Integer.Parse(.Cells("IdSucursal").Value.ToString()), False)
      End With
   End Function
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim pos As Integer = 0
         Dim countEmpresas As Integer = New Reglas.Empresas().Count()

         .Columns("IdEmpresa").FormatearColumna("Código Empresa", pos, 60, HAlign.Right, countEmpresas = 1)
         .Columns("NombreEmpresa").FormatearColumna("Nombre Empresa", pos, 150, , countEmpresas = 1)

         .Columns("IdSucursal").FormatearColumna("Código", pos, 50, HAlign.Right)
         .Columns("Nombre").FormatearColumna("Nombre", pos, 150)
         .Columns("Direccion").FormatearColumna("Dirección", pos, 130)
         .Columns("IdLocalidad").OcultoPosicion(True, pos)
         .Columns("NombreLocalidad").FormatearColumna("Localidad", pos, 100)
         .Columns("Telefono").FormatearColumna("Teléfono", pos, 120)
         .Columns("Correo").FormatearColumna("Correo", pos, 150)
         .Columns("FechaInicioActiv").FormatearColumna("Inicio Act.", pos, 70, HAlign.Center, , "dd/MM/yyyy")
         .Columns("EstoyAca").FormatearColumna("Aca", pos, 40, HAlign.Center)
         .Columns("SoyLaCentral").FormatearColumna("Central", pos, 70, HAlign.Center)
         .Columns("IdSucursalAsociada").OcultoPosicion(True, pos)
         .Columns("NombreSucursalAsociada").FormatearColumna("Nombre Suc. Asociada", pos, 150)
         .Columns("IdSucursalAsociadaPrecios").OcultoPosicion(True, pos)
         .Columns("NombreSucursalAsociadaPrecios").FormatearColumna("Suc. Asociada Precios", pos, 150, , True)
         .Columns("ColorSucursal").OcultoPosicion(True, pos)
         .Columns("DireccionComercial").FormatearColumna("Dirección Comercial", pos, 130)
         .Columns("IdLocalidadComercial").OcultoPosicion(True, pos)
         .Columns("NombreLocalidadComercial").FormatearColumna("Localidad Comercial", pos, 100)
         .Columns("RedesSociales").FormatearColumna("Redes Sociales", pos, 150)
         .Columns("PublicarEnWeb").FormatearColumna("Publicar En Web", pos, 70, HAlign.Center)

         .Columns("Id").OcultoPosicion(True, pos)
         .Columns("LogoSucursal").OcultoPosicion(True, pos)
      End With
      dgvDatos.AgregarFiltroEnLinea({"NombreEmpresa", "Nombre",
                                     "Direccion", "DireccionComercial",
                                     "NombreSucursalAsociada", "NombreSucursalAsociadaPrecios",
                                     "Correo", "RedesSociales"})
   End Sub
#End Region

   Private Sub dgvDatos_AfterRowActivate(sender As Object, e As EventArgs) Handles dgvDatos.AfterRowActivate
      TryCatched(
         Sub()
            Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
            If dr IsNot Nothing Then
               If dr.Field(Of Integer?)(Entidades.Sucursal.Columnas.IdSucursalAsociada.ToString()).HasValue Then
                  tsbVincular.Text = "Desvincular"
               Else
                  tsbVincular.Text = "Vincular"
               End If
            End If
         End Sub)
   End Sub

   Private Sub tsbVincular_Click(sender As Object, e As EventArgs) Handles tsbVincular.Click
      TryCatched(
         Sub()
            Dim suc = GetEntidad()
            If suc.IdSucursal <> 0 Then
               Using frm = New SucursalesVinculacionV2(DirectCast(suc, Entidades.Sucursal))
                  frm.ShowDialog(Me)
                  tsbRefrescar.PerformClick()
               End Using
            End If
         End Sub)
   End Sub

End Class
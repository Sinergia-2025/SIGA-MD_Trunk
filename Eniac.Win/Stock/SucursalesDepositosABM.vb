Public Class SucursalesDepositosABM
#Region "Overrides"
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)
      tsbImprimir.Visible = False
   End Sub
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New SucursalesDepositosDetalle(DirectCast(GetEntidad(), Entidades.SucursalDeposito))
      End If
      Return New SucursalesDepositosDetalle(New Entidades.SucursalDeposito())
   End Function

   Protected Overrides Function GetReglas() As Reglas.Base
      Return New Reglas.SucursalesDepositos()
   End Function

   Protected Overrides Function GetEntidad() As Entidades.Entidad
      Dim dr = dgvDatos.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Return New Reglas.SucursalesDepositos().GetUno(dr.Field(Of Integer)("IdDeposito"), dr.Field(Of Integer)("IdSucursal"), cargaUsuarios:=True)
      End If
      Return Nothing
   End Function

   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         .OcultaTodasLasColumnas()
         Dim col = 0I
         .Columns(Entidades.SucursalDeposito.Columnas.IdSucursal.ToString()).FormatearColumna("Sucursal", col, 80, HAlign.Right)
         .Columns(Entidades.SucursalDeposito.Columnas.NombreSucursal.ToString()).FormatearColumna("Nombre Sucursal", col, 200)
         .Columns(Entidades.SucursalDeposito.Columnas.IdDeposito.ToString()).Hidden = True
         .Columns(Entidades.SucursalDeposito.Columnas.CodigoDeposito.ToString()).FormatearColumna("Deposito", col, 80, HAlign.Left)
         .Columns(Entidades.SucursalDeposito.Columnas.NombreDeposito.ToString()).FormatearColumna("Nombre Deposito", col, 200)
         .Columns(Entidades.SucursalDeposito.Columnas.DisponibleVenta.ToString()).FormatearColumna("Disp. Venta", col, 80)
         .Columns(Entidades.SucursalDeposito.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 80)
         .Columns(Entidades.SucursalDeposito.Columnas.SucursalAsociada.ToString()).Hidden = True
         .Columns(Entidades.SucursalDeposito.Columnas.DepositoAsociado.ToString()).Hidden = True
         .Columns(Entidades.SucursalDeposito.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 80)
         .Columns(Entidades.SucursalDeposito.Columnas.TipoDeposito.ToString()).FormatearColumna("Tipo Deposito", col, 100)
      End With
      dgvDatos.AgregarFiltroEnLinea({Entidades.SucursalDeposito.Columnas.CodigoDeposito.ToString()})
   End Sub

   Protected Overrides Function ValidaBorrado(entidad As Entidades.Entidad) As Boolean
      Return MyBase.ValidaBorrado(entidad)
   End Function

   Protected Overrides Function ConfirmarBorrado() As DialogResult
      Dim dr = dgvDatos.ActiveRow.FilaSeleccionada(Of DataRow)()
      If dr IsNot Nothing Then
         Dim rUbi = New Reglas.SucursalesUbicaciones()
         Using dt = rUbi.GetSucursalDeposito(dr.Field(Of Integer)(Entidades.SucursalDeposito.Columnas.IdDeposito.ToString()),
                                             dr.Field(Of Integer)(Entidades.SucursalDeposito.Columnas.IdSucursal.ToString()))
            Dim stbMensaje = New StringBuilder()
            stbMensaje.AppendFormatLine("El Depósito {0} porsee {1} Ubicaciones.",
                                        dr.Field(Of String)(Entidades.SucursalDeposito.Columnas.NombreDeposito.ToString()),
                                        dt.Count)
            stbMensaje.AppendLine()
            stbMensaje.AppendFormatLine("De continuar no se eliminarán todas las ubicaciones y el stock de las mismas")
            stbMensaje.AppendLine()
            stbMensaje.AppendFormatLine("¿Desea continuar?")
            Return ShowPregunta(stbMensaje.ToString(), MessageBoxDefaultButton.Button2)
         End Using
      End If
      Return MyBase.ConfirmarBorrado()
   End Function

#End Region
End Class
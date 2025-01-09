Imports Eniac.Entidades
Imports Eniac.Reglas

Public Class DispositivosABM
   Protected Overrides Sub OnLoad(e As EventArgs)
      MyBase.OnLoad(e)

      'GAR:31/12/2022. Por control de Licencias. Temporalmente Anulado.
      Me.tsbNuevo.Visible = False
      Me.tsbBorrar.Visible = False

   End Sub

   'GET DETALLE
   Protected Overrides Function GetDetalle(estado As StateForm) As BaseDetalle
      If estado = StateForm.Actualizar Then
         Return New DispositivosDetalle(DirectCast(Me.GetEntidad(), Entidades.Dispositivo))
      End If
      Return New DispositivosDetalle(New Entidades.Dispositivo)
   End Function
   'GET REGLAS
   Protected Overrides Function GetReglas() As Base
      Return New Reglas.Dispositivos()
   End Function
   'GET ENTIDAD
   Protected Overrides Function GetEntidad() As Entidad
      MyBase.GetEntidad()
      With Me.dgvDatos.ActiveCell.Row
         Return New Reglas.Dispositivos().GetUno(.Cells(Entidades.Dispositivo.Columnas.IdDispositivo.ToString()).Value.ToString())
      End With
   End Function
   'IMPRIMIR
   Protected Overrides Sub Imprimir()
      MyBase.Imprimir()
   End Sub

   'FORMATEAR GRILLA
   Protected Overrides Sub FormatearGrilla()
      With Me.dgvDatos.DisplayLayout.Bands(0)
         Dim col As Integer = 0
         .Columns(Entidades.Dispositivo.Columnas.IdDispositivo.ToString()).FormatearColumna("Código", col, 100)
         .Columns(Entidades.Dispositivo.Columnas.NombreDispositivo.ToString()).FormatearColumna("Nombre", col, 100)
         .Columns(Entidades.Dispositivo.Columnas.FechaUltimoLogin.ToString()).FormatearColumna("Fecha Login", col, 100, HAlign.Center,   , "dd/MM/yyyy HH:mm")
         .Columns(Entidades.Dispositivo.Columnas.UsuarioUltimoLogin.ToString()).FormatearColumna("Usuario", col, 70)
         .Columns(Entidades.Dispositivo.Columnas.IdTipoDispositivo.ToString()).FormatearColumna("Tipo", col, 60)
         .Columns(Entidades.Dispositivo.Columnas.Activo.ToString()).FormatearColumna("Activo", col, 50)
         .Columns(Entidades.Dispositivo.Columnas.SistemaOperativo.ToString()).FormatearColumna("SO", col, 140)
         .Columns(Entidades.Dispositivo.Columnas.ArquitecturaSO.ToString()).FormatearColumna("Arquit.", col, 60)
         .Columns(Entidades.Dispositivo.Columnas.NumeroSerieDiscoPrimario.ToString()).FormatearColumna("Nro Serie HHD Princ.", col, 140)
         .Columns(Entidades.Dispositivo.Columnas.ResolucionPantalla.ToString()).FormatearColumna("Resolucion Pantalla", col, 80)
         .Columns(Entidades.Dispositivo.Columnas.VersionFramework.ToString()).FormatearColumna("Version Framework", col, 80)
         .Columns(Entidades.Dispositivo.Columnas.NumeroSerieDiscoRigido.ToString()).FormatearColumna("Número Serie HDD", col, 150)
         .Columns(Entidades.Dispositivo.Columnas.DireccionMAC.ToString()).FormatearColumna("Dirección MAC", col, 150)
         .Columns(Entidades.Dispositivo.Columnas.NumeroSerieMotherboard.ToString()).FormatearColumna("Nro Serie Motherboard", col, 150)
         .Columns(Entidades.Dispositivo.Columnas.Control1.ToString()).OcultoPosicion(hidden:=True, col)
      End With
   End Sub
End Class
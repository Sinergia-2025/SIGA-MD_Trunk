Option Strict On
Option Explicit On
Public Class CRMTiposNovedades
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "CRMTiposNovedades"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "CRMTiposNovedades"
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

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.CRMTiposNovedades = New SqlServer.CRMTiposNovedades(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As DataTable
      Return GetAll(aplicaSeguridad:=False, conDinamicos:={})
   End Function

   Public Overloads Function GetAll(aplicaSeguridad As Boolean, conDinamicos As Entidades.CRMTipoNovedad.TipoDinamico()) As DataTable
      Return New SqlServer.CRMTiposNovedades(da).CRMTiposNovedades_GA1(aplicaSeguridad:=aplicaSeguridad, idTipoNovedad:=String.Empty, conDinamicos:=conDinamicos)
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal entidad As Eniac.Entidades.Entidad, ByVal tipo As TipoSP)
      Try
         Dim en As Entidades.CRMTipoNovedad = DirectCast(entidad, Entidades.CRMTipoNovedad)

         da.OpenConection()
         da.BeginTransaction()

         Dim rDinamicos As Reglas.CRMTiposNovedadesDinamicos = New CRMTiposNovedadesDinamicos(da)
         Dim sqlC As SqlServer.CRMTiposNovedades = New SqlServer.CRMTiposNovedades(da)

         For Each din As Entidades.CRMTipoNovedadDinamico In en.Dinamicos
            din.IdTipoNovedad = en.IdTipoNovedad
         Next

         Select Case tipo
            Case TipoSP._I
               sqlC.CRMTiposNovedades_I(en.IdTipoNovedad,
                                        en.NombreTipoNovedad,
                                        en.UnidadDeMedida,
                                        en.UsuarioRequerido,
                                        en.UsuarioPorDefecto,
                                        en.ProximoContactoRequerido,
                                        en.PrimerOrdenGrilla,
                                        en.PrimerOrdenDesc,
                                        en.SegundoOrdenGrilla,
                                        en.SegundoOrdenDesc,
                                        en.VisualizaOtrasNovedades,
                                        en.VisualizaRevisionAdministrativa,
                                        en.PermiteBorrarComentarios,
                                        en.DiasProximoContacto,
                                        en.PermiteIngresarNumero,
                                        en.ReportaAvance,
                                        en.ReportaCantidad,
                                        en.LetrasHabilitadas,
                                        en.VerCambios,
                                        en.RequierePadre,
                                        en.Reporte,
                                        en.Embebido,
                                        en.CantidadCopias,
                                        en.SolapaPorDefecto,
                                        en.VisualizaSucursal)
               rDinamicos.Insertar(en.Dinamicos)
            Case TipoSP._U
               rDinamicos.Borrar(en.IdTipoNovedad)
               sqlC.CRMTiposNovedades_U(en.IdTipoNovedad,
                                        en.NombreTipoNovedad,
                                        en.UnidadDeMedida,
                                        en.UsuarioRequerido,
                                        en.UsuarioPorDefecto,
                                        en.ProximoContactoRequerido,
                                        en.PrimerOrdenGrilla,
                                        en.PrimerOrdenDesc,
                                        en.SegundoOrdenGrilla,
                                        en.SegundoOrdenDesc,
                                        en.VisualizaOtrasNovedades,
                                        en.VisualizaRevisionAdministrativa,
                                        en.PermiteBorrarComentarios,
                                        en.DiasProximoContacto,
                                        en.PermiteIngresarNumero,
                                        en.ReportaAvance,
                                        en.ReportaCantidad,
                                        en.LetrasHabilitadas,
                                        en.VerCambios,
                                        en.RequierePadre,
                                        en.Reporte,
                                        en.Embebido,
                                        en.CantidadCopias,
                                        en.SolapaPorDefecto,
                                        en.VisualizaSucursal)

               rDinamicos.Insertar(en.Dinamicos)
            Case TipoSP._D
               rDinamicos.Borrar(en.IdTipoNovedad)
               sqlC.CRMTiposNovedades_D(en.IdTipoNovedad)
         End Select

         da.CommitTransaction()
      Catch
         da.RollbakTransaction()
         Throw
      Finally
         da.CloseConection()
      End Try
   End Sub

   Private Sub CargarUno(ByVal o As Entidades.CRMTipoNovedad, ByVal dr As DataRow)
      With o
         .IdTipoNovedad = dr(Entidades.CRMTipoNovedad.Columnas.IdTipoNovedad.ToString()).ToString()
         .NombreTipoNovedad = dr(Entidades.CRMTipoNovedad.Columnas.NombreTipoNovedad.ToString()).ToString()
         .UnidadDeMedida = dr(Entidades.CRMTipoNovedad.Columnas.UnidadDeMedida.ToString()).ToString()
         .UsuarioRequerido = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.UsuarioRequerido.ToString()).ToString())
         .UsuarioPorDefecto = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.UsuarioPorDefecto.ToString()).ToString())
         .ProximoContactoRequerido = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.ProximoContactoRequerido.ToString()).ToString())
         .PrimerOrdenGrilla = dr(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenGrilla.ToString()).ToString()
         .PrimerOrdenDesc = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.PrimerOrdenDesc.ToString()).ToString())
         .SegundoOrdenGrilla = dr(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenGrilla.ToString()).ToString()
         .SegundoOrdenDesc = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.SegundoOrdenDesc.ToString()).ToString())
         .VisualizaOtrasNovedades = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.VisualizaOtrasNovedades.ToString()).ToString())
         .VisualizaRevisionAdministrativa = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.VisualizaRevisionAdministrativa.ToString()).ToString())
         .PermiteBorrarComentarios = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.PermiteBorrarComentarios.ToString()).ToString())
         .DiasProximoContacto = Integer.Parse(dr(Entidades.CRMTipoNovedad.Columnas.DiasProximoContacto.ToString()).ToString())
         .PermiteIngresarNumero = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.PermiteIngresarNumero.ToString()).ToString())
         .Dinamicos = New Reglas.CRMTiposNovedadesDinamicos().GetTodos(.IdTipoNovedad)
         .ReportaAvance = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.ReportaAvance.ToString()).ToString())
         .ReportaCantidad = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.ReportaCantidad.ToString()).ToString())
         .LetrasHabilitadas = dr(Entidades.CRMTipoNovedad.Columnas.LetrasHabilitadas.ToString()).ToString()
         .VerCambios = Boolean.Parse(dr(Entidades.CRMTipoNovedad.Columnas.VerCambios.ToString()).ToString())
         .RequierePadre = dr.Field(Of Boolean)(Entidades.CRMTipoNovedad.Columnas.RequierePadre.ToString())
         .Reporte = dr.Field(Of String)(Entidades.CRMTipoNovedad.Columnas.Reporte.ToString())
         .Embebido = dr.Field(Of Boolean)(Entidades.CRMTipoNovedad.Columnas.Embebido.ToString())
         .CantidadCopias = dr.Field(Of Integer)(Entidades.CRMTipoNovedad.Columnas.CantidadCopias.ToString())
         .SolapaPorDefecto = dr.Field(Of String)(Entidades.CRMTipoNovedad.Columnas.SolapaPorDefecto.ToString()).StringToEnum(Entidades.CRMTipoNovedad.SolapaPorDef.Comentarios)

         .VisualizaSucursal = dr(Entidades.CRMTipoNovedad.Columnas.VisualizaSucursal.ToString()).ToString()

      End With
   End Sub
#End Region

#Region "Metodos publicos"

   Public Function GetUno(idCRMTipoNovedad As String) As Entidades.CRMTipoNovedad
      Dim dt As DataTable = New SqlServer.CRMTiposNovedades(Me.da).CRMTiposNovedades_G1(idCRMTipoNovedad)
      Dim o As Entidades.CRMTipoNovedad = New Entidades.CRMTipoNovedad()
      If dt.Rows.Count > 0 Then
         Dim dr As DataRow = dt.Rows(0)
         Me.CargarUno(o, dt.Rows(0))
      End If
      Return o
   End Function

   'Public Function GetTodos() As List(Of Entidades.CRMTipoNovedad)
   '   Dim dt As DataTable = Me.GetAll()
   '   Dim o As Entidades.CRMTipoNovedad
   '   Dim oLis As List(Of Entidades.CRMTipoNovedad) = New List(Of Entidades.CRMTipoNovedad)
   '   For Each dr As DataRow In dt.Rows
   '      o = New Entidades.CRMTipoNovedad()
   '      Me.CargarUno(o, dr)
   '      oLis.Add(o)
   '   Next
   '   Return oLis
   'End Function

   Public Function GetTodos(reportaCantidad As Boolean) As List(Of Entidades.CRMTipoNovedad)
      Return CargaLista(New SqlServer.CRMTiposNovedades(da).CRMTiposNovedades_GA(reportaCantidad),
                        Sub(o, dr) CargarUno(o, dr), Function() New Entidades.CRMTipoNovedad())
   End Function

   Public Function GetTodos(idTipoNovedad As String) As List(Of Entidades.CRMTipoNovedad)
      Return GetTodos(idTipoNovedad, aplicaSeguridad:=False, conDinamicos:={})
   End Function

   Public Function GetTodos(idTipoNovedad As String, aplicaSeguridad As Boolean,
                            conDinamicos As Entidades.CRMTipoNovedad.TipoDinamico()) As List(Of Entidades.CRMTipoNovedad)
      Dim dt As DataTable
      If String.IsNullOrWhiteSpace(idTipoNovedad) Then
         dt = GetAll(aplicaSeguridad, conDinamicos)
      Else
         dt = GetOne(idTipoNovedad)
      End If

      Dim o As Entidades.CRMTipoNovedad
      Dim oLis As List(Of Entidades.CRMTipoNovedad) = New List(Of Entidades.CRMTipoNovedad)
      For Each dr As DataRow In dt.Rows
         o = New Entidades.CRMTipoNovedad()
         Me.CargarUno(o, dr)
         oLis.Add(o)
      Next
      Return oLis
   End Function

   Public Function GetOne(idTipoNovedad As String) As System.Data.DataTable
      Return New SqlServer.CRMTiposNovedades(Me.da).CRMTiposNovedades_GA1(aplicaSeguridad:=False, idTipoNovedad:=idTipoNovedad, conDinamicos:={})
   End Function

#End Region

End Class
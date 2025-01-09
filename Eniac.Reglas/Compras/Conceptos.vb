#Region "Option/Imports"
Option Explicit On
Option Strict On
Imports actual = Eniac.Entidades.Usuario.Actual
#End Region
Public Class Conceptos
   Inherits Eniac.Reglas.Base

#Region "Constructores"

   Public Sub New()
      Me.NombreEntidad = "Conceptos"
      da = New Datos.DataAccess()
   End Sub
   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.New()
      da = accesoDatos
   End Sub

#End Region

#Region "Overrides"

   Public Overrides Sub Insertar(ByVal entidad As Eniac.Entidades.Entidad)

      Dim concep As Entidades.Concepto = DirectCast(entidad, Entidades.Concepto)

      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Inserta(concep)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Inserta(ByVal conce As Eniac.Entidades.Concepto)

      'Inserto el Registro en la tabla Maestra
      Me.EjecutaSP(conce, TipoSP._I)


   End Sub

   Public Overrides Sub Actualizar(ByVal entidad As Eniac.Entidades.Entidad)
      Dim conce As Entidades.Concepto = DirectCast(entidad, Entidades.Concepto)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.Actualiza(conce)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Actualiza(ByVal conce As Eniac.Entidades.Concepto)
      Me.EjecutaSP(conce, TipoSP._U)
   End Sub

   Public Overrides Sub Borrar(ByVal entidad As Eniac.Entidades.Entidad)

      Dim conce As Entidades.Concepto = DirectCast(entidad, Entidades.Concepto)
      Try
         da.OpenConection()
         da.BeginTransaction()

         Me.EjecutaSP(conce, TipoSP._D)

         da.CommitTransaction()

      Catch ex As Exception
         da.RollbakTransaction()
         Throw ex
      Finally
         da.CloseConection()
      End Try
   End Sub

   Public Sub Borra(ByVal conce As Eniac.Entidades.Concepto)
      Me.EjecutaSP(conce, TipoSP._D)
   End Sub

   Public Overrides Function Buscar(ByVal entidad As Eniac.Entidades.Buscar) As DataTable
      Dim sql As SqlServer.Conceptos = New SqlServer.Conceptos(Me.da)
      Return sql.Buscar(entidad.Columna, entidad.Valor.ToString())
   End Function

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.Conceptos(Me.da).Conceptos_GA()
   End Function

#End Region

#Region "Metodos Privados"

   Private Sub EjecutaSP(ByVal conc As Entidades.Concepto, ByVal tipo As TipoSP)

      Dim sql As SqlServer.Conceptos = New SqlServer.Conceptos(Me.da)
      Select Case tipo
         Case TipoSP._I
            sql.Conceptos_I(conc.IdConcepto, conc.NombreConcepto, conc.IdRubroConcepto, conc.GrupoGastos,
                            conc.EsNoGravado, conc.Activo, conc.ImprimeProveedor, conc.ImprimeDetalleComprobante,
                            conc.IdProducto)

         Case TipoSP._U
            sql.Conceptos_U(conc.IdConcepto, conc.NombreConcepto, conc.IdRubroConcepto, conc.GrupoGastos,
                            conc.EsNoGravado, conc.Activo, conc.ImprimeProveedor, conc.ImprimeDetalleComprobante,
                            conc.IdProducto)

         Case TipoSP._D
            sql.Conceptos_D(conc.IdConcepto)
      End Select

   End Sub

#End Region

#Region "Metodos Publicos"

   Public Function GetCodigoMaximo() As Long
      Return New SqlServer.Conceptos(da).GetCodigoMaximo("IdConcepto", "Conceptos")
   End Function

   Private Sub CargarUno(o As Entidades.Concepto, dr As DataRow)
      With o
         .IdConcepto = Integer.Parse(dr("IdConcepto").ToString())
         .NombreConcepto = dr("NombreConcepto").ToString()
         .IdRubroConcepto = Integer.Parse(dr("IdRubroConcepto").ToString())
         .GrupoGastos = dr("GrupoGastos").ToString()
         If Not String.IsNullOrEmpty(dr("EsNoGravado").ToString()) Then
            .EsNoGravado = Boolean.Parse(dr("EsNoGravado").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("ImprimeProveedor").ToString()) Then
            .ImprimeProveedor = Boolean.Parse(dr("ImprimeProveedor").ToString())
         End If
         If Not String.IsNullOrEmpty(dr("ImprimeDetalleComprobante").ToString()) Then
            .ImprimeDetalleComprobante = Boolean.Parse(dr("ImprimeDetalleComprobante").ToString())
         End If
         .Activo = Boolean.Parse(dr("Activo").ToString())

         .IdProducto = dr(Entidades.Concepto.Columnas.IdProducto.ToString()).ToString()

      End With
   End Sub

   Public Function GetUno(ByVal idConcepto As Integer) As Entidades.Concepto
      Dim dt As DataTable = New SqlServer.Conceptos(da).Conceptos_G1(idConcepto)

      Dim oCon As Entidades.Concepto = New Entidades.Concepto()
      If dt.Rows.Count > 0 Then
         CargarUno(oCon, dt.Rows(0))
      End If
      Return oCon
   End Function

   Public Function GetTodos() As List(Of Entidades.Concepto)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(DirectCast(o, Entidades.Concepto), dr), Function() New Entidades.Concepto())
   End Function

   Public Function GetPorNombre(ByVal nombre As String) As DataTable
      Return New SqlServer.Conceptos(da).Conceptos_GA(0, nombre, True)
   End Function

   Public Function GetPorCodigo(ByVal IdConcepto As Integer) As DataTable
      Return New SqlServer.Conceptos(da).Conceptos_GA(IdConcepto, String.Empty, True)
   End Function

#End Region

End Class
Public Class TiposCheques
   Inherits Reglas.Base

#Region "Constructores"
   Public Sub New()
      Me.NombreEntidad = "TiposCheques"
      da = New Datos.DataAccess()
   End Sub

   Public Sub New(ByVal accesoDatos As Datos.DataAccess)
      Me.NombreEntidad = "TiposCheques"
      da = accesoDatos
   End Sub

#End Region

   Public Overrides Sub Insertar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._I))
   End Sub

   Public Overrides Sub Actualizar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._U))
   End Sub

   Public Overrides Sub Borrar(entidad As Eniac.Entidades.Entidad)
      EjecutaConTransaccion(Sub() Me.EjecutaSP(entidad, TipoSP._D))
   End Sub

   Public Overrides Function GetAll() As System.Data.DataTable
      Return New SqlServer.TiposCheques(da).TiposCheques_GA()
   End Function

   Private Sub EjecutaSP(entidad As Eniac.Entidades.Entidad, tipo As TipoSP)

      Dim en As Entidades.TiposCheques = DirectCast(entidad, Entidades.TiposCheques)
      Dim sql As SqlServer.TiposCheques = New SqlServer.TiposCheques(Me.da)

      Select Case tipo

         Case TipoSP._I
            sql.TiposCheques_I(en.IdTipoCheque, en.NombreTipoCheque, en.SolicitaNroOperacion)

         Case TipoSP._U
            sql.TiposCheques_U(en.IdTipoCheque, en.NombreTipoCheque, en.SolicitaNroOperacion)

         Case TipoSP._D
            sql.TiposCheques_D(en.IdTipoCheque)

      End Select

   End Sub

    Public Function GetUno(idTipoCheque As String) As Entidades.TiposCheques
        Return GetUno(idTipoCheque, AccionesSiNoExisteRegistro.Vacio)
    End Function

    Public Function GetUno(idTipoCheque As String, accion As AccionesSiNoExisteRegistro) As Entidades.TiposCheques
        Return CargaEntidad(New SqlServer.TiposCheques(Me.da).TiposCheques_G1(idTipoCheque),
                          Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TiposCheques(),
                          accion, Function() String.Format("No existe el tipo de cheque con ID {0}. Por favor, verifique.", idTipoCheque))
    End Function

    Private Sub CargarUno(o As Entidades.TiposCheques, dr As DataRow)
      With o
         .IdTipoCheque = dr.Field(Of String)(Entidades.TiposCheques.Columnas.IdTipoCheque.ToString())
         .NombreTipoCheque = dr.Field(Of String)(Entidades.TiposCheques.Columnas.NombreTipoCheque.ToString())
         .SolicitaNroOperacion = dr.Field(Of Boolean)(Entidades.TiposCheques.Columnas.SolicitaNroOperacion.ToString())
      End With
   End Sub

   Public Function GetTodos() As List(Of Entidades.TiposCheques)
      Return CargaLista(GetAll(), Sub(o, dr) CargarUno(o, dr), Function() New Entidades.TiposCheques())
   End Function


    'Public Function GetCodigoMaximo() As String

    '    Return New SqlServer.TiposCheques(Me.da).GetCodigoMaximo()
    'End Function

End Class

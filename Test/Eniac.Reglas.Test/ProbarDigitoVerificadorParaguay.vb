Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()> Public Class ProbarDigitoVerificadorParaguay

   <TestMethod()> Public Sub Probar100Rucs()
      Entidades.Usuario.Actual.CurrentUICulture = "es-PY"
      Reglas.Validaciones.Impositivo.ValidarDigitoVerificador.ResetInstancia()

      Dim rucResult As Dictionary(Of String, Validaciones.ValidacionResult) = New Dictionary(Of String, Validaciones.ValidacionResult)()
      Dim rucs As String() = {
                              "10607773",
                              "800913710",
                              "800912020",
                              "7777361",
                              "50753282",
                              "42155894",
                              "43561152",
                              "20683049",
                              "800034686",
                              "42435323",
                              "45172463",
                              "47979399",
                              "42252369",
                              "25197070",
                              "13904760",
                              "48815098",
                              "1364782",
                              "12897604",
                              "3772551",
                              "3508056",
                              "6859968",
                              "4612922",
                              "8330441",
                              "500457115",
                              "800483758",
                              "800802055",
                              "800258053",
                              "800538633",
                              "800517199",
                              "800623029",
                              "800748743",
                              "800346076",
                              "800477340",
                              "800615646",
                              "800846346",
                              "800175328",
                              "800734548",
                              "800289803",
                              "800591054",
                              "800377990",
                              "6773206",
                              "9408215",
                              "6818030",
                              "7909080",
                              "23194472",
                              "8567018",
                              "22876146",
                              "47373156",
                              "43565298",
                              "800529456",
                              "8037086",
                              "32154143",
                              "17833655",
                              "34142380",
                              "21624232",
                              "40093956",
                              "15162540",
                              "22024573",
                              "38450569",
                              "34142428",
                              "40093140",
                              "29383544",
                              "11762993",
                              "8883513",
                              "500457697",
                              "8891400",
                              "2516993",
                              "15783162",
                              "8379033",
                              "10986839",
                              "5671027",
                              "2661861",
                              "34944923",
                              "36929956",
                              "29072409",
                              "13204980",
                              "21868395",
                              "22534962",
                              "10810552",
                              "44665385",
                              "44390564",
                              "43383432",
                              "18927114",
                              "3329577",
                              "5408083",
                              "12829439",
                              "3332195",
                              "12829390",
                              "4159780",
                              "13166492",
                              "800270452",
                              "6907024",
                              "6907059",
                              "6907040",
                              "8157588",
                              "800109520",
                              "52761517",
                              "13614487",
                              "14333350",
                              "5560217",
                              "8060193",
                              "19302045",
                              ""
                             }

      For Each ruc As String In rucs
         If Not String.IsNullOrWhiteSpace(ruc) Then
            rucResult.Add(ruc, Reglas.Validaciones.Impositivo.ValidarDigitoVerificador.Instancia.Validar(ruc))
         End If
      Next

      Dim algunError As Boolean = False
      For Each result As KeyValuePair(Of String, Validaciones.ValidacionResult) In rucResult
         Console.WriteLine(String.Format("{0} : {1} - {2}", result.Key, result.Value.Error, result.Value.MensajeError))
         algunError = algunError Or result.Value.Error
      Next
      Assert.AreEqual(False, algunError)
   End Sub

End Class
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

/*

Video --> https://www.youtube.com/watch?v=Yp8uPxEn6Vg

*/

public class ConnectionController : MonoBehaviour
{
    // Este TAG nos permite ejecutar este metodo desde el inspector
    [ContextMenu("Test give response")]
    public async void TestGet()
    {
        // Instancio el cliente que usa el protocolo HTTP 
        var httpClient = new HttpClient(new JsonSerializationOption());

        // Set the API Url RASA
        var url_rasa = "http://localhost:5005/webhooks/rest/webhook";

        // Genero un form para guardar los valores a enviar en el POST
        WWWForm form = new WWWForm();

        // Agrego los campos del form
        form.AddField("sender", "juan");
        form.AddField("message", "Hola");

        var result = await httpClient.Post<Answer>(url_rasa, form);
    }
}

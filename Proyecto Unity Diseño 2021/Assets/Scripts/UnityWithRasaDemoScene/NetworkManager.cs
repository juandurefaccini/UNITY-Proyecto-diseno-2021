using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;

// Esta estructura ayuda a crear el objeto Json para ser enviado al servidor rasa
public class PostMessageJson
{
    public string message;
    public string sender;
}

[Serializable]
// RootReceiveMessageJson extrae las multiples respuestas que el bot puede dar
// Se usa para extraer multiples objetos json anidados dentro de un valor
public class RootReceiveMessageJson
{
    public ReceiveMessageJson[] messages;
}

[Serializable]
public class Custom
{
    public String text;
    public String vector;
}

[Serializable]
// ReceiveMessageJson extrae el valor del objeto json que se recibe del servidor rasa
// Se usa para extraer un solo mensaje devuelto por el bot
public class ReceiveMessageJson
{
    public string recipient_id;
    public Custom custom;
}

public class NetworkManager : MonoBehaviour
{
    public BotUI botUI;

    private const string rasa_url = "http://localhost:5005/webhooks/rest/webhook";
    public AnimationManager animationManager;


    public void SendMessageToRasa(GameObject receiver, string message)
    {
        // Va a ser llamado cuando el usuario presiona el botón de enviar mensaje
        // Creo un JSON para representar el mensaje del usuario
        PostMessageJson postMessage = new PostMessageJson
        {
            sender = receiver.name,
            message = message
        };

        string jsonBody = JsonUtility.ToJson(postMessage);

        // botUI solo reconoce user y bot de sender, no distintos usuarios DE MOMENTO
        botUI.UpdateDisplay("user", message, "text");


        // Creo una petición POST con los datos a enviar al servidor Rasa
        StartCoroutine(PostRequest(receiver, rasa_url, jsonBody));
    }

    private IEnumerator PostRequest(GameObject receiver, string url, string jsonBody)
    {
        // Va a crear una petición POST asíncrona al servidor Rasa y obtener la respuesta.
        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] rawBody = new System.Text.UTF8Encoding().GetBytes(jsonBody);
        request.uploadHandler = (UploadHandler)new UploadHandlerRaw(rawBody);
        request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        RootReceiveMessageJson recieveMessages = JsonUtility.FromJson<RootReceiveMessageJson>("{\"messages\":" + request.downloadHandler.text + "}");
        // receiver.GetComponent<Persona>();

        //Debug.Log(recieveMessages);
        Debug.Log(recieveMessages.messages[0].recipient_id);

        Debug.Log(recieveMessages.messages[0].custom.text);

        Debug.Log(recieveMessages.messages[0].custom.vector);

        // Agregar comportamiento de alterar animaciones
        var vector = recieveMessages.messages[0].custom.vector;
        animationManager.AnimateCharacter(vector, receiver);

        if (recieveMessages.messages[0].custom.text != null)//&& field.Name != "recipient_id")
        {
            botUI.UpdateDisplay("bot", receiver.name + ": " + recieveMessages.messages[0].custom.text, "text"); //messageType si o si text, solo muestra el contenido de la rta
        }

        //string recipient = recieveMessages.messages[0].text;
        //Custom cus = recieveMessages.messages[0].custom;


        //Debug.Log(recipient);

        //Debug.Log(cus.text);

        //Debug.Log(cus.vector);

        // Comento de aca para abajo porque hay que implementarlo de la nueva forma ////// IMPORTANTE

        //string animacionAEjecutar = data.Split('=')[0];
        //string mensaje = data.Split('=')[1];

        //UIManager.GetInstance().mostrarMensaje("CHAT: " + mensaje);
        //AnimationManager.playAnim(animacionAEjecutar, receiver.gameObject);

        //////////////////////////////////////////////////////////////////////////////////

        //UIManager.mostrarMensaje("CHAT: " + mensaje);
        //AnimationManager.playAnim(animacionAEjecutar, receiver.gameObject);
        // RecieveResponse(request.downloadHandler.text);
    }
}
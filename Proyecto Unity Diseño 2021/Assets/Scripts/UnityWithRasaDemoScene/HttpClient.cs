using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HttpClient
{
    private readonly ISerializationOption _serializationOption;

    public HttpClient(ISerializationOption serializationOption)
    {
        // Inyeccion de dependencias
        // En el constructor ya defino que objeto va a ser el encargado de de deserialziar lo que venga de la api
        _serializationOption = serializationOption;
    }

    // Este TAG nos permite ejecutar este metodo desde el inspector
    public async Task<TResultType> Get<TResultType>(string url)
    {
        try
        {
            // Instanciamos la solicitud GET
            using var www = UnityWebRequest.Get(url);

            // Determinamos el tipo de contenido del header
            www.SetRequestHeader("Content-Type", _serializationOption.ContentType);

            // Ejecutamos la solicitud
            var operation = www.SendWebRequest();

            // Esperamos a que se complete la solicitud
            while (!operation.isDone)
            {
                // Esperamos hasta que se complete la solicitud con un await
                await Task.Yield();
            }

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {www.error}");
            }

            var result = _serializationOption.Deserialize<TResultType>(www.downloadHandler.text);
            return result;
        }
        catch (System.Exception ex)
        {
            Debug.Log($"{nameof(Get)} failed {ex.Message}");
            return default;
        }
    }

    public async Task<TResultType> Post<TResultType>(string url, WWWForm form)
    {
        try
        {
            // Instanciamos la solicitud GET
            using var www = UnityWebRequest.Post(url, form);

            // Determinamos el tipo de contenido del header
            www.SetRequestHeader("Content-Type", _serializationOption.ContentType);

            // Ejecutamos la solicitud
            var operation = www.SendWebRequest();

            // Esperamos a que se complete la solicitud
            while (!operation.isDone)
            {
                // Esperamos hasta que se complete la solicitud con un await
                await Task.Yield();
            }

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"Error: {www.error}");
            }

            Debug.Log(www.downloadHandler.text);
            var result = _serializationOption.Deserialize<TResultType>(www.downloadHandler.text);
            return result;
        }
        catch (System.Exception ex)
        {
            Debug.Log($"{nameof(Post)} failed {ex.Message}");
            return default;
        }
    }

}

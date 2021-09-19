using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonSerializationOption : ISerializationOption
{
    public string ContentType => "application/json";

    public T Deserialize<T>(string text)
    {
        // Verificamos que la solicitud fue exitosa
        try
        {
            var result = JsonUtility.FromJson<T>(text);
            Debug.Log($"Success: {text}");
            return result;
        }
        catch (System.Exception ex)
        {
            Debug.Log($"{this} Could not parse respponse {text}. {ex.Message}");
            return default;
        }
    }
}

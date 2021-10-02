using UnityEngine;

public class Persona : MonoBehaviour
{
    public string nombre;
    public string mensaje;
    public GameObject otraPersona;

    public NetworkManager networkManager;

    [ContextMenu("Conversar")]
    private void Conversar()
    {
        Hablar(otraPersona, mensaje);
        // Mandarle a tal persona que haga tal animacion (MATE TOBI PEDRO)
        // Mostrar en consola el mensaje que vuelve de Rasa
    }

    public void Hablar(GameObject otraPersona, string mensaje)
    {
        networkManager.SendMessageToRasa(otraPersona, mensaje);
    }
}
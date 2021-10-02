using UnityEngine;
using UnityWithRasaDemoScene;

public class AnimationManager : MonoBehaviour
{
    // El chat se comunica conmigo para que me pueda hacer las animaciones, una vez obtenida la respuesta del network manager
    public EmotionInterpreter emotionInterpreter;

    private void Start()
    {
        emotionInterpreter = GetComponent<EmotionInterpreter>(); // Obtiene el componente hermano
    }
}
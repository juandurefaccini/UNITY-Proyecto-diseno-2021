using UnityEngine;
using UnityWithRasaDemoScene;
using AnimatorComposerStructures;

public class AnimationManager : MonoBehaviour
{
    // El chat se comunica conmigo para que me pueda hacer las animaciones, una vez obtenida la respuesta del network manager
    public EmotionInterpreter emotionInterpreter;

    public void AnimateCharacter(string vector, GameObject receiver)
    {
        emotionInterpreter = GetComponent<EmotionInterpreter>(); // Obtiene el componente hermano
        BlockQueue blockQueue = emotionInterpreter.GetBlockQueue(vector);
        // checkpoint :  Aca ya consegui la block queue para animar al reveiver
        receiver.GetComponent<AnimationComposer>().AddBlockQueue(blockQueue);
    }
}
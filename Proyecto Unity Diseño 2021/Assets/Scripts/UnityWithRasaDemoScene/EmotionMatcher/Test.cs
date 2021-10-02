using System;
using System.Collections.Generic;
using UnityEngine;
using UnityWithRasaDemoScene;
using AnimatorComposerStructures;


namespace UnityWithRasaDemoScene
{
    public class Test : MonoBehaviour
    {
        public ReceiveMessageJson mensaje;
        public EmotionInterpreter emotionInterpreter;
        private void Start()
        {
            BlockQueue conjGanador = emotionInterpreter.GetBlockQueue(mensaje);
        }

        [Serializable]
        // ReceiveMessageJson extrae el valor del objeto json que se recibe del servidor rasa
        // Se usa para extraer un solo mensaje devuelto por el bot
        public class ReceiveMessageJson
        {
            public string recipient_id;
            public Custom custom;
            [System.Serializable]
            public class Custom
            {
                public String text;
                public String[] vector;
            }
        }
    }
}
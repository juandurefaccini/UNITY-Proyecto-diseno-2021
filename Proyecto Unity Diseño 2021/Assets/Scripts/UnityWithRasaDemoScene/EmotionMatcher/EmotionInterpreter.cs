using System;
using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;
using System.Linq;

namespace UnityWithRasaDemoScene
{
    public class EmotionInterpreter : MonoBehaviour
    {
        private BibliotecaAnimaciones bibliotecaAnimaciones;
        private BlockQueueGenerator blockQueueGenerator;
        private EmotionDictonary emotionDictonary;
        // public TuplaScriptableObject[] Facialanim;
        // public Dictionary<String,Dictionary<String,List<TuplaScriptableObject>>> animations;

        public void Start()
        {
            BibliotecaAnimaciones.CargarAnimaciones();
        }

        public BlockQueue GetBlockQueue(string vector)
        {
            double[] parsedVector = ParseVector(vector); // Parse the vector
            List<TuplaScriptableObject> bestTriggers = new List<TuplaScriptableObject>(); // List of the best triggers
            string emocion = EmotionDictonary.GetEmotionBySum(parsedVector.Sum()); // Get the emotion by the sum of the vector
            Dictionary<string, List<TuplaScriptableObject>> triggers = BibliotecaAnimaciones.GetTriggersByEmocion(emocion); // Obtengo la animacion a partir del indice
            foreach (var capa in triggers)
            {
                TuplaScriptableObject animacion = GetBestMatchTrigger(capa.Value, parsedVector);

                if (animacion != null)
                {
                    bestTriggers.Add(animacion);
                }
            }
            return BlockQueueGenerator.GetBlockQueue(bestTriggers);
        }

        private TuplaScriptableObject GetBestMatchTrigger(List<TuplaScriptableObject> capa, double[] vector)
        {
            TuplaScriptableObject bestTrigger = null;
            if (capa.Count > 0)
            {
                List<TuplaScriptableObject> lista_copia = new List<TuplaScriptableObject>(capa);
                bestTrigger = lista_copia.Select(q => new { Matching = diferencia(q.Vector, vector), Tupla = q }).OrderBy(q => q.Matching).First().Tupla;
            }
            else
            {
                Debug.Log("NO EXISTEN ANIMACIONES PARA ESA EMOCION Y CAPA");
            }
            return bestTrigger;
        }

        private double diferencia(double[] v, double[] vector)
        {
            double diferencia = 0;

            for (int i = 0; i < 5; ++i)
            {
                diferencia += Math.Abs(vector[i] - v[i]);
            }

            return diferencia;
        }

        // Depende de algo del idioma de la maquina en la que se este ejecutando, si no anda con una proba con la otra
        private double[] ParseVector(string vector)
        {
            var aux = vector.Substring(1, vector.Length - 2);
            string[] csv_input = aux.Split(',');
            double[] res = new double[5];
            for (int i = 0; i < 5; i++)
            {
                // res[i] = Convert.ToDouble(csv_input[i].Replace('.', ','));
                res[i] = Convert.ToDouble(csv_input[i]);  // Segunda opcion
            }
            return res;
        }
    }
}


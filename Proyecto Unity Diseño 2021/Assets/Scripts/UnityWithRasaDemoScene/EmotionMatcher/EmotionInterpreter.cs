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
        public TuplaScriptableObject[] Facialanim;

        public BlockQueue GetBlockQueue(string vector)
        {
            double[] parsedVector = ParseVector(vector); // Parse the vector
            List<TuplaScriptableObject> bestTriggers = new List<TuplaScriptableObject>(); // List of the best triggers
            string emocion = emotionDictonary.GetEmotionBySum(parsedVector.Sum()); // Get the emotion by the sum of the vector
            Dictionary<string, List<TuplaScriptableObject>> triggers = bibliotecaAnimaciones.GetTriggersByEmocion(emocion); // Obtengo la animacion a partir del indice
            foreach (List<TuplaScriptableObject> lista in triggers.Values)
            {
                bestTriggers.Add(GetBestMatchTrigger(lista, parsedVector));
            }
            return blockQueueGenerator.GetBlockQueue(bestTriggers);
        }

        private TuplaScriptableObject GetBestMatchTrigger(List<TuplaScriptableObject> lista, double[] vector)
        {
            List<TuplaScriptableObject> lista_copia = new List<TuplaScriptableObject>(lista);
            TuplaScriptableObject bestTrigger = lista_copia.Select(q => new { Matching = diferencia(q.Vector, vector), Tupla = q }).OrderBy(q => q.Matching).First().Tupla;
            return bestTrigger;
        }

        private double diferencia(double[] v, double[] vector)
        {
            double aux = System.Math.Abs(vector[0] - v[0] + vector[1] - v[1] + vector[2] - v[2] + vector[3] - v[3] + vector[4] -
                                  v[4]);
            return aux;
        }


        private double[] ParseVector(string vector)
        {
            var aux = vector.Substring(1, vector.Length - 2);
            string[] csv_input = aux.Split(',');
            double[] res = new double[5];
            for (int i = 0; i < 5; i++)
            {
                res[i] = Convert.ToDouble(csv_input[i]);
            }
            return res;
        }
    }
}


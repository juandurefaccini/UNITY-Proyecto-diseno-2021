using System;
using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

namespace UnityWithRasaDemoScene
{
    public class EmotionInterpreter : MonoBehaviour
    {
        public TuplaScriptableObject[] anim;
        public TuplaScriptableObject[] Facialanim;

        private void Start()
        {
            // anim = Resources.LoadAll("ScriptableObjects/TriggersEmotions", typeof(TuplaScriptableObject)) as TuplaScriptableObject[];
        }

        public BlockQueue GetBlockQueue(string vector)
        {
            var parsedVector = ParseVector(vector);
            List<Tupla> conjGanador = MatchingVector(parsedVector, new List<TuplaScriptableObject>(anim));
            String triggerFacial = MatchingFacial(parsedVector, new List<TuplaScriptableObject>(Facialanim));
            return BlockQueueGenerator.GetBlockQueue(conjGanador, triggerFacial);
        }

        private String MatchingFacial(double[] vector, List<TuplaScriptableObject> facialAnims)
        {
            TuplaScriptableObject sol1 = new TuplaScriptableObject()
            {
                Vector = new double[] { 10, 10, 10, 10, 10 },
                tupla = new Tupla()
                {
                    Trigger = null,
                    Layer = null,
                }

            };
            foreach (TuplaScriptableObject tupla in facialAnims)
            {
                if (diferencia(vector, tupla.Vector) < diferencia(vector, sol1.Vector))
                {
                    sol1 = tupla;
                }
            }
            return sol1.tupla.Trigger;
        }

        public double diferencia(double[] v, double[] vector)
        {
            double aux = System.Math.Abs(vector[0] - v[0] + vector[1] - v[1] + vector[2] - v[2] + vector[3] - v[3] + vector[4] -
                                  v[4]);
            return aux;
        }

        public List<Tupla> MatchingVector(double[] vector, List<TuplaScriptableObject> lista)
        {
            TuplaScriptableObject sol1 = new TuplaScriptableObject()
            {
                Vector = new double[] { 10, 10, 10, 10, 10 },
                tupla = new Tupla()
                {
                    Trigger = null,
                    Layer = null,
                }

            };
            TuplaScriptableObject sol2 = new TuplaScriptableObject()
            {
                Vector = new double[] { 10, 10, 10, 10, 10 },
                tupla = new Tupla()
                {
                    Trigger = null,
                    Layer = null,
                }
            };
            foreach (TuplaScriptableObject t in lista)
            {
                if (diferencia(vector, t.Vector) < diferencia(vector, sol1.Vector))
                {
                    sol1 = t;
                }
                else if (diferencia(vector, t.Vector) < diferencia(vector, sol2.Vector))
                {
                    sol2 = t;
                }
            }

            List<Tupla> aux = new List<Tupla>();
            if (sol1.tupla.Trigger != null)
            {
                aux.Add(sol1.tupla);
            }
            if (sol2.tupla.Trigger != null)
            {
                aux.Add(sol2.tupla);
            }
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


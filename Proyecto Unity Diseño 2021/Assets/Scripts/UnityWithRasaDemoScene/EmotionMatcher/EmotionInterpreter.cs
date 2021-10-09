using System;
using System.IO; // Para directory
using System.Linq; // Para parsear el nombre de la carpeta de un path
using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

namespace UnityWithRasaDemoScene
{
    public class EmotionInterpreter : MonoBehaviour
    {
        public TuplaScriptableObject[] anim;
        public TuplaScriptableObject[] Facialanim;
        public Dictionary<String,Dictionary<String,List<TuplaScriptableObject>>> animations;

        private void Start()
        {
            //Cargar un mapa de layers
            animations = new Dictionary<String,Dictionary<String,List<TuplaScriptableObject>>>();
            String animationpath = Directory.GetCurrentDirectory();
            animationpath = animationpath + @"\Assets\Resources\ScriptableObjects\TriggersEmotions"; // @ me deja insertar \ sin que se considere especial
            string[] layerEntries = Directory.GetDirectories(animationpath);
            //Por cada layer en Resources/ScriptableObjects/TriggersEmotions
            foreach (String layerpath in layerEntries)
            {
                String layer = layerpath.Split(Path.DirectorySeparatorChar).Last();
                animations.Add(layer, new Dictionary<String,List<TuplaScriptableObject>>());
                string[] emotionEntries = Directory.GetDirectories(layerpath);
                //Por cada emocion en una layer, cargar su coleccion de scriptable objects
                foreach (String emotionpath in emotionEntries)
                {
                        String emotion = emotionpath.Split(Path.DirectorySeparatorChar).Last();
                        animations[layer].Add(emotion, new List<TuplaScriptableObject>());
                        String resourcespath = @"ScriptableObjects\TriggersEmotions";
                        try // No es necesario, ahora LoadAll retorna una lista vacia y no null.
                        {
                            TuplaScriptableObject[] listTuplas = (TuplaScriptableObject[])Resources.LoadAll<TuplaScriptableObject>(resourcespath + @"\" + layer + @"\" + emotion);
                            foreach (TuplaScriptableObject tupla in listTuplas)
                            {
                                animations[layer][emotion].Add(tupla);
                            }
                            Debug.Log(layer + @"\" + emotion + " posee " + animations[layer][emotion].Count + " tuplas");
                        }
                        catch 
                        {
                            Debug.Log("No hay animaciones para " + layer + " en la emocion " + emotion);
                        }
                }
            }

        }

        public BlockQueue GetBlockQueue(string vector)
        {
            var parsedVector = ParseVector(vector);
            List<TuplaScriptableObject> conjGanador = MatchingVector(parsedVector, new List<TuplaScriptableObject>(anim));
            String triggerFacial = MatchingFacial(parsedVector, new List<TuplaScriptableObject>(Facialanim));
            return BlockQueueGenerator.GetBlockQueue(conjGanador);
        }

        private String MatchingFacial(double[] vector, List<TuplaScriptableObject> facialAnims)
        {
            TuplaScriptableObject sol1 = new TuplaScriptableObject()
            {
                Vector = new double[] { 10, 10, 10, 10, 10 },
            };
            foreach (TuplaScriptableObject tupla in facialAnims)
            {
                if (diferencia(vector, tupla.Vector) < diferencia(vector, sol1.Vector))
                {
                    sol1 = tupla;
                }
            }
            return sol1.Trigger;
        }

        public double diferencia(double[] v, double[] vector)
        {
            double aux = System.Math.Abs(vector[0] - v[0] + vector[1] - v[1] + vector[2] - v[2] + vector[3] - v[3] + vector[4] -
                                  v[4]);
            return aux;
        }

        public List<TuplaScriptableObject> MatchingVector(double[] vector, List<TuplaScriptableObject> lista)
        {
            TuplaScriptableObject sol1 = new TuplaScriptableObject()
            {
                Vector = new double[] { 10, 10, 10, 10, 10 },
                Trigger= null,
            };
            TuplaScriptableObject sol2 = new TuplaScriptableObject()
            {
                Vector = new double[] { 10, 10, 10, 10, 10 },
                Trigger= null,
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

            List<TuplaScriptableObject> aux = new List<TuplaScriptableObject>();
            if (sol1.Trigger != null)
            {
                aux.Add(sol1);
            }
            if (sol2.Trigger != null)
            {
                aux.Add(sol2);
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


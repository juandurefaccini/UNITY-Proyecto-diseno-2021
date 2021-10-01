using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWithRasaDemoScene;

namespace UnityWithRasaDemoScene
{
    public class EmotionMatching : MonoBehaviour
    {
        public List<TuplaScriptableObject> anim;
    
        // Start is called before the first frame update
        void Start()
        {

        }
    
        // Update is called once per frame
        public List<Tupla> ObtenerConjGanador(Test.ReceiveMessageJson mensaje)
        {
            double[] bigFive= new double[5];
            double doubleVal = 0;
            for (int i = 0; i < 5; i++)
            {
                doubleVal = Convert.ToDouble(mensaje.custom.vector[i]);
                bigFive[i] = doubleVal;
            }
    
            List<Tupla> conjGanador = MatchingVector(bigFive, anim);
            return conjGanador;
        }
        public double diferencia(double[] v, double[] vector)
        {
            double aux = System.Math.Abs(vector[0] - v[0] + vector[1] - v[1] + vector[2] - v[2] + vector[3] - v[3] + vector[4] -
                                  v[4]);
            return aux;
        }
        
        public List<Tupla> MatchingVector(double[] vector, List<TuplaScriptableObject> lista)
        {
            TuplaScriptableObject sol1= new TuplaScriptableObject()
            {
                Vector=new double[]{10, 10, 10 ,10 ,10},
                tupla= new Tupla()
                {
                    Trigger = null,
                    Layer = null,
                }
             
            };
            TuplaScriptableObject sol2= new TuplaScriptableObject()
            {
                Vector=new double[]{10, 10, 10 ,10 ,10},
                tupla= new Tupla()
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
                }else if (diferencia(vector, t.Vector) < diferencia(vector, sol2.Vector))
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
    
        
    }
}


using System;
using System.IO; // Para directory
using System.Linq; // Para parsear el nombre de la carpeta de un path
using System.Collections.Generic;
using UnityEngine;
using AnimatorComposerStructures;

namespace UnityWithRasaDemoScene
{
    public class BibliotecaAnimaciones
    {
        public static Dictionary<string,Dictionary<string,List<TuplaScriptableObject>>> animations;

        // public BibliotecaAnimaciones()
        // {

        // }
        public static void CargarAnimaciones()
        {
            //Cargar un mapa de layers
            animations = new Dictionary<string,Dictionary<string,List<TuplaScriptableObject>>>();
            string animationpath = Directory.GetCurrentDirectory();
            animationpath = animationpath + "/Assets/Resources/ScriptableObjects/TriggersEmotions"; // @ me deja insertar \ sin que se considere especial
            string[] layerEntries = Directory.GetDirectories(animationpath);
            //Por cada layer en Resources/ScriptableObjects/TriggersEmotions
            foreach (string layerpath in layerEntries)
            {
                string layer = layerpath.Split(Path.DirectorySeparatorChar).Last();
                animations.Add(layer, new Dictionary<string,List<TuplaScriptableObject>>());
                string[] emotionEntries = Directory.GetDirectories(layerpath);
                //Por cada emocion en una layer, cargar su coleccion de scriptable objects
                foreach (string emotionpath in emotionEntries)
                {
                    string emotion = emotionpath.Split(Path.DirectorySeparatorChar).Last();
                    animations[layer].Add(emotion, new List<TuplaScriptableObject>());
                    string resourcespath = "ScriptableObjects/TriggersEmotions";
                    try // No es necesario, ahora LoadAll retorna una lista vacia y no null.
                    {
                        TuplaScriptableObject[] listTuplas = (TuplaScriptableObject[])Resources.LoadAll<TuplaScriptableObject>(resourcespath + "/" + layer + "/" + emotion);
                        foreach (TuplaScriptableObject tupla in listTuplas)
                        {
                            animations[layer][emotion].Add(tupla);
                        }
                        Debug.Log(layer + @"/" + emotion + " posee " + animations[layer][emotion].Count + " tuplas");
                    }
                    catch 
                    {
                        Debug.Log("No hay animaciones para " + layer + " en la emocion " + emotion);
                    }
                }
            }
        }

        public static Dictionary<string, List<TuplaScriptableObject>> GetTriggersByEmocion(string emocion) // Object --> Nuevo scriptable Object
        {
            Dictionary<string, List<TuplaScriptableObject>> retorno = new Dictionary<string, List<TuplaScriptableObject>>();
            Debug.Log(emocion);
            // layer es de tipo <string, Dictionary> 
            foreach (var layer in animations) 
            {
                retorno.Add(layer.Key, animations[layer.Key][emocion]);
            }
            return retorno; 
        }
    }
}
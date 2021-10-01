using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityWithRasaDemoScene;

namespace UnityWithRasaDemoScene
{
    [Serializable]
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Tupla", order = 1)]
    public class Tupla : ScriptableObject
    {
        public string Trigger;
        public string Layer;

    }
}

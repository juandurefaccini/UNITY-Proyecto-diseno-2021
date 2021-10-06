using System;

namespace UnityWithRasaDemoScene
{
    internal class EmotionDictonary
    {
        public EmotionDictonary()
        {

        }
        string[] emotions = new string[] { "anger", "disgust", "fear", "joy", "sadness" };

        public string GetEmotionBySum(double sum)
        {
            int index = (int)sum;
            if (sum < 0 || sum > emotions.Length) throw new InvalidOperationException("Suma de vector invalida");
            return emotions[index];
        }
    }
}
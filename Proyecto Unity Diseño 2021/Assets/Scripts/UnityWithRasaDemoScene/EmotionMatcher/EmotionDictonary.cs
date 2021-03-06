using System;

namespace UnityWithRasaDemoScene
{
    internal class EmotionDictonary
    {
        public EmotionDictonary()
        {

        }
        static string[] emotions = new string[] { "Enojo", "Miedo", "Alegria", "Sorpresa", "Confianza" };

        public static string GetEmotionBySum(double sum)
        {
            int index = (int)sum;
            if (sum < 0 || sum > emotions.Length) throw new InvalidOperationException("Suma de vector invalida");
            return emotions[index];
        }
    }
}
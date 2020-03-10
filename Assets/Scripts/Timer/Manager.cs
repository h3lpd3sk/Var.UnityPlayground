using System.Collections;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Events;

namespace Timer
{
    public static class Manager
    {
        public static event UnityAction OnTick;
        private static bool IsRunning = true;

        static Manager()
        {
            var behaviour = StaticGameObject.behaviour;
            behaviour.StartCoroutine(Tick());
        }

        private static IEnumerator Tick()
        {
            for (;IsRunning;)
            {
                yield return new WaitForSeconds(0.25f);
                OnTick?.Invoke();
            }
        }
    }
}
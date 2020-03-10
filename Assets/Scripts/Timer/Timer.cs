using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Timer
{
    public class Timer
    {
        private const string DefaultFormat = "mm\\:ss\\:ff";
        public event UnityAction<string> OnTick;
        public event UnityAction OnComplete;
        private DateTime expires;
        private string format;

        public Timer(TimeSpan timeSpan, string formatting = DefaultFormat) : this(DateTime.UtcNow.Add(timeSpan), formatting)
        {}

        public Timer(DateTime dateTime, string formatting = DefaultFormat)
        {
            format = formatting;
            expires = dateTime;
            Manager.OnTick += Tick;
        }

        public void Tick()
        {
            var now = DateTime.UtcNow;
            if (expires <= now)
            {
                Manager.OnTick -= Tick;
                OnComplete?.Invoke();
            }

            OnTick?.Invoke((expires - DateTime.UtcNow).ToString(format));
        }

        // Start
        // Stop
    }
}
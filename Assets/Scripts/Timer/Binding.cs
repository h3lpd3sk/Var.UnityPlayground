using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using System;
using UnityEngine.Events;
using TMPro;

namespace Timer {
    
    public class Binding : MonoBehaviour
    {
        private Timer timer;
        
        [SerializeField]
        private TextMeshProUGUI text = null;
        
        private void Awake()
        {
            timer = new Timer(new TimeSpan(0, 1, 30));
            timer.OnTick += (remaining) =>
            {
                if (text == null)
                    return;
                text.text = remaining;
            };
            timer.OnComplete += () => Debug.Log("Done...");
        }
    }
}

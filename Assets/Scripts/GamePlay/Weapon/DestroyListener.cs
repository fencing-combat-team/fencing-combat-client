using System;
using UnityEngine;

namespace GamePlay
{
    public class DestroyListener : MonoBehaviour
    {
        public event Action Destroy;

        private void OnDestroy()
        {
            Destroy?.Invoke();
        }
    }
}
using UnityEngine;

namespace TheDonnut.Actionables
{
    public abstract class Actionable : MonoBehaviour
    {
        public string Name = "";
        public float TriggerSize = 1;
        public abstract void Actionate();

        private void Start()
        {
            BoxCollider trigger = gameObject.AddComponent<BoxCollider>();
            trigger.isTrigger = true;
            trigger.size = Vector3.one * TriggerSize;
        }
    }
}
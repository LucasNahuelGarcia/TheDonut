using UnityEngine;

namespace TheDonnut.Actionables
{
    public abstract class Actionable : MonoBehaviour
    {
        public string Name = "";
        public abstract void Actionate();
    }
}
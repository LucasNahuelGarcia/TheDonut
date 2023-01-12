using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheDonnut.Actionable
{
    public abstract class Actionable : MonoBehaviour
    {
        public string Name = "";
        public abstract void Actionate();
    }
}
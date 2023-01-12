using UnityEngine;

namespace TheDonnut.Actionables
{
    public class Note : Actionable
    {
        [SerializeField] string text = "";


        public override void Actionate()
        {
            Debug.Log(text);
        }
    }
}
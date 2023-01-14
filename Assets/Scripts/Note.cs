using UnityEngine;

namespace TheDonnut.Actionables
{
    public class Note : Actionable
    {
        [SerializeField] [TextArea(3, 10)] string text = "";


        public override void Actionate()
        {
            Debug.Log(text);
        }
    }
}
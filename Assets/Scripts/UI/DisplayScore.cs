using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    public class DisplayScore
    {
        private Text _text;

        public DisplayScore()
        {
            _text = Object.FindObjectOfType<Text>();
        }

        public void Display(int value)
        {
            _text.text = $"Вы набрали {value} очков";        
        }
    }
}

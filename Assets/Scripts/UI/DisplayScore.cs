using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    public class DisplayScore
    {
        private Image _image;
        private float _value = 0;

        public DisplayScore()
        {
            _image = Object.FindObjectOfType<Image>();
        }

        public void Display(float value)
        {
            _value += value / 100;
            Debug.Log(_value);
            _image.fillAmount = _value;        
        }
    }
}

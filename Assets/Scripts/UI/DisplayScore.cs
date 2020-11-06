using UnityEngine.UI;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class DisplayScore
    {
        private Image _image;

        public DisplayScore(GameObject image)
        {
            _image = image.GetComponent<Image>();
            _image.fillAmount = 0.0f;
        }

        public void Display(float value)
        {
            _image.fillAmount = value;        
        }
    }
}

using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    public class DisplayScore
    {
        private Image _image;

        public DisplayScore()
        {
           
        }

        public void Display(float value)
        {
            _image.fillAmount = value;        
        }
    }
}

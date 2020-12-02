using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    public class RestartButtonInitiaizator
    {
        private Button _restartButton;

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var canvas = GameObject.FindObjectOfType<Canvas>();
                    Button buttonObject = Resources.Load<Button>("RestartButton");
                    _restartButton = Object.Instantiate(buttonObject, canvas.transform);
                }

                return _restartButton;
            }
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    internal class DisplayWinGame
    {
        private Text _endGameText;

        public DisplayWinGame(GameObject text)
        {
            _endGameText = text.GetComponent<Text>();
        }

        public void СongratulationWinText(float value)
        {
            _endGameText.text = $"Вы победили, набрав {value} очков!";
        }
    }
}

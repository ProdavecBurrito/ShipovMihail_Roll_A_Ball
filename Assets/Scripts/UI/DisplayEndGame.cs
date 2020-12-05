using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    internal class DisplayEndGame
    {
        private Text _endGameText;

        public DisplayEndGame(GameObject text)
        {
            _endGameText = text.GetComponent<Text>();
        }

        public void GameOver(string name, Color color)
        {
            _endGameText.text = $"Вы проиграли. Вас убил {name} {color} цвета";
        }
    }
}

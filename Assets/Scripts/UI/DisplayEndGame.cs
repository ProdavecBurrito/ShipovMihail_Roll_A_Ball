using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    class DisplayEndGame
    {
        private Text _endGameText;

        public DisplayEndGame(Text finishedGameText)
        {
            _endGameText = finishedGameText;
            _endGameText.text = string.Empty;
        }

        public void GameOver(object value, CaughtPlayerEventArgs args)
        {
            _endGameText.text = $"Вы проиграли. Вас убил{((BadBonus)value).name} {args.Color} цвета";
        }
    }
}

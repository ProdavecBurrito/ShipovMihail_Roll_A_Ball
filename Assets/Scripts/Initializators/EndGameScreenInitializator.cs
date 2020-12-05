using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class EndGameScreenInitializator
    {
        private GameObject _endGameScreen;

        public GameObject GetEndGame
        {
            get
            {
                if (_endGameScreen == null)
                {
                    var canvas = GameObject.FindObjectOfType<Canvas>();
                    var endObject = Resources.Load<GameObject>("GameOver");
                    _endGameScreen = Object.Instantiate(endObject, canvas.transform);
                }

                return _endGameScreen;
            }
        }
    }
}

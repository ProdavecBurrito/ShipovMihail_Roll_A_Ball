using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class WinGameScreenInitializator
    {
        private GameObject _winGame;

        public GameObject GetWinGame
        {
            get
            {
                if (_winGame == null)
                {
                    var canvas = GameObject.FindObjectOfType<Canvas>();
                    var winObject = Resources.Load<GameObject>("WinGame");
                    _winGame = Object.Instantiate(winObject, canvas.transform);
                }

                return _winGame;
            }
        }
    }
}

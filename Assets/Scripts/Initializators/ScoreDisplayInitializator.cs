using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class ScoreDisplayInitializator
    {
        private GameObject _scoreDisplay;

        public GameObject GetScoreDisplay
        {
            get
            {
                if (_scoreDisplay == null)
                {
                    var canvas = GameObject.FindObjectOfType<Canvas>();
                    var scoreObject = Resources.Load<GameObject>("Score");
                    _scoreDisplay = GameObject.Instantiate(scoreObject, canvas.transform);
                }

                return _scoreDisplay;
            }
        }
    }
}

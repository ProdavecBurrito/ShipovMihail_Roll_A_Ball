using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    public class References
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Animator _cameraAnimator;
        private Canvas _canvas;
        private GameObject _endGame;
        private GameObject _winGame;
        private GameObject _score;
        private Button _restartButton;

        internal PlayerBall GetPlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    PlayerBall loadingPlayer = Resources.Load<PlayerBall>("Player");
                    _playerBall = Object.Instantiate(loadingPlayer);
                }

                return _playerBall;
            }
        }

        internal Camera GetMainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                    _cameraAnimator = _mainCamera.GetComponent<Animator>();
                }

                return _mainCamera;
            }
        }

        public Animator GetCameraAnimator
        {
            get
            {
                if (_cameraAnimator == null && _mainCamera != null)
                {
                    _cameraAnimator = _mainCamera.GetComponent<Animator>();
                }

                return _cameraAnimator;
            }
        }

        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }

                return _canvas;
            }
        }

        public GameObject Score
        {
            get
            {
                if (_score == null)
                {
                    var scoreObject = Resources.Load<GameObject>("Score");
                    _score = Object.Instantiate(scoreObject, Canvas.transform);
                }

                return _score;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var endObject = Resources.Load<GameObject>("GameOver");
                    _endGame = Object.Instantiate(endObject, Canvas.transform);
                }

                return _endGame;
            }
        }

        public GameObject WinGame
        {
            get
            {
                if (_winGame == null)
                {
                    var winObject = Resources.Load<GameObject>("WinGame");
                    _winGame = Object.Instantiate(winObject, Canvas.transform);
                }

                return _winGame;
            }
        }

        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    Button buttonObject = Resources.Load<Button>("RestartButton");
                    _restartButton = Object.Instantiate(buttonObject, Canvas.transform);
                }

                return _restartButton;
            }
        }
    }
}

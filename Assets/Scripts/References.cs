using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ShipovMihail_Roll_A_Boll
{
    public class References
    {
        private PlayerEffects _playerEffects;
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Animator _cameraAnimator;
        private Canvas _canvas;
        private GameObject _endGame;
        private GameObject _winGame;
        private GameObject _score;
        private Button _restartButton;
        private List<SpeedBonusController> _speedBonus;
        private List<ReduceSpeedController> _reduceSpeed;
        private List<GoodBonusController> _goodBonuses;
        private List<BadBonusController> _badBonuses;

        internal List<SpeedBonusController> GetSpeedBonus
        {
            get
            {
                if (_speedBonus == null)
                {
                    _speedBonus = new List<SpeedBonusController>();
                    var speedBonusObject = Resources.Load<GameObject>("SpeedBonus");
                    var speedBonusInst = Object.Instantiate(speedBonusObject);
                    var speedBonusDivider = speedBonusInst.GetComponentsInChildren<SpeedBonusController>();
                    foreach (var item in speedBonusDivider)
                    {
                        _speedBonus.Add(item);
                    }
                }

                return _speedBonus;
            }
        }

        internal List<ReduceSpeedController> GetReduceSpeedBonuses
        {
            get
            {
                if (_reduceSpeed == null)
                {
                    _reduceSpeed = new List<ReduceSpeedController>();
                    var reduceSpeedBonusObject = Resources.Load<GameObject>("ReduceSpeedBonus");
                    var reduceSpeedBonusInst = Object.Instantiate(reduceSpeedBonusObject);
                    var reduceSpeedBonusDivider = reduceSpeedBonusInst.GetComponentsInChildren<ReduceSpeedController>();
                    for (int i = 0; i < reduceSpeedBonusDivider.Length; i++)
                    {
                        _reduceSpeed.Add(reduceSpeedBonusDivider[i]);
                    }
                }

                return _reduceSpeed;
            }
        }

        internal PlayerEffects GetPlayerEffects
        {
            get
            {
                if (_playerEffects == null)
                {
                    _playerEffects = new PlayerEffects();
                }

                return _playerEffects;
            }
        }

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

        internal List<GoodBonusController> GetGoodBonuses
        {
            get
            {
                if (_goodBonuses == null)
                {
                    _goodBonuses = new List<GoodBonusController>();
                    var goodBonusObject = Resources.Load<GameObject>("GoodBonus");
                    var goodBonusInst = Object.Instantiate(goodBonusObject);
                    var goodBonusDivider = goodBonusInst.GetComponentsInChildren<GoodBonusController>();
                    foreach (var item in goodBonusDivider)
                    {
                        _goodBonuses.Add(item);   
                    }
                }

                return _goodBonuses;
            }
        }

        internal List<BadBonusController> GetBadBonus
        {
            get
            {
                if (_badBonuses == null)
                {
                    _badBonuses = new List<BadBonusController>();
                    var badBonusObject = Resources.Load<GameObject>("BadBonus");
                    var badBonusInst = Object.Instantiate(badBonusObject);
                    var badBonusDivider = badBonusInst.GetComponentsInChildren<BadBonusController>();
                    foreach (var item in badBonusDivider)
                    {
                        _badBonuses.Add(item);
                    }
                }

                return _badBonuses;
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

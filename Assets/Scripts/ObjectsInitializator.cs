using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ShipovMihail_Roll_A_Boll
{
    public class ObjectsInitializator
    {
        private PlayerEffects _playerEffects;
        private PlayerBall _playerBall;
        private CameraController _cameraController;
        private ListIUpdateObjects _updatingObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayWinGame _displayWin;
        private DisplayScore _displayScore;
        private InputController _inputController;
        private References _reference;
        private List<GoodBonusController> _goodBonuses;
        private List<BadBonusController> _badBonuses;
        private List<GameObject> _savingObjects;
        private int _totalScoreObjects;

        private float _currentScore;

        internal PlayerEffects PlayerEffects { get => _playerEffects; private set => _playerEffects = value; }
        internal PlayerBall PlayerBall { get => _playerBall; private set => _playerBall = value; }
        internal CameraController CameraController { get => _cameraController; private set => _cameraController = value; }
        internal ListIUpdateObjects UpdatingObjects { get => _updatingObjects; private set => _updatingObjects = value; }
        internal DisplayEndGame DisplayEndGame { get => _displayEndGame; private set => _displayEndGame = value; }
        internal DisplayWinGame DisplayWin { get => _displayWin; private set => _displayWin = value; }
        public DisplayScore DisplayScore { get => _displayScore; private set => _displayScore = value; }
        internal InputController InputController { get => _inputController; private set => _inputController = value; }
        public References Reference { get => _reference; private set => _reference = value; }
        internal List<GoodBonusController> GoodBonuses { get => _goodBonuses; private set => _goodBonuses = value; }
        internal List<BadBonusController> BadBonuses { get => _badBonuses; private set => _badBonuses = value; }
        public List<GameObject> SavingObjects { get => _savingObjects; private set => _savingObjects = value; }
        public int TotalScoreObjects { get => _totalScoreObjects; set => _totalScoreObjects = value; }

        public ObjectsInitializator()
        {
            UpdatingObjects = new ListIUpdateObjects();

            Reference = new References();

            PlayerBall = Reference.GetPlayerBall;
            DisplayEndGame = new DisplayEndGame(Reference.EndGame);
            DisplayWin = new DisplayWinGame(Reference.WinGame);
            DisplayScore = new DisplayScore(Reference.Score);
            _playerEffects = PlayerBall.GetComponent<PlayerEffects>();
            GoodBonuses = Reference.GetGoodBonuses;
            BadBonuses = Reference.GetBadBonus;
            SavingObjects = new List<GameObject>();
            CameraController = new CameraController(PlayerBall.transform, Reference.GetMainCamera.transform, Reference.GetCameraAnimator);

            foreach (var item in GoodBonuses)
            {
                UpdatingObjects.AddUpdateObject(item);
                TotalScoreObjects++;
                item.BonusChange += AddScore;
                item.BonusChange += CameraController.ShakeCamera;
            }

            foreach (var item in BadBonuses)
            {
                UpdatingObjects.AddUpdateObject(item);
                item.CaughtPlayer += CaughtPlayer;
                item.CaughtPlayer += DisplayEndGame.GameOver;
            }
            for (int i = 0; i < UpdatingObjects.Count; i++)
            {
                if (UpdatingObjects[i] is InteractiveObject interactiveObject)
                {
                    SavingObjects.Add(interactiveObject.gameObject);
                }
            }

            SavingObjects.Add(PlayerBall.gameObject);

            InputController = new InputController(SavingObjects, PlayerBall);

            UpdatingObjects.AddUpdateObject(CameraController);
            UpdatingObjects.AddUpdateObject(InputController);

            Reference.RestartButton.onClick.AddListener(RestartGame);
            Reference.RestartButton.gameObject.SetActive(false);
        }

        private void CaughtPlayer(string value, Color args)
        {
            Reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void AddScore(float value)
        {
            _currentScore += value;
            DisplayScore.Display(_currentScore / TotalScoreObjects);
        }

        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }
    }
}

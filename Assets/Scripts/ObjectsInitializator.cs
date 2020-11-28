﻿using System.Collections.Generic;
using UnityEngine;

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
        private List<ReduceSpeedController> _reduceSpeed;
        private List<SpeedBonusController> _speedBonus;
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
        internal List<SpeedBonusController> SpeedBonus { get => _speedBonus; private set => _speedBonus = value; }
        internal List<ReduceSpeedController> ReduceSpeed { get => _reduceSpeed; private set => _reduceSpeed = value; }

        public ObjectsInitializator()
        {
            UpdatingObjects = new ListIUpdateObjects();

            Reference = new References();

            PlayerBall = Reference.GetPlayerBall;
            DisplayEndGame = new DisplayEndGame(Reference.EndGame);
            DisplayWin = new DisplayWinGame(Reference.WinGame);
            DisplayScore = new DisplayScore(Reference.Score);
            _playerEffects = _reference.GetPlayerEffects;
            ReduceSpeed = Reference.GetReduceSpeedBonuses;
            SpeedBonus = Reference.GetSpeedBonus;
            GoodBonuses = Reference.GetGoodBonuses;
            BadBonuses = Reference.GetBadBonus;
            SavingObjects = new List<GameObject>();
            CameraController = new CameraController(PlayerBall.transform, Reference.GetMainCamera.transform, Reference.GetCameraAnimator);

            foreach (var item in GoodBonuses)
            {
                UpdatingObjects.AddUpdateObject(item);
                TotalScoreObjects++;
            }

            foreach (var item in BadBonuses)
            {
                UpdatingObjects.AddUpdateObject(item);
            }

            foreach (var item in ReduceSpeed)
            {
                UpdatingObjects.AddUpdateObject(item);
            }

            foreach (var item in SpeedBonus)
            {
                UpdatingObjects.AddUpdateObject(item);
            }

            for (int i = 0; i < UpdatingObjects.Count; i++)
            {
                if (UpdatingObjects[i] is InteractiveObject interactiveObject)
                {
                    if (interactiveObject != null)
                    {
                        //Debug.Log(interactiveObject);
                        SavingObjects.Add(interactiveObject.gameObject);
                    }
                }
            }

            SavingObjects.Add(PlayerBall.gameObject);

            InputController = new InputController(SavingObjects, PlayerBall);

            UpdatingObjects.AddUpdateObject(CameraController);
            UpdatingObjects.AddUpdateObject(InputController);
        }
    }
}

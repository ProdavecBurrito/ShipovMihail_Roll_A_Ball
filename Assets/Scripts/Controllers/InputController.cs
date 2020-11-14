using System.Collections.Generic;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    internal class InputController : IUpdate
    {
        private PlayerBall _playerBall;
        private SaveDataRepository _dataRepository;
        private KeyCode Save = KeyCode.F5;
        private KeyCode Load = KeyCode.F9;
        private List<GoodBonusController> _goodBonuses;
        private List<GameObject> _savingObjects;
        private References references;

        public InputController(PlayerBall playerBall)
        {
            references = new References();

            _goodBonuses = references.GetGoodBonuses;

            _playerBall = playerBall;

            _savingObjects = new List<GameObject>();

            for (int i = 0; i < _goodBonuses.Count; i++)
            {
                _savingObjects.Add(_goodBonuses[i]);
            }



            _dataRepository = new SaveDataRepository();
        }

        public void UpdateTick()
        {
            _playerBall.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _playerBall.Jump(Input.GetButtonDown("Jump"));

            if (CheckSave())
            {
                _dataRepository.Save(_savingObjects);
            }

            if (CheckLoad())
            {
                _dataRepository.Load(_savingObjects);
            }
        }

        private bool CheckSave()
        {
            return Input.GetKeyDown(Save);
        }

        private bool CheckLoad()
        {
            return Input.GetKeyDown(Load);
        }
    }
}

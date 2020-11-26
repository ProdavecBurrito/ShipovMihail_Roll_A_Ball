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
        private GameObject[] _listSaveingObjects;

        public InputController(List<GameObject> listISaveObjects, PlayerBall playerBall)
        {

            _playerBall = playerBall;

            _listSaveingObjects = listISaveObjects.ToArray();

            _dataRepository = new SaveDataRepository();
        }

        public void UpdateTick()
        {
            _playerBall.Move(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            _playerBall.Jump(Input.GetButtonDown("Jump"));

            if (CheckSave())
            {
                _dataRepository.Save(_listSaveingObjects);
            }

            if (CheckLoad())
            {
                _dataRepository.Load(_listSaveingObjects);
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

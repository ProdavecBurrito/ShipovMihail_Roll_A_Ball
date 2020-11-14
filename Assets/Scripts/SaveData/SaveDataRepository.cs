using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace ShipovMihail_Roll_A_Boll
{
    public sealed class SaveDataRepository
    {
        private readonly ISaveData<SavedData> _data;

        private const string _folderName = "SavedData";
        private const string _fileName = "Data.bat";
        private readonly string _path;
        private List<SavedData> savingObjects = new List<SavedData>();
        private List<GameObject> loadingObjects = new List<GameObject>();

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.PS4)
            {
                //_data = new StreamData();
            }
            else
            {
                _data = new XMLData();
            }

            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save<T>(List<T> objects)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                {
                    Directory.CreateDirectory(_path);
                }
            }

            for (int i = 0; i < objects.Count; i++)
            {
                savingObjects.Add(objects[i] as SavedData);
                //if (objects[i] is InteractiveObject savingObject)
                //{
                //    var saveObject = new SavedData
                //    {
                //        Position = savingObject.transform.position,
                //        Name = savingObject.name,
                //        IsEnable = savingObject.gameObject.activeSelf
                //    };
                //}
            }

            for (int i = 0; i < savingObjects.Count; i++)
            {
                _data.Save(Path.Combine(_path, _fileName), savingObjects[i]);
            }
        }

        public void Load(List<InteractiveObject> objects)
        {
            Debug.Log(objects.Count);
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                return;
            }

            var newObject = _data.Load(file);

            for (int i = 0; i < objects.Count; i++)
            {

                objects[i].transform.position = newObject[i].Position;
                objects[i].name = newObject[i].Name;
                objects[i].gameObject.SetActive(newObject[i].IsEnable);
                Debug.Log(newObject);
            }
        }
    }
}

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
        private List<SavedData> savingObjects;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.PS4)
            {
                _data = new StreamData();
            }
            else
            {
                _data = new XMLData();
            }

            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save(List<GameObject> objects)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                {
                    Directory.CreateDirectory(_path);
                }

                for (int i = 0; i < objects.Count; i++)
                {
                    var saveObject = new SavedData
                    {
                        Position = objects[i].transform.position,
                        Name = objects[i].name,
                        IsEnable = true
                    };
                    savingObjects.Add(saveObject);
                }
            }
            for (int i = 0; i < savingObjects.Count; i++)
            {
                _data.Save(Path.Combine(_path, _fileName), savingObjects[i]);
            }
        }

        public void Load(List<GameObject> objects)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                return;
            }

            for (int i = 0; i < savingObjects.Count; i++)
            {
                var newObject = _data.Load(file);
                objects[i].transform.position = newObject.Position;
                objects[i].name = newObject.Name;
                objects[i].gameObject.SetActive(newObject.IsEnable);
                Debug.Log(newObject);
            }
        }
    }
}

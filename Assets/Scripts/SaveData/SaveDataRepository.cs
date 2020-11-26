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

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.PS4)
            {
                //_data = new StreamData();
            }
            else
            {
                _data = new XMLData<SavedData>();
            }

            _path = Path.Combine(Application.dataPath, _folderName);
        }

        public void Save<T>(T[] objects)
        {
            Debug.Log(objects.Length);
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            List<SavedData> savingObjects = new List<SavedData>();

            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is GameObject loadingObject)
                {
                    savingObjects.Add(new SavedData()
                    {
                        Name = loadingObject.name,
                        Position = loadingObject.transform.position,
                        IsEnable = loadingObject.gameObject.activeSelf
                    });
                }
            }


            _data.Save(Path.Combine(_path, _fileName), savingObjects.ToArray() as SavedData[]);
            Debug.Log("Saved");
        }
        public void Load<T>(T[] objects)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                return;
            }

            var newObject = _data.Load(file);

            Debug.Log(objects.Length);
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i] is GameObject loadingObject)
                {
                    loadingObject.transform.position = newObject[i].Position;
                    loadingObject.name = newObject[i].Name;
                    loadingObject.gameObject.SetActive(newObject[i].IsEnable);
                }
            }

            Debug.Log("Loaded");
        }

    }
}

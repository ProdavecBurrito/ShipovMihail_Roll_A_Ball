using UnityEditor;
using UnityEngine;

namespace ShipovMihail_Roll_A_Boll
{
    public class UserWindow : EditorWindow
    {
        public static GameObject InstantiatingObject;

        public string NameObject = "Oh, hi Mark";

        public bool CanGroup;
        public bool CanRandomiseColor;

        public int CountObjects = 1;
        public float Radius;

        private void OnGUI()
        {
            GUILayout.Label("Общие настройки", EditorStyles.boldLabel);
            InstantiatingObject = EditorGUI.ObjectField
                (new Rect(3, 20, position.width - 5, 18), "Копируемый обьект",
                InstantiatingObject, typeof(GameObject), true) as GameObject;
            GUILayout.Space(25);

            NameObject = EditorGUILayout.TextField("Имя обьекта", NameObject);

            CanGroup = EditorGUILayout.BeginToggleGroup("Доп. Настройки", CanGroup);
            CanRandomiseColor = EditorGUILayout.Toggle("Рандомный цвет", CanRandomiseColor);
            CountObjects = EditorGUILayout.IntSlider("Количество обьектов", CountObjects, 1, 50);
            Radius = EditorGUILayout.Slider("Радиус", Radius, 0.1f, 100f);
            EditorGUILayout.EndToggleGroup();

            var createButton = GUILayout.Button("Создать выбраный обьект");

            if (createButton)
            {
                if (InstantiatingObject)
                {
                    GameObject root = new GameObject("Main");
                    for (int i = 0; i < CountObjects; i++)
                    {
                        float angle = i * Mathf.PI * 2 / CountObjects;
                        Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * Radius;
                        GameObject temp = Instantiate(InstantiatingObject, pos, Quaternion.identity);
                        temp.name = NameObject + "(" + i + ")";
                        temp.transform.parent = root.transform;
                        var tempRenderer = temp.GetComponent<Renderer>();

                        if (tempRenderer && CanRandomiseColor)
                        {
                            tempRenderer.material.color = Random.ColorHSV();
                        }
                    }
                }
            }
        }
    }
}

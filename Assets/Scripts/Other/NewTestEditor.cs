using UnityEngine;
using UnityEditor;

namespace ShipovMihail_Roll_A_Boll
{
    [CustomEditor(typeof(NewTest))]
    public class NewTestEditor : UnityEditor.Editor
    {
        private bool _isPressButtonOk;

        public override void OnInspectorGUI()
        {
            //DrawDefaultInspector();
            NewTest testTarget = (NewTest)target;

            testTarget.Count = EditorGUILayout.IntSlider(testTarget.Count, 1, 50);
            testTarget.Offset = EditorGUILayout.IntSlider(testTarget.Offset, 1, 5);

            testTarget.TestObject = EditorGUILayout.ObjectField("Объект который хотим вставить",
                     testTarget.TestObject, typeof(GameObject), false) as GameObject;

            var isPressButton = GUILayout.Button("Создание объектов по кнопке",  EditorStyles.miniButtonLeft);

            _isPressButtonOk = GUILayout.Toggle(_isPressButtonOk, "Ok");

            if (isPressButton)
            {
                testTarget.CreateObject();
                _isPressButtonOk = true;
            }

            if (_isPressButtonOk)
            {
                testTarget.Test = EditorGUILayout.Slider(testTarget.Test, 10, 50);
                EditorGUILayout.HelpBox("Вы нажали на кнопку", MessageType.Warning);

                var isPressAddButton = GUILayout.Button("Add Component", EditorStyles.miniButtonLeft);
                var isPressRemoveButton = GUILayout.Button("Remove Component", EditorStyles.miniButtonLeft);
                if (isPressAddButton)
                {
                    testTarget.AddComponent();
                }
                if (isPressRemoveButton)
                {
                    testTarget.RemoveComponent();
                }
            }
        }

    }
}

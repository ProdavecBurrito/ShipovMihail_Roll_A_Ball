using UnityEditor;

namespace ShipovMihail_Roll_A_Boll
{
    internal class NewBehaviourScript
    {
        [MenuItem("UserPrefs/TestSpawnWindow %#b")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(UserWindow), false, "SpawnWindow");
        }

        [MenuItem("UserPrefs/UserSpawnWindow %#q")]
        private static void NewMenu()
        {
            EditorWindow.GetWindow(typeof(NewSpawner), false, "NewSpawner");
        }
    }
}

using UnityEditor;

namespace ShipovMihail_Roll_A_Boll
{
    public class NewBehaviourScript
    {
        [MenuItem("UserPrefs/Option 1 %#b")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(UserWindow), false, "SpawnWindow");
        }

        [MenuItem("UserPrefs/Option 2 %#q")]
        private static void NewMenu()
        {

        }

        [MenuItem("Assets/Create/UserOption")]
        private static void NewItem()
        {
            
        }

        [MenuItem("CONTEXT/Rigidbody/NewRB")]
        private static void NewRB()
        {

        }
    }
}

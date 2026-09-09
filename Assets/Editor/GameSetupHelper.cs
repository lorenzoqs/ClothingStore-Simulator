using UnityEngine;
using UnityEditor;

public class GameSetupHelper : MonoBehaviour
{
    [MenuItem("ClothingStore/Setup Game Environment")]
    public static void SetupGame()
    {
        Debug.Log("🏪 Setting up Clothing Store Simulator...");
        
        // Create main folders
        System.IO.Directory.CreateDirectory("Assets/Scripts");
        System.IO.Directory.CreateDirectory("Assets/Prefabs");
        System.IO.Directory.CreateDirectory("Assets/Materials");
        System.IO.Directory.CreateDirectory("Assets/Scenes");
        System.IO.Directory.CreateDirectory("Assets/Audio");
        System.IO.Directory.CreateDirectory("Assets/UI");
        
        Debug.Log("✅ Folders created!");
        Debug.Log("📋 Next steps:");
        Debug.Log("1. Create MainGame scene in Assets/Scenes/");
        Debug.Log("2. Add Player, Store, Backroom GameObjects");
        Debug.Log("3. Attach Scripts to appropriate GameObjects");
        Debug.Log("4. Configure UI Canvas with TextMeshPro");
        Debug.Log("5. Press Play!");
    }
    
    [MenuItem("ClothingStore/Documentation")]
    public static void OpenDocumentation()
    {
        Application.OpenURL("https://github.com/lorenzoqs/ClothingStore-Simulator");
    }
}

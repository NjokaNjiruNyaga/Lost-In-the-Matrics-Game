using UnityEngine;
using UnityEngine.SceneManagement;

public class Loadgame_scene_script: MonoBehaviour
{
    // Optional scene name in case you want to use a name instead of index
    public string gameSceneName = "Lost in the Matrics";

    // Public method to load game scene, this will show up in the Button OnClick list
    public void PlayGame()
    {
        // Either load by index...
        SceneManager.LoadScene(1); 

        // ...OR load by name:
         SceneManager.LoadScene(gameSceneName);
    }
}

using UnityEditor;
using UnityEditor.SceneManagement;
[InitializeOnLoad]
public class AutoSaveOnRun {
    static AutoSaveOnRun() {
        EditorApplication.playModeStateChanged += (PlayModeStateChange state) => {
            if (EditorApplication.isPlayingOrWillChangePlaymode && !EditorApplication.isPlaying) {
                EditorSceneManager.SaveOpenScenes();
                AssetDatabase.SaveAssets();
            }
        };
    }
}
using UnityEditor;
using UnityEngine;

public class SoundObjectSpawner : EditorWindow
{
    string soundName = " ";
    GameObject soundToSpawn;

    [MenuItem("Tools/Sound/Sound Object Spawner")]
    public static void ShowWindow(){
        GetWindow(typeof(SoundObjectSpawner));  
    }

    private void OnGUI() {
        GUILayout.Label("Spwan New Sound", EditorStyles.boldLabel);

        soundName = EditorGUILayout.TextField("Sound Name", soundName);
        soundToSpawn = EditorGUILayout.ObjectField("Sound Prefab", soundToSpawn, typeof(GameObject), false) as GameObject;

        if(GUILayout.Button("Spawn Sound")){
            SpawnSound();
        }
    }

    private void SpawnSound(){
        if(soundToSpawn == null){
            Debug.Log("Error: Please assign an sound to be spawned.");
            return;
        }

        if(soundName == string.Empty){
            Debug.Log("Error: Please enter a sound name for the object.");
            return;
        }

        GameObject newSoundObject = Instantiate(soundToSpawn, Vector3.zero, Quaternion.identity);
        newSoundObject.name = soundName;   
    }
}

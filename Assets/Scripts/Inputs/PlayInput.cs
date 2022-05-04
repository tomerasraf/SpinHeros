using UnityEngine;

public class PlayInput : MonoBehaviour
{
    [SerializeField] VoidEvent scene_Transition_To_WorldScene;

    public void SceneTransitionToWorld()
    {
        scene_Transition_To_WorldScene.Raise();
    }
}
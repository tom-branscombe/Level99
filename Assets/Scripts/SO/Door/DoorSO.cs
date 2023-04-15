using UnityEngine;

[CreateAssetMenu(menuName = "Map/Passage")]
public class DoorSO : ScriptableObject
{
    public char passageLetter;
    public string sceneToLoad;
    public Vector2 position;
}
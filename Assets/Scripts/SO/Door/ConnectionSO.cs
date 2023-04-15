using UnityEngine;

[CreateAssetMenu(menuName = "Map/DoorConnection")]
public class ConnectionSO : ScriptableObject
{
    public DoorSO[] routes;
}

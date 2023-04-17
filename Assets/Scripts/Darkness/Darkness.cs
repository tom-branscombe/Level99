using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Darkness : MonoBehaviour
{

    [SerializeField] VoidEventChannelSO _onDarknessStartEvent;
    [SerializeField] VoidEventChannelSO _onDarknessLeaveEvent;
    [SerializeField] Tilemap _darkTiles;


    Vector3Int c_previousCell;
    bool c_previousDark;

    private void FixedUpdate()
    {
        DarkUpdate();
    }


    private void DarkUpdate()
    {
        Vector2 playerPos = transform.position;

        var TilePos = _darkTiles.WorldToCell(playerPos);
        if (c_previousCell == TilePos)
        {
            return;
        }

        c_previousCell = TilePos;
        bool isDark = _darkTiles.GetTile(TilePos) ? true : false;
        
        if (isDark == c_previousDark) {
            return;
        }
        c_previousDark = isDark;


        if (isDark)
        {
            OnDarkStartEvent();
            return;
        }
        OnDarkEndEvent();
    }


    void OnDarkStartEvent()
    {
        _onDarknessStartEvent.RaiseEvent();
    }

    void OnDarkEndEvent()
    {
        _onDarknessLeaveEvent.RaiseEvent();
    }


}

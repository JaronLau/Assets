using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanel : Collectible
{
    public Door door;

    public override void Collected(Player player)
    {
        if (door != null)
        {
            door.DoorToggle();
        }
    }
}

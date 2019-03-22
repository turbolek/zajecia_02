using UnityEngine;
using System.Collections;

public class DownDirectionGetter : IDirectionGetter
{

    public Vector3 GetDirection()
    {
        return Vector3.down;
    }
}

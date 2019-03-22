using UnityEngine;
using System.Collections;

public class UpDirectionGetter : IDirectionGetter
{

    public Vector3 GetDirection()
    {
        return Vector3.up;
    }
}

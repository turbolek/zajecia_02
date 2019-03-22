using UnityEngine;
using System.Collections;

public class RightDirectionGetter : IDirectionGetter
{

    public Vector3 GetDirection()
    {
        return Vector3.right;
    }
}

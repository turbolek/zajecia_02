using UnityEngine;
using System.Collections;

public class LeftDirectionGetter : IDirectionGetter
{

    public Vector3 GetDirection()
    {
        return Vector3.left;
    }
}

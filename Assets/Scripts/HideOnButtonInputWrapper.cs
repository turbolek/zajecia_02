using UnityEngine;
using System.Collections;

public class HideOnButtonInputWrapper : IHideInputWrapper
{
    public bool GetHideInput()
    {
        return Input.GetKey(KeyCode.Z);
    }
}

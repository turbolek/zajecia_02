using UnityEngine;
using System.Collections;

public class NeverHideInputWrapper : IHideInputWrapper
{
    public bool GetHideInput()
    {
        return false;
    }
}

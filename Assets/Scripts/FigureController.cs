using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureController : MonoBehaviour
{
    private IDirectionGetter directionGetter;
    private IHideInputWrapper hideInputWrapper;
    private float speed;
    private bool initialized = false;


    public void Initialize(float speed, IHideInputWrapper hideInputWrapper)
    {
        this.speed = speed;
        this.hideInputWrapper = hideInputWrapper;
        initialized = true;
    }

    public void SetDirectionGetter(IDirectionGetter directionGetter)
    {
        this.directionGetter = directionGetter;
    }

    private void Update()
    {
        if (directionGetter == null || !initialized)
            return;

        Vector3 movementDirection = directionGetter.GetDirection();
        Vector3 shift = movementDirection * speed * Time.deltaTime;
        transform.Translate(shift);

        bool hide = hideInputWrapper.GetHideInput();

        if (hide)
            gameObject.SetActive(false);
    }
}

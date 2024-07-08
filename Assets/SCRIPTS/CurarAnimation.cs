using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CurarAnimation : MonoBehaviour
{
    [SerializeField] UnityEvent onCardStart;
    [SerializeField] UnityEvent onCardMiddle;
    [SerializeField] UnityEvent onCardsEnd;

    public void OnStartCard()
    {
        onCardStart.Invoke();
    }

    public void OnEndCard()
    {
        onCardsEnd.Invoke();
    }

    public void OnMiddleCard()
    {
        onCardMiddle.Invoke();
    }
}

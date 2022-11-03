using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using Unity.VisualScripting;

public class GeneralButton : MonoBehaviour, IPointerClickHandler
{
    public GameEventSO SoundEvent;
    public GameEventSO NextEvent;



    public void OnPointerClick(PointerEventData eventData)
    {
        SoundEvent.Raise();
        Invoke(nameof(EventSO), 0.314f);

    }

    void EventSO()
    {
        NextEvent.Raise();
    }



    




}

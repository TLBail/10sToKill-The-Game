using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventGrêve : GameEvent
{
    private const string shootingPlaceAfterHouse = "afterHouse";
    public override void init(EventManager eventManager)
    {
        eventName = "Grêve";
        SubEvents = new List<SubEvent>()
        {
            new SubEvent()
            {
                Position = new Vector3(17, 15, 37f),
                Action = () =>
                {
                    Debug.Log("salut");
                    eventManager.setImpactPosition(shootingPlaceAfterHouse);
                }
            }
        };
    }

    public override void triggerEvent(EventManager eventManager)
    {
        eventManager.setActiveFamousGameObject("billy",false);
        eventManager.setActiveFamousGameObject("taxi",false);
        eventManager.setActiveFamousGameObject("StructureInGrêve", true);
    }
}

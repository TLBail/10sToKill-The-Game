using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventBraquage : GameEvent
{
    public GameEventBraquage() {
        eventName = "Braquage";
    }
    
    public override void init(EventManager eventManager)
    {
        SubEvents = new List<SubEvent>()
        {
            new SubEvent()
            {
                Position = new Vector3(0, 0, -44f),
                Action = () =>
                {
                    
                    eventManager.famousGameObjectDictionary["coffre"].GetComponent<CoffreAi>().dropCoffre();
                    eventManager.setImpactPosition("afterBank");
                }
            }
        };
    }
    public override void triggerEvent(EventManager eventManager)
    {
        eventManager.setActiveFamousGameObject("braquage",true);
    }
}

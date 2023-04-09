using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameEventCoupeDuMonde : GameEvent
{
    
    //UnityEditor.TransformWorldPlacementJSON:{"position":{"x":11.49334716796875,"y":25.32965087890625,"z":-298.53228759765627},"rotation":{"x":0.23231784999370576,"y":-0.7234529852867127,"z":-0.07500379532575607,"w":-0.6457698345184326},"scale":{"x":2.617500066757202,"y":2.617500066757202,"z":2.617500066757202}}
    public GameEventCoupeDuMonde() {
        eventName = "Coupe du monde";
    }

    public override void init(EventManager eventManager) {
        SubEvents = new List<SubEvent>()
        {
            new SubEvent()
            {
                Position = new Vector3(0, 0, -298.53f),
                Action = () =>
                {
                    eventManager.setImpactPosition("afterPlane");
                }
            }
        };
    }
    
    public override void triggerEvent(EventManager eventManager) {
        eventManager.setActiveFamousGameObject("plane",true);
    }
}

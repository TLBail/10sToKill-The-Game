using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventNight : GameEvent
{
    
    public GameEventNight()
    {
        eventName = "Nuits";
    }
    
    
    public override void init(EventManager eventManager)
    {
        SubEvents = new List<SubEvent>()
        {
            
            new SubEvent()
            {
                Position = new Vector3(0, 0, 62f),
                Action = () =>
                {
                    eventManager.stopRecord();
                }
            },
            new SubEvent()
            {
                Position = new Vector3()
            }
        };
    }
    
    
    public override void triggerEvent(EventManager eventManager)
    {
        eventManager.setNight();
        eventManager.setImpactPosition("foser");
        eventManager.setActiveFamousGameObject("billy",false);
        eventManager.setActiveFamousGameObject("taxi",false);
    }
}

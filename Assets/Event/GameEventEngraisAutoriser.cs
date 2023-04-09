using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//c'ette evénnement déclanche l'explosion des murs car les engrais permettent la fabrication de la bombe
public class GameEventEngraisAutoriser : GameEvent
{
    public GameEventEngraisAutoriser()
    {
        eventName = "Engrais agricole libre circulation";
    }
    
    
    public override void init(EventManager eventManager)
    {
        SubEvents = new List<SubEvent>()
        {
            new SubEvent()
            {
                Position = new Vector3(0, 0, -65f),
                Action = () =>
                {
                    eventManager.famousGameObjectDictionary["explosion"].GetComponent<explosionWall>().explosion();
                    eventManager.setImpactPosition("afterBank");
                }
            }
        };
    }
    
}

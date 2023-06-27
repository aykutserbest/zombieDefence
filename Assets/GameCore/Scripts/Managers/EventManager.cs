using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action OnZombieHitReactionFinished;

    public static void ZombieHitReactionFinished()
    {
        OnZombieHitReactionFinished?.Invoke();
    }
    
    
}
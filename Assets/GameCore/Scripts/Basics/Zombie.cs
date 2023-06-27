using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Animator zombieAnimator;
    public int Health;
    public bool hitTake;

    void Start()
    {
        EventManager.OnZombieHitReactionFinished += EventManagerOnOnZombieHitReactionFinished;
        zombieAnimator= gameObject.GetComponent<Animator>();
       
    }

    private void EventManagerOnOnZombieHitReactionFinished()
    {
        hitTake = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZombieHitReaction()
    {
        // yürürken hit yememe ddurması lazım
        //ard arda hit yeme olayı (belki anim oynanır)
        //hp düsücek
        //hp yoksa ölücek
        
        Debug.Log("vuruldu");

        if (hitTake)
        {
            return;
        }

        hitTake = true;
        zombieAnimator.SetTrigger("HitTake");
         
        
    }
}

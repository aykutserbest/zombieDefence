using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    private Animator zombieAnimator;
    public int Health;
    void Start()
    {
        zombieAnimator= gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ZombieHitReaction()
    {
        //animasyon çalışıcak
        //hp düsücek
        //hp yoksa ölücek
        
        zombieAnimator.SetTrigger("HitTake");
        
        
        
        
    }
}

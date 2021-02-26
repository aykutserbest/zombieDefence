using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ZombieDefence.Controller
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "ScriptableObjects/Weapon", order = 1)]
    public class Weapon : ScriptableObject
    {
        public int magazineSize;
        public int inMagazineBullet;
        
    }
}

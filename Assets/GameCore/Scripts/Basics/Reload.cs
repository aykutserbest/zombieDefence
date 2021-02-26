using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieDefence.Controller;

namespace ZombieDefence.Basics
{
    public class Reload : MonoBehaviour
    {
        private Animator zombieAnimator;
        public Weapon _weapon;
        private BasicsShoot _basicsShoot;
        private Animator _animator;
        void Start()
        {
            _animator = GetComponent<Animator>();
            _weapon.inMagazineBullet = _weapon.magazineSize;
            _basicsShoot = GetComponent<BasicsShoot>();
        }

       
        public void MagazineIncrease()
        {
            _weapon.inMagazineBullet--;
            if (_weapon.inMagazineBullet<=0)
            {
                ReloadMagazine();
            }
        }

        public void ReloadMagazine()
        {
            _basicsShoot.isReload = true;
            _animator.SetBool("isReload", true);
            _animator.Play("Recharge");
        }

        public void MagazineAnimationUpdate()
        {
            _basicsShoot.isReload = false;
            _animator.SetBool("isReload", false);
            _weapon.inMagazineBullet = _weapon.magazineSize;
        }
    }
    
}

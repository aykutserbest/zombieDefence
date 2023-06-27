using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ZombieDefence.Controller;

namespace ZombieDefence.Basics
{
    public class BasicsShoot : MonoBehaviour
    {
        public Material hitMaterial;
        private Animator _animator;
        public GameObject _parent;
        public Weapon _weapon;
        public bool isReload;
        
        [SerializeField] private GameObject muzzleFlashParticle;
        [SerializeField] private Transform muzzleTransform;
        
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _weapon = GetComponent<Reload>()._weapon;
        }

        private void Update()
        {
            if (Input.touchCount > 0 && _weapon.inMagazineBullet>=1 && !isReload)
            {
                Touch touch = Input.GetTouch(0);
                //_parent.transform.LookAt(touch.position, Vector3.forward);
                
                ShootAnim();
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                   
                    var rig = hitInfo.collider.GetComponent<Rigidbody>();
                    if (rig != null)
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        
                        Instantiate(cube, hitInfo.point , Quaternion.FromToRotation(Vector3.forward, hitInfo.normal));
                        
                        
                        var rigTag = rig.tag;
                        if (rigTag=="Enemy")
                        {
                            rig.GetComponent<Zombie>().ZombieHitReaction();
                           // rig.AddForceAtPosition(ray.direction * 50f, hitInfo.point,ForceMode.VelocityChange);
                           _parent.transform.LookAt(hitInfo.point);
                        }
                        else
                        {
                            
                            int speed = 12;
                            Quaternion OriginalRot = _parent.transform.rotation;
                            //_parent.transform.LookAt(hitInfo.transform);
                            _parent.transform.LookAt(hitInfo.point);
                            Quaternion NewRot = _parent.transform.rotation;
                            _parent.transform.rotation = OriginalRot;
                            _parent.transform.rotation = Quaternion.Lerp(_parent.transform.rotation, NewRot, speed * Time.deltaTime);
                        }
                        
                    }
                    
                }
            }
        }
        
        private void ShootAnim()
        {
            _animator.Play("Singl_Shot");

            ShowMuzzleFlash();
        }
        
        
        
        private void ShowMuzzleFlash()
        {
            var muzzle = Instantiate(muzzleFlashParticle, muzzleTransform, false);
            muzzle.SetActive(true);
        }
        
    }
}
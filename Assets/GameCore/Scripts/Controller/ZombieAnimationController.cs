using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ZombieDefence.Controller
{
    public class ZombieAnimationController : MonoBehaviour
    {
        private Animator zombieAnimator;
        public Transform target;
        private float distance;
        private NavMeshAgent _agent;
        

        private bool _isAttack;

        // Start is called before the first frame update
        void Start()
        {
            zombieAnimator = GetComponent<Animator>();
            _agent = GetComponent<NavMeshAgent>();
        }

        // Update is called once per frame
        void Update()
        {
            zombieAnimator.SetFloat("speed", _agent.velocity.magnitude);
            distance = Vector3.Distance(transform.position, target.position);

            if (distance <= 100 && !_isAttack)
            {
                _agent.enabled = true;
                _agent.destination = target.position;
            }
            else
            {
                _agent.enabled = false;
            }

            CheckAttack();


        }

        private float timer;

        private void CheckAttack()
        {
           

            if (distance <= 2.2 && !_isAttack)
            {
                _isAttack = true;
                zombieAnimator.SetBool("attack", true);
            }
            else
            {
                _isAttack = false;
                zombieAnimator.SetBool("attack", false);
            }

        }
    }
}
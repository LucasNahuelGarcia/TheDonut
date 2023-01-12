using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

namespace TheDonnut.PlayerInteraction
{
    public class CharacterMovement : MonoBehaviour
    {
        Controls controls;
        NavMeshAgent navMeshAgent;
        Animator animator;
        private void Awake()
        {
            controls = new Controls();
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        public void SetDestination(Vector3 destination)
        {
            navMeshAgent.SetDestination(destination);
        }

        private void Update()
        {
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        }
    }
}
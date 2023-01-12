using UnityEngine;
using UnityEngine.AI;
using TheDonnut.Actionables;

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

        public void SetDestination(Actionable actionable)
        {
            navMeshAgent.SetDestination(actionable.transform.position);
        }

        private void Update()
        {
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        }
    }
}
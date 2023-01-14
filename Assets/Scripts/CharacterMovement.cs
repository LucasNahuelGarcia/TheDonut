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
        Actionable actionableTarget;
        private void Awake()
        {
            controls = new Controls();
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
        }

        public void SetDestination(Vector3 destination)
        {
            Debug.DrawLine(destination, destination + Vector3.up, Color.green, 25f);
            navMeshAgent.SetDestination(destination);
        }

        public void SetDestinationAndActionate(Actionable actionable)
        {
            navMeshAgent.SetDestination(actionable.transform.position);
            actionableTarget = actionable;
        }

        private void Update()
        {
            animator.SetFloat("Speed", navMeshAgent.velocity.magnitude);
        }

        private void OnTriggerEnter(Collider other)
        {
            Actionable otherActionable = other.gameObject.GetComponent<Actionable>();
            if ((actionableTarget != null) && (otherActionable == actionableTarget))
            {
                Debug.Log("Hitting a trigger");
                actionableTarget.Actionate();
                actionableTarget = null;
            }
        }
    }
}
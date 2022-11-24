using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class CharacterMovement : MonoBehaviour
{
    private NavMeshAgent navmeshAgent;
    private Animator charAnimator;

    private void Awake()
    {
        navmeshAgent = GetComponent<NavMeshAgent>();
        charAnimator = GetComponent<Animator>();
    }
    
    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (input.magnitude <= 0)
        {
            charAnimator.SetBool("isRunning", false);
            return;
        }

        if (Mathf.Abs(input.y) > 0.01f)
        {
            Move(input);
        }

        else
        {
            Rotate(input);
        }
    }

    void Rotate(Vector2 input)
    {
        //To rotate player on pos
        navmeshAgent.destination = transform.position;
        charAnimator.SetBool("isRunning", false);
        transform.Rotate(0, input.x * navmeshAgent.angularSpeed * Time.deltaTime, 0);
    }

    private void Move(Vector2 input)
    {
        //move player 
        charAnimator.SetBool("isRunning", true);
        Vector3 _destination = transform.position + transform.right * input.x + transform.forward * input.y;
        navmeshAgent.destination = _destination;
    }
}

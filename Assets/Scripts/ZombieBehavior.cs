using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class ZombieBehavior : MonoBehaviour
{
    NavMeshAgent agent;
    Transform player;
    Vector3 target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        target = player.position;
        agent.SetDestination(target);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            Debug.Log("aefaefd");
            SceneManager.LoadScene("Pozo Seco");
        }
    }
}
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClashScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") )
        {
            var magnitude = -800;
            var force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
            
            collision.gameObject.GetComponent<NavMeshAgent>().enabled = false;
            collision.gameObject.GetComponent<EnemyAI>().enabled = false;
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            var magnitude = -200;
            var force = transform.position - collision.transform.position;
            force.Normalize();
            collision.gameObject.GetComponent<Rigidbody>().AddForce(force * magnitude);
        }
    }
}

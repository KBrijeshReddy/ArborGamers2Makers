using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

using UnityEngine;

public class FlytrapChase : MonoBehaviour
{
    // public float rotationSpeed = 2f; // Speed of rotation towards the player
    // public float chaseSpeed = 8f;    // Speed of chasing the player
    // private bool isChasing = false;
    // private GameObject player;

    // async void FixedUpdate()
    // {
    //     if (isChasing)
    //     {
    //         ChasePlayer();
    //     }
    // }

    // async public void StartChase(GameObject obj)
    // {
    //     player = obj;
    //     // Calculate the direction towards the player
    //         Vector2 direction = player.transform.position - transform.position;
    //         float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    //         // Smoothly rotate towards the player
    //         Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
    //         transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
    //         await Task.Delay(1000);
    //         isChasing = true;
    //         await Task.Delay(4000);
    //         Destroy(gameObject);
    // }

    // private void LookAtPlayer()
    // {
    //     // Calculate the direction towards the player
    //     Vector2 direction = transform.position - player.transform.position;
    //     float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

    //     // Smoothly rotate towards the player
    //     Quaternion targetRotation = Quaternion.Euler(0, 0, angle);
    //     transform.forward = -direction.normalized;
    // }

    // private void ChasePlayer()
    // {
    //     // Move towards the player's position
    //     Vector3 dir = (player.transform.position - transform.position).normalized;
    //     transform.Translate(-dir * chaseSpeed * Time.deltaTime);
    //     // transform.position = Vector2.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);
    // }
}

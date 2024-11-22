using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Waterlog : MonoBehaviour
{
    public SpriteRenderer sprite;

    async void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            // blink a few times
            await Task.Delay(500);
            sprite.color = Color.black;
            await Task.Delay(150);
            sprite.color = Color.white;
            await Task.Delay(1000);
            sprite.color = Color.black;
            await Task.Delay(150);
            sprite.color = Color.white;
            await Task.Delay(600);
            sprite.color = Color.black;
            await Task.Delay(150);
            sprite.color = Color.white;
            await Task.Delay(250);
            sprite.color = Color.black;
            await Task.Delay(150);
            sprite.color = Color.white;
            await Task.Delay(150);
            sprite.color = Color.black;
            await Task.Delay(150);
            sprite.color = Color.white;

            GetComponent<Rigidbody2D>().isKinematic = false;
        }
    }
}

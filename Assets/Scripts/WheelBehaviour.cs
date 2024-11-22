using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class WheelBehaviour : MonoBehaviour
{
    public int lifetime = 5000;
    public float speed = 6f;

    public async void Roll(bool isAbove)
    {
        if (isAbove)
        transform.position = transform.position += new Vector3(0f, 6.28f);

        GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0f);
        await Task.Delay(lifetime);
        Destroy(gameObject);
    }
}

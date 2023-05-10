using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D player;
    public float vel = 4;
    Transform sprite;
    public float salto = 7;
    bool t_suelo = true;
    private BoxCollider2D bc;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        sprite = GetComponent<Transform>();
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            player.velocity = new Vector2(vel,player.velocity.y);
            sprite.rotation = new Quaternion(0,0,0,0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            player.velocity = new Vector2(-vel, player.velocity.y);
            sprite.rotation = new Quaternion(0, 180f, 0, 0);
        }

        if (Input.GetKey(KeyCode.W) && t_suelo)
        {
            player.velocity = new Vector2(player.velocity.x, salto);
            t_suelo = false;
        }  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo") { 
            t_suelo = true;
        }
        print(collision.gameObject.tag);
        
    }

    bool es()
    {
        Physics2D.BoxCast(bc.bounds.center, new Vector2(bc.bounds.size.x,bc.bounds.size.y), 0f, Vector2.down, 0.2f, suelo);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Animator anim;
    private Rigidbody2D RB;
    private bool left;
    public float coins = 0;
    public AudioClip coin;
    private AudioSource aso;
    public AudioClip wolf;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        aso = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if (RB.velocity.x > 0.05) { left = false; anim.SetBool("Left", false); }
        if (RB.velocity.x < -0.05) { left = true; anim.SetBool("Left", true); }

        

        if (Mathf.Abs(RB.velocity.x) > 0.1 || Mathf.Abs(RB.velocity.x) < -0.1) { anim.SetFloat("Speed", 1.0f);}
        if (Mathf.Abs(RB.velocity.x) <= 0.1 && Mathf.Abs(RB.velocity.x) >= -0.1) { anim.SetFloat("Speed", 0f); }

        if (Mathf.Abs(RB.velocity.x) > 1.5 || Mathf.Abs(RB.velocity.x) < -1.5) { anim.SetFloat("Speed", 2.0f); }
        if (Mathf.Abs(RB.velocity.x) <= 1.5 && Mathf.Abs(RB.velocity.x) >= -1.5 && Mathf.Abs(RB.velocity.x) > 0.1 && Mathf.Abs(RB.velocity.x) < -0.1) { anim.SetFloat("Speed", 1f); }

        if (Mathf.Abs(RB.velocity.y) <= 0.05) { anim.SetFloat("SpeedY", 0f); }
        if (Mathf.Abs(RB.velocity.y) > 0.05) { anim.SetFloat("SpeedY", 1f); }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {

            Destroy(collision.gameObject);
            if (coins == 2)
            {
                anim.SetBool("MegaWolf", true);
            }
            coins++;
            CoinSound();

            


        }

        if (collision.gameObject.CompareTag("End"))
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            WolfSound();


        }

        if (collision.gameObject.CompareTag("Enemie") && coins == 3)
        {

            Destroy(collision.gameObject);
            CoinSound();
            


        }

        if (collision.gameObject.CompareTag("Enemie") && coins < 3)
        {

            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            WolfSound();


        }
    }

    public void CoinSound() {

        aso.clip = coin;
        aso.Play();

    }

    public void WolfSound() {

        aso.clip = wolf;
        aso.Play();
    }


}

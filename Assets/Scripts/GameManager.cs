using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public float CharacterVelocity = 2.00f;
    public float Force = 5.00f;
    public Sprite izquierda;
    public Sprite derecha;
    public Sprite paradopos;
    public Sprite paradoneg;
    public Sprite cayendoneg;
    public Sprite cayendopos;
    public Sprite saltandoneg;
    public Sprite saltandopos;
    public Animation walking;

    public GameObject character;
    private Rigidbody2D RBCharacter;
    private Camera camera;
    


    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;

        if (character)
        {
            RBCharacter = character.GetComponent<Rigidbody2D>();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

        RBCharacter.transform.eulerAngles = new Vector3(0, 0, 0);
        camera.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, -10);
        if (RBCharacter && Input.GetKeyDown("space") && Mathf.Abs(RBCharacter.velocity.y) <= 0.05f)
        {

            RBCharacter.AddForce(new Vector2(0, Force), ForceMode2D.Impulse);

        }



    }

    private void FixedUpdate()
    {

        if (RBCharacter) {

            RBCharacter.AddForce(new Vector2(Input.GetAxis("Horizontal") * CharacterVelocity, 0));

        }


    }

}

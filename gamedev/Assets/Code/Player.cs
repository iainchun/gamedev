using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector2 inputVec;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anime;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anime = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        Vector2 nextVec;

        if (inputVec.x != 0 && inputVec.y != 0) {
            nextVec = Vector2.zero;
        } else {
            nextVec = inputVec.normalized * speed * Time.fixedDeltaTime;
        }

        rigid.MovePosition(rigid.position + nextVec);
    }

    void LateUpdate() {
        anime.SetFloat("speed", inputVec.magnitude);

        if (inputVec.x != 0 && inputVec.y != 0) {
            if (inputVec.y != 0) {
                spriter.flipY = inputVec.y < 0;
            }

            if (inputVec.x > 0) {   
                spriter.flipX = false;
                transform.rotation = Quaternion.Euler(0f, 0f, -90f);
            } else if (inputVec.x < 0) {
                spriter.flipX = true;
                transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            } else {
                transform.rotation = Quaternion.identity;
            }
        }
    }

}

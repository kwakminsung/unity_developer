using UnityEngine;

public class ai : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spreiteRenderer;
    public int nextMove;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        Think();

        Invoke("Think", 5);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.linearVelocity = new Vector2(nextMove, rigid.linearVelocity.y);

        Vector2 frontVec = new Vector2(rigid.position.x + nextMove*0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, LayerMask.GetMask("Platform"));
        if (rayHit.collider = null)
        {
            nextMove *= -1;
            CancelInvoke();
            Invoke("Think", 2);
        }
    }

    void Think()
    {
        nextMove = Random.Range(-1, 2);

        float nextThinkTime = Random.Range(2f, 5f);
        Invoke("Think", nextThinkTime);

        anim.SetInteger("walkSpeed", nextMove);
        if (nextMove != 0)
        SpriteRenderer.flipx = nextMove == 1;
    }

    void Turn()
    {
        nextMove *= -1;
        SpriteRenderer.flipx = nextMove == 1;

        CancelInvoke();
        Invoke("Think", 2);
    }
}

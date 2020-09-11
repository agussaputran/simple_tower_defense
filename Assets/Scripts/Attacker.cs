using UnityEngine;


public class Attacker : MonoBehaviour 
{
	public bool isPlayer = true;
    public int attackPoin = 100;
    public int defensePoin = 200;
    public AudioClip attackAudio;
    private AudioSource attackMediaPlayer;

	private bool isMove = true;
    
	[HideInInspector]
    public int underAttack;
    private float timer = 0;
    private float posYEnemy;
    private bool isFind = false;
    private string nameTagEnemy;

	void Start () 
	{
        attackMediaPlayer = gameObject.AddComponent<AudioSource>();
        attackMediaPlayer.clip = attackAudio;

		if(isPlayer)
		{
			nameTagEnemy = "Enemy";
		}
		else
		{
			nameTagEnemy = "Player";
		}
	}

	void Update () 
	{
		
	}

	private void FixedUpdate() 
	{
		if (isPlayer)
        {
            if (isMove)
            {
                transform.position += transform.right * Time.deltaTime * 0.5f;
                if (transform.position.y > (posYEnemy + 0.1f) && isFind)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYEnemy - 0.1f) && isFind)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    defensePoin -= underAttack;
                    transform.localScale = new Vector3(2, 2f);
                    attackMediaPlayer.Play();
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(2, 2.2f);
                }
            }
        }
        else
        {
            if (isMove)
            {
                transform.position -= transform.right * Time.deltaTime * 0.5f;
                if (transform.position.y > (posYEnemy + 0.1f) && isFind)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y - Time.deltaTime));
                }
                if (transform.position.y < (posYEnemy - 0.1f) && isFind)
                {
                    transform.position = new Vector2(transform.position.x, (transform.position.y + Time.deltaTime));
                }
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > 0.6f)
                {
                    defensePoin -= underAttack;
                    transform.localScale = new Vector3(2, 2f);
                    attackMediaPlayer.Play();
                    timer = 0;
                }
                else if (timer > 0.5f)
                {
                    transform.localScale = new Vector3(2, 2.2f);
                    attackMediaPlayer.Play();
                }
            }
        }
        if (defensePoin <= 0)
        {
            Destroy(gameObject);
        }
        if (transform.position.x > 9 || transform.position.x < -9)
        {
            Destroy(gameObject);
        }
	}

    private void OnCollisionStay2D(Collision2D other) 
    {
        if (other.transform.tag.Equals(nameTagEnemy) && isMove)
        {
            isMove = false;
            Attacker m = other.gameObject.GetComponent<Attacker>();
            if (m != null) m.underAttack = attackPoin;
            Defender d = other.gameObject.GetComponent<Defender>();
            if (d != null) d.underAttack = attackPoin;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.transform.tag.Equals(nameTagEnemy))
        {
            isFind = true;
            posYEnemy = other.transform.position.y;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        isMove = true;
        transform.localScale = new Vector3(2, 2f);
    }
}

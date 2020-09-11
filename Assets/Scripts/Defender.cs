using UnityEngine;

public class Defender : MonoBehaviour 
{
	public bool isPlayer = true;
	public int defensePoin = 300;
    private bool isDefend = false;
    
    [HideInInspector]
    public int underAttack;
    private float timer = 0;
    private string nameTagEnemy;

	void Start () 
	{
		if (isPlayer)
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
		if (isDefend)
        {
            timer += Time.deltaTime;
            if (timer > 0.6f)
            {
                defensePoin -= underAttack;
                timer = 0;
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

	private void OnCollisionEnter2D(Collision2D other) 
	{
		if (other.transform.tag.Equals(nameTagEnemy))
        {
            isDefend = true;
            Attacker m = other.gameObject.GetComponent<Attacker>();
            if (m != null) m.underAttack = 0;
            Defender d = other.gameObject.GetComponent<Defender>();
            if (d != null) d.underAttack = 0;
        }
	}

	private void OnCollisionExit2D(Collision2D other) 
	{
		isDefend = false;
	}
}

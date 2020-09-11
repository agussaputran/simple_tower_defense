using UnityEngine;

public class CreatePlayer : MonoBehaviour 
{
	public GameObject player;
    public int cost = 100;

    private Vector3 screenPoint;
    private Vector3 offset;

	void Start () 
	{
		
	}

	void Update () 
	{
		
	}

	private void OnMouseDown() 
	{
		if (Data.coin > cost)
        {
            Debug.Log("Player");
            GameObject _item = (GameObject)Instantiate(player, transform.position, Quaternion.identity);
            foreach (Behaviour childCompnent in _item.GetComponentsInChildren<Behaviour>())
            childCompnent.enabled = false;

            screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
            Input.mousePosition.y, screenPoint.z));

            SummonPlayer summon = _item.GetComponent<SummonPlayer>();
            summon.enabled = true;
            summon.screenPoint = screenPoint;
            summon.offset = offset;
            summon.cost = cost;
        }
        else
        {
            Debug.Log("No coin");
        }
	}
}

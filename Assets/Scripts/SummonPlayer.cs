using UnityEngine;

public class SummonPlayer : MonoBehaviour 
{
	[HideInInspector]
    public Vector3 screenPoint;
    [HideInInspector]
    public Vector3 offset;
    [HideInInspector]
    public int cost;
    [HideInInspector]
    public bool follow = true;
	void Start () 
	{
		
	}

	void Update () 
	{
		if (follow)
        {
            Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
            Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + offset;
            transform.position = currentPosition;
            if (Input.GetMouseButtonUp(0))
            {
                if (transform.position.x < 0 && transform.position.y > -2f)
                {
                    follow = false;
                    Data.coin -= cost;
                    foreach (Behaviour childCompnent in GetComponentsInChildren<Behaviour>())
                    childCompnent.enabled = true;
                }
                else
                {
                    Destroy(gameObject);
                    Debug.Log("Meletakkan area yang tidak di izinkan");
                }
            }
        }
	}
}

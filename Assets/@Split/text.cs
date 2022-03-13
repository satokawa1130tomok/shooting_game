using UnityEngine;

public class text : MonoBehaviour
{

    [SerializeField]
    private Transform targetTfm;
    private GameObject player=null;
    private Vector3 position;

    private RectTransform myRectTfm;
    private Vector3 offset = new Vector3(0, 1.5f, 0);

    void Start()
    {
        myRectTfm = GetComponent<RectTransform>();
        
    }

    void Update()
    {
       if(player == null)
       {
           player = GameObject.FindGameObjectWithTag("pl");
       }
        
        position = player.transform.position;
        position = new Vector3(position.x, position.y + 5, position.z);
        this.transform.position = position;
           
    }
}
using UnityEngine;
using UnityEngine.SceneManagement;
public class Put_it_back : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("B_", 5f);
    }
    public void B_()
    {
        SceneManager.LoadScene("Start screen");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

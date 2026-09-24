using UnityEngine;

public class powerPlayer : MonoBehaviour
{
    public static bool peguei = false;
    public GameObject poder;
    public GameObject mensagemPoder;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
       mensagemPoder.SetActive(false);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < 1.5f)
        {
            mensagemPoder.SetActive(true);

            if (Input.GetKey(KeyCode.F))
            {
                peguei = true;
                Destroy(poder);
                Destroy(mensagemPoder);
            }
        }
        else
        {
            mensagemPoder.SetActive(false);
        }  
    }
}

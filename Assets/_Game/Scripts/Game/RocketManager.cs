using UnityEngine;

public class RocketManager : MonoBehaviour
{
    public GameObject fire;

    void Start()
    {
        GameObject.Find("Billy").SetActive(false);
        GameObject.Find("Teddy").SetActive(false);

        fire.SetActive(true);
    }

    void Update()
    {
        this.gameObject.transform.Translate(Vector3.up * Time.deltaTime * .5f);
    }
}

using UnityEngine;

public class SpwanManager : MonoBehaviour
{
    [SerializeField] GameObject ground;
    [SerializeField] GameObject brick;

    private Renderer renderer;

    private void Awake()
    {
        renderer = ground.GetComponent<Renderer>();
    }

    private void Start()
    {
        for (int i = 0; i < 10; i++) {

            SpwanObjectInGround();
        }

    }

    void SpwanObjectInGround()
    {
        float randomInxdix = Random.Range(renderer.bounds.min.x,renderer.bounds.max.x);
        float randomInxdiz = Random.Range(renderer.bounds.min.z,renderer.bounds.max.z);

        Vector3 spwanPos = new Vector3(randomInxdix, 0, randomInxdiz);
        Instantiate(brick,spwanPos, Quaternion.identity);

        
    }

}

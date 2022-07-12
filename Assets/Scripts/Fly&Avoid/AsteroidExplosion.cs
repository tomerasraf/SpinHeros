using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] GameObject asteroidUnbreakable;
    [SerializeField] GameObject asteroidBreakable;
    [SerializeField] GameObject explosionEffect;

    [Header("Vars")]
    [SerializeField] float explostionForce;
    [SerializeField] float explostionRadius;

    private Vector3 asteroidStartPos;
    private GameObject asteroidClone;

    public void AsteroidExplosion_Listener()
    {
        asteroidStartPos = asteroidUnbreakable.transform.position;
        Destroy(asteroidUnbreakable);

       asteroidClone = Instantiate(asteroidBreakable, asteroidStartPos, Quaternion.identity);

        asteroidClone.GetComponent<Rigidbody>().AddExplosionForce(explostionForce, asteroidClone.transform.position, explostionRadius);
        asteroidClone.GetComponent<Rigidbody>().useGravity = true;

        Destroy(Instantiate(explosionEffect, asteroidClone.transform.position, Quaternion.identity), 3); 

    }

}

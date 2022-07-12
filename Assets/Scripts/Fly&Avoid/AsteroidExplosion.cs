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
    private Rigidbody[] debrisRB;

    public void AsteroidExplosion_Listener()
    {
        asteroidStartPos = asteroidUnbreakable.transform.position;
        Destroy(asteroidUnbreakable);

       asteroidClone = Instantiate(asteroidBreakable, asteroidStartPos, Quaternion.identity);

           debrisRB = asteroidClone.GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < 9; i++)
        {
            debrisRB[i].AddExplosionForce(explostionForce, debrisRB[i].position, explostionRadius, 50, ForceMode.Impulse);
        }

        Destroy(Instantiate(explosionEffect, asteroidClone.transform.position, Quaternion.identity), 3); 

    }

}

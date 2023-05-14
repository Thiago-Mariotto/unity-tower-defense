using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Tower : MonoBehaviour
{
    [SerializeField] private float towerRange = 5f;
    [SerializeField] private bool allowFire = true;
    [SerializeField] private float towerDelay = 0.2f;
    [SerializeField] private GameObject turret;

    private float distanteToEnemy;

    private Transform closestEnemy = null;
    private Enemy[] allEnemiesAround;
    private Shoot towerShoot;
    private float counter;

    private void Start()
    {
        towerShoot = gameObject.GetComponent<Shoot>();
    }

    private void Update()
    {
        ShootIsAvaliable();
        FindAllEnemies();
        if (!closestEnemy)
        {
            closestEnemy = GetClosestEnemy(allEnemiesAround);
        }

        distanteToEnemy = Vector3.Distance(closestEnemy.position, this.transform.position);
        
        if (distanteToEnemy < towerRange && allowFire)
        {
            turret.transform.LookAt(closestEnemy);
            towerShoot.Fire(new Vector3(closestEnemy.position.x, closestEnemy.position.y, closestEnemy.position.z));
            allowFire = false;
        } else
        {
            closestEnemy = null;
        }
    }

    private void ShootIsAvaliable ()
    {
        if (!allowFire)
        {
            counter += Time.deltaTime;
            if (counter > towerDelay)
            {
                allowFire = true;
                counter = 0;
            }
        }
    }

    private void FindAllEnemies()
    {
        allEnemiesAround = GameObject.FindObjectsOfType<Enemy>();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, towerRange);
    }

    public Transform GetClosestEnemy(Enemy[] enemies)
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = this.transform.position;
        for (int i = 0; i < enemies.Length; i++)
        {
            Vector3 directionToTarget = enemies[i].transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = enemies[i].transform;
            }
        }
        return bestTarget;
    }

    public float GetTowerRange()
    {
        return this.towerRange;
    }
}

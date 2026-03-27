using UnityEngine;

public enum CatType
{
    Fire
}

public class Cat : MonoBehaviour
{
    public GameObject enemy;

    public CatType type;

    public Transform spawnPos;

    private bool appearEnemy;

    public bool generateEnemy;

    public bool unlocked;

    private void Start()
    {
        GameManager.instance.totalCats++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (!appearEnemy && generateEnemy)
            {
                appearEnemy = true;
                GameObject generatedEnemy = Instantiate(enemy, spawnPos.position, Quaternion.identity);
                Enemy enemyScript = generatedEnemy.GetComponent<Enemy>();
                enemyScript.cat = this;
                enemyScript.unlockCat = true;
            }
            if ((appearEnemy && unlocked) || generateEnemy == false && unlocked)
            {
                GameManager.instance.UnlockAbility(type);

                GameManager.instance.player.rightLimit = 104.92f;
                Camera.main.GetComponent<CameraFollower>().rightLimit = 97;

                Destroy(gameObject);
            }
        }
    }
}
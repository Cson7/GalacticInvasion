using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Destructable : MonoBehaviour
{
    bool canBeDestroyed = false;
    public int scoreValue = 100;
    public int hit = 0;

    // Start is called before the first frame update
    void Start()
    {
        LevelController.instance.AddEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 9.75f && !canBeDestroyed)
        {
            canBeDestroyed = true;
            GunController[] guns = transform.GetComponentsInChildren<GunController>();
            foreach (GunController gun in guns)
            {
                gun.isActive = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!canBeDestroyed)
        {
            return;
        }
        BulletMovement bullet = collision.GetComponent<BulletMovement>();
        
        if (bullet != null)
        {
            hit += 1;
            if(hit == 100)
            {
                if (!bullet.isEnemy) 
                {
                    LevelController.instance.AddScore(scoreValue);
                    LevelController.instance.RemoveEnemy();
                    Destroy(gameObject);
                    Destroy(bullet.gameObject);
                };
            }
        }
    }
}

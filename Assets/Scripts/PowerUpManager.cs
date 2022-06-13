using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public int maxPowerUpAmount;
    public List<GameObject> powerUpTemplateList;

    public Transform spawnArea;
    public Vector2 powerUpAreaMin;
    public Vector2 powerUpAreaMax;

    public float spawnInterval;

    private List<GameObject> powerUpList;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        powerUpList = new List<GameObject>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            Debug.Log("Spawn");
            GenerateRandomPowerUp();
            timer -= spawnInterval;
        }
    }

    public void GenerateRandomPowerUp()
    {
        GenerateRandomPowerUp(new Vector2(
            Random.Range(powerUpAreaMin.x, powerUpAreaMax.x), 
            Random.Range(powerUpAreaMin.y, powerUpAreaMax.y)
        ));
    }

    public void GenerateRandomPowerUp(Vector2 position)
    {
        if (powerUpList.Count >= maxPowerUpAmount)
        {
            return;
        }

        if (position.x < powerUpAreaMin.x
            || position.x > powerUpAreaMax.x
            || position.y < powerUpAreaMin.y
            || position.y > powerUpAreaMax.y)
        {
            return;
        }

        int randomIndex = Random.Range(0, powerUpTemplateList.Count);

        GameObject powerUpTemplate = powerUpTemplateList[randomIndex];

        GameObject powerUp = Instantiate(
            powerUpTemplate,
            new Vector3(position.x, position.y, powerUpTemplate.transform.position.z),
            Quaternion.identity,
            spawnArea);

        powerUp.SetActive(true);

        powerUpList.Add(powerUp);
    }

    public void RemovePowerUp(GameObject powerUp)
    {
        powerUpList.Remove(powerUp);
        Destroy(powerUp);
    }

    public void RemoveAllPowerUp()
    {
        foreach(GameObject powerUp in powerUpList) {
            RemovePowerUp(powerUp);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform;
    public Transform generationPoint;
    public float distanceBetween;
    
    private float platformWidth;
    public float distanceBetweenMin;
    public float distanceBetweenMax;

    //public GameObject[] thePlatforms;
    private int platformSelector;
    private float[] platformWidths;


    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private CoinGenerator theCoinGenerator;
    public float randomCoinThreshold;

    public float randomCactusThreshold;
    public ObjectPooler cactusPool;

    public float randomWaterThreshold;
    public ObjectPooler waterPool;

    public float randomToiletThreshold;
    public ObjectPooler toiletPool;

    // Start is called before the first frame update
    void Start()
    {
        //platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
        platformWidths = new float[theObjectPools.Length];
        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;

        theCoinGenerator = FindObjectOfType<CoinGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range (0, theObjectPools.Length);

            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);
            
        
            //Instantiate (/*thePlatform*/ thePlatforms[platformSelector], transform.position, transform.rotation);
        GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
        newPlatform.transform.position = transform.position;
        newPlatform.transform.rotation = transform.rotation;
        newPlatform.SetActive (true);

        if(Random.Range(0f, 100f) < randomCoinThreshold)
        {
        theCoinGenerator.SpawnCoins(new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z));
        }

        if(Random.Range(0f, 100f) < randomCactusThreshold)

        {
            float cactusXPosition = Random.Range(-platformWidths[platformSelector]/2 +.3f, platformWidths[platformSelector]/2 -.3f);
            GameObject newCactus = cactusPool.GetPooledObject();

            Vector3 cactusPosition = new Vector3(cactusXPosition, .3f, 0f);

            newCactus.transform.position = transform.position + cactusPosition;
            newCactus.transform.rotation = transform.rotation;
            newCactus.SetActive(true);

        }

        if(Random.Range(0f, 100f) < randomWaterThreshold)

        {
            float waterXPosition = Random.Range(-platformWidths[platformSelector]/2 +.3f, platformWidths[platformSelector]/2 -.3f);
            GameObject newWater = waterPool.GetPooledObject();

            Vector3 waterPosition = new Vector3(waterXPosition, .3f, 0f);

            newWater.transform.position = transform.position + waterPosition;
            newWater.transform.rotation = transform.rotation;
            newWater.SetActive(true);

        }

        if(Random.Range(0f, 100f) < randomToiletThreshold)

        {
            float toiletXPosition = Random.Range(-platformWidths[platformSelector]/2 +.3f, platformWidths[platformSelector]/2 -.3f);
            GameObject newToilet = toiletPool.GetPooledObject();

            Vector3 toiletPosition = new Vector3(toiletXPosition, .3f, 0f);

            newToilet.transform.position = transform.position + toiletPosition;
            newToilet.transform.rotation = transform.rotation;
            newToilet.SetActive(true);

        }

        transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z); 
        }
    }
}

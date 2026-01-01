using UnityEngine;
using System.Collections.Generic;

public class DropRateManager : MonoBehaviour
{
    [System.Serializable]
    public class Drops
    {
        public string name;
        public GameObject itemPrefab;
        public float dropRate;
    }

    public List<Drops> drops;

    private void OnDisable()
    {
        float randomNumer = UnityEngine.Random.Range(0f, 100f);
        List<Drops> posibleDrops = new List<Drops>();

        foreach(Drops d in drops)
        {
            if(randomNumer <= d.dropRate)
            {
                Instantiate(d.itemPrefab, transform.position, Quaternion.identity);
            }
        }
        if(posibleDrops.Count > 0)
        {
            Drops drops = posibleDrops[UnityEngine.Random.Range(0, posibleDrops.Count)];
            Instantiate(drops.itemPrefab, transform.position, Quaternion.identity);
        }
    }
}

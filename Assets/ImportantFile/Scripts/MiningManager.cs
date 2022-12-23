using UnityEngine;

public class MiningManager : MonoBehaviour
{
    public GameObject[] Rocks;

    public DataForTrigger Data;

    private void Awake()
    {
        if (Data.DeleteRock >= 0)
            Rocks[Data.DeleteRock].SetActive(false);
    } 
}

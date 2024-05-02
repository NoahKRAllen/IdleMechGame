using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// has data and SO for bonus/discount, timer, quests. Etc.
/// Easy to swap in testing data SO here for a fast/cheap match to test all mechanics.
/// </summary>
public class PlanetModel : MonoBehaviour
{
    public int PlanetID { get; private set; }
    public string Name { get; private set; }
    // Start is called before the first frame update
    void Start()
    {
        // TODO: load these from SO??
        PlanetID = 1;
        Name = "Earth";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

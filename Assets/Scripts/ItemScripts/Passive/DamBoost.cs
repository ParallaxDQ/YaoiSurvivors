using UnityEngine;

public class DamBoost : AbstractItem
{
    float damIncrease;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    override public float itemFunc(float varToBeInc)
    {
        varToBeInc += damIncrease;
        return varToBeInc;
    }
}

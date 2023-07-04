using UnityEngine;

/// <summary>
/// Simple script to disable the Cube object once its health is equal or below 0.
/// This simple script is just for the purpose of learning Unity's test framework.
/// </summary>
public class CubeHitpointsController : MonoBehaviour
{
    // If I set the hitPoints variable to an integer instead of float on purpose, the tests will fail when assigning a float to it in the tests script.
    // public int hitPoints;

    // Now if hitPoints variable is a float, it will no longer fail the tests.
    public float hitPoints;
    
    void Update()
    {
        DisableOnDeath();
    }

    public void DisableOnDeath()
    {
        /*
         * This part is made wrong intentionally to see how the unit test handles failing.
         * The reason this is wrong, because this only checks if HP is LESS than 0.
         * If the HP is EQUAL to zero, the Game Object won't be disabled.
         * To fix this, it should check for both less and equal with the <= operator.
         
        if(hitPoints < 0)
        {
            gameObject.SetActive(false);
        }
        */

        // This is the correct part which will result in the test not failing.
        // Simple way of showing how Unit tests could save A LOT of time in big projects,
        // because you can test small parts of the code.
        // In this case, the demonstration is quite simple, but it applies the same to more advanced functions.
        if (hitPoints <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
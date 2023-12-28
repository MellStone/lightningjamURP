using UnityEngine;
[CreateAssetMenu(fileName = "PowState", menuName = "ScriptableObjects/CampingPowStateSO", order = 1)]
public class CampingPowStateSO : ScriptableObject
{
    public int currentCherryInPow = 0;
    public int maxCherryInPow = 2;

    public void AddCherryToPow()
    {
        ++currentCherryInPow;
    }

}

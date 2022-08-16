using System;


[Serializable]
public class PickUpInfo
{
    //[HideInInspector]
    public string name;
    public PickUpBase PickUpPrefab;
    public int SpawnChance;

    public void UpdateName()
    {
        name = PickUpPrefab == null ? String.Empty : PickUpPrefab.name;
    }
}
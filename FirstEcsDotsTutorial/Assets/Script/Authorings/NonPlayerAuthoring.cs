using Unity.Entities;
using UnityEngine;

public class NonPlayerAuthoring : MonoBehaviour
{
    
}

public class NonPlayerBaker : Baker<NonPlayerAuthoring>
{
    public override void Bake(NonPlayerAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
    }
}
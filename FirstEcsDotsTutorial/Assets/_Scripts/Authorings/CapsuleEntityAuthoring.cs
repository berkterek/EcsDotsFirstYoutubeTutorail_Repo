using Unity.Entities;
using UnityEngine;

public class CapsuleEntityAuthoring : MonoBehaviour
{
    public float MoveSpeed = 5f;
}

public class CapsuleEntityBaker : Baker<CapsuleEntityAuthoring>
{
    public override void Bake(CapsuleEntityAuthoring authoring)
    {
        var entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new MoveSpeedData()
        {
            MoveSpeed = authoring.MoveSpeed
        });

        AddComponent<CapsuleTag>(entity);
    }
}
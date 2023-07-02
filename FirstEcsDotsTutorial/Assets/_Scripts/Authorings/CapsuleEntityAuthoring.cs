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
        AddComponent(new MoveSpeedComponentData()
        {
            MoveSpeed = authoring.MoveSpeed
        });
    }
}
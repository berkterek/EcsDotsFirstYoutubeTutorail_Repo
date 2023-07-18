using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

public partial struct CapsuleMoveSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;
        
        foreach (var (localTransform,moveSpeedData) in SystemAPI.Query<RefRW<LocalTransform>, RefRO<MoveSpeedData>>())
        {
            localTransform.ValueRW.Position += deltaTime * moveSpeedData.ValueRO.MoveSpeed * new float3(0f, 0f, 1f);
        }
    }
}
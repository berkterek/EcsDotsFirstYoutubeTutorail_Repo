using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(TransformSystemGroup))]
[BurstCompile]
public partial struct PlayerMoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        new PlayerMoveJob()
        {
            DeltaTime = deltaTime
        }.ScheduleParallel();

        //Run main thread
        //Schedule => worker'da calisir ama sadece tek worker'da calisir
        //ScheduleParallel => bir cok worker uzerinde calir

        //RW => read write
        //RO => read
        // foreach (var (localTransform, playerTag, playerMoveData) in SystemAPI
        //              .Query<RefRW<LocalTransform>, RefRO<PlayerTag>, RefRO<PlayerMoveData>>())
        // {
        //     localTransform.ValueRW.Position += deltaTime * playerMoveData.ValueRO.MoveSpeed * new float3(0f, 0f, 1f); 
        // }
    }

    [BurstCompile]
    public partial struct PlayerMoveJob : IJobEntity
    {
        public float DeltaTime;

        [BurstCompile]
        private void Execute(ref LocalTransform localTransform, in PlayerTag playerTag, in PlayerMoveData moveData)
        {
            localTransform.Position += DeltaTime * moveData.MoveSpeed * new float3(0f, 0f, 1f);
        }
    }
}
using System;
using System.Collections;
using Unity.Physics;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Collections;
using UnityEngine;
using Unity.Transforms;
using Collider = Unity.Physics.Collider;


[Serializable]
public class SpawnRandomPhysicsBodies : MonoBehaviour
{
    public GameObject prefab;
    public float3 range;
    public int count;
    public float delayBetweenSpawns = 0.01f;

    private NativeArray<float3> positions;
    private NativeArray<quaternion> rotations;
    
    void OnEnable()
    {
        if (this.enabled)
        {
            // Create entity prefab from the game object hierarchy once
            Entity sourceEntity = GameObjectConversionUtility.ConvertGameObjectHierarchy(prefab, World.Active);
            var entityManager = World.Active.EntityManager;

            positions = new NativeArray<float3>(count, Allocator.Persistent);    
            rotations = new NativeArray<quaternion>(count, Allocator.Persistent);
            
            RandomPointsOnCircle(transform.position, range, ref positions, ref rotations);

            BlobAssetReference<Collider> sourceCollider = entityManager.GetComponentData<PhysicsCollider>(sourceEntity).Value;
            for (int i = 0; i < count; i++)
            {
                StartCoroutine(CreateOneNewEntity(
                    entityManager, 
                    sourceEntity, 
                    positions,
                    i, 
                    rotations, 
                    sourceCollider, 
                    delayBetweenSpawns, 
                    i == count -1));
            }

        }
    }

    private static IEnumerator CreateOneNewEntity(EntityManager entityManager, Entity sourceEntity, 
        NativeArray<float3> positions, int i, NativeArray<quaternion> rotations, 
        BlobAssetReference<Collider> sourceCollider, float delayBetweenSpawns, bool isLast)
    {
        
        yield return new WaitForSeconds(delayBetweenSpawns * i);
        
        var instance = entityManager.Instantiate(sourceEntity);
        entityManager.SetComponentData(instance, new Translation {Value = positions[i]});
        entityManager.SetComponentData(instance, new Rotation {Value = rotations[i]});
        entityManager.SetComponentData(instance, new PhysicsCollider {Value = sourceCollider});

        if (isLast)
        {
            positions.Dispose();
            rotations.Dispose();
        }
    }

    public static void RandomPointsOnCircle(float3 center, float3 range, ref NativeArray<float3> positions, ref NativeArray<quaternion> rotations)
    {
        var count = positions.Length;
        // initialize the seed of the random number generator 
        Unity.Mathematics.Random random = new Unity.Mathematics.Random();
        random.InitState(10);
        for (int i = 0; i < count; i++)
        {
            positions[i] = center + random.NextFloat3(-range, range);
            rotations[i] = random.NextQuaternionRotation();
        }
    }
}

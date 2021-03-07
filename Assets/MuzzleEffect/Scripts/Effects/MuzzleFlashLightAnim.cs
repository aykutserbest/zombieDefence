using UnityEngine;
using Random = UnityEngine.Random;

namespace ZombieDefence.Effects
{
    public class MuzzleFlashLightAnim : MonoBehaviour
    {
        public float LiveTime = 0.13f;
        public Transform MuzzleShot;
        public float AngleStep = -1;
        public MeshRenderer TargetRenderer;
        public Material[] RandomMaterials;
        public float MinScale = 1f;
        public float MaxScale = 1f;

        private void OnEnable()
        {
            if (AngleStep < 0)
            {
                MuzzleShot.rotation *= Quaternion.AngleAxis(Random.value * 360f, Vector3.forward);
            }
            else
            {
                MuzzleShot.rotation *= Quaternion.AngleAxis(Random.Range(0, 360) * AngleStep, Vector3.forward);
            }

            if (TargetRenderer != null)
            {
                TargetRenderer.sharedMaterial = RandomMaterials[Random.Range(0, RandomMaterials.Length)];
            }

            transform.localScale *= Random.Range(MinScale, MaxScale);

            Destroy(gameObject, LiveTime);
        }
    }
}
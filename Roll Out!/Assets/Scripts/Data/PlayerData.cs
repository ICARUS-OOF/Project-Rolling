using ProjectRolling.Handlers;
using ProjectRolling.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjectRolling.Data
{
    public class PlayerData : MonoBehaviour, IEntity, IDataReferencable<Material, Texture2D>
    {
        public bool canDamage { get { return _canDamage; } set { _canDamage = value; } }
        [SerializeField] private bool _canDamage;
        public float Health { get { return _Health; } set { _Health = value; } }
        [SerializeField] private float _Health;

        public bool grounded = true;

        public Material objRef { get { return GetComponent<MeshRenderer>().material; } set { GetComponent<MeshRenderer>().material = value; } }
        public GameObject crackParticle;

        float fallDamagePerSecond = 130f;
        float currentFallTime = 0f; 

        float minFallTime = .9f;

        public Transform GroundCheck;

        [SerializeField]
        private float groundDistance = 2f;
        [SerializeField]
        private LayerMask groundLayer;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(GroundCheck.position, groundDistance);
        }

        private void Start()
        {
            Health = 100;
            _canDamage = true;
        }
        private void Update()
        {
            grounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundLayer);
            if (!grounded)
            {
                currentFallTime += Time.deltaTime;
            }
            else
            {
                if (currentFallTime >= minFallTime)
                {
                    Damage((currentFallTime - minFallTime) * fallDamagePerSecond);
                    currentFallTime = 0f;
                }
            }
        }
        public void Damage(float _damage)
        {
            if (!canDamage)
            {
                return;
            }
            GameObject particleInst = Instantiate(crackParticle, transform.position, Quaternion.identity);
            Destroy(particleInst, 1f);
            AudioHandler.singleton.PlaySound("Crack");
            Health -= _damage;
            if (Health <= 70)
            {
                SetObjUtilValue(MainHandler.singleton.cracks);
            }
            else
            {
                SetObjUtilValue(null);
            }
            if (Health <= 0)
            {
                Crack();
            }
        }
        public void SetObjUtilValue(Texture2D _texture2D)
        {
            objRef.mainTexture = _texture2D;
        }
        private void Crack()
        {
            Debug.Log("Player died!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Npc_AI
{
    public class EnemyHealth : CharacterStats, IAttackable

    {
        private Animator animator;
        

        public GameObject healthBarUI;
        public Slider slider;

        protected override void Start()
        {
            animator = GetComponent<Animator>();
            base.Start();
            slider.value = CalculateHealth();
        }

        private void Update()
        {
            slider.value = CalculateHealth();

            if (GetCurrentHealth().GetValue() < GetMaxHealth().GetValue())
            {
                healthBarUI.SetActive(true);
            }
            if (GetCurrentHealth().GetValue() <= 0)
            {
                // Destroy(gameObject);
                animator.enabled = false;
            }
            if (GetCurrentHealth().GetValue() > GetMaxHealth().GetValue())
            {
                GetCurrentHealth().SetValue(GetMaxHealth().GetValue());
            }
        }


        float CalculateHealth()
        {
            return GetCurrentHealth().GetValue() / GetMaxHealth().GetValue();
        }
        //private void OnCollisionEnter(Collision collision)
        //{
        //    if (collision.gameObject.CompareTag("DisableAnimator"))
        //    {
        //        TakeDamage(100); // Decrease the enemy health when collided with the player
        //    }
        //}

        public override void Attacked(GameObject attacker, Attack attack)
        {
            TakeDamage(attacker, attack.Damage);
            if (GetCurrentHealth().GetValue() <= 0)
            {
                OnDeath(attacker);
            }
        }

        protected override void OnDeath(GameObject attacker)
        {
            base.OnDeath(attacker);
            animator.enabled = false;
        }
        void TakeDamage(GameObject attacker, float damage)
        {
            if (damage <= 0f) return;
           // float armor = GetArmor().GetValue();
            //damage -= armor;
            damage = Mathf.Clamp(damage, 0f, float.MaxValue);
            GetCurrentHealth().SetValue(GetCurrentHealth().GetValue() - damage);
            //OnHealthValueChanged?.Invoke();


        }
    }
}

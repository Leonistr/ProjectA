using UnityEngine;

namespace _Root.Scripts.Controllers
{
    public class ContactPoller
    {
        private const float _collisionTresh = 0.5f;
        private ContactPoint2D[] _contactPoints = new ContactPoint2D[10];
        private int _contactsCount;
        private readonly Collider2D _collider;
        
        public bool IsGrounded { get; private set; }
        public bool HasLeftContact { get; private set; }
        public bool HasRightContact { get; private set; }

        public ContactPoller(Collider2D collider)
        {
            _collider = collider;
        }

        public void UpdateContacts()
        {
            IsGrounded = false;
            HasLeftContact = false;
            HasRightContact = false;
            _contactsCount = _collider.GetContacts(_contactPoints);
            for (int i = 0; i < _contactsCount; i++)
            {
                var normal = _contactPoints[i].normal;
                var rigidbody = _contactPoints[i].rigidbody;
                if (normal.y > _collisionTresh)
                {
                    IsGrounded = true;
                }

                if (normal.x > _collisionTresh && rigidbody == null)
                {
                    HasLeftContact = true;
                }

                if (normal.x < -_collisionTresh && rigidbody == null)
                {
                    HasRightContact = true;
                }
            }
        }
    }
}
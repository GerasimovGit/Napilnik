using System;

namespace NapilnikTask01
{
    public class Weapon
    {
        private readonly int _damage;
        private int _bullets;

        public Weapon(int damage, int bullets)
        {
            if (damage <= 0)
                throw new ArgumentOutOfRangeException(nameof(damage));

            if (IsOutOfBullets)
                throw new ArgumentOutOfRangeException(nameof(bullets));

            _damage = damage;
            _bullets = bullets;
        }

        public bool IsOutOfBullets => _bullets <= 0;

        public void Shot(Player player)
        {
            _bullets--;
            player.ApplyDamage(_damage);
        }
    }

    public class Player
    {
        private int _health;

        public Player(int health)
        {
            if (_isDead)
                throw new ArgumentOutOfRangeException(nameof(health));

            _health = health;
        }

        private bool _isDead => _health <= 0;

        public void ApplyDamage(int damage)
        {
            if (_isDead)
                throw new InvalidOperationException();

            if (_health > 0)
                _health -= damage;
        }
    }

    public class Bot
    {
        private readonly Weapon _weapon;

        public Bot(Weapon weapon)
        {
            _weapon = weapon ?? throw new ArgumentNullException(nameof(weapon));
        }

        public void OnSeePlayer(Player player)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            PreparingToShot(player);
        }

        private void PreparingToShot(Player player)
        {
            if (CheckBullets()) return;

            Shot(player);
        }

        private bool CheckBullets()
        {
            if (_weapon.IsOutOfBullets)
                throw new ArgumentOutOfRangeException(nameof(_weapon.IsOutOfBullets));

            return _weapon.IsOutOfBullets;
        }

        private void Shot(Player player)
        {
            _weapon.Shot(player);
        }
    }
}
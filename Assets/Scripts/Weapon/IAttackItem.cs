namespace CorruptedLandTales
{
    public interface IAttackItem
    {
        void Use();
        void Show();
        void Hide();
        void DestroySelf();
        void Initialize(WeaponSO data);

        void UseSkill();
    }
}

namespace Managers
{
    public class CurrencyManager
    {
        public int Currency { get; private set; }

        public void EarnCurrency(int amount)
        {
            Currency += amount;
            // Update UI to show new currency amount
            // ...
        }

        public bool SpendCurrency(int amount)
        {
            if (Currency < amount)
            {
                return false; // Not enough currency to spend
            }

            Currency -= amount;
            // Update UI to show new currency amount
            // ...

            return true;
        }

        public void SetCurrency(int saveDataCurrency) => Currency = saveDataCurrency;
    }
}
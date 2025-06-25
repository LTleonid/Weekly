namespace WinFormsApp3.Items
{
    public class Item
    {
        public required string Name { init; get; } // Название
        protected bool Consumable { get; set; } // Можно ли использовать?

        private int _quantity;
        public int Quantity
        {
            get => _quantity;
            set
            {
                if (value > 0 && value <= Stack)
                {
                    _quantity = value;
                }
            }
        } // Количество

        public int Stack { init; get; } // Макс количество в одном слоте
        protected delegate void ConsumeHandler();
        protected event ConsumeHandler? ConsumeEvent; // Событие на использование
        public required Image? Icon { get; set; } // Иконка предмета

        public virtual void Consume()
        { 
            ConsumeEvent?.Invoke();
        }
    }
}
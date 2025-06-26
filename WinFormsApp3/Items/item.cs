namespace WinFormsApp3.Items
{
    public class Item
    {
        public string Name { init; get; } // ��������
        protected bool Consumable { get; set; } // ����� �� ������������?

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
        } // ����������

        public int Stack { init; get; } // ���� ���������� � ����� �����
        protected delegate void ConsumeHandler();
        protected event ConsumeHandler? ConsumeEvent; // ������� �� �������������
        public Image? Icon { get; set; } // ������ ��������

        public virtual void Consume()
        { 
            ConsumeEvent?.Invoke();
        }
    }
}
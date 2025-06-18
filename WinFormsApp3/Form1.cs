namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Button button1;
        public bool Mdown;
        public bool Mup;
        public bool Mleft;
        public bool Mright;

        bool Mdiagright;
        bool Mdiagleft;
        
        public Form1()
        {
            Mdown = false;
            Mup= false;
            Mleft = false;
            Mright = false;
            InitializeComponent();
            Init();
            this.KeyPreview = true;
            
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Mright = true;
                button1.Location = new Point(button1.Location.X + 1, button1.Location.Y);
            }
            else if (e.KeyCode == Keys.W)
            {
                Mup = true;
                button1.Location = new Point(button1.Location.X, button1.Location.Y - 1);
            }
            else if (e.KeyCode == Keys.S)
            {
                Mdown = true;
                button1.Location = new Point(button1.Location.X, button1.Location.Y + 1);
            }
            else if (e.KeyCode == Keys.A)
            {
                Mleft = true;
                button1.Location = new Point(button1.Location.X - 1, button1.Location.Y);
            }
            base.OnKeyDown(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs eventArgs)
        {
            
            label1.Text = eventArgs.KeyChar.ToString();
            if (Mdown) { button1.Location = new Point(button1.Location.X, button1.Location.Y + 1); }
            if (Mleft) { button1.Location = new Point(button1.Location.X - 1, button1.Location.Y); }
            if (Mright) { button1.Location = new Point(button1.Location.X + 1, button1.Location.Y); }
            if (Mup) { button1.Location = new Point(button1.Location.X, button1.Location.Y - 1); }
            
            base.OnKeyPress(eventArgs);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D)
            {
                Mright = false;
            }
            else if (e.KeyCode == Keys.W)
            {
                Mup = false;
            }
            else if (e.KeyCode == Keys.S)
            {
                Mdown = false;
            }
            else if (e.KeyCode == Keys.A)
            {
                Mleft = false;
            }
            base.OnKeyUp(e);
        }
        public void Init()
        {
            //Создание кнопки
            button1 = new Button();
            button1.Location = new Point(100, 100);
            button1.Name = "";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "";
            button1.UseVisualStyleBackColor = true;

            Controls.Add(button1);
        }

        private void tick_Tick(object sender, EventArgs e)
        {

        }
    }
}

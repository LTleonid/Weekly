namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        Button button1;
        public bool Mdown;
        public bool Mup;
        public bool Mleft;
        public bool Mright;

        public Form1()
        {
            Mdown = false;
            Mup = false;
            Mleft = false;
            Mright = false;
            InitializeComponent();
            Init();
            this.KeyPreview = true;

            
            System.Windows.Forms.Timer movementTimer = new System.Windows.Forms.Timer(); //Пиздец он конфликтует с System.Threads.Timer
            movementTimer.Interval = 10; 
            movementTimer.Tick += MovementTimer_Tick;
            movementTimer.Start();
        }

        private void MovementTimer_Tick(object sender, EventArgs e)
        {
           
            int deltaX = 0, deltaY = 0;

            if (Mright) deltaX += 1;
            if (Mleft) deltaX -= 1;
            if (Mup) deltaY -= 1;
            if (Mdown) deltaY += 1;

            if (deltaX != 0 || deltaY != 0) //Спасаем проц)
            {
                button1.Location = new Point(button1.Location.X + deltaX, button1.Location.Y + deltaY);
            }
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D) Mright = true;
            else if (e.KeyCode == Keys.W) Mup = true;
            else if (e.KeyCode == Keys.S) Mdown = true;
            else if (e.KeyCode == Keys.A) Mleft = true;

            base.OnKeyDown(e);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.D) Mright = false;
            else if (e.KeyCode == Keys.W) Mup = false;
            else if (e.KeyCode == Keys.S) Mdown = false;
            else if (e.KeyCode == Keys.A) Mleft = false;

            base.OnKeyUp(e);
        }

        public void Init()
        {
            
            button1 = new Button();
            button1.Location = new Point(100, 100);
            button1.Name = "";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "";
            button1.UseVisualStyleBackColor = true;

            Controls.Add(button1);
        }
    }
}